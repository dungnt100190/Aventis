using System;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraTreeList;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Administration.IBE
{
    public partial class CtlAdTranslation : KissUserControl
    {
        #region Fields

        #region Private Fields

        private string _fieldName = "";
        private string _fieldNamePk = "";
        private int _languageCode;
        private string _tableName = "";

        #endregion

        #endregion

        #region Constructors

        public CtlAdTranslation()
        {
            InitializeComponent();

            SetupColumn(gridColumn1, false);
            SetupColumn(grdcolOtherLanguage, true);
        }

        #endregion

        #region EventHandlers

        private void btnAutoTranslate_Click(object sender, EventArgs e)
        {
            // zuerst speichern, wenn notwendig
            if (qryFields.RowModified)
            {
                if (!qryFields.Post())
                {
                    return;
                }
            }

            // automatisch übersetzen, indem eine vorhandene Übersetzung gesucht wird
            string newText = GetTranslatedText(qryFields["Deutsch"], qryFields[_fieldName + "TID"]);

            if (newText != "")
            {
                qryFields["LangToTranslate"] = newText;
                qryFields.Post();
            }

            qryFields.Next();
        }

        private void btnAutoTranslateAll_Click(object sender, EventArgs e)
        {
            // zuerst speichern, wenn notwendig
            if (qryFields.RowModified)
            {
                if (!qryFields.Post())
                {
                    return;
                }
            }

            // automatisch übersetzen, indem eine vorhandene Übersetzung gesucht wird
            foreach (DataRow row in qryFields.DataTable.Rows)
            {
                if (DBUtil.IsEmpty(row["LangToTranslate"]))
                {
                    string newText = GetTranslatedText(row["Deutsch"], row[_fieldName + "TID"]);
                    if (newText != "")
                    {
                        row["LangToTranslate"] = newText;
                        SaveRow(row);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // zuerst speichern, wenn notwendig
            if (qryFields.RowModified)
            {
                if (!qryFields.Post())
                {
                    return;
                }
            }

            var parent = Parent as KissForm;
            if (parent != null)
            {
                parent.Close();
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            // zuerst speichern, wenn notwendig
            if (qryFields.RowModified)
            {
                if (!qryFields.Post())
                {
                    return;
                }
            }

            // Text 1 zu 1 übertragen
            if (DBUtil.IsEmpty(qryFields["LangToTranslate"]))
            {
                qryFields["LangToTranslate"] = qryFields["Deutsch"];
                qryFields.Post();
            }

            qryFields.Next();
        }

        private void cboLanguages_CloseUp(object sender, CloseUpEventArgs e)
        {
            /*
                       Specifies that the dropdown window was closed because an end user:
              ButtonClick  clicked the editor's dropdown button.
              Cancel       pressed the ESC key or clicked the close button
                       (available for LookUpEdit, CalcEdit and PopupContainerEdit controls).
              CloseUpKey   pressed a shortcut used to close the dropdown (the ALT+DOWN ARROW or RepositoryItemPopupBase.CloseUpKey).
              Immediate    clicked outside the editor.
              Normal       selected an option from the editor's dropdown.
              */

            e.AcceptValue = true;
            if (!e.CloseMode.Equals(PopupCloseMode.Normal))
            {
                return;
            }

            int newValue = (int)e.Value;
            int oldValue = Utils.ConvertToInt(cboLanguages.EditValue);
            if (newValue == oldValue)
            {
                return;
            }

            if (qryFields.RowModified)
            {
                e.AcceptValue = qryFields.Post();
            }

            if (!e.AcceptValue)
            {
                return;
            }

            FillNewLanguage(newValue);
        }

        private void CtlAdTranslation_Load(object sender, EventArgs e)
        {
            qryLanguages.Fill();
            if (qryLanguages.Count > 0)
            {
                cboLanguages.EditValue = Utils.ConvertToInt(qryLanguages["Code"]);
            }

            _languageCode = Utils.ConvertToInt(cboLanguages.EditValue);
            FillNewLanguage(_languageCode);
        }

        private void qryFields_AfterFill(object sender, EventArgs e)
        {
            if (qryFields.Count == 0)
            {
                qryFields_PositionChanged(sender, e);
            }
        }

        private void qryFields_BeforePost(object sender, EventArgs e)
        {
            SaveRow(qryFields.Row);
        }

        private void qryFields_PositionChanged(object sender, EventArgs e)
        {
            btnCopy.Enabled = (qryFields.CanUpdate && qryFields.Count > 0);
            btnAutoTranslate.Enabled = btnCopy.Enabled;
            btnAutoTranslateAll.Enabled = btnCopy.Enabled;
        }

        private void qryFields_PositionChanging(object sender, EventArgs e)
        {
            if (qryFields.RowModified)
            {
                qryFields.Post();
            }
        }

        private void treFelder_AfterFocusNode(object sender, NodeEventArgs e)
        {
            string sql;
            if (treFelder.FocusedNode.Level == 2)
            {
                _tableName = (string)treFelder.FocusedNode.GetValue("TableName");
                _fieldName = (string)treFelder.FocusedNode.GetValue("FieldName");
                _fieldNamePk = (string)treFelder.FocusedNode.GetValue("FieldNamePK");
                lblTitel.Text = _tableName + " " + _fieldName;

                sql = string.Format(@"
                    --SQLCHECK_IGNORE--
                    SELECT
                      X.{2},
                      Deutsch = X.{1},
                      LangToTranslate = LT.Text,
                      X.{1}TID
                    FROM {0} X
                      LEFT OUTER JOIN XLangText LT ON LT.TID = X.{1}TID
                                                  AND LT.LanguageCode = {3}
                    ORDER BY Deutsch;",
                    _tableName,
                    _fieldName,
                    _fieldNamePk,
                    _languageCode.ToString());
            }
            else
            {
                _tableName = "";
                _fieldName = "";
                _fieldNamePk = "";
                lblTitel.Text = "";
                sql = "SELECT ID = NULL, Deutsch = NULL, LangToTranslate = NULL, TID = NULL WHERE 1 = 2;";
            }

            qryFields.Fill(sql);
        }

        private void treFelder_BeforeFocusNode(object sender, BeforeFocusNodeEventArgs e)
        {
            e.CanFocus = true;
            if (e.OldNode == null)
            {
                return;
            }

            if (e.OldNode.Level != 2)
            {
                return;
            }

            if (qryFields.RowModified)
            {
                e.CanFocus = qryFields.Post();
            }
        }

        #endregion

        #region Methods

        #region Private Methods

        private void FillNewLanguage(int aLanguage)
        {
            treFelder.AfterFocusNode -= treFelder_AfterFocusNode;
            _languageCode = aLanguage;
            if (aLanguage == 0)
            {
                grdcolOtherLanguage.Caption = "[Leer]";
                lblText.Text = "[Leer]";
                qryTable.Fill(0);
            }
            else
            {
                grdcolOtherLanguage.Caption = cboLanguages.Properties.GetDisplayText(aLanguage);
                lblText.Text = grdcolOtherLanguage.Caption;
                qryTable.Fill(Utils.ConvertToInt(cboLanguages.EditValue));
            }

            treFelder.AfterFocusNode += treFelder_AfterFocusNode;

            if (qryTable.Count > 2)
            {
                treFelder.Nodes[0].ExpandAll();
                treFelder.Nodes[0].Nodes[0].ExpandAll();
                treFelder.SetFocusedNode(treFelder.Nodes[0].Nodes[0].Nodes[0]);
            }
        }

        private string GetTranslatedText(object lang1, object fieldTID)
        {
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT T1.TID, T2.Text
                FROM XLangText T1
                  LEFT OUTER JOIN XLangText T2 ON T2.TID = T1.TID
                                              AND T2.LanguageCode = {1}
                WHERE T1.LanguageCode = 1
                  AND RTRIM(LTRIM(T1.Text)) LIKE RTRIM(LTRIM({0}))
                  AND T2.Text IS NOT NULL
                  AND ({2}=1 AND T2.TID IS NOT NULL
                    OR {2}=0 AND T2.TID <> {3})",
                lang1,
                _languageCode,
                DBUtil.IsEmpty(fieldTID),
                Utils.ConvertToInt(fieldTID)
                );

            string newText = Utils.ConvertToString(qry["Text"]);
            return newText;
        }

        private void SaveRow(DataRow row)
        {
            if (!DBUtil.IsEmpty(row["LangToTranslate"]))
            {
                string sqlWhere = _fieldNamePk + "=" + Utils.ConvertToInt(row[_fieldNamePk]).ToString();
                SqlQuery qry = DBUtil.OpenSQL(
                    "EXEC dbo.spXSetMLText {0}, {1}, {2}, {3}, {4}, {5}, {6}",
                    row[_fieldName + "TID"],
                    _languageCode,
                    _tableName,
                    _fieldName,
                    sqlWhere,
                    row["Deutsch"],
                    row["LangToTranslate"]
                    );

                if (DBUtil.IsEmpty(row[_fieldName + "TID"]))
                {
                    int newID = Utils.ConvertToInt(qry["TID"]);
                    row[_fieldName + "TID"] = newID;
                }
            }

            qryFields.RowModified = false;
        }

        private void SetupColumn(GridColumn gridColumn, bool editable)
        {
            var backColor = editable ? GuiConfig.GridEditable : GuiConfig.GridReadOnly;

            gridColumn.AppearanceCell.BackColor = backColor;
            gridColumn.AppearanceCell.Options.UseBackColor = true;

            gridColumn.OptionsColumn.AllowEdit = editable;
            gridColumn.OptionsColumn.AllowFocus = editable;
            gridColumn.OptionsColumn.ReadOnly = !editable;
        }

        #endregion

        #endregion
    }
}