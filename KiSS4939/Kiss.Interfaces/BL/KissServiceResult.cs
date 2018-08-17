using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

using FluentValidation.Results;

namespace Kiss.Interfaces.BL
{
    [DataContract]
    public class KissServiceResult : IServiceResult
    {
        #region Fields

        #region Private Fields

        private ObservableCollection<IServiceResultEntry> _resultInfos = new ObservableCollection<IServiceResultEntry>();

        #endregion

        #endregion

        #region Constructors

        public KissServiceResult(ServiceResultType resultType)
        {
            KissServiceResultEntries.Add(new KissServiceResultEntry(resultType));
        }

        public KissServiceResult(ServiceResultType resultType, string defaultMessage)
        {
            var info = new KissServiceResultEntry(resultType) { Message = defaultMessage };
            KissServiceResultEntries.Add(info);
        }

        public KissServiceResult(string questionID, string question, List<QuestionAnswerOption> availableAnswerOptions)
        {
            var info = new KissServiceResultEntry(ServiceResultType.Question)
            {
                MessageID = questionID,
                Message = question,
                AvailableAnswerOptions = availableAnswerOptions,
            };

            KissServiceResultEntries.Add(info);
        }

        public KissServiceResult(ServiceResultType resultType, string messageID, string defaultMessage, string propertyName)
        {
            var info = new KissServiceResultEntry(resultType)
            {
                MessageID = messageID,
                Message = defaultMessage,
                PropertyName = propertyName
            };

            KissServiceResultEntries.Add(info);
        }

        public KissServiceResult(ServiceResultType resultType, string messageID, string defaultMessage, params object[] args)
        {
            var info = new KissServiceResultEntry(resultType)
            {
                MessageID = messageID,
                Message = defaultMessage,
                MessageParameters = args
            };

            KissServiceResultEntries.Add(info);
        }

        public KissServiceResult(Exception ex)
        {
            var info = new KissServiceResultEntry(ServiceResultType.Error)
            {
                Exception = ex,
                Message = ex.Message
            };

            KissServiceResultEntries.Add(info);
        }

        public KissServiceResult(Exception ex, string messageID, string defaultMessage, params object[] args)
        {
            var info = new KissServiceResultEntry(ServiceResultType.Error)
            {
                Exception = ex,
                MessageID = messageID,
                Message = defaultMessage,
                MessageParameters = args
            };

            KissServiceResultEntries.Add(info);
        }

        /// <summary>
        /// Initializes a <see cref="KissServiceResult"/> object
        /// </summary>
        /// <param name="validationResult"><see cref="ValidationResult"/></param>
        public KissServiceResult(ValidationResult validationResult)
        {
            Set(validationResult);
        }

