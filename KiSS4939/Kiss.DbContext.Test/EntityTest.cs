using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.DbContext.Test
{
    [TestClass]
    public class EntityTest
    {
        private const int BA_PERSON_ID = 123;

        [TestMethod]
        public void TestDontUpdateNavigationPropertyFromID()
        {
            // Arrange
            var person = new BaPerson
            {
                BaPersonID = BA_PERSON_ID
            };
            var leistung = new FaLeistung
            {
                BaPerson = person
            };

            // Act
            leistung.BaPersonID = BA_PERSON_ID;

            // Assert
            Assert.AreEqual(leistung.BaPerson, person);
        }

        [TestMethod]
        public void TestEntityImplementsINotifyPropertyChanged()
        {
            // Arrange
            var person = new BaPerson();

            // Act
            var notifyPropertyChanged = person as INotifyPropertyChanged;

            // Assert
            Assert.IsNotNull(notifyPropertyChanged);
        }

        [TestMethod]
        public void TestNotifyPropertyChanged()
        {
            // Arrange
            var person = new BaPerson
                             {
                                 Name = "UnitTest Nachname"
                             };
            var notifyPropertyChanged = (INotifyPropertyChanged)person;
            var notificationReceived = false;
            notifyPropertyChanged.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "Name")
                {
                    notificationReceived = true;
                }
            };

            // Act
            person.Name = person.Name += " geändert";

            // Assert
            Assert.IsTrue(notificationReceived);
        }

        [TestMethod]
        public void TestUpdateIDFromNavigationProperty()
        {
            // Arrange
            var person = new BaPerson
            {
                BaPersonID = BA_PERSON_ID
            };
            var leistung = new FaLeistung();

            // Act
            leistung.BaPerson = person;

            // Assert
            Assert.AreEqual(person.BaPersonID, leistung.BaPersonID);
        }

        [TestMethod]
        public void TestUpdateNavigationPropertyFromID()
        {
            // Arrange
            var person = new BaPerson
                             {
                                 BaPersonID = BA_PERSON_ID
                             };
            var leistung = new FaLeistung
                               {
                                   BaPerson = person
                               };

            // Act
            leistung.BaPersonID = BA_PERSON_ID + 1;

            // Assert
            Assert.IsNull(leistung.BaPerson);
        }
    }
}