using System;
using System.Collections.Generic;
using System.Windows.Forms;
using KiSS4.DB;

namespace KiSS4.Gui
{
    /// <summary>
    /// The dialog to select the mask, dialog or form to translate
    /// </summary>
    public partial class DlgSelectTranslation : KiSS4.Gui.KissDialog
    {
        #region Fields

        /// <summary>
        /// A list containing all controls that can be translated (form, dialog, mask)
        /// </summary>
        private List<Control> controls = null;

        /// <summary>
        /// The query to hold data (not database bound)
        /// </summary>
        private SqlQuery qryControls = null;

        #endregion

        #region Constructor
        
        /// <summary>
        /// The constructor to init dialog
        /// </summary>
        public DlgSelectTranslation(List<Control> controls)
        {
            // apply fields
            this.controls = controls;
            
            // init
            InitializeComponent();

            // init controls to be translateable
            this.Text = KissMsg.GetMLMessage("DlgSelectTranslation", "DialogText", this.Text);
            this.lblSelectControl.Text = KissMsg.GetMLMessage("DlgSelectTranslation", "SelectControl", this.lblSelectControl.Text);
            this.colControl.Caption = KissMsg.GetMLMessage("DlgSelectTranslation", "ColumnControl", this.colControl.Caption);
            this.colType.Caption = KissMsg.GetMLMessage("DlgSelectTranslation", "ColumnType", this.colType.Caption);
            this.btnOk.Text = KissMsg.GetMLMessage("DlgSelectTranslation", "ButtonOk", this.btnOk.Text);
            this.btnCancel.Text = KissMsg.GetMLMessage("DlgSelectTranslation", "ButtonCancel", this.btnCancel.Text);

            // depending on amount of controls
            if (controls == null || controls.Count == 0)
            {
                this.btnOk.Enabled = false;
                return;
            }

            // create query with data
            qryControls = new SqlQuery();
            string sqlStmt = null;
            qryControls.HostControl = this;

            foreach (Control ctl in controls)
            {
                // set values
                string type = "";

                if(typeof(KissDialog).IsAssignableFrom(ctl.GetType()))
                {
                    // is dialog
                    type = KissMsg.GetMLMessage("DlgSelectTranslation", "TypeDialog", "Dialog");
                } 
                else if(typeof(KissForm).IsAssignableFrom(ctl.GetType()))
                {
                    // is form
                    type = KissMsg.GetMLMessage("DlgSelectTranslation", "TypeForm", "Fenster");
                } 
                else
                {
                    // is control
                    type = KissMsg.GetMLMessage("DlgSelectTranslation", "TypeMask", "Maske");
                }
                
                // add values to query
                sqlStmt = string.Format("{0} {1} SELECT Type = '{2}', Control = '{3}'", sqlStmt, sqlStmt == null ? "" : "UNION", type, ctl.GetType().Name);
            }

            // append order
            sqlStmt = string.Format("{0} ORDER BY Type, Control", sqlStmt);

            // exec sql
            qryControls.Fill(sqlStmt);

            // setup grid
            this.grdControls.DataSource = qryControls;
            this.colType.FieldName = "Type";
            this.colControl.FieldName = "Control";

            // select first row
            qryControls.First();
        } 

        #endregion

        #region Properties

        /// <summary>
        /// Get the control the user selected to translate
        /// </summary>
        public Control SelectedControl
        {
            get 
            {
                // get the name of the control to translate
                string controlName = qryControls["Control"] as string;
                
                // validate 
                if(DBUtil.IsEmpty(controlName))
                {
                    // no valid row selecte
                    return null;
                }

                // return the control that matches the name
                foreach (Control ctl in controls)
                {
                    if (ctl.GetType().Name.Equals(controlName))
                    {
                        return ctl;
                    }
                }

                // control not found
                return null;
            }
        }

        #endregion

        #region EventHandlers

        private void grdControls_DoubleClick(object sender, EventArgs e)
        {
            // double click = select the mask
            this.btnOk.PerformClick();
        }

        #endregion
    }
}