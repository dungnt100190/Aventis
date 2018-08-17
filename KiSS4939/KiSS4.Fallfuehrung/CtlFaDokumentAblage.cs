using System;
using System.Drawing;
using System.Windows.Forms;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using SharpLibrary.WinControls;

namespace KiSS4.Fallfuehrung
{
    public partial class CtlFaDokumentAblage : KissSearchUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CONTEXT_DOC = "FaDokumentAblage";
        private const string LOV_THEMA = "FaThemaDokAblage";

        #endregion

        #region Private Fields

        private int _baPersonID;
        private int _faLeistungID;

        #endregion

        #endregion

        #region Constructors

        public CtlFaDokumentAblage()
        {
            InitializeComponent();
            SetupDataMembers();
            SetupFieldNames();
            SetupTags();
            SetupContext();
        }

        #endregion

        #region EventHandlers

        private void CtlFaDokumentAblage_Load(object sender, EventArgs e)
        {
            gvwDokumente.OptionsView.ColumnAutoWidth = true;
        }

        private void edtBetroffenePersonen_EditValueChanged(object sender, EventArgs e)
        {
            if (edtBetroffenePersonen.UserModified)
            {
                // damit Änderungen bei den betroffenen Personen gespeichert werden
                qryFaDokumentAblage.RowModified = true;
            }
        }

        private void qryFaDokumentAblage_AfterDelete(object sender, EventArgs e)
        {
            if (Session.Transaction == null)
            {
                // wenn keine Transaktion vorhanden ist, dann dürfen weitere Updates nicht gemacht werden
                return;
            }

            try
            {
                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
            }
        }

        private void qryFaDokumentAblage_AfterFill(object sender, EventArgs e)
        {
            if (qryFaDokumentAblage.Count == 0)
            {
                // wenn keine Daten, wird PositionChanged nicht automatisch aufgerufen
                qryFaDokumentAblage_PositionChanged(null, null);
            }
        }

        private void qryFaDokumentAblage_AfterPost(object sender, EventArgs e)
        {
            if (Session.Transaction == null)
            {
                // wenn keine Transaktion vorhanden ist, dann dürfen weitere Updates nicht gemacht werden
                return;
            }

            try
            {
                // Auswahl betroffene Personen speichern
                SaveBetroffenePersonen();
                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
            }
        }

        private void qryFaDokumentAblage_BeforeDelete(object sender, EventArgs e)
        {
            Session.BeginTransaction();

            try
            {
                // Auswahl betroffene Personen auf DB löschen
                DeleteBetroffenePersonen();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
                throw new KissCancelException();
            }
        }

        private void qryFaDokumentAblage_PositionChanged(object sender, EventArgs e)
        {
            edtBetroffenePersonen.AllowEdit(!qryFaDokumentAblage.IsEmpty);

            // nach Zeilenwechsel: ganze Selektion neu anzeigen
            DisplayBetroffenePersonen();
        }

        private void qryFaDokumente_AfterInsert(object sender, EventArgs e)
        {
            qryFaDokumentAblage[DBO.FaDokumentAblage.FaLeistungID] = _faLeistungID;
            qryFaDokumentAblage[DBO.FaDokumentAblage.DatumErstellung] = DateTime.Today;
            qryFaDokumentAblage[DBO.FaDokumentAblage.UserID] = Session.User.UserID;
            qryFaDokumentAblage.SetCreator();
            edtDatumErstellung.Focus();

            // Betroffene Personen neu anzeigen
            DisplayBetroffenePersonen();
        }

