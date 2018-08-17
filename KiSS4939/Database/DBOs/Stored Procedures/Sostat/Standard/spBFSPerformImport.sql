SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spBFSPerformImport
GO
/*===============================================================================================
  $Revision: 12 $
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

CREATE PROCEDURE [dbo].[spBFSPerformImport]
(
  @BFSDossierID int,
  @BFSDossierPersonID  int = NULL
)
AS 
BEGIN
  SET NOCOUNT ON
  -- Perform Sanity Check on input variables
  IF @BFSDossierID IS NULL RETURN

    DECLARE @DebugMode bit,
            @ProcStart datetime,
            @FuncStart datetime

    SET @DebugMode = 1  -- hier DebugMode ein- oder ausschalten


    IF @DebugMode = 1 BEGIN
    SET @ProcStart = GetDate()
    PRINT 'Startzeit ' + CONVERT(varchar,@ProcStart,120)
  END

  DECLARE 
    @BaPersonID int,
    @FaLeistungID int,
    @AntragstellerID int,
    @DatumVon datetime,
    @DatumBis datetime,
    @Jahr int,
    @BFSLeistungsartCode int,
    @FFLOVName varchar(100),
    @Variable varchar(10),
    @VariableAntragsteller varchar(10),
    @BFSFeldCode int,
    @Frage varchar(200),
    @NameVorname varchar(300),
    @DossierStichtag bit

  SELECT @NameVorname = PRS.NameVorname
  FROM dbo.BFSDossierPerson PER
    INNER JOIN vwPerson PRS ON PRS.BaPersonID = PER.BaPersonID
  WHERE  BFSDossierPersonID = @BFSDossierPersonID

  PRINT 'BFSDossierID    : ' + CONVERT(varchar,@BFSDossierID)
  PRINT 'BFSDossierPerson: ' + CONVERT(varchar,@BFSDossierPersonID) + IsNull(' ' + @NameVorname,'')
  PRINT ''

  -- Declare some nice variables
  DECLARE @HerkunftSQL nvarchar(4000)
  DECLARE @BFSFrageID   int

  ------------------------------------------------------------------------------
  -- Declare the cursor; the cursor will loop through all available
  -- (and not filtered) SQL expressions.
  ------------------------------------------------------------------------------
  DECLARE BfsFragenKatalog_Cursor CURSOR FAST_FORWARD FOR
  SELECT
    DOS.FaLeistungID,
    DOS.Jahr,
    DOS.BFSLeistungsartCode,
    DOS.Stichtag,
    ANT.BaPersonID,
    DOS.DatumVon,
    DOS.DatumBis,
    PRS.BFSDossierPersonID,
    PRS.BaPersonID,
    FRA.BFSFrageID,
    FRA.HerkunftSQL,
    FRA.FFLOVName,
    FRA.Variable,
    FRA.VariableAntragsteller,
    FRA.BFSFeldCode,
    FRA.Frage
  FROM dbo.BFSDossier DOS
    INNER JOIN dbo.BFSDossierPerson PRS ON PRS.BFSDossierID = DOS.BFSDossierID
    INNER JOIN dbo.BFSFrage         FRA ON FRA.BFSKatalogVersionID = DOS.BFSKatalogVersionID
                                       AND FRA.BFSPersonCode = PRS.BFSPersonCode AND FRA.PersonIndex = PRS.PersonIndex
    INNER JOIN dbo.BFSDossierPerson ANT ON ANT.BFSDossierID = DOS.BFSDossierID 
                                       AND ANT.BFSPersonCode = 1 -- Antragsteller
    INNER JOIN dbo.BFSLOVCode       BLC ON BLC.LOVName = 'BFSLeistungsart'
                                       AND BLC.Code = DOS.BFSLeistungsartCode
  WHERE DOS.BFSDossierID = @BFSDossierID
    AND PRS.BFSDossierPersonID = IsNull(@BFSDossierPersonID, PRS.BFSDossierPersonID)
    AND FRA.HerkunftSQL IS NOT NULL
    AND ',' + FRA.BFSLeistungsfilterCodes + ',' LIKE '%,' + CONVERT(VARCHAR, BLC.Filter) + ',%'
    ORDER BY 
        CASE WHEN HerkunftSQL like '%fnBFSBetrag%' THEN 1 ELSE 0 END, 
        FRA.Reihenfolge, DOS.BFSDossierID

  ------------------------------------------------------------------------------
  -- Access the cursor
  ------------------------------------------------------------------------------
  OPEN BfsFragenKatalog_Cursor

  IF @DebugMode = 1 PRINT 'Zeitaufwand Cursor:' +  CONVERT(varchar,DateDiff(ms,@ProcStart,GetDate())) + ' ms'

  WHILE 1 = 1
  BEGIN
    FETCH NEXT FROM BfsFragenKatalog_Cursor INTO 
      @FaLeistungID, @Jahr, @BFSLeistungsartCode, @DossierStichtag, @AntragstellerID,
            @DatumVon, @DatumBis, @BFSDossierPersonID, @BaPersonID, @BFSFrageID,
            @HerkunftSQL, @FFLOVName, @Variable, @VariableAntragsteller, @BFSFeldCode, @Frage
    IF @@FETCH_STATUS < 0 BREAK

    IF @DebugMode = 1 
    BEGIN
      SET @FuncStart = GetDate()
      PRINT '------------------------------------------------------------------'
      PRINT 'Frage           : ' + CONVERT(varchar(10), @Variable) + ' - ' +  CONVERT(varchar(200), @Frage)
    END

    -- execute question query
    DECLARE @result    int
    DECLARE @value    sql_variant
    SET @value  = NULL
    SET @result = 5

    EXECUTE @result = sp_executesql @HerkunftSQL,
      N'@value sql_variant OUT, @BFSDossierID int, @Jahr int, @BFSLeistungsartCode int, @DossierStichtag bit, @BFSDossierPersonID int, @FaLeistungID int, @AntragstellerID int, @DatumVon datetime, @DatumBis datetime, @BaPersonID int, @LovName varchar(100), @Variable varchar(10), @VariableAntragsteller varchar(10)',
      @value OUT,
      @BFSDossierID,
      @Jahr,
      @BFSLeistungsartCode,
      @DossierStichtag,
      @BFSDossierPersonID,
      @FaLeistungID,
      @AntragstellerID,
      @DatumVon,
      @DatumBis,
      @BaPersonID,
      @FFLOVName,
      @Variable,
      @VariableAntragsteller

    
    IF (@result <> 0) 
    BEGIN 
      -- Failure in SQL execution 
      IF @DebugMode = 0 
      BEGIN
        PRINT '------------------------------------------------------------------'
        PRINT 'Frage           : ' + CONVERT(varchar(10), @Variable) + ' - ' +  CONVERT(varchar(200), @Frage)
      END
      PRINT 'BFSFrageID      : ' + CONVERT(varchar, @BFSFrageID)
      PRINT 'HerkunftSQL     : '
      PRINT CONVERT(varchar(4000),@HerkunftSQL)
    END ELSE 
    BEGIN
      IF @DebugMode = 1 PRINT 'Value           : ' + IsNull(CONVERT(varchar(150), @value),'NULL')
    END

    IF @BFSFeldCode = 8 -- Werteliste
       AND SQL_VARIANT_PROPERTY(@value, 'BaseType') = 'bit' AND @value = 0 -- false
    BEGIN
      SET @value = 2
    END


    IF EXISTS (  
      SELECT 1
      FROM dbo.BFSWert BFS
      WHERE BFS.BFSDossierID = @BFSDossierID
        AND BFS.BFSDossierPersonID = @BFSDossierPersonID 
        AND BFS.BFSFrageID = @BFSFrageID
    )
    BEGIN
      UPDATE dbo.BFSWert
      SET Wert = @value, PlausiFehler= NULL
      WHERE BFSDossierID = @BFSDossierID
        AND BFSDossierPersonID = @BFSDossierPersonID
        AND BFSFrageID = @BFSFrageID
    END
    ELSE
    BEGIN
      -- Store value in BFS table
      INSERT INTO dbo.BFSWert(
        BFSDossierID,
        BFSDossierPersonID,
        BFSFrageID,
        Wert,
        PlausiFehler)
      VALUES(
        @BFSDossierID,
        @BFSDossierPersonID,
        @BFSFrageID,
        @value,
        NULL)
    END
    
    IF @DebugMode = 1 
    BEGIN
      PRINT 'Zeitaufwand Variable:   ' +  CONVERT(varchar,DateDiff(ms,@FuncStart,GetDate())) + ' ms'
      PRINT 'Zeitaufwand seit Start: ' +  CONVERT(varchar,DateDiff(ms,@ProcStart,GetDate())) + ' ms'
    END
  END -- while BfsFragenKatalog_Cursor
  CLOSE BfsFragenKatalog_Cursor
  DEALLOCATE  BfsFragenKatalog_Cursor


  IF @DebugMode = 1
  BEGIN
    PRINT '------------------------------------------------------------------'
    PRINT 'Zeitaufwand gesamt: ' +  CONVERT(varchar, DateDiff(ms,@ProcStart, GetDate())) + ' ms'
  END
END

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
