namespace Kiss.UserInterface.ViewModel.Interfaces
{
    /// <summary>
    /// Base view for all KiSS WPF views
    /// </summary>
    public interface IViewWithViewModel
    {
        IViewModel ViewModel { get; set; }
    }
}