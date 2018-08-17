SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnABAGetLeistungsdaten
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnABAGetLeistungsdaten.sql $
  $Author: Cjaeggi $
  $Modtime: 1.09.09 13:32 $
  $Revision: 9 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Is used for Leistungsdaten (Schnittstelle)
    @MandantenNr:  The MandantenNr to use for filtering (performance!)
    @DatumVon:     The start date to get data for (period)
    @DatumBis:     The end date to get data for (period)
    @LanguageCode: The language code to use for data
  -
  RETURNS: Table containing all data found for Schnittstelle
  -
  TEST:    SELECT * FROM [dbo].[fnABAGetLeistungsdaten](101, '2008-01-01', '2008-01-31', 1)
           101 = KGS Graubünden
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnABAGetLeistungsdaten.sql $
 * 
 * 9     1.09.09 13:34 Cjaeggi
 * Fixed comments
 * 
 * 8     27.08.09 13:00 Spsota
 * #4835 ZLE Performance verbesserungen
 * 
 * 7     18.08.09 15:24 Cjaeggi
 * Added new index on BDELeistung
 * 
 * 6     18.08.09 14:59 Cjaeggi
 * #5174: Fixed performance problem
 * 
 * 5     18.08.09 14:09 Cjaeggi
 * #5174: Performance optimized
 * 
 * 4     18.08.09 12:57 Cjaeggi
 * #5174: Performanceoptimierung vorbereiten
 * 
 * 1     3.09.08 17:50 Aklopfenstein
 * 
 * 2     29.08.08 13:21 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnABAGetLeistungsdaten
 (
  @MandantenNr INT,
  @DatumVon DATETIME,
  @DatumBis DATETIME,
  @LanguageCode INT
 )
