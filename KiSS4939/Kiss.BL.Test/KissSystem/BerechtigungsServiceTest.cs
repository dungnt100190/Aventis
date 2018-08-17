using System;
using System.Linq;
using System.Transactions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.KissSystem;
using Kiss.BL.Test.Helpers;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Test.KissSystem
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class BerechtigungsServiceTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly FaLeistungHelper _faLeistungHelper = new FaLeistungHelper();
        private readonly XOrgUnitHelper _xOrgUnitHelper = new XOrgUnitHelper();
        private readonly XUserGroupHelper _xUserGroupHelper = new XUserGroupHelper();
        private readonly XUserHelper _xUserHelper = new XUserHelper();

        #endregion

        #region Private Fields

        private XOrgUnit _adminXOrgUnit;
        private XUser _adminXUser;
        private FaLeistung _closedFaLeistung;
        private XUser _guestXUser;
        private XUser _memberXUser;
        private FaLeistung _openFaLeistung;
        private FaLeistung _ownerFaLeistung;
        private XUser _ownerXUser;
        private TransactionScope _transaction;
        private XClass _xClass;
        private XRight _xRight;
        private XUserGroup _xUserGroup;
        private XUserGroup_Right _xUserGroupRight;

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
            _transaction = new TransactionScope();
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;

            var repositoryXClass = UnitOfWork.GetRepository<XClass>(unitOfWork);
            _xClass = repositoryXClass.FirstOrDefault(x => x.ClassName == "UnitTestClass") ?? new XClass
            {
                ClassName = "UnitTestClass",
                BaseType = "KiSS4.Gui.KissUserControl",
                ModulID = 3,
                System = true,
            };

            repositoryXClass.ApplyChanges(_xClass);
            unitOfWork.SaveChanges();

            var repositoryXRight = UnitOfWork.GetRepository<XRight>(unitOfWork);
            _xRight = repositoryXRight.FirstOrDefault(x => x.RightName == "TheRight") ?? new XRight
            {
                XClass = _xClass,
                ClassName = "UnitTestClass",
                RightName = "TheRight",
                UserText = "TheRight",
                Description = "Description",
                Creator = "UnitTester",
                Created = DateTime.Now,
                Modifier = "UnitTester",
                Modified = DateTime.Now
            };
            repositoryXRight.ApplyChanges(_xRight);
            unitOfWork.SaveChanges();
            _xRight.AcceptChanges();

            _xUserGroup = _xUserGroupHelper.Create(unitOfWork);
            _xUserGroupRight = new XUserGroup_Right
            {
                XUserGroup = _xUserGroup,
                UserGroupID = _xUserGroup.UserGroupID,
                XRight = _xRight,
                RightID = _xRight.RightID,
                ClassName = "UnitTestClass",
                MayInsert = true,
                MayUpdate = true,
                MayDelete = true
            };
            var repositoryUserGroupRight = UnitOfWork.GetRepository<XUserGroup_Right>(unitOfWork);
            repositoryUserGroupRight.ApplyChanges(_xUserGroupRight);
            unitOfWork.SaveChanges();
            _xUserGroupRight.AcceptChanges();

            var repoXUser = UnitOfWork.GetRepository<XUser>(unitOfWork);

            // -------------
            // Save an Admin
            // -------------
            _adminXUser = _xUserHelper.CreateNew(unitOfWork);
            _openFaLeistung = _faLeistungHelper.Create(unitOfWork, _adminXUser, 5, 501);
            _adminXUser.IsUserAdmin = true;
            repoXUser.ApplyChanges(_adminXUser);
            unitOfWork.SaveChanges();
            _adminXUser.AcceptChanges();

            // Zugriff, OrgUnit
            CreateLeistungZugriff(unitOfWork, _openFaLeistung, _adminXUser, true /*darfMutieren*/);
            _adminXOrgUnit = _xOrgUnitHelper.Create(unitOfWork);
            AddToOrgUnit(unitOfWork, _adminXUser, _adminXOrgUnit, true, true, true);

            // ------------
            // Save a Guest
            // ------------
            _guestXUser = _xUserHelper.CreateNew(unitOfWork);

            // Zugriff, OrgUnit
            CreateLeistungZugriff(unitOfWork, _openFaLeistung, _guestXUser, false);
            var guestXOrgUnit = _xOrgUnitHelper.Create(unitOfWork);
            AddToOrgUnit(unitOfWork, _guestXUser, guestXOrgUnit, false, false, false);
            // TODO ARCHIVIEREN

            // -------------
            // Save a Member
            // -------------
            // neue Leistung
            _closedFaLeistung = _faLeistungHelper.Create(unitOfWork, _adminXUser, 3, 300);
            var repoFaLeistung = UnitOfWork.GetRepository<FaLeistung>(unitOfWork);
            _closedFaLeistung.DatumVon = new DateTime(2012, 1, 1);
            _closedFaLeistung.DatumBis = DateTime.Today.AddDays(-1d);
            repoFaLeistung.ApplyChanges(_closedFaLeistung);
            unitOfWork.SaveChanges();
            _closedFaLeistung.AcceptChanges();

            _memberXUser = _xUserHelper.CreateNew(unitOfWork);
            CreateLeistungZugriff(unitOfWork, _closedFaLeistung, _memberXUser, false);
            AddToOrgUnit(unitOfWork, _memberXUser, _adminXOrgUnit, false, true, false);

            // -------------
            // Save an Owner
            // -------------
            _ownerXUser = _xUserHelper.CreateNew(unitOfWork);
            _ownerFaLeistung = _faLeistungHelper.Create(unitOfWork, _ownerXUser, 4, 400);

            CreateLeistungZugriff(unitOfWork, _ownerFaLeistung, _ownerXUser, true);
            AddToOrgUnit(unitOfWork, _ownerXUser, _adminXOrgUnit, true, true, true);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TestServiceBase.ClassCleanup();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }
        }

        [TestMethod]
        public void GetUserZugriffrecht_Guest_Ok()
        {
            // Arrange
            var service = Container.Resolve<BerechtigungsService>();

            // Act
            var result = service.GetUserZugriffrecht(null, _openFaLeistung.FaLeistungID, _guestXUser.UserID);

            // Assert
            //Assert.IsTrue(result.Archived);
            Assert.IsTrue(result.IsGuest);
            Assert.IsTrue(result.MayRead);

            Assert.IsFalse(result.IsMember);
            Assert.IsFalse(result.Closed);
            Assert.IsFalse(result.IsOwner);
            Assert.IsFalse(result.IsUserAdmin);
            Assert.IsFalse(result.MayDelete);
            Assert.IsFalse(result.MayInsert);
            Assert.IsFalse(result.MayUpdate);

            Assert.AreEqual(5, result.ModulID);
        }

        [TestMethod]
        public void GetUserZugriffrecht_Member_Ok()
        {
            // Arrange
            var service = Container.Resolve<BerechtigungsService>();

            // Act
            var result = service.GetUserZugriffrecht(null, _closedFaLeistung.FaLeistungID, _memberXUser.UserID);

            // Assert
            Assert.IsTrue(result.Closed);
            Assert.IsTrue(result.IsGuest);
            Assert.IsTrue(result.IsMember);
            Assert.IsTrue(result.MayUpdate);
            Assert.IsTrue(result.MayRead);

            Assert.IsFalse(result.Archived);
            Assert.IsFalse(result.IsOwner);
            Assert.IsFalse(result.MayDelete);
            Assert.IsFalse(result.MayInsert);
            Assert.IsFalse(result.IsUserAdmin);

            Assert.AreEqual(3, result.ModulID);
        }

        [TestMethod]
        public void GetUserZugriffrecht_Null()
        {
            // Arrange
            var service = Container.Resolve<BerechtigungsService>();

            // Act
            var result = service.GetUserZugriffrecht(null, 0, 0);

            // Assert
            Assert.IsFalse(result.Archived);
            Assert.IsFalse(result.Closed);
            Assert.IsFalse(result.IsGuest);
            Assert.IsFalse(result.IsMember);
            Assert.IsFalse(result.IsOwner);
            Assert.IsFalse(result.IsUserAdmin);
            Assert.IsFalse(result.MayDelete);
            Assert.IsFalse(result.MayInsert);
            Assert.IsFalse(result.MayRead);
            Assert.IsFalse(result.MayUpdate);
        }

        [TestMethod]
        public void GetUserZugriffrecht_Owner_Ok()
        {
            // Arrange
            var service = Container.Resolve<BerechtigungsService>();

            // Act
            var result = service.GetUserZugriffrecht(null, _ownerFaLeistung.FaLeistungID, _ownerXUser.UserID);

            // Assert
            Assert.IsFalse(result.IsUserAdmin);
            Assert.IsFalse(result.Closed);

            //Assert.IsTrue(result.Archived);
            Assert.IsTrue(result.IsGuest);
            Assert.IsTrue(result.IsMember);
            Assert.IsTrue(result.IsOwner);
            Assert.IsTrue(result.MayDelete);
            Assert.IsTrue(result.MayInsert);
            Assert.IsTrue(result.MayRead);
            Assert.IsTrue(result.MayUpdate);

            Assert.AreEqual(4, result.ModulID);
        }

        [TestMethod]
        public void GetUserZugriffrecht_UserAdmin_Ok()
        {
            // Arrange
            var service = Container.Resolve<BerechtigungsService>();

            // Act
            var result = service.GetUserZugriffrecht(null, _openFaLeistung.FaLeistungID, _adminXUser.UserID);

            // Assert
            Assert.IsFalse(result.Archived);
            Assert.IsFalse(result.Closed);

            Assert.IsTrue(result.IsGuest);
            Assert.IsTrue(result.IsMember);
            Assert.IsTrue(result.IsOwner);
            Assert.IsTrue(result.IsUserAdmin);
            Assert.IsTrue(result.MayDelete);
            Assert.IsTrue(result.MayInsert);
            Assert.IsTrue(result.MayRead);
            Assert.IsTrue(result.MayUpdate);

            Assert.AreEqual(5, result.ModulID);
        }

        [TestMethod]
        public void HatUserSpezialrecht_NOk()
        {
            // Arrange
            var service = Container.Resolve<BerechtigungsService>();

            // Act
            bool result = service.HatUserSpezialrecht(null, _xUserGroup.XUser_UserGroup[0].XUser.UserID, "blabliblabla");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void HatUserSpezialrecht_Ok()
        {
            // Arrange
            var service = Container.Resolve<BerechtigungsService>();

            // Act
            bool result = service.HatUserSpezialrecht(null, _xUserGroup.XUser_UserGroup[0].XUser.UserID, "TheRight");

            // Assert
            Assert.IsTrue(result);
        }

        #endregion

        #region Methods

        #region Private Methods

        private void AddToOrgUnit(IUnitOfWork unitOfWork, XUser xUser, XOrgUnit xOrgUnit, bool mayDelete, bool mayUpdate, bool mayInsert)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            var repoXOrgUnitUser = UnitOfWork.GetRepository<XOrgUnit_User>(unitOfWork);
            var orgUnitUser = new XOrgUnit_User
            {
                XUser = xUser,
                UserID = xUser.UserID,
                OrgUnitMemberCode = 2,
                XOrgUnit = xOrgUnit,
                OrgUnitID = xOrgUnit.OrgUnitID,
                MayDelete = mayDelete,
                MayUpdate = mayUpdate,
                MayInsert = mayInsert
            };

            repoXOrgUnitUser.ApplyChanges(orgUnitUser);
            unitOfWork.SaveChanges();
            orgUnitUser.AcceptChanges();
        }

        private void CreateLeistungZugriff(IUnitOfWork unitOfWork, FaLeistung faLeistung, XUser xUser, bool darfMutieren)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            var zugriff = new FaLeistungZugriff
            {
                FaLeistung = faLeistung,
                FaLeistungID = faLeistung.FaLeistungID,
                XUser = xUser,
                UserID = xUser.UserID,
                DarfMutieren = darfMutieren
            };
            var repoZugriff = UnitOfWork.GetRepository<FaLeistungZugriff>(unitOfWork);
            repoZugriff.ApplyChanges(zugriff);
            unitOfWork.SaveChanges();
            zugriff.AcceptChanges();
        }

        #endregion

        #endregion

        #region Other

        /*
        private void SaveAPersonForGetUserZugriffRecht(IUnitOfWork unitOfWork, XUser user, XUser userOwner, FaLeistung faLeistung, bool archived, DateTime? closedDate, XOrgUnit orgUnit, bool mayDelete, bool mayUpdate, bool mayInsert, bool darfMutieren)
        {
            //Save FaLeistung
            _faLeistung = new FaLeistung
            {
                BaPerson = _baPerson,
                BaPersonID = _baPerson.BaPersonID,
                ModulID = modulID,
                XUser =
                UserID = userIdOwner,
                DatumVon = closedDate != null ? closedDate.Value.AddDays(-1) : DateTime.Today,
                DatumBis = closedDate,
                Creator = "UnitTester",
                Created = DateTime.Now,
                Modifier = "UnitTester",
                Modified = DateTime.Now
            };
            var repositoryFaLeistung = UnitOfWork.GetRepository<FaLeistung>(unitOfWork);
            repositoryFaLeistung.ApplyChanges(_faLeistung);
            unitOfWork.SaveChanges();

            if (archived)
            {
                //Save FaLeistungArchiv
                _faLeistungArchiv = new FaLeistungArchiv
                {
                    FaLeistungID = faLeistungId,
                    CheckOut = null
                };
                var repositoryFaLeistungArchiv = UnitOfWork.GetRepository<FaLeistungArchiv>(unitOfWork);
                repositoryFaLeistungArchiv.ApplyChanges(_faLeistungArchiv);
                unitOfWork.SaveChanges();
            }

            //Save FaLeistungZugriff
            _faLeistungZugriff = new FaLeistungZugriff
            {
                FaLeistungID = faLeistungId,
                UserID = userId,
                DarfMutieren = darfMutieren
            };
            var repositoryFaLeistungZugriff = UnitOfWork.GetRepository<FaLeistungZugriff>(unitOfWork);
            repositoryFaLeistungZugriff.ApplyChanges(_faLeistungZugriff);
            unitOfWork.SaveChanges();

            //Save XOrgUnitUser
            _xOrgUnitUser = new XOrgUnit_User
            {
                UserID = userId,
                OrgUnitMemberCode = 2,
                OrgUnitID = orgUnitId,
                MayDelete = mayDelete,
                MayUpdate = mayUpdate,
                MayInsert = mayInsert
            };
            var repositoryXOrgUnitUser = UnitOfWork.GetRepository<XOrgUnit_User>(unitOfWork);
            repositoryXOrgUnitUser.ApplyChanges(_xOrgUnitUser);
            unitOfWork.SaveChanges();
        }
        */

        #endregion
    }
}