using System;
using System.Drawing;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
	/// <summary>
	/// Summary description for CtlKaProzess.
	/// </summary>
	public class CtlKaProzess : KissUserControl
	{
        private int BaPersonID = 0;
        private KiSS4.Gui.KissButton btnReopen;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissDateEdit datAbschluss;
        private KiSS4.Gui.KissDateEdit datEroeffnung;
        private KiSS4.Gui.KissLookUpEdit ddlAbschlussGrundCode;
        private KiSS4.Gui.KissLookUpEdit ddlAuftrag;
        private KiSS4.Gui.KissLookUpEdit ddlGemeinde;
        private KiSS4.Gui.KissTextEdit edtSAR;
        private int FaLeistungID = 0;
        private KiSS4.Gui.KissLabel lblAbschluss;
        private KiSS4.Gui.KissLabel lblAbschlussDat;
        private KiSS4.Gui.KissLabel lblAuftrag;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblEroeffDat;
        private KiSS4.Gui.KissLabel lblEroeffung;
        private KiSS4.Gui.KissLabel lblGrund;
        private KiSS4.Gui.KissLabel lblSar;
        private System.Windows.Forms.Label lblTitel;
        private KiSS4.Gui.KissLabel lblZustGemeinde;
        private KiSS4.Gui.KissRTFEdit memBemerkung;
        private System.Windows.Forms.PictureBox picTitle;
        private KiSS4.DB.SqlQuery qryFall;
		public CtlKaProzess()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

        public void Init(string TitleName, Image TitleImage, int FaLeistungID, int BaPersonID)
        {
            this.lblTitel.Text = TitleName;
            this.picTitle.Image = TitleImage;
            this.FaLeistungID = FaLeistungID;
            this.BaPersonID = BaPersonID;

            qryFall.Fill(@"
				select	FAL.*,
						SAR = USR.LastName + isnull(', ' + USR.FirstName,''),
						ARC.FaLeistungArchivID 
				from	FaLeistung FAL 
						inner join XUser USR on USR.UserID = FAL.UserID 
						left  join FaLeistungArchiv ARC ON ARC.FaLeistungID = FAL.FaLeistungID and
													   ARC.CheckOut is null
				where	FAL.FaLeistungID = {0}",
                FaLeistungID);

            //			string LOVName = null;

            /// TODO: Change reason to KA!
            if (!DBUtil.IsEmpty(qryFall["FaProzessCode"]))
            {
                //				switch ((int)qryFall["FaProzessCode"])
                //				{
                //					case 701: LOVName = "VmMassnahmeAbschlussgrund"; break;
                //					case 702: LOVName = "VmVaterschaftAbschlussgrund"; break;
                //					case 703: LOVName = "VmErbschaftAbschlussgrund"; break;
                //					case 704: LOVName = "VmPflegekindAbschlussgrund"; break;
                //					case 705:
                //						lblAuftrag.Visible = true;
                //						ddlAuftrag.Visible = true;
                //						LOVName = "VmAuftragAbschlussgrund";
                //						break;
                //				}
                //				if ((int)DBUtil.ExecuteScalarSQL("select count(*) from XLOV where LOVName = {0}",LOVName) > 0)
                //					ddlAbschlussGrundCode.LOVName = LOVName;
                //				else
                ddlAbschlussGrundCode.LOVName = "Abschlussgrund";

            }

            SetEditMode();
        }

        public override bool OnSaveData()
        {
            bool ret = qryFall.Post();
            SetEditMode();
            return ret;
        }

        /// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaProzess));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.ddlGemeinde = new KiSS4.Gui.KissLookUpEdit();
            this.qryFall = new KiSS4.DB.SqlQuery();
            this.lblZustGemeinde = new KiSS4.Gui.KissLabel();
            this.lblAuftrag = new KiSS4.Gui.KissLabel();
            this.ddlAuftrag = new KiSS4.Gui.KissLookUpEdit();
            this.btnReopen = new KiSS4.Gui.KissButton();
            this.lblSar = new KiSS4.Gui.KissLabel();
            this.memBemerkung = new KiSS4.Gui.KissRTFEdit();
            this.edtSAR = new KiSS4.Gui.KissTextEdit();
            this.lblAbschlussDat = new KiSS4.Gui.KissLabel();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.lblTitel = new System.Windows.Forms.Label();
            this.lblAbschluss = new KiSS4.Gui.KissLabel();
            this.lblEroeffung = new KiSS4.Gui.KissLabel();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.lblGrund = new KiSS4.Gui.KissLabel();
            this.ddlAbschlussGrundCode = new KiSS4.Gui.KissLookUpEdit();
            this.datAbschluss = new KiSS4.Gui.KissDateEdit();
            this.datEroeffnung = new KiSS4.Gui.KissDateEdit();
            this.lblEroeffDat = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ddlGemeinde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlGemeinde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustGemeinde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuftrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAuftrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAuftrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSAR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussDat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschluss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAbschlussGrundCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAbschlussGrundCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datAbschluss.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datEroeffnung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffDat)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlGemeinde
            // 
            this.ddlGemeinde.DataMember = "GemeindeCode";
            this.ddlGemeinde.DataSource = this.qryFall;
            this.ddlGemeinde.Location = new System.Drawing.Point(90, 430);
            this.ddlGemeinde.LOVFilter = "(Value3 IS NULL OR \',\' + Value3 + \',\' LIKE \'%,K,%\')";
            this.ddlGemeinde.LOVFilterWhereAppend = true;
            this.ddlGemeinde.LOVName = "GemeindeSozialdienst";
            this.ddlGemeinde.Name = "ddlGemeinde";
            this.ddlGemeinde.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlGemeinde.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlGemeinde.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlGemeinde.Properties.Appearance.Options.UseBackColor = true;
            this.ddlGemeinde.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlGemeinde.Properties.Appearance.Options.UseFont = true;
            this.ddlGemeinde.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlGemeinde.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlGemeinde.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlGemeinde.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlGemeinde.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.ddlGemeinde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.ddlGemeinde.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlGemeinde.Properties.NullText = "";
            this.ddlGemeinde.Properties.ShowFooter = false;
            this.ddlGemeinde.Properties.ShowHeader = false;
            this.ddlGemeinde.Size = new System.Drawing.Size(280, 24);
            this.ddlGemeinde.TabIndex = 521;
            // 
            // qryFall
            // 
            this.qryFall.CanUpdate = true;
            this.qryFall.HostControl = this;
            this.qryFall.IsIdentityInsert = false;
            this.qryFall.TableName = "FaLeistung";
            this.qryFall.AfterPost += new System.EventHandler(this.qryFall_AfterPost);
            this.qryFall.BeforePost += new System.EventHandler(this.qryFall_BeforePost);
            // 
            // lblZustGemeinde
            // 
            this.lblZustGemeinde.ForeColor = System.Drawing.Color.Black;
            this.lblZustGemeinde.Location = new System.Drawing.Point(5, 430);
            this.lblZustGemeinde.Name = "lblZustGemeinde";
            this.lblZustGemeinde.Size = new System.Drawing.Size(126, 24);
            this.lblZustGemeinde.TabIndex = 522;
            this.lblZustGemeinde.Text = "zust. Gemeinde";
            // 
            // lblAuftrag
            // 
            this.lblAuftrag.Location = new System.Drawing.Point(205, 80);
            this.lblAuftrag.Name = "lblAuftrag";
            this.lblAuftrag.Size = new System.Drawing.Size(40, 24);
            this.lblAuftrag.TabIndex = 520;
            this.lblAuftrag.Text = "Auftrag";
            this.lblAuftrag.Visible = false;
            // 
            // ddlAuftrag
            // 
            this.ddlAuftrag.DataMember = "VmAuftragCode";
            this.ddlAuftrag.DataSource = this.qryFall;
            this.ddlAuftrag.Location = new System.Drawing.Point(260, 80);
            this.ddlAuftrag.LOVName = "VmAuftrag";
            this.ddlAuftrag.Name = "ddlAuftrag";
            this.ddlAuftrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlAuftrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlAuftrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlAuftrag.Properties.Appearance.Options.UseBackColor = true;
            this.ddlAuftrag.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlAuftrag.Properties.Appearance.Options.UseFont = true;
            this.ddlAuftrag.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlAuftrag.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlAuftrag.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlAuftrag.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlAuftrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.ddlAuftrag.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.ddlAuftrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlAuftrag.Properties.NullText = "";
            this.ddlAuftrag.Properties.ShowFooter = false;
            this.ddlAuftrag.Properties.ShowHeader = false;
            this.ddlAuftrag.Size = new System.Drawing.Size(256, 24);
            this.ddlAuftrag.TabIndex = 506;
            this.ddlAuftrag.Visible = false;
            // 
            // btnReopen
            // 
            this.btnReopen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReopen.Location = new System.Drawing.Point(90, 400);
            this.btnReopen.Name = "btnReopen";
            this.btnReopen.Size = new System.Drawing.Size(90, 24);
            this.btnReopen.TabIndex = 511;
            this.btnReopen.Text = "wieder öffnen";
            this.btnReopen.UseVisualStyleBackColor = false;
            this.btnReopen.Click += new System.EventHandler(this.btnReopen_Click);
            // 
            // lblSar
            // 
            this.lblSar.Location = new System.Drawing.Point(5, 110);
            this.lblSar.Name = "lblSar";
            this.lblSar.Size = new System.Drawing.Size(70, 24);
            this.lblSar.TabIndex = 519;
            this.lblSar.Text = "SAR";
            // 
            // memBemerkung
            // 
            this.memBemerkung.BackColor = System.Drawing.Color.White;
            this.memBemerkung.DataMember = "Bemerkung";
            this.memBemerkung.DataSource = this.qryFall;
            this.memBemerkung.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memBemerkung.Location = new System.Drawing.Point(90, 260);
            this.memBemerkung.Name = "memBemerkung";
            this.memBemerkung.Size = new System.Drawing.Size(432, 134);
            this.memBemerkung.TabIndex = 510;
            // 
            // edtSAR
            // 
            this.edtSAR.DataMember = "SAR";
            this.edtSAR.DataSource = this.qryFall;
            this.edtSAR.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSAR.Location = new System.Drawing.Point(90, 110);
            this.edtSAR.Name = "edtSAR";
            this.edtSAR.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSAR.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSAR.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSAR.Properties.Appearance.Options.UseBackColor = true;
            this.edtSAR.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSAR.Properties.Appearance.Options.UseFont = true;
            this.edtSAR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSAR.Properties.ReadOnly = true;
            this.edtSAR.Size = new System.Drawing.Size(432, 24);
            this.edtSAR.TabIndex = 507;
            // 
            // lblAbschlussDat
            // 
            this.lblAbschlussDat.Location = new System.Drawing.Point(5, 200);
            this.lblAbschlussDat.Name = "lblAbschlussDat";
            this.lblAbschlussDat.Size = new System.Drawing.Size(70, 24);
            this.lblAbschlussDat.TabIndex = 518;
            this.lblAbschlussDat.Text = "Datum";
            // 
            // picTitle
            // 
            this.picTitle.Image = ((System.Drawing.Image)(resources.GetObject("picTitle.Image")));
            this.picTitle.Location = new System.Drawing.Point(10, 15);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(25, 20);
            this.picTitle.TabIndex = 516;
            this.picTitle.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.Black;
            this.lblTitel.Location = new System.Drawing.Point(35, 15);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(31, 15);
            this.lblTitel.TabIndex = 517;
            this.lblTitel.Text = "Titel";
            // 
            // lblAbschluss
            // 
            this.lblAbschluss.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblAbschluss.Location = new System.Drawing.Point(90, 175);
            this.lblAbschluss.Name = "lblAbschluss";
            this.lblAbschluss.Size = new System.Drawing.Size(100, 16);
            this.lblAbschluss.TabIndex = 515;
            this.lblAbschluss.Text = "Abschluss";
            // 
            // lblEroeffung
            // 
            this.lblEroeffung.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblEroeffung.Location = new System.Drawing.Point(90, 55);
            this.lblEroeffung.Name = "lblEroeffung";
            this.lblEroeffung.Size = new System.Drawing.Size(100, 16);
            this.lblEroeffung.TabIndex = 514;
            this.lblEroeffung.Text = "Eröffnung";
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Location = new System.Drawing.Point(5, 260);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(66, 24);
            this.lblBemerkung.TabIndex = 513;
            this.lblBemerkung.Text = "Bemerkung";
            // 
            // lblGrund
            // 
            this.lblGrund.Location = new System.Drawing.Point(5, 230);
            this.lblGrund.Name = "lblGrund";
            this.lblGrund.Size = new System.Drawing.Size(70, 24);
            this.lblGrund.TabIndex = 512;
            this.lblGrund.Text = "Grund";
            // 
            // ddlAbschlussGrundCode
            // 
            this.ddlAbschlussGrundCode.DataMember = "AbschlussGrundCode";
            this.ddlAbschlussGrundCode.DataSource = this.qryFall;
            this.ddlAbschlussGrundCode.Location = new System.Drawing.Point(90, 230);
            this.ddlAbschlussGrundCode.Name = "ddlAbschlussGrundCode";
            this.ddlAbschlussGrundCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlAbschlussGrundCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlAbschlussGrundCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlAbschlussGrundCode.Properties.Appearance.Options.UseBackColor = true;
            this.ddlAbschlussGrundCode.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlAbschlussGrundCode.Properties.Appearance.Options.UseFont = true;
            this.ddlAbschlussGrundCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlAbschlussGrundCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlAbschlussGrundCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlAbschlussGrundCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlAbschlussGrundCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.ddlAbschlussGrundCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.ddlAbschlussGrundCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlAbschlussGrundCode.Properties.NullText = "";
            this.ddlAbschlussGrundCode.Properties.ShowFooter = false;
            this.ddlAbschlussGrundCode.Properties.ShowHeader = false;
            this.ddlAbschlussGrundCode.Size = new System.Drawing.Size(432, 24);
            this.ddlAbschlussGrundCode.TabIndex = 509;
            // 
            // datAbschluss
            // 
            this.datAbschluss.DataMember = "DatumBis";
            this.datAbschluss.DataSource = this.qryFall;
            this.datAbschluss.EditValue = null;
            this.datAbschluss.Location = new System.Drawing.Point(90, 200);
            this.datAbschluss.Name = "datAbschluss";
            this.datAbschluss.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datAbschluss.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.datAbschluss.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datAbschluss.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datAbschluss.Properties.Appearance.Options.UseBackColor = true;
            this.datAbschluss.Properties.Appearance.Options.UseBorderColor = true;
            this.datAbschluss.Properties.Appearance.Options.UseFont = true;
            this.datAbschluss.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.datAbschluss.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datAbschluss.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.datAbschluss.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datAbschluss.Properties.ShowToday = false;
            this.datAbschluss.Size = new System.Drawing.Size(89, 24);
            this.datAbschluss.TabIndex = 508;
            // 
            // datEroeffnung
            // 
            this.datEroeffnung.DataMember = "DatumVon";
            this.datEroeffnung.DataSource = this.qryFall;
            this.datEroeffnung.EditValue = null;
            this.datEroeffnung.Location = new System.Drawing.Point(90, 80);
            this.datEroeffnung.Name = "datEroeffnung";
            this.datEroeffnung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datEroeffnung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.datEroeffnung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datEroeffnung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datEroeffnung.Properties.Appearance.Options.UseBackColor = true;
            this.datEroeffnung.Properties.Appearance.Options.UseBorderColor = true;
            this.datEroeffnung.Properties.Appearance.Options.UseFont = true;
            this.datEroeffnung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.datEroeffnung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datEroeffnung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.datEroeffnung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datEroeffnung.Properties.ShowToday = false;
            this.datEroeffnung.Size = new System.Drawing.Size(89, 24);
            this.datEroeffnung.TabIndex = 504;
            // 
            // lblEroeffDat
            // 
            this.lblEroeffDat.Location = new System.Drawing.Point(5, 80);
            this.lblEroeffDat.Name = "lblEroeffDat";
            this.lblEroeffDat.Size = new System.Drawing.Size(70, 24);
            this.lblEroeffDat.TabIndex = 505;
            this.lblEroeffDat.Text = "Datum";
            // 
            // CtlKaProzess
            // 
            this.Controls.Add(this.ddlGemeinde);
            this.Controls.Add(this.lblZustGemeinde);
            this.Controls.Add(this.lblAuftrag);
            this.Controls.Add(this.ddlAuftrag);
            this.Controls.Add(this.btnReopen);
            this.Controls.Add(this.lblSar);
            this.Controls.Add(this.memBemerkung);
            this.Controls.Add(this.edtSAR);
            this.Controls.Add(this.lblAbschlussDat);
            this.Controls.Add(this.picTitle);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.lblAbschluss);
            this.Controls.Add(this.lblEroeffung);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.lblGrund);
            this.Controls.Add(this.ddlAbschlussGrundCode);
            this.Controls.Add(this.datAbschluss);
            this.Controls.Add(this.datEroeffnung);
            this.Controls.Add(this.lblEroeffDat);
            this.Name = "CtlKaProzess";
            this.Size = new System.Drawing.Size(680, 500);
            ((System.ComponentModel.ISupportInitialize)(this.ddlGemeinde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlGemeinde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustGemeinde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuftrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAuftrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAuftrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSAR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussDat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschluss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAbschlussGrundCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAbschlussGrundCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datAbschluss.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datEroeffnung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffDat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
        private void btnReopen_Click(object sender, System.EventArgs e)
        {
            if (KissMsg.ShowQuestion("CtlKaProzess", "FallWiederEroeffnen", "Soll der geschlossene Fall wieder geöffnet werden ?"))
            {
                qryFall.CanUpdate = true;
                qryFall["DatumBis"] = DBNull.Value;
                qryFall.Post();
            }
        }

        private bool CloseAllgemein()
        {
            bool rslt = false;

            rslt = Convert.ToInt32(
                DBUtil.ExecuteScalarSQL(@"select count(*) from FaLeistung
										  where BaPersonID = {0}										  
										  and   ModulID = 7
										  and   FaProzessCode BETWEEN 701 AND 720
										  and   DatumBis is null",
                BaPersonID)
                ) == 0;

            return rslt;
        }

        private void qryFall_AfterPost(object sender, System.EventArgs e)
        {
            if (CloseAllgemein())
            {
                DBUtil.ExecSQL(@"UPDATE FaLeistung SET DatumBis = GetDate(), Modifier = {1}, Modified = GetDate() WHERE BaPersonID = {0} AND ModulID = 7 AND FaProzessCode = 700", BaPersonID, DBUtil.GetDBRowCreatorModifier());
            }
            else
            {
                DBUtil.ExecSQL(@"UPDATE FaLeistung SET DatumBis = null, Modifier = {1}, Modified = GetDate() WHERE BaPersonID = {0} AND ModulID = 7 AND FaProzessCode = 700", BaPersonID, DBUtil.GetDBRowCreatorModifier());
            }

            //this.GetKissMainForm().TreeFallRefresh();
            //FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            SetEditMode();

            //this.GetKissMainForm().TreeFallRefresh();
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
        }

        private void qryFall_BeforePost(object sender, System.EventArgs e)
        {
            DBUtil.CheckNotNullField(datEroeffnung, "Eröffnungsdatum");

            //falls DatumBis erfasst, muss es grösser sein als DatumVon
            if (!DBUtil.IsEmpty(qryFall["DatumBis"]) && (DateTime)qryFall["DatumVon"] > (DateTime)qryFall["DatumBis"])
                throw new KissInfoException("Das Eröffnungsdatum darf nicht nach dem Abschlussdatum sein!");

            //prüfen, ob DatumVon in eine andere Fallperiode fällt
            int Count = (int)DBUtil.ExecuteScalarSQL(@"
				select	count(*) 
				from	FaLeistung A
						inner join FaLeistung B on  B.BaPersonID = A.BaPersonID and
												B.ModulID = 7 and
												B.FaProzessCode = A.FaProzessCode and
												B.FaLeistungID <> A.FaLeistungID and
												{0} between B.DatumVon and B.DatumBis
				where	A.FaLeistungID = {1}",
                qryFall["DatumVon"],
                FaLeistungID);

            if (Count > 0)
                throw new KissInfoException("Das Eröffnungsdatum darf nicht mit einem anderen Fall überschneiden!");
        }

        private void SetEditMode()
		{
			if (qryFall.Count == 0) return;

			//nur owner oder admin darf abschliessen
			if (Session.User.IsUserAdmin || (int) qryFall["UserID"] == Session.User.UserID)
			{
				bool open = DBUtil.IsEmpty(qryFall["DatumBis"]);
				bool archived = !DBUtil.IsEmpty(qryFall["FaLeistungArchivID"]);

				qryFall.EnableBoundFields(qryFall.CanUpdate && open);
				btnReopen.Visible = !open && !archived;
			}
			else
			{
				qryFall.EnableBoundFields(false);
				btnReopen.Visible = false;
			}
		}
	}
}
