namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaArbeitAusbildung")]
    public partial class BaArbeitAusbildung
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BaPersonID { get; set; }

        public int? ErwerbssituationStatus1Code { get; set; }

        public int? ErwerbssituationStatus2Code { get; set; }

        public int? ErwerbssituationStatus3Code { get; set; }

        public int? ErwerbssituationStatus4Code { get; set; }

        public int? BeschaeftigungsGradCode { get; set; }

        public int? GrundTeilzeitarbeit1Code { get; set; }

        public int? GrundTeilzeitarbeit2Code { get; set; }

        public int? BrancheCode { get; set; }

        public int? ErlernterBerufCode { get; set; }

        public int? BerufCode { get; set; }

        public int? BaInstitutionID { get; set; }

        public int? HoechsteAusbildungCode { get; set; }

        public int? AbgebrochenAusbildungCode { get; set; }

        public int? AnstellungCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Arbeitszeit { get; set; }

        public bool IsVariableArbeitszeit { get; set; }

        public DateTime? StempelDatum { get; set; }

        public int? WieOftArbeitslos { get; set; }

        public int? AusgesteuertUnbekanntCode { get; set; }

        public DateTime? AusgesteuertDatum { get; set; }

        public string Bemerkung { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BaArbeitAusbildungTS { get; set; }

        public int? IntegrationsstandCode { get; set; }

        public bool FinanziellUnabhaengig { get; set; }

        public virtual BaInstitution BaInstitution { get; set; }

        public virtual BaPerson BaPerson { get; set; }
    }
}
