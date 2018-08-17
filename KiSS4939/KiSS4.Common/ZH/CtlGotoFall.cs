using System;
using System.ComponentModel;
using System.Windows.Forms;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common.ZH
{
    /// <summary>
    /// Summary description for CtlGotoFall.
    /// </summary>
    public class CtlGotoFall : KiSS4.Common.CtlGotoFall
    {
        private int faFallID = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlGotoFall"/> class.
        /// </summary>
        public CtlGotoFall()
        {
        }

        /// <summary>
        /// Displays the specified case.
        /// </summary>
        /// <param name="modulID">The modul ID.</param>
        /// <returns></returns>
        public override bool ShowFall(int modulID)
        {
            if (this.qryFallIcon.Find(string.Format("ModulID = {0}", modulID)))
            {
                if ((int)this.qryFallIcon["IconID"] % 10 > 0)
                {
                    if (faFallID > 0)
                    {
                        // FallID wurde spezifiziert, d.h. wir verwenden sie auch zum Selektieren des Falls
                        FormController.OpenForm("FrmFall", "Action", "ShowFall",
                             "BaPersonID", this.BaPersonID, "FaFallID", this.faFallID, "ModulID", modulID);
                    }
                    else
                    {
                        // Nur BaPersonID ist bekannt, d.h. wir delegieren ans Basis-Control
                        base.ShowFall(modulID);
                    }

                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Reset Case Icons.
        /// </summary>
        public override void ResetFallIcons()
        {
            base.ResetFallIcons();

            this.faFallID = 0;
        }

        /// <summary>
        /// Occurs when [FaFallID changed].
        /// </summary>
        public event System.EventHandler FaFallIDChanged;

        protected virtual void OnFaFallIDChanged(EventArgs e)
        {
            if (FaFallIDChanged != null) FaFallIDChanged(this, e);
        }

        /// <summary>
        /// Gets or Sets the FaFallID. Accepts null, DBNull.Value or (int)0 to unset.  Returns null if not set.
        /// This is to refine the display of the Icons in case a person has multiple Cases (FaFall)
        /// Note that you still need to set the BaPersonID (e.g. explitit through the property or via Data Binding)
        /// </summary>
        /// <value>The FaFallID.</value>    
        [DefaultValue(null)]
        [Browsable(false)]
        public object FaFallID
        {
            get { return this.faFallID == 0 ? null : (object)this.faFallID; }

            set
            {
                int newValue = DBUtil.IsEmpty(value) ? 0 : (int)value;

                if (this.faFallID != newValue)
                {
                    // Wert hat geändert, d.h. ändere die Darstellung und löse den Changed Event aus
                    this.faFallID = newValue;
                    this.RefreshIcons(this.BaPersonID);
                    this.OnFaFallIDChanged(EventArgs.Empty);
                }
            }
        }

	    /// <summary>
		/// Refreshes the icons.
		/// </summary>
		/// <param name="personID">The person ID.</param>
		protected override void RefreshIcons(object personID)
		{
			Cursor cur = Cursor.Current;
			Cursor.Current = Cursors.WaitCursor;

            if (faFallID > 0)
            {
                // FallID wurde spezifiziert, d.h. wir verwenden sie auch zum Selektieren des Falls
                // Change the SP-Call to take two arguments (BaPersonID and FaFallID)
                base.qryFallIcon.SelectStatement = " EXECUTE spFaGetModulIcon {0}, {1}";
			    this.qryFallIcon.Fill(personID, this.faFallID);                
            }
            else
            {
                // Nur BaPersonID ist bekannt, d.h. wir delegieren ans Basis-Control
                
                // But first, change the SP-Call to take only ine argument (BaPersonID)
                base.qryFallIcon.SelectStatement = " EXECUTE spFaGetModulIcon {0}";

                base.RefreshIcons(personID); 

            }

			Cursor.Current = cur;
		}

    }
}
