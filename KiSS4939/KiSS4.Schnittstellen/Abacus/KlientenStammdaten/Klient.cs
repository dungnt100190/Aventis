using System;
using System.Data;
using KiSS4.DB;
using KiSS4.Schnittstellen.Abacus.KlientenStammdaten.Adresse;
using KiSS4.Schnittstellen.Abacus.KlientenStammdaten.KlientenKonto;

namespace KiSS4.Schnittstellen.Abacus.KlientenStammdaten
{
    public class Klient
    {
        #region Fields

        private KlientenAddress adresse;
        private Int32? baPersonID;
        private Boolean isNewKlient;
        private String itemName;
        private Konto klientenKonto;
        private Boolean kontoFuehrung;
        private Int32? kostenstelle;
        private String mandantenNummer;
        private String mitarbeiterNr;
        private String name;
        private Int32? orgUnitID;
        private String plzOrt;
        private String sachbearbeiter;
        private Sozialberater sozialBerater;
        private Char sprachCode;
        private String vorname;
        private String waehrung;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance of Klient
        /// </summary>
        /// <param name="row">The datarow that contains all required information to create a new Klient</param>
        public Klient(DataRow row)
        {
            // validate row
            if (row == null)
            {
                throw new ArgumentNullException("row", "The given DataRow cannot be null.");
            }

            // setup fields from given datarow
            this.baPersonID = DataHandler.GetInt32Value(row, Constants.colBaPersonID);

            this.itemName = Convert.ToString(row[Constants.colItemName]);
            this.kontoFuehrung = Convert.ToBoolean(row[Constants.colKontoFuehrung]);
            this.kostenstelle = DataHandler.GetInt32Value(row, Constants.colKostenstelle);
            this.mandantenNummer = Convert.ToString(row[Constants.colMandantenNummer]);
            this.mitarbeiterNr = Convert.ToString(row[Constants.colMitarbeiterNr]);
            this.name = Convert.ToString(row[Constants.colName]);
            this.orgUnitID = DataHandler.GetInt32Value(row, Constants.colKostenstelle);
            this.sachbearbeiter = Convert.ToString(row[Constants.colSachbearbeiter]);
            this.sprachCode = Convert.ToChar(row[Constants.colSpracheChar]);
            this.vorname = Convert.ToString(row[Constants.colVorname]);
            this.waehrung = Convert.ToString(row[Constants.colWaehrung]);
            this.plzOrt = Convert.ToString(row[Constants.colPlzOrt]);

            // create new instances of KlientenAddress, Sozialberater and Konto
            this.adresse = new KlientenAddress(row);
            this.sozialBerater = new Sozialberater(row);
            this.klientenKonto = new Konto(row);

            // set flag is Klient is new Klient (has no KlientenkontoNr set)
            this.isNewKlient = !klientenKonto.KlientenkontoNr.HasValue;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Get the instance of <see cref="KlientenAdress"/> of this Klient
        /// </summary>
        public KlientenAddress Adresse
        {
            get { return adresse; }
        }

        /// <summary>
        /// Get the BaPersonID of this Klient
        /// </summary>
        public Int32? BaPersonID
        {
            get { return baPersonID; }
        }

        /// <summary>
        /// Get the flag if this Klient is a new Klient to export (has no KlientenkontoNr)
        /// </summary>
        public Boolean IsNewKlient
        {
            get { return isNewKlient; }
        }

        /// <summary>
        /// Get the name of the orgunit of the responsible user
        /// </summary>
        public String ItemName
        {
            get { return itemName; }
        }

        /// <summary>
        /// Get the <see cref="Konto"/> of this Klient
        /// </summary>
        public Konto KlientenKonto
        {
            get { return klientenKonto; }
        }

        /// <summary>
        /// Get the flag if this Klient has KontoFuehrung enabled
        /// </summary>
        public Boolean KontoFuehrung
        {
            get { return kontoFuehrung; }
        }

        /// <summary>
        /// Get the cost center of the orgunit of the responsible user
        /// </summary>
        public Int32? Kostenstelle
        {
            get { return kostenstelle; }
        }

        /// <summary>
        /// Get the MandantenNummer of the orgunit of the responsible user
        /// </summary>
        public String MandantenNummer
        {
            get { return mandantenNummer; }
        }

        /// <summary>
        /// Get the MitarbeiterNr of the responsible user
        /// </summary>
        public String MitarbeiterNr
        {
            get { return mitarbeiterNr; }
        }

        /// <summary>
        /// Get the lastname of this Klient
        /// </summary>
        public String Name
        {
            get { return name; }
        }

        /// <summary>
        /// Get the OrgUnitID of the orgunit of the responsible user
        /// </summary>
        public Int32? OrgUnitID
        {
            get { return orgUnitID; }
        }

        /// <summary>
        /// Get the PLZ with Ort of the Wohnort of this Klient
        /// </summary>
        public String PlzOrt
        {
            get { return plzOrt; }
        }

        /// <summary>
        /// Get the name of the responsible user
        /// </summary>
        public String Sachbearbeiter
        {
            get { return sachbearbeiter; }
        }

        /// <summary>
        /// Get the instance of <see cref="Sozialberater"/> of this Klient
        /// </summary>
        public Sozialberater SozialBerater
        {
            get { return sozialBerater; }
        }

        /// <summary>
        /// Get the SprachCode (D, F, I, E) for this Klient
        /// </summary>
        public Char SprachCode
        {
            get { return sprachCode; }
        }

        /// <summary>
        /// Get the firstname of this Klient
        /// </summary>
        public String Vorname
        {
            get { return vorname; }
        }

        /// <summary>
        /// Get the Waehrung to use for export
        /// </summary>
        public String Waehrung
        {
            get { return waehrung; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Save changes on KlientenkontoNr and DebitorUpdate to database
        /// </summary>
        public void Save()
        {
            // HISTORY
            // create new history entry
            DBUtil.NewHistoryVersion();

            // save KlientenkontoNr in KiSS database
            if (this.KlientenKonto.KlientenkontoNrChanged)
            {
                // UPDATE BaPerson-entry (when new KlientenkontoNr was generated)
                DBUtil.ExecSQLThrowingException(@"
                        UPDATE BaPerson
                        SET KlientenkontoNr = {1},
                            DebitorUpdate = GETDATE(),
                            Modifier = {2},
                            Modified = GetDate()
                        WHERE BaPersonID = {0}", this.BaPersonID, this.KlientenKonto.KlientenkontoNr, DBUtil.GetDBRowCreatorModifier());
            }
            else
            {
                // UPDATE BaPerson-entry (when KlientenkontoNr is existing)
                DBUtil.ExecSQLThrowingException(@"
                        UPDATE dbo.BaPerson
                        SET DebitorUpdate = GETDATE(), Modifier = {0}, Modified = GetDate()
                        WHERE BaPersonID = {1}", DBUtil.GetDBRowCreatorModifier(), this.BaPersonID);
            }
        }

        /// <summary>
        /// Returns a System.String that represents the current System.Object
        /// </summary>
        /// <returns>Returns a System.String that represents the current System.Object</returns>
        public override string ToString()
        {
            // get values for own objects
            String addresseString = this.Adresse == null ? "<empty>" : this.Adresse.ToString();
            String kontoString = this.KlientenKonto == null ? "<empty>" : this.KlientenKonto.ToString();
            String sozialberaterString = this.SozialBerater == null ? "<empty>" : this.SozialBerater.ToString();

            // return string that represents the client (e.g. for logging)
            return String.Format(@"BaPersonID='{0}', Name='{1}', Vorname='{2}', PLZOrt='{3}', SprachCode='{4}', KontoFuehrung='{5}', IsNewKlient='{6}', Waehrung='{7}', MandantenNummer='{8}', OrgUnit='{9} {10}', Kostenstelle='{11}', Mitarbeiter='{12} {13}', Adresse=({14}), SozialBerater=({15}), Konto=({16})",
                                  this.BaPersonID,				// 0
                                  this.Name,					// 1
                                  this.Vorname,					// 2
                                  this.PlzOrt,					// 3
                                  this.SprachCode,				// 4
                                  this.KontoFuehrung,			// 5
                                  this.IsNewKlient,				// 6
                                  this.Waehrung,				// 7
                                  this.MandantenNummer,			// 8
                                  this.OrgUnitID,				// 9
                                  this.ItemName,				// 10
                                  this.Kostenstelle,			// 11
                                  this.MitarbeiterNr,			// 12
                                  this.Sachbearbeiter,			// 13
                                  addresseString,				// 14
                                  sozialberaterString,			// 15
                                  kontoString);					// 16
        }

        #endregion
    }
}