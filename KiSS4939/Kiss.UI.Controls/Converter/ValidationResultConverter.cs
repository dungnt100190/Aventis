using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;

using Kiss.Interfaces.BL;
using Kiss.UI.Controls.LocalResources;

namespace Kiss.UI.Controls.Converter
{
    [ValueConversion(typeof(KissServiceResult), typeof(string))]
    public class ValidationResultConverter : IValueConverter
    {
        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = value as IServiceResult;

            var errorText = new StringBuilder();

            if (result != null)
            {
                if (result.IsError)
                {
                    errorText.Append(ValidationResultConverterRes.FalscheOderFehlendeDateneingabe);
                }
                else if (result.IsWarning)
                {
                    errorText.Append(ValidationResultConverterRes.Warnungen);
                }

                for (int i = 0; i < result.ServiceResultEntries.Count; i++)
                {
                    if (result.ServiceResultEntries[i].ResultType != ServiceResultType.Ok)
                    {
                        errorText.Append("- ");
                        if (result.ServiceResultEntries[i].MessageParameters != null && result.ServiceResultEntries[i].MessageParameters.Length > 0)
                        {
                            errorText.Append(string.Format(result.ServiceResultEntries[i].Message, result.ServiceResultEntries[i].MessageParameters));
                        }
                        else
                        {
                            errorText.Append(result.ServiceResultEntries[i].Message);
                        }
                        if (i < result.ServiceResultEntries.Count - 1)
                        {
                            errorText.Append("\n");
                        }
                    }
                }
                return errorText.ToString();
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