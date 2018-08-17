SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnABAGetStundenlohn
GO
/*===============================================================================================
  $Revision: 8 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Is used for Stundenlohn (Query and Schnittstelle)
    @MandantenNr:  The MandantenNr to use for filtering (performance!)
    @DatumVon:     The start date to get data for (period)
    @DatumBis:     The end date to get data for (period)
    @LanguageCode: The language code to use for data
  -
  RETURNS: Table containing all data found for query and Schnittstelle
  -
=================================================================================================
  TEST:    SELECT * FROM [dbo].[fnABAGetStundenlohn](101, '2008-01-01', '2008-01-31', 1)
           101 = KGS Graubünden
=================================================================================================*/

CREATE FUNCTION dbo.fnABAGetStundenlohn
(
  @MandantenNr INT,
  @DatumVon datetime,
  @DatumBis datetime,
  @LanguageCode INT
)
RETURNS @Result TABLE
--DECLARE @Result TABLE
(
  [ID$] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
  [UserID$] INT,
  [Periodendatum$] DATETIME,
  [Mandanten-Nr.] INT,
  [Perioden-Nr.] INT,
  [MA-Nr.] INT,
  [Name] VARCHAR(200),
  [Vorname] VARCHAR(200),
  [Lohntyp] VARCHAR(2000),
  [Lohnart 1100] MONEY,
  [Lohnart 1110] MONEY,
  [Lohnart 1120] MONEY,
  [Lohnart 1130] MONEY,
  --[Lohnart 5] MONEY,
  --[Lohnart 6] MONEY,
  --[Lohnart 7] MONEY,
  --[Lohnart 8] MONEY,
  --[Lohnart 9] MONEY,
  --[Lohnart 10] MONEY,
  [Lohnart 1210] MONEY,
  [Lohnart 1220] MONEY,
  [Lohnart 1230] MONEY,
  [Lohnart 1240] MONEY,
  [Lohnart 1250] MONEY,
  [Lohnart 1260] MONEY,
  --[Lohnart 17] MONEY,
  --[Lohnart 18] MONEY,
  --[Lohnart 19] MONEY,
  --[Lohnart 20] MONEY,
  [Kostenstelle] INT,
  [Kostenart] INT,
  [Kostenträger] INT,
  [Freigabe] BIT,
  [Visum] BIT,
  [Verbucht] BIT,
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

  SET @MandantenNr = 1
  SET @DatumVon = '2013-01-01'
  SET @DatumBis = '2013-12-31'
  SET @LanguageCode = 1
  --*/
  
  -----------------------------------------------------------------------------
  -- validate first
  -----------------------------------------------------------------------------
  IF (@MandantenNr IS NULL OR @DatumVon IS NULL OR @DatumBis IS NULL OR @LanguageCode IS NULL)
  BEGIN
    INSERT INTO @Result ([Name]) VALUES ('Error: Invalid parameters, could not execute query');
    RETURN;
  END;
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @PeriodenNr INT;
  DECLARE @ZeitraumString VARCHAR(50);
  
  -- set periode
  SET @ZeitraumString = dbo.fnGetZeitraumString(@DatumVon, @DatumBis);
  
  -- PeriodenNr
  SET @PeriodenNr = dbo.fnOrgUnitHierarchyValue(dbo.fnBDEGetOrgUnitIDFromMandantenNr(@MandantenNr), 'stundenlohnlnr');
  
  -----------------------------------------------------------------------------
  -- validate PeriodenNr
  -----------------------------------------------------------------------------
  IF (ISNULL(@PeriodenNr, 0) < 1)
  BEGIN
    INSERT INTO @Result ([Name]) VALUES ('Error: Invalid PeriodenNr value, could not execute query');
    RETURN;
  END;
  
  -----------------------------------------------------------------------------
  -- write out result to output
  -- >> UNIQUE MandantenNr, Kostenstelle, Kostentraeger, Kostenart
  --    to create sum for Lohnart XXXX
  -----------------------------------------------------------------------------
  WITH Dauer_CTE AS (
    SELECT
      UserID,
      HistKostenstelle,
      HistKostentraeger,
      HistKostenart
      , Lohnart_1100 = SUM(CASE WHEN LEI.LohnartCode = 1100 THEN LEI.Dauer ELSE 0.0 END) --LA1
      , Lohnart_1110 = SUM(CASE WHEN LEI.LohnartCode = 1110 THEN LEI.Dauer ELSE 0.0 END) --LA2
      , Lohnart_1120 = SUM(CASE WHEN LEI.LohnartCode = 1120 THEN LEI.Dauer ELSE 0.0 END) --LA3
      , Lohnart_1130 = SUM(CASE WHEN LEI.LohnartCode = 1130 THEN LEI.Dauer ELSE 0.0 END) --LA4
      --, Lohnart_5 = SUM(CASE WHEN LEI.LohnartCode = -5 THEN LEI.Dauer ELSE 0.0 END) --LA5
      --, Lohnart_6 = SUM(CASE WHEN LEI.LohnartCode = -6 THEN LEI.Dauer ELSE 0.0 END) --LA6
      --, Lohnart_7 = SUM(CASE WHEN LEI.LohnartCode = -7 THEN LEI.Dauer ELSE 0.0 END) --LA7
      --, Lohnart_8 = SUM(CASE WHEN LEI.LohnartCode = -8 THEN LEI.Dauer ELSE 0.0 END) --LA8
      --, Lohnart_9 = SUM(CASE WHEN LEI.LohnartCode = -9 THEN LEI.Dauer ELSE 0.0 END) --LA9
      --, Lohnart_10 = SUM(CASE WHEN LEI.LohnartCode = -10 THEN LEI.Dauer ELSE 0.0 END) --LA10
      , Lohnart_1210 = SUM(CASE WHEN LEI.LohnartCode = 1210 THEN LEI.Dauer ELSE 0.0 END) --LA11
      , Lohnart_1220 = SUM(CASE WHEN LEI.LohnartCode = 1220 THEN LEI.Dauer ELSE 0.0 END) --LA12
      , Lohnart_1230 = SUM(CASE WHEN LEI.LohnartCode = 1230 THEN LEI.Dauer ELSE 0.0 END) --LA13
      , Lohnart_1240 = SUM(CASE WHEN LEI.LohnartCode = 1240 THEN LEI.Dauer ELSE 0.0 END) --LA14
      , Lohnart_1250 = SUM(CASE WHEN LEI.LohnartCode = 1250 THEN LEI.Dauer ELSE 0.0 END) --LA15
      , Lohnart_1260 = SUM(CASE WHEN LEI.LohnartCode = 1260 THEN LEI.Dauer ELSE 0.0 END) --LA16
      --, Lohnart_17 = SUM(CASE WHEN LEI.LohnartCode = -17 THEN LEI.Dauer ELSE 0.0 END) --LA17
      --, Lohnart_18 = SUM(CASE WHEN LEI.LohnartCode = -18 THEN LEI.Dauer ELSE 0.0 END) --LA18
      --, Lohnart_19 = SUM(CASE WHEN LEI.LohnartCode = -19 THEN LEI.Dauer ELSE 0.0 END) --LA19
      --, Lohnart_20 = SUM(CASE WHEN LEI.LohnartCode = -20 THEN LEI.Dauer ELSE 0.0 END) --LA20
    FROM dbo.BDELeistung      LEI WITH(READUNCOMMITTED)
    WHERE LEI.Datum BETWEEN @DatumVon AND @DatumBis
      AND LEI.HistMandantNr = @MandantenNr
      AND ISNULL(LEI.LohnartCode, -1) > 0 -- nur Stundenlohn + gültige Lohnarten (inaktive haben negativen Code)
    GROUP BY LEI.UserID, LEI.HistKostenstelle, LEI.HistKostentraeger, LEI.HistKostenart
  )
  INSERT INTO @Result
    SELECT DISTINCT
          [UserID$]        = LEI.UserID,
          [Periodendatum$] = @DatumBis,
          --
          [Mandanten-Nr.]  = @MandantenNr, -- mandantennummer given and filtered in WHERE clause
          [Perioden-Nr.]   = @PeriodenNr,  -- static given from MandantenNr
          --
          [MA-Nr.]         = USR.MitarbeiterNr,
          [Name]           = USR.LastName,
          [Vorname]        = USR.FirstName,
          [Lohntyp]        = dbo.fnGetLOVMLText('BenutzerLohnTyp', USR.LohntypCode, @LanguageCode),
          --
          [Lohnart 1100]   = ISNULL(CTE.Lohnart_1100, 0.0),
          [Lohnart 1110]   = ISNULL(CTE.Lohnart_1110, 0.0),
          [Lohnart 1120]   = ISNULL(CTE.Lohnart_1120, 0.0),
          [Lohnart 1130]   = ISNULL(CTE.Lohnart_1130, 0.0),
          --[Lohnart 5]   = ISNULL(CTE.Lohnart_5, 0.0),
          --[Lohnart 6]   = ISNULL(CTE.Lohnart_6, 0.0),
          --[Lohnart 7]   = ISNULL(CTE.Lohnart_7, 0.0),
          --[Lohnart 8]   = ISNULL(CTE.Lohnart_8, 0.0),
          --[Lohnart 9]   = ISNULL(CTE.Lohnart_9, 0.0),
          --[Lohnart 10]   = ISNULL(CTE.Lohnart_10, 0.0),
          [Lohnart 1210]   = ISNULL(CTE.Lohnart_1210, 0.0),
          [Lohnart 1220]   = ISNULL(CTE.Lohnart_1220, 0.0),
          [Lohnart 1230]   = ISNULL(CTE.Lohnart_1230, 0.0),
          [Lohnart 1240]   = ISNULL(CTE.Lohnart_1240, 0.0),
          [Lohnart 1250]   = ISNULL(CTE.Lohnart_1250, 0.0),
          [Lohnart 1260]   = ISNULL(CTE.Lohnart_1260, 0.0),
          --[Lohnart 17]   = ISNULL(CTE.Lohnart_17, 0.0),
          --[Lohnart 18]   = ISNULL(CTE.Lohnart_18, 0.0),
          --[Lohnart 19]   = ISNULL(CTE.Lohnart_19, 0.0),
          --[Lohnart 20]   = ISNULL(CTE.Lohnart_20, 0.0),
          --
          [Kostenstelle]   = LEI.HistKostenstelle,
          [Kostenart]      = LEI.HistKostenart,
          [Kostenträger]   = LEI.HistKostentraeger,
          --
          -- Freigabe is for whole daterange and all inserted entries
          [Freigabe] = CASE WHEN EXISTS(SELECT TOP 1 1
                                        FROM dbo.BDELeistung LEI2 WITH (READUNCOMMITTED)
                                        WHERE LEI2.UserID = LEI.UserID AND
                                              LEI2.Datum BETWEEN @DatumVon AND @DatumBis AND
                                              ISNULL(LEI2.Freigegeben, 0) = 0) THEN 0
                            ELSE 1
                       END,
          --
          -- Visum is for whole daterange and all inserted entries
          [Visum]    = CASE WHEN EXISTS(SELECT TOP 1 1
                                        FROM dbo.BDELeistung LEI3 WITH (READUNCOMMITTED)
                                        WHERE LEI3.UserID = LEI.UserID AND
                                              LEI3.Datum BETWEEN @DatumVon AND @DatumBis AND
                                              ISNULL(LEI3.Visiert, 0) = 0) THEN 0
                            ELSE 1
                       END,
          --
          -- Verbucht is only for current Kostenstelle but all inserted entries of this Kostenstelle
          [Verbucht] = CASE WHEN EXISTS(SELECT TOP 1 1
                                        FROM dbo.BDELeistung LEI4 WITH (READUNCOMMITTED)
                                        WHERE LEI4.UserID = LEI.UserID AND
                                              LEI4.Datum BETWEEN @DatumVon AND @DatumBis AND
                                              ISNULL(LEI4.Verbucht, '') = '' AND
                                              LEI4.HistKostenstelle = LEI.HistKostenstelle
                                              ) THEN 0
                            ELSE 1
                       END,
          --
          [KeinExport]  = LEI.KeinExport,
          --
          [Periode]  = @ZeitraumString
    
    FROM dbo.BDELeistung                LEI WITH(READUNCOMMITTED)
      INNER JOIN Dauer_CTE              CTE ON CTE.UserID = LEI.UserID
                                           AND CTE.HistKostenstelle = LEI.HistKostenstelle
                                           AND CTE.HistKostentraeger = LEI.HistKostentraeger
                                           AND CTE.HistKostenart = LEI.HistKostenart
      INNER JOIN dbo.XUser              USR WITH(READUNCOMMITTED) ON USR.UserID = LEI.UserID
      INNER JOIN dbo.XUserStundenansatz USA WITH(READUNCOMMITTED) ON USA.UserID = USR.UserID
                                                                 AND (ISNULL(USA.Lohnart1, 0) +
                                                                      ISNULL(USA.Lohnart2, 0) +
                                                                      ISNULL(USA.Lohnart3, 0) +
                                                                      ISNULL(USA.Lohnart4, 0) +
                                                                      ISNULL(USA.Lohnart5, 0) +
                                                                      ISNULL(USA.Lohnart6, 0) +
                                                                      ISNULL(USA.Lohnart7, 0) +
                                                                      ISNULL(USA.Lohnart8, 0) +
                                                                      ISNULL(USA.Lohnart9, 0) +
                                                                      ISNULL(USA.Lohnart10, 0) +
                                                                      ISNULL(USA.Lohnart11, 0) +
                                                                      ISNULL(USA.Lohnart12, 0) +
                                                                      ISNULL(USA.Lohnart13, 0) +
                                                                      ISNULL(USA.Lohnart14, 0) +
                                                                      ISNULL(USA.Lohnart15, 0) +
                                                                      ISNULL(USA.Lohnart16, 0) +
                                                                      ISNULL(USA.Lohnart17, 0) +
                                                                      ISNULL(USA.Lohnart18, 0) +
                                                                      ISNULL(USA.Lohnart19, 0) +
                                                                      ISNULL(USA.Lohnart20, 0)) > 0;
  
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
  RETURN;
END;
GO