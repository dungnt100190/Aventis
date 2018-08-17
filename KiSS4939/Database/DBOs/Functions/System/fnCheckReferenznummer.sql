 SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnCheckReferenznummer
GO

/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnCheckReferenznummer.sql $
  $Author: Spsota $
  $Modtime: 23.11.09 12:39 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnCheckReferenznummer.sql $
 * 
 * 2     23.11.09 12:40 Spsota
 * Fehler in Kommentaren korrigiert
 * 
 * 1     19.11.09 14:04 Mminder
 * #5505: Prüfung auf vorhandene & gültige ESR von FAMOZ übernommen
=================================================================================================*/

CREATE FUNCTION [dbo].[fnCheckReferenznummer]
(
  @Nummer varchar(50)
)
RETURNS bit
AS BEGIN
  DECLARE @Length int
  SET @Length = LEN(@Nummer)

  IF @Length IN (15,26)
    RETURN 1
  ELSE IF @Length NOT IN (16,27)
    RETURN 0
  -- Nur 0er
  IF cast(SUBSTRING(@Nummer,1,17) as bigint) = 0 AND cast(SUBSTRING(@Nummer,18,17) as bigint) = 0 AND cast(SUBSTRING(@Nummer,35,17) as bigint) = 0
    RETURN 0

  RETURN dbo.[fnCheckMod10Nummer](@Nummer)
END

