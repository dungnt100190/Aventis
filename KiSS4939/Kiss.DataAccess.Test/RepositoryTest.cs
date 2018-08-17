using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;

using Kiss.DataAccess.Test.Seeder;
using Kiss.DbContext;
using Kiss.DbContext.Test;
using Kiss.Infrastructure.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.DataAccess.Test
{
    [TestClass]
    public class RepositoryTest
    {
        private DbTestHelper _testHelper;

        [TestInitialize]
        public void Setup()
        {
            _testHelper = new DbTestHelper();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _testHelper.Dispose();
        }

        [TestMethod]
        public void TestGet()
        {
            // Act
            BaPerson person;
            using (var uow = new KissUnitOfWork())
            {
                person = uow.BaPerson.GetById(_testHelper.Person.BaPersonID);
            }

            // Assert
            Assert.IsNotNull(person);
            Assert.AreEqual(_testHelper.Person.BaPersonID, person.BaPersonID);
            Assert.AreEqual(_testHelper.Person.Name, person.Name);
        }

        //[TestMethod]
        //public void TestGetInUnchangedState()
        //{
        //    // Act
        //    BaPerson person;
        //    using (var uow = new KissUnitOfWork())
        //    {
        //        person = uow.BaPerson.GetById(_testHelper.Person.BaPersonID);
        //    }

        //    // Assert
        //    Assert.IsNotNull(person);
        //    Assert.AreEqual(EntityState.Unchanged, person.EntityState);
        //}

        //[TestMethod]
        //public void TestGetMulitpleInUnchangedState()
        //{
        //    // Act
        //    BFSKatalogVersion[] versionen;
        //    using (var uow = new KissUnitOfWork())
        //    {
        //        var result = uow.BFSKatalogVersion.GetAllEntities();
        //        versionen = result.ToArray();
        //    }

        //    // Assert
        //    Assert.IsNotNull(versionen);
        //    Assert.AreNotEqual(versionen.Length, 0);
        //    Assert.AreEqual(EntityState.Unchanged, versionen[0].EntityState);
        //}


        [TestMethod]
        public void TestInsertInvalidPerson()
        {
            // Act
            using (var uow = new KissUnitOfWork())
            {
                var person = new BaPerson
                {
                    Name = "Müller",
                    Vorname = "Hans",
                    Sterbedatum = DateTime.Today.AddDays(-10),
                    Geburtsdatum = DateTime.Today // Geburtsdatum nach Sterbedatum, wird in BaPersonValidator abgefangen
                };
                uow.BaPerson.InsertOrUpdateEntity(person);

                TestHelper.AssertThrows<DbEntityValidationException>(() => uow.SaveChanges(), null, "Die Validierung müsste fehlschlagen, da das Sterbedatum vor dem Geburtsdatum liegt.");
            }
        }

        [TestMethod]
        public void TestInsert()
        {
            // Act
            int baPersonID;
            using (var uow = new KissUnitOfWork())
            {
                var person = new BaPerson
                {
                    Name = "Müller",
                    Vorname = "Hans"
                };
                uow.BaPerson.InsertOrUpdateEntity(person);

                uow.SaveChanges();
                baPersonID = person.BaPersonID;
            }

            // Assert
            Assert.AreNotEqual(0, baPersonID);
            using (var context = new KissContext())
            {
                var personAssert = context.BaPerson.Find(baPersonID);
                Assert.IsNotNull(personAssert);
            }
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
            using (var uow = new KissUnitOfWork())
            {
                uow.BaAdresse.InsertOrUpdateEntity(adresse);
                uow.SaveChanges();
                _testHelper.DeleteOnCleanup(adresse);
            }
            var baPersonIdInserted = adresse.BaPerson.BaPersonID;

            // Assert
            Assert.AreNotEqual(0, adresse.BaAdresseID);
            Assert.AreEqual(baPersonID, baPersonIdInserted, "Referenzierte Person darf nicht noch einmal eingefügt werden");
            BaAdresse adresseAssert;
            using (var context = new KissContext())
            {
                adresseAssert = context.BaAdresse.Find(adresse.BaAdresseID);
            }
            Assert.AreEqual(strasse, adresseAssert.Strasse);
            Assert.AreEqual(baPersonID, adresseAssert.BaPersonID);
        }

        [TestMethod]
        public void TestUpdate()
        {
            // Act
            BaPerson personAct;
            using (var uow = new KissUnitOfWork())
            {
                var repository = uow.BaPerson;
                personAct = repository.GetById(_testHelper.Person.BaPersonID);
                personAct.Vorname += "test";
                repository.InsertOrUpdateEntity(personAct);

                uow.SaveChanges();
            }

            // Assert
            using (var context = new KissContext())
            {
                var personAssert = context.BaPerson.Find(_testHelper.Person.BaPersonID);
                Assert.AreEqual(personAct.Vorname, personAssert.Vorname);
            }
        }

        [TestMethod]
        public void TestUpdateShouldAffectRowversion()
        {
            // Act
            byte[] rowversionBefore;
            using (var uow = new KissUnitOfWork())
            {
                var repository = uow.BaPerson;
                var person = repository.GetById(_testHelper.Person.BaPersonID);
                rowversionBefore = person.BaPersonTS;
                person.Vorname += "test";
                repository.InsertOrUpdateEntity(person);

                uow.SaveChanges();
            }

            // Assert
            using (var context = new KissContext())
            {
                var personAssert = context.BaPerson.Find(_testHelper.Person.BaPersonID);
                Assert.IsNotNull(personAssert);
                var rowversionAfter = personAssert.BaPersonTS;
                DbTestHelper.AssertRowVersionChanged(rowversionBefore, rowversionAfter);
            }
        }

        [TestMethod]
        public void TestImplicitTransactionDuringInsertOfIndependentEntities()
        {
            // Arrange
            var person = new BaPerson
            {
                Name = "Meier",
                Vorname = "Hans"
            };
            var adresse = new BaAdresse
            {
                BaPersonID = -1, //invalid
                DatumVon = DateTime.Today,
            };

            // Act
            using (var context = new KissUnitOfWork())
            {
                var adresseRepository = context.BaAdresse;
                adresseRepository.InsertOrUpdateEntity(adresse);
                var personRepository = context.BaPerson;
                personRepository.InsertOrUpdateEntity(person);

                _testHelper.DeleteOnCleanup(person);
                _testHelper.DeleteOnCleanup(adresse);

                TestHelper.AssertThrows<DbUpdateException>(() => { context.SaveChanges(); }, null, "Die Adresse dürfte wegen der ungültigen BaPersonID nicht eingefügt werden");
            }

            // Assert
            BaPerson personAssert;
            using (var context = new KissContext())
            {
                personAssert = context.BaPerson.Find(person.BaPersonID);
            }
            Assert.IsNull(personAssert, "Durch das implizite Transaktionshandling des DbContext dürfte das Insert der Person nicht commited werden");
        }

        [TestMethod]
        public void TestImplicitTransactionDuringInsertOfParentChildEntities()
        {
            // Arrange
            var person = new BaPerson
            {
                Name = "Meier",
                Vorname = "Hans"
            };
            var adresse = new BaAdresse
            {
                BaPerson = person,
                BaPersonID = person.BaPersonID,
                DatumVon = DateTime.MinValue, //invalid
            };

            // Act
            using (var context = new KissUnitOfWork())
            {
                var adresseRepository = context.BaAdresse;
                adresseRepository.InsertOrUpdateEntity(adresse);

                _testHelper.DeleteOnCleanup(person);
                _testHelper.DeleteOnCleanup(adresse);

                TestHelper.AssertThrows<DbUpdateException>(() => context.SaveChanges(), null, "Die Adresse dürfte wegen des ungültigen Datums nicht eingefügt werden");
            }

            // Assert
            BaPerson personAssert;
            using (var context = new KissContext())
            {
                personAssert = context.BaPerson.Find(person.BaPersonID);
            }
            Assert.IsNull(personAssert, "Durch das implizite Transaktionshandling des DbContext dürfte das Insert der Person nicht commited werden");
        }

        [TestMethod]
        public void TestUpdateDetectConcurrencyProblem()
        {
            // Act
            // der langsamere User holt sich eine entität
            BaPerson personGet;
            using (var uow = new KissUnitOfWork())
            {
                personGet = uow.BaPerson.GetById(_testHelper.Person.BaPersonID);
            }

            // anderen (schnelleren) User simulieren
            using (var context = new KissContext())
            {
                var personOther = context.BaPerson.Find(_testHelper.Person.BaPersonID);
                personOther.Bemerkung += "blabla";
                context.SaveChanges();
            }

            // nun speichert der langsamere User und sollte eine Concurrency-Exception erhalten
            using (var uow = new KissUnitOfWork())
            {
                TestHelper.AssertThrows<DBConcurrencyException>(() => uow.BaPerson.InsertOrUpdateEntity(personGet), null, "Concurrency-Problem wurde nicht detektiert");
                uow.SaveChanges();
            }
        }

        //[TestMethod]
        //public void TestConcurrencyCheckWithEntityWithoutRowversion()
        //{
        //    // Arrange
        //    BFSKatalogVersion katalog;
        //    using (var context = new KissContext())
        //    {
        //        katalog = new BFSKatalogVersion
        //                          {
        //                              BFSKatalogVersionID = 20010101,
        //                              Jahr = 2001
        //                          };
        //        context.BFSKatalogVersion.Add(katalog);
        //        _testHelper.DeleteOnCleanup(katalog);
        //        context.SaveChanges();
        //    }

        //    // Act
        //    using (var context = new KissUnitOfWork())
        //    {
        //        var repository = context.BFSKatalogVersion;
        //        var localKatalog = repository.GetById(katalog.BFSKatalogVersionID);
        //        localKatalog.Jahr += 1;
        //        repository.InsertOrUpdateEntity(localKatalog);
        //        context.SaveChanges();
        //    }
        //}

        [TestMethod]
        public void TestUpdateUnchangedEntityTimestampShouldBeUnchanged()
        {
            // Arrange
            var baPersonID = _testHelper.Person.BaPersonID;
            byte[] timestampBefore;
            byte[] timestampAfter;
            byte[] timestampNewRead;

            // Act
            using (var context = new KissUnitOfWork())
            {
                var person = context.BaPerson.GetById(baPersonID);
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
        public void TestUpdateUnchangedEntityInDifferentContextTimestampShouldBeUnchanged()
        {
            // Arrange
            var baPersonID = _testHelper.Person.BaPersonID;
            byte[] timestampBefore;
            byte[] timestampAfter;
            byte[] timestampNewRead;

            // Act
            // Testperson laden, 
            BaPerson person;
            using (var uow = new KissUnitOfWork())
            {
                person = uow.BaPerson.GetById(baPersonID);
                timestampBefore = person.BaPersonTS;
            }
            // verändern, Änderung rückgängig machen
            var originalName = person.Name;
            person.Name = originalName + " test";
            person.Name = originalName;

            // speichern
            using (var uow = new KissUnitOfWork())
            {
                uow.BaPerson.InsertOrUpdateEntity(person);
                uow.SaveChanges();

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
            DbTestHelper.AssertAreEqual(timestampBefore, timestampAfter, "TS sollte unverändert bleiben, da die Entität beim Speichern wieder unverändert war");
            DbTestHelper.AssertAreEqual(timestampAfter, timestampNewRead, "TS darf auch auf DB nicht verändert worden sein");
        }

        [TestMethod]
        public void TestRemove()
        {
            // Arrange
            BaPerson person;
            using (var context = new KissContext())
            {
                person = context.BaPerson.Add(new BaPerson { Name = "Kissinger", Vorname = "Henry" });
                context.SaveChanges();
            }

            // Act
            using (var uow = new KissUnitOfWork())
            {
                uow.BaPerson.Remove(person);
                uow.SaveChanges();
            }

            // Assert
            using (var context = new KissContext())
            {
                var personAssert = context.BaPerson.Find(person.BaPersonID);
                Assert.IsNull(personAssert);
            }
        }

        [TestMethod]
        public void Test_UpdateAfterDeleteByOtherUser_ExceptionShouldBeThrown()
        {
            // Arrange
            var testPerson = _testHelper.Person;

            // Act
            BaPerson person;
            using (var uowGet = new KissUnitOfWork())
            {
                person = uowGet.BaPerson.GetById(testPerson.BaPersonID);
            }
            var originalName = person.Name;
            person.Name = originalName + " test";
            person.Name = originalName;

            // other user deletes entity
            using (var uowOtherUser = new KissUnitOfWork())
            {
                uowOtherUser.BaPerson.Remove(testPerson);
                uowOtherUser.SaveChanges();
            }

            // try to save
            using (var uowSave = new KissUnitOfWork())
            {
                TestHelper.AssertThrows<DbUpdateException>(() => uowSave.BaPerson.InsertOrUpdateEntity(person));
            }
        }


        [TestMethod]
        public void Test_DontUpdateUnchangedReferencedEntity()
        {
            // Arrange
            using (var seed = new DbSeed(() => new KissUnitOfWork()))
            {
                var klientenbudget = seed.GetOrCreateEntity<VmKlientenbudget>();
                seed.CreateSeed();

                // Act
                klientenbudget.VmKlientenbudgetMutationsgrundCode += 1;
                using (var unitOfWork = new KissUnitOfWork())
                {
                    var state = unitOfWork.VmKlientenbudget.InsertOrUpdateEntity(klientenbudget);
                    // wird XUser updated? falls ja, gibt es eine exception, weil keine HistoryVersion erstellt wurde
                    unitOfWork.SaveChanges();
                }

                // Assert
                // nop, keine exception heisst ok
            }
        }
    }
}
