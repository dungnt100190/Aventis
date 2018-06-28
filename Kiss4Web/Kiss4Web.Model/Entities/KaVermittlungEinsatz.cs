using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaVermittlungEinsatz
    {
        public int KaVermittlungEinsatzId { get; set; }
        public int? KaVermittlungVorschlagId { get; set; }
        public DateTime? Lehrvertrag { get; set; }
        public DateTime? EinsatzVon { get; set; }
        public DateTime? EinsatzBis { get; set; }
        public bool? Unbefristet { get; set; }
        public bool? Verlaengerung { get; set; }
        public int? Arbeitspensum { get; set; }
        public string ArbeitspensumErgaenzungen { get; set; }
        public int? Leistungsfaehigkeit { get; set; }
        public int? EinsatzVereinbarungDokId { get; set; }
        public DateTime? EinsatzVereinbarungErhalten { get; set; }
        public bool? EinsatzVereinbarungUnterschrieben { get; set; }
        public int? EinsatzEinladungDokId { get; set; }
        public DateTime? BieazdatumVon { get; set; }
        public DateTime? BieazdatumBis { get; set; }
        public bool? Bieazverlaengert { get; set; }
        public int? BieazvereinbarungDokId { get; set; }
        public bool? BieazvereinbarungUnterschrieben { get; set; }
        public string Bieazbemerkung { get; set; }
        public decimal? Bibruttolohn { get; set; }
        public int? BifinanzierungsgradEaz { get; set; }
        public decimal? BibeteilungEaz { get; set; }
        public DateTime? Bipzwischenbericht1Datum { get; set; }
        public bool? Bipzwischenbericht1Erhalten { get; set; }
        public DateTime? Bipzwischenbericht2Datum { get; set; }
        public bool? Bipzwischenbericht2Erhalten { get; set; }
        public int? InizioEinsatzAbbruchDurchCode { get; set; }
        public DateTime? InizioEinsatzAbbruch { get; set; }
        public DateTime? Abschluss { get; set; }
        public string InizioAbschlussGrund { get; set; }
        public string InizioLoesung { get; set; }
        public int? InizioAnschlussloesungCode { get; set; }
        public int? BiabschlussGrundCode { get; set; }
        public int? BipabschlussGrundCode { get; set; }
        public int? BibipsiabschlussDurchCode { get; set; }
        public int? SiabschlussGrundCode { get; set; }
        public int? Attest { get; set; }
        public string EinsatzBemerkungen { get; set; }
        public byte[] KaVermittlungEinsatzTs { get; set; }
        public int? MigrationKa { get; set; }

        public KaVermittlungVorschlag KaVermittlungVorschlag { get; set; }
    }
}
