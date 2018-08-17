SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spWhFinanzplan_Update;
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/
CREATE PROCEDURE dbo.spWhFinanzplan_Update
(
  @BgFinanzplanID INT
)
AS BEGIN
  DECLARE @BgBudgetID               INT,
          @WhGrundbedarfTyp         INT,
          @BgBewilligungStatusCode  INT,
          @RefDate                  DATETIME;

  -- Falls nötig, werden zuerst noch Positionen terminiert im neuen Masterbudget
  EXEC spWhPositionsart_Masterbudget_Terminieren @BgFinanzplanID

  SELECT
    @BgBudgetID               = BBG.BgBudgetID,
    @BgBewilligungStatusCode  = BFP.BgBewilligungStatusCode,
    @RefDate                  = dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1)
  FROM dbo.BgFinanzplan      BFP WITH (READUNCOMMITTED) 
    INNER JOIN dbo.BgBudget  BBG WITH (READUNCOMMITTED) ON BBG.BgFinanzplanID = BFP.BgFinanzplanID AND BBG.MasterBudget = 1
  WHERE BFP.BgFinanzplanID = @BgFinanzplanID

  IF @BgBudgetID IS NULL RETURN

  SELECT @WhGrundbedarfTyp = POA.BgPositionsartCode
  FROM dbo.BgPosition        BPO WITH (READUNCOMMITTED) 
    INNER JOIN dbo.BgPositionsart POA WITH (READUNCOMMITTED) ON POA.BgPositionsartID = BPO.BgPositionsartID
    INNER JOIN XLOVCode  XLC ON XLC.LOVName = 'WhGrundbedarfTyp' AND XLC.Code = POA.BgPositionsartCode
  WHERE BPO.BgBudgetID = @BgBudgetID

  IF @WhGrundbedarfTyp = 32011 
  BEGIN
    -- Grundbedarf 1
    UPDATE BPO
      SET Betrag = IsNull(dbo.fnShGrundbedarfI(@BgFinanzplanID), 0)
    FROM dbo.BgPosition   BPO
    INNER JOIN dbo.BgPositionsart POA WITH (READUNCOMMITTED) ON POA.BgPositionsartID = BPO.BgPositionsartID
    WHERE BPO.BgBudgetID = @BgBudgetID AND POA.BgPositionsartCode = 32011

    -- Grundbedarf 1 Zuschlag
    UPDATE BPO
      SET Betrag = IsNull(dbo.fnShGrundbedarfIZuschlag(@BgFinanzplanID), 0)
    FROM BgPosition   BPO
    INNER JOIN dbo.BgPositionsart POA WITH (READUNCOMMITTED) ON POA.BgPositionsartID = BPO.BgPositionsartID
    WHERE BPO.BgBudgetID = @BgBudgetID AND POA.BgPositionsartCode = 32012

    -- Grundbedarf 2
    UPDATE BPO
      SET Betrag = IsNull(dbo.fnShGrundbedarfII(@BgFinanzplanID, 1), 0)
    FROM BgPosition   BPO
    INNER JOIN dbo.BgPositionsart POA WITH (READUNCOMMITTED) ON POA.BgPositionsartID = BPO.BgPositionsartID
    WHERE BPO.BgBudgetID = @BgBudgetID AND POA.BgPositionsartCode = 32013

    -- Grundbedarf 2 - Keine kopfteilung
    UPDATE BPO
      SET Betrag = IsNull(dbo.fnShGrundbedarfII(@BgFinanzplanID, 0), 0)
    FROM BgPosition   BPO
    INNER JOIN dbo.BgPositionsart POA WITH (READUNCOMMITTED) ON POA.BgPositionsartID = BPO.BgPositionsartID
    WHERE BPO.BgBudgetID = @BgBudgetID AND POA.BgPositionsartCode = 32014
  END
  ELSE IF @WhGrundbedarfTyp = 32015 AND @BgBewilligungStatusCode < 5 BEGIN
    UPDATE BPO
      SET Betrag = -$1.00
    FROM BgPosition BPO
    INNER JOIN dbo.BgPositionsart POA WITH (READUNCOMMITTED) ON POA.BgPositionsartID = BPO.BgPositionsartID
    WHERE BPO.BgBudgetID = @BgBudgetID AND POA.BgPositionsartCode = 32015
  END


  -- Wohnkosten
  DECLARE @BgPositionID_Wohn INT

  DECLARE cWohnkosten CURSOR FOR
    SELECT BgPositionID
    FROM dbo.BgPosition             BPO WITH (READUNCOMMITTED) 
      INNER JOIN dbo.WhPositionsart  SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID
    WHERE BPO.BgBudgetID = @BgBudgetID AND SPT.BgPositionsartCode <> 32060 AND SPT.BgGruppeCode = 3206
      AND (SPT.BgPositionsartCode % 2) = 0  -- Richtlinien

  DECLARE @UeFactor  FLOAT
  SELECT @UeFactor = RntHgUeFactor FROM dbo.fnWhKennzahlen(@BgFinanzplanID)

  OPEN cWohnkosten
  WHILE 1 = 1 
  BEGIN
    FETCH NEXT FROM cWohnkosten INTO @BgPositionID_Wohn
    IF @@FETCH_STATUS != 0 BREAK

    IF @BgBewilligungStatusCode < 5  -- in planung
    BEGIN
      -- Miete
      UPDATE BPO
        SET Reduktion  = IsNull(Betrag * (CONVERT(float, 1) - @UeFactor), $0.00),
          Abzug        = $0.00,
          MaxBeitragSD = IsNull(dbo.fnShWohnkosten_Hg(@BgFinanzplanID, BPO.DatumVon) * @UeFactor, $0.00)
      FROM BgPosition             BPO
      WHERE BgPositionID = @BgPositionID_Wohn

      -- Nebenkosten
      UPDATE BPO
        SET Reduktion  = IsNull(Betrag * (CONVERT(float, 1) - @UeFactor), $0.00),
          Abzug        = $0.00,
          MaxBeitragSD = IsNull(Betrag * @UeFactor, $0.00)
      FROM BgPosition   BPO
      WHERE BgPositionID_Parent = @BgPositionID_Wohn

    END 
    ELSE 
    BEGIN
      -- Miete
      UPDATE BPO
        SET Reduktion  = IsNull(Betrag * (CONVERT(float, 1) - @UeFactor), $0.00) - Abzug,
          MaxBeitragSD = IsNull(dbo.fnShWohnkosten_Hg(@BgFinanzplanID, BPO.DatumVon) * @UeFactor, $0.00)
      FROM BgPosition             BPO
      WHERE BgPositionID = @BgPositionID_Wohn

      -- Nebenkosten
      UPDATE BPO
        SET Reduktion  = IsNull(Betrag * (CONVERT(float, 1) - @UeFactor), $0.00) - Abzug,
          MaxBeitragSD = IsNull(Betrag * @UeFactor, $0.00)
      FROM BgPosition   BPO
      WHERE BgPositionID_Parent = @BgPositionID_Wohn

    END
  END
  CLOSE cWohnkosten
  DEALLOCATE cWohnkosten

  -- Add Remove Person
  DECLARE @BaPersonID      int,
          @IstUnterstuetzt  bit

  DECLARE cPerson CURSOR FAST_FORWARD FOR
    SELECT BaPersonID, IstUnterstuetzt
    FROM dbo.BgFinanzplan_BaPerson WITH (READUNCOMMITTED) 
    WHERE BgFinanzplanID = @BgFinanzplanID
   UNION ALL
    SELECT DISTINCT BPO.BaPersonID, 0
    FROM dbo.BgBudget            BBG WITH (READUNCOMMITTED) 
      INNER JOIN dbo.BgPosition  BPO WITH (READUNCOMMITTED) ON BPO.BgBudgetID = BBG.BgBudgetID
    WHERE BBG.BgFinanzplanID = @BgFinanzplanID AND BPO.BaPersonID IS NOT NULL
      AND NOT EXISTS (SELECT 1 FROM dbo.BgFinanzplan_BaPerson WITH (READUNCOMMITTED) 
                      WHERE BaPersonID = BPO.BaPersonID AND BgFinanzplanID = @BgFinanzplanID)

  OPEN cPerson
  WHILE 1 = 1 
  BEGIN
    FETCH NEXT FROM cPerson INTO @BaPersonID, @IstUnterstuetzt
    IF @@FETCH_STATUS != 0 BREAK

    IF @IstUnterstuetzt = 1 BEGIN
      DECLARE @KVG                  money,
              @BaInstitutionID      int,
              @VVG                  money,
              @VVG_BaInstitutionID  int

 SELECT @KVG = $0.00,
        @VVG = $0.00
