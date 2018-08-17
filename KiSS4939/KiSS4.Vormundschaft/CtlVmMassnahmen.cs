using System;
using System.Drawing;

using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using DevExpress.XtraGrid.Views.Base;

namespace KiSS4.Vormundschaft
{
    /// <summary>
    /// Summary description for CtlVmMassnahmen.
    /// </summary>
    public partial class CtlVmMassnahmen : KissSearchLogischesLoeschenUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string PRI_MA_ZUST_SARID = @"System\Vormundschaft\PriMa\ZustaendigerSAR";

        #endregion

        #region Private Fields

        // _mode = "E": wenn "Wechsel Mandatsträgerin" geklickt wurde, _mode == "M":  Normalzustand
        private string _mode = "M";
        private int _vmMassnahmeID;

        #endregion

        #endregion

        #region Constructors

        public CtlVmMassnahmen()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            SetupLogischesLoeschen();
        }

        #endregion

        #region EventHandlers

        private void CtlVmMassnahmen_Load(object sender, EventArgs e)
        {
            DBUtil.ApplyFallRightsToSqlQuery(_faLeistungId, qryVmMassnahme);
            qryVmMassnahme.Last();
            grdVmMassnahme.Focus();
        }

        private void btnNeueMT_Click(object sender, EventArgs e)
        {
            // Zuerst kotrollieren, ob gespeichert werden kann
            if (!qryVmMassnahme.Post()) return;

            // _mode = "E": wenn "Wechsel Mandatsträgerin" geklickt wurde, _mode == "M":  Normalzustand
            _mode = "E";
            qryVmMassnahme.Insert();
        }

        private void btnRestoreDocument_Click(object sender, EventArgs e)
        {
            OnRestoreData();
        }

        private void edtSAR_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MandatstraegerSuchen(edtSAR.Text, e.ButtonClicked);
            if (!e.Cancel)
            {
                qryVmMassnahme["UserID"] = dlg["UserID"];
                qryVmMassnahme["SAR"] = dlg["Name"];
                qryVmMassnahme["VmPriMaID"] = DBNull.Value;
                qryVmMassnahme["VmPriMa"] = DBNull.Value;
            }
        }

        private void edtVmPriMa_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.PriMaSuchen(edtVmPriMa.Text, e.ButtonClicked);
            if (!e.Cancel)
            {
                qryVmMassnahme["VmPriMaID"] = dlg["VmPriMaID"];
                qryVmMassnahme["VmPriMa"] = dlg["Name"];
                qryVmMassnahme["UserID"] = DBNull.Value;
                qryVmMassnahme["SAR"] = DBNull.Value;
            }
        }

        private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "ZGBListe")
                e.DisplayText = ZGBinvisible.GetDisplayText(e.CellValue.ToString());
        }

        private void qryVmMassnahme_AfterInsert(object sender, EventArgs e)
        {
            // _mode = "E": wenn "Wechsel Mandatsträgerin" geklickt wurde, _mode == "M":  Normalzustand
            if (_mode == "M")
            {
                SqlQuery qry = DBUtil.OpenSQL("select max(DatumBis) MaxDatum from VmMassnahme where FaLeistungID = {0} and IsDeleted = 0", _faLeistungId);
                if (!DBUtil.IsEmpty(qryVmMassnahme["DatumVon"]))
                {
                    qryVmMassnahme["DatumVon"] = ((DateTime)qry["MaxDatum"]).AddDays(1);
                }
                qryVmMassnahme["FaLeistungID"] = _faLeistungId;
                qryVmMassnahme["Typ"] = "M";
                edtDatumVon.Focus();
            }
            else
            {
                qryVmMassnahme["Typ"] = "E";
                edtErnennung.Focus();
            }
            if (_vmMassnahmeID != 0) qryVmMassnahme["VmMassnahmeID"] = _vmMassnahmeID;

            qryVmMassnahme.SetCreator();
            SetEditMode();
        }

        private void qryVmMassnahme_AfterPost(object sender, EventArgs e)
        {
            SaveErnennung();

            // _mode = "E": wenn "Wechsel Mandatsträgerin" geklickt wurde, _mode == "M":  Normalzustand
            if (qryVmMassnahme["Typ"].ToString() == "M")
            {
                qryVmMassnahme["Beschluss"] = qryVmMassnahme["DatumVon"];
                qryVmMassnahme["Aufhebung"] = qryVmMassnahme["DatumBis"];
                qryVmMassnahme["ZGBListe"] = qryVmMassnahme["ZGBCodes"];
            }

            if (!DBUtil.IsEmpty(qryVmMassnahme["VmPriMa"]))
            {
                qryVmMassnahme["MT"] = qryVmMassnahme["VmPriMa"];
                qryVmMassnahme["Privat"] = true;
            }
            else
            {
                qryVmMassnahme["MT"] = qryVmMassnahme["SAR"];
                qryVmMassnahme["Privat"] = false;
            }
        }

        /// <summary>
        /// Diese Methode wird nur aufgerufen, wenn das logische Löschen ausgeschaltet ist.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void qryVmMassnahme_BeforeDelete(object sender, EventArgs e)
        {

            //Geschäftsregel: Die Massnahme wird nur dann gelöscht, wenn es eine Ernennung hat.
            //Hat es mehr als eine Ernennung, dann wird nur die Ernennung gelöscht, die Massnahme bleibt erhalten.           
            if (!DBUtil.IsEmpty(qryVmMassnahme["VmErnennungID"]))
            {
                DBUtil.ExecSQL("DELETE dbo.VmErnennung WHERE VmErnennungID = {0};", qryVmMassnahme["VmErnennungID"]);
            }
            
            var countErnennung = (int)DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(*)
                FROM dbo.VmErnennung WITH(READUNCOMMITTED)
                WHERE VmMassnahmeID = {0};", qryVmMassnahme["VmMassnahmeID"]);

            if (!DBUtil.IsEmpty(qryVmMassnahme["VmMassnahmeID"]) && countErnennung > 0)
            {
                qryVmMassnahme.Row.AcceptChanges();
            }
        }

        public override bool OnDeleteData()
        {
            if (IsLogischesLoeschen)
            {
                
                //check if the document is already deleted.
                //if yes, tell the user and stop further processing.
                if (Utils.ConvertToBool(ActiveSQLQuery[DB_COL_IS_DELETED]))
                {
                    KissMsg.ShowInfo(Name, "RowAlreadyDeleted", "Dieser Datensatz ist bereits gelöscht.");
                    return false;
                }

                //User Fragen, ob er wirklich löschen will.
                if (KissMsg.ShowQuestion(Name, "ConfirmDeleteRow", "Wollen Sie den Datensatz wirklich löschen?"))
                {
                    DBUtil.ExecSQL("UPDATE dbo.VmErnennung SET IsDeleted = 1 WHERE VmErnennungID = {0};", qryVmMassnahme["VmErnennungID"]);

                    var countErnennung = (int)DBUtil.ExecuteScalarSQL(@"
                                                        SELECT COUNT(*)
                                                        FROM dbo.VmErnennung WITH(READUNCOMMITTED)
                                                        WHERE VmMassnahmeID = {0} AND IsDeleted = 0;", qryVmMassnahme["VmMassnahmeID"]);

                    if (!DBUtil.IsEmpty(qryVmMassnahme["VmMassnahmeID"]) && countErnennung == 0)
                    {
                        qryVmMassnahme["IsDeleted"] = true;
                    }
                   

                    if (ActiveSQLQuery.Post())
                    {
                        ActiveSQLQuery.Refresh();
                        return true;
                    }

                    ////else
                    ////{
                    ////    return base.OnDeleteData();
                    ////}
                    
                }

                return false;
            }

            return base.OnDeleteData();
        }

        /// <summary>
        ///  Stellt einen Datensatz wieder her.
        /// </summary>
        /// <returns></returns>
        public override bool OnRestoreData()
        {
            if (IsLogischesLoeschen)
            {
                
                int count = (int) DBUtil.ExecuteScalarSQL("SELECT COUNT(*) FROM dbo.VmErnennung WHERE IsDeleted = 0 AND VmErnennungID = {0}",
                                            qryVmMassnahme["VmErnennungID"]);

                if (count > 0)
                {
                    KissMsg.ShowInfo(Name, "RowAlreadyRestored", "Dieser Datensatz ist bereits wiederhergestellt.");
                    return true;
                }
                               
                DBUtil.ExecSQL("UPDATE dbo.VmErnennung SET IsDeleted = 0 WHERE VmErnennungID = {0};", qryVmMassnahme["VmErnennungID"]);
                qryVmMassnahme["IsDeleted"] = false;
                ActiveSQLQuery.Refresh();

                return true;
            }

            return false;
        }

        private void qryVmMassnahme_BeforeInsert(object sender, EventArgs e)
        {
            // _mode = "E": wenn "Wechsel Mandatsträgerin" geklickt wurde, _mode == "M":  Normalzustand
            if (_mode == "M")
            {
                if ((int)DBUtil.ExecuteScalarSQL(
                    "select count(*) from VmMassnahme where FaLeistungID = {0} and DatumBis is null AND IsDeleted = 0", _faLeistungId) > 0)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage(
                        "CtlVmMassnahmen", 
                        "ErstAlleMassnahmenAbschliessen", 
                        "Bevor eine neue Massnahme erfasst werden kann, müssen zuerst alle anderen Massnahmen abgeschlossen sein!", 
                        KissMsgCode.MsgInfo
                    ));
                }
            }

            if (qryVmMassnahme.Row != null)
                _vmMassnahmeID = (int)qryVmMassnahme["VmMassnahmeID"];
            else
                _vmMassnahmeID = 0;
        }

        private void qryVmMassnahme_BeforePost(object sender, EventArgs e)
        {
            qryVmMassnahme.SetModifierModified();

            // _mode = "E": wenn "Wechsel Mandatsträgerin" geklickt wurde, _mode == "M":  Normalzustand
            if (qryVmMassnahme["Typ"].ToString() == "M")
            {
                DBUtil.CheckNotNullField(edtDatumVon, lblDatumVon.Text);
                if (DBUtil.IsEmpty(qryVmMassnahme["WeitereZGB"]))
                    DBUtil.CheckNotNullField(edtZGBCodes, lblZGBCodes.Text);
            }

            //check: Mandatsträger muss erfasst sein
            if (DBUtil.IsEmpty(qryVmMassnahme["UserID"]) &&
                DBUtil.IsEmpty(qryVmMassnahme["VmPriMaID"]))
            {
                throw new KissInfoException(KissMsg.GetMLMessage(
                    "CtlVmMassnahmen", 
                    "SARprivatLeer", 
                    "Eines der beiden Felder 'SAR' oder 'privat' muss erfasst sein!", 
                    KissMsgCode.MsgInfo
                ));
            }

            if (!DBUtil.IsEmpty(qryVmMassnahme["UserID"]) &&
                !DBUtil.IsEmpty(qryVmMassnahme["VmPriMaID"]))
            {
                throw new KissInfoException(KissMsg.GetMLMessage(
                    "CtlVmMassnahmen", 
                    "NurSAROderNurprivat", 
                    "Nur eines der beiden Felder 'SAR' oder 'privat' darf erfasst sein!", 
                    KissMsgCode.MsgInfo
                ));
            }

            // _mode = "E": wenn "Wechsel Mandatsträgerin" geklickt wurde, _mode == "M":  Normalzustand
            if (qryVmMassnahme["Typ"].ToString() == "M")
            {
                //check: Datum-Überschhneidung
                if ((int)DBUtil.ExecuteScalarSQL(@"
                    select count(*)
                    from   VmMassnahme
                    where  FaLeistungID = {0} and
                           ({1} between DatumVon and DatumBis or
                            {2} between DatumVon and DatumBis) and
                           isNull({3},-1) <> VmMassnahmeID and
                           IsDeleted = 0",
                    _faLeistungId,
                    qryVmMassnahme["DatumVon"],
                    qryVmMassnahme["DatumBis"],
                    qryVmMassnahme["VmMassnahmeID"]) > 0)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage(
                        "CtlVmMassnahmen", 
                        "UeberschneidungDatum", 
                        "Der Datumsbereich der neuen/veränderten Massnahme überschneidet sich mit einer anderen Massnahme", 
                        KissMsgCode.MsgInfo
                    ));
                }
            }
            else if (qryVmMassnahme["Typ"].ToString() == "E")
            {
                SaveErnennung();
                qryVmMassnahme.Row.AcceptChanges();
                qryVmMassnahme.RowModified = false;
            }
        }

        private void qryVmMassnahme_PositionChanged(object sender, EventArgs e)
        {
            // _mode = "E": wenn "Wechsel Mandatsträgerin" geklickt wurde, _mode == "M":  Normalzustand
            if (!DBUtil.IsEmpty(qryVmMassnahme["Typ"]))
                _mode = qryVmMassnahme["Typ"].ToString();

            SetEditMode();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "VMMASSNAHMEID":
                    if (qryVmMassnahme.Count > 0)
                        return qryVmMassnahme["VmMassnahmeID"];
                    break;

                case "VMERNENNUNGID":
                    if (qryVmMassnahme.Count > 0)
                        return qryVmMassnahme["VmErnennungID"];
                    break;

                case "BAPERSONID":
                    return DBUtil.ExecuteScalarSQL("select BaPersonID from FaLeistung where FaLeistungID = {0}", _faLeistungId);

                case "FALEISTUNG":
                    return _faLeistungId;

                case "OWNERUSERID":
                    return (int)DBUtil.ExecuteScalarSQL("select UserID from FaLeistung where FaLeistungID = {0}", _faLeistungId);
            }

            return base.GetContextValue(fieldName);
        }

        public override void Init(string titleName, Image titleImage, int baPersonId, int faLeistungId)
        {
            base.Init(titleName, titleImage, baPersonId, faLeistungId);
            lblTitel.Text = titleName;
            picTitel.Image = titleImage;

            edtZGBCodes.LookupSQL = @"
                select Code, Text = Text + char(9) + ' - ' + isNull(Value1,'')
                from   XLOVCode
                where  LOVName = 'VmZGB' and
                       ',' + Value3 + ',' like '%,1,%'
                order by SortKey";

            NewSearchAndRun();
        }

        public override bool OnAddData()
        {
            // _mode = "E": wenn "Wechsel Mandatsträgerin" geklickt wurde, _mode == "M":  Normalzustand
            _mode = "M";
            return qryVmMassnahme.Insert() != null;
        }

        public override bool OnSaveData()
        {
            bool ret = qryVmMassnahme.Post();
            if (ret)
            {
                qryVmMassnahme.Refresh();
                qryVmMassnahme.Last();
            }
            return ret;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Enabled oder disabled die Inputfelder,
        /// je nachdem, ob ein Datensatz logisch gelöscht ist oder nicht.
        /// </summary>
        /// <param name="isActive"></param>
        /// <param name="editMode"></param>
        protected override void OnEnableFields(bool isActive, EditModeType editMode)
        {
            edtErnennung.EditMode = editMode;
            edtErnennungsurkundeDokID.EditMode = editMode;
            edtSAR.EditMode = editMode;
            edtVmPriMa.EditMode = editMode;
            edtElterlicheSorgeCode.EditMode = editMode;

            edtWeitereZGB.EditMode = editMode;
            edtBemerkung.EditMode = editMode;

            if (isActive)
            {
                SetEditMode();
            }
            else
            {
                edtZGBCodes.EditMode = editMode;
                edtDatumBis.EditMode = editMode;
                edtDatumVon.EditMode = editMode;
            }
        }

        /// <summary>
        /// Führt die Suche aus.  Hier werden dem Query die Parameter übergeben
        /// {0}, {1} ...      
        /// </summary>
        protected override void RunSearch()
        {
            bool isDeleted1;
            bool isDeleted2;

            int editVal = Convert.ToInt32(radGrpDeleted.EditValue);

            //Nur aktive Dokumente anzeigen
            if (editVal == 1)
            {
                isDeleted1 = false;
                isDeleted2 = false;
            }

            //Alle (gelöschte und aktuelle Dokumente) anzeigen
            else if (editVal == 0)
            {
                isDeleted1 = true;
                isDeleted2 = false;
            }

            //Nur gelöschte Dokumente anzeigen
            else
            {
                isDeleted1 = true;
                isDeleted2 = true;
            }

            kissSearch.SelectParameters = new object[] { _faLeistungId, isDeleted1, isDeleted2 };

            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void SaveErnennung()
        {
            //Speichern in VmErnennung
            qryVmMassnahme["VmErnennungID"] = DBUtil.ExecuteScalarSQL(@"
                IF {0} IS NULL BEGIN
                  INSERT VmErnennung (VmMassnahmeID, UserID, VmPriMaID, Ernennung, ErnennungsurkundeDokID, Creator, Created, Modifier, Modified)
                  VALUES ({1}, {2}, {3}, {4}, {5}, {6}, GETDATE(), {6}, GETDATE())

                  SELECT SCOPE_IDENTITY()
                END ELSE BEGIN
                  UPDATE VmErnennung
                    SET VmMassnahmeID = {1}, UserID ={2}, VmPriMaID = {3},
                        Ernennung = {4}, ErnennungsurkundeDokID = {5}
                  WHERE VmErnennungID = {0}

                  SELECT {0}
                END",
                qryVmMassnahme["VmErnennungID"],
                qryVmMassnahme["VmMassnahmeID"],
                qryVmMassnahme["UserID"],
                qryVmMassnahme["VmPriMaID"],
                qryVmMassnahme["Ernennung"],
                qryVmMassnahme["ErnennungsurkundeDokID"],
                DBUtil.GetDBRowCreatorModifier());

            //automatische Fallübertragung an ernannten MT, falls Ernennung aktiv
            object aktivesErnennungsDatum = DBUtil.ExecuteScalarSQL(@"
                SELECT MAX(Ernennung)
                FROM dbo.VmErnennung WITH(READUNCOMMITTED)
                WHERE VmMassnahmeID = {0} AND IsDeleted = 0;",
                qryVmMassnahme["VmMassnahmeID"]);

            if (qryVmMassnahme["Ernennung"].Equals(aktivesErnennungsDatum))
            {
                object newUserID;

                if (!DBUtil.IsEmpty(qryVmMassnahme["VmPriMa"]))
                {
                    newUserID = DBUtil.GetConfigValue(PRI_MA_ZUST_SARID, null);
                }
                else
                {
                    newUserID = qryVmMassnahme["UserID"];
                }

                if (!DBUtil.IsEmpty(newUserID))
                {
                    var faLeistungId = qryVmMassnahme["FaLeistungID"] as int? ?? 0;
                    Utils.InsertFaLeistungUserHist(faLeistungId);
                    DBUtil.ExecSQL(@"
                        UPDATE dbo.FaLeistung
                        SET UserID = {0}, Modifier = {1}, Modified = GetDate()
                        WHERE FaLeistungID = {2} AND UserID <> {0};",
                        newUserID,
                        DBUtil.GetDBRowCreatorModifier(),
                        faLeistungId);
                }
            }
        }

        private void SetEditMode()
        {
            // _mode = "E": wenn "Wechsel Mandatsträgerin" geklickt wurde, _mode == "M":  Normalzustand
            if (qryVmMassnahme["Typ"] == null)
            {
                return;
            }

            bool allowEdit = qryVmMassnahme.CanUpdate && qryVmMassnahme["Typ"].ToString() == "M";

            edtDatumVon.EditMode = allowEdit ? EditModeType.Normal : EditModeType.ReadOnly;
            edtDatumBis.EditMode = allowEdit ? EditModeType.Normal : EditModeType.ReadOnly;
            edtZGBCodes.EditMode = allowEdit ? EditModeType.Normal : EditModeType.ReadOnly;
        }

        /// <summary>
        /// Setup für das logische Löschen.
        /// </summary>
        private void SetupLogischesLoeschen()
        {
            //Positionierung der RadioGrp
            radGrpDeleted.Top = edtBeschlussVonSuche.Top;

            //GridView setzen
            GridView = grvVmMassnahme;
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            btnNeueMT.Enabled = (tabControlSearch.SelectedTabIndex == 0);
        }

        #endregion

        #endregion
    }
}