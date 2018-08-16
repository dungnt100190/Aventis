using Kiss4Web.Infrastructure.Mediator;

namespace Kiss4Web.Modules.Pendenzen.CreateOrUpdate
{
    public class CreateUpdateQuery : Message<bool>
    {
        public int? id { get; set; }
        public int status { get; set; }
        public int? pendenzTyp { get; set; }
        public string betreff { get; set; }
        public string beschreibung { get; set; }
        public int? empfanger { get; set; }
        public string empfangerName { get; set; }
        public int? empfangerId { get; set; }
        public int? falltrager { get; set; }
        public string falltragerName { get; set; }
        public string leistungModul { get; set; }
        public int? leistung { get; set; }
        public int? leistungsverantw { get; set; }
        public int? betrifftPerson { get; set; }
        public string antwort { get; set; }
        public string erfasst { get; set; }
        public string fallig { get; set; }
        public string BearbeitungName { get; set; }
        public string ErledigtName { get; set; }
        public string SenderId { get; set; }
        public int? PersonId { get; set; }

    }
}
