using System;

namespace Kiss.BusinessLogic.Ba.DTO
{
    public class BaAdressatDTO
    {
        public int? AdressatId
        {
            get
            {
                if (IsTypBaInstitution)
                {
                    return -BaInstitutionId;
                }

                return BaPersonId;
            }
        }

        public int? BaInstitutionId { get; set; }

        public int? BaPersonId { get; set; }

        public string HausNr { get; set; }

        public bool IsTypBaInstitution
        {
            get { return BaInstitutionId.HasValue; }
        }

        public string Name { get; set; }
        public string NameVorname { get; set; }

        public string NameVornameOhneNewline => NameVorname?.Replace(Environment.NewLine, " ") ?? NameVorname;

        public string Ort { get; set; }
        public string Plz { get; set; }

        public string PlzOrt
        {
            get { return string.Format("{0} {1}", Plz, Ort); }
        }

        public string Strasse { get; set; }

        public string StrasseHausNr
        {
            get { return Strasse + (string.IsNullOrEmpty(HausNr) ? string.Empty : " " + HausNr); }
        }

        public string Typ { get; set; }
        public string Vorname { get; set; }
    }
}