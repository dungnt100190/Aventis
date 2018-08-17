SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmEdMitarbeiter;
GO
/*===============================================================================================
  $Revision: 10 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this view to get textmarken for EdMitarbeiter (module idependent)
  -
  RETURNS: All bookmarks for emplyee within EdMitarbeiter
  -
  TEST:    SELECT * FROM dbo.vwTmEdMitarbeiter WHERE EDMitarbeiterID = 21
           SELECT TOP 10 * FROM dbo.vwTmEdMitarbeiter
=================================================================================================*/

CREATE VIEW dbo.vwTmEdMitarbeiter
AS
SELECT
  -----------------------------------------------------------------------------
  -- IDs
  -----------------------------------------------------------------------------
  EDMitarbeiterID                 = EDM.EDMitarbeiterID,
  UserIDInterview                 = EDM.UserIDInterview,
  UserIDVorgesetzter              = EDM.UserIDVorgesetzter,
  
  -----------------------------------------------------------------------------
  -- data from vwTmUser (some values are already defined there!)
  -----------------------------------------------------------------------------
  TMU.*,
  
  -----------------------------------------------------------------------------
  -- static flags for BW/ED
  -----------------------------------------------------------------------------
  IstBWMa = CONVERT(BIT, CASE
                           WHEN EXISTS(SELECT TOP 1 1
                                       FROM dbo.EdMitarbeiter_XModul EMX WITH (READUNCOMMITTED)
                                       WHERE EMX.EdMitarbeiterID = EDM.EdMitarbeiterID
                                         AND EMX.XModulID = 5) THEN 1
                           ELSE 0
                         END),
  IstEDMa = CONVERT(BIT, CASE
                           WHEN EXISTS(SELECT TOP 1 1
                                       FROM dbo.EdMitarbeiter_XModul EMX WITH (READUNCOMMITTED)
                                       WHERE EMX.EdMitarbeiterID = EDM.EdMitarbeiterID
                                         AND EMX.XModulID = 6) THEN 1
                           ELSE 0
                         END),
  
  -----------------------------------------------------------------------------
  -- Grunddaten
  -----------------------------------------------------------------------------
  GrunddatenAdresseZusatz         = ADR.Zusatz,
  GrunddatenAdresseStrasse        = ADR.Strasse,
  GrunddatenAdresseHausNr         = ADR.HausNr,
  GrunddatenAdressePostfach       = ADR.Postfach,
  GrunddatenAdressePLZ            = ADR.PLZ,
  GrunddatenAdresseOrt            = ADR.Ort,
  GrunddatenAdresseKanton         = ADR.Kanton,
  GrunddatenAdresseBezirk         = ADR.Bezirk,
  GrunddatenAdresseLandD          = dbo.fnLandMLText(ADR.BaLandID, 1),
  GrunddatenAdresseLandF          = dbo.fnLandMLText(ADR.BaLandID, 2),
  GrunddatenAdresseLandI          = dbo.fnLandMLText(ADR.BaLandID, 3),
  
  GrunddatenAdresseEinzD          = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, 1, 0, 'edmitarbeiter', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  GrunddatenAdresseEinzF          = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, 2, 0, 'edmitarbeiter', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  GrunddatenAdresseEinzI          = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, 3, 0, 'edmitarbeiter', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  GrunddatenAdrEinzOhneNameD      = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, 1, 0, 'edmitarbeiter', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  GrunddatenAdrEinzOhneNameF      = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, 2, 0, 'edmitarbeiter', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  GrunddatenAdrEinzOhneNameI      = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, 3, 0, 'edmitarbeiter', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  GrunddatenAdresseMehrzD         = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, 1, 1, 'edmitarbeiter', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  GrunddatenAdresseMehrzF         = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, 2, 1, 'edmitarbeiter', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  GrunddatenAdresseMehrzI         = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, 3, 1, 'edmitarbeiter', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  GrunddatenAdrMehrzOhneNameD     = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, 1, 1, 'edmitarbeiter', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  GrunddatenAdrMehrzOhneNameF     = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, 2, 1, 'edmitarbeiter', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  GrunddatenAdrMehrzOhneNameI     = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, 3, 1, 'edmitarbeiter', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  GrunddatenAdresseStrasseNr      = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, 1, 0, 'edmitarbeiter', 0, 0, NULL, NULL, 0, 0, 1, 0, 0, 0, 0, 0, 0),
  GrunddatenAdressePLZOrt         = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, 1, 0, 'edmitarbeiter', 0, 0, NULL, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0),

  GrunddatenTelefonD              = dbo.fnEdGetEntlasterKontakt(USR.UserID, 1, 0, 1),
  GrunddatenTelefonF              = dbo.fnEdGetEntlasterKontakt(USR.UserID, 1, 0, 2),
  GrunddatenTelefonI              = dbo.fnEdGetEntlasterKontakt(USR.UserID, 1, 0, 3),
  
  GrunddatenMobilTel              = USR.PhoneMobile,
  GrunddatenFax                   = USR.Fax,
  
  GrunddatenPersonalNr            = USR.MitarbeiterNr,
  GrunddatenEintritt              = CONVERT(VARCHAR, USR.Eintrittsdatum, 104),
  GrunddatenAustritt              = CONVERT(VARCHAR, USR.Austrittsdatum, 104),
  
  GrunddatenGeburtsdatum          = CONVERT(VARCHAR, USR.Geburtstag, 104),
  
  GrunddatenGeschlechtD           = dbo.fnGetLOVMLText('Geschlecht', USR.GenderCode, 1),
  GrunddatenGeschlechtF           = dbo.fnGetLOVMLText('Geschlecht', USR.GenderCode, 2),
  GrunddatenGeschlechtI           = dbo.fnGetLOVMLText('Geschlecht', USR.GenderCode, 3),

  GrunddatenVersichertennummer    = EDM.Versichertennummer,
  GrunddatenFreieKapazitaet       = EDM.FreieKapazitaet,
  
  -----------------------------------------------------------------------------
  -- Zusatzdaten
  -----------------------------------------------------------------------------
  ZusatzZivilstandD               = dbo.fnGetLOVMLText('Zivilstand', EDM.ZusatzZivilstandCode, 1),
  ZusatzZivilstandF               = dbo.fnGetLOVMLText('Zivilstand', EDM.ZusatzZivilstandCode, 2),
  ZusatzZivilstandI               = dbo.fnGetLOVMLText('Zivilstand', EDM.ZusatzZivilstandCode, 3),
  
  ZusatzNationalitaetD            = dbo.fnGetCountryName(EDM.ZusatzNationalitaetLandCode, 1, 0),
  ZusatzNationalitaetF            = dbo.fnGetCountryName(EDM.ZusatzNationalitaetLandCode, 2, 0),
  ZusatzNationalitaetI            = dbo.fnGetCountryName(EDM.ZusatzNationalitaetLandCode, 3, 0),
  
  ZusatzAufenthaltsbewilligungD   = dbo.fnGetLOVMLText('BaAuslaenderAufenthaltStatus', EDM.ZusatzAufenthaltsbewilligungCode, 1),
  ZusatzAufenthaltsbewilligungF   = dbo.fnGetLOVMLText('BaAuslaenderAufenthaltStatus', EDM.ZusatzAufenthaltsbewilligungCode, 2),
  ZusatzAufenthaltsbewilligungI   = dbo.fnGetLOVMLText('BaAuslaenderAufenthaltStatus', EDM.ZusatzAufenthaltsbewilligungCode, 3),
  
  ZusatzAnzahlKinder              = EDM.ZusatzAnzahlKinder,
  ZusatzWeitereSprachen           = EDM.ZusatzWeitereSprachen,
  ZusatzStrafregDatum             = CONVERT(VARCHAR, EDM.ZusatzStrafregisterauszugDatum, 104),
  ZusatzStrafregBemerkungen       = EDM.ZusatzStrafregisterauszugBemerkungen,
  ZusatzAusbildung                = EDM.ZusatzAusbildung,
  ZusatzTaetigkeit                = EDM.ZusatzTaetigkeit,
  
  -----------------------------------------------------------------------------
  -- Interview
  -----------------------------------------------------------------------------
  InterviewDatum                  = CONVERT(VARCHAR, EDM.InterviewDatum, 104),
  
  InterviewName                      = UIN.LastName,
  InterviewVorname                   = UIN.FirstName,
  InterviewNameVorname               = dbo.fnGetLastFirstName(NULL, UIN.LastName, UIN.FirstName),
  InterviewNameVornameOhneKomma      = REPLACE(dbo.fnGetLastFirstName(NULL, UIN.LastName, UIN.FirstName), ',', ''),
  InterviewVornameName               = REPLACE(dbo.fnGetLastFirstName(NULL, UIN.FirstName, UIN.LastName), ',', ''),

  VorgesetzterName                   = UV.LastName,
  VorgesetzterVorname                = UV.FirstName,
  VorgesetzterNameVorname            = dbo.fnGetLastFirstName(NULL, UV.LastName, UV.FirstName),
  VorgesetzterNameVornameOhneKomma   = REPLACE(dbo.fnGetLastFirstName(NULL, UV.LastName, UV.FirstName), ',', ''),
  VorgesetzterVornameName            = REPLACE(dbo.fnGetLastFirstName(NULL, UV.FirstName, UV.LastName), ',', ''),
  
  InterviewZusammenfassung           = EDM.InterviewZusammenfassung,
  InterviewBeurteilung               = EDM.InterviewBeurteilung,
  
  -----------------------------------------------------------------------------
  -- Persönlichkeit
  -----------------------------------------------------------------------------
  PersoenlichkeitErfahrungen      = EDM.PersoenlichkeitErfahrungen,
  PersoenlichkeitErfahrungenAlter = EDM.PersoenlichkeitErfahrungenAlter,
  PersoenlichkeitVorlieben        = EDM.PersoenlichkeitVorlieben,
  PersoenlichkeitPersoenlichkeit  = EDM.PersoenlichkeitPersoenlichkeit,
  PersoenlichkeitGesundheit       = EDM.PersoenlichkeitGesundheit,
  
  -----------------------------------------------------------------------------
  -- Kenntnisse
  -----------------------------------------------------------------------------
  KenntnisseMehrfachbehinderung   = EDM.KenntnisseMehrfachbehinderung,
  KenntnisseIMC                   = EDM.KenntnisseIMC,
  KenntnisseGehirnschaedigung     = EDM.KenntnisseGehirnschaedigung,
  KenntnisseEpilepsie             = EDM.KenntnisseEpilepsie,
  KenntnisseGeistigeBehinderung   = EDM.KenntnisseGeistigeBehinderung,
  KenntnisseVerhaltensstoerung    = EDM.KenntnisseVerhaltensstoerung,
  KenntnisseAggression            = EDM.KenntnisseAggression,
  KenntnisseHilfsmittel           = EDM.KenntnisseHilfsmittel,
  KenntnisseTransport             = EDM.KenntnisseTransport,
  KenntnisseKommunikation         = EDM.KenntnisseKommunikation,
  KenntnisseWeitere               = EDM.KenntnisseWeitere,

  -----------------------------------------------------------------------------
  -- Verfügbarkeit
  -----------------------------------------------------------------------------
  VerfuegbarkeitEigenesFahrzeugD     = dbo.fnGetYesNoMLText(ISNULL(EDV.GrundangabenEigenesFahrzeug, 0), 1, 0),
  VerfuegbarkeitEigenesFahrzeugF     = dbo.fnGetYesNoMLText(ISNULL(EDV.GrundangabenEigenesFahrzeug, 0), 2, 0),
  VerfuegbarkeitEigenesFahrzeugI     = dbo.fnGetYesNoMLText(ISNULL(EDV.GrundangabenEigenesFahrzeug, 0), 3, 0),
  
  VerfuegbarkeitBemerkungen          = EDV.GrundangabenBemerkungen,
  VerfuegbarkeitMobilitaetBemerkung  = EDV.GrundangabenMobilitaetBemerkungen, 

  VerfuegbarkeitZeitlVerfuegbarkeitD = dbo.fnEdGetVerfuegbarkeitText(EDV.EdVerfuegbarkeitID, 1),
  VerfuegbarkeitZeitlVerfuegbarkeitF = dbo.fnEdGetVerfuegbarkeitText(EDV.EdVerfuegbarkeitID, 2),
  VerfuegbarkeitZeitlVerfuegbarkeitI = dbo.fnEdGetVerfuegbarkeitText(EDV.EdVerfuegbarkeitID, 3),
  
  VerfuegbarkeitAktBegleitungen      = EDV.AktuelleBegleitungen,
  VerfuegbarkeitEhemBegleitungen     = EDV.EhemaligeBegleitungen

FROM dbo.EdMitarbeiter           EDM WITH(READUNCOMMITTED)
  LEFT JOIN dbo.vwTmUser         TMU WITH(READUNCOMMITTED) ON TMU.UserID = EDM.UserID
  LEFT JOIN dbo.XUser            USR WITH(READUNCOMMITTED) ON USR.UserID = EDM.UserID
  LEFT JOIN dbo.BaAdresse        ADR WITH(READUNCOMMITTED) ON ADR.UserID = USR.UserID
  LEFT JOIN dbo.XUser            UIN WITH(READUNCOMMITTED) ON UIN.UserID = EDM.UserIDInterview
  LEFT JOIN dbo.XUser            UV  WITH(READUNCOMMITTED) ON UV.UserID  = EDM.UserIDVorgesetzter
  LEFT JOIN dbo.EdVerfuegbarkeit EDV WITH(READUNCOMMITTED) ON EDV.EdMitarbeiterID = EDM.EdMitarbeiterID;
GO