        protected KissServiceResult()
        {
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        public bool IsError
        {
            get { return _resultInfos.Any(i => i.ResultType == ServiceResultType.Error); }
        }

        public bool IsErrorOrWarning
        {
            get { return IsError | IsWarning; }
        }

        public bool IsOk
        {
            get { return _resultInfos.All(i => i.ResultType == ServiceResultType.Ok); }
        }

        public bool IsOkOrWarning
        {
            get { return IsOk | IsWarning; }
        }

        /// <summary>
        /// Returns true if the maximum severity of all ResultInfos is Warning, but at least warning.
        /// Note: If there is an error or a warning, this property returns false as you need to test for errors explicitly or use the combined property IsErrorOrWarning
        /// </summary>
        public bool IsQuestion
        {
            get
            {
                if (_resultInfos.Any(i => i.ResultType == ServiceResultType.Error || i.ResultType == ServiceResultType.Warning))
                {
                    return false;
                }

                return _resultInfos.Any(i => i.ResultType == ServiceResultType.Question);
            }
        }

        /// <summary>
        /// Returns true if the maximum severity of all ResultInfos is Warning, but at least warning.
        /// Note: If there is an error, this property returns false as you need to test for errors explicitly or use the combined property IsErrorOrWarning
        /// </summary>
        public bool IsWarning
        {
            get
            {
                if (_resultInfos.Any(i => i.ResultType == ServiceResultType.Error))
                {
                    return false;
                }

                return _resultInfos.Any(i => i.ResultType == ServiceResultType.Warning);
            }
        }

        [DataMember]
        public ObservableCollection<IServiceResultEntry> KissServiceResultEntries
        {
            get { return _resultInfos; }
            private set
            {
                _resultInfos = value; //is needed for deserialization. Do NOT delete
            }
        }

        public object Result { get; set; }

        public ObservableCollection<IServiceResultEntry> ServiceResultEntries
        {
            get { return KissServiceResultEntries; }
        }

        #endregion

        #region Methods

        #region Public Static Methods

        public static KissServiceResult Error(string messageId, string defaultMessage, params object[] parameters)
        {
            return new KissServiceResult(ServiceResultType.Error, messageId, defaultMessage, parameters);
        }

        public static KissServiceResult Error(Exception ex)
        {
            return new KissServiceResult(ex);
        }

        public static implicit operator bool(KissServiceResult result)
        {
            return result != null && result.IsOk;
        }

        public static implicit operator string(KissServiceResult result)
        {
            return result.ToString();
        }

        public static KissServiceResult Ok()
        {
            return new KissServiceResult(ServiceResultType.Ok);
        }

        public static bool operator !(KissServiceResult result)
        {
            return result == null || !result.IsOk;
        }

        public static KissServiceResult operator +(KissServiceResult result, Exception ex)
        {
            return result + new KissServiceResult(ex);
        }

        public static KissServiceResult operator +(KissServiceResult right, KissServiceResult left)
        {
            right.Add(left);
            return right;
        }

        public static bool operator false(KissServiceResult result)
        {
            return result == null || !result.IsOk;
        }

        public static bool operator true(KissServiceResult result)
        {
            return result != null && result.IsOk;
        }

        public static KissServiceResult Warning(string messageId, string defaultMessage, params object[] parameters)
        {
            return new KissServiceResult(ServiceResultType.Warning, messageId, defaultMessage, parameters);
        }

        #endregion

        #region Public Methods

        public void Add(IServiceResult right)
        {
            // Addiere nur die problematische Resultat-Infos der linke Seite dazu
            foreach (KissServiceResultEntry info in right.ServiceResultEntries.Where(i => i.ResultType != ServiceResultType.Ok))
            {
                _resultInfos.Add(info);
            }
        }

        public bool ContainsError(string messageID)
        {
            return Contains(ServiceResultType.Error, messageID);
        }

        public bool ContainsWarning(string messageID)
        {
            return Contains(ServiceResultType.Warning, messageID);
        }

        public string GetMessageError(string messageID)
        {
            return GetMessage(ServiceResultType.Error, messageID);
        }

        public string GetMessageWarning(string messageID)
        {
            return GetMessage(ServiceResultType.Warning, messageID);
        }

        public IList<IServiceResultEntry> GetQuestions()
        {
            return _resultInfos
                .Where(i => i.ResultType == ServiceResultType.Question)
                .ToList();
        }

        public string GetTechnicalDetails()
        {
            return _resultInfos
                .Where(i => i.ResultType != ServiceResultType.Ok)
                .Aggregate(
                    "",
                    (current, info) =>
                    string.Format(
                        "- Type: {0}{4} Message: {1}{4} Property Name: {2}{4} Exception: {3}{4}",
                        info.ResultType,
                        info.Message,
                        info.PropertyName,
                        info.Exception,
                        Environment.NewLine));
        }

        public string GetWarningsAndErrors()
        {
            return _resultInfos
                .Where(i => i.ResultType != ServiceResultType.Ok)
                .Aggregate(string.Empty, (current, info) => current + GetMessage(info) + Environment.NewLine);
        }

        public void RemoveWarning(string messageId)
        {
            RemoveMessage(ServiceResultType.Warning, messageId);
        }

        public override string ToString()
        {
            // TODO: Need to display User message too

            return _resultInfos
                .Where(i => i.ResultType != ServiceResultType.Ok)
                .Aggregate("", (current, info) => current + info + Environment.NewLine);
        }

        #endregion

        #region Private Static Methods

        private static string GetMessage(IServiceResultEntry info)
        {
            if (info.MessageParameters == null || info.MessageParameters.Length == 0)
            {
                return "- " + info.Message;
            }
            return "- " + string.Format(info.Message, info.MessageParameters);
        }

        #endregion

        #region Private Methods

        private bool Contains(ServiceResultType resultType, string messageID)
        {
            return _resultInfos.Any(i => i.ResultType == resultType && i.MessageID == messageID);
        }

        private string GetMessage(ServiceResultType resultType, string messageID)
        {
            return string.Join(
                Environment.NewLine + "- ", _resultInfos.Where(i => i.ResultType == resultType && i.MessageID == messageID).Select(i => i.Message));
        }

        private void RemoveMessage(ServiceResultType resultType, string messageID)
        {
            var entryToRemove = _resultInfos.Where(x => x.MessageID == messageID && x.ResultType == resultType);

            foreach (var kissServiceResultEntry in entryToRemove)
            {
                _resultInfos.Remove(kissServiceResultEntry);
            }
        }

        /// <summary>
        /// Sets the <see cref="KissServiceResult"/> with a <see cref="ValidationResult"/> object
        /// </summary>
        /// <param name="validationResult">The <see cref="ValidationResult"/> to set</param>
        private void Set(ValidationResult validationResult)
        {
            foreach (var item in validationResult.Errors.Select(
                e => new KissServiceResultEntry(ServiceResultType.Error)
                {
                    Message = e.ErrorMessage,
                    PropertyName = e.PropertyName,
                }).ToList())
            {
                KissServiceResultEntries.Add(item);
            }
        }

        #endregion

        #endregion
    }
}