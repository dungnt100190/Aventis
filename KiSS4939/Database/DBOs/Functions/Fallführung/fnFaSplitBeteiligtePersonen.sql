SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnFaSplitBeteiligtePersonen;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/Fallführung/fnFaSplitBeteiligtePersonen.sql $
  $Author: Cjaeggi $
  $Modtime: 5.08.10 13:35 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to split db-field 'BeteiligtePersonen' into
           desired strings with given line break mode
    @BeteiligtePersonen: The ids from (+)BaPerson and (-)BaInstitution to split
    @LineBreakMode:      0=',', 1=CRLF
    @LanguageCode:       The language code (1=D, 2=F, 3=I) (not yet used)
  -
  RETURNS: 'Name Vorname' (BaPerson) and 'Name Vorname' (BaInstitution) in ',' mode 
           OR
           'Name, Vorname' (BaPerson) and 'Name, Vorname' (BaInstitution) in CRLF mode
  -
  TEST:    SELECT dbo.fnFaSplitBeteiligtePersonen('35370,35369,35371,-552', 0, 1)
           SELECT dbo.fnFaSplitBeteiligtePersonen('35370,35369,35371,-552', 1, 1)
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/Fallführung/fnFaSplitBeteiligtePersonen.sql $
 * 
 * 3     5.08.10 13:36 Cjaeggi
 * #4167: Fixed function after changes
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:51 Aklopfenstein
 * 
 * 1     29.08.08 15:34 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnFaSplitBeteiligtePersonen
(
  @BeteiligtePersonen VARCHAR(2000),
  @LineBreakMode INT,
  @LanguageCode INT
)
RETURNS VARCHAR(8000)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- if not date is passed, invalid value
  IF (@BeteiligtePersonen IS NULL)
  BEGIN
    RETURN NULL;
  END;
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @OUTPUT VARCHAR(8000);
  
  DECLARE @LineBreakChar VARCHAR(10);
  DECLARE @LenLineBreak INT;
  
  DECLARE @SplittedIDs TABLE (ID INT NOT NULL, SortKey INT);
  DECLARE @CurrentID INT; -- store id from cursor (+)=ID in BaPerson, (-)=ID in BaInstitution
  DECLARE @SortKey INT;
  
  DECLARE @AddOutput VARCHAR(255);
  
  -- prepare vars
  SET @OUTPUT = '';
  
  -----------------------------------------------------------------------------
  -- setup line break
  -----------------------------------------------------------------------------
  IF (@LineBreakMode = 1)
  BEGIN
    -- multiline
    SET @LineBreakChar = CHAR(13) + CHAR(10);
    SET @LenLineBreak = 2;
  END
  ELSE
  BEGIN
    -- comma separated (default)
    SET @LineBreakChar = ', ';
    SET @LenLineBreak = 2;
  END;
  
  -----------------------------------------------------------------------------
  -- split value
  -----------------------------------------------------------------------------
  INSERT INTO @SplittedIDs (ID, SortKey)
    SELECT CONVERT(INT, SplitValue), OccurenceId
    FROM dbo.fnSplitStringToValues(@BeteiligtePersonen, ',', 1);
  
  -----------------------------------------------------------------------------
  -- loop values and add name to output
  -----------------------------------------------------------------------------
  -- setup cursor
  --   get all different ids
  DECLARE curIDs CURSOR FAST_FORWARD FOR
    SELECT DISTINCT ID, SortKey
    FROM @SplittedIDs
    ORDER BY SortKey ASC;

  -- iterate through cursor
  OPEN curIDs
  WHILE 1 = 1
  BEGIN
    -- read next row and check if we have one
    FETCH NEXT FROM curIDs INTO @CurrentID, @SortKey;
    IF @@FETCH_STATUS != 0 BREAK;

    -- reset value
    SET @AddOutput = NULL;

    -- depending on id, we get value
    IF (@CurrentID >= 0)
    BEGIN
      -- ID in BaPerson, get value depending on line break mode
      SELECT @AddOutput = CASE 
                            WHEN @LineBreakMode = 1 THEN dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname) -- CRLF
                            ELSE REPLACE(dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname), ',', '') -- ','
                          END
      FROM BaPerson PRS
      WHERE PRS.BaPersonID = @CurrentID;
    END
    ELSE
    BEGIN
      -- ID in BaInstitution
      SELECT @AddOutput = CASE 
                            WHEN @LineBreakMode = 1 THEN dbo.fnGetLastFirstName(NULL, INS.Name, INS.Vorname) -- CRLF
                            ELSE REPLACE(dbo.fnGetLastFirstName(NULL, INS.Name, INS.Vorname), ',', '') -- ','
                          END
      FROM BaInstitution INS
      WHERE INS.BaInstitutionID = -@CurrentID;
    END;
    
    -- append id to output
    SET @OUTPUT = CASE 
                    WHEN ISNULL(@OUTPUT, '') = '' OR RIGHT(@OUTPUT, @LenLineBreak) = @LineBreakChar THEN @OUTPUT + ISNULL(@AddOutput, '')
                    ELSE @OUTPUT + ISNULL(@LineBreakChar + @AddOutput, '')
                  END;
  END; -- [WHILE cursor]
  
  -- clean up cursor
  CLOSE curIDs;
  DEALLOCATE curIDs;
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------  
  RETURN @OUTPUT;
END;
GO