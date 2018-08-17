SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBFSGetAlbvBetrag;
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Gibt die Summe aller ALBV Zahlungen zurück
    @FaLeistungID: ID der Leistung
    @BaPersonID:   BaPersonID des Gläubigers
    @DatumVon:     Belegdatum von
    @DatumBis:     Belegdatum bis

  RETURNS: ALBV-Betrag

  TEST:SELECT * FROM dbo.fnBFSGetAlbvBetrag(1, 1, '20140101', '20141231') FCN;
=================================================================================================*/

CREATE FUNCTION dbo.fnBFSGetAlbvBetrag
(
  @FaLeistungID INT,
  @BaPersonID INT,
  @DatumVon DATETIME,
  @DatumBis DATETIME,
  @letzteVolleMonat BIT
)
RETURNS MONEY
AS
BEGIN

  DECLARE @AlbvBetrag MONEY;
  ;WITH BuchungCte AS
  (
    SELECT 
      AlbvBetrag = BKO.Betrag, 
      BUC.BelegNr, 
      BUC.BelegDatum, 
      BelegDatum_ausgleich = BUCA.BelegDatum, 
      BUC.IkPositionID
    FROM dbo.KbBuchung                       BUC  WITH (READUNCOMMITTED)
      INNER JOIN dbo.KbBuchungKostenart      BKO  WITH (READUNCOMMITTED) ON BKO.KbBuchungID = BUC.KbBuchungID
      INNER JOIN dbo.KbKostenstelle_BaPerson KSP  WITH (READUNCOMMITTED) ON KSP.KbKostenstelleID = BKO.KbKostenstelleID
      INNER JOIN dbo.KbOpAusgleich           OPA  WITH (READUNCOMMITTED) ON OPA.OpBuchungID = BUC.KbBuchungID
      INNER JOIN dbo.KbBuchung               BUCA WITH (READUNCOMMITTED) ON BUCA.KbBuchungID = OPA.AusgleichBuchungID
    WHERE BUC.BelegNr IS NOT NULL    -- only those with valid belegnr
      AND BUCA.BelegDatum BETWEEN @DatumVon AND @DatumBis
      AND BUC.FaLeistungID = @FaLeistungID  -- Buchungen aus Inkasso
      AND KSP.BaPersonID = ISNULL(@BaPersonID, KSP.BaPersonID)
      AND BKO.KontoNr IN (SELECT [Value]
                          FROM dbo.fnSplit(CONVERT(VARCHAR(MAX), dbo.fnXConfig('System\KliBu\Sozialhilferechnung\ALBVKontiBevorschussung', BUC.BelegDatum)), ';'))
  )

  SELECT @AlbvBetrag = SUM(AlbvBetrag)
  FROM BuchungCte CTE
  WHERE (@letzteVolleMonat = 0
    OR CTE.IkPositionID = (SELECT TOP 1 IPO.IkPositionID
                           FROM dbo.IkPosition IPO WITH (READUNCOMMITTED)
                             INNER JOIN BuchungCTE CTE1 ON CTE1.IkPositionID = IPO.IkPositionID
                             INNER JOIN dbo.IkForderungPosition FDP WITH (READUNCOMMITTED) ON FDP.IkPositionID = IPO.IkPositionID
                             INNER JOIN dbo.IkForderung FRD WITH (READUNCOMMITTED) ON FRD.IkForderungID = FDP.IkForderungID
                                                                                  AND FRD.IkForderungPeriodischCode = 1 -- Kinderalimente
                                                                                  AND FRD.ALBVBerechtigt = 1
                           WHERE dbo.fnLastDayOf(IPO.Datum) <= ISNULL(FRD.DatumGueltigBis, '99991231')
                           ORDER BY IPO.Datum DESC));

  RETURN @AlbvBetrag;
END;
GO