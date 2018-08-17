SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhBudget_UpdateKbBuchungZahlInfo
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spWhBudget_UpdateKbBuchungZahlInfo.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:12 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spWhBudget_UpdateKbBuchungZahlInfo.sql $
 * 
 * 2     25.06.09 8:47 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spWhBudget_UpdateKbBuchungZahlInfo
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:55
*/
CREATE PROCEDURE dbo.spWhBudget_UpdateKbBuchungZahlInfo
 (@BgPositionID int,
  @UserID       int)
AS BEGIN

  UPDATE BUC
  SET    BaZahlungswegID     = AUP.BaZahlungswegID,
         PCKontoNr           = KRE.PostKontoNummer,
         BaBankID            = KRE.BaBankID,
         BankKontoNr         = KRE.BankKontoNummer,
         IBAN                = KRE.IBANNummer,
         ReferenzNummer      = AUP.ReferenzNummer,
         BeguenstigtName     = KRE.BeguenstigtName,
         BeguenstigtName2    = KRE.BeguenstigtName2,
         BeguenstigtStrasse  = KRE.BeguenstigtStrasse,
         BeguenstigtPLZ      = KRE.BeguenstigtPLZ,
         BeguenstigtOrt      = KRE.BeguenstigtOrt,
         BankName            = KRE.BankName,
         BankStrasse         = KRE.BankStrasse,
         BankPLZ             = KRE.BankPLZ,
         BankOrt             = KRE.BankOrt,
         BankBCN             = KRE.BankClearingNr,
         MutiertUserID       = @UserID,
         MutiertDatum        = GetDate()
  FROM   dbo.BgAuszahlungPerson            AUP WITH (READUNCOMMITTED) 
         INNER JOIN dbo.BgPosition         BPO WITH (READUNCOMMITTED) ON BPO.BgPositionID = AUP.BgPositionID
         INNER JOIN dbo.KbBuchungKostenart BUK WITH (READUNCOMMITTED) ON BUK.BgPositionID = BPO.BgPositionID AND BUK.BaPersonID = IsNull(AUP.BaPersonID, BUK.BaPersonID)
         INNER JOIN dbo.KbBuchung          BUC WITH (READUNCOMMITTED) ON BUC.KbBuchungID = BUK.KbBuchungID
         INNER JOIN dbo.vwKreditor         KRE ON KRE.BaZahlungswegID = AUP.BaZahlungswegID
  WHERE  BPO.BgPositionID = @BgPositionID
END
GO