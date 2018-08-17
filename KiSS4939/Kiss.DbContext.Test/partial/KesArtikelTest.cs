using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.DbContext.Test.partial
{
    [TestClass]
    public class KesArtikelTest
    {
        [TestMethod]
        public void ArtikelText_BezeichnungLeer_ReturnArtikelZifferGesetz()
        {
            var artikel = new KesArtikel
            {
                KesArtikelID = 11,
                Artikel = "392",
                Ziffer = "2",
                Gesetz = "ZGB",
            };

            Assert.AreEqual("392.2 ZGB", artikel.ArtikelTextBezeichnung);
        }

        [TestMethod]
        public void ArtikelTextKurz_AbsatzLeer_ReturnArtikelZifferGesetz()
        {
            var artikel = new KesArtikel
            {
                KesArtikelID = 11,
                Artikel = "392",
                Ziffer = "2",
                Gesetz = "ZGB",
                Bezeichnung = "Auftrag an Drittperson",
            };

            Assert.AreEqual("392.2 ZGB", artikel.ArtikelText);
        }

        [TestMethod]
        public void ArtikelTextKurz_BezeichnungNichtLeer_ReturnArtikelAbsatzZifferGesetzBezeichnung()
        {
            var artikel = new KesArtikel
            {
                KesArtikelID = 12,
                Artikel = "311",
                Absatz = "1",
                Ziffer = "1",
                Gesetz = "ZGB",
                Bezeichnung = "Entziehung der elterlichen Sorge von Amtes wegen - Eltern sind ausserstande",
            };

            Assert.AreEqual("311.1.1 ZGB Entziehung der elterlichen Sorge von Amtes wegen - Eltern sind ausserstande", artikel.ArtikelTextBezeichnung);
        }

        [TestMethod]
        public void ArtikelTextKurz_NichtsLeer_ReturnArtikelAbsatzZifferGesetz()
        {
            var artikel = new KesArtikel
            {
                KesArtikelID = 12,
                Artikel = "311",
                Absatz = "1",
                Ziffer = "1",
                Gesetz = "ZGB",
                Bezeichnung = "Entziehung der elterlichen Sorge von Amtes wegen - Eltern sind ausserstande",
            };

            Assert.AreEqual("311.1.1 ZGB", artikel.ArtikelText);
        }

        [TestMethod]
        public void ArtikelTextKurz_ZifferLeer_ReturnArtikelAbsatzGesetz()
        {
            var artikel = new KesArtikel
            {
                KesArtikelID = 13,
                Artikel = "394",
                Absatz = "1",
                Gesetz = "ZGB",
                Bezeichnung = "Vertretungsbeistandschaft - allgemein",
            };

            Assert.AreEqual("394.1 ZGB", artikel.ArtikelText);
        }
    }
}