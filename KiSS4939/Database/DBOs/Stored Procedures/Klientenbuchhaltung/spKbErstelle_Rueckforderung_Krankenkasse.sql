SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKbErstelle_Rueckforderung_Krankenkasse
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Stored Procedures/Klientenbuchhaltung/spKbErstelle_Rueckforderung_Krankenkasse.sql $
  $Author: Tabegglen $
  $Modtime: 18.08.10 18:26 $
  $Revision: 8 $
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
  $Log: /KiSS4/Database/DBOs/Stored Procedures/Klientenbuchhaltung/spKbErstelle_Rueckforderung_Krankenkasse.sql $
 * 
 * 8     18.08.10 18:41 Tabegglen
 * #3978 Korrektur: Wenn die Position-Tabelle mit LEFT JOIN verbunden
 * wurde, dann darf die Positionsart-Tabelle nicht mit INNER JOIN
 * verbunden werden.
 * 
 * 7     15.07.10 18:59 Cjaeggi
 * #4167: Fixed BaInstitution.InstitutionName after changes of table
 * 
 * 6     26.01.10 16:15 Lgreulich
 * Erweiterung wegen Positionsart 32130 (KVG EL)
 * 
 * 5     16.11.09 14:29 Lloreggia
 * Header Updated
 * 
 * 3     12.08.09 14:27 Ckaeser
 * #4932 Alter2Create Bereinigung DBO's
 * 
 * 2     25.06.09 11:35 Ckaeser
 * Alter2Create
 * 
 * 1     2.06.09 8:32 Ckaeser
 * 
 * 5     29.05.09 8:57 Ckaeser
 * Renaming
 * 
 * 4     29.05.09 8:55 Ckaeser
 * Renaming 
 * 
 * 3     29.05.09 8:53 Ckaeser
 * 
 * 2     28.05.09 16:52 Ckaeser
 * 
 * 1     28.05.09 15:19 Ckaeser
 * #4765 InitialVersion wie aus Maske
 * 
 * 1     13.09.08 17:07 ckaeser
 * VSS First
=================================================================================================*/

CREATE PROCEDURE dbo.spKbErstelle_Rueckforderung_Krankenkasse
 (@KbBuchungID int)
AS

DECLARE @BgPositionsartCode_Arztrechnung       int,
        @BgPositionsartCode_RueckforderungKK  int

SELECT @BgPositionsartCode_Arztrechnung       = 39020, -- das ist natürlich Mist so hartcodiert!
       @BgPositionsartCode_RueckforderungKK  = 31030  -- das ist natürlich Mist so hartcodiert!


DECLARE @BgBudgetID            int,
        @BaPersonID            int,
        @UserID                int,
        @KbBuchungKostenartID  int

DECLARE cKbBuchung CURSOR FAST_FORWARD FOR
  SELECT
    BPO.BgBudgetID,
    KBU.ErstelltUserID,
    KBK.KbBuchungKostenartID,
    KBK.BaPersonID
  FROM KbBuchung                  KBU
    INNER JOIN KbBuchungKostenart KBK ON KBU.KbBuchungID = KBK.KbBuchungID
    INNER JOIN BgPosition         BPO ON BPO.BgPositionID = KBK.BgPositionID 
    INNER JOIN BgPositionsart     POA ON POA.BgPositionsartID = BPO.BgPositionsartID
                                     AND POA.BgPositionsartCode = @BgPositionsartCode_Arztrechnung
    LEFT  JOIN BgPosition         EIN ON EIN.BgBudgetID                 = KBU.BgBudgetID
                                     AND EIN.BaPersonID                 = KBK.BaPersonID
                                     AND EIN.Betrag                     = KBK.Betrag
                                     AND IsNull(EIN.VerwPeriodeVon,-1)  = IsNull(KBK.VerwPeriodeVon,-1)
                                     AND IsNull(EIN.VerwPeriodeBis,-1)  = IsNull(KBK.VerwPeriodeBis,-1)       --check: bereits Forderung an KK vorhanden? 
                                     AND EIN.BgPositionID_AutoForderung = KBK.BgPositionID     -- #4765 check: bereits Forderung an KK 
    LEFT JOIN BgPositionsart      EIN_POA ON EIN_POA.BgPositionsartID   = EIN.BgPositionsartID
                                     AND EIN_POA.BgPositionsartCode     = @BgPositionsartCode_RueckforderungKK 
  WHERE KBU.KbBuchungID = @KbBuchungID 
    AND KBU.KbBuchungStatusCode = 6 /*ausgeglichen*/
    AND EIN.BgPositionID IS NULL 	-- Selektiere nur die Buchungen, die noch KEINE Rückforderungs-Position haben    

