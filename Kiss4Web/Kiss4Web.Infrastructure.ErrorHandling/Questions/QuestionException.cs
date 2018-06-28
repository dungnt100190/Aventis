using System.Collections.Generic;

namespace Kiss4Web.Infrastructure.ErrorHandling.Questions
{
    /// <summary>
    /// The request was not completed because a question has to be answered by the user
    /// </summary>
    public class QuestionException : ValidationException
    {
        public string QuestionIdentifier { get; }
        public IEnumerable<QuestionAnswerOption> PossibleAnswers { get; }

        public QuestionException(string message, string questionIdentifier, IEnumerable<QuestionAnswerOption> possibleAnswers)
            : base(message)
        {
            QuestionIdentifier = questionIdentifier;
            PossibleAnswers = possibleAnswers ?? new List<QuestionAnswerOption>();
        }
    }
}