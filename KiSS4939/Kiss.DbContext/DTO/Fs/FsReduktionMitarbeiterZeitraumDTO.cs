using Kiss.Infrastructure;

namespace Kiss.DbContext.DTO.Fs
{
    public class FsReduktionMitarbeiterZeitraumDTO
    {
        public int ReduktionID { get; set; }
        public int UserID { get; set; }
        public decimal StundenProMonat { get; set; }
        private TimePeriod Zeitraum { get; set; }
    }
}