OPEN cKbBuchung
WHILE (1 = 1) BEGIN
  FETCH NEXT FROM cKbBuchung INTO @BgBudgetID, @UserID, @KbBuchungKostenartID, @BaPersonID
  IF @@FETCH_STATUS < 0 BREAK

  -- es wurde eine Arztrechnung ausbezahlt, das wollen wir sofort von der KK zurück!
  DECLARE @KKBaInstitutionID      int,
          @KKName                 varchar(200),
          @KKForderungKbBuchungID int,
          @KKBgPositionID         int

  -- KK bestimmen, an welche die Rechnung geht
  SELECT @KKBaInstitutionID = KVG.BaInstitutionID, @KKName = INS.[Name]
  FROM BgBudget               BUD
    INNER JOIN BgBudget       MAB ON MAB.BgFinanzplanID   = BUD.BgFinanzplanID AND MAB.MasterBudget = 1
    INNER JOIN BgPosition     KVG ON KVG.BgBudgetID       = MAB.BgBudgetID
                                 AND KVG.BaPersonID       = @BaPersonID -- KVG im Masterbudget
    INNER JOIN BgPositionsart POA ON POA.BgPositionsartID = KVG.BgPositionsartID
                                 AND (POA.BgPositionsartCode = 32020 
                                      OR POA.BgPositionsartCode BETWEEN 32121 AND 32130 /*KVG*/)
    LEFT  JOIN BaInstitution  INS ON INS.BaInstitutionID  = KVG.BaInstitutionID
  WHERE BUD.BgBudgetID = @BgBudgetID

  -- Liste mit Ids der Positionen, die noch erstellt werden.
  DECLARE @BgPositionsIds TABLE
  (
    [ID] [int] IDENTITY(1,1) NOT NULL,
    BgPositionId INT  
  );
  
  DECLARE @BgPositionCount INT;
  
  --Budgetposition erstellen
  INSERT INTO BgPosition(BgBudgetID, BgKategorieCode, BaPersonID, BaInstitutionID, BgPositionsartID, Buchungstext, Betrag, 
                         VerwPeriodeVon, VerwPeriodeBis, FaelligAm, VerwaltungSD, BgBewilligungStatusCode, ErstelltDatum, ErstelltUserID,
                         BgPositionID_AutoForderung)
  OUTPUT  INSERTED.BgPositionId INTO @BgPositionsIds (BgPositionId)     -- ID's speichern.                 
  SELECT @BgBudgetID, 1 /*Einnahmen*/, KBK.BaPersonID, @KKBaInstitutionID, POA.BgPositionsartID,
    Buchungstext =  CONVERT(VARCHAR(100), IsNull(@KKName +': ','') + IsNull(KBK.Buchungstext, 'Arztrechnung')),
    KBK.Betrag, KBK.VerwPeriodeVon, KBK.VerwPeriodeBis, KBU.ValutaDatum, 1 /*abgetreten*/, 1, GETDATE(), @UserID,
    KBK.BgPositionID
  FROM KbBuchungKostenart     KBK
    INNER JOIN KbBuchung      KBU ON KBU.KbBuchungID   = KBK.KbBuchungID
    INNER JOIN BgBudget       BDG ON BDG.BgBudgetID = @BgBudgetID
    INNER JOIN BgPositionsart POA ON POA.BgPositionsartCode = @BgPositionsartCode_RueckforderungKK     -- die RueckforderungKK-Positionsart herausfinden, die während dieses
                                 AND ISNULL(POA.DatumVon, '1900-01-01') <= dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1) -- Monatsbudgets aktiv ist.
                                 AND ISNULL(POA.DatumBis, '9999-12-31') >= dbo.fnLastDayOf(dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1))
    
                                 
  WHERE KBK.KbBuchungID = @KbBuchungID
  SET @BgPositionCount = @@ROWCOUNT;


  -- Iteration über alle erstellten Positionen
  DECLARE @Iterator INT;
  SET @Iterator = 1;
  
  DECLARE @BgPositionId INT;
  
  WHILE (@Iterator <= @BgPositionCount)
  BEGIN
	 	 SELECT @BgPositionId = BgPositionId	 FROM @BgPositionsIds	 WHERE ID = @Iterator;	-- Budgetposition auf grün stellen    
	EXECUTE spWhBudget_CreateKbBuchung @BgBudgetID, @UserID, 0, 0, @BgPositionId;

	SET @Iterator = @Iterator + 1; -- Iterator inkrementieren.

  END




  /* DEBUG HELPER
  select 'KKPosition',*
  from BgPosition
  where bgpositionid = @KKBgPositionID

  select 'KK-KbBuchungKostenart',*
  from KbBuchungKostenart
  where bgpositionid = @KKBgPositionID
  */
END

DEALLOCATE cKbBuchung


GO
