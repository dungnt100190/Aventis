using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XuserStundenansatz
    {
        public int XuserStundenansatzId { get; set; }
        public int UserId { get; set; }
        public decimal? Lohnart1 { get; set; }
        public decimal? Lohnart2 { get; set; }
        public decimal? Lohnart3 { get; set; }
        public decimal? Lohnart4 { get; set; }
        public decimal? Lohnart5 { get; set; }
        public decimal? Lohnart6 { get; set; }
        public decimal? Lohnart7 { get; set; }
        public decimal? Lohnart8 { get; set; }
        public decimal? Lohnart9 { get; set; }
        public decimal? Lohnart10 { get; set; }
        public decimal? Lohnart11 { get; set; }
        public decimal? Lohnart12 { get; set; }
        public decimal? Lohnart13 { get; set; }
        public decimal? Lohnart14 { get; set; }
        public decimal? Lohnart15 { get; set; }
        public decimal? Lohnart16 { get; set; }
        public decimal? Lohnart17 { get; set; }
        public decimal? Lohnart18 { get; set; }
        public decimal? Lohnart19 { get; set; }
        public decimal? Lohnart20 { get; set; }
        public int? VerId { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] XuserStundenansatzTs { get; set; }

        public XUser User { get; set; }
    }
}
