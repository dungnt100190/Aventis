using System.Windows.Input;

namespace Kiss.UserInterface.ViewModel.Commanding
{
    // Summary:
    //     Provides a standard set of commands used in KiSS.
    public static class KissCommands
    {
        static KissCommands()
        {
            Search = new RoutedUICommand();
            CancelSearch = new RoutedUICommand();

            GoToFirstItem = new RoutedUICommand();
            GoToPreviousItem = new RoutedUICommand();
            GoToNextItem = new RoutedUICommand();
            GoToLastItem = new RoutedUICommand();

            CreateNewItem = new RoutedUICommand();
            SaveItem = new RoutedUICommand();
            DeleteItem = new RoutedUICommand();
            UndoChangesOnItem = new RoutedUICommand();

            Refresh = new RoutedUICommand();

            JumpToPath = new RoutedUICommand();
        }

        /// <summary>
        /// Toggle search (as known since KiSS3)
        /// Toggles between
        /// - open the search panel
        /// - search
        /// </summary>
        public static RoutedUICommand Search { get; private set; }
        public static RoutedUICommand CancelSearch { get; private set; }

        public static RoutedUICommand GoToFirstItem { get; private set; }
        public static RoutedUICommand GoToPreviousItem { get; private set; }
        public static RoutedUICommand GoToNextItem { get; private set; }
        public static RoutedUICommand GoToLastItem { get; private set; }

        public static RoutedUICommand CreateNewItem { get; private set; }
        public static RoutedUICommand SaveItem { get; private set; }
        public static RoutedUICommand DeleteItem { get; private set; }
        public static RoutedUICommand UndoChangesOnItem { get; private set; }

        public static RoutedUICommand Refresh { get; private set; }
        
        public static RoutedUICommand JumpToPath { get; private set; }
    }
}