/*
TODO Beträge übernehmen
      SELECT TOP 1
        @KVG = IsNull(KVG.Praemie, $0.00), @BaInstitutionID     = KVG.BaInstitutionID,
        @VVG = IsNull(VVG.Praemie, $0.00), @VVG_BaInstitutionID = VVG.BaInstitutionID
      FROM BaPerson                       PRS
        LEFT JOIN BaKrankenversicherung   KVG ON KVG.BaPersonID = PRS.BaPersonID AND KVG.GesetzesGrundlageCode = 1
                                             AND @RefDate BETWEEN IsNull(KVG.DatumVon, @RefDate) AND IsNull(KVG.DatumBis, @RefDate)
        LEFT JOIN BaKrankenversicherung   VVG ON VVG.BaPersonID = PRS.BaPersonID AND VVG.GesetzesGrundlageCode = 2
                                             AND @RefDate BETWEEN IsNull(VVG.DatumVon, @RefDate) AND IsNull(VVG.DatumBis, @RefDate)
      WHERE PRS.BaPersonID = @BaPersonID
      ORDER BY KVG.DatumVon DESC, VVG.DatumVon DESC
*/
      -- KVG
      IF NOT EXISTS (SELECT 1 
                     FROM dbo.BgPosition POS WITH (READUNCOMMITTED) 
                     INNER JOIN dbo.BgPositionsart POA WITH (READUNCOMMITTED) ON POA.BgPositionsartID = POS.BgPositionsartID
                     WHERE POS.BgBudgetID = @BgBudgetID AND POS.BaPersonID = @BaPersonID
                       AND (POA.BgPositionsartCode = 32020 OR POA.BgPositionsartCode BETWEEN 32121 AND 32130))
        INSERT INTO BgPosition (BgBudgetID, BaPersonID, BgKategorieCode, BgPositionsartID, Betrag, BaInstitutionID, Buchungstext)
          SELECT @BgBudgetID, @BaPersonID, POA.BgKategorieCode, POA.BgPositionsartID, @KVG, @BaInstitutionID, [Name]
          FROM dbo.BgPositionsart POA WITH (READUNCOMMITTED) 
          INNER JOIN dbo.BgBudget BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = @BgBudgetID
          WHERE POA.BgPositionsartCode = 32020 AND
           ISNULL(POA.DatumVon, '1900-01-01') <= dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1) AND 
           ISNULL(POA.DatumBis, '9999-12-31') >= dbo.fnLastDayOf(dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1))

      -- VVG
      IF NOT EXISTS (SELECT 1 
                     FROM dbo.BgPosition POS WITH (READUNCOMMITTED) 
                     INNER JOIN dbo.BgPositionsart POA WITH (READUNCOMMITTED) ON POA.BgPositionsartID = POS.BgPositionsartID
                     WHERE POS.BgBudgetID = @BgBudgetID AND POS.BaPersonID = @BaPersonID 
                       AND POA.BgPositionsartCode IN (32021, 32022))
        INSERT INTO BgPosition (BgPositionID_Parent, BgBudgetID, BaPersonID, BgKategorieCode, BgPositionsartID, Betrag, MaxBeitragSD, BaInstitutionID, Buchungstext)
          SELECT SCOPE_IDENTITY(), @BgBudgetID, @BaPersonID, POA.BgKategorieCode, POA.BgPositionsartID, @VVG, $0.00, @VVG_BaInstitutionID, [Name]
          FROM dbo.BgPositionsart POA WITH (READUNCOMMITTED) 
          INNER JOIN dbo.BgBudget BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = @BgBudgetID
          WHERE POA.BgPositionsartCode = 32021 AND
           ISNULL(POA.DatumVon, '1900-01-01') <= dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1) AND 
           ISNULL(POA.DatumBis, '9999-12-31') >= dbo.fnLastDayOf(dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1))

      -- Alg. Erwerbsunkosten
      IF @WhGrundbedarfTyp = 32011 
      BEGIN
        IF NOT EXISTS (SELECT 1 
                       FROM dbo.BgPosition POS WITH (READUNCOMMITTED) 
                       INNER JOIN dbo.BgPositionsart POA WITH (READUNCOMMITTED) ON POA.BgPositionsartID = POS.BgPositionsartID
                       WHERE POS.BgBudgetID = @BgBudgetID AND POS.BaPersonID = @BaPersonID 
                         AND POA.BgPositionsartCode = 32031) 
        BEGIN
          INSERT INTO BgPosition (BgBudgetID, BaPersonID, BgKategorieCode, BgPositionsartID, MaxBeitragSD, Buchungstext)
            SELECT @BgBudgetID, @BaPersonID, POA.BgKategorieCode, POA.BgPositionsartID, CONVERT(money, dbo.fnXConfig('System\Sozialhilfe\SKOS\C3_GeAmount', @RefDate)), [Name]
            FROM dbo.BgPositionsart POA WITH (READUNCOMMITTED) 
            INNER JOIN dbo.BgBudget BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = @BgBudgetID
            WHERE POA.BgPositionsartCode = 32031 AND
             ISNULL(POA.DatumVon, '1900-01-01') <= dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1) AND 
             ISNULL(POA.DatumBis, '9999-12-31') >= dbo.fnLastDayOf(dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1))
        END
      END 
      ELSE IF @WhGrundbedarfTyp = 32015 
      BEGIN
        DELETE POS
        FROM BgPosition POS
        INNER JOIN BgPositionsart POA ON POA.BgPositionsartID = POS.BgPositionsartID
        WHERE POS.BgBudgetID = @BgBudgetID AND POS.BaPersonID = @BaPersonID 
          AND POA.BgPositionsartCode = 32031
      END

    END 
    ELSE 
    BEGIN
      -- Persönliche Eintrage für nichtunterstützte Persone löschen
      WHILE 1 = 1 
      BEGIN
        DELETE BPO
        FROM dbo.BgBudget            BBG 
          INNER JOIN BgPosition  BPO ON BPO.BgBudgetID = BBG.BgBudgetID
        WHERE BBG.BgFinanzplanID = @BgFinanzplanID AND BPO.BaPersonID = @BaPersonID
          AND (BBG.MasterBudget = 1 OR BBG.BgBewilligungStatusCode < 5)
          AND NOT EXISTS (SELECT * FROM BgPosition WHERE BgPositionID_Parent = BPO.BgPositionID)

        IF @@rowcount = 0 BREAK
      END
    END
  END
  CLOSE cPerson
  DEALLOCATE cPerson

  EXECUTE spWhBudget_Update @BgBudgetID
END
GO