using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Transactions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Test.Helpers;
using Kiss.BL.Wsh;
using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.Enumeration;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Wsh;

namespace Kiss.BL.Test.Wsh
{
    /// <summary>
    /// Summary description for WshKategorieKontoDTOServiceTest
    /// </summary>
    [TestClass]
    public class WshKategorieKontoDTOServiceTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly KbuKontoHelper _kontoHelper = new KbuKontoHelper();

        #endregion

        #region Private Fields

        private WshKategorieKontoDTO _item;
        private KbuKonto _konto;
        private WshKategorieKontoDTOService _serviceDTO;

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
            _serviceDTO = Container.Resolve<WshKategorieKontoDTOService>();
            _konto = _kontoHelper.Create(unitOfWork);

            unitOfWork.SaveChanges();

            _item = _serviceDTO.GetData(unitOfWork).First();
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
                _kontoHelper.Delete(unitOfWork);

                unitOfWork.SaveChanges();
                transaction.Complete();
            }
        }

        [TestMethod]
        public void GetNewData()
        {
            // Arrange
            var unitOfWork = UnitOfWork.GetNew;

            var mappingService = Container.Resolve<WshKategorieKbuKontoService>();

            var mappingEntry = mappingService.GetByForeignKeysOrCreate(unitOfWork, (int)LOVsGenerated.WshKategorie.Ausgabe, _konto.KbuKontoID);
            mappingEntry.NurMitSpezialrecht = false;
            mappingService.SaveData(unitOfWork, mappingEntry);

            mappingEntry = mappingService.GetByForeignKeysOrCreate(unitOfWork, (int)LOVsGenerated.WshKategorie.Einnahme, _konto.KbuKontoID);
            mappingEntry.NurMitSpezialrecht = true;
            mappingService.SaveData(unitOfWork, mappingEntry);

            mappingEntry = mappingService.GetByForeignKeysOrCreate(unitOfWork, (int)LOVsGenerated.WshKategorie.Sanktion, _konto.KbuKontoID);
            mappingEntry.NurMitSpezialrecht = true;
            mappingService.SaveData(unitOfWork, mappingEntry);

            // Act
            var dto = _serviceDTO.GetDataByKontoId(unitOfWork, _konto.KbuKontoID);

            // Assert
            Assert.AreEqual(_konto.KbuKontoID, dto.KbuKontoID);
            Assert.AreEqual(_konto.KontoNr, dto.KontoNr);
            Assert.AreEqual(_konto.Name, dto.KontoName);

            Assert.AreEqual(WshKategorieKbuKontoVerfuegbar.Ja, dto.VerfuegbarAlsAusgabe);
            Assert.AreEqual(WshKategorieKbuKontoVerfuegbar.JaMitSpezialrecht, dto.VerfuegbarAlsEinnahme);
            Assert.AreEqual(WshKategorieKbuKontoVerfuegbar.JaMitSpezialrecht, dto.VerfuegbarAlsSanktion);
            Assert.AreEqual(WshKategorieKbuKontoVerfuegbar.Nein, dto.VerfuegbarAlsAbzahlung);
        }

        [TestMethod]
        public void InsertNewData()
        {
            // Arrange
            var unitOfWork = UnitOfWork.GetNew;
            var item = _serviceDTO.GetDataByKontoId(unitOfWork, _konto.KbuKontoID);
            item.KbuKontoID = _konto.KbuKontoID;
            item.VerfuegbarAlsAusgabe = WshKategorieKbuKontoVerfuegbar.Ja;
            item.VerfuegbarAlsEinnahme = WshKategorieKbuKontoVerfuegbar.JaMitSpezialrecht;
            item.VerfuegbarAlsSanktion = WshKategorieKbuKontoVerfuegbar.JaMitSpezialrecht;
            item.VerfuegbarAlsRueckerstattung = WshKategorieKbuKontoVerfuegbar.Ja;

            // Act
            var result = _serviceDTO.SaveData(unitOfWork, item);

            // Assert
            Assert.IsTrue(result.IsOk);

            var mappingService = Container.Resolve<WshKategorieKbuKontoService>();
            var mappingEntries = mappingService.GetByKontoId(unitOfWork, item.KbuKontoID);

            Assert.IsNotNull(mappingEntries);

            var mappingAusgabe = mappingEntries.SingleOrDefault(x => x.WshKategorieID == (int)LOVsGenerated.WshKategorie.Ausgabe);
            Assert.IsNotNull(mappingAusgabe);
            Assert.AreEqual(false, mappingAusgabe.NurMitSpezialrecht);

            var mappingEinnahme = mappingEntries.SingleOrDefault(x => x.WshKategorieID == (int)LOVsGenerated.WshKategorie.Einnahme);
            Assert.IsNotNull(mappingEinnahme);
            Assert.AreEqual(true, mappingEinnahme.NurMitSpezialrecht);

            var mappingSanktion = mappingEntries.SingleOrDefault(x => x.WshKategorieID == (int)LOVsGenerated.WshKategorie.Sanktion);
            Assert.IsNotNull(mappingSanktion);
            Assert.AreEqual(true, mappingSanktion.NurMitSpezialrecht);

            var mappingRueckerstattung = mappingEntries.SingleOrDefault(x => x.WshKategorieID == (int)LOVsGenerated.WshKategorie.Rueckerstattung);
            Assert.IsNotNull(mappingRueckerstattung);
            Assert.AreEqual(false, mappingRueckerstattung.NurMitSpezialrecht);

            var mappingKuerzung = mappingEntries.SingleOrDefault(x => x.WshKategorieID == (int)LOVsGenerated.WshKategorie.Kuerzung);
            Assert.IsNull(mappingKuerzung);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void SaveData_WithQuestion_ThrowException()
        {
            // Arrange
            var service = Container.Resolve<WshKategorieKontoDTOService>();

            // Act
            service.SaveData(null, null, null);

            // Assert
            Assert.IsFalse(true);
        }

        #endregion

        #region Other

        //private int _faLeistungId;
        //private int _faLeistungIdWithoutPosition;

        #endregion
    }
}