        private void qryFaDokumente_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtDatumErstellung, lblDatumErstellung.Text);

            Session.BeginTransaction();

            try
            {
                qryFaDokumentAblage.SetModifierModified();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
                throw new KissCancelException();
            }
        }

        private void tabControlSearch_SelectedTabChanged(TabPageEx page)
        {
            if (tabControlSearch.SelectedTab == tpgListe)
            {
                panelDetail.Enabled = true;
            }
            else
            {
                panelDetail.Enabled = false;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "USERID":
                    return Session.User.UserID;

                case "OWNERUSERID":
                    return Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                        SELECT UserID
                        FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                        WHERE FaLeistungID = {0};", qryFaDokumentAblage["FaLeistungID"]));

                case "FT":
                    return DBUtil.ExecuteScalarSQL(@"
                        SELECT FAL.BaPersonID
                        FROM dbo.FaFall FAL
                          INNER JOIN dbo.FaLeistung LEI ON LEI.FaFallID = FAL.FaFallID
                        WHERE LEI.FaLeistungID = {0};", qryFaDokumentAblage["FaLeistungID"]);

                case "FALLUSERID":
                    return DBUtil.ExecuteScalarSQL(@"
                        SELECT FAL.UserID
                        FROM dbo.FaFall FAL
                          INNER JOIN dbo.FaLeistung LEI ON LEI.FaFallID = FAL.FaFallID
                        where LEI.FaLeistungID = {0};", qryFaDokumentAblage["FaLeistungID"]);
            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string maskName, Image maskImage, int baPersonID, int faLeistungID)
        {
            _faLeistungID = faLeistungID;
            _baPersonID = baPersonID;
            lblTitle.Text = maskName;
            imageTitle.Image = maskImage;

            LoadBetroffenepersonen();

            NewSearchAndRun();
        }

        public override void OnRefreshData()
        {
            // bei den Namen der betroffenen Personen soll auch ein Refresh gemacht werden
            LoadBetroffenepersonen();

            base.OnRefreshData();
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();
            edtDatumErstellung.Focus();

            var qry = DBUtil.OpenSQL(GetSQLBetroffenePersonen(true, _baPersonID, _faLeistungID));
            edtPersonSuche.LoadQuery(qry);
            edtPersonSuche.Properties.DropDownRows = Math.Min(qry.Count, 14);
        }

        /// <summary>
        /// Führt eine neue Suche aus.
        /// </summary>
        protected void NewSearchAndRun()
        {
            NewSearch();
            tabControlSearch.SelectTab(tpgListe);
        }

        /// <summary>
        /// Führt die Suche aus.  Hier werden dem Query die Parameter übergeben
        /// {0}, {1} ...
        /// </summary>
        protected override void RunSearch()
        {
            kissSearch.SelectParameters = new object[] { _faLeistungID };
            base.RunSearch();
        }

        #endregion

        #region Private Static Methods

        private static string GetSQLBetroffenePersonen(bool emptyEntry, int baPersonID, int faLeistungID)
        {
            return string.Format(@"
                DECLARE @CurrentIDsCSV VARCHAR(255);
                DECLARE @EmptyEntry    BIT;
                DECLARE @FaLeistungID  INT;
                DECLARE @BaPersonID    INT;

                DECLARE @TmpOutput TABLE
                (
                    Code INT NULL UNIQUE,
                    Text VARCHAR(255) NOT NULL
                );

                SELECT @EmptyEntry   = {0},
                       @FaLeistungID = {1},
                       @BaPersonID   = {2};

                -- Suche von Personen die bereits an Dokumente zugewiesen worden sind
                SELECT @CurrentIDsCSV = STUFF((SELECT DISTINCT
                                                 ', ' + CONVERT(VARCHAR, DAP.BaPersonID)
                                               FROM dbo.FaDokumentAblage                 DKA WITH (READUNCOMMITTED)
                                                 LEFT JOIN dbo.XUser                     USR WITH (READUNCOMMITTED) ON USR.UserId = DKA.UserID
                                                 LEFT JOIN dbo.FaDokumentAblage_BaPerson DAP WITH (READUNCOMMITTED) ON DAP.FaDokumentAblageID = DKA.FaDokumentAblageID
                                               WHERE DKA.FaLeistungID = @FaLeistungID
                                               FOR XML PATH('')),
                                               1, 2, '');

                IF (@EmptyEntry = 1)
                BEGIN
                    INSERT INTO @TmpOutput (Code, Text)
                      SELECT Code = NULL,
                             Text = '';
                END;

                -- Suche von Personen im Klientensystem
                INSERT INTO @TmpOutput (Code, Text)
                  SELECT FCN.Code,
                         FCN.Text
                  FROM dbo.fnFaGetBeteiligtePersonenInstitutionen(@BaPersonID, @CurrentIDsCSV) FCN
                  WHERE Code > 0; -- Nur die Personen anzeigen, keine Institution

                -- Output
                SELECT Code, Text
                FROM @TmpOutput
                ORDER BY CASE
                           WHEN Code IS NULL THEN 0
                           ELSE 1
                         END,
                         Text;", DBUtil.SqlLiteral(emptyEntry), DBUtil.SqlLiteral(faLeistungID), DBUtil.SqlLiteral(baPersonID));
        }

        #endregion

        #region Private Methods

        private void DeleteBetroffenePersonen()
        {
            // Alle betroffenen Personen löschen
            DBUtil.ExecSQLThrowingException(@"
                DELETE
                FROM dbo.FaDokumentAblage_BaPerson
                WHERE FaDokumentAblageID = {0};", qryFaDokumentAblage[DBO.FaDokumentAblage.FaDokumentAblageID]
            );
        }

        private void DisplayBetroffenePersonen()
        {
            // neuste Daten aus der DB holen
            qryFaDokumentAblage_BaPerson.Fill(qryFaDokumentAblage[DBO.FaDokumentAblage.FaDokumentAblageID]);

            for (var i = 0; i < edtBetroffenePersonen.ItemCount; i++)
            {
                edtBetroffenePersonen.Items[i].CheckState =
                    qryFaDokumentAblage_BaPerson.Find("BaPersonID=" + edtBetroffenePersonen.GetCodeFromItem(i)) ?
                        CheckState.Checked :
                        CheckState.Unchecked;
            }
        }

        private void LoadBetroffenepersonen()
        {
            edtBetroffenePersonen.LookupSQL = GetSQLBetroffenePersonen(false, _baPersonID, _faLeistungID);
        }

        private void SaveBetroffenePersonen()
        {
            // für die ganze Liste kontrollieren, ob ein Eintrab hinzugefügt oder gelöscht werden muss
            for (var i = 0; i < edtBetroffenePersonen.ItemCount; i++)
            {
                switch (edtBetroffenePersonen.Items[i].CheckState)
                {
                    case CheckState.Checked:
                        if (!qryFaDokumentAblage_BaPerson.Find("BaPersonID=" + edtBetroffenePersonen.GetCodeFromItem(i)))
                        {
                            qryFaDokumentAblage_BaPerson.Insert();
                            qryFaDokumentAblage_BaPerson[DBO.FaDokumentAblage_BaPerson.BaPersonID] =
                                Convert.ToInt32(edtBetroffenePersonen.GetCodeFromItem(i));
                            qryFaDokumentAblage_BaPerson[DBO.FaDokumentAblage_BaPerson.FaDokumentAblageID] =
                                qryFaDokumentAblage[DBO.FaDokumentAblage.FaDokumentAblageID];
                            qryFaDokumentAblage_BaPerson.Post();
                        }

                        break;

                    case CheckState.Unchecked:
                        if (qryFaDokumentAblage_BaPerson.Find("BaPersonID=" + edtBetroffenePersonen.GetCodeFromItem(i)))
                        {
                            qryFaDokumentAblage_BaPerson.Delete();
                        }

                        break;
                }
            }
        }

        /// <summary>
        /// Context von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupContext()
        {
            edtDokument.Context = CONTEXT_DOC;
        }

        /// <summary>
        /// DataMember von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupDataMembers()
        {
            edtDatumErstellung.DataMember = DBO.FaDokumentAblage.DatumErstellung;
            edtThema.DataMember = DBO.FaDokumentAblage.FaThemaDokAblageCodes;
            edtDokument.DataMember = DBO.FaDokumentAblage.DocumentID;
            memBemerkung.DataMember = DBO.FaDokumentAblage.Bemerkung;
        }

        /// <summary>
        /// FieldName für die Kolonen von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupFieldNames()
        {
            colDatum.FieldName = DBO.FaDokumentAblage.DatumErstellung;
            colThema.FieldName = DBO.FaDokumentAblage.FaThemaDokAblageCodes;
            colThema.ColumnEdit = grdDokumente.GetLOVLookUpEdit(LOV_THEMA);
            colBemerkung.FieldName = DBO.FaDokumentAblage.Bemerkung;
        }

        /// <summary>
        /// Tag benutzen um ein klaren Text anzuzeigen für die Mussfelder.
        /// </summary>
        private void SetupTags()
        {
            edtDatumErstellung.Tag = lblDatumErstellung.Text;
            edtThema.Tag = lblThema.Text;
            edtDokument.Tag = lblDokument.Text;
            memBemerkung.Tag = lblBemerkung.Text;
        }

        #endregion

        #endregion
    }
}