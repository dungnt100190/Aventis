using Kiss4Web.DataAccess;
using Kiss4Web.Infrastructure;
using Kiss4Web.Infrastructure.DataAccess;
using Kiss4Web.Infrastructure.DataAccess.Audit;
using Kiss4Web.Infrastructure.DataAccess.Context;
using Kiss4Web.Model.Entities;
using Kiss4Web.TestInfrastructure.Client;
using Kiss4Web.TestInfrastructure.Resources;
using Kiss4Web.TestInfrastructure.TestServer;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Kiss4Web.TestInfrastructure
{
    public class TestDataManager : IDisposable
    {
        private readonly TestServerFixture _integrationTestEnvironment;
        private readonly ConnectionString _connectionString;
        private readonly IDateTimeProvider _dateTimeProvider;

        public TestDataManager(ConnectionString connectionString, IDateTimeProvider dateTimeProvider, TestServerFixture integrationTestEnvironment)
        {
            _connectionString = connectionString;
            _dateTimeProvider = dateTimeProvider;
            _integrationTestEnvironment = integrationTestEnvironment;
        }

        public void Dispose()
        {
            Cleanup();
        }

        /// <summary>
        /// Setup TestDataHandler
        /// </summary>
        public void Setup()
        {
            TestDataPool.TempEntities.Clear();
            TestDataPool.CreatedEntities.Clear();
            TestDataPool.IdentifierLookup.Clear();
            TestDataPool.ReturnData.Clear();
        }

        /// <summary>
        /// Initial client
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public void InitClient(string username, string password)
        {
            TestDataPool.Client = _integrationTestEnvironment.GetClient(username, password).Result;
        }

        /// <summary>
        /// Get value of field id that correspond with input logical name
        /// </summary>
        /// <typeparam name="TEntity">Entity type name</typeparam>
        /// <param name="logicalName">logical name of field id in testcase</param>
        /// <returns></returns>
        public int Lookup<TEntity>(string logicalName)
            where TEntity : class
        {
            var id = TestDataPool.IdentifierLookup.Lookup(typeof(TEntity).Name.Normalize())?.Lookup(logicalName);
            if (id == null)
            {
                throw new KeyNotFoundException($"Logical name {logicalName} not found. Have you set up test data?");
            }

            return id.Value;
        }

        /// <summary>
        /// Create set from table
        /// </summary>
        /// <typeparam name="T">entity type in set</typeparam>
        /// <param name="table"></param>
        /// <param name="fieldMapping">set of field name of given table and field name of entity type</param>
        /// <returns></returns>
        public IEnumerable<T> CreateSetWithLookup<T>(Table table, Dictionary<string, string> fieldMapping = null)
            where T : class
        {
            var entityProperties = typeof(T).GetProperties();
            var properties = table.Header.ToList();
            List<T> result = new List<T>();

            for (var i = 0; i < table.RowCount; i++)
            {
                T entity = Activator.CreateInstance<T>();
                foreach (var prop in properties)
                {
                    var value = table.Rows[i][prop];

                    // Get property
                    var propName = prop;
                    if (fieldMapping != null && fieldMapping.ContainsKey(prop))
                    {
                        propName = fieldMapping[prop];
                    }
                    var property = entityProperties.Where(prp => string.Equals(prp.Name, propName, StringComparison.InvariantCultureIgnoreCase))?.FirstOrDefault();
                    if (property == null) continue;

                    // value is null
                    if (string.Equals(value, "NULL", StringComparison.OrdinalIgnoreCase))
                    {
                        if (property.PropertyType == typeof(string)) property.SetValue(entity, null);
                        continue;
                    }

                    // value contains the logical name of entity (which should already be created)
                    bool isContainsId = false;
                    foreach (var lookup in TestDataPool.IdentifierLookup)
                    {
                        foreach (var item in lookup.Value)
                        {
                            if (value.Contains(item.Key))
                            {
                                isContainsId = true;
                                value = value.Replace(item.Key, item.Value.ToString());
                                if (value.Equals(item.Value.ToString()) && (property.PropertyType == typeof(int) || property.PropertyType == typeof(int?)))
                                {
                                    property.SetValue(entity, item.Value);
                                }
                                else
                                {
                                    property.SetValue(entity, value);
                                }
                            }
                        }
                    }
                    if (isContainsId == true) continue;

                    if (property.PropertyType == typeof(string))
                    {
                        property.SetValue(entity, value);
                        continue;
                    }

                    if (property.PropertyType == typeof(char) || property.PropertyType == typeof(char?))
                    {
                        property.SetValue(entity, char.Parse(value));
                        continue;
                    }

                    if (property.PropertyType == typeof(bool) || property.PropertyType == typeof(bool?))
                    {
                        property.SetValue(entity, value == "1" ? true : false);
                        continue;
                    }

                    if (property.PropertyType == typeof(int) || property.PropertyType == typeof(int?))
                    {
                        property.SetValue(entity, int.Parse(value));
                        continue;
                    }

                    if (property.PropertyType == typeof(double) || property.PropertyType == typeof(double?))
                    {
                        property.SetValue(entity, double.Parse(value));
                        continue;
                    }

                    if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                    {
                        var givenDateInfo = value.Split(' ');
                        string dateFormat = null;
                        string dateValue = value;
                        if (givenDateInfo.Count() > 1
                            && (givenDateInfo[givenDateInfo.Count() - 1].Contains("d")
                                || givenDateInfo[givenDateInfo.Count() - 1].Contains("M")
                                || givenDateInfo[givenDateInfo.Count() - 1].Contains("y")
                                || givenDateInfo[givenDateInfo.Count() - 1].Contains("H")
                                || givenDateInfo[givenDateInfo.Count() - 1].Contains("m")
                                || givenDateInfo[givenDateInfo.Count() - 1].Contains("s")))
                        {
                            dateFormat = givenDateInfo[givenDateInfo.Count() - 1];
                            dateValue = value.Replace(dateFormat, string.Empty).Trim();
                        }
                        DateTime givenDate = DateTime.ParseExact(dateValue, string.IsNullOrEmpty(dateFormat) ? Format.Date : dateFormat, CultureInfo.InvariantCulture);
                        property.SetValue(entity, givenDate);
                        continue;
                    }
                }

                result.Add(entity);
            }

            return result;
        }

        /// <summary>
        /// Insert all row in table to database and add to data pool of TestDataManager
        /// </summary>
        /// <typeparam name="TEntity">name of table in database</typeparam>
        /// <param name="table"></param>
        public void Insert<TEntity>(Table table)
            where TEntity : class
        {
            var entities = table.CreateSet<TEntity>().ToList(); // Assumption: order remains as in the table
            var entityProperties = typeof(TEntity).GetProperties();
            var entityTypeName = typeof(TEntity).Name;
            var entityIdPropertyName = TestDataPool.IdConventionExceptions.Lookup(entityTypeName) ?? $"{entityTypeName}ID"; // convention
            var logicalNameLookup = new Dictionary<object, string>();

            var properties = table.Header.ToList();
            using (var context = _CreateDbContext())
            {
                for (var i = 0; i < table.RowCount; i++)
                {
                    var entity = entities[i];
                    foreach (var prop in properties)
                    {
                        var value = table.Rows[i][prop];

                        // Get property
                        var property = entityProperties.Where(prp => string.Equals(prp.Name, prop, StringComparison.InvariantCultureIgnoreCase))?.FirstOrDefault();
                        if (property == null)
                        {
                            throw new KeyNotFoundException($"Field {prop} is not exists in table {entityTypeName}, please recheck name of this field in file feature");
                        }

                        if (string.Equals(value, "NULL", StringComparison.OrdinalIgnoreCase))
                        {
                            // value of property is null
                            property.SetValue(entity, null);
                            continue;
                        }
                        else if (prop.EndsWith("ID", StringComparison.InvariantCultureIgnoreCase) && !int.TryParse(value, out var id))
                        {
                            // lookup instead of id
                            if (string.Equals(prop, entityIdPropertyName, StringComparison.InvariantCultureIgnoreCase))
                            {
                                // value is the logical name of this entity that will be created
                                logicalNameLookup.Add(entity, value);

                                // determine that key of this entity is not identity => set key value for this new record = key value of last created record + 1
                                if (TestDataPool.NoneIdentityEntities.Contains(entityTypeName))
                                {
                                    var lastRecord = context.Set<TEntity>().OrderByField(prop, false).FirstOrDefault();
                                    int lastRecordId = int.Parse(property.GetValue(lastRecord).ToString());
                                    property.SetValue(entity, lastRecordId + 1);
                                }
                            }
                            else
                            {
                                // value is the logical name of another entity (which should already be created)
                                bool isContainsId = false;
                                foreach (var lookup in TestDataPool.IdentifierLookup)
                                {
                                    foreach (var item in lookup.Value)
                                    {
                                        if (value.Contains(item.Key))
                                        {
                                            isContainsId = true;
                                            property.SetValue(entity, item.Value);
                                        }
                                    }
                                }
                                if (isContainsId == false)
                                {
                                    throw new KeyNotFoundException($"Identifier for {value} is never created, please recheck dummy test data in file feature");
                                }
                            }
                        }
                    }

                    context.Set<TEntity>().Add(entity);
                    context.Entry(entity).State = EntityState.Added;
                    context.SaveChanges();
                }
            }

            // get ids for lookup
            var entityLookup = TestDataPool.IdentifierLookup.LookupAddIfMissing(typeof(TEntity).Name.Normalize(), () => new Dictionary<string, int>());
            foreach (var entity in entities.OfType<IEntity>())
            {
                var logicalName = logicalNameLookup.Lookup(entity);
                if (logicalName != null)
                {
                    entityLookup.Add(logicalName.Normalize(), entity.Id);
                }
            }

            // add created entity to data pool
            var createdEntities = new List<object>();
            foreach (var entity in entities)
            {
                createdEntities.Add(entity);
            }
            TrackEntity<TEntity>(createdEntities);
        }

        /// <summary>
        /// Add records to data pool of TestDataManager
        /// </summary>
        /// <typeparam name="TEntity">name of table in database</typeparam>
        /// <param name="entity"></param>
        public void TrackEntity<TEntity>(List<object> entities)
            where TEntity : class
        {
            var entityTypeName = typeof(TEntity).Name;
            if (TestDataPool.CreatedEntities.ContainsKey(entityTypeName))
            {
                TestDataPool.CreatedEntities[entityTypeName].AddRange(entities);
            }
            else
            {
                TestDataPool.CreatedEntities.Add(entityTypeName, entities);
            }
        }

        /// <summary>
        /// Check record does exists in database or not, if exists then add to data pool of TestDataManager
        /// </summary>
        /// <typeparam name="TEntity">name of table in database</typeparam>
        /// <param name="entity"></param>
        /// <param name="isExists"></param>
        /// <param name="isUpdated">determine that this record is not inserted (just be updated)</param>
        public void CheckEntityExistsInDB<TEntity>(object entity, bool isExists = true, bool isInserted = true)
            where TEntity : class
        {
            bool actual = false;

            var entityTypeName = typeof(TEntity).Name;
            var entityIdPropertyName = TestDataPool.IdConventionExceptions.Lookup(entityTypeName) ?? $"{entityTypeName}ID"; // convention

            StringBuilder sql = new StringBuilder();
            sql.Append($"SELECT {entityIdPropertyName} FROM {entityTypeName} WHERE 1 = 1 ");

            var entityProperties = typeof(TEntity).GetProperties();
            foreach (var property in entityProperties)
            {
                if (property.Name.Equals("Id")) continue;
                if (property.PropertyType == typeof(string))
                {
                    var value = property.GetValue(entity) as string;
                    if (!string.IsNullOrEmpty(value))
                    {
                        sql.Append($"AND {property.Name} = '{value.ToString()}' ");
                    }
                }
                if (property.PropertyType == typeof(char) || property.PropertyType == typeof(char?))
                {
                    var value = property.GetValue(entity) as char?;
                    if (value != null && value.Value != '\0')
                    {
                        sql.Append($"AND {property.Name} = '{value.ToString()}' ");
                    }
                }
                if (property.PropertyType == typeof(bool) || property.PropertyType == typeof(bool?))
                {
                    var value = property.GetValue(entity) as bool?;
                    if (value != null)
                    {
                        sql.Append($"AND {property.Name} = " + (value.Value == true ? 1 : 0).ToString());
                    }
                }
                if (property.PropertyType == typeof(int) || property.PropertyType == typeof(int?))
                {
                    var value = property.GetValue(entity) as int?;
                    if (value != null && value.Value != 0)
                    {
                        sql.Append($"AND {property.Name} = {value.ToString()} ");
                    }
                }
                if (property.PropertyType == typeof(double) || property.PropertyType == typeof(double?))
                {
                    var value = property.GetValue(entity) as double?;
                    if (value != null && value.Value != 0)
                    {
                        sql.Append($"AND {property.Name} = {value.ToString()} ");
                    }
                }
                if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                {
                    var value = property.GetValue(entity) as DateTime?;
                    if (value != null && value.Value.Year != 1)
                    {
                        sql.Append($"AND {property.Name} = '{value.Value.ToString("yyyy-MM-dd HH:mm:ss.fff")}' ");
                    }
                }
            }
            sql.Append(";");

            List<int> dbEntities = new List<int>();
            var context = _CreateDbContext();
            var command = context.Database.GetDbConnection().CreateCommand();
            command.CommandText = sql.ToString();
            context.Database.OpenConnection();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                dbEntities.Add(reader.GetInt32(0));
            }

            if (dbEntities != null && dbEntities.Count > 0)
            {
                actual = true;
                if (isInserted)
                {
                    var createdEntities = new List<object>();
                    foreach (int id in dbEntities)
                    {
                        object dbEntity = Activator.CreateInstance<TEntity>();
                        var idProperty = entityProperties.First(prp => string.Equals(prp.Name, entityIdPropertyName, StringComparison.InvariantCultureIgnoreCase));
                        idProperty.SetValue(dbEntity, id);
                        createdEntities.Add(dbEntity);
                    }
                    TrackEntity<TEntity>(createdEntities);
                }
            }

            actual.ShouldBe(isExists, "should be " + (isExists ? "exists" : "not exists") + ", but was " + (actual ? "exists" : "not exists"));
        }

        /// <summary>
        /// Check added or updated Record exists in database, if exists then add to data pool
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="isExists"></param>
        /// <param name="isInserted"></param>
        public void CheckAddUpdateEntityExistsInDB<TEntity>(bool isExists = true, bool isInserted = true)
            where TEntity : class
        {
            foreach (var entity in TestDataPool.TempEntities)
            {
                CheckEntityExistsInDB<TEntity>(entity, isExists, isInserted);
            }

        }

        /// <summary>
        /// Add the added or updated Record to Temporary Entities Pool in data pool
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="givenData"></param>
        /// <param name="fieldMapping"></param>
        public void AddToTempEntities<TEntity>(Table table, Dictionary<string, string> fieldMapping = null)
            where TEntity : class
        {
            TestDataPool.TempEntities.AddRange(CreateSetWithLookup<TEntity>(table, fieldMapping: fieldMapping));
        }

        /// <summary>
        /// Call API of type GET return single object
        /// </summary>
        /// <typeparam name="TResult">type of return data</typeparam>
        /// <param name="url">url of API</param>
        /// <param name="parameters">additional input parameters</param>
        public void CallApiGetReturnObject<TResult>(string url, object parameters = null, bool isAddToResult = true)
        {
            var result = TestDataPool.Client.GetAsJsonAsync<TResult>(url, parameters).Result;
            TestDataPool.CallResult = result;
            if (result.Result != null && isAddToResult == true)
            {
                TestDataPool.ReturnData.Add(result.Result);
            }
        }

        /// <summary>
        /// Call API of type GET return list object
        /// </summary>
        /// <typeparam name="TResult">type of return data</typeparam>
        /// <param name="url">url of API</param>
        /// <param name="parameters">additional input parameters</param>
        public void CallApiGetReturnList<TResult>(string url, object parameters = null, bool isAddToResult = true)
        {
            var result = TestDataPool.Client.GetAsJsonAsync<IEnumerable<TResult>>(url, parameters).Result;
            TestDataPool.CallResult = result;
            if (result.Result != null && result.Result.Count() > 0 && isAddToResult == true)
            {
                foreach (var item in result.Result.ToList())
                {
                    TestDataPool.ReturnData.Add(item);
                }
            }
        }

        /// <summary>
        /// Call API of type POST return single object
        /// </summary>
        /// <typeparam name="TInput">type of input data</typeparam>
        /// <typeparam name="TResult">type of return data</typeparam>
        /// <param name="url">url of API</param>
        /// <param name="input">input data</param>
        /// <param name="parameters">additional input parameters</param>
        public void CallApiPostReturnObject<TInput, TResult>(string url, TInput input, object parameters = null, bool isAddToResult = true)
        {
            var callResult = TestDataPool.Client.PostAsJsonAsync<TInput, TResult>(url, value: input, parameters: parameters).Result as ServiceResult<TResult>;
            TestDataPool.CallResult = callResult;

            var result = callResult as ServiceResult<TResult>;
            if (result != null && isAddToResult == true)
            {
                TestDataPool.ReturnData.Add(result.Result);
            }
        }

        /// <summary>
        /// Call API of type POST return list object
        /// </summary>
        /// <typeparam name="TInput">type of input data</typeparam>
        /// <typeparam name="TResult">type of return data</typeparam>
        /// <param name="url">url of API</param>
        /// <param name="input">input data</param>
        /// <param name="parameters">additional input parameters</param>
        public void CallApiPostReturnList<TInput, TResult>(string url, TInput input, object parameters = null, bool isAddToResult = true)
        {
            var callResult = TestDataPool.Client.PostAsJsonAsync<TInput, IEnumerable<TResult>>(url, value: input, parameters: parameters).Result;
            TestDataPool.CallResult = callResult;

            var result = callResult as ServiceResult<IEnumerable<TResult>>;
            if (result != null && isAddToResult == true)
            {
                foreach (var item in result.Result.ToList())
                {
                    TestDataPool.ReturnData.Add(item);
                }
            }
        }

        /// <summary>
        /// Call API of type POST no return data
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <param name="url">url of API</param>
        /// <param name="input">input data</param>
        /// <param name="parameters">additional input parameters</param>
        public void CallApiPostNoReturn<TInput>(string url, TInput input, object parameters = null)
        {
            TestDataPool.CallResult = TestDataPool.Client.PostAsJsonAsync<TInput>(url, value: input, parameters: parameters).Result;
        }

        /// <summary>
        /// Call API of type PUT no return data
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <param name="url">url of API</param>
        /// <param name="input">input data</param>
        /// <param name="parameters">additional input parameters</param>
        public void CallApiPutNoReturn<TInput>(string url, TInput input, object parameters = null)
        {
            TestDataPool.CallResult = TestDataPool.Client.PutAsJsonAsync<TInput>(url, value: input, parameters: parameters).Result;
        }

        /// <summary>
        /// Check return status of the call API
        /// </summary>
        /// <param name="isSuccess">default is true (success)</param>
        public void CheckCallApiStatus(bool isSuccess = true)
        {
            if (TestDataPool.CallResult != null)
            {
                if (isSuccess)
                {
                    TestDataPool.CallResult.IsSuccess.ShouldBeTrue(TestDataPool.CallResult.Error);
                }
                else
                {
                    TestDataPool.CallResult.IsSuccess.ShouldBeFalse(TestDataPool.CallResult.Error);
                }
            }
            else
            {
                throw new NullReferenceException("the call result is null, must implement calling at least one API");
            }
        }

        /// <summary>
        /// Check return data of the call API
        /// </summary>
        /// <typeparam name="T">type of element in actual data</typeparam>
        /// <param name="expectedData">expected data</param>
        /// <param name="fieldMapping">set of field name of given expected data table and field name of actual data type</param>
        public void CheckCallApiReturnData<T>(Table expectedData, Dictionary<string, string> fieldMapping = null)
            where T : class
        {
            var actualData = ConvertListType<T>(TestDataPool.ReturnData);
            CheckReturnData<T>(actualData, expectedData, fieldMapping);
        }

        /// <summary>
        /// Check data of an object or list object
        /// </summary>
        /// <typeparam name="T">type of element in actual data</typeparam>
        /// <param name="actualData">actual data</param>
        /// <param name="expectedData">expected data</param>
        /// <param name="fieldMapping">set of field name of given expected data table and field name of actual data type</param>
        public void CheckReturnData<T>(List<T> actualData, Table expectedData, Dictionary<string, string> fieldMapping = null)
            where T : class
        {
            actualData.ShouldNotBeNull();
            actualData.ShouldNotBeEmpty();

            var expected = CreateSetWithLookup<T>(expectedData, fieldMapping).ToList();
            actualData.ShouldBePartially(expected, expectedData.Header);
        }

        /// <summary>
        /// Check return value of the call API
        /// </summary>
        /// <param name="expected"></param>
        public void CheckCallApiReturnValue(object expected)
        {
            CheckReturnValue(TestDataPool.ReturnData[0], expected);
        }

        /// <summary>
        /// Check value of primitive type
        /// </summary>
        /// <param name="actual">actual value</param>
        /// <param name="expected">expected value</param>
        public void CheckReturnValue(object actual, object expected)
        {
            var actualValue = actual != null ? actual.ToString() : "null";
            var expectedValue = expected != null ? expected.ToString() : "null";
            actualValue.ShouldBe(expectedValue, $"should be {expectedValue}, but was {actualValue}");
        }

        /// <summary>
        /// Delete all records of tables in database that correspond with records in data pool 
        /// and clear data pool 
        /// </summary>
        public void Cleanup()
        {
            if (TestDataPool.CreatedEntities.Count > 0)
            {
                var context = _CreateDbContext();
                for (int i = TestDataPool.CreatedEntities.Count - 1; i >= 0; --i)
                {
                    var entityTypeName = TestDataPool.CreatedEntities.ElementAt(i).Key;
                    foreach (var entity in TestDataPool.CreatedEntities.ElementAt(i).Value)
                    {
                        string entityIdPropertyName = TestDataPool.IdConventionExceptions.Lookup(entityTypeName) ?? $"{entityTypeName}ID";
                        var entityProperties = entity.GetType().GetProperties();
                        var idProperty = entityProperties.First(prp => string.Equals(prp.Name, entityIdPropertyName, StringComparison.InvariantCultureIgnoreCase));
                        var value = idProperty.GetValue(entity);

                        string sql = $"DELETE {entityTypeName} WHERE {entityIdPropertyName} = {value};";

                        context.Entry(entity).State = EntityState.Deleted;
                        context.ExecuteSqlCommand(sql);
                    }
                }
            }
            TestDataPool.TempEntities.Clear();
            TestDataPool.CreatedEntities.Clear();
            TestDataPool.IdentifierLookup.Clear();
            TestDataPool.ReturnData.Clear();
        }

        private static string GetEntityNameFromHeader(string idProperty)
        {
            var exception = TestDataPool.IdConventionExceptions.Where(kvp => string.Equals(kvp.Value, idProperty, StringComparison.InvariantCultureIgnoreCase))
                                                  .Select(kvp => kvp.Key)
                                                  .FirstOrDefault();
            return (exception ?? idProperty.Substring(0, idProperty.Length - 2)).Normalize();
        }

        private Kiss4DbContext _CreateDbContext()
        {
            var options = new DbContextOptionsBuilder();
            options.UseSqlServer(_connectionString);
            var ccmmAuditor = new CcmmAuditor("Test API runner", _dateTimeProvider);
            var historyAuditor = new HistoryVersionCreator("Test API runner");
            return new Kiss4DbContext(options.Options, new IDbChangeAuditor[] { ccmmAuditor, historyAuditor });
        }

        private static List<T> ConvertListType<T>(List<object> inputList)
            where T : class
        {
            List<T> outputList = new List<T>();
            foreach (var item in inputList)
            {
                outputList.Add(item as T);
            }
            return outputList;
        }

    }
}