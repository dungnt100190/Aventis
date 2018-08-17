SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnKbGetRelevanteBuchungen;
GO
/*===============================================================================================
  $Revision: 10 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get all relevant entries the Buchhalter cares about
    @KbPeriodeID:    The id within KbPeriode specified
    @DatumVon   :    BelegDatum has to be >= (KbPeriode.PeriodeVon if null)
    @Datumbis   :    BelegDatum has to be <= (KbPeriode.PeriodeBis if null)
    @CheckExists:    0 Return all relevant entries
                     1 Return top 1 entry!
  -
  RETURNS: Table containing all relevant data used for 'Buchhalter'
=================================================================================================
  TEST:    SELECT * FROM dbo.fnKbGetRelevanteBuchungen(6, '2008-12-31', NULL, NULL, NULL);
=================================================================================================*/

CREATE FUNCTION dbo.fnKbGetRelevanteBuchungen
(
  @KbPeriodeID         INT, 
  @DatumVon            DATETIME,
  @DatumBis            DATETIME,
  @CheckExists         BIT = 0,
  @IncludeGemeindeCode BIT = 1
)
RETURNS @Result TABLE
(
  KbBuchungKostenartID INT NULL,
  KbBuchungID          INT NOT NULL,
  SollKtoNr            VARCHAR(10) NOT NULL,
  HabenKtoNr           VARCHAR(10) NOT NULL,
  Betrag               MONEY NOT NULL,
  Ausgabe              BIT NOT NULL,
  BelegDatum           DATETIME NOT NULL,
  GemeindeCode         INT NULL
)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@KbPeriodeID IS NULL)
  BEGIN
    -- invalid data
    RETURN;
  END;
  
  -----------------------------------------------------------------------------
  -- Prerequisites
  -----------------------------------------------------------------------------
  IF (@DatumVon IS NULL)
  BEGIN
    SELECT @DatumVon = PER.PeriodeVon 
    FROM dbo.KbPeriode PER WITH(READUNCOMMITTED) 
    WHERE PER.KbPeriodeID = @KbPeriodeID;
  END;     
  
  IF (@DatumBis IS NULL)
  BEGIN
    SELECT @DatumBis = PER.PeriodeBis 
    FROM dbo.KbPeriode PER WITH(READUNCOMMITTED) 
    WHERE PER.KbPeriodeID = @KbPeriodeID;
  END;
  
  -----------------------------------------------------------------------------
  -- create temporary table
  -----------------------------------------------------------------------------
  DECLARE @tmpBuchungen TABLE
  (
    --Id$ INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    KbBuchungKostenartID INT NULL,
    KbBuchungID          INT NOT NULL,
    SollKtoNr            VARCHAR(10) NOT NULL,
    HabenKtoNr           VARCHAR(10) NOT NULL,
    Betrag               MONEY NOT NULL,
    Ausgabe              BIT NOT NULL,
    BelegDatum           DATETIME NOT NULL,
    GemeindeCode         INT NULL
  );
  
  -------------------------------------------------------------------------------
  -- COLLECT ALL CANDIDATES:
  -- collect all possible entries within KbBuchungKostenart and store ids in
  --   temporary table
  -------------------------------------------------------------------------------
  --   > only those where KbBuchung.KbPeriodeID = @KbPeriodeID
  --   > only those where KbBuchung.BelegNr IS NOT NULL
  --   > only those where KbBuchung.BelegDatum Between @DatumVon AND @DatumBis
  -------------------------------------------------------------------------------
  
  -- Es gibt einen fachlichen Grund, dass die Debitor KiSS intern immer auf 0.00 sein soll. 
  -- Die Debitoren werden in der Klibu nicht bewirtschaftet, sie werden nur KiSS-intern geführt (als offene Posten-Liste). 
  -- Daher werden unten die Debitoren separat nochmals selektiert 

  -- HACK: (Siehe auch #6717)
  -- Der folgende UNION ist nötig, da die internen Debitoren-Buchungen auf die Kostenarten aufgeteilt werden müssen. 
  -- Dies daher, weil es keine explizite Buchung gibt für die Debitoren zu KOA Zuordnung
  -- Daher werden im ersten SQL-Statement alle Buchungen selektiert, und im zweiten SQL-Statements werden nochmals die Debitoren selektiert, 
  -- wobei das SollKonto dem Habenkonto vom ersten SQL entspricht und beim Habenkonto neu das Konto der KOA genommen wird. 
  -- Somit werden die internen Debitoren auf die Kostenarten verteilt
  IF (ISNULL(@CheckExists, 0) = 0)
  BEGIN
    INSERT INTO @tmpBuchungen(KbBuchungKostenartID, KbBuchungID, SollKtoNr, HabenKtoNr, Betrag, Ausgabe, BelegDatum)
      -- expenses
      SELECT 
        KbBuchungKostenartID = KOA.KbBuchungKostenartID,
        KbBuchungID          = BUC.KbBuchungID,
        SollKtoNr            = COALESCE(BUC.SollKtoNr, BGK.KontoNr, ''),
        HabenKtoNr           = COALESCE(BUC.HabenKtoNr, BGK.KontoNr, ''),
        Betrag               = ISNULL(KOA.Betrag, BUC.Betrag),
        Ausgabe              = 1,
        BelegDatum           = BUC.BelegDatum
      FROM dbo.KbBuchung                 BUC WITH (READUNCOMMITTED) 
        LEFT JOIN dbo.KbBuchungKostenart KOA WITH (READUNCOMMITTED) ON KOA.KbBuchungID = BUC.KbBuchungID
        LEFT JOIN dbo.BgKostenart        BGK WITH (READUNCOMMITTED) ON BGK.BgKostenartID = KOA.BgKostenartID -- only those with valid entry
      WHERE BUC.KbPeriodeID = @KbPeriodeID                                        -- only those of same periode
        AND BUC.BelegNr IS NOT NULL                                               -- only those with valid belegnr
        AND dbo.fnDateOf(BUC.BelegDatum) BETWEEN @DatumVon AND @DatumBis          -- only those where KbBuchung.BelegDatum Between @DatumVon AND @DatumBis
         
      -- combine entries
      UNION ALL

      -- income
      SELECT 
        KbBuchungKostenartID = KOA.KbBuchungKostenartID,
        KbBuchungID          = BUC.KbBuchungID,
        SollKtoNr            = BUC.HabenKtoNr,
        HabenKtoNr           = COALESCE(BGK.KontoNr, BUC.SollKtoNr),
        Betrag               = ISNULL(KOA.Betrag, BUC.Betrag),
        Ausgabe              = 0,
        BelegDatum           = BUC.BelegDatum
      FROM dbo.KbBuchung                 BUC WITH (READUNCOMMITTED) 
        INNER JOIN dbo.KbKonto           DEB WITH (READUNCOMMITTED) ON DEB.KbPeriodeID = BUC.KbPeriodeID             -- only those of same periode
                                                                   AND DEB.KontoNr = BUC.HabenKtoNr                  -- only those with matching kontoNr
                                                                   AND ',' + DEB.KbKontoartCodes + ',' LIKE '%,20,%' -- only those with code=20 'Debitor' in kontoart
        LEFT JOIN dbo.KbBuchungKostenart KOA WITH (READUNCOMMITTED) ON KOA.KbBuchungID = BUC.KbBuchungID
        LEFT JOIN dbo.BgKostenart        BGK WITH (READUNCOMMITTED) ON BGK.BgKostenartID = KOA.BgKostenartID
      WHERE BUC.KbPeriodeID = @KbPeriodeID                                -- only those of same periode
        AND BUC.BelegNr IS NOT NULL                                       -- only those with valid belegnr
        AND dbo.fnDateOf(BUC.BelegDatum) BETWEEN @DatumVon AND @DatumBis; -- only those where KbBuchung.BelegDatum Between @DatumVon AND @DatumBis
  END
  ELSE 
  BEGIN
    INSERT INTO @tmpBuchungen(KbBuchungKostenartID, KbBuchungID, SollKtoNr, HabenKtoNr, Betrag, Ausgabe, BelegDatum)
      -- expenses
      SELECT TOP 1
        KbBuchungKostenartID = KOA.KbBuchungKostenartID,
        KbBuchungID          = BUC.KbBuchungID,
        SollKtoNr            = COALESCE(BUC.SollKtoNr, BGK.KontoNr, ''),
        HabenKtoNr           = COALESCE(BUC.HabenKtoNr, BGK.KontoNr, ''),
        Betrag               = ISNULL(KOA.Betrag, BUC.Betrag),
        Ausgabe              = 1,
        BelegDatum           = BUC.BelegDatum
      FROM dbo.KbBuchung                 BUC WITH (READUNCOMMITTED) 
        LEFT JOIN dbo.KbBuchungKostenart KOA WITH (READUNCOMMITTED) ON KOA.KbBuchungID = BUC.KbBuchungID
        LEFT JOIN dbo.BgKostenart        BGK WITH (READUNCOMMITTED) ON BGK.BgKostenartID = KOA.BgKostenartID -- only those with valid entry
      WHERE BUC.KbPeriodeID = @KbPeriodeID                                        -- only those of same periode
        AND BUC.BelegNr IS NOT NULL                                               -- only those with valid belegnr
        AND dbo.fnDateOf(BUC.BelegDatum) BETWEEN @DatumVon AND @DatumBis          -- only those where KbBuchung.BelegDatum Between @DatumVon AND @DatumBis
         
      -- combine entries
      UNION ALL

      -- income
      SELECT TOP 1
        KbBuchungKostenartID = KOA.KbBuchungKostenartID,
        KbBuchungID          = BUC.KbBuchungID,
        SollKtoNr            = BUC.HabenKtoNr,
        HabenKtoNr           = COALESCE(BGK.KontoNr, BUC.SollKtoNr),
        Betrag               = ISNULL(KOA.Betrag, BUC.Betrag),
        Ausgabe              = 0,
        BelegDatum           = BUC.BelegDatum
      FROM dbo.KbBuchung                 BUC WITH (READUNCOMMITTED) 
        INNER JOIN dbo.KbKonto           DEB WITH (READUNCOMMITTED) ON DEB.KbPeriodeID = BUC.KbPeriodeID             -- only those of same periode
                                                                   AND DEB.KontoNr = BUC.HabenKtoNr                  -- only those with matching kontoNr
                                                                   AND ',' + DEB.KbKontoartCodes + ',' LIKE '%,20,%' -- only those with code=20 'Debitor' in kontoart
        LEFT JOIN dbo.KbBuchungKostenart KOA WITH (READUNCOMMITTED) ON KOA.KbBuchungID = BUC.KbBuchungID
        LEFT JOIN dbo.BgKostenart        BGK WITH (READUNCOMMITTED) ON BGK.BgKostenartID = KOA.BgKostenartID
      WHERE BUC.KbPeriodeID = @KbPeriodeID                                -- only those of same periode
        AND BUC.BelegNr IS NOT NULL                                       -- only those with valid belegnr
        AND dbo.fnDateOf(BUC.BelegDatum) BETWEEN @DatumVon AND @DatumBis; -- only those where KbBuchung.BelegDatum Between @DatumVon AND @DatumBis
  END;
  
  IF (ISNULL(@IncludeGemeindeCode, 1) = 1)
  BEGIN
    -- Zuständige Gemeinde suchen (Dies ist relativ aufwändig, daher kann es per Parameter ausgeschaltet werden)
    UPDATE BUC
    SET GemeindeCode = dbo.fnKbGetZustaendigeGemeinde(BUC.KbBuchungKostenartID)
    FROM @tmpBuchungen BUC;
  END;
  
  -----------------------------------------------------------------------------
  -- filter result to output table
  -----------------------------------------------------------------------------
  INSERT INTO @Result
    SELECT DISTINCT                   -- each entry has to be unique!
      KbBuchungKostenartID,
      KbBuchungID,
      SollKtoNr,
      HabenKtoNr,
      Betrag,
      Ausgabe,
      BelegDatum,
      GemeindeCode
    FROM @tmpBuchungen;
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN;
END;
GO