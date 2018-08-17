SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKaGetBelegMotivation
GO
/*===============================================================================================
  $Revision: 10 $

  Obsolete?
=================================================================================================*/

CREATE PROCEDURE dbo.spKaGetBelegMotivation
(
  @DatumVon      DATETIME,
  @DatumBis      DATETIME,
  @NiveauCode    INT,
  @FachbereichID INT,
  @auswZuweiser  INT
)
AS BEGIN
  SET NOCOUNT ON

DECLARE @tmp TABLE 
(
  ID                    INT IDENTITY,
  KaZuteilFachbereichID INT,
  BaPersonID            INT,
  ZuteilungVon          DATETIME,
  ZuteilungBis          DATETIME,
  FachbereichID         INT,
  NiveauCode            INT,
  ZustaendigKaID        INT,
  FachleitungID         INT,
  ZuteilDokID           INT,
  SichtbarSDFlag        BIT
  PRIMARY KEY (ID)
);

DECLARE @AuswZuw INT
SET @AuswZuw = @auswZuweiser

IF @AuswZuw = 0 
BEGIN
  INSERT @tmp
  SELECT KZF.KaZuteilFachbereichID,
         KZF.BaPersonID,
         KZF.ZuteilungVon,
         KZF.ZuteilungBis,
         KZF.FachbereichID,
         KZF.NiveauCode,
         KZF.ZustaendigKaID,
         KZF.FachleitungID,
         KZF.ZuteilDokID,
         KZF.SichtbarSDFlag
  FROM dbo.KaZuteilFachbereich KZF WITH (READUNCOMMITTED) 
  WHERE 1 = 1
    AND (@DatumVon IS NULL OR ZuteilungBis IS NULL OR ZuteilungBis >= @DatumVon)
    AND (@DatumBis IS NULL OR ZuteilungVon <= @DatumBis)
    AND (@NiveauCode IS NULL OR NiveauCode = @NiveauCode)
    AND (@FachbereichID IS NULL OR FachbereichID = @FachbereichID)
END 
ELSE IF @AuswZuw = 1 
BEGIN
  INSERT @tmp
  SELECT KZF.KaZuteilFachbereichID,
         KZF.BaPersonID,
         KZF.ZuteilungVon,
         KZF.ZuteilungBis,
         KZF.FachbereichID,
         KZF.NiveauCode,
         KZF.ZustaendigKaID,
         KZF.FachleitungID,
         KZF.ZuteilDokID,
         KZF.SichtbarSDFlag
  FROM dbo.KaZuteilFachbereich KZF WITH (READUNCOMMITTED) 
    LEFT JOIN dbo.KaEinsatz    KAE WITH (READUNCOMMITTED) ON KAE.BaPersonID = KZF.BaPersonID AND KAE.KaEinsatzID = (SELECT TOP 1 KaEinsatzID
                                                                                                                    FROM dbo.KaEinsatz WITH (READUNCOMMITTED) 
                                                                                                                    WHERE BaPersonID = KZF.BaPersonID
                                                                                                                      AND KZF.ZuteilungVon BETWEEN DatumVon AND DatumBis)
    LEFT JOIN dbo.BaInstitutionKontakt OKO WITH (READUNCOMMITTED) ON OKO.BaInstitutionKontaktID = KAE.ZuweiserID
    LEFT JOIN dbo.BaInstitution        ORG WITH (READUNCOMMITTED) ON ORG.BaInstitutionID = OKO.BaInstitutionID
  WHERE ORG.[Name] LIKE '%rav%'
    AND (@DatumVon IS NULL OR ZuteilungBis IS NULL OR ZuteilungBis >= @DatumVon)
    AND (@DatumBis IS NULL OR ZuteilungVon <= @DatumBis)
    AND (@NiveauCode IS NULL OR NiveauCode = @NiveauCode)
    AND (@FachbereichID IS NULL OR FachbereichID = @FachbereichID)
END 
ELSE IF @AuswZuw = 2 
BEGIN
  INSERT @tmp
  SELECT KZF.KaZuteilFachbereichID,
         KZF.BaPersonID,
         KZF.ZuteilungVon,
         KZF.ZuteilungBis,
         KZF.FachbereichID,
         KZF.NiveauCode,
         KZF.ZustaendigKaID,
         KZF.FachleitungID,
         KZF.ZuteilDokID,
         KZF.SichtbarSDFlag
  FROM dbo.KaZuteilFachbereich KZF WITH (READUNCOMMITTED) 
    LEFT JOIN dbo.KaEinsatz    KAE WITH (READUNCOMMITTED) ON KAE.BaPersonID = KZF.BaPersonID AND KAE.KaEinsatzID = (SELECT TOP 1 KaEinsatzID
                                                                                                                    FROM dbo.KaEinsatz WITH (READUNCOMMITTED) 
                                                                                                                    WHERE BaPersonID = KZF.BaPersonID
                                                                                                                      AND KZF.ZuteilungVon BETWEEN DatumVon AND DatumBis)
    LEFT JOIN dbo.XUser        XUR WITH (READUNCOMMITTED) ON XUR.UserID = -KAE.ZuweiserID
  WHERE XUR.LogonName NOT LIKE 'KA%'
    AND (@DatumVon IS NULL OR ZuteilungBis IS NULL OR ZuteilungBis >= @DatumVon)
    AND (@DatumBis IS NULL OR ZuteilungVon <= @DatumBis)
    AND (@NiveauCode IS NULL OR NiveauCode = @NiveauCode)
    AND (@FachbereichID IS NULL OR FachbereichID = @FachbereichID)
