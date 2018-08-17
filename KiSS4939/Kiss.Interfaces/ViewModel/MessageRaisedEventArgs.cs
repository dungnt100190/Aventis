using System.ComponentModel;
using System.Linq;
using System.Text;
using Kiss.Interfaces.BL;

namespace Kiss.Interfaces.ViewModel
{
    public class MessageRaisedEventArgs : CancelEventArgs
    {
        public MessageRaisedEventArgs(string message)
        {
            Message = message;
        }

        public MessageRaisedEventArgs(string title, IServiceResult result)
        {
            Message = ConvertToString(title, result);
        }

        public string Message { get; private set; }

        public static string ConvertToString(string title, IServiceResult result)
        {
            var errorText = new StringBuilder(title);
            if (result != null)
            {
                errorText.AppendLine();

                var messages = result.ServiceResultEntries.Where(x => x.ResultType != ServiceResultType.Ok).Select(x => x.Message).ToList();

                if (messages.Count == 1)
                {
                    errorText.AppendLine(messages[0]);
                }
                else
                {
                    foreach (var message in messages)
                    {
                        errorText.AppendFormat("- {0}", message);
                        errorText.AppendLine("");
                    }
                }
            }
            errorText.AppendLine("");
            return errorText.ToString();
        }
    }
}