using System.Drawing;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Vormundschaft
{
    /// <summary>
    /// Summary description for CtlVmErblasser.
    /// </summary>
    public class CtlVmErblasser : KissUserControl
    {
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit edtAHVNummer;
        private KiSS4.Gui.KissTextEdit edtAnrede;
        private KiSS4.Gui.KissTextEdit edtAufenthalt;
        private KiSS4.Gui.KissRTFEdit edtBemerkung;
        private KiSS4.Gui.KissTextEdit edtElternnamen;
        private KiSS4.Gui.KissTextEdit edtFamiliennamen;
        private KiSS4.Gui.KissTextEdit edtGeburtsdatum;
        private KiSS4.Gui.KissTextEdit edtHeimatorte;
        private KiSS4.Gui.KissTextEdit edtOrt;
        private KiSS4.Gui.KissCheckEdit edtPrivat;
        private KiSS4.Gui.KissTextEdit edtStrasse;
        private KiSS4.Gui.KissDateEdit edtTodesdatum;
        private KiSS4.Gui.KissTextEdit edtTodesdatumText;
        private KiSS4.Gui.KissTextEdit edtTodesOrt;
        private KissVersichertenNrEdit edtVersNr;
        private KiSS4.Gui.KissTextEdit edtVornamen;
        private KiSS4.Gui.KissTextEdit edtZivilstand;
        private KiSS4.Gui.KissLookUpEdit edtZivilstandCode;
        private int FaLeistungID = 0;
        private KiSS4.Gui.KissLabel lblAHVNummer;
        private KiSS4.Gui.KissLabel lblAnrede;
        private KiSS4.Gui.KissLabel lblAufenthalt;
        private KiSS4.Gui.KissLabel lblBeistand;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblElternnamen;
        private KiSS4.Gui.KissLabel lblFamilienNamen;
        private KiSS4.Gui.KissLabel lblGeburtsdatum;
        private KiSS4.Gui.KissLabel lblHeimatorte;
        private KiSS4.Gui.KissLabel lblMT;
        private KiSS4.Gui.KissLabel lblOrt;
        private KiSS4.Gui.KissLabel lblStrasse;
        private System.Windows.Forms.Label lblTitel;
        private KiSS4.Gui.KissLabel lblTodesdatum;
        private KiSS4.Gui.KissLabel lblTodesDatumText;
        private KiSS4.Gui.KissLabel lblTodesort;
        private KissLabel lblVersNr;
        private KiSS4.Gui.KissLabel lblVornamen;
        private KiSS4.Gui.KissLabel lblZivilstand;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryBeistand;
        private KiSS4.DB.SqlQuery qryVmErblasser;

        public CtlVmErblasser()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }

        public void Init(string titleName, Image titleImage, int faLeistungID)
        {
            this.lblTitel.Text = titleName;
            this.picTitel.Image = titleImage;
            this.FaLeistungID = faLeistungID;

            qryBeistand.Fill(@"
                SELECT MT = CASE WHEN USR.UserID IS NOT NULL
                                 THEN USR.LastName + isNull(', ' + USR.FirstName,'')
                                 ELSE VPM.Name + isNull(', ' + VPM.Vorname,'') + ' (PriMa)'
                             END,
                       privat = CONVERT(BIT, CASE WHEN USR.UserID IS NOT NULL THEN 0 ELSE 1	END)
                FROM dbo.FaLeistung FAL1 WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.FaLeistung FAL2 WITH (READUNCOMMITTED) ON FAL2.BaPersonID = FAL1.BaPersonID
                                           AND FAL2.ModulID = 5
                                           AND FAL2.FaProzessCode = 501
                                           AND FAL2.FaLeistungID = (SELECT Top 1 FaLeistungID
                                                                    FROM FaLeistung
                                                                    WHERE  BaPersonID = FAL1.BaPersonID
                                                                       AND ModulID = 5
                                                                       AND FaProzessCode = 501
																	ORDER BY DatumVon)
                  LEFT JOIN dbo.VmMassnahme VMN WITH (READUNCOMMITTED) ON VMN.FaLeistungID = FAL2.FaLeistungID
                                           AND VMN.DatumVon = (SELECT MAX(DatumVon)
                                                               FROM VmMassnahme
                                                               WHERE  FaLeistungID = FAL2.FaLeistungID)
                  LEFT JOIN dbo.VmErnennung VEN WITH (READUNCOMMITTED) ON VEN.VmMassnahmeID = VMN.VmMassnahmeID
                                           AND VEN.VmErnennungID = (SELECT TOP 1 VmErnennungID
                                                                    FROM VmErnennung
                                                                    WHERE  VmMassnahmeID = VMN.VmMassnahmeID
                                                                    ORDER BY Ernennung DESC)
                  LEFT  JOIN dbo.XUser      USR WITH (READUNCOMMITTED) ON USR.UserID = VEN.UserID
                  LEFT  JOIN dbo.VmPriMa    VPM WITH (READUNCOMMITTED) ON VPM.VmPriMaID = VEN.VmPriMaID
				WHERE FAL1.FaLeistungID = {0}",
                FaLeistungID);

            qryVmErblasser.Fill("SELECT * FROM dbo.VmErblasser WITH (READUNCOMMITTED) WHERE FaLeistungID = {0}", FaLeistungID);

            if (qryVmErblasser.Count == 0)
                qryVmErblasser.Insert(null);
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlVmErblasser));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryVmErblasser = new KiSS4.DB.SqlQuery(this.components);
            this.lblTitel = new System.Windows.Forms.Label();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.lblOrt = new KiSS4.Gui.KissLabel();
            this.lblStrasse = new KiSS4.Gui.KissLabel();
            this.lblHeimatorte = new KiSS4.Gui.KissLabel();
            this.lblGeburtsdatum = new KiSS4.Gui.KissLabel();
            this.lblZivilstand = new KiSS4.Gui.KissLabel();
            this.lblElternnamen = new KiSS4.Gui.KissLabel();
            this.lblVornamen = new KiSS4.Gui.KissLabel();
            this.lblFamilienNamen = new KiSS4.Gui.KissLabel();
            this.lblAnrede = new KiSS4.Gui.KissLabel();
            this.lblAHVNummer = new KiSS4.Gui.KissLabel();
            this.lblTodesort = new KiSS4.Gui.KissLabel();
            this.lblTodesdatum = new KiSS4.Gui.KissLabel();
            this.edtOrt = new KiSS4.Gui.KissTextEdit();
            this.edtStrasse = new KiSS4.Gui.KissTextEdit();
            this.edtAHVNummer = new KiSS4.Gui.KissTextEdit();
            this.edtGeburtsdatum = new KiSS4.Gui.KissTextEdit();
            this.edtElternnamen = new KiSS4.Gui.KissTextEdit();
            this.edtVornamen = new KiSS4.Gui.KissTextEdit();
            this.edtFamiliennamen = new KiSS4.Gui.KissTextEdit();
            this.edtAnrede = new KiSS4.Gui.KissTextEdit();
            this.edtZivilstand = new KiSS4.Gui.KissTextEdit();
            this.edtTodesOrt = new KiSS4.Gui.KissTextEdit();
            this.edtTodesdatumText = new KiSS4.Gui.KissTextEdit();
            this.edtBemerkung = new KiSS4.Gui.KissRTFEdit();
            this.edtHeimatorte = new KiSS4.Gui.KissTextEdit();
            this.edtAufenthalt = new KiSS4.Gui.KissTextEdit();
            this.lblAufenthalt = new KiSS4.Gui.KissLabel();
            this.edtZivilstandCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtTodesdatum = new KiSS4.Gui.KissDateEdit();
            this.lblTodesDatumText = new KiSS4.Gui.KissLabel();
            this.lblBeistand = new KiSS4.Gui.KissLabel();
            this.edtPrivat = new KiSS4.Gui.KissCheckEdit();
            this.qryBeistand = new KiSS4.DB.SqlQuery(this.components);
            this.lblMT = new KiSS4.Gui.KissLabel();
            this.edtVersNr = new KiSS4.Gui.KissVersichertenNrEdit();
            this.lblVersNr = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryVmErblasser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeimatorte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZivilstand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblElternnamen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVornamen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFamilienNamen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnrede)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAHVNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTodesort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTodesdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtElternnamen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVornamen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFamiliennamen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnrede.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTodesOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTodesdatumText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatorte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufenthalt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthalt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstandCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstandCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTodesdatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTodesDatumText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeistand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPrivat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBeistand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersNr)).BeginInit();
            this.SuspendLayout();
            //
            // qryVmErblasser
            //
            this.qryVmErblasser.CanUpdate = true;
            this.qryVmErblasser.HostControl = this;
            this.qryVmErblasser.TableName = "VmErblasser";
            this.qryVmErblasser.BeforePost += new System.EventHandler(this.qryVmErblasser_BeforePost);
            //
            // lblTitel
            //
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.Black;
            this.lblTitel.Location = new System.Drawing.Point(35, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(31, 15);
            this.lblTitel.TabIndex = 13;
            this.lblTitel.Text = "Titel";
            //
            // picTitel
            //
            this.picTitel.Image = ((System.Drawing.Image)(resources.GetObject("picTitel.Image")));
            this.picTitel.Location = new System.Drawing.Point(10, 9);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(25, 20);
            this.picTitel.TabIndex = 12;
            this.picTitel.TabStop = false;
            //
            // lblBemerkung
            //
            this.lblBemerkung.Location = new System.Drawing.Point(5, 446);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(94, 24);
            this.lblBemerkung.TabIndex = 43;
            this.lblBemerkung.Text = "Bemerkungen";
            //
            // lblOrt
            //
            this.lblOrt.Location = new System.Drawing.Point(5, 282);
            this.lblOrt.Name = "lblOrt";
            this.lblOrt.Size = new System.Drawing.Size(94, 24);
            this.lblOrt.TabIndex = 54;
            this.lblOrt.Text = "Ort";
            //
            // lblStrasse
            //
            this.lblStrasse.Location = new System.Drawing.Point(5, 259);
            this.lblStrasse.Name = "lblStrasse";
            this.lblStrasse.Size = new System.Drawing.Size(94, 24);
            this.lblStrasse.TabIndex = 55;
            this.lblStrasse.Text = "Strasse";
            //
            // lblHeimatorte
            //
            this.lblHeimatorte.Location = new System.Drawing.Point(5, 229);
            this.lblHeimatorte.Name = "lblHeimatorte";
            this.lblHeimatorte.Size = new System.Drawing.Size(94, 24);
            this.lblHeimatorte.TabIndex = 56;
            this.lblHeimatorte.Text = "Heimatort(e)";
            //
            // lblGeburtsdatum
            //
            this.lblGeburtsdatum.Location = new System.Drawing.Point(5, 199);
            this.lblGeburtsdatum.Name = "lblGeburtsdatum";
            this.lblGeburtsdatum.Size = new System.Drawing.Size(94, 24);
            this.lblGeburtsdatum.TabIndex = 57;
            this.lblGeburtsdatum.Text = "Geburtsdatum";
            //
            // lblZivilstand
            //
            this.lblZivilstand.Location = new System.Drawing.Point(5, 146);
            this.lblZivilstand.Name = "lblZivilstand";
            this.lblZivilstand.Size = new System.Drawing.Size(94, 24);
            this.lblZivilstand.TabIndex = 58;
            this.lblZivilstand.Text = "Zivilstand";
            //
            // lblElternnamen
            //
            this.lblElternnamen.Location = new System.Drawing.Point(5, 116);
            this.lblElternnamen.Name = "lblElternnamen";
            this.lblElternnamen.Size = new System.Drawing.Size(94, 24);
            this.lblElternnamen.TabIndex = 59;
            this.lblElternnamen.Text = "Elternnamen";
            //
            // lblVornamen
            //
            this.lblVornamen.Location = new System.Drawing.Point(5, 93);
            this.lblVornamen.Name = "lblVornamen";
            this.lblVornamen.Size = new System.Drawing.Size(94, 24);
            this.lblVornamen.TabIndex = 60;
            this.lblVornamen.Text = "Vorname(n)";
            //
            // lblFamilienNamen
            //
            this.lblFamilienNamen.Location = new System.Drawing.Point(5, 70);
            this.lblFamilienNamen.Name = "lblFamilienNamen";
            this.lblFamilienNamen.Size = new System.Drawing.Size(94, 24);
            this.lblFamilienNamen.TabIndex = 62;
            this.lblFamilienNamen.Text = "Familienname(n)";
            //
            // lblAnrede
            //
            this.lblAnrede.Location = new System.Drawing.Point(5, 40);
            this.lblAnrede.Name = "lblAnrede";
            this.lblAnrede.Size = new System.Drawing.Size(44, 24);
            this.lblAnrede.TabIndex = 63;
            this.lblAnrede.Text = "Anrede";
            //
            // lblAHVNummer
            //
            this.lblAHVNummer.Location = new System.Drawing.Point(5, 386);
            this.lblAHVNummer.Name = "lblAHVNummer";
            this.lblAHVNummer.Size = new System.Drawing.Size(94, 24);
            this.lblAHVNummer.TabIndex = 64;
            this.lblAHVNummer.Text = "AHV-Nr.";
            //
            // lblTodesort
            //
            this.lblTodesort.Location = new System.Drawing.Point(225, 358);
            this.lblTodesort.Name = "lblTodesort";
            this.lblTodesort.Size = new System.Drawing.Size(52, 24);
            this.lblTodesort.TabIndex = 65;
            this.lblTodesort.Text = "Todesort";
            //
            // lblTodesdatum
            //
            this.lblTodesdatum.Location = new System.Drawing.Point(5, 335);
            this.lblTodesdatum.Name = "lblTodesdatum";
            this.lblTodesdatum.Size = new System.Drawing.Size(94, 24);
            this.lblTodesdatum.TabIndex = 66;
            this.lblTodesdatum.Text = "Todesdatum";
            //
            // edtOrt
            //
            this.edtOrt.DataMember = "Ort";
            this.edtOrt.DataSource = this.qryVmErblasser;
            this.edtOrt.Location = new System.Drawing.Point(105, 282);
            this.edtOrt.Name = "edtOrt";
            this.edtOrt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrt.Properties.Appearance.Options.UseFont = true;
            this.edtOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtOrt.Size = new System.Drawing.Size(485, 24);
            this.edtOrt.TabIndex = 9;
            //
            // edtStrasse
            //
            this.edtStrasse.DataMember = "Strasse";
            this.edtStrasse.DataSource = this.qryVmErblasser;
            this.edtStrasse.Location = new System.Drawing.Point(105, 259);
            this.edtStrasse.Name = "edtStrasse";
            this.edtStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStrasse.Size = new System.Drawing.Size(485, 24);
            this.edtStrasse.TabIndex = 8;
            //
            // edtAHVNummer
            //
            this.edtAHVNummer.DataMember = "AHVNummer";
            this.edtAHVNummer.DataSource = this.qryVmErblasser;
            this.edtAHVNummer.Location = new System.Drawing.Point(105, 386);
            this.edtAHVNummer.Name = "edtAHVNummer";
            this.edtAHVNummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAHVNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAHVNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAHVNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtAHVNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAHVNummer.Properties.Appearance.Options.UseFont = true;
            this.edtAHVNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAHVNummer.Size = new System.Drawing.Size(137, 24);
            this.edtAHVNummer.TabIndex = 14;
            //
            // edtGeburtsdatum
            //
            this.edtGeburtsdatum.DataMember = "Geburtsdatum";
            this.edtGeburtsdatum.DataSource = this.qryVmErblasser;
            this.edtGeburtsdatum.Location = new System.Drawing.Point(105, 199);
            this.edtGeburtsdatum.Name = "edtGeburtsdatum";
            this.edtGeburtsdatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeburtsdatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtsdatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtsdatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtsdatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtsdatum.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtsdatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGeburtsdatum.Size = new System.Drawing.Size(249, 24);
            this.edtGeburtsdatum.TabIndex = 6;
            //
            // edtElternnamen
            //
            this.edtElternnamen.DataMember = "Elternnamen";
            this.edtElternnamen.DataSource = this.qryVmErblasser;
            this.edtElternnamen.Location = new System.Drawing.Point(105, 116);
            this.edtElternnamen.Name = "edtElternnamen";
            this.edtElternnamen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtElternnamen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtElternnamen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtElternnamen.Properties.Appearance.Options.UseBackColor = true;
            this.edtElternnamen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtElternnamen.Properties.Appearance.Options.UseFont = true;
            this.edtElternnamen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtElternnamen.Size = new System.Drawing.Size(485, 24);
            this.edtElternnamen.TabIndex = 3;
            //
            // edtVornamen
            //
            this.edtVornamen.DataMember = "Vornamen";
            this.edtVornamen.DataSource = this.qryVmErblasser;
            this.edtVornamen.Location = new System.Drawing.Point(105, 93);
            this.edtVornamen.Name = "edtVornamen";
            this.edtVornamen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVornamen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVornamen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVornamen.Properties.Appearance.Options.UseBackColor = true;
            this.edtVornamen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVornamen.Properties.Appearance.Options.UseFont = true;
            this.edtVornamen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVornamen.Size = new System.Drawing.Size(485, 24);
            this.edtVornamen.TabIndex = 2;
            //
            // edtFamiliennamen
            //
            this.edtFamiliennamen.DataMember = "FamilienNamen";
            this.edtFamiliennamen.DataSource = this.qryVmErblasser;
            this.edtFamiliennamen.Location = new System.Drawing.Point(105, 70);
            this.edtFamiliennamen.Name = "edtFamiliennamen";
            this.edtFamiliennamen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFamiliennamen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFamiliennamen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFamiliennamen.Properties.Appearance.Options.UseBackColor = true;
            this.edtFamiliennamen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFamiliennamen.Properties.Appearance.Options.UseFont = true;
            this.edtFamiliennamen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFamiliennamen.Size = new System.Drawing.Size(485, 24);
            this.edtFamiliennamen.TabIndex = 1;
            //
            // edtAnrede
            //
            this.edtAnrede.DataMember = "Anrede";
            this.edtAnrede.DataSource = this.qryVmErblasser;
            this.edtAnrede.Location = new System.Drawing.Point(105, 40);
            this.edtAnrede.Name = "edtAnrede";
            this.edtAnrede.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAnrede.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnrede.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnrede.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnrede.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnrede.Properties.Appearance.Options.UseFont = true;
            this.edtAnrede.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAnrede.Size = new System.Drawing.Size(85, 24);
            this.edtAnrede.TabIndex = 0;
            //
            // edtZivilstand
            //
            this.edtZivilstand.DataMember = "Zivilstand";
            this.edtZivilstand.DataSource = this.qryVmErblasser;
            this.edtZivilstand.Location = new System.Drawing.Point(105, 146);
            this.edtZivilstand.Name = "edtZivilstand";
            this.edtZivilstand.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZivilstand.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZivilstand.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZivilstand.Properties.Appearance.Options.UseBackColor = true;
            this.edtZivilstand.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZivilstand.Properties.Appearance.Options.UseFont = true;
            this.edtZivilstand.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZivilstand.Size = new System.Drawing.Size(485, 24);
            this.edtZivilstand.TabIndex = 4;
            //
            // edtTodesOrt
            //
            this.edtTodesOrt.DataMember = "TodesOrt";
            this.edtTodesOrt.DataSource = this.qryVmErblasser;
            this.edtTodesOrt.Location = new System.Drawing.Point(301, 358);
            this.edtTodesOrt.Name = "edtTodesOrt";
            this.edtTodesOrt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTodesOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTodesOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTodesOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtTodesOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTodesOrt.Properties.Appearance.Options.UseFont = true;
            this.edtTodesOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTodesOrt.Size = new System.Drawing.Size(289, 24);
            this.edtTodesOrt.TabIndex = 13;
            //
            // edtTodesdatumText
            //
            this.edtTodesdatumText.DataMember = "TodesDatumText";
            this.edtTodesdatumText.DataSource = this.qryVmErblasser;
            this.edtTodesdatumText.Location = new System.Drawing.Point(301, 335);
            this.edtTodesdatumText.Name = "edtTodesdatumText";
            this.edtTodesdatumText.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTodesdatumText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTodesdatumText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTodesdatumText.Properties.Appearance.Options.UseBackColor = true;
            this.edtTodesdatumText.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTodesdatumText.Properties.Appearance.Options.UseFont = true;
            this.edtTodesdatumText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTodesdatumText.Size = new System.Drawing.Size(289, 24);
            this.edtTodesdatumText.TabIndex = 12;
            //
            // edtBemerkung
            //
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBemerkung.BackColor = System.Drawing.Color.White;
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryVmErblasser;
            this.edtBemerkung.Font = new System.Drawing.Font("Arial", 10F);
            this.edtBemerkung.Location = new System.Drawing.Point(105, 446);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Size = new System.Drawing.Size(489, 93);
            this.edtBemerkung.TabIndex = 16;
            //
            // edtHeimatorte
            //
            this.edtHeimatorte.DataMember = "Heimatorte";
            this.edtHeimatorte.DataSource = this.qryVmErblasser;
            this.edtHeimatorte.Location = new System.Drawing.Point(105, 229);
            this.edtHeimatorte.Name = "edtHeimatorte";
            this.edtHeimatorte.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHeimatorte.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHeimatorte.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHeimatorte.Properties.Appearance.Options.UseBackColor = true;
            this.edtHeimatorte.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHeimatorte.Properties.Appearance.Options.UseFont = true;
            this.edtHeimatorte.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHeimatorte.Size = new System.Drawing.Size(485, 24);
            this.edtHeimatorte.TabIndex = 7;
            //
            // edtAufenthalt
            //
            this.edtAufenthalt.DataMember = "Aufenthalt";
            this.edtAufenthalt.DataSource = this.qryVmErblasser;
            this.edtAufenthalt.Location = new System.Drawing.Point(105, 305);
            this.edtAufenthalt.Name = "edtAufenthalt";
            this.edtAufenthalt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAufenthalt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAufenthalt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAufenthalt.Properties.Appearance.Options.UseBackColor = true;
            this.edtAufenthalt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAufenthalt.Properties.Appearance.Options.UseFont = true;
            this.edtAufenthalt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAufenthalt.Size = new System.Drawing.Size(485, 24);
            this.edtAufenthalt.TabIndex = 10;
            //
            // lblAufenthalt
            //
            this.lblAufenthalt.Location = new System.Drawing.Point(5, 305);
            this.lblAufenthalt.Name = "lblAufenthalt";
            this.lblAufenthalt.Size = new System.Drawing.Size(94, 24);
            this.lblAufenthalt.TabIndex = 69;
            this.lblAufenthalt.Text = "Aufenthalt in";
            //
            // edtZivilstandCode
            //
            this.edtZivilstandCode.DataMember = "ZivilstandCode";
            this.edtZivilstandCode.DataSource = this.qryVmErblasser;
            this.edtZivilstandCode.Location = new System.Drawing.Point(105, 169);
            this.edtZivilstandCode.LOVName = "VmErbeZivilstand";
            this.edtZivilstandCode.Name = "edtZivilstandCode";
            this.edtZivilstandCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZivilstandCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZivilstandCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZivilstandCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtZivilstandCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZivilstandCode.Properties.Appearance.Options.UseFont = true;
            this.edtZivilstandCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZivilstandCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZivilstandCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZivilstandCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZivilstandCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtZivilstandCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtZivilstandCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZivilstandCode.Properties.NullText = "";
            this.edtZivilstandCode.Properties.ShowFooter = false;
            this.edtZivilstandCode.Properties.ShowHeader = false;
            this.edtZivilstandCode.Size = new System.Drawing.Size(485, 24);
            this.edtZivilstandCode.TabIndex = 5;
            //
            // edtTodesdatum
            //
            this.edtTodesdatum.DataMember = "TodesDatum";
            this.edtTodesdatum.DataSource = this.qryVmErblasser;
            this.edtTodesdatum.EditValue = null;
            this.edtTodesdatum.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.edtTodesdatum.Location = new System.Drawing.Point(105, 335);
            this.edtTodesdatum.Name = "edtTodesdatum";
            this.edtTodesdatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTodesdatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTodesdatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTodesdatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTodesdatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtTodesdatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTodesdatum.Properties.Appearance.Options.UseFont = true;
            this.edtTodesdatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtTodesdatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtTodesdatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtTodesdatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTodesdatum.Properties.ShowToday = false;
            this.edtTodesdatum.Size = new System.Drawing.Size(100, 24);
            this.edtTodesdatum.TabIndex = 11;
            //
            // lblTodesDatumText
            //
            this.lblTodesDatumText.Location = new System.Drawing.Point(225, 335);
            this.lblTodesDatumText.Name = "lblTodesDatumText";
            this.lblTodesDatumText.Size = new System.Drawing.Size(75, 24);
            this.lblTodesDatumText.TabIndex = 71;
            this.lblTodesDatumText.Text = "Datumbereich";
            //
            // lblBeistand
            //
            this.lblBeistand.Location = new System.Drawing.Point(276, 40);
            this.lblBeistand.Name = "lblBeistand";
            this.lblBeistand.Size = new System.Drawing.Size(90, 24);
            this.lblBeistand.TabIndex = 73;
            this.lblBeistand.Text = "Beistand/Vormund";
            //
            // edtPrivat
            //
            this.edtPrivat.DataMember = "privat";
            this.edtPrivat.DataSource = this.qryBeistand;
            this.edtPrivat.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPrivat.EditValue = false;
            this.edtPrivat.Location = new System.Drawing.Point(541, 46);
            this.edtPrivat.Name = "edtPrivat";
            this.edtPrivat.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtPrivat.Properties.Appearance.Options.UseBackColor = true;
            this.edtPrivat.Properties.Caption = "privat";
            this.edtPrivat.Properties.ReadOnly = true;
            this.edtPrivat.Size = new System.Drawing.Size(53, 19);
            this.edtPrivat.TabIndex = 74;
            //
            // qryBeistand
            //
            this.qryBeistand.HostControl = this;
            //
            // lblMT
            //
            this.lblMT.DataMember = "MT";
            this.lblMT.DataSource = this.qryBeistand;
            this.lblMT.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblMT.Location = new System.Drawing.Point(378, 44);
            this.lblMT.Name = "lblMT";
            this.lblMT.Size = new System.Drawing.Size(157, 16);
            this.lblMT.TabIndex = 75;
            //
            // edtVersNr
            //
            this.edtVersNr.DataMember = "Versichertennummer";
            this.edtVersNr.DataSource = this.qryVmErblasser;
            this.edtVersNr.Location = new System.Drawing.Point(105, 416);
            this.edtVersNr.Name = "edtVersNr";
            this.edtVersNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVersNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVersNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVersNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVersNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtVersNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVersNr.Properties.Appearance.Options.UseFont = true;
            this.edtVersNr.Properties.Appearance.Options.UseTextOptions = true;
            this.edtVersNr.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.edtVersNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVersNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVersNr.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.edtVersNr.Properties.DisplayFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtVersNr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtVersNr.Properties.EditFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtVersNr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtVersNr.Properties.Mask.EditMask = "000\\.0000\\.0000\\.00";
            this.edtVersNr.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.edtVersNr.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtVersNr.Properties.MaxLength = 13;
            this.edtVersNr.Properties.Precision = 0;
            this.edtVersNr.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtVersNr.Size = new System.Drawing.Size(137, 24);
            this.edtVersNr.TabIndex = 15;
            //
            // lblVersNr
            //
            this.lblVersNr.Location = new System.Drawing.Point(5, 416);
            this.lblVersNr.Name = "lblVersNr";
            this.lblVersNr.Size = new System.Drawing.Size(94, 24);
            this.lblVersNr.TabIndex = 77;
            this.lblVersNr.Text = "Versichertennr.";
            //
            // CtlVmErblasser
            //
            this.ActiveSQLQuery = this.qryVmErblasser;

            this.Controls.Add(this.edtVersNr);
            this.Controls.Add(this.lblVersNr);
            this.Controls.Add(this.lblMT);
            this.Controls.Add(this.edtPrivat);
            this.Controls.Add(this.lblBeistand);
            this.Controls.Add(this.lblTodesDatumText);
            this.Controls.Add(this.edtTodesdatum);
            this.Controls.Add(this.edtZivilstandCode);
            this.Controls.Add(this.edtAufenthalt);
            this.Controls.Add(this.lblAufenthalt);
            this.Controls.Add(this.edtHeimatorte);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.edtTodesdatumText);
            this.Controls.Add(this.edtTodesOrt);
            this.Controls.Add(this.edtZivilstand);
            this.Controls.Add(this.edtAnrede);
            this.Controls.Add(this.edtFamiliennamen);
            this.Controls.Add(this.edtVornamen);
            this.Controls.Add(this.edtElternnamen);
            this.Controls.Add(this.edtGeburtsdatum);
            this.Controls.Add(this.edtAHVNummer);
            this.Controls.Add(this.edtStrasse);
            this.Controls.Add(this.edtOrt);
            this.Controls.Add(this.lblTodesdatum);
            this.Controls.Add(this.lblTodesort);
            this.Controls.Add(this.lblAHVNummer);
            this.Controls.Add(this.lblAnrede);
            this.Controls.Add(this.lblFamilienNamen);
            this.Controls.Add(this.lblVornamen);
            this.Controls.Add(this.lblElternnamen);
            this.Controls.Add(this.lblZivilstand);
            this.Controls.Add(this.lblGeburtsdatum);
            this.Controls.Add(this.lblHeimatorte);
            this.Controls.Add(this.lblStrasse);
            this.Controls.Add(this.lblOrt);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.lblTitel);
            this.Name = "CtlVmErblasser";
            this.Size = new System.Drawing.Size(608, 542);
            ((System.ComponentModel.ISupportInitialize)(this.qryVmErblasser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeimatorte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZivilstand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblElternnamen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVornamen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFamilienNamen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnrede)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAHVNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTodesort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTodesdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtElternnamen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVornamen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFamiliennamen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnrede.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTodesOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTodesdatumText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatorte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufenthalt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthalt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstandCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstandCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTodesdatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTodesDatumText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeistand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPrivat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBeistand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersNr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private void qryVmErblasser_BeforePost(object sender, System.EventArgs e)
        {
            DBUtil.CheckNotNullField(edtTodesdatum, lblTodesdatum.Text);
            DBUtil.CheckNotNullField(edtFamiliennamen, lblFamilienNamen.Text);
            DBUtil.CheckNotNullField(edtVornamen, lblVornamen.Text);

            if (!edtVersNr.ValidateVersNr(true, false))
            {
                // set focus
                edtVersNr.Focus();

                // cancel, message already shown
                throw new KissCancelException();
            }

            qryVmErblasser["FaLeistungID"] = FaLeistungID;
        }
    }
}