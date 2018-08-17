using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

using Kiss.Infrastructure.Testing;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.DbContext.Test
{
    [TestClass]
    public class ContextTest
    {
        private DbTestHelper _testHelper;

        [TestCleanup]
        public void Cleanup()
        {
            _testHelper.Dispose();
        }

        [TestInitialize]
        public void Setup()
        {
            _testHelper = new DbTestHelper();
        }

        [TestMethod]
        public void Test_UpdateAfterDeleteByOtherUser_ExceptionShouldBeThrown()
        {
            // Arrange
            var baPersonID = _testHelper.Person.BaPersonID;

            // Act
            BaPerson person;
            using (var contextGet = new KissContext())
            {
                person = contextGet.BaPerson.Find(baPersonID);
            }
            var originalName = person.Name;
            person.Name = originalName + " test";
            person.Name = originalName;

            // other user deletes entity
            using (var contextOtherUser = new KissContext())
            {
                var personDelete = contextOtherUser.BaPerson.Find(baPersonID);
                contextOtherUser.BaPerson.Remove(personDelete);
                contextOtherUser.SaveChanges();
            }

            // try to save
            using (var contextSave = new KissContext())
            {
                contextSave.BaPerson.Attach(person);
                contextSave.Entry(person).State = EntityState.Modified;
                TestHelper.AssertThrows<DbUpdateException>(() => contextSave.SaveChanges());
            }
        }

        [TestMethod]
        public void Test_UpdateUnchangedEntity_TimestampShouldBeUnchanged()
        {
            // Arrange
            var baPersonID = _testHelper.Person.BaPersonID;
            byte[] timestampBefore;
            byte[] timestampAfter;
            byte[] timestampNewRead;

            // Act
            using (var context = new KissContext())
            {
                var person = context.BaPerson.Find(baPersonID);
                timestampBefore = person.BaPersonTS;

                var originalName = person.Name;
                person.Name = originalName + " test";
                person.Name = originalName;

                context.SaveChanges();

                timestampAfter = person.BaPersonTS;
            }

            // Assert
            BaPerson personAssert;
            using (var context = new KissContext())
            {
                personAssert = context.BaPerson.Find(baPersonID);
                timestampNewRead = personAssert.BaPersonTS;
            }
            Assert.AreEqual(_testHelper.Person.Name, personAssert.Name);
            DbTestHelper.AssertAreEqual(timestampBefore, timestampAfter);
            DbTestHelper.AssertAreEqual(timestampAfter, timestampNewRead);
        }

        [TestMethod]
        public void Test_UpdateUnchangedEntityInDifferentContext_TimestampShouldBeUnchanged()
        {
            // Arrange
            var baPersonID = _testHelper.Person.BaPersonID;
            byte[] timestampBefore;
            byte[] timestampAfter;
            byte[] timestampNewRead;

            // Act
            BaPerson person;
            using (var context = new KissContext())
            {
                person = context.BaPerson.Find(baPersonID);
                timestampBefore = person.BaPersonTS;
            }
            var originalName = person.Name;
            person.Name = originalName + " test";
            person.Name = originalName;

            using (var context = new KissContext())
            {
                context.BaPerson.Attach(person);
                context.Entry(person).State = EntityState.Modified;
                context.SaveChanges();

                timestampAfter = person.BaPersonTS;
            }

            // Assert
            BaPerson personAssert;
            using (var context = new KissContext())
            {
                personAssert = context.BaPerson.Find(baPersonID);
                timestampNewRead = personAssert.BaPersonTS;
            }
            Assert.AreEqual(_testHelper.Person.Name, personAssert.Name);
            //TestHelper.AssertAreEqual(timestampBefore, timestampAfter); // Kann über 2 Context nicht erreicht werden
            DbTestHelper.AssertAreEqual(timestampAfter, timestampNewRead);
        }

        [TestMethod]
        public void TestGet()
        {
            // Arrange

            // Act
            BaPerson person;
            using (var context = new KissContext())
            {
                person = context.BaPerson.Find(_testHelper.Person.BaPersonID);
            }

            // Assert
            Assert.IsNotNull(person);
            Assert.AreEqual(_testHelper.Person.BaPersonID, person.BaPersonID);
            Assert.AreEqual(_testHelper.Person.Name, person.Name);
        }

        [TestMethod]
        public void TestImplicitTransaction()
        {
            // Arrange
            var adresse = new BaAdresse
            {
                BaPersonID = _testHelper.Person.BaPersonID,
            };
            var zahlungsweg = new BaZahlungsweg
            {
                BaPersonID = -1, // invalid
                DatumVon = DateTime.Now,
            };
            var exceptionOccured = false;

            // Act
            using (var context = new KissContext())
            {
                context.BaAdresse.Attach(adresse);
                context.Entry(adresse).State = EntityState.Added;
                context.BaZahlungsweg.Attach(zahlungsweg);
                context.Entry(zahlungsweg).State = EntityState.Added;

                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    exceptionOccured = true;
                }
                _testHelper.DeleteOnCleanup(adresse);
                _testHelper.DeleteOnCleanup(zahlungsweg);
            }

            // Assert
            Assert.IsTrue(exceptionOccured, "Der Zahlungsweg dürfte wegen der ungültigen BaPersonID nicht eingefügt werden können");

            BaAdresse adresseAssert;
            using (var context = new KissContext())
            {
                adresseAssert = context.BaAdresse.Find(adresse.BaAdresseID);
            }
            Assert.IsNull(adresseAssert, "Durch das implizite Transaktionshandling des DbContext dürfte das Insert der Adresse nicht commited werden");
            Assert.AreEqual(0, adresse.BaAdresseID, "ID müsste 0 bleiben, wenn Transaktion abgebrochen wird");
            Assert.AreEqual(0, zahlungsweg.BaZahlungswegID, "ID müsste 0 bleiben, wenn Transaktion abgebrochen wird");
        }

        [TestMethod]
        public void TestInsert()
        {
            // Arrange
            const string strasse = "Teststrasse";
            var baPersonID = _testHelper.Person.BaPersonID;

            var adresse = new BaAdresse
                              {
                                  BaPersonID = _testHelper.Person.BaPersonID,
                                  Strasse = strasse
                              };
            // Act
            using (var context = new KissContext())
            {
                context.BaAdresse.Attach(adresse);
                context.Entry(adresse).State = EntityState.Added;
                context.SaveChanges();
                _testHelper.DeleteOnCleanup(adresse);
            }

            // Assert
            Assert.AreNotEqual(0, adresse.BaAdresseID);
            BaAdresse adresseAssert;
            using (var context = new KissContext())
            {
                adresseAssert = context.BaAdresse.Find(adresse.BaAdresseID);
            }
            Assert.AreEqual(strasse, adresseAssert.Strasse);
            Assert.AreEqual(baPersonID, adresseAssert.BaPersonID);
        }

        [TestMethod]
        public void TestInsert_AddHistoryVersionAutomatically()
        {
            // Arrange
            var person = new BaPerson
            {
                BaPersonID = _testHelper.Person.BaPersonID,
                Name = "Name",
                Vorname = "Vorname"
            };
            // Act
            using (var context = new KissContext())
            {
                context.BaPerson.Attach(person);
                context.Entry(person).State = EntityState.Added;
                context.SaveChanges(); // trigger throws exception if HistoryVersion is not added
                _testHelper.DeleteOnCleanup(person);
            }

            // Assert
            Assert.AreNotEqual(0, person.BaPersonID);
        }

        //[TestMethod]
        //public void TestInsertDebug()
        //{
        //    // Arrange
        //    var person = new BaPerson
        //    {
        //    };

        //    // Act
        //    using (var context = new KissContext())
        //    {
        //        context.BaPerson.Attach(person);
        //        context.Entry(person).State = EntityState.Added;
        //        context.SaveChanges();
        //        _testHelper.DeleteOnCleanup(person);
        //    }

        //    // Assert
        //    Assert.AreNotEqual(0, person.BaPersonID);
        //    BaPerson personAssert;
        //    using (var context = new KissContext())
        //    {
        //        personAssert = context.BaPerson.Find(person.BaPersonID);
        //    }
        //    //Assert.AreEqual(baPersonID, personAssert.BaPersonID);
        //}

        [TestMethod]
        public void TestInsertHistoryVersionDirectly()
        {
            // Arrange
            var historyVersion = new HistoryVersion
            {
                AppUser = "UnitTestRunner",
                VersionDate = DateTime.Now,
            };

            // Act
            using (var context = new KissContext())
            {
                context.Configuration.ValidateOnSaveEnabled = false;
                context.HistoryVersion.Attach(historyVersion);
                context.Entry(historyVersion).State = EntityState.Added;
                context.SaveChanges();
            }

            // Assert
            Assert.AreNotEqual(0, historyVersion.VerID);
        }

        [TestMethod]
        public void TestInsertWithAutoIdentitySet()
        {
            // Arrange
            const string strasse = "Teststrasse AutoIdentity";
            var baPersonID = _testHelper.Person.BaPersonID;
            const int baAdresseID = 1234;

            var adresse = new BaAdresse
            {
                BaAdresseID = baAdresseID,
                BaPersonID = _testHelper.Person.BaPersonID,
                Strasse = strasse
            };
            // Act
            using (var context = new KissContext())
            {
                context.BaAdresse.Attach(adresse);
                context.Entry(adresse).State = EntityState.Added;
                context.SaveChanges();
                _testHelper.DeleteOnCleanup(adresse); // nur im fehlerfall nötig, eigentlich sollte die adresse nicht auf der db landen
            }

            // Assert
            // da AutoIdentity gesetzt ist, wird die Adresse nicht gespeichert (weder INSERT noch UPDATE)
            BaAdresse adresseAssert;
            using (var context = new KissContext())
            {
                adresseAssert = context.BaAdresse.Find(adresse.BaAdresseID);
            }
            Assert.IsNull(adresseAssert);
        }

        [TestMethod]
        public void TestInsertWithReference()
        {
            // Arrange
            const string strasse = "Teststrasse";
            var baPersonID = _testHelper.Person.BaPersonID;

            var adresse = new BaAdresse
            {
                BaPerson = _testHelper.Person,
                BaPersonID = _testHelper.Person.BaPersonID,
                Strasse = strasse
            };

            // Act
            using (var context = new KissContext())
            {
                // Variante A: Add mit Atttach() für referenzierte Entitäten
                //context.BaPerson.Attach(adresse.BaPerson); // Wichtig, sonst wird die Entität nochmals eingefügt - trotz gesetzter ID!
                //context.BaAdresse.Add(adresse);

                // Variante B: Attach mit setzten des State
                context.BaAdresse.Attach(adresse);
                context.Entry(adresse).State = EntityState.Added;

                context.SaveChanges();
                _testHelper.DeleteOnCleanup(adresse);
            }

            // Assert
            Assert.AreNotEqual(0, adresse.BaAdresseID, "Adresse wurde nicht eingefügt oder ID der Entity danach nicht gesetzt");
            BaAdresse adresseAssert;
            using (var context = new KissContext())
            {
                adresseAssert = context.BaAdresse.Find(adresse.BaAdresseID);
            }
            Assert.AreEqual(strasse, adresseAssert.Strasse);
            Assert.AreEqual(baPersonID, adresseAssert.BaPersonID, "Person wurde nochmals eingefügt");
        }

        // TODO Test can't be enabled as long as the Concurency Mode of the timestamp is set to fixed.
        //[TestMethod]
        public void TestRemoveByIdWithoutTimestamp()
        {
            // Arrange
            XDocument document;
            using (var context = new KissContext())
            {
                document = context.XDocument.Add(new XDocument { FileBinary = new byte[] { }, DateCreation = DateTime.Now, DateLastSave = DateTime.Now, });
                context.SaveChanges();
            }

            // Act
            using (var context = new KissContext())
            {
                var dbSet = context.XDocument;
                var doc = new XDocument { DocumentID = document.DocumentID };
                dbSet.Attach(doc);
                dbSet.Remove(doc);
                TestHelper.AssertThrows<DbUpdateException>(() => context.SaveChanges());
            }

            // Assert
            using (var context = new KissContext())
            {
                var documentAssert = context.XDocument.Find(document.DocumentID);
                Assert.IsNotNull(documentAssert);
            }
        }

        [TestMethod]
        public void TestRemoveByIdWithTimestamp()
        {
            // Arrange
            XDocument document;
            using (var context = new KissContext())
            {
                document = context.XDocument.Add(new XDocument { FileBinary = new byte[] { }, DateCreation = DateTime.Now, DateLastSave = DateTime.Now, });
                context.SaveChanges();
            }

            // Act
            using (var context = new KissContext())
            {
                var dbSet = context.XDocument;
                var doc = new XDocument { DocumentID = document.DocumentID, XDocumentTS = document.XDocumentTS };
                dbSet.Attach(doc);
                dbSet.Remove(doc);
                context.SaveChanges();
            }

            // Assert
            using (var context = new KissContext())
            {
                var documentAssert = context.XDocument.Find(document.DocumentID);
                Assert.IsNull(documentAssert);
            }
        }

        [TestMethod]
        public void TestUpdateInDifferentContext()
        {
            // Arrange
            var updatedName = _testHelper.Person.Name + " geändert";
            var baPersonID = _testHelper.Person.BaPersonID;

            // Act
            BaPerson person;
            using (var context = new KissContext())
            {
                person = context.BaPerson.Find(baPersonID);
            }

            person.Name = updatedName;

            using (var context = new KissContext())
            {
                context.Entry(person).State = EntityState.Modified; // Attach and mark as modified
                context.SaveChanges();
            }

            // Assert
            BaPerson personAssert;
            using (var context = new KissContext())
            {
                personAssert = context.BaPerson.Find(baPersonID);
            }
            Assert.AreEqual(updatedName, personAssert.Name);
        }

        [TestMethod]
        public void TestUpdateInSameContext()
        {
            // Arrange
            var updatedName = _testHelper.Person.Name + " geändert";
            var baPersonID = _testHelper.Person.BaPersonID;

            // Act
            using (var context = new KissContext())
            {
                var person = context.BaPerson.Find(baPersonID);
                person.Name = updatedName;

                context.SaveChanges();
            }

            // Assert
            BaPerson personAssert;
            using (var context = new KissContext())
            {
                personAssert = context.BaPerson.Find(baPersonID);
            }
            Assert.AreEqual(updatedName, personAssert.Name);
        }

        [TestMethod]
        public void TestUpdateIsTimestampUpdatedOnEntity()
        {
            // Arrange
            var updatedName = _testHelper.Person.Name + " geändert";
            var baPersonID = _testHelper.Person.BaPersonID;
            byte[] timestampBefore;
            byte[] timestampAfter;
            byte[] timestampNewRead;

            // Act
            using (var context = new KissContext())
            {
                var person = context.BaPerson.Find(baPersonID);
                timestampBefore = person.BaPersonTS;
                person.Name = updatedName;

                context.SaveChanges();

                timestampAfter = person.BaPersonTS;
            }

            // Assert
            BaPerson personAssert;
            using (var context = new KissContext())
            {
                personAssert = context.BaPerson.Find(baPersonID);
                timestampNewRead = personAssert.BaPersonTS;
            }
            Assert.AreEqual(updatedName, personAssert.Name);
            DbTestHelper.AssertRowVersionChanged(timestampBefore, timestampAfter);
            DbTestHelper.AssertAreEqual(timestampAfter, timestampNewRead);
        }

        // TODO [TestMethod] Concurrency Mode in EDMX (Problem mit .NET 4)
        public void TestUpdateWithConcurrencyConflict()
        {
            // Arrange
            var updatedName = _testHelper.Person.Name + " geändert";
            var baPersonID = _testHelper.Person.BaPersonID;

            // Act
            BaPerson person;
            var exceptionOccured = false; // ToDo: Helpermethode für ExpectedException
            using (var context = new KissContext())
            {
                person = context.BaPerson.Find(baPersonID);
                person.Name = updatedName;

                // anderen (schnelleren) User simulieren
                using (var innerContext = new KissContext())
                {
                    var innerPerson = innerContext.BaPerson.Find(baPersonID);
                    innerPerson.Name = updatedName + updatedName;
                    innerContext.SaveChanges();
                }
                // nun speichert der langsamere User und sollte eine Concurrency-Exception erhalten
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    exceptionOccured = true;
                }
            }

            // Assert
            Assert.IsTrue(exceptionOccured, "Optimistic Locking wurde nicht geprüft");
            BaPerson personAssert;
            using (var context = new KissContext())
            {
                personAssert = context.BaPerson.Find(baPersonID);
            }
            Assert.AreEqual(updatedName + updatedName, personAssert.Name);
        }
    }
}