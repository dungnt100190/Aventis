using System.Runtime.Serialization;

namespace Kiss.Interfaces
{
    [DataContract]
    public class QuestionAnswerOption
    {
        public QuestionAnswerOption(object tag, string caption)
        {
            Tag = tag;
            Caption = caption;
        }

        [DataMember]
        public string Caption { get; private set; }

        [DataMember]
        public object Tag { get; private set; }
    }
}