END 
ELSE IF @AuswZuw = 3 
BEGIN
  INSERT @tmp
  SELECT KZF.KaZuteilFachbereichID,
         KZF.BaPersonID,
         KZF.ZuteilungVon,
         KZF.ZuteilungBis,
         KZF.FachbereichID,
         KZF.NiveauCode,
         KZF.ZustaendigKaID,
         KZF.FachleitungID,
         KZF.ZuteilDokID,
         KZF.SichtbarSDFlag
  FROM dbo.KaZuteilFachbereich KZF WITH (READUNCOMMITTED) 
    LEFT JOIN dbo.KaEinsatz    KAE WITH (READUNCOMMITTED) ON KAE.BaPersonID = KZF.BaPersonID AND KAE.KaEinsatzID = (SELECT TOP 1 KaEinsatzID
                                                                                                                    FROM dbo.KaEinsatz WITH (READUNCOMMITTED) 
                                                                                                                    WHERE BaPersonID = KZF.BaPersonID
                                                                                                                      AND KZF.ZuteilungVon BETWEEN DatumVon AND DatumBis)
    LEFT JOIN dbo.BaInstitutionKontakt OKO WITH (READUNCOMMITTED) ON OKO.BaInstitutionKontaktID = KAE.ZuweiserID
    LEFT JOIN dbo.BaInstitution        ORG WITH (READUNCOMMITTED) ON ORG.BaInstitutionID = OKO.BaInstitutionID
  WHERE 1 = 1
    AND (@DatumVon IS NULL OR ZuteilungBis IS NULL OR ZuteilungBis >= @DatumVon)
    AND (@DatumBis IS NULL OR ZuteilungVon <= @DatumBis)
    AND (@NiveauCode IS NULL OR NiveauCode = @NiveauCode)
    AND (@FachbereichID IS NULL OR FachbereichID = @FachbereichID)
END 
ELSE IF @AuswZuw = 4 
BEGIN
  INSERT @tmp
  SELECT KZF.KaZuteilFachbereichID,
         KZF.BaPersonID,
         KZF.ZuteilungVon,
         KZF.ZuteilungBis,
         KZF.FachbereichID,
         KZF.NiveauCode,
         KZF.ZustaendigKaID,
         KZF.FachleitungID,
         KZF.ZuteilDokID,
         KZF.SichtbarSDFlag
  FROM dbo.KaZuteilFachbereich KZF WITH (READUNCOMMITTED) 
    LEFT JOIN dbo.KaEinsatz    KAE WITH (READUNCOMMITTED) ON KAE.BaPersonID = KZF.BaPersonID AND KAE.KaEinsatzID = (SELECT TOP 1 KaEinsatzID
                                                                                                                    FROM dbo.KaEinsatz WITH (READUNCOMMITTED) 
                                                                                                                    WHERE BaPersonID = KZF.BaPersonID
                                                                                                                      AND KZF.ZuteilungVon BETWEEN DatumVon AND DatumBis)
    LEFT  JOIN dbo.XUser       XUR WITH (READUNCOMMITTED) ON XUR.UserID = -KAE.ZuweiserID
  WHERE XUR.LogonName NOT LIKE 'KA%'
    AND (@DatumVon IS NULL OR ZuteilungBis IS NULL OR ZuteilungBis >= @DatumVon)
    AND (@DatumBis IS NULL OR ZuteilungVon <= @DatumBis)
    AND (@NiveauCode IS NULL OR NiveauCode = @NiveauCode)
    AND (@FachbereichID IS NULL OR FachbereichID = @FachbereichID)
  
  INSERT @tmp
  SELECT KZF.KaZuteilFachbereichID,
         KZF.BaPersonID,
         KZF.ZuteilungVon,
         KZF.ZuteilungBis,
         KZF.FachbereichID,
         KZF.NiveauCode,
         KZF.ZustaendigKaID,
         KZF.FachleitungID,
         KZF.ZuteilDokID,
         KZF.SichtbarSDFlag
  FROM dbo.KaZuteilFachbereich KZF WITH (READUNCOMMITTED) 
    LEFT JOIN dbo.KaEinsatz    KAE WITH (READUNCOMMITTED) ON KAE.BaPersonID = KZF.BaPersonID AND KAE.KaEinsatzID = (SELECT TOP 1 KaEinsatzID
                                                                                                                    FROM dbo.KaEinsatz WITH (READUNCOMMITTED) 
                                                                                                                    WHERE BaPersonID = KZF.BaPersonID
                                                                                                                      AND KZF.ZuteilungVon BETWEEN DatumVon AND DatumBis)
    LEFT JOIN dbo.BaInstitutionKontakt OKO WITH (READUNCOMMITTED) ON OKO.BaInstitutionKontaktID = KAE.ZuweiserID
    LEFT JOIN dbo.BaInstitution        ORG WITH (READUNCOMMITTED) ON ORG.BaInstitutionID = OKO.BaInstitutionID
  WHERE ORG.[Name] NOT LIKE '%rav%'
    AND (ORG.[Name] LIKE '%SD%' OR ORG.[Name] LIKE '%Sozialdienst%')
    AND (@DatumVon IS NULL OR ZuteilungBis IS NULL OR ZuteilungBis >= @DatumVon)
    AND (@DatumBis IS NULL OR ZuteilungVon <= @DatumBis)
    AND (@NiveauCode IS NULL OR NiveauCode = @NiveauCode)
    AND (@FachbereichID IS NULL OR FachbereichID = @FachbereichID)
END

