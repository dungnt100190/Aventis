using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common
{
    /// <summary>
    /// Summary description for CtlGotoFall.
    /// </summary>
    public class CtlGotoFall : KiSS4.Gui.KissComplexControl, IKissBindableEdit
    {
        protected KiSS4.DB.SqlQuery qryFallIcon;
        private object _baPersonID = null;
        private System.ComponentModel.IContainer components;
        private string displayModules = "";
        private System.Windows.Forms.PictureBox imgB;
        private int[] modules;
        private System.Windows.Forms.Panel panFallIcons;
        private bool showToolTipsOnIcons = false;
        private ToolTip ttpControler = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlGotoFall"/> class.
        /// </summary>
        public CtlGotoFall()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // setup default values
            this.panFallIcons.BackColor = GuiConfig.ButtonBackColorEnabled;
            this.panFallIcons.BorderStyle = BorderStyle.FixedSingle;

            if (Session.Active)
                ResetFallIcons();
        }

        /// <summary>
        /// Occurs when [BaPersonID changed].
        /// </summary>
        public event System.EventHandler BaPersonIDChanged;

        [DefaultValue(typeof(Color), "255, 228, 196")]
        public new Color BackColor
        {
            set { this.panFallIcons.BackColor = value; }
            get { return this.panFallIcons.BackColor; }
        }

        /// <summary>
        /// Gets or sets the BaPersonID.
        /// </summary>
        /// <value>The ba person ID.</value>
        [DefaultValue(null)]
        [Browsable(false)]
        public object BaPersonID
        {
            get { return _baPersonID; }
            set
            {
                if (_baPersonID == value)
                {
                    return;
                }

                _baPersonID = value as int?;
                RefreshIcons(_baPersonID);
                OnBaPersonIDChanged(EventArgs.Empty);
            }
        }

        [Browsable(true)]
        [DefaultValue(BorderStyle.FixedSingle)]
        [Description("Set borderstyle")]
        public new BorderStyle BorderStyle
        {
            set { this.panFallIcons.BorderStyle = value; }
            get { return this.panFallIcons.BorderStyle; }
        }

        [Browsable(true)]
        [DefaultValue("")]
        [Description("Set module-ids to display as commaseparated values. If empty, all modules will be displayed.")]
        public string DisplayModules
        {
            set
            {
                this.displayModules = value;
                this.modules = CommaStringToArray(value);

                // refresh icons
                RefreshIcons(this.BaPersonID);
            }
            get { return this.displayModules; }
        }

        /// <summary>
        /// Show tooltip texts on icons depending on module and state. The default text is the name of the icon that is shown.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(false)]
        [Description("Show tooltip texts on icons depending on module and state. The default text is the name of the icon that is shown.")]
        public bool ShowToolTipsOnIcons
        {
            get { return this.showToolTipsOnIcons; }
            set
            {
                if (value == this.showToolTipsOnIcons)
                {
                    // do nothing if value is unchanged
                    return;
                }

                // setup value and new condition
                this.showToolTipsOnIcons = value;
                this.ttpControler = value ? new ToolTip() : null;

                // refresh icons
                RefreshIcons(this.BaPersonID);
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the CtlGotoFall control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        public void CtlGotoFall_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Handled) return;

            if (e.Modifiers == Keys.Alt)
            {
                if (this.qryFallIcon.Find(string.Format("ShortName = '{0}'", e.KeyCode)))
                    ShowFall((int)this.qryFallIcon["ModulID"]);
            }
        }

        /// <summary>
        /// Reset Case Icons.
        /// </summary>
        public virtual void ResetFallIcons()
        {
            this.BaPersonID = DBNull.Value;
        }

        /// <summary>
        /// Displays the case of the specified module..
        /// </summary>
        /// <param name="modul">The modul.</param>
        /// <returns></returns>
        public bool ShowFall(KiSS4.Gui.ModulID modul)
        {
            return ShowFall((int)modul);
        }

        /// <summary>
        /// Displays the specified case.
        /// </summary>
        /// <param name="modulID">The modul ID.</param>
        /// <returns></returns>
        public virtual bool ShowFall(int modulID)
        {
            if (this.qryFallIcon.Find(string.Format("ModulID = {0}", modulID)))
            {
                if ((int)this.qryFallIcon["IconID"] % 10 > 0)
                {
                    FormController.OpenForm("FrmFall", "Action", "ShowFall",
                         "BaPersonID", this.BaPersonID,
                         "ModulID", modulID);

                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CtlGotoFall));
            this.panFallIcons = new System.Windows.Forms.Panel();
            this.imgB = new System.Windows.Forms.PictureBox();
            this.qryFallIcon = new KiSS4.DB.SqlQuery(this.components);
            this.panFallIcons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryFallIcon)).BeginInit();
            this.SuspendLayout();
            //
            // panFallIcons
            //
            this.panFallIcons.BackColor = System.Drawing.Color.Bisque;
            this.panFallIcons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panFallIcons.Controls.Add(this.imgB);
            this.panFallIcons.Location = new System.Drawing.Point(0, 0);
            this.panFallIcons.Name = "panFallIcons";
            this.panFallIcons.Size = new System.Drawing.Size(154, 24);
            this.panFallIcons.TabIndex = 449;
            //
            // imgB
            //
            this.imgB.Image = ((System.Drawing.Image)(resources.GetObject("imgB.Image")));
            this.imgB.Location = new System.Drawing.Point(3, 3);
            this.imgB.Name = "imgB";
            this.imgB.Size = new System.Drawing.Size(16, 16);
            this.imgB.TabIndex = 441;
            this.imgB.TabStop = false;
            //
            // qryFallIcon
            //
            this.qryFallIcon.HostControl = this;
            this.qryFallIcon.SelectStatement = "EXECUTE spFaGetModulIcon {0}";
            this.qryFallIcon.AfterFill += new System.EventHandler(this.qryFallIcon_AfterFill);
            //
            // CtlGotoFall
            //
            this.Controls.Add(this.panFallIcons);
            this.Name = "CtlGotoFall";
            this.Size = new System.Drawing.Size(154, 24);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CtlGotoFall_KeyDown);
            this.panFallIcons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryFallIcon)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        protected virtual void OnBaPersonIDChanged(EventArgs e)
        {
            if (BaPersonIDChanged != null) BaPersonIDChanged(this, e);
        }

        #region IKissBindableEdit

        private string dataMember = string.Empty;
        private SqlQuery dataSource = null;

        [Browsable(true)]
        [DefaultValue("")]
        public string DataMember
        {
            get { return dataMember; }
            set { dataMember = value; }
        }

        [Browsable(true)]
        [DefaultValue(null)]
        public SqlQuery DataSource
        {
            get { return dataSource; }
            set { dataSource = value; }
        }

        void IKissBindableEdit.AllowEdit(bool value)
        {
        }

        string IKissBindableEdit.GetBindablePropertyName()
        {
            return "BaPersonID";
        }

        #endregion

        /// <summary>
        /// Refreshes the icons.
        /// </summary>
        /// <param name="personID">The person ID.</param>
        protected virtual void RefreshIcons(object personID)
        {
            Cursor cur = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            this.qryFallIcon.Fill(personID);

            Cursor.Current = cur;
        }

        private int[] CommaStringToArray(string comma)
        {
            if (DBUtil.IsEmpty(comma)) return new int[] { };

            string[] arrayCols;
            arrayCols = comma.Split(new char[] { ',' });

            int[] arrayInts = new int[arrayCols.Length];

            for (int i = 0; i < arrayCols.Length; i++)
            {
                arrayInts[i] = int.Parse(arrayCols[i]);
            }

            return arrayInts;
        }

        private void img_Click(object sender, System.EventArgs e)
        {
            if (this.qryFallIcon.Count == 0) return;

            PictureBox pic = sender as PictureBox;

            if (pic != null)
                ShowFall((((int)pic.Tag) - 1000) / 100);
        }

        /// <summary>
        /// Handles the AfterFill event of the qryFallIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void qryFallIcon_AfterFill(object sender, System.EventArgs e)
        {
            this.panFallIcons.Controls.Clear();

            PictureBox pic = null;
            int counter = 0;

            while (this.qryFallIcon.Count > 0)
            {
                // check if we need to show this module
                if (this.modules != null && this.modules.Length > 0)
                {
                    bool showModule = false;

                    for (int i = 0; i < this.modules.Length; i++)
                    {
                        if (this.modules[i] == Convert.ToInt32(this.qryFallIcon.Row["ModulID"]))
                        {
                            showModule = true;
                            break;
                        }
                    }

                    if (!showModule)
                    {
                        if (!this.qryFallIcon.Next()) break;
                        continue;
                    }
                }

                pic = new PictureBox();
                pic.Location = new System.Drawing.Point(4 + counter * 20, 3);
                pic.Size = new System.Drawing.Size(16, 16);
                pic.TabIndex = this.qryFallIcon.Position;
                pic.Tag = this.qryFallIcon["IconID"];
                pic.Image = KissImageList.GetSmallImage((int)pic.Tag);
                this.panFallIcons.Controls.Add(pic);

                // set tooltip (if we have a valid icon that is not "dummy")
                if (this.ttpControler != null && !DBUtil.IsEmpty(pic.Tag) && pic.Tag is int && ((int)pic.Tag) != 0)
                {
                    this.ttpControler.SetToolTip(pic, KissMsg.GetMLMessage("CtlGotoFall", string.Format("IconToolTip_{0}", pic.Tag), KissImageList.GetXIconName((int)pic.Tag)));
                }

                // count up amount of icons
                counter++;

                // attach click event if we have a valid icon
                if ((int)pic.Tag % 10 > 0)
                {
                    pic.Click += new System.EventHandler(this.img_Click);
                }

                // check if need to go on
                if (!this.qryFallIcon.Next())
                {
                    break;
                }
            }

            // recalc width if we have a new icon
            if (pic != null)
            {
                this.panFallIcons.Width = pic.Left + 22;
            }
        }
    }
}