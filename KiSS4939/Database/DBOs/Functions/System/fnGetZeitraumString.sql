SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetZeitraumString;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/fnGetZeitraumString.sql $
  $Author: Cjaeggi $
  $Modtime: 17.03.10 13:33 $
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get the Zeitraum varchar value as used in queries
   @ZeitraumVon: The date from to use
   @ZeitraumBis: The date to to use
  -
  RETURNS: The proper formated Zeitraum varchar value as defined (e.g. '1.1.2009 - 31.1.2009')
  -
  TEST:    SELECT [dbo].[fnGetZeitraumString]('2008-01-01', '2008-01-31')
           SELECT [dbo].[fnGetZeitraumString]('2008-01-01', NULL)
           SELECT [dbo].[fnGetZeitraumString](NULL, '2008-01-31')
           SELECT [dbo].[fnGetZeitraumString](NULL, NULL)
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/System/fnGetZeitraumString.sql $
 * 
 * 4     17.03.10 13:33 Cjaeggi
 * Revised for coding rules
 * 
 * 3     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 2     5.02.09 16:59 Cjaeggi
 * Moved location
 * 
 * 1     5.02.09 14:58 Cjaeggi
 * New function
=================================================================================================*/

CREATE FUNCTION dbo.fnGetZeitraumString
(
  @ZeitraumVon DATETIME,
  @ZeitraumBis DATETIME
)
RETURNS VARCHAR(100)
AS BEGIN
  -----------------------------------------------------------------------------
  -- wellformat and return value as defined
  -----------------------------------------------------------------------------
  RETURN LTRIM(RTRIM(ISNULL(dbo.fnDateAsVarchar(@ZeitraumVon, 'dd.mm.yyyy'), '') + 
                     ' - ' + 
                     ISNULL(dbo.fnDateAsVarchar(@ZeitraumBis, 'dd.mm.yyyy'), '')));
END;
GO
