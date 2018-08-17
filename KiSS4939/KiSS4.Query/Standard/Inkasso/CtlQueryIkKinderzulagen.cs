using System;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    public class CtlQueryIkKinderzulagen : KiSS4.Common.KissQueryControl
    {
        #region Fields


        // Letzte Bearbeitung
        // 24.11.2008 : sozheo : neu
        // -------------------------------------------------------------
        private int FilterUserID = 0;
        private string FilterUserText = "";
        private DateTime OldDate = DateTime.Today;
        private DevExpress.XtraGrid.Columns.GridColumn colFalltraegerFallNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colFalltraegerName;
        private DevExpress.XtraGrid.Columns.GridColumn colFalltraegerPersonenNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colFalltraegerVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colFalltraeger_FallNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colFalltraeger_Name;
        private DevExpress.XtraGrid.Columns.GridColumn colFalltraeger_PersonenNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colFalltraeger_Vorname;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb01AlteKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb01BaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb01Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb01Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb01VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb01_AlteKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb01_BaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb01_Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb01_VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb02AlteKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb02BaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb02Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb02Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb02VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb02_AlteKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb02_BaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb02_Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb02_VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb03AlteKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb03BaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb03Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb03Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb03VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb03_AlteKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb03_BaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb03_Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb03_VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb04AlteKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb04BaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb04Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb04Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb04VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb04_AlteKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb04_BaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb04_Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb04_VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb05AlteKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb05BaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb05Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb05Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb05VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb05_AlteKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb05_BaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb05_Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb05_VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb06AlteKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb06BaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb06Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb06Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb06VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb06_AlteKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb06_BaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb06_Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb06_VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb07AlteKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb07BaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb07Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb07Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb07VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb07_AlteKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb07_BaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb07_Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb07_VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb08AlteKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb08BaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb08Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb08Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb08VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb08_AlteKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb08_BaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb08_Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb08_VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb09AlteKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb09BaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb09Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb09Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb09VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb09_AlteKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb09_BaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb09_Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb09_VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb10AlteKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb10BaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb10Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb10Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb10VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb10_AlteKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb10_BaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb10_Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb10_VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colKopieAn;
        private DevExpress.XtraGrid.Columns.GridColumn colKopieAnQT;
        private DevExpress.XtraGrid.Columns.GridColumn colKopieAnSozZentrum;
        private DevExpress.XtraGrid.Columns.GridColumn colKopieAn_QT;
        private DevExpress.XtraGrid.Columns.GridColumn colKopieAn_SZ;
        private DevExpress.XtraGrid.Columns.GridColumn colRTDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colRTInfo;
        private DevExpress.XtraGrid.Columns.GridColumn colRTTeuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colRTTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colSBDisplayname;
        private DevExpress.XtraGrid.Columns.GridColumn colSBLogonName;
        private DevExpress.XtraGrid.Columns.GridColumn colSBVornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colSB_Displayname;
        private DevExpress.XtraGrid.Columns.GridColumn colSB_LogonName;
        private DevExpress.XtraGrid.Columns.GridColumn colSB_VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldnerAnrede;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldnerName;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldnerOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldnerPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldnerPersonenNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldnerPostfach;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldnerStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldnerVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldnerZusatz;
        private KiSS4.Gui.KissDateEdit edtDate;
        private KiSS4.Gui.KissButtonEdit edtUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwQuery;
        private KiSS4.Gui.KissLabel lblUser;
        private KiSS4.Gui.KissLabel lblYear;

        #endregion

        #region Constructors

        public CtlQueryIkKinderzulagen()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryIkKinderzulagen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblUser = new KiSS4.Gui.KissLabel();
            this.edtUser = new KiSS4.Gui.KissButtonEdit();
            this.lblYear = new KiSS4.Gui.KissLabel();
            this.edtDate = new KiSS4.Gui.KissDateEdit();
            this.colFalltraeger_FallNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFalltraeger_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFalltraeger_PersonenNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFalltraeger_Vorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFalltraegerFallNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFalltraegerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFalltraegerPersonenNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFalltraegerVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb01_AlteKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb01_BaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb01_Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb01_VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb01AlteKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb01BaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb01Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb01Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb01VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb02_AlteKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb02_BaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb02_Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb02_VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb02AlteKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb02BaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb02Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb02Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb02VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb03_AlteKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb03_BaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb03_Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb03_VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb03AlteKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb03BaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb03Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb03Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb03VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb04_AlteKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb04_BaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb04_Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb04_VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb04AlteKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb04BaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb04Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb04Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb04VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb05_AlteKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb05_BaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb05_Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb05_VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb05AlteKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb05BaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb05Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb05Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb05VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb06_AlteKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb06_BaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb06_Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb06_VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb06AlteKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb06BaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb06Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb06Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb06VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb07_AlteKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb07_BaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb07_Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb07_VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb07AlteKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb07BaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb07Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb07Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb07VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb08_AlteKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb08_BaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb08_Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb08_VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb08AlteKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb08BaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb08Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb08Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb08VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb09_AlteKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb09_BaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb09_Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb09_VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb09AlteKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb09BaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb09Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb09Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb09VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb10_AlteKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb10_BaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb10_Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb10_VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb10AlteKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb10BaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb10Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb10Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb10VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKopieAn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKopieAn_QT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKopieAn_SZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKopieAnQT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKopieAnSozZentrum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRTDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRTInfo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRTTeuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRTTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSB_Displayname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSB_LogonName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSB_VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSBDisplayname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSBLogonName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSBVornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldnerAnrede = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldnerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldnerOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldnerPersonenNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldnerPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldnerPostfach = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldnerStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldnerVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldnerZusatz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvwQuery = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwQuery)).BeginInit();
            this.SuspendLayout();
            //
            // qryQuery
            //
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            //
            // grdQuery1
            //
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.MainView = this.gvwQuery;
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.gvwQuery});
            //
            // xDocument
            //
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.xDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument �ffnen")});
            //
            // ctlGotoFall
            //
            this.ctlGotoFall.DataMember = "Falltraeger_PersonenNummer";
            //
            // tpgListe
            //
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtDate);
            this.tpgSuchen.Controls.Add(this.lblYear);
            this.tpgSuchen.Controls.Add(this.edtUser);
            this.tpgSuchen.Controls.Add(this.lblUser);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblUser, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUser, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblYear, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDate, 0);
            //
            // lblUser
            //
            this.lblUser.Location = new System.Drawing.Point(8, 75);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(120, 24);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Sachbearbeiter/in";
            this.lblUser.UseCompatibleTextRendering = true;
            //
            // edtUser
            //
            this.edtUser.Location = new System.Drawing.Point(147, 74);
            this.edtUser.Name = "edtUser";
            this.edtUser.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUser.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUser.Properties.Appearance.Options.UseBackColor = true;
            this.edtUser.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUser.Properties.Appearance.Options.UseFont = true;
            this.edtUser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtUser.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUser.Size = new System.Drawing.Size(328, 24);
            this.edtUser.TabIndex = 2;
            this.edtUser.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtUser_UserModifiedFld);
            //
            // lblYear
            //
            this.lblYear.Location = new System.Drawing.Point(8, 104);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(120, 24);
            this.lblYear.TabIndex = 3;
            this.lblYear.Text = "Stichtag";
            this.lblYear.UseCompatibleTextRendering = true;
            //
            // edtDate
            //
            this.edtDate.EditValue = null;
            this.edtDate.Location = new System.Drawing.Point(147, 104);
            this.edtDate.Name = "edtDate";
            this.edtDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.edtDate.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDate.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDate.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDate.Properties.Appearance.Options.UseBackColor = true;
            this.edtDate.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDate.Properties.Appearance.Options.UseFont = true;
            this.edtDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtDate.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDate.Properties.ShowToday = false;
            this.edtDate.Size = new System.Drawing.Size(118, 24);
            this.edtDate.TabIndex = 4;
            //
            // colFalltraeger_FallNummer
            //
            this.colFalltraeger_FallNummer.Caption = "Falltraeger_FallNummer";
            this.colFalltraeger_FallNummer.FieldName = "Falltraeger_FallNummer";
            this.colFalltraeger_FallNummer.Name = "colFalltraeger_FallNummer";
            this.colFalltraeger_FallNummer.Visible = true;
            this.colFalltraeger_FallNummer.VisibleIndex = 3;
            //
            // colFalltraeger_Name
            //
            this.colFalltraeger_Name.Caption = "Falltraeger_Name";
            this.colFalltraeger_Name.FieldName = "Falltraeger_Name";
            this.colFalltraeger_Name.Name = "colFalltraeger_Name";
            this.colFalltraeger_Name.Visible = true;
            this.colFalltraeger_Name.VisibleIndex = 0;
            //
            // colFalltraeger_PersonenNummer
            //
            this.colFalltraeger_PersonenNummer.Caption = "Falltraeger_PersonenNummer";
            this.colFalltraeger_PersonenNummer.FieldName = "Falltraeger_PersonenNummer";
            this.colFalltraeger_PersonenNummer.Name = "colFalltraeger_PersonenNummer";
            this.colFalltraeger_PersonenNummer.Visible = true;
            this.colFalltraeger_PersonenNummer.VisibleIndex = 2;
            //
            // colFalltraeger_Vorname
            //
            this.colFalltraeger_Vorname.Caption = "Falltraeger_Vorname";
            this.colFalltraeger_Vorname.FieldName = "Falltraeger_Vorname";
            this.colFalltraeger_Vorname.Name = "colFalltraeger_Vorname";
            this.colFalltraeger_Vorname.Visible = true;
            this.colFalltraeger_Vorname.VisibleIndex = 1;
            //
            // colFalltraegerFallNummer
            //
            this.colFalltraegerFallNummer.Name = "colFalltraegerFallNummer";
            //
            // colFalltraegerName
            //
            this.colFalltraegerName.Name = "colFalltraegerName";
            //
            // colFalltraegerPersonenNummer
            //
            this.colFalltraegerPersonenNummer.Name = "colFalltraegerPersonenNummer";
            //
            // colFalltraegerVorname
            //
            this.colFalltraegerVorname.Name = "colFalltraegerVorname";
            //
            // colGlb01_AlteKiZu
            //
            this.colGlb01_AlteKiZu.Caption = "Glb01_AlteKiZu";
            this.colGlb01_AlteKiZu.FieldName = "Glb01_AlteKiZu";
            this.colGlb01_AlteKiZu.Name = "colGlb01_AlteKiZu";
            this.colGlb01_AlteKiZu.Visible = true;
            this.colGlb01_AlteKiZu.VisibleIndex = 7;
            //
            // colGlb01_BaPersonID
            //
            this.colGlb01_BaPersonID.Caption = "Glb01_BaPersonID";
            this.colGlb01_BaPersonID.FieldName = "Glb01_BaPersonID";
            this.colGlb01_BaPersonID.Name = "colGlb01_BaPersonID";
            this.colGlb01_BaPersonID.Visible = true;
            this.colGlb01_BaPersonID.VisibleIndex = 4;
            //
            // colGlb01_Geburtsdatum
            //
            this.colGlb01_Geburtsdatum.Caption = "Glb01_Geburtsdatum";
            this.colGlb01_Geburtsdatum.FieldName = "Glb01_Geburtsdatum";
            this.colGlb01_Geburtsdatum.Name = "colGlb01_Geburtsdatum";
            this.colGlb01_Geburtsdatum.Visible = true;
            this.colGlb01_Geburtsdatum.VisibleIndex = 6;
            //
            // colGlb01_VornameName
            //
            this.colGlb01_VornameName.Caption = "Glb01_VornameName";
            this.colGlb01_VornameName.FieldName = "Glb01_VornameName";
            this.colGlb01_VornameName.Name = "colGlb01_VornameName";
            this.colGlb01_VornameName.Visible = true;
            this.colGlb01_VornameName.VisibleIndex = 5;
            //
            // colGlb01AlteKiZu
            //
            this.colGlb01AlteKiZu.Name = "colGlb01AlteKiZu";
            //
            // colGlb01BaPersonID
            //
            this.colGlb01BaPersonID.Name = "colGlb01BaPersonID";
            //
            // colGlb01Geburtsdatum
            //
            this.colGlb01Geburtsdatum.Name = "colGlb01Geburtsdatum";
            //
            // colGlb01Teuerungseinsprache
            //
            this.colGlb01Teuerungseinsprache.Name = "colGlb01Teuerungseinsprache";
            //
            // colGlb01VornameName
            //
            this.colGlb01VornameName.Name = "colGlb01VornameName";
            //
            // colGlb02_AlteKiZu
            //
            this.colGlb02_AlteKiZu.Caption = "Glb02_AlteKiZu";
            this.colGlb02_AlteKiZu.FieldName = "Glb02_AlteKiZu";
            this.colGlb02_AlteKiZu.Name = "colGlb02_AlteKiZu";
            this.colGlb02_AlteKiZu.Visible = true;
            this.colGlb02_AlteKiZu.VisibleIndex = 11;
            //
            // colGlb02_BaPersonID
            //
            this.colGlb02_BaPersonID.Caption = "Glb02_BaPersonID";
            this.colGlb02_BaPersonID.FieldName = "Glb02_BaPersonID";
            this.colGlb02_BaPersonID.Name = "colGlb02_BaPersonID";
            this.colGlb02_BaPersonID.Visible = true;
            this.colGlb02_BaPersonID.VisibleIndex = 8;
            //
            // colGlb02_Geburtsdatum
            //
            this.colGlb02_Geburtsdatum.Caption = "Glb02_Geburtsdatum";
            this.colGlb02_Geburtsdatum.FieldName = "Glb02_Geburtsdatum";
            this.colGlb02_Geburtsdatum.Name = "colGlb02_Geburtsdatum";
            this.colGlb02_Geburtsdatum.Visible = true;
            this.colGlb02_Geburtsdatum.VisibleIndex = 10;
            //
            // colGlb02_VornameName
            //
            this.colGlb02_VornameName.Caption = "Glb02_VornameName";
            this.colGlb02_VornameName.FieldName = "Glb02_VornameName";
            this.colGlb02_VornameName.Name = "colGlb02_VornameName";
            this.colGlb02_VornameName.Visible = true;
            this.colGlb02_VornameName.VisibleIndex = 9;
            //
            // colGlb02AlteKiZu
            //
            this.colGlb02AlteKiZu.Name = "colGlb02AlteKiZu";
            //
            // colGlb02BaPersonID
            //
            this.colGlb02BaPersonID.Name = "colGlb02BaPersonID";
            //
            // colGlb02Geburtsdatum
            //
            this.colGlb02Geburtsdatum.Name = "colGlb02Geburtsdatum";
            //
            // colGlb02Teuerungseinsprache
            //
            this.colGlb02Teuerungseinsprache.Name = "colGlb02Teuerungseinsprache";
            //
            // colGlb02VornameName
            //
            this.colGlb02VornameName.Name = "colGlb02VornameName";
            //
            // colGlb03_AlteKiZu
            //
            this.colGlb03_AlteKiZu.Caption = "Glb03_AlteKiZu";
            this.colGlb03_AlteKiZu.FieldName = "Glb03_AlteKiZu";
            this.colGlb03_AlteKiZu.Name = "colGlb03_AlteKiZu";
            this.colGlb03_AlteKiZu.Visible = true;
            this.colGlb03_AlteKiZu.VisibleIndex = 15;
            //
            // colGlb03_BaPersonID
            //
            this.colGlb03_BaPersonID.Caption = "Glb03_BaPersonID";
            this.colGlb03_BaPersonID.FieldName = "Glb03_BaPersonID";
            this.colGlb03_BaPersonID.Name = "colGlb03_BaPersonID";
            this.colGlb03_BaPersonID.Visible = true;
            this.colGlb03_BaPersonID.VisibleIndex = 12;
            //
            // colGlb03_Geburtsdatum
            //
            this.colGlb03_Geburtsdatum.Caption = "Glb03_Geburtsdatum";
            this.colGlb03_Geburtsdatum.FieldName = "Glb03_Geburtsdatum";
            this.colGlb03_Geburtsdatum.Name = "colGlb03_Geburtsdatum";
            this.colGlb03_Geburtsdatum.Visible = true;
            this.colGlb03_Geburtsdatum.VisibleIndex = 14;
            //
            // colGlb03_VornameName
            //
            this.colGlb03_VornameName.Caption = "Glb03_VornameName";
            this.colGlb03_VornameName.FieldName = "Glb03_VornameName";
            this.colGlb03_VornameName.Name = "colGlb03_VornameName";
            this.colGlb03_VornameName.Visible = true;
            this.colGlb03_VornameName.VisibleIndex = 13;
            //
            // colGlb03AlteKiZu
            //
            this.colGlb03AlteKiZu.Name = "colGlb03AlteKiZu";
            //
            // colGlb03BaPersonID
            //
            this.colGlb03BaPersonID.Name = "colGlb03BaPersonID";
            //
            // colGlb03Geburtsdatum
            //
            this.colGlb03Geburtsdatum.Name = "colGlb03Geburtsdatum";
            //
            // colGlb03Teuerungseinsprache
            //
            this.colGlb03Teuerungseinsprache.Name = "colGlb03Teuerungseinsprache";
            //
            // colGlb03VornameName
            //
            this.colGlb03VornameName.Name = "colGlb03VornameName";
            //
            // colGlb04_AlteKiZu
            //
            this.colGlb04_AlteKiZu.Caption = "Glb04_AlteKiZu";
            this.colGlb04_AlteKiZu.FieldName = "Glb04_AlteKiZu";
            this.colGlb04_AlteKiZu.Name = "colGlb04_AlteKiZu";
            this.colGlb04_AlteKiZu.Visible = true;
            this.colGlb04_AlteKiZu.VisibleIndex = 19;
            //
            // colGlb04_BaPersonID
            //
            this.colGlb04_BaPersonID.Caption = "Glb04_BaPersonID";
            this.colGlb04_BaPersonID.FieldName = "Glb04_BaPersonID";
            this.colGlb04_BaPersonID.Name = "colGlb04_BaPersonID";
            this.colGlb04_BaPersonID.Visible = true;
            this.colGlb04_BaPersonID.VisibleIndex = 16;
            //
            // colGlb04_Geburtsdatum
            //
            this.colGlb04_Geburtsdatum.Caption = "Glb04_Geburtsdatum";
            this.colGlb04_Geburtsdatum.FieldName = "Glb04_Geburtsdatum";
            this.colGlb04_Geburtsdatum.Name = "colGlb04_Geburtsdatum";
            this.colGlb04_Geburtsdatum.Visible = true;
            this.colGlb04_Geburtsdatum.VisibleIndex = 18;
            //
            // colGlb04_VornameName
            //
            this.colGlb04_VornameName.Caption = "Glb04_VornameName";
            this.colGlb04_VornameName.FieldName = "Glb04_VornameName";
            this.colGlb04_VornameName.Name = "colGlb04_VornameName";
            this.colGlb04_VornameName.Visible = true;
            this.colGlb04_VornameName.VisibleIndex = 17;
            //
            // colGlb04AlteKiZu
            //
            this.colGlb04AlteKiZu.Name = "colGlb04AlteKiZu";
            //
            // colGlb04BaPersonID
            //
            this.colGlb04BaPersonID.Name = "colGlb04BaPersonID";
            //
            // colGlb04Geburtsdatum
            //
            this.colGlb04Geburtsdatum.Name = "colGlb04Geburtsdatum";
            //
            // colGlb04Teuerungseinsprache
            //
            this.colGlb04Teuerungseinsprache.Name = "colGlb04Teuerungseinsprache";
            //
            // colGlb04VornameName
            //
            this.colGlb04VornameName.Name = "colGlb04VornameName";
            //
            // colGlb05_AlteKiZu
            //
            this.colGlb05_AlteKiZu.Caption = "Glb05_AlteKiZu";
            this.colGlb05_AlteKiZu.FieldName = "Glb05_AlteKiZu";
            this.colGlb05_AlteKiZu.Name = "colGlb05_AlteKiZu";
            this.colGlb05_AlteKiZu.Visible = true;
            this.colGlb05_AlteKiZu.VisibleIndex = 23;
            //
            // colGlb05_BaPersonID
            //
            this.colGlb05_BaPersonID.Caption = "Glb05_BaPersonID";
            this.colGlb05_BaPersonID.FieldName = "Glb05_BaPersonID";
            this.colGlb05_BaPersonID.Name = "colGlb05_BaPersonID";
            this.colGlb05_BaPersonID.Visible = true;
            this.colGlb05_BaPersonID.VisibleIndex = 20;
            //
            // colGlb05_Geburtsdatum
            //
            this.colGlb05_Geburtsdatum.Caption = "Glb05_Geburtsdatum";
            this.colGlb05_Geburtsdatum.FieldName = "Glb05_Geburtsdatum";
            this.colGlb05_Geburtsdatum.Name = "colGlb05_Geburtsdatum";
            this.colGlb05_Geburtsdatum.Visible = true;
            this.colGlb05_Geburtsdatum.VisibleIndex = 22;
            //
            // colGlb05_VornameName
            //
            this.colGlb05_VornameName.Caption = "Glb05_VornameName";
            this.colGlb05_VornameName.FieldName = "Glb05_VornameName";
            this.colGlb05_VornameName.Name = "colGlb05_VornameName";
            this.colGlb05_VornameName.Visible = true;
            this.colGlb05_VornameName.VisibleIndex = 21;
            //
            // colGlb05AlteKiZu
            //
            this.colGlb05AlteKiZu.Name = "colGlb05AlteKiZu";
            //
            // colGlb05BaPersonID
            //
            this.colGlb05BaPersonID.Name = "colGlb05BaPersonID";
            //
            // colGlb05Geburtsdatum
            //
            this.colGlb05Geburtsdatum.Name = "colGlb05Geburtsdatum";
            //
            // colGlb05Teuerungseinsprache
            //
            this.colGlb05Teuerungseinsprache.Name = "colGlb05Teuerungseinsprache";
            //
            // colGlb05VornameName
            //
            this.colGlb05VornameName.Name = "colGlb05VornameName";
            //
            // colGlb06_AlteKiZu
            //
            this.colGlb06_AlteKiZu.Caption = "Glb06_AlteKiZu";
            this.colGlb06_AlteKiZu.FieldName = "Glb06_AlteKiZu";
            this.colGlb06_AlteKiZu.Name = "colGlb06_AlteKiZu";
            this.colGlb06_AlteKiZu.Visible = true;
            this.colGlb06_AlteKiZu.VisibleIndex = 27;
            //
            // colGlb06_BaPersonID
            //
            this.colGlb06_BaPersonID.Caption = "Glb06_BaPersonID";
            this.colGlb06_BaPersonID.FieldName = "Glb06_BaPersonID";
            this.colGlb06_BaPersonID.Name = "colGlb06_BaPersonID";
            this.colGlb06_BaPersonID.Visible = true;
            this.colGlb06_BaPersonID.VisibleIndex = 24;
            //
            // colGlb06_Geburtsdatum
            //
            this.colGlb06_Geburtsdatum.Caption = "Glb06_Geburtsdatum";
            this.colGlb06_Geburtsdatum.FieldName = "Glb06_Geburtsdatum";
            this.colGlb06_Geburtsdatum.Name = "colGlb06_Geburtsdatum";
            this.colGlb06_Geburtsdatum.Visible = true;
            this.colGlb06_Geburtsdatum.VisibleIndex = 26;
            //
            // colGlb06_VornameName
            //
            this.colGlb06_VornameName.Caption = "Glb06_VornameName";
            this.colGlb06_VornameName.FieldName = "Glb06_VornameName";
            this.colGlb06_VornameName.Name = "colGlb06_VornameName";
            this.colGlb06_VornameName.Visible = true;
            this.colGlb06_VornameName.VisibleIndex = 25;
            //
            // colGlb06AlteKiZu
            //
            this.colGlb06AlteKiZu.Name = "colGlb06AlteKiZu";
            //
            // colGlb06BaPersonID
            //
            this.colGlb06BaPersonID.Name = "colGlb06BaPersonID";
            //
            // colGlb06Geburtsdatum
            //
            this.colGlb06Geburtsdatum.Name = "colGlb06Geburtsdatum";
            //
            // colGlb06Teuerungseinsprache
            //
            this.colGlb06Teuerungseinsprache.Name = "colGlb06Teuerungseinsprache";
            //
            // colGlb06VornameName
            //
            this.colGlb06VornameName.Name = "colGlb06VornameName";
            //
            // colGlb07_AlteKiZu
            //
            this.colGlb07_AlteKiZu.Caption = "Glb07_AlteKiZu";
            this.colGlb07_AlteKiZu.FieldName = "Glb07_AlteKiZu";
            this.colGlb07_AlteKiZu.Name = "colGlb07_AlteKiZu";
            this.colGlb07_AlteKiZu.Visible = true;
            this.colGlb07_AlteKiZu.VisibleIndex = 31;
            //
            // colGlb07_BaPersonID
            //
            this.colGlb07_BaPersonID.Caption = "Glb07_BaPersonID";
            this.colGlb07_BaPersonID.FieldName = "Glb07_BaPersonID";
            this.colGlb07_BaPersonID.Name = "colGlb07_BaPersonID";
            this.colGlb07_BaPersonID.Visible = true;
            this.colGlb07_BaPersonID.VisibleIndex = 28;
            //
            // colGlb07_Geburtsdatum
            //
            this.colGlb07_Geburtsdatum.Caption = "Glb07_Geburtsdatum";
            this.colGlb07_Geburtsdatum.FieldName = "Glb07_Geburtsdatum";
            this.colGlb07_Geburtsdatum.Name = "colGlb07_Geburtsdatum";
            this.colGlb07_Geburtsdatum.Visible = true;
            this.colGlb07_Geburtsdatum.VisibleIndex = 30;
            //
            // colGlb07_VornameName
            //
            this.colGlb07_VornameName.Caption = "Glb07_VornameName";
            this.colGlb07_VornameName.FieldName = "Glb07_VornameName";
            this.colGlb07_VornameName.Name = "colGlb07_VornameName";
            this.colGlb07_VornameName.Visible = true;
            this.colGlb07_VornameName.VisibleIndex = 29;
            //
            // colGlb07AlteKiZu
            //
            this.colGlb07AlteKiZu.Name = "colGlb07AlteKiZu";
            //
            // colGlb07BaPersonID
            //
            this.colGlb07BaPersonID.Name = "colGlb07BaPersonID";
            //
            // colGlb07Geburtsdatum
            //
            this.colGlb07Geburtsdatum.Name = "colGlb07Geburtsdatum";
            //
            // colGlb07Teuerungseinsprache
            //
            this.colGlb07Teuerungseinsprache.Name = "colGlb07Teuerungseinsprache";
            //
            // colGlb07VornameName
            //
            this.colGlb07VornameName.Name = "colGlb07VornameName";
            //
            // colGlb08_AlteKiZu
            //
            this.colGlb08_AlteKiZu.Caption = "Glb08_AlteKiZu";
            this.colGlb08_AlteKiZu.FieldName = "Glb08_AlteKiZu";
            this.colGlb08_AlteKiZu.Name = "colGlb08_AlteKiZu";
            this.colGlb08_AlteKiZu.Visible = true;
            this.colGlb08_AlteKiZu.VisibleIndex = 35;
            //
            // colGlb08_BaPersonID
            //
            this.colGlb08_BaPersonID.Caption = "Glb08_BaPersonID";
            this.colGlb08_BaPersonID.FieldName = "Glb08_BaPersonID";
            this.colGlb08_BaPersonID.Name = "colGlb08_BaPersonID";
            this.colGlb08_BaPersonID.Visible = true;
            this.colGlb08_BaPersonID.VisibleIndex = 32;
            //
            // colGlb08_Geburtsdatum
            //
            this.colGlb08_Geburtsdatum.Caption = "Glb08_Geburtsdatum";
            this.colGlb08_Geburtsdatum.FieldName = "Glb08_Geburtsdatum";
            this.colGlb08_Geburtsdatum.Name = "colGlb08_Geburtsdatum";
            this.colGlb08_Geburtsdatum.Visible = true;
            this.colGlb08_Geburtsdatum.VisibleIndex = 34;
            //
            // colGlb08_VornameName
            //
            this.colGlb08_VornameName.Caption = "Glb08_VornameName";
            this.colGlb08_VornameName.FieldName = "Glb08_VornameName";
            this.colGlb08_VornameName.Name = "colGlb08_VornameName";
            this.colGlb08_VornameName.Visible = true;
            this.colGlb08_VornameName.VisibleIndex = 33;
            //
            // colGlb08AlteKiZu
            //
            this.colGlb08AlteKiZu.Name = "colGlb08AlteKiZu";
            //
            // colGlb08BaPersonID
            //
            this.colGlb08BaPersonID.Name = "colGlb08BaPersonID";
            //
            // colGlb08Geburtsdatum
            //
            this.colGlb08Geburtsdatum.Name = "colGlb08Geburtsdatum";
            //
            // colGlb08Teuerungseinsprache
            //
            this.colGlb08Teuerungseinsprache.Name = "colGlb08Teuerungseinsprache";
            //
            // colGlb08VornameName
            //
            this.colGlb08VornameName.Name = "colGlb08VornameName";
            //
            // colGlb09_AlteKiZu
            //
            this.colGlb09_AlteKiZu.Caption = "Glb09_AlteKiZu";
            this.colGlb09_AlteKiZu.FieldName = "Glb09_AlteKiZu";
            this.colGlb09_AlteKiZu.Name = "colGlb09_AlteKiZu";
            this.colGlb09_AlteKiZu.Visible = true;
            this.colGlb09_AlteKiZu.VisibleIndex = 39;
            //
            // colGlb09_BaPersonID
            //
            this.colGlb09_BaPersonID.Caption = "Glb09_BaPersonID";
            this.colGlb09_BaPersonID.FieldName = "Glb09_BaPersonID";
            this.colGlb09_BaPersonID.Name = "colGlb09_BaPersonID";
            this.colGlb09_BaPersonID.Visible = true;
            this.colGlb09_BaPersonID.VisibleIndex = 36;
            //
            // colGlb09_Geburtsdatum
            //
            this.colGlb09_Geburtsdatum.Caption = "Glb09_Geburtsdatum";
            this.colGlb09_Geburtsdatum.FieldName = "Glb09_Geburtsdatum";
            this.colGlb09_Geburtsdatum.Name = "colGlb09_Geburtsdatum";
            this.colGlb09_Geburtsdatum.Visible = true;
            this.colGlb09_Geburtsdatum.VisibleIndex = 38;
            //
            // colGlb09_VornameName
            //
            this.colGlb09_VornameName.Caption = "Glb09_VornameName";
            this.colGlb09_VornameName.FieldName = "Glb09_VornameName";
            this.colGlb09_VornameName.Name = "colGlb09_VornameName";
            this.colGlb09_VornameName.Visible = true;
            this.colGlb09_VornameName.VisibleIndex = 37;
            //
            // colGlb09AlteKiZu
            //
            this.colGlb09AlteKiZu.Name = "colGlb09AlteKiZu";
            //
            // colGlb09BaPersonID
            //
            this.colGlb09BaPersonID.Name = "colGlb09BaPersonID";
            //
            // colGlb09Geburtsdatum
            //
            this.colGlb09Geburtsdatum.Name = "colGlb09Geburtsdatum";
            //
            // colGlb09Teuerungseinsprache
            //
            this.colGlb09Teuerungseinsprache.Name = "colGlb09Teuerungseinsprache";
            //
            // colGlb09VornameName
            //
            this.colGlb09VornameName.Name = "colGlb09VornameName";
            //
            // colGlb10_AlteKiZu
            //
            this.colGlb10_AlteKiZu.Caption = "Glb10_AlteKiZu";
            this.colGlb10_AlteKiZu.FieldName = "Glb10_AlteKiZu";
            this.colGlb10_AlteKiZu.Name = "colGlb10_AlteKiZu";
            this.colGlb10_AlteKiZu.Visible = true;
            this.colGlb10_AlteKiZu.VisibleIndex = 43;
            //
            // colGlb10_BaPersonID
            //
            this.colGlb10_BaPersonID.Caption = "Glb10_BaPersonID";
            this.colGlb10_BaPersonID.FieldName = "Glb10_BaPersonID";
            this.colGlb10_BaPersonID.Name = "colGlb10_BaPersonID";
            this.colGlb10_BaPersonID.Visible = true;
            this.colGlb10_BaPersonID.VisibleIndex = 40;
            //
            // colGlb10_Geburtsdatum
            //
            this.colGlb10_Geburtsdatum.Caption = "Glb10_Geburtsdatum";
            this.colGlb10_Geburtsdatum.FieldName = "Glb10_Geburtsdatum";
            this.colGlb10_Geburtsdatum.Name = "colGlb10_Geburtsdatum";
            this.colGlb10_Geburtsdatum.Visible = true;
            this.colGlb10_Geburtsdatum.VisibleIndex = 42;
            //
            // colGlb10_VornameName
            //
            this.colGlb10_VornameName.Caption = "Glb10_VornameName";
            this.colGlb10_VornameName.FieldName = "Glb10_VornameName";
            this.colGlb10_VornameName.Name = "colGlb10_VornameName";
            this.colGlb10_VornameName.Visible = true;
            this.colGlb10_VornameName.VisibleIndex = 41;
            //
            // colGlb10AlteKiZu
            //
            this.colGlb10AlteKiZu.Name = "colGlb10AlteKiZu";
            //
            // colGlb10BaPersonID
            //
            this.colGlb10BaPersonID.Name = "colGlb10BaPersonID";
            //
            // colGlb10Geburtsdatum
            //
            this.colGlb10Geburtsdatum.Name = "colGlb10Geburtsdatum";
            //
            // colGlb10Teuerungseinsprache
            //
            this.colGlb10Teuerungseinsprache.Name = "colGlb10Teuerungseinsprache";
            //
            // colGlb10VornameName
            //
            this.colGlb10VornameName.Name = "colGlb10VornameName";
            //
            // colKopieAn
            //
            this.colKopieAn.Caption = "KopieAn";
            this.colKopieAn.FieldName = "KopieAn";
            this.colKopieAn.Name = "colKopieAn";
            this.colKopieAn.Visible = true;
            this.colKopieAn.VisibleIndex = 47;
            //
            // colKopieAn_QT
            //
            this.colKopieAn_QT.Caption = "KopieAn_QT";
            this.colKopieAn_QT.FieldName = "KopieAn_QT";
            this.colKopieAn_QT.Name = "colKopieAn_QT";
            this.colKopieAn_QT.Visible = true;
            this.colKopieAn_QT.VisibleIndex = 49;
            //
            // colKopieAn_SZ
            //
            this.colKopieAn_SZ.Caption = "KopieAn_SZ";
            this.colKopieAn_SZ.FieldName = "KopieAn_SZ";
            this.colKopieAn_SZ.Name = "colKopieAn_SZ";
            this.colKopieAn_SZ.Visible = true;
            this.colKopieAn_SZ.VisibleIndex = 48;
            //
            // colKopieAnQT
            //
            this.colKopieAnQT.Name = "colKopieAnQT";
            //
            // colKopieAnSozZentrum
            //
            this.colKopieAnSozZentrum.Name = "colKopieAnSozZentrum";
            //
            // colRTDatum
            //
            this.colRTDatum.Name = "colRTDatum";
            //
            // colRTInfo
            //
            this.colRTInfo.Name = "colRTInfo";
            //
            // colRTTeuerungseinsprache
            //
            this.colRTTeuerungseinsprache.Name = "colRTTeuerungseinsprache";
            //
            // colRTTyp
            //
            this.colRTTyp.Name = "colRTTyp";
            //
            // colSB_Displayname
            //
            this.colSB_Displayname.Caption = "SB_Displayname";
            this.colSB_Displayname.FieldName = "SB_Displayname";
            this.colSB_Displayname.Name = "colSB_Displayname";
            this.colSB_Displayname.Visible = true;
            this.colSB_Displayname.VisibleIndex = 46;
            //
            // colSB_LogonName
            //
            this.colSB_LogonName.Caption = "SB_LogonName";
            this.colSB_LogonName.FieldName = "SB_LogonName";
            this.colSB_LogonName.Name = "colSB_LogonName";
            this.colSB_LogonName.Visible = true;
            this.colSB_LogonName.VisibleIndex = 44;
            //
            // colSB_VornameName
            //
            this.colSB_VornameName.Caption = "SB_VornameName";
            this.colSB_VornameName.FieldName = "SB_VornameName";
            this.colSB_VornameName.Name = "colSB_VornameName";
            this.colSB_VornameName.Visible = true;
            this.colSB_VornameName.VisibleIndex = 45;
            //
            // colSBDisplayname
            //
            this.colSBDisplayname.Name = "colSBDisplayname";
            //
            // colSBLogonName
            //
            this.colSBLogonName.Name = "colSBLogonName";
            //
            // colSBVornameName
            //
            this.colSBVornameName.Name = "colSBVornameName";
            //
            // colSchuldnerAnrede
            //
            this.colSchuldnerAnrede.Name = "colSchuldnerAnrede";
            //
            // colSchuldnerName
            //
            this.colSchuldnerName.Name = "colSchuldnerName";
            //
            // colSchuldnerOrt
            //
            this.colSchuldnerOrt.Name = "colSchuldnerOrt";
            //
            // colSchuldnerPersonenNummer
            //
            this.colSchuldnerPersonenNummer.Name = "colSchuldnerPersonenNummer";
            //
            // colSchuldnerPLZ
            //
            this.colSchuldnerPLZ.Name = "colSchuldnerPLZ";
            //
            // colSchuldnerPostfach
            //
            this.colSchuldnerPostfach.Name = "colSchuldnerPostfach";
            //
            // colSchuldnerStrasse
            //
            this.colSchuldnerStrasse.Name = "colSchuldnerStrasse";
            //
            // colSchuldnerVorname
            //
            this.colSchuldnerVorname.Name = "colSchuldnerVorname";
            //
            // colSchuldnerZusatz
            //
            this.colSchuldnerZusatz.Name = "colSchuldnerZusatz";
            //
            // grvQuery1
            //
            this.grvQuery1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvQuery1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Empty.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Empty.Options.UseFont = true;
            this.grvQuery1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvQuery1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.EvenRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvQuery1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvQuery1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvQuery1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.OddRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.Options.UseFont = true;
            this.grvQuery1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Row.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Row.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvQuery1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvQuery1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.VertLine.Options.UseBackColor = true;
            this.grvQuery1.GridControl = this.grdQuery1;
            this.grvQuery1.Name = "grvQuery1";
            this.grvQuery1.OptionsBehavior.Editable = false;
            this.grvQuery1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvQuery1.OptionsNavigation.AutoFocusNewRow = true;
            this.grvQuery1.OptionsNavigation.UseTabKey = false;
            this.grvQuery1.OptionsPrint.AutoWidth = false;
            this.grvQuery1.OptionsPrint.ExpandAllDetails = true;
            this.grvQuery1.OptionsPrint.UsePrintStyles = true;
            this.grvQuery1.OptionsView.ColumnAutoWidth = false;
            this.grvQuery1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvQuery1.OptionsView.ShowGroupPanel = false;
            this.grvQuery1.OptionsView.ShowIndicator = false;
            //
            // gvwQuery
            //
            this.gvwQuery.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gvwQuery.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwQuery.Appearance.Empty.Options.UseBackColor = true;
            this.gvwQuery.Appearance.Empty.Options.UseFont = true;
            this.gvwQuery.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwQuery.Appearance.EvenRow.Options.UseFont = true;
            this.gvwQuery.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvwQuery.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwQuery.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gvwQuery.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvwQuery.Appearance.FocusedCell.Options.UseFont = true;
            this.gvwQuery.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvwQuery.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvwQuery.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwQuery.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvwQuery.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvwQuery.Appearance.FocusedRow.Options.UseFont = true;
            this.gvwQuery.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvwQuery.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvwQuery.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvwQuery.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvwQuery.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvwQuery.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvwQuery.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvwQuery.Appearance.GroupRow.Options.UseFont = true;
            this.gvwQuery.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvwQuery.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvwQuery.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvwQuery.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvwQuery.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvwQuery.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvwQuery.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvwQuery.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gvwQuery.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwQuery.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvwQuery.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvwQuery.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvwQuery.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvwQuery.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gvwQuery.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvwQuery.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwQuery.Appearance.OddRow.Options.UseFont = true;
            this.gvwQuery.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gvwQuery.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwQuery.Appearance.Row.Options.UseBackColor = true;
            this.gvwQuery.Appearance.Row.Options.UseFont = true;
            this.gvwQuery.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwQuery.Appearance.SelectedRow.Options.UseFont = true;
            this.gvwQuery.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gvwQuery.Appearance.VertLine.Options.UseBackColor = true;
            this.gvwQuery.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvwQuery.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colFalltraeger_Name,
                        this.colFalltraeger_Vorname,
                        this.colFalltraeger_PersonenNummer,
                        this.colFalltraeger_FallNummer,
                        this.colGlb01_BaPersonID,
                        this.colGlb01_VornameName,
                        this.colGlb01_Geburtsdatum,
                        this.colGlb01_AlteKiZu,
                        this.colGlb02_BaPersonID,
                        this.colGlb02_VornameName,
                        this.colGlb02_Geburtsdatum,
                        this.colGlb02_AlteKiZu,
                        this.colGlb03_BaPersonID,
                        this.colGlb03_VornameName,
                        this.colGlb03_Geburtsdatum,
                        this.colGlb03_AlteKiZu,
                        this.colGlb04_BaPersonID,
                        this.colGlb04_VornameName,
                        this.colGlb04_Geburtsdatum,
                        this.colGlb04_AlteKiZu,
                        this.colGlb05_BaPersonID,
                        this.colGlb05_VornameName,
                        this.colGlb05_Geburtsdatum,
                        this.colGlb05_AlteKiZu,
                        this.colGlb06_BaPersonID,
                        this.colGlb06_VornameName,
                        this.colGlb06_Geburtsdatum,
                        this.colGlb06_AlteKiZu,
                        this.colGlb07_BaPersonID,
                        this.colGlb07_VornameName,
                        this.colGlb07_Geburtsdatum,
                        this.colGlb07_AlteKiZu,
                        this.colGlb08_BaPersonID,
                        this.colGlb08_VornameName,
                        this.colGlb08_Geburtsdatum,
                        this.colGlb08_AlteKiZu,
                        this.colGlb09_BaPersonID,
                        this.colGlb09_VornameName,
                        this.colGlb09_Geburtsdatum,
                        this.colGlb09_AlteKiZu,
                        this.colGlb10_BaPersonID,
                        this.colGlb10_VornameName,
                        this.colGlb10_Geburtsdatum,
                        this.colGlb10_AlteKiZu,
                        this.colSB_LogonName,
                        this.colSB_VornameName,
                        this.colSB_Displayname,
                        this.colKopieAn,
                        this.colKopieAn_SZ,
                        this.colKopieAn_QT});
            this.gvwQuery.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvwQuery.GridControl = this.grdQuery1;
            this.gvwQuery.Name = "gvwQuery";
            this.gvwQuery.OptionsBehavior.Editable = false;
            this.gvwQuery.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvwQuery.OptionsNavigation.AutoFocusNewRow = true;
            this.gvwQuery.OptionsNavigation.UseTabKey = false;
            this.gvwQuery.OptionsView.ColumnAutoWidth = false;
            this.gvwQuery.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvwQuery.OptionsView.ShowGroupPanel = false;
            this.gvwQuery.OptionsView.ShowIndicator = false;
            //
            // CtlQueryIkKinderzulagen
            //
            this.Name = "CtlQueryIkKinderzulagen";
            this.Load += new System.EventHandler(this.CtlQueryIkKinderzulagen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwQuery)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region Protected Methods


        // Letzte Bearbeitung
        // 24.11.2008 : sozheo : neu
        // -------------------------------------------------------------
        protected override void NewSearch()
        {
            // Alte Suchwerte speichern
              edtDate.EditValue = OldDate;
              edtUser.LookupID = FilterUserID;
              edtUser.EditValue = FilterUserText;
              edtUser.ToolTip = FilterUserText;
              base.NewSearch();
        }

        protected override void RunSearch()
        {
            if (DBUtil.IsEmpty(edtDate.EditValue))
              {
            KissMsg.ShowInfo("W�hlen Sie zuerst ein Datum aus.");
            throw new KissCancelException();
              }

              // Alte Suchwerte speichern
              OldDate = edtDate.DateTime;
              FilterUserText = Utils.ConvertToString(edtUser.EditValue);

              // Fixe Parameter
              object[] parameters = new object[] {
            OldDate,
            FilterUserID
              };
              this.kissSearch.SelectParameters = parameters;
              base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void CtlQueryIkKinderzulagen_Load(object sender, System.EventArgs e)
        {
            // Letzte Bearbeitung
            // 24.11.2008 : sozheo : neu
            // 02.12.2008 : sozheo : neu auch die folgenden 10 Jahre anzeigen
            // 08.12.2008 : sozheo : es soll immer nach Stichtag gesucht werrden
            // -----------------------------------------------------------------

            // Auswahl Jahre f�llen
            //int AYear = DateTime.Today.Year + 10;
            //for (int i = AYear; i > AYear - 20; i--) edtYear.Properties.Items.Add(i);

            FilterUserID = Session.User.UserID;
            SqlQuery qry = DBUtil.OpenSQL("select DisplayText from dbo.vwUser where UserID = {0}", Session.User.UserID);
            edtUser.LookupID = FilterUserID;
            edtUser.EditValue = Utils.ConvertToString(qry["DisplayText"]);
            edtDate.EditValue = DateTime.Today;
            tabControlSearch.SelectedTabIndex = 1;
        }

        private void edtUser_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            // Letzte Bearbeitung
            // 24.11.2008 : sozheo : neu
            // -------------------------------------------------------------

            string SearchString = edtUser.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
              if (e.ButtonClicked) SearchString = "";
              else
              {

                FilterUserID = 0;
                edtUser.LookupID = 0;
                edtUser.EditValue = "";
                edtUser.ToolTip = "";
                return;
              }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              SELECT UserID$ = UserID,
               DisplayText$ = DisplayText,
               [K�rzel] = LogonName,
               [Mitarbeiter/in] = NameVorname,
               [Org.Einheit] = OrgUnit,
               LogonNameVornameOrgUnit$ = LogonNameVornameOrgUnit
              FROM vwUser
              WHERE (DisplayText LIKE '%' + {0} + '%' or {0} IS NULL)
                AND UserID IN (select distinct UserID from FaLeistung where ModulID in (3,4))
              ORDER BY NameVorname",
              SearchString,
              e.ButtonClicked,null,null,null);

            if (!e.Cancel)
            {
              FilterUserID = Utils.ConvertToInt(dlg[0]);
              edtUser.LookupID = FilterUserID;
              edtUser.EditValue = Utils.ConvertToString(dlg[1]);
              edtUser.ToolTip = Utils.ConvertToString(dlg[1]);
            }
        }

        #endregion
    }
}