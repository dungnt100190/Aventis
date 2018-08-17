using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kiss.Interfaces.BL
{
    [DataContract]
    public class KissServiceResultEntry : IServiceResultEntry
    {
        private Exception _exception;

        public KissServiceResultEntry(ServiceResultType resultType)
        {
            ResultType = resultType;
            Exception = null;
            Message = "";
            MessageID = "";
            MessageParameters = null;
        }

        public List<QuestionAnswerOption> AvailableAnswerOptions
        {
            get;
            set;
        }

        public Exception Exception
        {
            get { return _exception; }
            set
            {
                _exception = value;
                ExceptionString = value != null ? value.ToString() : null;
            }
        }

        [DataMember]
        public string ExceptionString
        {
            get;
            set;
        }

        [DataMember]
        public string Message
        {
            get;
            set;
        }

        [DataMember]
        public string MessageID
        {
            get;
            set;
        }

        [DataMember]
        public object[] MessageParameters
        {
            get;
            set;
        }

        [DataMember]
        public string PropertyName
        {
            get;
            set;
        }

        [DataMember]
        public ServiceResultType ResultType
        {
            get;
            private set;
        }

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
            string toString = "";

            switch (ResultType)
            {
                case ServiceResultType.Ok:
                    toString = "OK";
                    break;

                case ServiceResultType.Warning:
                    toString = "Warning: " + GetMessage();
                    break;

                case ServiceResultType.Error:
                    toString = "Error: " + GetMessage();
                    break;

                case ServiceResultType.Question:
                    toString = "Question: " + GetMessage() + "\n Possible Answers:";
                    break;
            }
            return toString;
        }
    }
}