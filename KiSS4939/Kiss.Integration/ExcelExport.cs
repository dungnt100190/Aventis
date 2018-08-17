using DevExpress.Xpf.Grid;

using Kiss.UI.Controls.Helper;

namespace Kiss.Integration
{
    public class ExcelExport
    {
        /// <summary>
        /// Do the export for GridControls. Throw an exception if something happens.
        /// </summary>
        /// <param name="gridControl"></param>
        public void Export(GridControl gridControl)
        {
            var xlsExporter = new ExportToExcelProvider(gridControl);
            xlsExporter.Export();
        }
    }
}