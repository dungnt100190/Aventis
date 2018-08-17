using Kiss.Interfaces.UI;

namespace KiSS4.DB
{
    public interface IKissUserControl : IKissDataNavigator, IKissContext, IKissActiveSQLQuery, IViewMessaging, IKissView
    {
    }
}