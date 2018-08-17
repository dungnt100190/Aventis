using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.Infrastructure.Test
{
    [TestClass]
    public class PropertyValueTest
    {
        [TestMethod]
        public void GetPropertyValueLevel1()
        {
            var testObject = new Test();
            testObject.Test2 = new Test2();
            testObject.Id = 1;
            testObject.Name = "Test";
            testObject.Test2.Id = 99;

            var id = PropertyValue.GetPropertyValue(testObject, "Id");
            var name = PropertyValue.GetPropertyValue(testObject, "Name");
            Assert.AreEqual(1, id);
            Assert.AreEqual("Test", name);
        }

        [TestMethod]
        public void GetPropertyValueLevel2()
        {
            var testObject = new Test();
            testObject.Test2 = new Test2();
            testObject.Id = 1;
            testObject.Name = "Test";
            testObject.Test2.Id = 99;

            var id = PropertyValue.GetPropertyValue(testObject, "Test2.Id");
            Assert.AreEqual(99, id);
        }

        [TestMethod]
        public void SetPropertyValueLevel1()
        {
            var testObject = new Test();

            PropertyValue.SetPropertyValue(testObject, "Id", 5);
            PropertyValue.SetPropertyValue(testObject, "Name", "XYZ");

            Assert.AreEqual(5, testObject.Id);
            Assert.AreEqual("XYZ", testObject.Name);
        }

        [TestMethod]
        public void SetPropertyValueLevel2()
        {
            var testObject = new Test();
            testObject.Test2 = new Test2();

            PropertyValue.SetPropertyValue(testObject, "Test2.Id", 10);

            Assert.AreEqual(10, testObject.Test2.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SetPropertyValueLevel2NullReference()
        {
            var testObject = new Test();

            PropertyValue.SetPropertyValue(testObject, "Test2.Id", 10);
        }

        private class Test
        {
            public int Id
            {
                get;
                set;
            }

            public string Name
            {
                get;
                set;
            }

            public Test2 Test2
            {
                get;
                set;
            }
        }

        private class Test2
        {
            public int Id
            {
                get;
                set;
            }
        }
    }
}