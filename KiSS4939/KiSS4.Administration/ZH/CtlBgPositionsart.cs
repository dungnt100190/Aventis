using System;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Administration.ZH
{
    public partial class CtlBgPositionsart : Common.KissSearchUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly ModulID _modul;

        #endregion

        #endregion

        #region Constructors

        public CtlBgPositionsart(ModulID modul)
            : this()
        {
            _modul = modul;
        }

        public CtlBgPositionsart()
        {
            InitializeComponent();

            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in chkEditMaskMonatHigh.Items)
            {
                chkEditMaskMasterLow.Items.Add(new DevExpress.XtraEditors.Controls.CheckedListBoxItem(item.Value));
                chkEditMaskMasterHigh.Items.Add(new DevExpress.XtraEditors.Controls.CheckedListBoxItem(item.Value));
                chkEditMaskMonatLow.Items.Add(new DevExpress.XtraEditors.Controls.CheckedListBoxItem(item.Value));
            }
        }

        #endregion

        #region EventHandlers

        private void chkEditMask_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (qryBgPositionsart.CanUpdate)
            {
                qryBgPositionsart.RowModified = true;
            }
        }

        private void CtlBgPositionsart_Load(object sender, EventArgs e)
        {
            kissSearch.SelectParameters = new object[] { (int)_modul };
            SetupDataMembers();
            SetupFieldNames();

            colBgKategorieCode.ColumnEdit = grdBgPositionsart.GetLOVLookUpEdit("BgKategorie");
            colBgGruppeCode.ColumnEdit = grdBgPositionsart.GetLOVLookUpEdit("BgGruppe");

            qryBgKostenart.Fill((int)_modul);
            edtBgKostenartID.LoadQuery(qryBgKostenart, "BgKostenartID", "NrName");
            colBgKostenartID.ColumnEdit = grdBgPositionsart.GetLOVLookUpEdit(qryBgKostenart, "BgKostenartID", "NrName");

            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT BgKostenartID = NULL, Name = NULL
                UNION ALL
                SELECT BgKostenartID, KontoNr + ' ' + Name
                FROM   BgKostenart
                WHERE ModulID = {0}", (int)_modul);
            edtBgKostenartIDX.LoadQuery(qry, "BgKostenartID", "Name");

            qryBgPositionsart.Fill((int)_modul);
        }

        // ControlName: editReadOnly, ComponentName: qryBgPositionsart
        private void editReadOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (!qryBgPositionsart.Post())
            {
                return;
            }

            qryBgPositionsart.CanDelete = !editReadOnly.Checked;
            qryBgPositionsart.CanInsert = !editReadOnly.Checked;
            qryBgPositionsart.CanUpdate = !editReadOnly.Checked;

            qryBgPositionsartBuchungstext.CanDelete = !editReadOnly.Checked;
            qryBgPositionsartBuchungstext.CanInsert = !editReadOnly.Checked;
            qryBgPositionsartBuchungstext.CanUpdate = !editReadOnly.Checked;

            chkEditMaskMasterLow.EditMode = editReadOnly.Checked ? EditModeType.ReadOnly : EditModeType.Normal;
            chkEditMaskMasterHigh.EditMode = editReadOnly.Checked ? EditModeType.ReadOnly : EditModeType.Normal;
            chkEditMaskMonatLow.EditMode = editReadOnly.Checked ? EditModeType.ReadOnly : EditModeType.Normal;
            chkEditMaskMonatHigh.EditMode = editReadOnly.Checked ? EditModeType.ReadOnly : EditModeType.Normal;

            qryBgPositionsart.ApplyUserRights();
            qryBgPositionsartBuchungstext.ApplyUserRights();

            qryBgPositionsart.Refresh();
        }

        private void edtPositionsartUseText_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtPositionsartUseText.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBgPositionsartBuchungstext[DBO.BgPositionsartBuchungstext.BgPositionsartID_UseText] = DBNull.Value;
                    qryBgPositionsartBuchungstext["Positionsart"] = DBNull.Value;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            const string sql = @"
                SELECT LA                  = BKA.KontoNr,
                       Positionsart        = BPA.Name,
                       Quoting             = BKA.Quoting,
                       Gruppe              = dbo.fnLOVText('BgGruppe', BPA.BgGruppeCode),
                       Kategorie           = dbo.fnLOVText('BgKategorie', BPA.BgKategorieCode),
                       BgPositionsartID$   = BPA.BgPositionsartID,
                       BgKostenartID$      = BPA.BgKostenartID,
                       KOAPositionsart$    = BKA.KontoNr + ' '+ BPA.Name,
                       KOA$                = BKA.KontoNr,
                       Name$               = BPA.Name,
                       BgSplittingArtCode$ = BKA.BgSplittingArtCode,
                       sqlRichtlinie$      = BPA.sqlRichtlinie,
                       BaZahlungswegIDFix$ = BKA.BaZahlungswegIDFix
                FROM dbo.WhPositionsart      BPA WITH (READUNCOMMITTED)
                  INNER JOIN dbo.BgKostenart BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID = BPA.BgKostenartID
                WHERE BPA.BgPositionsartID <> {1}
                  AND (BPA.Name LIKE '%' + {0} + '%'
                    OR BKA.KontoNr LIKE {0} + '%')
                ORDER BY 1, 2, 5, 4;";

            e.Cancel = !dlg.SearchData(sql, searchString, e.ButtonClicked, qryBgPositionsart["BgPositionsartID"], null, null);

            if (!e.Cancel)
            {
                qryBgPositionsartBuchungstext[DBO.BgPositionsartBuchungstext.BgPositionsartID_UseText] = dlg["BgPositionsartID$"];
                qryBgPositionsartBuchungstext["Positionsart"] = dlg["KOAPositionsart$"];
            }
        }

        private void qryBgPositionsart_AfterInsert(object sender, EventArgs e)
        {
            qryBgPositionsart["ModulID"] = _modul;

            edtBgKategorieCode.Focus();
        }

        private void qryBgPositionsart_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtBgGruppeCode, lblBgGruppeCode.Text);
            DBUtil.CheckNotNullField(edtBgKategorieCode, lblBgKategorieCode.Text);
            DBUtil.CheckNotNullField(edtName, lblName.Text);
            DBUtil.CheckNotNullField(edtSortKey, lblSortKey.Text);

            int i = 0;

            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in chkEditMaskMasterLow.Items)
            {
                if (item.CheckState == CheckState.Checked)
                {
                    qryBgPositionsart["Masterbudget_EditMask"] = ((int)qryBgPositionsart["Masterbudget_EditMask"]) | ((int)(Math.Pow(2, i)));
                }
                else
                {
                    qryBgPositionsart["Masterbudget_EditMask"] = ((int)qryBgPositionsart["Masterbudget_EditMask"]) & ~((int)(Math.Pow(2, i)));
                }

                i++;
            }

            i = 0;
            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in chkEditMaskMasterHigh.Items)
            {
                if (item.CheckState == CheckState.Checked)
                {
                    qryBgPositionsart["Masterbudget_EditMask"] = ((int)qryBgPositionsart["Masterbudget_EditMask"]) |
                                                                 ((int)(Math.Pow(2, i) * 0x1000));
                }
                else
                {
                    qryBgPositionsart["Masterbudget_EditMask"] = ((int)qryBgPositionsart["Masterbudget_EditMask"]) &
                                                                 ~((int)(Math.Pow(2, i) * 0x1000));
                }

                i++;
            }

            i = 0;

            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in chkEditMaskMonatLow.Items)
            {
                if (item.CheckState == CheckState.Checked)
                {
                    qryBgPositionsart["Monatsbudget_EditMask"] = ((int)qryBgPositionsart["Monatsbudget_EditMask"]) | ((int)(Math.Pow(2, i)));
                }
                else
                {
                    qryBgPositionsart["Monatsbudget_EditMask"] = ((int)qryBgPositionsart["Monatsbudget_EditMask"]) & ~((int)(Math.Pow(2, i)));
                }

                i++;
            }

            i = 0;
            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in chkEditMaskMonatHigh.Items)
            {
                if (item.CheckState == CheckState.Checked)
                {
                    qryBgPositionsart["Monatsbudget_EditMask"] = ((int)qryBgPositionsart["Monatsbudget_EditMask"]) |
                                                                 ((int)(Math.Pow(2, i) * 0x1000));
                }
                else
                {
                    qryBgPositionsart["Monatsbudget_EditMask"] = ((int)qryBgPositionsart["Monatsbudget_EditMask"]) &
                                                                 ~((int)(Math.Pow(2, i) * 0x1000));
                }

                i++;
            }
        }

        private void qryBgPositionsart_PositionChanged(object sender, EventArgs e)
        {
            int i = 0;

            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in chkEditMaskMasterLow.Items)
            {
                int editMask = ((int)(qryBgPositionsart["Masterbudget_EditMask"]) & 0xFFF);
                item.CheckState = (editMask & ((int)Math.Pow(2, i))) > 0 ? CheckState.Checked : CheckState.Unchecked;

                i++;
            }

            i = 0;

            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in chkEditMaskMasterHigh.Items)
            {
                int editMask = ((int)(qryBgPositionsart["Masterbudget_EditMask"]) & 0xFFF000) / 0x1000;
                item.CheckState = (editMask & ((int)Math.Pow(2, i))) > 0 ? CheckState.Checked : CheckState.Unchecked;

                i++;
            }

            i = 0;

            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in chkEditMaskMonatLow.Items)
            {
                int editMask = ((int)(qryBgPositionsart["Monatsbudget_EditMask"]) & 0xFFF);
                item.CheckState = (editMask & ((int)Math.Pow(2, i))) > 0 ? CheckState.Checked : CheckState.Unchecked;

                i++;
            }

            i = 0;

            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in chkEditMaskMonatHigh.Items)
            {
                int editMask = ((int)(qryBgPositionsart["Monatsbudget_EditMask"]) & 0xFFF000) / 0x1000;
                item.CheckState = (editMask & ((int)Math.Pow(2, i))) > 0 ? CheckState.Checked : CheckState.Unchecked;

                i++;
            }

            qryBgPositionsart.RowModified = false;

            qryBgPositionsartBuchungstext.Fill(qryBgPositionsart["BgPositionsartID"]);
        }

        private void qryBgPositionsartBuchungstext_AfterInsert(object sender, EventArgs e)
        {
            qryBgPositionsartBuchungstext[DBO.BgPositionsartBuchungstext.BgPositionsartID] = qryBgPositionsart["BgPositionsartID"];
            qryBgPositionsartBuchungstext.SetCreator();
            qryBgPositionsartBuchungstext.SetModifierModified();
        }

        private void qryBgPositionsartBuchungstext_BeforePost(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(qryBgPositionsartBuchungstext[DBO.BgPositionsartBuchungstext.BgPositionsartID_UseText]))
            {
                DBUtil.CheckNotNullField(edtBuchungstext, lblBuchungstext.Text);
            }

            // validate default selection (allow only one default)
            if (!DBUtil.IsEmpty(qryBgPositionsartBuchungstext[DBO.BgPositionsartBuchungstext.Standardwert]) &&
                Convert.ToBoolean(qryBgPositionsartBuchungstext[DBO.BgPositionsartBuchungstext.Standardwert]))
            {
                var bgPositionsartID = Convert.ToInt32(qryBgPositionsartBuchungstext[DBO.BgPositionsartBuchungstext.BgPositionsartID]);
                var bgPositionsartBuchungstextID =
                    DBUtil.IsEmpty(qryBgPositionsartBuchungstext[DBO.BgPositionsartBuchungstext.BgPositionsartBuchungstextID])
                        ? -1
                        : Convert.ToInt32(qryBgPositionsartBuchungstext[DBO.BgPositionsartBuchungstext.BgPositionsartBuchungstextID]);

                if (HasAlreadyStandardText(bgPositionsartID, bgPositionsartBuchungstextID))
                {
                    KissMsg.ShowInfo(Name, "StandardTextAlreadyExists", "Für diese Positionsart ist bereits einen Standardwert vorhanden");
                    throw new KissCancelException();
                }
            }

            qryBgPositionsartBuchungstext.SetModifierModified();
        }

        private void tabDetail_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (page == tpgBuchungstext)
            {
                ActiveSQLQuery = qryBgPositionsartBuchungstext;
            }
            else
            {
                ActiveSQLQuery = qryBgPositionsart;
            }
        }

        #endregion

        #region Methods

        #region Private Static Methods

        private static bool HasAlreadyStandardText(int bgPositionsartID, int bgPositionsartBuchungstextID)
        {
            return Convert.ToBoolean(DBUtil.ExecuteScalarSQLThrowingException(@"
                IF (EXISTS(SELECT TOP 1 1
                           FROM dbo.BgPositionsartBuchungstext WITH (READUNCOMMITTED)
                           WHERE BgPositionsartID = {0}
                             AND BgPositionsartBuchungstextID <> {1}
                             AND Standardwert = 1))
                BEGIN
                  SELECT 1;
                END
                ELSE
                BEGIN
                  SELECT 0;
                END;", bgPositionsartID, bgPositionsartBuchungstextID));
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// DataMember von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupDataMembers()
        {
            edtBuchungstext.DataMember = DBO.BgPositionsartBuchungstext.Buchungstext;
            edtStandardwert.DataMember = DBO.BgPositionsartBuchungstext.Standardwert;
        }

        /// <summary>
        /// FieldName für die Kolonen von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupFieldNames()
        {
            colBuchungstext.FieldName = DBO.BgPositionsartBuchungstext.Buchungstext;
            colStandardwert.FieldName = DBO.BgPositionsartBuchungstext.Standardwert;
        }

        #endregion

        private void edtSpezkonto_CheckedChanged(object sender, EventArgs e)
        {
            if (edtSpezkonto.Checked && edtKeinKreditor.Checked)
            {
                edtKeinKreditor.Checked = false;
            }
        }

        #endregion

        private void edtKeinKreditor_CheckedChanged(object sender, EventArgs e)
        {
            if (edtKeinKreditor.Checked && edtSpezkonto.Checked)
            {
                edtSpezkonto.Checked = false;
            }
        }
    }
}