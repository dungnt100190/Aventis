using System;
using System.ComponentModel;

using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Basis.ZH
{
    public partial class CtlBaPersonArbeit : KissUserControl
    {
        private int _baPersonID;
        private SqlQuery _ctlBaPersonSqlQuery;

        public CtlBaPersonArbeit()
        {
            InitializeComponent();

            colTyp.ColumnEdit = grdBaArbeitIntegration.GetLOVLookUpEdit((SqlQuery)edtTypCode.Properties.DataSource);
        }

        [DefaultValue(0)]
        public int BaPersonID
        {
            set
            {
                _baPersonID = value;
                qryBaArbeit.Fill(value);
                if ((qryBaArbeit.Count == 0) && qryBaArbeit.CanInsert)
                {
                    qryBaArbeit.Insert();
                }
            }

            get
            {
                return _baPersonID;
            }
        }

        public void Activate()
        {
            edtDatumVon.Focus();
        }

        public bool CtlBaPersonArbeit_CanSaveData()
        {
            if (!qryBaArbeit.Post())
            {
                return false;
            }

            // Damit die Daten unten auch gespeichert werden: !!!
            if (_ctlBaPersonSqlQuery != null)
            {
                if (!_ctlBaPersonSqlQuery.Post())
                {
                    return false;
                }
            }

            return true;
        }

        public void SetRights(bool hasEditRights)
        {
            qryBaArbeit.CanUpdate = hasEditRights;
            qryBaArbeit.CanInsert = hasEditRights;
            qryBaArbeit.CanDelete = hasEditRights;

            qryBaArbeit.ApplyUserRights();
        }

        private void CtlBaPersonArbeit_AddData(object sender, EventArgs e)
        {
            qryBaArbeit.Insert();
        }

        private void CtlBaPersonArbeit_DeleteData(object sender, EventArgs e)
        {
            qryBaArbeit.Delete();
        }

        private void CtlBaPersonArbeit_Load(object sender, EventArgs e)
        {
            // Damit CtlBaPerson gespeichert werden kann
            _ctlBaPersonSqlQuery = null;
            if (Parent.Parent.Parent is KissUserControl)
            {
                _ctlBaPersonSqlQuery = (Parent.Parent.Parent as KissUserControl).ActiveSQLQuery;
            }
        }

        private void CtlBaPersonArbeit_MoveFirst(object sender, EventArgs e)
        {
            qryBaArbeit.First();
        }

        private void CtlBaPersonArbeit_MoveLast(object sender, EventArgs e)
        {
            qryBaArbeit.Last();
        }

        private void CtlBaPersonArbeit_MoveNext(object sender, EventArgs e)
        {
            qryBaArbeit.Next();
        }

        private void CtlBaPersonArbeit_MovePrevious(object sender, EventArgs e)
        {
            qryBaArbeit.Previous();
        }

        private void CtlBaPersonArbeit_RefreshData(object sender, EventArgs e)
        {
            if (!qryBaArbeit.Post())
            {
                throw new KissCancelException();
            }

            // Damit die Daten unten auch erneuert werden: !!!
            if (_ctlBaPersonSqlQuery != null)
            {
                if (!_ctlBaPersonSqlQuery.Post())
                {
                    throw new KissCancelException();
                }
            }

            qryBaArbeit.Refresh();
            // Damit die Daten unten auch erneuert werden: !!!
            if (_ctlBaPersonSqlQuery != null)
            {
                _ctlBaPersonSqlQuery.Refresh();
            }
        }

        private void CtlBaPersonArbeit_SaveData(object sender, EventArgs e)
        {
            if (!CtlBaPersonArbeit_CanSaveData())
            {
                throw new KissCancelException();
            }
        }

        private void CtlBaPersonArbeit_UndoDataChanges(object sender, EventArgs e)
        {
            qryBaArbeit.Cancel();
            // Damit die Daten unten auch rückgängog gemacht werden: !!!
            if (_ctlBaPersonSqlQuery != null)
            {
                _ctlBaPersonSqlQuery.Cancel();
            }
        }

        private void dlgArbeitgeber_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = dlgArbeitgeber.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBaArbeit["BaInstitutionID"] = DBNull.Value;
                    qryBaArbeit["InstitutionName"] = DBNull.Value;
                    SetArbeitgeberText();
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT ID$                 = INS.BaInstitutionID,
                       Institution         = INS.Name,
                       Adresse             = INS.Adresse,
                       Typ                 = INS.Typ,
                       InstitutionTypCode$ = INS.InstitutionTypCode,
                       OrtStrasse$         = INS.OrtStrasse
                FROM dbo.vwInstitution INS
                WHERE INS.BaFreigabeStatusCode = 2
                  AND INS.Name LIKE '%' + {0} + '%'
                ORDER BY INS.Name",
                searchString,
                e.ButtonClicked,
                null,
                null,
                null);

            if (!e.Cancel)
            {
                qryBaArbeit["BaInstitutionID"] = dlg[0];
                qryBaArbeit["InstitutionName"] = dlg[1];
                SetArbeitgeberText();
            }
        }

        private void edtAdresse_EditValueChanged(object sender, EventArgs e)
        {
            if (!edtAdresse.UserModified)
            {
                return;
            }

            qryBaArbeit["Adresse"] = edtAdresse.Text;
            SetArbeitgeberText();
        }

        private void edtPensum_EditValueChanged(object sender, EventArgs e)
        {
            var pensum = edtPensum.EditValue as int?;

            if (pensum.HasValue && pensum > 0 && pensum < 90)
            {
                edtGrundTeilzeit.EditMode = EditModeType.Normal;
            }
            else
            {
                if (!DBUtil.IsEmpty(edtGrundTeilzeit.EditValue))
                {
                    edtGrundTeilzeit.EditValue = DBNull.Value;
                }

                edtGrundTeilzeit.EditMode = EditModeType.ReadOnly;
            }
        }

        private void qryBaArbeit_AfterInsert(object sender, EventArgs e)
        {
            qryBaArbeit["BaPersonID"] = BaPersonID;
            edtDatumVon.Focus();
        }

        private void qryBaArbeit_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtDatumVon, lblDatumVon.Text);

            // Kontrollieren, dass Datum von kleiner oder gleich als Datum bis ist:
            if (!DBUtil.IsEmpty(qryBaArbeit["DatumVon"]) && !DBUtil.IsEmpty(qryBaArbeit["DatumBis"]))
            {
                if ((DateTime)qryBaArbeit["DatumVon"] > (DateTime)qryBaArbeit["DatumBis"])
                {
                    edtDatumVon.Focus();
                    KissMsg.ShowInfo(
                        "CtlBaPersonArbeit",
                        "DatumsFehler",
                        "Das Von-Datum muss kleiner oder gleich sein wie das Bis-Datum.");
                    throw new KissCancelException();
                }
            }

            SetArbeitgeberText();
        }

        private void SetArbeitgeberText()
        {
            // Im Gitter entweder Text oder Institution anzeigen
            if (DBUtil.IsEmpty(qryBaArbeit["BaInstitutionID"]))
            {
                qryBaArbeit["Arbeitgeber"] = Utils.ConvertToString(qryBaArbeit["Adresse"]);
            }
            else
            {
                qryBaArbeit["Arbeitgeber"] = Utils.ConvertToString(qryBaArbeit["InstitutionName"]);
            }

            // Wenn leer, auf null setzen
            if (Utils.ConvertToString(qryBaArbeit["Arbeitgeber"]) == "")
            {
                qryBaArbeit["Arbeitgeber"] = DBNull.Value;
            }
        }
    }
}