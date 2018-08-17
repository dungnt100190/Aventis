using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

using Kiss.Infrastructure.Constant;
using Kiss.Model.DTO.Vm;

namespace Kiss.UI.View.Vm
{
    public class VmPositionDTOToFontWeightConverter : MarkupExtension, IValueConverter
    {
        #region Methods

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dto = value as VmPositionDTO;

            if (dto != null && dto.VmPosition.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.VermTotal)
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