using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class VmSachversicherung
    {
        public int VmSachversicherungId { get; set; }
        public int FaLeistungId { get; set; }
        public int? BaPersonId { get; set; }
        public int? BaInstitutionId { get; set; }
        public int? VmPriMaId { get; set; }
        public int? DocumentIdMutation { get; set; }
        public int? DocumentIdMittAnm { get; set; }
        public int? DocumentIdAufhKuend { get; set; }
        public int? VmVersicherungsartSachversicherungCode { get; set; }
        public string Policenummer { get; set; }
        public decimal? Selbstbehalt { get; set; }
        public string Grundpraemie { get; set; }
        public int? VmZahlungsturnusCode { get; set; }
        public DateTime? LaufzeitVon { get; set; }
        public DateTime? LaufzeitBis { get; set; }
        public DateTime? VersichertSeit { get; set; }
        public string Person { get; set; }
        public string Bemerkungen { get; set; }
        public bool IsDeleted { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] VmSachversicherungTs { get; set; }

        public BaInstitution BaInstitution { get; set; }
        public BaPerson BaPerson { get; set; }
        public FaLeistung FaLeistung { get; set; }
        public VmPriMa VmPriMa { get; set; }
    }
}
