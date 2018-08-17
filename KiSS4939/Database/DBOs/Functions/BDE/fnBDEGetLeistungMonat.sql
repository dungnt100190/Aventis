SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEGetLeistungMonat;
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get values for month (only direct calculated values)
    @UserID:       The user to get data from
    @LanguageCode: The language code used for display data
    @OnlyMonth:    Show only specified month of specified year
    @OnlyYear:     Show only specified month of specified year
  -
  RETURNS: Table containing year, month and corresponding BDE-values for given parameters
  -
  INFO:    Some fields are used in dbo.fnBDEGetUebersicht()
=================================================================================================
  TEST:    SELECT * FROM dbo.fnBDEGetLeistungMonat(2, 1, NULL, NULL)
           SELECT * FROM dbo.fnBDEGetLeistungMonat(515, 1, NULL, NULL)
           SELECT * FROM dbo.fnBDEGetLeistungMonat(515, 1, 4, 2008)
           SELECT * FROM dbo.fnBDEGetLeistungMonat(515, 1, 8, 2008)
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEGetLeistungMonat
(
  @UserID INT,
  @LanguageCode INT,
  @OnlyMonth INT,
  @OnlyYear INT
)
RETURNS @Result TABLE
(
  Id$ INT identity(1, 1) NOT NULL PRIMARY KEY,
  UserID INT,
  Jahr INT,
  Monat INT,
  MonatText VARCHAR(50),
  MonatStartDatum DATETIME,
  MonatEndDatum DATETIME,
  GZIstArbeitszeitProMonat MONEY,
  GZSollArbeitszeitProMonat MONEY,
  GZMonatsSaldo MONEY,
  SLIstArbeitszeitProMonat MONEY,
  Freigegeben BIT,
  Visiert BIT,
  Verbucht DATETIME,
  VerbuchtLD DATETIME,
  IstVerbucht BIT,
  IstVerbuchtLD BIT,
  KeinExport BIT,
  Fakturiert BIT
)
AS 
BEGIN
  -------------------------------------------------------------------------------
  -- validate
  -------------------------------------------------------------------------------
  IF (@UserID IS NULL OR @LanguageCode IS NULL)
  BEGIN
    -- invalid values
    RETURN;
  END;
  
  -------------------------------------------------------------------------------
  -- temporary table (same as result)
  -------------------------------------------------------------------------------
  DECLARE @Temp TABLE
  (
    UserID INT,
    Jahr INT,
    Monat INT,
    MonatText VARCHAR(50),
    MonatStartDatum DATETIME,
    MonatEndDatum DATETIME,
    GZIstArbeitszeitProMonat MONEY,
    GZSollArbeitszeitProMonat MONEY,
    GZMonatsSaldo MONEY,
    SLIstArbeitszeitProMonat MONEY,
    Freigegeben BIT,
    Visiert BIT,
    Verbucht DATETIME,
    VerbuchtLD DATETIME,
    IstVerbucht BIT,
    IstVerbuchtLD BIT,
    KeinExport BIT,
    Fakturiert BIT
  );
  
  -------------------------------------------------------------------------------
  -- get all defined month and status flags
  -------------------------------------------------------------------------------
  INSERT INTO @Temp (Jahr, Monat, Freigegeben, Visiert, Verbucht, VerbuchtLD, Fakturiert)
    SELECT Jahr        = YEAR(LEI.Datum),
           Monat       = MONTH(LEI.Datum),
           Freigegeben = MIN(CASE 
                               WHEN LEI.Freigegeben = 1 THEN 1 
                               ELSE 0 
                             END),
           Visiert     = MIN(CASE 
                               WHEN LEI.Visiert = 1 THEN 1 
                               ELSE 0 
                             END),
           Verbucht    = MAX(LEI.Verbucht),
           VerbuchtLD  = MAX(LEI.VerbuchtLD),
           Fakturiert  = MIN(CASE
                               WHEN LEI.Fakturiert = 1 THEN 1 
                               ELSE 0 
                             END)
    FROM dbo.BDELeistung LEI WITH(READUNCOMMITTED)
    WHERE LEI.UserID = @UserID
    GROUP BY YEAR(LEI.Datum), MONTH(LEI.Datum);

  -------------------------------------------------------------------------------
  -- check if we have a value for only month with year
  -------------------------------------------------------------------------------
  IF (@OnlyMonth IS NOT NULL AND 
      @OnlyYear IS NOT NULL AND 
      NOT EXISTS(SELECT TOP 1 1 
                 FROM @Temp 
                 WHERE Monat = @OnlyMonth 
                   AND Jahr = @OnlyYear))
  BEGIN
    -- no data for desired month and year, that should not be! >> insert a specific row with default values
    INSERT INTO @Temp (Jahr, Monat, GZIstArbeitszeitProMonat, SLIstArbeitszeitProMonat, Freigegeben, Visiert, Verbucht, VerbuchtLD, Fakturiert)
      SELECT Jahr                     = @OnlyYear,
             Monat                    = @OnlyMonth,
             GZIstArbeitszeitProMonat = 0.0,
             SLIstArbeitszeitProMonat = 0.0,
             Freigegeben              = 0,
             Visiert                  = 0,
             Verbucht                 = NULL,
             VerbuchtLD               = NULL,
             Fakturiert               = 0;
  END;
  
  -------------------------------------------------------------------------------
  -- update values
  -- (1=Gleitzeitsaldo; 2=Gleitzeitkorrektur; 3=Feriensaldo, 4=Ferienkorrektur, 5=Stunden-Import)
  -------------------------------------------------------------------------------
  -- 1. step
  UPDATE @Temp
  SET UserID                    = @UserID,
      MonatText                 = dbo.fnXMonatML(Monat, @LanguageCode),
      MonatStartDatum           = dbo.fnGetDateFromInts(1, Monat, Jahr),
      MonatEndDatum             = dbo.fnLastDayOf(dbo.fnGetDateFromInts(1, Monat, Jahr)),
      IstVerbucht               = CONVERT(BIT, CASE 
                                                 WHEN Verbucht IS NULL THEN 0 
                                                 ELSE 1 
                                               END),
      IstVerbuchtLD             = CONVERT(BIT, CASE 
                                                 WHEN VerbuchtLD IS NULL THEN 0 
                                                 ELSE 1 
                                               END);

  -- 2. step (get amount of hours for 'Monatslohn')
  UPDATE TMP
  SET TMP.GZIstArbeitszeitProMonat = ISNULL((SELECT SUM(LEI.Dauer)
                                             FROM dbo.BDELeistung LEI WITH(READUNCOMMITTED)
                                               INNER JOIN dbo.BDELeistungsart ART WITH(READUNCOMMITTED) ON ART.BDELeistungsartID = LEI.BDELeistungsartID 
                                                                                                       AND ART.LeistungsartTypCode IN (1, 3, 5)
                                             WHERE LEI.UserID = @UserID 
                                               AND LEI.Datum BETWEEN TMP.MonatStartDatum AND TMP.MonatEndDatum 
                                               AND ISNULL(LEI.LohnartCode, -1) < 0), 0.0)
  FROM @Temp TMP;
  
  -- 3. step (get amount of hours for 'Stundenlohn')
  UPDATE TMP
  SET TMP.SLIstArbeitszeitProMonat = ISNULL((SELECT SUM(LEI.Dauer)
                                             FROM dbo.BDELeistung LEI WITH(READUNCOMMITTED)
                                               INNER JOIN dbo.BDELeistungsart ART WITH(READUNCOMMITTED) ON ART.BDELeistungsartID = LEI.BDELeistungsartID 
                                                                                                       AND ART.LeistungsartTypCode IN (1, 3, 5)
                                             WHERE LEI.UserID = @UserID 
                                               AND LEI.Datum BETWEEN TMP.MonatStartDatum AND TMP.MonatEndDatum 
                                               AND ISNULL(LEI.LohnartCode, -1) > -1), 0.0)
  FROM @Temp TMP;
  
  -- 4. step (get soll for 'Monatslohn')
  UPDATE @Temp
  SET GZSollArbeitszeitProMonat = dbo.fnBDEGetSollProMonat(@UserID, MonatEndDatum);
  
  -- 5. step (validate soll for 'Monatslohn')
  UPDATE @Temp
  SET GZSollArbeitszeitProMonat = CASE 
                                    WHEN ISNULL(GZSollArbeitszeitProMonat, -1) < 0.0 THEN 0.0  --(negative soll is not allowed)
                                    ELSE GZSollArbeitszeitProMonat
                                  END;
  
  -- 6. step (calculate saldo for 'Monatslohn')
  UPDATE @Temp
  SET GZMonatsSaldo = GZIstArbeitszeitProMonat - GZSollArbeitszeitProMonat; -- saldo = IST-SOLL
  
  -----------------------------------------------------------------------------
  -- apply values to result
  -----------------------------------------------------------------------------
  INSERT INTO @Result
    SELECT TMP.*
    FROM @Temp TMP
    WHERE (@OnlyMonth IS NULL AND @OnlyYear IS NULL) OR (TMP.Monat = @OnlyMonth AND TMP.Jahr = @OnlyYear)
    ORDER BY TMP.Jahr DESC, TMP.Monat DESC;
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN;
END;
GO