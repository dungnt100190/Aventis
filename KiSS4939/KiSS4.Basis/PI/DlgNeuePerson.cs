using System;

using KiSS4.DB;

namespace KiSS4.Basis.PI
{
    public class DlgNeuePerson : KiSS4.Common.PI.DlgPersonSucheNeu
    {
        #region Fields

        #region Private Fields

        private int _falltraegerID;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburt;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlecht;
        private DevExpress.XtraGrid.Columns.GridColumn colKL;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNeueVersNr;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private KiSS4.Gui.KissLookUpEdit edtBeziehungFalltraeger;
        private KiSS4.Gui.KissTextEdit edtSucheNeueVersNr;

        ////////private DevExpress.XtraGrid.Views.Grid.GridView grvListe;
        private KiSS4.Gui.KissLabel lblBeziehungFalltraeger;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DlgNeuePerson"/> class.
        /// </summary>
        /// <param name="FalltraegerID">The id of the case responsible BaPersonID</param>
        public DlgNeuePerson(int falltraegerID)
            : base()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            this._falltraegerID = falltraegerID;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DlgNeuePerson"/> class.
        /// </summary>
        public DlgNeuePerson()
        {
            // This call is required by the Windows Form Designer.
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtSucheNeueVersNr = new KiSS4.Gui.KissTextEdit();
            this.lblBeziehungFalltraeger = new KiSS4.Gui.KissLabel();
            this.edtBeziehungFalltraeger = new KiSS4.Gui.KissLookUpEdit();
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
            this.tabPerson.SuspendLayout();
            this.tpgPersonSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRowCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdListe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNeueVersNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeziehungFalltraeger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeziehungFalltraeger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeziehungFalltraeger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe)).BeginInit();
            this.SuspendLayout();
            //
            // btnNeu
            //
            this.btnNeu.Location = new System.Drawing.Point(495, 562);
            this.btnNeu.TabIndex = 3;
            //
            // tabPerson
            //
            this.tabPerson.Location = new System.Drawing.Point(10, 10);
            this.tabPerson.Size = new System.Drawing.Size(690, 515);
            //
            // tpgPersonSuchen
            //
            this.tpgPersonSuchen.Size = new System.Drawing.Size(678, 477);
            this.tpgPersonSuchen.Title = "tpgPersonSuchen";
            //
            // qryBaPerson
            //
            this.qryBaPerson.TableName = "BaPerson";
            //
            // btnAbbrechen
            //
            this.btnAbbrechen.Location = new System.Drawing.Point(600, 562);
            this.btnAbbrechen.TabIndex = 4;
            //
            // lblRowCount
            //
            this.lblRowCount.Location = new System.Drawing.Point(517, 260);
            this.lblRowCount.Text = "Anzahl Datensätze: 2";
            //
            // tabListeSuchen
            //
            this.tabListeSuchen.SelectedTabIndex = 0;
            this.tabListeSuchen.Size = new System.Drawing.Size(672, 249);
            //
            // grdListe
            //
            this.grdListe.EmbeddedNavigator.Name = "gridList.EmbeddedNavigator";
            this.grdListe.MainView = this.grvListe;
            this.grdListe.Size = new System.Drawing.Size(660, 211);
            this.grdListe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvListe});
            //
            // tpgPersonErfassen
            //
            this.tpgPersonErfassen.Size = new System.Drawing.Size(678, 477);
            this.tpgPersonErfassen.Title = "tpgPersonErfassen";
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
            // lblBeziehungFalltraeger
            //
            this.lblBeziehungFalltraeger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBeziehungFalltraeger.Location = new System.Drawing.Point(245, 528);
            this.lblBeziehungFalltraeger.Name = "lblBeziehungFalltraeger";
            this.lblBeziehungFalltraeger.Size = new System.Drawing.Size(164, 24);
            this.lblBeziehungFalltraeger.TabIndex = 1;
            this.lblBeziehungFalltraeger.Text = "Beziehung zu Fallträger/in";
            this.lblBeziehungFalltraeger.UseCompatibleTextRendering = true;
            //
            // edtBeziehungFalltraeger
            //
            this.edtBeziehungFalltraeger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBeziehungFalltraeger.Location = new System.Drawing.Point(415, 528);
            this.edtBeziehungFalltraeger.LOVName = "Sprache";
            this.edtBeziehungFalltraeger.Name = "edtBeziehungFalltraeger";
            this.edtBeziehungFalltraeger.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBeziehungFalltraeger.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBeziehungFalltraeger.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBeziehungFalltraeger.Properties.Appearance.Options.UseBackColor = true;
            this.edtBeziehungFalltraeger.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBeziehungFalltraeger.Properties.Appearance.Options.UseFont = true;
            this.edtBeziehungFalltraeger.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBeziehungFalltraeger.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBeziehungFalltraeger.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBeziehungFalltraeger.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBeziehungFalltraeger.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBeziehungFalltraeger.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBeziehungFalltraeger.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBeziehungFalltraeger.Properties.Name = "editBeziehung.Properties";
            this.edtBeziehungFalltraeger.Properties.NullText = "";
            this.edtBeziehungFalltraeger.Properties.ShowFooter = false;
            this.edtBeziehungFalltraeger.Properties.ShowHeader = false;
            this.edtBeziehungFalltraeger.Size = new System.Drawing.Size(281, 24);
            this.edtBeziehungFalltraeger.TabIndex = 2;
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
            this.colNeueVersNr.VisibleIndex = 9;
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
            // DlgNeuePerson
            //
            this.ClientSize = new System.Drawing.Size(707, 594);
            this.Controls.Add(this.edtBeziehungFalltraeger);
            this.Controls.Add(this.lblBeziehungFalltraeger);
            this.Name = "DlgNeuePerson";
            this.Load += new System.EventHandler(this.DlgNeuePerson_Load);
            this.Controls.SetChildIndex(this.tabPerson, 0);
            this.Controls.SetChildIndex(this.lblBeziehungFalltraeger, 0);
            this.Controls.SetChildIndex(this.edtBeziehungFalltraeger, 0);
            this.Controls.SetChildIndex(this.btnNeu, 0);
            this.Controls.SetChildIndex(this.btnAbbrechen, 0);
            this.tabPerson.ResumeLayout(false);
            this.tpgPersonSuchen.ResumeLayout(false);
            this.tpgPersonSuchen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRowCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdListe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNeueVersNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeziehungFalltraeger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeziehungFalltraeger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeziehungFalltraeger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Perform additional checks before creating new data entries
        /// </summary>
        protected override void Additional_Check()
        {
            if (DBUtil.IsEmpty(edtBeziehungFalltraeger.EditValue))
            {
                throw new KissInfoException(KissMsg.GetMLMessage("DlgNeuePerson", "BeziehungFalltraegerLeer", "Das Feld 'Beziehung zu Fallträger/-in' darf nicht leer bleiben!", KissMsgCode.MsgInfo));
            }

            if (tabPerson.SelectedTabIndex == 0)
            {
                //Prüfen, ob die neue Person die Fallträgerin selbst ist
                if (NewBaPersonID == this._falltraegerID)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage("DlgNeuePerson", "PersonIstFalltraeger", "Diese Person ist der/die Fallträger/-in!", KissMsgCode.MsgInfo));
                }

                //Prüfen, ob diese Person bereits im Klientensystem besteht
                Int32 count = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                        SELECT COUNT(*)
                        FROM dbo.BaPerson_Relation WITH (READUNCOMMITTED)
                        WHERE (BaPersonID_1 = {0} AND BaPersonID_2 = {1}) OR
                              (BaPersonID_1 = {1} AND BaPersonID_2 = {0})", NewBaPersonID, this._falltraegerID));

                if (count > 0)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage("DlgNeuePerson", "PersonImKlientensystem", "Diese Person gehört bereits zum Klientensystem", KissMsgCode.MsgInfo));
                }
            }
        }

        /// <summary>
        /// Perform additional work after creating new data entries
        /// </summary>
        protected override void Additional_Save()
        {
            try
            {
                //neue Person zu Klientensystem hinzufügen
                object baPersonID_1;
                object baPersonID_2;
                int baRelationID;

                if (Convert.ToInt32(edtBeziehungFalltraeger.EditValue) < 100)
                {
                    baPersonID_1 = NewBaPersonID;
                    baPersonID_2 = _falltraegerID;
                    baRelationID = Convert.ToInt32(edtBeziehungFalltraeger.EditValue);
                }
                else
                {
                    baPersonID_1 = _falltraegerID;
                    baPersonID_2 = NewBaPersonID;
                    baRelationID = Convert.ToInt32(edtBeziehungFalltraeger.EditValue) - 100;
                }

                // insert relation
                DBUtil.ExecSQLThrowingException(@"
                    INSERT INTO dbo.BaPerson_Relation (BaPersonID_1, BaPersonID_2, BaRelationID)
                    VALUES ({0}, {1}, {2});", baPersonID_1, baPersonID_2, baRelationID);

                // update person (do not show details by default for this person if person does not have leistungen)
                DBUtil.ExecSQL(@"
                    UPDATE dbo.BaPerson
                    SET ZeigeDetails = 0, Modifier = {1}, Modified = GetDate()
                    WHERE BaPersonID = {0} AND
                            NOT EXISTS(SELECT TOP 1 1
                                        FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                                        WHERE BaPersonID = {0});", NewBaPersonID, DBUtil.GetDBRowCreatorModifier());
            }
            catch (Exception ex)
            {
                throw new KissErrorException(KissMsg.GetMLMessage("DlgNeuePerson",
                                                                  "FehlerBeiErstellenPerson",
                                                                  "Es ist ein Fehler beim Erstellen der neuen Person aufgetreten.",
                                                                  KissMsgCode.MsgError),
                                             ex);
            }
        }

        private void DlgNeuePerson_Load(object sender, System.EventArgs e)
        {
            // init dropdown for relationship
            SqlQuery qryRelations = DBUtil.OpenSQL(@"
                SELECT Code = BaRelationID,
                       Text = dbo.fnGetMLTextByDefault(NameGenerisch1TID, {0}, NameGenerisch1)
                FROM dbo.BaRelation WITH (READUNCOMMITTED)

                UNION ALL

                SELECT Code = BaRelationID + 100,
                       Text = dbo.fnGetMLTextByDefault(NameGenerisch2TID, {0}, NameGenerisch2)
                FROM dbo.BaRelation WITH (READUNCOMMITTED)
                WHERE NameGenerisch1 <> NameGenerisch2

                ORDER BY 2;", Session.User.LanguageCode);

            // setup dropdown-list
            edtBeziehungFalltraeger.Properties.DataSource = qryRelations;
            edtBeziehungFalltraeger.Properties.DropDownRows = Math.Min(qryRelations.Count, 7);

            // set default value
            edtBeziehungFalltraeger.EditValue = 99; //Andere
        }

        #endregion
    }
}