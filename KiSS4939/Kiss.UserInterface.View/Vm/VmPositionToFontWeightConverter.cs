using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

using Kiss.DbContext;
using Kiss.DbContext.Enums.Vm;

namespace Kiss.UserInterface.View.Vm
{
    public class VmPositionToFontWeightConverter : MarkupExtension, IValueConverter
    {
        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var position = value as VmPosition;

            if (position != null && position.VmPositionsart.VmPositionsartTyp == VmPositionsartTyp.VermTotal)
            {
                return FontWeights.Bold;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        #endregion

        #endregion
    }
}