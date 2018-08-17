using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Klientenbuchhaltung
{
    public class CtlKbAuswahlMandant : KissComplexControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colBis;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colVon;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissButtonEdit edtMandant;
        private KiSS4.Gui.KissTextEdit edtMandantID;
        private KiSS4.Gui.KissGrid grdPeriode;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPeriode;
        private int KbMandantID = -1;
        private KiSS4.Gui.KissLabel lblMandant;
        private KiSS4.DB.SqlQuery qryPeriode;

        #endregion

        #region Constructors

        public CtlKbAuswahlMandant()
        {
            this.InitializeComponent();
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtMandant = new KiSS4.Gui.KissButtonEdit();
            this.grdPeriode = new KiSS4.Gui.KissGrid();
            this.lblMandant = new KiSS4.Gui.KissLabel();
            this.edtMandantID = new KiSS4.Gui.KissTextEdit();
            this.colBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvPeriode = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qryPeriode = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.edtMandant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPeriode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandantID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPeriode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPeriode)).BeginInit();
            this.SuspendLayout();
            //
            // edtMandant
            //
            this.edtMandant.Location = new System.Drawing.Point(86, 5);
            this.edtMandant.Name = "edtMandant";
            this.edtMandant.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMandant.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMandant.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMandant.Properties.Appearance.Options.UseBackColor = true;
            this.edtMandant.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMandant.Properties.Appearance.Options.UseFont = true;
            this.edtMandant.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtMandant.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtMandant.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMandant.Size = new System.Drawing.Size(205, 24);
            this.edtMandant.TabIndex = 376;
            this.edtMandant.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtMandant_UserModifiedFld);
            //
            // grdPeriode
            //
            this.grdPeriode.DataSource = this.qryPeriode;
            this.grdPeriode.EmbeddedNavigator.Name = "";
            this.grdPeriode.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdPeriode.Location = new System.Drawing.Point(410, 5);
            this.grdPeriode.MainView = this.grvPeriode;
            this.grdPeriode.Name = "grdPeriode";
            this.grdPeriode.Size = new System.Drawing.Size(384, 89);
            this.grdPeriode.TabIndex = 377;
            this.grdPeriode.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvPeriode});
            //
            // lblMandant
            //
            this.lblMandant.Location = new System.Drawing.Point(7, 5);
            this.lblMandant.Name = "lblMandant";
            this.lblMandant.Size = new System.Drawing.Size(63, 24);
            this.lblMandant.TabIndex = 378;
            this.lblMandant.Text = "Mandant";
            this.lblMandant.UseCompatibleTextRendering = true;
            //
            // edtMandantID
            //
            this.edtMandantID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtMandantID.Location = new System.Drawing.Point(307, 5);
            this.edtMandantID.Name = "edtMandantID";
            this.edtMandantID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtMandantID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMandantID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMandantID.Properties.Appearance.Options.UseBackColor = true;
            this.edtMandantID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMandantID.Properties.Appearance.Options.UseFont = true;
            this.edtMandantID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMandantID.Properties.Name = "editMandantNrX.Properties";
            this.edtMandantID.Properties.ReadOnly = true;
            this.edtMandantID.Size = new System.Drawing.Size(70, 24);
            this.edtMandantID.TabIndex = 379;
            //
            // colBis
            //
            this.colBis.Caption = "Periode Bis";
            this.colBis.FieldName = "PeriodeBis";
            this.colBis.Name = "colBis";
            this.colBis.Visible = true;
            this.colBis.VisibleIndex = 1;
            this.colBis.Width = 90;
            //
            // colID
            //
            this.colID.Caption = "PeriodeID";
            this.colID.FieldName = "KbPeriodeID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 3;
            //
            // colStatus
            //
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "PeriodeStatusCode";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 2;
            this.colStatus.Width = 100;
            //
            // colVon
            //
            this.colVon.Caption = "Periode Von";
            this.colVon.FieldName = "PeriodeVon";
            this.colVon.Name = "colVon";
            this.colVon.Visible = true;
            this.colVon.VisibleIndex = 0;
            this.colVon.Width = 90;
            //
            // grvPeriode
            //
            this.grvPeriode.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvPeriode.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriode.Appearance.Empty.Options.UseBackColor = true;
            this.grvPeriode.Appearance.Empty.Options.UseFont = true;
            this.grvPeriode.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriode.Appearance.EvenRow.Options.UseFont = true;
            this.grvPeriode.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvPeriode.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriode.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvPeriode.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvPeriode.Appearance.FocusedCell.Options.UseFont = true;
            this.grvPeriode.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvPeriode.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvPeriode.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriode.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvPeriode.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvPeriode.Appearance.FocusedRow.Options.UseFont = true;
            this.grvPeriode.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvPeriode.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPeriode.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvPeriode.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPeriode.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriode.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPeriode.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvPeriode.Appearance.GroupRow.Options.UseFont = true;
            this.grvPeriode.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvPeriode.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvPeriode.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvPeriode.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriode.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvPeriode.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvPeriode.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvPeriode.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvPeriode.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriode.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPeriode.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvPeriode.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvPeriode.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvPeriode.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvPeriode.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvPeriode.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriode.Appearance.OddRow.Options.UseFont = true;
            this.grvPeriode.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvPeriode.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriode.Appearance.Row.Options.UseBackColor = true;
            this.grvPeriode.Appearance.Row.Options.UseFont = true;
            this.grvPeriode.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriode.Appearance.SelectedRow.Options.UseFont = true;
            this.grvPeriode.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvPeriode.Appearance.VertLine.Options.UseBackColor = true;
            this.grvPeriode.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvPeriode.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colVon,
                        this.colBis,
                        this.colStatus,
                        this.colID});
            this.grvPeriode.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvPeriode.GridControl = this.grdPeriode;
            this.grvPeriode.Name = "grvPeriode";
            this.grvPeriode.OptionsBehavior.Editable = false;
            this.grvPeriode.OptionsCustomization.AllowFilter = false;
            this.grvPeriode.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvPeriode.OptionsNavigation.AutoFocusNewRow = true;
            this.grvPeriode.OptionsNavigation.UseTabKey = false;
            this.grvPeriode.OptionsView.ColumnAutoWidth = false;
            this.grvPeriode.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvPeriode.OptionsView.ShowGroupPanel = false;
            this.grvPeriode.OptionsView.ShowIndicator = false;
            //
            // qryPeriode
            //
            this.qryPeriode.HostControl = this;
            this.qryPeriode.SelectStatement = "SELECT * \r\nFROM KbPeriode\r\nWHERE KbMandantID = {0}";
            this.qryPeriode.TableName = "KbPeriode";
            //
            // CtlKbAuswahlMandant
            //
            this.Controls.Add(this.edtMandantID);
            this.Controls.Add(this.lblMandant);
            this.Controls.Add(this.grdPeriode);
            this.Controls.Add(this.edtMandant);
            this.Name = "CtlKbAuswahlMandant";
            this.Size = new System.Drawing.Size(806, 101);
            this.Load += new System.EventHandler(this.CtlKbAuswahlMandant_Load);
            ((System.ComponentModel.ISupportInitialize)(this.edtMandant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPeriode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandantID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPeriode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPeriode)).EndInit();
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

        #region Public Properties

        public int KbPeriodeID
        {
            get
            {
                if (qryPeriode["KbPeriodeID"] is int)
                    return (int)qryPeriode["KbPeriodeID"];
                return -1;
            }
        }

        #endregion

        #region Public Methods

        public void Reset()
        {
            edtMandant.EditValue = string.Empty;
            KbMandantID = -1;
            qryPeriode.Fill(KbMandantID);
        }

        #endregion

        #region Private Methods

        private void CtlKbAuswahlMandant_Load(object sender, System.EventArgs e)
        {
            this.colStatus.ColumnEdit = grdPeriode.GetLOVLookUpEdit("KbPeriodeStatus");
        }

        private void edtMandant_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            KissLookupDialog dlg = new KissLookupDialog();

            if (dlg.SearchData(@"
                SELECT DISTINCT
                    MND.KbMandantID,
                    Mandant = dbo.fnGetMLTextByDefault(MND.MandantTID, {1}, MND.Mandant)
                FROM KbMandant MND
                WHERE MND.Mandant LIKE {0} + '%'",
                edtMandant.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%"),
                e.ButtonClicked,
                Session.User.LanguageCode))
            {
                if (DBUtil.IsEmpty(dlg["KbMandantID"]))
                    KbMandantID = 0;
                else
                    KbMandantID = (int)dlg["KbMandantID"];

                edtMandantID.Text = dlg["KbMandantID"].ToString();
                edtMandant.Text = dlg["Mandant"].ToString();

                qryPeriode.Fill(KbMandantID);
            }
        }

        #endregion
    }
}