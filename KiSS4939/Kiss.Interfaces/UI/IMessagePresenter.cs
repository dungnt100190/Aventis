using System;

namespace Kiss.Interfaces.UI
{
    public interface IMessagePresenter
    {
        void ClearMessage();

        int ShowButtonDialog(string message, string[] buttonTextList, int focusedButtonIndex);

        void ShowError(string userText, string technicalText, Exception ex, int height, int width);

        void ShowInfo(string info, int width, int height);

        bool ShowQuestion(string question, int width, int height, bool defaultYes);
    }
}