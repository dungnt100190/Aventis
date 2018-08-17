SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhBudget_UpdateKbBuchungZahlInfo
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spWhBudget_UpdateKbBuchungZahlInfo.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 11:55 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spWhBudget_UpdateKbBuchungZahlInfo.sql $
 * 
 * 3     11.12.09 11:58 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 17:59 Rstahel
 * Abgleich der Stored Procedures aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE PROCEDURE [dbo].[spWhBudget_UpdateKbBuchungZahlInfo]
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
         BeguenstigtName     = CASE WHEN KRE.BaPersonID IS NOT NULL THEN KRE.PersonNameVorname   ELSE KRE.InstitutionName          END, 
         BeguenstigtName2    = CASE WHEN KRE.BaPersonID IS NOT NULL THEN KRE.PersonAdressZusatz  ELSE KRE.InstitutionAdressZusatz  END, 
         BeguenstigtStrasse  = CASE WHEN KRE.BaPersonID IS NOT NULL THEN KRE.PersonStrasseHausNr ELSE KRE.InstitutionStrasseHausNr END, 
         BeguenstigtPLZ      = CASE WHEN KRE.BaPersonID IS NOT NULL THEN KRE.PersonPLZ           ELSE KRE.InstitutionPLZ           END, 
         BeguenstigtOrt      = CASE WHEN KRE.BaPersonID IS NOT NULL THEN KRE.PersonOrt           ELSE KRE.InstitutionOrt           END,
         BankName            = KRE.BankName, 
         BankStrasse         = KRE.BankStrasse, 
         BankPLZ             = KRE.BankPLZ, 
         BankOrt             = KRE.BankOrt, 
         BankBCN             = KRE.BankClearingNr,
         PscdZahlwegArt      = XLC.Value1,
         MutiertUserID       = @UserID,
         MutiertDatum        = GetDate()
  FROM   dbo.BgAuszahlungPerson AUP WITH (READUNCOMMITTED) 
         INNER JOIN dbo.BgPosition         BPO WITH (READUNCOMMITTED) ON BPO.BgPositionID = AUP.BgPositionID
         INNER JOIN dbo.KbBuchungKostenart BUK WITH (READUNCOMMITTED) ON BUK.BgPositionID = BPO.BgPositionID
         INNER JOIN dbo.KbBuchung          BUC WITH (READUNCOMMITTED) ON BUC.KbBuchungID = BUK.KbBuchungID
         INNER JOIN dbo.vwKreditor         KRE ON KRE.BaZahlungswegID = AUP.BaZahlungswegID
         LEFT  JOIN dbo.XLOVCode           XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'BgEinzahlungsschein' AND XLC.Code = KRE.EinzahlungsscheinCode
  WHERE  BPO.BgPositionID = @BgPositionID
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
