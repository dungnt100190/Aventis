using System;
using System.Collections.Generic;
using Kiss4Web.Model.Fibu;

namespace Kiss4Web.Model
{
    public partial class FbKonto
    {
        public FbKonto()
        {
            FbBuchung = new HashSet<FbBuchung>();
        }

        public int FbKontoId { get; set; }
        public int? FbPeriodeId { get; set; }
        public int KontoKlasseCode { get; set; }
        public KontoTyp KontoTypCode { get; set; }
        public int KontoNr { get; set; }
        public string KontoName { get; set; }
        public decimal EroeffnungsSaldo { get; set; }
        public string SaldoGruppeName { get; set; }
        public int? FbDtazugangId { get; set; }
        public byte[] FbKontoTs { get; set; }
        public string FbDepotNr { get; set; }
        public string EroeffnungsSaldoModifier { get; set; }
        public DateTime? EroeffnungsSaldoModified { get; set; }
        public string EroeffnungsSaldoCreator { get; set; }
        public DateTime? EroeffnungsSaldoCreated { get; set; }
        public decimal? EroeffnungsSaldoAtCreation { get; set; }

        public FbDtazugang FbDtazugang { get; set; }
        public FbPeriode FbPeriode { get; set; }
        public ICollection<FbBuchung> FbBuchung { get; set; }
    }
}