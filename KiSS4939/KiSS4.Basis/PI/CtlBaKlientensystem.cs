using System;
using System.Drawing;
using DevExpress.XtraGrid.Columns;
using KiSS.DBScheme;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Basis.PI
{
    /// <summary>
    /// Control, used for showing personal data of person and its relation details
    /// </summary>
    public partial class CtlBaKlientensystem : KissUserControl
    {
        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private int _baPersonID = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlBaKlientensystem"/> class.
        /// </summary>
        public CtlBaKlientensystem()
        {
            InitializeComponent();

            // init with default values
            Init(null, null, -1);

            //Prepare Grid Personen
            SetupGrid(grdPersonen);
        }

        public override Object GetContextValue(string fieldName)
        {
            // logging
            _logger.Debug("call");

            switch (fieldName.ToUpper())
            {
                case "BAPERSONID":
                    return _baPersonID;
            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string titleName, Image titleImage, int baPersonID)
        {
            // logging
            _logger.Debug("enter");

            // apply values
            picTitel.Image = titleImage;
            lblTitel.Text = titleName;
            _baPersonID = baPersonID;

            // init image combo
            repItemBWEDIconCbo.NullText = " ";
            repItemBWEDIconCbo.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            KissImageList.FillIconsIntoComboBox(repItemBWEDIconCbo, true, false);

            // load relation queries
            LoadRelationShipData();

            // Falltraeger
            LoadFalltraegerData();

            // apply Postadresse (with New Line!)
            if (!DBUtil.IsEmpty(qryFalltraeger["Adresse"]))
            {
                // apply address
                lblPostadresse.Text = ((String)qryFalltraeger["Adresse"]).Replace(@"\r\n", Environment.NewLine);
            }
            else
            {
                // no address
                lblPostadresse.Text = "";
            }

            // Bezugspersonen
            LoadBezugspersonenData();

            // Begleiter/innen und Entlaster/innen
            LoadBegleiterInnenEntlasterInnenData();

            // Fachpersonen und Institutionen
            LoadInstitutionenFachpersonenData();

            // logging
            _logger.Debug("done");
        }

        public override void OnRefreshData()
        {
            // logging
            _logger.Debug("enter");

            // refresh data on Falltraeger
            qryFalltraeger.Refresh();

            // refresh data on relation
            qryPersonRelation.Refresh();

            // refresh data on Begleiter/innen//Entlaster/innen
            qryBegleiterInnenEntlasterInnen.Refresh();

            // refresh data on Institution/Fachperson
            qryFachpersonenInstitutionen.Refresh();

            // logging
            _logger.Debug("done");
        }

        private void grvPersonen_CustomRowCellEdit(Object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "RelationID")
            {
                // logging
                //logger.Debug("enter");

                // get gender of current person
                object geschlechtCode = grvPersonen.GetRowCellValue(e.RowHandle, grvPersonen.Columns["GeschlechtCode"]);

                // gender depending dropdown in grid
                if (geschlechtCode is int && Convert.ToInt32(geschlechtCode) == 1)
                {
                    // male
                    e.RepositoryItem = repRelationMale;
                }
                else if (geschlechtCode is int && Convert.ToInt32(geschlechtCode) == 2)
                {
                    // female
                    e.RepositoryItem = repRelationFemale;
                }
                else
                {
                    // unknown gender
                    e.RepositoryItem = repRelationGeneric;
                }

                // logging
                //logger.Debug("done");
            }
        }

        private void LoadBegleiterInnenEntlasterInnenData()
        {
            // logging
            _logger.Debug("load begleiterInnen/entlasterInnen data");

            // fill query
            qryBegleiterInnenEntlasterInnen.Fill(@"
                DECLARE @BaPersonID INT;
                DECLARE @LanguageCode INT;

                SET @BaPersonID = {0};
                SET @LanguageCode = {1};

                -- collect data from BW users
                SELECT IconID     = 1501, -- static id for BW active
                       Name       = dbo.fnGetLastFirstName(UEV.UserID, NULL, NULL),
                       Adresse    = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, @LanguageCode, 0, 'edmitarbeiter', 0, 0, NULL, NULL, 0, 0, 1, 0, 1, 0, 0, 1, 1),
                       TelNr      = dbo.fnEdGetEntlasterKontakt(UEV.UserID, 1, 0, @LanguageCode), -- phone number depending on priority
                       TelNrMobil = USR.PhoneMobile,
                       EMail      = USR.EMail
                FROM dbo.XUser_BwEinsatzvereinbarung   UEV WITH (READUNCOMMITTED)
                  INNER JOIN dbo.BwEinsatzvereinbarung EEV WITH (READUNCOMMITTED) ON EEV.BwEinsatzvereinbarungID = UEV.BwEinsatzvereinbarungID
                                                                                 AND EEV.FaLeistungID = dbo.fnFaGetLastFaLeistungID(@BaPersonID, 5) -- 5=BW
                  INNER JOIN dbo.XUser                 USR WITH (READUNCOMMITTED) ON USR.UserID = UEV.UserID
                  INNER JOIN dbo.EdMitarbeiter         EDM WITH (READUNCOMMITTED) ON EDM.UserID = USR.UserID

                UNION ALL

                SELECT IconID     = 1601, -- static id for ED active
                       Name       = dbo.fnGetLastFirstName(UEV.UserID, NULL, NULL),
                       Adresse    = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, @LanguageCode, 0, 'edmitarbeiter', 0, 0, NULL, NULL, 0, 0, 1, 0, 1, 0, 0, 1, 1),
                       TelNr      = dbo.fnEdGetEntlasterKontakt(UEV.UserID, 1, 0, @LanguageCode), -- phone number depending on priority
                       TelNrMobil = USR.PhoneMobile,
                       EMail      = USR.EMail
                FROM dbo.XUser_EdEinsatzvereinbarung   UEV WITH (READUNCOMMITTED)
                  INNER JOIN dbo.EdEinsatzvereinbarung EEV WITH (READUNCOMMITTED) ON EEV.EdEinsatzvereinbarungID = UEV.EdEinsatzvereinbarungID
                                                                                 AND EEV.FaLeistungID = dbo.fnFaGetLastFaLeistungID(@BaPersonID, 6) -- 6=ED
                  INNER JOIN dbo.XUser                 USR WITH (READUNCOMMITTED) ON USR.UserID = UEV.UserID
                  INNER JOIN dbo.EdMitarbeiter         EDM WITH (READUNCOMMITTED) ON EDM.UserID = USR.UserID

                ORDER BY IconID, Name, Adresse;", _baPersonID, Session.User.LanguageCode);
        }

        private void LoadBezugspersonenData()
        {
            // logging
            _logger.Debug("load bezugspersonen data");

            // fill query
            qryPersonRelation.Fill(@"
                DECLARE @BaPersonID INT;
                DECLARE @LanguageCode INT;

                SET @BaPersonID = {0};
                SET @LanguageCode = {1};

                SELECT BRE.*,
                       Person             = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname),
                       PersonID           = PRS.BaPersonID,
                       RelationID         = BRL.BaRelationID +
                                            CASE
                                              WHEN BRE.BaPersonID_1 = @BaPersonID AND (BRL.NameWeiblich1 <> BRL.NameWeiblich2 OR BRL.NameMaennlich1 <> BRL.NameMaennlich2)
                                                THEN 1000
                                              ELSE 0
                                            END +
                                            CASE PRS.GeschlechtCode
                                              WHEN 1 THEN 100
                                              WHEN 2 THEN 200
                                              ELSE 0
                                            END,
                       Age                = dbo.fnGetAge(PRS.Geburtsdatum, ISNULL(PRS.Sterbedatum, GETDATE())),
                       Klient             = CONVERT(BIT, CASE
                                                           WHEN EXISTS (SELECT TOP 1 1
                                                                        FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                                                                        WHERE LEI.BaPersonID = PRS.BaPersonID)
                                                             THEN 1
                                                           ELSE 0
                                                         END),
                       GeschlechtCode     = PRS.GeschlechtCode,
                       ImGleichenHaushalt = dbo.fnBaGleicheAdresse(@BaPersonID, PRS.BaPersonID, 1, NULL), -- compare: wohnsitz addresses
                       TelNr              = STUFF((SELECT CONVERT(VARCHAR(MAX), PHN.Phone)
                                                   FROM (SELECT Phone = ', ' + PRS.Telefon_P + ' (' + dbo.fnXDbObjectMLMsg('dbGeneral', 'TelefonPrivat', @LanguageCode) + ')'
                                                         WHERE PRS.ZeigeTelPrivat = 1

                                                         UNION ALL

                                                         SELECT Phone = ', ' + PRS.Telefon_G + ' (' + dbo.fnXDbObjectMLMsg('dbGeneral', 'TelefonGeschaeft', @LanguageCode) + ')'
                                                         WHERE PRS.ZeigeTelGeschaeft = 1

                                                         UNION ALL

                                                         SELECT Phone = ', ' + PRS.MobilTel + ' (' + dbo.fnXDbObjectMLMsg('dbGeneral', 'TelefonMobil', @LanguageCode) + ')'
                                                         WHERE PRS.ZeigeTelMobil = 1
                                                        ) AS PHN FOR XML PATH('')), 1, 2, ''),
                       EMail              = PRS.EMail
                FROM dbo.BaPerson_Relation  BRE WITH (READUNCOMMITTED)
                  INNER JOIN dbo.BaPerson   PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID IN (BRE.BaPersonID_1, BRE.BaPersonID_2)
                  LEFT  JOIN dbo.BaRelation BRL WITH (READUNCOMMITTED) ON BRL.BaRelationID = BRE.BaRelationID
                WHERE (BRE.BaPersonID_1 = @BaPersonID OR BRE.BaPersonID_2 = @BaPersonID)
                  AND PRS.BaPersonID != @BaPersonID
                ORDER BY RelationID ASC, Age DESC;", _baPersonID, Session.User.LanguageCode);
        }

        private void LoadFalltraegerData()
        {
            // logging
            _logger.Debug("load falltraeger data");

            // fill query
            qryFalltraeger.Fill(@"
                -- declare vars
                DECLARE @BaPersonID INT;
                DECLARE @LanguageCode INT;

                -- set vars
                SET @BaPersonID   = {0};
                SET @LanguageCode = {1};

                -- get data
                SELECT BaPersonID        = PRS.BaPersonID,
                       Person            = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname),
                       --
                       Wohnsitz          = ISNULL(dbo.fnGetAdressText(PRS.BaPersonID, 0, 0) + ISNULL(' (' + WOH.Bezirk + ')', ''), ''),
                       WohnsitzAdresseID = ISNULL(WOH.BaAdresseID, -1),
                       --
                       Adresse           = CASE
                                             WHEN ISNULL(PST.PLZ, -1) > 0 THEN
                                               -- Postadresse
                                               CASE
                                                 WHEN dbo.fnGetLastFirstName(NULL, PRS.Name, PST.ZuhandenVon) = '' THEN
                                                   dbo.fnGetLastFirstName(NULL, PRS.Name, PST.ZuhandenVon)
                                                 ELSE dbo.fnGetLastFirstName(NULL, PRS.Name, PST.ZuhandenVon) + '\r\n'
                                               END +
                                               ISNULL(dbo.fnBaGetPostfachText(NULL, PST.Postfach, PST.PostfachOhneNr, @LanguageCode) + '\r\n', '') +
                                               dbo.fnGetAdressText(PRS.BaPersonID, 1, 2) + ISNULL(' (' + PST.Bezirk + ')', '')
                                             WHEN ISNULL(AUF.PLZ, -1) > 0 THEN
                                               -- Aufenthalt
                                               ISNULL(PRS.Name + '\r\n', '') +
                                               ISNULL(dbo.fnBaGetPostfachText(NULL, AUF.Postfach, AUF.PostfachOhneNr, @LanguageCode) + '\r\n', '') +
                                               dbo.fnGetAdressText(PRS.BaPersonID, 1, 1) + ISNULL(' (' + AUF.Bezirk + ')', '')
                                             ELSE
                                               -- Wohnsitz
                                               ISNULL(dbo.fnBaGetPostfachText(NULL, WOH.Postfach, WOH.PostfachOhneNr, @LanguageCode) + '\r\n', '') +
                                               dbo.fnGetAdressText(PRS.BaPersonID, 1, 0) + ISNULL(' (' + WOH.Bezirk + ')', '')
                                           END,
                        Nationalitaet    = dbo.fnLandMLText(PRS.NationalitaetCode, @LanguageCode),
                        TelefonNummern   = STUFF((SELECT CONVERT(VARCHAR(MAX), PHN.Phone)
                                                  FROM (SELECT Phone = ', ' + PRS.Telefon_P + ' (' + dbo.fnXDbObjectMLMsg('dbGeneral', 'TelefonPrivat', @LanguageCode) + ')'

                                                        UNION ALL

                                                        SELECT Phone = ', ' + PRS.Telefon_G + ' (' + dbo.fnXDbObjectMLMsg('dbGeneral', 'TelefonGeschaeft', @LanguageCode) + ')'

                                                        UNION ALL

                                                        SELECT Phone = ', ' + PRS.MobilTel + ' (' + dbo.fnXDbObjectMLMsg('dbGeneral', 'TelefonMobil', @LanguageCode) + ')'
                                                       ) AS PHN FOR XML PATH('')), 1, 2, ''),
                        EMail            = PRS.EMail,
                        [Alter]          = dbo.fnGetAge(PRS.Geburtsdatum, ISNULL(PRS.Sterbedatum, GETDATE())),
                        Geburtstag       = CONVERT(VARCHAR, PRS.Geburtsdatum, 104),
                        Geschlecht       = dbo.fnGetLOVMLText('Geschlecht', PRS.GeschlechtCode, @LanguageCode),
                        Zivilstand       = dbo.fnGetLOVMLText('Zivilstand', PRS.ZivilstandCode, @LanguageCode)
                FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.BaAdresse WOH WITH (READUNCOMMITTED) ON WOH.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 1, NULL)
                  LEFT JOIN dbo.BaAdresse AUF WITH (READUNCOMMITTED) ON AUF.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 2, NULL)
                  LEFT JOIN dbo.BaAdresse PST WITH (READUNCOMMITTED) ON PST.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 3, NULL)
                WHERE PRS.BaPersonID = @BaPersonID;", _baPersonID,
                                                      Session.User.LanguageCode);
        }

        private void LoadInstitutionenFachpersonenData()
        {
            // logging
            _logger.Debug("load institutionen/fachpersonen data");

            // fill query
            qryFachpersonenInstitutionen.Fill(@"
                DECLARE @BaPersonID INT;
                DECLARE @LanguageCode INT;

                SET @BaPersonID = {0};
                SET @LanguageCode = {1};

                SELECT DISTINCT
                       BaPerson_BaInstitutionID = -1, -- static field used for refresh
                       BaInstitutionID          = INS.BaInstitutionID,
                       [Name]                   = dbo.fnGetLastFirstName(NULL, INS.Name, INS.Vorname),
                       Adresse                  = dbo.fnGetLastFirstName(NULL, INS.StrasseHausNr, INS.PLZOrt),
                       Kontaktperson            = dbo.fnGetLastFirstName(NULL, KTK.Name, KTK.Vorname),
                       TelNr                    = COALESCE(KTK.Telefon, INS.Telefon, INS.Telefon2, INS.Telefon3),
                       EMail                    = COALESCE(KTK.EMail, INS.EMail),
                       BetrifftBaPerson         = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname),
                       BeziehungZuPerson        = dbo.fnGetMLTextByDefault(ITY.NameTID, @LanguageCode, ITY.Name)
                FROM dbo.BaPerson_BaInstitution       BPI WITH (READUNCOMMITTED)
                  INNER JOIN dbo.vwInstitution        INS WITH (READUNCOMMITTED) ON INS.BaInstitutionID = BPI.BaInstitutionID
                  LEFT  JOIN dbo.BaPerson             PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = BPI.BaPersonID
                  LEFT  JOIN dbo.BaInstitutionTyp     ITY WITH (READUNCOMMITTED) ON ITY.BaInstitutionTypID = BPI.BaInstitutionTypID
                  LEFT  JOIN dbo.BaInstitutionKontakt KTK WITH (READUNCOMMITTED) ON KTK.BaInstitutionKontaktID = BPI.BaInstitutionKontaktID
                                                                                AND KTK.Aktiv = 1
                WHERE BPI.BaPersonID IN (SELECT BaPersonID_1
                                         FROM dbo.BaPerson_Relation WITH (READUNCOMMITTED)
                                         WHERE BaPersonID_2 = @BaPersonID

                                         UNION ALL

                                         SELECT BaPersonID_2
                                         FROM dbo.BaPerson_Relation WITH (READUNCOMMITTED)
                                         WHERE BaPersonID_1 = @BaPersonID

                                         UNION ALL

                                         SELECT @BaPersonID)
                ORDER BY [Name] ASC, INS.BaInstitutionID;", _baPersonID, Session.User.LanguageCode);
        }

        private void LoadRelationShipData()
        {
            // logging
            _logger.Debug("load relationship data");

            // Beziehung Lookup generisch
            SqlQuery qryGeneric = DBUtil.OpenSQL(@"
                SELECT Code = BaRelationID,
                       Text = dbo.fnGetMLTextByDefault(NameGenerisch1TID, {0}, NameGenerisch1)
                FROM dbo.BaRelation WITH (READUNCOMMITTED)

                UNION ALL

                SELECT Code = BaRelationID + 1000,
                       Text = dbo.fnGetMLTextByDefault(NameGenerisch2TID, {0}, NameGenerisch2)
                FROM dbo.BaRelation WITH (READUNCOMMITTED)
                WHERE NameGenerisch1 <> NameGenerisch2
                ORDER BY [Text];", Session.User.LanguageCode);

            repRelationGeneric = grdPersonen.GetLOVLookUpEdit(qryGeneric);

            // Beziehung Lookup männlich
            SqlQuery qryMale = DBUtil.OpenSQL(@"
                SELECT Code = BaRelationID + 100,
                       Text = dbo.fnGetMLTextByDefault(NameMaennlich1TID, {0}, NameMaennlich1)
                FROM dbo.BaRelation WITH (READUNCOMMITTED)

                UNION ALL

                SELECT Code = BaRelationID + 1000 + 100,
                       Text = dbo.fnGetMLTextByDefault(NameMaennlich2TID, {0}, NameMaennlich2)
                FROM dbo.BaRelation WITH (READUNCOMMITTED)
                WHERE NameMaennlich1 <> NameMaennlich2
                ORDER BY [Text];", Session.User.LanguageCode);

            repRelationMale = grdPersonen.GetLOVLookUpEdit(qryMale);

            // Beziehung Lookup weiblich
            SqlQuery qryFemale = DBUtil.OpenSQL(@"
                SELECT Code = BaRelationID + 200,
                       Text = dbo.fnGetMLTextByDefault(NameWeiblich1TID, {0}, NameWeiblich1)
                FROM dbo.BaRelation WITH (READUNCOMMITTED)

                UNION ALL

                SELECT Code = BaRelationID + 1000 + 200,
                       Text = dbo.fnGetMLTextByDefault(NameWeiblich2TID, {0}, NameWeiblich2)
                FROM dbo.BaRelation WITH (READUNCOMMITTED)
                WHERE NameWeiblich1 <> NameWeiblich2
                ORDER BY [Text];", Session.User.LanguageCode);

            repRelationFemale = grdPersonen.GetLOVLookUpEdit(qryFemale);
        }

        private void qryPersonRelation_BeforePost(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            if (!DBUtil.IsEmpty(qryPersonRelation["RelationID"]))
            {
                // get relation id and store it in query
                int relationID = Convert.ToInt32(qryPersonRelation["RelationID"]);
                qryPersonRelation[DBO.BaPerson_Relation.BaRelationID] = relationID % 100;

                // setup person
                if (relationID >= 1000)
                {
                    // person 1 is main person
                    qryPersonRelation[DBO.BaPerson_Relation.BaPersonID_1] = _baPersonID;
                    qryPersonRelation[DBO.BaPerson_Relation.BaPersonID_2] = qryPersonRelation["PersonID"];
                }
                else
                {
                    // person 2 is main person
                    qryPersonRelation[DBO.BaPerson_Relation.BaPersonID_1] = qryPersonRelation["PersonID"];
                    qryPersonRelation[DBO.BaPerson_Relation.BaPersonID_2] = _baPersonID;
                }
            }

            // logging
            _logger.Debug("handling GleicherHaushalt");

            // handle GleicherHaushalt flag
            bool valid = false;

            try
            {
                valid = BaUtils.HandleGleicherHaushaltFlagSet(qryPersonRelation.ColumnModified(colImGleicherHaushalt.FieldName),
                                                              Convert.ToBoolean(qryPersonRelation[colImGleicherHaushalt.FieldName]),
                                                              Convert.ToInt32(qryPersonRelation["PersonID"]),
                                                              Convert.ToString(qryPersonRelation["Person"]),
                                                              Convert.ToInt32(qryFalltraeger["WohnsitzAdresseID"]),
                                                              Convert.ToString(qryFalltraeger["Wohnsitz"]));
            }
            finally
            {
                if (!valid)
                {
                    // we need to reset flag
                    qryPersonRelation[colImGleicherHaushalt.FieldName] = false;
                }
            }

            // logging
            _logger.Debug("done");
        }

        private void repImGleichenHaushalt_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (grvPersonen.FocusedColumn.FieldName == colImGleicherHaushalt.FieldName)
            {
                // check if valid address
                if (DBUtil.IsEmpty(qryFalltraeger["WohnsitzAdresseID"]) || Convert.ToInt32(qryFalltraeger["WohnsitzAdresseID"]) < 1)
                {
                    KissMsg.ShowInfo(Name,
                                     "InvalidAddressOfSourcePerson_01",
                                     "Die Person '{0}' hat keine gültige Wohnsitzadresse. Eine Koppelung der Adressen ist somit nicht möglich.",
                                     qryFalltraeger["Person"]);

                    e.Cancel = true;
                    return;
                }

                // check if two clients
                if (!Convert.ToBoolean(qryPersonRelation[colImGleicherHaushalt.FieldName]) &&
                    Convert.ToBoolean(qryPersonRelation[colKlient.FieldName]))
                {
                    KissMsg.ShowInfo(Name,
                                     "KopplungAdresseKlientenNichtMoeglich",
                                     "Die Adressen von zwei Klienten/innen können nicht gekoppelt werden!");

                    e.Cancel = true;
                }
            }
        }

        private void SetupGrid(KissGrid kissGrid)
        {
            foreach (GridColumn column in kissGrid.View.Columns)
            {
                if (column.OptionsColumn.AllowEdit)
                {
                    column.AppearanceCell.BackColor = GuiConfig.EditColorNormal;
                }
                else
                {
                    column.AppearanceCell.BackColor = GuiConfig.GridReadOnly;
                }
            }
        }
    }
}