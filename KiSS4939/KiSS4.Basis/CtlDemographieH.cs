using System;
using System.Drawing;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Basis
{
    /// <summary>
    /// Summary description for DataExplorerForm.
    /// </summary>
    public class CtlDemographieH : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Internal Fields

        protected internal KiSS4.Gui.KissRTFEdit editBemerkungRTF;
        protected internal KiSS4.Gui.KissRTFEdit editBemerkungRTF_Wohnsituation;
        protected internal KiSS4.Gui.KissLabel kissLabel3;
        protected internal KiSS4.Gui.KissLabel kissLabel38;
        protected internal System.Windows.Forms.Panel panel1;
        protected internal KiSS4.DB.SqlQuery qryBaPerson;
        protected internal KiSS4.Gui.KissTabControlEx xTabControl1;

        #endregion

        #region Private Fields

        private int BaPersonID = 0;
        private KiSS4.Gui.KissButtonEdit btnInstitution;
        private KiSS4.Gui.KissLookUpEdit cboAuslaenderStatus;
        private KiSS4.Gui.KissLookUpEdit cboGeschlecht;
        private KiSS4.Gui.KissLookUpEdit cboNationalitaet;
        private KiSS4.Gui.KissLookUpEdit cboReligion;
        private KiSS4.Gui.KissLookUpEdit cboWohnStatus;
        private KiSS4.Gui.KissLookUpEdit cboWohnungsGroesse;
        private KiSS4.Gui.KissLookUpEdit cboZivilstand;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissDateEdit dtpAuslaenderStatusGueltigBis;
        private KissDateEdit dtpCAusweisDatum;
        private KiSS4.Gui.KissDateEdit dtpGeburtstag;
        private KiSS4.Gui.KissDateEdit dtpSterbeDatum;
        private KiSS4.Gui.KissTextEdit dtpVersichertennummer;
        private KiSS4.Common.KissBfsDtpSeitGeburt dtpZuzugKantonSeit;
        private KiSS4.Common.KissBfsDtpSeitGeburt dtpZuzugSeit;
        private KiSS4.Gui.KissTextEdit editAHVNr;
        private KiSS4.Gui.KissLookUpEdit editAufenthaltsortLand;
        private KiSS4.Gui.KissTextEdit editAufenthaltsOrtNummer;
        private KiSS4.Gui.KissTextEdit editAufenthaltsOrtOrt;
        private KiSS4.Gui.KissTextEdit editAufenthaltsOrtPLZ;
        private KiSS4.Gui.KissTextEdit editAufenthaltsOrtPosfach;
private int FTPersonID = 0;
        private int VerID = 0;
        private KiSS4.Gui.KissTextEdit editFruehererName;
        private KiSS4.Gui.KissButtonEdit editHeimatort;
        private KiSS4.Gui.KissDateEdit editInCHSeit;
        private KiSS4.Gui.KissCheckEdit editInCHSeitGeburt;
        private KiSS4.Gui.KissTextEdit editKantonAufenthalt;
        private KiSS4.Gui.KissTextEdit editKantonUnterstützung;
        private KiSS4.Gui.KissTextEdit editKantonWegzug;
        private KiSS4.Gui.KissTextEdit editKantonWohnsitz;
        private KiSS4.Gui.KissTextEdit editKantonZuzug;
        private KiSS4.Gui.KissLookUpEdit editLandWohnsitz;
        private KiSS4.Gui.KissLookUpEdit editLandZuzug;
        private KiSS4.Gui.KissTextEdit editName;
        private KiSS4.Gui.KissTextEdit editNummerWohnsitz;
        private KiSS4.Gui.KissTextEdit editOrtUnterstuetzung;
        private KiSS4.Gui.KissTextEdit editOrtWegzug;
        private KiSS4.Gui.KissTextEdit editOrtWohnsitz;
        private KiSS4.Gui.KissTextEdit editOrtZuzug;
        private KiSS4.Gui.KissTextEdit editOrtZuzugKanton;
        private KiSS4.Gui.KissTextEdit editPLZUnterstuetzung;
        private KiSS4.Gui.KissTextEdit editPLZWegzug;
        private KiSS4.Gui.KissTextEdit editPLZWohnsitz;
        private KiSS4.Gui.KissTextEdit editPLZZuzug;
        private KiSS4.Gui.KissTextEdit editPLZZuzugKanton;
        private KiSS4.Gui.KissTextEdit editPostfachWohnsitz;
        private KiSS4.Gui.KissTextEdit editStrasseAufenthaltsOrt;
        private KiSS4.Gui.KissTextEdit editStrasseWohnsitz;
        private KiSS4.Gui.KissTextEdit editVorname;
        private KiSS4.Gui.KissTextEdit editZusatzWohnsitz;
        private KiSS4.Gui.KissTextEdit editZuzugKantonKanton;
        private KiSS4.Gui.KissLookUpEdit editZuzugKantonLandCode;
        private KissDateEdit edtErteilungVA;
        private KiSS4.Gui.KissCheckEdit kissCheckEdit1;
        private KiSS4.Gui.KissCheckEdit kissCheckEdit2;
        private KiSS4.Gui.KissDateEdit kissDateEdit7;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel10;
        private KiSS4.Gui.KissLabel kissLabel11;
        private KiSS4.Gui.KissLabel kissLabel12;
        private KiSS4.Gui.KissLabel kissLabel13;
        private KiSS4.Gui.KissLabel kissLabel14;
        private KiSS4.Gui.KissLabel kissLabel15;
        private KiSS4.Gui.KissLabel kissLabel16;
        private KiSS4.Gui.KissLabel kissLabel17;
        private KiSS4.Gui.KissLabel kissLabel18;
        private KiSS4.Gui.KissLabel kissLabel19;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel20;
        private KiSS4.Gui.KissLabel kissLabel21;
        private KiSS4.Gui.KissLabel kissLabel22;
        private KiSS4.Gui.KissLabel kissLabel23;
        private KiSS4.Gui.KissLabel kissLabel24;
        private KiSS4.Gui.KissLabel kissLabel25;
        private KiSS4.Gui.KissLabel kissLabel26;
        private KiSS4.Gui.KissLabel kissLabel27;
        private KiSS4.Gui.KissLabel kissLabel28;
        private KiSS4.Gui.KissLabel kissLabel29;
        private KiSS4.Gui.KissLabel kissLabel30;
        private KiSS4.Gui.KissLabel kissLabel31;
        private KiSS4.Gui.KissLabel kissLabel32;
        private KiSS4.Gui.KissLabel kissLabel33;
        private KiSS4.Gui.KissLabel kissLabel34;
        private KiSS4.Gui.KissLabel kissLabel35;
        private KiSS4.Gui.KissLabel kissLabel36;
        private KiSS4.Gui.KissLabel kissLabel37;
        private KiSS4.Gui.KissLabel kissLabel39;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel40;
        private KiSS4.Gui.KissLabel kissLabel41;
        private KiSS4.Gui.KissLabel kissLabel42;
        private KiSS4.Gui.KissLabel kissLabel43;
        private KiSS4.Gui.KissLabel kissLabel44;
        private KiSS4.Gui.KissLabel kissLabel45;
        private KissLabel kissLabel46;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KiSS4.Gui.KissLabel kissLabel74;
        private KiSS4.Gui.KissLabel kissLabel8;
        private KiSS4.Gui.KissLabel kissLabel9;
        private KissLookUpEdit kissLookUpEdit1;
        private KiSS4.Gui.KissLookUpEdit kissLookUpEdit10;
        private KiSS4.Gui.KissLookUpEdit kissLookUpEdit13;
        private KiSS4.Gui.KissLookUpEdit kissLookUpEdit2;
        private KiSS4.Gui.KissTextEdit kissTextEdit1;
        private KiSS4.Gui.KissTextEdit kissTextEdit10;
        private KiSS4.Gui.KissTextEdit kissTextEdit11;
        private KissTextEdit kissTextEdit12;
        private KiSS4.Gui.KissTextEdit kissTextEdit2;
        private KiSS4.Gui.KissTextEdit kissTextEdit22;
        private KiSS4.Gui.KissTextEdit kissTextEdit3;
        private KiSS4.Gui.KissTextEdit kissTextEdit34;
        private KiSS4.Gui.KissTextEdit kissTextEdit4;
        private KiSS4.Gui.KissTextEdit kissTextEdit5;
        private KiSS4.Gui.KissTextEdit kissTextEdit6;
        private KiSS4.Gui.KissTextEdit kissTextEdit7;
        private KiSS4.Gui.KissTextEdit kissTextEdit8;
        private KiSS4.Gui.KissTextEdit kissTextEdit9;
        private KiSS4.Gui.KissLabel label9;
        private KissLabel lblCAusweis;
        private KissLabel lblEntscheid;
        private KiSS4.Gui.KissLabel lblTitel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryAufenthaltAdr;
        private KiSS4.DB.SqlQuery qryWohnsitzAdr;
        private SharpLibrary.WinControls.TabPageEx tabAdressen;
        private SharpLibrary.WinControls.TabPageEx tabPersonalien;

        #endregion

        #endregion

        #region Constructors

        public CtlDemographieH()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlDemographieH));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject16 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject17 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject18 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject19 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject20 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject21 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject22 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject23 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject24 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryBaPerson = new KiSS4.DB.SqlQuery(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.xTabControl1 = new KiSS4.Gui.KissTabControlEx();
            this.tabPersonalien = new SharpLibrary.WinControls.TabPageEx();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCAusweis = new KiSS4.Gui.KissLabel();
            this.lblEntscheid = new KiSS4.Gui.KissLabel();
            this.dtpCAusweisDatum = new KiSS4.Gui.KissDateEdit();
            this.edtErteilungVA = new KiSS4.Gui.KissDateEdit();
            this.kissTextEdit12 = new KiSS4.Gui.KissTextEdit();
            this.kissLabel46 = new KiSS4.Gui.KissLabel();
            this.dtpVersichertennummer = new KiSS4.Gui.KissTextEdit();
            this.kissLabel39 = new KiSS4.Gui.KissLabel();
            this.kissTextEdit4 = new KiSS4.Gui.KissTextEdit();
            this.kissLabel41 = new KiSS4.Gui.KissLabel();
            this.editInCHSeit = new KiSS4.Gui.KissDateEdit();
            this.editInCHSeitGeburt = new KiSS4.Gui.KissCheckEdit();
            this.kissTextEdit34 = new KiSS4.Gui.KissTextEdit();
            this.kissLabel74 = new KiSS4.Gui.KissLabel();
            this.kissTextEdit3 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit1 = new KiSS4.Gui.KissTextEdit();
            this.kissCheckEdit2 = new KiSS4.Gui.KissCheckEdit();
            this.kissCheckEdit1 = new KiSS4.Gui.KissCheckEdit();
            this.editBemerkungRTF = new KiSS4.Gui.KissRTFEdit();
            this.dtpAuslaenderStatusGueltigBis = new KiSS4.Gui.KissDateEdit();
            this.dtpSterbeDatum = new KiSS4.Gui.KissDateEdit();
            this.dtpGeburtstag = new KiSS4.Gui.KissDateEdit();
            this.editAHVNr = new KiSS4.Gui.KissTextEdit();
            this.kissLabel23 = new KiSS4.Gui.KissLabel();
            this.kissLabel22 = new KiSS4.Gui.KissLabel();
            this.cboReligion = new KiSS4.Gui.KissLookUpEdit();
            this.cboAuslaenderStatus = new KiSS4.Gui.KissLookUpEdit();
            this.cboGeschlecht = new KiSS4.Gui.KissLookUpEdit();
            this.cboZivilstand = new KiSS4.Gui.KissLookUpEdit();
            this.editHeimatort = new KiSS4.Gui.KissButtonEdit();
            this.kissLookUpEdit2 = new KiSS4.Gui.KissLookUpEdit();
            this.cboNationalitaet = new KiSS4.Gui.KissLookUpEdit();
            this.kissTextEdit9 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit8 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit7 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit6 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit5 = new KiSS4.Gui.KissTextEdit();
            this.editFruehererName = new KiSS4.Gui.KissTextEdit();
            this.editVorname = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit2 = new KiSS4.Gui.KissTextEdit();
            this.editName = new KiSS4.Gui.KissTextEdit();
            this.kissLabel21 = new KiSS4.Gui.KissLabel();
            this.kissLabel20 = new KiSS4.Gui.KissLabel();
            this.kissLabel19 = new KiSS4.Gui.KissLabel();
            this.kissLabel18 = new KiSS4.Gui.KissLabel();
            this.kissLabel17 = new KiSS4.Gui.KissLabel();
            this.kissLabel16 = new KiSS4.Gui.KissLabel();
            this.kissLabel15 = new KiSS4.Gui.KissLabel();
            this.kissLabel13 = new KiSS4.Gui.KissLabel();
            this.kissLabel12 = new KiSS4.Gui.KissLabel();
            this.kissLabel11 = new KiSS4.Gui.KissLabel();
            this.kissLabel10 = new KiSS4.Gui.KissLabel();
            this.kissLabel9 = new KiSS4.Gui.KissLabel();
            this.kissLabel8 = new KiSS4.Gui.KissLabel();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.label9 = new KiSS4.Gui.KissLabel();
            this.tabAdressen = new SharpLibrary.WinControls.TabPageEx();
            this.panel3 = new System.Windows.Forms.Panel();
            this.kissLookUpEdit1 = new KiSS4.Gui.KissLookUpEdit();
            this.btnInstitution = new KiSS4.Gui.KissButtonEdit();
            this.qryAufenthaltAdr = new KiSS4.DB.SqlQuery(this.components);
            this.editZuzugKantonLandCode = new KiSS4.Gui.KissLookUpEdit();
            this.kissTextEdit10 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit11 = new KiSS4.Gui.KissTextEdit();
            this.kissLabel14 = new KiSS4.Gui.KissLabel();
            this.dtpZuzugKantonSeit = new KiSS4.Common.KissBfsDtpSeitGeburt();
            this.editOrtZuzugKanton = new KiSS4.Gui.KissTextEdit();
            this.editZuzugKantonKanton = new KiSS4.Gui.KissTextEdit();
            this.editPLZZuzugKanton = new KiSS4.Gui.KissTextEdit();
            this.kissLabel45 = new KiSS4.Gui.KissLabel();
            this.editLandZuzug = new KiSS4.Gui.KissLookUpEdit();
            this.kissLabel44 = new KiSS4.Gui.KissLabel();
            this.kissLabel43 = new KiSS4.Gui.KissLabel();
            this.kissLabel42 = new KiSS4.Gui.KissLabel();
            this.dtpZuzugSeit = new KiSS4.Common.KissBfsDtpSeitGeburt();
            this.kissLabel40 = new KiSS4.Gui.KissLabel();
            this.editOrtUnterstuetzung = new KiSS4.Gui.KissTextEdit();
            this.editKantonUnterstützung = new KiSS4.Gui.KissTextEdit();
            this.editPLZUnterstuetzung = new KiSS4.Gui.KissTextEdit();
            this.editBemerkungRTF_Wohnsituation = new KiSS4.Gui.KissRTFEdit();
            this.qryWohnsitzAdr = new KiSS4.DB.SqlQuery(this.components);
            this.kissLabel38 = new KiSS4.Gui.KissLabel();
            this.kissDateEdit7 = new KiSS4.Gui.KissDateEdit();
            this.kissLabel37 = new KiSS4.Gui.KissLabel();
            this.editOrtWegzug = new KiSS4.Gui.KissTextEdit();
            this.kissLookUpEdit13 = new KiSS4.Gui.KissLookUpEdit();
            this.editKantonWegzug = new KiSS4.Gui.KissTextEdit();
            this.editPLZWegzug = new KiSS4.Gui.KissTextEdit();
            this.editOrtZuzug = new KiSS4.Gui.KissTextEdit();
            this.editKantonZuzug = new KiSS4.Gui.KissTextEdit();
            this.editPLZZuzug = new KiSS4.Gui.KissTextEdit();
            this.kissLabel35 = new KiSS4.Gui.KissLabel();
            this.kissLabel36 = new KiSS4.Gui.KissLabel();
            this.editAufenthaltsOrtOrt = new KiSS4.Gui.KissTextEdit();
            this.editAufenthaltsortLand = new KiSS4.Gui.KissLookUpEdit();
            this.editKantonAufenthalt = new KiSS4.Gui.KissTextEdit();
            this.editAufenthaltsOrtPLZ = new KiSS4.Gui.KissTextEdit();
            this.editAufenthaltsOrtPosfach = new KiSS4.Gui.KissTextEdit();
            this.editAufenthaltsOrtNummer = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit22 = new KiSS4.Gui.KissTextEdit();
            this.editStrasseAufenthaltsOrt = new KiSS4.Gui.KissTextEdit();
            this.editOrtWohnsitz = new KiSS4.Gui.KissTextEdit();
            this.cboWohnungsGroesse = new KiSS4.Gui.KissLookUpEdit();
            this.cboWohnStatus = new KiSS4.Gui.KissLookUpEdit();
            this.kissLabel34 = new KiSS4.Gui.KissLabel();
            this.editLandWohnsitz = new KiSS4.Gui.KissLookUpEdit();
            this.kissLabel33 = new KiSS4.Gui.KissLabel();
            this.kissLabel32 = new KiSS4.Gui.KissLabel();
            this.kissLabel31 = new KiSS4.Gui.KissLabel();
            this.kissLabel30 = new KiSS4.Gui.KissLabel();
            this.editKantonWohnsitz = new KiSS4.Gui.KissTextEdit();
            this.editPLZWohnsitz = new KiSS4.Gui.KissTextEdit();
            this.editPostfachWohnsitz = new KiSS4.Gui.KissTextEdit();
            this.editNummerWohnsitz = new KiSS4.Gui.KissTextEdit();
            this.editZusatzWohnsitz = new KiSS4.Gui.KissTextEdit();
            this.editStrasseWohnsitz = new KiSS4.Gui.KissTextEdit();
            this.kissLabel24 = new KiSS4.Gui.KissLabel();
            this.kissLabel25 = new KiSS4.Gui.KissLabel();
            this.kissLabel26 = new KiSS4.Gui.KissLabel();
            this.kissLabel27 = new KiSS4.Gui.KissLabel();
            this.kissLabel28 = new KiSS4.Gui.KissLabel();
            this.kissLabel29 = new KiSS4.Gui.KissLabel();
            this.kissLookUpEdit10 = new KiSS4.Gui.KissLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            this.xTabControl1.SuspendLayout();
            this.tabPersonalien.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblCAusweis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEntscheid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpCAusweisDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErteilungVA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit12.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpVersichertennummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editInCHSeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editInCHSeitGeburt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit34.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel74)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissCheckEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissCheckEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAuslaenderStatusGueltigBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpSterbeDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpGeburtstag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAHVNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboReligion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboReligion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAuslaenderStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAuslaenderStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGeschlecht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboZivilstand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboZivilstand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editHeimatort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNationalitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNationalitaet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit9.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit8.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit7.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFruehererName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            this.tabAdressen.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnInstitution.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAufenthaltAdr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editZuzugKantonLandCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editZuzugKantonLandCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit10.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit11.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editOrtZuzugKanton.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editZuzugKantonKanton.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPLZZuzugKanton.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editLandZuzug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editLandZuzug.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editOrtUnterstuetzung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKantonUnterstützung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPLZUnterstuetzung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryWohnsitzAdr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissDateEdit7.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editOrtWegzug.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit13.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKantonWegzug.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPLZWegzug.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editOrtZuzug.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKantonZuzug.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPLZZuzug.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAufenthaltsOrtOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAufenthaltsortLand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAufenthaltsortLand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKantonAufenthalt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAufenthaltsOrtPLZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAufenthaltsOrtPosfach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAufenthaltsOrtNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit22.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStrasseAufenthaltsOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editOrtWohnsitz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWohnungsGroesse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWohnungsGroesse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWohnStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWohnStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editLandWohnsitz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editLandWohnsitz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKantonWohnsitz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPLZWohnsitz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPostfachWohnsitz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editNummerWohnsitz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editZusatzWohnsitz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStrasseWohnsitz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit10.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // qryBaPerson
            //
            this.qryBaPerson.HostControl = this;
            this.qryBaPerson.TableName = "BaPerson";
            //
            // panel1
            //
            this.panel1.Controls.Add(this.picTitel);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(719, 30);
            this.panel1.TabIndex = 0;
            //
            // picTitel
            //
            this.picTitel.Image = ((System.Drawing.Image)(resources.GetObject("picTitel.Image")));
            this.picTitel.Location = new System.Drawing.Point(5, 9);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 293;
            this.picTitel.TabStop = false;
            //
            // lblTitel
            //
            this.lblTitel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblTitel.Location = new System.Drawing.Point(25, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(648, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Demographie";
            //
            // xTabControl1
            //
            this.xTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xTabControl1.Controls.Add(this.tabPersonalien);
            this.xTabControl1.Controls.Add(this.tabAdressen);
            this.xTabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.xTabControl1.Location = new System.Drawing.Point(0, 30);
            this.xTabControl1.Name = "xTabControl1";
            this.xTabControl1.ShowFixedWidthTooltip = true;
            this.xTabControl1.Size = new System.Drawing.Size(719, 590);
            this.xTabControl1.TabIndex = 2;
            this.xTabControl1.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tabPersonalien,
            this.tabAdressen});
            this.xTabControl1.TabsLineColor = System.Drawing.Color.Black;
            this.xTabControl1.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.xTabControl1.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.xTabControl1.TabStop = false;
            this.xTabControl1.Text = "xTabControl1";
            this.xTabControl1.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.xTabControl1_SelectedTabChanged);
            //
            // tabPersonalien
            //
            this.tabPersonalien.Controls.Add(this.panel2);
            this.tabPersonalien.Location = new System.Drawing.Point(6, 32);
            this.tabPersonalien.Name = "tabPersonalien";
            this.tabPersonalien.Size = new System.Drawing.Size(707, 552);
            this.tabPersonalien.TabIndex = 0;
            this.tabPersonalien.Title = "Personalien";
            //
            // panel2
            //
            this.panel2.Controls.Add(this.lblCAusweis);
            this.panel2.Controls.Add(this.lblEntscheid);
            this.panel2.Controls.Add(this.dtpCAusweisDatum);
            this.panel2.Controls.Add(this.edtErteilungVA);
            this.panel2.Controls.Add(this.kissTextEdit12);
            this.panel2.Controls.Add(this.kissLabel46);
            this.panel2.Controls.Add(this.dtpVersichertennummer);
            this.panel2.Controls.Add(this.kissLabel39);
            this.panel2.Controls.Add(this.kissTextEdit4);
            this.panel2.Controls.Add(this.kissLabel41);
            this.panel2.Controls.Add(this.editInCHSeit);
            this.panel2.Controls.Add(this.editInCHSeitGeburt);
            this.panel2.Controls.Add(this.kissTextEdit34);
            this.panel2.Controls.Add(this.kissLabel74);
            this.panel2.Controls.Add(this.kissTextEdit3);
            this.panel2.Controls.Add(this.kissTextEdit1);
            this.panel2.Controls.Add(this.kissCheckEdit2);
            this.panel2.Controls.Add(this.kissCheckEdit1);
            this.panel2.Controls.Add(this.editBemerkungRTF);
            this.panel2.Controls.Add(this.dtpAuslaenderStatusGueltigBis);
            this.panel2.Controls.Add(this.dtpSterbeDatum);
            this.panel2.Controls.Add(this.dtpGeburtstag);
            this.panel2.Controls.Add(this.editAHVNr);
            this.panel2.Controls.Add(this.kissLabel23);
            this.panel2.Controls.Add(this.kissLabel22);
            this.panel2.Controls.Add(this.cboReligion);
            this.panel2.Controls.Add(this.cboAuslaenderStatus);
            this.panel2.Controls.Add(this.cboGeschlecht);
            this.panel2.Controls.Add(this.cboZivilstand);
            this.panel2.Controls.Add(this.editHeimatort);
            this.panel2.Controls.Add(this.kissLookUpEdit2);
            this.panel2.Controls.Add(this.cboNationalitaet);
            this.panel2.Controls.Add(this.kissTextEdit9);
            this.panel2.Controls.Add(this.kissTextEdit8);
            this.panel2.Controls.Add(this.kissTextEdit7);
            this.panel2.Controls.Add(this.kissTextEdit6);
            this.panel2.Controls.Add(this.kissTextEdit5);
            this.panel2.Controls.Add(this.editFruehererName);
            this.panel2.Controls.Add(this.editVorname);
            this.panel2.Controls.Add(this.kissTextEdit2);
            this.panel2.Controls.Add(this.editName);
            this.panel2.Controls.Add(this.kissLabel21);
            this.panel2.Controls.Add(this.kissLabel20);
            this.panel2.Controls.Add(this.kissLabel19);
            this.panel2.Controls.Add(this.kissLabel18);
            this.panel2.Controls.Add(this.kissLabel17);
            this.panel2.Controls.Add(this.kissLabel16);
            this.panel2.Controls.Add(this.kissLabel15);
            this.panel2.Controls.Add(this.kissLabel13);
            this.panel2.Controls.Add(this.kissLabel12);
            this.panel2.Controls.Add(this.kissLabel11);
            this.panel2.Controls.Add(this.kissLabel10);
            this.panel2.Controls.Add(this.kissLabel9);
            this.panel2.Controls.Add(this.kissLabel8);
            this.panel2.Controls.Add(this.kissLabel7);
            this.panel2.Controls.Add(this.kissLabel6);
            this.panel2.Controls.Add(this.kissLabel5);
            this.panel2.Controls.Add(this.kissLabel4);
            this.panel2.Controls.Add(this.kissLabel3);
            this.panel2.Controls.Add(this.kissLabel2);
            this.panel2.Controls.Add(this.kissLabel1);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(707, 552);
            this.panel2.TabIndex = 0;
            //
            // lblCAusweis
            //
            this.lblCAusweis.Location = new System.Drawing.Point(443, 326);
            this.lblCAusweis.Name = "lblCAusweis";
            this.lblCAusweis.Size = new System.Drawing.Size(90, 24);
            this.lblCAusweis.TabIndex = 586;
            this.lblCAusweis.Text = "Ende Zuständigk.";
            this.lblCAusweis.UseCompatibleTextRendering = true;
            //
            // lblEntscheid
            //
            this.lblEntscheid.Location = new System.Drawing.Point(443, 303);
            this.lblEntscheid.Name = "lblEntscheid";
            this.lblEntscheid.Size = new System.Drawing.Size(80, 24);
            this.lblEntscheid.TabIndex = 585;
            this.lblEntscheid.Text = "Entscheid";
            this.lblEntscheid.UseCompatibleTextRendering = true;
            //
            // dtpCAusweisDatum
            //
            this.dtpCAusweisDatum.AllowDrop = true;
            this.dtpCAusweisDatum.DataMember = "CAusweisDatum";
            this.dtpCAusweisDatum.DataSource = this.qryBaPerson;
            this.dtpCAusweisDatum.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.dtpCAusweisDatum.EditValue = null;
            this.dtpCAusweisDatum.Location = new System.Drawing.Point(535, 326);
            this.dtpCAusweisDatum.Name = "dtpCAusweisDatum";
            this.dtpCAusweisDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dtpCAusweisDatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.dtpCAusweisDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dtpCAusweisDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dtpCAusweisDatum.Properties.Appearance.Options.UseBackColor = true;
            this.dtpCAusweisDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.dtpCAusweisDatum.Properties.Appearance.Options.UseFont = true;
            this.dtpCAusweisDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.dtpCAusweisDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("dtpCAusweisDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.dtpCAusweisDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dtpCAusweisDatum.Properties.ReadOnly = true;
            this.dtpCAusweisDatum.Properties.ShowToday = false;
            this.dtpCAusweisDatum.Size = new System.Drawing.Size(100, 24);
            this.dtpCAusweisDatum.TabIndex = 584;
            //
            // edtErteilungVA
            //
            this.edtErteilungVA.DataMember = "ErteilungVA";
            this.edtErteilungVA.DataSource = this.qryBaPerson;
            this.edtErteilungVA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtErteilungVA.EditValue = null;
            this.edtErteilungVA.Location = new System.Drawing.Point(535, 303);
            this.edtErteilungVA.Name = "edtErteilungVA";
            this.edtErteilungVA.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErteilungVA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtErteilungVA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErteilungVA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErteilungVA.Properties.Appearance.Options.UseBackColor = true;
            this.edtErteilungVA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErteilungVA.Properties.Appearance.Options.UseFont = true;
            this.edtErteilungVA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtErteilungVA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtErteilungVA.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtErteilungVA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErteilungVA.Properties.ReadOnly = true;
            this.edtErteilungVA.Properties.ShowToday = false;
            this.edtErteilungVA.Size = new System.Drawing.Size(100, 24);
            this.edtErteilungVA.TabIndex = 583;
            //
            // kissTextEdit12
            //
            this.kissTextEdit12.DataMember = "ZEMISNummer";
            this.kissTextEdit12.DataSource = this.qryBaPerson;
            this.kissTextEdit12.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit12.Location = new System.Drawing.Point(99, 320);
            this.kissTextEdit12.Name = "kissTextEdit12";
            this.kissTextEdit12.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit12.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit12.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit12.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit12.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit12.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit12.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit12.Properties.ReadOnly = true;
            this.kissTextEdit12.Size = new System.Drawing.Size(135, 24);
            this.kissTextEdit12.TabIndex = 580;
            //
            // kissLabel46
            //
            this.kissLabel46.ForeColor = System.Drawing.Color.Black;
            this.kissLabel46.Location = new System.Drawing.Point(5, 320);
            this.kissLabel46.Name = "kissLabel46";
            this.kissLabel46.Size = new System.Drawing.Size(70, 24);
            this.kissLabel46.TabIndex = 581;
            this.kissLabel46.Text = "ZEMIS Nummer";
            //
            // dtpVersichertennummer
            //
            this.dtpVersichertennummer.DataMember = "Versichertennummer";
            this.dtpVersichertennummer.DataSource = this.qryBaPerson;
            this.dtpVersichertennummer.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.dtpVersichertennummer.Location = new System.Drawing.Point(99, 297);
            this.dtpVersichertennummer.Name = "dtpVersichertennummer";
            this.dtpVersichertennummer.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.dtpVersichertennummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dtpVersichertennummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dtpVersichertennummer.Properties.Appearance.Options.UseBackColor = true;
            this.dtpVersichertennummer.Properties.Appearance.Options.UseBorderColor = true;
            this.dtpVersichertennummer.Properties.Appearance.Options.UseFont = true;
            this.dtpVersichertennummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.dtpVersichertennummer.Properties.ReadOnly = true;
            this.dtpVersichertennummer.Size = new System.Drawing.Size(135, 24);
            this.dtpVersichertennummer.TabIndex = 578;
            //
            // kissLabel39
            //
            this.kissLabel39.ForeColor = System.Drawing.Color.Black;
            this.kissLabel39.Location = new System.Drawing.Point(5, 297);
            this.kissLabel39.Name = "kissLabel39";
            this.kissLabel39.Size = new System.Drawing.Size(79, 24);
            this.kissLabel39.TabIndex = 579;
            this.kissLabel39.Text = "Versichertennr.";
            //
            // kissTextEdit4
            //
            this.kissTextEdit4.DataMember = "NavigatorZusatz";
            this.kissTextEdit4.DataSource = this.qryBaPerson;
            this.kissTextEdit4.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit4.Location = new System.Drawing.Point(337, 274);
            this.kissTextEdit4.Name = "kissTextEdit4";
            this.kissTextEdit4.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit4.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit4.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit4.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit4.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit4.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit4.Properties.ReadOnly = true;
            this.kissTextEdit4.Size = new System.Drawing.Size(95, 24);
            this.kissTextEdit4.TabIndex = 14;
            //
            // kissLabel41
            //
            this.kissLabel41.ForeColor = System.Drawing.Color.Black;
            this.kissLabel41.Location = new System.Drawing.Point(266, 274);
            this.kissLabel41.Name = "kissLabel41";
            this.kissLabel41.Size = new System.Drawing.Size(66, 24);
            this.kissLabel41.TabIndex = 577;
            this.kissLabel41.Text = "Nav.-Zusatz";
            //
            // editInCHSeit
            //
            this.editInCHSeit.DataMember = "InCHSeit";
            this.editInCHSeit.DataSource = this.qryBaPerson;
            this.editInCHSeit.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editInCHSeit.EditValue = null;
            this.editInCHSeit.Location = new System.Drawing.Point(535, 144);
            this.editInCHSeit.Name = "editInCHSeit";
            this.editInCHSeit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editInCHSeit.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editInCHSeit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editInCHSeit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editInCHSeit.Properties.Appearance.Options.UseBackColor = true;
            this.editInCHSeit.Properties.Appearance.Options.UseBorderColor = true;
            this.editInCHSeit.Properties.Appearance.Options.UseFont = true;
            this.editInCHSeit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.editInCHSeit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("editInCHSeit.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.editInCHSeit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editInCHSeit.Properties.ReadOnly = true;
            this.editInCHSeit.Properties.ShowToday = false;
            this.editInCHSeit.Size = new System.Drawing.Size(86, 24);
            this.editInCHSeit.TabIndex = 22;
            //
            // editInCHSeitGeburt
            //
            this.editInCHSeitGeburt.DataMember = "InCHSeitGeburt";
            this.editInCHSeitGeburt.DataSource = this.qryBaPerson;
            this.editInCHSeitGeburt.Location = new System.Drawing.Point(630, 146);
            this.editInCHSeitGeburt.Name = "editInCHSeitGeburt";
            this.editInCHSeitGeburt.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.editInCHSeitGeburt.Properties.Appearance.Options.UseBackColor = true;
            this.editInCHSeitGeburt.Properties.Caption = "seit Geburt";
            this.editInCHSeitGeburt.Size = new System.Drawing.Size(80, 19);
            this.editInCHSeitGeburt.TabIndex = 23;
            //
            // kissTextEdit34
            //
            this.kissTextEdit34.DataMember = "BaPersonID";
            this.kissTextEdit34.DataSource = this.qryBaPerson;
            this.kissTextEdit34.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit34.Location = new System.Drawing.Point(332, 8);
            this.kissTextEdit34.Name = "kissTextEdit34";
            this.kissTextEdit34.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit34.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit34.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit34.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit34.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit34.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit34.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit34.Properties.ReadOnly = true;
            this.kissTextEdit34.Size = new System.Drawing.Size(100, 24);
            this.kissTextEdit34.TabIndex = 576;
            //
            // kissLabel74
            //
            this.kissLabel74.ForeColor = System.Drawing.Color.Black;
            this.kissLabel74.Location = new System.Drawing.Point(310, 8);
            this.kissLabel74.Name = "kissLabel74";
            this.kissLabel74.Size = new System.Drawing.Size(18, 24);
            this.kissLabel74.TabIndex = 575;
            this.kissLabel74.Text = "Nr";
            //
            // kissTextEdit3
            //
            this.kissTextEdit3.DataMember = "BFFNummer";
            this.kissTextEdit3.DataSource = this.qryBaPerson;
            this.kissTextEdit3.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit3.Location = new System.Drawing.Point(99, 274);
            this.kissTextEdit3.Name = "kissTextEdit3";
            this.kissTextEdit3.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit3.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit3.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit3.Properties.ReadOnly = true;
            this.kissTextEdit3.Size = new System.Drawing.Size(135, 24);
            this.kissTextEdit3.TabIndex = 11;
            //
            // kissTextEdit1
            //
            this.kissTextEdit1.DataMember = "NNummer";
            this.kissTextEdit1.DataSource = this.qryBaPerson;
            this.kissTextEdit1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit1.Location = new System.Drawing.Point(99, 251);
            this.kissTextEdit1.Name = "kissTextEdit1";
            this.kissTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit1.Properties.ReadOnly = true;
            this.kissTextEdit1.Size = new System.Drawing.Size(135, 24);
            this.kissTextEdit1.TabIndex = 10;
            //
            // kissCheckEdit2
            //
            this.kissCheckEdit2.DataMember = "TestPerson";
            this.kissCheckEdit2.DataSource = this.qryBaPerson;
            this.kissCheckEdit2.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissCheckEdit2.Location = new System.Drawing.Point(618, 8);
            this.kissCheckEdit2.Name = "kissCheckEdit2";
            this.kissCheckEdit2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.kissCheckEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.kissCheckEdit2.Properties.Caption = "Testperson";
            this.kissCheckEdit2.Properties.ReadOnly = true;
            this.kissCheckEdit2.Size = new System.Drawing.Size(97, 19);
            this.kissCheckEdit2.TabIndex = 16;
            //
            // kissCheckEdit1
            //
            this.kissCheckEdit1.DataMember = "Fiktiv";
            this.kissCheckEdit1.DataSource = this.qryBaPerson;
            this.kissCheckEdit1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissCheckEdit1.Location = new System.Drawing.Point(533, 8);
            this.kissCheckEdit1.Name = "kissCheckEdit1";
            this.kissCheckEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.kissCheckEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissCheckEdit1.Properties.Caption = "fiktiv";
            this.kissCheckEdit1.Properties.ReadOnly = true;
            this.kissCheckEdit1.Size = new System.Drawing.Size(62, 19);
            this.kissCheckEdit1.TabIndex = 15;
            //
            // editBemerkungRTF
            //
            this.editBemerkungRTF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.editBemerkungRTF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editBemerkungRTF.DataMember = "Bemerkung";
            this.editBemerkungRTF.DataSource = this.qryBaPerson;
            this.editBemerkungRTF.Font = new System.Drawing.Font("Arial", 10F);
            this.editBemerkungRTF.Location = new System.Drawing.Point(99, 365);
            this.editBemerkungRTF.Name = "editBemerkungRTF";
            this.editBemerkungRTF.Size = new System.Drawing.Size(596, 177);
            this.editBemerkungRTF.TabIndex = 29;
            //
            // dtpAuslaenderStatusGueltigBis
            //
            this.dtpAuslaenderStatusGueltigBis.DataMember = "AuslaenderStatusGueltigBis";
            this.dtpAuslaenderStatusGueltigBis.DataSource = this.qryBaPerson;
            this.dtpAuslaenderStatusGueltigBis.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.dtpAuslaenderStatusGueltigBis.EditValue = null;
            this.dtpAuslaenderStatusGueltigBis.Location = new System.Drawing.Point(535, 197);
            this.dtpAuslaenderStatusGueltigBis.Name = "dtpAuslaenderStatusGueltigBis";
            this.dtpAuslaenderStatusGueltigBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dtpAuslaenderStatusGueltigBis.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.dtpAuslaenderStatusGueltigBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dtpAuslaenderStatusGueltigBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dtpAuslaenderStatusGueltigBis.Properties.Appearance.Options.UseBackColor = true;
            this.dtpAuslaenderStatusGueltigBis.Properties.Appearance.Options.UseBorderColor = true;
            this.dtpAuslaenderStatusGueltigBis.Properties.Appearance.Options.UseFont = true;
            this.dtpAuslaenderStatusGueltigBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.dtpAuslaenderStatusGueltigBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("dtpAuslaenderStatusGueltigBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.dtpAuslaenderStatusGueltigBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dtpAuslaenderStatusGueltigBis.Properties.ReadOnly = true;
            this.dtpAuslaenderStatusGueltigBis.Properties.ShowToday = false;
            this.dtpAuslaenderStatusGueltigBis.Size = new System.Drawing.Size(169, 24);
            this.dtpAuslaenderStatusGueltigBis.TabIndex = 25;
            //
            // dtpSterbeDatum
            //
            this.dtpSterbeDatum.DataMember = "Sterbedatum";
            this.dtpSterbeDatum.DataSource = this.qryBaPerson;
            this.dtpSterbeDatum.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.dtpSterbeDatum.EditValue = null;
            this.dtpSterbeDatum.Location = new System.Drawing.Point(337, 251);
            this.dtpSterbeDatum.Name = "dtpSterbeDatum";
            this.dtpSterbeDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dtpSterbeDatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.dtpSterbeDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dtpSterbeDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dtpSterbeDatum.Properties.Appearance.Options.UseBackColor = true;
            this.dtpSterbeDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.dtpSterbeDatum.Properties.Appearance.Options.UseFont = true;
            this.dtpSterbeDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.dtpSterbeDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("dtpSterbeDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.dtpSterbeDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dtpSterbeDatum.Properties.ReadOnly = true;
            this.dtpSterbeDatum.Properties.ShowToday = false;
            this.dtpSterbeDatum.Size = new System.Drawing.Size(95, 24);
            this.dtpSterbeDatum.TabIndex = 13;
            //
            // dtpGeburtstag
            //
            this.dtpGeburtstag.DataMember = "Geburtsdatum";
            this.dtpGeburtstag.DataSource = this.qryBaPerson;
            this.dtpGeburtstag.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.dtpGeburtstag.EditValue = null;
            this.dtpGeburtstag.Location = new System.Drawing.Point(337, 228);
            this.dtpGeburtstag.Name = "dtpGeburtstag";
            this.dtpGeburtstag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dtpGeburtstag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.dtpGeburtstag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dtpGeburtstag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dtpGeburtstag.Properties.Appearance.Options.UseBackColor = true;
            this.dtpGeburtstag.Properties.Appearance.Options.UseBorderColor = true;
            this.dtpGeburtstag.Properties.Appearance.Options.UseFont = true;
            this.dtpGeburtstag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.dtpGeburtstag.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("dtpGeburtstag.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.dtpGeburtstag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dtpGeburtstag.Properties.ReadOnly = true;
            this.dtpGeburtstag.Properties.ShowToday = false;
            this.dtpGeburtstag.Size = new System.Drawing.Size(95, 24);
            this.dtpGeburtstag.TabIndex = 12;
            //
            // editAHVNr
            //
            this.editAHVNr.DataMember = "AHVNummer";
            this.editAHVNr.DataSource = this.qryBaPerson;
            this.editAHVNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editAHVNr.Location = new System.Drawing.Point(99, 228);
            this.editAHVNr.Name = "editAHVNr";
            this.editAHVNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editAHVNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editAHVNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editAHVNr.Properties.Appearance.Options.UseBackColor = true;
            this.editAHVNr.Properties.Appearance.Options.UseBorderColor = true;
            this.editAHVNr.Properties.Appearance.Options.UseFont = true;
            this.editAHVNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editAHVNr.Properties.ReadOnly = true;
            this.editAHVNr.Size = new System.Drawing.Size(135, 24);
            this.editAHVNr.TabIndex = 9;
            //
            // kissLabel23
            //
            this.kissLabel23.ForeColor = System.Drawing.Color.Black;
            this.kissLabel23.Location = new System.Drawing.Point(266, 228);
            this.kissLabel23.Name = "kissLabel23";
            this.kissLabel23.Size = new System.Drawing.Size(45, 24);
            this.kissLabel23.TabIndex = 426;
            this.kissLabel23.Text = "Geburt";
            //
            // kissLabel22
            //
            this.kissLabel22.ForeColor = System.Drawing.Color.Black;
            this.kissLabel22.Location = new System.Drawing.Point(266, 251);
            this.kissLabel22.Name = "kissLabel22";
            this.kissLabel22.Size = new System.Drawing.Size(45, 24);
            this.kissLabel22.TabIndex = 425;
            this.kissLabel22.Text = "Tod";
            //
            // cboReligion
            //
            this.cboReligion.DataMember = "KonfessionCode";
            this.cboReligion.DataSource = this.qryBaPerson;
            this.cboReligion.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.cboReligion.Location = new System.Drawing.Point(535, 274);
            this.cboReligion.LOVName = "Konfession";
            this.cboReligion.Name = "cboReligion";
            this.cboReligion.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.cboReligion.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboReligion.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboReligion.Properties.Appearance.Options.UseBackColor = true;
            this.cboReligion.Properties.Appearance.Options.UseBorderColor = true;
            this.cboReligion.Properties.Appearance.Options.UseFont = true;
            this.cboReligion.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboReligion.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboReligion.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboReligion.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboReligion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.cboReligion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.cboReligion.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboReligion.Properties.NullText = "";
            this.cboReligion.Properties.ReadOnly = true;
            this.cboReligion.Properties.ShowFooter = false;
            this.cboReligion.Properties.ShowHeader = false;
            this.cboReligion.Size = new System.Drawing.Size(169, 24);
            this.cboReligion.TabIndex = 28;
            //
            // cboAuslaenderStatus
            //
            this.cboAuslaenderStatus.DataMember = "AuslaenderStatusCode";
            this.cboAuslaenderStatus.DataSource = this.qryBaPerson;
            this.cboAuslaenderStatus.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.cboAuslaenderStatus.Location = new System.Drawing.Point(535, 174);
            this.cboAuslaenderStatus.LOVName = "Aufenthaltsstatus";
            this.cboAuslaenderStatus.Name = "cboAuslaenderStatus";
            this.cboAuslaenderStatus.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.cboAuslaenderStatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboAuslaenderStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboAuslaenderStatus.Properties.Appearance.Options.UseBackColor = true;
            this.cboAuslaenderStatus.Properties.Appearance.Options.UseBorderColor = true;
            this.cboAuslaenderStatus.Properties.Appearance.Options.UseFont = true;
            this.cboAuslaenderStatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboAuslaenderStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboAuslaenderStatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboAuslaenderStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboAuslaenderStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.cboAuslaenderStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.cboAuslaenderStatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboAuslaenderStatus.Properties.NullText = "";
            this.cboAuslaenderStatus.Properties.ReadOnly = true;
            this.cboAuslaenderStatus.Properties.ShowFooter = false;
            this.cboAuslaenderStatus.Properties.ShowHeader = false;
            this.cboAuslaenderStatus.Size = new System.Drawing.Size(169, 24);
            this.cboAuslaenderStatus.TabIndex = 24;
            //
            // cboGeschlecht
            //
            this.cboGeschlecht.DataMember = "GeschlechtCode";
            this.cboGeschlecht.DataSource = this.qryBaPerson;
            this.cboGeschlecht.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.cboGeschlecht.Location = new System.Drawing.Point(535, 228);
            this.cboGeschlecht.LOVName = "Geschlecht";
            this.cboGeschlecht.Name = "cboGeschlecht";
            this.cboGeschlecht.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.cboGeschlecht.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboGeschlecht.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboGeschlecht.Properties.Appearance.Options.UseBackColor = true;
            this.cboGeschlecht.Properties.Appearance.Options.UseBorderColor = true;
            this.cboGeschlecht.Properties.Appearance.Options.UseFont = true;
            this.cboGeschlecht.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboGeschlecht.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboGeschlecht.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboGeschlecht.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboGeschlecht.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.cboGeschlecht.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.cboGeschlecht.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboGeschlecht.Properties.NullText = "";
            this.cboGeschlecht.Properties.ReadOnly = true;
            this.cboGeschlecht.Properties.ShowFooter = false;
            this.cboGeschlecht.Properties.ShowHeader = false;
            this.cboGeschlecht.Size = new System.Drawing.Size(169, 24);
            this.cboGeschlecht.TabIndex = 26;
            //
            // cboZivilstand
            //
            this.cboZivilstand.DataMember = "ZivilstandCode";
            this.cboZivilstand.DataSource = this.qryBaPerson;
            this.cboZivilstand.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.cboZivilstand.Location = new System.Drawing.Point(535, 251);
            this.cboZivilstand.LOVName = "Zivilstand";
            this.cboZivilstand.Name = "cboZivilstand";
            this.cboZivilstand.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.cboZivilstand.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboZivilstand.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboZivilstand.Properties.Appearance.Options.UseBackColor = true;
            this.cboZivilstand.Properties.Appearance.Options.UseBorderColor = true;
            this.cboZivilstand.Properties.Appearance.Options.UseFont = true;
            this.cboZivilstand.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboZivilstand.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboZivilstand.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboZivilstand.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboZivilstand.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.cboZivilstand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.cboZivilstand.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboZivilstand.Properties.NullText = "";
            this.cboZivilstand.Properties.ReadOnly = true;
            this.cboZivilstand.Properties.ShowFooter = false;
            this.cboZivilstand.Properties.ShowHeader = false;
            this.cboZivilstand.Size = new System.Drawing.Size(169, 24);
            this.cboZivilstand.TabIndex = 27;
            //
            // editHeimatort
            //
            this.editHeimatort.DataMember = "Heimatort";
            this.editHeimatort.DataSource = this.qryBaPerson;
            this.editHeimatort.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editHeimatort.Location = new System.Drawing.Point(535, 61);
            this.editHeimatort.Name = "editHeimatort";
            this.editHeimatort.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editHeimatort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editHeimatort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editHeimatort.Properties.Appearance.Options.UseBackColor = true;
            this.editHeimatort.Properties.Appearance.Options.UseBorderColor = true;
            this.editHeimatort.Properties.Appearance.Options.UseFont = true;
            this.editHeimatort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.editHeimatort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.editHeimatort.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editHeimatort.Properties.ReadOnly = true;
            this.editHeimatort.Size = new System.Drawing.Size(169, 24);
            this.editHeimatort.TabIndex = 18;
            //
            // kissLookUpEdit2
            //
            this.kissLookUpEdit2.DataMember = "SprachCode";
            this.kissLookUpEdit2.DataSource = this.qryBaPerson;
            this.kissLookUpEdit2.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissLookUpEdit2.Location = new System.Drawing.Point(535, 91);
            this.kissLookUpEdit2.LOVName = "Sprache";
            this.kissLookUpEdit2.Name = "kissLookUpEdit2";
            this.kissLookUpEdit2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissLookUpEdit2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissLookUpEdit2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissLookUpEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.kissLookUpEdit2.Properties.Appearance.Options.UseBorderColor = true;
            this.kissLookUpEdit2.Properties.Appearance.Options.UseFont = true;
            this.kissLookUpEdit2.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.kissLookUpEdit2.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLookUpEdit2.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.kissLookUpEdit2.Properties.AppearanceDropDown.Options.UseFont = true;
            this.kissLookUpEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.kissLookUpEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.kissLookUpEdit2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissLookUpEdit2.Properties.NullText = "";
            this.kissLookUpEdit2.Properties.ReadOnly = true;
            this.kissLookUpEdit2.Properties.ShowFooter = false;
            this.kissLookUpEdit2.Properties.ShowHeader = false;
            this.kissLookUpEdit2.Size = new System.Drawing.Size(169, 24);
            this.kissLookUpEdit2.TabIndex = 19;
            //
            // cboNationalitaet
            //
            this.cboNationalitaet.DataMember = "NationalitaetCode";
            this.cboNationalitaet.DataSource = this.qryBaPerson;
            this.cboNationalitaet.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.cboNationalitaet.Location = new System.Drawing.Point(535, 38);
            this.cboNationalitaet.LOVName = "BaLand";
            this.cboNationalitaet.Name = "cboNationalitaet";
            this.cboNationalitaet.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.cboNationalitaet.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboNationalitaet.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboNationalitaet.Properties.Appearance.Options.UseBackColor = true;
            this.cboNationalitaet.Properties.Appearance.Options.UseBorderColor = true;
            this.cboNationalitaet.Properties.Appearance.Options.UseFont = true;
            this.cboNationalitaet.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboNationalitaet.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboNationalitaet.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboNationalitaet.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboNationalitaet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.cboNationalitaet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.cboNationalitaet.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboNationalitaet.Properties.NullText = "";
            this.cboNationalitaet.Properties.ReadOnly = true;
            this.cboNationalitaet.Properties.ShowFooter = false;
            this.cboNationalitaet.Properties.ShowHeader = false;
            this.cboNationalitaet.Properties.EditValueChanged += new System.EventHandler(this.cboNationalitaet_EditValueChanged);
            this.cboNationalitaet.Size = new System.Drawing.Size(169, 24);
            this.cboNationalitaet.TabIndex = 17;
            //
            // kissTextEdit9
            //
            this.kissTextEdit9.DataMember = "MobilTel";
            this.kissTextEdit9.DataSource = this.qryBaPerson;
            this.kissTextEdit9.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit9.Location = new System.Drawing.Point(99, 144);
            this.kissTextEdit9.Name = "kissTextEdit9";
            this.kissTextEdit9.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit9.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit9.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit9.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit9.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit9.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit9.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit9.Properties.ReadOnly = true;
            this.kissTextEdit9.Size = new System.Drawing.Size(333, 24);
            this.kissTextEdit9.TabIndex = 6;
            //
            // kissTextEdit8
            //
            this.kissTextEdit8.DataMember = "EMail";
            this.kissTextEdit8.DataSource = this.qryBaPerson;
            this.kissTextEdit8.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit8.Location = new System.Drawing.Point(99, 197);
            this.kissTextEdit8.Name = "kissTextEdit8";
            this.kissTextEdit8.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit8.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit8.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit8.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit8.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit8.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit8.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit8.Properties.ReadOnly = true;
            this.kissTextEdit8.Size = new System.Drawing.Size(333, 24);
            this.kissTextEdit8.TabIndex = 8;
            //
            // kissTextEdit7
            //
            this.kissTextEdit7.DataMember = "Fax";
            this.kissTextEdit7.DataSource = this.qryBaPerson;
            this.kissTextEdit7.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit7.Location = new System.Drawing.Point(99, 174);
            this.kissTextEdit7.Name = "kissTextEdit7";
            this.kissTextEdit7.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit7.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit7.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit7.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit7.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit7.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit7.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit7.Properties.ReadOnly = true;
            this.kissTextEdit7.Size = new System.Drawing.Size(333, 24);
            this.kissTextEdit7.TabIndex = 7;
            //
            // kissTextEdit6
            //
            this.kissTextEdit6.DataMember = "Telefon_G";
            this.kissTextEdit6.DataSource = this.qryBaPerson;
            this.kissTextEdit6.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit6.Location = new System.Drawing.Point(99, 121);
            this.kissTextEdit6.Name = "kissTextEdit6";
            this.kissTextEdit6.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit6.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit6.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit6.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit6.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit6.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit6.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit6.Properties.ReadOnly = true;
            this.kissTextEdit6.Size = new System.Drawing.Size(333, 24);
            this.kissTextEdit6.TabIndex = 5;
            //
            // kissTextEdit5
            //
            this.kissTextEdit5.DataMember = "Telefon_P";
            this.kissTextEdit5.DataSource = this.qryBaPerson;
            this.kissTextEdit5.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit5.Location = new System.Drawing.Point(99, 98);
            this.kissTextEdit5.Name = "kissTextEdit5";
            this.kissTextEdit5.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit5.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit5.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit5.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit5.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit5.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit5.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit5.Properties.ReadOnly = true;
            this.kissTextEdit5.Size = new System.Drawing.Size(333, 24);
            this.kissTextEdit5.TabIndex = 4;
            //
            // editFruehererName
            //
            this.editFruehererName.DataMember = "FruehererName";
            this.editFruehererName.DataSource = this.qryBaPerson;
            this.editFruehererName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editFruehererName.Location = new System.Drawing.Point(99, 68);
            this.editFruehererName.Name = "editFruehererName";
            this.editFruehererName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editFruehererName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editFruehererName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editFruehererName.Properties.Appearance.Options.UseBackColor = true;
            this.editFruehererName.Properties.Appearance.Options.UseBorderColor = true;
            this.editFruehererName.Properties.Appearance.Options.UseFont = true;
            this.editFruehererName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editFruehererName.Properties.ReadOnly = true;
            this.editFruehererName.Size = new System.Drawing.Size(333, 24);
            this.editFruehererName.TabIndex = 3;
            //
            // editVorname
            //
            this.editVorname.DataMember = "Vorname";
            this.editVorname.DataSource = this.qryBaPerson;
            this.editVorname.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editVorname.Location = new System.Drawing.Point(309, 38);
            this.editVorname.Name = "editVorname";
            this.editVorname.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editVorname.Properties.Appearance.Options.UseBackColor = true;
            this.editVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.editVorname.Properties.Appearance.Options.UseFont = true;
            this.editVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editVorname.Properties.ReadOnly = true;
            this.editVorname.Size = new System.Drawing.Size(123, 24);
            this.editVorname.TabIndex = 2;
            //
            // kissTextEdit2
            //
            this.kissTextEdit2.DataMember = "Titel";
            this.kissTextEdit2.DataSource = this.qryBaPerson;
            this.kissTextEdit2.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit2.Location = new System.Drawing.Point(99, 8);
            this.kissTextEdit2.Name = "kissTextEdit2";
            this.kissTextEdit2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit2.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit2.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit2.Properties.ReadOnly = true;
            this.kissTextEdit2.Size = new System.Drawing.Size(100, 24);
            this.kissTextEdit2.TabIndex = 0;
            //
            // editName
            //
            this.editName.DataMember = "Name";
            this.editName.DataSource = this.qryBaPerson;
            this.editName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editName.Location = new System.Drawing.Point(99, 38);
            this.editName.Name = "editName";
            this.editName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editName.Properties.Appearance.Options.UseBackColor = true;
            this.editName.Properties.Appearance.Options.UseBorderColor = true;
            this.editName.Properties.Appearance.Options.UseFont = true;
            this.editName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editName.Properties.ReadOnly = true;
            this.editName.Size = new System.Drawing.Size(212, 24);
            this.editName.TabIndex = 1;
            //
            // kissLabel21
            //
            this.kissLabel21.ForeColor = System.Drawing.Color.Black;
            this.kissLabel21.Location = new System.Drawing.Point(442, 274);
            this.kissLabel21.Name = "kissLabel21";
            this.kissLabel21.Size = new System.Drawing.Size(45, 24);
            this.kissLabel21.TabIndex = 424;
            this.kissLabel21.Text = "Religion";
            //
            // kissLabel20
            //
            this.kissLabel20.ForeColor = System.Drawing.Color.Black;
            this.kissLabel20.Location = new System.Drawing.Point(442, 251);
            this.kissLabel20.Name = "kissLabel20";
            this.kissLabel20.Size = new System.Drawing.Size(55, 24);
            this.kissLabel20.TabIndex = 423;
            this.kissLabel20.Text = "Zivilstand";
            //
            // kissLabel19
            //
            this.kissLabel19.ForeColor = System.Drawing.Color.Black;
            this.kissLabel19.Location = new System.Drawing.Point(442, 228);
            this.kissLabel19.Name = "kissLabel19";
            this.kissLabel19.Size = new System.Drawing.Size(65, 24);
            this.kissLabel19.TabIndex = 422;
            this.kissLabel19.Text = "Geschlecht";
            //
            // kissLabel18
            //
            this.kissLabel18.ForeColor = System.Drawing.Color.Black;
            this.kissLabel18.Location = new System.Drawing.Point(5, 274);
            this.kissLabel18.Name = "kissLabel18";
            this.kissLabel18.Size = new System.Drawing.Size(70, 24);
            this.kissLabel18.TabIndex = 421;
            this.kissLabel18.Text = "BFM-Nummer";
            //
            // kissLabel17
            //
            this.kissLabel17.ForeColor = System.Drawing.Color.Black;
            this.kissLabel17.Location = new System.Drawing.Point(5, 251);
            this.kissLabel17.Name = "kissLabel17";
            this.kissLabel17.Size = new System.Drawing.Size(65, 24);
            this.kissLabel17.TabIndex = 420;
            this.kissLabel17.Text = "N-Nummer";
            //
            // kissLabel16
            //
            this.kissLabel16.ForeColor = System.Drawing.Color.Black;
            this.kissLabel16.Location = new System.Drawing.Point(5, 228);
            this.kissLabel16.Name = "kissLabel16";
            this.kissLabel16.Size = new System.Drawing.Size(45, 24);
            this.kissLabel16.TabIndex = 419;
            this.kissLabel16.Text = "AHV-Nr";
            //
            // kissLabel15
            //
            this.kissLabel15.ForeColor = System.Drawing.Color.Black;
            this.kissLabel15.Location = new System.Drawing.Point(440, 91);
            this.kissLabel15.Name = "kissLabel15";
            this.kissLabel15.Size = new System.Drawing.Size(45, 24);
            this.kissLabel15.TabIndex = 418;
            this.kissLabel15.Text = "Sprache";
            //
            // kissLabel13
            //
            this.kissLabel13.ForeColor = System.Drawing.Color.Black;
            this.kissLabel13.Location = new System.Drawing.Point(442, 144);
            this.kissLabel13.Name = "kissLabel13";
            this.kissLabel13.Size = new System.Drawing.Size(90, 24);
            this.kissLabel13.TabIndex = 416;
            this.kissLabel13.Text = "in Schweiz seit";
            //
            // kissLabel12
            //
            this.kissLabel12.ForeColor = System.Drawing.Color.Black;
            this.kissLabel12.Location = new System.Drawing.Point(442, 174);
            this.kissLabel12.Name = "kissLabel12";
            this.kissLabel12.Size = new System.Drawing.Size(85, 24);
            this.kissLabel12.TabIndex = 415;
            this.kissLabel12.Text = "Ausl.-Status";
            //
            // kissLabel11
            //
            this.kissLabel11.ForeColor = System.Drawing.Color.Black;
            this.kissLabel11.Location = new System.Drawing.Point(442, 197);
            this.kissLabel11.Name = "kissLabel11";
            this.kissLabel11.Size = new System.Drawing.Size(80, 24);
            this.kissLabel11.TabIndex = 414;
            this.kissLabel11.Text = "Status gültig bis";
            //
            // kissLabel10
            //
            this.kissLabel10.ForeColor = System.Drawing.Color.Black;
            this.kissLabel10.Location = new System.Drawing.Point(5, 8);
            this.kissLabel10.Name = "kissLabel10";
            this.kissLabel10.Size = new System.Drawing.Size(80, 24);
            this.kissLabel10.TabIndex = 413;
            this.kissLabel10.Text = "Anrede / Titel";
            //
            // kissLabel9
            //
            this.kissLabel9.ForeColor = System.Drawing.Color.Black;
            this.kissLabel9.Location = new System.Drawing.Point(5, 68);
            this.kissLabel9.Name = "kissLabel9";
            this.kissLabel9.Size = new System.Drawing.Size(80, 24);
            this.kissLabel9.TabIndex = 412;
            this.kissLabel9.Text = "Früherer Name";
            //
            // kissLabel8
            //
            this.kissLabel8.ForeColor = System.Drawing.Color.Black;
            this.kissLabel8.Location = new System.Drawing.Point(5, 98);
            this.kissLabel8.Name = "kissLabel8";
            this.kissLabel8.Size = new System.Drawing.Size(70, 24);
            this.kissLabel8.TabIndex = 411;
            this.kissLabel8.Text = "Telefon privat";
            //
            // kissLabel7
            //
            this.kissLabel7.ForeColor = System.Drawing.Color.Black;
            this.kissLabel7.Location = new System.Drawing.Point(5, 121);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(75, 24);
            this.kissLabel7.TabIndex = 410;
            this.kissLabel7.Text = "Telefon gesch.";
            //
            // kissLabel6
            //
            this.kissLabel6.ForeColor = System.Drawing.Color.Black;
            this.kissLabel6.Location = new System.Drawing.Point(5, 144);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(70, 24);
            this.kissLabel6.TabIndex = 409;
            this.kissLabel6.Text = "Telefon mobil";
            //
            // kissLabel5
            //
            this.kissLabel5.ForeColor = System.Drawing.Color.Black;
            this.kissLabel5.Location = new System.Drawing.Point(5, 174);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(31, 24);
            this.kissLabel5.TabIndex = 408;
            this.kissLabel5.Text = "Fax";
            //
            // kissLabel4
            //
            this.kissLabel4.ForeColor = System.Drawing.Color.Black;
            this.kissLabel4.Location = new System.Drawing.Point(5, 197);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(31, 24);
            this.kissLabel4.TabIndex = 407;
            this.kissLabel4.Text = "EMail";
            //
            // kissLabel3
            //
            this.kissLabel3.ForeColor = System.Drawing.Color.Black;
            this.kissLabel3.Location = new System.Drawing.Point(5, 350);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(70, 24);
            this.kissLabel3.TabIndex = 406;
            this.kissLabel3.Text = "Bemerkung";
            //
            // kissLabel2
            //
            this.kissLabel2.ForeColor = System.Drawing.Color.Black;
            this.kissLabel2.Location = new System.Drawing.Point(440, 38);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(45, 24);
            this.kissLabel2.TabIndex = 405;
            this.kissLabel2.Text = "Nation";
            //
            // kissLabel1
            //
            this.kissLabel1.ForeColor = System.Drawing.Color.Black;
            this.kissLabel1.Location = new System.Drawing.Point(440, 61);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(55, 24);
            this.kissLabel1.TabIndex = 404;
            this.kissLabel1.Text = "Heimatort";
            //
            // label9
            //
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(5, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 24);
            this.label9.TabIndex = 403;
            this.label9.Text = "Name / Vorname";
            //
            // tabAdressen
            //
            this.tabAdressen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.tabAdressen.Controls.Add(this.panel3);
            this.tabAdressen.Location = new System.Drawing.Point(6, 32);
            this.tabAdressen.Name = "tabAdressen";
            this.tabAdressen.Size = new System.Drawing.Size(707, 552);
            this.tabAdressen.TabIndex = 1;
            this.tabAdressen.Title = "Adressen";
            this.tabAdressen.Visible = false;
            //
            // panel3
            //
            this.panel3.Controls.Add(this.kissLookUpEdit1);
            this.panel3.Controls.Add(this.btnInstitution);
            this.panel3.Controls.Add(this.editZuzugKantonLandCode);
            this.panel3.Controls.Add(this.kissTextEdit10);
            this.panel3.Controls.Add(this.kissTextEdit11);
            this.panel3.Controls.Add(this.kissLabel14);
            this.panel3.Controls.Add(this.dtpZuzugKantonSeit);
            this.panel3.Controls.Add(this.editOrtZuzugKanton);
            this.panel3.Controls.Add(this.editZuzugKantonKanton);
            this.panel3.Controls.Add(this.editPLZZuzugKanton);
            this.panel3.Controls.Add(this.kissLabel45);
            this.panel3.Controls.Add(this.editLandZuzug);
            this.panel3.Controls.Add(this.kissLabel44);
            this.panel3.Controls.Add(this.kissLabel43);
            this.panel3.Controls.Add(this.kissLabel42);
            this.panel3.Controls.Add(this.dtpZuzugSeit);
            this.panel3.Controls.Add(this.kissLabel40);
            this.panel3.Controls.Add(this.editOrtUnterstuetzung);
            this.panel3.Controls.Add(this.editKantonUnterstützung);
            this.panel3.Controls.Add(this.editPLZUnterstuetzung);
            this.panel3.Controls.Add(this.editBemerkungRTF_Wohnsituation);
            this.panel3.Controls.Add(this.kissLabel38);
            this.panel3.Controls.Add(this.kissDateEdit7);
            this.panel3.Controls.Add(this.kissLabel37);
            this.panel3.Controls.Add(this.editOrtWegzug);
            this.panel3.Controls.Add(this.kissLookUpEdit13);
            this.panel3.Controls.Add(this.editKantonWegzug);
            this.panel3.Controls.Add(this.editPLZWegzug);
            this.panel3.Controls.Add(this.editOrtZuzug);
            this.panel3.Controls.Add(this.editKantonZuzug);
            this.panel3.Controls.Add(this.editPLZZuzug);
            this.panel3.Controls.Add(this.kissLabel35);
            this.panel3.Controls.Add(this.kissLabel36);
            this.panel3.Controls.Add(this.editAufenthaltsOrtOrt);
            this.panel3.Controls.Add(this.editAufenthaltsortLand);
            this.panel3.Controls.Add(this.editKantonAufenthalt);
            this.panel3.Controls.Add(this.editAufenthaltsOrtPLZ);
            this.panel3.Controls.Add(this.editAufenthaltsOrtPosfach);
            this.panel3.Controls.Add(this.editAufenthaltsOrtNummer);
            this.panel3.Controls.Add(this.kissTextEdit22);
            this.panel3.Controls.Add(this.editStrasseAufenthaltsOrt);
            this.panel3.Controls.Add(this.editOrtWohnsitz);
            this.panel3.Controls.Add(this.cboWohnungsGroesse);
            this.panel3.Controls.Add(this.cboWohnStatus);
            this.panel3.Controls.Add(this.kissLabel34);
            this.panel3.Controls.Add(this.editLandWohnsitz);
            this.panel3.Controls.Add(this.kissLabel33);
            this.panel3.Controls.Add(this.kissLabel32);
            this.panel3.Controls.Add(this.kissLabel31);
            this.panel3.Controls.Add(this.kissLabel30);
            this.panel3.Controls.Add(this.editKantonWohnsitz);
            this.panel3.Controls.Add(this.editPLZWohnsitz);
            this.panel3.Controls.Add(this.editPostfachWohnsitz);
            this.panel3.Controls.Add(this.editNummerWohnsitz);
            this.panel3.Controls.Add(this.editZusatzWohnsitz);
            this.panel3.Controls.Add(this.editStrasseWohnsitz);
            this.panel3.Controls.Add(this.kissLabel24);
            this.panel3.Controls.Add(this.kissLabel25);
            this.panel3.Controls.Add(this.kissLabel26);
            this.panel3.Controls.Add(this.kissLabel27);
            this.panel3.Controls.Add(this.kissLabel28);
            this.panel3.Controls.Add(this.kissLabel29);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(707, 552);
            this.panel3.TabIndex = 0;
            //
            // kissLookUpEdit1
            //
            this.kissLookUpEdit1.DataMember = "UntWohnsitzLandCode";
            this.kissLookUpEdit1.DataSource = this.qryBaPerson;
            this.kissLookUpEdit1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissLookUpEdit1.Location = new System.Drawing.Point(405, 263);
            this.kissLookUpEdit1.LOVName = "BaLand";
            this.kissLookUpEdit1.Name = "kissLookUpEdit1";
            this.kissLookUpEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissLookUpEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissLookUpEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissLookUpEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissLookUpEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissLookUpEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissLookUpEdit1.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.kissLookUpEdit1.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLookUpEdit1.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.kissLookUpEdit1.Properties.AppearanceDropDown.Options.UseFont = true;
            this.kissLookUpEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.kissLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.kissLookUpEdit1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissLookUpEdit1.Properties.NullText = "";
            this.kissLookUpEdit1.Properties.ReadOnly = true;
            this.kissLookUpEdit1.Properties.ShowFooter = false;
            this.kissLookUpEdit1.Properties.ShowHeader = false;
            this.kissLookUpEdit1.Size = new System.Drawing.Size(270, 24);
            this.kissLookUpEdit1.TabIndex = 63;
            //
            // btnInstitution
            //
            this.btnInstitution.DataMember = "PlatzierungInst";
            this.btnInstitution.DataSource = this.qryAufenthaltAdr;
            this.btnInstitution.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.btnInstitution.Location = new System.Drawing.Point(405, 24);
            this.btnInstitution.Name = "btnInstitution";
            this.btnInstitution.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.btnInstitution.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.btnInstitution.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btnInstitution.Properties.Appearance.Options.UseBackColor = true;
            this.btnInstitution.Properties.Appearance.Options.UseBorderColor = true;
            this.btnInstitution.Properties.Appearance.Options.UseFont = true;
            this.btnInstitution.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.btnInstitution.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.btnInstitution.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnInstitution.Properties.ReadOnly = true;
            this.btnInstitution.Size = new System.Drawing.Size(270, 24);
            this.btnInstitution.TabIndex = 40;
            //
            // qryAufenthaltAdr
            //
            this.qryAufenthaltAdr.HostControl = this;
            this.qryAufenthaltAdr.TableName = "BaAdresse";
            //
            // editZuzugKantonLandCode
            //
            this.editZuzugKantonLandCode.DataMember = "ZuzugKtLandCode";
            this.editZuzugKantonLandCode.DataSource = this.qryBaPerson;
            this.editZuzugKantonLandCode.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editZuzugKantonLandCode.Location = new System.Drawing.Point(99, 359);
            this.editZuzugKantonLandCode.LOVName = "BaLand";
            this.editZuzugKantonLandCode.Name = "editZuzugKantonLandCode";
            this.editZuzugKantonLandCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editZuzugKantonLandCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editZuzugKantonLandCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editZuzugKantonLandCode.Properties.Appearance.Options.UseBackColor = true;
            this.editZuzugKantonLandCode.Properties.Appearance.Options.UseBorderColor = true;
            this.editZuzugKantonLandCode.Properties.Appearance.Options.UseFont = true;
            this.editZuzugKantonLandCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.editZuzugKantonLandCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editZuzugKantonLandCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.editZuzugKantonLandCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.editZuzugKantonLandCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject16.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject16.Options.UseBackColor = true;
            this.editZuzugKantonLandCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject16)});
            this.editZuzugKantonLandCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editZuzugKantonLandCode.Properties.NullText = "";
            this.editZuzugKantonLandCode.Properties.ReadOnly = true;
            this.editZuzugKantonLandCode.Properties.ShowFooter = false;
            this.editZuzugKantonLandCode.Properties.ShowHeader = false;
            this.editZuzugKantonLandCode.Size = new System.Drawing.Size(270, 24);
            this.editZuzugKantonLandCode.TabIndex = 36;
            //
            // kissTextEdit10
            //
            this.kissTextEdit10.DataMember = "Vorname";
            this.kissTextEdit10.DataSource = this.qryBaPerson;
            this.kissTextEdit10.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit10.Location = new System.Drawing.Point(246, 24);
            this.kissTextEdit10.Name = "kissTextEdit10";
            this.kissTextEdit10.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit10.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit10.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit10.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit10.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit10.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit10.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit10.Properties.ReadOnly = true;
            this.kissTextEdit10.Size = new System.Drawing.Size(123, 24);
            this.kissTextEdit10.TabIndex = 3;
            //
            // kissTextEdit11
            //
            this.kissTextEdit11.DataMember = "Name";
            this.kissTextEdit11.DataSource = this.qryBaPerson;
            this.kissTextEdit11.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit11.Location = new System.Drawing.Point(99, 24);
            this.kissTextEdit11.Name = "kissTextEdit11";
            this.kissTextEdit11.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit11.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit11.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit11.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit11.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit11.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit11.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit11.Properties.ReadOnly = true;
            this.kissTextEdit11.Size = new System.Drawing.Size(148, 24);
            this.kissTextEdit11.TabIndex = 2;
            //
            // kissLabel14
            //
            this.kissLabel14.ForeColor = System.Drawing.Color.Black;
            this.kissLabel14.Location = new System.Drawing.Point(6, 24);
            this.kissLabel14.Name = "kissLabel14";
            this.kissLabel14.Size = new System.Drawing.Size(90, 24);
            this.kissLabel14.TabIndex = 1;
            this.kissLabel14.Text = "Name / Vorname";
            //
            // dtpZuzugKantonSeit
            //
            this.dtpZuzugKantonSeit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.dtpZuzugKantonSeit.DataMember = "ZuzugKtDatum";
            this.dtpZuzugKantonSeit.DataSource = this.qryBaPerson;
            this.dtpZuzugKantonSeit.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.dtpZuzugKantonSeit.Location = new System.Drawing.Point(98, 384);
            this.dtpZuzugKantonSeit.Name = "dtpZuzugKantonSeit";
            this.dtpZuzugKantonSeit.Size = new System.Drawing.Size(225, 24);
            this.dtpZuzugKantonSeit.TabIndex = 38;
            //
            // editOrtZuzugKanton
            //
            this.editOrtZuzugKanton.DataMember = "ZuzugKtOrt";
            this.editOrtZuzugKanton.DataSource = this.qryBaPerson;
            this.editOrtZuzugKanton.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editOrtZuzugKanton.Location = new System.Drawing.Point(143, 336);
            this.editOrtZuzugKanton.Name = "editOrtZuzugKanton";
            this.editOrtZuzugKanton.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editOrtZuzugKanton.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editOrtZuzugKanton.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editOrtZuzugKanton.Properties.Appearance.Options.UseBackColor = true;
            this.editOrtZuzugKanton.Properties.Appearance.Options.UseBorderColor = true;
            this.editOrtZuzugKanton.Properties.Appearance.Options.UseFont = true;
            this.editOrtZuzugKanton.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editOrtZuzugKanton.Properties.ReadOnly = true;
            this.editOrtZuzugKanton.Size = new System.Drawing.Size(196, 24);
            this.editOrtZuzugKanton.TabIndex = 33;
            //
            // editZuzugKantonKanton
            //
            this.editZuzugKantonKanton.DataMember = "ZuzugKtKanton";
            this.editZuzugKantonKanton.DataSource = this.qryBaPerson;
            this.editZuzugKantonKanton.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editZuzugKantonKanton.Location = new System.Drawing.Point(338, 336);
            this.editZuzugKantonKanton.Name = "editZuzugKantonKanton";
            this.editZuzugKantonKanton.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editZuzugKantonKanton.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editZuzugKantonKanton.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editZuzugKantonKanton.Properties.Appearance.Options.UseBackColor = true;
            this.editZuzugKantonKanton.Properties.Appearance.Options.UseBorderColor = true;
            this.editZuzugKantonKanton.Properties.Appearance.Options.UseFont = true;
            this.editZuzugKantonKanton.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editZuzugKantonKanton.Properties.ReadOnly = true;
            this.editZuzugKantonKanton.Size = new System.Drawing.Size(31, 24);
            this.editZuzugKantonKanton.TabIndex = 34;
            //
            // editPLZZuzugKanton
            //
            this.editPLZZuzugKanton.DataMember = "ZuzugKtPLZ";
            this.editPLZZuzugKanton.DataSource = this.qryBaPerson;
            this.editPLZZuzugKanton.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editPLZZuzugKanton.Location = new System.Drawing.Point(99, 336);
            this.editPLZZuzugKanton.Name = "editPLZZuzugKanton";
            this.editPLZZuzugKanton.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editPLZZuzugKanton.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editPLZZuzugKanton.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editPLZZuzugKanton.Properties.Appearance.Options.UseBackColor = true;
            this.editPLZZuzugKanton.Properties.Appearance.Options.UseBorderColor = true;
            this.editPLZZuzugKanton.Properties.Appearance.Options.UseFont = true;
            this.editPLZZuzugKanton.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editPLZZuzugKanton.Properties.ReadOnly = true;
            this.editPLZZuzugKanton.Size = new System.Drawing.Size(45, 24);
            this.editPLZZuzugKanton.TabIndex = 32;
            //
            // kissLabel45
            //
            this.kissLabel45.ForeColor = System.Drawing.Color.Black;
            this.kissLabel45.Location = new System.Drawing.Point(5, 336);
            this.kissLabel45.Name = "kissLabel45";
            this.kissLabel45.Size = new System.Drawing.Size(85, 24);
            this.kissLabel45.TabIndex = 31;
            this.kissLabel45.Text = "PLZ / Ort / Kt";
            //
            // editLandZuzug
            //
            this.editLandZuzug.DataMember = "ZuzugGdeLandCode";
            this.editLandZuzug.DataSource = this.qryBaPerson;
            this.editLandZuzug.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editLandZuzug.Location = new System.Drawing.Point(99, 263);
            this.editLandZuzug.LOVName = "BaLand";
            this.editLandZuzug.Name = "editLandZuzug";
            this.editLandZuzug.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editLandZuzug.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editLandZuzug.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editLandZuzug.Properties.Appearance.Options.UseBackColor = true;
            this.editLandZuzug.Properties.Appearance.Options.UseBorderColor = true;
            this.editLandZuzug.Properties.Appearance.Options.UseFont = true;
            this.editLandZuzug.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.editLandZuzug.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editLandZuzug.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.editLandZuzug.Properties.AppearanceDropDown.Options.UseFont = true;
            this.editLandZuzug.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject17.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject17.Options.UseBackColor = true;
            this.editLandZuzug.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject17)});
            this.editLandZuzug.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editLandZuzug.Properties.NullText = "";
            this.editLandZuzug.Properties.ReadOnly = true;
            this.editLandZuzug.Properties.ShowFooter = false;
            this.editLandZuzug.Properties.ShowHeader = false;
            this.editLandZuzug.Size = new System.Drawing.Size(270, 24);
            this.editLandZuzug.TabIndex = 27;
            //
            // kissLabel44
            //
            this.kissLabel44.ForeColor = System.Drawing.Color.Black;
            this.kissLabel44.Location = new System.Drawing.Point(5, 384);
            this.kissLabel44.Name = "kissLabel44";
            this.kissLabel44.Size = new System.Drawing.Size(45, 24);
            this.kissLabel44.TabIndex = 37;
            this.kissLabel44.Text = "Datum";
            //
            // kissLabel43
            //
            this.kissLabel43.ForeColor = System.Drawing.Color.Black;
            this.kissLabel43.Location = new System.Drawing.Point(5, 359);
            this.kissLabel43.Name = "kissLabel43";
            this.kissLabel43.Size = new System.Drawing.Size(75, 24);
            this.kissLabel43.TabIndex = 35;
            this.kissLabel43.Text = "Land";
            //
            // kissLabel42
            //
            this.kissLabel42.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel42.ForeColor = System.Drawing.Color.Black;
            this.kissLabel42.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel42.Location = new System.Drawing.Point(99, 317);
            this.kissLabel42.Name = "kissLabel42";
            this.kissLabel42.Size = new System.Drawing.Size(138, 16);
            this.kissLabel42.TabIndex = 30;
            this.kissLabel42.Text = "Zuzug in den Kanton";
            //
            // dtpZuzugSeit
            //
            this.dtpZuzugSeit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.dtpZuzugSeit.DataMember = "ZuzugGdeDatum";
            this.dtpZuzugSeit.DataSource = this.qryBaPerson;
            this.dtpZuzugSeit.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.dtpZuzugSeit.Location = new System.Drawing.Point(98, 288);
            this.dtpZuzugSeit.Name = "dtpZuzugSeit";
            this.dtpZuzugSeit.Size = new System.Drawing.Size(204, 24);
            this.dtpZuzugSeit.TabIndex = 29;
            //
            // kissLabel40
            //
            this.kissLabel40.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel40.ForeColor = System.Drawing.Color.Black;
            this.kissLabel40.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel40.Location = new System.Drawing.Point(405, 221);
            this.kissLabel40.Name = "kissLabel40";
            this.kissLabel40.Size = new System.Drawing.Size(180, 16);
            this.kissLabel40.TabIndex = 51;
            this.kissLabel40.Text = "Unterstützungswohnsitz";
            //
            // editOrtUnterstuetzung
            //
            this.editOrtUnterstuetzung.DataMember = "UntWohnsitzOrt";
            this.editOrtUnterstuetzung.DataSource = this.qryBaPerson;
            this.editOrtUnterstuetzung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editOrtUnterstuetzung.Location = new System.Drawing.Point(449, 240);
            this.editOrtUnterstuetzung.Name = "editOrtUnterstuetzung";
            this.editOrtUnterstuetzung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editOrtUnterstuetzung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editOrtUnterstuetzung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editOrtUnterstuetzung.Properties.Appearance.Options.UseBackColor = true;
            this.editOrtUnterstuetzung.Properties.Appearance.Options.UseBorderColor = true;
            this.editOrtUnterstuetzung.Properties.Appearance.Options.UseFont = true;
            this.editOrtUnterstuetzung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editOrtUnterstuetzung.Properties.ReadOnly = true;
            this.editOrtUnterstuetzung.Size = new System.Drawing.Size(196, 24);
            this.editOrtUnterstuetzung.TabIndex = 53;
            //
            // editKantonUnterstützung
            //
            this.editKantonUnterstützung.DataMember = "UntWohnsitzKanton";
            this.editKantonUnterstützung.DataSource = this.qryBaPerson;
            this.editKantonUnterstützung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editKantonUnterstützung.Location = new System.Drawing.Point(644, 240);
            this.editKantonUnterstützung.Name = "editKantonUnterstützung";
            this.editKantonUnterstützung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editKantonUnterstützung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editKantonUnterstützung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editKantonUnterstützung.Properties.Appearance.Options.UseBackColor = true;
            this.editKantonUnterstützung.Properties.Appearance.Options.UseBorderColor = true;
            this.editKantonUnterstützung.Properties.Appearance.Options.UseFont = true;
            this.editKantonUnterstützung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editKantonUnterstützung.Properties.ReadOnly = true;
            this.editKantonUnterstützung.Size = new System.Drawing.Size(31, 24);
            this.editKantonUnterstützung.TabIndex = 54;
            //
            // editPLZUnterstuetzung
            //
            this.editPLZUnterstuetzung.DataMember = "UntWohnsitzPLZ";
            this.editPLZUnterstuetzung.DataSource = this.qryBaPerson;
            this.editPLZUnterstuetzung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editPLZUnterstuetzung.Location = new System.Drawing.Point(405, 240);
            this.editPLZUnterstuetzung.Name = "editPLZUnterstuetzung";
            this.editPLZUnterstuetzung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editPLZUnterstuetzung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editPLZUnterstuetzung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editPLZUnterstuetzung.Properties.Appearance.Options.UseBackColor = true;
            this.editPLZUnterstuetzung.Properties.Appearance.Options.UseBorderColor = true;
            this.editPLZUnterstuetzung.Properties.Appearance.Options.UseFont = true;
            this.editPLZUnterstuetzung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editPLZUnterstuetzung.Properties.ReadOnly = true;
            this.editPLZUnterstuetzung.Size = new System.Drawing.Size(45, 24);
            this.editPLZUnterstuetzung.TabIndex = 52;
            //
            // editBemerkungRTF_Wohnsituation
            //
            this.editBemerkungRTF_Wohnsituation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.editBemerkungRTF_Wohnsituation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editBemerkungRTF_Wohnsituation.DataMember = "Bemerkung";
            this.editBemerkungRTF_Wohnsituation.DataSource = this.qryWohnsitzAdr;
            this.editBemerkungRTF_Wohnsituation.Font = new System.Drawing.Font("Arial", 10F);
            this.editBemerkungRTF_Wohnsituation.Location = new System.Drawing.Point(100, 411);
            this.editBemerkungRTF_Wohnsituation.Name = "editBemerkungRTF_Wohnsituation";
            this.editBemerkungRTF_Wohnsituation.Size = new System.Drawing.Size(570, 126);
            this.editBemerkungRTF_Wohnsituation.TabIndex = 62;
            //
            // qryWohnsitzAdr
            //
            this.qryWohnsitzAdr.HostControl = this;
            this.qryWohnsitzAdr.TableName = "BaAdresse";
            //
            // kissLabel38
            //
            this.kissLabel38.ForeColor = System.Drawing.Color.Black;
            this.kissLabel38.Location = new System.Drawing.Point(6, 411);
            this.kissLabel38.Name = "kissLabel38";
            this.kissLabel38.Size = new System.Drawing.Size(70, 24);
            this.kissLabel38.TabIndex = 61;
            this.kissLabel38.Text = "Bemerkung";
            //
            // kissDateEdit7
            //
            this.kissDateEdit7.DataMember = "WegzugDatum";
            this.kissDateEdit7.DataSource = this.qryBaPerson;
            this.kissDateEdit7.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissDateEdit7.EditValue = null;
            this.kissDateEdit7.Location = new System.Drawing.Point(405, 384);
            this.kissDateEdit7.Name = "kissDateEdit7";
            this.kissDateEdit7.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.kissDateEdit7.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissDateEdit7.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissDateEdit7.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissDateEdit7.Properties.Appearance.Options.UseBackColor = true;
            this.kissDateEdit7.Properties.Appearance.Options.UseBorderColor = true;
            this.kissDateEdit7.Properties.Appearance.Options.UseFont = true;
            this.kissDateEdit7.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject18.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject18.Options.UseBackColor = true;
            this.kissDateEdit7.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("kissDateEdit7.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject18)});
            this.kissDateEdit7.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissDateEdit7.Properties.ReadOnly = true;
            this.kissDateEdit7.Properties.ShowToday = false;
            this.kissDateEdit7.Size = new System.Drawing.Size(90, 24);
            this.kissDateEdit7.TabIndex = 60;
            //
            // kissLabel37
            //
            this.kissLabel37.ForeColor = System.Drawing.Color.Black;
            this.kissLabel37.Location = new System.Drawing.Point(5, 288);
            this.kissLabel37.Name = "kissLabel37";
            this.kissLabel37.Size = new System.Drawing.Size(45, 24);
            this.kissLabel37.TabIndex = 28;
            this.kissLabel37.Text = "Datum";
            //
            // editOrtWegzug
            //
            this.editOrtWegzug.DataMember = "WegzugOrt";
            this.editOrtWegzug.DataSource = this.qryBaPerson;
            this.editOrtWegzug.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editOrtWegzug.Location = new System.Drawing.Point(449, 336);
            this.editOrtWegzug.Name = "editOrtWegzug";
            this.editOrtWegzug.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editOrtWegzug.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editOrtWegzug.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editOrtWegzug.Properties.Appearance.Options.UseBackColor = true;
            this.editOrtWegzug.Properties.Appearance.Options.UseBorderColor = true;
            this.editOrtWegzug.Properties.Appearance.Options.UseFont = true;
            this.editOrtWegzug.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editOrtWegzug.Properties.ReadOnly = true;
            this.editOrtWegzug.Size = new System.Drawing.Size(196, 24);
            this.editOrtWegzug.TabIndex = 57;
            //
            // kissLookUpEdit13
            //
            this.kissLookUpEdit13.DataMember = "WegzugLandCode";
            this.kissLookUpEdit13.DataSource = this.qryBaPerson;
            this.kissLookUpEdit13.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissLookUpEdit13.Location = new System.Drawing.Point(405, 359);
            this.kissLookUpEdit13.LOVName = "BaLand";
            this.kissLookUpEdit13.Name = "kissLookUpEdit13";
            this.kissLookUpEdit13.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissLookUpEdit13.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissLookUpEdit13.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissLookUpEdit13.Properties.Appearance.Options.UseBackColor = true;
            this.kissLookUpEdit13.Properties.Appearance.Options.UseBorderColor = true;
            this.kissLookUpEdit13.Properties.Appearance.Options.UseFont = true;
            this.kissLookUpEdit13.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.kissLookUpEdit13.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLookUpEdit13.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.kissLookUpEdit13.Properties.AppearanceDropDown.Options.UseFont = true;
            this.kissLookUpEdit13.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject19.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject19.Options.UseBackColor = true;
            this.kissLookUpEdit13.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject19)});
            this.kissLookUpEdit13.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissLookUpEdit13.Properties.NullText = "";
            this.kissLookUpEdit13.Properties.ReadOnly = true;
            this.kissLookUpEdit13.Properties.ShowFooter = false;
            this.kissLookUpEdit13.Properties.ShowHeader = false;
            this.kissLookUpEdit13.Size = new System.Drawing.Size(270, 24);
            this.kissLookUpEdit13.TabIndex = 59;
            //
            // editKantonWegzug
            //
            this.editKantonWegzug.DataMember = "WegzugKanton";
            this.editKantonWegzug.DataSource = this.qryBaPerson;
            this.editKantonWegzug.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editKantonWegzug.Location = new System.Drawing.Point(644, 336);
            this.editKantonWegzug.Name = "editKantonWegzug";
            this.editKantonWegzug.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editKantonWegzug.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editKantonWegzug.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editKantonWegzug.Properties.Appearance.Options.UseBackColor = true;
            this.editKantonWegzug.Properties.Appearance.Options.UseBorderColor = true;
            this.editKantonWegzug.Properties.Appearance.Options.UseFont = true;
            this.editKantonWegzug.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editKantonWegzug.Properties.ReadOnly = true;
            this.editKantonWegzug.Size = new System.Drawing.Size(31, 24);
            this.editKantonWegzug.TabIndex = 58;
            //
            // editPLZWegzug
            //
            this.editPLZWegzug.DataMember = "WegzugPLZ";
            this.editPLZWegzug.DataSource = this.qryBaPerson;
            this.editPLZWegzug.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editPLZWegzug.Location = new System.Drawing.Point(405, 336);
            this.editPLZWegzug.Name = "editPLZWegzug";
            this.editPLZWegzug.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editPLZWegzug.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editPLZWegzug.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editPLZWegzug.Properties.Appearance.Options.UseBackColor = true;
            this.editPLZWegzug.Properties.Appearance.Options.UseBorderColor = true;
            this.editPLZWegzug.Properties.Appearance.Options.UseFont = true;
            this.editPLZWegzug.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editPLZWegzug.Properties.ReadOnly = true;
            this.editPLZWegzug.Size = new System.Drawing.Size(45, 24);
            this.editPLZWegzug.TabIndex = 56;
            //
            // editOrtZuzug
            //
            this.editOrtZuzug.DataMember = "ZuzugGdeOrt";
            this.editOrtZuzug.DataSource = this.qryBaPerson;
            this.editOrtZuzug.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editOrtZuzug.Location = new System.Drawing.Point(143, 240);
            this.editOrtZuzug.Name = "editOrtZuzug";
            this.editOrtZuzug.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editOrtZuzug.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editOrtZuzug.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editOrtZuzug.Properties.Appearance.Options.UseBackColor = true;
            this.editOrtZuzug.Properties.Appearance.Options.UseBorderColor = true;
            this.editOrtZuzug.Properties.Appearance.Options.UseFont = true;
            this.editOrtZuzug.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editOrtZuzug.Properties.ReadOnly = true;
            this.editOrtZuzug.Size = new System.Drawing.Size(196, 24);
            this.editOrtZuzug.TabIndex = 24;
            //
            // editKantonZuzug
            //
            this.editKantonZuzug.DataMember = "ZuzugGdeKanton";
            this.editKantonZuzug.DataSource = this.qryBaPerson;
            this.editKantonZuzug.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editKantonZuzug.Location = new System.Drawing.Point(338, 240);
            this.editKantonZuzug.Name = "editKantonZuzug";
            this.editKantonZuzug.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editKantonZuzug.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editKantonZuzug.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editKantonZuzug.Properties.Appearance.Options.UseBackColor = true;
            this.editKantonZuzug.Properties.Appearance.Options.UseBorderColor = true;
            this.editKantonZuzug.Properties.Appearance.Options.UseFont = true;
            this.editKantonZuzug.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editKantonZuzug.Properties.ReadOnly = true;
            this.editKantonZuzug.Size = new System.Drawing.Size(31, 24);
            this.editKantonZuzug.TabIndex = 25;
            //
            // editPLZZuzug
            //
            this.editPLZZuzug.DataMember = "ZuzugGdePLZ";
            this.editPLZZuzug.DataSource = this.qryBaPerson;
            this.editPLZZuzug.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editPLZZuzug.Location = new System.Drawing.Point(99, 240);
            this.editPLZZuzug.Name = "editPLZZuzug";
            this.editPLZZuzug.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editPLZZuzug.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editPLZZuzug.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editPLZZuzug.Properties.Appearance.Options.UseBackColor = true;
            this.editPLZZuzug.Properties.Appearance.Options.UseBorderColor = true;
            this.editPLZZuzug.Properties.Appearance.Options.UseFont = true;
            this.editPLZZuzug.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editPLZZuzug.Properties.ReadOnly = true;
            this.editPLZZuzug.Size = new System.Drawing.Size(45, 24);
            this.editPLZZuzug.TabIndex = 23;
            //
            // kissLabel35
            //
            this.kissLabel35.ForeColor = System.Drawing.Color.Black;
            this.kissLabel35.Location = new System.Drawing.Point(5, 240);
            this.kissLabel35.Name = "kissLabel35";
            this.kissLabel35.Size = new System.Drawing.Size(85, 24);
            this.kissLabel35.TabIndex = 22;
            this.kissLabel35.Text = "PLZ / Ort / Kt";
            //
            // kissLabel36
            //
            this.kissLabel36.ForeColor = System.Drawing.Color.Black;
            this.kissLabel36.Location = new System.Drawing.Point(5, 263);
            this.kissLabel36.Name = "kissLabel36";
            this.kissLabel36.Size = new System.Drawing.Size(75, 24);
            this.kissLabel36.TabIndex = 26;
            this.kissLabel36.Text = "Land";
            //
            // editAufenthaltsOrtOrt
            //
            this.editAufenthaltsOrtOrt.DataMember = "Ort";
            this.editAufenthaltsOrtOrt.DataSource = this.qryAufenthaltAdr;
            this.editAufenthaltsOrtOrt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editAufenthaltsOrtOrt.Location = new System.Drawing.Point(449, 116);
            this.editAufenthaltsOrtOrt.Name = "editAufenthaltsOrtOrt";
            this.editAufenthaltsOrtOrt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editAufenthaltsOrtOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editAufenthaltsOrtOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editAufenthaltsOrtOrt.Properties.Appearance.Options.UseBackColor = true;
            this.editAufenthaltsOrtOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.editAufenthaltsOrtOrt.Properties.Appearance.Options.UseFont = true;
            this.editAufenthaltsOrtOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editAufenthaltsOrtOrt.Properties.ReadOnly = true;
            this.editAufenthaltsOrtOrt.Size = new System.Drawing.Size(196, 24);
            this.editAufenthaltsOrtOrt.TabIndex = 46;
            //
            // editAufenthaltsortLand
            //
            this.editAufenthaltsortLand.DataMember = "BaLandID";
            this.editAufenthaltsortLand.DataSource = this.qryAufenthaltAdr;
            this.editAufenthaltsortLand.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editAufenthaltsortLand.Location = new System.Drawing.Point(405, 139);
            this.editAufenthaltsortLand.LOVName = "BaLand";
            this.editAufenthaltsortLand.Name = "editAufenthaltsortLand";
            this.editAufenthaltsortLand.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editAufenthaltsortLand.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editAufenthaltsortLand.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editAufenthaltsortLand.Properties.Appearance.Options.UseBackColor = true;
            this.editAufenthaltsortLand.Properties.Appearance.Options.UseBorderColor = true;
            this.editAufenthaltsortLand.Properties.Appearance.Options.UseFont = true;
            this.editAufenthaltsortLand.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.editAufenthaltsortLand.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editAufenthaltsortLand.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.editAufenthaltsortLand.Properties.AppearanceDropDown.Options.UseFont = true;
            this.editAufenthaltsortLand.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject20.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject20.Options.UseBackColor = true;
            this.editAufenthaltsortLand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject20)});
            this.editAufenthaltsortLand.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editAufenthaltsortLand.Properties.NullText = "";
            this.editAufenthaltsortLand.Properties.ReadOnly = true;
            this.editAufenthaltsortLand.Properties.ShowFooter = false;
            this.editAufenthaltsortLand.Properties.ShowHeader = false;
            this.editAufenthaltsortLand.Size = new System.Drawing.Size(270, 24);
            this.editAufenthaltsortLand.TabIndex = 48;
            //
            // editKantonAufenthalt
            //
            this.editKantonAufenthalt.DataMember = "Kanton";
            this.editKantonAufenthalt.DataSource = this.qryAufenthaltAdr;
            this.editKantonAufenthalt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editKantonAufenthalt.Location = new System.Drawing.Point(644, 116);
            this.editKantonAufenthalt.Name = "editKantonAufenthalt";
            this.editKantonAufenthalt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editKantonAufenthalt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editKantonAufenthalt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editKantonAufenthalt.Properties.Appearance.Options.UseBackColor = true;
            this.editKantonAufenthalt.Properties.Appearance.Options.UseBorderColor = true;
            this.editKantonAufenthalt.Properties.Appearance.Options.UseFont = true;
            this.editKantonAufenthalt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editKantonAufenthalt.Properties.ReadOnly = true;
            this.editKantonAufenthalt.Size = new System.Drawing.Size(31, 24);
            this.editKantonAufenthalt.TabIndex = 47;
            //
            // editAufenthaltsOrtPLZ
            //
            this.editAufenthaltsOrtPLZ.DataMember = "PLZ";
            this.editAufenthaltsOrtPLZ.DataSource = this.qryAufenthaltAdr;
            this.editAufenthaltsOrtPLZ.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editAufenthaltsOrtPLZ.Location = new System.Drawing.Point(405, 116);
            this.editAufenthaltsOrtPLZ.Name = "editAufenthaltsOrtPLZ";
            this.editAufenthaltsOrtPLZ.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editAufenthaltsOrtPLZ.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editAufenthaltsOrtPLZ.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editAufenthaltsOrtPLZ.Properties.Appearance.Options.UseBackColor = true;
            this.editAufenthaltsOrtPLZ.Properties.Appearance.Options.UseBorderColor = true;
            this.editAufenthaltsOrtPLZ.Properties.Appearance.Options.UseFont = true;
            this.editAufenthaltsOrtPLZ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editAufenthaltsOrtPLZ.Properties.ReadOnly = true;
            this.editAufenthaltsOrtPLZ.Size = new System.Drawing.Size(45, 24);
            this.editAufenthaltsOrtPLZ.TabIndex = 45;
            //
            // editAufenthaltsOrtPosfach
            //
            this.editAufenthaltsOrtPosfach.DataMember = "Postfach";
            this.editAufenthaltsOrtPosfach.DataSource = this.qryAufenthaltAdr;
            this.editAufenthaltsOrtPosfach.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editAufenthaltsOrtPosfach.Location = new System.Drawing.Point(405, 93);
            this.editAufenthaltsOrtPosfach.Name = "editAufenthaltsOrtPosfach";
            this.editAufenthaltsOrtPosfach.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editAufenthaltsOrtPosfach.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editAufenthaltsOrtPosfach.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editAufenthaltsOrtPosfach.Properties.Appearance.Options.UseBackColor = true;
            this.editAufenthaltsOrtPosfach.Properties.Appearance.Options.UseBorderColor = true;
            this.editAufenthaltsOrtPosfach.Properties.Appearance.Options.UseFont = true;
            this.editAufenthaltsOrtPosfach.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editAufenthaltsOrtPosfach.Properties.ReadOnly = true;
            this.editAufenthaltsOrtPosfach.Size = new System.Drawing.Size(270, 24);
            this.editAufenthaltsOrtPosfach.TabIndex = 44;
            //
            // editAufenthaltsOrtNummer
            //
            this.editAufenthaltsOrtNummer.DataMember = "HausNr";
            this.editAufenthaltsOrtNummer.DataSource = this.qryAufenthaltAdr;
            this.editAufenthaltsOrtNummer.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editAufenthaltsOrtNummer.Location = new System.Drawing.Point(626, 70);
            this.editAufenthaltsOrtNummer.Name = "editAufenthaltsOrtNummer";
            this.editAufenthaltsOrtNummer.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editAufenthaltsOrtNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editAufenthaltsOrtNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editAufenthaltsOrtNummer.Properties.Appearance.Options.UseBackColor = true;
            this.editAufenthaltsOrtNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.editAufenthaltsOrtNummer.Properties.Appearance.Options.UseFont = true;
            this.editAufenthaltsOrtNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editAufenthaltsOrtNummer.Properties.ReadOnly = true;
            this.editAufenthaltsOrtNummer.Size = new System.Drawing.Size(49, 24);
            this.editAufenthaltsOrtNummer.TabIndex = 43;
            //
            // kissTextEdit22
            //
            this.kissTextEdit22.DataMember = "Zusatz";
            this.kissTextEdit22.DataSource = this.qryAufenthaltAdr;
            this.kissTextEdit22.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit22.Location = new System.Drawing.Point(405, 47);
            this.kissTextEdit22.Name = "kissTextEdit22";
            this.kissTextEdit22.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit22.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit22.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit22.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit22.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit22.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit22.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit22.Properties.ReadOnly = true;
            this.kissTextEdit22.Size = new System.Drawing.Size(270, 24);
            this.kissTextEdit22.TabIndex = 41;
            //
            // editStrasseAufenthaltsOrt
            //
            this.editStrasseAufenthaltsOrt.DataMember = "Strasse";
            this.editStrasseAufenthaltsOrt.DataSource = this.qryAufenthaltAdr;
            this.editStrasseAufenthaltsOrt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editStrasseAufenthaltsOrt.Location = new System.Drawing.Point(405, 70);
            this.editStrasseAufenthaltsOrt.Name = "editStrasseAufenthaltsOrt";
            this.editStrasseAufenthaltsOrt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editStrasseAufenthaltsOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editStrasseAufenthaltsOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editStrasseAufenthaltsOrt.Properties.Appearance.Options.UseBackColor = true;
            this.editStrasseAufenthaltsOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.editStrasseAufenthaltsOrt.Properties.Appearance.Options.UseFont = true;
            this.editStrasseAufenthaltsOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editStrasseAufenthaltsOrt.Properties.ReadOnly = true;
            this.editStrasseAufenthaltsOrt.Size = new System.Drawing.Size(222, 24);
            this.editStrasseAufenthaltsOrt.TabIndex = 42;
            //
            // editOrtWohnsitz
            //
            this.editOrtWohnsitz.DataMember = "Ort";
            this.editOrtWohnsitz.DataSource = this.qryWohnsitzAdr;
            this.editOrtWohnsitz.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editOrtWohnsitz.Location = new System.Drawing.Point(143, 116);
            this.editOrtWohnsitz.Name = "editOrtWohnsitz";
            this.editOrtWohnsitz.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editOrtWohnsitz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editOrtWohnsitz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editOrtWohnsitz.Properties.Appearance.Options.UseBackColor = true;
            this.editOrtWohnsitz.Properties.Appearance.Options.UseBorderColor = true;
            this.editOrtWohnsitz.Properties.Appearance.Options.UseFont = true;
            this.editOrtWohnsitz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editOrtWohnsitz.Properties.ReadOnly = true;
            this.editOrtWohnsitz.Size = new System.Drawing.Size(196, 24);
            this.editOrtWohnsitz.TabIndex = 13;
            //
            // cboWohnungsGroesse
            //
            this.cboWohnungsGroesse.DataMember = "WohnungsgroesseCode";
            this.cboWohnungsGroesse.DataSource = this.qryWohnsitzAdr;
            this.cboWohnungsGroesse.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.cboWohnungsGroesse.Location = new System.Drawing.Point(99, 190);
            this.cboWohnungsGroesse.LOVName = "Wohnungsgroesse";
            this.cboWohnungsGroesse.Name = "cboWohnungsGroesse";
            this.cboWohnungsGroesse.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.cboWohnungsGroesse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboWohnungsGroesse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboWohnungsGroesse.Properties.Appearance.Options.UseBackColor = true;
            this.cboWohnungsGroesse.Properties.Appearance.Options.UseBorderColor = true;
            this.cboWohnungsGroesse.Properties.Appearance.Options.UseFont = true;
            this.cboWohnungsGroesse.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboWohnungsGroesse.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboWohnungsGroesse.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboWohnungsGroesse.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboWohnungsGroesse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject21.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject21.Options.UseBackColor = true;
            this.cboWohnungsGroesse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject21)});
            this.cboWohnungsGroesse.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboWohnungsGroesse.Properties.NullText = "";
            this.cboWohnungsGroesse.Properties.ReadOnly = true;
            this.cboWohnungsGroesse.Properties.ShowFooter = false;
            this.cboWohnungsGroesse.Properties.ShowHeader = false;
            this.cboWohnungsGroesse.Size = new System.Drawing.Size(270, 24);
            this.cboWohnungsGroesse.TabIndex = 20;
            //
            // cboWohnStatus
            //
            this.cboWohnStatus.DataMember = "WohnStatusCode";
            this.cboWohnStatus.DataSource = this.qryWohnsitzAdr;
            this.cboWohnStatus.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.cboWohnStatus.Location = new System.Drawing.Point(99, 167);
            this.cboWohnStatus.LOVName = "Wohnstatus";
            this.cboWohnStatus.Name = "cboWohnStatus";
            this.cboWohnStatus.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.cboWohnStatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboWohnStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboWohnStatus.Properties.Appearance.Options.UseBackColor = true;
            this.cboWohnStatus.Properties.Appearance.Options.UseBorderColor = true;
            this.cboWohnStatus.Properties.Appearance.Options.UseFont = true;
            this.cboWohnStatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboWohnStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboWohnStatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboWohnStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboWohnStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject22.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject22.Options.UseBackColor = true;
            this.cboWohnStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject22)});
            this.cboWohnStatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboWohnStatus.Properties.NullText = "";
            this.cboWohnStatus.Properties.ReadOnly = true;
            this.cboWohnStatus.Properties.ShowFooter = false;
            this.cboWohnStatus.Properties.ShowHeader = false;
            this.cboWohnStatus.Size = new System.Drawing.Size(270, 24);
            this.cboWohnStatus.TabIndex = 18;
            //
            // kissLabel34
            //
            this.kissLabel34.ForeColor = System.Drawing.Color.Black;
            this.kissLabel34.Location = new System.Drawing.Point(5, 190);
            this.kissLabel34.Name = "kissLabel34";
            this.kissLabel34.Size = new System.Drawing.Size(91, 24);
            this.kissLabel34.TabIndex = 19;
            this.kissLabel34.Text = "Wohnungsgrösse";
            //
            // editLandWohnsitz
            //
            this.editLandWohnsitz.DataMember = "BaLandID";
            this.editLandWohnsitz.DataSource = this.qryWohnsitzAdr;
            this.editLandWohnsitz.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editLandWohnsitz.Location = new System.Drawing.Point(99, 139);
            this.editLandWohnsitz.LOVName = "BaLand";
            this.editLandWohnsitz.Name = "editLandWohnsitz";
            this.editLandWohnsitz.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editLandWohnsitz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editLandWohnsitz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editLandWohnsitz.Properties.Appearance.Options.UseBackColor = true;
            this.editLandWohnsitz.Properties.Appearance.Options.UseBorderColor = true;
            this.editLandWohnsitz.Properties.Appearance.Options.UseFont = true;
            this.editLandWohnsitz.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.editLandWohnsitz.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editLandWohnsitz.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.editLandWohnsitz.Properties.AppearanceDropDown.Options.UseFont = true;
            this.editLandWohnsitz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject23.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject23.Options.UseBackColor = true;
            this.editLandWohnsitz.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject23)});
            this.editLandWohnsitz.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editLandWohnsitz.Properties.NullText = "";
            this.editLandWohnsitz.Properties.ReadOnly = true;
            this.editLandWohnsitz.Properties.ShowFooter = false;
            this.editLandWohnsitz.Properties.ShowHeader = false;
            this.editLandWohnsitz.Size = new System.Drawing.Size(270, 24);
            this.editLandWohnsitz.TabIndex = 16;
            //
            // kissLabel33
            //
            this.kissLabel33.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel33.ForeColor = System.Drawing.Color.Black;
            this.kissLabel33.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel33.Location = new System.Drawing.Point(405, 317);
            this.kissLabel33.Name = "kissLabel33";
            this.kissLabel33.Size = new System.Drawing.Size(138, 16);
            this.kissLabel33.TabIndex = 55;
            this.kissLabel33.Text = "Wegzug";
            //
            // kissLabel32
            //
            this.kissLabel32.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel32.ForeColor = System.Drawing.Color.Black;
            this.kissLabel32.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel32.Location = new System.Drawing.Point(99, 221);
            this.kissLabel32.Name = "kissLabel32";
            this.kissLabel32.Size = new System.Drawing.Size(147, 16);
            this.kissLabel32.TabIndex = 21;
            this.kissLabel32.Text = "Zuzug in die Gemeinde";
            //
            // kissLabel31
            //
            this.kissLabel31.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel31.ForeColor = System.Drawing.Color.Black;
            this.kissLabel31.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel31.Location = new System.Drawing.Point(405, 5);
            this.kissLabel31.Name = "kissLabel31";
            this.kissLabel31.Size = new System.Drawing.Size(138, 16);
            this.kissLabel31.TabIndex = 39;
            this.kissLabel31.Text = "Aufenthaltsort";
            //
            // kissLabel30
            //
            this.kissLabel30.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel30.ForeColor = System.Drawing.Color.Black;
            this.kissLabel30.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel30.Location = new System.Drawing.Point(99, 5);
            this.kissLabel30.Name = "kissLabel30";
            this.kissLabel30.Size = new System.Drawing.Size(231, 16);
            this.kissLabel30.TabIndex = 0;
            this.kissLabel30.Text = "zivilrechtliche Adresse (Wohnsitz)";
            //
            // editKantonWohnsitz
            //
            this.editKantonWohnsitz.DataMember = "Kanton";
            this.editKantonWohnsitz.DataSource = this.qryWohnsitzAdr;
            this.editKantonWohnsitz.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editKantonWohnsitz.Location = new System.Drawing.Point(338, 116);
            this.editKantonWohnsitz.Name = "editKantonWohnsitz";
            this.editKantonWohnsitz.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editKantonWohnsitz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editKantonWohnsitz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editKantonWohnsitz.Properties.Appearance.Options.UseBackColor = true;
            this.editKantonWohnsitz.Properties.Appearance.Options.UseBorderColor = true;
            this.editKantonWohnsitz.Properties.Appearance.Options.UseFont = true;
            this.editKantonWohnsitz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editKantonWohnsitz.Properties.ReadOnly = true;
            this.editKantonWohnsitz.Size = new System.Drawing.Size(31, 24);
            this.editKantonWohnsitz.TabIndex = 14;
            //
            // editPLZWohnsitz
            //
            this.editPLZWohnsitz.DataMember = "PLZ";
            this.editPLZWohnsitz.DataSource = this.qryWohnsitzAdr;
            this.editPLZWohnsitz.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editPLZWohnsitz.Location = new System.Drawing.Point(99, 116);
            this.editPLZWohnsitz.Name = "editPLZWohnsitz";
            this.editPLZWohnsitz.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editPLZWohnsitz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editPLZWohnsitz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editPLZWohnsitz.Properties.Appearance.Options.UseBackColor = true;
            this.editPLZWohnsitz.Properties.Appearance.Options.UseBorderColor = true;
            this.editPLZWohnsitz.Properties.Appearance.Options.UseFont = true;
            this.editPLZWohnsitz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editPLZWohnsitz.Properties.ReadOnly = true;
            this.editPLZWohnsitz.Size = new System.Drawing.Size(45, 24);
            this.editPLZWohnsitz.TabIndex = 12;
            //
            // editPostfachWohnsitz
            //
            this.editPostfachWohnsitz.DataMember = "Postfach";
            this.editPostfachWohnsitz.DataSource = this.qryWohnsitzAdr;
            this.editPostfachWohnsitz.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editPostfachWohnsitz.Location = new System.Drawing.Point(99, 93);
            this.editPostfachWohnsitz.Name = "editPostfachWohnsitz";
            this.editPostfachWohnsitz.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editPostfachWohnsitz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editPostfachWohnsitz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editPostfachWohnsitz.Properties.Appearance.Options.UseBackColor = true;
            this.editPostfachWohnsitz.Properties.Appearance.Options.UseBorderColor = true;
            this.editPostfachWohnsitz.Properties.Appearance.Options.UseFont = true;
            this.editPostfachWohnsitz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editPostfachWohnsitz.Properties.ReadOnly = true;
            this.editPostfachWohnsitz.Size = new System.Drawing.Size(270, 24);
            this.editPostfachWohnsitz.TabIndex = 10;
            //
            // editNummerWohnsitz
            //
            this.editNummerWohnsitz.DataMember = "HausNr";
            this.editNummerWohnsitz.DataSource = this.qryWohnsitzAdr;
            this.editNummerWohnsitz.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editNummerWohnsitz.Location = new System.Drawing.Point(320, 70);
            this.editNummerWohnsitz.Name = "editNummerWohnsitz";
            this.editNummerWohnsitz.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editNummerWohnsitz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editNummerWohnsitz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editNummerWohnsitz.Properties.Appearance.Options.UseBackColor = true;
            this.editNummerWohnsitz.Properties.Appearance.Options.UseBorderColor = true;
            this.editNummerWohnsitz.Properties.Appearance.Options.UseFont = true;
            this.editNummerWohnsitz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editNummerWohnsitz.Properties.ReadOnly = true;
            this.editNummerWohnsitz.Size = new System.Drawing.Size(49, 24);
            this.editNummerWohnsitz.TabIndex = 8;
            //
            // editZusatzWohnsitz
            //
            this.editZusatzWohnsitz.DataMember = "Zusatz";
            this.editZusatzWohnsitz.DataSource = this.qryWohnsitzAdr;
            this.editZusatzWohnsitz.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editZusatzWohnsitz.Location = new System.Drawing.Point(99, 47);
            this.editZusatzWohnsitz.Name = "editZusatzWohnsitz";
            this.editZusatzWohnsitz.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editZusatzWohnsitz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editZusatzWohnsitz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editZusatzWohnsitz.Properties.Appearance.Options.UseBackColor = true;
            this.editZusatzWohnsitz.Properties.Appearance.Options.UseBorderColor = true;
            this.editZusatzWohnsitz.Properties.Appearance.Options.UseFont = true;
            this.editZusatzWohnsitz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editZusatzWohnsitz.Properties.ReadOnly = true;
            this.editZusatzWohnsitz.Size = new System.Drawing.Size(270, 24);
            this.editZusatzWohnsitz.TabIndex = 5;
            //
            // editStrasseWohnsitz
            //
            this.editStrasseWohnsitz.DataMember = "Strasse";
            this.editStrasseWohnsitz.DataSource = this.qryWohnsitzAdr;
            this.editStrasseWohnsitz.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editStrasseWohnsitz.Location = new System.Drawing.Point(99, 70);
            this.editStrasseWohnsitz.Name = "editStrasseWohnsitz";
            this.editStrasseWohnsitz.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editStrasseWohnsitz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editStrasseWohnsitz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editStrasseWohnsitz.Properties.Appearance.Options.UseBackColor = true;
            this.editStrasseWohnsitz.Properties.Appearance.Options.UseBorderColor = true;
            this.editStrasseWohnsitz.Properties.Appearance.Options.UseFont = true;
            this.editStrasseWohnsitz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editStrasseWohnsitz.Properties.ReadOnly = true;
            this.editStrasseWohnsitz.Size = new System.Drawing.Size(222, 24);
            this.editStrasseWohnsitz.TabIndex = 7;
            //
            // kissLabel24
            //
            this.kissLabel24.ForeColor = System.Drawing.Color.Black;
            this.kissLabel24.Location = new System.Drawing.Point(5, 47);
            this.kissLabel24.Name = "kissLabel24";
            this.kissLabel24.Size = new System.Drawing.Size(80, 24);
            this.kissLabel24.TabIndex = 4;
            this.kissLabel24.Text = "Zusatz";
            //
            // kissLabel25
            //
            this.kissLabel25.ForeColor = System.Drawing.Color.Black;
            this.kissLabel25.Location = new System.Drawing.Point(5, 93);
            this.kissLabel25.Name = "kissLabel25";
            this.kissLabel25.Size = new System.Drawing.Size(80, 24);
            this.kissLabel25.TabIndex = 9;
            this.kissLabel25.Text = "Postfach";
            //
            // kissLabel26
            //
            this.kissLabel26.ForeColor = System.Drawing.Color.Black;
            this.kissLabel26.Location = new System.Drawing.Point(5, 116);
            this.kissLabel26.Name = "kissLabel26";
            this.kissLabel26.Size = new System.Drawing.Size(70, 24);
            this.kissLabel26.TabIndex = 11;
            this.kissLabel26.Text = "PLZ / Ort / Kt";
            //
            // kissLabel27
            //
            this.kissLabel27.ForeColor = System.Drawing.Color.Black;
            this.kissLabel27.Location = new System.Drawing.Point(5, 139);
            this.kissLabel27.Name = "kissLabel27";
            this.kissLabel27.Size = new System.Drawing.Size(75, 24);
            this.kissLabel27.TabIndex = 15;
            this.kissLabel27.Text = "Land";
            //
            // kissLabel28
            //
            this.kissLabel28.ForeColor = System.Drawing.Color.Black;
            this.kissLabel28.Location = new System.Drawing.Point(5, 167);
            this.kissLabel28.Name = "kissLabel28";
            this.kissLabel28.Size = new System.Drawing.Size(70, 24);
            this.kissLabel28.TabIndex = 17;
            this.kissLabel28.Text = "Wohnstatus";
            //
            // kissLabel29
            //
            this.kissLabel29.ForeColor = System.Drawing.Color.Black;
            this.kissLabel29.Location = new System.Drawing.Point(5, 70);
            this.kissLabel29.Name = "kissLabel29";
            this.kissLabel29.Size = new System.Drawing.Size(90, 24);
            this.kissLabel29.TabIndex = 6;
            this.kissLabel29.Text = "Strasse / Nr";
            //
            // kissLookUpEdit10
            //
            this.kissLookUpEdit10.DataMember = "WohnsituationSizeCode";
            this.kissLookUpEdit10.Location = new System.Drawing.Point(405, 203);
            this.kissLookUpEdit10.LOVName = "Wohnungsgroesse";
            this.kissLookUpEdit10.Name = "kissLookUpEdit10";
            this.kissLookUpEdit10.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.kissLookUpEdit10.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissLookUpEdit10.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissLookUpEdit10.Properties.Appearance.Options.UseBackColor = true;
            this.kissLookUpEdit10.Properties.Appearance.Options.UseBorderColor = true;
            this.kissLookUpEdit10.Properties.Appearance.Options.UseFont = true;
            this.kissLookUpEdit10.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.kissLookUpEdit10.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLookUpEdit10.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.kissLookUpEdit10.Properties.AppearanceDropDown.Options.UseFont = true;
            this.kissLookUpEdit10.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject24.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject24.Options.UseBackColor = true;
            this.kissLookUpEdit10.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject24)});
            this.kissLookUpEdit10.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissLookUpEdit10.Properties.NullText = "";
            this.kissLookUpEdit10.Properties.ShowFooter = false;
            this.kissLookUpEdit10.Properties.ShowHeader = false;
            this.kissLookUpEdit10.Size = new System.Drawing.Size(270, 24);
            this.kissLookUpEdit10.TabIndex = 20;
            //
            // CtlDemographieH
            //
            this.ActiveSQLQuery = this.qryBaPerson;

            this.Controls.Add(this.panel1);
            this.Controls.Add(this.xTabControl1);
            this.Name = "CtlDemographieH";
            this.Size = new System.Drawing.Size(719, 620);
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            this.xTabControl1.ResumeLayout(false);
            this.tabPersonalien.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblCAusweis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEntscheid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpCAusweisDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErteilungVA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit12.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpVersichertennummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editInCHSeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editInCHSeitGeburt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit34.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel74)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissCheckEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissCheckEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAuslaenderStatusGueltigBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpSterbeDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpGeburtstag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAHVNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboReligion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboReligion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAuslaenderStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAuslaenderStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGeschlecht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboZivilstand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboZivilstand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editHeimatort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNationalitaet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNationalitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit9.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit8.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit7.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFruehererName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            this.tabAdressen.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnInstitution.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAufenthaltAdr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editZuzugKantonLandCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editZuzugKantonLandCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit10.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit11.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editOrtZuzugKanton.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editZuzugKantonKanton.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPLZZuzugKanton.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editLandZuzug.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editLandZuzug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editOrtUnterstuetzung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKantonUnterstützung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPLZUnterstuetzung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryWohnsitzAdr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissDateEdit7.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editOrtWegzug.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit13.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKantonWegzug.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPLZWegzug.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editOrtZuzug.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKantonZuzug.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPLZZuzug.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAufenthaltsOrtOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAufenthaltsortLand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAufenthaltsortLand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKantonAufenthalt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAufenthaltsOrtPLZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAufenthaltsOrtPosfach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAufenthaltsOrtNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit22.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStrasseAufenthaltsOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editOrtWohnsitz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWohnungsGroesse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWohnungsGroesse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWohnStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWohnStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editLandWohnsitz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editLandWohnsitz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKantonWohnsitz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPLZWohnsitz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPostfachWohnsitz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editNummerWohnsitz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editZusatzWohnsitz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStrasseWohnsitz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit10.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit10)).EndInit();
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
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region EventHandlers

        private void cboNationalitaet_EditValueChanged(object sender, System.EventArgs e)
        {
            if (cboNationalitaet.EditValue != DBNull.Value && cboNationalitaet.EditValue != null)
            {
                if (Convert.ToInt32(cboNationalitaet.EditValue) == Session.BaLandCodeSchweiz)
                {
                    ((IKissBindableEdit)this.cboAuslaenderStatus).AllowEdit(false);
                    ((IKissBindableEdit)this.dtpAuslaenderStatusGueltigBis).AllowEdit(false);
                    ((IKissBindableEdit)this.editHeimatort).AllowEdit(true);
                }
                else
                {
                    ((IKissBindableEdit)this.cboAuslaenderStatus).AllowEdit(true);
                    ((IKissBindableEdit)this.dtpAuslaenderStatusGueltigBis).AllowEdit(true);
                    ((IKissBindableEdit)this.editHeimatort).AllowEdit(false);
                }

                this.editHeimatort.Refresh();
            }
        }

        private void xTabControl1_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string FieldName)
        {
            switch (FieldName.ToUpper())
            {
                case "ADRESSATID":
                case "BAPERSONID":
                    return qryBaPerson["BaPersonID"];
            }

            return base.GetContextValue(FieldName);
        }

        public void Init(string TitleName, Image TitleImage, int FTPersonID, bool IsFallTraeger)
        {
            this.FTPersonID = FTPersonID;
            this.picTitel.Image = TitleImage;

            xTabControl1.SelectedTabIndex = 0;
        }

        public void SetVersion(int BaPersonID, int VerID)
        {
            this.BaPersonID = BaPersonID;
            this.VerID = VerID;

            //Personalien
            qryBaPerson.Fill(@"
                SELECT TOP 1
                       PRS.*,
                       Heimatort = HEI.Name + ISNULL(' ' + HEI.Kanton, '')
                FROM dbo.Hist_BaPerson     PRS WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.BaGemeinde HEI WITH (READUNCOMMITTED) ON HEI.BaGemeindeID = PRS.HeimatgemeindeBaGemeindeID
                WHERE PRS.BaPersonID = {0}
                  AND PRS.VerID <= {1}
                ORDER BY PRS.VerID DESC;", BaPersonID, VerID);

            DisplayWohnsituation();
        }

        #endregion

        #region Internal Methods

        protected internal void DisplayWohnsituation()
        {
            // Wohnsitz
            qryWohnsitzAdr.Fill(@"
                SELECT TOP 1
                       *
                FROM dbo.Hist_BaAdresse WITH (READUNCOMMITTED)
                WHERE BaPersonID = {0}
                  AND VerID <= {1}
                  AND AdresseCode = 1
                ORDER BY VerID DESC", qryBaPerson["BaPersonID"], VerID);

            // Aufenthaltsort
            qryAufenthaltAdr.Fill(@"
                SELECT TOP 1
                       ADR.*,
                       PlatzierungInst = INS.Name
                FROM dbo.Hist_BaAdresse       ADR WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.BaInstitution INS ON INS.BaInstitutionID = ADR.PlatzierungInstID
                WHERE ADR.BaPersonID = {0}
                  AND ADR.VerID <= {1}
                  AND ADR.AdresseCode = 3
                ORDER BY VerID DESC", qryBaPerson["BaPersonID"], VerID);
        }

        #endregion

        #endregion
    }
}