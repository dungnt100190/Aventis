using System.Threading.Tasks;

namespace Kiss4Web.Infrastructure.CircuitBreakers.Diagnose
{
    public interface IDiagnose
    {
        Task<DiagnoseResult> Diagnose();
    }
}