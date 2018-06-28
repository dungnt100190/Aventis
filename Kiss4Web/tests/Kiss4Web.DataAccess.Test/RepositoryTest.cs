using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.DataAccess.Context;
using Kiss4Web.Infrastructure.Modularity;
using Kiss4Web.Model;
using Kiss4Web.TestInfrastructure;
using Kiss4Web.TestInfrastructure.TestServer;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace Kiss4Web.DataAccess.Test
{
    public class RepositoryTest : IntegrationTest
    {
        public RepositoryTest(TestServerFixture integrationTestEnvironment)
            : base(integrationTestEnvironment)
        {
        }

        [Fact]
        public async Task Test_DontUpdateUnchangedReferencedEntity()
        {
            var testUser = IntegrationTestEnvironment.TestData<XUserTestData>().Administrator;
            var testAdresse = new BaAdresse
            {
                UserId = testUser.UserId,
                Bemerkung = "testadresse"
            };

            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var context = IntegrationTestEnvironment.Container.GetInstance<Kiss4DbContext>();
                var adressen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaAdresse>>();

                await adressen.InsertOrUpdateEntity(testAdresse);
                await context.SaveChangesAsync();
            }

            // Arrange
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var context = IntegrationTestEnvironment.Container.GetInstance<Kiss4DbContext>();
                var adressen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaAdresse>>();
                var adresse = await adressen.Where(adr => adr.Id == testAdresse.BaAdresseId)
                                            .Include(adr => adr.User)
                                            .FirstOrDefaultAsync();

                // Act
                adresse.Bemerkung += "blabla";
                await adressen.InsertOrUpdateEntity(adresse);
                // wird XUser updated? falls ja, gibt es eine exception, weil keine HistoryVersion erstellt wurde
                await context.SaveChangesAsync();

                // Assert
                // nop, keine exception heisst ok
            }
        }

        [Fact]
        public async Task Test_UpdateAfterDeleteByOtherUser_ExceptionShouldBeThrown()
        {
            // Arrange
            var testPerson = IntegrationTestEnvironment.TestData<BaPersonTestData>().Vasquez;

            // Act
            BaPerson person;
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();
                person = await personen.GetById(testPerson.BaPersonId);
            }

            var originalName = person.Name;
            person.Name = originalName + " test";
            person.Name = originalName;

            // other user deletes entity
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var context = IntegrationTestEnvironment.Container.GetInstance<Kiss4DbContext>();
                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();
                personen.Remove(prs => prs.BaPersonId == testPerson.BaPersonId);
                person = await personen.GetById(testPerson.BaPersonId);
                await context.SaveChangesAsync();
            }

            // try to save
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();
                await Should.ThrowAsync<DbUpdateException>(() => personen.InsertOrUpdateEntity(person));
            }
        }

        [Fact]
        public async Task TestGet()
        {
            var expectedPerson = IntegrationTestEnvironment.TestData<BaPersonTestData>().Vasquez;

            // Act
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();
                var person = await personen.GetById(expectedPerson.Id);

                // Assert
                person.ShouldNotBeNull("Person not found");
                person.BaPersonId.ShouldBe(expectedPerson.Id);
                person.Name.ShouldBe(expectedPerson.Name);
                person.Vorname.ShouldBe(expectedPerson.Vorname);
            }
        }

        [Fact]
        public async Task TestGetInUnchangedState()
        {
            var expectedPerson = IntegrationTestEnvironment.TestData<BaPersonTestData>().Vasquez;

            // Act
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var context = IntegrationTestEnvironment.Container.GetInstance<Kiss4DbContext>();

                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();
                var person = await personen.GetById(expectedPerson.Id);

                // Assert
                context.ChangeTracker.DetectChanges();
                var entry = context.ChangeTracker.Entries<BaPerson>().FirstOrDefault(prs => prs.Entity.BaPersonId == person.Id);
                entry.ShouldNotBeNull();

                entry.State.ShouldBe(EntityState.Unchanged);
            }
        }

        [Fact]
        public async Task TestImplicitTransactionDuringInsertOfIndependentEntities()
        {
            // Arrange
            var person = new BaPerson
            {
                Name = "Meier",
                Vorname = "Hans"
            };
            var adresse = new BaAdresse
            {
                BaPersonId = -1, //invalid
                DatumVon = DateTime.Today,
            };

            // Act
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var context = IntegrationTestEnvironment.Container.GetInstance<IDbContext>();
                var adressen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaAdresse>>();
                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();

                await adressen.InsertOrUpdateEntity(adresse);
                await personen.InsertOrUpdateEntity(person);
                var ex = await Should.ThrowAsync<DbUpdateException>(context.SaveChangesAsync(), "Die Adresse dürfte wegen der ungültigen BaPersonID nicht eingefügt werden");
                var sqlEx = ex.InnerException.ShouldBeOfType<SqlException>();
                sqlEx.Number.ShouldBe(547);
            }

            // Assert
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();
                var personAssert = await personen.GetById(person.BaPersonId);
                personAssert.ShouldBeNull("Durch das implizite Transaktionshandling des DbContext dürfte das Insert der Person nicht commited werden");
            }
        }

        [Fact]
        public async Task TestImplicitTransactionDuringInsertOfParentChildEntities()
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
                BaPersonId = person.BaPersonId,
                DatumVon = DateTime.MinValue, // invalid because SQL datetime.Min is 01.01.1753
            };

            // Act
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var context = IntegrationTestEnvironment.Container.GetInstance<IDbContext>();
                var adressen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaAdresse>>();

                await adressen.InsertOrUpdateEntity(adresse);
                var ex = await Should.ThrowAsync<DbUpdateException>(context.SaveChangesAsync(), "Die Adresse dürfte wegen des ungültigen Datums nicht eingefügt werden");
                var sqlEx = ex.InnerException.ShouldBeOfType<SqlTypeException>();
            }

            // Assert
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();
                var personAssert = await personen.GetById(person.BaPersonId);
                personAssert.ShouldBeNull("Durch das implizite Transaktionshandling des DbContext dürfte das Insert der Person nicht commited werden");
            }
        }

        [Fact]
        public async Task TestInsert()
        {
            // Act
            int baPersonId;
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var context = IntegrationTestEnvironment.Container.GetInstance<IDbContext>();
                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();
                var person = new BaPerson
                {
                    Name = "Müller",
                    Vorname = "Hans"
                };
                await personen.InsertOrUpdateEntity(person);

                await context.SaveChangesAsync();
                baPersonId = person.BaPersonId;
            }

            // Assert
            baPersonId.ShouldNotBe(0);
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();
                var personAssert = await personen.GetById(baPersonId);
                personAssert.ShouldNotBeNull();
            }
        }

        [Fact]
        public async Task TestInsert_CcmmShouldBeSet()
        {
            // Arrange
            var now = new DateTime(2020, 1, 1);
            IntegrationTestEnvironment.DateTime.SetLocalTime(now);

            // Act
            int baPersonId;
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var context = IntegrationTestEnvironment.Container.GetInstance<IDbContext>();
                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();
                var person = new BaPerson
                {
                    Name = "Müller",
                    Vorname = "Hans"
                };
                await personen.InsertOrUpdateEntity(person);

                await context.SaveChangesAsync();
                baPersonId = person.BaPersonId;
            }

            // Assert
            baPersonId.ShouldNotBe(0);
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();
                var personAssert = await personen.GetById(baPersonId);
                personAssert.ShouldNotBeNull();
                personAssert.Created.ShouldBe(now);
                personAssert.Modified.ShouldBe(now);
            }
        }

        //[Fact]
        //public void TestInsertInvalidPerson()
        //{
        //    // Act
        //    using (new EnsureExecutionScope(Server.Container))
        //    {
        //        var context = Server.Container.GetInstance<IDbContext>();
        //        var personen = Server.Container.GetInstance<IRepository<BaPerson>>();
        //        var person = new BaPerson
        //        {
        //            Name = "Müller",
        //            Vorname = "Hans",
        //            Sterbedatum = DateTime.Today.AddDays(-10),
        //            Geburtsdatum = DateTime.Today // Geburtsdatum nach Sterbedatum, wird in BaPersonValidator abgefangen
        //        };
        //        personen.InsertOrUpdateEntity(person);

        //        var ex = Should.ThrowAsync<Exception>(() => context.SaveChangesAsync(), "Die Validierung müsste fehlschlagen, da das Sterbedatum vor dem Geburtsdatum liegt.");
        //    }
        //}

        [Fact]
        public async Task TestInsertWithReference()
        {
            var testPerson = IntegrationTestEnvironment.TestData<BaPersonTestData>().Vasquez;

            // Arrange
            const string strasse = "Teststrasse";
            var baPersonId = testPerson.BaPersonId;

            var adresse = new BaAdresse
            {
                BaPerson = testPerson,
                BaPersonId = testPerson.BaPersonId,
                Strasse = strasse
            };

            // Act
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var context = IntegrationTestEnvironment.Container.GetInstance<IDbContext>();
                var adressen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaAdresse>>();

                await adressen.InsertOrUpdateEntity(adresse);
                await context.SaveChangesAsync();
            }
            var baPersonIdInserted = adresse.BaPersonId;

            // Assert
            adresse.BaAdresseId.ShouldNotBe(0);
            baPersonIdInserted.ShouldBe(baPersonId, "Referenzierte Person darf nicht noch einmal eingefügt werden");
            BaAdresse adresseAssert;
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var adressen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaAdresse>>();
                adresseAssert = await adressen.GetById(adresse.BaAdresseId);
            }
            adresseAssert.Strasse.ShouldBe(strasse);
            adresseAssert.BaPersonId.ShouldBe(baPersonId);
        }

        [Fact]
        public async Task TestRemove()
        {
            // Arrange
            var person = IntegrationTestEnvironment.TestData<BaPersonTestData>().Vasquez;

            // Act
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var context = IntegrationTestEnvironment.Container.GetInstance<IDbContext>();
                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();
                personen.Remove(person);
                await context.SaveChangesAsync();
            }

            // Assert
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();
                var personAssert = await personen.GetById(person.BaPersonId);
                personAssert.ShouldBeNull();
            }
        }

        [Fact]
        public async Task TestUpdate()
        {
            // Arrange
            var person = IntegrationTestEnvironment.TestData<BaPersonTestData>().Vasquez;

            // Act
            string newVorname;
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var context = IntegrationTestEnvironment.Container.GetInstance<IDbContext>();
                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();

                var personAct = await personen.GetById(person.BaPersonId);
                newVorname = personAct.Vorname + "-test";
                personAct.Vorname = newVorname;
                //await personen.InsertOrUpdateEntity(personAct);

                await context.SaveChangesAsync();
            }

            // Assert
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();
                var personAssert = await personen.GetById(person.BaPersonId);
                personAssert.Vorname.ShouldBe(newVorname);
            }
        }

        [Fact]
        public async Task TestUpdate_ModifierShouldBeSet()
        {
            // Arrange
            var person = IntegrationTestEnvironment.TestData<BaPersonTestData>().Vasquez;
            var now = new DateTime(2020, 1, 1);
            IntegrationTestEnvironment.DateTime.SetLocalTime(now);
            var createdBefore = person.Created;

            // Act
            string newVorname;
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var context = IntegrationTestEnvironment.Container.GetInstance<IDbContext>();
                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();

                var personAct = await personen.GetById(person.BaPersonId);
                newVorname = personAct.Vorname + "-test";
                personAct.Vorname = newVorname;
                //await personen.InsertOrUpdateEntity(personAct);

                await context.SaveChangesAsync();
            }

            // Assert
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();
                var personAssert = await personen.GetById(person.BaPersonId);
                personAssert.Vorname.ShouldBe(newVorname);
                personAssert.Modified.ShouldBe(now);
            }
        }

        [Fact]
        public async Task TestUpdate_CreatedShouldBeUnchanged()
        {
            // Arrange
            var person = IntegrationTestEnvironment.TestData<BaPersonTestData>().Vasquez;
            var now = new DateTime(2020, 1, 1);
            IntegrationTestEnvironment.DateTime.SetLocalTime(now);
            var createdBefore = person.Created;

            // Act
            string newVorname;
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var context = IntegrationTestEnvironment.Container.GetInstance<IDbContext>();
                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();

                var personAct = await personen.GetById(person.BaPersonId);
                newVorname = personAct.Vorname + "-test";
                personAct.Vorname = newVorname;
                //await personen.InsertOrUpdateEntity(personAct);

                await context.SaveChangesAsync();
            }

            // Assert
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();
                var personAssert = await personen.GetById(person.BaPersonId);
                personAssert.Vorname.ShouldBe(newVorname);
                personAssert.Created.ShouldBeWithSqlDateTimePrecision(createdBefore);
            }
        }

        [Fact]
        public async Task TestUpdateDetectConcurrencyProblem()
        {
            // Arrange
            var person = IntegrationTestEnvironment.TestData<BaPersonTestData>().Vasquez;

            // Act
            // first User gets an entity
            BaPerson personGet;

            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();
                personGet = await personen.GetById(person.BaPersonId);
                personGet.Bemerkung += "bla";
            }

            // simulate second (quicker) User who changes the same entity
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var context = IntegrationTestEnvironment.Container.GetInstance<IDbContext>();
                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();

                var personQuick = await personen.GetById(person.BaPersonId);
                personQuick.Bemerkung += "blabla";
                //await personen.InsertOrUpdateEntity(person);
                await context.SaveChangesAsync();
            }

            // nun speichert der langsamere User und sollte eine Concurrency-Exception erhalten
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var context = IntegrationTestEnvironment.Container.GetInstance<IDbContext>();
                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();
                await personen.InsertOrUpdateEntity(personGet);
                var ex = await Should.ThrowAsync<DbUpdateConcurrencyException>(() => context.SaveChangesAsync(), "Concurrency problem was not detected");
            }
        }

        [Fact]
        public async Task TestUpdateShouldAffectRowversion()
        {
            // Arrange
            var testPerson = IntegrationTestEnvironment.TestData<BaPersonTestData>().Vasquez;

            // Act
            byte[] rowversionBefore;
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var context = IntegrationTestEnvironment.Container.GetInstance<IDbContext>();
                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();

                var person = await personen.GetById(testPerson.BaPersonId);
                rowversionBefore = testPerson.BaPersonTs;
                person.Vorname += "test";
                await personen.InsertOrUpdateEntity(person);

                await context.SaveChangesAsync();
            }

            // Assert
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();

                var personAssert = await personen.GetById(testPerson.BaPersonId);
                personAssert.ShouldNotBeNull();
                var rowversionAfter = personAssert.BaPersonTs;
                rowversionAfter.ShouldNotBe(rowversionBefore);
            }
        }

        [Fact]
        public async Task TestConcurrencyCheckWithEntityWithoutRowversion()
        {
            // Arrange
            BfskatalogVersion katalog;
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var context = IntegrationTestEnvironment.Container.GetInstance<Kiss4DbContext>();
                const int katalogId = 20010101;
                katalog = await context.BfskatalogVersion.FirstOrDefaultAsync(bkv => bkv.BfskatalogVersionId == katalogId);
                if (katalog == null)
                {
                    katalog = new BfskatalogVersion
                    {
                        BfskatalogVersionId = katalogId,
                        Jahr = 2001
                    };
                    context.BfskatalogVersion.Add(katalog);
                    await context.SaveChangesAsync();
                }
            }

            // Act
            int? newYear;
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var context = IntegrationTestEnvironment.Container.GetInstance<Kiss4DbContext>();
                var kataloge = context.BfskatalogVersion;
                var localKatalog = await kataloge.FindAsync(katalog.BfskatalogVersionId);
                newYear = localKatalog.Jahr + 1;
                localKatalog.Jahr = newYear;
                //await repository.(localKatalog);
                await context.SaveChangesAsync();
            }

            // Assert
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var context = IntegrationTestEnvironment.Container.GetInstance<Kiss4DbContext>();
                var kataloge = context.BfskatalogVersion;
                var localKatalog = await kataloge.FindAsync(katalog.BfskatalogVersionId);

                localKatalog.Jahr.ShouldBe(newYear);
            }
        }

        [Fact]
        public async Task TestUpdateUnchangedEntityInDifferentContextTimestampShouldBeUnchanged()
        {
            // Arrange
            var testPerson = IntegrationTestEnvironment.TestData<BaPersonTestData>().Vasquez;
            var testPersonId = testPerson.Id;
            byte[] timestampBefore;
            byte[] timestampAfter;
            byte[] timestampNewRead;

            // Act
            // Testperson laden
            BaPerson person;
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();
                person = await personen.GetById(testPersonId);
                timestampBefore = person.BaPersonTs;
            }

            // make a change and then reverse it
            var originalName = person.Name;
            person.Name = originalName + " test";
            person.Name = originalName;

            // save
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var context = IntegrationTestEnvironment.Container.GetInstance<IDbContext>();
                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();

                await personen.InsertOrUpdateEntity(person);
                await context.SaveChangesAsync();

                timestampAfter = person.BaPersonTs;
            }

            // Assert
            BaPerson personAssert;
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();

                personAssert = await personen.GetById(testPersonId);
                timestampNewRead = personAssert.BaPersonTs;
            }
            personAssert.Name.ShouldBe(testPerson.Name);
            timestampBefore.ShouldBe(timestampAfter, "Timestamp should be unchanged since the entity was unchanged");
            timestampBefore.ShouldBe(timestampNewRead, "Timestamp should be unchanged also on the database");
        }

        [Fact]
        public async Task TestUpdateUnchangedEntityTimestampShouldBeUnchanged()
        {
            // Arrange
            var testPerson = IntegrationTestEnvironment.TestData<BaPersonTestData>().Vasquez;
            var testPersonId = testPerson.Id;
            byte[] timestampBefore;
            byte[] timestampAfter;
            byte[] timestampNewRead;

            // Act
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var context = IntegrationTestEnvironment.Container.GetInstance<IDbContext>();
                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();

                var person = await personen.GetById(testPersonId);
                timestampBefore = person.BaPersonTs;

                var originalName = person.Name;
                person.Name = originalName + " test";
                person.Name = originalName;

                await context.SaveChangesAsync();

                timestampAfter = person.BaPersonTs;
            }

            // Assert
            BaPerson personAssert;
            using (new EnsureExecutionScope(IntegrationTestEnvironment.Container))
            {
                var personen = IntegrationTestEnvironment.Container.GetInstance<IRepository<BaPerson>>();
                personAssert = await personen.GetById(testPersonId);
                timestampNewRead = personAssert.BaPersonTs;
            }
            personAssert.Name.ShouldBe(testPerson.Name);
            timestampBefore.ShouldBe(timestampAfter, "Timestamp should be unchanged since the entity was unchanged");
            timestampBefore.ShouldBe(timestampNewRead, "Timestamp should be unchanged also on the database");
        }
    }
}