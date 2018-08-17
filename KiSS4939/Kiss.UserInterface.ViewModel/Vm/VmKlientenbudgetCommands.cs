using System.Windows.Input;



namespace Kiss.UserInterface.ViewModel.Vm
{
    public static class VmKlientenbudgetCommands
    {
        static VmKlientenbudgetCommands()
        {
            ImportToPosition = new RoutedUICommand();

            InsertPosition = new RoutedUICommand();
            DeletePosition = new RoutedUICommand();

            MovePositionUpCommand = new RoutedUICommand();
            MovePositionDownCommand = new RoutedUICommand();
        }

        public static RoutedUICommand ImportToPosition { get; private set; }

        public static RoutedUICommand InsertPosition { get; private set; }
        public static RoutedUICommand DeletePosition { get; private set; }

        public static RoutedUICommand MovePositionUpCommand { get; private set; }
        public static RoutedUICommand MovePositionDownCommand { get; private set; }
    }}