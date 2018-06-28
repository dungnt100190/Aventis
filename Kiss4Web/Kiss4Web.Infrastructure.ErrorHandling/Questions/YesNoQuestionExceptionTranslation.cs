using System.Net;

namespace Kiss4Web.Infrastructure.ErrorHandling.Questions
{
    public class YesNoQuestionExceptionTranslation : ExceptionTranslation<YesNoQuestionException>
    {
        public YesNoQuestionExceptionTranslation()
        {
            HttpCode = HttpStatusCode.BadRequest;
        }

        public override object Translate(YesNoQuestionException ex)
        {
            return new QuestionDto
            {
                QuestionIdentifier = ex.QuestionIdentifier,
                PossibleAnswers = ex.PossibleAnswers
            };
        }
    }
}