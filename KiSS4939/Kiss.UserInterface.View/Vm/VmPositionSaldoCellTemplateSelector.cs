using System.Windows;
using System.Windows.Controls;

using Kiss.DbContext;
using Kiss.DbContext.DTO.Vm;
using Kiss.DbContext.Enums.Vm;
using Kiss.Infrastructure.Constant;

using DevExpress.Xpf.Grid;

namespace Kiss.UserInterface.View.Vm
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
        public DataTemplate DropDownTemplate { get; set; }

        #endregion

        #region Methods

        #region Public Methods

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var data = item as GridCellData;

            if (data != null)
            {
                var position = data.RowData.Row as VmPosition;

                if (position != null && position.VmPositionsart != null)
                {
                    // Bei Typ Vermögen - EL-Freibetrag das DropDownTemplate anwenden
                    if (position.VmPositionsart.VmPositionsartTyp == VmPositionsartTyp.VermElFreibetrag)
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