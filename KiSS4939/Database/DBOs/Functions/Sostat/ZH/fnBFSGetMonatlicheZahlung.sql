SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBFSGetMonatlicheZahlung;
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    SELECT * FROM dbo.fnBFSGetMonatlicheZahlung(...);
=================================================================================================*/

CREATE FUNCTION dbo.fnBFSGetMonatlicheZahlung
(
  @AntragstellerID      INT,
  @BFSLeistungsartCode  INT,
  @BaPersonID           INT,
  @Jahr                 INT,
  @Monat                INT,
  @summeJahr            BIT,
  @DatumVon             DATETIME,
  @DatumBis             DATETIME
)
RETURNS @ResultTable TABLE 
(
  KbBuchungKostenartID INT,
  Betrag               MONEY,
  LA                   INT,
  BFSVariable          VARCHAR(10)
)
AS 
BEGIN
  DECLARE @vonDatum DATETIME;
  DECLARE @bisDatum DATETIME;
  DECLARE @FaProzessCode INT;
  
  INSERT @ResultTable 
    SELECT null, 0, 0, '';    -- Dummy-Eintrag, damit die Summe der Tabelle sicher 0 gibt und nicht NULL


  IF (ISNULL(@summeJahr,0) = 1)
  BEGIN
    SET @vonDatum = dbo.fnDateSerial (@Jahr, 1, 1);
    SET @bisDatum = dbo.fnDateSerial (@Jahr, 12, 31);
    -- Begrenzen auf Datumsbereich des Dossiers
    IF @vonDatum < dbo.fnFirstDayOf(@DatumVon)
    BEGIN
      SET @vonDatum = dbo.fnFirstDayOf(@DatumVon);
    END;

    IF @bisDatum > dbo.fnLastDayOf(@DatumBis)
    BEGIN
      SET @bisDatum = dbo.fnLastDayOf(@DatumBis);
    END;
  END
  ELSE 
  BEGIN
    SET @vonDatum = dbo.fnDateSerial (@Jahr, @Monat, 1);
    SET @bisDatum = dbo.fnLastDayOf (@vonDatum);

    IF NOT @vonDatum BETWEEN dbo.fnFirstDayOf(@DatumVon) AND dbo.fnLastDayOf(@DatumBis)
    BEGIN
      RETURN;  -- Auswertemonat liegt ausserhalb des Datumbereichs des Dossiers
    END;
  END;
  
  SET @FaProzessCode = dbo.fnBFSLeistungsartTOProzess(@BFSLeistungsartCode);
  
  INSERT @ResultTable
    SELECT BUK.KbBuchungKostenartID,
           BUK.Betrag, 
           KOA.KontoNr,
           MAX(BPA.VarName)
    FROM dbo.KbBuchung                  BUC  WITH(READUNCOMMITTED)
      INNER JOIN dbo.KbBuchungKostenart BUK  WITH(READUNCOMMITTED) ON BUK.KbBuchungID = BUC.KbBuchungID
      INNER JOIN dbo.BgKostenart        KOA  WITH(READUNCOMMITTED) ON KOA.BgKostenartID = BUK.BgKostenartID
      INNER JOIN dbo.BgPositionsart     BPA  WITH(READUNCOMMITTED) ON BPA.BgKostenartID = KOA.BgKostenartID
      LEFT  JOIN dbo.KbOpAusgleich      KOP  WITH(READUNCOMMITTED) ON KOP.OpBuchungID = BUC.KbBuchungId
      INNER JOIN dbo.KbBuchung          BUC2 WITH(READUNCOMMITTED) ON KOP.AusgleichBuchungID = BUC2.KbBuchungId
      INNER JOIN dbo.FaLeistung         FAL  WITH(READUNCOMMITTED) ON FAL.FaLeistungID = BUC.FALeistungID
                                                                  AND FAL.FaProzessCode = @FaProzessCode
      INNER JOIN dbo.KbKonto            KTO  WITH(READUNCOMMITTED) ON KTO.KbPeriodeID = BUC.KbPeriodeID
                                                                  AND KTO.KontoNr = BUC.HabenKtoNr
                                                                  AND KTO.KbKontoartCodes like '%30%' -- Kreditorkto, nur Auszahlungen
      WHERE FAL.BaPersonID = @AntragstellerID
        AND ISNULL(BUC2.Belegdatum, BUC.Barbelegdatum) BETWEEN @vonDatum AND @bisDatum
        AND Buc.KbBuchungStatusCode NOT IN (8, 9)                -- Storno, Rückläufer
        AND BUK.BaPersonID = ISNULL(@BaPersonID, BUK.BaPersonID)
      GROUP BY BUK.KbBuchungKostenartID, BUK.Betrag, KOA.KontoNr
      HAVING MAX(BPA.VarName) IS NOT NULL; -- nur via LA-Mapping Tool zugeteilte BFS Variablen berücksichtigen
  RETURN;
END;
