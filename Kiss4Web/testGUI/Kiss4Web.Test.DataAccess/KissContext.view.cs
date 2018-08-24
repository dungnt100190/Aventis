namespace Kiss4Web.Test.DataAccess
{
    using System.Data.Entity;

    public partial class KissContext : DbContext
    {
        public virtual DbSet<AyKostenart> AyKostenarts { get; set; }
        public virtual DbSet<AyPositionsart> AyPositionsarts { get; set; }
        public virtual DbSet<FaFall> FaFalls { get; set; }
        public virtual DbSet<FaFallPerson> FaFallPersons { get; set; }
        public virtual DbSet<viewDauerauftrag> viewDauerauftrags { get; set; }
        public virtual DbSet<viewDTAFbBuchungen> viewDTAFbBuchungens { get; set; }
        public virtual DbSet<viewFbBuchungCode> viewFbBuchungCodes { get; set; }
        public virtual DbSet<viewFbBuchungen> viewFbBuchungens { get; set; }
        public virtual DbSet<vwBaAdressate> vwBaAdressates { get; set; }
        public virtual DbSet<vwBaKlientensystemPerson> vwBaKlientensystemPersons { get; set; }
        public virtual DbSet<vwBaZahlungsweg> vwBaZahlungswegs { get; set; }
        public virtual DbSet<vwBFSDossier> vwBFSDossiers { get; set; }
        public virtual DbSet<vwBgPosition> vwBgPositions { get; set; }
        public virtual DbSet<vwBgPositionFinanzplan> vwBgPositionFinanzplans { get; set; }
        public virtual DbSet<vwInstitution> vwInstitutions { get; set; }
        public virtual DbSet<vwIxBDELeistung_BDELeistungsart_AuswDLCode> vwIxBDELeistung_BDELeistungsart_AuswDLCode { get; set; }
        public virtual DbSet<vwKreditor> vwKreditors { get; set; }
        public virtual DbSet<vwPerson> vwPersons { get; set; }
        public virtual DbSet<vwPersonSimple> vwPersonSimples { get; set; }
        public virtual DbSet<vwShMassendruckPapierverfuegung> vwShMassendruckPapierverfuegungs { get; set; }
        public virtual DbSet<vwTmAbklPhasen> vwTmAbklPhasens { get; set; }
        public virtual DbSet<vwTmAdressat> vwTmAdressats { get; set; }
        public virtual DbSet<vwTmAllgemein> vwTmAllgemeins { get; set; }
        public virtual DbSet<vwTmErblasser> vwTmErblassers { get; set; }
        public virtual DbSet<vwTmFaAktennotizen> vwTmFaAktennotizens { get; set; }
        public virtual DbSet<vwTmGvGesuch> vwTmGvGesuches { get; set; }
        public virtual DbSet<vwTmInstitution> vwTmInstitutions { get; set; }
        public virtual DbSet<vwTmKaBetrieb> vwTmKaBetriebs { get; set; }
        public virtual DbSet<vwTmKaBetriebVerlauf> vwTmKaBetriebVerlaufs { get; set; }
        public virtual DbSet<vwTmKaEafSozioberuflicheBilanz> vwTmKaEafSozioberuflicheBilanzs { get; set; }
        public virtual DbSet<vwTmKaEafSpezifischeErmittlung> vwTmKaEafSpezifischeErmittlungs { get; set; }
        public virtual DbSet<vwTmKaEinsatzplatz> vwTmKaEinsatzplatzs { get; set; }
        public virtual DbSet<vwTmKaQJFallfuehrung> vwTmKaQJFallfuehrungs { get; set; }
        public virtual DbSet<vwTmKaTransfer> vwTmKaTransfers { get; set; }
        public virtual DbSet<vwTmKaVerlauf> vwTmKaVerlaufs { get; set; }
        public virtual DbSet<vwTmKaVermittlung> vwTmKaVermittlungs { get; set; }
        public virtual DbSet<vwTmKaVermittlungBIBIP> vwTmKaVermittlungBIBIPs { get; set; }
        public virtual DbSet<vwTmKaVermittlungSI> vwTmKaVermittlungSIs { get; set; }
        public virtual DbSet<vwTmKesAuftrag> vwTmKesAuftrags { get; set; }
        public virtual DbSet<vwTmKesDokument> vwTmKesDokuments { get; set; }
        public virtual DbSet<vwTmKesMassnahmeBericht> vwTmKesMassnahmeBerichts { get; set; }
        public virtual DbSet<vwTmKesVerlauf> vwTmKesVerlaufs { get; set; }
        public virtual DbSet<vwTmPerson> vwTmPersons { get; set; }
        public virtual DbSet<vwTmUser> vwTmUsers { get; set; }
        public virtual DbSet<vwTmVermittlungEinsatz> vwTmVermittlungEinsatzs { get; set; }
        public virtual DbSet<vwTmVermittlungProfil> vwTmVermittlungProfils { get; set; }
        public virtual DbSet<vwTmVmAntragEKSK> vwTmVmAntragEKSKs { get; set; }
        public virtual DbSet<vwTmVmGefaehrdungsMeldung> vwTmVmGefaehrdungsMeldungs { get; set; }
        public virtual DbSet<vwTmVmMandBericht> vwTmVmMandBerichts { get; set; }
        public virtual DbSet<vwTmVmSachversicherung> vwTmVmSachversicherungs { get; set; }
        public virtual DbSet<vwTmVmSituationsBericht> vwTmVmSituationsBerichts { get; set; }
        public virtual DbSet<vwTmVmVaterschaft> vwTmVmVaterschafts { get; set; }
        public virtual DbSet<vwUser> vwUsers { get; set; }
        public virtual DbSet<vwUserSimple> vwUserSimples { get; set; }
        public virtual DbSet<vwXConfig_public> vwXConfig_public { get; set; }
        public virtual DbSet<WhKostenart> WhKostenarts { get; set; }
        public virtual DbSet<WhPositionsart> WhPositionsarts { get; set; }
        public virtual DbSet<XViewForeignKey> XViewForeignKeys { get; set; }
        public virtual DbSet<XViewIndex> XViewIndexes { get; set; }
    }
}
