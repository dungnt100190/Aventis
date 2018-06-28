using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BdeferienanspruchXuser
    {
        public int BdeferienanspruchXuserId { get; set; }
        public int UserId { get; set; }
        public int Jahr { get; set; }
        public DateTime DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public decimal FerienanspruchStdProJahr { get; set; }
        public bool ManualEdit { get; set; }
        public byte[] BdeferienanspruchXuserTs { get; set; }

        public XUser User { get; set; }
    }
}
