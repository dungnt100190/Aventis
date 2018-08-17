SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnLOVMLColumnListe;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/PI/fnLOVMLColumnListe.sql $
  $Author: Cjaeggi $
  $Modtime: 18.03.10 13:00 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Get tag separated list of values specific of a single LOV.
           See config value 'System\GUI\SpaltenListenSeparator' for defining the tag globaly.
    @LOVName:      The name of the LOV to use for getting the data
    @Codes:        The codes to use for specifying the data to get
    @Column:       The column to use for getting the data ('value1', 'value2', 'shortText' > any other will be 'Text')
    @LanguageCode: The language to use for multilanguage content
  -
  RETURNS: Varchar containing the tag separated texts for given codes within the specified LOV
  -
  TEST:    SELECT dbo.fnLOVMLColumnListe('Sprache', '1,2,3', NULL, 1);
           SELECT dbo.fnLOVMLColumnListe('Sprache', '1,2,3', NULL, 2);
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/System/PI/fnLOVMLColumnListe.sql $
 * 
 * 3     18.03.10 13:01 Cjaeggi
 * Revised for coding rules, added configurated tag to separate values
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:51 Aklopfenstein
 * 
 * 1     29.08.08 16:41 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnLOVMLColumnListe
(
  @LOVName VARCHAR(100),
  @Codes VARCHAR(100),
  @Column VARCHAR(100),
  @LanguageCode INT
)
RETURNS VARCHAR(1000)
AS BEGIN
  DECLARE @Code VARCHAR(5);
  DECLARE @Text VARCHAR(100);
  DECLARE @Liste VARCHAR(1000);
  DECLARE @Idx INT;
  DECLARE @Separator VARCHAR(10);
  
  SET @Liste = '';
  SET @Idx = 1;
  SET @Separator = ISNULL(CONVERT(VARCHAR, dbo.fnXConfig('System\GUI\SpaltenListenSeparator', GETDATE())), ',');
  
  WHILE (@Idx <= LEN(@Codes))
  BEGIN
    -- nicht numerische Zeichen überspringen
    WHILE (@Idx <= LEN(@Codes) AND NOT SUBSTRING(@Codes, @Idx,1) BETWEEN '0' AND '9')
    BEGIN
      SET @Idx = @Idx + 1;
    END;
    
    -- Code aufbauen
    SET @Code = '';
    
    WHILE (@Idx <= LEN(@Codes) AND SUBSTRING(@Codes, @Idx,1) BETWEEN '0' AND '9')
    BEGIN
      SET @Code = @Code + SUBSTRING(@Codes, @Idx, 1);
      SET @Idx = @Idx + 1;
    END;
    
    IF (@Code <> '')
    BEGIN
      IF (@Column LIKE 'value1')
      BEGIN
        SELECT @Text = ISNULL(TXT.Text, LOV.Value1)
        FROM dbo.XLOVCode        LOV WITH (READUNCOMMITTED)
         LEFT JOIN dbo.XLangText TXT WITH (READUNCOMMITTED) ON TXT.TID = LOV.Value1TID 
                                                           AND TXT.LanguageCode = @LanguageCode
        WHERE LOVName = @LOVName 
          AND Code = CONVERT(INT, @Code)
        ORDER BY LOV.SortKey;
      END
      ELSE IF (@Column LIKE 'value2')
      BEGIN
        SELECT @Text = ISNULL(TXT.Text, LOV.Value2)
        FROM dbo.XLOVCode         LOV WITH (READUNCOMMITTED)
          LEFT JOIN dbo.XLangText TXT WITH (READUNCOMMITTED) ON TXT.TID = LOV.Value2TID 
                                                            AND TXT.LanguageCode = @LanguageCode
        WHERE LOVName = @LOVName 
          AND Code = CONVERT(INT, @Code)
        ORDER BY LOV.SortKey;
      END
      ELSE IF (@Column LIKE 'shortText')
      BEGIN
        SELECT @Text = ISNULL(TXT.Text, LOV.ShortText)
        FROM dbo.XLOVCode         LOV WITH (READUNCOMMITTED)
          LEFT JOIN dbo.XLangText TXT WITH (READUNCOMMITTED) ON TXT.TID = LOV.ShortTextTID 
                                                            AND TXT.LanguageCode = @LanguageCode
        WHERE LOVName = @LOVName 
          AND Code = CONVERT(INT, @Code)
        ORDER BY LOV.SortKey;
      END
      ELSE
      BEGIN
        SELECT @Text = ISNULL(TXT.Text, LOV.Text)
        FROM dbo.XLOVCode         LOV WITH (READUNCOMMITTED)
          LEFT JOIN dbo.XLangText TXT WITH (READUNCOMMITTED) ON TXT.TID = LOV.TextTID 
                                                            AND TXT.LanguageCode = @LanguageCode
        WHERE LOVName = @LOVName 
          AND Code = CONVERT(int, @Code)
        ORDER BY LOV.SortKey;
      END;
      
      IF (@Text IS NOT NULL)
      BEGIN
        IF (@Liste <> '')
        BEGIN
          SET @Liste = @Liste + @Separator;
        END;
        
        SET @Liste = @Liste + @Text;
      END;
    END; -- [IF (@Code <> '')]
  END; -- [WHILE]
  
  RETURN @Liste;
END;
GO