SELECT 
  'Garten',
  [Total der aktuelle STES]     = (SELECT COUNT(*) FROM @tmp T WHERE T.FachbereichID = 7),
  [Davon Sozialdienst Bern]     = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.KaEinsatz KAE WITH (READUNCOMMITTED) ON KAE.BaPersonID = T.BaPersonID AND T.ZuteilungVon BETWEEN KAE.DatumVon AND KAE.DatumBis
                                     LEFT JOIN dbo.XUser     XUR WITH (READUNCOMMITTED) ON XUR.UserID = -KAE.ZuweiserID
                                   WHERE KAE.ZuweiserID < 0
                                     AND T.FachbereichID = 7
                                     AND XUR.LogonName NOT LIKE 'KA%'),
  [Vorl. aufg. Flücht. 7- (F)]  = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 7
                                     AND PRS.AuslaenderStatusCode = 15),
  [Vorl. aufg. Flüchtl. 7+ (F)] = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 7
                                     AND PRS.AuslaenderStatusCode = 16)

UNION ALL

SELECT 
  'Garten Extern',
  [Total der aktuelle STES]     = (SELECT COUNT(*) FROM @tmp T WHERE T.FachbereichID = 21),
  [Davon Sozialdienst Bern]     = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.KaEinsatz KAE WITH (READUNCOMMITTED) ON KAE.BaPersonID = T.BaPersonID AND T.ZuteilungVon BETWEEN KAE.DatumVon AND KAE.DatumBis
                                     LEFT JOIN dbo.XUser     XUR WITH (READUNCOMMITTED) ON XUR.UserID = -KAE.ZuweiserID
                                   WHERE KAE.ZuweiserID < 0
                                     AND T.FachbereichID = 21
                                     AND XUR.LogonName NOT LIKE 'KA%'),
  [Vorl. aufg. Flücht. 7- (F)]  = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 21
                                     AND PRS.AuslaenderStatusCode = 15),
  [Vorl. aufg. Flüchtl. 7+ (F)] = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 21
                                     AND PRS.AuslaenderStatusCode = 16)

UNION ALL

SELECT 
  'Gastro & Reinigung',
  [Total der aktuelle STES]     = (SELECT COUNT(*) FROM @tmp T WHERE T.FachbereichID = 8),
  [Davon Sozialdienst Bern]     = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.KaEinsatz KAE WITH (READUNCOMMITTED) ON KAE.BaPersonID = T.BaPersonID AND T.ZuteilungVon BETWEEN KAE.DatumVon AND KAE.DatumBis
                                     LEFT JOIN dbo.XUser     XUR WITH (READUNCOMMITTED) ON XUR.UserID = -KAE.ZuweiserID
                                   WHERE KAE.ZuweiserID < 0
                                     AND T.FachbereichID = 8
                                     AND XUR.LogonName NOT LIKE 'KA%'),
  [Vorl. aufg. Flücht. 7- (F)]  = (SELECT COUNT(*) FROM @tmp T
                                   LEFT JOIN dbo.BaPerson   PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                     WHERE T.FachbereichID = 8
                                   AND PRS.AuslaenderStatusCode = 15),
  [Vorl. aufg. Flüchtl. 7+ (F)] = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 8
                                     AND PRS.AuslaenderStatusCode = 16)

UNION ALL

SELECT 
  'Gastro & Reinigung Extern',
  [Total der aktuelle STES]     = (SELECT COUNT(*) FROM @tmp T WHERE T.FachbereichID = 23),
  [Davon Sozialdienst Bern]     = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.KaEinsatz KAE WITH (READUNCOMMITTED) ON KAE.BaPersonID = T.BaPersonID AND T.ZuteilungVon BETWEEN KAE.DatumVon AND KAE.DatumBis
                                     LEFT JOIN dbo.XUser     XUR WITH (READUNCOMMITTED) ON XUR.UserID = -KAE.ZuweiserID
                                   WHERE KAE.ZuweiserID < 0
                                     AND T.FachbereichID = 23
                                     AND XUR.LogonName NOT LIKE 'KA%'),
  [Vorl. aufg. Flücht. 7- (F)]  = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson  PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 23
                                     AND PRS.AuslaenderStatusCode = 15),
  [Vorl. aufg. Flüchtl. 7+ (F)] = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson  PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 23
                                     AND PRS.AuslaenderStatusCode = 16)

UNION ALL

SELECT 
  'Holz & Metall',
  [Total der aktuelle STES]     = (SELECT COUNT(*) FROM @tmp T WHERE T.FachbereichID = 5),
  [Davon Sozialdienst Bern]     = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.KaEinsatz KAE WITH (READUNCOMMITTED) ON KAE.BaPersonID = T.BaPersonID AND T.ZuteilungVon BETWEEN KAE.DatumVon AND KAE.DatumBis
                                     LEFT JOIN dbo.XUser     XUR WITH (READUNCOMMITTED) ON XUR.UserID = -KAE.ZuweiserID
                                   WHERE KAE.ZuweiserID < 0
                                     AND T.FachbereichID = 5
                                     AND XUR.LogonName NOT LIKE 'KA%'),
  [Vorl. aufg. Flücht. 7- (F)]  = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 5
                                     AND PRS.AuslaenderStatusCode = 15),
  [Vorl. aufg. Flüchtl. 7+ (F)] = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson  PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 5
                                     AND PRS.AuslaenderStatusCode = 16)

UNION ALL

SELECT 
  'Holz & Metall Extern',
  [Total der aktuelle STES]     = (SELECT COUNT(*) FROM @tmp T WHERE T.FachbereichID = 22),
  [Davon Sozialdienst Bern]     = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.KaEinsatz KAE WITH (READUNCOMMITTED) ON KAE.BaPersonID = T.BaPersonID AND T.ZuteilungVon BETWEEN KAE.DatumVon AND KAE.DatumBis
                                     LEFT JOIN dbo.XUser     XUR WITH (READUNCOMMITTED) ON XUR.UserID = -KAE.ZuweiserID
                                   WHERE KAE.ZuweiserID < 0
                                     AND T.FachbereichID = 22
                                     AND XUR.LogonName NOT LIKE 'KA%'),
  [Vorl. aufg. Flücht. 7- (F)]  = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson  PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 22
                                     AND PRS.AuslaenderStatusCode = 15),
  [Vorl. aufg. Flüchtl. 7+ (F)] = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson  PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 22
                                     AND PRS.AuslaenderStatusCode = 16)

