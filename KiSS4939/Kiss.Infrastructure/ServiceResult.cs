using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

using FluentValidation.Results;

using Kiss.Interfaces;
using Kiss.Interfaces.BL;

namespace Kiss.Infrastructure
{
    [DataContract]
    public class ServiceResult<TResult> : ServiceResult, IServiceResult<TResult>
        where TResult : class
    {
        public ServiceResult(TResult result)
            : base(ServiceResultType.Ok)
        {
            Result = result;
        }

        public ServiceResult(ServiceResultType resultType, TResult result)
            : base(resultType)
        {
            Result = result;
        }

        public ServiceResult(string questionID, string question, List<QuestionAnswerOption> availableAnswerOptions)
            : base(questionID, question, availableAnswerOptions)
        {
        }

        public ServiceResult(ServiceResultType resultType, string defaultMessage = null, string messageID = null, string propertyName = null, params object[] args)
            : base(resultType, defaultMessage, messageID, propertyName, args)
        {
        }

        public ServiceResult(Exception ex, string messageID = null, string defaultMessage = null, params object[] args)
            : base(ex, messageID, defaultMessage, args)
        {
        }

        public ServiceResult(IServiceResult<TResult> other)
            : base(other)
        {
            Result = other.Result;
        }

        public ServiceResult(IServiceResult other)
            : base(other)
        {
        }

        [DataMember]
        public TResult Result { get; set; }

        public new static ServiceResult<TResult> Error(Exception ex)
        {
            return new ServiceResult<TResult>(ex);
        }

        public new static ServiceResult<TResult> ErrorWithId(string messageId, string defaultMessage, params object[] parameters)
        {
            return new ServiceResult<TResult>(ServiceResultType.Error, defaultMessage, messageId, null, parameters);
        }

        public new static ServiceResult<TResult> Ok()
        {
            return new ServiceResult<TResult>(ServiceResultType.Ok);
        }

        public new static ServiceResult<TResult> Warning(string defaultMessage, params object[] parameters)
        {
            return new ServiceResult<TResult>(ServiceResultType.Warning, defaultMessage, null, null, parameters);
        }

        public new static ServiceResult<TResult> WarningWithId(string messageId, string defaultMessage, params object[] parameters)
        {
            return new ServiceResult<TResult>(ServiceResultType.Warning, defaultMessage, messageId, null, parameters);
        }
    }

    [DataContract]
    [KnownType(typeof(ServiceResultEntry))]
    public class ServiceResult : IServiceResult
    {
        private ObservableCollection<IServiceResultEntry> _resultInfos = new ObservableCollection<IServiceResultEntry>();

        public ServiceResult(string questionID, string question, List<QuestionAnswerOption> availableAnswerOptions)
        {
            var info = new ServiceResultEntry(ServiceResultType.Question)
            {
                MessageID = questionID,
                Message = question,
                AvailableAnswerOptions = availableAnswerOptions,
            };

            ServiceResultEntries.Add(info);
        }

        public ServiceResult(ServiceResultType resultType, string defaultMessage = null, string messageID = null, string propertyName = null, params object[] args)
        {
            AddEntry(resultType, defaultMessage, messageID, propertyName, args);
        }

        public ServiceResult(IServiceResult other)
        {
            Add(other);
        }

        public ServiceResult(Exception ex, string messageID = null, string defaultMessage = null, params object[] args)
        {
            var info = new ServiceResultEntry(ServiceResultType.Error)
            {
                Exception = ex,
                MessageID = messageID,
                Message = defaultMessage ?? ex.Message,
                MessageParameters = args
            };

            ServiceResultEntries.Add(info);
        }

        ///// <summary>
        ///// Initializes a <see cref="KissServiceResult"/> object
        ///// </summary>
        ///// <param name="validationResult"><see cref="ValidationResult"/></param>
        //public ServiceResult(ValidationResult validationResult)
        //{
        //    Set(validationResult);
        //}

