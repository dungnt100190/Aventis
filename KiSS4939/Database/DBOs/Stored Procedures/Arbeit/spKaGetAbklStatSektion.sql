SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKaGetAbklStatSektion
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
  -
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spKaGetAbklStatSektion
(
  @DatumVon      DATETIME,
  @DatumBis      DATETIME,
  @auswAlter     INT,
  @auswAnmeldung INT,
  @auswZuweiser  INT,
  @intakeCode    INT,
  @vertAbklCode  INT
)
AS BEGIN
  SET NOCOUNT ON

DECLARE @tmp TABLE 
(
  ID               INT IDENTITY (1, 1),
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
  DatumIntegration DATETIME,
  IntegrationCode  INT
  PRIMARY KEY (ID)
);

DECLARE @rslt TABLE 
(
  ID     INT IDENTITY (1, 1),
  [Text] VARCHAR(500),
  Jan    INT,
  Feb    INT,
  Mrz    INT,
  Apr    INT,
  Mai    INT,
  Jun    INT,
  Jul    INT,
  Aug    INT,
  Sep    INT,
  Okt    INT,
  Nov    INT,
  Dez    INT
  PRIMARY KEY (ID)
);

DECLARE @Jahr INT;
SET @Jahr = YEAR(@DatumVon);

DECLARE @searchAlter INT;
SET @searchAlter = @auswAlter;

DECLARE @searchAnmeldung INT;
SET @searchAnmeldung = @auswAnmeldung;

DECLARE @searchZuweiser INT;
SET @searchZuweiser = @auswZuweiser;

-- Main select!
INSERT INTO @tmp (FaLeistungID, [Alter], Geschlecht, Nationalitaet, BaPersonID, FaDatumVon, InstitutionID, AnmeldungCode, IstIntake, PhasenCode, Datum, StatusCode, DatumIntegration, IntegrationCode)
  SELECT 
    FAL.FaLeistungID, 
    dbo.fnGetAge(PRS.Geburtsdatum, GETDATE()), 
    PRS.GeschlechtCode, 
    PRS.NationalitaetCode, 
    FAL.BaPersonID, 
    FAL.DatumVon, 
    AKZ.InstitutionID, 
    AKZ.AnmeldungCode, 
    1, 
    KAI.KaAbklaerungPhaseIntakeCode, 
    KAI.Datum, 
    KAI.KaAbklaerungStatusDossierCode, 
    KAI.DatumIntegration, 
    KAI.KaAbklaerungIntegrBeurCode
  FROM dbo.FaLeistung                  FAL WITH (READUNCOMMITTED) 
    LEFT JOIN dbo.BaPerson             PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = FAL.BaPersonID
    LEFT JOIN dbo.KaAKZuweiser         AKZ WITH (READUNCOMMITTED) ON AKZ.FaLeistungID = FAL.FaLeistungID
    LEFT JOIN dbo.KaAbklaerungIntake   KAI WITH (READUNCOMMITTED) ON KAI.FaLeistungID = FAL.FaLeistungID
  WHERE FAL.FaProzessCode = 701
    AND FAL.ModulID = 7
    AND ISNULL(KAI.DatumIntegration, KAI.Datum) BETWEEN @DatumVon AND @DatumBis
    AND @vertAbklCode = 0 
    AND (@intakeCode = 0 OR KAI.KaAbklaerungPhaseIntakeCode = @intakeCode)

  UNION ALL

  SELECT 
    FAL.FaLeistungID, 
    dbo.fnGetAge(PRS.Geburtsdatum, GETDATE()), 
    PRS.GeschlechtCode, 
    PRS.NationalitaetCode, 
    FAL.BaPersonID, 
    FAL.DatumVon, 
    AKZ.InstitutionID, 
    AKZ.AnmeldungCode, 
    0, 
    KAV.KaAbklaerungPhaseVertiefteAbklaerungenCode, 
    KAV.Datum,
    KAV.KaAbklaerungStatusDossierCode, 
    KAV.DatumIntegration, 
    KAV.KaAbklaerungIntegrBeurCode
  FROM dbo.FaLeistung                  FAL WITH (READUNCOMMITTED) 
    LEFT JOIN dbo.BaPerson             PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = FAL.BaPersonID
    LEFT JOIN dbo.KaAKZuweiser         AKZ WITH (READUNCOMMITTED) ON AKZ.FaLeistungID = FAL.FaLeistungID
    LEFT JOIN dbo.KaAbklaerungVertieft KAV WITH (READUNCOMMITTED) ON KAV.FaLeistungID = FAL.FaLeistungID
  WHERE FAL.FaProzessCode = 701
    AND FAL.ModulID = 7
    AND ISNULL(KAV.DatumIntegration, KAV.Datum) BETWEEN @DatumVon AND @DatumBis
    AND @intakeCode = 0 
    AND (@vertAbklCode = 0 OR KAV.KaAbklaerungPhaseVertiefteAbklaerungenCode = @vertAbklCode)