UNION ALL

SELECT 
  'Metallwerkstatt',
  [Total der aktuelle STES]     = (SELECT COUNT(*) FROM @tmp T WHERE T.FachbereichID = 6),
  [Davon Sozialdienst Bern]     = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.KaEinsatz KAE WITH (READUNCOMMITTED) ON KAE.BaPersonID = T.BaPersonID AND T.ZuteilungVon BETWEEN KAE.DatumVon AND KAE.DatumBis
                                     LEFT JOIN dbo.XUser     XUR WITH (READUNCOMMITTED) ON XUR.UserID = -KAE.ZuweiserID
                                   WHERE KAE.ZuweiserID < 0
                                     AND T.FachbereichID = 6
                                     AND XUR.LogonName NOT LIKE 'KA%'),
  [Vorl. aufg. Flücht. 7- (F)]  = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 6
                                     AND PRS.AuslaenderStatusCode = 15),
  [Vorl. aufg. Flüchtl. 7+ (F)] = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson  PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 6
                                     AND PRS.AuslaenderStatusCode = 16)

UNION ALL

SELECT 
  'Projektwerkstatt',
  [Total der aktuelle STES]     = (SELECT COUNT(*) FROM @tmp T WHERE T.FachbereichID = 9),
  [Davon Sozialdienst Bern]     = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.KaEinsatz KAE WITH (READUNCOMMITTED) ON KAE.BaPersonID = T.BaPersonID AND T.ZuteilungVon BETWEEN KAE.DatumVon AND KAE.DatumBis
                                     LEFT JOIN dbo.XUser     XUR WITH (READUNCOMMITTED) ON XUR.UserID = -KAE.ZuweiserID
                                   WHERE KAE.ZuweiserID < 0
                                     AND T.FachbereichID = 9
                                     AND XUR.LogonName NOT LIKE 'KA%'),
  [Vorl. aufg. Flücht. 7- (F)]  = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson  PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 9
                                     AND PRS.AuslaenderStatusCode = 15),
  [Vorl. aufg. Flüchtl. 7+ (F)] = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson  PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 9
                                     AND PRS.AuslaenderStatusCode = 16)

UNION ALL

SELECT 
  'Ton & Deko',
  [Total der aktuelle STES]     = (SELECT COUNT(*) FROM @tmp T WHERE T.FachbereichID = 10),
  [Davon Sozialdienst Bern]     = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.KaEinsatz KAE WITH (READUNCOMMITTED) ON KAE.BaPersonID = T.BaPersonID AND T.ZuteilungVon BETWEEN KAE.DatumVon AND KAE.DatumBis
                                     LEFT JOIN dbo.XUser     XUR WITH (READUNCOMMITTED) ON XUR.UserID = -KAE.ZuweiserID
                                   WHERE KAE.ZuweiserID < 0
                                     AND T.FachbereichID = 10
                                     AND XUR.LogonName NOT LIKE 'KA%'),
  [Vorl. aufg. Flücht. 7- (F)]  = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 10
                                     AND PRS.AuslaenderStatusCode = 15),
  [Vorl. aufg. Flüchtl. 7+ (F)] = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 10
                                     AND PRS.AuslaenderStatusCode = 16)

UNION ALL

SELECT 
  'Ton & Deko Extern',
  [Total der aktuelle STES]     = (SELECT COUNT(*) FROM @tmp T WHERE T.FachbereichID = 20),
  [Davon Sozialdienst Bern]     = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.KaEinsatz KAE WITH (READUNCOMMITTED) ON KAE.BaPersonID = T.BaPersonID AND T.ZuteilungVon BETWEEN KAE.DatumVon AND KAE.DatumBis
                                     LEFT JOIN dbo.XUser     XUR WITH (READUNCOMMITTED) ON XUR.UserID = -KAE.ZuweiserID
                                   WHERE KAE.ZuweiserID < 0
                                     AND T.FachbereichID = 20
                                     AND XUR.LogonName NOT LIKE 'KA%'),
  [Vorl. aufg. Flücht. 7- (F)]  = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson  PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 20
                                     AND PRS.AuslaenderStatusCode = 15),
  [Vorl. aufg. Flüchtl. 7+ (F)] = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson  PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 20
                                     AND PRS.AuslaenderStatusCode = 16)

UNION ALL

SELECT 
  'Extern A',
  [Total der aktuelle STES]     = (SELECT COUNT(*) FROM @tmp T WHERE T.FachbereichID = 11),
  [Davon Sozialdienst Bern]     = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.KaEinsatz KAE WITH (READUNCOMMITTED) ON KAE.BaPersonID = T.BaPersonID AND T.ZuteilungVon BETWEEN KAE.DatumVon AND KAE.DatumBis
                                     LEFT JOIN dbo.XUser     XUR WITH (READUNCOMMITTED) ON XUR.UserID = -KAE.ZuweiserID
                                   WHERE KAE.ZuweiserID < 0
                                     AND T.FachbereichID = 11
                                     AND XUR.LogonName NOT LIKE 'KA%'),
  [Vorl. aufg. Flücht. 7- (F)]  = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 11
                                     AND PRS.AuslaenderStatusCode = 15),
  [Vorl. aufg. Flüchtl. 7+ (F)] = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 11
                                     AND PRS.AuslaenderStatusCode = 16)

UNION ALL

