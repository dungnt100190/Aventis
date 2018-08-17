using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Dokument;
using KiSS4.Gui;

namespace KiSS4.Common
{
    /// <summary>
    /// Summary description for CtlDynaMask.
    /// </summary>
    public class CtlDynaMask : KissUserControl
    {
        #region Fields

        #region Public Fields

        /// <summary>
        /// Button "Link to BaInstitution."
        /// </summary>
        public KissButton btnLinkBaInstitution = null;

        /// <summary>
        /// Context field name.
        /// </summary>
        public string ContextFldName1 = null;

        /// <summary>
        /// Context field name.
        /// </summary>
        public string ContextFldName2 = null;

        /// <summary>
        /// Context field name.
        /// </summary>
        public string ContextFldName3 = null;

        /// <summary>
        /// Context value.
        /// </summary>
        public object ContextValue1 = null;

        /// <summary>
        /// Context value.
        /// </summary>
        public object ContextValue2 = null;

        /// <summary>
        /// Context value.
        /// </summary>
        public object ContextValue3 = null;

        /// <summary>
        /// Button Edit for BaInstitutionID.
        /// </summary>
        public KissButtonEdit editBaInstitutionID = null;

        /// <summary>
        /// Gets the name of the mask.
        /// </summary>
        /// <value>The name of the mask.</value>
        public string MaskName
        {
            get
            {
                return _maskName;
            }
        }

        #endregion

        #region Private Static Fields

