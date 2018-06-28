using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class HistXorgUnit
    {
        public int OrgUnitId { get; set; }
        public int? ParentId { get; set; }
        public int? ModulId { get; set; }
        public int? ChiefId { get; set; }
        public int? RechtsdienstUserId { get; set; }
        public int? RepresentativeId { get; set; }
        public int? StellvertreterId { get; set; }
        public int? XprofileId { get; set; }
        public string ItemName { get; set; }
        public int? OeitemTypCode { get; set; }
        public int? ParentPosition { get; set; }
        public int? Kostenstelle { get; set; }
        public int? Mandantennummer { get; set; }
        public int? StundenLohnlaufNr { get; set; }
        public int? LeistungLohnlaufNr { get; set; }
        public int? Sammelkonto { get; set; }
        public string Pckonto { get; set; }
        public string AdAbteilung { get; set; }
        public string Logo { get; set; }
        public string Adressat { get; set; }
        public string Adresse { get; set; }
        public string AdresseKgs { get; set; }
        public string AdresseAbteilung { get; set; }
        public string AdresseStrasse { get; set; }
        public string Postfach { get; set; }
        public bool PostfachOhneNr { get; set; }
        public string AdresseHausNr { get; set; }
        public string AdressePlz { get; set; }
        public string AdresseOrt { get; set; }
        public string Phone { get; set; }
        public string Telefon { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Www { get; set; }
        public string Internet { get; set; }
        public int? UserProfileCode { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Text3 { get; set; }
        public string Text4 { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public int VerId { get; set; }
        public int? VerIdDeleted { get; set; }
    }
}
