 SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnCheckMod10Nummer
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnCheckMod10Nummer.sql $
  $Author: Spsota $
  $Modtime: 23.11.09 12:40 $
  $Revision: 2 $
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
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnCheckMod10Nummer.sql $
 * 
 * 2     23.11.09 12:40 Spsota
 * Fehler in Kommentaren korrigiert
 * 
 * 1     19.11.09 14:04 Mminder
 * #5505: Prüfung auf vorhandene & gültige ESR von FAMOZ übernommen
=================================================================================================*/

CREATE FUNCTION [dbo].[fnCheckMod10Nummer]
(
  @Nummer varchar(50)
)
 RETURNS bit
AS BEGIN

  -- Leerzeichen entfernen
  SET @Nummer = REPLACE(@Nummer,' ','')
  
  DECLARE @array TABLE
  (
    [Key]   int,
    [Value] int
  )
  INSERT INTO @array
  VALUES (0,0)
  INSERT INTO @array
  VALUES (1,9)
  INSERT INTO @array
  VALUES (2,4)
  INSERT INTO @array
  VALUES (3,6)
  INSERT INTO @array
  VALUES (4,8)
  INSERT INTO @array
  VALUES (5,2)
  INSERT INTO @array
  VALUES (6,7)
  INSERT INTO @array
  VALUES (7,1)
  INSERT INTO @array
  VALUES (8,3)
  INSERT INTO @array
  VALUES (9,5)
  INSERT INTO @array
  VALUES (10,0)

  DECLARE @Length int,
          @Temp int,
          @Counter int

  SET @Length = LEN(@Nummer)

  SET @Counter = 1
  SELECT @Temp = [Value]
  FROM @array
  WHERE [Key] = CAST(LEFT(@Nummer,1) as int)

  WHILE @Counter < @Length - 1 BEGIN
    SET @Counter = @Counter + 1

    SELECT @Temp = [Value]
    FROM @array
    WHERE [Key] = (CAST(SUBSTRING(@Nummer,@Counter,1) as int) + @Temp ) % 10
  END
  
  RETURN CASE WHEN CAST(SUBSTRING(@Nummer,@Length,1) as int) = (10 - @Temp) % 10 THEN 1 ELSE 0 END
END

