SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnReplaceWildcard
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/fnReplaceWildcard.sql $
  $Author: Cjaeggi $
  $Modtime: 18.03.10 16:39 $
  $Revision: 5 $
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
  WARNING: This object is shared in Visual SourceSafe, beware of changes!
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/System/fnReplaceWildcard.sql $
 * 
 * 5     18.03.10 16:40 Cjaeggi
 * Revised for coding rules
 * 
 * 4     19.02.10 10:24 Spsota
 * #5408 Share Function - Warning eingefügt
 * 
 * 3     11.12.09 11:01 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:08 Rstahel
 * Abgleich der Functions aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE FUNCTION dbo.fnReplaceWildcard
(
  @searchString VARCHAR(8000)
)
RETURNS VARCHAR(8000)
AS BEGIN
  RETURN REPLACE(REPLACE(REPLACE(@searchString, '*', '%'), '?', '_'), ' ', '%') + '%';
END;
GO
