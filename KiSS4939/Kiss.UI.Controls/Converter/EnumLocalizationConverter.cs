using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

using Kiss.DbContext;
using Kiss.Infrastructure;

namespace Kiss.UI.Controls.Converter
{
    public class EnumLocalizationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            var text = GetDisplayText(value);
            if (text != null)
            {
                return text;
            }

            var enumerable = value as IEnumerable;
            if (enumerable != null)
            {
                return string.Join(", ", enumerable.OfType<object>().Select(GetDisplayText));
            }

            // fallback: lookup path
            var path = parameter as string;
            if (!string.IsNullOrEmpty(path))
            {
                var binding = new Binding(path) { Source = value };
                return binding.ProvideValue(null);
            }
            return value.ToString();
        }

        private string GetDisplayText(object item)
        {
            // translate enum via resources
            var enumValue = item as Enum;
            if (enumValue != null)
            {
                return enumValue.ToStringLocalized();
            }

            // translate XLOVCode via DB (don't access db directlyhere, but via cache)
            var lovCode = item as XLOVCode;
            if (lovCode != null)
            {
                // ToDo
                return lovCode.Text;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
