using System.Collections;

namespace Kiss.Interfaces.UI
{
    public interface IKiss4MessageHandler
    {
        object GetMessage(string className, IDictionary parameters);

        bool SendMessage(string className, IDictionary parameters, bool openView);
    }
}