SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spKaGetAbklStatSektionRohdaten;
GO
/*===============================================================================================
  $Revision: 11 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spKaGetAbklStatSektionRohdaten
(
  @DatumVon      DATETIME,
  @DatumBis      DATETIME,
  @auswAlter     INT,
  @auswAnmeldung INT,
  @auswZuweiser  INT,
  @tmpTable      INT,
  @intakeCode    INT,
  @vertAbklCode  INT
)
AS 
BEGIN
  SET NOCOUNT ON

DECLARE @tmp TABLE (
  ID               INT IDENTITY,
  FaLeistungID     INT,
  [Alter]          INT,
  Geschlecht       INT,
  Nationalitaet    INT,
  BaPersonID       INT,
  FaDatumVon       DATETIME,
  InstitutionID    INT,
  AnmeldungCode    INT,
  IstIntake        BIT,
  PhasenCode       INT,
  Datum            DATETIME,
  StatusCode       INT,
  KaAbklaerungPraesenzCode INT,
  DatumIntegration DATETIME,
  IntegrationCode  INT
PRIMARY KEY (ID))

DECLARE @Jahr INT
SET @Jahr = YEAR(@DatumVon)

DECLARE @searchAlter INT
SET @searchAlter = @auswAlter

DECLARE @searchAnmeldung INT
SET @searchAnmeldung = @auswAnmeldung

DECLARE @searchZuweiser INT
SET @searchZuweiser = @auswZuweiser

-- Main select!
INSERT INTO @tmp
SELECT FAL.FaLeistungID, 
       dbo.fnGetAge(PRS.Geburtsdatum, GETDATE()), 
       PRS.GeschlechtCode, 
       PRS.NationalitaetCode, 
       FAL.BaPersonID, 
       FAL.DatumVon, 
       AKZ.InstitutionID, 
       AKZ.AnmeldungCode, 
       1, -- IstIntake
       KAI.KaAbklaerungPhaseIntakeCode, 
       KAI.Datum, 
       KAI.KaAbklaerungStatusDossierCode, 
       KAI.KaAbklaerungPraesenzCode,  
       KAI.DatumIntegration, 
       KAI.KaAbklaerungIntegrBeurCode
FROM dbo.FaLeistung                FAL WITH (READUNCOMMITTED) 
  LEFT JOIN dbo.BaPerson           PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = FAL.BaPersonID
  LEFT JOIN dbo.KaAKZuweiser       AKZ WITH (READUNCOMMITTED) ON AKZ.FaLeistungID = FAL.FaLeistungID
  LEFT JOIN dbo.KaAbklaerungIntake KAI WITH (READUNCOMMITTED) ON KAI.FaLeistungID = FAL.FaLeistungID
WHERE FAL.FaProzessCode = 701
  AND FAL.ModulID = 7
  AND ISNULL(KAI.DatumIntegration, KAI.Datum) BETWEEN @DatumVon AND @DatumBis
  AND (@vertAbklCode = 0 AND (@intakeCode = 0 OR KAI.KaAbklaerungPhaseIntakeCode = @intakeCode))

UNION ALL

SELECT FAL.FaLeistungID, 
       dbo.fnGetAge(PRS.Geburtsdatum, 
       GETDATE()), 
       PRS.GeschlechtCode, 
       PRS.NationalitaetCode, 
       FAL.BaPersonID, 
       FAL.DatumVon, 
       AKZ.InstitutionID, 
       AKZ.AnmeldungCode, 
       0,   -- IstIntake
       KAV.KaAbklaerungPhaseVertiefteAbklaerungenCode, 
       KAV.Datum,
       KAV.KaAbklaerungStatusDossierCode, 
       KAV.KaAbklaerungPraesenzCode,
       KAV.DatumIntegration, 
       KAV.KaAbklaerungIntegrBeurCode
FROM dbo.FaLeistung                  FAL WITH (READUNCOMMITTED) 
  LEFT JOIN dbo.BaPerson             PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = FAL.BaPersonID
  LEFT JOIN dbo.KaAKZuweiser         AKZ WITH (READUNCOMMITTED) ON AKZ.FaLeistungID = FAL.FaLeistungID
  LEFT JOIN dbo.KaAbklaerungVertieft KAV WITH (READUNCOMMITTED) ON KAV.FaLeistungID = FAL.FaLeistungID
WHERE FAL.FaProzessCode = 701
  AND FAL.ModulID = 7
  AND ISNULL(KAV.DatumIntegration, KAV.Datum) BETWEEN @DatumVon AND @DatumBis
  AND (@intakeCode = 0 AND (@vertAbklCode = 0 OR KAV.KaAbklaerungPhaseVertiefteAbklaerungenCode = @vertAbklCode))

-- Search criterias!
IF @searchAlter = 1 BEGIN
   DELETE FROM @tmp WHERE [Alter] > 25
END ELSE IF @searchAlter = 2 BEGIN
   DELETE FROM @tmp WHERE [Alter] < 26
END

IF @searchAnmeldung = 1 BEGIN
   DELETE FROM @tmp WHERE AnmeldungCode in (2,3)
END ELSE IF @searchAnmeldung = 2 BEGIN
   DELETE FROM @tmp WHERE AnmeldungCode in (1,3)
END ELSE IF @searchAnmeldung = 3 BEGIN
   DELETE FROM @tmp WHERE AnmeldungCode in (1,2)
END ELSE IF @searchAnmeldung = 4 BEGIN
   DELETE FROM @tmp WHERE AnmeldungCode = 3
END

IF @searchZuweiser = 2 BEGIN
    --search OrgUnit 'Sozialdienst' and its sub-orgunits (recursively)
    WITH OrgUnits AS
    (
      SELECT OrgUnitID, ItemName
        FROM XOrgUnit
        WHERE OrgUnitID = 30
      UNION ALL
        SELECT ORG.OrgUnitID, ORG.ItemName
        FROM XOrgUnit ORG
          INNER JOIN OrgUnits PAR ON ORG.ParentID = PAR.OrgUnitID
    )

   DELETE FROM @tmp WHERE InstitutionID NOT IN (SELECT -OrgUnitID FROM OrgUnits) OR InstitutionID IS NULL 
END ELSE IF @searchZuweiser = 3 BEGIN
   DELETE FROM @tmp WHERE InstitutionID NOT IN (SELECT BaInstitutionID FROM BaInstitution WHERE [Name] like 'rav%') OR InstitutionID IS NULL
END ELSE IF @searchZuweiser = 4 BEGIN
   DELETE FROM @tmp WHERE InstitutionID NOT IN (SELECT BaInstitutionID FROM BaInstitution WHERE [Name] NOT like 'rav%' AND ([Name] like 'SD%' OR [Name] like 'Sozialdienst%' OR [Name] like 'Jugend%' OR [Name] like 'Asyl%')) OR InstitutionID IS NULL
END ELSE IF @searchZuweiser = 5 BEGIN
   DELETE FROM @tmp WHERE InstitutionID NOT IN (SELECT BaInstitutionID FROM BaInstitution WHERE [Name] like 'Burgergem%') OR InstitutionID IS NULL
END ELSE IF @searchZuweiser = 6 BEGIN
    --search OrgUnit 'EKS' and its sub-orgunits (recursively)
    WITH OrgUnits AS
    (
      SELECT OrgUnitID, ItemName
        FROM XOrgUnit
        WHERE OrgUnitID = 7
      UNION ALL
        SELECT ORG.OrgUnitID, ORG.ItemName
        FROM XOrgUnit ORG
          INNER JOIN OrgUnits PAR ON ORG.ParentID = PAR.OrgUnitID
    )

   DELETE FROM @tmp WHERE InstitutionID NOT IN (SELECT -OrgUnitID FROM OrgUnits) OR InstitutionID IS NULL 
END ELSE IF @searchZuweiser = 7 BEGIN
   DELETE FROM @tmp WHERE InstitutionID NOT IN (SELECT BaInstitutionID FROM BaInstitution WHERE [Name] like 'Caritas%') OR InstitutionID IS NULL
END ELSE IF @searchZuweiser = 8 BEGIN
   DELETE FROM @tmp WHERE InstitutionID NOT IN (SELECT BaInstitutionID FROM BaInstitution WHERE [Name] like 'Sozialdienst Oster%') OR InstitutionID IS NULL
END


-- Temp table for "Anmeldung Total", "Anzahl Zuweisung...", "davon Zweitanmeldung"
DECLARE @tmp1 TABLE (
  ID            INT IDENTITY,
  FaLeistungID  INT,
  BaPersonID    INT,
  FaDatumVon    DATETIME,
  InstitutionID INT,
  Institution   VARCHAR(200),
  AnmeldungCode INT
PRIMARY KEY (ID))

INSERT INTO @tmp1
SELECT DISTINCT t.FaLeistungID, t.BaPersonID, t.FaDatumVon, t.InstitutionID, 
   Institution = CASE WHEN t.InstitutionID < 0 THEN ORG1.ItemName ELSE ORG.[Name] END,
   t.AnmeldungCode
FROM @tmp t
  LEFT JOIN BaInstitution ORG ON ORG.BaInstitutionID = t.InstitutionID
  LEFT JOIN XOrgUnit	   ORG1 ON ORG1.OrgUnitID = -t.InstitutionID
WHERE YEAR(t.FaDatumVon) = @Jahr

-- used for "Anzahl Junge...", "davon Frauen", "davon Männer", "davon Schweizer", "davon Ausländer"
DECLARE @tmp2 TABLE (
  ID            INT IDENTITY,
  FaLeistungID  INT,
  [Alter]       INT,
  Geschlecht    INT,
  Nationalitaet INT,
  BaPersonID    INT,
  FaDatumVon    DATETIME
PRIMARY KEY (ID))

INSERT INTO @tmp2
SELECT DISTINCT t.FaLeistungID, t.[Alter], t.Geschlecht, t.Nationalitaet, t.BaPersonID, t.FaDatumVon
FROM @tmp t
WHERE YEAR(t.FaDatumVon) = @Jahr
  AND t.[Alter] <= 25

-- used for "Anzahl Erwachsene...", "davon Frauen", "davon Männer", "davon Schweizer", "davon Ausländer"
DELETE FROM @tmp2

INSERT INTO @tmp2
SELECT DISTINCT t.FaLeistungID, t.[Alter], t.Geschlecht, t.Nationalitaet, t.BaPersonID, t.FaDatumVon
FROM @tmp t
WHERE YEAR(t.FaDatumVon) = @Jahr
  AND t.[Alter] > 25


IF @tmpTable = 1 BEGIN
  SELECT 
    [Pers. Nr.]                     = t.BaPersonID,
    [Name]                          = PRS.Name,
    [Vorname]                       = PRS.Vorname,
    [Alter]                         = PRS.[Alter],
    Geschlecht                      = dbo.fnLOVText('Geschlecht', t.Geschlecht),
    [Nationalität]                  = PRS.Nationalitaet,
    [Eröffnungsdatum]               = t.FaDatumVon,
    Anmeldung                       = dbo.fnLOVText('KaAbklärungZuwAnmeld', t.AnmeldungCode),
    [Institution]                   = CASE WHEN t.InstitutionID < 0 THEN ORG1.ItemName ELSE ORG.[Name] END,
    Phase                           = CASE WHEN t.IstIntake = 1 THEN dbo.fnLOVText('KaAbklaerungPhaseIntake', t.PhasenCode) ELSE dbo.fnLOVText('KaAbklaerungPhaseVertiefteAbklaerungen', t.PhasenCode) END,
    [Datum Phase]                   = t.Datum,
    [Status Warteliste]             = dbo.fnLOVText('KaAbklaerungStatusDossier', t.StatusCode),
    [Präsenz]                       = dbo.fnLOVText('KaAbklaerungPraesenz', t.KaAbklaerungPraesenzCode),
    [Integrationsbeurteilung]       = dbo.fnLOVText('KaAbklaerungIntegrBeur', t.IntegrationCode),
    [Datum Integrationsbeurteilung] = DatumIntegration,
    [Periode]                       = CONVERT(VARCHAR, @DatumVon, 104) + ' - ' + CONVERT(VARCHAR, @DatumBis, 104),
    BaPersonID$ = t.BaPersonID
  FROM @tmp t
    LEFT JOIN dbo.vwPerson  PRS ON PRS.BaPersonID = t.BaPersonID
    LEFT JOIN BaInstitution ORG ON ORG.BaInstitutionID = t.InstitutionID
    LEFT JOIN XOrgUnit     ORG1 ON ORG1.OrgUnitID = -t.InstitutionID
    
END ELSE IF @tmpTable = 2 BEGIN
  SELECT
    [Pers. Nr.]       = t.BaPersonID,
    [Name]            = PRS.Name,
    [Vorname]         = PRS.Vorname,
    [Alter]           = PRS.[Alter],
    Geschlecht        = dbo.fnLOVText('Geschlecht', PRS.GeschlechtCode),
    [Nationalität]    = PRS.Nationalitaet,
    [Eröffnungsdatum] = t.FaDatumVon,
    Anmeldung         = dbo.fnLOVText('KaAbklärungZuwAnmeld', t.AnmeldungCode),
    [Institution]     = t.Institution,
    [Periode]         = CONVERT(VARCHAR, @DatumVon, 104) + ' - ' + CONVERT(VARCHAR, @DatumBis, 104)		
  FROM @tmp1 t		
    LEFT JOIN dbo.vwPerson PRS ON PRS.BaPersonID = t.BaPersonID
    
END ELSE IF @tmpTable = 3 BEGIN
  SELECT 
    [Pers. Nr.]       = t.BaPersonID,
    [Name]            = PRS.Name,
    [Vorname]         = PRS.Vorname,
    [Alter]           = PRS.[Alter],
    Geschlecht        = dbo.fnLOVText('Geschlecht', t.Geschlecht),
    [Nationalität]    = PRS.Nationalitaet,		
    [Eröffnungsdatum] = t.FaDatumVon,
    [Periode]         = CONVERT(VARCHAR, @DatumVon, 104) + ' - ' + CONVERT(VARCHAR, @DatumBis, 104)
  FROM @tmp2 t
    LEFT JOIN dbo.vwPerson PRS ON PRS.BaPersonID = t.BaPersonID
END

END
GO