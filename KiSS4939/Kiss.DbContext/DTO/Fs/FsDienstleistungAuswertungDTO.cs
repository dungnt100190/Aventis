using System;

namespace Kiss.DbContext.DTO.Fs
{
    public class FsDienstleistungAuswertungDTO
    {
        #region Properties

        public bool AbgelaufenDlpBedarf { get; set; }

        public bool AbgelaufenDlpZugewiesen { get; set; }

        public int BaPersonId { get; set; }

        public string BeschreibungDlpBedarf { get; set; }

        public string BeschreibungDlpZugewiesen { get; set; }

        public int FaPhaseID { get; set; }

        public string KlientName { get; set; }

        public DateTime? PhaseBis { get; set; }

        public DateTime PhaseVon { get; set; }

        public decimal StundenBedarf { get; set; }

        public decimal StundenZugewiesen { get; set; }

        #endregion
    }
}