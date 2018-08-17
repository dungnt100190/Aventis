using System;
using System.Data;
using KiSS4.DB;
using KiSS4.Schnittstellen.AbacFibuClassification201100;

namespace KiSS4.Schnittstellen.Abacus.KlientenStammdaten.KlientenKonto
{
    public class Konto
    {
        #region Constants

        private const String KONTENTYPKOSTENTRAEGER = "KTR";

        #endregion

        #region Fields

        private String bezeichnung;
        private DateTime debitorUpdate;
        private Boolean foundInAbacus;
        private String klassierung;
        private Int32? klientenkontoNr;
        private Boolean klientenkontoNrChanged;
        private String typ;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor - create a new instance using DataRow from KiSS
        /// </summary>
        /// <param name="row">The DataRow that contains the desired KiSS data</param>
        public Konto(DataRow row)
        {
            // validate row
            if (row == null)
            {
                throw new ArgumentNullException("row", "The given DataRow is emtpy, cannot create a new account instance.");
            }

            // set data from datarow
            this.klientenkontoNr = DataHandler.GetInt32Value(row, Constants.colKlientenkontoNr);
            this.SetKontoBezeichnung(DataHandler.GetStringValue(row, Constants.colName),
                                     DataHandler.GetStringValue(row, Constants.colVorname),
                                     DataHandler.GetStringValue(row, Constants.colWohnsitzPLZ),
                                     DataHandler.GetStringValue(row, Constants.colWohnsitzOrt));
            this.klassierung = String.Format("5{0:000}{1:00000}", DataHandler.GetInt32Value(row, Constants.colKostenstelle), DataHandler.GetInt32Value(row, Constants.colMitarbeiterNr));
            this.debitorUpdate = DBUtil.IsEmpty(row[Constants.colDebitorUpdate]) ? DateTime.MinValue : Convert.ToDateTime(row[Constants.colDebitorUpdate]);
            this.typ = KONTENTYPKOSTENTRAEGER;
            this.foundInAbacus = false;
        }

