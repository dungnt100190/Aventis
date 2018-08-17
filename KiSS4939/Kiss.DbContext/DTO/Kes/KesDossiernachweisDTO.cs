using System.Collections.Generic;

namespace Kiss.DbContext.DTO.Kes
{
    public class KesDossiernachweisDTO
    {
        public KesDossiernachweisDTO()
        {
            DossiernachweisGemeindeDTOs = new Dictionary<int, KesDossiernachweisGemeindeDTO>();
        }

        public IDictionary<int, KesDossiernachweisGemeindeDTO> DossiernachweisGemeindeDTOs { get; set; }

        public string Kapitel { get; set; }

        public string Text { get; set; }

        public int Total { get; set; }
    }
}