SELECT 
  'Extern B',
  [Total der aktuelle STES]     = (SELECT COUNT(*) FROM @tmp T WHERE T.FachbereichID = 12),
  [Davon Sozialdienst Bern]     = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.KaEinsatz KAE WITH (READUNCOMMITTED) ON KAE.BaPersonID = T.BaPersonID AND T.ZuteilungVon BETWEEN KAE.DatumVon AND KAE.DatumBis
                                     LEFT JOIN dbo.XUser     XUR WITH (READUNCOMMITTED) ON XUR.UserID = -KAE.ZuweiserID
                                   WHERE KAE.ZuweiserID < 0
                                     AND T.FachbereichID = 12
                                     AND XUR.LogonName NOT LIKE 'KA%'),
  [Vorl. aufg. Flücht. 7- (F)]  = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 12
                                     AND PRS.AuslaenderStatusCode = 15),
  [Vorl. aufg. Flüchtl. 7+ (F)] = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 12
                                     AND PRS.AuslaenderStatusCode = 16)

UNION ALL

SELECT 
  'Extern C',
  [Total der aktuelle STES]     = (SELECT COUNT(*) FROM @tmp T WHERE T.FachbereichID = 13),
  [Davon Sozialdienst Bern]     = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.KaEinsatz KAE WITH (READUNCOMMITTED) ON KAE.BaPersonID = T.BaPersonID AND T.ZuteilungVon BETWEEN KAE.DatumVon AND KAE.DatumBis
                                     LEFT JOIN dbo.XUser XUR WITH (READUNCOMMITTED) ON XUR.UserID = -KAE.ZuweiserID
                                   WHERE KAE.ZuweiserID < 0
                                     AND T.FachbereichID = 13
                                     AND XUR.LogonName NOT LIKE 'KA%'),
  [Vorl. aufg. Flücht. 7- (F)]  = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 13
                                     AND PRS.AuslaenderStatusCode = 15),
  [Vorl. aufg. Flüchtl. 7+ (F)] = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 13
                                     AND PRS.AuslaenderStatusCode = 16)

UNION ALL

SELECT 
  'Extern D',
  [Total der aktuelle STES]     = (SELECT COUNT(*) FROM @tmp T WHERE T.FachbereichID = 14),
  [Davon Sozialdienst Bern]     = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.KaEinsatz KAE WITH (READUNCOMMITTED) ON KAE.BaPersonID = T.BaPersonID AND T.ZuteilungVon BETWEEN KAE.DatumVon AND KAE.DatumBis
                                     LEFT JOIN dbo.XUser     XUR WITH (READUNCOMMITTED) ON XUR.UserID = -KAE.ZuweiserID
                                   WHERE KAE.ZuweiserID < 0
                                     AND T.FachbereichID = 14
                                     AND XUR.LogonName NOT LIKE 'KA%'),
  [Vorl. aufg. Flücht. 7- (F)]  = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson  PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 14
                                     AND PRS.AuslaenderStatusCode = 15),
  [Vorl. aufg. Flüchtl. 7+ (F)] = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson  PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 14
                                     AND PRS.AuslaenderStatusCode = 16)

UNION ALL

SELECT 
  'Extern E',
  [Total der aktuelle STES]     = (SELECT COUNT(*) FROM @tmp T WHERE T.FachbereichID = 15),
  [Davon Sozialdienst Bern]     = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.KaEinsatz KAE WITH (READUNCOMMITTED) ON KAE.BaPersonID = T.BaPersonID AND T.ZuteilungVon BETWEEN KAE.DatumVon AND KAE.DatumBis
                                     LEFT JOIN dbo.XUser     XUR WITH (READUNCOMMITTED) ON XUR.UserID = -KAE.ZuweiserID
                                   WHERE KAE.ZuweiserID < 0
                                     AND T.FachbereichID = 15
                                     AND XUR.LogonName NOT LIKE 'KA%'),
  [Vorl. aufg. Flücht. 7- (F)]  = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson  PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 15
                                     AND PRS.AuslaenderStatusCode = 15),
  [Vorl. aufg. Flüchtl. 7+ (F)] = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson  PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 15
                                     AND PRS.AuslaenderStatusCode = 16)

UNION ALL

SELECT 
  'Dock-In',
  [Total der aktuelle STES]     = (SELECT COUNT(*) FROM @tmp T WHERE T.FachbereichID = 16),
  [Davon Sozialdienst Bern]     = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.KaEinsatz KAE WITH (READUNCOMMITTED) ON KAE.BaPersonID = T.BaPersonID AND T.ZuteilungVon BETWEEN KAE.DatumVon AND KAE.DatumBis
                                     LEFT JOIN dbo.XUser     XUR WITH (READUNCOMMITTED) ON XUR.UserID = -KAE.ZuweiserID
                                   WHERE KAE.ZuweiserID < 0
                                     AND T.FachbereichID = 16
                                     AND XUR.LogonName NOT LIKE 'KA%'),
  [Vorl. aufg. Flücht. 7- (F)]  = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson  PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 16
                                     AND PRS.AuslaenderStatusCode = 15),
  [Vorl. aufg. Flüchtl. 7+ (F)] = (SELECT COUNT(*) FROM @tmp T
                                     LEFT JOIN dbo.BaPerson  PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID
                                   WHERE T.FachbereichID = 16
                                     AND PRS.AuslaenderStatusCode = 16)

UNION ALL

