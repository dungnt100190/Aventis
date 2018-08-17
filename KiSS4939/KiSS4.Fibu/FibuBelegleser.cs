using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.Gui;

namespace KiSS4.Fibu
{
    /// <summary>
    /// Summary description for Belegleser.
    /// </summary>
    public class FibuBelegleser : Belegleser
    {
        #region Fields

        #region Private Fields

        private int _fbKreditorID;
        private int _fbZahlungswegID;

        #endregion

        #endregion

        #region Constructors

        public FibuBelegleser(Belegleser beleg)
            : base(beleg)
        {
        }

        #endregion

        #region Properties

        public int FbKreditorID
        {
            get { return _fbKreditorID; }
        }

        public int FbZahlungswegID
        {
            get { return _fbZahlungswegID; }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Searchs and Sets if an existing "Zahlungsweg" exists on Database.
        /// </summary>
        public bool SearchZahlungsWeg()
        {
            DlgAuswahlFbZahlungsweg dlg = new DlgAuswahlFbZahlungsweg(KontoNummer, IBANNummer, BelegTyp);

            try
            {
                if (dlg.ShowDialogAuswahl() == DialogResult.OK)
                {
                    if (dlg.FbZahlungswegID != 0)
                    {
                        _fbZahlungswegID = dlg.FbZahlungswegID;
                        _fbKreditorID = dlg.FbKreditorID;
                        return true;
                    }
                }
            }
            finally
            {
                dlg.Dispose();
            }

            return false;
        }

        #endregion

        #endregion
    }
}