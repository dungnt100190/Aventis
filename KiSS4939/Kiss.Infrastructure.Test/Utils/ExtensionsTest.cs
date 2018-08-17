using System;
using System.Collections.Generic;

using Kiss.Infrastructure.Utils;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.Infrastructure.Test.Utils
{
    [TestClass]
    public class ExtensionsTest
    {
        [TestMethod]
        public void TryGetValue_DateTimeNull_ValueNotFound()
        {
            // Arrange
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("a", null);

            // Act
            DateTime res;
            var found = dictionary.TryGetValue("a", out res);

            // Assert
            Assert.IsFalse(found);
        }

        [TestMethod]
        public void TryGetValue_DateTimeValid_ValueFound()
        {
            // Arrange
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("a", new DateTime(2012, 01, 01));

            // Act
            DateTime res;
            var found = dictionary.TryGetValue("a", out res);

            // Assert
            Assert.IsTrue(found);
            Assert.AreEqual(new DateTime(2012, 01, 01), res);
        }

        [TestMethod]
        public void TryGetValue_IntNull_ValueNotFound()
        {
            // Arrange
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("a", null);

            // Act
            int res;
            var found = dictionary.TryGetValue("a", out res);

            // Assert
            Assert.IsFalse(found);
        }

        [TestMethod]
        public void TryGetValue_IntValid_ValueFound()
        {
            // Arrange
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("a", 1);

            // Act
            int res;
            var found = dictionary.TryGetValue("a", out res);

            // Assert
            Assert.IsTrue(found);
            Assert.AreEqual(1, res);
        }

        [TestMethod]
        public void TryGetValue_ListOfIntNull_ValueFound()
        {
            // Arrange
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("a", null);

            // Act
            List<int> res;
            var found = dictionary.TryGetValue("a", out res);

            // Assert
            Assert.IsTrue(found);
            Assert.IsNull(res);
        }

        [TestMethod]
        public void TryGetValue_ListOfIntValid_ValueFound()
        {
            // Arrange
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("a", new List<int> { 1 });

            // Act
            List<int> res;
            var found = dictionary.TryGetValue("a", out res);

            // Assert
            Assert.IsTrue(found);
            Assert.AreEqual(dictionary["a"], res);
        }

        [TestMethod]
        public void TryGetValue_NullableIntNull_ValueFound()
        {
            // Arrange
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("a", null);

            // Act
            int? res;
            var found = dictionary.TryGetValue("a", out res);

            // Assert
            Assert.IsTrue(found);
            Assert.IsNull(res);
        }

        [TestMethod]
        public void TryGetValue_NullableIntValid_ValueFound()
        {
            // Arrange
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("a", 1);

            // Act
            int? res;
            var found = dictionary.TryGetValue("a", out res);

            // Assert
            Assert.IsTrue(found);
            Assert.AreEqual(1, res);
        }

        [TestMethod]
        public void TryGetValue_TimestampNull_ValueFound()
        {
            // Arrange
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("a", null);

            // Act
            byte[] res;
            var found = dictionary.TryGetValue("a", out res);

            // Assert
            Assert.IsTrue(found);
            Assert.IsNull(res);
        }

        [TestMethod]
        public void TryGetValue_TimestampValid_ValueFound()
        {
            // Arrange
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("a", new byte[8]);

            // Act
            byte[] res;
            var found = dictionary.TryGetValue("a", out res);

            // Assert
            Assert.IsTrue(found);
            Assert.AreEqual(dictionary["a"], res);
        }
    }
}