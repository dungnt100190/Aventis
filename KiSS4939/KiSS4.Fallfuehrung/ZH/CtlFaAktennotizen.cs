using System;
using System.Drawing;
using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fallfuehrung.ZH
{
    public partial class CtlFaAktennotizen : KissSearchUserControl
    {
        private readonly bool _canDelete;
        private readonly bool _canUpdate;
        private int _faFallID = -1;
        private int _faLeistungID = -1;
        private bool _istAlim;
        private bool _istVertraulich;

        public CtlFaAktennotizen()
        {
            InitializeComponent();

            colFaGespraechstypCode.ColumnEdit = grdBesprechungen.GetLOVLookUpEdit(edtFaGespraechstypCode.LOVName); // ohne LOVFilter
            colFaGespraechsStatusCode.ColumnEdit = grdBesprechungen.GetLOVLookUpEdit((SqlQuery)edtFaGespraechsStatusCode.Properties.DataSource);

            edtInhaltRTF.Protected += Protected_Edit;

            bool x;
            Session.GetUserRight(GetType().Name, out x, out x, out _canUpdate, out _canDelete);
        }

        public bool AlwaysOpen
        {
            get { return true; }
        }

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "SELECTEDIDLIST":
                    if (qryFaAktennotiz.Count > 0)
                    {
                        string idList = "";
                        for (int i = 0; i < grvBesprechungen.DataRowCount; i++)
                        {
                            if (idList.Length > 0) idList += ",";
                            idList += grvBesprechungen.GetRowCellValue(i, colFaAktennotizID).ToString();
                        }

                        return idList;
                    }

                    return "null";

                case "SEARCHVALUES":
                    var str = "";
                    if (!DBUtil.IsEmpty(edtSucheDatumVon.Text) && !DBUtil.IsEmpty(edtSucheDatumBis.Text))
                    {
                        str += ", Datum = " + edtSucheDatumVon.Text + " - " + edtSucheDatumBis.Text;
                    }
                    else
                    {
                        if (!DBUtil.IsEmpty(edtSucheDatumVon.Text)) str += ", Datum von = " + edtSucheDatumVon.Text;
                        if (!DBUtil.IsEmpty(edtSucheDatumBis.Text)) str += ", Datum bis = " + edtSucheDatumBis.Text;
                    }

                    if (!DBUtil.IsEmpty(edtSucheGespraechsStatus.Text)) str += ", Status = " + edtSucheGespraechsStatus.Text;
                    if (!DBUtil.IsEmpty(edtSucheStichworte.Text)) str += ", Stichworte = " + edtSucheStichworte.Text;
                    if (!DBUtil.IsEmpty(edtSucheInhalt.Text)) str += ", Inhalt = " + edtSucheInhalt.Text;
                    if (!DBUtil.IsEmpty(edtSucheGespraechstyp.Text)) str += ", Gesprächstyp = " + edtSucheGespraechstyp.Text;
                    if (!DBUtil.IsEmpty(edtSucheOrgUnitID.Text)) str += ", Org.Einheit = " + edtSucheOrgUnitID.Text;
                    if (!DBUtil.IsEmpty(edtSucheUserID.Text)) str += ", Mitarbeiter/in = " + edtSucheUserID.Text;

                    if (str == "")
                    {
                        return "keine";
                    }

                    return str.Substring(2);

                case "FALEISTUNGID":
                    return _faLeistungID;
                case "FAAKTENNOTIZID":
                    return qryFaAktennotiz["FaAktennotizID"];
                case "FT":
                    return DBUtil.ExecuteScalarSQL(@"select BaPersonID from FaFall where FaFallID = {0}", _faFallID);
                case "FALLUSERID":
                    return DBUtil.ExecuteScalarSQL(@"select UserID from FaFall where FaFallID = {0}", _faFallID);
                case "FAFALLID":
                    return _faFallID;
                case "ABSENDER":
                    return 0;
            }
            return base.GetContextValue(fieldName);
        }

        public void Init(string name, Image titleImage, int leistungID, int fallID, bool vertraulich, bool alim)
        {
            picTitel.Image = titleImage;
            lblTitel.Text = name;

            _faFallID = fallID;
            _faLeistungID = leistungID;
            _istVertraulich = vertraulich;
            _istAlim = alim;

            if (_istAlim)
            {
                edtSucheGespraechstyp.LOVFilter = "FA";

                lblSucheGespraechsStatus.Visible = false;
                edtSucheGespraechsStatus.Visible = false;

                edtFaGespraechstypCode.LOVFilter = "FA";
                btnDokument.Context = "FaAktennotizenAlim";

                lblZeit.Visible = false;
                edtZeit.Visible = false;

                lblFaGespraechsStatusCode.Visible = false;
                edtFaGespraechsStatusCode.Visible = false;
                colFaGespraechsStatusCode.Visible = false;

                lblFaDauerCode.Visible = false;
                edtFaDauerCode.Visible = false;

                foreach (var ctl in new Control[] {
                    lblAutor, edtAutor,
                    lblKontaktpartner, edtKontaktpartner,
                    lblStichwort, edtStichwort,
                    lblInhaltRTF, edtInhaltRTF })
                {
                    ctl.Top -= 30;
                }

                edtInhaltRTF.Height += 30;
            }

            kissSearch.SelectParameters = new object[] { _faLeistungID, _istVertraulich };
            tabControlSearch.SelectedTabIndex = 0;
            qryFaAktennotiz.Fill(_faLeistungID, _istVertraulich);
        }

        public override bool OnDeleteData()
        {
            var userIdAutor = qryFaAktennotiz["UserID_Autor"] as int?;
            if (userIdAutor != null && userIdAutor.Value != Session.User.UserID)
            {
                KissMsg.ShowInfo(typeof(CtlFaAktennotizen).Name, "FremdeAktennotizNichtLoeschen", "Diese Aktennotiz darf nicht gelöscht werden da sie von einem anderen Benutzer erfasst worden ist.");
                return true;
            }

            return base.OnDeleteData();
        }

        private void CtlFaAktennotizen_Load(object sender, EventArgs e)
        {
            qryFaAktennotiz.Last();
        }

        private void edtAutor_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var searchString = edtAutor.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            var dlg = new KissLookupDialog();
            if (e.ButtonClicked || !DBUtil.IsEmpty(searchString))
            {
                if (DBUtil.IsEmpty(searchString))
                {
                    searchString = "%";
                }

                if (searchString == ".")
                {
                    e.Cancel = !dlg.SearchData(@"
                        SELECT
                          ID$              = UserID,
                          UserID$          = UserID,
                          DisplayText$     = DisplayText,
                          OrgUnit$         = OrgUnit,
                          [Kürzel]         = LogonName,
                          [Mitarbeiter/in] = NameVorname,
                          [Org. Einheit]   = OrgUnit
                        FROM vwUser  USR
                        WHERE EXISTS (SELECT * FROM FaFall     WHERE FaFallID = {1} AND UserID = USR.UserID)
                          OR  EXISTS (SELECT * FROM FaLeistung WHERE FaFallID = {1} AND (UserID = USR.UserID OR SachbearbeiterID = USR.UserID))
                        ORDER BY NameVorname
                        ", searchString, e.ButtonClicked, _faFallID);
                }
                else
                {
                    e.Cancel = !dlg.SearchData(@"
                        SELECT
                          ID$              = UserID,
                          UserID$          = UserID,
                          DisplayText$     = DisplayText,
                          OrgUnit$         = OrgUnit,
                          [Kürzel]         = LogonName,
                          [Mitarbeiter/in] = NameVorname,
                          [Org. Einheit]   = OrgUnit
                        FROM vwUser
                        WHERE DisplayText LIKE '%' + {0} + '%'
                        ORDER BY NameVorname
                        ", searchString, e.ButtonClicked);
                }

                if (e.Cancel) return;
            }

            qryFaAktennotiz["UserID"] = dlg["UserID$"];
            qryFaAktennotiz["Autor"] = dlg["DisplayText$"];
            qryFaAktennotiz["OrgUnit"] = dlg["OrgUnit$"];
        }

        private void edtSucheOrgUnitID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var searchString = edtSucheOrgUnitID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtSucheOrgUnitID.EditValue = DBNull.Value;
                    edtSucheOrgUnitID.LookupID = DBNull.Value;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              select ID$              = XOU.OrgUnitID,
                     [Org.Einheit]    = XOU.ItemName
              from   XOrgUnit XOU
              where XOU.ItemName like {0} + '%' order by XOU.ItemName",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtSucheOrgUnitID.EditValue = dlg[1];
                edtSucheOrgUnitID.LookupID = dlg[0];
            }
        }

        private void edtSucheUserID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var searchString = edtSucheUserID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            var dlg = new KissLookupDialog();
            if (e.ButtonClicked || !DBUtil.IsEmpty(searchString))
            {
                if (DBUtil.IsEmpty(searchString))
                {
                    searchString = "%";
                }

                if (searchString == ".")
                {
                    e.Cancel = !dlg.SearchData(@"
                        SELECT
                          ID$              = UserID,
                          UserID$          = UserID,
                          DisplayText$     = DisplayText,
                          OrgUnit$         = OrgUnit,
                          [Kürzel]         = LogonName,
                          [Mitarbeiter/in] = NameVorname,
                          [Org. Einheit]   = OrgUnit
                        FROM vwUser  USR
                        WHERE EXISTS (SELECT * FROM FaFall     WHERE FaFallID = {1} AND UserID = USR.UserID)
                          OR  EXISTS (SELECT * FROM FaLeistung WHERE FaFallID = {1} AND (UserID = USR.UserID OR SachbearbeiterID = USR.UserID))
                        ORDER BY NameVorname
                        ", searchString, e.ButtonClicked, _faFallID);
                }
                else
                {
                    e.Cancel = !dlg.SearchData(@"
                        SELECT
                          ID$              = UserID,
                          UserID$          = UserID,
                          DisplayText$     = DisplayText,
                          OrgUnit$         = OrgUnit,
                          [Kürzel]         = LogonName,
                          [Mitarbeiter/in] = NameVorname,
                          [Org. Einheit]   = OrgUnit
                        FROM vwUser
                        WHERE DisplayText LIKE '%' + {0} + '%'
                        ORDER BY NameVorname
                        ", searchString, e.ButtonClicked);
                }

                if (e.Cancel) return;
            }

            edtSucheUserID.EditValue = dlg["DisplayText$"];
            edtSucheUserID.LookupID = dlg["UserID$"];
        }

        // ControlName: edtInhaltRTF
        private void Protected_Edit(object sender, EventArgs e)
        {
            SuspendLayout();
            int pos = edtInhaltRTF.SelectionStart;
            int length = edtInhaltRTF.SelectionLength;
            edtInhaltRTF.SelectAll();
            edtInhaltRTF.SelectionProtected = false;
            edtInhaltRTF.SelectionStart = pos;
            edtInhaltRTF.SelectionLength = length;
            ResumeLayout();
        }

        private void qryFaAktennotiz_AfterFill(object sender, EventArgs e)
        {
            qryFaAktennotiz.Last();
        }

        private void qryFaAktennotiz_AfterInsert(object sender, EventArgs e)
        {
            /*
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT USR.UserID, USR.DisplayText, USR.OrgUnit
                FROM FaLeistung      LEI
                  INNER JOIN vwUser  USR on USR.UserID = LEI.UserID
                where  LEI.FaLeistungID = {0}",
                faLeistungID);
            */

            var qry = DBUtil.OpenSQL(@"
                SELECT USR.UserID, USR.DisplayText, USR.OrgUnit
                FROM vwUser  USR
                WHERE USR.UserID = {0}",
                Session.User.UserID);

            qryFaAktennotiz["FaLeistungID"] = _faLeistungID;
            qryFaAktennotiz["Vertraulich"] = _istVertraulich;
            qryFaAktennotiz["UserID"] = qry["UserID"];
            qryFaAktennotiz["Autor"] = qry["DisplayText"];
            qryFaAktennotiz["OrgUnit"] = qry["OrgUnit"];

            qryFaAktennotiz["UserID_Autor"] = Session.User.UserID;
            qryFaAktennotiz["Erstelldatum"] = DateTime.Now;

            Control firstControl = null;
            int minTabIndex = int.MaxValue;
            foreach (Control ctrl in Controls)
            {
                IKissBindableEdit edt = ctrl as IKissBindableEdit;
                if (edt != null && edt.DataMember != string.Empty && ctrl.Visible)
                {
                    if (ctrl.TabIndex < minTabIndex)
                    {
                        minTabIndex = ctrl.TabIndex;
                        firstControl = ctrl;
                    }
                }
            }

            if (firstControl != null)
            {
                firstControl.Focus();
            }
        }

        private void qryFaAktennotiz_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtFaDokBesprDatum, lblDatum.Text);
            // Mantis 1108 DBUtil.CheckNotNullField(edtFaDokBesprStatus, lblStatus.Text);
            DBUtil.CheckNotNullField(edtFaGespraechstypCode, lblFaGespraechstypCode.Text);
            DBUtil.CheckNotNullField(edtAutor, lblAutor.Text);
            DBUtil.CheckNotNullField(edtStichwort, lblStichwort.Text);
        }

        private void qryFaAktennotiz_PositionChanged(object sender, EventArgs e)
        {
            var userIdAutor = qryFaAktennotiz["UserID_Autor"] as int?;
            if (userIdAutor != null)
            {
                var allowEdit = userIdAutor.Value == Session.User.UserID;
                qryFaAktennotiz.CanDelete = allowEdit && _canDelete;
                qryFaAktennotiz.CanUpdate = allowEdit && _canUpdate;
                qryFaAktennotiz.EnableBoundFields(allowEdit);
            }

            UpdateErfassung(userIdAutor);
        }

        private void UpdateErfassung(int? userId)
        {
            var userName = DBUtil.ExecuteScalarSQL(@"
                SELECT DisplayText + ', '
                FROM dbo.vwUser
                WHERE UserID = {0};", userId) as string;

            var datum = qryFaAktennotiz["Erstelldatum"] as DateTime?;
            lblErfassungBenutzerDatum.Text = userName + (datum != null ? datum.Value.ToShortDateString() : string.Empty);
        }
    }
}