using System;
using System.Data;
using System.Drawing;

using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Common;

/*
 * ck: Bei IBE korrekt CtlBaArbeit, in Bern falsch CtlArbeit! --> umbenennen!
 * deshalb im seperatem Namespace...
 */
namespace KiSS4.Basis.IBE
{
    public class CtlBaArbeit : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Static Fields

        private static string btnDlgAbbrechen = KissMsg.GetMLMessage(CLASSNAME, "BtnAbbrechen", "&Abbrechen");

        #endregion

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "CtlBaArbeit";

        #endregion

        #region Private Fields

        private int _baPersonId = 0;
        private KiSS4.Gui.KissLookUpEdit cboAusgesteuert;
        private KiSS4.Gui.KissButtonEdit cboBeruf;
        private KiSS4.Gui.KissLookUpEdit cboBranche;
        private KiSS4.Gui.KissButtonEdit cboErlernterBeruf;
        private KiSS4.Gui.KissLookUpEdit cboErwerbssituation1;
        private KiSS4.Gui.KissLookUpEdit cboErwerbssituation2;
        private KiSS4.Gui.KissLookUpEdit cboErwerbssituation3;
        private KiSS4.Gui.KissLookUpEdit cboErwerbssituation4;
        private KiSS4.Gui.KissLookUpEdit cboHoechsteAusbildung;
        private KiSS4.Gui.KissLookUpEdit cboLetzteAbgebrocheneAusbildung;
        private KiSS4.Gui.KissLookUpEdit cboTeilZeitArbeitGrund1;
        private KiSS4.Gui.KissLookUpEdit cboTeilZeitArbeitGrund2;
        private KiSS4.Gui.KissCheckEdit chkUnregelmaessig;
        private DevExpress.XtraGrid.Columns.GridColumn colArbeitgeber;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumbis;
        private DevExpress.XtraGrid.Columns.GridColumn colPensum;
        private DevExpress.XtraGrid.Columns.GridColumn colTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colVon;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissDateEdit dtpAusgesteuertSeit;
        private KiSS4.Gui.KissDateEdit dtpStempelnSeit;
        private KiSS4.Gui.KissCalcEdit editArbeitsLosXMal;
        private KiSS4.Gui.KissRTFEdit editBemerkungRTF;
        private KiSS4.Gui.KissLookUpEdit edtArbeitTyp;
        private KiSS4.Gui.KissButtonEdit edtArbeitgeber;
        private KiSS4.Gui.KissLookUpEdit edtBeschaeftigungsGradCode;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissButtonEdit edtInstitution;
        private KiSS4.Gui.KissLookUpEdit edtPensumCode;
        private KiSS4.Gui.KissGrid grdArbeit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissCheckEdit kissCheckEdit1;
        private KiSS4.Gui.KissRTFEdit kissRTFEdit1;
        private KiSS4.Gui.KissLabel lbl1;
        private KiSS4.Gui.KissLabel lbl2;
        private KiSS4.Gui.KissLabel lbl3;
        private KiSS4.Gui.KissLabel lbl4;
        private KiSS4.Gui.KissLabel lblArbeit;
        private KiSS4.Gui.KissLabel lblArbeitTyp;
        private KiSS4.Gui.KissLabel lblArbeitgeber;
        private KiSS4.Gui.KissLabel lblArbeitslos;
        private KiSS4.Gui.KissLabel lblAusbildung;
        private KiSS4.Gui.KissLabel lblAusgesteuert;
        private KiSS4.Gui.KissLabel lblAusgesteuertSeit;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblBemerkung2;
        private KiSS4.Gui.KissLabel lblBeschGrad;
        private KiSS4.Gui.KissLabel lblBis;
        private KiSS4.Gui.KissLabel lblBranche;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblErlerntBeruf;
        private KiSS4.Gui.KissLabel lblErwerbs;
        private KiSS4.Gui.KissLabel lblInstitution;
        private KiSS4.Gui.KissLabel lblLetzteAusbildung;
        private KiSS4.Gui.KissLabel lblLetzteT;
        private KiSS4.Gui.KissLabel lblPensumCode;
        private KiSS4.Gui.KissLabel lblStempeln;
        private KiSS4.Gui.KissLabel lblTeil1;
        private KiSS4.Gui.KissLabel lblTeil2;
        private KiSS4.Gui.KissLabel lblTeilzeit;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblx;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryBaArbeit;
        private DevExpress.XtraGrid.Columns.GridColumn colSprachniveau;
        private KissLookUpEdit edtBaSprachniveauCode;
        private KissLabel lblBaSprachniveauCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkung;
        private KiSS4.DB.SqlQuery qryBaArbeitAusbildung;

        #endregion

        #endregion

        #region Constructors

