using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class HistXuser
    {
        public int UserId { get; set; }
        public int? ChiefId { get; set; }
        public int? PrimaryUserId { get; set; }
        public int? PermissionGroupId { get; set; }
        public int? GrantPermGroupId { get; set; }
        public int? XprofileId { get; set; }
        public int? ModulId { get; set; }
        public int? SachbearbeiterId { get; set; }
        public string MitarbeiterNr { get; set; }
        public string LogonName { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShortName { get; set; }
        public bool IsLocked { get; set; }
        public bool IsUserAdmin { get; set; }
        public bool IsUserBiagadmin { get; set; }
        public bool IsMandatsTraeger { get; set; }
        public int? GenderCode { get; set; }
        public DateTime? Geburtstag { get; set; }
        public int? LanguageCode { get; set; }
        public string Phone { get; set; }
        public string PhoneMobile { get; set; }
        public string PhoneOffice { get; set; }
        public string PhoneIntern { get; set; }
        public string PhonePrivat { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int? UserProfileCode { get; set; }
        public string Funktion { get; set; }
        public int? RoleTitleCode { get; set; }
        public int? QualificationTitleCode { get; set; }
        public string Bemerkungen { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public double? JobPercentage { get; set; }
        public int? HoursPerYearForCaseMgmt { get; set; }
        public DateTime? Eintrittsdatum { get; set; }
        public DateTime? Austrittsdatum { get; set; }
        public int? LohntypCode { get; set; }
        public int? Kostentraeger { get; set; }
        public string WeitereKostentraeger { get; set; }
        public int? Kostenart { get; set; }
        public bool KeinBdeexport { get; set; }
        public string MigHerkunft { get; set; }
        public string MigMakuerzel { get; set; }
        public bool MigUserFix { get; set; }
        public string Visdat36Area { get; set; }
        public string Visdat36SourceFile { get; set; }
        public string Visdat36Id { get; set; }
        public string Visdat36Name { get; set; }
        public int VerId { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public int? VerIdDeleted { get; set; }
    }
}
