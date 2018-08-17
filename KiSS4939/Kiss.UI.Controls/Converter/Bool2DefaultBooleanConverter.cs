using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

using DevExpress.Utils;

using Kiss.Interfaces.BL;

namespace Kiss.UI.Controls.Converter
{

    /// <summary>
    /// Konventiert bool nach DefaultBoolean (DevX).
    /// Mit dem Parameter-Wert "inverse" kann man den Wert invertieren.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(DefaultBoolean))]
    public class Bool2DefaultBooleanConverter : IValueConverter
    {
        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolValue = (bool)value;
            if (!"inverse".Equals(parameter))
            {
                if (boolValue)
                {
                    return DefaultBoolean.True;
                }
                
                return DefaultBoolean.False;
                
            }
                        
            if (boolValue)
            {
                return DefaultBoolean.False;
            }
            return DefaultBoolean.True;
                        
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();            
        }

        #endregion

        #endregion
    }
}