namespace Kiss4Web.Infrastructure.CircuitBreakers.Monitoring
{
    public class CircuitBreakerPublisher
    {
        //private readonly IHubContext<IMessageReceiver> _hubContext;

        public CircuitBreakerPublisher()
        {
            // ToDo
            //_hubContext = GlobalHost.ConnectionManager.GetHubContext<IMessageReceiver>(typeof(CircuitBreakerHub).Name);
        }

        public void StateChanged(string typeName)
        {
            //_hubContext.Clients.All.Notify(typeName);
        }
    }
}