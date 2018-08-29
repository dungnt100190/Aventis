namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Hist_XUser
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        public int? ChiefID { get; set; }

        public int? PrimaryUserID { get; set; }

        public int? PermissionGroupID { get; set; }

        public int? GrantPermGroupID { get; set; }

        public int? XProfileID { get; set; }

        public int? ModulID { get; set; }

        public int? SachbearbeiterID { get; set; }

        [StringLength(50)]
        public string MitarbeiterNr { get; set; }

        [Required]
        [StringLength(200)]
        public string LogonName { get; set; }

        [StringLength(200)]
        public string PasswordHash { get; set; }

        [StringLength(200)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(200)]
        public string LastName { get; set; }

        [StringLength(10)]
        public string ShortName { get; set; }

        public bool IsLocked { get; set; }

        public bool IsUserAdmin { get; set; }

        public bool IsUserBIAGAdmin { get; set; }

        public bool IsMandatsTraeger { get; set; }

        public int? GenderCode { get; set; }

        public DateTime? Geburtstag { get; set; }

        public int? LanguageCode { get; set; }

        [StringLength(100)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string PhoneMobile { get; set; }

        [StringLength(100)]
        public string PhoneOffice { get; set; }

        [StringLength(100)]
        public string PhoneIntern { get; set; }

        [StringLength(100)]
        public string PhonePrivat { get; set; }

        [StringLength(100)]
        public string Fax { get; set; }

        [StringLength(100)]
        public string EMail { get; set; }

        public int? UserProfileCode { get; set; }

        [StringLength(100)]
        public string Funktion { get; set; }

        public int? RoleTitleCode { get; set; }

        public int? QualificationTitleCode { get; set; }

        [StringLength(1000)]
        public string Bemerkungen { get; set; }

        [StringLength(2000)]
        public string Text1 { get; set; }

        [StringLength(2000)]
        public string Text2 { get; set; }

        public double? JobPercentage { get; set; }

        public int? HoursPerYearForCaseMgmt { get; set; }

        public DateTime? Eintrittsdatum { get; set; }

        public DateTime? Austrittsdatum { get; set; }

        public int? LohntypCode { get; set; }

        public int? Kostentraeger { get; set; }

        [StringLength(500)]
        public string WeitereKostentraeger { get; set; }

        public int? Kostenart { get; set; }

        public bool KeinBDEExport { get; set; }

        [StringLength(50)]
        public string MigHerkunft { get; set; }

        [StringLength(50)]
        public string MigMAKuerzel { get; set; }

        public bool MigUserFix { get; set; }

        [StringLength(255)]
        public string visdat36Area { get; set; }

        [StringLength(255)]
        public string visdat36SourceFile { get; set; }

        [StringLength(50)]
        public string visdat36ID { get; set; }

        [StringLength(255)]
        public string visdat36Name { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VerID { get; set; }

        [Required]
        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [StringLength(50)]
        public string Modifier { get; set; }

        public DateTime Modified { get; set; }

        public int? VerID_DELETED { get; set; }
    }
}
