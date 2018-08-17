SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject BLOV
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/BLOV.sql $
  $Author: Ckaeser $
  $Modtime: 25.06.09 11:42 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/BLOV.sql $
 * 
 * 2     25.06.09 11:43 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/

/*
  KiSS 4.0
  --------
  DB-Object: BLOV
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:53
*/

CREATE PROCEDURE dbo.BLOV
 (@LOVSearchValue varchar(50))
AS

SELECT 
  LOVName, Code, Text, TextTID, KurzText, KurzTextTID, Filter, SortKey, BFSLOVCodeTS
FROM 
  dbo.BFSLOVCode WITH (READUNCOMMITTED) 
WHERE 
  LOVName like '%'+ @LOVSearchValue + '%'
ORDER BY 
  LOVName, SortKey

GO