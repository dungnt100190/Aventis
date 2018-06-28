namespace Kiss4Web.Infrastructure.ErrorHandling.Questions
{
    public class QuestionAnswerOption
    {
        public QuestionAnswerOption(object id, string caption)
        {
            Id = id;
            Caption = caption;
        }

        public string Caption { get; }

        public object Id { get; }
    }
}