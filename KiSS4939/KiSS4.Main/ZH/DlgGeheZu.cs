#region Header

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.832
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#endregion

using System;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Gui.Layout;

namespace KiSS4.Main.ZH
{
    public class DlgGeheZu : KiSS4.Gui.KissDialog
    {
        #region Fields

        private string Context = "SFP";
        private KiSS4.Gui.KissButton btnCancel;
        private KiSS4.Gui.KissButton btnGeheZu;
        private KiSS4.Gui.KissCalcEdit editAyEinzelzahlung;
        private KiSS4.Gui.KissCalcEdit editAyFinanzplan;
        private KiSS4.Gui.KissCalcEdit editFaFall;
        private KiSS4.Gui.KissCalcEdit editShEinzelzahlung;
        private KiSS4.Gui.KissCalcEdit editShFinanzplan;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KiSS4.Gui.KissLabel kissLabel8;
        private KiSS4.Gui.KissLabel lblValue;

        #endregion

        #region Constructors

        public DlgGeheZu()
        {
            this.InitializeComponent();

            //�berpr�fen, welche Module lizenziert sind und GUIs enabled/disablen.

            //Sozialhilfe
            bool isLicModuleS = KiSS4.Common.Utils.IsModuleLicensed("KiSS4.Sozialhilfe");
            if(!isLicModuleS)
            {
                this.editShFinanzplan.EditMode = EditModeType.ReadOnly;
                this.editShEinzelzahlung.EditMode = EditModeType.ReadOnly;  
            }
            
            //Asyl
            bool isLicModuleA = KiSS4.Common.Utils.IsModuleLicensed("KiSS4.Asyl");
            if(!isLicModuleA)
            {
                this.editAyEinzelzahlung.EditMode = EditModeType.ReadOnly;
                this.editAyFinanzplan.EditMode = EditModeType.ReadOnly;         
            }

            //Fallf�hrung
            bool isLicModuleF = KiSS4.Common.Utils.IsModuleLicensed("KiSS4.Fallfuehrung");
            if (!isLicModuleF)
            {
                this.editFaFall.EditMode = EditModeType.ReadOnly;       
            }            

          
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.editShFinanzplan = new KiSS4.Gui.KissCalcEdit();
            this.lblValue = new KiSS4.Gui.KissLabel();
            this.editShEinzelzahlung = new KiSS4.Gui.KissCalcEdit();
            this.editAyFinanzplan = new KiSS4.Gui.KissCalcEdit();
            this.editAyEinzelzahlung = new KiSS4.Gui.KissCalcEdit();
            this.editFaFall = new KiSS4.Gui.KissCalcEdit();
            this.btnCancel = new KiSS4.Gui.KissButton();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.btnGeheZu = new KiSS4.Gui.KissButton();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.kissLabel8 = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.editShFinanzplan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editShEinzelzahlung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAyFinanzplan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAyEinzelzahlung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFaFall.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).BeginInit();
            this.SuspendLayout();
            // 
            // editShFinanzplan
            // 
            this.editShFinanzplan.Location = new System.Drawing.Point(96, 65);
            this.editShFinanzplan.Name = "editShFinanzplan";
            this.editShFinanzplan.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editShFinanzplan.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editShFinanzplan.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editShFinanzplan.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editShFinanzplan.Properties.Appearance.Options.UseBackColor = true;
            this.editShFinanzplan.Properties.Appearance.Options.UseBorderColor = true;
            this.editShFinanzplan.Properties.Appearance.Options.UseFont = true;
            this.editShFinanzplan.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editShFinanzplan.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editShFinanzplan.Properties.Name = "editShFinanzplan.Properties";
            this.editShFinanzplan.Size = new System.Drawing.Size(88, 24);
            this.editShFinanzplan.TabIndex = 0;
            // 
            // lblValue
            // 
            this.lblValue.Location = new System.Drawing.Point(8, 65);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(80, 24);
            this.lblValue.TabIndex = 0;
            this.lblValue.Text = "Finanzplan Nr.";
            this.lblValue.UseCompatibleTextRendering = true;
            // 
            // editShEinzelzahlung
            // 
            this.editShEinzelzahlung.Location = new System.Drawing.Point(96, 95);
            this.editShEinzelzahlung.Name = "editShEinzelzahlung";
            this.editShEinzelzahlung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editShEinzelzahlung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editShEinzelzahlung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editShEinzelzahlung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editShEinzelzahlung.Properties.Appearance.Options.UseBackColor = true;
            this.editShEinzelzahlung.Properties.Appearance.Options.UseBorderColor = true;
            this.editShEinzelzahlung.Properties.Appearance.Options.UseFont = true;
            this.editShEinzelzahlung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editShEinzelzahlung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editShEinzelzahlung.Properties.Name = "editShEinzelzahlung.Properties";
            this.editShEinzelzahlung.Size = new System.Drawing.Size(88, 24);
            this.editShEinzelzahlung.TabIndex = 1;
            // 
            // editAyFinanzplan
            // 
            this.editAyFinanzplan.Location = new System.Drawing.Point(208, 64);
            this.editAyFinanzplan.Name = "editAyFinanzplan";
            this.editAyFinanzplan.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editAyFinanzplan.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editAyFinanzplan.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editAyFinanzplan.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editAyFinanzplan.Properties.Appearance.Options.UseBackColor = true;
            this.editAyFinanzplan.Properties.Appearance.Options.UseBorderColor = true;
            this.editAyFinanzplan.Properties.Appearance.Options.UseFont = true;
            this.editAyFinanzplan.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editAyFinanzplan.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editAyFinanzplan.Properties.Name = "editAyFinanzplan.Properties";
            this.editAyFinanzplan.Size = new System.Drawing.Size(88, 24);
            this.editAyFinanzplan.TabIndex = 2;
            // 
            // editAyEinzelzahlung
            // 
            this.editAyEinzelzahlung.Location = new System.Drawing.Point(208, 96);
            this.editAyEinzelzahlung.Name = "editAyEinzelzahlung";
            this.editAyEinzelzahlung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editAyEinzelzahlung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editAyEinzelzahlung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editAyEinzelzahlung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editAyEinzelzahlung.Properties.Appearance.Options.UseBackColor = true;
            this.editAyEinzelzahlung.Properties.Appearance.Options.UseBorderColor = true;
            this.editAyEinzelzahlung.Properties.Appearance.Options.UseFont = true;
            this.editAyEinzelzahlung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editAyEinzelzahlung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editAyEinzelzahlung.Properties.Name = "editAyEinzelzahlung.Properties";
            this.editAyEinzelzahlung.Size = new System.Drawing.Size(88, 24);
            this.editAyEinzelzahlung.TabIndex = 3;
            // 
            // editFaFall
            // 
            this.editFaFall.Location = new System.Drawing.Point(96, 160);
            this.editFaFall.Name = "editFaFall";
            this.editFaFall.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editFaFall.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editFaFall.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editFaFall.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editFaFall.Properties.Appearance.Options.UseBackColor = true;
            this.editFaFall.Properties.Appearance.Options.UseBorderColor = true;
            this.editFaFall.Properties.Appearance.Options.UseFont = true;
            this.editFaFall.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editFaFall.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editFaFall.Properties.Name = "editFaFall.Properties";
            this.editFaFall.Size = new System.Drawing.Size(88, 24);
            this.editFaFall.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(112, 208);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 24);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Abbruch";
            this.btnCancel.UseCompatibleTextRendering = true;
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(8, 95);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(88, 24);
            this.kissLabel1.TabIndex = 5;
            this.kissLabel1.Text = "Einzelzahlung Nr.";
            this.kissLabel1.UseCompatibleTextRendering = true;
            // 
            // btnGeheZu
            // 
            this.btnGeheZu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeheZu.Location = new System.Drawing.Point(208, 208);
            this.btnGeheZu.Name = "btnGeheZu";
            this.btnGeheZu.Size = new System.Drawing.Size(88, 24);
            this.btnGeheZu.TabIndex = 6;
            this.btnGeheZu.Text = "Gehe zu";
            this.btnGeheZu.UseCompatibleTextRendering = true;
            this.btnGeheZu.UseVisualStyleBackColor = false;
            this.btnGeheZu.Click += new System.EventHandler(this.btnGeheZu_Click);
            // 
            // kissLabel4
            // 
            this.kissLabel4.Location = new System.Drawing.Point(8, 160);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(56, 24);
            this.kissLabel4.TabIndex = 11;
            this.kissLabel4.Text = "Fall Nr.";
            this.kissLabel4.UseCompatibleTextRendering = true;
            // 
            // kissLabel5
            // 
            this.kissLabel5.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel5.Location = new System.Drawing.Point(8, 8);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(144, 16);
            this.kissLabel5.TabIndex = 13;
            this.kissLabel5.Text = "Direktsprung zu ...";
            this.kissLabel5.UseCompatibleTextRendering = true;
            // 
            // kissLabel6
            // 
            this.kissLabel6.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel6.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel6.Location = new System.Drawing.Point(96, 40);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(88, 16);
            this.kissLabel6.TabIndex = 14;
            this.kissLabel6.Text = "Sozialhilfe";
            this.kissLabel6.UseCompatibleTextRendering = true;
            // 
            // kissLabel7
            // 
            this.kissLabel7.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel7.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel7.Location = new System.Drawing.Point(96, 135);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(88, 16);
            this.kissLabel7.TabIndex = 15;
            this.kissLabel7.Text = "Fallf�hrung";
            this.kissLabel7.UseCompatibleTextRendering = true;
            // 
            // kissLabel8
            // 
            this.kissLabel8.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel8.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel8.Location = new System.Drawing.Point(208, 40);
            this.kissLabel8.Name = "kissLabel8";
            this.kissLabel8.Size = new System.Drawing.Size(64, 16);
            this.kissLabel8.TabIndex = 16;
            this.kissLabel8.Text = "Asyl";
            this.kissLabel8.UseCompatibleTextRendering = true;
            // 
            // DlgGeheZu
            // 
            this.AcceptButton = this.btnGeheZu;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(306, 240);
            this.Controls.Add(this.kissLabel8);
            this.Controls.Add(this.kissLabel7);
            this.Controls.Add(this.kissLabel6);
            this.Controls.Add(this.kissLabel5);
            this.Controls.Add(this.kissLabel4);
            this.Controls.Add(this.btnGeheZu);
            this.Controls.Add(this.kissLabel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.editFaFall);
            this.Controls.Add(this.editAyEinzelzahlung);
            this.Controls.Add(this.editAyFinanzplan);
            this.Controls.Add(this.editShEinzelzahlung);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.editShFinanzplan);
            this.Name = "DlgGeheZu";
            this.Text = "Gehe zu ...";
            this.Activated += new System.EventHandler(this.DlgGeheZu_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.editShFinanzplan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editShEinzelzahlung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAyFinanzplan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAyEinzelzahlung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFaFall.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region Protected Methods

        protected override void OnGettingLayout(KissLayoutEventArgs e)
        {
            base.OnGettingLayout (e);

            KissControlLayout cl1 = new KissControlLayout("Context");
            e.Layout.ControlLayouts.Add(cl1);
            SimpleProperty p1 = new SimpleProperty("Value", Context);
            try { cl1.Properties.Add(p1); }	catch (Exception ex) { e.Errors.Add(new LayoutError(p1, ex)); }
        }

        protected override void OnSettingLayout(KissLayoutEventArgs e)
        {
            base.OnSettingLayout (e);

            KissControlLayout cl1;
            SimpleProperty p1;

            try { cl1 = e.Layout.ControlLayouts["Context"]; }	catch { cl1 = null; }

            if (cl1 != null) {
                try {
                    p1 = (SimpleProperty) cl1.Properties["Value"];
                    try { this.Context = (string)p1.Value; }
                    catch (Exception ex) { e.Errors.Add(new LayoutError(p1, ex)); }
                }
                catch {}
            }
        }

        #endregion

        #region Private Methods

        private void DlgGeheZu_Activated(object sender, System.EventArgs e)
        {
            SetFocusToContext();
        }

        private void SetFocusToContext()
        {
            if (DBUtil.IsEmpty(this.Context)) return;

            if (this.Context == "SFP")	editShFinanzplan.Focus();
            if (this.Context == "SEZ")	editShEinzelzahlung.Focus();
            if (this.Context == "AFP")	editAyFinanzplan.Focus();
            if (this.Context == "AEZ")	editAyEinzelzahlung.Focus();
            if (this.Context == "FAL")	editFaFall.Focus();
        }

        private void btnGeheZu_Click(object sender, System.EventArgs e)
        {
            bool		 ItemFound  = true;
            KissMainForm main		= (KissMainForm)Session.MainForm;
            int			 Key		= 0;
            string		 Target1	= null;
            string		 Target2	= null;

            try
            {
                if (!DBUtil.IsEmpty(editShFinanzplan.EditValue))
                {
                    Context   = "SFP";
                    Key       = Convert.ToInt32(editShFinanzplan.EditValue);
                    Target1   = "Der Sozialhilfe-Finanzplan";
                    Target2   = "des Sozialhilfe-Finanzplans";
                    ItemFound = main.ShowItem(ModulID.S, Context, Key);
                }

                if (!DBUtil.IsEmpty(editShEinzelzahlung.EditValue))
                {
                    Context   = "SEZ";
                    Key       = Convert.ToInt32(editShEinzelzahlung.EditValue);
                    Target1   = "Die Sozialhilfe-Einzelzahlung";
                    Target2   = "der Sozialhilfe-Einzelzahlung";
                    ItemFound = main.ShowItem(ModulID.S, Context, Key);
                }

                if (!DBUtil.IsEmpty(editAyFinanzplan.EditValue))
                {
                    Context   = "AFP";
                    Key       = Convert.ToInt32(editAyFinanzplan.EditValue);
                    Target1   = "Der Asyl-Finanzplan";
                    Target2   = "des Asyl-Finanzplans";
                    ItemFound = main.ShowItem(ModulID.A, Context, Key);
                }

                if (!DBUtil.IsEmpty(editAyEinzelzahlung.EditValue))
                {
                    Context   = "AEZ";
                    Key       = Convert.ToInt32(editAyEinzelzahlung.EditValue);
                    Target1   = "Die Asyl-Einzelzahlung";
                    Target2   = "der Asyl-Einzelzahlung";
                    ItemFound = main.ShowItem(ModulID.A, Context, Key);
                }

                if (!DBUtil.IsEmpty(editFaFall.EditValue))
                {
                    Context   = "FAL";
                    Key       = Convert.ToInt32(editFaFall.EditValue);
                    Target1   = "Die Fallf�hrung";
                    Target2   = "der Fallf�hrung";
                    ItemFound = main.ShowItem(ModulID.F, Context, Key);
                }

                if (ItemFound)
                    this.Close();
                else {
                    KissMsg.ShowInfo("DlgGeheZu", "NrNichtGefunden", "{0} mit der Nummer {1} konnte nicht gefunden werden.", 0, 0, Target1, Key);
                    SetFocusToContext();
                }

            } catch (Exception ex) {
                KissMsg.ShowError("DlgGeheZu", "FehlerBeiAufrufNummer", "Beim beim Aufruf {0} mit der Nummer {1} ist ein Fehler aufgetreten.", null, ex, 0, 0, Target2, Key);
            }
        }

        #endregion
    }
}