using System;
using System.Data;
using System.Drawing;

using KiSS4.Common.PI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Entlastungsdienst
{
    /// <summary>
    /// Control, used for managing ED/Auswertungsdaten
    /// </summary>
    public partial class CtlEdAuswertungsdaten : KissUserControl
    {
        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private int _faLeistungID = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlEdAuswertungsdaten"/> class.
        /// </summary>
        public CtlEdAuswertungsdaten()
        {
            // init components
            InitializeComponent();

            // init with default values
            Init(null, null, -1, false);
        }

        /// <summary>
        /// Get value for given <paramref name="fieldName"/> and context
        /// </summary>
        /// <param name="fieldName">The fieldname to use for getting data</param>
        /// <returns>The requested data if any found for given <paramref name="fieldName"/></returns>
        public override object GetContextValue(string fieldName)
        {
            // logging
            _logger.Debug("call");
            _logger.DebugFormat("fieldName='{0}'", fieldName);

            // get value depending on fieldName
            switch (fieldName.ToUpper())
            {
                case "EDAUSWERTUNGSDATENID":
                    // check if we have an entry
                    if (qryEdAuswertungsdaten.Count < 1)
                    {
                        return -1;
                    }

                    // get current value
                    return qryEdAuswertungsdaten["EdAuswertungsdatenID"];

                case "EDEINSATZVEREINBARUNGID":
                    // get id of FaBetreuungsinfoID with same BaPersonID
                    return FaUtils.GetEdEinsatzvereinbarungID(_faLeistungID);

                case "FABETREUUNGSINFOID":
                    // get id of FaBetreuungsinfoID with same BaPersonID
                    return FaUtils.GetFaBetreuungsinfoID(Convert.ToInt32(GetContextValue("BaPersonID")));

                case "FALEISTUNGID":
                    // get current value
                    return _faLeistungID;

                case "BAPERSONID":
                    // check if we have an entry
                    if (qryEdAuswertungsdaten.Count < 1)
                    {
                        return -1;
                    }

                    // get current value
                    return qryEdAuswertungsdaten["BaPersonID"];
            }

            // let base return value
            return base.GetContextValue(fieldName);
        }

        /// <summary>
        /// Init the control depending on given parameter values
        /// </summary>
        /// <param name="titleName">The title to show (will not be applied)</param>
        /// <param name="titleImage">The icon to show in title</param>
        /// <param name="faLeistungID">The id of the FaLeistung table used for identification of data</param>
        /// <param name="isLeistungClosed">Flag if entry in FaLeistung is already closed</param>
        public void Init(string titleName, Image titleImage, int faLeistungID, bool isLeistungClosed)
        {
            // validate
            if (faLeistungID < 1)
            {
                // do not continue
                qryEdAuswertungsdaten.CanUpdate = false;
                qryEdAuswertungsdaten.EnableBoundFields(qryEdAuswertungsdaten.CanUpdate);
                return;
            }

            // allow changes
            qryEdAuswertungsdaten.CanUpdate = !isLeistungClosed;

            // apply values
            _faLeistungID = faLeistungID;
            picTitel.Image = titleImage;
            //lblTitel.Text	= titleName;

            // fill data
            qryEdAuswertungsdaten.Fill(@"
                SELECT EDA.*,
                       LEI.BaPersonID
                FROM dbo.EdAuswertungsdaten EDA WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.FaLeistung  LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = EDA.FaLeistungID
                WHERE EDA.FaLeistungID = {0}", faLeistungID);

            // insert new entry if not yet any entry found
            if (qryEdAuswertungsdaten.CanUpdate && qryEdAuswertungsdaten.Count < 1)
            {
                qryEdAuswertungsdaten.Insert(null);
            }

            // set colors
            SetupColorRequiredFields();
        }

        /// <summary>
        /// Refreshes all required data
        /// </summary>
        public override void OnRefreshData()
        {
            // let base do stuff
            base.OnRefreshData();

            // setup colors
            SetupColorRequiredFields();
        }

        public override bool OnSaveData()
        {
            var stateAdded = qryEdAuswertungsdaten.CurrentRowState == DataRowState.Added;
            var result = base.OnSaveData();
            if (result && stateAdded)
            {
                //sicherstellen, dass Spalten via JOIN geladen sind
                qryEdAuswertungsdaten.Refresh();
            }
            return result;
        }

        /// <summary>
        /// Setup and refresh color for required fields
        /// </summary>
        public void SetupColorRequiredFields()
        {
            // check if we have a valid id
            if (_faLeistungID < 1)
            {
                // do nothing
                return;
            }

            // edtLetzteStandortbestimmung is always mustfield or readonly
            BaUtils.SetupColorOfRequiredFields(edtLetzteStandortbestimmung, qryEdAuswertungsdaten.CanUpdate);
        }

        private void qryEdAuswertungsdaten_AfterInsert(object sender, EventArgs e)
        {
            // apply person id
            qryEdAuswertungsdaten["FaLeistungID"] = _faLeistungID;

            // creator of row
            qryEdAuswertungsdaten.SetCreator();
        }

        private void qryEdAuswertungsdaten_BeforePost(object sender, EventArgs e)
        {
            // validate amount of siblings
            if (!DBUtil.IsEmpty(qryEdAuswertungsdaten["AnzahlGeschwister"]))
            {
                // get current value
                int anzahlGeschwister = Convert.ToInt32(qryEdAuswertungsdaten["AnzahlGeschwister"]);

                // check 0..99
                if (anzahlGeschwister < 0 || anzahlGeschwister > 99)
                {
                    // set focus
                    edtAnzahlGeschwister.Focus();

                    // show message
                    KissMsg.ShowInfo(Name, "NegativeAmountSiblings", "Die Anzahl Geschwister kann nicht negativ oder grösser als 99 sein.");

                    // do not continue
                    throw new KissCancelException();
                }
            }

            // check mustfields
            DBUtil.CheckNotNullField(edtLetzteStandortbestimmung, lblLetzteStandortbestimmung.Text);

            // apply modification
            qryEdAuswertungsdaten.SetModifierModified();
        }
    }
}