SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnBFSGetZahlungDatum
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @BaPersonID: Fallträger
    @Jahr: Auswertungsjahr
    @Monat: Monat

  -
  RETURNS: 
  -
  TEST:    
=================================================================================================*/
CREATE FUNCTION dbo.fnBFSGetZahlungDatum
(
  @FaLeistungID  INT,
  @Jahr          INT,
  @BaPersonID    INT = NULL
)
RETURNS @Auszahlung TABLE
(
  ErsteAuszahlung   datetime NULL,
  LetzteAuszahlung  datetime NULL
)
AS BEGIN
  DECLARE @ModulID INT;
  DECLARE @FaProzessCode INT;

  SELECT
    @ModulID = ModulID,
    @FaProzessCode = FaProzessCode
  FROM dbo.FaLeistung WITH (READUNCOMMITTED)
  WHERE FaLeistungID = @FaLeistungID;
  
  IF (@ModulID = 3)
  BEGIN
    INSERT INTO @Auszahlung
      SELECT
        ErsteAuszahlung  = MIN(BUC.BelegDatum),
        LetzteAuszahlung = CASE WHEN YEAR(MAX(BUC.BelegDatum)) = @Jahr AND MONTH(MAX(BUC.BelegDatum)) = 12 THEN NULL ELSE MAX(BUC.BelegDatum) END
      FROM dbo.KbBuchung             BUC WITH (READUNCOMMITTED) 
        INNER JOIN dbo.BgBudget      BDG WITH (READUNCOMMITTED)  ON BDG.BgBudgetID = BUC.BgBudgetID
        INNER JOIN dbo.BgFinanzplan  BFP WITH (READUNCOMMITTED)  ON BFP.BgFinanzPlanID = BDG.BgFinanzPlanID
      WHERE BUC.BelegNr IS NOT NULL    -- only those with valid belegnr
        AND BUC.BelegDatum <= dbo.fnDateSerial(@Jahr, 12, 31)
        AND BFP.FaLeistungID = @FaLeistungID; -- Buchung aus Sozialhilfe 
  END
  ELSE IF (@ModulID = 4 AND @FaProzessCode = 401)
  BEGIN
    DECLARE @KontoNrALBV VARCHAR(20);
    SET @KontoNrALBV = CONVERT(VARCHAR(20), dbo.fnXConfig('System\KliBu\Sozialhilferechnung\ALBVKontiBevorschussung', dbo.fnDateSerial(@Jahr, 12, 31)));

    INSERT INTO @Auszahlung
      SELECT
        ErsteAuszahlung  = MIN(BUC.BelegDatum),
        LetzteAuszahlung = MAX(BUC.BelegDatum)
      FROM dbo.KbBuchung                  BUC WITH (READUNCOMMITTED)
        INNER JOIN dbo.KbBuchungKostenart KOA WITH (READUNCOMMITTED) ON KOA.KbBuchungID = BUC.KbBuchungID
        INNER JOIN dbo.KbKostenstelle_BaPerson KST WITH (READUNCOMMITTED) ON KST.KbKostenstelleID = KOA.KbKostenstelleID
      WHERE BUC.BelegNr IS NOT NULL    -- only those with valid belegnr
        AND BUC.BelegDatum <= dbo.fnDateSerial(@Jahr, 12, 31)
        AND BUC.FaLeistungID = @FaLeistungID  -- Buchungen aus Inkasso
        AND KOA.BgKostenartID IN (SELECT dbo.fnBgGetKostenartIDByKontoNr([Value])
                                  FROM dbo.fnSplit(@KontoNrALBV, ';'))
        AND KST.BaPersonID = ISNULL(@BaPersonID, KST.BaPersonID);
  END;
  
  RETURN;
END;
GO