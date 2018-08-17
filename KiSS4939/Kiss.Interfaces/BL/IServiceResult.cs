using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Kiss.Interfaces.BL
{
    public interface IServiceResult<out TResult> : INotifyPropertyChanged, IServiceResult
        where TResult : class
    {
        TResult Result { get; }
    }
}

namespace Kiss.Interfaces.BL
{
    public interface IServiceResult
    {
        bool IsError { get; }

        bool IsErrorOrWarning { get; }

        bool IsOk { get; }

        bool IsOkOrWarning { get; }

        /// <summary>
        /// Returns true if the maximum severity of all ResultInfos is Warning, but at least warning.
        /// Note: If there is an error or a warning, this property returns false as you need to test for errors explicitly or use the combined property IsErrorOrWarning
        /// </summary>
        bool IsQuestion { get; }

        /// <summary>
        /// Returns true if the maximum severity of all ResultInfos is Warning, but at least warning.
        /// Note: If there is an error, this property returns false as you need to test for errors explicitly or use the combined property IsErrorOrWarning
        /// </summary>
        bool IsWarning { get; }

        [DataMember]
        ObservableCollection<IServiceResultEntry> ServiceResultEntries { get; }

        void Add(IServiceResult result);

        bool ContainsError(string messageID);

        bool ContainsWarning(string messageID);

        string GetMessageError(string messageID);

        string GetMessageWarning(string messageID);

        IList<IServiceResultEntry> GetQuestions();

        string GetTechnicalDetails();

        string GetWarningsAndErrors();

        void RemoveWarning(string messageId);
    }

    public static class IServiceResultExtensionMethods
    {
        public static bool IsOk(this IServiceResult result)
        {
            return result != null && result.IsOk;
        }
    }
}