namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmUser")]
    public partial class vwTmUser
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BenutzerNr { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(200)]
        public string Login { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(200)]
        public string Nachname { get; set; }

        [StringLength(200)]
        public string Vorname { get; set; }

        [StringLength(10)]
        public string Kuerzel { get; set; }

        [StringLength(100)]
        public string Telephon { get; set; }

        [StringLength(100)]
        public string EMail { get; set; }

        [StringLength(3)]
        public string ErSieGross { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(9)]
        public string FrauHerr { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(10)]
        public string FrauHerrn { get; set; }

        [StringLength(2000)]
        public string Briefanrede { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(402)]
        public string NameVorname { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(401)]
        public string NameVornameOhneKomma { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(401)]
        public string VornameName { get; set; }

        [StringLength(2000)]
        public string Text1MitFmt { get; set; }

        [StringLength(2000)]
        public string Text1OhneFmt { get; set; }

        [StringLength(2000)]
        public string Text2MitFmt { get; set; }

        [StringLength(2000)]
        public string Text2OhneFmt { get; set; }

        [StringLength(100)]
        public string AbteilungEMail { get; set; }

        [StringLength(100)]
        public string AbteilungFax { get; set; }

        [StringLength(100)]
        public string AbteilungName { get; set; }

        [StringLength(100)]
        public string AbteilungTelefon { get; set; }

        [StringLength(100)]
        public string AbteilungTelFaxWWW { get; set; }

        [StringLength(2000)]
        public string AbteilungText1MitFmt { get; set; }

        [StringLength(2000)]
        public string AbteilungText1OhneFmt { get; set; }

        [StringLength(2000)]
        public string AbteilungText2MitFmt { get; set; }

        [StringLength(2000)]
        public string AbteilungText2OhneFmt { get; set; }

        [StringLength(2000)]
        public string AbteilungText3MitFmt { get; set; }

        [StringLength(2000)]
        public string AbteilungText3OhneFmt { get; set; }

        [StringLength(2000)]
        public string AbteilungText4MitFmt { get; set; }

        [StringLength(2000)]
        public string AbteilungText4OhneFmt { get; set; }

        [StringLength(100)]
        public string AbteilungWWW { get; set; }

        [StringLength(200)]
        public string CareOf { get; set; }

        [StringLength(200)]
        public string AdressZusatz { get; set; }

        [StringLength(200)]
        public string ZuhandenVon { get; set; }

        [StringLength(100)]
        public string Strasse { get; set; }

        [StringLength(10)]
        public string HausNr { get; set; }

        [StringLength(100)]
        public string Postfach { get; set; }

        public bool? PostfachOhneNr { get; set; }

        [StringLength(255)]
        public string PostfachTextD { get; set; }

        [StringLength(10)]
        public string PLZ { get; set; }

        [StringLength(50)]
        public string Ort { get; set; }

        public int? OrtschaftCode { get; set; }

        [StringLength(10)]
        public string Kanton { get; set; }

        [StringLength(100)]
        public string Bezirk { get; set; }

        [StringLength(111)]
        public string StrasseHausNr { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(163)]
        public string OrtStrasse { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(61)]
        public string PLZOrt { get; set; }

        [StringLength(200)]
        public string LandD { get; set; }

        [StringLength(200)]
        public string LandF { get; set; }

        [StringLength(200)]
        public string LandI { get; set; }

        [StringLength(200)]
        public string LandE { get; set; }

        [StringLength(1135)]
        public string AdresseEinzeilig { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(633)]
        public string AdresseEinzOhneName { get; set; }

        [StringLength(1135)]
        public string AdresseMehrzeilig { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(633)]
        public string AdresseMehrzOhneName { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(4)]
        public string AbteilungLeitungInitialen { get; set; }
    }
}
