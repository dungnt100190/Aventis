namespace Kiss.Model.DTO.Fs
{
    public class FsDienstleistungAuswertungGesamtDTO : DTO
    {
        #region Properties

        public int UserId { get; set; }

        public int AnzahlDlpBedarf
        {
            get;
            set;
        }

        public int AnzahlDlpZugewiesen
        {
            get;
            set;
        }

        public int AnzahlPhasenBeratung
        {
            get;
            set;
        }

        public int AnzahlPhasenIntake
        {
            get;
            set;
        }

        public string Mitarbeiter
        {
            get;
            set;
        }

        public decimal StdBedarf
        {
            get;
            set;
        }

        public decimal StdFallarbeit
        {
            get;
            set;
        }

        public decimal StdZugewiesen
        {
            get;
            set;
        }

        public string Team
        {
            get;
            set;
        }

        #endregion
    }
}