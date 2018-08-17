using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Kiss.Interfaces.DocumentHandling;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Dokument;

namespace KiSS4.Administration
{
    public partial class CtlDocTemplate : KissSearchUserControl
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly string _xDocTemplateNonBlobFieldList = XDocFileHandler.GetXDocumentNonBlobFieldList("XDocTemplate");

        #endregion

        #region Private Constant/Read-Only Fields

        private const string COL_NAME_VORNAME = "NameVorname";
        private const string COL_PUBLICTEMPLATE = "PublicTemplate";
        private const string MESSAGE_GEWAEHLTE_ABTEILUNGEN = "gewaehlteAbteilungen";
        private const string MESSAGE_GEWAEHLTE_ABTEILUNGEN_DEFAULT = "Zugewiesene Abteilungen";
        private const string MESSAGE_GEWAEHLTE_BENUTZER = "gewaehlteBenutzer";
        private const string MESSAGE_GEWAEHLTE_BENUTZER_DEFAULT = "Zugewiesene Benutzer";
        private const string MESSAGE_VERFUEGBARE_ABTEILUNGEN = "verfuegbareAbteilungen";
        private const string MESSAGE_VERFUEGBARE_ABTEILUNGEN_DEFAULT = "Verfügbare Abteilungen";
        private const string MESSAGE_VERFUEGBARE_BENUTZER = "verfuegbareBenutzer";
        private const string MESSAGE_VERFUEGBARE_BENUTZER_DEFAULT = "Verfügbare Benutzer";

        /// <summary>
        /// SQL für die Picklist Abteilungen (linke Seite)
        /// </summary>
        private const string SQL_ABTEILUNGEN = @"
            SELECT ORG.OrgUnitID,
                   ORG.ItemName
            FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
            ORDER BY ORG.ItemName, ORG.ParentID;";

        /// <summary>
        /// Wenn eine Vorlage gelöscht wird,
        /// dann werden die Verknüfungen zu den Abteilungen und Usern
        /// und das zur Vorlage gehörende Profil auch gelöscht.
        /// </summary>
        private const string SQL_BEFORE_DELETING_DOCTEMPLATE = @"
            DELETE
            FROM dbo.XOrgUnit_XDocTemplate
            WHERE DocTemplateID = {0};

            DELETE
            FROM dbo.XUser_XDocTemplate
            WHERE DocTemplateID = {0};";

        /// <summary>
        /// SQL für die Picklist Benutzer (linke Seite)
        /// </summary>
        private const string SQL_BENUTZER = @"
            SELECT UserID      = USR.UserID,
                   NameVorname = USR.NameVorname + ' (' + USR.LogonName + ')'
            FROM dbo.vwUser USR WITH (READUNCOMMITTED)
            WHERE USR.IsLocked = 0
            ORDER BY NameVorname;";

        /// <summary>
        /// SQL für die Picklist Benutzer, löscht alle Zuweisungen zum Benutzer.
        /// </summary>
        private const string SQL_DELETEALLUSERASSIGNMENTS = @"
            DELETE
            FROM dbo.XUser_XDocTemplate
            WHERE DocTemplateID = {0};";

        /// <summary>
        /// SQL für die Picklist Abteilungen, löscht alle Zuweisungen zu einer Vorlage.
        /// </summary>
        private const string SQL_DELETEALLXORGUNITASSIGNMENTS = @"
            DELETE
            FROM dbo.XOrgUnit_XDocTemplate
            WHERE DocTemplateID = {0};";

        /// <summary>
        /// SQL für die Picklist Benutzer, löscht einen Eintrag.
        /// </summary>
        private const string SQL_DELETEUSRASSIGNMENT = @"
            DELETE
            FROM dbo.XUser_XDocTemplate
            WHERE UserID = {0}
              AND DocTemplateID = {1};";