-- Search criterias!
IF @searchAlter = 1 
BEGIN
  DELETE FROM @tmp WHERE [Alter] > 25;
END 
ELSE IF @searchAlter = 2 
BEGIN
  DELETE FROM @tmp WHERE [Alter] < 26;
END;

IF @searchAnmeldung = 1 
BEGIN
  DELETE FROM @tmp WHERE AnmeldungCode IN (2,3);
END 
ELSE IF @searchAnmeldung = 2 
BEGIN
  DELETE FROM @tmp WHERE AnmeldungCode IN (1,3);
END 
ELSE IF @searchAnmeldung = 3 
BEGIN
  DELETE FROM @tmp WHERE AnmeldungCode IN (1,2);
END 
ELSE IF @searchAnmeldung = 4 
BEGIN
  DELETE FROM @tmp WHERE AnmeldungCode = 3;
END;

IF @searchZuweiser = 2 
BEGIN
  --search OrgUnit 'Sozialdienst' and its sub-orgunits (recursively)
  WITH OrgUnits AS
  (
    SELECT OrgUnitID, ItemName
    FROM dbo.XOrgUnit WITH (READUNCOMMITTED)
    WHERE OrgUnitID = 30
    
    UNION ALL
    SELECT ORG.OrgUnitID, ORG.ItemName
    FROM dbo.XOrgUnit     ORG WITH (READUNCOMMITTED)
      INNER JOIN OrgUnits PAR ON ORG.ParentID = PAR.OrgUnitID
  )
  DELETE FROM @tmp WHERE InstitutionID IS NULL 
                      OR InstitutionID NOT IN (SELECT -OrgUnitID 
                                               FROM OrgUnits);
END 
ELSE IF @searchZuweiser = 3 
BEGIN
   DELETE FROM @tmp WHERE InstitutionID IS NULL 
                       OR InstitutionID NOT IN (SELECT BaInstitutionID 
                                                FROM dbo.BaInstitution 
                                                WHERE [Name] LIKE 'rav%');
END 
ELSE IF @searchZuweiser = 4 
BEGIN
   DELETE FROM @tmp WHERE InstitutionID IS NULL 
                       OR InstitutionID NOT IN (SELECT BaInstitutionID 
                                                FROM dbo.BaInstitution 
                                                WHERE [Name] NOT LIKE 'rav%' 
                                                  AND ([Name] LIKE 'SD%' 
                                                    OR [Name] LIKE 'Sozialdienst%' 
                                                    OR [Name] LIKE 'Jugend%' 
                                                    OR [Name] LIKE 'Asyl%'));
END
ELSE IF @searchZuweiser = 5 
BEGIN
   DELETE FROM @tmp WHERE InstitutionID IS NULL 
                       OR InstitutionID NOT IN (SELECT BaInstitutionID 
                                                FROM dbo.BaInstitution 
                                                WHERE [Name] LIKE 'Burgergem%');
END 
ELSE IF @searchZuweiser = 6 
BEGIN
  --search OrgUnit 'EKS' and its sub-orgunits (recursively)
  WITH OrgUnits AS
  (
    SELECT OrgUnitID, ItemName
    FROM dbo.XOrgUnit WITH (READUNCOMMITTED)
    WHERE OrgUnitID = 7

    UNION ALL
    SELECT ORG.OrgUnitID, ORG.ItemName
    FROM dbo.XOrgUnit     ORG WITH (READUNCOMMITTED)
      INNER JOIN OrgUnits PAR ON ORG.ParentID = PAR.OrgUnitID
  )
  DELETE FROM @tmp WHERE InstitutionID IS NULL 
                      OR InstitutionID NOT IN (SELECT -OrgUnitID FROM OrgUnits);
END 
ELSE IF @searchZuweiser = 7 
BEGIN
  DELETE FROM @tmp WHERE InstitutionID IS NULL 
                      OR InstitutionID NOT IN (SELECT BaInstitutionID 
                                               FROM dbo.BaInstitution 
                                               WHERE [Name] LIKE 'Caritas%');
