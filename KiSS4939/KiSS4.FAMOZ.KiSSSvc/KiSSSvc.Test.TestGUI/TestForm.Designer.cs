namespace KiSSToPSCDServerComponent_TestGUI
{
    partial class TestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			  this.label14 = new System.Windows.Forms.Label();
			  this.edtBankID = new System.Windows.Forms.TextBox();
			  this.label9 = new System.Windows.Forms.Label();
			  this.edtExternalKey = new System.Windows.Forms.TextBox();
			  this.btnWOPrecedingNulls = new System.Windows.Forms.Button();
			  this.btnSetSettings = new System.Windows.Forms.Button();
			  this.btnUmlaute = new System.Windows.Forms.Button();
			  this.label8 = new System.Windows.Forms.Label();
			  this.label10 = new System.Windows.Forms.Label();
			  this.label11 = new System.Windows.Forms.Label();
			  this.label12 = new System.Windows.Forms.Label();
			  this.label13 = new System.Windows.Forms.Label();
			  this.lblBusy = new System.Windows.Forms.Label();
			  this.btnNormal = new System.Windows.Forms.Button();
			  this.txtAnswer = new System.Windows.Forms.TextBox();
			  this.txtServiceLocation = new System.Windows.Forms.TextBox();
			  this.txtUser = new System.Windows.Forms.TextBox();
			  this.txtPassword = new System.Windows.Forms.TextBox();
			  this.txtProxy = new System.Windows.Forms.TextBox();
			  this.txtServerUrl = new System.Windows.Forms.TextBox();
			  this.label1 = new System.Windows.Forms.Label();
			  this.label2 = new System.Windows.Forms.Label();
			  this.edtUseMock = new System.Windows.Forms.CheckBox();
			  this.button1 = new System.Windows.Forms.Button();
			  this.label3 = new System.Windows.Forms.Label();
			  this.edtLEKey = new System.Windows.Forms.TextBox();
			  this.label4 = new System.Windows.Forms.Label();
			  this.edtIBAN = new System.Windows.Forms.TextBox();
			  this.button2 = new System.Windows.Forms.Button();
			  this.edtNotificationLocation = new System.Windows.Forms.TextBox();
			  this.button3 = new System.Windows.Forms.Button();
			  this.label5 = new System.Windows.Forms.Label();
			  this.edtBelegNr = new System.Windows.Forms.TextBox();
			  this.label6 = new System.Windows.Forms.Label();
			  this.edtFiKey = new System.Windows.Forms.TextBox();
			  this.label7 = new System.Windows.Forms.Label();
			  this.edtAccount = new System.Windows.Forms.TextBox();
			  this.label15 = new System.Windows.Forms.Label();
			  this.edtContract = new System.Windows.Forms.TextBox();
			  this.btnKontoabfrage = new System.Windows.Forms.Button();
			  this.btnTestBpWs = new System.Windows.Forms.Button();
			  this.btnTestSettlement = new System.Windows.Forms.Button();
			  this.edtSettlementLocation = new System.Windows.Forms.TextBox();
			  this.btnTestSettlementFetcher = new System.Windows.Forms.Button();
			  this.gridView = new System.Windows.Forms.DataGridView();
			  ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			  this.SuspendLayout();
			  // 
			  // label14
			  // 
			  this.label14.Location = new System.Drawing.Point(12, 204);
			  this.label14.Name = "label14";
			  this.label14.Size = new System.Drawing.Size(80, 16);
			  this.label14.TabIndex = 16;
			  this.label14.Text = "Bank-ID:";
			  // 
			  // edtBankID
			  // 
			  this.edtBankID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							  | System.Windows.Forms.AnchorStyles.Right)));
			  this.edtBankID.Location = new System.Drawing.Point(98, 201);
			  this.edtBankID.Name = "edtBankID";
			  this.edtBankID.Size = new System.Drawing.Size(950, 20);
			  this.edtBankID.TabIndex = 5;
			  this.edtBankID.Text = "230";
			  // 
			  // label9
			  // 
			  this.label9.Location = new System.Drawing.Point(14, 178);
			  this.label9.Name = "label9";
			  this.label9.Size = new System.Drawing.Size(80, 16);
			  this.label9.TabIndex = 15;
			  this.label9.Text = "Externer Key:";
			  // 
			  // edtExternalKey
			  // 
			  this.edtExternalKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							  | System.Windows.Forms.AnchorStyles.Right)));
			  this.edtExternalKey.Location = new System.Drawing.Point(98, 175);
			  this.edtExternalKey.Name = "edtExternalKey";
			  this.edtExternalKey.Size = new System.Drawing.Size(950, 20);
			  this.edtExternalKey.TabIndex = 4;
			  this.edtExternalKey.Text = "0000100019";
			  // 
			  // btnWOPrecedingNulls
			  // 
			  this.btnWOPrecedingNulls.Location = new System.Drawing.Point(427, 390);
			  this.btnWOPrecedingNulls.Name = "btnWOPrecedingNulls";
			  this.btnWOPrecedingNulls.Size = new System.Drawing.Size(160, 23);
			  this.btnWOPrecedingNulls.TabIndex = 9;
			  this.btnWOPrecedingNulls.Text = "Ohne aufgefüllte Nullen";
			  this.btnWOPrecedingNulls.Click += new System.EventHandler(this.btnTest_Click);
			  // 
			  // btnSetSettings
			  // 
			  this.btnSetSettings.Location = new System.Drawing.Point(10, 390);
			  this.btnSetSettings.Name = "btnSetSettings";
			  this.btnSetSettings.Size = new System.Drawing.Size(75, 23);
			  this.btnSetSettings.TabIndex = 6;
			  this.btnSetSettings.Text = "Set Settings";
			  this.btnSetSettings.Click += new System.EventHandler(this.btnSetSettings_Click);
			  // 
			  // btnUmlaute
			  // 
			  this.btnUmlaute.Location = new System.Drawing.Point(259, 390);
			  this.btnUmlaute.Name = "btnUmlaute";
			  this.btnUmlaute.Size = new System.Drawing.Size(160, 23);
			  this.btnUmlaute.TabIndex = 8;
			  this.btnUmlaute.Text = "Umlaute";
			  this.btnUmlaute.Click += new System.EventHandler(this.btnTest_Click);
			  // 
			  // label8
			  // 
			  this.label8.Location = new System.Drawing.Point(14, 150);
			  this.label8.Name = "label8";
			  this.label8.Size = new System.Drawing.Size(86, 16);
			  this.label8.TabIndex = 14;
			  this.label8.Text = "Location:";
			  // 
			  // label10
			  // 
			  this.label10.Location = new System.Drawing.Point(272, 463);
			  this.label10.Name = "label10";
			  this.label10.Size = new System.Drawing.Size(48, 16);
			  this.label10.TabIndex = 17;
			  this.label10.Text = "Antwort:";
			  // 
			  // label11
			  // 
			  this.label11.Location = new System.Drawing.Point(14, 43);
			  this.label11.Name = "label11";
			  this.label11.Size = new System.Drawing.Size(78, 16);
			  this.label11.TabIndex = 12;
			  this.label11.Text = "Password:";
			  // 
			  // label12
			  // 
			  this.label12.Location = new System.Drawing.Point(14, 15);
			  this.label12.Name = "label12";
			  this.label12.Size = new System.Drawing.Size(48, 16);
			  this.label12.TabIndex = 11;
			  this.label12.Text = "User:";
			  // 
			  // label13
			  // 
			  this.label13.Location = new System.Drawing.Point(14, 71);
			  this.label13.Name = "label13";
			  this.label13.Size = new System.Drawing.Size(78, 16);
			  this.label13.TabIndex = 13;
			  this.label13.Text = "Proxy:";
			  // 
			  // lblBusy
			  // 
			  this.lblBusy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			  this.lblBusy.BackColor = System.Drawing.Color.LightCoral;
			  this.lblBusy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			  this.lblBusy.Location = new System.Drawing.Point(8, 601);
			  this.lblBusy.Name = "lblBusy";
			  this.lblBusy.Size = new System.Drawing.Size(57, 23);
			  this.lblBusy.TabIndex = 18;
			  this.lblBusy.Text = "Busy";
			  this.lblBusy.Visible = false;
			  // 
			  // btnNormal
			  // 
			  this.btnNormal.Location = new System.Drawing.Point(98, 390);
			  this.btnNormal.Name = "btnNormal";
			  this.btnNormal.Size = new System.Drawing.Size(153, 23);
			  this.btnNormal.TabIndex = 7;
			  this.btnNormal.Text = "Test standard";
			  this.btnNormal.Click += new System.EventHandler(this.btnTest_Click);
			  // 
			  // txtAnswer
			  // 
			  this.txtAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							  | System.Windows.Forms.AnchorStyles.Left)
							  | System.Windows.Forms.AnchorStyles.Right)));
			  this.txtAnswer.Location = new System.Drawing.Point(326, 460);
			  this.txtAnswer.Multiline = true;
			  this.txtAnswer.Name = "txtAnswer";
			  this.txtAnswer.Size = new System.Drawing.Size(722, 146);
			  this.txtAnswer.TabIndex = 10;
			  // 
			  // txtServiceLocation
			  // 
			  this.txtServiceLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							  | System.Windows.Forms.AnchorStyles.Right)));
			  this.txtServiceLocation.Location = new System.Drawing.Point(98, 147);
			  this.txtServiceLocation.Name = "txtServiceLocation";
			  this.txtServiceLocation.Size = new System.Drawing.Size(950, 20);
			  this.txtServiceLocation.TabIndex = 3;
			  this.txtServiceLocation.Text = "/XISOAPAdapter/MessageServlet?channel=:BU_PARTNER_ANLEGEN:CC_SOAP_BU_PARTNER_ANLE" +
					"GEN&version=3.0&Sender.Service=BU_PARTNER_ANLEGEN&Interface=http://STZH^MI_OUT_K" +
					"UNDENDATEN";
			  // 
			  // txtUser
			  // 
			  this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							  | System.Windows.Forms.AnchorStyles.Right)));
			  this.txtUser.Location = new System.Drawing.Point(98, 12);
			  this.txtUser.Name = "txtUser";
			  this.txtUser.Size = new System.Drawing.Size(950, 20);
			  this.txtUser.TabIndex = 0;
			  this.txtUser.Text = "oizcia";
			  // 
			  // txtPassword
			  // 
			  this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							  | System.Windows.Forms.AnchorStyles.Right)));
			  this.txtPassword.Location = new System.Drawing.Point(98, 40);
			  this.txtPassword.Name = "txtPassword";
			  this.txtPassword.PasswordChar = '*';
			  this.txtPassword.Size = new System.Drawing.Size(950, 20);
			  this.txtPassword.TabIndex = 1;
			  this.txtPassword.Text = "monti2001";
			  // 
			  // txtProxy
			  // 
			  this.txtProxy.AcceptsReturn = true;
			  this.txtProxy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							  | System.Windows.Forms.AnchorStyles.Right)));
			  this.txtProxy.Location = new System.Drawing.Point(98, 68);
			  this.txtProxy.Name = "txtProxy";
			  this.txtProxy.Size = new System.Drawing.Size(950, 20);
			  this.txtProxy.TabIndex = 2;
			  this.txtProxy.Text = "localhost:81";
			  // 
			  // txtServerUrl
			  // 
			  this.txtServerUrl.AcceptsReturn = true;
			  this.txtServerUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							  | System.Windows.Forms.AnchorStyles.Right)));
			  this.txtServerUrl.Location = new System.Drawing.Point(98, 121);
			  this.txtServerUrl.Name = "txtServerUrl";
			  this.txtServerUrl.Size = new System.Drawing.Size(950, 20);
			  this.txtServerUrl.TabIndex = 19;
			  this.txtServerUrl.Text = "http://szhm2179.stzh.ch:8001";
			  // 
			  // label1
			  // 
			  this.label1.Location = new System.Drawing.Point(14, 124);
			  this.label1.Name = "label1";
			  this.label1.Size = new System.Drawing.Size(78, 16);
			  this.label1.TabIndex = 20;
			  this.label1.Text = "ServerURL:";
			  // 
			  // label2
			  // 
			  this.label2.Location = new System.Drawing.Point(14, 98);
			  this.label2.Name = "label2";
			  this.label2.Size = new System.Drawing.Size(78, 16);
			  this.label2.TabIndex = 22;
			  this.label2.Text = "Use Mock?";
			  // 
			  // edtUseMock
			  // 
			  this.edtUseMock.AutoSize = true;
			  this.edtUseMock.Location = new System.Drawing.Point(98, 96);
			  this.edtUseMock.Name = "edtUseMock";
			  this.edtUseMock.Size = new System.Drawing.Size(15, 14);
			  this.edtUseMock.TabIndex = 23;
			  this.edtUseMock.UseVisualStyleBackColor = true;
			  this.edtUseMock.CheckedChanged += new System.EventHandler(this.edtUseMock_CheckedChanged);
			  // 
			  // button1
			  // 
			  this.button1.Location = new System.Drawing.Point(593, 390);
			  this.button1.Name = "button1";
			  this.button1.Size = new System.Drawing.Size(153, 23);
			  this.button1.TabIndex = 7;
			  this.button1.Text = "Test BudgetData";
			  this.button1.Click += new System.EventHandler(this.button1_Click);
			  // 
			  // label3
			  // 
			  this.label3.Location = new System.Drawing.Point(12, 230);
			  this.label3.Name = "label3";
			  this.label3.Size = new System.Drawing.Size(80, 16);
			  this.label3.TabIndex = 16;
			  this.label3.Text = "LE-Key:";
			  // 
			  // edtLEKey
			  // 
			  this.edtLEKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							  | System.Windows.Forms.AnchorStyles.Right)));
			  this.edtLEKey.Location = new System.Drawing.Point(98, 227);
			  this.edtLEKey.Name = "edtLEKey";
			  this.edtLEKey.Size = new System.Drawing.Size(950, 20);
			  this.edtLEKey.TabIndex = 5;
			  this.edtLEKey.Text = "00000000000000010023";
			  // 
			  // label4
			  // 
			  this.label4.Location = new System.Drawing.Point(12, 256);
			  this.label4.Name = "label4";
			  this.label4.Size = new System.Drawing.Size(80, 16);
			  this.label4.TabIndex = 16;
			  this.label4.Text = "IBAN";
			  // 
			  // edtIBAN
			  // 
			  this.edtIBAN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							  | System.Windows.Forms.AnchorStyles.Right)));
			  this.edtIBAN.Location = new System.Drawing.Point(98, 253);
			  this.edtIBAN.Name = "edtIBAN";
			  this.edtIBAN.Size = new System.Drawing.Size(950, 20);
			  this.edtIBAN.TabIndex = 5;
			  this.edtIBAN.Text = "CH9508394001165438149";
			  // 
			  // button2
			  // 
			  this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			  this.button2.Location = new System.Drawing.Point(112, 609);
			  this.button2.Name = "button2";
			  this.button2.Size = new System.Drawing.Size(118, 23);
			  this.button2.TabIndex = 7;
			  this.button2.Text = "Test Notification";
			  this.button2.Click += new System.EventHandler(this.button2_Click);
			  // 
			  // edtNotificationLocation
			  // 
			  this.edtNotificationLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			  this.edtNotificationLocation.Location = new System.Drawing.Point(236, 611);
			  this.edtNotificationLocation.Name = "edtNotificationLocation";
			  this.edtNotificationLocation.Size = new System.Drawing.Size(230, 20);
			  this.edtNotificationLocation.TabIndex = 24;
			  this.edtNotificationLocation.Text = "http://10.1.100.62/Notification.asmx";
			  // 
			  // button3
			  // 
			  this.button3.Location = new System.Drawing.Point(752, 390);
			  this.button3.Name = "button3";
			  this.button3.Size = new System.Drawing.Size(153, 23);
			  this.button3.TabIndex = 7;
			  this.button3.Text = "Test Buchungsstoff";
			  this.button3.Click += new System.EventHandler(this.button3_Click);
			  // 
			  // label5
			  // 
			  this.label5.Location = new System.Drawing.Point(12, 334);
			  this.label5.Name = "label5";
			  this.label5.Size = new System.Drawing.Size(80, 16);
			  this.label5.TabIndex = 16;
			  this.label5.Text = "BelegNr";
			  // 
			  // edtBelegNr
			  // 
			  this.edtBelegNr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							  | System.Windows.Forms.AnchorStyles.Right)));
			  this.edtBelegNr.Location = new System.Drawing.Point(98, 331);
			  this.edtBelegNr.Name = "edtBelegNr";
			  this.edtBelegNr.Size = new System.Drawing.Size(950, 20);
			  this.edtBelegNr.TabIndex = 5;
			  this.edtBelegNr.Text = "100200";
			  this.edtBelegNr.TextChanged += new System.EventHandler(this.edtBelegNr_TextChanged);
			  // 
			  // label6
			  // 
			  this.label6.Location = new System.Drawing.Point(12, 360);
			  this.label6.Name = "label6";
			  this.label6.Size = new System.Drawing.Size(80, 16);
			  this.label6.TabIndex = 16;
			  this.label6.Text = "FiKey";
			  // 
			  // edtFiKey
			  // 
			  this.edtFiKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							  | System.Windows.Forms.AnchorStyles.Right)));
			  this.edtFiKey.Location = new System.Drawing.Point(98, 357);
			  this.edtFiKey.Name = "edtFiKey";
			  this.edtFiKey.Size = new System.Drawing.Size(950, 20);
			  this.edtFiKey.TabIndex = 5;
			  this.edtFiKey.Text = "100";
			  // 
			  // label7
			  // 
			  this.label7.Location = new System.Drawing.Point(12, 282);
			  this.label7.Name = "label7";
			  this.label7.Size = new System.Drawing.Size(80, 16);
			  this.label7.TabIndex = 16;
			  this.label7.Text = "Account";
			  // 
			  // edtAccount
			  // 
			  this.edtAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							  | System.Windows.Forms.AnchorStyles.Right)));
			  this.edtAccount.Location = new System.Drawing.Point(98, 279);
			  this.edtAccount.Name = "edtAccount";
			  this.edtAccount.Size = new System.Drawing.Size(950, 20);
			  this.edtAccount.TabIndex = 5;
			  this.edtAccount.Text = "100019";
			  // 
			  // label15
			  // 
			  this.label15.Location = new System.Drawing.Point(12, 308);
			  this.label15.Name = "label15";
			  this.label15.Size = new System.Drawing.Size(80, 16);
			  this.label15.TabIndex = 16;
			  this.label15.Text = "Contract";
			  // 
			  // edtContract
			  // 
			  this.edtContract.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							  | System.Windows.Forms.AnchorStyles.Right)));
			  this.edtContract.Location = new System.Drawing.Point(98, 305);
			  this.edtContract.Name = "edtContract";
			  this.edtContract.Size = new System.Drawing.Size(950, 20);
			  this.edtContract.TabIndex = 5;
			  this.edtContract.Text = "10040";
			  // 
			  // btnKontoabfrage
			  // 
			  this.btnKontoabfrage.Location = new System.Drawing.Point(927, 390);
			  this.btnKontoabfrage.Name = "btnKontoabfrage";
			  this.btnKontoabfrage.Size = new System.Drawing.Size(121, 23);
			  this.btnKontoabfrage.TabIndex = 7;
			  this.btnKontoabfrage.Text = "Test Kontoabfrage";
			  this.btnKontoabfrage.Click += new System.EventHandler(this.btnKontoabfrage_Click);
			  // 
			  // btnTestBpWs
			  // 
			  this.btnTestBpWs.Location = new System.Drawing.Point(98, 419);
			  this.btnTestBpWs.Name = "btnTestBpWs";
			  this.btnTestBpWs.Size = new System.Drawing.Size(153, 23);
			  this.btnTestBpWs.TabIndex = 7;
			  this.btnTestBpWs.Text = "Test BusinessPartner WS";
			  this.btnTestBpWs.Click += new System.EventHandler(this.btnTestBpWs_Click);
			  // 
			  // btnTestSettlement
			  // 
			  this.btnTestSettlement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			  this.btnTestSettlement.Location = new System.Drawing.Point(593, 609);
			  this.btnTestSettlement.Name = "btnTestSettlement";
			  this.btnTestSettlement.Size = new System.Drawing.Size(118, 23);
			  this.btnTestSettlement.TabIndex = 7;
			  this.btnTestSettlement.Text = "Test Settlement";
			  this.btnTestSettlement.Click += new System.EventHandler(this.btnTestSettlement_Click);
			  // 
			  // edtSettlementLocation
			  // 
			  this.edtSettlementLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			  this.edtSettlementLocation.Location = new System.Drawing.Point(717, 612);
			  this.edtSettlementLocation.Name = "edtSettlementLocation";
			  this.edtSettlementLocation.Size = new System.Drawing.Size(315, 20);
			  this.edtSettlementLocation.TabIndex = 25;
			  this.edtSettlementLocation.Text = "http://10.1.100.62/SettlementInfoSvc/SettlementInfo.asmx";
			  // 
			  // btnTestSettlementFetcher
			  // 
			  this.btnTestSettlementFetcher.Location = new System.Drawing.Point(259, 418);
			  this.btnTestSettlementFetcher.Name = "btnTestSettlementFetcher";
			  this.btnTestSettlementFetcher.Size = new System.Drawing.Size(160, 23);
			  this.btnTestSettlementFetcher.TabIndex = 26;
			  this.btnTestSettlementFetcher.Text = "Test SettlementFetcher";
			  this.btnTestSettlementFetcher.UseVisualStyleBackColor = true;
			  this.btnTestSettlementFetcher.Click += new System.EventHandler(this.btnTestSettlementFetcher_Click);
			  // 
			  // gridView
			  // 
			  this.gridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							  | System.Windows.Forms.AnchorStyles.Left)));
			  this.gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			  this.gridView.Location = new System.Drawing.Point(9, 481);
			  this.gridView.Name = "gridView";
			  this.gridView.Size = new System.Drawing.Size(311, 109);
			  this.gridView.TabIndex = 27;
			  // 
			  // TestForm
			  // 
			  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			  this.ClientSize = new System.Drawing.Size(1060, 636);
			  this.Controls.Add(this.gridView);
			  this.Controls.Add(this.btnTestSettlementFetcher);
			  this.Controls.Add(this.edtSettlementLocation);
			  this.Controls.Add(this.edtNotificationLocation);
			  this.Controls.Add(this.edtUseMock);
			  this.Controls.Add(this.label2);
			  this.Controls.Add(this.txtServerUrl);
			  this.Controls.Add(this.label1);
			  this.Controls.Add(this.edtFiKey);
			  this.Controls.Add(this.edtBelegNr);
			  this.Controls.Add(this.edtContract);
			  this.Controls.Add(this.edtAccount);
			  this.Controls.Add(this.edtIBAN);
			  this.Controls.Add(this.edtLEKey);
			  this.Controls.Add(this.edtBankID);
			  this.Controls.Add(this.edtExternalKey);
			  this.Controls.Add(this.btnWOPrecedingNulls);
			  this.Controls.Add(this.btnUmlaute);
			  this.Controls.Add(this.btnTestSettlement);
			  this.Controls.Add(this.button2);
			  this.Controls.Add(this.btnKontoabfrage);
			  this.Controls.Add(this.button3);
			  this.Controls.Add(this.button1);
			  this.Controls.Add(this.btnTestBpWs);
			  this.Controls.Add(this.btnNormal);
			  this.Controls.Add(this.txtAnswer);
			  this.Controls.Add(this.label6);
			  this.Controls.Add(this.txtServiceLocation);
			  this.Controls.Add(this.label15);
			  this.Controls.Add(this.label5);
			  this.Controls.Add(this.label7);
			  this.Controls.Add(this.txtUser);
			  this.Controls.Add(this.label4);
			  this.Controls.Add(this.txtPassword);
			  this.Controls.Add(this.label3);
			  this.Controls.Add(this.txtProxy);
			  this.Controls.Add(this.label14);
			  this.Controls.Add(this.label9);
			  this.Controls.Add(this.btnSetSettings);
			  this.Controls.Add(this.label8);
			  this.Controls.Add(this.label10);
			  this.Controls.Add(this.label11);
			  this.Controls.Add(this.label12);
			  this.Controls.Add(this.label13);
			  this.Controls.Add(this.lblBusy);
			  this.Name = "TestForm";
			  this.Text = "TestForm";
			  ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			  this.ResumeLayout(false);
			  this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox edtBankID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox edtExternalKey;
        private System.Windows.Forms.Button btnWOPrecedingNulls;
        private System.Windows.Forms.Button btnSetSettings;
        private System.Windows.Forms.Button btnUmlaute;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblBusy;
        private System.Windows.Forms.Button btnNormal;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.TextBox txtServiceLocation;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtProxy;
		 private System.Windows.Forms.TextBox txtServerUrl;
		 private System.Windows.Forms.Label label1;
		 private System.Windows.Forms.Label label2;
		 private System.Windows.Forms.CheckBox edtUseMock;
		 private System.Windows.Forms.Button button1;
		 private System.Windows.Forms.Label label3;
		 private System.Windows.Forms.TextBox edtLEKey;
		 private System.Windows.Forms.Label label4;
		 private System.Windows.Forms.TextBox edtIBAN;
		 private System.Windows.Forms.Button button2;
		 private System.Windows.Forms.TextBox edtNotificationLocation;
		 private System.Windows.Forms.Button button3;
		 private System.Windows.Forms.Label label5;
		 private System.Windows.Forms.TextBox edtBelegNr;
		 private System.Windows.Forms.Label label6;
		 private System.Windows.Forms.TextBox edtFiKey;
		 private System.Windows.Forms.Label label7;
		 private System.Windows.Forms.TextBox edtAccount;
		 private System.Windows.Forms.Label label15;
		 private System.Windows.Forms.TextBox edtContract;
		 private System.Windows.Forms.Button btnKontoabfrage;
		 private System.Windows.Forms.Button btnTestBpWs;
		 private System.Windows.Forms.Button btnTestSettlement;
		 private System.Windows.Forms.TextBox edtSettlementLocation;
		 private System.Windows.Forms.Button btnTestSettlementFetcher;
		 private System.Windows.Forms.DataGridView gridView;
    }
}