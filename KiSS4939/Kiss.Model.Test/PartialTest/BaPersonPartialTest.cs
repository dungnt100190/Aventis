using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.Model.Test.PartialTest
{
    /// <summary>
    /// Tests für zusätzliche Properties in BaPerson.partial.cs
    /// </summary>
    [TestClass]
    public class BaPersonPartialTest
    {
        [TestMethod]
        public void GetAlter_Geburtsdatum()
        {
            DateTime geburtsDatum = DateTime.Today.AddYears(-34).AddMonths(-2);
            // Arrange - Sterbedatum ist null -> Verwende ReferenzDatum in jedem Fall
            BaPerson baPerson = new BaPerson
            {
                Geburtsdatum = geburtsDatum,
            };

            // Act 
            int? alter = baPerson.Alter;

            // Assert - Person ist 34 Jahre + 2 Monate alt
            Assert.IsTrue(alter.HasValue, "Alter wurde nicht berechnet.");
            Assert.AreEqual(34, alter ?? -1, "Alter wurde falsch berechnet.");
        }

        [TestMethod]
        public void GetAlter_Geburtsdatum_Berechnung_Vor_Geburtstag_Im_Jahr()
        {
            DateTime geburtsDatum = DateTime.Today.AddYears(-34).AddMonths(+2);

            // Arrange - Sterbedatum ist null -> Verwende ReferenzDatum in jedem Fall
            BaPerson baPerson = new BaPerson
            {
                Geburtsdatum = geburtsDatum,
            };

            //Act
            int? alter = baPerson.Alter;

            // Assert - Person ist 33 Jahre + 10 Monate alt
            Assert.IsTrue(alter.HasValue, "Alter wurde nicht berechnet.");
            Assert.AreEqual(33, alter ?? -1, "Alter wurde falsch berechnet.");
        }

        [TestMethod]
        public void GetAlter_Geburtsdatum_Referenzdatum_Vor_Geburtsdatum()
        {
            //geburtsdatum liegt in der Zukunft
            DateTime geburtsDatum = DateTime.Today.AddYears(2);

            // Arrange - Sterbedatum ist null -> Verwende ReferenzDatum in jedem Fall
            BaPerson baPerson = new BaPerson
            {
                Geburtsdatum = geburtsDatum,
            };

            //Act
            int? alter = baPerson.Alter;

            // Assert
            Assert.IsFalse(alter.HasValue, "Alter wurde berechnet, obwohl Berechnung nicht möglich ist.");
        }

        [TestMethod]
        public void GetAlter_Geburtsdatum_Referenzdatum_Trotz_Sterbedatum()
        {
            DateTime geburtsdatum = DateTime.Today.AddYears(-21).AddMonths(-2);
            DateTime sterbedatum = DateTime.Today.AddYears(+2); //sterbedatum liegt in der Zukunft

            // Arrange - Sterbedatum hat Wert, Ref früher als Sterbedatum -> Verwende ReferenzDatum in jedem Fall
            BaPerson baPerson = new BaPerson
            {
                Geburtsdatum = geburtsdatum,
                Sterbedatum = sterbedatum,
            };

            //Referenzdatum ist früher als Sterbedatum, deshalb ist Referenzdatum relevant
            int? alter = baPerson.Alter;

            // Assert
            Assert.IsTrue(alter.HasValue, "Alter wurde nicht berechnet.");
            Assert.AreEqual(21, alter ?? -1, "Alter wurde falsch berechnet.");
            Assert.AreNotEqual(23, alter ?? -1, "Alter wurde mit Sterbedatum statt Referenzdatum berechnet.");
        }

        [TestMethod]
        public void GetAlter_Geburtsdatum_Sterbedatum_Statt_Referenzdatum()
        {
            DateTime sterbedatum = DateTime.Today.AddYears(-2); //sterbedatum 
            DateTime geburtsdatum = sterbedatum.AddYears(-22).AddMonths(-2);

            // Arrange - Sterbedatum hat Wert, Ref -> Verwende ReferenzDatum in jedem Fall
            BaPerson baPerson = new BaPerson
            {
                Geburtsdatum = geburtsdatum,
                Sterbedatum = sterbedatum,
            };

            //Act
            int? alter = baPerson.Alter;

            // Assert
            Assert.IsTrue(alter.HasValue, "Alter wurde nicht berechnet.");
            Assert.AreEqual(22, alter ?? -1, "Alter wurde falsch berechnet.");
            Assert.AreNotEqual(24, alter ?? -1, "Alter wurde mit Referenzdatum statt Sterbedatum berechnet.");
        }
    }
}
