SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
EXECUTE dbo.spDropObject fnShGetKuerzungBetrag
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnShGetKuerzungBetrag.sql $
  $Author: Nweber $
  $Modtime: 27.11.09 7:43 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnShGetKuerzungBetrag.sql $
 * 
 * 2     27.11.09 7:46 Nweber
 * VSS comment contained invalid char: NUL (null) with ASCII value 0
 * 
 * 1     18.11.09 13:32 Mminder
 * #4915: Kürzungen eingeführt
 * 
=================================================================================================*/

CREATE FUNCTION [dbo].[fnShGetKuerzungBetrag]
(
  @BgFinanzplanID  int,
  @AnteilGBL       money
)
RETURNS money
AS BEGIN
  RETURN FLOOR((dbo.fnShGetBetragGBL(@BgFinanzplanID, 1, 0) * @AnteilGBL / 100.0) * 20.0) / 20.0
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
 