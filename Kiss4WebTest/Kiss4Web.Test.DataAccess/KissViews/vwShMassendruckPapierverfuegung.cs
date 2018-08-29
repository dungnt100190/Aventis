namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwShMassendruckPapierverfuegung")]
    public partial class vwShMassendruckPapierverfuegung
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BaPersonID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BgBudgetID { get; set; }

        public int? Monat { get; set; }

        public int? Jahr { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KbBuchungID { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(401)]
        public string SAR { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(202)]
        public string Klient { get; set; }

        [StringLength(81)]
        public string BudgetMonat { get; set; }

        [StringLength(200)]
        public string Intern { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "money")]
        public decimal Betrag { get; set; }

        public bool? SelPrint { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BgFinanzplanID { get; set; }
    }
}
