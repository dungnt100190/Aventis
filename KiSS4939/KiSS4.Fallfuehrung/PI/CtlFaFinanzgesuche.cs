using System;
using System.Drawing;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fallfuehrung.PI
{
    public partial class CtlFaFinanzgesuche : KissUserControl
    {
        #region Fields

        #region Private Static Fields

        /// The Log4Net logger.
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        private int _baPersonID = -1;
        private bool _hasAutorChanged;

        #endregion

        #endregion

        #region Constructors

        public CtlFaFinanzgesuche()
        {
            InitializeComponent();

            // init with default values
            Init(null, null, -1);
        }

        #endregion

        #region EventHandlers

        private void edtAutor_EditValueChanged(object sender, EventArgs e)
        {
            _hasAutorChanged = true;
        }

        private void edtAutor_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            e.Cancel = !DialogAutor(e);
        }

        private void qryFaFinanzgesuche_AfterInsert(object sender, EventArgs e)
        {
            // apply person id
            qryFaFinanzgesuche["BaPersonID"] = _baPersonID;

            // apply default values
            qryFaFinanzgesuche["Autor"] = Session.User.LastFirstName;
            qryFaFinanzgesuche["UserID"] = Session.User.UserID;

            edtDatum.Focus();
        }

        private void qryFaFinanzgesuche_AfterPost(object sender, EventArgs e)
        {
            // apply lookup fields
            qryFaFinanzgesuche["Dokumenttyp"] = edtDokumenttyp.Text;
            qryFaFinanzgesuche["BeantragtSFr"] = edtBeantragterBetrag.Text.Replace("'", "");
            qryFaFinanzgesuche["BewilligtSFr"] = edtBewilligterBetrag.Text.Replace("'", "");
        }

        private void qryFaFinanzgesuche_BeforePost(object sender, EventArgs e)
        {
            // validate required fields
            DBUtil.CheckNotNullField(edtDatum, lblDatum.Text);
            DBUtil.CheckNotNullField(edtAutor, lblAutor_V01.Text);

            // validate buttonedits
            if (_hasAutorChanged && !DialogAutor(new UserModifiedFldEventArgs(false, false)))
            {
                // invalid Autor
                edtAutor.Focus();
                throw new KissCancelException();
            }

            // reset flags
            _hasAutorChanged = false;
        }

        private void qryFaFinanzgesuche_PositionChanged(object sender, EventArgs e)
        {
            _hasAutorChanged = false;
        }

        private void qryGvDokumenteInformation_AfterInsert(object sender, EventArgs e)
        {
            qryGvDokumenteInformation[DBO.GvDokumenteInformation.BaPersonID] = _baPersonID;
        }

        #endregion

        #region Methods

        #region Public Methods

        public override Object GetContextValue(String fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "FAFINANZGESUCHEID":
                    return qryFaFinanzgesuche["FaFinanzgesucheID"];

                case "BAPERSONID":
                    return _baPersonID;
            }

            return base.GetContextValue(fieldName);
        }

        /// <summary>
        /// Init control for usage
        /// </summary>
        /// <param name="titleName">The title to show</param>
        /// <param name="titleImage">The image to show near title</param>
        /// <param name="baPersonID">The person's id to use for dataaccess</param>
        public void Init(String titleName, Image titleImage, Int32 baPersonID)
        {
            // apply values
            _baPersonID = baPersonID;
            picTitel.Image = titleImage;
            lblTitel.Text = titleName;

            qryGvDokumenteInformation.Fill(@"
                SELECT
                  GDI.GvDokumenteInformationID,
                  GDI.BaPersonID,
                  GDI.Information,
                  GDI.Creator,
                  GDI.Created,
                  GDI.Modifier,
                  GDI.Modified
                FROM dbo.GvDokumenteInformation GDI WITH(READUNCOMMITTED)
                WHERE GDI.BaPersonID = {0};", baPersonID);

            if (qryGvDokumenteInformation.IsEmpty && qryGvDokumenteInformation.CanInsert)
            {
                qryGvDokumenteInformation.Insert();
            }

            var hasKompetenzstufe0 = DBUtil.UserHasRight("CtlGvGesuchverwaltung_Kompetenzstufe0");
            var hasKompetenzstufe1 = DBUtil.UserHasRight("CtlGvGesuchverwaltung_Kompetenzstufe1");
            var hasKompetenzstufe2 = DBUtil.UserHasRight("CtlGvGesuchverwaltung_Kompetenzstufe2");

            edtInformation.EditMode = hasKompetenzstufe0 || hasKompetenzstufe1 || hasKompetenzstufe2 ? EditModeType.Normal : EditModeType.ReadOnly;

            qryBaPerson.Fill(@"
                SELECT PRS.BaPersonID,
                       PRS.KontoFuehrung,
                       PRS.KlientenkontoNr
                FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
                WHERE PRS.BaPersonID = {0};", baPersonID);

            qryFaFinanzgesuche.Fill(@"
                DECLARE @BaPersonID INT
                DECLARE @LanguageCode INT

                SET @BaPersonID = {0}
                SET @LanguageCode = ISNULL({1}, 1)

                SELECT FIN.*,
                       BeantragtSFr = ISNULL('SFr. ' + CONVERT(VARCHAR(50), FIN.Beantragt), ''),
                       BewilligtSFr = ISNULL('SFr. ' + CONVERT(VARCHAR(50), FIN.BewilligterBetrag), ''),
                       Autor        = dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName),
                       Dokumenttyp  = dbo.fnGetLOVMLText('FaGesuchDokumenttyp', FIN.DokumenttypCode, @LanguageCode),
                       Status       = dbo.fnGetLOVMLText('FaGesuchStatus', FIN.StatusCode, @LanguageCode)
                FROM dbo.FaFinanzgesuche FIN WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.XUser    USR WITH (READUNCOMMITTED) ON USR.UserID = FIN.UserID
                WHERE FIN.BaPersonID = @BaPersonID
                ORDER BY FIN.Datum ASC;", baPersonID, Session.User.LanguageCode);

            qryFaFinanzgesuche.Last();

            // reset flags
            _hasAutorChanged = false;

            // update fields
            qryBaPerson.EnableBoundFields(qryBaPerson.CanUpdate);
            qryFaFinanzgesuche.EnableBoundFields();

            // show KlientenkontoNr-Nr.
            if (DBUtil.IsEmpty(qryBaPerson["KlientenkontoNr"]))
            {
                // no number
                lblKlientenkontoNr.Text = "";
            }
            else
            {
                // has number
                lblKlientenkontoNr.Text = String.Format("{0}: {1}", KissMsg.GetMLMessage("CtlFaFinanzgesuche", "LabelKlientenkontoNr", "Klientenkonto-Nr"), qryBaPerson["KlientenkontoNr"]);
            }
        }

        public override bool OnSaveData()
        {
            return qryGvDokumenteInformation.Post() && base.OnSaveData();
        }

        public override void Translate()
        {
            // let base do stuff
            base.Translate();

            try
            {
                // set dropdown list (see: #5082)
                edtDokumenttyp.Properties.DropDownRows = Math.Min(((SqlQuery)edtDokumenttyp.Properties.DataSource).Count, 14);
            }
            catch (Exception ex)
            {
                // logging
                _log.Warn("exception occured while setting dropdownrows property", ex);
            }
        }

        #endregion

        #region Private Methods

        private bool DialogAutor(UserModifiedFldEventArgs e)
        {
            try
            {
                // check if data can be altered
                if (!qryFaFinanzgesuche.CanUpdate || qryFaFinanzgesuche.Count < 1 || edtAutor.EditMode == EditModeType.ReadOnly)
                {
                    // do nothing
                    return true;
                }

                // prepare search string
                String searchString = "";

                // check if we have a value to parse
                if (!DBUtil.IsEmpty(edtAutor.EditValue))
                {
                    // prepare for database search
                    searchString = edtAutor.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%").Replace("'", "''");
                }

                // validate search string
                if (DBUtil.IsEmpty(searchString))
                {
                    if (e.ButtonClicked)
                    {
                        // if no data entered and the button is clicked, show dialog with all data
                        searchString = "%";
                    }
                    else
                    {
                        qryFaFinanzgesuche["UserID"] = DBNull.Value;
                        qryFaFinanzgesuche["Autor"] = DBNull.Value;
                        return true;
                    }
                }

                // Mitarbeiter_Suchen()
                KissLookupDialog dlg = new KissLookupDialog();

                e.Cancel = !dlg.SearchData(String.Format(@"
                    SELECT USR.*
                    FROM dbo.fnDlgMitarbeiterSuchenKGS({0}) USR
                    WHERE USR.Name LIKE '{1}%'", Session.User.UserID, searchString), searchString, e.ButtonClicked, null, null, null);

                if (!e.Cancel)
                {
                    // apply new value
                    qryFaFinanzgesuche["UserID"] = dlg["UserID$"];
                    qryFaFinanzgesuche["Autor"] = dlg["Name"];

                    // reset flag
                    _hasAutorChanged = false;

                    // success
                    return true;
                }

                // canceled or error
                return false;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("CtlFaFinanzgesuche", "ErrorIKissUserModified_v01", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
                return false;
            }
        }

        #endregion

        #endregion
    }
}