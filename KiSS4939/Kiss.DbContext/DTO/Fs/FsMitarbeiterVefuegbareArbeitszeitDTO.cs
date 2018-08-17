using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kiss.DbContext.DTO.Fs
{
    public class FsMitarbeiterVefuegbareArbeitszeitDTO
    {
        public XUser User { get; set; }
        public IEnumerable<FsReduktionMitarbeiter> Reduktionen { get; set; }
        public IEnumerable<BDESollStundenProJahr_XUser> Sollstunden { get; set; }
        public IEnumerable<BDEPensum_XUser> Pensen { get; set; }
        public string OrgName { get; set; }
    }
}
