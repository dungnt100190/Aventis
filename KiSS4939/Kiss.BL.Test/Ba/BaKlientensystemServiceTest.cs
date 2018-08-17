using System;
using System.Collections.Generic;
using System.Transactions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Ba;
using Kiss.BL.KissSystem;
using Kiss.BL.Test.Helpers;
using Kiss.Infrastructure.IoC;
using Kiss.Infrastructure.Testing;
using Kiss.Model;

namespace Kiss.BL.Test.Ba
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class BaKlientensystemServiceTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly FaLeistungHelper _leistungHelper = new FaLeistungHelper();
        private readonly BaPersonHelper _personHelper = new BaPersonHelper();
        private readonly SqlService _sqlService = Container.Resolve<SqlService>();
        private readonly XUserHelper _userHelper = new XUserHelper();

        #endregion

        #region Private Fields

        private int _baPersonRelationID1;
        private int _baPersonRelationID2;
        private List<BaPerson> _baPersons;
        private int _faFallId;
        private int _faFallPersonId1;
        private int _faFallPersonId2;
        private FaLeistung _faLeistung;
        private bool _isFaFallPersonAView;

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
            if (!TestUtils.IsDbTest(null))
            {
                return;
            }

            using (var transaction = new TransactionScope())
            {
                // Create some temporary test objects and store the entities
                var unitOfWork = UnitOfWork.GetNew;

                _baPersons = _personHelper.Create(unitOfWork, 2);
                _isFaFallPersonAView = SystemService.CheckIfDboExists(unitOfWork, "FaFallPerson", DboType.V);

                if (_isFaFallPersonAView)
                {
                    // insert data for standard
                    _faLeistung = _leistungHelper.CreateWsh(unitOfWork);

                    // -- baPersonRelationID1
                    string insertPerson1 = @"
                        INSERT INTO dbo.BaPerson_Relation (BaPersonID_1, BaPersonID_2, DatumVon, DatumBis)
                        VALUES (@FalltraegerId, @Pers1Id, @DatumVonOk, NULL);

                        SELECT SCOPE_IDENTITY();";

                    var baPersonRelationID1 = _sqlService.ExecuteScalar(
                        unitOfWork,
                        insertPerson1,
                        new Dictionary<string, object>
                        {
                            { "@FalltraegerId", _faLeistung.BaPersonID },
                            { "@Pers1Id", _baPersons[0].BaPersonID },
                            { "@DatumVonOk", "2009-1-2" }
                        });

                    _baPersonRelationID1 = Int32.Parse(baPersonRelationID1.ToString());

                    // -- baPersonRelationID2
                    string insertPerson2 = @"
                        INSERT INTO dbo.BaPerson_Relation (BaPersonID_1, BaPersonID_2, DatumVon, DatumBis)
                        VALUES (@FalltraegerId, @Pers1Id, @DatumVonOk, @DatumBisNok);

                        SELECT SCOPE_IDENTITY();";

                    var baPersonRelationID2 = _sqlService.ExecuteScalar(
                        unitOfWork,
                        insertPerson2,
                        new Dictionary<string, object>
                        {
                            { "@FalltraegerId", _faLeistung.BaPersonID },
                            { "@Pers1Id", _baPersons[1].BaPersonID },
                            { "@DatumVonOk", "2009-1-2" },
                            { "@DatumBisNok", "2010-12-31" }
                        });

                    _baPersonRelationID2 = Int32.Parse(baPersonRelationID2.ToString());
                }
                else
                {
                    // insert data for ZH
                    var falltraeger = _personHelper.Create(unitOfWork);
                    var user = _userHelper.GetOrCreate(unitOfWork);

                    // -- faFallId
                    string insertFall = @"
                        INSERT INTO dbo.FaFall (BaPersonID, UserID)
                        VALUES (@Falltraeger, @User);";

                    var faFallId = _sqlService.ExecuteScalar(
                        unitOfWork,
                        insertFall,
                        new Dictionary<string, object>
                        {
                            { "@Falltraeger", falltraeger.BaPersonID },
                            { "@User", user.UserID }
                        });

                    _faFallId = Int32.Parse(faFallId.ToString());
                    _faLeistung = _leistungHelper.CreateWsh(unitOfWork, _faFallId);

                    // -- faFallPerson1
                    string insertPerson1 = @"
                        INSERT INTO dbo.FaFallPerson (FaFallID, BaPersonID, DatumVon, DatumBis)
                        VALUES (@FallId, @Pers1Id, @DatumVonOk, NULL);

                        SELECT SCOPE_IDENTITY();";

                    var faFallPerson1 = _sqlService.ExecuteScalar(
                        unitOfWork,
                        insertPerson1,
                        new Dictionary<string, object>
                        {
                            { "@FallId", _faFallId },
                            { "@Pers1Id", _baPersons[0].BaPersonID },
                            { "@DatumVonOk", "2009-1-2" }
                        });

                    _faFallPersonId1 = Int32.Parse(faFallPerson1.ToString());

                    // -- faFallPerson2
                    string insertPerson2 = @"
                        INSERT INTO dbo.FaFallPerson (FaFallID, BaPersonID, DatumVon, DatumBis)
                        VALUES (@FallId, @Pers1Id, @DatumVonOk, @DatumBisNok);

                        SELECT SCOPE_IDENTITY();";

                    var faFallPerson2 = _sqlService.ExecuteScalar(
                        unitOfWork,
                        insertPerson2,
                        new Dictionary<string, object>
                        {
                            { "@FallId", _faFallId },
                            { "@Pers1Id", _baPersons[0].BaPersonID },
                            { "@DatumVonOk", "2009-1-2" },
                            { "@DatumBisNok", "2010-12-31" }
                        });

                    _faFallPersonId2 = Int32.Parse(faFallPerson2.ToString());
                }

                unitOfWork.SaveChanges();
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
            if (!TestUtils.IsDbTest(null))
            {
                return;
            }

            using (var transaction = new TransactionScope())
            {
                var unitOfWork = UnitOfWork.GetNew;

                if (_isFaFallPersonAView)
                {
                    string deleteRelation = @"
                        DELETE
                        FROM dbo.BaPerson_Relation
                        WHERE BaPerson_RelationID = @id;";

                    _sqlService.ExecuteScalar(
                        unitOfWork,
                        deleteRelation,
                        new Dictionary<string, object>
                        {
                            { "@id", _baPersonRelationID1 }
                        });

                    _sqlService.ExecuteScalar(
                        unitOfWork,
                        deleteRelation,
                        new Dictionary<string, object>
                        {
                            { "@id", _baPersonRelationID2 }
                        });

                    _leistungHelper.Delete(unitOfWork);
                }
                else
                {
                    string deleteFallPerson = @"
                        DELETE
                        FROM dbo.FaFallPerson
                        WHERE FaFallPersonID = @id;";

                    _sqlService.ExecuteScalar(
                        unitOfWork,
                        deleteFallPerson,
                        new Dictionary<string, object>
                        {
                            { "@id", _faFallPersonId1 }
                        });

                    _sqlService.ExecuteScalar(
                        unitOfWork,
                        deleteFallPerson,
                        new Dictionary<string, object>
                        {
                            { "@id", _faFallPersonId2 }
                        });

                    string deleteFaFall = @"
                        DELETE
                        FROM dbo.FaFall
                        WHERE FaFallID = @id;";

                    _sqlService.ExecuteScalar(
                        unitOfWork,
                        deleteFaFall,
                        new Dictionary<string, object>
                        {
                            { "@id", _faFallId }
                        });

                    _userHelper.Delete(unitOfWork);
                }

                _personHelper.Delete(unitOfWork);

                unitOfWork.SaveChanges();
                transaction.Complete();
            }
        }

        [TestMethod]
        [TestCategory("KiSS5")]
        public void GetKlientensystemByFaLeistungId_ValidFaLeistungId_Ok()
        {
            // check first
            if (!TestUtils.IsDbTest(null))
            {
                return;
            }

            // Arrange
            var service = Container.Resolve<BaKlientensystemService>();
            var unitOfWork = UnitOfWork.GetNew;

            // Act
            var result = service.GetKlientensystemByFaLeistungId(unitOfWork, _faLeistung.FaLeistungID);

            // Assert
            Assert.AreEqual(2, result.Count);

            foreach (var baPerson in result)
            {
                Assert.AreNotEqual(_baPersons[1].BaPersonID, baPerson.BaPersonID);
            }
        }

        [TestMethod]
        [TestCategory("KiSS5")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetById_ThrowsInvalidOperationException()
        {
            // Arrange
            var service = Container.Resolve<BaKlientensystemService>();
            var unitOfWork = UnitOfWork.GetNew;

            // Act
            service.GetById(unitOfWork, 1);

            // Assert
            Assert.IsFalse(true); // not expected to be reached
        }

        [TestMethod]
        [TestCategory("KiSS5")]
        public void GetKlientensystemByFaFallId_ValidFaFallId_Ok()
        {
            // check first
            if (!TestUtils.IsDbTest(null))
            {
                return;
            }

            // Arrange
            var service = Container.Resolve<BaKlientensystemService>();
            var unitOfWork = UnitOfWork.GetNew;
            var paramFaFallID = _isFaFallPersonAView ? _faLeistung.BaPersonID : _faFallId;

            // Act
            var result = service.GetKlientensystemByFaFallId(unitOfWork, paramFaFallID);

            // Assert
            Assert.AreEqual(2, result.Count);

            foreach (var baPerson in result)
            {
                Assert.AreNotEqual(_baPersons[1].BaPersonID, baPerson.BaPersonID);
            }
        }

        #endregion
    }
}