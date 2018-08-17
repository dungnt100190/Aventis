using System.Windows;

using Kiss.Infrastructure;

namespace Kiss.UI.Controls
{
    internal class DateScalePeriod : Bindable
    {
        public ScaleLevel Level { get; set; }

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

        private double _positionTop;
        public double PositionTop
        {
            get { return _positionTop; }
            set { SetProperty(ref _positionTop, value, () => PositionTop); }
        }

        private TimePeriod _period;
        public TimePeriod Period
        {
            get { return _period; }
            set { SetProperty(ref _period, value, () => Period); }
        }

        private string _caption;
        public string Caption
        {
            get { return _caption; }
            set { SetProperty(ref _caption, value, () => Caption); }
        }

        private bool _isVisible;
        public bool IsVisible
        {
            get { return _isVisible; }
            set { SetProperty(ref _isVisible, value, () => IsVisible); }
        }

        private Thickness _padding;
        public Thickness Padding
        {
            get { return _padding; }
            set { SetProperty(ref _padding, value, () => Padding); }
        }
    }

    public enum ScaleLevel
    {
        Year = 1,
        Month = 2,
        Day = 3
    }
}