SELECT 
  'Warteliste Eintritte',
  [Total der aktuelle STES]     = (SELECT COUNT(*) FROM dbo.KaQJIntake KIN WITH (READUNCOMMITTED)
                                     LEFT JOIN dbo.FaLeistung          FAL WITH (READUNCOMMITTED) ON FAL.FaLeistungID = KIN.FaLeistungID                    
                                     LEFT JOIN dbo.KaZuteilFachbereich KZF WITH (READUNCOMMITTED) ON KZF.BaPersonID = FAL.BaPersonID
                                   WHERE KIN.WartelisteCode = 1 -- in (1,2) -> Ticket 874
                                     AND (@DatumVon IS NULL OR KZF.ZuteilungBis IS NULL OR KZF.ZuteilungBis >= @DatumVon)
                                     AND (@DatumBis IS NULL OR KZF.ZuteilungVon IS NULL OR KZF.ZuteilungVon <= @DatumBis)
                                     AND (@NiveauCode IS NULL OR KZF.NiveauCode = @NiveauCode)
                                     AND (@FachbereichID IS NULL OR KZF.FachbereichID = @FachbereichID)),
  [Davon Sozialdienst Bern]     = (SELECT COUNT(*) FROM dbo.KaQJIntake KIN WITH (READUNCOMMITTED)
                                     LEFT JOIN dbo.FaLeistung          FAL WITH (READUNCOMMITTED) ON FAL.FaLeistungID = KIN.FaLeistungID					
                                     LEFT JOIN dbo.XUser               XUR WITH (READUNCOMMITTED) ON XUR.UserID = -KIN.ZuweiserID
                                     LEFT JOIN dbo.KaZuteilFachbereich KZF WITH (READUNCOMMITTED) ON KZF.BaPersonID = FAL.BaPersonID
                                   WHERE KIN.ZuweiserID < 0
                                     AND (@DatumVon IS NULL OR KZF.ZuteilungBis IS NULL OR KZF.ZuteilungBis >= @DatumVon)
                                     AND (@DatumBis IS NULL OR KZF.ZuteilungVon IS NULL OR KZF.ZuteilungVon <= @DatumBis)
                                     AND (@NiveauCode IS NULL OR KZF.NiveauCode = @NiveauCode)
                                     AND (@FachbereichID IS NULL OR KZF.FachbereichID = @FachbereichID)
                                     AND XUR.LogonName NOT LIKE 'KA%'
                                     AND KIN.WartelisteCode = 1), -- in (1,2) -> Ticket 874
  [Vorl. aufg. Flücht. 7- (F)]  = (SELECT COUNT(*) FROM dbo.KaQJIntake KIN WITH (READUNCOMMITTED)
                                     LEFT JOIN dbo.FaLeistung          FAL WITH (READUNCOMMITTED) ON FAL.FaLeistungID = KIN.FaLeistungID
                                     LEFT JOIN dbo.BaPerson            PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = FAL.BaPersonID   
                                     LEFT JOIN dbo.KaZuteilFachbereich KZF WITH (READUNCOMMITTED) ON KZF.BaPersonID = FAL.BaPersonID
                                   WHERE PRS.AuslaenderStatusCode = 15
                                     AND KIN.WartelisteCode = 1 -- in (1,2) -> Ticket 874
                                     AND (@DatumVon IS NULL OR KZF.ZuteilungBis IS NULL OR KZF.ZuteilungBis >= @DatumVon)
                                     AND (@DatumBis IS NULL OR KZF.ZuteilungVon IS NULL OR KZF.ZuteilungVon <= @DatumBis)
                                     AND (@NiveauCode IS NULL OR KZF.NiveauCode = @NiveauCode)
                                     AND (@FachbereichID IS NULL OR KZF.FachbereichID = @FachbereichID)),
  [Vorl. aufg. Flüchtl. 7+ (F)] = (SELECT COUNT(*) FROM dbo.KaQJIntake KIN WITH (READUNCOMMITTED)
                                     LEFT JOIN dbo.FaLeistung          FAL WITH (READUNCOMMITTED) ON FAL.FaLeistungID = KIN.FaLeistungID
                                     LEFT JOIN dbo.BaPerson            PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = FAL.BaPersonID   
                                     LEFT JOIN dbo.KaZuteilFachbereich KZF WITH (READUNCOMMITTED) ON KZF.BaPersonID = FAL.BaPersonID
                                   WHERE PRS.AuslaenderStatusCode = 16
                                     AND KIN.WartelisteCode = 1 -- in (1,2) -> Ticket 874
                                     AND (@DatumVon IS NULL OR KZF.ZuteilungBis IS NULL OR KZF.ZuteilungBis >= @DatumVon)
                                     AND (@DatumBis IS NULL OR KZF.ZuteilungVon IS NULL OR KZF.ZuteilungVon <= @DatumBis)
                                     AND (@NiveauCode IS NULL OR KZF.NiveauCode = @NiveauCode)
                                     AND (@FachbereichID IS NULL OR KZF.FachbereichID = @FachbereichID))

UNION ALL