        public CtlBaArbeit()
        {
            InitializeComponent();

            Init(null, null, -1);
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject22 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject21 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject20 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject19 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject18 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject17 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject16 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBaArbeit));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.components = new System.ComponentModel.Container();
            this.cboErwerbssituation1 = new KiSS4.Gui.KissLookUpEdit();
            this.qryBaArbeitAusbildung = new KiSS4.DB.SqlQuery();
            this.cboErwerbssituation2 = new KiSS4.Gui.KissLookUpEdit();
            this.cboErwerbssituation3 = new KiSS4.Gui.KissLookUpEdit();
            this.cboErwerbssituation4 = new KiSS4.Gui.KissLookUpEdit();
            this.cboTeilZeitArbeitGrund1 = new KiSS4.Gui.KissLookUpEdit();
            this.cboTeilZeitArbeitGrund2 = new KiSS4.Gui.KissLookUpEdit();
            this.cboBranche = new KiSS4.Gui.KissLookUpEdit();
            this.cboErlernterBeruf = new KiSS4.Gui.KissButtonEdit();
            this.cboBeruf = new KiSS4.Gui.KissButtonEdit();
            this.edtArbeitgeber = new KiSS4.Gui.KissButtonEdit();
            this.cboHoechsteAusbildung = new KiSS4.Gui.KissLookUpEdit();
            this.cboLetzteAbgebrocheneAusbildung = new KiSS4.Gui.KissLookUpEdit();
            this.chkUnregelmaessig = new KiSS4.Gui.KissCheckEdit();
            this.dtpStempelnSeit = new KiSS4.Gui.KissDateEdit();
            this.cboAusgesteuert = new KiSS4.Gui.KissLookUpEdit();
            this.dtpAusgesteuertSeit = new KiSS4.Gui.KissDateEdit();
            this.editArbeitsLosXMal = new KiSS4.Gui.KissCalcEdit();
            this.editBemerkungRTF = new KiSS4.Gui.KissRTFEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.lblTeilzeit = new KiSS4.Gui.KissLabel();
            this.lblErwerbs = new KiSS4.Gui.KissLabel();
            this.lbl3 = new KiSS4.Gui.KissLabel();
            this.lbl2 = new KiSS4.Gui.KissLabel();
            this.lbl1 = new KiSS4.Gui.KissLabel();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.lblTeil1 = new KiSS4.Gui.KissLabel();
            this.lblTeil2 = new KiSS4.Gui.KissLabel();
            this.lblStempeln = new KiSS4.Gui.KissLabel();
            this.lblArbeitslos = new KiSS4.Gui.KissLabel();
            this.lblAusgesteuertSeit = new KiSS4.Gui.KissLabel();
            this.lblAusgesteuert = new KiSS4.Gui.KissLabel();
            this.lblLetzteAusbildung = new KiSS4.Gui.KissLabel();
            this.lblAusbildung = new KiSS4.Gui.KissLabel();
            this.lblArbeitgeber = new KiSS4.Gui.KissLabel();
            this.lblLetzteT = new KiSS4.Gui.KissLabel();
            this.lblErlerntBeruf = new KiSS4.Gui.KissLabel();
            this.lblBranche = new KiSS4.Gui.KissLabel();
            this.lbl4 = new KiSS4.Gui.KissLabel();
            this.lblx = new KiSS4.Gui.KissLabel();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.qryBaArbeit = new KiSS4.DB.SqlQuery();
            this.lblBis = new KiSS4.Gui.KissLabel();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblArbeitTyp = new KiSS4.Gui.KissLabel();
            this.edtArbeitTyp = new KiSS4.Gui.KissLookUpEdit();
            this.lblBeschGrad = new KiSS4.Gui.KissLabel();
            this.edtBeschaeftigungsGradCode = new KiSS4.Gui.KissLookUpEdit();
            this.kissCheckEdit1 = new KiSS4.Gui.KissCheckEdit();
            this.grdArbeit = new KiSS4.Gui.KissGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumbis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArbeitgeber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPensum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSprachniveau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblArbeit = new KiSS4.Gui.KissLabel();
            this.lblInstitution = new KiSS4.Gui.KissLabel();
            this.edtInstitution = new KiSS4.Gui.KissButtonEdit();
            this.lblBemerkung2 = new KiSS4.Gui.KissLabel();
            this.kissRTFEdit1 = new KiSS4.Gui.KissRTFEdit();
            this.lblPensumCode = new KiSS4.Gui.KissLabel();
            this.edtPensumCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblBaSprachniveauCode = new KiSS4.Gui.KissLabel();
            this.edtBaSprachniveauCode = new KiSS4.Gui.KissLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaArbeitAusbildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTeilZeitArbeitGrund1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTeilZeitArbeitGrund1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTeilZeitArbeitGrund2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTeilZeitArbeitGrund2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBranche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBranche.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErlernterBeruf.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBeruf.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArbeitgeber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboHoechsteAusbildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboHoechsteAusbildung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLetzteAbgebrocheneAusbildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLetzteAbgebrocheneAusbildung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUnregelmaessig.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStempelnSeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAusgesteuert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAusgesteuert.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAusgesteuertSeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editArbeitsLosXMal.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTeilzeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErwerbs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTeil1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTeil2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStempeln)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArbeitslos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusgesteuertSeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusgesteuert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLetzteAusbildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusbildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArbeitgeber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLetzteT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErlerntBeruf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBranche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaArbeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArbeitTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArbeitTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArbeitTyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeschGrad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeschaeftigungsGradCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeschaeftigungsGradCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissCheckEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdArbeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArbeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInstitution.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPensumCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPensumCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPensumCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaSprachniveauCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaSprachniveauCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaSprachniveauCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cboErwerbssituation1
            // 
            this.cboErwerbssituation1.DataMember = "ErwerbssituationStatus1Code";
            this.cboErwerbssituation1.DataSource = this.qryBaArbeitAusbildung;
            this.cboErwerbssituation1.Location = new System.Drawing.Point(120, 41);
            this.cboErwerbssituation1.LOVName = "Erwerbssituation";
            this.cboErwerbssituation1.Name = "cboErwerbssituation1";
            this.cboErwerbssituation1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboErwerbssituation1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboErwerbssituation1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboErwerbssituation1.Properties.Appearance.Options.UseBackColor = true;
            this.cboErwerbssituation1.Properties.Appearance.Options.UseBorderColor = true;
            this.cboErwerbssituation1.Properties.Appearance.Options.UseFont = true;
            this.cboErwerbssituation1.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboErwerbssituation1.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboErwerbssituation1.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboErwerbssituation1.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboErwerbssituation1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject22.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject22.Options.UseBackColor = true;
            this.cboErwerbssituation1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject22)});
            this.cboErwerbssituation1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboErwerbssituation1.Properties.NullText = "";
            this.cboErwerbssituation1.Properties.ShowFooter = false;
            this.cboErwerbssituation1.Properties.ShowHeader = false;
            this.cboErwerbssituation1.Size = new System.Drawing.Size(355, 24);
            this.cboErwerbssituation1.TabIndex = 0;
            // 
            // qryBaArbeitAusbildung
            // 
            this.qryBaArbeitAusbildung.HostControl = this;
            this.qryBaArbeitAusbildung.SelectStatement = resources.GetString("qryBaArbeitAusbildung.SelectStatement");
            this.qryBaArbeitAusbildung.TableName = "BaArbeitAusbildung";
            this.qryBaArbeitAusbildung.AfterInsert += new System.EventHandler(this.qryBaArbeitAusbildung_AfterInsert);
            this.qryBaArbeitAusbildung.BeforePost += new System.EventHandler(this.qryBaArbeitAusbildung_BeforePost);
            // 
            // cboErwerbssituation2
            // 
            this.cboErwerbssituation2.DataMember = "ErwerbssituationStatus2Code";
            this.cboErwerbssituation2.DataSource = this.qryBaArbeitAusbildung;
            this.cboErwerbssituation2.Location = new System.Drawing.Point(120, 63);
            this.cboErwerbssituation2.LOVName = "Erwerbssituation";
            this.cboErwerbssituation2.Name = "cboErwerbssituation2";
            this.cboErwerbssituation2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboErwerbssituation2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboErwerbssituation2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboErwerbssituation2.Properties.Appearance.Options.UseBackColor = true;
            this.cboErwerbssituation2.Properties.Appearance.Options.UseBorderColor = true;
            this.cboErwerbssituation2.Properties.Appearance.Options.UseFont = true;
            this.cboErwerbssituation2.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboErwerbssituation2.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboErwerbssituation2.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboErwerbssituation2.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboErwerbssituation2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject21.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject21.Options.UseBackColor = true;
            this.cboErwerbssituation2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject21)});
            this.cboErwerbssituation2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboErwerbssituation2.Properties.NullText = "";
            this.cboErwerbssituation2.Properties.ShowFooter = false;
            this.cboErwerbssituation2.Properties.ShowHeader = false;
            this.cboErwerbssituation2.Size = new System.Drawing.Size(355, 24);
            this.cboErwerbssituation2.TabIndex = 1;
            // 
            // cboErwerbssituation3
            // 
            this.cboErwerbssituation3.DataMember = "ErwerbssituationStatus3Code";
            this.cboErwerbssituation3.DataSource = this.qryBaArbeitAusbildung;
            this.cboErwerbssituation3.Location = new System.Drawing.Point(120, 86);
            this.cboErwerbssituation3.LOVName = "Erwerbssituation";
            this.cboErwerbssituation3.Name = "cboErwerbssituation3";
            this.cboErwerbssituation3.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboErwerbssituation3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboErwerbssituation3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboErwerbssituation3.Properties.Appearance.Options.UseBackColor = true;
            this.cboErwerbssituation3.Properties.Appearance.Options.UseBorderColor = true;
            this.cboErwerbssituation3.Properties.Appearance.Options.UseFont = true;
            this.cboErwerbssituation3.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboErwerbssituation3.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboErwerbssituation3.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboErwerbssituation3.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboErwerbssituation3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject20.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject20.Options.UseBackColor = true;
            this.cboErwerbssituation3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject20)});
            this.cboErwerbssituation3.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboErwerbssituation3.Properties.NullText = "";
            this.cboErwerbssituation3.Properties.ShowFooter = false;
            this.cboErwerbssituation3.Properties.ShowHeader = false;
            this.cboErwerbssituation3.Size = new System.Drawing.Size(355, 24);
            this.cboErwerbssituation3.TabIndex = 2;
            // 
            // cboErwerbssituation4
            // 
            this.cboErwerbssituation4.DataMember = "ErwerbssituationStatus4Code";
            this.cboErwerbssituation4.DataSource = this.qryBaArbeitAusbildung;
            this.cboErwerbssituation4.Location = new System.Drawing.Point(120, 109);
            this.cboErwerbssituation4.LOVName = "Erwerbssituation";
            this.cboErwerbssituation4.Name = "cboErwerbssituation4";
            this.cboErwerbssituation4.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboErwerbssituation4.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboErwerbssituation4.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboErwerbssituation4.Properties.Appearance.Options.UseBackColor = true;
            this.cboErwerbssituation4.Properties.Appearance.Options.UseBorderColor = true;
            this.cboErwerbssituation4.Properties.Appearance.Options.UseFont = true;
            this.cboErwerbssituation4.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboErwerbssituation4.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboErwerbssituation4.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboErwerbssituation4.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboErwerbssituation4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject19.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject19.Options.UseBackColor = true;
            this.cboErwerbssituation4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject19)});
            this.cboErwerbssituation4.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboErwerbssituation4.Properties.NullText = "";
            this.cboErwerbssituation4.Properties.ShowFooter = false;
            this.cboErwerbssituation4.Properties.ShowHeader = false;
            this.cboErwerbssituation4.Size = new System.Drawing.Size(355, 24);
            this.cboErwerbssituation4.TabIndex = 3;
            // 
            // cboTeilZeitArbeitGrund1
            // 
            this.cboTeilZeitArbeitGrund1.DataMember = "GrundTeilzeitarbeit1Code";
            this.cboTeilZeitArbeitGrund1.DataSource = this.qryBaArbeitAusbildung;
            this.cboTeilZeitArbeitGrund1.Location = new System.Drawing.Point(590, 70);
            this.cboTeilZeitArbeitGrund1.LOVName = "Grundteilzeit";
            this.cboTeilZeitArbeitGrund1.Name = "cboTeilZeitArbeitGrund1";
            this.cboTeilZeitArbeitGrund1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboTeilZeitArbeitGrund1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboTeilZeitArbeitGrund1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboTeilZeitArbeitGrund1.Properties.Appearance.Options.UseBackColor = true;
            this.cboTeilZeitArbeitGrund1.Properties.Appearance.Options.UseBorderColor = true;
            this.cboTeilZeitArbeitGrund1.Properties.Appearance.Options.UseFont = true;
            this.cboTeilZeitArbeitGrund1.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboTeilZeitArbeitGrund1.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboTeilZeitArbeitGrund1.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboTeilZeitArbeitGrund1.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboTeilZeitArbeitGrund1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject18.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject18.Options.UseBackColor = true;
            this.cboTeilZeitArbeitGrund1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject18)});
            this.cboTeilZeitArbeitGrund1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboTeilZeitArbeitGrund1.Properties.NullText = "";
            this.cboTeilZeitArbeitGrund1.Properties.ShowFooter = false;
            this.cboTeilZeitArbeitGrund1.Properties.ShowHeader = false;
            this.cboTeilZeitArbeitGrund1.Size = new System.Drawing.Size(250, 24);
            this.cboTeilZeitArbeitGrund1.TabIndex = 5;
            // 
            // cboTeilZeitArbeitGrund2
            // 
            this.cboTeilZeitArbeitGrund2.DataMember = "GrundTeilzeitarbeit2Code";
            this.cboTeilZeitArbeitGrund2.DataSource = this.qryBaArbeitAusbildung;
            this.cboTeilZeitArbeitGrund2.Location = new System.Drawing.Point(590, 93);
            this.cboTeilZeitArbeitGrund2.LOVName = "Grundteilzeit";
            this.cboTeilZeitArbeitGrund2.Name = "cboTeilZeitArbeitGrund2";
            this.cboTeilZeitArbeitGrund2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboTeilZeitArbeitGrund2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboTeilZeitArbeitGrund2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboTeilZeitArbeitGrund2.Properties.Appearance.Options.UseBackColor = true;
            this.cboTeilZeitArbeitGrund2.Properties.Appearance.Options.UseBorderColor = true;
            this.cboTeilZeitArbeitGrund2.Properties.Appearance.Options.UseFont = true;
            this.cboTeilZeitArbeitGrund2.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboTeilZeitArbeitGrund2.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboTeilZeitArbeitGrund2.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboTeilZeitArbeitGrund2.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboTeilZeitArbeitGrund2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject17.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject17.Options.UseBackColor = true;
            this.cboTeilZeitArbeitGrund2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject17)});
            this.cboTeilZeitArbeitGrund2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboTeilZeitArbeitGrund2.Properties.NullText = "";
            this.cboTeilZeitArbeitGrund2.Properties.ShowFooter = false;
            this.cboTeilZeitArbeitGrund2.Properties.ShowHeader = false;
            this.cboTeilZeitArbeitGrund2.Size = new System.Drawing.Size(250, 24);
            this.cboTeilZeitArbeitGrund2.TabIndex = 6;
            // 
            // cboBranche
            // 
            this.cboBranche.DataMember = "BrancheCode";
            this.cboBranche.DataSource = this.qryBaArbeitAusbildung;
            this.cboBranche.Location = new System.Drawing.Point(590, 40);
            this.cboBranche.LOVName = "Branche";
            this.cboBranche.Name = "cboBranche";
            this.cboBranche.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboBranche.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboBranche.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboBranche.Properties.Appearance.Options.UseBackColor = true;
            this.cboBranche.Properties.Appearance.Options.UseBorderColor = true;
            this.cboBranche.Properties.Appearance.Options.UseFont = true;
            this.cboBranche.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboBranche.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboBranche.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboBranche.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboBranche.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject16.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject16.Options.UseBackColor = true;
            this.cboBranche.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject16)});
            this.cboBranche.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboBranche.Properties.NullText = "";
            this.cboBranche.Properties.ShowFooter = false;
            this.cboBranche.Properties.ShowHeader = false;
            this.cboBranche.Size = new System.Drawing.Size(250, 24);
            this.cboBranche.TabIndex = 7;
            // 
            // cboErlernterBeruf
            // 
            this.cboErlernterBeruf.DataMember = "ErlernterBeruf";
            this.cboErlernterBeruf.DataSource = this.qryBaArbeitAusbildung;
            this.cboErlernterBeruf.Location = new System.Drawing.Point(120, 139);
            this.cboErlernterBeruf.Name = "cboErlernterBeruf";
            this.cboErlernterBeruf.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboErlernterBeruf.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboErlernterBeruf.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboErlernterBeruf.Properties.Appearance.Options.UseBackColor = true;
            this.cboErlernterBeruf.Properties.Appearance.Options.UseBorderColor = true;
            this.cboErlernterBeruf.Properties.Appearance.Options.UseFont = true;
            this.cboErlernterBeruf.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.cboErlernterBeruf.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.cboErlernterBeruf.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboErlernterBeruf.Size = new System.Drawing.Size(355, 24);
            this.cboErlernterBeruf.TabIndex = 8;
            this.cboErlernterBeruf.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.cboErlernterBeruf_UserModifiedFld);
            // 
            // cboBeruf
            // 
            this.cboBeruf.DataMember = "Beruf";
            this.cboBeruf.DataSource = this.qryBaArbeitAusbildung;
            this.cboBeruf.Location = new System.Drawing.Point(120, 162);
            this.cboBeruf.Name = "cboBeruf";
            this.cboBeruf.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboBeruf.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboBeruf.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboBeruf.Properties.Appearance.Options.UseBackColor = true;
            this.cboBeruf.Properties.Appearance.Options.UseBorderColor = true;
            this.cboBeruf.Properties.Appearance.Options.UseFont = true;
            this.cboBeruf.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.cboBeruf.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.cboBeruf.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboBeruf.Size = new System.Drawing.Size(355, 24);
            this.cboBeruf.TabIndex = 9;
            this.cboBeruf.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.cboBeruf_UserModifiedFld);
            // 
            // edtArbeitgeber
            // 
            this.edtArbeitgeber.DataMember = "Arbeitgeber";
            this.edtArbeitgeber.DataSource = this.qryBaArbeitAusbildung;
            this.edtArbeitgeber.Location = new System.Drawing.Point(120, 185);
            this.edtArbeitgeber.Name = "edtArbeitgeber";
            this.edtArbeitgeber.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtArbeitgeber.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtArbeitgeber.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtArbeitgeber.Properties.Appearance.Options.UseBackColor = true;
            this.edtArbeitgeber.Properties.Appearance.Options.UseBorderColor = true;
            this.edtArbeitgeber.Properties.Appearance.Options.UseFont = true;
            this.edtArbeitgeber.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtArbeitgeber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtArbeitgeber.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtArbeitgeber.Size = new System.Drawing.Size(355, 24);
            this.edtArbeitgeber.TabIndex = 10;
            this.edtArbeitgeber.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtArbeitgeber_UserModifiedFld);
            // 
            // cboHoechsteAusbildung
            // 
            this.cboHoechsteAusbildung.DataMember = "HoechsteAusbildungCode";
            this.cboHoechsteAusbildung.DataSource = this.qryBaArbeitAusbildung;
            this.cboHoechsteAusbildung.Location = new System.Drawing.Point(120, 245);
            this.cboHoechsteAusbildung.LOVName = "Ausbildungstyp";
            this.cboHoechsteAusbildung.Name = "cboHoechsteAusbildung";
            this.cboHoechsteAusbildung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboHoechsteAusbildung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboHoechsteAusbildung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboHoechsteAusbildung.Properties.Appearance.Options.UseBackColor = true;
            this.cboHoechsteAusbildung.Properties.Appearance.Options.UseBorderColor = true;
            this.cboHoechsteAusbildung.Properties.Appearance.Options.UseFont = true;
            this.cboHoechsteAusbildung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboHoechsteAusbildung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboHoechsteAusbildung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboHoechsteAusbildung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboHoechsteAusbildung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.cboHoechsteAusbildung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.cboHoechsteAusbildung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboHoechsteAusbildung.Properties.NullText = "";
            this.cboHoechsteAusbildung.Properties.ShowFooter = false;
            this.cboHoechsteAusbildung.Properties.ShowHeader = false;
            this.cboHoechsteAusbildung.Size = new System.Drawing.Size(355, 24);
            this.cboHoechsteAusbildung.TabIndex = 11;
            // 
            // cboLetzteAbgebrocheneAusbildung
            // 
            this.cboLetzteAbgebrocheneAusbildung.DataMember = "AbgebrochenAusbildungCode";
            this.cboLetzteAbgebrocheneAusbildung.DataSource = this.qryBaArbeitAusbildung;
            this.cboLetzteAbgebrocheneAusbildung.Location = new System.Drawing.Point(120, 268);
            this.cboLetzteAbgebrocheneAusbildung.LOVName = "Ausbildungstyp";
            this.cboLetzteAbgebrocheneAusbildung.Name = "cboLetzteAbgebrocheneAusbildung";
            this.cboLetzteAbgebrocheneAusbildung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboLetzteAbgebrocheneAusbildung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboLetzteAbgebrocheneAusbildung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboLetzteAbgebrocheneAusbildung.Properties.Appearance.Options.UseBackColor = true;
            this.cboLetzteAbgebrocheneAusbildung.Properties.Appearance.Options.UseBorderColor = true;
            this.cboLetzteAbgebrocheneAusbildung.Properties.Appearance.Options.UseFont = true;
            this.cboLetzteAbgebrocheneAusbildung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboLetzteAbgebrocheneAusbildung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboLetzteAbgebrocheneAusbildung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboLetzteAbgebrocheneAusbildung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboLetzteAbgebrocheneAusbildung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.cboLetzteAbgebrocheneAusbildung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.cboLetzteAbgebrocheneAusbildung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboLetzteAbgebrocheneAusbildung.Properties.NullText = "";
            this.cboLetzteAbgebrocheneAusbildung.Properties.ShowFooter = false;
            this.cboLetzteAbgebrocheneAusbildung.Properties.ShowHeader = false;
            this.cboLetzteAbgebrocheneAusbildung.Size = new System.Drawing.Size(355, 24);
            this.cboLetzteAbgebrocheneAusbildung.TabIndex = 12;
            // 
            // chkUnregelmaessig
            // 
            this.chkUnregelmaessig.DataMember = "IsVariableArbeitszeit";
            this.chkUnregelmaessig.DataSource = this.qryBaArbeitAusbildung;
            this.chkUnregelmaessig.Location = new System.Drawing.Point(610, 248);
            this.chkUnregelmaessig.Name = "chkUnregelmaessig";
            this.chkUnregelmaessig.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkUnregelmaessig.Properties.Appearance.Options.UseBackColor = true;
            this.chkUnregelmaessig.Properties.Caption = "unregelmässig";
            this.chkUnregelmaessig.Size = new System.Drawing.Size(180, 19);
            this.chkUnregelmaessig.TabIndex = 15;
            // 
            // dtpStempelnSeit
            // 
            this.dtpStempelnSeit.DataMember = "StempelDatum";
            this.dtpStempelnSeit.DataSource = this.qryBaArbeitAusbildung;
            this.dtpStempelnSeit.EditValue = null;
            this.dtpStempelnSeit.Location = new System.Drawing.Point(610, 139);
            this.dtpStempelnSeit.Name = "dtpStempelnSeit";
            this.dtpStempelnSeit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dtpStempelnSeit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.dtpStempelnSeit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dtpStempelnSeit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dtpStempelnSeit.Properties.Appearance.Options.UseBackColor = true;
            this.dtpStempelnSeit.Properties.Appearance.Options.UseBorderColor = true;
            this.dtpStempelnSeit.Properties.Appearance.Options.UseFont = true;
            this.dtpStempelnSeit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.dtpStempelnSeit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("dtpStempelnSeit.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.dtpStempelnSeit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dtpStempelnSeit.Properties.ShowToday = false;
            this.dtpStempelnSeit.Size = new System.Drawing.Size(110, 24);
            this.dtpStempelnSeit.TabIndex = 16;
            // 
            // cboAusgesteuert
            // 
            this.cboAusgesteuert.DataMember = "AusgesteuertUnbekanntCode";
            this.cboAusgesteuert.DataSource = this.qryBaArbeitAusbildung;
            this.cboAusgesteuert.Location = new System.Drawing.Point(610, 162);
            this.cboAusgesteuert.LOVName = "Nichtbekannt";
            this.cboAusgesteuert.Name = "cboAusgesteuert";
            this.cboAusgesteuert.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboAusgesteuert.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboAusgesteuert.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboAusgesteuert.Properties.Appearance.Options.UseBackColor = true;
            this.cboAusgesteuert.Properties.Appearance.Options.UseBorderColor = true;
            this.cboAusgesteuert.Properties.Appearance.Options.UseFont = true;
            this.cboAusgesteuert.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboAusgesteuert.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboAusgesteuert.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboAusgesteuert.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboAusgesteuert.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.cboAusgesteuert.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.cboAusgesteuert.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboAusgesteuert.Properties.NullText = "";
            this.cboAusgesteuert.Properties.ShowFooter = false;
            this.cboAusgesteuert.Properties.ShowHeader = false;
            this.cboAusgesteuert.Size = new System.Drawing.Size(110, 24);
            this.cboAusgesteuert.TabIndex = 17;
            // 
            // dtpAusgesteuertSeit
            // 
            this.dtpAusgesteuertSeit.DataMember = "AusgesteuertDatum";
            this.dtpAusgesteuertSeit.DataSource = this.qryBaArbeitAusbildung;
            this.dtpAusgesteuertSeit.EditValue = null;
            this.dtpAusgesteuertSeit.Location = new System.Drawing.Point(610, 185);
            this.dtpAusgesteuertSeit.Name = "dtpAusgesteuertSeit";
            this.dtpAusgesteuertSeit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dtpAusgesteuertSeit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.dtpAusgesteuertSeit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dtpAusgesteuertSeit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dtpAusgesteuertSeit.Properties.Appearance.Options.UseBackColor = true;
            this.dtpAusgesteuertSeit.Properties.Appearance.Options.UseBorderColor = true;
            this.dtpAusgesteuertSeit.Properties.Appearance.Options.UseFont = true;
            this.dtpAusgesteuertSeit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.dtpAusgesteuertSeit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("dtpAusgesteuertSeit.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.dtpAusgesteuertSeit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dtpAusgesteuertSeit.Properties.ShowToday = false;
            this.dtpAusgesteuertSeit.Size = new System.Drawing.Size(110, 24);
            this.dtpAusgesteuertSeit.TabIndex = 18;
            // 
            // editArbeitsLosXMal
            // 
            this.editArbeitsLosXMal.DataMember = "WieOftArbeitslos";
            this.editArbeitsLosXMal.DataSource = this.qryBaArbeitAusbildung;
            this.editArbeitsLosXMal.Location = new System.Drawing.Point(610, 215);
            this.editArbeitsLosXMal.Name = "editArbeitsLosXMal";
            this.editArbeitsLosXMal.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editArbeitsLosXMal.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editArbeitsLosXMal.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editArbeitsLosXMal.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editArbeitsLosXMal.Properties.Appearance.Options.UseBackColor = true;
            this.editArbeitsLosXMal.Properties.Appearance.Options.UseBorderColor = true;
            this.editArbeitsLosXMal.Properties.Appearance.Options.UseFont = true;
            this.editArbeitsLosXMal.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editArbeitsLosXMal.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editArbeitsLosXMal.Size = new System.Drawing.Size(45, 24);
            this.editArbeitsLosXMal.TabIndex = 19;
            // 
            // editBemerkungRTF
            // 
            this.editBemerkungRTF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.editBemerkungRTF.BackColor = System.Drawing.Color.White;
            this.editBemerkungRTF.DataMember = "Bemerkung";
            this.editBemerkungRTF.DataSource = this.qryBaArbeitAusbildung;
            this.editBemerkungRTF.Font = new System.Drawing.Font("Arial", 10F);
            this.editBemerkungRTF.Location = new System.Drawing.Point(119, 298);
            this.editBemerkungRTF.Name = "editBemerkungRTF";
            this.editBemerkungRTF.Size = new System.Drawing.Size(720, 48);
            this.editBemerkungRTF.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picTitel);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(849, 30);
            this.panel1.TabIndex = 333;
            // 
            // picTitel
            // 
            this.picTitel.Location = new System.Drawing.Point(5, 9);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 293;
            this.picTitel.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(25, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(648, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Arbeit";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // lblTeilzeit
            // 
            this.lblTeilzeit.Location = new System.Drawing.Point(500, 70);
            this.lblTeilzeit.Name = "lblTeilzeit";
            this.lblTeilzeit.Size = new System.Drawing.Size(80, 24);
            this.lblTeilzeit.TabIndex = 419;
            this.lblTeilzeit.Text = "Teilzeitgrund";
            this.lblTeilzeit.UseCompatibleTextRendering = true;
            // 
            // lblErwerbs
            // 
            this.lblErwerbs.Location = new System.Drawing.Point(5, 40);
            this.lblErwerbs.Name = "lblErwerbs";
            this.lblErwerbs.Size = new System.Drawing.Size(90, 24);
            this.lblErwerbs.TabIndex = 420;
            this.lblErwerbs.Text = "Erwerbssituation";
            this.lblErwerbs.UseCompatibleTextRendering = true;
            // 
            // lbl3
            // 
            this.lbl3.Location = new System.Drawing.Point(95, 86);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(10, 24);
            this.lbl3.TabIndex = 425;
            this.lbl3.Text = "3.";
            this.lbl3.UseCompatibleTextRendering = true;
            // 
            // lbl2
            // 
            this.lbl2.Location = new System.Drawing.Point(95, 63);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(10, 24);
            this.lbl2.TabIndex = 426;
            this.lbl2.Text = "2.";
            this.lbl2.UseCompatibleTextRendering = true;
            // 
            // lbl1
            // 
            this.lbl1.Location = new System.Drawing.Point(95, 40);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(10, 24);
            this.lbl1.TabIndex = 427;
            this.lbl1.Text = "1.";
            this.lbl1.UseCompatibleTextRendering = true;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Location = new System.Drawing.Point(5, 298);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(105, 24);
            this.lblBemerkung.TabIndex = 429;
            this.lblBemerkung.Text = "Spezielle Fähigkeiten";
            this.lblBemerkung.UseCompatibleTextRendering = true;
            // 
            // lblTeil1
            // 
            this.lblTeil1.Location = new System.Drawing.Point(570, 70);
            this.lblTeil1.Name = "lblTeil1";
            this.lblTeil1.Size = new System.Drawing.Size(10, 24);
            this.lblTeil1.TabIndex = 435;
            this.lblTeil1.Text = "1.";
            this.lblTeil1.UseCompatibleTextRendering = true;
            // 
            // lblTeil2
            // 
            this.lblTeil2.Location = new System.Drawing.Point(572, 93);
            this.lblTeil2.Name = "lblTeil2";
            this.lblTeil2.Size = new System.Drawing.Size(10, 24);
            this.lblTeil2.TabIndex = 436;
            this.lblTeil2.Text = "2.";
            this.lblTeil2.UseCompatibleTextRendering = true;
            // 
            // lblStempeln
            // 
            this.lblStempeln.Location = new System.Drawing.Point(500, 139);
            this.lblStempeln.Name = "lblStempeln";
            this.lblStempeln.Size = new System.Drawing.Size(80, 24);
            this.lblStempeln.TabIndex = 437;
            this.lblStempeln.Text = "Stempeln seit";
            this.lblStempeln.UseCompatibleTextRendering = true;
            // 
            // lblArbeitslos
            // 
            this.lblArbeitslos.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblArbeitslos.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblArbeitslos.Location = new System.Drawing.Point(500, 216);
            this.lblArbeitslos.Name = "lblArbeitslos";
            this.lblArbeitslos.Size = new System.Drawing.Size(95, 32);
            this.lblArbeitslos.TabIndex = 438;
            this.lblArbeitslos.Text = "arbeitslos (letzte 3 Jahre)";
            this.lblArbeitslos.UseCompatibleTextRendering = true;
            // 
            // lblAusgesteuertSeit
            // 
            this.lblAusgesteuertSeit.Location = new System.Drawing.Point(500, 185);
            this.lblAusgesteuertSeit.Name = "lblAusgesteuertSeit";
            this.lblAusgesteuertSeit.Size = new System.Drawing.Size(95, 24);
            this.lblAusgesteuertSeit.TabIndex = 439;
            this.lblAusgesteuertSeit.Text = "Ausgesteuert seit";
            this.lblAusgesteuertSeit.UseCompatibleTextRendering = true;
            // 
            // lblAusgesteuert
            // 
            this.lblAusgesteuert.Location = new System.Drawing.Point(500, 162);
            this.lblAusgesteuert.Name = "lblAusgesteuert";
            this.lblAusgesteuert.Size = new System.Drawing.Size(80, 24);
            this.lblAusgesteuert.TabIndex = 440;
            this.lblAusgesteuert.Text = "Ausgesteuert";
            this.lblAusgesteuert.UseCompatibleTextRendering = true;
            // 
            // lblLetzteAusbildung
            // 
            this.lblLetzteAusbildung.Location = new System.Drawing.Point(5, 268);
            this.lblLetzteAusbildung.Name = "lblLetzteAusbildung";
            this.lblLetzteAusbildung.Size = new System.Drawing.Size(105, 24);
            this.lblLetzteAusbildung.TabIndex = 442;
            this.lblLetzteAusbildung.Text = "Letzte abgebr. Ausb.";
            this.lblLetzteAusbildung.UseCompatibleTextRendering = true;
            // 
            // lblAusbildung
            // 
            this.lblAusbildung.Location = new System.Drawing.Point(5, 245);
            this.lblAusbildung.Name = "lblAusbildung";
            this.lblAusbildung.Size = new System.Drawing.Size(100, 24);
            this.lblAusbildung.TabIndex = 443;
            this.lblAusbildung.Text = "höchste Ausbildung";
            this.lblAusbildung.UseCompatibleTextRendering = true;
            // 
            // lblArbeitgeber
            // 
            this.lblArbeitgeber.Location = new System.Drawing.Point(5, 185);
            this.lblArbeitgeber.Name = "lblArbeitgeber";
            this.lblArbeitgeber.Size = new System.Drawing.Size(80, 24);
            this.lblArbeitgeber.TabIndex = 444;
            this.lblArbeitgeber.Text = "Arbeitgeber";
            this.lblArbeitgeber.UseCompatibleTextRendering = true;
            // 
            // lblLetzteT
            // 
            this.lblLetzteT.Location = new System.Drawing.Point(5, 162);
            this.lblLetzteT.Name = "lblLetzteT";
            this.lblLetzteT.Size = new System.Drawing.Size(80, 24);
            this.lblLetzteT.TabIndex = 445;
            this.lblLetzteT.Text = "Letzte Tätigkeit";
            this.lblLetzteT.UseCompatibleTextRendering = true;
            // 
            // lblErlerntBeruf
            // 
            this.lblErlerntBeruf.Location = new System.Drawing.Point(5, 139);
            this.lblErlerntBeruf.Name = "lblErlerntBeruf";
            this.lblErlerntBeruf.Size = new System.Drawing.Size(80, 24);
            this.lblErlerntBeruf.TabIndex = 446;
            this.lblErlerntBeruf.Text = "Erlernter Beruf";
            this.lblErlerntBeruf.UseCompatibleTextRendering = true;
            // 
            // lblBranche
            // 
            this.lblBranche.Location = new System.Drawing.Point(500, 40);
            this.lblBranche.Name = "lblBranche";
            this.lblBranche.Size = new System.Drawing.Size(80, 24);
            this.lblBranche.TabIndex = 447;
            this.lblBranche.Text = "Branche";
            this.lblBranche.UseCompatibleTextRendering = true;
            // 
            // lbl4
            // 
            this.lbl4.Location = new System.Drawing.Point(95, 109);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(10, 24);
            this.lbl4.TabIndex = 448;
            this.lbl4.Text = "4.";
            this.lbl4.UseCompatibleTextRendering = true;
            // 
            // lblx
            // 
            this.lblx.Location = new System.Drawing.Point(661, 215);
            this.lblx.Name = "lblx";
            this.lblx.Size = new System.Drawing.Size(25, 24);
            this.lblx.TabIndex = 459;
            this.lblx.Text = "x";
            this.lblx.UseCompatibleTextRendering = true;
            // 
            // lblDatumVon
            // 
            this.lblDatumVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDatumVon.Location = new System.Drawing.Point(8, 481);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(100, 24);
            this.lblDatumVon.TabIndex = 463;
            this.lblDatumVon.Text = "Datum von";
            this.lblDatumVon.UseCompatibleTextRendering = true;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryBaArbeit;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(119, 480);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 464;
            // 
            // qryBaArbeit
            // 
            this.qryBaArbeit.HostControl = this;
            this.qryBaArbeit.SelectStatement = resources.GetString("qryBaArbeit.SelectStatement");
            this.qryBaArbeit.TableName = "BaArbeit";
            this.qryBaArbeit.AfterFill += new System.EventHandler(this.qryBaArbeit_AfterFill);
            this.qryBaArbeit.AfterInsert += new System.EventHandler(this.qryBaArbeit_AfterInsert);
            this.qryBaArbeit.BeforePost += new System.EventHandler(this.qryBaArbeit_BeforePost);
            // 
            // lblBis
            // 
            this.lblBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBis.Location = new System.Drawing.Point(8, 512);
            this.lblBis.Name = "lblBis";
            this.lblBis.Size = new System.Drawing.Size(59, 24);
            this.lblBis.TabIndex = 465;
            this.lblBis.Text = "Datum bis";
            this.lblBis.UseCompatibleTextRendering = true;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryBaArbeit;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(119, 511);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 466;
            // 
            // lblArbeitTyp
            // 
            this.lblArbeitTyp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblArbeitTyp.Location = new System.Drawing.Point(241, 481);
            this.lblArbeitTyp.Name = "lblArbeitTyp";
            this.lblArbeitTyp.Size = new System.Drawing.Size(61, 24);
            this.lblArbeitTyp.TabIndex = 467;
            this.lblArbeitTyp.Text = "Typ";
            this.lblArbeitTyp.UseCompatibleTextRendering = true;
            // 
            // edtArbeitTyp
            // 
            this.edtArbeitTyp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtArbeitTyp.DataMember = "TypCode";
            this.edtArbeitTyp.DataSource = this.qryBaArbeit;
            this.edtArbeitTyp.Location = new System.Drawing.Point(308, 480);
            this.edtArbeitTyp.LOVName = "BaArbeitTyp";
            this.edtArbeitTyp.Name = "edtArbeitTyp";
            this.edtArbeitTyp.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtArbeitTyp.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtArbeitTyp.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtArbeitTyp.Properties.Appearance.Options.UseBackColor = true;
            this.edtArbeitTyp.Properties.Appearance.Options.UseBorderColor = true;
            this.edtArbeitTyp.Properties.Appearance.Options.UseFont = true;
            this.edtArbeitTyp.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtArbeitTyp.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtArbeitTyp.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtArbeitTyp.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtArbeitTyp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtArbeitTyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtArbeitTyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtArbeitTyp.Properties.NullText = "";
            this.edtArbeitTyp.Properties.ShowFooter = false;
            this.edtArbeitTyp.Properties.ShowHeader = false;
            this.edtArbeitTyp.Size = new System.Drawing.Size(251, 24);
            this.edtArbeitTyp.TabIndex = 468;
            // 
            // lblBeschGrad
            // 
            this.lblBeschGrad.Location = new System.Drawing.Point(5, 210);
            this.lblBeschGrad.Name = "lblBeschGrad";
            this.lblBeschGrad.Size = new System.Drawing.Size(108, 24);
            this.lblBeschGrad.TabIndex = 470;
            this.lblBeschGrad.Text = "Beschäftigungsgrad";
            this.lblBeschGrad.UseCompatibleTextRendering = true;
            // 
            // edtBeschaeftigungsGradCode
            // 
            this.edtBeschaeftigungsGradCode.DataMember = "BeschaeftigungsGradCode";
            this.edtBeschaeftigungsGradCode.DataSource = this.qryBaArbeitAusbildung;
            this.edtBeschaeftigungsGradCode.Location = new System.Drawing.Point(120, 210);
            this.edtBeschaeftigungsGradCode.LOVName = "Beschaeftigungsgrad";
            this.edtBeschaeftigungsGradCode.Name = "edtBeschaeftigungsGradCode";
            this.edtBeschaeftigungsGradCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBeschaeftigungsGradCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBeschaeftigungsGradCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBeschaeftigungsGradCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBeschaeftigungsGradCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBeschaeftigungsGradCode.Properties.Appearance.Options.UseFont = true;
            this.edtBeschaeftigungsGradCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBeschaeftigungsGradCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBeschaeftigungsGradCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBeschaeftigungsGradCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBeschaeftigungsGradCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtBeschaeftigungsGradCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtBeschaeftigungsGradCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBeschaeftigungsGradCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtBeschaeftigungsGradCode.Properties.DisplayMember = "Text";
            this.edtBeschaeftigungsGradCode.Properties.NullText = "";
            this.edtBeschaeftigungsGradCode.Properties.ShowFooter = false;
            this.edtBeschaeftigungsGradCode.Properties.ShowHeader = false;
            this.edtBeschaeftigungsGradCode.Properties.ValueMember = "Code";
            this.edtBeschaeftigungsGradCode.Size = new System.Drawing.Size(355, 24);
            this.edtBeschaeftigungsGradCode.TabIndex = 471;
            // 
            // kissCheckEdit1
            // 
            this.kissCheckEdit1.DataMember = "FinanziellUnabhaengig";
            this.kissCheckEdit1.DataSource = this.qryBaArbeitAusbildung;
            this.kissCheckEdit1.Location = new System.Drawing.Point(610, 273);
            this.kissCheckEdit1.Name = "kissCheckEdit1";
            this.kissCheckEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.kissCheckEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissCheckEdit1.Properties.Caption = "finanziell unabhängig";
            this.kissCheckEdit1.Size = new System.Drawing.Size(199, 19);
            this.kissCheckEdit1.TabIndex = 474;
            // 
            // grdArbeit
            // 
            this.grdArbeit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdArbeit.DataSource = this.qryBaArbeit;
            // 
            // 
            // 
            this.grdArbeit.EmbeddedNavigator.Name = "";
            this.grdArbeit.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdArbeit.Location = new System.Drawing.Point(5, 381);
            this.grdArbeit.MainView = this.gridView1;
            this.grdArbeit.Name = "grdArbeit";
            this.grdArbeit.Size = new System.Drawing.Size(835, 93);
            this.grdArbeit.TabIndex = 476;
            this.grdArbeit.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVon,
            this.colDatumbis,
            this.colArbeitgeber,
            this.colBemerkung,
            this.colTyp,
            this.colPensum,
            this.colSprachniveau});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdArbeit;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colVon
            // 
            this.colVon.Caption = "von";
            this.colVon.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colVon.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colVon.FieldName = "DatumVon";
            this.colVon.Name = "colVon";
            this.colVon.Visible = true;
            this.colVon.VisibleIndex = 0;
            this.colVon.Width = 80;
            // 
            // colDatumbis
            // 
            this.colDatumbis.Caption = "bis";
            this.colDatumbis.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colDatumbis.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDatumbis.FieldName = "DatumBis";
            this.colDatumbis.Name = "colDatumbis";
            this.colDatumbis.Visible = true;
            this.colDatumbis.VisibleIndex = 1;
            this.colDatumbis.Width = 83;
            // 
            // colArbeitgeber
            // 
            this.colArbeitgeber.Caption = "Arbeitgeber/Anbieter";
            this.colArbeitgeber.FieldName = "Institution";
            this.colArbeitgeber.Name = "colArbeitgeber";
            this.colArbeitgeber.Visible = true;
            this.colArbeitgeber.VisibleIndex = 2;
            this.colArbeitgeber.Width = 182;
            // 
            // colBemerkung
            // 
            this.colBemerkung.Caption = "Bemerkung";
            this.colBemerkung.FieldName = "Bemerkung";
            this.colBemerkung.Name = "colBemerkung";
            this.colBemerkung.Visible = true;
            this.colBemerkung.VisibleIndex = 6;
            this.colBemerkung.Width = 124;
            // 
            // colTyp
            // 
            this.colTyp.Caption = "Typ";
            this.colTyp.FieldName = "TypCode";
            this.colTyp.Name = "colTyp";
            this.colTyp.Visible = true;
            this.colTyp.VisibleIndex = 3;
            this.colTyp.Width = 121;
            // 
            // colPensum
            // 
            this.colPensum.Caption = "%";
            this.colPensum.FieldName = "PensumCode";
            this.colPensum.Name = "colPensum";
            this.colPensum.Visible = true;
            this.colPensum.VisibleIndex = 4;
            // 
            // colSprachniveau
            // 
            this.colSprachniveau.Caption = "Sprachniveau";
            this.colSprachniveau.FieldName = "BaSprachniveauCode";
            this.colSprachniveau.Name = "colSprachniveau";
            this.colSprachniveau.Visible = true;
            this.colSprachniveau.VisibleIndex = 5;
            this.colSprachniveau.Width = 92;
            // 
            // lblArbeit
            // 
            this.lblArbeit.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblArbeit.Location = new System.Drawing.Point(8, 362);
            this.lblArbeit.Name = "lblArbeit";
            this.lblArbeit.Size = new System.Drawing.Size(294, 16);
            this.lblArbeit.TabIndex = 477;
            this.lblArbeit.Text = "Arbeit, Ausbildung und Beschäftigung";
            this.lblArbeit.UseCompatibleTextRendering = true;
            // 
            // lblInstitution
            // 
            this.lblInstitution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInstitution.Location = new System.Drawing.Point(241, 511);
            this.lblInstitution.Name = "lblInstitution";
            this.lblInstitution.Size = new System.Drawing.Size(61, 24);
            this.lblInstitution.TabIndex = 478;
            this.lblInstitution.Text = "Institution";
            this.lblInstitution.UseCompatibleTextRendering = true;
            // 
            // edtInstitution
            // 
            this.edtInstitution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtInstitution.DataMember = "Institution";
            this.edtInstitution.DataSource = this.qryBaArbeit;
            this.edtInstitution.Location = new System.Drawing.Point(308, 510);
            this.edtInstitution.Name = "edtInstitution";
            this.edtInstitution.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInstitution.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInstitution.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInstitution.Properties.Appearance.Options.UseBackColor = true;
            this.edtInstitution.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInstitution.Properties.Appearance.Options.UseFont = true;
            this.edtInstitution.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtInstitution.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtInstitution.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtInstitution.Size = new System.Drawing.Size(250, 24);
            this.edtInstitution.TabIndex = 479;
            this.edtInstitution.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtInstitution_UserModifiedFld);
            // 
            // lblBemerkung2
            // 
            this.lblBemerkung2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBemerkung2.Location = new System.Drawing.Point(8, 549);
            this.lblBemerkung2.Name = "lblBemerkung2";
            this.lblBemerkung2.Size = new System.Drawing.Size(105, 24);
            this.lblBemerkung2.TabIndex = 480;
            this.lblBemerkung2.Text = "Bemerkung";
            this.lblBemerkung2.UseCompatibleTextRendering = true;
            // 
            // kissRTFEdit1
            // 
            this.kissRTFEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.kissRTFEdit1.BackColor = System.Drawing.Color.White;
            this.kissRTFEdit1.DataMember = "Bemerkung";
            this.kissRTFEdit1.DataSource = this.qryBaArbeit;
            this.kissRTFEdit1.Font = new System.Drawing.Font("Arial", 10F);
            this.kissRTFEdit1.Location = new System.Drawing.Point(119, 549);
            this.kissRTFEdit1.Name = "kissRTFEdit1";
            this.kissRTFEdit1.Size = new System.Drawing.Size(720, 78);
            this.kissRTFEdit1.TabIndex = 481;
            // 
            // lblPensumCode
            // 
            this.lblPensumCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPensumCode.Location = new System.Drawing.Point(573, 481);
            this.lblPensumCode.Name = "lblPensumCode";
            this.lblPensumCode.Size = new System.Drawing.Size(51, 24);
            this.lblPensumCode.TabIndex = 482;
            this.lblPensumCode.Text = "Pensum";
            this.lblPensumCode.UseCompatibleTextRendering = true;
            // 
            // edtPensumCode
            // 
            this.edtPensumCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtPensumCode.DataMember = "PensumCode";
            this.edtPensumCode.DataSource = this.qryBaArbeit;
            this.edtPensumCode.Location = new System.Drawing.Point(670, 481);
            this.edtPensumCode.LOVName = "BaPensum";
            this.edtPensumCode.Name = "edtPensumCode";
            this.edtPensumCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPensumCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPensumCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPensumCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtPensumCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPensumCode.Properties.Appearance.Options.UseFont = true;
            this.edtPensumCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtPensumCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtPensumCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtPensumCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtPensumCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtPensumCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtPensumCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPensumCode.Properties.NullText = "";
            this.edtPensumCode.Properties.ShowFooter = false;
            this.edtPensumCode.Properties.ShowHeader = false;
            this.edtPensumCode.Size = new System.Drawing.Size(120, 24);
            this.edtPensumCode.TabIndex = 483;
            // 
            // lblBaSprachniveauCode
            // 
            this.lblBaSprachniveauCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBaSprachniveauCode.Location = new System.Drawing.Point(573, 510);
            this.lblBaSprachniveauCode.Name = "lblBaSprachniveauCode";
            this.lblBaSprachniveauCode.Size = new System.Drawing.Size(91, 24);
            this.lblBaSprachniveauCode.TabIndex = 484;
            this.lblBaSprachniveauCode.Text = "Sprachniveau";
            this.lblBaSprachniveauCode.UseCompatibleTextRendering = true;
            // 
            // edtBaSprachniveauCode
            // 
            this.edtBaSprachniveauCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBaSprachniveauCode.DataMember = "BaSprachniveauCode";
            this.edtBaSprachniveauCode.DataSource = this.qryBaArbeit;
            this.edtBaSprachniveauCode.Location = new System.Drawing.Point(670, 511);
            this.edtBaSprachniveauCode.LOVName = "BaSprachniveau";
            this.edtBaSprachniveauCode.Name = "edtBaSprachniveauCode";
            this.edtBaSprachniveauCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaSprachniveauCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaSprachniveauCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaSprachniveauCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaSprachniveauCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaSprachniveauCode.Properties.Appearance.Options.UseFont = true;
            this.edtBaSprachniveauCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBaSprachniveauCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaSprachniveauCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBaSprachniveauCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBaSprachniveauCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBaSprachniveauCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBaSprachniveauCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaSprachniveauCode.Properties.NullText = "";
            this.edtBaSprachniveauCode.Properties.ShowFooter = false;
            this.edtBaSprachniveauCode.Properties.ShowHeader = false;
            this.edtBaSprachniveauCode.Size = new System.Drawing.Size(120, 24);
            this.edtBaSprachniveauCode.TabIndex = 485;
            // 
            // CtlBaArbeit
            // 
            this.AutoRefresh = false;
            this.Controls.Add(this.edtBaSprachniveauCode);
            this.Controls.Add(this.lblBaSprachniveauCode);
            this.Controls.Add(this.edtPensumCode);
            this.Controls.Add(this.lblPensumCode);
            this.Controls.Add(this.kissRTFEdit1);
            this.Controls.Add(this.lblBemerkung2);
            this.Controls.Add(this.edtInstitution);
            this.Controls.Add(this.lblInstitution);
            this.Controls.Add(this.lblArbeit);
            this.Controls.Add(this.grdArbeit);
            this.Controls.Add(this.kissCheckEdit1);
            this.Controls.Add(this.edtBeschaeftigungsGradCode);
            this.Controls.Add(this.lblBeschGrad);
            this.Controls.Add(this.edtArbeitTyp);
            this.Controls.Add(this.lblArbeitTyp);
            this.Controls.Add(this.edtDatumBis);
            this.Controls.Add(this.lblBis);
            this.Controls.Add(this.edtDatumVon);
            this.Controls.Add(this.lblDatumVon);
            this.Controls.Add(this.lblx);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lblBranche);
            this.Controls.Add(this.lblErlerntBeruf);
            this.Controls.Add(this.lblLetzteT);
            this.Controls.Add(this.lblArbeitgeber);
            this.Controls.Add(this.lblAusbildung);
            this.Controls.Add(this.lblLetzteAusbildung);
            this.Controls.Add(this.lblAusgesteuert);
            this.Controls.Add(this.lblAusgesteuertSeit);
            this.Controls.Add(this.lblArbeitslos);
            this.Controls.Add(this.lblStempeln);
            this.Controls.Add(this.lblTeil2);
            this.Controls.Add(this.lblTeil1);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lblErwerbs);
            this.Controls.Add(this.lblTeilzeit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.editBemerkungRTF);
            this.Controls.Add(this.editArbeitsLosXMal);
            this.Controls.Add(this.dtpAusgesteuertSeit);
            this.Controls.Add(this.cboAusgesteuert);
            this.Controls.Add(this.dtpStempelnSeit);
            this.Controls.Add(this.chkUnregelmaessig);
            this.Controls.Add(this.cboLetzteAbgebrocheneAusbildung);
            this.Controls.Add(this.cboHoechsteAusbildung);
            this.Controls.Add(this.edtArbeitgeber);
            this.Controls.Add(this.cboBeruf);
            this.Controls.Add(this.cboErlernterBeruf);
            this.Controls.Add(this.cboBranche);
            this.Controls.Add(this.cboTeilZeitArbeitGrund2);
            this.Controls.Add(this.cboTeilZeitArbeitGrund1);
            this.Controls.Add(this.cboErwerbssituation4);
            this.Controls.Add(this.cboErwerbssituation3);
            this.Controls.Add(this.cboErwerbssituation2);
            this.Controls.Add(this.cboErwerbssituation1);
            this.MinimumSize = new System.Drawing.Size(849, 603);
            this.Name = "CtlBaArbeit";
            this.Size = new System.Drawing.Size(849, 630);
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaArbeitAusbildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTeilZeitArbeitGrund1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTeilZeitArbeitGrund1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTeilZeitArbeitGrund2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTeilZeitArbeitGrund2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBranche.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBranche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErlernterBeruf.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBeruf.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArbeitgeber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboHoechsteAusbildung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboHoechsteAusbildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLetzteAbgebrocheneAusbildung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLetzteAbgebrocheneAusbildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUnregelmaessig.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStempelnSeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAusgesteuert.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAusgesteuert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAusgesteuertSeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editArbeitsLosXMal.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTeilzeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErwerbs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTeil1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTeil2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStempeln)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArbeitslos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusgesteuertSeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusgesteuert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLetzteAusbildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusbildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArbeitgeber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLetzteT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErlerntBeruf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBranche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaArbeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArbeitTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArbeitTyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArbeitTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeschGrad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeschaeftigungsGradCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeschaeftigungsGradCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissCheckEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdArbeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArbeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInstitution.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPensumCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPensumCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPensumCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaSprachniveauCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaSprachniveauCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaSprachniveauCode)).EndInit();
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

        private void cboBeruf_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string searchString = cboBeruf.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBaArbeitAusbildung["BerufCode"] = DBNull.Value;
                    qryBaArbeitAusbildung["Beruf"] = DBNull.Value;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT ID$   = B.BaBerufID,
                       Beruf = B.Beruf,
                       BFS   = B.BFSCode
                FROM dbo.BaBeruf B
                WHERE B.Beruf LIKE '%' + {0} + '%'
                ORDER BY B.SortKey;", searchString, e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                qryBaArbeitAusbildung["BerufCode"] = dlg[0];
                qryBaArbeitAusbildung["Beruf"] = dlg[1];
            }
        }

        private void cboErlernterBeruf_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string searchString = cboErlernterBeruf.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBaArbeitAusbildung["ErlernterBerufCode"] = DBNull.Value;
                    qryBaArbeitAusbildung["ErlernterBeruf"] = DBNull.Value;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT ID$   = B.BaBerufID,
                       Beruf = B.Beruf,
                       BFS   = B.BFSCode
                FROM dbo.BaBeruf B
                WHERE B.Beruf LIKE '%' + {0} + '%'
                ORDER BY B.SortKey;", searchString, e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                qryBaArbeitAusbildung["ErlernterBerufCode"] = dlg[0];
                qryBaArbeitAusbildung["ErlernterBeruf"] = dlg[1];
            }
        }

        private void edtArbeitgeber_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string searchString = edtArbeitgeber.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBaArbeitAusbildung["BaInstitutionID"] = DBNull.Value;
                    qryBaArbeitAusbildung["Arbeitgeber"] = DBNull.Value;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();

            e.Cancel = !dlg.SearchData(@"
                SELECT ID$         = INS.BaInstitutionID,
                       Arbeitgeber = INS.NameVorname,
                       Strasse     = INS.StrasseHausNr,
                       Ort         = INS.PLZOrt
                FROM dbo.vwInstitution INS
                WHERE INS.NameVorname LIKE '%' + {0} + '%'
                ORDER BY INS.NameVorname;", searchString, e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                qryBaArbeitAusbildung["BaInstitutionID"] = dlg[0];
                qryBaArbeitAusbildung["Arbeitgeber"] = dlg[1];
            }
        }

        private void edtInstitution_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string searchString = edtInstitution.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBaArbeit["BaInstitutionID"] = DBNull.Value;
                    qryBaArbeit["Institution"] = DBNull.Value;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT ID$         = INS.BaInstitutionID,
                       Arbeitgeber = INS.NameVorname,
                       Strasse     = INS.StrasseHausNr,
                       Ort         = INS.PLZOrt
                FROM dbo.vwInstitution INS
                WHERE INS.NameVorname LIKE '%' + {0} + '%'
                ORDER BY INS.NameVorname;", searchString, e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                qryBaArbeit["BaInstitutionID"] = dlg[0];
                qryBaArbeit["Institution"] = dlg[1];
            }
        }

        private void qryBaArbeitAusbildung_AfterInsert(object sender, System.EventArgs e)
        {
            qryBaArbeitAusbildung["BaPersonID"] = _baPersonId;
            qryBaArbeitAusbildung["FinanziellUnabhaengig"] = 0;
            qryBaArbeitAusbildung["IsVariableArbeitszeit"] = 0;
        }

        private void qryBaArbeitAusbildung_BeforePost(object sender, System.EventArgs e)
        {
            ////DBUtil.CheckNotNullField(edtName);
        }

        private void qryBaArbeit_AfterFill(object sender, System.EventArgs e)
        {
            qryBaArbeit.Last();
        }

        private void qryBaArbeit_AfterInsert(object sender, System.EventArgs e)
        {
            qryBaArbeit["BaPersonID"] = _baPersonId;
        }

        private void qryBaArbeit_BeforePost(object sender, System.EventArgs e)
        {
            DBUtil.CheckNotNullField(edtDatumVon, lblDatumVon.Text);
            DBUtil.CheckNotNullField(edtArbeitTyp, lblArbeitTyp.Text);

            // Kontrollieren, dass Datum von kleiner als Datum bis ist:
            if (!DBUtil.IsEmpty(qryBaArbeit["DatumVon"]) && !DBUtil.IsEmpty(qryBaArbeit["DatumBis"]))
            {
                if ((DateTime)qryBaArbeit["DatumVon"] >= (DateTime)qryBaArbeit["DatumBis"])
                {
                    KissMsg.ShowInfo(this.Name, "DatumsFehler", "Das Von-Datum muss kleiner sein als das Bis-Datum.");
                    throw new KissCancelException();
                }
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Init(string TitleName, Image TitleImage, int PersonID)
        {
            _baPersonId = PersonID;
            picTitel.Image = TitleImage;

            colTyp.ColumnEdit = grdArbeit.GetLOVLookUpEdit("BaArbeitTyp");
            colPensum.ColumnEdit = grdArbeit.GetLOVLookUpEdit("BaPensum");
            colSprachniveau.ColumnEdit = grdArbeit.GetLOVLookUpEdit("BaSprachniveau");
            colBemerkung.DisplayFormat.Format = new GridColumnRTF();

            qryBaArbeitAusbildung.Fill(_baPersonId);
            qryBaArbeit.Fill(_baPersonId);

            bool canInsert = DBUtil.UserHasRight(this.Name, "I");
            bool canUpdate = DBUtil.UserHasRight(this.Name, "U");
            bool canDelete = DBUtil.UserHasRight(this.Name, "D");

            qryBaArbeitAusbildung.CanInsert = false;
            qryBaArbeitAusbildung.CanUpdate = canUpdate;
            qryBaArbeitAusbildung.CanDelete = false;

            qryBaArbeit.CanInsert = canInsert;
            qryBaArbeit.CanUpdate = canUpdate;
            qryBaArbeit.CanDelete = canDelete;
            qryBaArbeit.EnableBoundFields();

            InsertEmptyEntryArbeitAusbildung();
        }

        public override bool OnAddData()
        {
            if (OnSaveData())
            {
                bool result = InsertEmptyEntryArbeitAusbildung();

                if (qryBaArbeit.Insert() != null)
                {
                    qryBaArbeit.EnableBoundFields();
                    result = true;
                }

                return result;
            }

            return false;
        }

        public override bool OnDeleteData()
        {
            return qryBaArbeit.Delete();
        }

        public override void OnMoveFirst()
        {
            qryBaArbeit.First();
        }

        public override void OnMoveLast()
        {
            qryBaArbeit.Last();
        }

        public override void OnMoveNext()
        {
            qryBaArbeit.Next();
        }

        public override void OnMovePrevious()
        {
            qryBaArbeit.Previous();
        }

        public override void OnRefreshData()
        {
            qryBaArbeitAusbildung.Refresh();
            qryBaArbeit.Refresh();
        }

        public override bool OnSaveData()
        {
            bool result = (qryBaArbeitAusbildung.Post() && qryBaArbeit.Post());

            // resinsert empty entry if possible
            InsertEmptyEntryArbeitAusbildung();

            return result;
        }

        public override void OnUndoDataChanges()
        {
            string[] buttonList = { lblTitel.Text, lblArbeit.Text, btnDlgAbbrechen };

            string msgQuestion = KissMsg.GetMLMessage(this.Name,
                                                      "QuestionUndoEntry",
                                                      "Wollen Sie die Änderungen an '{0}' oder '{1}' rückgängig machen?",
                                                      lblTitel.Text,
                                                      lblArbeit.Text);

            int indexDlgBtn = KissMsg.ShowButtonDlg(msgQuestion, buttonList, Messages.DlgButtonPositionModes.dpmAutomatic, 0);

            switch (indexDlgBtn)
            {
                case 0:
                    // undo main query
                    qryBaArbeitAusbildung.Cancel();
                    InsertEmptyEntryArbeitAusbildung();
                    return;

                case 1:
                    // undo subquery
                    qryBaArbeit.Cancel();
                    return;
            }
        }

        #endregion

        #region Private Methods

        private bool InsertEmptyEntryArbeitAusbildung()
        {
            if (qryBaArbeitAusbildung.IsEmpty &&
                qryBaArbeitAusbildung.CanUpdate &&
                qryBaArbeitAusbildung.Insert(null) != null)
            {
                qryBaArbeitAusbildung.EnableBoundFields();
                return true;
            }

            return false;
        }

        #endregion

        #endregion
    }
}