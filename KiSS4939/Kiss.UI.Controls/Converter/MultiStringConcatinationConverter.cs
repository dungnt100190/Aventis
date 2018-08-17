using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

using Kiss.Interfaces.BL;

namespace Kiss.UI.Controls.Converter
{

    [ValueConversion(typeof(string), typeof(string))]
    public class MultiStringConcatinationConverter : IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            StringBuilder result = new StringBuilder();
            foreach (var value in values)
            {
                if (value != null)
                {
                    string str = value as string;
                    if (!string.IsNullOrEmpty(str))
                    {
                        result.Append(str + ", ");
                    }
                }
            }

            if (result.Length > 0)
            {
                result.Replace(", ", "", result.Length - 2, 2);
            }

            return result.ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}