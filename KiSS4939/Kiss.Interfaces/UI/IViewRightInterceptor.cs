using System.Threading.Tasks;

namespace Kiss.Interfaces.UI
{
    public interface IViewRightInterceptor
    {
        Task<IViewRight> GetViewRight();
    }
}