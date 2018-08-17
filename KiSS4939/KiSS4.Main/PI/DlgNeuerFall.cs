using System;
using System.Windows.Forms;

using Kiss.Interfaces.UI;

using KiSS4.Common.PI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Main.PI
{
    /// <summary>
    /// Dialog, used to create new clients with corresponding cases
    /// </summary>
    public class DlgNeuerFall : DlgPersonSucheNeu
    {
        #region Fields

        #region Public Fields

        public int FaLeistungID;

        #endregion

        #region Private Fields

        private bool _hasSARFallfuehrungChanged = false;
        private string _userFullName = "";
        private KiSS4.Gui.KissCheckEdit chkSucheNurFalltraeger;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburt;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlecht;
        private DevExpress.XtraGrid.Columns.GridColumn colKL;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNeueVersNr;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissButtonEdit edtSARFallfuehrung;
        private KiSS4.Gui.KissTextEdit edtSucheNeueVersNr;

        private DevExpress.XtraGrid.Views.Grid.GridView grvListe;

        //////private DevExpress.XtraGrid.Views.Grid.GridView grvListe;
        private KiSS4.Gui.KissLabel lblFallfuehrung;

        private KiSS4.DB.SqlQuery qryFaLeistung;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DlgNeuerFall"/> class.
        /// </summary>
        public DlgNeuerFall()
        {
            // init dialog
            this.InitializeComponent();

            // request userfullname
            _userFullName = DBUtil.ExecuteScalarSQL(@"
                SELECT dbo.fnGetLastFirstName({0}, NULL, NULL);", Session.User.UserID) as String;
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
            this.lblFallfuehrung = new KiSS4.Gui.KissLabel();
            this.edtSucheNeueVersNr = new KiSS4.Gui.KissTextEdit();
            this.chkSucheNurFalltraeger = new KiSS4.Gui.KissCheckEdit();
            this.edtSARFallfuehrung = new KiSS4.Gui.KissButtonEdit();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNeueVersNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvListe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qryFaLeistung = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lblRowCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).BeginInit();
            this.tabPerson.SuspendLayout();
            this.tpgPersonSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblFallfuehrung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNeueVersNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurFalltraeger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSARFallfuehrung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAbbrechen
            // 
            this.btnAbbrechen.Location = new System.Drawing.Point(640, 566);
            this.btnAbbrechen.TabIndex = 3;
            // 
            // btnNeu
            // 
            this.btnNeu.Location = new System.Drawing.Point(535, 566);
            this.btnNeu.TabIndex = 2;
            // 
            // lblRowCount
            // 
            this.lblRowCount.Location = new System.Drawing.Point(508, 257);
            this.lblRowCount.TabIndex = 36;
            this.lblRowCount.Text = "Anzahl Datensätze: 4";
            // 
            // tabListeSuchen
            // 
            this.tabListeSuchen.SelectedTabIndex = 0;
            this.tabListeSuchen.Size = new System.Drawing.Size(662, 246);
            // 
            // tabPerson
            // 
            this.tabPerson.Location = new System.Drawing.Point(10, 10);
            this.tabPerson.Size = new System.Drawing.Size(726, 512);
            // 
            // tpgPersonErfassen
            // 
            this.tpgPersonErfassen.Size = new System.Drawing.Size(714, 474);
            this.tpgPersonErfassen.Title = "tpgPersonErfassen";
            // 
            // tpgPersonSuchen
            // 
            this.tpgPersonSuchen.Size = new System.Drawing.Size(714, 474);
            this.tpgPersonSuchen.Title = "tpgPersonSuchen";
            // 
            // lblFallfuehrung
            // 
            this.lblFallfuehrung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFallfuehrung.Location = new System.Drawing.Point(11, 531);
            this.lblFallfuehrung.Name = "lblFallfuehrung";
            this.lblFallfuehrung.Size = new System.Drawing.Size(99, 24);
            this.lblFallfuehrung.TabIndex = 0;
            this.lblFallfuehrung.Text = "Fallführung";
            this.lblFallfuehrung.UseCompatibleTextRendering = true;
            // 
            // edtSucheNeueVersNr
            // 
            this.edtSucheNeueVersNr.Location = new System.Drawing.Point(390, 125);
            this.edtSucheNeueVersNr.Name = "edtSucheNeueVersNr";
            this.edtSucheNeueVersNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheNeueVersNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheNeueVersNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheNeueVersNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheNeueVersNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheNeueVersNr.Properties.Appearance.Options.UseFont = true;
            this.edtSucheNeueVersNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheNeueVersNr.Size = new System.Drawing.Size(229, 24);
            this.edtSucheNeueVersNr.TabIndex = 19;
            // 
            // chkSucheNurFalltraeger
            // 
            this.chkSucheNurFalltraeger.EditValue = false;
            this.chkSucheNurFalltraeger.Location = new System.Drawing.Point(390, 155);
            this.chkSucheNurFalltraeger.Name = "chkSucheNurFalltraeger";
            this.chkSucheNurFalltraeger.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSucheNurFalltraeger.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheNurFalltraeger.Size = new System.Drawing.Size(229, 19);
            this.chkSucheNurFalltraeger.TabIndex = 20;
            // 
            // edtSARFallfuehrung
            // 
            this.edtSARFallfuehrung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSARFallfuehrung.Location = new System.Drawing.Point(116, 531);
            this.edtSARFallfuehrung.Name = "edtSARFallfuehrung";
            this.edtSARFallfuehrung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSARFallfuehrung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSARFallfuehrung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSARFallfuehrung.Properties.Appearance.Options.UseBackColor = true;
            this.edtSARFallfuehrung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSARFallfuehrung.Properties.Appearance.Options.UseFont = true;
            this.edtSARFallfuehrung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSARFallfuehrung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSARFallfuehrung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSARFallfuehrung.Properties.Name = "editSAR.Properties";
            this.edtSARFallfuehrung.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSARFallfuehrung.Size = new System.Drawing.Size(282, 24);
            this.edtSARFallfuehrung.TabIndex = 1;
            this.edtSARFallfuehrung.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSARFallfuehrung_UserModifiedFld);
            this.edtSARFallfuehrung.EditValueChanged += new System.EventHandler(this.edtSARFallfuehrung_EditValueChanged);
            // 
            // colAlter
            // 
            this.colAlter.Caption = "Alter";
            this.colAlter.FieldName = "Alter";
            this.colAlter.Name = "colAlter";
            this.colAlter.Visible = true;
            this.colAlter.VisibleIndex = 6;
            this.colAlter.Width = 38;
            // 
            // colGeburt
            // 
            this.colGeburt.Caption = "Geburt";
            this.colGeburt.FieldName = "Geburtsdatum";
            this.colGeburt.Name = "colGeburt";
            this.colGeburt.Visible = true;
            this.colGeburt.VisibleIndex = 7;
            // 
            // colGeschlecht
            // 
            this.colGeschlecht.Caption = "m/w";
            this.colGeschlecht.FieldName = "Geschlecht";
            this.colGeschlecht.Name = "colGeschlecht";
            this.colGeschlecht.Visible = true;
            this.colGeschlecht.VisibleIndex = 5;
            this.colGeschlecht.Width = 34;
            // 
            // colKL
            // 
            this.colKL.Caption = "KL";
            this.colKL.FieldName = "KL";
            this.colKL.Name = "colKL";
            this.colKL.Visible = true;
            this.colKL.VisibleIndex = 0;
            this.colKL.Width = 27;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 131;
            // 
            // colNeueVersNr
            // 
            this.colNeueVersNr.Caption = "Vers.-Nr.";
            this.colNeueVersNr.FieldName = "NeueVersNummer";
            this.colNeueVersNr.Name = "colNeueVersNr";
            this.colNeueVersNr.Visible = true;
            this.colNeueVersNr.VisibleIndex = 8;
            this.colNeueVersNr.Width = 95;
            // 
            // colOrt
            // 
            this.colOrt.Caption = "Ort";
            this.colOrt.FieldName = "PLZOrt";
            this.colOrt.Name = "colOrt";
            this.colOrt.Visible = true;
            this.colOrt.VisibleIndex = 4;
            this.colOrt.Width = 132;
            // 
            // colSAR
            // 
            this.colSAR.Caption = "SAR";
            this.colSAR.FieldName = "SAR";
            this.colSAR.Name = "colSAR";
            this.colSAR.Visible = true;
            this.colSAR.VisibleIndex = 1;
            this.colSAR.Width = 100;
            // 
            // colVorname
            // 
            this.colVorname.Caption = "Vorname";
            this.colVorname.FieldName = "Vorname";
            this.colVorname.Name = "colVorname";
            this.colVorname.Visible = true;
            this.colVorname.VisibleIndex = 3;
            this.colVorname.Width = 90;
            // 
            // grvListe
            // 
            this.grvListe.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvListe.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe.Appearance.Empty.Options.UseBackColor = true;
            this.grvListe.Appearance.Empty.Options.UseFont = true;
            this.grvListe.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvListe.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvListe.Appearance.EvenRow.Options.UseFont = true;
            this.grvListe.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvListe.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvListe.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvListe.Appearance.FocusedCell.Options.UseFont = true;
            this.grvListe.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvListe.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvListe.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvListe.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvListe.Appearance.FocusedRow.Options.UseFont = true;
            this.grvListe.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvListe.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvListe.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvListe.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvListe.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvListe.Appearance.GroupRow.Options.UseFont = true;
            this.grvListe.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvListe.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvListe.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvListe.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvListe.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvListe.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvListe.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvListe.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvListe.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvListe.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvListe.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvListe.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvListe.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvListe.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvListe.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvListe.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe.Appearance.OddRow.Options.UseBackColor = true;
            this.grvListe.Appearance.OddRow.Options.UseFont = true;
            this.grvListe.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvListe.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe.Appearance.Row.Options.UseBackColor = true;
            this.grvListe.Appearance.Row.Options.UseFont = true;
            this.grvListe.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvListe.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvListe.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvListe.Appearance.SelectedRow.Options.UseFont = true;
            this.grvListe.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvListe.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvListe.Appearance.VertLine.Options.UseBackColor = true;
            this.grvListe.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvListe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKL,
            this.colSAR,
            this.colName,
            this.colVorname,
            this.colOrt,
            this.colGeschlecht,
            this.colAlter,
            this.colGeburt,
            this.colNeueVersNr});
            this.grvListe.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvListe.GridControl = this.grdListe;
            this.grvListe.Name = "grvListe";
            this.grvListe.OptionsBehavior.Editable = false;
            this.grvListe.OptionsCustomization.AllowFilter = false;
            this.grvListe.OptionsFilter.AllowFilterEditor = false;
            this.grvListe.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvListe.OptionsMenu.EnableColumnMenu = false;
            this.grvListe.OptionsNavigation.AutoFocusNewRow = true;
            this.grvListe.OptionsNavigation.UseTabKey = false;
            this.grvListe.OptionsView.ColumnAutoWidth = false;
            this.grvListe.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvListe.OptionsView.ShowGroupPanel = false;
            this.grvListe.OptionsView.ShowIndicator = false;
            // 
            // qryFaLeistung
            // 
            this.qryFaLeistung.CanInsert = true;
            this.qryFaLeistung.HostControl = this;
            this.qryFaLeistung.TableName = "FaLeistung";
            // 
            // DlgNeuerFall
            // 
            this.ClientSize = new System.Drawing.Size(747, 598);
            this.Controls.Add(this.edtSARFallfuehrung);
            this.Controls.Add(this.lblFallfuehrung);
            this.Name = "DlgNeuerFall";
            this.Text = "Neuer Fall";
            this.Load += new System.EventHandler(this.DlgNeuerFall_Load);
            this.Controls.SetChildIndex(this.lblFallfuehrung, 0);
            this.Controls.SetChildIndex(this.tabPerson, 0);
            this.Controls.SetChildIndex(this.edtSARFallfuehrung, 0);
            this.Controls.SetChildIndex(this.btnNeu, 0);
            this.Controls.SetChildIndex(this.btnAbbrechen, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lblRowCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).EndInit();
            this.tabPerson.ResumeLayout(false);
            this.tpgPersonSuchen.ResumeLayout(false);
            this.tpgPersonSuchen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblFallfuehrung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNeueVersNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurFalltraeger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSARFallfuehrung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).EndInit();
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

        #region EventHandlers

        /// <summary>
        /// Perform additional checks before creating new data entries
        /// </summary>
        protected override void Additional_Check()
        {
            // validate must fields
            if (DBUtil.IsEmpty(edtSARFallfuehrung.EditValue) || DBUtil.IsEmpty(edtSARFallfuehrung.LookupID))
            {
                throw new KissInfoException(KissMsg.GetMLMessage("DBUtil", "FeldXYLeer", "Das Feld '{0}' darf nicht leer bleiben !", KissMsgCode.MsgInfo, lblFallfuehrung.Text), (Control)edtSARFallfuehrung);
            }

            // validate buttonedits
            if (_hasSARFallfuehrungChanged && !DialogAutor(this, new UserModifiedFldEventArgs(false, false)))
            {
                // invalid Autor
                edtSARFallfuehrung.Focus();
                throw new KissCancelException();
            }

            // reset flags
            _hasSARFallfuehrungChanged = false;

            // check if not new person
            if (tabPerson.SelectedTabIndex == 0)
            {
                // Prüfen, ob schon eine aktive Fallführung besteht
                int count = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                    SELECT COUNT(1)
                    FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                    WHERE BaPersonID = {0}
                      AND ModulID = 2
                      AND DatumBis IS NULL;", NewBaPersonID));

                if (count > 0)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage(Name, "BereitsAktiverFall_v01", "Für diese Person gibt es bereits einen aktiven Fallverlauf!", KissMsgCode.MsgInfo));
                }
            }
        }

        protected override void JumpToNewFall()
        {
            // jump to new Fall
            FormController.OpenForm(
                "FrmFall",
                "Action",
                "ShowFall",
                "BaPersonID",
                NewBaPersonID,
                "ModulID",
                2);

            // jump to intake if possible
            FormController.SendMessage(
                "FrmFall",
                "Action",
                "ShowFall",
                "BaPersonID",
                NewBaPersonID,
                "ModulID",
                7);
        }

        /// <summary>
        /// Perform additional work after creating new data entries
        /// </summary>
        protected override void Additional_Save()
        {
            // check rights
            if (!qryFaLeistung.CanInsert)
            {
                throw new KissInfoException(KissMsg.GetMLMessage(Name,
                                                                 "KeineBerechtigung",
                                                                 "Sie haben nicht die Berechtigung, einen neuen Fall zu eröffnen!",
                                                                 KissMsgCode.MsgInfo));
            }

            // check additional permissions
            CheckUserIsAllowedToCreateNewFV(NewBaPersonID);

            // init vars
            int newUserID = Convert.ToInt32(edtSARFallfuehrung.LookupID);

            // FALLVERLAUF:
            // create new FV (check is implemented there!)
            int newFVID = FaUtils.CreateNewProcess(NewBaPersonID, 2, newUserID);

            // check if new FV is valid
            if (newFVID < 1)
            {
                // do cancel
                throw new KissCancelException();
            }

            // apply fields
            FaLeistungID = newFVID;
            UserID = newUserID;

            // INTAKE:
            // create new Intake
            int newINID = FaUtils.CreateNewProcess(NewBaPersonID, 7, newUserID);

            // check if new IN is valid
            if (newINID < 1)
            {
                // show info about failure
                KissMsg.ShowError(Name, "CouldNotCreateIntake", "Das Intake für den neuen Fall konnte nicht angelegt werden. Bitte erstellen Sie manuell ein neues Intake.");
            }
        }

        private void DlgNeuerFall_Load(object sender, EventArgs e)
        {
            // right management
            qryFaLeistung.ApplyUserRights(Name);

            // eingeloggten User vorschlagen
            edtSARFallfuehrung.EditValue = _userFullName;
            edtSARFallfuehrung.LookupID = Session.User.UserID;

            // reset fields
            _hasSARFallfuehrungChanged = false;
        }

        private void edtSARFallfuehrung_EditValueChanged(object sender, EventArgs e)
        {
            // data has changed
            _hasSARFallfuehrungChanged = true;
        }

        private void edtSARFallfuehrung_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            e.Cancel = !DialogAutor(sender, e);
        }

        #endregion

        #region Methods

        #region Private Methods

        /// <summary>
        /// Check if user is allowed to create new Fallverlauf fot given person
        /// </summary>
        /// <param name="baPersonId">The id of the person to create new FV</param>
        /// <exception cref="KissInfoException">Occures if creation of FV is denied for current user</exception>
        private void CheckUserIsAllowedToCreateNewFV(int baPersonId)
        {
            // validate if id is valid or user is creating a new person
            if (baPersonId < 1 || tabPerson.IsTabSelected(tpgPersonErfassen))
            {
                // do nothing
                return;
            }

            // if the user has no rights to display this user, we show an exception
            if (!FaUtils.UserMayShowPersonDossier(baPersonId))
            {
                throw new KissInfoException(KissMsg.GetMLMessage(Name,
                                                                 "AccessDeniedToPersonToCreateFV",
                                                                 "Sie besitzen keine Rechte, für die gewählte Person einen neuen Fall zu eröffnen!",
                                                                 KissMsgCode.MsgInfo));
            }
        }

        private bool DialogAutor(object sender, UserModifiedFldEventArgs e)
        {
            try
            {
                // check if data can be altered
                if (edtSARFallfuehrung.EditMode == EditModeType.ReadOnly)
                {
                    // do nothing
                    return true;
                }

                // prepare search string
                string searchString = "";

                // check if we have a value to parse
                if (!DBUtil.IsEmpty(edtSARFallfuehrung.EditValue))
                {
                    // prepare for database search
                    searchString = edtSARFallfuehrung.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%").Replace("'", "''");
                }

                // validate search string
                if (DBUtil.IsEmpty(searchString))
                {
                    if (e.ButtonClicked)
                    {
                        // if no data entered and the button is clicked, show dialog with all data
                        searchString = "%";
                    }
                    else
                    {
                        edtSARFallfuehrung.LookupID = null;
                        edtSARFallfuehrung.Text = null;
                        return true;
                    }
                }

                // Mitarbeiter_Suchen()
                var dlg = new KissLookupDialog();

                e.Cancel = !dlg.SearchData(String.Format(@"
                    SELECT USR.*
                    FROM dbo.fnDlgMitarbeiterSuchenKGS({0}) USR
                    WHERE USR.Name LIKE '{1}%'", Session.User.UserID, searchString), searchString, e.ButtonClicked, null, null, null);

                if (!e.Cancel)
                {
                    // apply new value
                    edtSARFallfuehrung.LookupID = Convert.ToInt32(dlg["UserID$"]);
                    edtSARFallfuehrung.Text = Convert.ToString(dlg["Name"]);

                    // reset flags
                    _hasSARFallfuehrungChanged = false;

                    // success
                    return true;
                }

                // canceled or error
                return false;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name, "ErrorIKissUserModified", "Fehler bei der Verarbeitung.", ex);
                return false;
            }
        }

        #endregion

        #endregion
    }
}