END 
ELSE IF @searchZuweiser = 8 
BEGIN
  DELETE FROM @tmp WHERE InstitutionID IS NULL 
                      OR InstitutionID NOT IN (SELECT BaInstitutionID 
                                               FROM dbo.BaInstitution 
                                               WHERE [Name] LIKE 'Sozialdienst Oster%');
END;

-- Temp table for "Anmeldung Total", "Anzahl Zuweisung...", "davon Zweitanmeldung"
DECLARE @tmp1 TABLE 
(
  ID               INT IDENTITY,
  FaLeistungID     INT,
  BaPersonID       INT,
  FaDatumVon       DATETIME,
  InstitutionID    INT,
  Institution      VARCHAR(200),
  AnmeldungCode    INT
  PRIMARY KEY (ID)
);

INSERT INTO @tmp1
  SELECT DISTINCT 
    t.FaLeistungID, 
    t.BaPersonID, 
    t.FaDatumVon, 
    t.InstitutionID, 
    Institution = CASE WHEN t.InstitutionID < 0 THEN ORG1.ItemName ELSE ORG.[Name] END,
    t.AnmeldungCode
  FROM @tmp t
    LEFT JOIN dbo.BaInstitution ORG  WITH (READUNCOMMITTED) ON ORG.BaInstitutionID = t.InstitutionID
    LEFT JOIN dbo.XOrgUnit      ORG1 WITH (READUNCOMMITTED) ON ORG1.OrgUnitID = -t.InstitutionID
  WHERE Year(t.FaDatumVon) = @Jahr;

-- Anzeige Jahr
INSERT INTO @rslt
  SELECT CONVERT(varchar, @Jahr), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL;

-- Total Anmeldungen
INSERT INTO @rslt 
  SELECT 'Total Anmeldungen', [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12]
  FROM(SELECT Monat = MONTH(FaDatumVon)
       FROM @tmp1) AS TMP
  PIVOT (COUNT(Monat) FOR Monat IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12])) AS PivotTable

IF (@@ROWCOUNT = 0)
BEGIN
  INSERT INTO @rslt 
    SELECT 'Total Anmeldungen', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0;
END;

-- Davon Wiederanmeldung
INSERT INTO @rslt 
  SELECT 'Davon Wiederanmeldung', [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12]
  FROM(SELECT Monat = MONTH(FaDatumVon)
       FROM @tmp1 
       WHERE AnmeldungCode = 2) AS TMP
  PIVOT (COUNT(Monat) FOR Monat IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12])) AS PivotTable

IF (@@ROWCOUNT = 0)
BEGIN
  INSERT INTO @rslt 
    SELECT 'Davon Wiederanmeldung', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0;
END;
  
-- Leere Zeile
INSERT INTO @rslt
  SELECT '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL;

-- used for "Anzahl Junge...", "davon Frauen", "davon Männer", "davon Schweizer", "davon Ausländer"
DECLARE @tmp2 TABLE 
(
  ID            INT IDENTITY,
  FaLeistungID  INT,
  [Alter]       INT,
  Geschlecht    INT,
  Nationalitaet INT,
  BaPersonID    INT,
  FaDatumVon    DATETIME
  PRIMARY KEY (ID)
);

INSERT INTO @tmp2
  SELECT DISTINCT t.FaLeistungID, t.[Alter], t.Geschlecht, t.Nationalitaet, t.BaPersonID, t.FaDatumVon
  FROM @tmp t
  WHERE Year(t.FaDatumVon) = @Jahr
    AND t.[Alter] <= 25;

-- Davon Wiederanmeldung
INSERT INTO @rslt 
  SELECT 'Anzahl Junge Erwachsene (bis 25 Jahre)', [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12]
  FROM(SELECT Monat = MONTH(FaDatumVon)
       FROM @tmp2) AS TMP
  PIVOT (COUNT(Monat) FOR Monat IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12])) AS PivotTable

IF (@@ROWCOUNT = 0)
BEGIN
  INSERT INTO @rslt 
    SELECT 'Anzahl Junge Erwachsene (bis 25 Jahre)', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0;
END;

-- davon Frauen
INSERT INTO @rslt 
  SELECT 'davon Frauen', [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12]
  FROM(SELECT Monat = MONTH(FaDatumVon)
       FROM @tmp2
       WHERE Geschlecht = 2) AS TMP
  PIVOT (COUNT(Monat) FOR Monat IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12])) AS PivotTable

IF (@@ROWCOUNT = 0)
BEGIN
  INSERT INTO @rslt 
    SELECT 'davon Frauen', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0;
