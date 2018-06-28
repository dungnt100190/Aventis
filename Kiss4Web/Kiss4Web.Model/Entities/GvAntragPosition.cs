using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class GvAntragPosition
    {
        public int GvAntragPositionId { get; set; }
        public int GvGesuchId { get; set; }
        public int GvAntragPositionTypCode { get; set; }
        public string Bezeichnung { get; set; }
        public decimal Betrag { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] GvAntragPositionTs { get; set; }

        public GvGesuch GvGesuch { get; set; }
    }
}