RETURNS @Result TABLE
--DECLARE @Result TABLE
(
  [Id$] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
  [UserID$] INT,
  [Periodendatum$] DATETIME,
  [Mandanten-Nr.] INT,
  [Perioden-Nr.] INT,
  [MA-Nr.] INT,
  [Name] VARCHAR(200),
  [Vorname] VARCHAR(200),
  [Lohntyp] VARCHAR(2000),
  [Lohnart] INT,
  [SumTotalStunden] MONEY,
  [SumPartialStunden] MONEY,
  [SumPartialProzent] MONEY,  -- 0.0-100.0 are valid, negative or NULL are invalid and will not be exported!
  [Kostenstelle] INT,
  [Kostenart] INT,
  [Kostenträger] INT,
  [Freigabe] BIT,
  [Visum] BIT,
  [Verbucht] BIT,
  [VerbuchtLD] BIT,
  [KeinExport] BIT,
  [Periode] VARCHAR(255)
)
AS BEGIN
  -----------------------------------------------------------------------------
  -- debug only
  -----------------------------------------------------------------------------
  /*
  DECLARE @MandantenNr INT
  DECLARE @DatumVon DATETIME
  DECLARE @DatumBis DATETIME
  DECLARE @LanguageCode INT

  SET @MandantenNr = 41
  SET @DatumVon = '2008-07-01'
  SET @DatumBis = '2008-07-31'
  SET @LanguageCode = 1
  --*/
  
  -----------------------------------------------------------------------------
  -- validate first
  -----------------------------------------------------------------------------
  IF (@MandantenNr IS NULL OR @DatumVon IS NULL OR @DatumBis IS NULL OR @LanguageCode IS NULL)
  BEGIN
    INSERT INTO @Result ([Name]) VALUES ('Error: Invalid parameters, could not execute query')
    RETURN
  END
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @PeriodenNr INT
  DECLARE @ZeitraumString VARCHAR(50)
  
  -- set periode
  SET @ZeitraumString = dbo.fnGetZeitraumString(@DatumVon, @DatumBis)
  
  -- set PeriodenNr
  SET @PeriodenNr = dbo.fnOrgUnitHierarchyValue(dbo.fnBDEGetOrgUnitIDFromMandantenNr(@MandantenNr), 'leistunglohnlnr')
  
  -----------------------------------------------------------------------------
  -- validate PeriodenNr
  -----------------------------------------------------------------------------
  -- PeriodenNr
  IF (ISNULL(@PeriodenNr, 0) < 1)
  BEGIN
    INSERT INTO @Result ([Name]) VALUES ('Error: Invalid PeriodenNr value, could not execute query')
    RETURN
  END
  
  -----------------------------------------------------------------------------
  -- create temporary table to gain performance
  -----------------------------------------------------------------------------
  DECLARE @TmpUserDataPerDate TABLE
  (
    ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    UserID INT NOT NULL,
    Datum DATETIME NOT NULL,
    --
    HistMandantenNrPerDate INT
  )
  
  -----------------------------------------------------------------------------
  -- fill temporary table with single entry per user and date
  -----------------------------------------------------------------------------
  INSERT INTO @TmpUserDataPerDate (UserID, Datum, HistMandantenNrPerDate)
    SELECT DISTINCT
           UserID = LEI.UserID,
           Datum  = LEI.Datum,
           HistMandantenNrPerDate = LEI.HistMandantNr   -- old: dbo.fnBDEGetHistMandantenNrPerDate(TMP.UserID, TMP.Datum, NULL), it's not in every case the same as new: dbo.fnBDEGetHistMandantenNrPerDate(LEI.UserID, LEI.Datum, LEI.KostenstelleOrgUnitID) but should not matter...
     FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
     WHERE ISNULL(LEI.LohnartCode, -1) < 1 AND        -- only those for Monatslohn (no LohnartCode)
           LEI.Datum BETWEEN @DatumVon AND @DatumBis  -- only within given range
  
  -- remove those with invalid mandantennr
  DELETE TMP
  FROM @TmpUserDataPerDate TMP
  WHERE ISNULL(TMP.HistMandantenNrPerDate, -1) <> @MandantenNr
  
  -----------------------------------------------------------------------------
  -- write output to result table
  -----------------------------------------------------------------------------
  -- >> UNIQUE MandantenNr, Kostenstelle, Kostentraeger, Kostenart
  --    to create sums
  -- --
  -- INFO: set only required columns to result to gain performance
  -----------------------------------------------------------------------------
  INSERT INTO @Result ([UserID$], [MA-Nr.], [Name], [Vorname], [Lohntyp], [Kostenstelle], [Kostenart], [Kostenträger])
    SELECT DISTINCT
          [UserID$]      = LEI.UserID,
          --
          [MA-Nr.]       = USR.MitarbeiterNr,
          [Name]         = USR.LastName,
          [Vorname]      = USR.FirstName,
          [Lohntyp]      = dbo.fnGetLOVMLText('BenutzerLohnTyp', USR.LohntypCode, @LanguageCode),
          --
          [Kostenstelle] = LEI.HistKostenstelle,
          [Kostenart]    = LEI.HistKostenart,
          [Kostenträger] = LEI.HistKostentraeger
    FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
      INNER JOIN dbo.XUser USR WITH (READUNCOMMITTED) ON USR.UserID = LEI.UserID
      INNER JOIN @TmpUserDataPerDate TMP              ON TMP.UserID = LEI.UserID AND
                                                         TMP.Datum = LEI.Datum AND
                                                         TMP.HistMandantenNrPerDate = @MandantenNr -- filter only user's member orgunit mandantennr
    
    WHERE ISNULL(LEI.LohnartCode, -1) < 1 AND                                                      -- only those for Monatslohn (no LohnartCode)
          LEI.Datum BETWEEN @DatumVon AND @DatumBis                                                -- only within given range
  
  -----------------------------------------------------------------------------
  -- update pending fields:
  -- --------------------------------------------------------------------------
  -- SumTotalStunden:   are total amount of relevant hours (100%-base)
  -- SumPartialStunden: are total amount of relevant hours for equal entry (*%base)
  -----------------------------------------------------------------------------
  -- update SumTotalStunden and SumPartialStunden
  UPDATE RES
  SET -- Total: Only UserID, DateRange, MandantenNr has to be equal
      RES.[SumTotalStunden]   = ISNULL((SELECT SUM(LEI.Dauer)
                                        FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
                                          INNER JOIN @TmpUserDataPerDate TMP ON TMP.UserID = LEI.UserID AND
                                                                                TMP.Datum = LEI.Datum AND
                                                                                TMP.HistMandantenNrPerDate = @MandantenNr -- filter only user's member orgunit mandantennr
                                        WHERE LEI.UserID = RES.[UserID$] AND
                                              LEI.Datum BETWEEN @DatumVon AND @DatumBis AND
                                              ISNULL(LEI.LohnartCode, -1) < 1     -- only those for Monatslohn (no LohnartCode)
                                       ), 0.0),
      
      -- Partial: UserID, DateRange, MandantenNr, Kostenstelle, Kostenträger, Kostenart has to be equal
      RES.[SumPartialStunden] = ISNULL((SELECT SUM(LEI.Dauer)
                                        FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
                                          INNER JOIN @TmpUserDataPerDate TMP ON TMP.UserID = LEI.UserID AND
                                                                                TMP.Datum = LEI.Datum AND
                                                                                TMP.HistMandantenNrPerDate = @MandantenNr -- filter only user's member orgunit mandantennr
                                        WHERE LEI.UserID = RES.[UserID$] AND
                                              LEI.Datum BETWEEN @DatumVon AND @DatumBis AND
                                              ISNULL(LEI.LohnartCode, -1) < 1 AND   -- only those for Monatslohn (no LohnartCode)
                                              LEI.HistKostenstelle = RES.[Kostenstelle] AND
                                              LEI.HistKostentraeger = RES.[Kostenträger] AND
                                              LEI.HistKostenart = RES.[Kostenart]
                                       ), 0.0)
  FROM @Result RES
  
  -----------------------------------------------------------------------------
  -- remove those without any hours within total
  -- 
  -- INFO: (-)1.0h + (+)1.0h gives 0.0h!! this case is handled now 
  --       --> don't delete those rows where SumPartialStunden is <> 1
  -----------------------------------------------------------------------------
  DELETE FROM @Result
  WHERE ISNULL([SumTotalStunden], 0.0) = 0.0 AND
        ISNULL([SumPartialStunden], 0.0) = 0.0
  
  -----------------------------------------------------------------------------
  -- calculate percentage
  -----------------------------------------------------------------------------
  -- update SumPartialProzent  
  UPDATE RES
  SET RES.[SumPartialProzent] = (RES.[SumPartialStunden] * 100) / (RES.[SumTotalStunden]) -- due to maximal precision, we first calculate 100-percentage, before division
  FROM @Result RES
  WHERE ISNULL(RES.[SumTotalStunden], 0.0) <> 0.0
  
  -----------------------------------------------------------------------------
  -- update final static and pending fields:
  -----------------------------------------------------------------------------
  UPDATE RES
  SET RES.[Periodendatum$] = @DatumBis,        -- static given from parameter
      RES.[Mandanten-Nr.]  = @MandantenNr,     -- mandantennummer given and filtered in WHERE clause above
      RES.[Perioden-Nr.]   = @PeriodenNr,      -- static given from MandantenNr
      RES.[Lohnart]        = 9630,             -- constant value
      RES.[Periode]        = @ZeitraumString,  -- set above
      --
      -- Freigabe: is for whole daterange and all inserted entries
      RES.[Freigabe]   = CASE WHEN EXISTS(SELECT TOP 1 1
                                          FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
                                          WHERE LEI.UserID = RES.[UserID$] AND
                                                LEI.Datum BETWEEN @DatumVon AND @DatumBis AND
                                                ISNULL(LEI.Freigegeben, 0) = 0) THEN 0
                              ELSE 1
                         END,
      --
      -- Visum: is for whole daterange and all inserted entries
      RES.[Visum]      = CASE WHEN EXISTS(SELECT TOP 1 1
                                          FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
                                          WHERE LEI.UserID = RES.[UserID$] AND
                                                LEI.Datum BETWEEN @DatumVon AND @DatumBis AND
                                                ISNULL(LEI.Visiert, 0) = 0) THEN 0
                              ELSE 1
                         END,
      --
      -- Verbucht: is only for current Kostenstelle but all inserted entries of this Kostenstelle
      RES.[Verbucht]   = CASE WHEN EXISTS(SELECT TOP 1 1
                                          FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
                                          WHERE LEI.UserID = RES.[UserID$] AND
                                                LEI.Datum BETWEEN @DatumVon AND @DatumBis AND
                                                ISNULL(LEI.Verbucht, '') = '' AND
                                                LEI.HistKostenstelle = RES.[Kostenstelle]
                                         ) THEN 0
                              ELSE 1
                         END,
      --
      -- VerbuchtLD: is only for current Kostenstelle but all inserted entries of this Kostenstelle
      RES.[VerbuchtLD] = CASE WHEN EXISTS(SELECT TOP 1 1
                                          FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
                                          WHERE LEI.UserID = RES.[UserID$] AND
                                                LEI.Datum BETWEEN @DatumVon AND @DatumBis AND
                                                ISNULL(LEI.VerbuchtLD, '') = '' AND
                                                LEI.HistKostenstelle = RES.[Kostenstelle]
                                         ) THEN 0
                              ELSE 1
                         END,
  
	  --
	  -- Kein Export (Sobald es eine Entität mit KeinExport gibt, dann true).
      RES.[KeinExport]      = CASE WHEN EXISTS(SELECT TOP 1 1
                                          FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
                                          WHERE LEI.UserID = RES.[UserID$] AND
                                                LEI.Datum BETWEEN @DatumVon AND @DatumBis AND
                                                ISNULL(LEI.KeinExport, 0) = 1) THEN 1
                              ELSE 0
                         END           
  
                               
  FROM @Result RES
  
  -----------------------------------------------------------------------------
  -- debug
  -----------------------------------------------------------------------------
  /*
  SELECT *
  FROM @Result
  --*/
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN
END
GO