END;

-- davon Männer
INSERT INTO @rslt 
  SELECT 'davon Männer', [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12]
  FROM(SELECT Monat = MONTH(FaDatumVon)
       FROM @tmp2
       WHERE Geschlecht = 1) AS TMP
  PIVOT (COUNT(Monat) FOR Monat IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12])) AS PivotTable

IF (@@ROWCOUNT = 0)
BEGIN
  INSERT INTO @rslt 
    SELECT 'davon Männer', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0;
END;

-- davon Schweizer/innen
INSERT INTO @rslt 
  SELECT 'davon Schweizer/innen', [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12]
  FROM(SELECT Monat = MONTH(FaDatumVon)
       FROM @tmp2
       WHERE Nationalitaet = 147) AS TMP
  PIVOT (COUNT(Monat) FOR Monat IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12])) AS PivotTable

IF (@@ROWCOUNT = 0)
BEGIN
  INSERT INTO @rslt 
    SELECT 'davon Schweizer/innen', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0;
END;

-- davon Ausländer/innen
INSERT INTO @rslt 
  SELECT 'davon Ausländer/innen', [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12]
  FROM(SELECT Monat = MONTH(FaDatumVon)
       FROM @tmp2
       WHERE Nationalitaet <> 147) AS TMP
  PIVOT (COUNT(Monat) FOR Monat IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12])) AS PivotTable

IF (@@ROWCOUNT = 0)
BEGIN
  INSERT INTO @rslt 
    SELECT 'davon Ausländer/innen', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0;
END;

-- Leere Zeile
INSERT INTO @rslt
  SELECT '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL;

-- used for "Anzahl Erwachsene...", "davon Frauen", "davon Männer", "davon Schweizer", "davon Ausländer"
DELETE FROM @tmp2

INSERT INTO @tmp2
  SELECT DISTINCT t.FaLeistungID, t.[Alter], t.Geschlecht, t.Nationalitaet, t.BaPersonID, t.FaDatumVon
  FROM @tmp t
  WHERE Year(t.FaDatumVon) = @Jahr
    AND t.[Alter] > 25;

-- Anzahl Erwachsene (ab 25 Jahre)
INSERT INTO @rslt 
  SELECT 'Anzahl Erwachsene (ab 25 Jahre)', [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12]
  FROM(SELECT Monat = MONTH(FaDatumVon)
       FROM @tmp2) AS TMP
  PIVOT (COUNT(Monat) FOR Monat IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12])) AS PivotTable

IF (@@ROWCOUNT = 0)
BEGIN
  INSERT INTO @rslt 
    SELECT 'Anzahl Erwachsene (ab 25 Jahre)', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0;
END;

-- davon Frauen
INSERT INTO @rslt 
  SELECT 'davon Frauen', [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12]
  FROM(SELECT Monat = MONTH(FaDatumVon)
       FROM @tmp2
       WHERE Geschlecht = 2) AS TMP
  PIVOT ( COUNT(Monat) FOR Monat IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12])) AS PivotTable

IF (@@ROWCOUNT = 0)
BEGIN
  INSERT INTO @rslt 
    SELECT 'davon Frauen', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0;
END;

-- davon Männer
INSERT INTO @rslt 
  SELECT 'davon Männer', [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12]
  FROM(SELECT Monat = MONTH(FaDatumVon)
       FROM @tmp2
       WHERE Geschlecht = 1) AS TMP
  PIVOT (COUNT(Monat) FOR Monat IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12])) AS PivotTable

IF (@@ROWCOUNT = 0)
BEGIN
  INSERT INTO @rslt 
    SELECT 'davon Männer', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0;
END;

-- davon Schweizer/innen
INSERT INTO @rslt 
  SELECT 'davon Schweizer/innen', [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12]
  FROM(SELECT Monat = MONTH(FaDatumVon)
       FROM @tmp2
       WHERE Nationalitaet = 147) AS TMP
  PIVOT (COUNT(Monat) FOR Monat IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12])) AS PivotTable

IF (@@ROWCOUNT = 0)
BEGIN
  INSERT INTO @rslt 
    SELECT 'davon Schweizer/innen', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0;
END;

-- davon Ausländer/innen
INSERT INTO @rslt 
  SELECT 'davon Ausländer/innen', [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12]
  FROM(SELECT Monat = MONTH(FaDatumVon)
       FROM @tmp2
       WHERE Nationalitaet <> 147) AS TMP
  PIVOT (COUNT(Monat) FOR Monat IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12])) AS PivotTable