        protected ServiceResult()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
        public ObservableCollection<IServiceResultEntry> ServiceResultEntries
        {
            get { return _resultInfos; }
            private set
            {
                _resultInfos = value; //is needed for deserialization. Do NOT delete
            }
        }

        public static ServiceResult Error(string defaultMessage, params object[] parameters)
        {
            return new ServiceResult(ServiceResultType.Error, defaultMessage, null, null, parameters);
        }

        public static ServiceResult Error(Exception ex)
        {
            return new ServiceResult(ex);
        }

        public static ServiceResult ErrorWithId(string messageId, string defaultMessage, params object[] parameters)
        {
            return new ServiceResult(ServiceResultType.Error, defaultMessage, messageId, null, parameters);
        }

        public static implicit operator bool(ServiceResult result)
        {
            return result != null && result.IsOk;
        }

        public static implicit operator string(ServiceResult result)
        {
            return result.ToString();
        }

        public static ServiceResult Ok()
        {
            return new ServiceResult(ServiceResultType.Ok);
        }

        public static bool operator !(ServiceResult result)
        {
            return result == null || !result.IsOk;
        }

        public static ServiceResult operator +(ServiceResult first, IServiceResult second)
        {
            first.Add(second);
            return first;
        }

        public static bool operator false(ServiceResult result)
        {
            return result == null || !result.IsOk;
        }

        public static bool operator true(ServiceResult result)
        {
            return result != null && result.IsOk;
        }

        public static ServiceResult Warning(string warning, params object[] parameters)
        {
            return new ServiceResult(ServiceResultType.Warning, warning, null, null, parameters);
        }

        public static ServiceResult WarningWithId(string messageId, string defaultMessage, params object[] parameters)
        {
            return new ServiceResult(ServiceResultType.Warning, defaultMessage, messageId, null, parameters);
        }

        public void Add(Exception ex)
        {
            Add(new ServiceResult(ex));
        }

        public void Add(IServiceResult newEntries)
        {
            // Addiere nur die problematische Resultat-Infos der linke Seite dazu
            foreach (var info in newEntries.ServiceResultEntries.Where(i => i.ResultType != ServiceResultType.Ok))
            {
                _resultInfos.Add(info);
            }
        }

        public IServiceResult AddEntry(ServiceResultType resultType, string defaultMessage = null, string messageID = null, string propertyName = null, params object[] args)
        {
            var info = new ServiceResultEntry(resultType)
            {
                MessageID = messageID,
                Message = defaultMessage,
                PropertyName = propertyName,
                MessageParameters = args
            };

            ServiceResultEntries.Add(info);
            return this;
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
                        current +
                        string.Format(
                            "- {0}{4}  Message: {1}{4}  Property Name: {2}{4}  Exception: {3}{4}",
                            info.ResultType,
                            info.GetMessage(),
                            info.PropertyName,
                            info.Exception != null ? info.Exception.ToString() : info.ExceptionString,
                            Environment.NewLine) +
                        Environment.NewLine);
        }

        public string GetWarningsAndErrors()
        {
            return _resultInfos
                .Where(i => i.ResultType != ServiceResultType.Ok)
                .Aggregate(string.Empty, (current, info) => current + ComposeMessage(info) + Environment.NewLine);
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
                .Aggregate("", (current, info) => current + info.GetMessage() + Environment.NewLine);
        }

        private static string ComposeMessage(IServiceResultEntry info)
        {
            if (info.MessageParameters == null || info.MessageParameters.Length == 0)
            {
                return "- " + info.Message;
            }
            return "- " + string.Format(info.Message, info.MessageParameters);
        }

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
                e => new ServiceResultEntry(ServiceResultType.Error)
                {
                    Message = e.ErrorMessage,
                    PropertyName = e.PropertyName,
                }).ToList())
            {
                ServiceResultEntries.Add(item);
            }
        }
    }
}