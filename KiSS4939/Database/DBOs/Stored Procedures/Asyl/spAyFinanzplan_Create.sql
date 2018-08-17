SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spAyFinanzplan_Create
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Stored Procedures/Asyl/spAyFinanzplan_Create.sql $
  $Author: Tabegglen $
  $Modtime: 20.08.10 11:55 $
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
  $Log: /KiSS4/Database/DBOs/Stored Procedures/Asyl/spAyFinanzplan_Create.sql $
 * 
 * 3     20.08.10 11:55 Tabegglen
 * #3978 Migration BgPositionsartID -> BgPositionsartCode
 * 
 * 2     25.06.09 11:40 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/

/*
  KiSS 4.0
  --------
  DB-Object: spAyFinanzplan_Create
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:53
*/
CREATE PROCEDURE dbo.spAyFinanzplan_Create
 (@FaLeistungID    int,
  @GeplantVon      datetime,
  @GeplantBis      datetime,
  @WhHilfeTypCode  int,
  @CopyOfLast       bit = 1,
  @WhGrundbedarfTyp int = NULL)
AS 

BEGIN
  DECLARE @BgFinanzplanID     int,
          @JahrMonatsbudget   int,
          @MonatMonatsbudget  int,
          @BgBudgetID         int

  -- BgFinanzplan
  INSERT INTO BgFinanzplan (FaLeistungID, BgBewilligungStatusCode, WhHilfeTypCode, GeplantVon, GeplantBis)
    VALUES (@FaLeistungID, 1, @WhHilfeTypCode, @GeplantVon, @GeplantBis)

  SELECT
    @BgFinanzplanID    = @@IDENTITY,
    @JahrMonatsbudget  = Year(@GeplantVon),
    @MonatMonatsbudget = MONTH(@GeplantVon)

  -- BgBudget (Masterbutget)
  INSERT INTO BgBudget (MasterBudget, BgBewilligungStatusCode, BgFinanzplanID, Jahr, Monat)
    VALUES (1, 1, @BgFinanzplanID, @JahrMonatsbudget, @MonatMonatsbudget)

  SET @BgBudgetID = @@IDENTITY

  IF @CopyOfLast = 1 BEGIN
    DECLARE @BgFinanzplanID_Copy int,
            @BgBudget_Copy       int,
            @MonatsDifferenz     int

    SELECT TOP 1
      @BgBudget_Copy        = BBG.BgBudgetID,
      @BgFinanzplanID_Copy  = BBG.BgFinanzplanID,
      @MonatsDifferenz      = DateDiff(m, dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1), @GeplantVon)
    FROM dbo.BgBudget              BBG WITH (READUNCOMMITTED) 
      INNER JOIN dbo.BgFinanzplan  SFP WITH (READUNCOMMITTED) ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
    WHERE SFP.FaLeistungID = @FaLeistungID AND BBG.MasterBudget = 1
      AND SFP.BgFinanzplanID != @BgFinanzplanID
    ORDER BY Jahr DESC, Monat DESC

    -- Personen
    INSERT INTO BgFinanzplan_BaPerson(BgFinanzplanID, BaPersonID, IstUnterstuetzt, BaZahlungswegID, ReferenzNummer,
        KbKostenstelleID, KbKostenstelleID_KVG, ShNrmVerrechnungsbasisID, PrsNummerKanton, PrsNummerHeimat, NrmVerrechnungVon,
        NrmVerrechnungBis, NrmVerrechnungsAnteilCode, IstAuslandCh, AuslandChVon, AuslandChBis, AuslandChMeldungAm, AuslandChReferenzNrBund,
        BurgergemeindeID, Bemerkung)
      SELECT @BgFinanzplanID, BaPersonID, IstUnterstuetzt, BaZahlungswegID, ReferenzNummer,
        KbKostenstelleID, KbKostenstelleID_KVG, ShNrmVerrechnungsbasisID, PrsNummerKanton, PrsNummerHeimat, NrmVerrechnungVon,
        NrmVerrechnungBis, NrmVerrechnungsAnteilCode, IstAuslandCh, AuslandChVon, AuslandChBis, AuslandChMeldungAm, AuslandChReferenzNrBund,
        BurgergemeindeID, Bemerkung
      FROM dbo.BgFinanzplan_BaPerson WITH (READUNCOMMITTED) 
      WHERE BgFinanzplanID = @BgFinanzplanID_Copy


    -- Copy BgPosition
    SELECT PK       = BgPositionID,
           Parent   = BgPositionID_Parent,
           KeyNew   = CONVERT(int, NULL),
           BPO.BgPositionID_CopyOf
    INTO #BgPosition
    FROM dbo.BgPosition  BPO WITH (READUNCOMMITTED) 
    WHERE BPO.BgBudgetID = @BgBudget_Copy
      AND @GeplantVon BETWEEN IsNull(BPO.DatumVon, '19000101') AND IsNull(BPO.DatumBis, @GeplantVon)

    DECLARE @FixFieldValue varchar(100)
    SET @FixFieldValue = CONVERT(varchar, @BgBudgetID)
    EXECUTE spXParentChildCopy '#BgPosition',
                               'BgPosition', 'BgPositionID', 'BgPositionID_Parent',
                               'BgBudgetID', @FixFieldValue, 'BgPositionID_CopyOf, BgBewilligungStatusCode, OldID, ShBelegID'

    UPDATE BgPosition
      SET DatumVon = NULL
    WHERE BgBudgetID = @BgBudgetID AND DatumVon < @GeplantVon

    UPDATE BPO
      SET BgPositionID_CopyOf = NXT.KeyNew
    FROM BgPosition           BPO
      INNER JOIN #BgPosition  ORI ON ORI.KeyNew = BPO.BgPositionID
      INNER JOIN #BgPosition  NXT ON NXT.PK = ORI.BgPositionID_CopyOf
    WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.DatumVon IS NOT NULL


    -- Copy BgAuszahlungPerson
    SELECT BgAuszahlungPersonID AS PK, CONVERT(int, NULL) AS Parent, CONVERT(int, NULL) AS KeyNew
    INTO #BgAuszahlungPerson
    FROM dbo.BgAuszahlungPerson    BAP WITH (READUNCOMMITTED) 
      INNER  JOIN #BgPosition  BPO ON BPO.PK = BAP.BgPositionID

    EXECUTE spXParentChildCopy '#BgAuszahlungPerson',
                               'BgAuszahlungPerson', 'BgAuszahlungPersonID', NULL,
                               'BgPositionID', '(SELECT KeyNew FROM #BgPosition WHERE PK = BgPositionID)'

    DROP TABLE #BgAuszahlungPerson
    DROP TABLE #BgPosition
  END ELSE BEGIN
    -- neuer,leerer Finanzplan: Klient als unterstützte Person eintragen
    INSERT BgFinanzplan_BaPerson (BgFinanzplanID, BaPersonID, IstUnterstuetzt)
      SELECT @BgFinanzplanID, FAL.BaPersonID, 1
      FROM dbo.BgFinanzplan        SFP WITH (READUNCOMMITTED) 
        INNER JOIN dbo.FaLeistung  FAL WITH (READUNCOMMITTED) on FAL.FaLeistungID = SFP.FaLeistungID
      WHERE SFP.BgFinanzplanID = @BgFinanzplanID

    -- Grundbedarf Stufe normal anlegen
    INSERT BgPosition (BgBudgetID, BgKategorieCode, BgPositionsartID, Betrag)
      SELECT TOP 1 
        @BgBudgetID, 2, BPA.BgPositionsartID, CONVERT(money, IsNull(dbo.fnXConfig('System\Asyl\Grundbedarf\normal\1', @GeplantVon), $0.00))
      FROM dbo.BgPositionsart BPA WITH (READUNCOMMITTED)
        INNER JOIN dbo.BgBudget BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = @BgBudgetID
      WHERE BPA.BgPositionsartCode = 60002 AND
           ISNULL(BPA.DatumVon, '1900-01-01') <= dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1) AND 
           ISNULL(BPA.DatumBis, '9999-12-31') >= dbo.fnLastDayOf(dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1));

    -- Kleidung
    INSERT BgPosition (BgBudgetID, BgKategorieCode, BgPositionsartID, Betrag)
      SELECT TOP 1 
        @BgBudgetID, 2, BPA.BgPositionsartID, CONVERT(money, IsNull(dbo.fnXConfig('System\Asyl\Kleidung', @GeplantVon), $0.00))
      FROM dbo.BgPositionsart BPA WITH (READUNCOMMITTED)
        INNER JOIN dbo.BgBudget BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = @BgBudgetID
      WHERE BPA.BgPositionsartCode = 60004 AND
           ISNULL(BPA.DatumVon, '1900-01-01') <= dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1) AND 
           ISNULL(BPA.DatumBis, '9999-12-31') >= dbo.fnLastDayOf(dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1));
        
  END

  EXEC spAyBudget_Update @BgBudgetID, 1, 1, 1
END
GO