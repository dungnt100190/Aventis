using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Kiss.Interfaces;
using Kiss.Interfaces.BL;

namespace Kiss.Infrastructure
{
    [DataContract]
    public class ServiceResultEntry : IServiceResultEntry
    {
        private Exception _exception;

        public ServiceResultEntry(ServiceResultType resultType)
        {
            ResultType = resultType;
            Exception = null;
            Message = "";
            MessageID = "";
            MessageParameters = null;
        }

        [DataMember]
        public List<QuestionAnswerOption> AvailableAnswerOptions { get; set; }

        public Exception Exception
        {
            get { return _exception; }
            set
            {
                _exception = value;
                ExceptionString = value != null ? value.ToString() : null;
            }
        }

        /// <summary>
        /// As Exception cannot easily be serialized, we store it as a string.
        /// </summary>
        [DataMember]
        public string ExceptionString { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string MessageID { get; set; }

        [DataMember]
        public object[] MessageParameters { get; set; }

        [DataMember]
        public string PropertyName { get; set; }

        [DataMember]
        public ServiceResultType ResultType { get; private set; }

        public string GetMessage()
        {
            if (MessageParameters == null || MessageParameters.Length == 0)
            {
                return Message;
            }
            return string.Format(Message, MessageParameters);
        }

        public override string ToString()
        {
            return GetMessage();
        }
    }
}