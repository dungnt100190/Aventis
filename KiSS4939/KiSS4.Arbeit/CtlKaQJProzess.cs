using System;
using System.Drawing;

using DevExpress.XtraEditors.Controls;

using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    /// <summary>
    /// Summary description for CtlKaQJProzess.
    /// </summary>
    public partial class CtlKaQJProzess : KissUserControl
    {
        private int _baPersonID;
        private int _faLeistungID;
        private bool _mayClose;
        private bool _mayDel;
        private bool _mayIns;
        private bool _mayRead;
        private bool _mayReopen;
        private bool _mayUpd;
        private bool _userDel;
        private bool _userIns;
        private bool _userUpd;

        public CtlKaQJProzess()
        {
            InitializeComponent();
        }

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "BAPERSONID":
                    return DBUtil.ExecuteScalarSQL(@"SELECT BaPersonID FROM FaLeistung WHERE FaLeistungID = {0}", _faLeistungID);

                case "FALEISTUNGID":
                    return _faLeistungID;

                case "OWNERUSERID":
                    return (int)DBUtil.ExecuteScalarSQL("select UserID from FaLeistung where FaLeistungID = {0}", _faLeistungID);
            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string titleName, Image titleImage, int faLeistungID, int baPersonID)
        {
            lblTitel.Text = titleName;
            picTitle.Image = titleImage;
            _faLeistungID = faLeistungID;
            _baPersonID = baPersonID;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (KissMsg.ShowQuestion("CtlKaQJProzess", "WerteZuruecksetzen", "Folgende Werte zurücksetzen: Programmende Datum und Grund (inkl. Auswahl)?"))
            {
                datProgEnde.EditValue = null;
                rgGrund.EditValue = null;
                ddlGrund.EditValue = null;
                ddlAbbruch.EditValue = null;

                ddlAbbruch.EditMode = EditModeType.ReadOnly;
                ddlGrund.EditMode = EditModeType.ReadOnly;
            }
        }

        private void CtlKaQJProzess_Load(object sender, EventArgs e)
        {
            SetEditMode();

            // Insert row in KaProzess if there is no entry.
            if (!ProzessExists() && DBUtil.UserHasRight("CtlKaQJProzess", "UI") && _mayUpd)
            {
                DBUtil.ExecSQL(@"INSERT INTO KaQJProzess (FaLeistungID, SichtbarSDFlag) VALUES ({0}, {1})", _faLeistungID, KaUtil.IsVisibleSD(_baPersonID));
            }

            qryProzess.Fill(@"
                select	KAP.*,
                        Berater = case when KAP.BeraterID < 0 then XUR.LastName + isNull(', ' + XUR.FirstName,'') else OKO.Name + isNull(', ' + OKO.Vorname,'') end,
                        Fallfuehrung = case when KAP.FallfuehrungID < 0 then XURF.LastName + isNull(', ' + XURF.FirstName,'') else OKOF.Name + isNull(', ' + OKOF.Vorname,'') end
                from	KaQJProzess KAP
                    left join BaInstitutionKontakt	OKO	on OKO.BaInstitutionKontaktID = KAP.BeraterID
                    left join XUser					XUR	on XUR.UserID = -KAP.BeraterID
                    left join BaInstitutionKontakt	OKOF on OKOF.BaInstitutionKontaktID = KAP.FallfuehrungID
                    left join XUser					XURF on XURF.UserID = -KAP.FallfuehrungID
                where	KAP.FaLeistungID = {0}
                and		(KAP.SichtbarSDFlag = {1} or KAP.SichtbarSDFlag = 1)",
                _faLeistungID, Session.User.IsUserKA ? 0 : 1);

            qryDates.Fill(@"
                DECLARE @ZWB1 	 DateTime
                DECLARE @ZWB2 	 DateTime
                DECLARE @ZWB3 	 DateTime

                DECLARE @FaLeistungID INT;
                SET @FaLeistungID = {0};

                DECLARE @IsUserNotKA INT;
                SET @IsUserNotKA = {1};

                DECLARE cursorDate CURSOR STATIC FOR
                  SELECT TOP 3 KQB.Datum
                  FROM dbo.KaQJPZBericht KQB
                  WHERE FaLeistungID = @FaLeistungID
                    AND KaQJPZBerichtTypCode = 1 -- Zwischenbericht
                    AND (CONVERT(INT,SichtbarSDFlag) = 1 OR CONVERT(INT,SichtbarSDFlag) = @IsUserNotKA)
                  ORDER BY KQB.Datum

                OPEN cursorDate
                    FETCH NEXT FROM cursorDate INTO @ZWB1
                    FETCH NEXT FROM cursorDate INTO @ZWB2
                    FETCH NEXT FROM cursorDate INTO @ZWB3
                CLOSE cursorDate
                DEALLOCATE cursorDate

                SELECT	AnweisungEnde =
                            (SELECT max(DatumBis)
                            FROM KaEinsatz
                            WHERE BaPersonID = (SELECT BaPersonID
                                                FROM FaLeistung
                                                WHERE FaLeistungID = @FaLeistungID)
                            AND (SichtbarSDFlag = @IsUserNotKA or SichtbarSDFlag = 1)),
                        Assessment = (SELECT TOP 1 CONVERT(DateTime, DatumAssessment, 104)
                                      FROM KaQJPZAssessment
                                      WHERE FaLeistungID = @FaLeistungID
                                        AND (SichtbarSDFlag = @IsUserNotKA or SichtbarSDFlag = 1)),
                        Zielvereinbarung = (SELECT max(ZielDatum)
                                            FROM KaQJPZZielvereinbarung
                                            WHERE FaLeistungID = @FaLeistungID
                                            AND   (SichtbarSDFlag = @IsUserNotKA or SichtbarSDFlag = 1)),
                        Zwischenbericht1 = @ZWB1,
                        Zwischenbericht2 = @ZWB2,
                        Zwischenbericht3 = @ZWB3,
                        Schlussbericht = (SELECT MAX(Datum)
                                          FROM dbo.KaQJPZBericht KQB
                                          WHERE FaLeistungID = @FaLeistungID
                                            AND (SichtbarSDFlag = @IsUserNotKA or SichtbarSDFlag = 1)
                                            AND KaQJPZBerichtTypCode = 2)",
                _faLeistungID, Session.User.IsUserKA ? 0 : 1);

            UpdateFallfuehrungInfo();
        }

        private void ddlGrund_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (qryProzess.IsFilling)
                return;

            if (!DBUtil.IsEmpty(e.NewValue))
            {
                if (Convert.ToInt32(e.NewValue) == 10)
                {
                    // Check if user has entered a value in 'Assessment'->'Nicht aufgenommen / Grund'!
                    // Display message only if he selected 'nur Assessment'!
                    SqlQuery qry = new SqlQuery();

                    qry.Fill(@"SELECT Value, ValueText
                               FROM DynaValue DV
                               WHERE DV.DynaFieldID = (SELECT FLD.DynaFieldID
                                                       FROM DynaField FLD
                                                       WHERE FLD.FieldName = 'KaQJAssessNichtAufgen')
                               AND DV.FaLeistungID = {0}", _faLeistungID);

                    if (qry.DataTable.Rows.Count > 0)
                    {
                        if (DBUtil.IsEmpty(qry["Value"]) && DBUtil.IsEmpty(qry["ValueText"]))
                        {
                            KissMsg.ShowInfo("CtlKaQJProzess", "FeldGrundAusfuellen", "Feld 'Nicht aufgenommen / Grund' in Maske Assessment muss noch ausgefüllt werden!");
                        }
                    }
                    else
                    {
                        KissMsg.ShowInfo("CtlKaQJProzess", "FeldGrundAusfuellen", "Feld 'Nicht aufgenommen / Grund' in Maske Assessment muss noch ausgefüllt werden!");
                    }
                }
            }
        }

        private void dlgBeratungBei_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            if (!_mayUpd)
                return;

            DlgAuswahl dlg = new DlgAuswahl();
            if (dlg.ZuweiserSuchen(dlgBeratungBei.Text, e.ButtonClicked))
            {
                qryProzess["Berater"] = dlg["FullName"];
                qryProzess["BeraterID"] = dlg["BeratID"];

                dlgBeratungBei.EditValue = dlg["FullName"];
                dlgBeratungBei.LookupID = dlg["BeratID"];
            }
            else
                e.Cancel = true;
        }

        private void dlgFallfuehrung_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            if (!_mayUpd)
                return;

            DlgAuswahl dlg = new DlgAuswahl();
            if (dlg.ZuweiserSuchen(dlgFallfuehrung.Text, e.ButtonClicked))
            {
                qryProzess["Fallfuehrung"] = dlg["FullName"];
                qryProzess["FallfuehrungID"] = dlg["BeratID"];

                dlgFallfuehrung.EditValue = dlg["FullName"];
                dlgFallfuehrung.LookupID = dlg["BeratID"];

                UpdateFallfuehrungInfo();
            }
            else
                e.Cancel = true;
        }

        private bool ProzessExists()
        {
            var rslt = Convert.ToInt32(
                DBUtil.ExecuteScalarSQL(@"select count(*) from KaQJProzess where FaLeistungID = {0}",
                    _faLeistungID)
                ) > 0;

            return rslt;
        }

        private void qryProzess_AfterPost(object sender, EventArgs e)
        {
            try
            {
                KaUtil.UpdateKaArbeitsRapportRecords(_faLeistungID);

                Session.Commit();
            }
            catch (Exception exc)
            {
                Session.Rollback();
                KissMsg.ShowInfo(exc.Message);
                throw new KissCancelException();
            }
        }

        private void qryProzess_BeforePost(object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(ddlGrund.EditValue) || !DBUtil.IsEmpty(ddlAbbruch.EditValue))
            {
                DBUtil.CheckNotNullField(datProgEnde, "Datum Programmende");
            }

            if (!DBUtil.IsEmpty(rgGrund.EditValue))
            {
                DBUtil.CheckNotNullField(datProgEnde, "Datum Programmende");
            }

            if (!DBUtil.IsEmpty(datProgEnde.EditValue))
            {
                DBUtil.CheckNotNullField(rgGrund, "Entweder-Oder Grund");

                if (rgGrund.SelectedIndex == 0)
                {
                    DBUtil.CheckNotNullField(ddlGrund, "Auswahl Grund");
                }
                else
                {
                    DBUtil.CheckNotNullField(ddlAbbruch, "Auswahl Grund");
                }
            }

            var austrittsdatum = qryProzess["ProgEnde"] as DateTime?;
            if (KaUtil.IsDatePartOfAnArbeitsRapportRange(_faLeistungID, austrittsdatum))
            {
                // prüfen ob KaArbeitsrapport-Einträge vor dem neuen Datum vorhanden sind
                DateTime? datumVon;
                DateTime? datumBis;
                var hatArbeitsrapport = KaUtil.WouldKaArbeitsRapportRecordsBeDeleted(
                    _faLeistungID,
                    austrittsdatum,
                    out datumVon,
                    out datumBis);

                // wenn ja, fragen ob die Daten gelöscht werden können
                if (hatArbeitsrapport && datumVon.HasValue && datumBis.HasValue)
                {
                    var answer = KissMsg.ShowQuestion(
                        Name,
                        "FrageZeiterfassungLoeschen",
                        "Es sind bereits Daten für die Präsenzzeiterfassung vor dem {0} oder nach dem {1} vorhanden." + Environment.NewLine +
                        "Wollen Sie diese Daten löschen?",
                        true,
                        datumVon.Value.ToShortDateString(),
                        datumBis.Value.ToShortDateString());

                    if (!answer)
                    {
                        throw new KissCancelException();
                    }
                }
            }
            else
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(Name, "ErrorDatumNichtInnerhalbZeiterfassung_V2", "Das Austrittsdatum liegt nicht innerhalb einer Anweisung."));
            }

            Session.BeginTransaction();
        }

        private void rgGrund_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (qryProzess.IsFilling || DBUtil.IsEmpty(e.NewValue))
                return;

            if (Convert.ToInt32(e.NewValue) == 1)
            {
                if (DBUtil.IsEmpty(ddlAbbruch.EditValue))
                {
                    ddlAbbruch.EditMode = EditModeType.ReadOnly;
                    ddlGrund.EditMode = EditModeType.Normal;
                }
                else
                {
                    if (KissMsg.ShowQuestion("CtlKaQJProzess", "WertAbbruchLoeschen", "Wert in Auswahl 'Abbruch' löschen?"))
                    {
                        ddlAbbruch.EditValue = null;
                        ddlAbbruch.EditMode = EditModeType.ReadOnly;
                        ddlGrund.EditMode = EditModeType.Normal;
                    }
                    else
                    {
                        rgGrund.SelectedIndex = Convert.ToInt32(e.OldValue) - 1;
                        e.Cancel = true;
                    }
                }
            }
            else
            {
                if (DBUtil.IsEmpty(ddlGrund.EditValue))
                {
                    ddlAbbruch.EditMode = EditModeType.Normal;
                    ddlGrund.EditMode = EditModeType.ReadOnly;
                }
                else
                {
                    if (KissMsg.ShowQuestion("CtlKaQJProzess", "WertMassnahmeBeendetLoeschen", "Wert in Auswahl 'Massnahme beendet' löschen?"))
                    {
                        ddlGrund.EditValue = null;
                        ddlAbbruch.EditMode = EditModeType.Normal;
                        ddlGrund.EditMode = EditModeType.ReadOnly;
                    }
                    else
                    {
                        rgGrund.SelectedIndex = Convert.ToInt32(e.OldValue) - 1;
                        e.Cancel = true;
                    }
                }
            }
        }

        private void rgGrund_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rgGrund.SelectedIndex == 0)
            {
                ddlAbbruch.EditMode = EditModeType.ReadOnly;
                ddlGrund.EditMode = EditModeType.Normal;
            }
            else
            {
                ddlAbbruch.EditMode = EditModeType.Normal;
                ddlGrund.EditMode = EditModeType.ReadOnly;
            }
        }

        private void SetEditMode()
        {
            _userUpd = DBUtil.UserHasRight("CtlKaQJProzess", "U");
            _userIns = DBUtil.UserHasRight("CtlKaQJProzess", "I");
            _userDel = DBUtil.UserHasRight("CtlKaQJProzess", "D");

            DBUtil.GetFallRights(_faLeistungID, out _mayRead, out _mayIns, out _mayUpd, out _mayDel, out _mayClose, out _mayReopen);

            qryProzess.CanUpdate = _mayUpd && _userUpd;
            btnReset.Enabled = _mayUpd && _userUpd;

            qryProzess.EnableBoundFields();

            if (DBUtil.IsEmpty(rgGrund.EditValue))
            {
                ddlAbbruch.EditMode = EditModeType.ReadOnly;
                ddlGrund.EditMode = EditModeType.ReadOnly;
            }
            else
            {
                if (rgGrund.SelectedIndex == 0)
                {
                    ddlAbbruch.EditMode = EditModeType.ReadOnly;
                    ddlGrund.EditMode = EditModeType.Normal;
                }
                else
                {
                    ddlAbbruch.EditMode = EditModeType.Normal;
                    ddlGrund.EditMode = EditModeType.ReadOnly;
                }
            }
        }

        private void UpdateFallfuehrungInfo()
        {
            if (qryProzess.IsEmpty)
            {
                return;
            }

            qryFallfuehrung.Fill(qryProzess["FallfuehrungID"]);
        }
    }
}