using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.QueryTypes;
using System;
using System.Collections.Generic;

namespace Kiss4Web.Modules.Pendenzen.SearchPendenzen
{
    public class SearchPendenzenQuery : Message<IEnumerable<TablePendenzenItem>>
    {
        public int? IdStatus { get; set; }
        public int? IdPendenzTyp { get; set; }
        public string Betreff { get; set; }
        public int? IdErsteller { get; set; }
        public int? IdEmpfanger { get; set; }
        public string NameKlientIn { get; set; }
        public string VornameKlientIn { get; set; }
        public int? Fallnummer { get; set; }
        public int? IdLeistungsverantw { get; set; }
        public int? IdOrganisationseinheit { get; set; }
        public string FromErfasst { get; set; }
        public string ToErfasst { get; set; }
        public string FromFallig { get; set; }
        public string ToFallig { get; set; }
        public string FromBearbeitung { get; set; }
        public string ToBearbeitung { get; set; }
        public string FromErledigt { get; set; }
        public string ToErledigt { get; set; }
        public string IdMenu { get; set; }
        public string UserId{ get; set; }
    }
}
