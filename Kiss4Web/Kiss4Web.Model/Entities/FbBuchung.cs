using System;
using System.Collections.Generic;
using Kiss4Web.Model.Entities;
using Kiss4Web.Model.Fibu;

namespace Kiss4Web.Model
{
    public partial class FbBuchung : IEntity, IAuditableEntity
    {
        public FbBuchung()
        {
            FbBarauszahlungAusbezahlt = new HashSet<FbBarauszahlungAusbezahlt>();
            FbDtabuchung = new HashSet<FbDtabuchung>();
        }

        public int FbBuchungId { get; set; }
        public int FbPeriodeId { get; set; }
        public int BuchungTypCode { get; set; }
        public string Code { get; set; }
        public string BelegNr { get; set; }
        public int BelegNrPos { get; set; }
        public DateTime BuchungsDatum { get; set; }
        public int? SollKtoNr { get; set; }
        public int? HabenKtoNr { get; set; }
        public decimal Betrag { get; set; }
        public string Text { get; set; }
        public DateTime? ValutaDatum { get; set; }
        public DateTime? ValutaDatumOriginal { get; set; }
        public int? Zahlungsfrist { get; set; }
        public int? BuchungStatusCode { get; set; }
        public int? FbDauerauftragId { get; set; }
        public DateTime? ErfassungsDatum { get; set; }
        public int? UserId { get; set; }
        public int? FbZahlungswegId { get; set; }
        public string PckontoNr { get; set; }
        public string BankKontoNr { get; set; }
        public string Iban { get; set; }
        public FbZahlungsart? ZahlungsArtCode { get; set; }
        public string ReferenzNummer { get; set; }
        public string Zahlungsgrund { get; set; }
        public string Name { get; set; }
        public string Zusatz { get; set; }
        public string Strasse { get; set; }
        public string Plz { get; set; }
        public string Ort { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] FbBuchungTs { get; set; }

        public FbDauerauftrag FbDauerauftrag { get; set; }
        public FbKonto FbKonto { get; set; }
        public FbPeriode FbPeriode { get; set; }
        public FbZahlungsweg FbZahlungsweg { get; set; }
        public XUser User { get; set; }
        public ICollection<FbBarauszahlungAusbezahlt> FbBarauszahlungAusbezahlt { get; set; }
        public ICollection<FbDtabuchung> FbDtabuchung { get; set; }
        public int Id => FbBuchungId;
        public byte[] RowVersion => FbBuchungTs;
    }
}