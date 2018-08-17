using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Kiss.Infrastructure;

namespace Kiss.Model.DTO.Fs
{
    public class FsReduktionMitarbeiterZeitraumDTO
    {
        public int ReduktionID { get; set; }
        public int UserID { get; set; }
        public decimal StundenProMonat { get; set; }
        private TimePeriod Zeitraum { get; set; }
    }
}
