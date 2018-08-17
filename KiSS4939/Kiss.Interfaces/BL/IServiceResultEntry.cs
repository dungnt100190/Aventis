using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kiss.Interfaces.BL
{
    public interface IServiceResultEntry
    {
        [DataMember]
        List<QuestionAnswerOption> AvailableAnswerOptions { get; set; }

        Exception Exception { get; set; }

        [DataMember]
        string ExceptionString { get; set; }

        [DataMember]
        string Message { get; set; }

        [DataMember]
        string MessageID { get; set; }

        [DataMember]
        object[] MessageParameters { get; set; }

        [DataMember]
        string PropertyName { get; set; }

        [DataMember]
        ServiceResultType ResultType { get; }

        string GetMessage();
    }
}