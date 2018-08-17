using System.Collections.Generic;

using Kiss.Interfaces.ViewModel;

namespace Kiss.Interfaces
{
    public class QuestionRaisedEventArgs : MessageRaisedEventArgs
    {
        public List<QuestionAnswerOption> AvailableOptions { get; private set; }
        public QuestionAnswerOption SelectedOption { get; set; }

        public QuestionRaisedEventArgs(string question, List<QuestionAnswerOption> availableOptions)
            : base(question)
        {
            AvailableOptions = new List<QuestionAnswerOption>(availableOptions);
        }

    }
}