IF (@@ROWCOUNT = 0)
BEGIN
  INSERT INTO @rslt 
    SELECT 'davon Ausländer/innen', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0;
END;

-- Leere Zeile
INSERT INTO @rslt
  SELECT '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL;

-- Zuweiser
INSERT INTO @rslt
  SELECT 'Zuweiser', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL;

-- dynamische Auflistung aller Institutionen
INSERT INTO @rslt 
  SELECT Institution, [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12]
  FROM(SELECT Institution,
              Monat = MONTH(FaDatumVon)
       FROM @tmp1) AS TMP
  PIVOT (COUNT(Monat) FOR Monat IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12])) AS PivotTable
  ORDER BY Institution;

-- Leere Zeile
INSERT INTO @rslt
  SELECT '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL;

-- Integrationsbeurteilungen aus Abklärung sur Dossier AsD
INSERT INTO @rslt 
  SELECT 'Integrationsbeurteilungen aus Abklärung sur Dossier AsD', [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12]
  FROM(SELECT Monat = MONTH(DatumIntegration)
       FROM @tmp
       WHERE YEAR(DatumIntegration) = @Jahr 
         AND PhasenCode = 1 
         AND IstIntake = 1) AS TMP
  PIVOT (COUNT(Monat) FOR Monat IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12])) AS PivotTable

IF (@@ROWCOUNT = 0)
BEGIN
  INSERT INTO @rslt 
    SELECT 'Integrationsbeurteilungen aus Abklärung sur Dossier AsD', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0;
END;

-- dynamische Auflistung aller KaAbklaerungIntegrBeur in AsD
INSERT INTO @rslt 
  SELECT Name, [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12]
  FROM(SELECT LOC.SortKey,
              Name = LOC.Text,
              Monat = MONTH(t.DatumIntegration)
       FROM dbo.XLOVCode LOC WITH (READUNCOMMITTED)
         INNER JOIN @tmp t ON t.IntegrationCode = LOC.Code 
                          AND YEAR(DatumIntegration) = @Jahr 
                          AND PhasenCode = 1 
                          AND IstIntake = 1
       WHERE LOC.LOVName = 'KaAbklaerungIntegrBeur' ) AS TMP
  PIVOT (COUNT(Monat) FOR Monat IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12])) AS PivotTable
  ORDER BY SortKey;

-- Pendent
INSERT INTO @rslt 
  SELECT 'Pendent', [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12]
  FROM(SELECT Monat = MONTH(Datum)
       FROM @tmp
       WHERE YEAR(Datum) = @Jahr 
         AND StatusCode = 1 
         AND PhasenCode = 1 
         AND IstIntake = 1) AS TMP
  PIVOT (COUNT(Monat) FOR Monat IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12])) AS PivotTable

-- Leere Zeile
INSERT INTO @rslt
  SELECT '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL;

-- Integrationsbeurteilungen aus Erstgespräch
INSERT INTO @rslt 
  SELECT 'Integrationsbeurteilungen aus Erstgespräch', [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12]
  FROM(SELECT Monat = MONTH(DatumIntegration)
       FROM @tmp
       WHERE YEAR(DatumIntegration) = @Jahr 
         AND PhasenCode = 2 
         AND IstIntake = 1) AS TMP
  PIVOT (COUNT(Monat) FOR Monat IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12])) AS PivotTable

IF (@@ROWCOUNT = 0)
BEGIN
  INSERT INTO @rslt 
    SELECT 'Integrationsbeurteilungen aus Erstgespräch', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0;
END;

-- dynamische Auflistung aller KaAbklaerungIntegrBeur aus Erstgespräch
INSERT INTO @rslt 
  SELECT Name, [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12]
  FROM(SELECT LOC.SortKey,
              Name = LOC.Text,
              Monat = MONTH(t.DatumIntegration)
       FROM dbo.XLOVCode LOC WITH (READUNCOMMITTED)
         INNER JOIN @tmp t ON t.IntegrationCode = LOC.Code 
                          AND YEAR(DatumIntegration) = @Jahr 
                          AND PhasenCode = 2 
                          AND IstIntake = 1
       WHERE LOC.LOVName = 'KaAbklaerungIntegrBeur' ) AS TMP
  PIVOT (COUNT(Monat) FOR Monat IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12])) AS PivotTable
  ORDER BY SortKey;

SELECT [Text], Jan, Feb, Mrz, Apr, Mai, Jun, Jul, Aug, Sep, Okt, Nov, Dez
FROM @rslt;

END
GO