SELECT 
  'Warteliste',
  [Total der aktuelle STES]     = (SELECT COUNT(*) FROM dbo.KaQJIntake KIN WITH (READUNCOMMITTED)
                                     LEFT JOIN dbo.FaLeistung          FAL WITH (READUNCOMMITTED) ON FAL.FaLeistungID = KIN.FaLeistungID                    
                                     LEFT JOIN dbo.KaZuteilFachbereich KZF WITH (READUNCOMMITTED) ON KZF.BaPersonID = FAL.BaPersonID
                                   WHERE KIN.WartelisteCode = 2
                                     AND (@DatumVon IS NULL OR KZF.ZuteilungBis IS NULL OR KZF.ZuteilungBis >= @DatumVon)
                                     AND (@DatumBis IS NULL OR KZF.ZuteilungVon IS NULL OR KZF.ZuteilungVon <= @DatumBis)
                                     AND (@NiveauCode IS NULL OR KZF.NiveauCode = @NiveauCode)
                                     AND (@FachbereichID IS NULL OR KZF.FachbereichID = @FachbereichID)),
  [Davon Sozialdienst Bern]     = (SELECT COUNT(*) FROM dbo.KaQJIntake KIN WITH (READUNCOMMITTED)
                                     LEFT JOIN dbo.FaLeistung          FAL WITH (READUNCOMMITTED) ON FAL.FaLeistungID = KIN.FaLeistungID					
                                     LEFT JOIN dbo.XUser               XUR WITH (READUNCOMMITTED) ON XUR.UserID = -KIN.ZuweiserID
                                     LEFT JOIN dbo.KaZuteilFachbereich KZF WITH (READUNCOMMITTED) ON KZF.BaPersonID = FAL.BaPersonID
                                   WHERE KIN.ZuweiserID < 0
                                     AND (@DatumVon IS NULL OR KZF.ZuteilungBis IS NULL OR KZF.ZuteilungBis >= @DatumVon)
                                     AND (@DatumBis IS NULL OR KZF.ZuteilungVon IS NULL OR KZF.ZuteilungVon <= @DatumBis)
                                     AND (@NiveauCode IS NULL OR KZF.NiveauCode = @NiveauCode)
                                     AND (@FachbereichID IS NULL OR KZF.FachbereichID = @FachbereichID)
                                     AND XUR.LogonName NOT LIKE 'KA%'
                                     AND KIN.WartelisteCode = 2 ),
  [Vorl. aufg. Flücht. 7- (F)]  = (SELECT COUNT(*) FROM dbo.KaQJIntake KIN WITH (READUNCOMMITTED)
                                     LEFT JOIN dbo.FaLeistung          FAL WITH (READUNCOMMITTED) ON FAL.FaLeistungID = KIN.FaLeistungID
                                     LEFT JOIN dbo.BaPerson            PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = FAL.BaPersonID   
                                     LEFT JOIN dbo.KaZuteilFachbereich KZF WITH (READUNCOMMITTED) ON KZF.BaPersonID = FAL.BaPersonID
                                   WHERE PRS.AuslaenderStatusCode = 15
                                     AND KIN.WartelisteCode = 2
                                     AND (@DatumVon IS NULL OR KZF.ZuteilungBis IS NULL OR KZF.ZuteilungBis >= @DatumVon)
                                     AND (@DatumBis IS NULL OR KZF.ZuteilungVon IS NULL OR KZF.ZuteilungVon <= @DatumBis)
                                     AND (@NiveauCode IS NULL OR KZF.NiveauCode = @NiveauCode)
                                     AND (@FachbereichID IS NULL OR KZF.FachbereichID = @FachbereichID)),
  [Vorl. aufg. Flüchtl. 7+ (F)] = (SELECT COUNT(*) FROM dbo.KaQJIntake KIN WITH (READUNCOMMITTED)
                                     LEFT JOIN dbo.FaLeistung          FAL WITH (READUNCOMMITTED) ON FAL.FaLeistungID = KIN.FaLeistungID
                                     LEFT JOIN dbo.BaPerson            PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = FAL.BaPersonID   
                                     LEFT JOIN dbo.KaZuteilFachbereich KZF WITH (READUNCOMMITTED) ON KZF.BaPersonID = FAL.BaPersonID
                                   WHERE PRS.AuslaenderStatusCode = 16
                                     AND KIN.WartelisteCode = 2
                                     AND (@DatumVon IS NULL OR KZF.ZuteilungBis IS NULL OR KZF.ZuteilungBis >= @DatumVon)
                                     AND (@DatumBis IS NULL OR KZF.ZuteilungVon IS NULL OR KZF.ZuteilungVon <= @DatumBis)
                                     AND (@NiveauCode IS NULL OR KZF.NiveauCode = @NiveauCode)
                                     AND (@FachbereichID IS NULL OR KZF.FachbereichID = @FachbereichID))

UNION ALL

