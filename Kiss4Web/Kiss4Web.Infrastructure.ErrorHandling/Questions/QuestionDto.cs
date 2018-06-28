using System.Collections.Generic;

namespace Kiss4Web.Infrastructure.ErrorHandling.Questions
{
    public class QuestionDto
    {
        public string QuestionIdentifier { get; set; }
        public IEnumerable<QuestionAnswerOption> PossibleAnswers { get; set; }
    }
}