using System.Windows;
using System.Windows.Controls;

using Kiss.Infrastructure.Constant;
using Kiss.Model.DTO.Vm;

using DevExpress.Xpf.Grid;

namespace Kiss.UI.View.Vm
{
    /// <summary>
    /// Wird in VmKlientenbudgetKategorieView.xaml verwendet, um in der Saldo-Spalte (Typ decimal) ein Drop-Down anzuzeigen.
    /// </summary>
    internal class VmPositionSaldoCellTemplateSelector : DataTemplateSelector
    {
        #region Properties

        /// <summary>
        /// Das Template, welches verwendet wird, wenn die Positionsart vom Typ <see cref="LOVsGenerated.VmPositionsartTyp.VermElFreibetrag"/> ist.
        /// </summary>
        public DataTemplate DropDownTemplate
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region Public Methods

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var data = item as GridCellData;

            if (data != null)
            {
                var dto = data.RowData.Row as VmPositionDTO;

                if (dto != null && dto.VmPosition != null && dto.VmPosition.VmPositionsart != null)
                {
                    // Bei Typ Vermögen - EL-Freibetrag das DropDownTemplate anwenden
                    if (dto.VmPosition.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.VermElFreibetrag)
                    {
                        return DropDownTemplate;
                    }
                }
            }

            return base.SelectTemplate(item, container);
        }

        #endregion

        #endregion
    }
}