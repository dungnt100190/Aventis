namespace Kiss4Web.Infrastructure.CircuitBreakers.Diagnose
{
    public class DiagnoseResult
    {
        public string Details { get; set; }
        public string Error { get; set; }
        public bool IsOk { get; set; }
        public string Name { get; set; }
    }
}