        /// <summary>
        /// SQL für die Picklist Abteilungen, löscht einen Eintrag.
        /// </summary>
        private const string SQL_DELETEXORGUNITASSIGNMENT = @"
            DELETE
            FROM dbo.XOrgUnit_XDocTemplate
            WHERE OrgUnitID = {0}
              AND DocTemplateID = {1};";

        private const string SQL_QUERYPART_TEMPLATENAME = @"
            --- AND DTP.DocTemplateName LIKE '%'+ {edtNameSuche} + '%'
            --- AND CASE WHEN DTP.DocFormatCode NOT IN (1, 2) THEN 99 ELSE DTP.DocFormatCode END = {edtSucheFormat}";

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor, init components
        /// </summary>
        public CtlDocTemplate()
        {
            InitializeComponent();
            SetupPickLists();
            tabDocumentTemplate.SelectTab(tpgDetail);

            SetupRights();
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// The form load event
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void CtlDocTemplate_Load(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // set this property in order to let work the documenthandler correctly
            edtDocTemplate.DokTypCode = DokTyp.Template;

            qryDocTemplate.SelectStatement = string.Format(qryDocTemplate.SelectStatement,
                                            _xDocTemplateNonBlobFieldList,
                                            SQL_QUERYPART_TEMPLATENAME,
                                            Session.User.LanguageCode);

            var qryFormat = DBUtil.OpenSQL(@"
                SELECT Code = NULL,
                       Text = ''

                UNION ALL

                SELECT Code = 1,
                       Text = 'Word'

                UNION ALL

                SELECT Code = 2,
                       Text = 'Excel'

                UNION ALL

                SELECT Code = 99,
                       Text = {0};", KissMsg.GetMLMessage(Name, "OtherFileType", "Andere"));

            edtSucheFormat.LoadQuery(qryFormat);

            // select tabs/run search
            tabDocumentTemplate.SelectTab(tpgDetail);
            NewSearchAndRun();

            // logging
            _logger.Debug("done");
        }

        /// <summary>
        /// Assigns a new XOrgUnit to the template.
        /// </summary>
        private void edtAbteilungen_AddItemClick(object sender, Gui.KissDoubleListSelectorEventArgs e)
        {
            DataRow rowAdded = e.ItemRow;
            int orgUnitId = Utils.ConvertToInt(rowAdded["OrgUnitID"]);
            int tempateId = Utils.ConvertToInt(qryDocTemplate.Row[DBO.XDocTemplate.DocTemplateID]);

            qryAssignedXOrgUnits.Insert();

            qryAssignedXOrgUnits.Row[DBO.XOrgUnit_XDocTemplate.OrgUnitID] = orgUnitId;
            qryAssignedXOrgUnits.Row[DBO.XOrgUnit_XDocTemplate.DocTemplateID] = tempateId;
            qryAssignedXOrgUnits.SetCreator();
            qryAssignedXOrgUnits.SetModifierModified();
            qryAssignedXOrgUnits.Post();
        }

        /// <summary>
        /// Removes all assigned XOrgUnits.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void edtAbteilungen_RemoveAllItemsClick(object sender, EventArgs e)
        {
            int tempateId = Utils.ConvertToInt(qryDocTemplate.Row[DBO.XDocTemplate.DocTemplateID]);
            DBUtil.ExecSQL(SQL_DELETEALLXORGUNITASSIGNMENTS, tempateId);
        }

        /// <summary>
        /// Removes an XOrgUnit from assigned XOrgUnit.
        /// </summary>
        private void edtAbteilungen_RemoveItemClick(object sender, Gui.KissDoubleListSelectorEventArgs e)
        {
            DataRow rowAdded = e.ItemRow;
            int orgUnitId = Utils.ConvertToInt(rowAdded["OrgUnitID"]);
            int tempateId = Utils.ConvertToInt(qryDocTemplate.Row[DBO.XOrgUnit_XDocTemplate.DocTemplateID]);

            DBUtil.ExecSQL(SQL_DELETEXORGUNITASSIGNMENT, orgUnitId, tempateId);
        }

        private void edtAbteilungen_SelectionChanged(object sender, EventArgs e)
        {
            SetColPublicTemplate();
        }

        /// <summary>
        /// Assigns a new User to the template.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void edtBenutzer_AddItemClick(object sender, Gui.KissDoubleListSelectorEventArgs e)
        {
            DataRow rowAdded = e.ItemRow;
            int userID = Utils.ConvertToInt(rowAdded[DBO.XUser.UserID]);
            int tempateId = Utils.ConvertToInt(qryDocTemplate.Row[DBO.XDocTemplate.DocTemplateID]);

            qryAssignedUsers.Insert();
            qryAssignedUsers.Row[DBO.XUser_XDocTemplate.UserID] = userID;
            qryAssignedUsers.Row[DBO.XUser_XDocTemplate.DocTemplateID] = tempateId;
            qryAssignedUsers.SetCreator();
            qryAssignedUsers.SetModifierModified();
            qryAssignedUsers.Post();
        }

        private void edtBenutzer_RemoveAllItemsClick(object sender, EventArgs e)
        {
            int tempateId = Utils.ConvertToInt(qryDocTemplate.Row[DBO.XDocTemplate.DocTemplateID]);
            DBUtil.ExecSQL(SQL_DELETEALLUSERASSIGNMENTS, tempateId);
        }

        /// <summary>
        /// Removes a user from the document (assignment).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void edtBenutzer_RemoveItemClick(object sender, Gui.KissDoubleListSelectorEventArgs e)
        {
            int userID = Utils.ConvertToInt(e.ItemRow["UserID"]);
            int tempateId = Utils.ConvertToInt(qryDocTemplate.Row[DBO.XDocTemplate.DocTemplateID]);

            DBUtil.ExecSQL(SQL_DELETEUSRASSIGNMENT, userID, tempateId);
        }

        private void edtBenutzer_SelectionChanged(object sender, EventArgs e)
        {
            SetColPublicTemplate();
        }

        private void edtDocTemplate_DocumentImporting(object sender, CancelEventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // importing needs a post (as DocumentOpening)
            edtDocTemplate_DocumentOpening(sender, e);

            // logging
            _logger.Debug("done");
        }

        private void edtDocTemplate_DocumentOpening(object sender, CancelEventArgs e)
        {
            // logging
            _logger.Debug("enter");

            e.Cancel = false;

            if (edtDocTemplate.InUse)
            {
                // logging
                _logger.Debug("document is in use, cannot open");

                // problem is observed with EXCEL:
                // after closing a template and reopening it too quickly KISS shuts down ... good bye :-)
                // thus : check if document is still in use and therefore cannot be saved back
                // TODO RH : has to be tested if efficient
                KissMsg.ShowInfo(Name,
                                 "DokumentProzessNochOffen_v02",
                                 "Bitte warten Sie einen Moment, bis der Prozess das Dokument wieder freigegeben hat.\r\n\r\n" +
                                 "Unter Umständen ist das Dokument noch geöffnet und die aktuelle Bearbeitung nicht abgeschlossen.");
                e.Cancel = true;
                return;
            }

            if (qryDocTemplate.Row.RowState == DataRowState.Added)
            {
                // new row : check if we have already a file defined
                if (DBUtil.IsEmpty(qryDocTemplate["FileBinary"]))
                {
                    // logging
                    _logger.Debug("FileBinary is empty, cannot open document");

                    // no stream for filebinary found, cannot open template
                    KissMsg.ShowInfo(Name, "NoTemplateFileBinaryNewItem", "Zu dieser Vorlage wurde noch kein Dokument importiert.");

                    // no filebinary found, cannot open document
                    e.Cancel = true;
                    return;
                }

                // stream for filebinary found, so let him edit it
                // but in order to get the template ID new rows have to be posted first
                bool oldRowModified = qryDocTemplate.RowModified;
                qryDocTemplate.RowModified = true;

                if (!qryDocTemplate.Post())
                {
                    // logging
                    _logger.Debug("Post() failed, cannot continue");

                    // probably the name is missing (or other errors), so do not continue
                    qryDocTemplate.RowModified = oldRowModified;
                    e.Cancel = true;

                    return;
                }

                // post was successful, so set the metadata again
                // in order to have the row ID in XDocument class
                edtDocTemplate.Row = qryDocTemplate.Row;
                qryDocTemplate.RowModified = true;
            }

            // logging
            _logger.Debug("done");
        }

        private void grdKontext_Load(object sender, EventArgs e)
        {
            grvKontext.OptionsView.ColumnAutoWidth = true;
        }

        private void gridVorlagen_DoubleClick(object sender, EventArgs e)
        {
            edtDocTemplate.OpenDoc();
        }

        private void qryDocTemplate_AfterDelete(object sender, EventArgs e)
        {
            try
            {
                Session.Commit();
            }
            catch (Exception ex)
            {
                // catch über alle Typen von Exceptions muss immer vorhanden sein!
                // hier darf kein Code stehen!
                // Reihenfolge darf hier nicht vertauscht werden!
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
            }
        }

        private void qryDocTemplate_AfterFill(object sender, EventArgs e)
        {
            // in order to disable the editing fields
            if (qryDocTemplate.Count == 0)
            {
                qryTemplate_PositionChanged(sender, e);
            }
        }

        private void qryDocTemplate_AfterInsert(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // TODO RH : a better place would be OnBeforeInsert

            // get one of the available templates
            AvailableTemplate template = edtDocTemplate.GetNewTemplate();

            // check if we got one
            if (template != null)
            {
                // logging
                _logger.Debug("template is not null, go on");

                // apply values to query
                // do not insert a name here, because the user believes
                //qryDocTemplate["DocTemplateName"] = template.DocTemplateName;
                qryDocTemplate[DBO.XDocTemplate.DocFormatCode] = template.DocFormat;
                qryDocTemplate[DBO.XDocTemplate.FileExtension] = template.DocTemplateFileExtension;
                qryDocTemplate[DBO.XDocTemplate.FileBinary] = template.CompressedData;
                qryDocTemplate[DBO.XDocTemplate.DateCreation] = DateTime.Now;
                qryDocTemplate[DBO.XDocTemplate.DateLastSave] = DateTime.Now;

                // in order not to loose the row, when user does not make modifications at all:
                qryDocTemplate.RowModified = true;
            }
            else
            {
                // logging
                _logger.Debug("template is null, cancel");

                // do not continue, if no template exists
                qryDocTemplate.Cancel();
                return;

                // set default values to prevent errors
                //qryDocTemplate["DocFormatCode"] = DokFormat.Unbekannt;
                //qryDocTemplate["DateCreation"] = DateTime.Now;
                //qryDocTemplate["DateLastSave"] = DateTime.Now;
            }

            // apply docformat
            SetDocFormat();

            // logging
            _logger.Debug("done");
        }

        private void qryDocTemplate_AfterPost(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // in order to be up to date, when the row position will not be changed
            qryTemplate_PositionChanged(sender, e);

            // apply docformat
            SetDocFormat();

            // logging
            _logger.Debug("done");
        }

        private void qryDocTemplate_BeforeDelete(object sender, EventArgs e)
        {
            // make a copy of the template before deleting it
            edtDocTemplate.SaveTemplateToLocalDirectory();

            //Referenzierte Objekte auch löschen. Z.B. Profil und Verknüpfungen
            //zu Abteilungen und Usern.

            Session.BeginTransaction();

            // hier darf kein Code stehen!
            // wenn in DoSomething() nichts gemacht werden muss,
            // kann der ganze try-catch-Block weggelassen werden.
            try
            {
                int doctemplateId = Utils.ConvertToInt(qryDocTemplate[DBO.XDocTemplate.DocTemplateID]);
                int profileID = Utils.ConvertToInt(qryDocTemplate[DBO.XDocTemplate.XProfileID]);
                DBUtil.ExecSQL(SQL_BEFORE_DELETING_DOCTEMPLATE, doctemplateId, profileID);
            }
            catch (Exception ex)
            {
                // catch über alle Typen von Exceptions muss immer vorhanden sein!
                // hier darf kein Code stehen!
                // Reihenfolge darf hier nicht vertauscht werden!
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
                throw new KissCancelException();
            }
        }

        private void qryDocTemplate_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            // has to be made in order to get the newest timestamp
            // if not, KISS cannot delete
            if (!RestoreDataFromDB(true))
            {
                throw new KissCancelException();
            }
        }

        private void qryTemplate_BeforePost(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");
            _logger.DebugFormat("RowState='{0}'", qryDocTemplate.Row.RowState);

            // check not null fields
            DBUtil.CheckNotNullField(edtDocTemplateName, lblDocTemplateName.Text);

            // check if document is still in use and therefore cannot be saved back
            if (edtDocTemplate.InUse)
            {
                // cancel Post() event
                throw new KissInfoException(KissMsg.GetMLMessage(Name,
                                                                 "DokumentSchliessenUndWarten_v02",
                                                                 "Bitte die bereits geöffnete Vorlage zuerst schliessen und/oder warten bis das Dokument vollständig freigegeben ist.", KissMsgCode.MsgInfo));
            }

            // check if document is locked at the moment
            if (edtDocTemplate.IsDocumentLocked)
            {
                // cancel Post() event
                throw new KissInfoException(KissMsg.GetMLMessage(Name,
                                                                 "DokumentIstGesperrt_v01",
                                                                 "Diese Vorlage wird zurzeit bearbeitet und kann nicht verändert werden. Bitte warten Sie, bis das Dokument wieder freigegeben ist.", KissMsgCode.MsgInfo));
            }

            // validate must-fields on database-table
            if (DBUtil.IsEmpty(qryDocTemplate[DBO.XDocTemplate.DateCreation]))
            {
                KissMsg.ShowInfo(Name, "DateCreationIsEmpty", "Die Vorlage kann nicht gepeichert werden, es ist kein Erstelldatum hinterlegt.");
                throw new KissCancelException();
            }

            if (DBUtil.IsEmpty(qryDocTemplate[DBO.XDocTemplate.DateLastSave]))
            {
                KissMsg.ShowInfo(Name, "DateLastSaveIsEmpty", "Die Vorlage kann nicht gepeichert werden, es ist kein Speicherdatum hinterlegt.");
                throw new KissCancelException();
            }

            // due to late-loading of FileBinary, we have to try to load it from database if user changed something and
            // the filebinary was not loaded yet. otherwise, the filebinary will be overriden by NULL and the template
            // therefore lost. this is only important for already existing documents.
            //if (DBUtil.IsEmpty(qryDocTemplate["FileBinary"]) && qryDocTemplate.Row.RowState != DataRowState.Added)
            if (qryDocTemplate.Row.RowState != DataRowState.Added)
            {
                // try to load FileBinary from database
                // we do not Post, if there is no success (FileBinary might be empty)
                if (!RestoreDataFromDB(false))
                {
                    // logging
                    _logger.Debug("failed to restore data from database, cancel");

                    // cancel
                    throw new KissCancelException();
                }
            }

            // validate must-fields on database-table
            if (DBUtil.IsEmpty(qryDocTemplate[DBO.XDocTemplate.FileBinary]))
            {
                KissMsg.ShowInfo(Name, "FileBinaryIsEmpty", "Die Vorlage kann nicht gepeichert werden, da noch kein Dokument hinterlegt ist.");
                throw new KissCancelException();
            }

            // security check
            if (!edtDocTemplate.CanUpdate)
            {
                KissMsg.ShowInfo(Name, "SecurityCheckBeforePost_v01", "Der Datensatz kann nicht gespeichert werden, da er als \"in Bearbeitung\" gekennzeichnet ist.");
                throw new KissCancelException();
            }

            // TODO RH : checkout the templete here, in order to have check it out for other users
            // could also be done by locking the template later, but then a transaction is a must !!!
            // has not a high priority, because only the transaction is not implemented yet

            // when the user can edit the document (not checked out by another user),
            // we allways can checkin the row here, because timestamp will check for us
            qryDocTemplate[DBO.XDocTemplate.CheckOut_UserID] = DBNull.Value;
            qryDocTemplate[DBO.XDocTemplate.CheckOut_Date] = DBNull.Value;
            qryDocTemplate[DBO.XDocTemplate.CheckOut_Filename] = DBNull.Value;
            qryDocTemplate[DBO.XDocTemplate.CheckOut_Machine] = DBNull.Value;

            // logging
            _logger.Debug("done");
        }

        private void qryTemplate_PositionChanged(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            //If zero documents are found, then we will disable all fields in the detail panel.
            panDetails.Enabled = !qryDocTemplate.IsEmpty;
            DisableTabsWhileInserting();

            // setting the editing fields
            //bool canEdit = (qryDocTemplate.Count > 0 && DBUtil.IsEmpty(qryDocTemplate["Checkout_UserID"]));
            //qryDocTemplate.EnableBoundFields(canEdit););
            if (qryDocTemplate.Row != null)
            {
                // check if user added a new row
                if (qryDocTemplate.Row.RowState == DataRowState.Added)
                {
                    // new row, prevent applying row because of further problems with display...
                    edtDocTemplate.Row = null;
                }
                else
                {
                    // here the main document information is collected, colors are changed, hints are set
                    edtDocTemplate.Row = qryDocTemplate.Row;

                    // reload the access assignements (~who is allowed to use this template?).
                    ReloadAccessAssignments();
                }
            }

            DisplayContexts();

            // logging
            _logger.Debug("done");
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (tabControlSearch.SelectedTab == tpgListe && !qryDocTemplate.IsEmpty)
            {
                panDetails.Enabled = true;
            }
            else
            {
                panDetails.Enabled = false;
            }
        }

        #endregion

        #region Methods

        #region Protected Methods

        /// <summary>
        /// Führt eine neue Suche aus.
        /// </summary>
        protected void NewSearchAndRun()
        {
            NewSearch();
            tabControlSearch.SelectTab(tpgListe);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Während einem Insert soll nur das erste Tab aktiv sein,
        /// bis der Datensatz gespeichert ist.
        /// </summary>
        private void DisableTabsWhileInserting()
        {
            if (qryDocTemplate.Row != null)
            {
                bool isEnabled = true;

                if (qryDocTemplate.Row.RowState == DataRowState.Added)
                {
                    isEnabled = false;
                }

                tpgProfile.Enabled = isEnabled;
                tpgBenutzer.Enabled = isEnabled;
                tpgAbteilungen.Enabled = isEnabled;
            }
        }

        /// <summary>
        /// Display and refresh contexts of selected template
        /// </summary>
        private void DisplayContexts()
        {
            qryKontexte.Fill(qryDocTemplate[DBO.XDocTemplate.DocTemplateID]);
        }

        /// <summary>
        /// Reloads the access assignments.
        /// </summary>
        private void ReloadAccessAssignments()
        {
            int templateId = Utils.ConvertToInt(qryDocTemplate.Row[DBO.XDocTemplate.DocTemplateID]);

            //1. Look for assigned XOrgUnits.
            qryAssignedXOrgUnits.Fill(templateId);
            edtAbteilungen.UnselectAll();

            List<string> rows = new List<string>();

            foreach (DataRow row in qryAssignedXOrgUnits.DataTable.Rows)
            {
                int idXOrgUnit = Utils.ConvertToInt(row[DBO.XOrgUnit.OrgUnitID]);
                rows.Add("" + idXOrgUnit);
            }

            edtAbteilungen.Select(rows, DBO.XOrgUnit.OrgUnitID);

            //2. Look for assigned XUsers.
            qryAssignedUsers.Fill(templateId);

            edtBenutzer.UnselectAll();

            rows = new List<string>();

            foreach (DataRow row in qryAssignedUsers.DataTable.Rows)
            {
                int idUser = Utils.ConvertToInt(row[DBO.XUser.UserID]);
                rows.Add("" + idUser);
            }

            edtBenutzer.Select(rows, DBO.XUser.UserID);
        }

        /// <summary>
        /// Restores actual from DB back to qryDocTemplate.
        /// </summary>
        private bool RestoreDataFromDB(bool onlyTimestamp)
        {
            // logging
            _logger.Debug("enter");

            // nothing to do, wenn DocTemplateID is NULL
            if (DBUtil.IsEmpty(qryDocTemplate[DBO.XDocTemplate.DocTemplateID]))
            {
                // logging
                _logger.Debug("coding error, DocTemplateID is NULL");

                // Coding error, do not translate
                KissMsg.ShowInfo("Programmfehler: Beim neuen Zeilen kann keine Vorlage zurückgesichert werden.");
                return false;
            }

            // restoring the filebinary data from the DB to the actual row
            // TODO RH : new fields UserIDLastSave ?
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT DTP.FileBinary,
                       DTP.DateCreation,
                       DTP.DateLastSave,
                       DTP.DocFormatCode,
                       DTP.FileExtension,
                       DTP.DocTemplateTS
                FROM dbo.XDocTemplate DTP
                WHERE DTP.DocTemplateID = {0};", qryDocTemplate[DBO.XDocTemplate.DocTemplateID]);

            // check if we have a template saved on database
            if (!onlyTimestamp && DBUtil.IsEmpty(qry[DBO.XDocTemplate.FileBinary]))
            {
                // no stream for filebinary found, cannot open template
                KissMsg.ShowInfo(Name, "NoTemplateFileBinary", "Zu dieser Vorlage wurde kein Dokument gefunden. Die Vorlage kann nicht geöffnet werden.");
                return false;
            }

            // apply for current row all new data including filebinary
            if (!onlyTimestamp)
            {
                qryDocTemplate[DBO.XDocTemplate.FileBinary] = qry[DBO.XDocTemplate.FileBinary];
                qryDocTemplate[DBO.XDocTemplate.DateCreation] = qry[DBO.XDocTemplate.DateCreation];
                qryDocTemplate[DBO.XDocTemplate.DateLastSave] = qry[DBO.XDocTemplate.DateLastSave];
                qryDocTemplate[DBO.XDocTemplate.DocFormatCode] = qry[DBO.XDocTemplate.DocFormatCode];
                qryDocTemplate[DBO.XDocTemplate.FileExtension] = qry[DBO.XDocTemplate.FileExtension];
                // TODO RH : new fields UserIDLastSave ?
            }

            qryDocTemplate[DBO.XDocTemplate.DocTemplateTS] = qry[DBO.XDocTemplate.DocTemplateTS];
            qryDocTemplate.Row.AcceptChanges();

            // logging
            _logger.Debug("done");

            return true;
        }

        /// <summary>
        /// Sets the column "öffentlich", based on
        /// the values in the two pick-lists (XUser and XOrgunit).
        /// Public tempaltes (vorlagen) can be used by everybody.
        /// </summary>
        private void SetColPublicTemplate()
        {
            bool isPublic = true;

            if (edtAbteilungen.GetSelected().Count > 0 || edtBenutzer.GetSelected().Count > 0)
            {
                isPublic = false;
            }

            if (qryDocTemplate.Row != null)
            {
                qryDocTemplate[COL_PUBLICTEMPLATE] = isPublic;

                // used to prevent error message in case of non-allowed changes (see: #8047)
                if (!qryDocTemplate.CanUpdate)
                {
                    qryDocTemplate.RowModified = false;
                    qryDocTemplate.Row.AcceptChanges();
                }
            }
        }

        /// <summary>
        /// Set DocFormat value depending on current DocFormatCode
        /// </summary>
        private void SetDocFormat()
        {
            // logging
            _logger.Debug("enter");

            // check if we have a format code
            if (!DBUtil.IsEmpty(qryDocTemplate[DBO.XDocTemplate.DocFormatCode]))
            {
                // set DocFormat depending on given DocFormatCode
                switch (Convert.ToInt32(qryDocTemplate[DBO.XDocTemplate.DocFormatCode]))
                {
                    case 1:
                        // word
                        qryDocTemplate["DocFormat"] = "word";
                        edtDocTemplate.DokFormatCode = DokFormat.Word;
                        break;

                    case 2:
                        // excel
                        qryDocTemplate["DocFormat"] = "excel";
                        edtDocTemplate.DokFormatCode = DokFormat.Excel;
                        break;

                    default:
                        // other
                        qryDocTemplate["DocFormat"] = "other";
                        edtDocTemplate.DokFormatCode = DokFormat.Unbekannt;
                        break;
                }
            }

            // logging
            _logger.DebugFormat("DocFormat='{0}'", qryDocTemplate["DocFormat"]);
            _logger.Debug("done");
        }

        /// <summary>
        /// Initialisiert die PickLists.
        /// </summary>
        private void SetupPickLists()
        {
            string verfuegbaereAbteilungenTitle = KissMsg.GetMLMessage(Name, MESSAGE_VERFUEGBARE_ABTEILUNGEN, MESSAGE_VERFUEGBARE_ABTEILUNGEN_DEFAULT);
            string gewaehlteAbteilungenTitle = KissMsg.GetMLMessage(Name, MESSAGE_GEWAEHLTE_ABTEILUNGEN, MESSAGE_GEWAEHLTE_ABTEILUNGEN_DEFAULT);
            edtAbteilungen.Initialize(SQL_ABTEILUNGEN, DBO.XOrgUnit.ItemName, verfuegbaereAbteilungenTitle, gewaehlteAbteilungenTitle);

            string verfuegbareBenutzerTitle = KissMsg.GetMLMessage(Name, MESSAGE_VERFUEGBARE_BENUTZER, MESSAGE_VERFUEGBARE_BENUTZER_DEFAULT);
            string gewaehlteBenutzer = KissMsg.GetMLMessage(Name, MESSAGE_GEWAEHLTE_BENUTZER, MESSAGE_GEWAEHLTE_BENUTZER_DEFAULT);
            edtBenutzer.Initialize(SQL_BENUTZER, COL_NAME_VORNAME, verfuegbareBenutzerTitle, gewaehlteBenutzer);
        }

        private void SetupRights()
        {
            // logging
            _logger.Debug("enter");

            // init vars
            var isAdmin = Session.User.IsUserAdmin;
            bool canReadData;
            bool canUserInsert;
            bool canUserUpdate;
            bool canUserDelete;

            // set values
            Session.GetUserRight(Name, out canReadData, out canUserInsert, out canUserUpdate, out canUserDelete);

            if (!canReadData)
            {
                // no rights to view this control
                throw new Exception("No rights to view details of this control.");
            }

            // logging
            _logger.DebugFormat("isAdmin='{0}', canUserInsert='{1}', canUserUpdate='{2}', canUserDelete='{3}'",
                isAdmin, canUserInsert, canUserUpdate, canUserDelete);

            qryDocTemplate.CanInsert = isAdmin || canUserInsert;
            qryDocTemplate.CanUpdate = isAdmin || canUserUpdate;
            qryDocTemplate.CanDelete = isAdmin || canUserDelete;

            var enabled = qryDocTemplate.CanUpdate;

            edtAbteilungen.Enabled = enabled;
            edtBenutzer.Enabled = enabled;
            edtProfileTags.Enabled = enabled;

            qryDocTemplate.EnableBoundFields();

            // logging
            _logger.DebugFormat("qryDocTemplate.CanInsert='{0}', qryUser.CanUpdate='{1}', qryUser.CanDelete='{2}'",
                qryDocTemplate.CanInsert, qryDocTemplate.CanUpdate, qryDocTemplate.CanDelete);
            _logger.Debug("done");
        }

        #endregion

        #endregion
    }
}