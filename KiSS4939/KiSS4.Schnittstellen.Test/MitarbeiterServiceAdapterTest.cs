using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using KiSS4.Schnittstellen.Abacus.Mitarbeiter;

namespace KiSS4.Schnittstellen.Test
{
    [TestClass]
    public class MitarbeiterServiceAdapterTest
    {
        #region Test Methods


        
        //[TestMethod]
        public void GetAlleMitarbeiterDatenTest()
        {
            MitarbeiterServiceAdapter adapter = new MitarbeiterServiceAdapter();
            adapter.GetAlleMitarbeiterDaten("testEingabeBenutzerName", "testEingabePasswort", 2012, 1, 1);
        }

        //[TestMethod]
        public void GetMitarbeiterDatenTest()
        {
            IList<int> mitarbeiterNummern = new List<int>();
            for (int i = 0; i < 99; i++)
            {
                mitarbeiterNummern.Add(i * 5);
            }

            MitarbeiterServiceAdapter adapter = new MitarbeiterServiceAdapter();
            adapter.GetMitarbeiterDaten("testEingabeBenutzerName", "testEingabePasswort", 2012, 1, mitarbeiterNummern, mitarbeiterNummern, 71);
        }

        #endregion
    }
}