﻿using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FaLeistungUserHist
    {
        public int FaLeistungUserHistId { get; set; }
        public int FaLeistungId { get; set; }
        public int UserId { get; set; }
        public DateTime DatumVon { get; set; }
        public DateTime DatumBis { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] FaLeistungUserHistTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public XUser User { get; set; }
    }
}