SELECT 
  'Warteliste Intake',
  [Total der aktuelle STES]     = (SELECT COUNT(*) FROM dbo.KaQJIntake KIN WITH (READUNCOMMITTED)
                                     LEFT JOIN dbo.FaLeistung          FAL WITH (READUNCOMMITTED) ON FAL.FaLeistungID = KIN.FaLeistungID   
                                     LEFT JOIN dbo.BaPerson            PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = FAL.BaPersonID   
                                     LEFT JOIN dbo.KaAbklaerungIntake  KAI WITH (READUNCOMMITTED) ON KAI.FaLeistungID = (SELECT TOP 1 FaLeistungID 
                                                                                                                         FROM dbo.FaLeistung WITH (READUNCOMMITTED) 
                                                                                                                         WHERE BaPersonID = PRS.BaPersonID
                                                                                                                           AND ModulID = 7
                                                                                                                           AND FaProzessCode = 701
                                                                                                                         ORDER BY DatumVon DESC)
                                     LEFT JOIN dbo.KaZuteilFachbereich KZF WITH (READUNCOMMITTED) ON KZF.BaPersonID = FAL.BaPersonID
                                   WHERE KAI.KaAbklaerungPhaseIntakeCode = 2
                                     AND KAI.KaAbklaerungStatusDossierCode IN (1, 3) -- KaAbklaerungStatusDossier -> wartend, eingeladen => Ticket 874
                                     AND (@DatumVon IS NULL OR KZF.ZuteilungBis IS NULL OR KZF.ZuteilungBis >= @DatumVon)
                                     AND (@DatumBis IS NULL OR KZF.ZuteilungVon IS NULL OR KZF.ZuteilungVon <= @DatumBis)
                                     AND (@NiveauCode IS NULL OR KZF.NiveauCode = @NiveauCode)
                                     AND (@FachbereichID IS NULL OR KZF.FachbereichID = @FachbereichID)),
  [Davon Sozialdienst Bern]     = (SELECT COUNT(*) FROM dbo.KaQJIntake KIN WITH (READUNCOMMITTED)
                                     LEFT JOIN dbo.FaLeistung          FAL WITH (READUNCOMMITTED) ON FAL.FaLeistungID = KIN.FaLeistungID					
                                     LEFT JOIN dbo.XUser               XUR WITH (READUNCOMMITTED) ON XUR.UserID = -KIN.ZuweiserID
                                     LEFT JOIN dbo.BaPerson            PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = FAL.BaPersonID 
                                     LEFT JOIN dbo.KaAbklaerungIntake  KAI WITH (READUNCOMMITTED) ON KAI.FaLeistungID = (SELECT TOP 1 FaLeistungID 
                                                                                                                         FROM dbo.FaLeistung WITH (READUNCOMMITTED) 
                                                                                                                         WHERE BaPersonID = PRS.BaPersonID
                                                                                                                           AND ModulID = 7
                                                                                                                           AND FaProzessCode = 701
                                                                                                                         ORDER BY DatumVon DESC)
                                     LEFT JOIN dbo.KaZuteilFachbereich KZF WITH (READUNCOMMITTED) ON KZF.BaPersonID = FAL.BaPersonID
                                   WHERE KIN.ZuweiserID < 0
                                     AND (@DatumVon IS NULL OR KZF.ZuteilungBis IS NULL OR KZF.ZuteilungBis >= @DatumVon)
                                     AND (@DatumBis IS NULL OR KZF.ZuteilungVon IS NULL OR KZF.ZuteilungVon <= @DatumBis)
                                     AND (@NiveauCode IS NULL OR KZF.NiveauCode = @NiveauCode)
                                     AND (@FachbereichID IS NULL OR KZF.FachbereichID = @FachbereichID)
                                     AND XUR.LogonName NOT LIKE 'KA%'
                                     AND KAI.KaAbklaerungPhaseIntakeCode = 2
                                     AND KAI.KaAbklaerungStatusDossierCode IN (1, 3)), -- KaAbklaerungStatusDossier -> wartend, eingeladen => Ticket 874
  [Vorl. aufg. Flücht. 7- (F)]  = (SELECT COUNT(*) FROM dbo.KaQJIntake KIN WITH (READUNCOMMITTED)
                                     LEFT JOIN dbo.FaLeistung          FAL WITH (READUNCOMMITTED) ON FAL.FaLeistungID = KIN.FaLeistungID
                                     LEFT JOIN dbo.BaPerson            PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = FAL.BaPersonID   
                                     LEFT JOIN dbo.KaAbklaerungIntake  KAI WITH (READUNCOMMITTED) ON KAI.FaLeistungID = (SELECT TOP 1 FaLeistungID 
                                                                                                                         FROM dbo.FaLeistung WITH (READUNCOMMITTED) 
                                                                                                                         WHERE BaPersonID = PRS.BaPersonID
                                                                                                                           AND ModulID = 7
                                                                                                                           AND FaProzessCode = 701
                                                                                                                         ORDER BY DatumVon DESC)
                                     LEFT JOIN dbo.KaZuteilFachbereich KZF WITH (READUNCOMMITTED) ON KZF.BaPersonID = FAL.BaPersonID
                                   WHERE PRS.AuslaenderStatusCode = 15
                                     AND KAI.KaAbklaerungPhaseIntakeCode = 2
                                     AND KAI.KaAbklaerungStatusDossierCode IN (1, 3) -- KaAbklaerungStatusDossier -> wartend, eingeladen => Ticket 874
                                     AND (@DatumVon IS NULL OR KZF.ZuteilungBis IS NULL OR KZF.ZuteilungBis >= @DatumVon)
                                     AND (@DatumBis IS NULL OR KZF.ZuteilungVon IS NULL OR KZF.ZuteilungVon <= @DatumBis)
                                     AND (@NiveauCode IS NULL OR KZF.NiveauCode = @NiveauCode)
                                     AND (@FachbereichID IS NULL OR KZF.FachbereichID = @FachbereichID)),
  [Vorl. aufg. Flüchtl. 7+ (F)] = (SELECT COUNT(*) FROM dbo.KaQJIntake KIN WITH (READUNCOMMITTED)
                                     LEFT JOIN dbo.FaLeistung          FAL WITH (READUNCOMMITTED) ON FAL.FaLeistungID = KIN.FaLeistungID
                                     LEFT JOIN dbo.BaPerson            PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = FAL.BaPersonID   
                                     LEFT JOIN dbo.KaAbklaerungIntake  KAI WITH (READUNCOMMITTED) ON KAI.FaLeistungID = (SELECT TOP 1 FaLeistungID 
                                                                                                                         FROM dbo.FaLeistung WITH (READUNCOMMITTED) 
                                                                                                                         WHERE BaPersonID = PRS.BaPersonID
                                                                                                                           AND ModulID = 7
                                                                                                                           AND FaProzessCode = 701
                                                                                                                         ORDER BY DatumVon DESC)
                                     LEFT JOIN dbo.KaZuteilFachbereich KZF WITH (READUNCOMMITTED) ON KZF.BaPersonID = FAL.BaPersonID
                                   WHERE PRS.AuslaenderStatusCode = 16
                                     AND KAI.KaAbklaerungPhaseIntakeCode = 2
                                     AND KAI.KaAbklaerungStatusDossierCode IN (1, 3) -- KaAbklaerungStatusDossier -> wartend, eingeladen => Ticket 874
                                     AND (@DatumVon IS NULL OR KZF.ZuteilungBis IS NULL OR KZF.ZuteilungBis >= @DatumVon)
                                     AND (@DatumBis IS NULL OR KZF.ZuteilungVon IS NULL OR KZF.ZuteilungVon <= @DatumBis)
                                     AND (@NiveauCode IS NULL OR KZF.NiveauCode = @NiveauCode)
                                     AND (@FachbereichID IS NULL OR KZF.FachbereichID = @FachbereichID))

END
GO