        /// <summary>
        /// Constructor - create a new instance using webservice-response from Abacus
        /// </summary>
        /// <param name="response">The webservice-response from Abacus that contains the desired data</param>
        public Konto(ResponseType response)
        {
            // check if we have a valid response and data
            if (response == null)
            {
                throw new ArgumentNullException("response", "The response itself is not valid, cannot continue creating a new Konto.");
            }
            else if (response.DataContainer == null)
            {
                throw new ArgumentNullException("response.DataContainer", "The response does not have a valid DataContainer[0], cannot continue creating a new Konto.");
            }
            else if (response.DataContainer[0].Element == null)
            {
                throw new ArgumentNullException("response.DataContainer", "The response does not have a valid DataContainer.Element, cannot continue creating a new Konto.");
            }
            else if (response.DataContainer[0].Element.CostCentreElement == null)
            {
                throw new ArgumentNullException("response.DataContainer", "The response does not have a valid DataContainer.Element.CostCenterElement, cannot continue creating a new Konto.");
            }
            else if (response.DataContainer[0].Element.CostCentreElement[0] == null)
            {
                throw new ArgumentNullException("response.DataContainer", "The response does not have a valid DataContainer.Element.CostCenterElement[0], cannot continue creating a new Konto.");
            }

            // get data from response
            CostCentreElementComType abaCostCenter = response.DataContainer[0].Element.CostCentreElement[0];
            this.bezeichnung = abaCostCenter.Name; // do not handle using SetKontoBezeichnung because it comes from Abacus!
            this.klassierung = Convert.ToString(Convert.ToInt32(abaCostCenter.Reference));	// required to be casted first as Int32 (otherwise, it would have "xxx.00" from abacus)
            this.typ = KONTENTYPKOSTENTRAEGER;

            // check if item contains a valid Idendification (=KlientenkontoNr), used for matching with KiSS-data
            if (response.DataContainer[0].Element.CostCentreElement[0].IdentificationSpecified)
            {
                // apply given KlientenkontoNr and a minimal date
                this.klientenkontoNr = Convert.ToInt32(response.DataContainer[0].Element.CostCentreElement[0].Identification);
                this.debitorUpdate = DateTime.MinValue;
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Get the Bezeichung of the Konto
        /// </summary>
        public String Bezeichnung
        {
            get { return this.bezeichnung; }
        }

        /// <summary>
        /// Get the DebitorUpdate date of last update within KiSS
        /// </summary>
        public DateTime DebitorUpdate
        {
            get { return this.debitorUpdate; }
        }

        /// <summary>
        /// Get flag if Konto was found in current Mandant within Abacus
        /// </summary>
        public Boolean FoundInAbacus
        {
            get { return this.foundInAbacus; }
        }

        /// <summary>
        /// Get the Klassierung of the Konto
        /// </summary>
        public String Klassierung
        {
            get { return this.klassierung; }
        }

        /// <summary>
        /// Get the KlientenkontoNr of the Konto
        /// </summary>
        public Int32? KlientenkontoNr
        {
            get { return this.klientenkontoNr; }
        }

        /// <summary>
        /// Get flag if KlientenkontoNr was changed within processing this Konto
        /// </summary>
        public Boolean KlientenkontoNrChanged
        {
            get { return this.klientenkontoNrChanged; }
        }

        /// <summary>
        /// Get the Typ of the Konto
        /// </summary>
        public String Typ
        {
            get { return this.typ; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Determines whether [is equal as] [the specified comparing konto].
        /// </summary>
        /// <param name="comparingKonto">The comparing konto.</param>
        /// <returns>
        /// 	<c>true</c> if [is equal as] [the specified comparing konto]; otherwise, <c>false</c>.
        /// </returns>
        public Boolean Equals(Konto comparingKonto)
        {
            // validate parameter
            if (comparingKonto == null)
            {
                // no Konto given, cannot compare
                return false;
            }

            // Konto is equal if Bezeichnung and Klassierung are the same
            return (this.Bezeichnung.Equals(comparingKonto.Bezeichnung) && this.Klassierung.Equals(comparingKonto.Klassierung));
        }

        /// <summary>
        /// Sets the found in abacus flag to determine if Konto was found in current Mandant in Abacus
        /// </summary>
        public void SetFoundInAbacus()
        {
            this.foundInAbacus = true;
        }

        /// <summary>
        /// Set new KlientenkontoNr to this Klient
        /// </summary>
        /// <param name="klientenkontoNumber">The new KlientenkontoNr to apply</param>
        public void SetKlientenkontoNummer(Int32 klientenkontoNumber)
        {
            // validate range of given number
            if (klientenkontoNumber < 30000000 || klientenkontoNumber > 40000000)
            {
                throw new ArgumentOutOfRangeException("The given 'KlientenkontoNr' is out of range. Valid numbers are between 30'000'000 and 39'999'999.");
            }

            // apply number
            this.klientenkontoNr = klientenkontoNumber;

            // set flag: number has changed! used to set save() mode
            this.klientenkontoNrChanged = true;
        }

        /// <summary>
        /// Returns a System.String that represents the current System.Object
        /// </summary>
        /// <returns>Returns a System.String that represents the current System.Object</returns>
        public override string ToString()
        {
            // return string that represents the account (e.g. for logging)
            return String.Format(@"KlientenkontoNr='{0}', DebitorUpdate='{1}', Typ='{2}', Bezeichnung='{3}', Klassierung='{4}', FoundInAbacus='{5}', KlientenkontoNrChanged='{6}'",
                                  this.KlientenkontoNr,			// 0
                                  this.DebitorUpdate,		// 1
                                  this.Typ,					// 2
                                  this.Bezeichnung,			// 3
                                  this.Klassierung,			// 4
                                  this.FoundInAbacus,		// 5
                                  this.klientenkontoNrChanged);	// 6
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Set Konto.Bezeichnung as given by rules ("Name Vorname, PLZ Ort")
        /// > if Length > 40 Chars, then shorten "Name Vorname" to 19 Chars and "PLZ Ort" to 19 Chars (19+19+", "=40)
        /// </summary>
        /// <param name="name">The lastname of the client</param>
        /// <param name="vorname">The firstname of the client</param>
        /// <param name="wohnsitzPLZ">The WohnsitzPLZ of the client</param>
        /// <param name="wohnsitzOrt">The WohnsitzOrt of the client</param>
        private void SetKontoBezeichnung(String name, String vorname, String wohnsitzPLZ, String wohnsitzOrt)
        {
            // get empty flags
            Boolean noName = DBUtil.IsEmpty(name);
            Boolean noVorname = DBUtil.IsEmpty(vorname);
            Boolean noWohnsitzPLZ = DBUtil.IsEmpty(wohnsitzPLZ);
            Boolean noWohnsitzOrt = DBUtil.IsEmpty(wohnsitzOrt);

            // validate parameters
            if (noName && noVorname && noWohnsitzPLZ && noWohnsitzOrt)
            {
                // no valid content to apply, no Bezeichnung possible
                throw new ArgumentNullException("Empty parameters received, cannot apply empty account description.");
            }

            // if only first part or only second part is given
            if (noName && noVorname)
            {
                // no Name/Vorname, apply just PLZ/Ort
                this.bezeichnung = String.Format("{0} {1}", wohnsitzPLZ, wohnsitzOrt).Trim();
            }
            else if (noWohnsitzPLZ && noWohnsitzOrt)
            {
                // no PLZ/Ort, apply just Name/Vorname
                this.bezeichnung = String.Format("{0} {1}", name, vorname).Trim();
            }
            else
            {
                // apply Bezeichnung as "Name Vorname, PLZ Ort"
                this.bezeichnung = String.Format("{0} {1}, {2} {3}", name, vorname, wohnsitzPLZ, wohnsitzOrt).Trim();
            }

            // Bezeichung has to be maxium 40 chars (restriction because of Abacus)
            if (this.bezeichnung.Length > 40)
            {
                // shorten and set parts:

                // if only first part or only second part is given
                if (noName && noVorname)
                {
                    // no Name/Vorname, apply just PLZ/Ort as MAX 40
                    this.bezeichnung = WebServiceHelper.ShortenStringToMaxLength(String.Format("{0} {1}", wohnsitzPLZ, wohnsitzOrt).Trim(), 40);
                }
                else if (noWohnsitzPLZ && noWohnsitzOrt)
                {
                    // no PLZ/Ort, apply just Name/Vorname as MAX 40
                    this.bezeichnung = WebServiceHelper.ShortenStringToMaxLength(String.Format("{0} {1}", name, vorname).Trim(), 40);
                }
                else
                {
                    // apply Bezeichnung and then check afterwards if length has to be handled
                    this.bezeichnung = String.Format("{0}, {1}", WebServiceHelper.ShortenStringToMaxLength(String.Format("{0} {1}", name, vorname).Trim(), 19),
                                                                 WebServiceHelper.ShortenStringToMaxLength(String.Format("{0} {1}", wohnsitzPLZ, wohnsitzOrt).Trim(), 19));
                }
            }
        }

        #endregion
    }
}