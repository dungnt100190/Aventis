using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class GvGesuch
    {
        public GvGesuch()
        {
            GvAbklaerendeStelle = new HashSet<GvAbklaerendeStelle>();
            GvAntragPosition = new HashSet<GvAntragPosition>();
            GvAuflage = new HashSet<GvAuflage>();
            GvAuszahlungPosition = new HashSet<GvAuszahlungPosition>();
            GvBewilligung = new HashSet<GvBewilligung>();
            GvDocument = new HashSet<GvDocument>();
        }

        public int GvGesuchId { get; set; }
        public int BaPersonId { get; set; }
        public int XuserIdAutor { get; set; }
        public int? UserIdbewilligt { get; set; }
        public int? DocumentId { get; set; }
        public int GvFondsId { get; set; }
        public int? ErfasstesGesuchgeprueftdurchIksUserId { get; set; }
        public int? AbgeschlossenesGesuchdurchIksUserId { get; set; }
        public int GvStatusCode { get; set; }
        public DateTime GesuchsDatum { get; set; }
        public DateTime? ErfassungAbgeschlossen { get; set; }
        public decimal? BetragBewilligt { get; set; }
        public DateTime? BewilligtAm { get; set; }
        public string Begruendung { get; set; }
        public string Bemerkung { get; set; }
        public decimal? BetragBewilligtKompetenzstufe1 { get; set; }
        public DateTime? DatumBewilligtKompetenzstufe1 { get; set; }
        public string BemerkungBewilligungKompetenzstufe1 { get; set; }
        public decimal? BetragBewilligtKompetenzstufe2 { get; set; }
        public DateTime? DatumBewilligtKompetenzstufe2 { get; set; }
        public string BemerkungBewilligungKompetenzstufe2 { get; set; }
        public DateTime? AbschlussDatum { get; set; }
        public int? GvAbschlussgrundCode { get; set; }
        public string Gesuchsgrund { get; set; }
        public bool IstEigenkompetenz { get; set; }
        public bool IstKompetenzBsl { get; set; }
        public bool IstKompetenzKanton { get; set; }
        public bool Extern { get; set; }
        public DateTime? ErfasstesGesuchgeprueftam { get; set; }
        public bool ErfasstesGesuchBesprechen { get; set; }
        public string ErfasstesGesuchBemerkung { get; set; }
        public DateTime? AbgeschlossenesGesuchgeprueftam { get; set; }
        public bool AbgeschlossenesGesuchBesprechen { get; set; }
        public string AbgeschlossenesGesuchBemerkung { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] GvGesuchTs { get; set; }

        public XUser AbgeschlossenesGesuchdurchIksUser { get; set; }
        public BaPerson BaPerson { get; set; }
        public XUser ErfasstesGesuchgeprueftdurchIksUser { get; set; }
        public GvFonds GvFonds { get; set; }
        public XUser XuserIdAutorNavigation { get; set; }
        public ICollection<GvAbklaerendeStelle> GvAbklaerendeStelle { get; set; }
        public ICollection<GvAntragPosition> GvAntragPosition { get; set; }
        public ICollection<GvAuflage> GvAuflage { get; set; }
        public ICollection<GvAuszahlungPosition> GvAuszahlungPosition { get; set; }
        public ICollection<GvBewilligung> GvBewilligung { get; set; }
        public ICollection<GvDocument> GvDocument { get; set; }
    }
}
