using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

using Kiss.Infrastructure.Enumeration;
using Kiss.Interfaces.BL;

namespace Kiss.UI.Controls.Converter
{

    [ValueConversion(typeof(WshAuszahlvorschlagStatusWrapper), typeof(DevExpress.Utils.DefaultBoolean))]
    public class KbuStatusBeleg2BoolConverter : IValueConverter
    {
        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            WshAuszahlvorschlagStatusWrapper status = value as WshAuszahlvorschlagStatusWrapper;
            if (status != null)
            {
                if (status.EnumValue == WshAuszahlvorschlagStatus.Vorschlag)
                {
                    return DevExpress.Utils.DefaultBoolean.True;
                }
            }
            return DevExpress.Utils.DefaultBoolean.False;         
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
            /*
                ViewThing source  = (ViewThing) value;
                ModelThing target;
                return target;
             */
        }

        #endregion

        #endregion
    }
}