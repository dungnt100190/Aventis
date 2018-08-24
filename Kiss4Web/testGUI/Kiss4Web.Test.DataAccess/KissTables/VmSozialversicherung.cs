namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VmSozialversicherung")]
    public partial class VmSozialversicherung
    {
        public int VmSozialversicherungID { get; set; }

        public int? FaLeistungID { get; set; }

        public int? BaPersonID_Adressat { get; set; }

        public int? BaInstitutionID_Adressat { get; set; }

        public int? VmPriMaID_Adressat { get; set; }

        public int? DocumentID_Korrespondenz { get; set; }

        public int? VmSozialversicherungenBezeichnungenCode { get; set; }

        public string Grund { get; set; }

        public DateTime? Eingereicht { get; set; }

        public DateTime? VerfuegungVom { get; set; }

        [StringLength(300)]
        public string Berechnungsgrundlage { get; set; }

        [Column(TypeName = "money")]
        public decimal? Verfuegungsbetrag { get; set; }

        public string Bemerkungen { get; set; }

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
        public byte[] VmSozialversicherungTS { get; set; }

        public virtual BaInstitution BaInstitution { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual VmPriMa VmPriMa { get; set; }
    }
}
