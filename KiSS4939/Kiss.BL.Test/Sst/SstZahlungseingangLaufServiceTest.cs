using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Sst;
using Kiss.Infrastructure.Testing;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;

namespace Kiss.BL.Test.Sst
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class SstZahlungseingangLaufServiceTest
    {
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
                IUnitOfWork unitOfWork = UnitOfWork.GetNew;
                var repositryZahlungseingangLauf = UnitOfWork.GetRepository<SstZahlungseingangLauf>(unitOfWork);

                var zl = new SstZahlungseingangLauf
                {
                    AbholungErfolgreich = true,
                    EinfuegenErfolgreich = true,
                    Fremdsystem = "Unit",
                    TimestampErhalten = "xy",
                    TimestampGesendet = null,
                    Creator = "UnitTest",
                    Created = DateTime.Today,
                    Modifier = "UnitTest",
                    Modified = DateTime.Today,
                };

                repositryZahlungseingangLauf.ApplyChanges(zl);
                unitOfWork.SaveChanges();

                var repositryZahlungseingang = UnitOfWork.GetRepository<SstZahlungseingang>(unitOfWork);

                var ze = new SstZahlungseingang
                {
                    SstZahlungseingangLaufID = zl.SstZahlungseingangLaufID,
                    AMOUNT_LOC_CURR = 888,
                    BANK_ACCOUNT = "80-2036-3",
                    PAY_DATE_ESR = DateTime.Today,
                    PAYMENT_LOT = "12", //ID Zahlstapel
                    PAYMENT_LOT_POS = "1", //Position im Zahlstapel
                    PAYMENT_TEXT = "Hello Unit",
                    POST_DATE = DateTime.Today,
                    Creator = "UnitTest",
                    Created = DateTime.Today,
                    Modifier = "UnitTest",
                    Modified = DateTime.Today,

                };
                repositryZahlungseingang.ApplyChanges(ze);
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
            using (var transaction = new TransactionScope())
            {

                //Löschen des Zahlungslauf mit Position 12
                IUnitOfWork unitOfWork = UnitOfWork.GetNew;

                //Löschen geht nicht mit Mock.
                if (!TestUtils.IsDbTest(unitOfWork))
                {
                    return;
                }

                //Zahlungseingeänge inklusive KbuZahlungseingänge löschen
                var repositoryZahlungseingang = UnitOfWork.GetRepository<SstZahlungseingang>(unitOfWork);
                var zahlungsEingaenge = repositoryZahlungseingang.Include(x => x.KbuZahlungseingang).Where(x => x.PAYMENT_LOT == "12").ToList();
                IList<int> kbuZahlungseingangListe = new List<int>();
                foreach (var sstZahlungseingang in zahlungsEingaenge)
                {

                    if (sstZahlungseingang.KbuZahlungseingangID.HasValue)
                    {
                        kbuZahlungseingangListe.Add(sstZahlungseingang.KbuZahlungseingangID.Value);
                    }
                    sstZahlungseingang.MarkAsDeleted();
                    repositoryZahlungseingang.ApplyChanges(sstZahlungseingang);
                }
                zahlungsEingaenge.ForEach(repositoryZahlungseingang.ApplyChanges);
                unitOfWork.SaveChanges();

                //Zahllauf löschen.
                var repositoryZahlungseingangLauf = UnitOfWork.GetRepository<SstZahlungseingangLauf>(unitOfWork);
                var laeufe = repositoryZahlungseingangLauf.Where(x => x.TimestampErhalten == "te" || x.TimestampErhalten == "xy").ToList();
                laeufe.ForEach(x => x.MarkAsDeleted());

                laeufe.ForEach(repositoryZahlungseingangLauf.ApplyChanges);
                unitOfWork.SaveChanges();

                //KbuZahlungseingaenge Löschen (so kompliziert, weil Cascading delete nicht funktioniert).
                //irgendwo ein bug mit löschen und STE. Wenn man das wegnimmt, funktioniert es nicht mehr (Datensatz wird einfach nicht gelöscht).

                unitOfWork = UnitOfWork.GetNew;
                var repositoryKbuZahlungseingang = UnitOfWork.GetRepository<KbuZahlungseingang>(unitOfWork);
                var kbuZahlungseingaenge = repositoryKbuZahlungseingang.Where(x => kbuZahlungseingangListe.Contains(x.KbuZahlungseingangID)).ToList();
                kbuZahlungseingaenge.ForEach(x => x.MarkAsDeleted());
                kbuZahlungseingaenge.ForEach(repositoryKbuZahlungseingang.ApplyChanges);
                unitOfWork.SaveChanges();

                transaction.Complete();
            }
        }

        [TestMethod]
        public void SaveZahlungseingangLauf_Test()
        {
            //Arrange
            var service = Container.Resolve<SstZahlungseingangLaufService>();
            List<SstZahlungseingang> zahlungseingaenge = new List<SstZahlungseingang>();

            SstZahlungseingang eingang1 = new SstZahlungseingang
            {
                AMOUNT_LOC_CURR = 888,
                BANK_ACCOUNT = "80-2036-3",
                PAY_DATE_ESR = DateTime.Today,
                PAYMENT_LOT = "12", //ID Zahlstapel
                PAYMENT_LOT_POS = "1", //Position im Zahlstapel
                PAYMENT_TEXT = "Hello Unit",
                POST_DATE = DateTime.Today
            };

            SstZahlungseingang eingang2 = new SstZahlungseingang
            {
                AMOUNT_LOC_CURR = 66,
                BANK_ACCOUNT = "80-2036-3",
                PAY_DATE_ESR = DateTime.Today,
                PAYMENT_LOT = "12", //ID Zahlstapel
                PAYMENT_LOT_POS = "2", //Position im Zahlstapel
                PAYMENT_TEXT = "Hello Unit",
                POST_DATE = DateTime.Today
            };

            zahlungseingaenge.Add(eingang1);
            zahlungseingaenge.Add(eingang2);
            SstZahlungseingangLauf lauf = new SstZahlungseingangLauf
            {
                TimestampErhalten = "te",
                AbholungErfolgreich = true,
            };

            //Act
            var result = service.SaveZahlungseingangLauf(null, lauf, zahlungseingaenge);

            //Assert
            Assert.IsTrue(result.IsOk);
        }

        [TestMethod]
        public void ZahlungseingangLaufSpeichernUndVerarbeiten_Test()
        {
            //Arrange
            var service = Container.Resolve<SstZahlungseingangLaufService>();
            List<SstZahlungseingang> zahlungseingaenge = new List<SstZahlungseingang>();

            SstZahlungseingang eingang1 = new SstZahlungseingang
            {
                AMOUNT_LOC_CURR = 888,
                BANK_ACCOUNT = "80-2036-3",
                PAY_DATE_ESR = DateTime.Today,
                PAYMENT_LOT = "12", //ID Zahlstapel
                PAYMENT_LOT_POS = "1", //Position im Zahlstapel
                PAYMENT_TEXT = "Hello Unit",
                POST_DATE = DateTime.Today
            };

            SstZahlungseingang eingang2 = new SstZahlungseingang
            {
                AMOUNT_LOC_CURR = 66,
                BANK_ACCOUNT = "80-2036-3",
                PAY_DATE_ESR = DateTime.Today,
                PAYMENT_LOT = "12", //ID Zahlstapel
                PAYMENT_LOT_POS = "2", //Position im Zahlstapel
                PAYMENT_TEXT = "Hello Unit",
                POST_DATE = DateTime.Today
            };

            zahlungseingaenge.Add(eingang1);
            zahlungseingaenge.Add(eingang2);
            SstZahlungseingangLauf lauf = new SstZahlungseingangLauf
            {
                TimestampErhalten = "te",
                AbholungErfolgreich = true,
            };

            //Act
            var result = service.ZahlungseingangLaufSpeichernUndVerarbeiten(null, lauf, zahlungseingaenge);

            //Assert
            Assert.IsTrue(result.IsOk);
        }

        #endregion
    }
}