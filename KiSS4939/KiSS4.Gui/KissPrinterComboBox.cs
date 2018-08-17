using System.Drawing.Printing;

namespace KiSS4.Gui
{
    public class KissPrinterComboBox : KissComboBox
    {
        #region Methods

        #region Protected Methods

        protected override void OnLoaded()
        {
            base.OnLoaded();

            if (!DesignMode)
            {
                LoadInstalledPrinters();
            }
        }

        #endregion

        #region Private Methods

        private void LoadInstalledPrinters()
        {
            string defaultPrinter = null;

            foreach (string printerName in PrinterSettings.InstalledPrinters)
            {
                Properties.Items.Add(printerName);

                // Retrieve the printer settings.
                PrinterSettings printer = new PrinterSettings { PrinterName = printerName };

                if (printer.IsDefaultPrinter)
                {
                    defaultPrinter = printerName;
                }
            }

            if (defaultPrinter != null)
            {
                SelectedItem = defaultPrinter;
            }
        }

        #endregion

        #endregion
    }
}