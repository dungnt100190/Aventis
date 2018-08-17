using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Kiss.UI.Controls.Converter
{
    public class ColorPickConverter : IValueConverter
    {
        #region Constructors

        public ColorPickConverter()
        {
            LightBrush = new SolidColorBrush(Colors.White);
            DarkBrush = new SolidColorBrush(Colors.Black);
            Threshold = 0.5f;
        }

        #endregion

        #region Properties

        public Brush DarkBrush { get; set; }

        public Brush LightBrush { get; set; }

        public float Threshold { get; set; }

        #endregion

        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var brush = value as SolidColorBrush;

            if (brush != null)
            {
                var lightness = (Math.Max(Math.Max(brush.Color.R, brush.Color.G), brush.Color.B) / 255f) * (brush.Color.A / 255f);

                return lightness >= Threshold ? DarkBrush : LightBrush;
            }

            return LightBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}