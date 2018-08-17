using System;
using System.Collections;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;
using KiSS4.DB;
using KiSS4.Fallfuehrung.SozialSystem;
using KiSS4.GraphLib;

namespace KiSS4.Fallfuehrung
{
    public delegate void DisplayItemDoubleClickEventHandler(object sender, DisplayItemDoubleClickEventArgs e);

    public enum ModulStatus { none, active, closed, archived };

    public class CtlFaSozialSystem : KiSS4.Gui.KissUserControl
    {
        private System.ComponentModel.IContainer components = null;
        private int fallId = -1;
        private GraphDisplay gd;
        private System.Windows.Forms.Panel panGD;
        private Person person;
        private int personId = -1;

        public CtlFaSozialSystem()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }

        [Description("Fired when the User double clicks on a displayitem ")]
        public event DisplayItemDoubleClickEventHandler DisplayItemDoubleClick
        {
            add { onDisplayItemDoubleClick += value; }
            remove { onDisplayItemDoubleClick -= value; }
        }

        private event DisplayItemDoubleClickEventHandler onDisplayItemDoubleClick;

        /// <summary>
        /// Gets or sets the active (highlighted) <see cref="Fall"/>.
        /// </summary>
        [Browsable(false)]
        [DefaultValue(-1)]
        public int FallId
        {
            get { return this.fallId; }
            set
            {
                if (this.gd.Graph != null) // propagate to PersonDisplay objects
                    if (value == -1)
                    {
                        PersonDisplay pd = (PersonDisplay)this.gd.GetDisplayOf(this.person);
                        this.gd.SelectedItem = pd;
                    }
                    else
                        foreach (Person p in this.gd.Graph)
                        {
                            PersonDisplay pd = (PersonDisplay)this.gd.GetDisplayOf(p);
                            pd.FallId = value;
                            if (pd.IsFallTraeger) this.gd.SelectedItem = pd;
                        }

                this.fallId = value;
            }
        }

        /// <summary>
        /// Gets accees to the internal GraphDisplay
        /// </summary>
        [Browsable(false)]
        public GraphDisplay GD { get { return this.gd; } }

