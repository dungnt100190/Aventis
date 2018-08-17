using System;
using System.Transactions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Test.Helpers;
using Kiss.BL.Wsh;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Wsh;

namespace Kiss.BL.Test.Wsh
{
    /// <summary>
    /// Tests the WshAbzugDetailDTOService service.
    /// </summary>
    [TestClass]
    public class WshAbzugDetailDTOServiceTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly WshAbzugHelper _abzugHelper = new WshAbzugHelper();
        private readonly WshGrundbudgetPositionHelper _grundbudgetHelper = new WshGrundbudgetPositionHelper();
        private readonly WshKategorieHelper _kategorieHelper = new WshKategorieHelper();

        #endregion

        #region Private Fields

        private WshGrundbudgetPosition _gblPosition;
        private WshAbzugDTO _wshAbzugDto;

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
            using (var ts = new TransactionScope())
            {
                var unitOfWork = UnitOfWork.GetNew;

                _kategorieHelper.FillWshKategorieMock(unitOfWork);
                _wshAbzugDto = _abzugHelper.CreateAbzugRueckerstattungGbl(unitOfWork);
                _gblPosition = _grundbudgetHelper.Create(unitOfWork, _wshAbzugDto.WshAbzug.WshGrundbudgetPosition.FaLeistung);

                ts.Complete();
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
            using (var ts = new TransactionScope())
            {
                var unitOfWork = UnitOfWork.GetNew;

                _abzugHelper.RegisterGrundbudgetPositionForDeletion(_gblPosition);
                _abzugHelper.Delete(unitOfWork);
                _grundbudgetHelper.Delete(unitOfWork);
                _kategorieHelper.ClearWshKategorieMock(unitOfWork);

                ts.Complete();
            }
        }

        [TestMethod]
        public void Test_ProzentGBL()
        {
            // Arrange
            var unitOfWork = UnitOfWork.GetNew;
            var detailService = Container.Resolve<WshAbzugDetailDTOService>();

            // AbzugDetail hinzufügen
            WshAbzugDetailDTO detailDto;
            var result = detailService.NewData(out detailDto);
            result.Assert();

            detailDto.WshAbzugDetail.KbuKonto = _gblPosition.KbuKonto;
            detailDto.WshAbzugDetail.WshAbzug = _wshAbzugDto.WshAbzug;
            detailDto.WshAbzugDetail.Betrag = 146.9M; // 10%

            detailService.SaveData(unitOfWork, detailDto);

            // Act
            detailService.SetDtoProperties(unitOfWork, detailDto);

            // Assert
            Assert.AreEqual(10, detailDto.GblAbzugProzent);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void SaveData_WithQuestion_ThrowException()
        {
            // Arrange
            var service = Container.Resolve<WshAbzugDetailDTOService>();

            // Act
            service.SaveData(null, null, null);

            // Assert
            Assert.IsFalse(true);
        }

        #endregion
    }
}