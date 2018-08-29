namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmFaAktennotizen")]
    public partial class vwTmFaAktennotizen
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FaAktennotizID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FaLeistungID { get; set; }

        [StringLength(20)]
        public string ID { get; set; }

        [StringLength(10)]
        public string Datum { get; set; }

        [StringLength(200)]
        public string Dauer { get; set; }

        public DateTime? Zeit { get; set; }

        [StringLength(200)]
        public string Kontaktart { get; set; }

        [StringLength(200)]
        public string GespraechsStatus { get; set; }

        [StringLength(200)]
        public string Gespraechstyp { get; set; }

        [StringLength(200)]
        public string Kontaktpartner { get; set; }

        [StringLength(200)]
        public string AlimentenstelleTyp { get; set; }

        [StringLength(200)]
        public string Stichwort { get; set; }

        public string InhaltMitFmt { get; set; }

        public string InhaltOhneFmt { get; set; }

        [StringLength(1000)]
        public string Themen { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(4)]
        public string Vertraulich { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(4)]
        public string BesprechungThema1 { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(4)]
        public string BesprechungThema2 { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(4)]
        public string BesprechungThema3 { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(4)]
        public string BesprechungThema4 { get; set; }

        [StringLength(200)]
        public string BesprechungThemaText1 { get; set; }

        [StringLength(200)]
        public string BesprechungThemaText2 { get; set; }

        [StringLength(200)]
        public string BesprechungThemaText3 { get; set; }

        [StringLength(200)]
        public string BesprechungThemaText4 { get; set; }

        [StringLength(200)]
        public string BesprechungZiel1 { get; set; }

        [StringLength(200)]
        public string BesprechungZiel2 { get; set; }

        [StringLength(200)]
        public string BesprechungZiel3 { get; set; }

        [StringLength(200)]
        public string BesprechungZiel4 { get; set; }

        [StringLength(20)]
        public string BesprechungZielGrad1 { get; set; }

        [StringLength(20)]
        public string BesprechungZielGrad2 { get; set; }

        [StringLength(20)]
        public string BesprechungZielGrad3 { get; set; }

        [StringLength(20)]
        public string BesprechungZielGrad4 { get; set; }

        [StringLength(200)]
        public string Pendenz1 { get; set; }

        [StringLength(200)]
        public string Pendenz2 { get; set; }

        [StringLength(200)]
        public string Pendenz3 { get; set; }

        [StringLength(200)]
        public string Pendenz4 { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(4)]
        public string PendenzErledigt1 { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(4)]
        public string PendenzErledigt2 { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(4)]
        public string PendenzErledigt3 { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(4)]
        public string PendenzErledigt4 { get; set; }

        [StringLength(200)]
        public string UserLogin { get; set; }

        [StringLength(200)]
        public string UserNachname { get; set; }

        [StringLength(200)]
        public string UserVorname { get; set; }

        [StringLength(10)]
        public string UserKuerzel { get; set; }

        [StringLength(402)]
        public string UserNameVorname { get; set; }

        [StringLength(401)]
        public string UserNameVornameOhneKomma { get; set; }

        [StringLength(401)]
        public string UserVornameName { get; set; }
    }
}
