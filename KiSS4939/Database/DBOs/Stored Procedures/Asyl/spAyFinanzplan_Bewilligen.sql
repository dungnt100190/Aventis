SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spAyFinanzplan_Bewilligen
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spAyFinanzplan_Bewilligen.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:34 $
  $Revision: 2 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spAyFinanzplan_Bewilligen.sql $
 * 
 * 2     25.06.09 11:42 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spAyFinanzplan_Bewilligen
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:53
*/
CREATE PROCEDURE dbo.spAyFinanzplan_Bewilligen
 (@BgFinanzplanID  int,
  @BewilligtAb     datetime)
AS BEGIN
  DECLARE @FaLeistungID        int,
          @BgBudgetID      int,
          @StdTag          int

  SET @StdTag = IsNull(CONVERT(int, dbo.fnXConfig('System\Asyl\Zahlungsmodus_Termin', @BewilligtAb)), -24)

  SELECT @FaLeistungID = SFP.FaLeistungID, @BgBudgetID = BBG.BgBudgetID
  FROM dbo.BgFinanzplan      SFP WITH (READUNCOMMITTED) 
    INNER JOIN dbo.BgBudget  BBG WITH (READUNCOMMITTED) ON BBG.BgFinanzplanID = SFP.BgFinanzplanID
                            AND BBG.MasterBudget = 1
  WHERE SFP.BgFinanzplanID = @BgFinanzplanID

  -- Standardzahlungsmodi
  INSERT INTO BgZahlungsmodus (FaLeistungID, NameZahlungsmodus, KbAuszahlungsArtCode, BaZahlungswegID, ReferenzNummer, DatumVon)
    SELECT @FaLeistungID, CFG.Child,
      CONVERT(int,         dbo.fnCSVSplit(CFG.ValueVar, 1) )  AS KbAuszahlungsArtCode,
      CONVERT(int,         dbo.fnCSVSplit(CFG.ValueVar, 2) )  AS BaZahlungswegID,
      CONVERT(varchar(50), dbo.fnCSVSplit(CFG.ValueVar, 3) )  AS ReferenzNummer,
      @BewilligtAb
    FROM (SELECT Child, CONVERT(varchar(8000), ValueVar) AS ValueVar
          FROM dbo.fnXConfigChild('System\Asyl\Zahlungsmodus', @BewilligtAb) )  CFG
    WHERE NOT EXISTS (SELECT 1 FROM dbo.BgZahlungsmodus WITH (READUNCOMMITTED) 
                      WHERE FaLeistungID = @FaLeistungID AND NameZahlungsmodus = CFG.Child
                        AND IsNull(DatumBis, @BewilligtAb) >= @BewilligtAb)

  INSERT INTO BgZahlungsmodusTermin(BgZahlungsmodusID, TagImMonat, ImVormonat, nMonatlich)
    SELECT BgZahlungsmodusID, ABS(@StdTag), CASE WHEN @StdTag < 0 THEN 1 ELSE 0 END, 1
    FROM dbo.BgZahlungsmodus  SZM WITH (READUNCOMMITTED) 
    WHERE SZM.FaLeistungID = @FaLeistungID
      AND NOT EXISTS (SELECT 1 FROM dbo.BgZahlungsmodusTermin WITH (READUNCOMMITTED) WHERE BgZahlungsmodusID = SZM.BgZahlungsmodusID)

  -- Zahlungsmodus Klient
  DECLARE @NameZahlungsmodus  varchar(100),
          @BaZahlungswegID    int,
          @ReferenzNummer     varchar(50),
          @StdZahlungsartCode int

  SET @StdZahlungsartCode = IsNull(CONVERT(int,dbo.fnXConfig('System\Asyl\KlientStandardZahlungart', @BewilligtAb)), 101);

  DECLARE cZahlungsmodus CURSOR FAST_FORWARD FOR
    SELECT
      CASE WHEN IsNull(SPP.BaZahlungswegID, FPR.BaZahlungswegID) = FPR.BaZahlungswegID
        THEN 'Konto: ' + FPR.Name
        ELSE 'Konto: ' + PRS.Name + IsNull(', ' + PRS.Vorname, '')
      END AS  NameZahlungsmodus,
      IsNull(SPP.BaZahlungswegID, FPR.BaZahlungswegID),
      IsNull(SPP.ReferenzNummer, FPR.ReferenzNummer)
    FROM dbo.BgFinanzplan_BaPerson  SPP WITH (READUNCOMMITTED) 
      INNER JOIN dbo.BaPerson       PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = SPP.BaPersonID
      LEFT  JOIN (SELECT PRS.BaPersonID, PRS.Name + IsNull(', ' + PRS.Vorname, '') AS Name, SPP.BaZahlungswegID, SPP.ReferenzNummer
                  FROM dbo.FaLeistung                          FAL WITH (READUNCOMMITTED) 
                    INNER JOIN dbo.BaPerson               PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = FAL.BaPersonID
                    INNER JOIN dbo.BgFinanzplan_BaPerson  SPP WITH (READUNCOMMITTED) ON SPP.BgFinanzplanID = @BgFinanzplanID AND SPP.BaPersonID = PRS.BaPersonID
                  WHERE FAL.FaLeistungID = @FaLeistungID)  FPR ON 1 = 1
    WHERE SPP.BgFinanzplanID = @BgFinanzplanID
      AND SPP.IstUnterstuetzt = 1
    ORDER BY CASE WHEN IsNull(SPP.BaZahlungswegID, FPR.BaZahlungswegID) = FPR.BaZahlungswegID THEN 1 ELSE 0 END,
      SPP.BaZahlungswegID, SPP.ReferenzNummer,
      PRS.Geburtsdatum DESC

  OPEN cZahlungsmodus
  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM cZahlungsmodus INTO @NameZahlungsmodus, @BaZahlungswegID, @ReferenzNummer
    IF @@FETCH_STATUS < 0 BREAK

    IF NOT EXISTS (SELECT 1
                   FROM dbo.BgZahlungsmodus  SZM WITH (READUNCOMMITTED) 
                   WHERE FaLeistungID = @FaLeistungID AND KontoKlient = 1
                     AND DatumVon <= @BewilligtAb AND (DatumBis >= @BewilligtAb OR DatumBis IS NULL)
                     AND BaZahlungswegID = @BaZahlungswegID AND IsNull(ReferenzNummer, '') = IsNull(@ReferenzNummer, '')
    ) BEGIN
      INSERT INTO BgZahlungsmodus (FaLeistungID, NameZahlungsmodus, KbAuszahlungsArtCode, KontoKlient, BaZahlungswegID, ReferenzNummer, DatumVon)
        VALUES (@FaLeistungID, @NameZahlungsmodus, @StdZahlungsartCode, 1, @BaZahlungswegID, @ReferenzNummer, @BewilligtAb)
      INSERT INTO BgZahlungsmodusTermin (BgZahlungsmodusID, TagImMonat, ImVormonat, nMonatlich)
        SELECT @@IDENTITY, ABS(@StdTag), CASE WHEN @StdTag < 0 THEN 1 ELSE 0 END, 1
    END
  END
  CLOSE cZahlungsmodus
  DEALLOCATE cZahlungsmodus

  -- Ausgabekonto
  INSERT INTO BgSpezkonto (FaLeistungID, BgSpezkontoTypCode, NameSpezkonto, BgPositionsartID, BgKostenartID)
    SELECT DISTINCT @FaLeistungID, 1, BPT.Name, BPT.BgPositionsartID, BPT.BgKostenartID
    FROM dbo.vwBgPosition            BPO
      INNER JOIN dbo.BgPositionsart  BPT ON BPT.BgPositionsartID = BPO.BgPositionsartID
    WHERE BPO.BgBudgetID = @BgBudgetID AND (BPO.BetragRechnung > $0.00 OR (BPT.Masterbudget_EditMask & 0x4 != 0))
      AND BPT.Spezkonto = 1
      AND NOT EXISTS (SELECT 1 FROM dbo.BgSpezkonto WITH (READUNCOMMITTED) WHERE FaLeistungID = @FaLeistungID AND BgPositionsartID = BPT.BgPositionsartID)

  UPDATE BPO
    SET BgSpezkontoID = SSK.BgSpezkontoID
  FROM BgPosition              BPO
    INNER JOIN dbo.vwBgPosition    vBP ON vBP.BgPositionID = BPO.BgPositionID
    INNER JOIN dbo.BgPositionsart  BPT WITH (READUNCOMMITTED) ON BPT.BgPositionsartID = BPO.BgPositionsartID
    INNER JOIN dbo.BgSpezkonto     SSK WITH (READUNCOMMITTED) ON SSK.FaLeistungID = @FaLeistungID AND SSK.BgPositionsartID = BPT.BgPositionsartID
  WHERE BPO.BgBudgetID = @BgBudgetID AND (vBP.BetragRechnung > $0.00 OR (BPT.Masterbudget_EditMask & 0x4 != 0))
    AND BPT.Spezkonto = 1 AND BPO.BgSpezkontoID IS NULL
    AND NOT EXISTS (SELECT 1 FROM dbo.BgAuszahlungPerson WITH (READUNCOMMITTED) WHERE BgPositionID = BPO.BgPositionID)

  -- BgAuszahlung / BgAuszahlungPerson
  DECLARE @AnzZahlungsweg int
  SELECT @AnzZahlungsweg = COUNT(*)
  FROM (SELECT DISTINCT BaZahlungswegID, ReferenzNummer
        FROM dbo.BgFinanzplan_BaPerson WITH (READUNCOMMITTED) 
        WHERE BgFinanzplanID = @BgFinanzplanID AND IstUnterstuetzt = 1) TMP

  INSERT INTO BgAuszahlungPerson (BgPositionID, BaPersonID, BgZahlungsmodusID, KbAuszahlungsArtCode, Zahlungsgrund, BaZahlungswegID, ReferenzNummer)
    SELECT DISTINCT BPO.BgPositionID,
      BaPersonID = CASE WHEN @AnzZahlungsweg = 1 THEN NULL ELSE SPP.BaPersonID END,
      SZM.BgZahlungsmodusID, SZM.KbAuszahlungsArtCode, NULL, SZM.BaZahlungswegID, SZM.ReferenzNummer
    FROM dbo.BgFinanzplan_BaPerson    SPP WITH (READUNCOMMITTED) 
      INNER JOIN dbo.BgZahlungsmodus  SZM WITH (READUNCOMMITTED) ON SZM.BaZahlungswegID = SPP.BaZahlungswegID
      INNER JOIN dbo.BgPosition       BPO WITH (READUNCOMMITTED) ON BPO.BgBudgetID = @BgBudgetID AND BgKategorieCode = 2 AND BPO.BgSpezkontoID IS NULL
    WHERE SPP.BgFinanzplanID = @BgFinanzplanID AND SPP.IstUnterstuetzt = 1 AND SZM.FaLeistungID = @FaLeistungID
      AND SZM.BgZahlungsmodusID = (SELECT TOP 1 BgZahlungsmodusID FROM dbo.BgZahlungsmodus WITH (READUNCOMMITTED) 
                                   WHERE FaLeistungID = @FaLeistungID AND BaZahlungswegID = SZM.BaZahlungswegID AND IsNull(ReferenzNummer, '') = IsNull(SPP.ReferenzNummer, '')
                                     AND DatumVon <= @BewilligtAb AND (DatumBis >= @BewilligtAb OR DatumBis IS NULL)
                                   ORDER BY BgZahlungsmodusID DESC)
      AND NOT EXISTS (SELECT 1 FROM dbo.BgAuszahlungPerson WITH (READUNCOMMITTED) WHERE BgPositionID = BPO.BgPositionID)

  -- Spezialkonto
  DECLARE @BgSpezkontoID  int

  DECLARE cShSpezkonto CURSOR FAST_FORWARD FOR
    SELECT BgSpezkontoID
    FROM dbo.BgFinanzplan         SFP WITH (READUNCOMMITTED) 
      INNER JOIN dbo.BgSpezkonto  SSK WITH (READUNCOMMITTED) ON SSK.FaLeistungID = SFP.FaLeistungID
    WHERE SFP.BgFinanzplanID = @BgFinanzplanID

  OPEN cShSpezkonto
  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM cShSpezkonto INTO @BgSpezkontoID
    IF @@FETCH_STATUS < 0 BREAK

    EXECUTE spAySpezkonto_UpdateBudget @BgSpezkontoID, @BgFinanzplanID
  END
  CLOSE cShSpezkonto
  DEALLOCATE cShSpezkonto
END
GO