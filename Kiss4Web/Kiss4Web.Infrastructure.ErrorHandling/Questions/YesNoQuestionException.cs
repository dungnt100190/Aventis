namespace Kiss4Web.Infrastructure.ErrorHandling.Questions
{
    public class YesNoQuestionException : QuestionException
    {
        public YesNoQuestionException(string message, string questionIdentifier)
            : base(message, questionIdentifier, new[] { new QuestionAnswerOption(true, ErrorHandlingRessources.Ja), new QuestionAnswerOption(false, ErrorHandlingRessources.Nein) })
        {
        }
    }
}