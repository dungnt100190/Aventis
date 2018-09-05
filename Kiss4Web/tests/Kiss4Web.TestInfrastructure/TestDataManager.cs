using Kiss4Web.DataAccess;
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
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Kiss4Web.TestInfrastructure
{
    public static class TestDataManager
    {
        private static readonly IDictionary<string, string> _IdConventionExceptions = new Dictionary<string, string>
        {
            {"XUser", "UserID"},
            {"XUserGroup", "UserGroupID"},
            {"XRight", "RightID"},
            {"XModul", "ModulID"},
        };

        private static readonly List<string> _NoneIdentityEntities = new List<string>
        {
            "XModul"
        };

        public static HttpClient Client { get; private set; }
        public static List<object> TempAddedEntities { get; private set; } = new List<object>();

        private static readonly IDictionary<string, List<object>> _createdEntities = new Dictionary<string, List<object>>();
        private static readonly IDictionary<string, IDictionary<string, int>> _identifierLookup = new Dictionary<string, IDictionary<string, int>>();
        private static readonly TestServerFixture _integrationTestEnvironment = new TestServerFixture();

        private static IServiceResult _callResult;
        private static List<object> _returnData;

        /// <summary>
        /// Setup TestDataManager
        /// </summary>
        public static void Setup()
        {
            Client = null;
            TempAddedEntities.Clear();
            _createdEntities.Clear();
            _identifierLookup.Clear();
            _callResult = null;
            _returnData = new List<object>();
        }

        /// <summary>
        /// Get value of field id that correspond with input logical name
        /// </summary>
        /// <typeparam name="TEntity">Entity type name</typeparam>
        /// <param name="logicalName">logical name of field id in testcase</param>
        /// <returns></returns>
        public static int Lookup<TEntity>(string logicalName)
            where TEntity : class
        {
            var id = _identifierLookup.Lookup(typeof(TEntity).Name.Normalize())?.Lookup(logicalName);
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
        /// <param name="idFieldMapping">set of field name of given table and ID field name of table in database that it’s data refer to</param>
        /// <returns></returns>
        public static IEnumerable<T> CreateSetWithLookup<T>(Table table, Dictionary<string, string> fieldMapping = null, Dictionary<string, string> idFieldMapping = null)
            where T : class
        {
            var properties = table.Header.ToList();
            foreach (var prop in properties)
            {
                if (fieldMapping != null && fieldMapping.ContainsKey(prop))
                {
                    table.RenameColumn(prop, fieldMapping[prop]);
                }
            }

            properties = table.Header.ToList();
            var entities = table.CreateSet<T>().ToList();
            var result = new List<T>();

            for (var i = 0; i < table.RowCount; i++)
            {
                var entity = entities[i];
                foreach (var prop in properties)
                {
                    var value = table.Rows[i][prop];

                    var property = typeof(T).GetProperty(prop);
                    if (property == null) continue;

                    if (string.Equals(value, "NULL", StringComparison.OrdinalIgnoreCase))
                    {
                        // value of property is null
                        property.SetValue(entity, null);
                    }
                    else
                    {
                        string refFieldName = null;
                        if (prop.EndsWith("ID", StringComparison.InvariantCultureIgnoreCase) && !int.TryParse(value, out var id1))
                        {
                            refFieldName = prop;
                        }
                        if (idFieldMapping != null && idFieldMapping.ContainsKey(prop) && !int.TryParse(value, out var id2))
                        {
                            refFieldName = idFieldMapping[prop];
                        }

                        if (!string.IsNullOrEmpty(refFieldName))
                        {
                            // value is the logical name of entity (which should already be created)
                            var refEntityName = GetEntityNameFromHeader(refFieldName);
                            var lookup = _identifierLookup.Lookup(refEntityName);
                            foreach (var item in lookup)
                            {
                                if (value.Contains(item.Key))
                                {
                                    value = value.Replace(item.Key, item.Value.ToString());
                                }
                            }
                            property.SetValue(entity, value);
                        }
                        else if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                        {
                            var givenDateInfo = value.Split(' ');
                            string dateFormat = null;
                            if (givenDateInfo.Count() > 1) dateFormat = givenDateInfo[1];
                            DateTime givenDate = DateTime.ParseExact(givenDateInfo[0], string.IsNullOrEmpty(dateFormat) ? Format.Date : dateFormat, CultureInfo.InvariantCulture);
                            property.SetValue(entity, givenDate);
                        }
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
        /// <param name="idFieldMapping">set of field name of this table and ID field name of other table that it’s data refer to</param>
        /// <param name="isView">this table is View in database</param>
        public static void Insert<TEntity>(Table table, Dictionary<string, string> idFieldMapping = null, bool isView = false)
            where TEntity : class
        {
            var entities = table.CreateSet<TEntity>().ToList(); // Assumption: order remains as in the table
            var entityProperties = typeof(TEntity).GetProperties();
            var entityTypeName = typeof(TEntity).Name;
            var entityIdPropertyName = _IdConventionExceptions.Lookup(entityTypeName) ?? $"{entityTypeName}ID"; // convention
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
                        var property = entityProperties.First(prp => string.Equals(prp.Name, prop, StringComparison.InvariantCultureIgnoreCase));
                        if (string.Equals(value, "NULL", StringComparison.OrdinalIgnoreCase))
                        {
                            // value of property is null
                            property.SetValue(entity, null);
                        }
                        else if (prop.EndsWith("ID", StringComparison.InvariantCultureIgnoreCase) && !int.TryParse(value, out var id))
                        {
                            // lookup instead of id
                            if (string.Equals(prop, entityIdPropertyName, StringComparison.InvariantCultureIgnoreCase) && !isView)
                            {
                                // value is the logical name of this entity that will be created
                                logicalNameLookup.Add(entity, value);

                                // determine that key of this entity is not identity => set key value for this new record = key value of last created record + 1
                                object[] attrs = typeof(TEntity).GetProperty(prop).GetCustomAttributes(true);
                                foreach (object attr in attrs)
                                {
                                    DatabaseGeneratedAttribute dbGenAttr = attr as DatabaseGeneratedAttribute;
                                    if (dbGenAttr != null && dbGenAttr.DatabaseGeneratedOption == DatabaseGeneratedOption.None)
                                    {
                                        var lastRecord = context.Set<TEntity>().OrderByField(prop, false).FirstOrDefault();
                                        int lastRecordId = int.Parse(property.GetValue(lastRecord).ToString());
                                        property.SetValue(entity, lastRecordId + 1);
                                    }
                                }
                            }
                            else
                            {
                                // value is the logical name of another entity (which should already be created)
                                var refFieldName = prop;
                                if (idFieldMapping != null && idFieldMapping.ContainsKey(prop))
                                {
                                    refFieldName = idFieldMapping[prop];
                                }
                                var refEntityName = GetEntityNameFromHeader(refFieldName);
                                var lookup = _identifierLookup[refEntityName];
                                var referencedEntityId = lookup[value.Normalize()];
                                property.SetValue(entity, referencedEntityId);
                            }
                        }
                    }

                    context.Add(entity);
                }
            }

            // get ids for lookup & add created entity to data pool
            var entityLookup = _identifierLookup.LookupAddIfMissing(typeof(TEntity).Name.Normalize(), () => new Dictionary<string, int>());
            var createdEntities = new List<object>();
            foreach (var entity in entities.OfType<IEntity>())
            {
                createdEntities.Add(entity);
                var logicalName = logicalNameLookup.Lookup(entity);
                if (logicalName != null)
                {
                    entityLookup.Add(logicalName.Normalize(), entity.Id);
                }
            }
            TrackEntity<TEntity>(createdEntities);
        }

        /// <summary>
        /// Add records to data pool of TestDataManager
        /// </summary>
        /// <typeparam name="TEntity">name of table in database</typeparam>
        /// <param name="entity"></param>
        public static void TrackEntity<TEntity>(List<object> entities)
            where TEntity : class
        {
            var entityTypeName = typeof(TEntity).Name;
            if (_createdEntities.ContainsKey(entityTypeName))
            {
                _createdEntities[entityTypeName].AddRange(entities);
            }
            else
            {
                _createdEntities.Add(entityTypeName, entities);
            }
        }

        /// <summary>
        /// Check record does exists in database or not, if exists then add to data pool of TestDataManager
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="isExists"></param>
        public static void CheckEntityExistsInDB<TEntity>(object entity, bool isExists = true)
            where TEntity : class
        {
            bool actual = false;

            var entityTypeName = typeof(TEntity).Name;
            var entityIdPropertyName = _IdConventionExceptions.Lookup(entityTypeName) ?? $"{entityTypeName}ID"; // convention

            StringBuilder sql = new StringBuilder();
            sql.Append($"SELECT {entityIdPropertyName} FROM {entityTypeName} WHERE 1 = 1 ");

            var entityProperties = entity.GetType().GetProperties();
            foreach (var property in entityProperties)
            {
                if (property.PropertyType == typeof(string))
                {
                    var value = property.GetValue(entity);
                    if (value != null && !string.IsNullOrEmpty(value.ToString()))
                    {
                        sql.Append($"AND {property.Name} = '{value.ToString()}' ");
                    }
                }
                if (property.PropertyType == typeof(int) || property.PropertyType == typeof(int?))
                {
                    var value = property.GetValue(entity);
                    if (value != null && !string.IsNullOrEmpty(value.ToString()) && int.Parse(value.ToString()) != 0)
                    {
                        sql.Append($"AND {property.Name} = {value.ToString()} ");
                    }
                }
                if (property.PropertyType == typeof(double) || property.PropertyType == typeof(double?))
                {
                    var value = property.GetValue(entity);
                    if (value != null && !string.IsNullOrEmpty(value.ToString()) && double.Parse(value.ToString()) != 0)
                    {
                        sql.Append($"AND {property.Name} = {value.ToString()} ");
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
                var createdEntities = new List<object>();
                foreach (int id in dbEntities)
                {
                    object dbEntity = Activator.CreateInstance<TEntity>();
                    dbEntity.GetType().GetProperty(entityIdPropertyName).SetValue(dbEntity, id);
                    createdEntities.Add(dbEntity);
                }
                TrackEntity<TEntity>(createdEntities);
            }

            actual.ShouldBe(isExists, "should be " + (isExists ? "exists" : "not exists") + ", but was " + (actual ? "exists" : "not exists"));
        }

        /// <summary>
        /// Initial client
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static void InitClient(string username, string password)
        {
            Client = _integrationTestEnvironment.GetClient(username, password).Result;
        }

        /// <summary>
        /// Call API of type GET
        /// </summary>
        /// <typeparam name="TResult">type of return data</typeparam>
        /// <param name="url">url of API</param>
        /// <param name="parameters">additional input parameters</param>
        public static void CallApiGet<TResult>(string url, object parameters = null, bool isAddToResult = true)
        {
            var result = Client.GetAsJsonAsync<IEnumerable<TResult>>(url, parameters).Result;
            _callResult = result;
            if (isAddToResult == true)
            {
                foreach (var item in result.Result.ToList())
                {
                    _returnData.Add(item);
                }
            }
        }

        /// <summary>
        /// Call API of type POST
        /// </summary>
        /// <typeparam name="TInput">type of input data</typeparam>
        /// <typeparam name="TResult">type of return data</typeparam>
        /// <param name="url">url of API</param>
        /// <param name="input">input data</param>
        /// <param name="parameters">additional input parameters</param>
        public static void CallApiPost<TInput, TResult>(string url, TInput input, object parameters = null, bool isAddToResult = true)
        {
            var result = Client.PostAsJsonAsync<TInput, TResult>(url, value: input, parameters: parameters).Result as ServiceResult<TResult>;
            _callResult = result;
            if (isAddToResult == true)
            {
                _returnData.Add(result.Result);
            }
        }

        /// <summary>
        /// Call API of type POST no return data
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <param name="url">url of API</param>
        /// <param name="input">input data</param>
        /// <param name="parameters">additional input parameters</param>
        public static void CallApiPostNoReturn<TInput>(string url, TInput input, object parameters = null)
        {
            _callResult = Client.PostAsJsonAsync<TInput>(url, value: input, parameters: parameters).Result;
        }

        /// <summary>
        /// Call API of type PUT no return data
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <param name="url">url of API</param>
        /// <param name="input">input data</param>
        /// <param name="parameters">additional input parameters</param>
        public static void CallApiPutNoReturn<TInput>(string url, TInput input, object parameters = null)
        {
            _callResult = Client.PutAsJsonAsync<TInput>(url, value: input, parameters: parameters).Result;
        }

        /// <summary>
        /// Check return status of the call API
        /// </summary>
        /// <param name="isSuccess">default is true (success)</param>
        public static void CheckCallApiStatus(bool isSuccess = true)
        {
            if (_callResult != null)
            {
                if (isSuccess)
                {
                    _callResult.IsSuccess.ShouldBeTrue(_callResult.Error);
                }
                else
                {
                    _callResult.IsSuccess.ShouldBeFalse(_callResult.Error);
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
        /// <typeparam name="T"></typeparam>
        /// <param name="expectedData"></param>
        /// <param name="fieldMapping"></param>
        /// <param name="idFieldMapping"></param>
        public static void CheckCallApiReturnData<T>(Table expectedData, Dictionary<string, string> fieldMapping = null, Dictionary<string, string> idFieldMapping = null)
            where T : class
        {
            var actualData = ConvertListType<T>(_returnData);
            CheckReturnData<T>(actualData, expectedData, fieldMapping, idFieldMapping);
        }

        /// <summary>
        /// Check data of an object or list object
        /// </summary>
        /// <typeparam name="T">type of element in actual data</typeparam>
        /// <param name="actualData">actual data</param>
        /// <param name="expectedData">expected data</param>
        /// <param name="fieldMapping">set of field name of given expected data table and field name of actual data type</param>
        /// <param name="idFieldMapping">set of field name of given expected data table and ID field name of table in database that it’s data refer to</param>
        public static void CheckReturnData<T>(List<T> actualData, Table expectedData, Dictionary<string, string> fieldMapping = null, Dictionary<string, string> idFieldMapping = null)
            where T : class
        {
            actualData.ShouldNotBeNull();
            actualData.ShouldNotBeEmpty();

            var expected = CreateSetWithLookup<T>(expectedData, fieldMapping, idFieldMapping).ToList();
            actualData.ShouldBePartially(expected, expectedData.Header);
        }

        /// <summary>
        /// Check return value of the call API
        /// </summary>
        /// <param name="expected"></param>
        public static void CheckCallApiReturnValue(object expected)
        {
            CheckReturnValue(_returnData[0], expected);
        }

        /// <summary>
        /// Check value of primitive type
        /// </summary>
        /// <param name="actual">actual value</param>
        /// <param name="expected">expected value</param>
        public static void CheckReturnValue(object actual, object expected)
        {
            var actualValue = actual != null ? actual.ToString() : "null";
            var expectedValue = expected != null ? expected.ToString() : "null";
            actualValue.ShouldBe(expectedValue, $"should be {expectedValue}, but was {actualValue}");
        }

        /// <summary>
        /// Delete all records of tables in database that correspond with records in data pool of TestDataManager 
        /// and close driver and clear data pool of TestDataManager 
        /// </summary>
        public static void Cleanup()
        {
            if (_createdEntities.Count > 0)
            {
                var context = _CreateDbContext();
                for (int i = _createdEntities.Count - 1; i >= 0; --i)
                {
                    var entityTypeName = _createdEntities.ElementAt(i).Key;
                    foreach (var entity in _createdEntities.ElementAt(i).Value)
                    {
                        string entityIdPropertyName = _IdConventionExceptions.Lookup(entityTypeName) ?? $"{entityTypeName}ID";
                        var value = entity.GetType().GetProperty(entityIdPropertyName).GetValue(entity);

                        string sql = $"DELETE {entityTypeName} WHERE {entityIdPropertyName} = {value};";

                        context.Entry(entity).State = EntityState.Deleted;
                        context.ExecuteSqlCommand(sql);
                    }
                }
            }
            TempAddedEntities.Clear();
            _createdEntities.Clear();
            _identifierLookup.Clear();
            _callResult = null;
            _returnData.Clear();
        }

        private static string GetEntityNameFromHeader(string idProperty)
        {
            var exception = _IdConventionExceptions.Where(kvp => kvp.Value == idProperty)
                                                  .Select(kvp => kvp.Key)
                                                  .FirstOrDefault();
            return (exception ?? idProperty.Substring(0, idProperty.Length - 2)).Normalize();
        }

        private static Kiss4DbContext _CreateDbContext()
        {
            var options = new DbContextOptionsBuilder();
            options.UseSqlServer(_integrationTestEnvironment.ConnectionString);
            var ccmmAuditor = new CcmmAuditor("Test runner", _integrationTestEnvironment.DateTime);
            var historyAuditor = new HistoryVersionCreator("Test runner");
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
