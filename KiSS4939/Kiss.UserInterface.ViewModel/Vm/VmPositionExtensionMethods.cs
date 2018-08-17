
using Kiss.DbContext;
using Kiss.DbContext.Enums.Vm;


namespace Kiss.UserInterface.ViewModel.Vm
{
    public static class VmPositionExtensionMethods
    {
        public static bool CanEdit(this VmPosition position)
        {
            if (position.IstImportiert ||
                position.VmPositionsart.VmPositionsartTyp == VmPositionsartTyp.VermTotal ||
                position.VmPositionsart.VmPositionsartTyp == VmPositionsartTyp.VermElBerechnung ||
                position.VmPositionsart.VmPositionsartTyp == VmPositionsartTyp.VermElFreibetrag)
            {
                return false;
            }

            return true;
        }

        public static bool CanEditBemerkung(this VmPosition position)
        {
            if (position.VmPositionsart.VmPositionsartTyp == VmPositionsartTyp.VermTotal ||
                position.VmPositionsart.VmPositionsartTyp == VmPositionsartTyp.VermElBerechnung ||
                position.VmPositionsart.VmPositionsartTyp == VmPositionsartTyp.VermElFreibetrag)
            {
                return false;
            }

            // die Bemerkung von Betriebskonto, Depot BS und Kasse + PC kann immer gesetzt werden
            if (position.IstImportiert &&
                position.VmPositionsart.VmPositionsartTyp != VmPositionsartTyp.VermBetriebskonto &&
                position.VmPositionsart.VmPositionsartTyp != VmPositionsartTyp.VermDepotBs &&
                position.VmPositionsart.VmPositionsartTyp != VmPositionsartTyp.VermKassePc)
            {
                return false;
            }

            return true;
        }

        public static bool IstFixeVermoegenPosition(this VmPosition position)
        {
            if (position == null || position.VmPositionsart == null)
            {
                return false;
            }

            var type = position.VmPositionsart.VmPositionsartTyp;

            return type == VmPositionsartTyp.VermElBerechnung ||
                   type == VmPositionsartTyp.VermElFreibetrag ||
                   type == VmPositionsartTyp.VermTotal;
        }
    }
}