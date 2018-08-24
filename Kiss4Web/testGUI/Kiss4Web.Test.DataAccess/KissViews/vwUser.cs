namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwUser")]
    public partial class vwUser
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string LogonName { get; set; }

        [StringLength(200)]
        public string FirstName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(200)]
        public string LastName { get; set; }

        [StringLength(10)]
        public string ShortName { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool IsUserAdmin { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool IsUserBIAGAdmin { get; set; }

        [StringLength(200)]
        public string PasswordHash { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool IsLocked { get; set; }

        public int? GenderCode { get; set; }

        public int? LanguageCode { get; set; }

        public int? ModulID { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool isMandatsTraeger { get; set; }

        [StringLength(100)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string EMail { get; set; }

        public int? ChiefID { get; set; }

        public int? PermissionGroupID { get; set; }

        public int? GrantPermGroupID { get; set; }

        [StringLength(2000)]
        public string Text1 { get; set; }

        [StringLength(2000)]
        public string Text2 { get; set; }

        public double? JobPercentage { get; set; }

        public int? HoursPerYearForCaseMgmt { get; set; }

        [Key]
        [Column(Order = 7, TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XUserTS { get; set; }

        public int? XProfileID { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(402)]
        public string NameVorname { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(401)]
        public string NameVornameOhneKomma { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(401)]
        public string VornameName { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(708)]
        public string LogonNameVornameOrgUnit { get; set; }

        public int? OrgUnitID { get; set; }

        public int? ParentID { get; set; }

        [StringLength(100)]
        public string OrgEinheitName { get; set; }

        [StringLength(100)]
        public string OrgUnit { get; set; }

        [StringLength(100)]
        public string OrgEinheitEmail { get; set; }

        [StringLength(100)]
        public string OrgEinheitFax { get; set; }

        [StringLength(100)]
        public string OrgEinheitWWW { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(708)]
        public string DisplayText { get; set; }
    }
}
