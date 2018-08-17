SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhBgUebersicht
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spWhBgUebersicht.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:15 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spWhBgUebersicht.sql $
 * 
 * 2     25.06.09 8:51 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spWhBgUebersicht
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:55
*/
CREATE PROCEDURE dbo.spWhBgUebersicht
 (@BgBudgetID int)
AS BEGIN
  DECLARE @GetDate  datetime
  SET @GetDate = GetDate()

  DECLARE @FinanzPlan TABLE (
    BgKategorieCode    int NOT NULL,
    Bezeichnung       varchar(500),
    BetragFinanzplan  money,
    BgGruppeCode varchar(20),
    Info              varchar(1000)
  )

  INSERT INTO @FinanzPlan
  SELECT BgKategorieCode,
		 Bezeichnung,
		 Betrag,
		 BgGruppeCode,
         Info
  FROM dbo.fnWhGetFinanzplan(@BgBudgetID, @GetDate)

  DECLARE @tmp TABLE (
    Style             int,
    Bezeichnung       varchar(500),
    Betrag            money,
    BgGruppeCode varchar(20),
    Info              varchar(1000)
  )

-- Einkommen
  INSERT INTO @tmp (Style, Bezeichnung) VALUES (1, 'Einkommen')

  INSERT INTO @tmp (Bezeichnung, Betrag, BgGruppeCode, Info)
    SELECT Bezeichnung, BetragFinanzplan, BgGruppeCode, Info
    FROM @FinanzPlan
    WHERE BgKategorieCode = 1

  INSERT INTO @tmp (Style, Bezeichnung, Betrag)
    SELECT 2, 'Total Einkommen', SUM(BetragFinanzplan)
    FROM @FinanzPlan
    WHERE BgKategorieCode = 1

  INSERT INTO @tmp (Style, Bezeichnung) VALUES (0, '')

-- Ausgaben
  INSERT INTO @tmp (Style, Bezeichnung) VALUES (1, 'Ausgaben')

  INSERT INTO @tmp (Bezeichnung, Betrag, BgGruppeCode, Info)
    SELECT Bezeichnung, BetragFinanzplan, BgGruppeCode, Info
    FROM @FinanzPlan
    WHERE BgKategorieCode = 2

  INSERT INTO @tmp (Style, Bezeichnung, Betrag)
    SELECT 2, 'Total Ausgaben', SUM(BetragFinanzplan)
    FROM @FinanzPlan
    WHERE BgKategorieCode = 2

  INSERT INTO @tmp (Style, Bezeichnung) VALUES (0, '')

-- Kürzung
  INSERT INTO @tmp (Style, Bezeichnung) VALUES (1, 'Kürzung')

  INSERT INTO @tmp (Bezeichnung, Betrag, BgGruppeCode, Info)
    SELECT Bezeichnung, BetragFinanzplan, BgGruppeCode, Info
    FROM @FinanzPlan
    WHERE BgKategorieCode = 4

  INSERT INTO @tmp (Style, Bezeichnung, Betrag)
    SELECT 2, 'Total Kürzungen', SUM(BetragFinanzplan)
    FROM @FinanzPlan
    WHERE BgKategorieCode = 4

  INSERT INTO @tmp (Style, Bezeichnung) VALUES (0, '')

-- Differenz
  INSERT INTO @tmp (Style, Bezeichnung) VALUES (1, 'Differenz')

  DECLARE @Betrag  money
  SELECT @Betrag = SUM(CASE BgKategorieCode
                         WHEN 1 THEN BetragFinanzplan
                         WHEN 2 THEN 0 - BetragFinanzplan
                         WHEN 4 THEN BetragFinanzplan
                       END)
    FROM @FinanzPlan

  INSERT INTO @tmp (Style, Bezeichnung, Betrag)
    SELECT 2, CASE WHEN @Betrag < 0 THEN 'Fehlbetrag' ELSE 'Überschuss' END, ABS(@Betrag)

-- Output
  UPDATE @tmp
    SET Bezeichnung = CASE Style
                        WHEN 1 THEN ''
                        WHEN 2 THEN '  '
                        ELSE        '    '
                      END + Bezeichnung

  SELECT Style,
         Bezeichnung,
         Betrag = round(Betrag/0.05,0)* 0.05,  -- Runden auf 5 Rp.
         BgGruppeCode,
         Info
  FROM   @tmp
END
GO