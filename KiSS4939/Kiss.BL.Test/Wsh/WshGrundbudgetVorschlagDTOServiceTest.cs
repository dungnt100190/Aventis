using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Test.Helpers;
using Kiss.BL.Wsh;
using Kiss.Interfaces;
using Kiss.Interfaces.IoC;
using Kiss.Interfaces.ViewModel;
using Kiss.Model;
using Kiss.Model.DTO.Wsh;

namespace Kiss.BL.Test.Wsh
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class WshGrundbudgetVorschlagDTOServiceTest
    {
        #region Fields

        #region Private Static Fields

        private static readonly Dictionary<string, QuestionAnswerOption> _questionsAndAnswers = new Dictionary<string, QuestionAnswerOption>();

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly WshGrundbudgetHelper _grundbudgetHelper = new WshGrundbudgetHelper();

        #endregion

        #endregion

        #region Test Methods

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            TestServiceBase.ClassInitialize();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            using (var transaction = new TransactionScope())
            {
                // Create some temporary test objects and store the entities
                var unitOfWork = UnitOfWork.GetNew;
                _grundbudgetHelper.CreateGrundbudget(unitOfWork);

                // persist
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
                _grundbudgetHelper.Delete(unitOfWork);
                transaction.Complete();
            }
        }

        [TestMethod]
        public void SaveBerechnetePosition_CreateNewPositions()
        {
            // Arrange
            var unitOfWork = UnitOfWork.GetNew;
            if (!TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }

            var service = Container.Resolve<WshGrundbudgetVorschlagDTOService>();
            var wshGrundbudgetVorschlagDto = new WshGrundbudgetVorschlagDTO();
            string guidText = Guid.NewGuid().ToString();

            wshGrundbudgetVorschlagDto.Ausgaben = 1024.55m;
            wshGrundbudgetVorschlagDto.KontoID = _grundbudgetHelper.KbuKonto.KbuKontoID;
            wshGrundbudgetVorschlagDto.Selected = true;
            wshGrundbudgetVorschlagDto.Text = guidText;

            var vorschlagDtoListe = new List<WshGrundbudgetVorschlagDTO>();
            vorschlagDtoListe.Add(wshGrundbudgetVorschlagDto);

            // Act
            var result = service.SaveBerechnetePositionen(null, vorschlagDtoListe, _grundbudgetHelper.Leistung.FaLeistungID, _questionsAndAnswers);

            // Assert
            Assert.IsTrue(result, result);
            var repository = UnitOfWork.GetRepository<WshGrundbudgetPosition>(unitOfWork);
            var gbQuery = from gbpos in repository
                          where gbpos.Berechnet
                          where gbpos.Bemerkung == guidText
                          select gbpos;

            Assert.IsTrue(gbQuery.Count() == 1);

            foreach (var wshGrundbudgetPosition in gbQuery)
            {
                _grundbudgetHelper.Entities.Add(wshGrundbudgetPosition);
            }

            var posRepository = UnitOfWork.GetRepository<WshPosition>(UnitOfWork.GetNew);
            var posQuery = from pos in posRepository
                           where pos.Bemerkung == guidText
                           select pos;

            int count = posQuery.Count();
            Assert.IsTrue(count >= 1);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void DeleteData_ThrowException()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetVorschlagDTOService>();

            // Act
            service.DeleteData(null, null);

            // Assert
            Assert.IsFalse(true);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void GetData_ThrowException()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetVorschlagDTOService>();

            // Act
            service.GetData(null);

            // Assert
            Assert.IsFalse(true);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void NewData_ThrowException()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetVorschlagDTOService>();
            WshGrundbudgetVorschlagDTO dto;

            // Act
            service.NewData(out dto);

            // Assert
            Assert.IsFalse(true);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void SaveData_WithDto_ThrowException()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetVorschlagDTOService>();

            // Act
            service.SaveData(null, new WshGrundbudgetVorschlagDTO());

            // Assert
            Assert.IsFalse(true);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void SaveData_WithList_ThrowException()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetVorschlagDTOService>();

            // Act
            service.SaveData(null, new List<WshGrundbudgetVorschlagDTO>());

            // Assert
            Assert.IsFalse(true);
        }

        #endregion
    }
}