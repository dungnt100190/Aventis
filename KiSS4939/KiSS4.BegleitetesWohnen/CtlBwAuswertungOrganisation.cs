using System;
using System.Data;
using System.Drawing;

using KiSS4.Common.PI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.BegleitetesWohnen
{
    /// <summary>
    /// Control, used for evaluation and organisation of BW
    /// </summary>
    public partial class CtlBwAuswertungOrganisation : KissUserControl
    {
        private int _faLeistungId = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlBwAuswertungOrganisation"/> class.
        /// </summary>
        public CtlBwAuswertungOrganisation()
        {
            InitializeComponent();
            Init(null, null, -1, false);
        }

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "BWAUSWERTUNGORGANISATIONID":
                    // check if we have an entry
                    if (qryBwAuswertungOrganisation.Count < 1)
                    {
                        return -1;
                    }

                    // get current value
                    return qryBwAuswertungOrganisation["BwAuswertungOrganisationID"];

                case "BWEINSATZVEREINBARUNGID":
                    // get id of FaBetreuungsinfoID with same BaPersonID
                    return FaUtils.GetBwEinsatzvereinbarungID(_faLeistungId);

                case "FALEISTUNGID":
                    // get current value
                    return _faLeistungId;

                case "BAPERSONID":
                    // check if we have an entry
                    if (qryBwAuswertungOrganisation.Count < 1)
                    {
                        return -1;
                    }

                    // get current value
                    return qryBwAuswertungOrganisation["BaPersonID"];
            }

            // let base do stuff
            return base.GetContextValue(fieldName);
        }

        /// <summary>
        /// Init control with given data
        /// </summary>
        /// <param name="titleName">The titlename (won't be displayed)</param>
        /// <param name="titleImage">The title image to display in title panel</param>
        /// <param name="faLeistungId">The id of the FaLeistung entry of the given person</param>
        /// <param name="isLeistungClosed"><c>True</c> if entry in FaLeistung is closed and therefore cannot be edited, otherwise <c>False</c></param>
        public void Init(string titleName, Image titleImage, int faLeistungId, bool isLeistungClosed)
        {
            // validate
            if (faLeistungId < 1)
            {
                qryBwAuswertungOrganisation.CanUpdate = false;
                qryBwAuswertungOrganisation.EnableBoundFields(qryBwAuswertungOrganisation.CanUpdate);
                return;
            }

            // set update-mode
            qryBwAuswertungOrganisation.CanUpdate = !isLeistungClosed;

            // apply values
            picTitel.Image = titleImage;
            _faLeistungId = faLeistungId;

            // fill data
            qryBwAuswertungOrganisation.Fill(@"
                SELECT BAO.BwAuswertungOrganisationID,
                       BAO.FaLeistungID,
                       BAO.AuswertungAm,
                       BAO.ZieleErreicht,
                       BAO.ZieleBegruendung,
                       KostenHELBVerfuegung = CONVERT(BIT, CASE WHEN PRS.HilfslosenEntschaedigungCode IN (4, 5) THEN 1 ELSE 0 END), -- 'leb. Begl.' / 'Leichte HE + HELB'
                       BAO.KostenELEmpfaenger,
                       BAO.KostenBSVBeitrag,
                       BAO.KostenSelbstzahler,
                       BAO.AbwesenheitKlient,
                       BAO.LeistungIstBefristet,
                       BAO.BefristetBis,
                       BAO.BwEintrittVonCode,
                       BAO.BwAustrittNachCode,
                       BAO.Vereinbarungen,
                       BAO.KostenBeitragKanton,
                       BAO.KostenBeitragPI,
                       BAO.KostenWeitereBeitraege,
                       BAO.Creator,
                       BAO.Created,
                       BAO.Modifier,
                       BAO.Modified,
                       BAO.BwAuswertungOrganisationTS,
                       --
                       ZustaendigBW = dbo.fnGetLastFirstName(LEI.UserID, NULL, NULL),
                       BwTypCode    = ESV.BwTypCode,
                       ErstellungEV = ESV.ErstellungEV,
                       Ziele        = ESV.Ziele,
                       BaPersonID   = LEI.BaPersonID
                FROM dbo.BwAuswertungOrganisation      BAO WITH (READUNCOMMITTED)
                  INNER JOIN dbo.FaLeistung            LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = BAO.FaLeistungID
                  INNER JOIN dbo.BaPerson              PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
                  LEFT  JOIN dbo.BwEinsatzvereinbarung ESV WITH (READUNCOMMITTED) ON ESV.FaLeistungID = BAO.FaLeistungID
                WHERE BAO.FaLeistungID = {0};", _faLeistungId);

            // insert new entry if not yet any entry found
            if (qryBwAuswertungOrganisation.CanUpdate && qryBwAuswertungOrganisation.Count < 1)
            {
                qryBwAuswertungOrganisation.Insert(null);
            }
        }

        public override bool OnSaveData()
        {
            var stateAdded = qryBwAuswertungOrganisation.CurrentRowState == DataRowState.Added;
            var result = base.OnSaveData();
            if (result && stateAdded)
            {
                //sicherstellen, dass Spalten via JOIN geladen sind
                qryBwAuswertungOrganisation.Refresh();
            }
            return result;
        }

        private void qryBwAuswertungOranisation_AfterInsert(object sender, EventArgs e)
        {
            // apply default values
            qryBwAuswertungOrganisation["FaLeistungID"] = _faLeistungId;

            // set creator
            qryBwAuswertungOrganisation.SetCreator();

            // get data from BwEinsatzvereinbarung and FaLeistung
            var qryEv = DBUtil.OpenSQL(@"
                SELECT BwTypCode    = ESV.BwTypCode,
                       ZustaendigBW = dbo.fnGetLastFirstName(LEI.UserID, NULL, NULL),
                       ErstellungEV = ESV.ErstellungEV,
                       Ziele        = ESV.Ziele
                FROM dbo.BwEinsatzvereinbarung ESV WITH (READUNCOMMITTED)
                  INNER JOIN dbo.FaLeistung    LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = ESV.FaLeistungID
                WHERE ESV.FaLeistungID = {0};", _faLeistungId);

            if (qryEv.Count > 0)
            {
                qryBwAuswertungOrganisation["BwTypCode"] = qryEv["BwTypCode"];
                qryBwAuswertungOrganisation["ZustaendigBW"] = qryEv["ZustaendigBW"];
                qryBwAuswertungOrganisation["ErstellungEV"] = qryEv["ErstellungEV"];
                qryBwAuswertungOrganisation["Ziele"] = qryEv["Ziele"];
            }
        }

        private void qryBwAuswertungOranisation_BeforePost(object sender, EventArgs e)
        {
            // if "befristet bis" is chosen the date must be set
            if (Convert.ToBoolean(rgrKuendigung.EditValue))
            {
                DBUtil.CheckNotNullField(edtKuendigungBefristet, KissMsg.GetMLMessage(Name, "BefristetBis", "Befristet bis"));
            }

            // set modifier
            qryBwAuswertungOrganisation.SetModifierModified();
        }
    }
}