SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnWhGetUePersonen
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnWhGetUePersonen.sql $
  $Author: Ckaeser $
  $Modtime: 24.06.09 16:06 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnWhGetUePersonen.sql $
 * 
 * 2     25.06.09 8:17 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:06 Aklopfenstein
 * VSS First
=================================================================================================*/

/*
  KiSS 4.0
  --------
  DB-Object: fnWhGetUePersonen
  Branch   : KiSS4_BSS_Master
  BuildNr  : 2
  Datum    : 15.07.2008 13:11
*/
/*
===================================================================================================
Author		:	ckaeser
ALTER  date	:	15.07.2008
Description	:	Gibt alle PersonenID's die in irgendeinem Finanzplan der Leistung (optionaler Param)
                FallträgerPerson (Parameter) / UEPerson unterstützt wird zurück

===================================================================================================
History:
17.06.2008	:	ckaeser : neu erstellt
15.07.2008  :	ckaeser : Ticket 3197: einschränken auf Leistung
*/
CREATE FUNCTION dbo.fnWhGetUePersonen
 (@FTBaPersonID int, @UEBaPersonID int, @FaLeistungID int = null)
RETURNS TABLE
AS 

RETURN(
  -- Personen im UE zusammensuchen
  SELECT BaPersonID = @FTBaPersonID
  UNION
  SELECT BaPersonID  = @UEBaPersonID
  UNION 
  SELECT DISTINCT BFP.BaPersonID
  FROM dbo.FaLeistung                    LST WITH (READUNCOMMITTED) 
    INNER  JOIN dbo.BgFinanzplan          FPP WITH (READUNCOMMITTED) ON FPP.FaLeistungID = LST.FaLeistungID
    INNER  JOIN dbo.BgFinanzplan_BaPerson BFP WITH (READUNCOMMITTED) ON BFP.BgFinanzplanID = FPP.BgFinanzplanID
                                        AND IstUnterstuetzt = 1
  WHERE LST.BaPersonID   = @FTBaPersonID
    AND BFP.BaPersonID   = IsNull(@UEBaPersonID, BFP.BaPersonID)
    AND LST.FaLeistungID = IsNull(@FaLeistungID, LST.FaLeistungID)
)
GO