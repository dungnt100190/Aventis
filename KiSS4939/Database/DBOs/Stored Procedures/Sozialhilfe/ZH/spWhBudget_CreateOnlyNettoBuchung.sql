SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhBudget_CreateOnlyNettoBuchung
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spWhBudget_CreateOnlyNettoBuchung.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 11:53 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spWhBudget_CreateOnlyNettoBuchung.sql $
 * 
 * 3     11.12.09 11:58 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 17:58 Rstahel
 * Abgleich der Stored Procedures aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE PROCEDURE [dbo].[spWhBudget_CreateOnlyNettoBuchung]
(
  @BgPositionID int,
  @UserID       int
)
AS BEGIN

BEGIN try
BEGIN tran

DECLARE @BetragPosition money, @BetragBruttoGesendet money, @BetragNetto money, @BgBudgetID int, @BetragBruttoNeuErstellt money
--SET @BgPositionID = 383735

SELECT @BetragPosition = BetragBudget, @BgBudgetID = BgBudgetID
FROM dbo.vwBgPosition
WHERE BgPositionID = @BgPositionID


SELECT @BetragBruttoGesendet = SUM(KBP.Betrag)
FROM   dbo.KbBuchungBruttoPerson KBP WITH (READUNCOMMITTED) 
  INNER JOIN dbo.KbBuchungBrutto KBB WITH (READUNCOMMITTED) ON KBB.KbBuchungBruttoID = KBP.KbBuchungBruttoID
WHERE  BgPositionID = @BgPositionID
  AND KbBuchungStatusCode IN (3,6,10)

SELECT @BetragNetto = SUM(KBK.Betrag)
FROM   dbo.KbBuchungKostenart KBK WITH (READUNCOMMITTED) 
  INNER JOIN dbo.KbBuchung    KBU WITH (READUNCOMMITTED) ON KBU.KbBuchungID = KBK.KbBuchungID
WHERE  BgPositionID = @BgPositionID
  --AND KbBuchungStatusCode IN (3,6,10)

--SELECT @BetragPosition, @BetragBruttoGesendet, @BetragNetto

IF ABS(@BetragPosition) <> ABS(@BetragBruttoGesendet)
  RAISERROR('Betrag der gesendeten Bruttobelege entspricht nicht dem BetragBudget -> Handarbeit...',18,1)

IF ABS(@BetragPosition) = ABS(IsNull(@BetragNetto,0))
  RAISERROR('Nettobeleg ist vorhanden -> besteht hier wirklich ein Problem?',18,1)


DECLARE @tmp TABLE
(
  KbBuchungBruttoPersonID int
)

-- betroffene Buchungen merken
INSERT INTO @tmp
  SELECT KbBuchungBruttoPersonID
  FROM   dbo.KbBuchungBruttoPerson WITH (READUNCOMMITTED) 
  WHERE  BgPositionID = @BgPositionID

-- BgPositionID wegnehmen, damit auf grün gestellt werden kann
UPDATE KbBuchungBruttoPerson
  SET BgPositionID = NULL
  WHERE  BgPositionID = @BgPositionID

EXEC [spWhBudget_CreateKbBuchung] @BgBudgetID, @UserID, 0, 0, @BgPositionID

-- Sicherstellen, dass nicht andere Positionen gleichzeitig grüngestellt wurden
SELECT @BetragBruttoNeuErstellt = SUM(KBP.Betrag)
FROM   dbo.KbBuchungBruttoPerson KBP WITH (READUNCOMMITTED) 
  INNER JOIN dbo.KbBuchungBrutto KBB WITH (READUNCOMMITTED) ON KBB.KbBuchungBruttoID = KBP.KbBuchungBruttoID
WHERE  BgPositionID = @BgPositionID

IF ABS(@BetragPosition) <> ABS(IsNull(@BetragBruttoNeuErstellt,0)) BEGIN
/*
  UPDATE KbBuchungBruttoPerson
    SET BgPositionID = NULL
    WHERE  KbBuchungBruttoPersonID IN (SELECT KbBuchungBruttoPersonID FROM @tmp)
*/
  RAISERROR('Betrag des neuen Bruttobelegs stimmt nicht mit BetragBudget überein. Wahrscheinlich wurden mehrere Pos auf Grün gestellt?',18,1)
END

-- neue Bruttobuchungen (überzählige) löschen
DELETE FROM KBB
FROM dbo.KbBuchungBruttoPerson   KBP WITH (READUNCOMMITTED) 
  INNER JOIN dbo.KbBuchungBrutto KBB WITH (READUNCOMMITTED) ON KBB.KbBuchungBruttoID = KBP.KbBuchungBruttoID
WHERE BgPositionID = @BgPositionID 

-- BgPositionID wieder setzen
UPDATE KbBuchungBruttoPerson
  SET BgPositionID = @BgPositionID
  WHERE  KbBuchungBruttoPersonID IN (SELECT KbBuchungBruttoPersonID FROM @tmp)


commit
END try
BEGIN catch
  rollback
  DECLARE @msg varchar(1000)
  SET @msg = ERROR_MESSAGE()
  RAISERROR(@msg,18,1)
END catch
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
