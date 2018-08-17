using System.Collections.Generic;
using System.Xml.Linq;

namespace Kiss.BusinessLogic.Kes
{
    internal class KesKokesExportElementsDTO
    {
        public KesKokesExportElementsDTO()
        {
            UmwandlungKinder = new List<XElement>();
            UmwandlungErwachsene = new List<XElement>();
            UebertragungKinder = new List<XElement>();
            UebertragungErwachsene = new List<XElement>();
            UebernahmeKinder = new List<XElement>();
            UebernahmeErwachsene = new List<XElement>();
            NichtMassnahmengebundeneGeschaefteKinder = new List<XElement>();
            NichtMassnahmengebundeneGeschaefteErwachsene = new List<XElement>();
            ErrichtungKinder = new List<XElement>();
            ErrichtungErwachsene = new List<XElement>();
            Bestehende3112Kinder = new List<XElement>();
            Bestehende3112Erwachsene = new List<XElement>();
            Bestehende0101Kinder = new List<XElement>();
            Bestehende0101Erwachsene = new List<XElement>();
            Bestehende3112ErwachseneAlt = new List<XElement>();
            AufhebungKinder = new List<XElement>();
            AufhebungErwachsene = new List<XElement>();
            AenderungKinder = new List<XElement>();
            AenderungErwachsene = new List<XElement>();
        }

        public List<XElement> AenderungErwachsene { get; private set; }

        public List<XElement> AenderungKinder { get; private set; }

        public List<XElement> AufhebungErwachsene { get; private set; }

        public List<XElement> AufhebungKinder { get; private set; }

        public List<XElement> Bestehende0101Erwachsene { get; private set; }

        public List<XElement> Bestehende0101Kinder { get; private set; }

        public List<XElement> Bestehende3112Erwachsene { get; private set; }

        public List<XElement> Bestehende3112ErwachseneAlt { get; private set; }

        public List<XElement> Bestehende3112Kinder { get; private set; }

        public List<XElement> ErrichtungErwachsene { get; private set; }

        public List<XElement> ErrichtungKinder { get; private set; }

        public List<XElement> NichtMassnahmengebundeneGeschaefteErwachsene { get; private set; }

        public List<XElement> NichtMassnahmengebundeneGeschaefteKinder { get; private set; }

        public List<XElement> UebernahmeErwachsene { get; private set; }

        public List<XElement> UebernahmeKinder { get; private set; }

        public List<XElement> UebertragungErwachsene { get; private set; }

        public List<XElement> UebertragungKinder { get; private set; }

        public List<XElement> UmwandlungErwachsene { get; private set; }

        public List<XElement> UmwandlungKinder { get; private set; }

        public void AddElementsToPerson(XElement personElement)
        {
            // Achtung: Reihenfolge darf nicht verändert werden (ist im XSD als Sequence definiert)
            personElement.Add(Bestehende0101Kinder);
            personElement.Add(Bestehende0101Erwachsene);
            personElement.Add(UebernahmeKinder);
            personElement.Add(UebernahmeErwachsene);
            personElement.Add(ErrichtungKinder);
            personElement.Add(ErrichtungErwachsene);
            personElement.Add(AenderungKinder);
            personElement.Add(AenderungErwachsene);
            personElement.Add(UmwandlungKinder);
            personElement.Add(UmwandlungErwachsene);
            personElement.Add(AufhebungKinder);
            personElement.Add(AufhebungErwachsene);
            personElement.Add(Bestehende3112Kinder);
            personElement.Add(Bestehende3112Erwachsene);
            personElement.Add(Bestehende3112ErwachseneAlt);
            personElement.Add(UebertragungKinder);
            personElement.Add(UebertragungErwachsene);
            personElement.Add(NichtMassnahmengebundeneGeschaefteKinder);
            personElement.Add(NichtMassnahmengebundeneGeschaefteErwachsene);
        }
    }
}