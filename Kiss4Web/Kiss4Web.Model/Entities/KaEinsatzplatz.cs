using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaEinsatzplatz
    {
        public KaEinsatzplatz()
        {
            KaVermittlungVorschlag = new HashSet<KaVermittlungVorschlag>();
        }

        public int KaEinsatzplatzId { get; set; }
        public string Bezeichnung { get; set; }
        public int? BrancheCode { get; set; }
        public int? KaBetriebId { get; set; }
        public bool? Aktiv { get; set; }
        public int? KaProgrammCode { get; set; }
        public int? ZustaendigKa { get; set; }
        public int? LehrberufCode { get; set; }
        public int? BerufsAusbildungTyp { get; set; }
        public bool? NeuGeschaffeneLehrstelle { get; set; }
        public string Details { get; set; }
        public DateTime? ErfassungsDatum { get; set; }
        public DateTime? EinsatzAb { get; set; }
        public bool? DauerUnbefristet { get; set; }
        public int? GesamtPensum { get; set; }
        public bool? PensumAufteilbar { get; set; }
        public int? EinzelpensumMinimum { get; set; }
        public int? EinzelpensumMaximum { get; set; }
        public bool? PensumUnbestimmt { get; set; }
        public bool? Fuehrerausweis { get; set; }
        public int? FuehrerausweisKategorieCode { get; set; }
        public bool? Pckenntnisse { get; set; }
        public int? GeschlechtCode { get; set; }
        public int? DeutschMuendlichCode { get; set; }
        public int? DeutschSchriftlichCode { get; set; }
        public int? AusbildungCode { get; set; }
        public string WeitereAnforderungen { get; set; }
        public int? KaKontaktpersonId { get; set; }
        public int? FunktionCode { get; set; }
        public string Bemerkung { get; set; }
        public byte[] KaEinsatzplatzTs { get; set; }
        public int? MigrationKa { get; set; }

        public KaBetrieb KaBetrieb { get; set; }
        public KaBetriebKontakt KaKontaktperson { get; set; }
        public ICollection<KaVermittlungVorschlag> KaVermittlungVorschlag { get; set; }
    }
}
