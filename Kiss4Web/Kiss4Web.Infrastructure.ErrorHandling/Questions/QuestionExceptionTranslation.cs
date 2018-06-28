using System.Net;

namespace Kiss4Web.Infrastructure.ErrorHandling.Questions
{
    public class QuestionExceptionTranslation : ExceptionTranslation<QuestionException>
    {
        public QuestionExceptionTranslation()
        {
            HttpCode = HttpStatusCode.BadRequest;
        }

        public override object Translate(QuestionException ex)
        {
            return new QuestionDto
            {
                QuestionIdentifier = ex.QuestionIdentifier,
                PossibleAnswers = ex.PossibleAnswers
            };
        }
    }
}