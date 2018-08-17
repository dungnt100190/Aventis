using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

using Kiss.DbContext;

namespace Kiss.UserInterface.View.Converter
{
    public class LovToStringConverter : IValueConverter
    {
        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var singleLov = value as XLOVCode;
            if( singleLov !=null)
            {
                return singleLov.Text;
            }
            var lovList = value as IEnumerable<XLOVCode>;
            if (lovList != null)
            {
                return string.Join(", ", lovList.Select(lov=>lov.Text));
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}