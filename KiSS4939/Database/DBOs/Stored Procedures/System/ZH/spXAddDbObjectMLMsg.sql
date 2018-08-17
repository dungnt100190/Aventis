SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spXAddDbObjectMLMsg
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spXAddDbObjectMLMsg.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:47 $
  $Revision: 3 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spXAddDbObjectMLMsg.sql $
 * 
 * 3     11.12.09 12:51 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 17:59 Rstahel
 * Abgleich der Stored Procedures aus KISS4_MASTER_ZH
=================================================================================================*/
-------------------------------------------------------------------------------
-- INFO: Run this stored procedure to insert all multilanguage texts for 
--       database objects into database and let it translate in KiSS
-- 
-- Run:  EXEC spXAddDbObjectMLMsg
--
-- Test: SELECT dbo.fnXDbObjectMLMsg('fnGetPersonTitle', 'Telefon', 1)
-------------------------------------------------------------------------------
CREATE PROCEDURE dbo.spXAddDbObjectMLMsg
AS BEGIN
  -----------------------------------------------------------------------------
  -- Functions:
  -----------------------------------------------------------------------------
  -- fnXKurzMonat
  EXEC spXDbObjectMLMsg 'fnXKurzMonat', 'Januar', 'Jan'
  EXEC spXDbObjectMLMsg 'fnXKurzMonat', 'Februar', 'Feb'
  EXEC spXDbObjectMLMsg 'fnXKurzMonat', 'Maerz', 'Mrz'
  EXEC spXDbObjectMLMsg 'fnXKurzMonat', 'April', 'Apr'
  EXEC spXDbObjectMLMsg 'fnXKurzMonat', 'Mai', 'Mai'
  EXEC spXDbObjectMLMsg 'fnXKurzMonat', 'Juni', 'Jun'
  EXEC spXDbObjectMLMsg 'fnXKurzMonat', 'Juli', 'Jul'
  EXEC spXDbObjectMLMsg 'fnXKurzMonat', 'August', 'Aug'
  EXEC spXDbObjectMLMsg 'fnXKurzMonat', 'September', 'Sep'
  EXEC spXDbObjectMLMsg 'fnXKurzMonat', 'Oktober', 'Okt'
  EXEC spXDbObjectMLMsg 'fnXKurzMonat', 'November', 'Nov'
  EXEC spXDbObjectMLMsg 'fnXKurzMonat', 'Dezember', 'Dez'

  -----------------------------------------------------------------------------
  -- Stored Procedures:
  -----------------------------------------------------------------------------

  -----------------------------------------------------------------------------
  -- ClassNames:
  -----------------------------------------------------------------------------

  -----------------------------------------------------------------------------
  -- Done
  -----------------------------------------------------------------------------
  SELECT Info = 'Inserted dbo multilanguage texts into database.'
  RETURN 1
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
