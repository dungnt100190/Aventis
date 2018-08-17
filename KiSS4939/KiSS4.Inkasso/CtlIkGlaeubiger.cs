using System;
using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Inkasso
{
    public partial class CtlIkGlaeubiger : KissUserControl
    {
        #region Fields

        #region Private Fields

        private bool _datenGlaeubigerWurdenKorrigiert;
        private int _faFallID;
        private int? _faLeistungID;
        private int _faProzessCode = -1;
        private int? _ikRechtstitelID;

        #endregion

        #endregion

        #region Constructors

        public CtlIkGlaeubiger()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void chkGanzesKlientensystem_CheckedChanged(object sender, EventArgs e)
        {
            AllesSpeichern();
            GlaeubigerOeffnen();
        }

        private void CtlIkRechtstitelGlaeubiger_MoveFirst(object sender, EventArgs e)
        {
            qryIkGlaeubiger.First();
        }

        private void CtlIkRechtstitelGlaeubiger_MoveLast(object sender, EventArgs e)
        {
            qryIkGlaeubiger.Last();
        }

        private void CtlIkRechtstitelGlaeubiger_MoveNext(object sender, EventArgs e)
        {
            qryIkGlaeubiger.Next();
        }

        private void CtlIkRechtstitelGlaeubiger_MovePrevious(object sender, EventArgs e)
        {
            qryIkGlaeubiger.Previous();
        }

        private void CtlIkRechtstitelGlaeubiger_RefreshData(object sender, EventArgs e)
        {
            CtlIkRechtstitelGlaeubiger_SaveData(sender, e);
            // Daten neu anzeigen:
            GlaeubigerOeffnen();
        }

        private void CtlIkRechtstitelGlaeubiger_SaveData(object sender, EventArgs e)
        {
            AllesSpeichern();
        }

        private void CtlIkRechtstitelGlaeubiger_UndoDataChanges(object sender, EventArgs e)
        {
            // Daten neu anzeigen:
            GlaeubigerOeffnen();
        }

        private void grvGlaeubiger_ShowingEditor(object sender, CancelEventArgs e)
        {
            // Editor freigeben:
            if (grvGlaeubiger.FocusedColumn.FieldName == "IstGlaeubiger")
            {
                e.Cancel = ((bool)qryIkGlaeubiger["HatDaten"] || !qryIkGlaeubiger.CanUpdate);
            }
            else
            {
                if (grvGlaeubiger.FocusedColumn.FieldName == "PersonName")
                {
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = (!(bool)qryIkGlaeubiger["IstGlaeubiger"] || !qryIkGlaeubiger.CanUpdate);
                }
            }
        }

        private void qryIkGlaeubiger_AfterFill(object sender, EventArgs e)
        {
            _datenGlaeubigerWurdenKorrigiert = false;

            if (qryIkGlaeubiger.Count == 0)
            {
                qryIkGlaeubiger_PositionChanged(sender, e);
            }
        }

        private void qryIkGlaeubiger_BeforePost(object sender, EventArgs e)
        {
            _datenGlaeubigerWurdenKorrigiert = true;
        }

        private void qryIkGlaeubiger_PositionChanged(object sender, EventArgs e)
        {
            bool canEdit = (qryIkGlaeubiger.Count > 0 && qryIkGlaeubiger.CanUpdate);
            qryIkGlaeubiger.EnableBoundFields(canEdit);

            // Zahlinfos anzeigen:
            qryZahlInfo.Fill(Utils.ConvertToInt(qryIkGlaeubiger["BaZahlungswegID"]));

            qryAlteKostenstelle.Fill(qryIkGlaeubiger["BaPersonID"]);
        }

        private void qryIkGlaeubiger_PositionChanging(object sender, EventArgs e)
        {
            if (qryIkGlaeubiger.RowModified && !qryIkGlaeubiger.Post())
            {
                throw new KissCancelException();
            }
        }

        private void repchkAktiv_CheckedChanged(object sender, EventArgs e)
        {
            _datenGlaeubigerWurdenKorrigiert = true;

            if (((CheckEdit)sender).Checked)
            {
                if (grvGlaeubiger.FocusedColumn.FieldName == "Aktiv" &&
                    Convert.ToBoolean(qryIkGlaeubiger[DBO.IkGlaeubiger.AuszahlungVermittlungStoppen]))
                {
                    KissMsg.ShowInfo(Name, "AuszahlungVermittlungIstGestoppt", "Die Auszahlung von Vermittlungen ist gestoppt. Es muss zuerst wieder aktiviert werden.");
                    qryIkGlaeubiger[DBO.IkGlaeubiger.Aktiv] = false;
                    grvGlaeubiger.RefreshData();
                    return;
                }

                string personNameVorname = DBUtil.ExecuteScalarSQL(@"
                    SELECT TOP 1 PRS.NameVorname
                    FROM dbo.FaLeistung                    SHL WITH (READUNCOMMITTED)
                      INNER JOIN dbo.BgFinanzplan          FPL WITH (READUNCOMMITTED) ON FPL.FaLeistungID = SHL.FaLeistungID
                      INNER JOIN dbo.BgFinanzplan_BaPerson FPP WITH (READUNCOMMITTED) ON FPP.BgFinanzplanID = FPL.BgFinanzplanID
                      INNER JOIN dbo.IkGlaeubiger          GLB WITH (READUNCOMMITTED) ON GLB.BaPersonID = FPP.BaPersonID
                      INNER JOIN dbo.IkRechtstitel         RTL WITH (READUNCOMMITTED) ON RTL.IkRechtstitelID = GLB.IkRechtstitelID
                      INNER JOIN dbo.FaLeistung            IKL WITH (READUNCOMMITTED) ON IKL.FaLeistungID = RTL.FaLeistungID
                      LEFT JOIN  dbo.vwPerson              PRS ON PRS.BaPersonID = FPP.BaPersonID
                    WHERE FPP.IstUnterstuetzt = 1 -- Unterstützt im Finanzplan
                      AND IKL.FaProzessCode = 401 -- Aliment
                      AND SHL.DatumVon <= GETDATE()
                      AND (SHL.DatumBis IS NULL OR SHL.DatumBis >= GETDATE())
                      AND FPL.BgBewilligungStatusCode = 5 -- Bewilligung erteilt
                      AND FPL.DatumVon <= GETDATE()
                      AND FPL.DatumBis >= GETDATE()
                      AND FPP.BaPersonID = {0}", qryIkGlaeubiger["BaPersonID"]) as string;

                if (personNameVorname != null)
                {
                    KissMsg.ShowInfo(Name, "GlaeubigerInFinanzplanInfo", "{0} ist Fallträger oder aktives Mitglied in einer aktiven Sozialhilfe!", personNameVorname);
                }
            }
        }

        private void repedtCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Damit wir später wissen, dass im Gitter editiert wurde:
            _datenGlaeubigerWurdenKorrigiert = true;

            if (grvGlaeubiger.FocusedColumn.FieldName == "AuszahlungVermittlungStoppen" &&
                !Convert.ToBoolean(qryIkGlaeubiger[DBO.IkGlaeubiger.AuszahlungVermittlungStoppen]))
            {
                var auszahlungStop = KissMsg.ShowQuestion(Name, "AuszahlungVermittlungStoppen", "Soll die Auszahlung von Vermittlungen gestoppt werden?", false);
                if (auszahlungStop)
                {
                    qryIkGlaeubiger[DBO.IkGlaeubiger.Aktiv] = false;
                }
                else
                {
                    qryIkGlaeubiger[DBO.IkGlaeubiger.AuszahlungVermittlungStoppen] = false;
                }

                grvGlaeubiger.RefreshData();
            }
        }

        private void repedtZahlungsweg_CloseUp(object sender, CloseUpEventArgs e)
        {
            // Damit wir später wissen, dass im Gitter editiert wurde:
            e.AcceptValue = true;

            if (!e.CloseMode.Equals(PopupCloseMode.Normal))
            {
                return;
            }

            _datenGlaeubigerWurdenKorrigiert = true;
        }

        #endregion

        #region Methods

        #region Public Static Methods

        public static void GlaeubigerEinfuegen(int faLeistungId, object ikRechtstitelId = null, object baZahlungswegId = null, object bemerkung = null)
        {
            int baPersonId = (int)DBUtil.ExecuteScalarSQL(@"
                SELECT BaPersonID
                FROM dbo.FaLeistung WITH(READUNCOMMITTED)
                WHERE FaLeistungID = {0}",
                faLeistungId);

            bool glaeubigerExists = (bool)DBUtil.ExecuteScalarSQL(@"
                SELECT CONVERT(bit, CASE
                                      WHEN EXISTS(SELECT 1 FROM IkGlaeubiger WHERE FaLeistungID = {0}) THEN 1
                                      ELSE 0
                                    END)",
                faLeistungId);

            if (!glaeubigerExists)
            {
                bemerkung = bemerkung == null ? null : "'" + bemerkung + "'";

                DBUtil.ExecSQL(@"
                    INSERT INTO IkGlaeubiger (FaLeistungID, IkRechtstitelID, BaPersonID, BaZahlungswegID, Aktiv, Bemerkung)
                      VALUES ({0}, {1}, {2}, {3}, 0, {4})",
                    faLeistungId,
                    ikRechtstitelId,
                    baPersonId,
                    baZahlungswegId,
                    bemerkung);
            }
        }

        #endregion

        #region Public Methods

        public bool AllesSpeichern()
        {
            if (!qryIkGlaeubiger.Post()) return false;
            if (!_datenGlaeubigerWurdenKorrigiert) return true;

            IBANNummernChecken();

            Session.BeginTransaction();
            try
            {
                foreach (System.Data.DataRow row in qryIkGlaeubiger.DataTable.Rows)
                {
                    var istGlaeubiger = (bool)row["IstGlaeubiger"];

                    if (DBUtil.IsEmpty(qryIkGlaeubiger.Row[DBO.IkGlaeubiger.BaZahlungswegID]) && (bool)qryIkGlaeubiger.Row[DBO.IkGlaeubiger.Aktiv])
                    {
                        throw new KissInfoException("Die Auszahlung kann nicht aktiviert werden: Es ist keine Zahlungsverbindung definiert.");
                    }

                    if (DBUtil.GetConfigBool(@"System\Inkasso\AntragStellendePersonMuss", true) &&
                        istGlaeubiger &&
                        (bool)row[DBO.IkGlaeubiger.Aktiv] &&
                        (bool)row["IstKind"] &&
                        (bool)row["IstALBV"] &&
                        DBUtil.IsEmpty(row["BaPersonID_AntragStellendePerson"]))
                    {
                        throw new KissInfoException(string.Format("Bei Gläubiger: {0} muss eine antragstellende Person erfasst werden.", row["PersonName"]));
                    }

                    int rowCount = -1;

                    var ikGlaeubigerID = Utils.ConvertToInt(row[DBO.IkGlaeubiger.IkGlaeubigerID]);

                    if (!istGlaeubiger && ikGlaeubigerID > 0)
                    {
                        // Löschen:
                        rowCount = DBUtil.ExecSQLThrowingException(
                            "DELETE dbo.IkGlaeubiger WHERE IkGlaeubigerID = {0} AND IkGlaeubigerTS = {1}",
                            row[DBO.IkGlaeubiger.IkGlaeubigerID],
                            row[DBO.IkGlaeubiger.IkGlaeubigerTS]);
                    }
                    else if (istGlaeubiger && ikGlaeubigerID == 0 && row.RowState != System.Data.DataRowState.Unchanged)
                    {
                        // Einfügen:
                        rowCount = DBUtil.ExecSQLThrowingException(@"
                            INSERT INTO dbo.IkGlaeubiger (FaLeistungID, IkRechtstitelID, BaPersonID, BaPersonID_AntragStellendePerson, BaZahlungswegID, Ausbildung, Bemerkung, Aktiv, AuszahlungVermittlungStoppen)
                            VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8});",
                            _faLeistungID,
                            _ikRechtstitelID,
                            row[DBO.IkGlaeubiger.BaPersonID],
                            row[DBO.IkGlaeubiger.BaPersonID_AntragStellendePerson],
                            row[DBO.IkGlaeubiger.BaZahlungswegID],
                            row[DBO.IkGlaeubiger.Ausbildung],
                            row[DBO.IkGlaeubiger.Bemerkung],
                            row[DBO.IkGlaeubiger.Aktiv],
                            row[DBO.IkGlaeubiger.AuszahlungVermittlungStoppen]
                            );
                    }
                    else if (istGlaeubiger && ikGlaeubigerID > 0 && row.RowState != System.Data.DataRowState.Unchanged)
                    {
                        // Update
                        rowCount = DBUtil.ExecSQLThrowingException(@"
                            UPDATE dbo.IkGlaeubiger
                                SET FaLeistungID    = {1},
                                    IkRechtstitelID = {2},
                                    BaPersonID      = {3},
                                    BaPersonID_AntragStellendePerson = {4},
                                    BaZahlungswegID = {5},
                                    Ausbildung      = {6},
                                    Bemerkung       = {7},
                                    Aktiv           = {8},
                                    AuszahlungVermittlungStoppen = {9}
                            WHERE IkGlaeubigerID = {0}
                                AND IkGlaeubigerTS = {10};",
                            row[DBO.IkGlaeubiger.IkGlaeubigerID],
                            row[DBO.IkGlaeubiger.FaLeistungID],
                            row[DBO.IkGlaeubiger.IkRechtstitelID],
                            row[DBO.IkGlaeubiger.BaPersonID],
                            row[DBO.IkGlaeubiger.BaPersonID_AntragStellendePerson],
                            row[DBO.IkGlaeubiger.BaZahlungswegID],
                            row[DBO.IkGlaeubiger.Ausbildung],
                            row[DBO.IkGlaeubiger.Bemerkung],
                            row[DBO.IkGlaeubiger.Aktiv],
                            row[DBO.IkGlaeubiger.AuszahlungVermittlungStoppen],
                            row[DBO.IkGlaeubiger.IkGlaeubigerTS]);
                    }

                    if (rowCount == 0)
                    {
                        throw new KissCancelException(
                            KissMsg.GetMLMessage(
                            Name,
                            "TimestampError",
                            "Der gewählte Datensatz wurde in der Zwischenzeit von einer anderen Person geändert oder gelöscht." + Environment.NewLine +
                            "Aktualisieren sie die Daten zuerst, um Ihre Änderungen zu speichern."));
                    }
                }

                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
                return false;
            }

            _datenGlaeubigerWurdenKorrigiert = false;
            GlaeubigerOeffnen();
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");

            return true;
        }

        public void Init(string titleName, Image titleImage, int faLeistungID, int faFallID, int faProzessCode)
        {
            picTitel.Image = titleImage;
            lblTitel.Text = titleName;

            _faLeistungID = faLeistungID;
            _faProzessCode = faProzessCode;
            Init(-1, faFallID, true);
        }

        public void Init(int rechtstitelID, int fallID, bool canEdit)
        {
            _ikRechtstitelID = rechtstitelID;

            if (_ikRechtstitelID < 0)
            {
                _ikRechtstitelID = null;
            }

            _faFallID = fallID;

            pnlTitel.Visible = rechtstitelID < 0;
            colZahlungsweg.Visible = rechtstitelID > 0;
            colAktiv.Visible = rechtstitelID > 0;
            colAuszahlungVermittlungStoppen.Visible = rechtstitelID > 0;
            pnlKreditor.Visible = rechtstitelID > 0;

            //400	Abklärung
            //401	Alimente
            //402	Elternbeitrag
            //403	Rückerstattung
            //404	Verwandtenbeitrag
            //405	Tagesheim/Krippe
            //406	Nachlass
            //407	Rückerstattung POM
            pnlGlaeubiger.Visible = _faProzessCode != 403 && _faProzessCode != 407 && _faProzessCode != 406;
            pnlNichtPersonenbezogen.Visible = _faProzessCode == 403 || _faProzessCode == 407 || _faProzessCode == 406;
            chkGanzesKlientensystem.Visible = _faProzessCode != 403 && _faProzessCode != 407 && _faProzessCode != 406;
            //edtBemerkung.Visible = FaProzessCode != 403 && FaProzessCode != 407;
            //lblBemerkung.Visible = FaProzessCode != 403 && FaProzessCode != 407;

            edtAusbildung.Visible = _faProzessCode != 403 && _faProzessCode != 405 && _faProzessCode != 407;
            lblAusbildung.Visible = _faProzessCode != 403 && _faProzessCode != 405 && _faProzessCode != 407;

            if (_faProzessCode == 403 || _faProzessCode == 407 || _faProzessCode == 406)
            {
                GlaeubigerEinfuegen(_faLeistungID.Value);
            }

            qryIkGlaeubiger.CanUpdate = canEdit;

            colGlaeubiger.ColumnEdit.ReadOnly = !canEdit;

            // Daten neu anzeigen:
            GlaeubigerOeffnen();
        }

        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary param)
        {
            // we need at least one parameter to know what to do
            if (param == null || param.Count < 1) return true;

            // action depending
            switch (param["Action"] as string)
            {
                case "Refresh": qryIkGlaeubiger.Refresh(); return true;
            }

            // did not understand message
            return false;
        }

        #endregion

        #region Private Methods

        private void GlaeubigerOeffnen()
        {
            int filter = (chkGanzesKlientensystem.Checked) ? 1 : 0;
            qryIkGlaeubiger.Fill(_ikRechtstitelID, _faFallID, filter, _faLeistungID);
            //	SchuldnerBaPersonID = Utils.ConvertToInt(qryIkGlaeubiger["SchuldnerBaPersonID"]);

            qryAntragStellendePerson.Fill(_faFallID);

            // Mögliche Zahlungswege neu anzeigen:
            qryZahlungsweg.Fill(_faFallID, Utils.ConvertToInt(qryIkGlaeubiger["SchuldnerBaPersonID"]));
        }

        private void IBANNummernChecken()
        {
            return;
        }

        #endregion

        #endregion
    }
}