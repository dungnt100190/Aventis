using System;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common
{
    /// <summary>
    /// Zeigt die Felder Creator, Created, Mofifier, Modified an.
    /// Verwendeung: Auf GUI hinzufügen und Property Active SqlQuery
    /// setzen. 
    /// </summary>
    public class CtlCreationModification : KissComplexControl
    {
        #region Fields

        #region Private Fields

        private System.ComponentModel.IContainer components = null;
        private KissLabel lblErfassung;
        private KissLabel lblMutation;
        private KissLabel lblUserCreationDate;
        private KissLabel lblUserErfassung;
        private KissLabel lblUserModificationDate;
        private KissLabel lblUserMutation;
        private System.Windows.Forms.ToolTip toolTip1;

        #endregion

        #endregion

        #region Constructors

        public CtlCreationModification()
        {
            InitializeComponent();

            toolTip1 = new System.Windows.Forms.ToolTip();

            lblUserErfassung.Text = "---";
            lblUserMutation.Text = "---";
            toolTip1.SetToolTip(lblUserErfassung, String.Empty);
            toolTip1.SetToolTip(lblUserMutation, String.Empty);

            ShowInfo();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblErfassung = new KiSS4.Gui.KissLabel();
            this.lblMutation = new KiSS4.Gui.KissLabel();
            this.lblUserErfassung = new KiSS4.Gui.KissLabel();
            this.lblUserMutation = new KiSS4.Gui.KissLabel();
            this.lblUserCreationDate = new KiSS4.Gui.KissLabel();
            this.lblUserModificationDate = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMutation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserErfassung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserMutation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserCreationDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserModificationDate)).BeginInit();
            this.SuspendLayout();
            //
            // lblErfassung
            //
            this.lblErfassung.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblErfassung.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblErfassung.Location = new System.Drawing.Point(0, 2);
            this.lblErfassung.Name = "lblErfassung";
            this.lblErfassung.Size = new System.Drawing.Size(59, 18);
            this.lblErfassung.TabIndex = 45;
            this.lblErfassung.Text = "Erfassung";
            this.lblErfassung.UseCompatibleTextRendering = true;
            //
            // lblMutation
            //
            this.lblMutation.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblMutation.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblMutation.Location = new System.Drawing.Point(0, 21);
            this.lblMutation.Name = "lblMutation";
            this.lblMutation.Size = new System.Drawing.Size(59, 18);
            this.lblMutation.TabIndex = 46;
            this.lblMutation.Text = "Mutation";
            this.lblMutation.UseCompatibleTextRendering = true;
            //
            // lblUserErfassung
            //
            this.lblUserErfassung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserErfassung.DataMember = "Creator";
            this.lblUserErfassung.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblUserErfassung.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUserErfassung.Location = new System.Drawing.Point(182, 2);
            this.lblUserErfassung.Name = "lblUserErfassung";
            this.lblUserErfassung.Size = new System.Drawing.Size(317, 18);
            this.lblUserErfassung.TabIndex = 47;
            this.lblUserErfassung.UseCompatibleTextRendering = true;
            //
            // lblUserMutation
            //
            this.lblUserMutation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserMutation.DataMember = "Modifier";
            this.lblUserMutation.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblUserMutation.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUserMutation.Location = new System.Drawing.Point(182, 21);
            this.lblUserMutation.Name = "lblUserMutation";
            this.lblUserMutation.Size = new System.Drawing.Size(317, 18);
            this.lblUserMutation.TabIndex = 48;
            this.lblUserMutation.UseCompatibleTextRendering = true;
            //
            // lblUserCreationDate
            //
            this.lblUserCreationDate.DataMember = "Created";
            this.lblUserCreationDate.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblUserCreationDate.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUserCreationDate.Location = new System.Drawing.Point(65, 2);
            this.lblUserCreationDate.Name = "lblUserCreationDate";
            this.lblUserCreationDate.Size = new System.Drawing.Size(111, 18);
            this.lblUserCreationDate.TabIndex = 49;
            //
            // lblUserModificationDate
            //
            this.lblUserModificationDate.DataMember = "Modified";
            this.lblUserModificationDate.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblUserModificationDate.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUserModificationDate.Location = new System.Drawing.Point(65, 21);
            this.lblUserModificationDate.Name = "lblUserModificationDate";
            this.lblUserModificationDate.Size = new System.Drawing.Size(111, 18);
            this.lblUserModificationDate.TabIndex = 50;
            //
            // CtlCreationModification
            //
            this.Controls.Add(this.lblUserModificationDate);
            this.Controls.Add(this.lblUserCreationDate);
            this.Controls.Add(this.lblUserMutation);
            this.Controls.Add(this.lblUserErfassung);
            this.Controls.Add(this.lblMutation);
            this.Controls.Add(this.lblErfassung);
            this.Name = "CtlCreationModification";
            this.Size = new System.Drawing.Size(512, 39);
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMutation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserErfassung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserMutation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserCreationDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserModificationDate)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if ((components != null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the active SQL query.
        /// </summary>
        /// <value>The active SQL query.</value>
        public override SqlQuery ActiveSQLQuery
        {
            get { return base.ActiveSQLQuery; }
            set
            {
                lblUserErfassung.DataSource = value;
                lblUserMutation.DataSource = value;
                lblUserCreationDate.DataSource = value;
                lblUserModificationDate.DataSource = value;

                base.ActiveSQLQuery = value;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void ShowInfo()
        {
            const string COL_CREATOR = "Creator";
            const string COL_CREATED = "Created";
            const string COL_MODIFIER = "Modifier";
            const string COL_MODIFIED = "Modified";

            try
            {
                string creator = (string)ActiveSQLQuery[COL_CREATOR];
                DateTime created = (DateTime)ActiveSQLQuery[COL_CREATED];
                string modifier = (string)ActiveSQLQuery[COL_MODIFIER];
                DateTime modified = (DateTime)ActiveSQLQuery[COL_MODIFIED];
            }
            catch
            {
                lblUserErfassung.Text = "---";
                lblUserMutation.Text = "---";
                toolTip1.SetToolTip(lblUserErfassung, String.Empty);
                toolTip1.SetToolTip(lblUserMutation, String.Empty);
            }
        }

        #endregion

        #endregion
    }
}