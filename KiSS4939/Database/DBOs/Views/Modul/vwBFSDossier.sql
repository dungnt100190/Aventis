SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwBFSDossier
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Views/vwBFSDossier.sql $
  $Author: Ckaeser $
  $Modtime: 25.06.09 12:54 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Views/vwBFSDossier.sql $
 * 
 * 2     25.06.09 13:07 Ckaeser
 * Alter2Create
 * 
 * 1     11.09.08 14:52 Aklopfenstein
 * VSS First
=================================================================================================*/

/*
  KiSS 4.0
  --------
  DB-Object: vwBFSDossier
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.07.2008 15:09
*/
CREATE VIEW dbo.vwBFSDossier
AS

--SELECT 
--  FaLeistungID,    
--  FalltraegerID = LEI.BaPersonID 
--FROM FaLeistung	LEI
SELECT 
  FaLeistungID,    
  BaPersonID as 'FalltraegerID'
FROM dbo.FaLeistung	LEI WITH (READUNCOMMITTED) 

GO

