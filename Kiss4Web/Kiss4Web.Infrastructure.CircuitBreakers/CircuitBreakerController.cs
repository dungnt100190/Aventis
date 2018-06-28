namespace Kiss4Web.Infrastructure.CircuitBreakers
{
    //[Route("api/[Controller]")]
    //public class CircuitBreakerController : Controller
    //{
    //    private readonly CircuitBreakerMonitor _monitor;

    //    public CircuitBreakerController(CircuitBreakerMonitor monitor)
    //    {
    //        _monitor = monitor;
    //    }

    //    [HttpGet]
    //    [Route("{id}/Diagnose")]
    //    public Task<IEnumerable<DiagnoseResult>> Diagnose(string id)
    //    {
    //        return _monitor.Diagnose(id);
    //    }

    //    [HttpGet]
    //    public IEnumerable<CircuitBreakerStateDTO> Get()
    //    {
    //        return _monitor.GetState();
    //    }
    //}
}