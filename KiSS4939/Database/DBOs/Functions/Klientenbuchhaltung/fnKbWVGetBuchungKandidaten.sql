SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnKbWVGetBuchungKandidaten
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/Klientenbuchhaltung/fnKbWVGetBuchungKandidaten.sql $
  $Author: Nweber $
  $Modtime: 14.07.10 9:01 $
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get all relevant entries for 'WV'
    @KbPeriodeID:    The id within KbPeriode specified
    @DatumBisWVLauf: The date-to used for filtering later entries
  -
  RETURNS: Table containing all relevant data used for 'WV'
  -
  TEST:    SELECT * FROM dbo.fnKbWVGetBuchungKandidaten](6, '2008-12-31')
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/Klientenbuchhaltung/fnKbWVGetBuchungKandidaten.sql $
 * 
 * 6     14.07.10 11:31 Nweber
 * #6064: Spalte KbPeriodeID von der Tabelle KbBuchungKostenart löschen
 * 
 * 5     29.04.10 10:06 Nweber
 * #6142: fnDateSerial benutzen anstatt String
 * 
 * 4     24.06.09 16:22 Ckaeser
 * Alter2Create
 * 
 * 3     1.10.08 12:53 Cjaeggi
 * Comment, case fix
 * 
 * 2     1.10.08 12:31 Cjaeggi
 * KbBuchungStatusCode 13='verbucht' now also considered
 * 
 * 1     13.09.08 17:06 Aklopfenstein
 * VSS First
=================================================================================================*/

CREATE FUNCTION dbo.fnKbWVGetBuchungKandidaten
(
  @KbPeriodeID INT, 
  @DatumBisWVLauf DATETIME
)
RETURNS @Result TABLE
(
  KbBuchungKostenartID INT NOT NULL
)
AS 

BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@DatumBisWVLauf IS NULL)
  BEGIN
    -- invalid data
    RETURN
  END

  -----------------------------------------------------------------------------
  -- create temporary table
  -----------------------------------------------------------------------------
  DECLARE @tmpWVBuchungen TABLE
  (
    Id$ INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    KbBuchungKostenartID INT NOT NULL
  )

  -------------------------------------------------------------------------------
  -- COLLECT ALL CANDIDATES:
  -- collect all possible entries within KbBuchungKostenart and store ids in
  --   temporary table
  -------------------------------------------------------------------------------
  --   > only those where KbBuchung.KbPeriodeID = @KbPeriodeID
  --   > only those where KbBuchung.BelegNr IS NOT NULL
  --   > only those where KbBuchung.BelegDatum <= @DatumBisWVLauf
  --   > only those where KbBuchungKostenart.VerwPeriodeVon <= @DatumBisWVLauf
  --   > corresponding entry for BaWVCode.BaPerson (to KbBuchungKostenart.BaPersonID)
  --   > valid for WV (KbBuchungKostenart.Weiterverrechenbar = true)
  --   > valid for WV (BaWVCode.BaWVCode = 21 'ZUG mit Weiterverrechnung > als 2 J. im Kanton' AND 
  --                   BaWVCode.StatusCode = 1 'Gültig')
  --   > only those with KbBuchung.KbBuchungStatusCode IN (6, 10, 13) (6='ausgeglichen', 10='teilweise ausgeglichen', 13='verbucht')
  -------------------------------------------------------------------------------
  INSERT INTO @tmpWVBuchungen
    -- expenses
    SELECT BKO.KbBuchungKostenartID
    FROM dbo.KbBuchungKostenart  BKO WITH (READUNCOMMITTED)
      INNER JOIN dbo.KbBuchung   BUC WITH (READUNCOMMITTED) ON BUC.KbBuchungID = BKO.KbBuchungID AND                 -- only those with valid entry
                                                               BUC.BelegNr IS NOT NULL AND                           -- only those with valid belegnr
                                                               BUC.StorniertKbBuchungID IS NULL AND                  -- only those who are not reversed entries (that means, the original ones)
                                                               dbo.fnDateOf(BUC.BelegDatum) <= @DatumBisWVLauf AND   -- only those where belegdatum is in date range
                                                               BUC.KbBuchungStatusCode IN (6, 13)                    -- only those with status 6='ausgeglichen' or 13='verbucht'

      INNER JOIN dbo.BgKostenart KOA WITH (READUNCOMMITTED) ON KOA.BgKostenartID = BKO.BgKostenartID                 -- only those with valid entry

      INNER JOIN dbo.BaWVCode    WVC WITH (READUNCOMMITTED) ON WVC.BaPersonID = BKO.BaPersonID AND                   -- only those with valid entry
                                                               WVC.BaWVCode = 21 AND                                 -- only those with code 21='ZUG mit Weiterverrechnung > als 2 J. im Kanton'
                                                               WVC.StatusCode = 1 AND                                -- only those with status 1='Gültig'
                                                               (                                                     -- handling of WVC.DatumVon..Bis matching with BKO.VerwPeriodeVon..Bis:
                                                                (WVC.DatumVon <= BKO.VerwPeriodeVon AND ISNULL(WVC.DatumBis, dbo.fnDateSerial(9999,12,31)) >= BKO.VerwPeriodeVon) OR     -- get entries starting before start of Verwendungsperiode (>= means at least one day at start of Verwendungsperiode)
                                                                (WVC.DatumVon <= BKO.VerwPeriodeBis AND ISNULL(WVC.DatumBis, dbo.fnDateSerial(9999,12,31)) >= BKO.VerwPeriodeBis) OR     -- get entries starting before or within end of Verwendungsperiode and end later or with Verwendungsperiode (<= means at least one day at end of Verwendungsperiode)
                                                                (WVC.DatumVon >= BKO.VerwPeriodeVon AND ISNULL(WVC.DatumBis, dbo.fnDateSerial(9999,12,31)) <= BKO.VerwPeriodeBis)        -- get entries starting with or later than start of Verwendungsperiode and end before or at end of Verwendungsperiode
                                                               )

    WHERE BUC.KbPeriodeID = @KbPeriodeID AND                          -- only those of same periode
          dbo.fnDateOf(BKO.VerwPeriodeVon) <= @DatumBisWVLauf AND     -- only those where verwperiodes start in date range
          BKO.BgSplittingArtCode IS NOT NULL AND                      -- only those with valid splittingartcode
          ISNULL(BKO.Weiterverrechenbar, 0) = 1                       -- only those who are true for wv and therefore have to be handled
          
    -- combine entries
    UNION ALL

    -- income
    SELECT BKO.KbBuchungKostenartID
    FROM dbo.KbBuchungKostenart  BKO WITH (READUNCOMMITTED) 
      INNER JOIN dbo.KbBuchung   BUC WITH (READUNCOMMITTED) ON BUC.KbBuchungID = BKO.KbBuchungID AND                 -- only those with valid entry
                                                               BUC.BelegNr IS NOT NULL AND                           -- only those with valid belegnr
                                                               BUC.StorniertKbBuchungID IS NULL AND                  -- only those who are not reversed entries (that means, the original ones)
                                                               dbo.fnDateOf(BUC.BelegDatum) <= @DatumBisWVLauf AND   -- only those where belegdatum is in date range
                                                               BUC.KbBuchungStatusCode IN (6, 10, 13)                -- only those with status 6='ausgeglichen' or 10='teilweise ausgeglichen' or 13='verbucht'

      INNER JOIN dbo.BgKostenart KOA WITH (READUNCOMMITTED) ON KOA.BgKostenartID = BKO.BgKostenartID                 -- only those with valid entry

      INNER JOIN dbo.BaWVCode    WVC WITH (READUNCOMMITTED) ON WVC.BaPersonID = BKO.BaPersonID AND                   -- only those with valid entry
                                                               WVC.BaWVCode = 21 AND                                 -- only those with code 21='ZUG mit Weiterverrechnung > als 2 J. im Kanton'
                                                               WVC.StatusCode = 1 AND                                -- only those with status 1='Gültig'
                                                               (                                                     -- handling of WVC.DatumVon..Bis matching with BKO.VerwPeriodeVon..Bis:
                                                                (WVC.DatumVon <= BKO.VerwPeriodeVon AND ISNULL(WVC.DatumBis, dbo.fnDateSerial(9999,12,31)) >= BKO.VerwPeriodeVon) OR     -- get entries starting before start of Verwendungsperiode (>= means at least one day at start of Verwendungsperiode)
                                                                (WVC.DatumVon <= BKO.VerwPeriodeBis AND ISNULL(WVC.DatumBis, dbo.fnDateSerial(9999,12,31)) >= BKO.VerwPeriodeBis) OR     -- get entries starting before or within end of Verwendungsperiode and end later or with Verwendungsperiode (<= means at least one day at end of Verwendungsperiode)
                                                                (WVC.DatumVon >= BKO.VerwPeriodeVon AND ISNULL(WVC.DatumBis, dbo.fnDateSerial(9999,12,31)) <= BKO.VerwPeriodeBis)        -- get entries starting with or later than start of Verwendungsperiode and end before or at end of Verwendungsperiode
                                                               )

      INNER JOIN dbo.KbKonto     DEB WITH(READUNCOMMITTED) ON DEB.KbPeriodeID = BUC.KbPeriodeID AND                  -- only those of same periode
                                                              DEB.KontoNr = BUC.HabenKtoNr AND                       -- only those with matching kontoNr
                                                              (',' + DEB.KbKontoartCodes + ',' LIKE '%,20,%')        -- only those with code=20 'Debitor' in kontoart

    WHERE BUC.KbPeriodeID = @KbPeriodeID AND                          -- only those of same periode
          dbo.fnDateOf(BKO.VerwPeriodeVon) <= @DatumBisWVLauf AND     -- only those where verwperiode starts in date range
          BKO.BgSplittingArtCode IS NOT NULL AND                      -- only those with valid splittingartcode
          ISNULL(BKO.Weiterverrechenbar, 0) = 1                       -- only those who are true for wv and therefore have to be handled

  -----------------------------------------------------------------------------
  -- filter result to output table
  -----------------------------------------------------------------------------
  INSERT INTO @Result
    SELECT DISTINCT                   -- each entry has to be unique!
           KbBuchungKostenartID
    FROM @tmpWVBuchungen

  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN
END

GO
