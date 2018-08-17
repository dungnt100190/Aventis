using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kiss.Model.DTO.BA
{
    public class SearchPersonAdresseDTO
    {
        public BaPerson BaPerson { get; set; }
        public string Strasse { get; set; }
        public DateTime? BaAdresseDatumVon { get; set; }
    }
}
