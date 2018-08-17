namespace Kiss.Interfaces.ViewModel
{
    public interface IOpenFileService
    {
        string OpenFileDialog(string filter = null);
    }
}