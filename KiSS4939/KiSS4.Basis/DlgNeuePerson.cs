using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Messages;

namespace KiSS4.Basis
{
    public class DlgNeuePerson : KiSS4.Common.DlgPersonSucheNeu
    {
        #region Fields

        #region Private Fields

        private KiSS4.Gui.KissLookUpEdit edtBaRelationID;
        private int falltraegerID;
        private KiSS4.Gui.KissLabel lblBaRelationID;

        #endregion

        #endregion

        #region Constructors

        public DlgNeuePerson(int FalltraegerID)
            : this()
        {
            this.falltraegerID = FalltraegerID;
        }

        public DlgNeuePerson()
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblBaRelationID = new KiSS4.Gui.KissLabel();
            this.edtBaRelationID = new KiSS4.Gui.KissLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).BeginInit();
            this.tabPerson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaRelationID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaRelationID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaRelationID.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(585, 534);
            //
            // btnNeu
            //
            this.btnNeu.Location = new System.Drawing.Point(483, 534);
            this.btnNeu.Text = "Neue Person";
            //
            // grdPerson
            //
            //
            //
            //
            this.grdPerson.EmbeddedNavigator.Name = "grdPerson.EmbeddedNavigator";
            //
            // grvPerson
            //
            this.grvPerson.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvPerson.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPerson.Appearance.Empty.Options.UseBackColor = true;
            this.grvPerson.Appearance.Empty.Options.UseFont = true;
            this.grvPerson.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvPerson.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPerson.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvPerson.Appearance.EvenRow.Options.UseFont = true;
            this.grvPerson.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvPerson.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPerson.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvPerson.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvPerson.Appearance.FocusedCell.Options.UseFont = true;
            this.grvPerson.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvPerson.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvPerson.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPerson.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvPerson.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvPerson.Appearance.FocusedRow.Options.UseFont = true;
            this.grvPerson.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvPerson.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPerson.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvPerson.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPerson.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvPerson.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPerson.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvPerson.Appearance.GroupRow.Options.UseFont = true;
            this.grvPerson.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvPerson.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvPerson.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvPerson.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvPerson.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvPerson.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvPerson.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvPerson.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvPerson.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPerson.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPerson.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvPerson.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvPerson.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvPerson.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvPerson.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvPerson.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvPerson.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPerson.Appearance.OddRow.Options.UseBackColor = true;
            this.grvPerson.Appearance.OddRow.Options.UseFont = true;
            this.grvPerson.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvPerson.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPerson.Appearance.Row.Options.UseBackColor = true;
            this.grvPerson.Appearance.Row.Options.UseFont = true;
            this.grvPerson.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvPerson.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPerson.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvPerson.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvPerson.Appearance.SelectedRow.Options.UseFont = true;
            this.grvPerson.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvPerson.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvPerson.Appearance.VertLine.Options.UseBackColor = true;
            this.grvPerson.OptionsBehavior.Editable = false;
            this.grvPerson.OptionsCustomization.AllowFilter = false;
            this.grvPerson.OptionsFilter.AllowFilterEditor = false;
            this.grvPerson.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvPerson.OptionsMenu.EnableColumnMenu = false;
            this.grvPerson.OptionsNavigation.AutoFocusNewRow = true;
            this.grvPerson.OptionsNavigation.UseTabKey = false;
            this.grvPerson.OptionsView.ColumnAutoWidth = false;
            this.grvPerson.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvPerson.OptionsView.ShowGroupPanel = false;
            this.grvPerson.OptionsView.ShowIndicator = false;
            //
            // qryBaPerson
            //
            this.qryBaPerson.SelectStatement = null;
            //
            // lblBaRelationID
            //
            this.lblBaRelationID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBaRelationID.Location = new System.Drawing.Point(261, 504);
            this.lblBaRelationID.Name = "lblBaRelationID";
            this.lblBaRelationID.Size = new System.Drawing.Size(148, 24);
            this.lblBaRelationID.TabIndex = 1;
            this.lblBaRelationID.Text = "Beziehung zu Fallträger/-in";
            this.lblBaRelationID.UseCompatibleTextRendering = true;
            //
            // edtBaRelationID
            //
            this.edtBaRelationID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBaRelationID.Location = new System.Drawing.Point(415, 504);
            this.edtBaRelationID.LOVName = "BaLand";
            this.edtBaRelationID.Name = "edtBaRelationID";
            this.edtBaRelationID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaRelationID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaRelationID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaRelationID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaRelationID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaRelationID.Properties.Appearance.Options.UseFont = true;
            this.edtBaRelationID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBaRelationID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaRelationID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBaRelationID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBaRelationID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBaRelationID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBaRelationID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaRelationID.Properties.NullText = "";
            this.edtBaRelationID.Properties.ShowFooter = false;
            this.edtBaRelationID.Properties.ShowHeader = false;
            this.edtBaRelationID.Size = new System.Drawing.Size(270, 24);
            this.edtBaRelationID.TabIndex = 2;
            //
            // DlgNeuePerson
            //
            this.ClientSize = new System.Drawing.Size(692, 579);
            this.Controls.Add(this.edtBaRelationID);
            this.Controls.Add(this.lblBaRelationID);
            this.Name = "DlgNeuePerson";
            this.Load += new System.EventHandler(this.DlgNeuePerson_Load);
            this.Controls.SetChildIndex(this.tabPerson, 0);
            this.Controls.SetChildIndex(this.lblBaRelationID, 0);
            this.Controls.SetChildIndex(this.edtBaRelationID, 0);
            this.Controls.SetChildIndex(this.btnNeu, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).EndInit();
            this.tabPerson.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblBaRelationID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaRelationID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaRelationID)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        #region EventHandlers

        protected override void Additional_Check()
        {
            if (DBUtil.IsEmpty(edtBaRelationID.EditValue))
                throw new KissInfoException(KissMsg.GetMLMessage("DlgNeuePerson", "BeziehungFalltraegerLeer", "Das Feld 'Beziehung zu Fallträger/-in' darf nicht leer bleiben!", KissMsgCode.MsgInfo));

            if (tabPerson.SelectedTabIndex == 0)
            {
                //Prüfen, ob die neue Person die Fallträgerin selbst ist
                if (NewBaPersonID == this.falltraegerID)
                    throw new KissInfoException(KissMsg.GetMLMessage("DlgNeuePerson", "PersonIstFalltraeger", "Diese Person ist der/die Fallträger/-in!", KissMsgCode.MsgInfo));

                //Prüfen, ob diese Person bereits im Klientensystem besteht
                int Count = (int)DBUtil.ExecuteScalarSQL(@"
                    SELECT count(*) FROM dbo.BaPerson_Relation WITH (READUNCOMMITTED)
                    WHERE (BaPersonID_1 = {0} and BaPersonID_2 = {1}) OR
                          (BaPersonID_1 = {1} and BaPersonID_2 = {0})",
                    NewBaPersonID,
                    this.falltraegerID);

                if (Count > 0)
                    throw new KissInfoException(KissMsg.GetMLMessage("DlgNeuePerson", "PersonImKlientensystem", "Diese Person gehört bereits zum Klientensystem", KissMsgCode.MsgInfo));
            }
        }

        protected override void Additional_Save()
        {
            try
            {
                //neue Person zu Klientensystem hinzufügen
                object BaPersonID_1;
                object BaPersonID_2;
                int BaPersonRelationID;

                if ((int)edtBaRelationID.EditValue < 100)
                {
                    BaPersonID_1 = NewBaPersonID;
                    BaPersonID_2 = this.falltraegerID;
                    BaPersonRelationID = (int)edtBaRelationID.EditValue;
                }
                else
                {
                    BaPersonID_1 = this.falltraegerID;
                    BaPersonID_2 = NewBaPersonID;
                    BaPersonRelationID = (int)edtBaRelationID.EditValue - 100;
                }

                DBUtil.ExecSQLThrowingException(@"
                    INSERT INTO BaPerson_Relation (BaPersonID_1, BaPersonID_2, BaRelationID)
                      VALUES ({0}, {1}, {2})",
                    BaPersonID_1, BaPersonID_2, BaPersonRelationID);

                DBUtil.ExecSQL(@"EXEC dbo.spKbKostenstelleAnlegen {0}", NewBaPersonID);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                throw new KissErrorException(KissMsg.GetMLMessage("DlgNeuePerson", "FehlerBeiAnlegenPerson", "Beim Anlegen der neuen Person ist ein Fehler aufgetreten.", KissMsgCode.MsgError), ex);
            }
        }

        private void DlgNeuePerson_Load(object sender, System.EventArgs e)
        {
            edtBaRelationID.LoadQuery(DBUtil.OpenSQL(@"
                SELECT Code = BaRelationID, Text = NameGenerisch1 FROM dbo.BaRelation WITH (READUNCOMMITTED)
                UNION ALL
                SELECT Code = BaRelationID + 100, Text = NameGenerisch2 FROM dbo.BaRelation WITH (READUNCOMMITTED)
                WHERE NameGenerisch1 <> NameGenerisch2
                ORDER BY 2"));
            edtBaRelationID.EditValue = 29; //Unbekannt
        }

        #endregion
    }
}