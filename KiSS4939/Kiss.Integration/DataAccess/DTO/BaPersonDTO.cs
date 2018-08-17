using System;

namespace Kiss.Integration.DataAccess.DTO
{
    public class BaPersonDTO
    {
        public int BaPersonID { get; set; }

        public string Email { get; set; }

        public DateTime? Geburtsdatum { get; set; }

        public string Geschlecht { get; set; }

        public string Name { get; set; }

        public string Nationalitaet { get; set; }

        public string Ort { get; set; }

        public string Plz { get; set; }

        public DateTime? Sterbedatum { get; set; }

        public string Strasse { get; set; }

        public string TelefonMobil { get; set; }

        public string TelefonPrivat { get; set; }

        public string Titel { get; set; }

        public string Versichertennummer { get; set; }

        public string Vorname { get; set; }

        public string Zivilstand { get; set; }
    }
}