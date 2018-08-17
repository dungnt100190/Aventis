SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spGetFallMemberTyp
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spGetFallMemberTyp.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:25 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spGetFallMemberTyp.sql $
 * 
 * 2     25.06.09 11:38 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spGetFallMemberTyp
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:54
*/
CREATE PROCEDURE dbo.spGetFallMemberTyp
 (@BaPersonID int)
AS 

BEGIN
  DECLARE @Age int

  IF EXISTS (SELECT 1
             FROM dbo.BgFinanzplan_BaPerson  SPP WITH (READUNCOMMITTED) 
               INNER JOIN dbo.BgFinanzplan    SFP WITH (READUNCOMMITTED) ON SFP.BgFinanzplanID = SPP.BgFinanzplanID
             WHERE SPP.BaPersonID = @BaPersonID AND SPP.IstUnterstuetzt = 1
               AND GetDate() BETWEEN IsNull(SFP.DatumVon, SFP.GeplantVon) AND IsNull(SFP.DatumBis, SFP.GeplantBis)
  ) BEGIN
    SELECT @Age = dbo.fnGetAge(Geburtsdatum, GetDate()) FROM dbo.BaPerson WITH (READUNCOMMITTED) WHERE BaPersonID = @BaPersonID

     IF @Age >= 14 BEGIN
       PRINT 'Unterstuezt ueber 14 Jahre'
       SELECT 2
     END ELSE BEGIN
       PRINT 'Unterstuezt unter 14 Jahre'
       SELECT 3
     END
  END ELSE BEGIN
    SELECT 4 -- Nicht Unterstuetzt default
  END
END
GO