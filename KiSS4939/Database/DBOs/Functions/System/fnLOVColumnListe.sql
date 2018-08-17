SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnLOVColumnListe;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/fnLOVColumnListe.sql $
  $Author: Cjaeggi $
  $Modtime: 18.03.10 11:42 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: returns fnLovMLColumnListe with default language
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/System/fnLOVColumnListe.sql $
 * 
 * 3     18.03.10 11:42 Cjaeggi
 * Revised for coding rules
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:51 Aklopfenstein
=================================================================================================*/

CREATE FUNCTION dbo.fnLOVColumnListe
(
  @LOVName VARCHAR(100),
  @Codes VARCHAR(100),
  @Column VARCHAR(100)
)
RETURNS VARCHAR(1000)
AS BEGIN
  RETURN dbo.fnLOVMLColumnListe(@LOVName, @Codes, @Column, 1);
END;
GO