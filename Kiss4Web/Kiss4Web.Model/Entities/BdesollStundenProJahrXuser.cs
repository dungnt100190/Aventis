using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BdesollStundenProJahrXuser
    {
        public int BdesollStundenProJahrXuserId { get; set; }
        public int UserId { get; set; }
        public int Jahr { get; set; }
        public decimal JanuarStd { get; set; }
        public decimal FebruarStd { get; set; }
        public decimal MaerzStd { get; set; }
        public decimal AprilStd { get; set; }
        public decimal MaiStd { get; set; }
        public decimal JuniStd { get; set; }
        public decimal JuliStd { get; set; }
        public decimal AugustStd { get; set; }
        public decimal SeptemberStd { get; set; }
        public decimal OktoberStd { get; set; }
        public decimal NovemberStd { get; set; }
        public decimal DezemberStd { get; set; }
        public decimal TotalStd { get; set; }
        public bool ManualEdit { get; set; }
        public byte[] BdesollStundenProJahrXuserTs { get; set; }
        public int? VerId { get; set; }

        public XUser User { get; set; }
    }
}
