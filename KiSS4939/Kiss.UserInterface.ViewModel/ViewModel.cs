using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

using Kiss.BusinessLogic;
using Kiss.BusinessLogic.Sys;
using Kiss.DbContext.DTO.KissSystem;
using Kiss.Infrastructure;
using Kiss.Interfaces;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.UI;
using Kiss.Interfaces.ViewModel;
using Kiss.UserInterface.ViewModel.Async;

using Container = Kiss.Infrastructure.IoC.Container;
using IViewModel = Kiss.UserInterface.ViewModel.Interfaces.IViewModel;

namespace Kiss.UserInterface.ViewModel
{
    public class ViewModel : Bindable, IMessageRaiser, IViewModel
    {
        protected InitParameters? _initParameters;
        private readonly Dictionary<string, QuestionAnswerOption> _questionCache = new Dictionary<string, QuestionAnswerOption>();

        private readonly Collection<IViewRightInterceptor> _viewRightInterceptors;

        private bool _isCompletelyBusy;

        private MaskenRechtDTO _maskenRecht = MaskenRechtDTO.Default;

        private EventHandler<MessageRaisedEventArgs> _messageRaised;

        // ToDo: schöner wäre readonly
        private IServiceResult _validationResult = ServiceResult.Ok();

        public ViewModel()
        {
            CompletelyBusyTasks = new TaskObserver();
            CompletelyBusyTasks.PropertyChanged += (sender, args) => { IsCompletelyBusy = CompletelyBusyTasks.Waiting; };

            _viewRightInterceptors = new Collection<IViewRightInterceptor>();

            if (!DesignMode)
            {
                UpdateMaskenRecht();
            }
        }

        public event EventHandler<MessageRaisedEventArgs> MessageRaised
        {
            add
            {
                if (_messageRaised == null)
                {
                    _messageRaised += value;
                }
            }
            remove
            {
                _messageRaised -= value;
            }
        }

        /// <summary>
        /// Indicates if the current viewModel is being utilized in the VS.NET IDE or not.
        /// </summary>
        public static bool DesignMode
        {
            get { return DesignerProperties.GetIsInDesignMode(new DependencyObject()); }
        }

        public TaskObserver CompletelyBusyTasks { get; private set; }

        public bool HasErrors
        {
            get { return ValidationResult.IsError; }
        }

        public virtual bool HasMaskRight
        {
            get { return Maskenrecht.CanUpdate; }
        }

        // ToDo: remove after rename (to IsCompletelyBusy) in interface
        public bool IsBusy
        {
            get { return IsCompletelyBusy; }
            set { IsCompletelyBusy = value; } // ToDo: remove setter, use CompletelyBusyTasks
        }

        /// <summary>
        /// Indicates whether a long running process is currently running.
        /// </summary>
        public bool IsCompletelyBusy
        {
            get
            {
                return _isCompletelyBusy;
            }
            private set
            {
                if (_isCompletelyBusy == value)
                {
                    return;
                }

                _isCompletelyBusy = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => IsCompletelyBusy);
                NotifyPropertyChanged.RaisePropertyChanged(() => IsBusy); // ToDo: remove after rename in interface
            }
        }

        /// <summary>
        /// Rechte des angemeldeten Users auf dieser Maske
        /// </summary>
        public MaskenRechtDTO Maskenrecht
        {
            get
            {
                return _maskenRecht;
            }
            private set
            {
                if (value == _maskenRecht)
                {
                    return;
                }

                _maskenRecht = value ?? MaskenRechtDTO.Default;
                NotifyPropertyChanged.RaisePropertyChanged(() => Maskenrecht);
                NotifyPropertyChanged.RaisePropertyChanged(() => HasMaskRight);
            }
        }

        /// <summary>
        /// Setzt die erforderlichen Werte in InitAsync() fest. (Flags)
        /// </summary>
        public InitParameterValue RequiredParameters { get; set; }

