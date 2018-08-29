namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmVmMandBericht")]
    public partial class vwTmVmMandBericht
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VmMandBerichtID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FaLeistungID { get; set; }

        public int? VmBerichtID { get; set; }

        [StringLength(200)]
        public string GrundMassnahme { get; set; }

        [StringLength(200)]
        public string Berichtstitel { get; set; }

        [StringLength(10)]
        public string BerichtDatumVon { get; set; }

        [StringLength(10)]
        public string BerichtDatumBis { get; set; }

        public string GrundMassnahmeText { get; set; }

        public string AuftragZielsetzungText { get; set; }

        [StringLength(200)]
        public string ZielErreicht { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool VIP { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(4)]
        public string VeraenderungInPeriodCBText { get; set; }

        public string Begruendung { get; set; }

        public string NeueZieleText { get; set; }

        [StringLength(200)]
        public string Wohnen { get; set; }

        [StringLength(200)]
        public string Gesundheit { get; set; }

        [StringLength(200)]
        public string Verhalten { get; set; }

        [StringLength(200)]
        public string Taetigkeit { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool FS { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(4)]
        public string FamiliaereSituationCBText { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool SK { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(4)]
        public string SozialeKompetenzenCBText { get; set; }

        [Key]
        [Column(Order = 8)]
        public bool FZ { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(4)]
        public string FreizeitCBText { get; set; }

        [Key]
        [Column(Order = 10)]
        public bool RES { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(4)]
        public string ResourcenCBText { get; set; }

        public string WohnenText { get; set; }

        public string GesundheitText { get; set; }

        public string VerhaltenText { get; set; }

        public string TaetigkeitText { get; set; }

        public string FamSituationText { get; set; }

        public string SozialeKompetenzenText { get; set; }

        public string FreizeitText { get; set; }

        public string BesondereRessourcenText { get; set; }

        public string HandlungenText { get; set; }

        public string BesSchwierigkeitenText { get; set; }

        [Key]
        [Column(Order = 12)]
        public bool KL { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(4)]
        public string KlientCBText { get; set; }

        [Key]
        [Column(Order = 14)]
        public bool DR { get; set; }

        [Key]
        [Column(Order = 15)]
        [StringLength(4)]
        public string DritteCBText { get; set; }

        [Key]
        [Column(Order = 16)]
        public bool I { get; set; }

        [Key]
        [Column(Order = 17)]
        [StringLength(4)]
        public string InstitutionenCBText { get; set; }

        public string KlientText { get; set; }

        public string DritteText { get; set; }

        public string InstitutionenText { get; set; }

        [StringLength(200)]
        public string MCSCMandat { get; set; }

        [StringLength(200)]
        public string BerichtBelastAngMCSCAdmin { get; set; }

        public string BelastungMandatText { get; set; }

        public string BelastungAdminText { get; set; }

        [StringLength(1000)]
        public string EinnahmenAngaben { get; set; }

        [StringLength(255)]
        public string EA { get; set; }

        [StringLength(1000)]
        public string BerichtVersicherungen { get; set; }

        [StringLength(255)]
        public string BV { get; set; }

        [StringLength(1000)]
        public string BerichtBesondereAngaben { get; set; }

        [StringLength(255)]
        public string BBA { get; set; }

        public string EinnahmenBemerkungen { get; set; }

        public string VersicherungenBemerkungen { get; set; }

        public string BesondereAngabenBem { get; set; }

        [Key]
        [Column(Order = 18)]
        public bool AU { get; set; }

        [Key]
        [Column(Order = 19)]
        [StringLength(4)]
        public string AbrechnungUnterschrieben { get; set; }

        [Key]
        [Column(Order = 20)]
        public bool PT { get; set; }

        [Key]
        [Column(Order = 21)]
        [StringLength(4)]
        public string PassationTeilnahmeCBText { get; set; }

        public string PassationBemerkung { get; set; }

        [StringLength(200)]
        public string AntragBericht { get; set; }

        public string AntragBegruendung { get; set; }

        [StringLength(10)]
        public string ErstellungDatum { get; set; }

        [StringLength(200)]
        public string BerichtBeilagen { get; set; }

        [StringLength(10)]
        public string BsDatum { get; set; }

        [StringLength(10)]
        public string BelegeZurueckRevision { get; set; }

        [StringLength(10)]
        public string ZurueckVomBS { get; set; }

        [StringLength(200)]
        public string Berichtsart { get; set; }

        [StringLength(401)]
        public string Autor { get; set; }
    }
}
