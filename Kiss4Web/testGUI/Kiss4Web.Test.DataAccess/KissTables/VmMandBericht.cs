namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VmMandBericht")]
    public partial class VmMandBericht
    {
        public int VmMandBerichtID { get; set; }

        public int FaLeistungID { get; set; }

        public int? UserID { get; set; }

        public int? VmBerichtID { get; set; }

        public int? DocumentID { get; set; }

        public int? VmGrundMassnahmeCode { get; set; }

        public int? VmBerichtstitelCode { get; set; }

        public DateTime? BerichtDatumVon { get; set; }

        public DateTime? BerichtDatumBis { get; set; }

        public string GrundMassnahmeText { get; set; }

        public string AuftragZielsetzungText { get; set; }

        public int? VmZielErreichtCode { get; set; }

        public bool VeraenderungInPeriode { get; set; }

        public string Begruendung { get; set; }

        public string NeueZieleText { get; set; }

        public int? VmWohnenCode { get; set; }

        public int? VmGesundheitCode { get; set; }

        public int? VmVerhaltenCode { get; set; }

        public int? VmTaetigkeitCode { get; set; }

        public bool FamiliaereSituation { get; set; }

        public bool SozialeKompetenzen { get; set; }

        public bool Freizeit { get; set; }

        public bool Resourcen { get; set; }

        public string WohnenText { get; set; }

        public string GesundheitText { get; set; }

        public string VerhaltenText { get; set; }

        public string TaetigkeitText { get; set; }

        public string FamSituationText { get; set; }

        public string SozialeKompetenzenText { get; set; }

        public string FreizeitText { get; set; }

        public string BesondereRessourcenText { get; set; }

        public string HandlungenText { get; set; }

        public string BesondereSchwierigkeitenText { get; set; }

        public bool Klient { get; set; }

        public bool Dritte { get; set; }

        public bool Institutionen { get; set; }

        public string KlientText { get; set; }

        public string DritteText { get; set; }

        public string InstitutionenText { get; set; }

        public int? VmBerichtBelastungsangabeMCSCCode_Mandat { get; set; }

        public int? VmBerichtBelastungsangabeMCSCCode_Admin { get; set; }

        public string BelastungMandatText { get; set; }

        public string BelastungAdminText { get; set; }

        [StringLength(255)]
        public string VmEinnahmenAngabenCodes { get; set; }

        [StringLength(255)]
        public string VmBerichtVersicherungenCodes { get; set; }

        [StringLength(255)]
        public string VmBerichtBesondereAngabenCodes { get; set; }

        public string EinnahmenBemerkungen { get; set; }

        public string VersicherungenBemerkungen { get; set; }

        public string BesondereAngabenBemerkungen { get; set; }

        public bool AbrechnungUnterschrieben { get; set; }

        public bool PassationTeilnahme { get; set; }

        public string PassationBemerkung { get; set; }

        public int? VmAntragBerichtCode { get; set; }

        public string AntragBegruendung { get; set; }

        public DateTime? ErstellungDatum { get; set; }

        public int? VmMfBerichtBeilagenCode { get; set; }

        public DateTime? BsDatum { get; set; }

        public DateTime? BelegeZurueckRevision { get; set; }

        public DateTime? ZurueckVomBS { get; set; }

        public int? VmBerichtsartCode { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [StringLength(50)]
        public string Modifier { get; set; }

        public DateTime Modified { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] VmMandBerichtTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual VmBericht VmBericht { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
