using System.ComponentModel;

namespace Kiss.UserInterface.ViewModel.Fa.Timeline
{
    public interface ICanvasItem : INotifyPropertyChanged
    {
        double PositionLeft { get; set; }

        double Width { get; set; }

        double Height { get; set; }

        double PositionTop { get; set; }
    }
}