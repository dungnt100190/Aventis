using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FaWeisung
    {
        public FaWeisung()
        {
            FaWeisungBaPerson = new HashSet<FaWeisungBaPerson>();
            FaWeisungProtokoll = new HashSet<FaWeisungProtokoll>();
        }

        public int FaWeisungId { get; set; }
        public int FaLeistungId { get; set; }
        public int UserIdCreator { get; set; }
        public int? UserIdVerantwortlichRd { get; set; }
        public int? UserIdVerantwortlichSar { get; set; }
        public int? XtaskIdSar { get; set; }
        public int StatusCode { get; set; }
        public int WeisungsartCode { get; set; }
        public string Betreff { get; set; }
        public string Ausganslage { get; set; }
        public string Auflage { get; set; }
        public int KonsequenzCodeAngedroht { get; set; }
        public int KuerzungGbangedroht { get; set; }
        public DateTime? TerminWeisung { get; set; }
        public int? XdocumentIdWeisung { get; set; }
        public DateTime? TerminMahnung1 { get; set; }
        public int? XdocumentIdMahnung1 { get; set; }
        public DateTime? TerminMahnung2 { get; set; }
        public int? XdocumentIdMahnung2 { get; set; }
        public DateTime? TerminMahnung3 { get; set; }
        public int? XdocumentIdMahnung3 { get; set; }
        public DateTime? DatumVerfuegung { get; set; }
        public int? XdocumentIdVerfuegung { get; set; }
        public int? KonsequenzCodeVerfuegt { get; set; }
        public DateTime? KonsequenzDatumVon { get; set; }
        public DateTime? KonsequenzDatumBis { get; set; }
        public int? KuerzungGbverfuegt { get; set; }
        public DateTime? KuerzungDatumVon { get; set; }
        public DateTime? KuerzungDatumBis { get; set; }
        public bool WeisungVerschoben { get; set; }
        public bool WeisungErfuellt { get; set; }
        public bool? CanDelete { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] FaWeisungTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public XUser UserIdCreatorNavigation { get; set; }
        public XUser UserIdVerantwortlichRdNavigation { get; set; }
        public XUser UserIdVerantwortlichSarNavigation { get; set; }
        public Xtask XtaskIdSarNavigation { get; set; }
        public ICollection<FaWeisungBaPerson> FaWeisungBaPerson { get; set; }
        public ICollection<FaWeisungProtokoll> FaWeisungProtokoll { get; set; }
    }
}
