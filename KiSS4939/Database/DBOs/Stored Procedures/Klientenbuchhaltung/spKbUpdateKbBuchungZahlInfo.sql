SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKbUpdateKbBuchungZahlInfo
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spKbUpdateKbBuchungZahlInfo.sql $
  $Author: Nweber $
  $Modtime: 17.12.09 10:52 $
  $Revision: 5 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spKbUpdateKbBuchungZahlInfo.sql $
 * 
 * 4     17.12.09 10:53 Nweber
 * #4644: Meldung für ungültige Banken angepasst
 * 
 * 3     28.11.09 11:15 Nweber
 * #4644: Fehlermeldung wenn die Bank eine neue ClearingNr hat.
 * 
 * 2     25.06.09 11:35 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spKbUpdateKbBuchungZahlInfo
  Branch   : KiSS4_BSS_Master
  BuildNr  : 2
  Datum    : 27.06.2008 14:46
*/
CREATE PROCEDURE dbo.spKbUpdateKbBuchungZahlInfo
 (@KbBuchungID  int,
  @UserID       int)
AS BEGIN

DECLARE @KreditorMehrZeilig VARCHAR(MAX),
        @ClearingNr VARCHAR(15),
        @ClearingNrNeu VARCHAR(15),
        @BaZahlungswegID INT

  -- #4644: Hat der Zalungsweg eine Bank mit einer neuen ClearingNr?
  SELECT TOP 1 
    @KreditorMehrZeilig = KRE.KreditorMehrZeilig,  
    @ClearingNr = BNK.ClearingNr, 
    @ClearingNrNeu = BNK.ClearingNrNeu, 
    @BaZahlungswegID = KRE.BaZahlungswegID
  FROM   dbo.KbBuchung          BUC WITH (READUNCOMMITTED) 
    INNER JOIN dbo.vwKreditor   KRE ON KRE.BaZahlungswegID = BUC.BaZahlungswegID
    LEFT  JOIN dbo.BaBank       BNK ON BNK.BaBankID = KRE.BaBankID
  WHERE  BUC.KbBuchungID = @KbBuchungID

  IF @ClearingNrNeu IS NOT NULL
  BEGIN
    DECLARE @Message VARCHAR(MAX)
    SET @Message = 'Der Zahlungsweg mit der ID %d hat eine Bank (ClearingNr %s) mit einer neuen ClearingNr.' + CHAR(13) + CHAR(10) +
                   'Kreditor:'+ CHAR(13) + CHAR(10) +
                   '%s'
    RAISERROR (@Message, 18, 1, @BaZahlungswegID, @ClearingNr, @KreditorMehrZeilig)
    RETURN -1
  END

  UPDATE BUC
  SET    KbBuchungStatusCode = 13, -- auf verbucht setzen
         PCKontoNr           = KRE.PostKontoNummer,
         BaBankID            = KRE.BaBankID,
         BankKontoNr         = KRE.BankKontoNummer,
         IBAN                = KRE.IBANNummer,
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
  FROM   dbo.KbBuchung          BUC WITH (READUNCOMMITTED) 
    INNER JOIN dbo.vwKreditor   KRE ON KRE.BaZahlungswegID = BUC.BaZahlungswegID
  WHERE  BUC.KbBuchungID = @KbBuchungID
END
GO