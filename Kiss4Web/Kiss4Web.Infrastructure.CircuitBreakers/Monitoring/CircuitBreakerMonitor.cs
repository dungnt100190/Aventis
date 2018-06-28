using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.CircuitBreakers.Diagnose;

namespace Kiss4Web.Infrastructure.CircuitBreakers.Monitoring
{
    public class CircuitBreakerMonitor
    {
        private readonly IEnumerable<CircuitBreaker> _circuitBreakers;
        private readonly CircuitBreakerPublisher _publisher;

        public CircuitBreakerMonitor(IEnumerable<CircuitBreaker> circuitBreakers, CircuitBreakerPublisher publisher)
        {
            _circuitBreakers = circuitBreakers;
            _circuitBreakers.DoForEach(cbr => cbr.StateChanged += CbrOnStateChanged);
            _publisher = publisher;
        }

        public async Task<IEnumerable<DiagnoseResult>> Diagnose(string id)
        {
            var circuitBreaker = _circuitBreakers.FirstOrDefault(cbr => cbr.Id == id);
            if (circuitBreaker == null)
            {
                return null;
            }
            return await Task.WhenAll(circuitBreaker.Diagnoses.Select(dgn => dgn.Diagnose()));
        }

        public IEnumerable<CircuitBreakerStateDTO> GetState()
        {
            return _circuitBreakers.Select(cbr => new CircuitBreakerStateDTO
            {
                ID = cbr.Id,
                Name = cbr.Name,
                State = cbr.State,
                LastSuccess = cbr.LastSuccessUtc, //ToDo: .ToLocalTime(),
                LastException = cbr.State == CircuitBreakerState.Closed ? null : cbr.LastExceptionUserText,
                LastOpen = cbr.LastOpenUtc // ToDo: .ToLocalTime()
            });
        }

        private void CbrOnStateChanged(object sender, EventArgs eventArgs)
        {
            var breaker = sender as CircuitBreaker;
            if (breaker != null)
            {
                _publisher.StateChanged(breaker.GetType().FullName);
            }
        }
    }
}