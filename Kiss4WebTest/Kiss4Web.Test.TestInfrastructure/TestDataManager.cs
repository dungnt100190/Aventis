﻿using Kiss4Web.Resource;
using Kiss4Web.Test.DataAccess;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using Shouldly;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Kiss4Web.Test.TestInfrastructure
{
    public static class TestDataManager
    {
        /// <summary>
        /// Setup TestDataManager
        /// </summary>
        public static void Setup()
        {
            TestDataPool.Driver = null;
            TestDataPool.TempEntities.Clear();
            TestDataPool.CreatedEntities.Clear();
            TestDataPool.IdentifierLookup.Clear();
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
            List<T> result = new List<T>();

            for (var i = 0; i < table.RowCount; i++)
            {
                T entity = Activator.CreateInstance<T>();
                foreach (var prop in properties)
                {
                    var value = table.Rows[i][prop];

                    var property = typeof(T).GetProperty(prop);
                    if (property == null) continue;

                    if (string.Equals(value, "NULL", StringComparison.OrdinalIgnoreCase))
                    {
                        // value of property is null
                        property.SetValue(entity, null);
                        continue;
                    }

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
                        var lookup = TestDataPool.IdentifierLookup.Lookup(refEntityName);
                        foreach (var item in lookup)
                        {
                            if (value.Contains(item.Key))
                            {
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
                        continue;
                    }

                    if (property.PropertyType == typeof(string))
                    {
                        property.SetValue(entity, value);
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
        /// Insert all row in table to database and add to data pool
        /// </summary>
        /// <typeparam name="TEntity">name of table in database</typeparam>
        /// <param name="table"></param>
        /// <param name="idFieldMapping">set of field name of this table and ID field name of other table that it’s data refer to</param>
        public static void Insert<TEntity>(Table table, Dictionary<string, string> idFieldMapping = null)
            where TEntity : class
        {
            var entities = table.CreateSet<TEntity>().ToList(); // Assumption: order remains as in the table
            var entityProperties = typeof(TEntity).GetProperties();
            var entityTypeName = typeof(TEntity).Name;
            var entityIdPropertyName = ConstantData.IdConventionExceptions.Lookup(entityTypeName) ?? $"{entityTypeName}ID"; // convention
            var logicalNameLookup = new Dictionary<object, string>();

            var properties = table.Header.ToList();
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
                            if (string.Equals(prop, entityIdPropertyName, StringComparison.InvariantCultureIgnoreCase))
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
                                if (idFieldMapping != null && idFieldMapping.ContainsKey(prop))
                                {
                                    refFieldName = idFieldMapping[prop];
                                }
                                var refEntityName = GetEntityNameFromHeader(refFieldName);
                                var lookup = TestDataPool.IdentifierLookup[refEntityName];
                                var referencedEntityId = lookup[value.Normalize()];
                                property.SetValue(entity, referencedEntityId);
                            }
                        }
                    }

                    repository.Insert(entity);
                }
            }

            // get ids for lookup & add created entity to data pool
            var entityLookup = TestDataPool.IdentifierLookup.LookupAddIfMissing(typeof(TEntity).Name.Normalize(), () => new Dictionary<string, int>());
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
        /// Add records to data pool
        /// </summary>
        /// <typeparam name="TEntity">name of table in database</typeparam>
        /// <param name="entity"></param>
        public static void TrackEntity<TEntity>(List<object> entities)
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
        public static void CheckEntityExistsInDB<TEntity>(object entity, bool isExists = true, bool isInserted = true)
            where TEntity : class
        {
            bool actual = false;

            var entityTypeName = typeof(TEntity).Name;
            var entityIdPropertyName = ConstantData.IdConventionExceptions.Lookup(entityTypeName) ?? $"{entityTypeName}ID"; // convention

            StringBuilder sql = new StringBuilder();
            sql.Append($"SELECT {entityIdPropertyName} FROM {entityTypeName} WHERE 1 = 1 ");

            var entityProperties = entity.GetType().GetProperties();
            foreach (var property in entityProperties)
            {
                if (property.Name.Equals("Id")) continue;
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

            var context = _CreateDbContext();
            var dbEntities = context.Database.SqlQuery<int>(sql.ToString()).ToList();
            if (dbEntities != null && dbEntities.Count > 0)
            {
                actual = true;
                if (isInserted)
                {
                    var createdEntities = new List<object>();
                    foreach (int id in dbEntities)
                    {
                        object dbEntity = Activator.CreateInstance<TEntity>();
                        dbEntity.GetType().GetProperty(entityIdPropertyName).SetValue(dbEntity, id);
                        createdEntities.Add(dbEntity);
                    }
                    TrackEntity<TEntity>(createdEntities);
                }
            }

            try
            {
                Assert.That(actual == isExists);
            }
            catch (AssertionException)
            {
                string message = $"Expected: this records does " + (isExists ? "exists" : "not exists") + " in database \nBut was: " + (actual ? "exists" : "not exists");
                throw new AssertionException(message);
            }
        }

        /// <summary>
        /// Check added or updated Record exists in database, if exists then add to data pool
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="isExists"></param>
        /// <param name="isInserted"></param>
        public static void CheckAddUpdateEntityExistsInDB<TEntity>(bool isExists = true, bool isInserted = true)
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
        /// <param name="idFieldMapping"></param>
        public static void AddToTempEntities<TEntity>(Table givenData, Dictionary<string, string> fieldMapping = null, Dictionary<string, string> idFieldMapping = null)
            where TEntity : class
        {
            TestDataPool.TempEntities.AddRange(CreateSetWithLookup<TEntity>(givenData, fieldMapping: fieldMapping, idFieldMapping: idFieldMapping));
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
            options.AddArguments("--start-maximized");
            TestDataPool.Driver = new ChromeDriver(options);

            TestDataPool.Driver.Url = Urls.UrlLogin;
            System.Threading.Thread.Sleep(5000);
            TestDataPool.Driver.FindElement(By.XPath(XPathLogin.InputUsername)).SendKeys(username);
            TestDataPool.Driver.FindElement(By.XPath(XPathLogin.InputPassword)).SendKeys(password);
            TestDataPool.Driver.FindElement(By.XPath(XPathLogin.ButtonLogin)).Click();
            System.Threading.Thread.Sleep(10000);
        }

        /// <summary>
        /// Implement action click
        /// </summary>
        /// <param name="xpath">xPath of element</param>
        /// <param name="index">specify element in found elements, default is the first element</param>
        /// <param name="waitingTime">waiting time (second) after implement action</param>
        public static void Click(string xpath, int index = 1, int waitingTime = 1)
        {
            if (index < 1) throw new ArgumentOutOfRangeException("index must be >= 1");
            if (waitingTime < 0) throw new NotSupportedException("waitingTime must be >= 0");

            var elements = TestDataPool.Driver.FindElements(By.XPath(xpath));
            elements[index - 1].Click();
            if (waitingTime > 0)
            {
                System.Threading.Thread.Sleep(waitingTime * 1000);
            }
        }

        /// <summary>
        /// Implement action click, apply only for element is button with the type Submit
        /// </summary>
        /// <param name="xpath">xPath of element</param>
        /// <param name="index">specify element in found elements, default is the first element</param>
        /// <param name="waitingTime">waiting time (second) after implement action</param>
        public static void Submit(string xpath, int index = 1, int waitingTime = 1)
        {
            if (index < 1) throw new ArgumentOutOfRangeException("index must be >= 1");
            if (waitingTime < 0) throw new NotSupportedException("waitingTime must be >= 0");

            var elements = TestDataPool.Driver.FindElements(By.XPath(xpath));
            elements[index - 1].Submit();
            if (waitingTime > 0)
            {
                System.Threading.Thread.Sleep(waitingTime * 1000);
            }
        }

        /// <summary>
        /// Implement action input text
        /// </summary>
        /// <param name="xpath">xPath of element</param>
        /// <param name="inputText"></param>
        /// <param name="index">specify element in found elements, default is the first element</param>
        /// <param name="waitingTime">waiting time (second) after implement action</param>
        public static void Input(string xpath, string inputText, int index = 1, int waitingTime = 1)
        {
            if (index < 1) throw new ArgumentOutOfRangeException("index must be >= 1");
            if (waitingTime < 0) throw new NotSupportedException("waitingTime must be >= 0");

            TestDataPool.Driver.FindElements(By.XPath(xpath))[index - 1].Clear();
            TestDataPool.Driver.FindElements(By.XPath(xpath))[index - 1].SendKeys(inputText);
            if (waitingTime > 0)
            {
                System.Threading.Thread.Sleep(waitingTime * 1000);
            }
        }

        /// <summary>
        /// Implement choose option in dropdown element 
        /// </summary>
        /// <param name="xpath">xPath of dropdown element</param>
        /// <param name="option">option in dropdown</param>
        /// <param name="index">specify element in found elements, default is the first element</param>
        /// <param name="waitingTime">waiting time (second) after implement action</param>
        public static void InputDropdown(string xpath, string option, int index = 1, int waitingTime = 1)
        {
            if (index < 1) throw new ArgumentOutOfRangeException("index must be >= 1");
            if (waitingTime < 0) throw new NotSupportedException("waitingTime must be >= 0");

            Click(xpath, index: index, waitingTime: 2);
            Click(string.Format(XPath0DevExtreme.DropdownOption, option), waitingTime: waitingTime);
        }

        /// <summary>
        /// Implement choose option in embed grid of dropdown element 
        /// </summary>
        /// <param name="xpath">xPath of embed grid dropdown element</param>
        /// <param name="option">info of row in embed grid, format is <colname>=<value>/<colname>=<value>/...</param>
        /// <param name="index">specify element in found elements, default is the first element</param>
        /// <param name="waitingTime">waiting time (second) after implement action</param>
        public static void InputGridDropdown(string xpath, string option, int index = 1, int waitingTime = 1)
        {
            if (index < 1) throw new ArgumentOutOfRangeException("index must be >= 1");
            if (waitingTime < 0) throw new NotSupportedException("waitingTime must be >= 0");

            Click(xpath, index: index, waitingTime: 2);
            string[] rowInfo = option.Split('/');
            string xPathColFilter = XPath0DevExtreme.AutogenElement + XPath0DevExtreme.GridColumnFilter;
            foreach (var info in rowInfo)
            {
                string column = info.Split('=')[0];
                string value = info.Split('=')[1];
                Input(string.Format(xPathColFilter + XPath0Common.Textbox, column), value, waitingTime: 2);
            }
            Click(XPath0DevExtreme.AutogenElement + XPath0DevExtreme.DropdownGridRow, waitingTime: waitingTime);
        }

        /// <summary>
        /// Implement choose option in dropdown of field filter in grid
        /// </summary>
        /// <param name="xpath">xPath of field in grid</param>
        /// <param name="option"></param>
        /// <param name="index"></param>
        /// <param name="waitingTime"></param>
        public static void InputDropdownGridFilter(string xpath, string option, int index = 1, int waitingTime = 1)
        {
            if (index < 1) throw new ArgumentOutOfRangeException("index must be >= 1");
            if (waitingTime < 0) throw new NotSupportedException("waitingTime must be >= 0");

            Click(xpath + XPath0DevExtreme.GridColumnFilterButton, index: index, waitingTime: 2);
            Click(string.Format(XPath0DevExtreme.AutogenElement + "//*[contains(text(),'{0}')]", option), waitingTime: waitingTime);
        }

        /// <summary>
        /// Implement choose option in datebox element
        /// </summary>
        /// <param name="xpath">xPath of datebox element</param>
        /// <param name="option">the date that want to choose, format is <date-value> <date-format>, <date-format> is optional</param>
        /// <param name="index">specify element in found elements, default is the first element</param>
        /// <param name="waitingTime">waiting time (second) after implement action</param>
        public static void InputDatebox(string xpath, string option, int index = 1, int waitingTime = 1)
        {
            if (index < 1) throw new ArgumentOutOfRangeException("index must be >= 1");
            if (waitingTime < 0) throw new NotSupportedException("waitingTime must be >= 0");

            Click(xpath + XPath0DevExtreme.InputElementEditorButton, index: index, waitingTime: 2);
            Click(XPath0DevExtreme.AutogenElement + XPath0DevExtreme.CalendarDateRangeButton);
            Click(XPath0DevExtreme.AutogenElement + XPath0DevExtreme.CalendarDateRangeButton);
            Click(XPath0DevExtreme.AutogenElement + XPath0DevExtreme.CalendarDateRangeButton);

            // get date, month, year from expected value
            var givenDateInfo = option.Split(' ');
            string dateFormat = null;
            if (givenDateInfo.Count() > 1) dateFormat = givenDateInfo[1];
            DateTime givenDate = DateTime.ParseExact(givenDateInfo[0], string.IsNullOrEmpty(dateFormat) ? Format.Date : dateFormat, CultureInfo.InvariantCulture);

            // choose year range
            bool isContainYear = false;
            while (isContainYear == false)
            {
                var yearRangeElements = TestDataPool.Driver.FindElements(By.XPath(XPath0DevExtreme.AutogenElement + XPath0DevExtreme.CalendarCellOption));
                for (int i = 1; i < yearRangeElements.Count - 1; ++i)
                {
                    var rangeValue = yearRangeElements[i].GetAttribute("innerText");
                    var startYear = int.Parse(rangeValue.Split(new string[] { " - " }, StringSplitOptions.None)[0]);
                    var endYear = int.Parse(rangeValue.Split(new string[] { " - " }, StringSplitOptions.None)[1]);
                    if (givenDate.Year >= startYear && givenDate.Year <= endYear)
                    {
                        isContainYear = true;
                        yearRangeElements[i].Click();
                        System.Threading.Thread.Sleep(1000);
                        break;
                    }
                }
                if (isContainYear == false)
                {
                    // go to previous year range
                    var rangeValueFirst = yearRangeElements[1].GetAttribute("innerText");
                    var startYearFirst = int.Parse(rangeValueFirst.Split(new string[] { " - " }, StringSplitOptions.None)[0]);
                    if (givenDate.Year < startYearFirst)
                    {
                        Click(XPath0DevExtreme.AutogenElement + XPath0DevExtreme.CalendarDateRangePrevButton);
                        continue;
                    }
                    // go to next year range
                    var rangeValueLast = yearRangeElements[yearRangeElements.Count - 2].GetAttribute("innerText");
                    var endYearLast = int.Parse(rangeValueFirst.Split(new string[] { " - " }, StringSplitOptions.None)[1]);
                    if (givenDate.Year > endYearLast)
                    {
                        Click(XPath0DevExtreme.AutogenElement + XPath0DevExtreme.CalendarDateRangeNextButton);
                        continue;
                    }
                } 
            }

            // choose year 
            var yearElements = TestDataPool.Driver.FindElements(By.XPath(XPath0DevExtreme.AutogenElement + XPath0DevExtreme.CalendarCellOption));
            for (int i = 1; i < yearElements.Count - 1; ++i)
            {
                var yearValue = int.Parse(yearElements[i].GetAttribute("innerText"));
                if (givenDate.Year == yearValue)
                {
                    yearElements[i].Click();
                    System.Threading.Thread.Sleep(1000);
                    break;
                }
            }

            // choose month
            var monthElements = TestDataPool.Driver.FindElements(By.XPath(XPath0DevExtreme.AutogenElement + XPath0DevExtreme.CalendarCellOption));
            for (int i = 0; i < monthElements.Count; ++i)
            {
                var monthValue = int.Parse(monthElements[i].GetAttribute("data-value").Split('/')[1]);
                if (givenDate.Month == monthValue)
                {
                    monthElements[i].Click();
                    System.Threading.Thread.Sleep(1000);
                    break;
                }
            }

            // choose day
            var dayElements = TestDataPool.Driver.FindElements(By.XPath(XPath0DevExtreme.AutogenElement + XPath0DevExtreme.CalendarCellOption));
            for (int i = 0; i < dayElements.Count; ++i)
            {
                if (dayElements[i].GetAttribute("class").Contains("dx-calendar-other-month")) continue;
                var dayValue = int.Parse(dayElements[i].GetAttribute("innerText"));
                if (givenDate.Day == dayValue)
                {
                    dayElements[i].Click();
                    break;
                }
            }

            if (waitingTime > 0)
            {
                System.Threading.Thread.Sleep(waitingTime * 1000);
            }
            else
            {
                System.Threading.Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Implement input into many elements in a screen area
        /// </summary>
        /// <param name="xPaths">xPath for elements of fields in table</param>
        /// <param name="givenData">given data for elements</param>
        /// <param name="elementType">element type</param>
        /// <param name="screenMapping">set of field name of givenData table and logical name of that element on screen</param>
        /// <param name="waitingTime">waiting time (second) after implement action</param>
        public static void InputTableData(string[] xPaths, Table givenData, Dictionary<string, InputElementType> elementType = null, Dictionary<string, string> screenMapping = null, int waitingTime = 1)
        {
            if (xPaths.Count() == 0) throw new NotSupportedException("must have one or more xPaths to find element");
            if (waitingTime < 0) throw new NotSupportedException("waitingTime must be >= 0");

            var properties = givenData.Header.ToList();
            for (var i = 0; i < givenData.RowCount; i++)
            {
                foreach (var prop in properties)
                {
                    string givenValue = givenData.Rows[i][prop];
                    if (givenValue.Equals("NULL")) continue;

                    var logicalName = prop;
                    if (screenMapping != null && screenMapping.ContainsKey(prop))
                    {
                        logicalName = screenMapping[prop];
                    }
                    foreach (var xpath in xPaths)
                    {
                        var element = TestDataPool.Driver.FindElements(By.XPath(string.Format(xpath, logicalName)));
                        if (element != null && element.Count > 0)
                        {
                            if (elementType != null)
                            {
                                if (elementType.ContainsKey(prop))
                                {
                                    switch (elementType[prop])
                                    {
                                        case InputElementType.Textarea:
                                            Input(string.Format(xpath + XPath0Common.Textarea, logicalName), givenValue, waitingTime: waitingTime);
                                            break;
                                        case InputElementType.Dropdown:
                                            InputDropdown(string.Format(xpath, logicalName), givenValue, waitingTime: waitingTime);
                                            break;
                                        case InputElementType.GridDropdown:
                                            InputGridDropdown(string.Format(xpath, logicalName), givenValue, waitingTime: waitingTime);
                                            break;
                                        case InputElementType.Datebox:
                                            InputDatebox(string.Format(xpath, logicalName), givenValue, waitingTime: waitingTime);
                                            break;
                                        default:
                                            Input(string.Format(xpath + XPath0Common.Textbox, logicalName), givenValue, waitingTime: waitingTime);
                                            break;
                                    }
                                }
                                else
                                {
                                    Input(string.Format(xpath + XPath0Common.Textbox, logicalName), givenValue, waitingTime: waitingTime);
                                }
                            }
                            else
                            {
                                Input(string.Format(xpath + XPath0Common.Textbox, logicalName), givenValue, waitingTime: waitingTime);
                            }
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Open a specified URL in the browser
        /// </summary>
        /// <param name="url"></param>
        public static void GoToUrl(string url)
        {
            TestDataPool.Driver.Url = url;
        }

        /// <summary>
        /// Implement clear text in element
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="index">driver can find many elements by the given xPath, pass this index to determine which element that want to focus, index must be >= 1</param>
        /// <param name="waitingTime">waiting time (second) after implement click action</param>
        public static void Clear(string xpath, int index = 1, int waitingTime = 1)
        {
            if (index < 1) throw new ArgumentOutOfRangeException("index must be >= 1");
            if (waitingTime < 0) throw new NotSupportedException("waitingTime must be >= 0");

            TestDataPool.Driver.FindElements(By.XPath(xpath))[index - 1].Clear();
            if (waitingTime > 0)
            {
                System.Threading.Thread.Sleep(waitingTime * 1000);
            }
        }

        /// <summary>
        /// Implement click-and-hold at the location of the source element, moves to the location of the target element, then releases the mouse
        /// </summary>
        /// <param name="sourceXPath">xPath for source element</param>
        /// <param name="targetXPath">xPath for target element</param>
        /// <param name="waitingTime">waiting time (second) after implement action</param>
        public static void DragAndDrop(string sourceXPath, string targetXPath, int waitingTime = 1)
        {
            Actions action = new Actions(TestDataPool.Driver);
            IWebElement sourceElement = TestDataPool.Driver.FindElement(By.XPath(sourceXPath));
            IWebElement targetElement = TestDataPool.Driver.FindElement(By.XPath(targetXPath));

            action.DragAndDrop(sourceElement, targetElement);
            action.Build().Perform();
            if (waitingTime > 0)
            {
                System.Threading.Thread.Sleep(waitingTime * 1000);
            }
        }

        /// <summary>
        /// Implement click-and-hold at the location of the source element, moves to given offset, then releases the mouse
        /// </summary>
        /// <param name="sourceXPath">xPath for source element</param>
        /// <param name="xOffset"></param>
        /// <param name="yOffset"></param>
        /// <param name="waitingTime">waiting time (second) after implement action</param>
        public static void DragAndDropToOffset(string sourceXPath, int xOffset, int yOffset, int waitingTime = 1)
        {
            Actions action = new Actions(TestDataPool.Driver);
            IWebElement sourceElement = TestDataPool.Driver.FindElement(By.XPath(sourceXPath));

            action.DragAndDropToOffset(sourceElement, xOffset, yOffset);
            action.Build().Perform();
            if (waitingTime > 0)
            {
                System.Threading.Thread.Sleep(waitingTime * 1000);
            }
        }

        /// <summary>
        /// Scroll browser to specific element
        /// </summary>
        /// <param name="targetXPath">xPath for target element</param>
        /// <param name="waitingTime"></param>
        public static void ScrollToElement(string targetXPath, int waitingTime = 1)
        {
            var targetElement = TestDataPool.Driver.FindElement(By.XPath(targetXPath));
            Actions actions = new Actions(TestDataPool.Driver);
            actions.MoveToElement(targetElement);
            actions.Perform();
            if (waitingTime > 0)
            {
                System.Threading.Thread.Sleep(waitingTime * 1000);
            }
        }

        /// <summary>
        /// Check current url in web driver
        /// </summary>
        /// <param name="expectedUrl"></param>
        public static void CheckUrl(string expectedUrl)
        {
            try
            {
                Assert.That(TestDataPool.Driver.Url.Equals(expectedUrl));
            }
            catch (AssertionException)
            {
                string message = $"Expected Url: {expectedUrl} \nBut was: {TestDataPool.Driver.Url}";
                throw new AssertionException(message);
            }
        }

        /// <summary>
        /// Check element exists or not
        /// </summary>
        /// <param name="xpath">xPath of element on screen that is input text</param>
        /// <param name="isExists">exists or not, default is true</param>
        /// <param name="index">driver can find many elements by the given xPath, pass this index to determine which element that want to focus, index must be >= 1</param>
        public static void CheckControlExists(string xpath, bool isExists = true, int index = 1)
        {
            if (index < 1) throw new ArgumentOutOfRangeException("index must be >= 1");

            bool actual = true;
            var elements = TestDataPool.Driver.FindElements(By.XPath(xpath));
            if (elements == null 
                || (elements != null && elements.Count == 0)
                || (elements != null && elements.Count > 0 && elements.Count < index))
            {
                actual = false;
            }
            try
            {
                Assert.That(actual == isExists);
            }
            catch (AssertionException)
            {
                string message = $"Expected: element {index} by xpath {xpath} does " + (isExists ? "exists" : "not exists") + "\nBut was: " + (actual ? "exists" : "not exists");
                throw new AssertionException(message);
            }
        }

        /// <summary>
        /// Check enable & visible status of element
        /// </summary>
        /// <param name="xpath">xPath of this element on screen</param>
        /// <param name="isDisplayed">display status of this element</param>
        /// <param name="isEnabled">enable status of this element</param>
        /// <param name="index">driver can find many elements by the given xPath, pass this index to determine which element that want to focus, index must be >= 1</param>
        public static void CheckControlStatus(string xpath, bool? isDisplayed = null, bool? isEnabled = null, int index = 1)
        {
            if (index < 1) throw new ArgumentOutOfRangeException("index must be >= 1");

            if (isDisplayed != null)
            {
                bool actualStatus = TestDataPool.Driver.FindElements(By.XPath(xpath))[index - 1].Displayed;
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
                bool actualStatus = TestDataPool.Driver.FindElements(By.XPath(xpath))[index - 1].Enabled;
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
        /// Check element is selected, apply for checkbox, radio button, and select operation
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="isSelected"></param>
        /// <param name="index"></param>
        public static void CheckControlSelected(string xpath, bool isSelected = true, int index = 1)
        {
            bool actualStatus = TestDataPool.Driver.FindElements(By.XPath(xpath))[index - 1].Selected;
            actualStatus.ShouldBe(isSelected, $"should be {isSelected}, but was {actualStatus}");
        }

        /// <summary>
        /// Check value of specific attribute in element
        /// </summary>
        /// <param name="xpath">xPath of this element on screen</param>
        /// <param name="expectedValue"></param>
        /// <param name="valueAttribute">name of the attribute in element that need to focus</param>
        /// <param name="index">driver can find many elements by the given xPath, pass this index to determine which element that want to focus, index must be >= 1</param>
        public static void CheckControlContent(string xpath, string expectedValue, string valueAttribute = null, int index = 1)
        {
            if (index < 1) throw new ArgumentOutOfRangeException("index must be >= 1");

            var element = TestDataPool.Driver.FindElements(By.XPath(xpath))[index - 1];
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
        /// Check value of each field in each row in grid or value of multi fields in an area 
        /// </summary>
        /// <param name="xPathAndAttribute">set of xPath for elements of fields in table and the attribute to get value</param>
        /// <param name="expectedData">expected data for elements</param>
        /// <param name="screenMapping">set of field name of expectedData table and logical name of that element on screen</param>
        /// <param name="idFieldMapping">set of field name of expectedData table and ID field name of table in database that it’s data refer to</param>
        /// <param name="additionalRules">additional rules as format rule, etc</param>
        public static void CheckTableData(Dictionary<string, string> xPathAndAttribute, Table expectedData, Dictionary<string, string> screenMapping = null, Dictionary<string, string> idFieldMapping = null)
        {
            var properties = expectedData.Header.ToList();
            for (var i = 0; i < expectedData.RowCount; i++)
            {
                foreach (var prop in properties)
                {
                    // Get expected value from test case
                    string expectedValue = expectedData.Rows[i][prop];
                    if (expectedValue.Equals("NULL"))
                    {
                        expectedValue = string.Empty;
                    }
                    else
                    {
                        if (expectedValue.Contains("TODAY"))
                        {
                            expectedValue = DateTime.Now.ToString(expectedValue.Split(' ')[1]);
                        }
                        string refFieldName = null;
                        if (prop.EndsWith("ID", StringComparison.InvariantCultureIgnoreCase) && !int.TryParse(expectedValue, out var id1))
                        {
                            refFieldName = prop;
                        }
                        if (idFieldMapping != null && idFieldMapping.ContainsKey(prop) && !int.TryParse(expectedValue, out var id2))
                        {
                            refFieldName = idFieldMapping[prop];
                        }
                        if (!string.IsNullOrEmpty(refFieldName))
                        {
                            var refEntityName = GetEntityNameFromHeader(refFieldName);
                            var lookup = TestDataPool.IdentifierLookup.Lookup(refEntityName);
                            foreach (var item in lookup)
                            {
                                if (expectedValue.Contains(item.Key))
                                {
                                    expectedValue = expectedValue.Replace(item.Key, item.Value.ToString());
                                }
                            }
                        }
                    }

                    // Get actual value from screen by xpath
                    string actualValue = null;
                    var logicalName = prop;
                    if (screenMapping != null && screenMapping.ContainsKey(prop))
                    {
                        logicalName = screenMapping[prop];
                    }
                    foreach (var xpath in xPathAndAttribute)
                    {
                        var element = TestDataPool.Driver.FindElements(By.XPath(string.Format(xpath.Key, logicalName)));
                        if (element != null && element.Count > 0)
                        {
                            actualValue = element[i].GetAttribute(string.IsNullOrEmpty(xpath.Value) ? "innerText" : xpath.Value);
                            break;
                        }
                    }
                    if (actualValue == null)
                    {
                        string message = $"Cannot find any element of field {logicalName} by these xPaths: \n";
                        foreach (var xpath in xPathAndAttribute)
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
                        string message = $"Expected: {expectedValue} \nBut was: {actualValue} for field {prop} in row {i + 1}";
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
            if (TestDataPool.Driver != null) TestDataPool.Driver.Quit();
            if (TestDataPool.CreatedEntities.Count > 0)
            {
                var context = _CreateDbContext();
                for (int i = TestDataPool.CreatedEntities.Count - 1; i >= 0; --i)
                {
                    var entityTypeName = TestDataPool.CreatedEntities.ElementAt(i).Key;
                    foreach (var entity in TestDataPool.CreatedEntities.ElementAt(i).Value)
                    {
                        string entityIdPropertyName = ConstantData.IdConventionExceptions.Lookup(entityTypeName) ?? $"{entityTypeName}ID";
                        var value = entity.GetType().GetProperty(entityIdPropertyName).GetValue(entity);

                        string sql = $"DELETE {entityTypeName} WHERE {entityIdPropertyName} = {value};";
                        
                        context.Entry(entity).State = EntityState.Deleted;
                        context.ExecuteSqlCommand(sql);
                    }
                }
            }
            TestDataPool.TempEntities.Clear();
            TestDataPool.CreatedEntities.Clear();
            TestDataPool.IdentifierLookup.Clear();
        }

        private static string GetEntityNameFromHeader(string idProperty)
        {
            var exception = ConstantData.IdConventionExceptions.Where(kvp => kvp.Value == idProperty)
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
