using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.CircuitBreakers.Diagnose;
using Kiss4Web.Infrastructure.ErrorHandling;

namespace Kiss4Web.Infrastructure.CircuitBreakers
{
    public abstract class CircuitBreaker : ICircuitBreaker
    {
        private readonly IExceptionTranslator _exceptionTranslator;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly object _halfOpenSyncObject = new object();
        private CircuitBreakerState _state;

        protected CircuitBreaker(IExceptionTranslator exceptionTranslator, IDateTimeProvider dateTimeProvider)
        {
            _exceptionTranslator = exceptionTranslator;
            _dateTimeProvider = dateTimeProvider;
            State = CircuitBreakerState.Closed;
            OpenToHalfOpenWaitTime = new TimeSpan(0, 0, 0, 30);
            DiagnosesList = new List<IDiagnose>();
        }

        public event EventHandler StateChanged;

        public IEnumerable<IDiagnose> Diagnoses => DiagnosesList;
        public string Id => GetType().FullName;
        public Exception LastException { get; private set; }
        public string LastExceptionUserText { get; set; }
        public DateTime? LastOpenUtc { get; private set; }
        public DateTime? LastSuccessUtc { get; private set; }
        public virtual string Name => GetType().Name;
        public TimeSpan OpenToHalfOpenWaitTime { get; protected set; }
        public IEnumerable<Type> ProtectedCommandsAndQueries { get; protected set; }

        public CircuitBreakerState State
        {
            get { return _state; }
            private set
            {
                if (State == value)
                {
                    return;
                }
                _state = value;
                OnStateChanged();
            }
        }

        protected IList<IDiagnose> DiagnosesList { get; }
        private CircuitBreakerOpenException CircuitBreakerException { get; set; }

        public async Task Execute(Func<Task> action)
        {
            if (State != CircuitBreakerState.Closed)
            {
                if (LastOpenUtc + OpenToHalfOpenWaitTime > _dateTimeProvider.UtcNow)
                {
                    throw CircuitBreakerException;
                }
                var lockTaken = false;
                try
                {
                    Monitor.TryEnter(_halfOpenSyncObject, ref lockTaken);
                    if (lockTaken)
                    {
                        // Set the circuit breaker state to HalfOpen.
                        State = CircuitBreakerState.HalfOpen;

                        // Attempt the operation.
                        await action().ConfigureAwait(false);

                        // If this action succeeds, reset the state and allow other operations.
                        // In reality, instead of immediately returning to the Open state, a counter
                        // here would record the number of successful operations and return the
                        // circuit breaker to the Open state only after a specified number succeed.
                        State = CircuitBreakerState.Closed;

                        return;
                    }
                }
                catch (Exception ex)
                {
                    // If there is still an exception, trip the breaker again immediately.
                    ProcessException(ex);

                    // Throw the exception so that the caller knows which exception occurred.
                    throw;
                }
                finally
                {
                    if (lockTaken)
                    {
                        Monitor.Exit(_halfOpenSyncObject);
                    }
                }
            }

            // The circuit breaker is Closed, execute the action.
            try
            {
                await action().ConfigureAwait(false);
                LastSuccessUtc = _dateTimeProvider.UtcNow;
            }
            catch (Exception ex)
            {
                // If an exception still occurs here, simply
                // re-trip the breaker immediately.
                ProcessException(ex);

                // Throw the exception so that the caller can tell
                // the type of exception that was thrown.
                throw;
            }
        }

        public async Task<TResult> Execute<TResult>(Func<Task<TResult>> action)
        {
            if (State != CircuitBreakerState.Closed)
            {
                if (LastOpenUtc + OpenToHalfOpenWaitTime > _dateTimeProvider.UtcNow)
                {
                    throw CircuitBreakerException;
                }
                var lockTaken = false;
                try
                {
                    Monitor.TryEnter(_halfOpenSyncObject, ref lockTaken);
                    if (lockTaken)
                    {
                        // Set the circuit breaker state to HalfOpen.
                        State = CircuitBreakerState.HalfOpen;

                        // Attempt the operation.
                        var result = await action().ConfigureAwait(false);

                        // If this action succeeds, reset the state and allow other operations.
                        // In reality, instead of immediately returning to the Open state, a counter
                        // here would record the number of successful operations and return the
                        // circuit breaker to the Open state only after a specified number succeed.
                        State = CircuitBreakerState.Closed;

                        return result;
                    }
                }
                catch (Exception ex)
                {
                    // If there is still an exception, trip the breaker again immediately.
                    ProcessException(ex);

                    // Throw the exception so that the caller knows which exception occurred.
                    throw;
                }
                finally
                {
                    if (lockTaken)
                    {
                        Monitor.Exit(_halfOpenSyncObject);
                    }
                }
            }

            // The circuit breaker is Closed, execute the action.
            try
            {
                var result = await action().ConfigureAwait(false);
                LastSuccessUtc = _dateTimeProvider.UtcNow;
                return result;
            }
            catch (Exception ex)
            {
                // If an exception still occurs here, simply
                // re-trip the breaker immediately.
                ProcessException(ex);

                // Throw the exception so that the caller can tell
                // the type of exception that was thrown.
                throw;
            }
        }

        protected virtual string ComposeExceptionMessage()
        {
            return string.Format(Resources.CircuitBreakerExceptionUserText, Name, LastExceptionUserText);
        }

        protected abstract bool IsBreakingException(Exception exception);

        protected virtual void OnStateChanged()
        {
            StateChanged?.Invoke(this, EventArgs.Empty);
        }

        private void ProcessException(Exception ex)
        {
            do
            {
                if (IsBreakingException(ex))
                {
                    LastException = ex;
                    LastExceptionUserText = _exceptionTranslator.TranslateExceptionToUserText(ex).result as string ?? ex.Message;
                    LastOpenUtc = _dateTimeProvider.UtcNow;
                    State = CircuitBreakerState.Open;
                    CircuitBreakerException = new CircuitBreakerOpenException(ComposeExceptionMessage(), this, LastException, LastExceptionUserText);
                    throw CircuitBreakerException;
                }
                ex = ex.InnerException;
            }
            while (ex != null);
        }
    }
}