        public IServiceResult ValidationResult
        {
            get
            {
                return _validationResult;
            }
            set
            {
                _validationResult = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => ValidationResult);
            }
        }

        /// <summary>
        /// Executes Tasks before the view can be closed.
        /// The base implementation does nothing and returns true.
        /// </summary>
        /// <returns><c>true</c> if the View can be closed</returns>
        public virtual bool BeforeCloseView()
        {
            return true;
        }

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
                        var session = Container.Resolve<ISessionService>();
                        return session.AuthenticatedUser.UserID;
                    }

                //case "LANGUAGECODE":
                //    {
                //        // get current selected langugage
                //        var session = Container.Resolve<Kiss.Interfaces.BL.ISessionService>();
                //        var userService = Container.Resolve<XUserService>();
                //        var user = userService.GetById(null, session.AuthenticatedUser.UserID);
                //        return user.LanguageCode;
                //    }

                default:
                    return DBNull.Value;
            }
        }

        public async Task Init(InitParameters? initParameters = null)
        {
            CheckInitParameters(initParameters);
            _initParameters = initParameters;
            var initTask = InitAsync(initParameters);
            CompletelyBusyTasks.AddObservation(initTask);
            var maskenRechtTask = UpdateMaskenRecht();
            CompletelyBusyTasks.AddObservation(maskenRechtTask);

            await initTask;
            await maskenRechtTask;

            InitCompleted();
        }

        public virtual bool JumpToPath(HybridDictionary parameters)
        {
            return false;
        }

        public virtual void PrintReport()
        {
            throw new NotImplementedException();
        }

        public void RaiseMessage(string title, IServiceResult result)
        {
            var args = new MessageRaisedEventArgs(title, result);
            OnMessageRaised(args);
        }

        /// <summary>
        /// Registriert ein Objekt, welches das Maskenrecht überschreiben kann.
        /// Der Output des Interceptors wird vor der Methode <see cref="OverrideMaskenrecht"/> evaluiert.
        /// </summary>
        /// <param name="interceptor"></param>
        protected void AddViewRightInterceptor(IViewRightInterceptor interceptor)
        {
            _viewRightInterceptors.Add(interceptor);
        }

        protected virtual void CheckInitParameters(InitParameters? initParameters)
        {
            if (RequiredParameters == 0)
            {
                return;
            }

            if (initParameters == null)
            {
                throw new ArgumentNullException("initParameters");
            }

            if (RequiredParameters.HasFlag(InitParameterValue.FaLeistungID) && initParameters.Value.FaLeistungID == null)
            {
                throw new ArgumentNullException("initParameters", "FaLeistungID");
            }

            if (RequiredParameters.HasFlag(InitParameterValue.BaPersonID) && initParameters.Value.BaPersonID == null)
            {
                throw new ArgumentNullException("initParameters", "BaPersonID");
            }

            if (RequiredParameters.HasFlag(InitParameterValue.FaFallID) && initParameters.Value.FaFallID == null)
            {
                throw new ArgumentNullException("initParameters", "FaFallID");
            }

            if (RequiredParameters.HasFlag(InitParameterValue.Title) && string.IsNullOrEmpty(initParameters.Value.Title))
            {
                throw new ArgumentNullException("initParameters", "Title");
            }
        }

        protected void ClearQuestionCache(Dictionary<string, QuestionAnswerOption> questionsAndAnswers)
        {
            ClearQuestionCache();
            questionsAndAnswers.Clear();
        }

        protected void ClearQuestionCache()
        {
            _questionCache.Clear();
        }

        protected virtual async Task InitAsync(InitParameters? initParameters = null)
        {
            // nop
        }

        /// <summary>
        /// Gets called at the end of <see cref="Init"/> (after <see cref="InitAsync"/> and <see cref="UpdateMaskenRecht"/>).
        /// </summary>
        protected virtual void InitCompleted()
        {
        }

        protected void Invoke(Action action)
        {
            Application.Current.Dispatcher.Invoke(action);
        }

        /// <summary>
        /// Fires the MessageRaised event. Depending on the specified MessageRaisedEventArgs, this can be an Info-Message,
        /// or a Question letting the user to provide a selection among the specified Answer options.
        /// </summary>
        /// <param name="eventArgs"></param>
        protected void OnMessageRaised(MessageRaisedEventArgs eventArgs)
        {
            var messageRaised = _messageRaised;
            if (messageRaised != null)
            {
                messageRaised.Invoke(this, eventArgs);
            }
        }

        protected virtual MaskenRechtDTO OverrideMaskenrecht(MaskenRechtDTO maskenRecht)
        {
            return maskenRecht;
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

        protected Task<T> RunAsCompletelyBusy<T>(Func<T> func)
        {
            var updateDefaultTask = Task.Run(func);
            CompletelyBusyTasks.AddObservation(updateDefaultTask);
            return updateDefaultTask;
        }

        /// <summary>
        /// Lädt das Maskenrecht erneut aus der DB.
        /// Dabei wird die Methode <see cref="OverrideMaskenrecht"/> erneut evaluiert.
        /// </summary>
        protected async Task UpdateMaskenRecht()
        {
            var rechtService = Container.Resolve<SysBerechtigungsService>();
            var maskenRecht = rechtService.GetUserMaskenrechtByViewModel(GetType());

            foreach (var viewRightInterceptor in _viewRightInterceptors)
            {
                var viewRight = await viewRightInterceptor.GetViewRight();
                maskenRecht.CanDelete &= viewRight.CanDelete;
                maskenRecht.CanInsert &= viewRight.CanInsert;
                maskenRecht.CanUpdate &= viewRight.CanUpdate;
            }

            Maskenrecht = OverrideMaskenrecht(maskenRecht);
        }
    }
}