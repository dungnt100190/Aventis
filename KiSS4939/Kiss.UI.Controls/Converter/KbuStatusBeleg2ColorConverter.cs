using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

using Kiss.Infrastructure.Enumeration;
using Kiss.Interfaces.BL;

namespace Kiss.UI.Controls.Converter
{

    [ValueConversion(typeof(WshAuszahlvorschlagStatusWrapper), typeof(Brush))]
    public class KbuStatusBeleg2ColorConverter : IValueConverter
    {
        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            WshAuszahlvorschlagStatusWrapper status = value as WshAuszahlvorschlagStatusWrapper;

            if(status != null){
                if (status.EnumValue == WshAuszahlvorschlagStatus.Freigegeben)
                {
                    return Brushes.LightGreen;
                }
                if(status.EnumValue == WshAuszahlvorschlagStatus.Verbucht)
                {
                    return Brushes.Yellow;
                }                
            }           
            return Brushes.LightGray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();        
        }

        #endregion

        #endregion
    }
}