using Kiss.Interfaces.UI;
using Kiss.UserInterface.ViewModel.Commanding;

using KeyEventArgs = System.Windows.Forms.KeyEventArgs;

namespace Kiss.Integration
{
    public class WpfDataNavigator : IKissDataNavigator
    {
        public bool AddData()
        {
            KissCommands.CreateNewItem.Execute(null, null);
            return true;
        }

        public bool DeleteData()
        {
            KissCommands.DeleteItem.Execute(null, null);
            return true;
        }

        public bool KeyDownKiss(KeyEventArgs keyEvent)
        {
            return true;
        }

        public void MoveFirst()
        {
            KissCommands.GoToFirstItem.Execute(null, null);
        }

        public void MoveLast()
        {
            KissCommands.GoToLastItem.Execute(null, null);
        }

        public void MoveNext()
        {
            KissCommands.GoToNextItem.Execute(null, null);
        }

        public void MovePrevious()
        {
            KissCommands.GoToPreviousItem.Execute(null, null);
        }

        public void RefreshData()
        {
            KissCommands.Refresh.Execute(null, null);
        }

        public bool RestoreData()
        {
            KissCommands.UndoChangesOnItem.Execute(null, null);
            return true;
        }

        public bool SaveData()
        {
            KissCommands.SaveItem.Execute(null, null);
            return true;
        }

        public void Search()
        {
            KissCommands.Search.Execute(null, null);
        }

        public void UndoDataChanges()
        {
            KissCommands.UndoChangesOnItem.Execute(null, null);
        }
    }
}