        private static readonly log4net.ILog LOG = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        private int BasisDatum0FldID = 0;
        private System.ComponentModel.IContainer components;
        private KissButtonEdit editAdressat = null;
        private Control editDokuSperre = null;
        private KissButtonEdit editKontaktperson = null;
        private XDokument editXDocument = null;
        private int editXDocumentCount = 0;
        private int Frist0FldID = 0;
        private KissGrid gridControl = null;
        private int GridHeight = 0;
        private string IDFieldName;
        private int IDValue = 0;
        private KiSS4.Gui.KissLabel lblNoAccess;
        private string _maskName = null;
        private System.Windows.Forms.PictureBox pictNoAccess;
        private KiSS4.DB.SqlQuery qryData;
        private KiSS4.DB.SqlQuery qryField;
        private int SichtbarSDFldID = 0;
        private KissTabControlEx tabControl = null;
        private int ThemaFldID = 0;
        private string ThemenFilter = "";
        private bool ThemenFilterAktiv = false;
        private bool ZielAuswertung = false;
        private string ZielAuswMaske = "";
        private string ZielMaske = "";
        private int ZielTextAuswFldID = 0;
        private int ZielTextFldID = 0;
        private int ZielThemaAuswFldID = 0;
        private int ZielThemaFldID = 0;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlDynaMask"/> class.
        /// </summary>
        public CtlDynaMask()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CtlDynaMask));
            this.qryData = new KiSS4.DB.SqlQuery(this.components);
            this.qryField = new KiSS4.DB.SqlQuery(this.components);
            this.lblNoAccess = new KiSS4.Gui.KissLabel();
            this.pictNoAccess = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.qryData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNoAccess)).BeginInit();
            this.SuspendLayout();
            //
            // qryData
            //
            this.qryData.AutoApplyUserRights = false;
            this.qryData.HostControl = this;
            this.qryData.BeforeDelete += new System.EventHandler(this.qryData_BeforeDelete);
            this.qryData.PositionChanged += new System.EventHandler(this.qryData_PositionChanged);
            this.qryData.BeforePost += new System.EventHandler(this.qryData_BeforePost);
            this.qryData.AfterInsert += new System.EventHandler(this.qryData_AfterInsert);
            //
            // lblNoAccess
            //
            this.lblNoAccess.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblNoAccess.Location = new System.Drawing.Point(64, 33);
            this.lblNoAccess.Name = "lblNoAccess";
            this.lblNoAccess.Size = new System.Drawing.Size(162, 16);
            this.lblNoAccess.TabIndex = 0;
            this.lblNoAccess.Text = "Zutritt verweigert!";
            //
            // pictNoAccess
            //
            this.pictNoAccess.Image = ((System.Drawing.Image)(resources.GetObject("pictNoAccess.Image")));
            this.pictNoAccess.Location = new System.Drawing.Point(18, 24);
            this.pictNoAccess.Name = "pictNoAccess";
            this.pictNoAccess.Size = new System.Drawing.Size(43, 37);
            this.pictNoAccess.TabIndex = 1;
            this.pictNoAccess.TabStop = false;
            //
            // CtlDynaMask
            //
            this.ActiveSQLQuery = this.qryData;
            this.AutoRefresh = false;
            this.Controls.Add(this.pictNoAccess);
            this.Controls.Add(this.lblNoAccess);
            this.Name = "CtlDynaMask";
            this.Size = new System.Drawing.Size(679, 301);
            ((System.ComponentModel.ISupportInitialize)(this.qryData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNoAccess)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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

        #endregion

        #region EventHandlers

        private void btnLink_Click(object sender, System.EventArgs e)
        {
            if (sender == btnLinkBaInstitution && editBaInstitutionID != null && !DBUtil.IsEmpty(editBaInstitutionID.LookupID))
            {
                FormController.OpenForm("FrmInstitutionenStamm",
                                          "Action", "ShowOrganisation",
                                          "BaInstitutionID", (int)editBaInstitutionID.LookupID);
            }
        }

        private void grid_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.MinWidth == 18) //Auswahl
            {
                foreach (Control ctl in UtilsGui.AllControls(this))
                {
                    KissLookUpEdit edt = ctl as KissLookUpEdit;
                    if (edt != null && edt.DataMember == e.Column.FieldName)
                    {
                        e.DisplayText = edt.GetDisplayText(e.CellValue);
                        break;
                    }
                }
            }
            else if (e.Column.MinWidth == 19) //Mehrfachauswahl
            {
                foreach (Control ctl in UtilsGui.AllControls(this))
                {
                    KissCheckedLookupEdit edt = ctl as KissCheckedLookupEdit;
                    if (edt != null && edt.DataMember == e.Column.FieldName)
                    {
                        e.DisplayText = edt.GetDisplayText(e.CellValue.ToString());
                        break;
                    }
                }
            }
        }

        private void grid_DoubleClick(object sender, System.EventArgs e)
        {
            if (editXDocumentCount == 1)
            {
                if (DBUtil.IsEmpty(editXDocument.DocumentID))
                    editXDocument.NewDoc();
                else
                    editXDocument.OpenDoc();
            }
        }

        private void qryData_AfterInsert(object sender, System.EventArgs e)
        {
            //Set Default Values
            foreach (DataRow row in qryField.DataTable.Rows)
            {
                try
                {
                    string FldName = "Field" + row["DynaFieldID"].ToString();

                    switch ((int)row["FieldCode"])
                    {
                        case 5: // DateEdit
                            if (Utils.AppCodeContainsToken(row["DefaultValue"], "Heute"))
                                qryData[FldName] = DateTime.Today;
                            else if (Utils.AppCodeContainsToken(row["DefaultValue"], "1.Jan"))
                                qryData[FldName] = new DateTime(DateTime.Today.Year, 1, 1);
                            else if (Utils.AppCodeContainsToken(row["DefaultValue"], "31.Dez"))
                                qryData[FldName] = new DateTime(DateTime.Today.Year, 12, 31);
                            break;

                        case 6: // TimeEdit
                            if (Utils.AppCodeContainsToken(row["DefaultValue"], "Jetzt"))
                                qryData[FldName] = DateTime.Now.TimeOfDay;
                            break;

                        case 7: // Checkbox
                            if (Utils.AppCodeContainsToken(row["DefaultValue"], "Ja"))
                                qryData[FldName] = true;
                            else
                                qryData[FldName] = false;
                            break;
                    }

                    //Sichtbar SD
                    if (Utils.AppCodeContainsToken(row["DefaultValue"], "sichtbarSD"))
                    {
                        int BaPersonID = (int)this.GetContextValue("BaPersonID");
                        switch ((int)row["FieldCode"])
                        {
                            case 7: //Checkbox
                                qryData[FldName] = DBUtil.ExecuteScalarSQLThrowingException(
                                     "SELECT SichtbarSDFlag FROM BaPerson WHERE BaPersonID = {0}",
                                     BaPersonID);
                                break;
                        }
                    }

                    //Klient
                    if (Utils.AppCodeContainsToken(row["DefaultValue"], "Klient"))
                    {
                        int BaPersonID = (int)this.GetContextValue("BaPersonID");
                        switch ((int)row["FieldCode"])
                        {
                            case 2: //Text
                                qryData[FldName] = DBUtil.ExecuteScalarSQL(
                                    "SELECT NameVorname FROM vwPerson WHERE BaPersonID = {0}",
                                    BaPersonID);
                                break;

                            case 8: //Auswahl
                            case 9: //Mehrfachauswahl
                            case 14: //Auswahl mit Dialog
                                qryData[FldName] = BaPersonID;
                                break;
                        }
                    }

                    //angemeldeter oder zuständiger Benutzer
                    int UserID = 0;
                    if (Utils.AppCodeContainsToken(row["DefaultValue"], "Benutzer"))
                        UserID = Session.User.UserID;
                    else if (Utils.AppCodeContainsToken(row["DefaultValue"], "ZustBenutzer"))
                        UserID = (int)this.GetContextValue("OwnerPersonID");

                    if (UserID != 0)
                    {
                        switch ((int)row["FieldCode"])
                        {
                            case 2: //Text
                                qryData[FldName] = DBUtil.ExecuteScalarSQL(
                                    "SELECT Lastname + IsNull(', ' + Firstname,'') FROM XUser WHERE UserID = {0}",
                                    UserID);
                                break;

                            case 8: //Auswahl
                            case 9: //Mehrfachauswahl
                            case 14: //Auswahl mit Dialog
                                qryData[FldName] = UserID;
                                break;
                        }
                    }
                }
                catch { }
            }

            //Focus to first Control in Tab Order
            int Pos = -1;
            foreach (DataRow row in qryField.DataTable.Rows)
            {
                if ((int)row["FieldCode"] > 1)
                {
                    Pos = (int)row["TabPosition"];
                    break;
                }
            }

            if (Pos != -1)
            {
                if (tabControl == null)
                {
                    foreach (Control ctl in this.Controls)
                    {
                        if (ctl.Tag != null)
                        {
                            DataRow row = (DataRow)ctl.Tag;
                            if (((int)row["TabPosition"]) == Pos)
                            {
                                ctl.Focus();
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void qryData_BeforeDelete(object sender, System.EventArgs e)
        {
            Session.BeginTransaction();
            try
            {
                // Löschen der gelesenen DynaValue
                foreach (DataRow row in qryField.DataTable.Rows)
                {
                    if (ZielAuswertung && ((int)row["DynaFieldID"] == ZielTextAuswFldID || (int)row["DynaFieldID"] == ZielThemaAuswFldID))
                    {
                        continue;
                    }
                    else if ((int)row["FieldCode"] != 1 && (int)row["FieldCode"] != 13 && (int)row["FieldCode"] != 16)  //alle ausser Label, WordBericht, Schaltfläche
                    {
                        string ColName = "Field" + row["DynaFieldID"].ToString();

                        string DataFld = "Value";
                        if ((int)row["FieldCode"] == 15)
                            DataFld = "ValueText"; //RTF-Memo

                        if (!DBUtil.IsEmpty(qryData[ColName, DataRowVersion.Original]))
                        {
                            string strQuery = @"
                                --SQLCHECK_IGNORE--
                                DELETE
                                FROM dbo.DynaValue
                                WHERE " + IDFieldName + @" = {0}
                                AND DynaFieldID = {1}
                                AND GridRowID = {2}";

                            switch ((int)row["FieldCode"])
                            {
                                case 15:  // RTF-Memo
                                    break;

                                case 2:  // Text
                                case 3:  // Memo
                                case 9:  // Mehrfachauswahl
                                    strQuery += " AND CONVERT(varchar(8000), " + DataFld + ") = CONVERT(varchar(8000), {3})";
                                    break;

                                default:
                                    strQuery += " AND " + DataFld + " = {3}";
                                    break;
                            }

                            int RowCount = (int)DBUtil.ExecuteScalarSQL(strQuery + "\r\nselect @@RowCount",
                              this.IDValue,
                              row["DynaFieldID"],
                              qryData["GridRowID"],
                              qryData[ColName, DataRowVersion.Original]);

                            if (RowCount == 0)
                            {
                                throw new KissErrorException(qryData.TimestampMessage);
                            }

                            if ((int)row["FieldCode"] == 12) // WordDokument
                                DBUtil.ExecSQL("DELETE FROM dbo.XDocument WHERE DocumentID = {0}",
                                  qryData[ColName, DataRowVersion.Original]);
                        }
                    }
                }

                // Check: weitere DynaValue (Durch anderen Benutzer erstellt)
                if (0 != (int)DBUtil.ExecuteScalarSQL(@"
                  --SQLCHECK_IGNORE--
                  SELECT COUNT(1)
                  FROM dbo.DynaValue         VAL
                    INNER JOIN dbo.DynaField FLD ON FLD.DynaFieldID = VAL.DynaFieldID
                  WHERE " + IDFieldName + @" = {0}
                    AND GridRowID = {1}
                    AND FLD.MaskName = CONVERT(VARCHAR(100), {2})", IDValue, qryData["GridRowID"], _maskName))
                {
                    throw new KissErrorException(qryData.TimestampMessage);
                }

                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();

                // Eintrag ins Log.
                LOG.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);

                // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                XLog.Create(GetType().FullName, LogLevel.ERROR, ex.Message);

                throw;
            }

            this.qryData.Row.AcceptChanges();
        }

        private void qryData_BeforePost(object sender, System.EventArgs e)
        {
            //AutoFrist für BasisDatum0 / Frist0
            if (BasisDatum0FldID != 0 && Frist0FldID != 0)
            {
                string BasisDatum0FldName = "Field" + BasisDatum0FldID.ToString();
                string Frist0FldName = "Field" + Frist0FldID.ToString();

                if (!DBUtil.IsEmpty(qryData[BasisDatum0FldName]) && DBUtil.IsEmpty(qryData[Frist0FldName]))
                {
                    DateTime d = (DateTime)qryData[BasisDatum0FldName];
                    int MonthOffset = 4;
                    if (d.Day <= 5)
                        MonthOffset = 3;

                    d = new DateTime(d.Year, d.Month, 1);
                    d = d.AddMonths(MonthOffset).AddDays(-1);

                    qryData[Frist0FldName] = d;
                }
            }

            //check mandatory Fields
            foreach (DataRow row in qryField.DataTable.Rows)
            {
                string ColName = "Field" + row["DynaFieldID"].ToString();

                if ((int)row["FieldCode"] != 1 && (int)row["FieldCode"] != 13 && (int)row["FieldCode"] != 16
                    && !DBUtil.IsEmpty(qryData[ColName]))  //alle ausser Label, WordBericht, Schaltfläche
                {
                    try
                    {
                        switch ((int)row["FieldCode"])
                        {
                            case 4: //CalcEdit (Zahl)
                                if (!(qryData[ColName] is decimal))
                                    qryData[ColName] = decimal.Parse(qryData[ColName].ToString());
                                break;

                            case 5: // Datum
                            case 6: // Zeit
                                if (!(qryData[ColName] is DateTime))
                                    qryData[ColName] = DateTime.Parse(qryData[ColName].ToString());
                                break;

                            case 7: //Checkbox
                                if (!(qryData[ColName] is bool))
                                    if (qryData[ColName].Equals("1"))
                                        qryData[ColName] = true;
                                    else if (qryData[ColName].Equals("0"))
                                        qryData[ColName] = false;
                                    else
                                        qryData[ColName] = bool.Parse(qryData[ColName].ToString());
                                break;

                            case 8:  //Lookup
                            case 12: //Dokument
                            case 14: //Button Edit (Auswahl mit Dialog)
                                if (!(qryData[ColName] is int))
                                    qryData[ColName] = int.Parse(qryData[ColName].ToString());
                                break;
                        }
                    }
                    catch { }
                }

                if (!DBUtil.IsEmpty(row["Mandatory"]) &&
                    (bool)row["Mandatory"] &&
                    (int)row["FieldCode"] != 1 &&
                    (int)row["FieldCode"] != 13 &&
                    (int)row["FieldCode"] != 16)  //Mussfelder ausser Label, WordBericht, Schaltfläche
                {
                    if (DBUtil.IsEmpty(qryData[ColName]))
                    {
                        if (DBUtil.IsEmpty(row["DisplayText"]))
                            KissMsg.ShowInfo("CtlDynaMask", "Min1FeldAusgefuellt", "Mindestens ein Mussfeld ist nicht ausgefüllt (Textmarke: {0})!", 0, 0, row["FieldName"].ToString());
                        else
                            KissMsg.ShowInfo("CtlDynaMask", "FeldLeer", "Das Feld '{0}' darf nicht leer bleiben !", 0, 0, row["DisplayText"].ToString());

                        Control ctl = GetControl(row);
                        if (ctl != null)
                            ctl.Focus();

                        throw new KissCancelException();
                    }
                }
            }

            this.qryData.RefreshDisplay();

            Session.BeginTransaction();

            try
            {
                //calculate new GridRowID
                if (DBUtil.IsEmpty(qryData["GridRowID"]))
                {
                    qryData["GridRowID"] = DBUtil.ExecuteScalarSQL(@"
                        --SQLCHECK_IGNORE--
                        SELECT NewID = ISNULL(MAX(VAL.GridRowID), 0) + 1
                        FROM dbo.DynaValue         VAL
                          INNER JOIN dbo.DynaField FLD ON FLD.DynaFieldID = VAL.DynaFieldID
                        WHERE " + IDFieldName + @" = {0}
                          AND MaskName = CONVERT(VARCHAR(100), {1});", IDValue, _maskName);
                }

                //save all changed columns of current row
                foreach (DataRow row in qryField.DataTable.Rows)
                {
                    if (ZielAuswertung && ((int)row["DynaFieldID"] == ZielTextAuswFldID || (int)row["DynaFieldID"] == ZielThemaAuswFldID))
                    {
                        continue;
                    }
                    else if ((int)row["FieldCode"] != 1 && (int)row["FieldCode"] != 13 && (int)row["FieldCode"] != 16) //alle ausser Label, WordBericht, Schaltfläche
                    {
                        string ColName = "Field" + row["DynaFieldID"].ToString();

                        string DataFld = "Value";
                        if ((int)row["FieldCode"] == 15)
                            DataFld = "ValueText"; //RTF-Memo

                        if ((qryData.Row.RowState == DataRowState.Modified && qryData.ColumnModified(ColName)) ||
                          (qryData.Row.RowState == DataRowState.Added && !DBUtil.IsEmpty(qryData[ColName])))
                        {
                            string strQuery;

                            if (qryData.Row.RowState == DataRowState.Added ||
                              DBUtil.IsEmpty(qryData[ColName, DataRowVersion.Original]))
                            {
                                strQuery = @"
                                  if not exists (select 1 from DynaValue
                                                 where  " + IDFieldName + @" = {0} and
                                                        DynaFieldID = {1} and
                                                        GridRowID = {2})
                                  begin
                                      insert DynaValue
                                          (" + IDFieldName + @",DynaFieldID," + DataFld + @",GridRowID,CreationDate)
                                      values
                                          ({0},{1},{3},{2},getdate())
                                  end";
                            }
                            else
                            {
                                if (DBUtil.IsEmpty(qryData[ColName]))
                                {
                                    strQuery = @"
                                      --SQLCHECK_IGNORE--
                                      DELETE
                                      FROM dbo.DynaValue
                                      WHERE " + IDFieldName + @" = {0}
                                        AND DynaFieldID = {1}
                                        AND GridRowID = {2}";
                                }
                                else
                                {
                                    strQuery = @"
                                      --SQLCHECK_IGNORE--
                                      UPDATE dbo.DynaValue
                                      SET " + DataFld + @" = {3},
                                          CreationDate = GETDATE()
                                      WHERE " + IDFieldName + @" = {0}
                                        AND DynaFieldID = {1}
                                        AND GridRowID = {2}";
                                }

                                switch ((int)row["FieldCode"])
                                {
                                    case 15:  // RTF-Memo
                                        break;

                                    case 2:  // Text
                                    case 3:  // Memo
                                    case 9:  // Mehrfachauswahl
                                        strQuery += " AND CONVERT(VARCHAR(8000), " + DataFld + ") = CONVERT(VARCHAR(8000), {4})";
                                        break;

                                    default:
                                        strQuery += " AND " + DataFld + " = {4}";
                                        break;
                                }
                            }

                            int RowCount = (int)DBUtil.ExecuteScalarSQL(strQuery + "\r\nSELECT @@RowCount",
                              IDValue,
                              row["DynaFieldID"],
                              qryData["GridRowID"],
                              qryData[ColName],
                              qryData.Row.HasVersion(DataRowVersion.Original) ? qryData[ColName, DataRowVersion.Original] : null);

                            if (RowCount == 0)
                            {
                                object OldValue = qryData.Row.HasVersion(DataRowVersion.Original) ? qryData[ColName, DataRowVersion.Original] : null;
                                string Transaktion = "keiner";
                                if (Session.Transaction != null)
                                    Transaktion = Session.Transaction.IsolationLevel.ToString();

                                throw new KissErrorException(this.qryData.TimestampMessage,
                                  "sql: " + strQuery + "\r\n\r\n" +
                                  "{0}: IDValue: " + this.IDValue.ToString() + "\r\n" +
                                  "{1}: DynaFieldID: " + row["DynaFieldID"].ToString() + "\r\n" +
                                  "{2}: GridRowID: " + qryData["GridRowID"].ToString() + "\r\n" +
                                  "{3}: Value: " + qryData[ColName].ToString() + "\r\n" +
                                  "{4}: OldValue: " + OldValue.ToString() + "\r\n" +
                                  "Transaktionslevel: " + Transaktion,
                                  null);
                            }
                        }
                    }
                }
                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();

                // Eintrag ins Log.
                LOG.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);

                // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                XLog.Create(GetType().FullName, LogLevel.ERROR, ex.Message);

                throw;
            }

            qryData.Row.AcceptChanges();
            qryData.RowModified = false;
            DokuSperre();
        }

        private void qryData_PositionChanged(object sender, System.EventArgs e)
        {
            DokuSperre();
            qryData.EnableBoundFields(qryData.CanUpdate && qryData.Count > 0);
        }

        #endregion

        #region Methods

        #region Public Static Methods

        [Obsolete]
        public static string GetSubstituteMask(string MaskName, string AppCode)
        {
            int idx = AppCode.IndexOf("[=");
            if (idx == -1)
                return MaskName;

            string MaskToken = AppCode.Substring(idx + 2);
            idx = MaskToken.IndexOf("]");
            if (idx == -1)
            {
                KissMsg.ShowInfo("CtlDynaMask", "FehlerPCode", "Eigene Masken: Syntax Fehler im P-Code: Abschlusszeichen ']' fehlt\r\nMaske :\t {0}\r\nP-Code:\t {1}", 0, 0, MaskName, AppCode);
            }
            else
            {
                MaskToken = MaskToken.Substring(0, idx);
                SqlQuery qry = DBUtil.OpenSQL("select 1 from DynaMask where MaskName = CONVERT(varchar(100), {0})", MaskToken);
                if (qry.Count == 0)
                {
                    KissMsg.ShowInfo("CtlDynaMask", "MaskeNichtGefunden", "Eigene Masken: Basismaske nicht gefunden\r\nMaske :\t {0}\r\nP-Code:\t {1}", 0, 0, MaskName, AppCode);
                }
                else
                {
                    MaskName = MaskToken;
                }
            }

            return MaskName;
        }

        #endregion

        #region Public Methods

        public override object GetContextValue(string FieldName)
        {
            switch (FieldName.ToUpper())
            {
                case "BAPERSONID":
                    if (IDFieldName == "FaPhaseID")
                    {
                        return (int)DBUtil.ExecuteScalarSQL(@"
                            SELECT BaPersonID
                            FROM FaPhase PHA
                              INNER JOIN FaLeistung FAL ON FAL.FaLeistungID = PHA.FaLeistungID
                            WHERE FaPhaseID = {0}",
                            IDValue);
                    }
                    else if (IDFieldName == "FaLeistungID")
                        return (int)DBUtil.ExecuteScalarSQL("SELECT BaPersonID FROM FaLeistung WHERE FaLeistungID = {0}", IDValue);
                    break;

                case "FAFALLID":
                    // TODO
                    break;

                case "FALEISTUNGID":
                    if (IDFieldName == "FaLeistungID")
                        return IDValue;
                    else
                        return (int)DBUtil.ExecuteScalarSQL("select FaLeistungID from FaPhase where FaPhaseID = {0}", IDValue);

                case "FAPHASEID":
                    if (IDFieldName == "FaPhaseID")
                        return IDValue;
                    break;

                case "GRIDROWID":
                    if (qryData.Count > 0)
                        return qryData["GridRowID"];
                    else
                        return DBNull.Value;

                case "OWNERUSERID":
                    if (IDFieldName == "FaPhaseID")
                        return (int)DBUtil.ExecuteScalarSQL("select UserID from FaPhase where FaPhaseID = {0}", IDValue);
                    else if (IDFieldName == "FaLeistungID")
                        return (int)DBUtil.ExecuteScalarSQL("select UserID from FaLeistung where FaLeistungID = {0}", IDValue);
                    break;

                case "ADRESSATID":
                    if (editAdressat != null)
                    {
                        // #4560 and #5758: validate if LookupID has any value, otherwise, an error would appear
                        // (use 0 as (-) is BaInstitution and (+) is BaPerson)
                        return (DBUtil.IsEmpty(editAdressat.LookupID) ? 0 : editAdressat.LookupID);
                    }
                    break;

                case "KONTAKTID":
                    if (editKontaktperson != null)
                        return editKontaktperson.LookupID;
                    break;

                case "THEMENFILTER":
                    if (this.ThemenFilterAktiv)
                        return this.ThemenFilter;
                    else
                        return "-";
            }

            if (FieldName.Equals(ContextFldName1, StringComparison.InvariantCultureIgnoreCase))
                return ContextValue1;
            else if (FieldName.Equals(ContextFldName2, StringComparison.InvariantCultureIgnoreCase))
                return ContextValue2;
            else if (FieldName.Equals(ContextFldName3, StringComparison.InvariantCultureIgnoreCase))
                return ContextValue3;

            return base.GetContextValue(FieldName);
        }

        public void Init(string titleName, Image titleImage, int faLeistungID, int faPhaseID, string maskName,
            bool ThemenFilterAktiv, string ThemenFilter)
        {
            this._maskName = maskName;
            this.ThemenFilter = ThemenFilter;
            this.ThemenFilterAktiv = ThemenFilterAktiv;

            if (faPhaseID > 0)
            {
                IDValue = faPhaseID;
                IDFieldName = "FaPhaseID";
            }
            else
            {
                IDValue = faLeistungID;
                IDFieldName = "FaLeistungID";
            }

            //generelles Zugriffsrecht prüfen
            if (!DBUtil.UserHasRight(maskName))
                return;  //keep "Zutritt verweigert"

            this.Controls.Clear(); //clear "Zutritt verweigert"

            //Ziele
            ZielAuswertung = false;

            if (faPhaseID > 0)
            {
                int FaPhaseCode = (int)DBUtil.ExecuteScalarSQL(@"SELECT FaPhaseCode FROM FaPhase WHERE FaPhaseID = {0}", faPhaseID);

                SqlQuery qryZiel = DBUtil.OpenSQL(@"
                    select
                        ZielMaske          = (select MaskName from DynaMask where AppCode like '%[[]Ziel]%' and FaPhaseCode = {0}),
                        ZielAuswMaske      = (select MaskName from DynaMask where AppCode like '%[[]ZielAusw]%' and FaPhaseCode = {0}),
                        ZielTextFldID      = isNull((select DynaFieldID
                                                     from   DynaField FLD
                                                            inner join DynaMask MSK on MSK.MaskName = FLD.Maskname
                                                     where  FLD.AppCode like '%[[]ZielText]%' and
                                                            FaPhaseCode = {0}),0),
                        ZielTextAuswFldID  = isNull((select DynaFieldID
                                                     from   DynaField FLD
                                                            inner join DynaMask MSK on MSK.MaskName = FLD.Maskname
                                                     where  FLD.AppCode like '%[[]ZielTextAusw]%' and
                                                            FaPhaseCode = {0}),0),
                        ZielThemaFldID     = isNull((select DynaFieldID
                                                     from   DynaField FLD
                                                            inner join DynaMask MSK on MSK.MaskName = FLD.Maskname
                                                     where  FLD.AppCode like '%[[]ZielThema]%' and
                                                            FaPhaseCode = {0}),0),
                        ZielThemaAuswFldID = isNull((select DynaFieldID
                                                     from   DynaField FLD
                                                            inner join DynaMask MSK on MSK.MaskName = FLD.Maskname
                                                     where  FLD.AppCode like '%[[]ZielThemaAusw]%' and
                                                            FaPhaseCode = {0}),0)",
                     FaPhaseCode);

                ZielMaske = qryZiel["ZielMaske"].ToString();
                ZielAuswMaske = qryZiel["ZielAuswMaske"].ToString();
                ZielTextFldID = (int)qryZiel["ZielTextFldID"];
                ZielTextAuswFldID = (int)qryZiel["ZielTextAuswFldID"];
                ZielThemaFldID = (int)qryZiel["ZielThemaFldID"];
                ZielThemaAuswFldID = (int)qryZiel["ZielThemaAuswFldID"];

                ZielAuswertung = (ZielAuswMaske == maskName && ZielMaske != "" &&
                                      ZielTextFldID > 0 && ZielTextAuswFldID > 0 &&
                                      ZielThemaFldID > 0 && ZielThemaAuswFldID > 0);
            }
            else
            {
                SqlQuery qrySichtbar = DBUtil.OpenSQL(@"
                    select SichtbarSDFldID    = isNull((select DynaFieldID
                                                     from   DynaField FLD
                                                     where  FLD.DefaultValue like '%[[]sichtbarSD]%' and
                                                            FLD.MaskName = {0}),0)",
                     maskName);

                SichtbarSDFldID = (int)qrySichtbar["SichtbarSDFldID"];
            }

            //Feld- und Maskendefinitionen laden
            qryField.Fill(@"
                select	MSK.FaModulCode, MSK.TabNames, MSK.GridHeight, MaskAppCode = MSK.AppCode, FLD.*,
                        MLText = IsNull(dbo.fnGetMLText(FLD.DisplayTextTID, {1}), FLD.DisplayText)
                from	DynaMask MSK
                        inner join DynaField FLD on MSK.MaskName = FLD.MaskName
                where	MSK.MaskName = CONVERT(varchar(100), {0})
                order by FLD.TabPosition",
                maskName, Session.User.LanguageCode);

            if (qryField.Count == 0)
                return;

            //Maske aufbauen
            GridHeight = 0;
            try
            {
                GridHeight = (int)qryField["GridHeight"];
            }
            catch { GridHeight = 0; }

            DynaFactory F = new DynaFactory();
            F.BuildMask(qryField.DataTable, this,
                                    titleName, titleImage,
                                    GridHeight, out gridControl,
                                    qryField["TabNames"].ToString(), out tabControl);

            if (gridControl != null)
            {
                gridControl.View.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grid_CustomDrawCell);
                gridControl.View.DoubleClick += new System.EventHandler(this.grid_DoubleClick);
            }

            //AppCode Handling
            foreach (DataRow row in qryField.DataTable.Rows)
            {
                if (Utils.AppCodeContainsToken(row["AppCode"], "Thema"))
                    ThemaFldID = (int)row["DynaFieldID"];

                if (Utils.AppCodeContainsToken(row["AppCode"], "DokuSperre"))
                    editDokuSperre = GetControl(row);

                if (Utils.AppCodeContainsToken(row["AppCode"], "BasisDatum0") && (int)row["FieldCode"] == 5)
                    BasisDatum0FldID = (int)row["DynaFieldID"];

                if (Utils.AppCodeContainsToken(row["AppCode"], "Frist0") && (int)row["FieldCode"] == 5)
                    Frist0FldID = (int)row["DynaFieldID"];

                if (Utils.AppCodeContainsToken(row["AppCode"], "Adressat"))
                    try
                    {
                        editAdressat = (KissButtonEdit)GetControl(row);
                        editAdressat.ContextValue1 = this.GetContextValue("BaPersonID");
                    }
                    catch { }

                if (Utils.AppCodeContainsToken(row["AppCode"], "Kontaktperson"))
                {
                    try
                    {
                        editKontaktperson = (KissButtonEdit)GetControl(row);
                        editKontaktperson.ContextValue1 = this.GetContextValue("BaPersonID");
                    }
                    catch { }
                }

                if (Utils.AppCodeContainsToken(row["AppCode"], "KlientenSystem") &&
                    ((int)row["FieldCode"] == 8 || (int)row["FieldCode"] == 9))
                {
                    KissLookUpEdit lookupEdit = null;
                    KissCheckedLookupEdit checkedlookupEdit = null;

                    if ((int)row["FieldCode"] == 8)
                        lookupEdit = (KissLookUpEdit)GetControl(row);
                    else
                        checkedlookupEdit = (KissCheckedLookupEdit)GetControl(row);

                    int BaPersonID = (int)this.GetContextValue("BaPersonID");

                    SqlQuery qry = DBUtil.OpenSQL(@"
            SELECT Code = NULL, Text = NULL
            UNION ALL
            SELECT DISTINCT PRS.BaPersonID, PRS.NameVorname
            FROM vwPerson  PRS
              LEFT JOIN BaPerson_Relation  DRE1 ON DRE1.BaPersonID_1 = PRS.BaPersonID AND DRE1.BaPersonID_2 = {0}
              LEFT JOIN BaPerson_Relation  DRE2 ON DRE2.BaPersonID_2 = PRS.BaPersonID AND DRE2.BaPersonID_1 = {0}
            WHERE PRS.BaPersonID = {0} OR DRE1.BaPerson_RelationID IS NOT NULL OR DRE2.BaPerson_RelationID IS NOT NULL
            ORDER BY Text", BaPersonID);

                    if ((int)row["FieldCode"] == 8)
                        lookupEdit.LoadQuery(qry);
                    else
                        checkedlookupEdit.SetLookupDataSource(qry);
                }

                if (Utils.AppCodeContainsToken(row["AppCode"], "LinkInstitution") && (GetControl(row) is KissButton))
                {
                    btnLinkBaInstitution = (KissButton)GetControl(row);
                    btnLinkBaInstitution.Click += new System.EventHandler(this.btnLink_Click);
                }

                if (Utils.AppCodeContainsToken(row["AppCode"], "BaInstitutionID") && (GetControl(row) is KissButtonEdit))
                    editBaInstitutionID = (KissButtonEdit)GetControl(row);

                if ((int)row["FieldCode"] == 12)
                {
                    editXDocument = (XDokument)GetControl(row);
                    editXDocumentCount++;
                }
            }

            //prepare data binding
            foreach (Control ctl in UtilsGui.AllControls(this))
            {
                if (ctl is IKissBindableEdit && !(ctl is KissLabel))
                {
                    DataRow row = (DataRow)ctl.Tag;
                    ((IKissBindableEdit)ctl).DataSource = qryData;
                    ((IKissBindableEdit)ctl).DataMember = "Field" + row["DynaFieldID"].ToString();
                }
            }

            ReadData();
        }

        public override void OnRefreshData()
        {
            base.OnRefreshData();
            this.ReadData();
        }

        public void ReadData()
        {
            if (qryField.Count == 0)
                return;

            if (GridHeight > 0)
                gridControl.DataSource = null;

            qryData.UnbindControls();

            SqlQuery qryValue = null;
            if (ZielAuswertung)
            {
                //Spezialfall Auswertung Zielvereinbarungen
                //ummappen der beiden Felder Thema und Ziel
                //alle GridRowID der Zielvereinbarungen müssen vorhanden sein
                qryValue = DBUtil.OpenSQL(@"
                    select case
                           when DF.DynaFieldID = {3} then {4}
                           when DF.DynaFieldID = {5} then {6}
                           else DF.DynaFieldID
                           end DynaFieldID,
                           FieldCode, GridRowID, Value, ValueText
                    from   DynaValue DV
                           inner join DynaField DF on DV.DynaFieldID = DF.DynaFieldID
                    where  DV.FaPhaseID = {0} and
                           ((DF.MaskName = CONVERT(varchar(100), {1}) and DF.DynaFieldID in ({3},{5})) or
                            (DF.MaskName = CONVERT(varchar(100), {2}) and not DF.DynaFieldID in ({4},{6})))
                    order by DV.GridRowID, DF.TabPosition",
                    IDValue,
                    ZielMaske,
                    ZielAuswMaske,
                    ZielTextFldID,
                    ZielTextAuswFldID,
                    ZielThemaFldID,
                    ZielThemaAuswFldID);
            }
            else
            {
                //Normalfall: alle Werte dieser Maske lesen
                qryValue = DBUtil.OpenSQL(@"
                    --SQLCHECK_IGNORE--
                    SELECT DF.DynaFieldID, DF.FieldCode, DV.GridRowID, DV.Value, DV.ValueText
                    FROM dbo.DynaValue         DV
                      INNER JOIN dbo.DynaField DF ON DV.DynaFieldID = DF.DynaFieldID
                    WHERE DV." + IDFieldName + @" = {0}
                      AND DF.MaskName = CONVERT(VARCHAR(100), {1})
                    ORDER BY DV.GridRowID, DF.TabPosition", IDValue, _maskName);
            }

            //create Columns for qryData
            string FldList = "";
            foreach (Control ctl in UtilsGui.AllControls(this))
            {
                if (ctl is IKissBindableEdit && !(ctl is KissLabel))
                {
                    var row = (DataRow)ctl.Tag;

                    if (FldList != "")
                    {
                        FldList += ",";
                    }
                    if (ctl is KissRTFEdit)
                    {
                        FldList += "Field" + row["DynaFieldID"] + " = CONVERT(TEXT, NULL)";
                    }
                    else if (ctl is KissCheckEdit)
                    {
                        FldList += "Field" + row["DynaFieldID"] + " = CONVERT(BIT, NULL)";
                    }
                    else
                    {
                        FldList += "Field" + row["DynaFieldID"] + " = CONVERT(SQL_VARIANT, NULL)";
                    }
                }
            }

            if (FldList != "")
            {
                FldList += ",";
            }

            qryData.Fill(@"
                --SQLCHECK_IGNORE--
                SELECT " + FldList + @"GridRowID = CONVERT(INT, NULL)
                WHERE 1 = 2");

            qryData.UnbindControls();

            //transfer Data from qryValue to qryData
            qryData.HostControl = null;

            int CurrGridRowID = -1;
            DataRow NewRow = null;

            qryData.IsFilling = true;
            foreach (DataRow row in qryValue.DataTable.Rows)
            {
                if ((int)row["GridRowID"] != CurrGridRowID)
                {
                    CurrGridRowID = (int)row["GridRowID"];
                    // insert new row
                    NewRow = qryData.DataTable.NewRow();
                    qryData.DataTable.Rows.Add(NewRow);
                    NewRow["GridRowID"] = CurrGridRowID;
                }

                try
                {
                    string FieldName = "Field" + row["DynaFieldID"].ToString();
                    if ((int)row["FieldCode"] == 15)
                        NewRow[FieldName] = row["ValueText"]; //RTF
                    else
                        NewRow[FieldName] = row["Value"];
                }
                catch { }
            }
            qryData.IsFilling = false;

            //apply ThemaFilter
            if (ThemenFilterAktiv && ThemaFldID != 0)
            {
                for (int i = qryData.DataTable.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow row = qryData.DataTable.Rows[i];
                    string Themen = "," + row["Field" + ThemaFldID.ToString()].ToString() + ",";
                    bool found = false;
                    foreach (string Filter in ThemenFilter.Split(','))
                    {
                        if (Themen.IndexOf("," + Filter + ",") != -1)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                        row.Delete();
                }
            }

            if (!Session.User.IsUserKA && SichtbarSDFldID != 0)
            {
                string FieldName = string.Format("Field{0}", SichtbarSDFldID);

                for (int i = qryData.DataTable.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow row = qryData.DataTable.Rows[i];

                    if (row[FieldName] is bool && !(bool)row[FieldName])
                        row.Delete();
                }
            }

            qryData.DataSet.AcceptChanges();
            qryData.RowModified = false;
            qryData.HostControl = this;

            qryData.CanInsert = true;
            qryData.CanUpdate = true;
            qryData.CanDelete = true;

            //Maskenrecht
            DBUtil.ApplyUserRightsToSqlQuery(this._maskName, qryData);

            string MaskAppCode = qryField.DataTable.Rows[0]["MaskAppCode"].ToString();

            //Fallrechte
            bool AlwaysOpen = Utils.AppCodeContainsToken(MaskAppCode, "ImmerOffen");
            if (AlwaysOpen && !Session.User.IsUserKA)
            {
                //Maske bleibt offen, obwohl Fall bereits geschlossen/archiviert
                SqlQuery qryFallZugriff = DBUtil.OpenSQL(@"
                    SELECT *
                    FROM dbo.fnUserAccess({0}, {1})  ACL",
                    Session.User.UserID,
                    GetContextValue("FaLeistungID"));

                if (Session.User.IsUserAdmin || (bool)qryFallZugriff["IsOwner"])
                {
                    qryData.CanInsert = true;
                    qryData.CanUpdate = true;
                    qryData.CanDelete = true;
                }
                else if (qryFallZugriff.Count == 1)
                {
                    qryData.CanInsert = (bool)qryFallZugriff["MayInsert"];
                    qryData.CanUpdate = (bool)qryFallZugriff["MayUpdate"];
                    qryData.CanDelete = (bool)qryFallZugriff["MayDelete"];
                }
            }
            else
            {
                DBUtil.ApplyFallRightsToSqlQuery((int)GetContextValue("FaLeistungID"), qryData);
            }

            //AppCode-Rechte RechtE, RechtM, RechtL der DynaMask überlagern
            bool RechtE = Utils.AppCodeContainsToken(MaskAppCode, "RechtE");
            bool RechtM = Utils.AppCodeContainsToken(MaskAppCode, "RechtM");
            bool RechtL = Utils.AppCodeContainsToken(MaskAppCode, "RechtL");
            if ((RechtE || RechtM || RechtL) && !Session.User.IsUserKA)
            {
                bool FallClosed = (bool)DBUtil.ExecuteScalarSQL(@"
                    select	convert(bit,case when DatumBis is null then 0 else 1 end)
                    from	FaLeistung
                    where FaLeistungID = {0}",
                    GetContextValue("FaLeistungID"));
                if (RechtE && (!FallClosed || AlwaysOpen))
                    qryData.CanInsert = true;
                if (RechtM && (!FallClosed || AlwaysOpen))
                    qryData.CanUpdate = true;
                if (RechtL && (!FallClosed || AlwaysOpen))
                    qryData.CanDelete = true;
            }

            //Falls Phase bereits abgeschlossen: Keine Rechte
            //Falls Phasenbesitzer und offen: alle Rechte
            if (IDFieldName == "FaPhaseID")
            {
                SqlQuery qryPhase = DBUtil.OpenSQL("SELECT * FROM FaPhase WHERE FaPhaseID = {0}", IDValue);

                if (!DBUtil.IsEmpty(qryPhase["DatumBis"]))
                {
                    qryData.CanInsert = false;
                    qryData.CanUpdate = false;
                    qryData.CanDelete = false;
                }
                else if (!DBUtil.IsEmpty(qryPhase["UserID"]) && (int)qryPhase["UserID"] == Session.User.UserID)
                {
                    qryData.CanInsert = true;
                    qryData.CanUpdate = true;
                    qryData.CanDelete = true;
                }
            }

            if (GridHeight > 0)
            {
                qryData.Last();
                gridControl.DataSource = qryData;
            }
            else
            {
                qryData.CanInsert = false;
                qryData.CanDelete = false;
                if (qryData.Count == 0)
                    qryData.Insert(null);
            }

            // Steuerung Sichtbarkeit des Eintrages für "eigene Masken" welche kein Grid haben!
            bool CheckSichtbarSD = Utils.AppCodeContainsToken(MaskAppCode, "CheckSichtbarSD");
            if (CheckSichtbarSD && !Session.User.IsUserKA)
            {
                bool IsMaskSichtbar = (bool)DBUtil.ExecuteScalarSQL(@"
                    SELECT	CONVERT(BIT, SichtbarSDFlag)
                    FROM dbo.BaPerson WITH (READUNCOMMITTED)
                    WHERE BaPersonID = {0}",
                    GetContextValue("BaPersonID"));

                if (!IsMaskSichtbar)
                {
                    // Maske muss leer und gesperrt sein!
                    qryData.Fill("SELECT 1 WHERE 1 = 2 ");
                    qryData.CanInsert = false;
                    qryData.CanUpdate = false;
                    qryData.CanDelete = false;

                    // Dok-Feld sperren, falls vorhanden ;-)
                    foreach (Control ctl in UtilsGui.AllControls(this))
                    {
                        if (ctl is XDokument)
                            ((XDokument)ctl).EditMode = EditModeType.ReadOnly;

                        if (ctl is KissDocumentButton)
                            ((KissDocumentButton)ctl).Enabled = false;
                    }
                }
            }

            qryData.BindControls();
            DokuSperre();
            qryData.EnableBoundFields(qryData.CanUpdate && qryData.Count > 0);
        }

        /// <summary>
        /// Resizes the child Controls.
        /// </summary>
        public void ResizeControls()
        {
            foreach (Control ctl in UtilsGui.AllControls(this))
            {
                if (ctl is KissGrid)
                {
                    ((KissGrid)ctl).PerformLoad();

                    // select last possible row
                    if (((KissGrid)ctl).View != null)
                    {
                        // we found grid, so jump to last possible row
                        ((KissGrid)ctl).View.MoveLastVisible();
                    }
                }
                else
                {
                    if ((ctl.Anchor & AnchorStyles.Right) == AnchorStyles.Right)
                        ctl.Width = this.Width - ctl.Left - 5;

                    if ((ctl.Anchor & AnchorStyles.Bottom) == AnchorStyles.Bottom)
                        ctl.Height = this.Height - ctl.Top - 5;
                }
            }
        }

        public void SetThemenFilter(bool ThemenFilterAktiv, string ThemenFilter)
        {
            if (this.ThemenFilter == ThemenFilter && this.ThemenFilterAktiv == ThemenFilterAktiv)
                return;
            this.ThemenFilter = ThemenFilter;
            this.ThemenFilterAktiv = ThemenFilterAktiv;
            if (ThemaFldID > 0)
                ReadData(); //refresh
        }

        #endregion

        #region Private Methods

        private void DokuSperre()
        {
            //Spezialfall DokuSperre:
            //Falls es ein Control mit AppCode [DokuSperre] und nicht leerem Inhalt gibt:
            //Alle XDokument-Controls auf ReadOnly setzen und das Control selbst auch
            //ausser: bei admin

            if (!Session.User.IsUserAdmin && editDokuSperre != null && editDokuSperre is BaseEdit)
            {
                bool empty = DBUtil.IsEmpty(((BaseEdit)editDokuSperre).EditValue);

                EditModeType mode;
                if (empty)
                    mode = EditModeType.Normal;
                else
                    mode = EditModeType.ReadOnly;

                foreach (Control ctl in UtilsGui.AllControls(this))
                    if (ctl is XDokument)
                        ((XDokument)ctl).EditMode = mode;

                if (editDokuSperre is IKissEditable)
                    ((IKissEditable)editDokuSperre).EditMode = mode;
            }
        }

        private Control GetControl(DataRow row)
        {
            foreach (Control ctl in UtilsGui.AllControls(this))
            {
                if (row == (DataRow)ctl.Tag)
                    return ctl;
            }
            return null;
        }

        #endregion

        #endregion
    }
}