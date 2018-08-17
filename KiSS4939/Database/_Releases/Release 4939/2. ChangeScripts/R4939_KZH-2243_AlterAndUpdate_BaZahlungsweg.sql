/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: use this script to add columns to table BaZahlungsweg
=================================================================================================*/


-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- step 1: DefinitivUserID und DefinitivDatum
-------------------------------------------------------------------------------
IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns
           WHERE object_id = OBJECT_ID('BaZahlungsweg')
             AND name = 'BaFreigabeStatusCode'))
BEGIN
  PRINT ('Info: Spalte BaZahlungsweg.BaFreigabeStatusCode existiert bereits');
END
ELSE
BEGIN 
  ALTER TABLE dbo.BaZahlungsweg ADD [BaFreigabeStatusCode] [int] NULL
  PRINT ('Info: Spalte BaZahlungsweg.BaFreigabeStatusCode wurde hinzugefügt');
END;
GO

IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns
           WHERE object_id = OBJECT_ID('BaZahlungsweg')
             AND name = 'DefinitivUserID'))
BEGIN
  PRINT ('Info: Spalte BaZahlungsweg.DefinitivUserID existiert bereits');
END
ELSE
BEGIN 
  ALTER TABLE dbo.BaZahlungsweg ADD [DefinitivUserID] [int] NULL
  PRINT ('Info: Spalte BaZahlungsweg.DefinitivUserID wurde hinzugefügt');
END;
GO

IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns
           WHERE object_id = OBJECT_ID('BaZahlungsweg')
             AND name = 'DefinitivDatum'))
BEGIN
  PRINT ('Info: Spalte BaZahlungsweg.DefinitivDatum existiert bereits');
END
ELSE
BEGIN 
  ALTER TABLE dbo.BaZahlungsweg ADD [DefinitivDatum] [datetime] NULL
  PRINT ('Info: Spalte BaZahlungsweg.DefinitivDatum wurde hinzugefügt');
END;
GO

IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns
           WHERE object_id = OBJECT_ID('BaZahlungsweg')
             AND name = 'ErstelltUserID'))
BEGIN
  PRINT ('Info: Spalte BaZahlungsweg.ErstelltUserID existiert bereits');
END
ELSE
BEGIN 
  ALTER TABLE dbo.BaZahlungsweg ADD [ErstelltUserID] [int] NULL
  PRINT ('Info: Spalte BaZahlungsweg.ErstelltUserID wurde hinzugefügt');
END;
GO

IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns
           WHERE object_id = OBJECT_ID('BaZahlungsweg')
             AND name = 'MutiertUserID'))
BEGIN
  PRINT ('Info: Spalte BaZahlungsweg.MutiertUserID existiert bereits');
END
ELSE
BEGIN 
  ALTER TABLE dbo.BaZahlungsweg ADD [MutiertUserID] [int] NULL
  PRINT ('Info: Spalte BaZahlungsweg.MutiertUserID wurde hinzugefügt');
END;
GO


-------------------------------------------------------------------------------
-- step 2: CCMM
-------------------------------------------------------------------------------
IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns
           WHERE object_id = OBJECT_ID('BaZahlungsweg')
             AND name = 'Creator'))
BEGIN
  PRINT ('Info: Spalte BaZahlungsweg.Creator existiert bereits');
END
ELSE
BEGIN 
  ALTER TABLE dbo.BaZahlungsweg ADD [Creator] [VARCHAR](50) NOT NULL CONSTRAINT DF_BaZahlungsweg_Creator DEFAULT 'migration'
  ALTER TABLE dbo.BaZahlungsweg ADD [Created] [DATETIME] NOT NULL CONSTRAINT DF_BaZahlungsweg_Created DEFAULT getdate()
  ALTER TABLE dbo.BaZahlungsweg ADD [Modifier] [VARCHAR](50) NOT NULL CONSTRAINT DF_BaZahlungsweg_Modifier DEFAULT 'migration'
  ALTER TABLE dbo.BaZahlungsweg ADD [Modified] [DATETIME] NOT NULL CONSTRAINT DF_BaZahlungsweg_Modified DEFAULT getdate()

  ALTER TABLE dbo.BaZahlungsweg DROP CONSTRAINT DF_BaZahlungsweg_Creator
  ALTER TABLE dbo.BaZahlungsweg DROP CONSTRAINT DF_BaZahlungsweg_Modifier

  PRINT ('Info: Spalten CCMM wurden auf BaZahlungsweg hinzugefügt');
END;
GO


-------------------------------------------------------------------------------
-- step 3: set new columns
-------------------------------------------------------------------------------
UPDATE ZAH 
  SET BaFreigabeStatusCode = INS.BaFreigabeStatusCode,
      MutiertUserID        = INS.MutiertUserID, 
      Modified             = ISNULL(INS.MutiertDatum, ZAH.Modified),
      Modifier             = CASE WHEN INS.MutiertUserID IS NOT NULL THEN dbo.fnGetDBRowCreatorModifier(INS.MutiertUserID) ELSE ZAH.Modifier END,
      ErstelltUserID       = INS.ErstelltUserID, 
      Created              = ISNULL(INS.ErstelltDatum, ZAH.Created),
      Creator              = CASE WHEN INS.ErstelltUserID IS NOT NULL THEN dbo.fnGetDBRowCreatorModifier(INS.ErstelltUserID) ELSE ZAH.Creator END
FROM dbo.BaZahlungsweg ZAH WITH (READUNCOMMITTED)
  INNER JOIN dbo.BaInstitution INS WITH (READUNCOMMITTED) ON INS.BaInstitutionID = ZAH.BaInstitutionID
GO


-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO