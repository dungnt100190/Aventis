using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kiss.Model.DTO.Wsh
{
    public class WshKlientDTO
    {
        public BaPerson WshHaushaltPerson { get; set; }
        public BaPerson Falltraeger { get; set; }
        public FaLeistung FaLeistung { get; set; }
        public FaFall FaFall { get; set; }
    }
}
