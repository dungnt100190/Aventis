using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Kbu;
using Kiss.Infrastructure;
using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.Testing;
using Kiss.Interfaces.Database;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Kbu;

namespace Kiss.BL.Test.Kbu
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class KbuKontoServiceTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CREATOR = "UnitTester";

        #endregion

        #region Private Fields

        private List<KbuKonto> _entities;

        #endregion

        #endregion

        #region Test Methods

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            TestServiceBase.ClassInitialize(DatabaseTestUtil.CONNECTION_STRING_NAME_KISS5);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            using (var transaction = new TransactionScope())
            {

                // Create some temporary test objects and store the entities
                var unitOfWork = UnitOfWork.GetNew;
                var repository = UnitOfWork.GetRepository<KbuKonto>(unitOfWork);

                _entities = new List<KbuKonto>
                {
                    new KbuKonto()
                    {
                        KontoNr = "12",
                        Name = "Geldfresserli",
                        KbuKontoklasseCode = (int) LOVsGenerated.KbuKontoklasse.Aufwand,
                        Creator = CREATOR,
                        Created = new DateTime(2010, 01, 01),
                        Modifier = CREATOR,
                        Modified = new DateTime(2010, 01, 01),
                    },
                    new KbuKonto()
                    {
                        KontoNr = "88",
                        Name = "Bürobedarf",
                        KbuKontoklasseCode = (int) LOVsGenerated.KbuKontoklasse.Aufwand,
                        Creator = CREATOR,
                        Created = new DateTime(2010, 01, 01),
                        Modifier = CREATOR,
                        Modified = new DateTime(2010, 01, 01),
                    },
                    new KbuKonto()
                    {
                        KontoNr = "99",
                        Name = "Verpflegung",
                        KbuKontoklasseCode = (int) LOVsGenerated.KbuKontoklasse.Aufwand,
                        Creator = CREATOR,
                        Created = new DateTime(2010, 01, 01),
                        Modifier = CREATOR,
                        Modified = new DateTime(2010, 01, 01),
                    }
                };

                _entities.ForEach(x => repository.ApplyChanges(x));
                unitOfWork.SaveChanges();
                _entities.ForEach(x => x.AcceptChanges());

                transaction.Complete();
            }
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TestServiceBase.ClassCleanup();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            using (var transaction = new TransactionScope())
            {
                var unitOfWork = UnitOfWork.GetNew;
                var repository = UnitOfWork.GetRepository<KbuKonto>(unitOfWork);

                // Delete the temporary test objects
                _entities.ForEach(x => x.MarkAsDeleted());
                _entities.ForEach(repository.ApplyChanges);

                unitOfWork.SaveChanges();
                transaction.Complete();
            }
        }

        [TestMethod]
        public void GetGblKonto_Ok()
        {
            // Arrange
            var service = Container.Resolve<KbuKontoService>();

            //Act
            KbuKonto konto = service.GetGblKonto(null);

            //Assert
        }

        #endregion
    }
}