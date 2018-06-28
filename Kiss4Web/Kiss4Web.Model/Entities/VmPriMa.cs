using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class VmPriMa
    {
        public VmPriMa()
        {
            BaAdresse = new HashSet<BaAdresse>();
            FaDokumente = new HashSet<FaDokumente>();
            KesMassnahmeBss = new HashSet<KesMassnahmeBss>();
            VmErnennung = new HashSet<VmErnennung>();
            VmSachversicherung = new HashSet<VmSachversicherung>();
            VmSozialversicherung = new HashSet<VmSozialversicherung>();
        }

        public int VmPriMaId { get; set; }
        public string Titel { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }
        public string TelefonP { get; set; }
        public string TelefonG { get; set; }
        public string MobilTel { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Beruf { get; set; }
        public int? SprachCode { get; set; }
        public string BankName { get; set; }
        public string BankKontoNr { get; set; }
        public string Bemerkung { get; set; }
        public bool? IsActive { get; set; }
        public byte[] VmPriMaTs { get; set; }
        public int? VerId { get; set; }
        public string Ahvnummer { get; set; }
        public string Versichertennummer { get; set; }
        public DateTime? Geburtsdatum { get; set; }

        public ICollection<BaAdresse> BaAdresse { get; set; }
        public ICollection<FaDokumente> FaDokumente { get; set; }
        public ICollection<KesMassnahmeBss> KesMassnahmeBss { get; set; }
        public ICollection<VmErnennung> VmErnennung { get; set; }
        public ICollection<VmSachversicherung> VmSachversicherung { get; set; }
        public ICollection<VmSozialversicherung> VmSozialversicherung { get; set; }
    }
}
