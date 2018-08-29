using Kiss4Web.Resource;
using Kiss4Web.Test.DataAccess;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Kiss4Web.Test.TestInfrastructure
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

        public static IWebDriver Driver { get; private set; }
        private static readonly List<object> _createdEntities = new List<object>();
        private static readonly List<string> _createdEntityTypes = new List<string>();
        private static readonly IDictionary<string, IDictionary<string, int>> _identifierLookup = new Dictionary<string, IDictionary<string, int>>();

        public static void Setup()
        {
            Driver = null;
            _createdEntities.Clear();
            _createdEntityTypes.Clear();
            _identifierLookup.Clear();
        }

        /// <summary>
        /// Get value of field id that correspond with input logical name
        /// </summary>
        /// <typeparam name="TEntity">Entity type name</typeparam>
        /// <param name="logicalName">logical name of field id in testcase</param>
        /// <returns></returns>
        public static int Lookup<TEntity>(string logicalName)
        {
            var id = _identifierLookup.Lookup(typeof(TEntity).Name.Normalize())?.Lookup(logicalName);
            if (id == null)
            {
                throw new KeyNotFoundException($"Logical name {logicalName} not found. Have you set up test data?");
            }

            return id.Value;
        }

        /// <summary>
        /// Create set from data table
        /// </summary>
        /// <typeparam name="T">Type name of element in set</typeparam>
        /// <param name="table">Data table</param>
        /// <param name="refFieldMapping">set of field name of this table and field name of table in database that it’s data refer to</param>
        /// <returns></returns>
        public static IEnumerable<T> CreateSetWithLookup<T>(Table table, Dictionary<string, string> refFieldMapping = null) where T : class
        {
            var entities = table.CreateSet<T>().ToList();
            var properties = table.Header.ToList();
            var entityProperties = typeof(T).GetProperties();
            var result = new List<T>();

            for (var i = 0; i < table.RowCount; i++)
            {
                var entity = entities[i];
                foreach (var prop in properties)
                {
                    var value = table.Rows[i][prop];
                    // Get property in T by property name
                    var property = entityProperties.First(prp => string.Equals(prp.Name, prop, StringComparison.InvariantCultureIgnoreCase));
                    // Get property in T by name of attribute Display
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
                        if (refFieldMapping != null && refFieldMapping.ContainsKey(prop) && !int.TryParse(value, out var id2))
                        {
                            refFieldName = refFieldMapping[prop];
                        }

                        // value is the logical name of entity (which should already be created)
                        if (!string.IsNullOrEmpty(refFieldName))
                        {
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
                    }
                }

                result.Add(entity);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        //public static TEntity GetLastRecord<TEntity>() where TEntity : class
        //{
        //    var entityTypeName = typeof(TEntity).Name;
        //    var entityIdPropertyName = _IdConventionExceptions.Lookup(entityTypeName) ?? $"{entityTypeName}ID"; // convention
        //    object[] attrs = typeof(TEntity).GetProperty(entityIdPropertyName).GetCustomAttributes(true);
        //    foreach (object attr in attrs)
        //    {
        //        KeyAttribute keyAttr = attr as KeyAttribute;
        //        if (keyAttr != null)
        //        {
        //            var repository = new EntityRepository<TEntity>(_CreateDbContext());
        //            var lastRecord = repository.GetAll().OrderByField(entityIdPropertyName, false).FirstOrDefault();
        //            return lastRecord;
        //        }
        //    }
        //    return null;
        //}

        /// <summary>
        /// Insert all row in table to database and add to data pool of TestDataManager
        /// </summary>
        /// <typeparam name="TEntity">name of table in database</typeparam>
        /// <param name="table"></param>
        /// <param name="refFieldMapping">set of field name of this table and field name of other table that it’s data refer to</param>
        /// <param name="isView">this table is View in database</param>
        public static void Insert<TEntity>(Table table, Dictionary<string, string> refFieldMapping = null, bool isView = false) where TEntity : class
        {
            var entities = table.CreateSet<TEntity>().ToList(); // Assumption: order remains as in the table
            var properties = table.Header.ToList();
            var entityProperties = typeof(TEntity).GetProperties();
            var entityTypeName = typeof(TEntity).Name;
            var entityIdPropertyName = _IdConventionExceptions.Lookup(entityTypeName) ?? $"{entityTypeName}ID"; // convention
            var logicalNameLookup = new Dictionary<object, string>();

            using (var context = _CreateDbContext())
            {
                var repository = new EntityRepository<TEntity>(context);
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
                                        var lastRecord = repository.GetAll().OrderByField(prop, false).FirstOrDefault();
                                        int lastRecordId = int.Parse(property.GetValue(lastRecord).ToString());
                                        property.SetValue(entity, lastRecordId + 1);
                                    }
                                }
                            }
                            else
                            {
                                // value is the logical name of another entity (which should already be created)
                                var refFieldName = prop;
                                if (refFieldMapping != null && refFieldMapping.ContainsKey(prop))
                                {
                                    refFieldName = refFieldMapping[prop];
                                }
                                var refEntityName = GetEntityNameFromHeader(refFieldName);
                                var lookup = _identifierLookup[refEntityName];
                                var referencedEntityId = lookup[value.Normalize()];
                                property.SetValue(entity, referencedEntityId);
                            }
                        }
                    }

                    repository.Insert(entity);
                    _createdEntityTypes.Add(entity.GetType().Name);
                }
            }

            // get ids for lookup
            var entityLookup = _identifierLookup.LookupAddIfMissing(typeof(TEntity).Name.Normalize(), () => new Dictionary<string, int>());
            foreach (var entity in entities.OfType<IEntity>())
            {
                var logicalName = logicalNameLookup.Lookup(entity);
                if (logicalName != null)
                {
                    entityLookup.Add(logicalName.Normalize(), entity.Id);
                }
            }

            _createdEntities.AddRange(entities);
        }

        /// <summary>
        /// Find records by value of one or some field of that entity type, and add these records to data pool of TestDataManager
        /// </summary>
        /// <typeparam name="TEntity">name of table in database</typeparam>
        /// <param name="fieldData">set of field name and corresponding value</param>
        public static void TrackEntity<TEntity>(Dictionary<string, object> fieldData) where TEntity : class
        {
            var entityTypeName = typeof(TEntity).Name;

            StringBuilder sql = new StringBuilder();
            sql.Append($"SELECT * FROM {entityTypeName} WHERE 1 = 1 ");

            foreach (var item in fieldData)
            {
                if (item.Value.GetType() == typeof(string))
                {
                    sql.Append($"AND {item.Key} = '{item.Value}' ");
                }
                if (item.Value.GetType() == typeof(int) || item.Value.GetType() == typeof(double))
                {
                    sql.Append($"AND {item.Key} = {item.Value} ");
                }
            }

            var context = _CreateDbContext();
            var entities = context.Database.SqlQuery<TEntity>(sql.ToString());
            _createdEntities.AddRange(entities);

            if (!_createdEntityTypes.Contains(entityTypeName))
            {
                _createdEntityTypes.Add(entityTypeName);
            }
        }

        /// <summary>
        /// Implement Login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public static void Login(string username, string password)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--incognito");
            Driver = new ChromeDriver(options);

            Driver.Url = Urls.UrlLogin;
            System.Threading.Thread.Sleep(5000);
            Driver.FindElement(By.XPath(XPathLogin.InputUsername)).SendKeys(username);
            Driver.FindElement(By.XPath(XPathLogin.InputPassword)).SendKeys(password);
            Driver.FindElement(By.XPath(XPathLogin.ButtonLogin)).Click();
            System.Threading.Thread.Sleep(7000);
        }

        /// <summary>
        /// Implement action click
        /// </summary>
        /// <param name="xpath">xPath of element on screen that is clicked on</param>
        /// <param name="index">driver can find many elements by the given xPath, pass this index to determine which element that want to focus</param>
        /// <param name="sleepTime">temporary pause time (second) after implement click action</param>
        public static void Click(string xpath, int index = 1, int sleepTime = 0)
        {
            var elements = Driver.FindElements(By.XPath(xpath));
            elements[index - 1].Click();
            if (sleepTime > 0)
            {
                System.Threading.Thread.Sleep(sleepTime * 1000);
            }
        }

        /// <summary>
        /// Implement action input text
        /// </summary>
        /// <param name="xpath">xPath of element on screen that is input text</param>
        /// <param name="inputText"></param>
        /// <param name="index">driver can find many elements by the given xPath, pass this index to determine which element that want to focus</param>
        public static void Input(string xpath, string inputText, int index = 1)
        {
            Driver.FindElements(By.XPath(xpath))[index - 1].Clear();
            Driver.FindElements(By.XPath(xpath))[index - 1].SendKeys(inputText);
        }

        /// <summary>
        /// Compare current url in web driver with given Url
        /// </summary>
        /// <param name="expectedUrl"></param>
        public static void CheckUrl(string expectedUrl)
        {
            try
            {
                Assert.That(Driver.Url.Equals(expectedUrl));
            }
            catch (AssertionException)
            {
                string message = $"Expected Url: {expectedUrl} \nBut was: {Driver.Url}";
                throw new AssertionException(message);
            }
        }

        /// <summary>
        /// Compare status of element with given status 
        /// </summary>
        /// <param name="xpath">xPath of this element on screen</param>
        /// <param name="isDisplayed">display status of this element</param>
        /// <param name="isEnabled">enable status of this element</param>
        /// <param name="index">driver can find many elements by the given xPath, pass this index to determine which element that want to focus</param>
        public static void CheckControlStatus(string xpath, bool? isDisplayed = null, bool? isEnabled = null, int index = 1)
        {
            if (isDisplayed != null)
            {
                bool actualStatus = Driver.FindElements(By.XPath(xpath))[index - 1].Displayed;
                try
                {
                    Assert.That(actualStatus == isDisplayed.Value);
                }
                catch (AssertionException)
                {
                    string message = $"Expected display status: {isDisplayed.Value} \nBut was: {actualStatus}";
                    throw new AssertionException(message);
                }
            }
            if (isEnabled != null)
            {
                bool actualStatus = Driver.FindElements(By.XPath(xpath))[index - 1].Enabled;
                try
                {
                    Assert.That(actualStatus == isEnabled.Value);
                }
                catch (AssertionException)
                {
                    string message = $"Expected enable status: {isEnabled.Value} \nBut was: {actualStatus}";
                    throw new AssertionException(message);
                }
            }
        }

        /// <summary>
        /// Compare value of specific attribute in element with given value
        /// </summary>
        /// <param name="expectedValue"></param>
        /// <param name="xpath">xPath of this element on screen</param>
        /// <param name="valueAttribute">name of the attribute in element that need to focus</param>
        /// <param name="index">driver can find many elements by the given xPath, pass this index to determine which element that want to focus</param>
        public static void CheckControlContent(string expectedValue, string xpath, string valueAttribute = null, int index = 1)
        {
            var element = Driver.FindElements(By.XPath(xpath))[index - 1];
            string actualValue = element.GetAttribute(string.IsNullOrEmpty(valueAttribute) ? "innerText" : valueAttribute);
            try
            {
                Assert.That(actualValue.Trim().Equals(expectedValue.Trim()));
            }
            catch (AssertionException)
            {
                string message = $"Expected: {expectedValue} \nBut was: {actualValue}";
                throw new AssertionException(message);
            }
        }

        /// <summary>
        /// Compare value of each field in each row in given expected data table with value of that field in that row on screen 
        /// </summary>
        /// <param name="expectedData">expected data table</param>
        /// <param name="xPathAttributePairs">set of xPath for any fields in table and the attribute to get value</param>
        /// <param name="screenMapping">set of field name of result data table and field name on screen</param>
        /// <param name="refFieldMapping">set of field name of result data table and field name of table in database that it’s data refer to</param>
        /// <param name="additionalRules">additional rules as format rule, etc</param>
        public static void CheckTableData(Table expectedData, Dictionary<string, string> xPathAttributePairs, Dictionary<string, string> screenMapping = null, Dictionary<string, string> refFieldMapping = null, Dictionary<string, string> additionalRules = null)
        {
            var properties = expectedData.Header.ToList();
            for (var i = 0; i < expectedData.RowCount; i++)
            {
                foreach (var prop in properties)
                {
                    // Get expected value from test case
                    string expectedValue = expectedData.Rows[i][prop];
                    if (expectedValue.Equals("NULL")) expectedValue = string.Empty;
                    if (expectedValue.Equals("today") && additionalRules != null && additionalRules.ContainsKey("format-date"))
                    {
                        expectedValue = DateTime.Now.ToString(additionalRules["format-date"]);
                    }
                    string refFieldName = null;
                    if (prop.EndsWith("ID", StringComparison.InvariantCultureIgnoreCase) && !int.TryParse(expectedValue, out var id1))
                    {
                        refFieldName = prop;
                    }
                    if (refFieldMapping != null && refFieldMapping.ContainsKey(prop) && !int.TryParse(expectedValue, out var id2))
                    {
                        refFieldName = refFieldMapping[prop];
                    }
                    if (!string.IsNullOrEmpty(refFieldName))
                    {
                        var refEntityName = GetEntityNameFromHeader(refFieldName);
                        var lookup = _identifierLookup.Lookup(refEntityName);
                        foreach (var item in lookup)
                        {
                            if (expectedValue.Contains(item.Key))
                            {
                                expectedValue = expectedValue.Replace(item.Key, item.Value.ToString());
                            }
                        }
                    }

                    // Get actual value from screen by xpath
                    string actualValue = null;
                    var screenFieldName = prop;
                    if (screenMapping != null && screenMapping.ContainsKey(prop))
                    {
                        screenFieldName = screenMapping[prop];
                    }
                    foreach (var xpath in xPathAttributePairs)
                    {
                        var element = Driver.FindElements(By.XPath(string.Format(xpath.Key, screenFieldName)));
                        if (element != null && element.Count > 0)
                        {
                            actualValue = element[i].GetAttribute(string.IsNullOrEmpty(xpath.Value) ? "innerText" : xpath.Value);
                            break;
                        }
                    }
                    if (actualValue == null)
                    {
                        string message = $"Cannot find any element of field {screenFieldName} by these xPaths: \n";
                        foreach (var xpath in xPathAttributePairs)
                        {
                            message += xpath.Key + "\n";
                        }
                        throw new NoSuchElementException(message);
                    }

                    // Compare value
                    try
                    {
                        Assert.That(actualValue.Trim().Equals(expectedValue.Trim()));
                    }
                    catch (AssertionException)
                    {
                        string message = $"Expected: {expectedValue} \nBut was: {actualValue}";
                        throw new AssertionException(message);
                    }
                }
            }
        }

        /// <summary>
        /// Delete all records of tables in database that correspond with records in data pool of TestDataManager 
        /// and close driver and clear data pool of TestDataManager 
        /// </summary>
        public static void Cleanup()
        {
            Driver.Quit();
            if (_createdEntities.Count > 0)
            {
                var context = _CreateDbContext();
                for (int i = _createdEntityTypes.Count - 1; i >= 0; --i)
                {
                    foreach (var createdEntity in _createdEntities)
                    {
                        string entityTypeName = createdEntity.GetType().Name;
                        if (entityTypeName.Equals(_createdEntityTypes[i]))
                        {
                            string entityIdPropertyName = _IdConventionExceptions.Lookup(entityTypeName) ?? $"{entityTypeName}ID";
                            var entityIdValue = createdEntity.GetType().GetProperty(entityIdPropertyName).GetValue(createdEntity);

                            string sql = $"DELETE {entityTypeName} WHERE {entityIdPropertyName} = {entityIdValue};";
                            context.Entry(createdEntity).State = EntityState.Deleted;
                            context.ExecuteSqlCommand(sql);
                        }
                    }
                }
            }
            _createdEntities.Clear();
            _createdEntityTypes.Clear();
            _identifierLookup.Clear();
        }

        private static string GetEntityNameFromHeader(string idProperty)
        {
            var exception = _IdConventionExceptions.Where(kvp => kvp.Value == idProperty)
                                                  .Select(kvp => kvp.Key)
                                                  .FirstOrDefault();
            return (exception ?? idProperty.Substring(0, idProperty.Length - 2)).Normalize();
        }

        private static KissContext _CreateDbContext()
        {
            var commonAuditor = new CommonAuditor("Test GUI runner", DateTime.Now);
            var historyAuditor = new HistoryVersionCreator("Test GUI runner");
            return new KissContext(new IDbChangeAuditor[] { commonAuditor, historyAuditor });
        }
    }
}
