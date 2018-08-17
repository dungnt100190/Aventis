using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kiss.Model.DTO.BA
{
    public class BaPersonAdresseDTO
    {
        public int FaLeistungID { get; set; }
        public BaPerson BaPerson { get; set; }
        public BaAdresse Wohnadresse { get; set; }
    }
}
