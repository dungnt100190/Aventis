using System;
using System.Drawing;
using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Basis
{
    partial class CtlArbeit : Gui.KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _baPersonID;

        #endregion

        #endregion

        #region Constructors

        public CtlArbeit()
        {
            InitializeComponent();

            if (!DBUtil.GetConfigBool(@"System\Basis\Arbeit_Integrationsstand", false))
            {
                lblIntegrationsstand.Visible = false;
                edtIntegrationsstand.DataMember = string.Empty;
                edtIntegrationsstand.Visible = false;

                lblBemerkung.Top = lblIntegrationsstand.Top;
                editBemerkungRTF.Height += editBemerkungRTF.Top - edtIntegrationsstand.Top;
                editBemerkungRTF.Top = edtIntegrationsstand.Top;
            }
        }

        #endregion

        #region EventHandlers

        private void cboBeschaeftigungsgrad_EditValueChanged(object sender, EventArgs e)
        {
            if (cboBeschaeftigungsgrad.EditValue != DBNull.Value && cboBeschaeftigungsgrad.EditValue != null &&
                (Convert.ToInt32(cboBeschaeftigungsgrad.EditValue) == 2 ||
                 Convert.ToInt32(cboBeschaeftigungsgrad.EditValue) == 3 ||
                 Convert.ToInt32(cboBeschaeftigungsgrad.EditValue) == 4 ||
                 Convert.ToInt32(cboBeschaeftigungsgrad.EditValue) == 5 ||
                 Convert.ToInt32(cboBeschaeftigungsgrad.EditValue) == 99999))
            {
                ((IKissBindableEdit)cboTeilZeitArbeitGrund1).AllowEdit(qryArbeit.CanUpdate);
                ((IKissBindableEdit)cboTeilZeitArbeitGrund2).AllowEdit(qryArbeit.CanUpdate);
                if (qryArbeit.CanUpdate)
                {
                    cboTeilZeitArbeitGrund1.EditMode = EditModeType.BfsMust;
                    cboTeilZeitArbeitGrund2.EditMode = EditModeType.BfsMust;
                }
            }
            else
            {
                cboTeilZeitArbeitGrund1.EditValue = DBNull.Value;
                cboTeilZeitArbeitGrund2.EditValue = DBNull.Value;
                cboTeilZeitArbeitGrund1.EditMode = EditModeType.Normal;
                cboTeilZeitArbeitGrund2.EditMode = EditModeType.Normal;
                ((IKissBindableEdit)cboTeilZeitArbeitGrund1).AllowEdit(false);
                ((IKissBindableEdit)cboTeilZeitArbeitGrund2).AllowEdit(false);
            }
        }

        private void cboErlernterBeruf_UserModifiedFld(object sender, Gui.UserModifiedFldEventArgs e)
        {
            var dlg = new DlgAuswahl();

            if (dlg.BerufSuchen(cboErlernterBeruf.Text, Utils.ConvertToInt(qryArbeit["GeschlechtCode"], -1)))
            {
                qryArbeit["ErlernterBeruf"] = dlg["Text"];
                qryArbeit["ErlernterBerufCode"] = dlg["BaBerufID"];
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void cboLetzteTaetigkeit_UserModifiedFld(object sender, Gui.UserModifiedFldEventArgs e)
        {
            var dlg = new DlgAuswahl();

            if (dlg.BerufSuchen(cboLetzteTaetigkeit.Text, Utils.ConvertToInt(qryArbeit["GeschlechtCode"], -1)))
            {
                qryArbeit["Beruf"] = dlg["Text"];
                qryArbeit["BerufCode"] = dlg["BaBerufID"];
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void editArbeitgeber_UserModifiedFld(object sender, Gui.UserModifiedFldEventArgs e)
        {
            if (DBUtil.IsEmpty(editArbeitgeber.Text))
            {
                qryArbeit["Arbeitgeber"] = DBNull.Value;
                qryArbeit["BaInstitutionID"] = DBNull.Value;
                return;
            }

            var dlg = new DlgAuswahl();
            if (dlg.InstitutionSuchen(editArbeitgeber.Text, true, e.ButtonClicked))
            {
                qryArbeit["Arbeitgeber"] = dlg["Name"];
                qryArbeit["BaInstitutionID"] = dlg["BaInstitutionID"];
            }
            else
                e.Cancel = true;
        }

        private void qryArbeit_AfterFill(object sender, EventArgs e)
        {
            if (ActiveSQLQuery.CanUpdate && ActiveSQLQuery.Count == 0)
            {
                ActiveSQLQuery.Insert(ActiveSQLQuery.TableName);
            }
        }

        private void qryArbeit_AfterInsert(object sender, EventArgs e)
        {
            qryArbeit["BaPersonID"] = _baPersonID;
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Init(string titleName, Image titleImage, int baPersonID, bool isFallTraeger)
        {
            _baPersonID = baPersonID;
            picTitel.Image = titleImage;

            //Filter out "weiss nicht"
            var qry = (SqlQuery)cboLetzteAbgebrocheneAusbildung.Properties.DataSource;
            qry.DataTable.DefaultView.RowFilter = "ISNULL(Code, 0) <> 1 AND ISNULL(Code, 0) <> 2 AND ISNULL(Code, 0) <> 99999";

            qry = (SqlQuery)cboTeilZeitArbeitGrund1.Properties.DataSource;
            qry.DataTable.DefaultView.RowFilter = "ISNULL(Code, 0) <> 99999";

            qry = (SqlQuery)cboTeilZeitArbeitGrund2.Properties.DataSource;
            qry.DataTable.DefaultView.RowFilter = "ISNULL(Code, 0) <> 99999";

            qry = (SqlQuery)cboHoechsteAusbildung.Properties.DataSource;
            qry.DataTable.DefaultView.RowFilter = "ISNULL(Code, 0) <> 99999";

            qryArbeit.Fill(@"
                    DECLARE @GenderCode INT

                    SELECT @GenderCode = PRS.GeschlechtCode
                    FROM dbo.BaPerson PRS
                    WHERE PRS.BaPersonID = {0}

                    SET @GenderCode = ISNULL(@GenderCode, -1)

                    SELECT DAA.*,
                           Beruf          = CASE WHEN @GenderCode = 1 THEN BR1.BezeichnungM
                                                 WHEN @GenderCode = 2 THEN BR1.BezeichnungW
                                                 ELSE BR1.Beruf
                                            END,
                           ErlernterBeruf = CASE WHEN @GenderCode = 1 THEN BR2.BezeichnungM
                                                 WHEN @GenderCode = 2 THEN BR2.BezeichnungW
                                                 ELSE BR2.Beruf
                                            END,
                           Arbeitgeber    = ORG.Name,
                           GeschlechtCode = @GenderCode
                    FROM dbo.BaArbeitAusbildung   DAA WITH (READUNCOMMITTED)
                      LEFT JOIN dbo.BaBeruf       BR1 WITH (READUNCOMMITTED) ON BR1.BaBerufID = DAA.BerufCode
                      LEFT JOIN dbo.BaBeruf       BR2 WITH (READUNCOMMITTED) ON BR2.BaBerufID = DAA.ErlernterBerufCode
                      LEFT JOIN dbo.BaInstitution ORG WITH (READUNCOMMITTED) ON ORG.BaInstitutionID = DAA.BaInstitutionID
                    WHERE BaPersonID = {0}", baPersonID);
        }

        #endregion

        #region Private Methods

        private void cboErwerbssituation_UserModifiedFld(object sender, Gui.UserModifiedFldEventArgs e)
        {
            var cbo = sender as KissLookUpEdit;
            if (cbo == null)
            {
                return;
            }

            var code = cbo.EditValue as int?;
            if (code.HasValue)
            {
                SetErwerbssituation((ErwerbssituationsCode)code.Value, cbo.DataMember);
            }
            else
            {
                SetErwerbssituation(null, cbo.DataMember);
            }
        }

        private void SetErwerbssituation(ErwerbssituationsCode? code, string dataMember)
        {
            //assign new value
            qryArbeit[dataMember] = code;

            switch (code)
            {
                // Erwerbstätig
                case ErwerbssituationsCode.Selbständig: // 1 selbständig
                case ErwerbssituationsCode.AngestelltInDerEigenenFirma: // 2 Angestellt in eigener Firma
                case ErwerbssituationsCode.RegelmaessigAngestellt: // 3 regelmässig angestellt
                case ErwerbssituationsCode.ZeitlichBefristeterVertrag: // 4 zeitlich befristeter Vertrag
                case ErwerbssituationsCode.ArbeitAufAbruf: // 5 Arbeit auf Abruf
                case ErwerbssituationsCode.Gelegenheitsarbeit: // 6 Gelegenheitsarbeit
                case ErwerbssituationsCode.MitarbeitendesFamilienmitglied: // 7 Mitarbeitendes Familienmitglied
                case ErwerbssituationsCode.InDerLehre: // 8 In der Lehre
                case ErwerbssituationsCode.AnderesErwerbstaetig: // 20 Anderes (erwerbstätig)

                // Erwerbslos (beschäftigt)
                case ErwerbssituationsCode.Arbeitsintegrationsprogramm: // 9 Arbeitsintegrationsprogramm
                case ErwerbssituationsCode.BeschaeftigungsprogrammFuerAusgesteuerte: // 10 Beschäftigungsprogramm für Ausgesteuerte
                    {
                        ((IKissBindableEdit)editArbeitzeit).AllowEdit(qryArbeit.CanUpdate);
                        ((IKissBindableEdit)chkUnregelmaessig).AllowEdit(qryArbeit.CanUpdate);
                        ((IKissBindableEdit)cboBeschaeftigungsgrad).AllowEdit(qryArbeit.CanUpdate);

                        ((IKissBindableEdit)dtpStempelnSeit).AllowEdit(false);
                        ((IKissBindableEdit)dtpAusgesteuertSeit).AllowEdit(false);
                        ((IKissBindableEdit)cboAusgesteuert).AllowEdit(false);
                        break;
                    }

                // Erwerbslos
                case ErwerbssituationsCode.AufStellensucheBeimArbeitsamtGemeldet: // 11 auf Stellensuche, beim Arbeitsamt gemeldet
                case ErwerbssituationsCode.AufStellensucheNichtBeimArbeitsamtGemeldet: // 12 auf Stellensuche, nicht beim Arbeitsamt gemeldet
                case ErwerbssituationsCode.AnderesAufArbeitssuche: // 21 Anderes (erwerbslos)
                    {
                        ((IKissBindableEdit)editArbeitzeit).AllowEdit(false);
                        ((IKissBindableEdit)chkUnregelmaessig).AllowEdit(false);
                        ((IKissBindableEdit)cboBeschaeftigungsgrad).AllowEdit(false);
                        cboBeschaeftigungsgrad.EditValue = DBNull.Value;
                        ((IKissBindableEdit)dtpStempelnSeit).AllowEdit(qryArbeit.CanUpdate);
                        ((IKissBindableEdit)dtpAusgesteuertSeit).AllowEdit(qryArbeit.CanUpdate);
                        ((IKissBindableEdit)cboAusgesteuert).AllowEdit(qryArbeit.CanUpdate);
                        break;
                    }

                // Nichterwerbstätig
                case ErwerbssituationsCode.InAusbildungOhneLehrlinge: // 13 In Ausbildung (ohne Lehrlinge)
                case ErwerbssituationsCode.HaushaltFamiliäreGruende: // 14 Haushalt, familiäre Gründe
                case ErwerbssituationsCode.Rentner: // 15 Rentner/Rentnerin
                case ErwerbssituationsCode.VoruebergehendArbeitsunfaehig: // 16 vorübergehend arbeitsunfähig
                case ErwerbssituationsCode.Dauerinvaliditaet: // 17 Dauerinvalidität
                case ErwerbssituationsCode.KeineChanceAufDemArbeitsmarkt: // 18 Keine Chance auf dem Arbeitsmarkt
                case ErwerbssituationsCode.AnderesNichtErwerbstaetig: // 22 Anderes (nichterwerbstätig)
                case ErwerbssituationsCode.NichtFestgestellt: // -1 (99999) Weiss nicht / -1 (99999) nicht festgestellt
                    {
                        ((IKissBindableEdit)editArbeitzeit).AllowEdit(false);
                        ((IKissBindableEdit)chkUnregelmaessig).AllowEdit(false);
                        ((IKissBindableEdit)cboBeschaeftigungsgrad).AllowEdit(false);
                        cboBeschaeftigungsgrad.EditValue = DBNull.Value;
                        ((IKissBindableEdit)dtpStempelnSeit).AllowEdit(false);
                        ((IKissBindableEdit)dtpAusgesteuertSeit).AllowEdit(false);
                        ((IKissBindableEdit)cboAusgesteuert).AllowEdit(false);
                        break;
                    }

                default:
                    {
                        ((IKissBindableEdit)editArbeitzeit).AllowEdit(qryArbeit.CanUpdate);
                        ((IKissBindableEdit)chkUnregelmaessig).AllowEdit(qryArbeit.CanUpdate);
                        ((IKissBindableEdit)cboBeschaeftigungsgrad).AllowEdit(qryArbeit.CanUpdate);

                        ((IKissBindableEdit)dtpStempelnSeit).AllowEdit(qryArbeit.CanUpdate);
                        ((IKissBindableEdit)dtpAusgesteuertSeit).AllowEdit(qryArbeit.CanUpdate);
                        ((IKissBindableEdit)cboAusgesteuert).AllowEdit(qryArbeit.CanUpdate);
                        break;
                    }
            }
        }

        #endregion

        #endregion
    }
}