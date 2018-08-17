using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Kiss.BL.KissSystem;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;

using IoC = Kiss.Infrastructure.IoC;

using Kiss.Interfaces;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.ViewModel;
using Kiss.Model.DTO.KissSystem;

namespace Kiss.UI.ViewModel
{
    public class ViewModelBase : DependencyObject, INotifyPropertyChanged, IMessageRaiser, IViewModel
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly Dictionary<string, QuestionAnswerOption> _questionCache = new Dictionary<string, QuestionAnswerOption>();

        #endregion

        #region Private Fields

        private bool _isBusy;
        private MaskenRechtDTO _maskenRecht;
        private string _maskName;
        private NotifyPropertyChanged _notifyPropertyChanged;
        private KissServiceResult _validationResult = KissServiceResult.Ok();

        #endregion

        #endregion

        #region Events

        public event EventHandler<MessageRaisedEventArgs> MessageRaised;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Indicates if the current viewModel is being utilized in the VS.NET IDE or not.
        /// </summary>
        public static bool DesignMode
        {
            get { return DesignerProperties.GetIsInDesignMode(new DependencyObject()); }
        }

        public ICollection<CommandBinding> CommandBindings { get { return null; } } // dummy implementation

        public bool HasErrors
        {
            get { return ValidationResult != null && ValidationResult.IsError; }
        }

        public virtual bool HasMaskRight
        {
            get
            {
                if (Maskenrecht == null)
                {
                    return false;
                }
                return Maskenrecht.CanUpdate;
            }
        }

        /// <summary>
        /// Indicates whether a long running process is currently running.
        /// </summary>
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (_isBusy == value)
                {
                    return;
                }

                _isBusy = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => IsBusy);
            }
        }

        /// <summary>
        /// Rechte des angemeldeten Users auf dieser Maske
        /// </summary>
        public MaskenRechtDTO Maskenrecht
        {
            get { return _maskenRecht; }
            private set
            {
                if (value == _maskenRecht)
                {
                    return;
                }

                _maskenRecht = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => Maskenrecht);
                NotifyPropertyChanged.RaisePropertyChanged(() => HasMaskRight);
            }
        }

        /// <summary>
        /// Maskenname; wird verwendet, um die Maskenrechte zu bestimmen
        /// </summary>
        public string MaskName
        {
            get { return _maskName; }
            set
            {
                if (value == _maskName)
                {
                    return;
                }
                _maskName = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => Maskenrecht);

                var rechtService = IoC.Container.Resolve<BerechtigungsService>();
                Maskenrecht = rechtService.GetUserMaskenrecht(null, _maskName);
            }
        }

        public KissServiceResult ValidationResult
        {
            get { return _validationResult; }
            set
            {
                _validationResult = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => ValidationResult);
                NotifyPropertyChanged.RaisePropertyChanged(() => HasErrors);
            }
        }

        protected NotifyPropertyChanged NotifyPropertyChanged
        {
            get { return _notifyPropertyChanged ?? (_notifyPropertyChanged = new NotifyPropertyChanged(this, () => PropertyChanged)); }
        }

        #endregion

        #region Methods

        #region Public Methods

        public virtual string GetContextName()
        {
            return GetType().Name;
        }

        public virtual object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "USERID":
                    {
                        // get current user
                        var session = IoC.Container.Resolve<ISessionService>();
                        return session.AuthenticatedUser.UserID;
                    }

                case "LANGUAGECODE":
                    {
                        // get current selected langugage
                        var session = IoC.Container.Resolve<ISessionService>();
                        var userService = IoC.Container.Resolve<XUserService>();
                        var user = userService.GetById(null, session.AuthenticatedUser.UserID);
                        return user.LanguageCode;
                    }

                default:
                    return DBNull.Value;
            }
        }

        public virtual Task Init(InitParameters? initParameters = null)
        {
            // default: nop
            return null; // ToDo: Task.Delay(0);, solange diese Klasse noch benötigt wird
        }

        public virtual bool JumpToPath(HybridDictionary parameters)
        {
            return true;
        }

        public virtual void PrintReport()
        {
            throw new NotImplementedException();
        }

        public void RaiseMessage(string title, KissServiceResult result)
        {
            var args = new MessageRaisedEventArgs(title, result);
            OnMessageRaised(args);
        }

        #endregion

        #region Protected Methods

        protected void ClearQuestionCache(Dictionary<string, QuestionAnswerOption> questionsAndAnswers)
        {
            ClearQuestionCache();
            questionsAndAnswers.Clear();
        }

        protected void ClearQuestionCache()
        {
            _questionCache.Clear();
        }

        /// <summary>
        /// Fires the MessageRaised event. Depending on the specified MessageRaisedEventArgs, this can be an Info-Message,
        /// or a Question letting the user to provide a selection among the specified Answer options.
        /// </summary>
        /// <param name="eventArgs"></param>
        protected void OnMessageRaised(MessageRaisedEventArgs eventArgs)
        {
            if (MessageRaised != null)
            {
                MessageRaised(this, eventArgs);
            }
        }

        /// <summary>
        /// Convenience-Method to send a message to the user.
        /// </summary>
        /// <param name="message">The message to be sent.</param>
        protected void RaiseMessage(string message)
        {
            var args = new MessageRaisedEventArgs(message);
            OnMessageRaised(args);
        }

        /// <summary>
        /// Convenience-Method to ask a question to the user. This overload allows to specify whether the user should be asked
        /// a second time about the same question (e.g. if the question is asked in a loop). If nothing is specified, the user is
        /// asked every time the question is raised.
        /// </summary>
        /// <param name="question">The question to ask.</param>
        /// <param name="availableOptions">The list of possible answers.</param>
        /// <param name="askSameQuestionOnlyOnce">Flag specifying whether the user should be asked a second time about the same question.</param>
        /// <returns>The answer from the user.</returns>
        protected QuestionAnswerOption RaiseQuestion(string question, List<QuestionAnswerOption> availableOptions, bool askSameQuestionOnlyOnce)
        {
            if (askSameQuestionOnlyOnce && _questionCache.ContainsKey(question))
            {
                return _questionCache[question];
            }

            var args = new QuestionRaisedEventArgs(question, availableOptions);
            OnMessageRaised(args);
            var selectedOption = args.SelectedOption;
            if (askSameQuestionOnlyOnce && !args.Cancel)
            {
                _questionCache.Add(question, selectedOption);
            }

            if (!args.Cancel)
            {
                return selectedOption;
            }

            return null;
        }

        /// <summary>
        /// Sets the property and raises the <see cref="PropertyChanged"/> event if it has changed.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storage">The field containing the old value.</param>
        /// <param name="value">The new value.</param>
        /// <param name="property">() => PROPERTY</param>
        /// <returns>True, if the property has changed, otherwise false.</returns>
        protected bool SetProperty<T>(ref T storage, T value, Expression<Func<T>> property)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            NotifyPropertyChanged.RaisePropertyChanged(property);
            return true;
        }

        #endregion

        #endregion
    }
}