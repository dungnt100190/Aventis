using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Transactions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Ba;
using Kiss.BL.Test.Helpers;
using Kiss.BL.Wsh;
using Kiss.Infrastructure;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.Database;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.BA;
using Kiss.Model.DTO.Wsh;

namespace Kiss.BL.Test.Wsh
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class WshGrundbudgetPositionDTOServiceTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly WshGrundbudgetPositionHelper _grundbudgetPositionHelper = new WshGrundbudgetPositionHelper();

        #endregion

        #region Private Fields

        private List<WshGrundbudgetPositionDTO> _entities;
        private int _faLeistungId;
        private int _faLeistungIdWithoutPosition;

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
            // Create some temporary test objects and store the entities
            var unitOfWork = UnitOfWork.GetNew;

            var position = _grundbudgetPositionHelper.CreateAusgabe(unitOfWork);
            _faLeistungId = position.FaLeistungID;
            _faLeistungIdWithoutPosition = position.FaLeistungID;
            unitOfWork.SaveChanges();

            _entities = new List<WshGrundbudgetPositionDTO>
                {
                    new WshGrundbudgetPositionDTO
                    {
                        WshGrundbudgetPosition = position,
                    }
                };
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

                // Delete the temporary test objects
                _grundbudgetPositionHelper.Delete(unitOfWork);

                unitOfWork.SaveChanges();
                transaction.Complete();
            }
        }

        [TestMethod]
        public void GetByFaLeistungID_onePositionWithLeistungId_DtoPropertiesAreSet()
        {
            // Only run on DB because of SelectedZahlungsweg
            if(!TestUtils.IsDbTest(null))
            {
                return;
            }

            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionDTOService>();

            // Act
            var positionDtoList = service.GetByFaLeistungID(null, _faLeistungId);

            // Assert
            Assert.AreEqual(1, positionDtoList.Count());
            var positionDto = positionDtoList.First();
            Assert.IsNotNull(positionDto.SelectedZahlungsweg);
            Assert.IsNull(positionDto.SelectedDebitor);
            Assert.IsNull(positionDto.BetragEinnahme);
            Assert.AreEqual(1200, positionDto.BetragAusgabe);
        }

        [TestMethod]
        public void HasWshGrundbudgetPosition_leitungMitPosition_returnFalse()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionDTOService>();

            // Act
            var hasPosition = service.HasWshGrundbudgetPosition(null, _faLeistungIdWithoutPosition);

            // Assert
            Assert.IsTrue(hasPosition);
        }

        [TestMethod]
        public void HasWshGrundbudgetPosition_leitungMitPosition_returnTrue()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionDTOService>();

            // Act
            var hasPosition = service.HasWshGrundbudgetPosition(null, _faLeistungId);

            // Assert
            Assert.IsTrue(hasPosition);
        }

        [TestMethod]
        public void SetBetragMonatlich_PeriodizitaetQuartal_BetragIsSet()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionDTOService>();
            var positionDto = _entities[0];
            positionDto.WshGrundbudgetPosition.WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet.Quartal;
            positionDto.WshGrundbudgetPosition.BetragTotal = 600;

            // Act
            service.SetBetragMonatlich(positionDto);

            // Assert
            Assert.AreEqual(200, positionDto.BetragBerechnet);
            Assert.IsNull(positionDto.BetragEinnahme);
            Assert.AreEqual(200, positionDto.BetragAusgabe);
        }

        [TestMethod]
        public void SetBetragMonatlich_PeriodizitaetQuartal_BetragTotalIsNotSet_BetragIsSetFromBetragMonatlich()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionDTOService>();
            var positionDto = _entities[0];
            positionDto.WshGrundbudgetPosition.WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet.Quartal;
            positionDto.WshGrundbudgetPosition.BetragMonatlich = 900;
            positionDto.WshGrundbudgetPosition.BetragTotal = null;

            // Act
            service.SetBetragMonatlich(positionDto);

            // Assert
            Assert.AreEqual(300, positionDto.BetragBerechnet);
            Assert.IsNull(positionDto.BetragEinnahme);
            Assert.AreEqual(300, positionDto.BetragAusgabe);
        }

        [TestMethod]
        public void SetBetragMonatlich_PeriodizitaetSemester_BetragIsSet()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionDTOService>();
            var positionDto = _entities[0];
            positionDto.WshGrundbudgetPosition.WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet.Semester;
            positionDto.WshGrundbudgetPosition.BetragMonatlich = 900;
            positionDto.WshGrundbudgetPosition.BetragTotal = 600;

            // Act
            service.SetBetragMonatlich(positionDto);

            // Assert
            Assert.AreEqual(100, positionDto.BetragBerechnet);
            Assert.IsNull(positionDto.BetragEinnahme);
            Assert.AreEqual(100, positionDto.BetragAusgabe);
        }

        [TestMethod]
        public void SetBetragMonatlich_PeriodizitaetValuta_BetragIsSetWithBetragMonatlich()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionDTOService>();
            var positionDto = _entities[0];
            positionDto.WshGrundbudgetPosition.WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet.Valuta;
            positionDto.WshGrundbudgetPosition.BetragMonatlich = 900;
            positionDto.WshGrundbudgetPosition.BetragTotal = 600;

            // Act
            service.SetBetragMonatlich(positionDto);

            // Assert
            Assert.AreEqual(900, positionDto.BetragBerechnet);
            Assert.IsNull(positionDto.BetragEinnahme);
            Assert.AreEqual(900, positionDto.BetragAusgabe);
        }

        [TestMethod]
        public void SetZahlungsweg_SelectedZahlungswegIsSet_SetZahlungswegOnPosition()
        {
            // Only run on DB because of SelectedZahlungsweg
            if (!TestUtils.IsDbTest(null))
            {
                return;
            }

            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionDTOService>();
            var positionDto = service.GetByFaLeistungID(null, _faLeistungId).First();
            var haushalt = new ObservableCollection<BaPerson> { positionDto.WshGrundbudgetPosition.BaPerson };

            // Act
            service.SetZahlungsweg(positionDto, haushalt);

            // Assert
            Assert.IsFalse(positionDto.IsAuszahlungDritte);
        }

        [TestMethod]
        public void UpdateIsAuszahlungDritte_personImHaushalt_IsAuszahlungDritteFalse()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionDTOService>();
            var positionDto = _entities[0];
            var haushalt = new ObservableCollection<BaPerson>{positionDto.WshGrundbudgetPosition.BaPerson};

            // Act
            service.UpdateIsAuszahlungDritte(positionDto, haushalt);

            // Assert
            Assert.IsFalse(positionDto.IsAuszahlungDritte);
        }

        [TestMethod]
        public void UpdateIsAuszahlungDritte_personNichtImHaushalt_IsAuszahlungDritteTrue()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionDTOService>();
            var positionDto = _entities[0];
            var haushalt = new ObservableCollection<BaPerson>();

            // Act
            service.UpdateIsAuszahlungDritte(positionDto, haushalt);

            // Assert
            Assert.IsTrue(positionDto.IsAuszahlungDritte);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void SaveData_WithDto_ThrowException()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionDTOService>();

            // Act
            service.SaveData(null, new WshGrundbudgetPositionDTO());

            // Assert
            Assert.IsFalse(true);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void SaveData_WithList_ThrowException()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionDTOService>();

            // Act
            service.SaveData(null, new List<WshGrundbudgetPositionDTO>());

            // Assert
            Assert.IsFalse(true);
        }

        #endregion
    }
}