        /// <summary>
        /// Gets or sets the ID of the <see cref="Person"/> who's Sozialsystem is to be displayed.
        /// </summary>
        [Browsable(false)]
        [DefaultValue(-1)]
        public int PersonId
        {
            get { return this.personId; }
            set
            {
                this.gd.Graph = null;
                this.personId = -1;
                this.fallId = -1;

                if (value >= 0)
                {
                    Graph g = new Graph();
                    Hashtable personHash = new Hashtable();
                    Hashtable faelle = new Hashtable();

                    SqlCommand cmd = new SqlCommand("exec spFaGetSozialSystem " + value, Session.Connection);
                    SqlDataReader dr = cmd.ExecuteReader();
                    try
                    {
                        // Person
                        while (dr.Read())
                        {
                            int persId = (int)dr["BaPersonID"];
                            string name = (string)dr["Name"];
                            string vorName = (string)dr["Vorname"];

                            object gebDatObj = dr["Geburtsdatum"];
                            DateTime gebDat = gebDatObj is DateTime ? (DateTime)gebDatObj : DateTime.MinValue;

                            object geschlCodeObj = dr["GeschlechtCode"];
                            bool male = geschlCodeObj is int ? (int)geschlCodeObj == 1 : false;
                            bool female = geschlCodeObj is int ? (int)geschlCodeObj == 2 : false;

                            Person p = new Person(g, persId, name, vorName, male, female, gebDat);
                            p.DoubleClick += new EventHandler(OnPersonDoubleClick);
                            personHash.Add(persId, p);
                        }

                        // Relation
                        dr.NextResult();
                        while (dr.Read())
                        {
                            int persIdSrc = (int)dr["BaPersonID_1"];
                            int persIdDst = (int)dr["BaPersonID_2"];
                            string textSrc = (string)dr["RelationName1"];
                            string textDst = (string)dr["RelationName2"];
                            int priority = (int)dr["RelationPriority"];
                            bool isSymmetric = (bool)dr["symmetrisch"];

                            Person persSrc = (Person)personHash[persIdSrc];
                            Person persDst = (Person)personHash[persIdDst];

                            new Relation(persSrc, textSrc, persDst, textDst, isSymmetric, priority);
                        }

                        // Fälle
                        dr.NextResult();
                        while (dr.Read())
                        {
                            //TODO umbenennen fall --> Leistung (Klasse Fall --> Leistung)
                            int fallId = (int)dr["FaLeistungID"];
                            int modulCode = (int)dr["ModulID"];
                            ModulStatus modulStatus = (ModulStatus)dr["ModulStatusCode"];
                            int persId = (int)dr["Falltraeger"];

                            Person fallTraeger = (Person)personHash[persId];
                            Fall f = new Fall(fallId, modulCode, modulStatus, fallTraeger);

                            faelle.Add(fallId, f);
                            fallTraeger.AddFall(f, true);
                        }

                        // FallPerson
                        dr.NextResult();
                        while (dr.Read())
                        {
                            int fallId = (int)dr["FaLeistungID"];
                            int persId = (int)dr["BaPersonID"];
                            bool isUnterstuetzt = (int)dr["IstUnterstuetzt"] != 0;

                            Fall f = (Fall)faelle[fallId];
                            Person p = (Person)personHash[persId];

                            try
                            {
                                if (f != null && p != null)
                                {
                                    // 09.04.2009 : Nach Elimination von FaFall müssen doppelte FallIDs ( = neu BaPersonIDs) eliminiert werden
                                    // p.AddFall(f, isUnterstuetzt);
                                    if (!faelle.ContainsKey(f.FallId)) p.AddFall(f, isUnterstuetzt);
                                }
                            }
                            catch (ArgumentException ex)
                            {
                                // TODO: Due to DataReader, we cannot use ML-Errormessage (see: SqlQuery.Fill() will throw exception)
                                // KissMsg.ShowError("CtlFaSozialsystem", "ErrorAddingFallPersonArgumentEx", "Es ist ein Fehler beim Hinzufügen der Fall-Personen aufgetreten.", ex);
                                KissMsg.ShowError(null, null, "Es ist ein Fehler beim Hinzufügen der Fall-Personen aufgetreten.", ex);
                            }
                        }
                    }
                    finally { dr.Close(); }

                    bool display = true;

                    if (personHash.Count >= 100 ||
                        personHash.Count > 15 && Session.IsKiss5Mode)
                    {
                        display = false;
                        KissMsg.ShowInfo("CtlFaSozialsystem", "SozialsystemWirdNichtAngezeigt", "Das darzustellende Sozialsystem umfasst {0} Personen.\r\n\r\nWahrscheinlich ist eine fiktive Person (zB. Wohnpartner, MitbewohnerIn etc.) in den Basisdaten nicht als fiktiv gekennzeichnet.\r\n\r\nDie graphische Aufbereitung würde sehr, sehr lange dauern. Deshalb wird das Sozialsystem nicht angezeigt.\r\n\r\nBitte melden Sie zur Behebung dem Administrator/der Administratorin die FallträgerIn dieses grossen Sozialsystems.", 500, 280, personHash.Count.ToString());
                    }
                    else if (personHash.Count > 15)
                    {
                        display = KissMsg.ShowQuestion("CtlFaSozialsystem", "SozialsystemTrotzdemAnzeigen", "Das darzustellende Sozialsystem umfasst {0} Personen.\r\n\r\nDie graphische Aufbereitung kann einige Zeit in Anspruch nehmen.\r\n\r\nSoll das Sozialsystem trotzdem angezeigt werden ?", 500, 200, true, personHash.Count.ToString());
                    }

                    if (display)
                    {
                        this.gd.Graph = g;
                        this.personId = value;
                        this.person = (Person)personHash[value];
                    }
                }
            }
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

        protected virtual void OnDisplayItemDoubleClick(object sender, DisplayItemDoubleClickEventArgs e)
        {
            if (onDisplayItemDoubleClick != null)
            {
                onDisplayItemDoubleClick(sender, e);
            }
        }

        protected virtual void OnPersonDoubleClick(object sender, EventArgs e)
        {
            DisplayItemDoubleClickEventArgs args = new DisplayItemDoubleClickEventArgs();
            args.Person = (Person)sender;
            OnDisplayItemDoubleClick(this, args);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panGD = new System.Windows.Forms.Panel();
            this.gd = new KiSS4.GraphLib.GraphDisplay();
            this.panGD.SuspendLayout();
            this.SuspendLayout();
            //
            // panGD
            //
            this.panGD.Controls.Add(this.gd);
            this.panGD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panGD.Location = new System.Drawing.Point(0, 0);
            this.panGD.Name = "panGD";
            this.panGD.Size = new System.Drawing.Size(753, 394);
            this.panGD.TabIndex = 1;
            //
            // gd
            //
            this.gd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gd.Location = new System.Drawing.Point(0, 0);
            this.gd.Name = "gd";
            this.gd.Size = new System.Drawing.Size(753, 394);
            this.gd.TabIndex = 1;
            this.gd.Print += new System.EventHandler(this.gd_Print);
            //
            // CtlFaSozialSystem
            //
            this.AutoRefresh = false;
            this.Controls.Add(this.panGD);
            this.Name = "CtlFaSozialSystem";
            this.Size = new System.Drawing.Size(753, 394);
            this.RefreshData += new System.EventHandler(this.CtlFaSozialSystem_RefreshData);
            this.panGD.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private void CtlFaSozialSystem_RefreshData(object sender, System.EventArgs e)
        {
            this.PersonId = this.PersonId;
        }

        private void gd_Print(object sender, EventArgs e)
        {
            if (this.gd.Graph == null) return;

            PrintPreviewDialog ppd = new PrintPreviewDialog();
            GraphDocument gd = new GraphDocument(this.gd.Graph);
            gd.Title = KissMsg.GetMLMessage("CtlFaSozialSystem", "SozialsystemDruckTitel", "Sozialsystem - {0} {1}", this.person.Vorname, this.person.Name);
            ppd.Document = gd;
            ppd.Show();
        }
    }

    public class DisplayItemDoubleClickEventArgs : EventArgs
    {
        private Person person;

        public Person Person
        {
            get { return person; }
            set { person = value; }
        }
    }
}