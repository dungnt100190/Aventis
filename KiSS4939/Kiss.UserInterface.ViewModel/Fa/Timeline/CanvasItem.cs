
using System.Windows;
using Kiss.Infrastructure;

namespace Kiss.UserInterface.ViewModel.Fa.Timeline
{
    public class CanvasItem<T> : Bindable, ICanvasItem
    {
        private double _positionLeft;
        public double PositionLeft
        {
            get { return _positionLeft; }
            set { SetProperty(ref _positionLeft, value, () => PositionLeft); }
        }

        private double _width;
        public double Width
        {
            get { return _width; }
            set { SetProperty(ref _width, value, () => Width); }
        }

        private double _height;
        public double Height
        {
            get { return _height; }
            set { SetProperty(ref _height, value, () => Height); }
        }

        private double _positionTop;
        public double PositionTop
        {
            get { return _positionTop; }
            set { SetProperty(ref _positionTop, value, () => PositionTop); }
        }

        private Thickness _padding;
        public Thickness Padding
        {
            get { return _padding; }
            set { SetProperty(ref _padding, value, () => Padding); }
        }

        public T DataItem { get; set; }
    }
}
