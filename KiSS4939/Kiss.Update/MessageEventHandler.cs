using System;
using System.Windows;

namespace Kiss.Update
{
    #region Delegates

    public delegate void MessageEventHandler(object sender, MessageEventArgs e);

    #endregion

    public class MessageEventArgs : EventArgs
    {
        #region Constructors

        public MessageEventArgs(string message, string title, MessageBoxButton buttons)
        {
            Message = message;
            Title = title;
            Buttons = buttons;
            Result = MessageBoxResult.None;
        }

        #endregion

        #region Properties

        public MessageBoxButton Buttons
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public MessageBoxResult Result
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        #endregion
    }
}