SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhBudget_DeleteKbBuchung
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spWhBudget_DeleteKbBuchung.sql $
  $Author: Mminder $
  $Modtime: 15.02.10 14:32 $
  $Revision: 7 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spWhBudget_DeleteKbBuchung.sql $
 * 
 * 7     15.02.10 14:36 Mminder
 * #5645: Falls zu einer Position bereits Belege an PSCD gesendet wurden,
 * darf diese nicht mehr gelöscht werden
 * 
 * 6     11.01.10 11:25 Mmarghitola
 * #5645: WITH  (READUNCOMMITTED) entfernt
 * 
 * 5     11.12.09 11:58 Lloreggia
 * Header aktualisiert
 * 
 * 4     1.04.09 9:24 Mminder
 * ##3990: Ausgedruckte Barbelege können nicht mehr gelöscht werden
 * 
 * 3     10.03.09 18:54 Mweber
 * Erweiterung auf Sammelbelege (Haupt- und Detailpositionen)
 * Der Input-Parameter @BgPositionID muss die Hauptposition sein
 * 
 * 2     10.03.09 17:59 Rstahel
 * Abgleich der Stored Procedures aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE PROCEDURE [dbo].[spWhBudget_DeleteKbBuchung]
(
  @BgPositionID int
)
AS BEGIN

  -- check: sind in die bestehenden Belegen Budgetposition noch andere Positionen verflechtet?
  -- Ausnahme: Sammelbelege ohne GBL-Einzelzahlungen
  DECLARE @Count int,
          @msg   varchar(1000)

  SELECT @Count = COUNT(*)
  FROM dbo.KbBuchungKostenart         KBK
    INNER JOIN dbo.KbBuchungKostenart CMP ON CMP.KbBuchungID = KBK.KbBuchungID AND CMP.BgPositionID <> KBK.BgPositionID
    INNER JOIN dbo.BgPosition         BPO ON BPO.BgPositionID = CMP.BgPositionID AND
                                          (IsNull(BPO.BgPositionID_Parent,0) <> @BgPositionID OR
                                          (BPO.BgKategorieCode = 101 AND BPO.BgSpezkontoID IS NULL))
  WHERE KBK.BgPositionID = @BgPositionID

  IF @Count > 0 BEGIN
    SET @msg = 'In die Nettobelege dieser Budgetposition sind weitere Positionen involviert, deshalb kann sie nicht separat auf grau gestellt werden'
    RAISERROR(@msg, 18, 1)
    RETURN
  END

  SELECT @Count = COUNT(*)
  FROM dbo.KbBuchungBruttoPerson         KBP
    INNER JOIN dbo.KbBuchungBruttoPerson CMP ON CMP.KbBuchungBruttoID = KBP.KbBuchungBruttoID AND CMP.BgPositionID <> KBP.BgPositionID
    INNER JOIN dbo.BgPosition            BPO ON BPO.BgPositionID = CMP.BgPositionID AND
                                                (IsNull(BPO.BgPositionID_Parent,0) <> @BgPositionID OR
                                                (BPO.BgKategorieCode = 101 AND BPO.BgSpezkontoID IS NULL))
  WHERE KBP.BgPositionID = @BgPositionID

  IF @Count > 0 BEGIN
    SET @msg = 'In die Bruttobelege dieser Budgetposition sind weitere Positionen involviert, deshalb kann sie nicht separat auf grau gestellt werden'
    RAISERROR(@msg, 18, 1)
    RETURN
  END

  -- check: wurde ein Barbeleg, in den diese Position involviert ist, bereits ausgedruckt?
  SELECT @Count = COUNT(*)
  FROM dbo.KbBuchungKostenart KBK
    INNER JOIN dbo.BgPosition BPO ON BPO.BgPositionID = KBK.BgPositionID
    INNER JOIN dbo.KbBuchung  KBU ON KBU.KbBuchungID  = KBK.KbBuchungID AND KBU.BarbelegDatum IS NOT NULL
  WHERE KBK.BgPositionID = @BgPositionID

  IF @Count > 0 BEGIN
    SET @msg = 'Ein Barbeleg dieser Budgetposition wurde bereits ausgedruckt, deshalb kann der Beleg nicht gelöscht werden'
    RAISERROR(@msg, 18, 1)
    RETURN
  END

  -- check: wurde ein Beleg (Brutto oder Netto), in den diese Position involviert ist, bereits an PSCD übertragen?
  SELECT @Count = COUNT(*)
  FROM dbo.KbBuchungKostenart KBK
    INNER JOIN dbo.KbBuchung  KBU ON KBU.KbBuchungID = KBK.KbBuchungID
  WHERE KBK.BgPositionID = @BgPositionID AND KBU.TransferDatum IS NOT NULL

  SELECT @Count = @Count + COUNT(*)
  FROM dbo.KbBuchungBruttoPerson   KBP
    INNER JOIN dbo.KbBuchungBrutto KBB ON KBB.KbBuchungBruttoID = KBP.KbBuchungBruttoID
  WHERE KBP.BgPositionID = @BgPositionID AND KBB.TransferDatum IS NOT NULL

  IF @Count > 0 BEGIN
    SET @msg = 'Zu dieser Position wurden bereits Belege an PSCD übertragen, diese dürfen nicht gelöscht werden'
    RAISERROR(@msg, 18, 1)
    RETURN
  END

  DECLARE @KbBuchungIDList TABLE (KbBuchungID int)

  INSERT @KbBuchungIDList
  SELECT DISTINCT BUK.KbBuchungID
  FROM   dbo.BgPosition               BPO
    INNER JOIN dbo.KbBuchungKostenart BUK ON BUK.BgPositionID = BPO.BgPositionID
    INNER JOIN dbo.KbBuchung          BUC ON BUC.KbBuchungID = BUK.KbBuchungID AND
                                             BUC.KbBuchungStatusCode IN (2,5) /*freigegeben, fehlerhaft*/
  WHERE  BPO.BgPositionID = @BgPositionID OR
         BPO.BgPositionID_Parent = @BgPositionID

  DELETE dbo.KbBuchungKostenart
  WHERE KbBuchungID IN (SELECT KbBuchungID FROM @KbBuchungIDList)

  DELETE dbo.KbBuchung
  WHERE  KbBuchungID IN (SELECT KbBuchungID FROM @KbBuchungIDList)

  DECLARE @KbBuchungBruttoIDList TABLE (KbBuchungBruttoID int)

  INSERT @KbBuchungBruttoIDList
  SELECT DISTINCT BUP.KbBuchungBruttoID
  FROM   dbo.BgPosition                  BPO
    INNER JOIN dbo.KbBuchungBruttoPerson BUP ON BUP.BgPositionID = BPO.BgPositionID
    INNER JOIN dbo.KbBuchungBrutto       BUC ON BUC.KbBuchungBruttoID = BUP.KbBuchungBruttoID AND
                                                BUC.KbBuchungStatusCode IN (2,5) /*freigegeben, fehlerhaft*/
  WHERE  BPO.BgPositionID = @BgPositionID OR
         BPO.BgPositionID_Parent = @BgPositionID

  DELETE dbo.KbBuchungBruttoPerson
  WHERE  KbBuchungBruttoID IN (SELECT KbBuchungBruttoID FROM @KbBuchungBruttoIDList)

  DELETE dbo.KbBuchungBrutto
  WHERE  KbBuchungBruttoID IN (SELECT KbBuchungBruttoID FROM @KbBuchungBruttoIDList)
END

