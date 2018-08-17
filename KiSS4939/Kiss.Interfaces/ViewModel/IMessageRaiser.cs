using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kiss.Interfaces.ViewModel
{
    public interface IMessageRaiser
    {
        /// <summary>
        /// Raised if the ViewModel would like to send a message to the user.
        /// Depending on the specified MessageRaisedEventArgs, this can be an Info-Message,
        /// or a Question letting the user to provide a selection among the specified Answer options.
        /// This event is cancellable, in case the user pressed cancel in the resulting
        /// messagebox.
        /// </summary>
        event EventHandler<MessageRaisedEventArgs> MessageRaised;
    }
}
