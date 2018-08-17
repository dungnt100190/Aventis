SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spReportWhMonatsbudgetGemeinde2013;
GO
/*===============================================================================================
  $Revision: 17$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Listet alle Positionen eines Monatsbudgets auf. Monatsbudget Version von den Gemeinden.
    @BgBudgetID: Das darzustellende Monatsbudget
    @LanguageCode: Sprache für die Titelzellen. z.B. 1 für DE.
  -
  RETURNS: Eine Tabelle mit allen Positionen eines Monatsbudgets.
=================================================================================================
  TEST:    EXEC dbo.spReportWhMonatsbudgetGemeinde2013 2137, 2;
=================================================================================================*/

CREATE PROCEDURE dbo.spReportWhMonatsbudgetGemeinde2013
(
  @BgBudgetID INT,
  @GBL MONEY,
  @LanguageCode INT
)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- start call
  -----------------------------------------------------------------------------
  SET NOCOUNT ON;

  --------------------------------------------
  -- Haushalt/Unterstützungseinheit ermitteln
  --------------------------------------------
  DECLARE @UnterstuetztePersonen TABLE (
    BaPersonID INT
  );

  INSERT INTO @UnterstuetztePersonen (BaPersonID)
  SELECT BFB.BaPersonID
  FROM dbo.BgBudget                       BDG WITH (READUNCOMMITTED)
    INNER JOIN dbo.BgFinanzplan           FPL WITH (READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
    INNER JOIN dbo.BgFinanzplan_BaPerson  BFB WITH (READUNCOMMITTED) ON BFB.BgFinanzplanID = FPL.BgFinanzplanID
  WHERE BDG.BgBudgetID = @BgBudgetID
    AND BFB.IstUnterstuetzt = 1;

  DECLARE @UE INT;
  DECLARE @HG INT;
  DECLARE @BgFinanzplanID INT;
  DECLARE @NameVornameKlient VARCHAR(MAX);
  DECLARE @RefDate DATETIME;

  SELECT  @UE                = SUM(CONVERT(INT, BFB.IstUnterstuetzt)),
          @HG                = SUM(1), 
          @BgFinanzplanID    = MIN(FPL.BgFinanzplanID),
          @NameVornameKlient = MIN(PRS.NameVorname),
          @RefDate           = MIN(dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1))
  FROM dbo.BgBudget                       BDG WITH (READUNCOMMITTED)
    INNER JOIN dbo.BgFinanzplan           FPL WITH (READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
    INNER JOIN dbo.BgFinanzplan_BaPerson  BFB WITH (READUNCOMMITTED) ON BFB.BgFinanzplanID = FPL.BgFinanzplanID
    INNER JOIN dbo.FaLeistung             LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = FPL.FaLeistungID
    INNER JOIN dbo.vwPerson               PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
  WHERE BDG.BgBudgetID = @BgBudgetID;
  
  --------------------------------------------
  -- Init Vars
  --------------------------------------------
  DECLARE @MaskName VARCHAR(MAX);
  SET @MaskName = 'ShMonatsbudgetGemeinde2013';
  
  DECLARE @GroupHeader_Ausgaben VARCHAR(MAX);
  DECLARE @GroupHeader_MaterielleGrundsicherung VARCHAR(MAX);
  DECLARE @GroupHeader_SituationsbedingteLeistungen VARCHAR(MAX);
  DECLARE @GroupHeader_ZulagenEfb VARCHAR(MAX);
  DECLARE @GroupHeader_Einnahmen VARCHAR(MAX);
  DECLARE @GroupHeader_AnzurechendeAbzuege VARCHAR(MAX);

  DECLARE @GroupFooter_Ausgaben VARCHAR(MAX);
  DECLARE @GroupFooter_MaterielleGrundsicherung VARCHAR(MAX);
  DECLARE @GroupFooter_SituationsbedingteLeistungen VARCHAR(MAX);
  DECLARE @GroupFooter_ZulagenEfb VARCHAR(MAX);
  DECLARE @GroupFooter_Einnahmen VARCHAR(MAX);
  DECLARE @GroupFooter_AnzurechendeAbzuege VARCHAR(MAX);
  DECLARE @GroupFooter_Fehlbetrag VARCHAR(MAX);
  DECLARE @GroupFooter_AuszahlungAnKlient VARCHAR(MAX);
  
  DECLARE @Ausgaben_MaterielleGrundversicherung_Grundbedarf VARCHAR(MAX);
  DECLARE @Ausgaben_MaterielleGrundversicherung_AnpassungGrundbedarf VARCHAR(MAX);
  DECLARE @Ausgaben_MaterielleGrundversicherung_KuerzungSanktion VARCHAR(MAX);
  DECLARE @Ausgaben_MaterielleGrundversicherung_Wohnkosten VARCHAR(MAX);
  DECLARE @Ausgaben_MaterielleGrundversicherung_KuerzungMiete VARCHAR(MAX);
  DECLARE @Ausgaben_MaterielleGrundversicherung_Nebenkosten VARCHAR(MAX);
  DECLARE @Ausgaben_MaterielleGrundversicherung_KuerzungNebenkosten VARCHAR(MAX);
  DECLARE @Ausgaben_MaterielleGrundversicherung_TotalKvg VARCHAR(MAX);
  DECLARE @Ausgaben_MaterielleGrundversicherung_KuerzungKvg VARCHAR(MAX);
  DECLARE @Ausgaben_MaterielleGrundversicherung_TotalVvg VARCHAR(MAX);
  DECLARE @Ausgaben_MaterielleGrundversicherung_KuerzungVvg VARCHAR(MAX);
  DECLARE @Ausgaben_MaterielleGrundversicherung_AuszahlungSpezkonto VARCHAR(MAX);
  
  DECLARE @TextBudget VARCHAR(MAX);
  DECLARE @TextKlient VARCHAR(MAX);
  DECLARE @TextDritteSD VARCHAR(MAX);
  DECLARE @TextDirektausgaben VARCHAR(MAX);
  DECLARE @TextDirekteinnahmen VARCHAR(MAX);
  
  SELECT @GroupHeader_Ausgaben = dbo.fnGetMLTextFromName(@MaskName, 'GroupHeader_Ausgaben', @LanguageCode);
  SELECT @GroupHeader_MaterielleGrundsicherung = dbo.fnGetMLTextFromName(@MaskName, 'GroupHeader_MaterielleGrungsicherung', @LanguageCode);
  SELECT @GroupHeader_SituationsbedingteLeistungen = dbo.fnGetMLTextFromName(@MaskName, 'GroupHeader_SituationsbedingteLeistungen', @LanguageCode);
  SELECT @GroupHeader_ZulagenEfb = dbo.fnGetMLTextFromName(@MaskName, 'GroupHeader_ZulagenEfb', @LanguageCode);
  SELECT @GroupHeader_Einnahmen = dbo.fnGetMLTextFromName(@MaskName, 'GroupHeader_Einnahmen', @LanguageCode);
  SELECT @GroupHeader_AnzurechendeAbzuege = dbo.fnGetMLTextFromName(@MaskName, 'GroupHeader_AnzurechendeAbzuege', @LanguageCode);

  SELECT @GroupFooter_Ausgaben = dbo.fnGetMLTextFromName(@MaskName, 'GroupFooter_Ausgaben', @LanguageCode);
  SELECT @GroupFooter_MaterielleGrundsicherung = dbo.fnGetMLTextFromName(@MaskName, 'GroupFooter_MaterielleGrundsicherung', @LanguageCode);
  SELECT @GroupFooter_SituationsbedingteLeistungen = dbo.fnGetMLTextFromName(@MaskName, 'GroupFooter_SituationsbedingteLeistungen', @LanguageCode);
  SELECT @GroupFooter_ZulagenEfb = dbo.fnGetMLTextFromName(@MaskName, 'GroupFooter_ZulagenEfb', @LanguageCode);
  SELECT @GroupFooter_Einnahmen = dbo.fnGetMLTextFromName(@MaskName, 'GroupFooter_Einnahmen', @LanguageCode);
  SELECT @GroupFooter_AnzurechendeAbzuege = dbo.fnGetMLTextFromName(@MaskName, 'GroupFooter_AnzurechendeAbzuege', @LanguageCode);
  SELECT @GroupFooter_Fehlbetrag = dbo.fnGetMLTextFromName(@MaskName, 'GroupFooter_Fehlbetrag', @LanguageCode);
  SELECT @GroupFooter_AuszahlungAnKlient = dbo.fnGetMLTextFromName(@MaskName, 'GroupFooter_AuszahlungAnKlient', @LanguageCode);
  
  SELECT @Ausgaben_MaterielleGrundversicherung_Grundbedarf = dbo.fnGetMLTextFromName(@MaskName, 'Ausgaben_MaterielleGrundversicherung_Grundbedarf', @LanguageCode);
  SELECT @Ausgaben_MaterielleGrundversicherung_AnpassungGrundbedarf = dbo.fnGetMLTextFromName(@MaskName, 'Ausgaben_MaterielleGrundversicherung_AnpassungGrundbedarf', @LanguageCode);
  SELECT @Ausgaben_MaterielleGrundversicherung_KuerzungSanktion = dbo.fnGetMLTextFromName(@MaskName, 'Ausgaben_MaterielleGrundversicherung_KuerzungSanktion', @LanguageCode);
  SELECT @Ausgaben_MaterielleGrundversicherung_Wohnkosten = dbo.fnGetMLTextFromName(@MaskName, 'Ausgaben_MaterielleGrundversicherung_Wohnkosten', @LanguageCode);
  SELECT @Ausgaben_MaterielleGrundversicherung_KuerzungMiete = dbo.fnGetMLTextFromName(@MaskName, 'Ausgaben_MaterielleGrundversicherung_KuerzungMiete', @LanguageCode);
  SELECT @Ausgaben_MaterielleGrundversicherung_Nebenkosten = dbo.fnGetMLTextFromName(@MaskName, 'Ausgaben_MaterielleGrundversicherung_Nebenkosten', @LanguageCode);
  SELECT @Ausgaben_MaterielleGrundversicherung_KuerzungNebenkosten = dbo.fnGetMLTextFromName(@MaskName, 'Ausgaben_MaterielleGrundversicherung_KuerzungNebenkosten', @LanguageCode);
  SELECT @Ausgaben_MaterielleGrundversicherung_TotalKvg = dbo.fnGetMLTextFromName(@MaskName, 'Ausgaben_MaterielleGrundversicherung_TotalKvg', @LanguageCode);
  SELECT @Ausgaben_MaterielleGrundversicherung_KuerzungKvg = dbo.fnGetMLTextFromName(@MaskName, 'Ausgaben_MaterielleGrundversicherung_KuerzungKvg', @LanguageCode);
  SELECT @Ausgaben_MaterielleGrundversicherung_TotalVvg = dbo.fnGetMLTextFromName(@MaskName, 'Ausgaben_MaterielleGrundversicherung_TotalVvg', @LanguageCode);
  SELECT @Ausgaben_MaterielleGrundversicherung_KuerzungVvg = dbo.fnGetMLTextFromName(@MaskName, 'Ausgaben_MaterielleGrundversicherung_KuerzungVvg', @LanguageCode);
  SELECT @Ausgaben_MaterielleGrundversicherung_AuszahlungSpezkonto = dbo.fnGetMLTextFromName(@MaskName, 'Ausgaben_MaterielleGrundversicherung_AuszahlungSpezkonto', @LanguageCode);

  SELECT @TextBudget = dbo.fnGetMLTextFromName(@MaskName, 'TextBudget', @LanguageCode);
  SELECT @TextKlient = dbo.fnGetMLTextFromName(@MaskName, 'TextKlient', @LanguageCode);
  SELECT @TextDritteSD = dbo.fnGetMLTextFromName(@MaskName, 'TextDritteSD', @LanguageCode);
  SELECT @TextDirektausgaben = dbo.fnGetMLTextFromName(@MaskName, 'TextDirektausgaben', @LanguageCode);
  SELECT @TextDirekteinnahmen = dbo.fnGetMLTextFromName(@MaskName, 'TextDirekteinnahmen', @LanguageCode);

  -- Temporäre Tabelle für die Positionen
  DECLARE @Positionen TABLE (
    BgPositionID           INT,
    BgPositionID_Parent    INT,
    BaPersonID             INT,
    BgPositionsartCode     INT,
    BgPositionsartID       INT,
    BgGruppeCode           INT,
    BgSpezkontoID          INT,
    BgBudgetID             INT,
    BgFinanzplanID         INT,
    BgKategorieCode        INT,
    Buchungstext           VARCHAR(MAX),
    VerwaltungSD           BIT,
    BetragPosition         MONEY,
    BetragBudget           MONEY,
    BetragFinanzplan       MONEY,
    BetragRechnung         MONEY,
    BetragReduktion        MONEY,
    BetragAbzug            MONEY,
    BgSpezkontoTypCode     INT,
                           
    SortKey3               INT, -- Gruppe 3
    SortKey2               INT, -- Gruppe 2
    SortKey1               INT, -- Gruppe 1
    SortKey0               INT, -- Detail
    GroupBy                INT,
    GroupHeader2           VARCHAR(MAX),
    GroupHeader1           VARCHAR(MAX),
    [Text]                 VARCHAR(MAX),
    GroupFooter1           VARCHAR(MAX),
    GroupFooter2           VARCHAR(MAX),
    GroupFooter3           VARCHAR(MAX),
                           
    Betrag                 MONEY,  
    AnKlient               BIT,
    AnDritte               BIT,
    ShowBetragPositiv      BIT,
    HideSumBetragDisplay   BIT,
    HideBetragDisplaySD    BIT,
    AddPageBreakAfterGroup BIT
  );


  --------------------------------------------
  ---- Positionen aus Monatsbudget übernehmen
  --------------------------------------------
  INSERT INTO @Positionen (BgPositionID, BgPositionID_Parent, BaPersonID, BgPositionsartCode, BgPositionsartID, BgGruppeCode, BgSpezkontoID, BgBudgetID, BgFinanzplanID, 
                           BgKategorieCode, Buchungstext, VerwaltungSD, BetragPosition, BetragBudget, BetragFinanzplan, BetragRechnung, BetragReduktion, BetragAbzug, 
                           BgSpezkontoTypCode)
    SELECT 
      POS.BgPositionID,
      POS.BgPositionID_Parent,
      POS.BaPersonID, 
      POA.BgPositionsartCode, 
      POS.BgPositionsartID, 
      POA.BgGruppeCode, 
      POS.BgSpezkontoID, 
      POS.BgBudgetID,
      BDG.BgFinanzplanID,
      POS.BgKategorieCode, 
      Buchungstext = COALESCE(POS.Buchungstext, POA.Name, SPK.NameSpezkonto), 
      POS.VerwaltungSD,
      BetragPosition = POS.Betrag, 
      POS.BetragBudget, 
      POS.BetragFinanzplan, 
      POS.BetragRechnung, 
      BetragReduktion = POS.Reduktion, 
      BetragAbzug = POS.Abzug,
      SPK.BgSpezkontoTypCode
    FROM dbo.vwBgPosition           POS WITH (READUNCOMMITTED)
      INNER JOIN dbo.BgBudget       BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = POS.BgBudgetID
      LEFT  JOIN dbo.BgSpezkonto    SPK WITH (READUNCOMMITTED) ON SPK.BgSpezkontoID = POS.BgSpezkontoID
      LEFT  JOIN dbo.BgPositionsart POA WITH (READUNCOMMITTED) ON POA.BgPositionsartID = ISNULL(POS.BgPositionsartID, SPK.BgPositionsartID)
      LEFT  JOIN (SELECT 
                    BUC.BgBudgetID, 
                    BUK.BgPositionID, 
                    StatusCode = MAX(BUC.KbBuchungStatusCode)
                  FROM   KbBuchungKostenart BUK 
                         LEFT JOIN KbBuchung BUC ON BUC.KbBuchungID = BUK.KbBuchungID
                  GROUP  BY BUC.BgBudgetID, BUK.BgPositionID) STA ON STA.BgBudgetID = POS.BgBudgetID AND STA.BgPositionID = POS.BgPositionID
    WHERE POS.BgBudgetID = @BgBudgetID
      AND BDG.BgBewilligungStatusCode = 5 --5:Bewilligung erteilt
      AND ISNULL(STA.StatusCode, 2) NOT IN (1, 12, 15, 14, 7);
      
  -----------------------------------
  -- Positionen mit Daten anreichern
  -----------------------------------
  -- AUSGABEN
  -----------------------------------
  -- Materielle Grundsicherung
  -----------------------------------
  -- Grundbedarf
  UPDATE POS
    SET SortKey3     = 1,
        SortKey2     = 1,
        SortKey1     = 1,
        SortKey0     = 1,
        GroupBy      = 1,
        GroupHeader2 = @GroupHeader_Ausgaben,
        GroupHeader1 = @GroupHeader_MaterielleGrundsicherung,
        [Text]       = REPLACE(REPLACE(@Ausgaben_MaterielleGrundversicherung_Grundbedarf, '{0}', @UE), '{1}', @HG),
        GroupFooter1 = @GroupFooter_MaterielleGrundsicherung,
        GroupFooter2 = @GroupFooter_Ausgaben,
        GroupFooter3 = @GroupFooter_Fehlbetrag,
        Betrag       = @GBL,
        AnKlient     = 1,
        AnDritte     = 0
  FROM @Positionen POS
  WHERE POS.BgGruppeCode = 3201; -- Grundbedarf
  
  -- Anpassung des Grundbedarfs
  INSERT INTO @Positionen (BgPositionID, BaPersonID, BgPositionsartCode, BgPositionsartID, BgGruppeCode, BgSpezkontoID, BgBudgetID, BgFinanzplanID, BgKategorieCode, 
                           Buchungstext, VerwaltungSD, BetragPosition, BetragBudget, BetragFinanzplan, BetragRechnung, BetragReduktion, BetragAbzug,
                           SortKey3, SortKey2, SortKey1, SortKey0, GroupBy, GroupHeader2, GroupHeader1, [Text], GroupFooter1, GroupFooter2, GroupFooter3,
                           Betrag, AnKlient, AnDritte)
    SELECT 
      BgPositionID, 
      BaPersonID, 
      BgPositionsartCode, 
      BgPositionsartID, 
      BgGruppeCode, 
      BgSpezkontoID, 
      BgBudgetID, 
      BgFinanzplanID, 
      BgKategorieCode, 
      Buchungstext, 
      VerwaltungSD, 
      BetragPosition, 
      BetragBudget, 
      BetragFinanzplan, 
      BetragRechnung, 
      BetragReduktion, 
      BetragAbzug,
      SortKey3     = 1, 
      SortKey2     = 1, 
      SortKey1     = 1, 
      SortKey0     = 2, 
      GroupBy      = 1,
      GroupHeader2 = @GroupHeader_Ausgaben, 
      GroupHeader1 = @GroupHeader_MaterielleGrundsicherung, 
      [Text]       = @Ausgaben_MaterielleGrundversicherung_AnpassungGrundbedarf, 
      GroupFooter1 = @GroupFooter_MaterielleGrundsicherung, 
      GroupFooter2 = @GroupFooter_Ausgaben, 
      GroupFooter3 = @GroupFooter_Fehlbetrag,
      Betrag       = - POS.BetragReduktion, 
      AnKlient     = 1, 
      AnDritte     = 0
    FROM @Positionen POS
    WHERE POS.BgGruppeCode = 3201 -- Grundbedarf
      AND POS.BetragReduktion <> 0;
  
  -- Kürzung / Sanktion des Grundbedarfs
  UPDATE POS
    SET SortKey3     = 1, 
        SortKey2     = 1, 
        SortKey1     = 1, 
        SortKey0     = 3, 
        GroupBy      = POS.BaPersonID,
        GroupHeader2 = @GroupHeader_Ausgaben, 
        GroupHeader1 = @GroupHeader_MaterielleGrundsicherung, 
        [Text]       = REPLACE(@Ausgaben_MaterielleGrundversicherung_KuerzungSanktion, '{0}', PRS.NameVorname), 
        GroupFooter1 = @GroupFooter_MaterielleGrundsicherung, 
        GroupFooter2 = @GroupFooter_Ausgaben, 
        GroupFooter3 = @GroupFooter_Fehlbetrag,
        Betrag       = - POS.BetragPosition, 
        AnKlient     = 1, 
        AnDritte     = 0
  FROM @Positionen POS
    LEFT JOIN dbo.vwPersonSimple PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = POS.BaPersonID
  WHERE POS.BgKategorieCode = 4;
  
  -- Wohnungskosten
  UPDATE POS
    SET SortKey3     = 1, 
        SortKey2     = 1, 
        SortKey1     = 1, 
        SortKey0     = 4, 
        GroupBy      = 1,
        GroupHeader2 = @GroupHeader_Ausgaben, 
        GroupHeader1 = @GroupHeader_MaterielleGrundsicherung, 
        [Text]       = @Ausgaben_MaterielleGrundversicherung_Wohnkosten, 
        GroupFooter1 = @GroupFooter_MaterielleGrundsicherung, 
        GroupFooter2 = @GroupFooter_Ausgaben, 
        GroupFooter3 = @GroupFooter_Fehlbetrag,
        Betrag       = POS.BetragRechnung
  FROM @Positionen POS
  WHERE POS.BgGruppeCode = 3206 -- Wohnkosten
    AND POS.BgPositionsartCode <> 32060;
  
  -- Kürzung Miete
  INSERT INTO @Positionen (BgPositionID, BaPersonID, BgPositionsartCode, BgPositionsartID, BgGruppeCode, BgSpezkontoID, BgBudgetID, BgFinanzplanID, BgKategorieCode, 
                           Buchungstext, VerwaltungSD, BetragPosition, BetragBudget, BetragFinanzplan, BetragRechnung, BetragReduktion, BetragAbzug,
                           SortKey3, SortKey2, SortKey1, SortKey0, GroupBy, GroupHeader2, GroupHeader1, [Text], GroupFooter1, GroupFooter2, GroupFooter3,
                           Betrag, AnKlient, AnDritte)
    SELECT 
      BgPositionID, 
      BaPersonID, 
      BgPositionsartCode, 
      BgPositionsartID, 
      BgGruppeCode, 
      BgSpezkontoID, 
      BgBudgetID, 
      BgFinanzplanID, 
      BgKategorieCode, 
      Buchungstext, 
      VerwaltungSD, 
      BetragPosition, 
      BetragBudget, 
      BetragFinanzplan, 
      BetragRechnung, 
      BetragReduktion, 
      BetragAbzug,
      SortKey3     = 1, 
      SortKey2     = 1, 
      SortKey1     = 1, 
      SortKey0     = 5, 
      GroupBy      = POS.BaPersonID,
      GroupHeader2 = @GroupHeader_Ausgaben, 
      GroupHeader1 = @GroupHeader_MaterielleGrundsicherung, 
      [Text]       = @Ausgaben_MaterielleGrundversicherung_KuerzungMiete, 
      GroupFooter1 = @GroupFooter_MaterielleGrundsicherung, 
      GroupFooter2 = @GroupFooter_Ausgaben, 
      GroupFooter3 = @GroupFooter_Fehlbetrag,
      Betrag       = POS.BetragBudget - POS.BetragRechnung,
      AnKlient     = 1,
      AnDritte     = 0
  FROM @Positionen POS
  WHERE POS.BgGruppeCode = 3206 -- Wohnkosten
    AND POS.BgPositionsartCode <> 32060
    AND POS.BetragBudget - POS.BetragRechnung < 0;
  
  -- Nebenkosten
  UPDATE POS
    SET SortKey3     = 1, 
        SortKey2     = 1, 
        SortKey1     = 1, 
        SortKey0     = 6, 
        GroupBy      = 1,
        GroupHeader2 = @GroupHeader_Ausgaben, 
        GroupHeader1 = @GroupHeader_MaterielleGrundsicherung, 
        [Text]       = @Ausgaben_MaterielleGrundversicherung_Nebenkosten, 
        GroupFooter1 = @GroupFooter_MaterielleGrundsicherung, 
        GroupFooter2 = @GroupFooter_Ausgaben, 
        GroupFooter3 = @GroupFooter_Fehlbetrag,
        Betrag       = POS.BetragRechnung
  FROM @Positionen POS
  WHERE POS.BgGruppeCode = 3206 -- Wohnkosten
    AND POS.BgPositionsartCode = 32060;
  
  -- Kürzung Nebenkosten
  INSERT INTO @Positionen (BgPositionID, BaPersonID, BgPositionsartCode, BgPositionsartID, BgGruppeCode, BgSpezkontoID, BgBudgetID, BgFinanzplanID, BgKategorieCode, 
                           Buchungstext, VerwaltungSD, BetragPosition, BetragBudget, BetragFinanzplan, BetragRechnung, BetragReduktion, BetragAbzug,
                           SortKey3, SortKey2, SortKey1, SortKey0, GroupBy, GroupHeader2, GroupHeader1, [Text], GroupFooter1, GroupFooter2, GroupFooter3,
                           Betrag, AnKlient, AnDritte)
    SELECT 
      BgPositionID, 
      BaPersonID, 
      BgPositionsartCode, 
      BgPositionsartID, 
      BgGruppeCode, 
      BgSpezkontoID, 
      BgBudgetID, 
      BgFinanzplanID, 
      BgKategorieCode, 
      Buchungstext, 
      VerwaltungSD, 
      BetragPosition, 
      BetragBudget, 
      BetragFinanzplan, 
      BetragRechnung, 
      BetragReduktion, 
      BetragAbzug,
      SortKey3     = 1, 
      SortKey2     = 1, 
      SortKey1     = 1, 
      SortKey0     = 7, 
      GroupBy      = POS.BaPersonID,
      GroupHeader2 = @GroupHeader_Ausgaben, 
      GroupHeader1 = @GroupHeader_MaterielleGrundsicherung, 
      [Text]       = @Ausgaben_MaterielleGrundversicherung_KuerzungNebenkosten, 
      GroupFooter1 = @GroupFooter_MaterielleGrundsicherung, 
      GroupFooter2 = @GroupFooter_Ausgaben, 
      GroupFooter3 = @GroupFooter_Fehlbetrag,
      Betrag       = POS.BetragBudget - POS.BetragRechnung,
      AnKlient     = 1,
      AnDritte     = 0
  FROM @Positionen POS
  WHERE POS.BgGruppeCode = 3206 -- Wohnkosten
    AND POS.BgPositionsartCode = 32060
    AND POS.BetragBudget - POS.BetragRechnung < 0;
    
  -- Total KVG
  UPDATE POS
    SET SortKey3     = 1, 
        SortKey2     = 1, 
        SortKey1     = 1, 
        SortKey0     = 8, 
        GroupBy      = 1,
        GroupHeader2 = @GroupHeader_Ausgaben, 
        GroupHeader1 = @GroupHeader_MaterielleGrundsicherung, 
        [Text]       = REPLACE(@Ausgaben_MaterielleGrundversicherung_TotalKvg, '{0}', @UE), 
        GroupFooter1 = @GroupFooter_MaterielleGrundsicherung, 
        GroupFooter2 = @GroupFooter_Ausgaben, 
        GroupFooter3 = @GroupFooter_Fehlbetrag,
        Betrag       = POS.BetragPosition - ISNULL(POS.BetragReduktion,0) + ISNULL(POS1.BetragPosition, 0)
  FROM @Positionen POS
    LEFT JOIN @Positionen POS1 ON POS1.BgPositionID_Parent = POS.BgPositionID AND POS1.BgPositionsartCode IN (32023) -- KVG-GBL
  WHERE (POS.BgPositionsartCode IN (32020, 32024) OR POS.BgPositionsartCode BETWEEN 32121 AND 32130)
    AND POS.BgKategorieCode = 2;

  -- Kürzung KVG
  UPDATE POS
    SET SortKey3     = 1, 
        SortKey2     = 1, 
        SortKey1     = 1, 
        SortKey0     = 9, 
        GroupBy      = 1,
        GroupHeader2 = @GroupHeader_Ausgaben, 
        GroupHeader1 = @GroupHeader_MaterielleGrundsicherung, 
        [Text]       = @Ausgaben_MaterielleGrundversicherung_KuerzungKvg, 
        GroupFooter1 = @GroupFooter_MaterielleGrundsicherung, 
        GroupFooter2 = @GroupFooter_Ausgaben, 
        GroupFooter3 = @GroupFooter_Fehlbetrag,
        Betrag       = -POS.BetragPosition ,
        AnKlient     = 1,
        AnDritte     = 0
  FROM @Positionen POS
  WHERE POS.BgPositionsartCode IN (32023) -- KVG-GBL nicht vom SD übernommen
    AND POS.BgKategorieCode = 2;

  -- Total VVG
  UPDATE POS
    SET SortKey3     = 1, 
        SortKey2     = 1, 
        SortKey1     = 1, 
        SortKey0     = 10, 
        GroupBy      = 1,
        GroupHeader2 = @GroupHeader_Ausgaben, 
        GroupHeader1 = @GroupHeader_MaterielleGrundsicherung, 
        [Text]       = @Ausgaben_MaterielleGrundversicherung_TotalVvg, 
        GroupFooter1 = @GroupFooter_MaterielleGrundsicherung, 
        GroupFooter2 = @GroupFooter_Ausgaben, 
        GroupFooter3 = @GroupFooter_Fehlbetrag,
        Betrag       = POS.BetragPosition - ISNULL(POS.BetragReduktion,0)
  FROM @Positionen POS
  WHERE POS.BgPositionsartCode IN (32022) -- VVG
    AND POS.BgKategorieCode = 2;
    
  -- Kürzung VVG
  UPDATE POS
    SET SortKey3     = 1, 
        SortKey2     = 1, 
        SortKey1     = 1, 
        SortKey0     = 11, 
        GroupBy      = 1,
        GroupHeader2 = @GroupHeader_Ausgaben, 
        GroupHeader1 = @GroupHeader_MaterielleGrundsicherung, 
        [Text]       = @Ausgaben_MaterielleGrundversicherung_KuerzungVvg, 
        GroupFooter1 = @GroupFooter_MaterielleGrundsicherung, 
        GroupFooter2 = @GroupFooter_Ausgaben, 
        GroupFooter3 = @GroupFooter_Fehlbetrag,
        Betrag       = -(POS.BetragPosition - ISNULL(POS.BetragReduktion,0)),
        AnKlient     = 1,
        AnDritte     = 0
  FROM @Positionen POS
  WHERE POS.BgPositionsartCode IN (32021) -- VVG nicht vom SD übernommen
    AND POS.BgKategorieCode = 2;

  -- Sicherstellen, dass es eine "Total VVG" Zeile gibt
  INSERT INTO @Positionen (BgPositionID, BaPersonID, BgPositionsartCode, BgPositionsartID, BgGruppeCode, BgSpezkontoID, BgBudgetID, BgFinanzplanID, BgKategorieCode, 
                       Buchungstext, VerwaltungSD, BetragPosition, BetragBudget, BetragFinanzplan, BetragRechnung, BetragReduktion, BetragAbzug,
                       SortKey3, SortKey2, SortKey1, SortKey0, GroupBy, GroupHeader2, GroupHeader1, [Text], GroupFooter1, GroupFooter2, GroupFooter3,
                       Betrag, AnKlient, AnDritte)
    SELECT 
      BgPositionID, 
      BaPersonID, 
      BgPositionsartCode, 
      BgPositionsartID, 
      BgGruppeCode, 
      BgSpezkontoID, 
      BgBudgetID, 
      BgFinanzplanID, 
      BgKategorieCode, 
      Buchungstext, 
      VerwaltungSD, 
      BetragPosition, 
      BetragBudget, 
      BetragFinanzplan, 
      BetragRechnung, 
      BetragReduktion, 
      BetragAbzug,
      SortKey3     = 1, 
      SortKey2     = 1, 
      SortKey1     = 1, 
      SortKey0     = 10, 
      GroupBy      = 1,
      GroupHeader2 = @GroupHeader_Ausgaben, 
      GroupHeader1 = @GroupHeader_MaterielleGrundsicherung, 
      [Text]       = @Ausgaben_MaterielleGrundversicherung_TotalVvg, 
      GroupFooter1 = @GroupFooter_MaterielleGrundsicherung, 
      GroupFooter2 = @GroupFooter_Ausgaben, 
      GroupFooter3 = @GroupFooter_Fehlbetrag,
      Betrag       = POS.BetragPosition - ISNULL(POS.BetragReduktion,0),
      AnKlient     = NULL, --wird später anhand des Zahlwegs gesetzt
      AnDritte     = NULL --wird später anhand des Zahlwegs gesetzt
  FROM @Positionen POS
  WHERE POS.BgPositionsartCode = 32021
  AND NOT EXISTS (SELECT TOP 1 1 
                  FROM @Positionen 
                  WHERE BgPositionsartCode = 32022
                    AND BaPersonID = POS.BaPersonID)

  -- Auszahlung aus Spezkonto
  UPDATE POS
    SET SortKey3     = 1, 
        SortKey2     = 1, 
        SortKey1     = 1, 
        SortKey0     = 12, 
        GroupBy      = POS.BgSpezkontoID,
        GroupHeader2 = @GroupHeader_Ausgaben, 
        GroupHeader1 = @GroupHeader_MaterielleGrundsicherung, 
        [Text]       = REPLACE(@Ausgaben_MaterielleGrundversicherung_AuszahlungSpezkonto, '{0}', SPK.NameSpezkonto), 
        GroupFooter1 = @GroupFooter_MaterielleGrundsicherung, 
        GroupFooter2 = @GroupFooter_Ausgaben, 
        GroupFooter3 = @GroupFooter_Fehlbetrag,
        Betrag       = POS.BetragBudget
  FROM @Positionen POS
    INNER JOIN dbo.BgSpezkonto SPK WITH (READUNCOMMITTED) ON SPK.BgSpezkontoID = POS.BgSpezkontoID
  WHERE POS.BgKategorieCode = 101 -- Einzelzahlung
    AND (POS.BgGruppeCode IS NULL OR NOT POS.BgGruppeCode = 3201) -- Grundbedarf
    AND (POS.BgGruppeCode IS NULL OR NOT POS.BgGruppeCode = 3206) -- Wohnkosten
    AND (POS.BgPositionsartCode IS NULL OR NOT (POS.BgPositionsartCode IN (32020, 32023, 32024) OR POS.BgPositionsartCode BETWEEN 32121 AND 32130)) -- KVG
    AND (POS.BgPositionsartCode IS NULL OR NOT POS.BgPositionsartCode IN (32022, 32021)) -- VVG
    AND (POS.BgGruppeCode IS NULL OR NOT POS.BgGruppeCode BETWEEN 39000 AND 39999) -- Zulagen / EFB
          
  -----------------------------------
  -- Situationsbedingte Leistungen
  -----------------------------------
  -- Situationsbedingte Leistungen
  UPDATE POS
    SET SortKey3     = 1, 
        SortKey2     = 1, 
        SortKey1     = 2, 
        SortKey0     = 1, 
        GroupBy      = POS.BgPositionID,
        GroupHeader2 = @GroupHeader_Ausgaben, 
        GroupHeader1 = @GroupHeader_SituationsbedingteLeistungen, 
        [Text]       = POS.Buchungstext + ISNULL(' (' + PRS.NameVorname + ')', ''), 
        GroupFooter1 = @GroupFooter_SituationsbedingteLeistungen, 
        GroupFooter2 = @GroupFooter_Ausgaben, 
        GroupFooter3 = @GroupFooter_Fehlbetrag,
        Betrag       = POS.BetragBudget
  FROM @Positionen POS
    LEFT JOIN dbo.vwPersonSimple PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = POS.BaPersonID
  WHERE POS.BgGruppeCode BETWEEN 3901 AND 3905 -- SIL
    AND POS.BgSpezkontoID IS NULL
    AND POS.BgKategorieCode <> 101; -- keine Einzelzahlungen
    
  -- Zusätzliche Leistungen
  UPDATE POS
    SET SortKey3     = 1, 
        SortKey2     = 1, 
        SortKey1     = 2, 
        SortKey0     = 2, 
        GroupBy      = POS.BgPositionID,
        GroupHeader2 = @GroupHeader_Ausgaben, 
        GroupHeader1 = @GroupHeader_SituationsbedingteLeistungen, 
        [Text]       = POS.Buchungstext + ISNULL(' (' + PRS.NameVorname + ')', ''), 
        GroupFooter1 = @GroupFooter_SituationsbedingteLeistungen, 
        GroupFooter2 = @GroupFooter_Ausgaben, 
        GroupFooter3 = @GroupFooter_Fehlbetrag,
        Betrag       = POS.BetragBudget
  FROM @Positionen POS
    LEFT JOIN dbo.vwPersonSimple PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = POS.BaPersonID
  WHERE POS.BgSpezkontoID IS NULL
    AND POS.BgKategorieCode = 100; -- zusätzliche Leistung
  
  -----------------------------------
  -- Zulagen / EFB
  -----------------------------------
  UPDATE POS
    SET SortKey3     = 1, 
        SortKey2     = 1, 
        SortKey1     = 3, 
        SortKey0     = 1, 
        GroupBy      = POS.BgPositionID,
        GroupHeader2 = @GroupHeader_Ausgaben, 
        GroupHeader1 = @GroupHeader_ZulagenEfb, 
        [Text]       = CASE 
                         WHEN POS.BgGruppeCode IN (39100, 39110) THEN 'EFB Erwerbsaufnahme '
                         WHEN POS.BgGruppeCode IN (39120, 39130) THEN 'EFB '
                         WHEN POS.BgGruppeCode IN (39200) THEN 'IZU '
                         ELSE ''
                       END + POS.Buchungstext + ISNULL(' (' + PRS.NameVorname + ')', ''), 
        GroupFooter1 = @GroupFooter_ZulagenEfb, 
        GroupFooter2 = @GroupFooter_Ausgaben, 
        GroupFooter3 = @GroupFooter_Fehlbetrag,
        Betrag       = POS.BetragBudget
  FROM @Positionen POS
    LEFT JOIN dbo.vwPersonSimple PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = POS.BaPersonID
  WHERE POS.BgGruppeCode BETWEEN 39000 AND 39999 -- Zulagen / EFB
    AND POS.BgGruppeCode <> 39090 -- Sanktion
    AND POS.BgSpezkontoID IS NULL;
  
  -----------------------------------
  -- Ausgaben die noch nicht zugewiesen sind unter Situationsbedingte Leistungen anzeigen
  -----------------------------------
  UPDATE POS
    SET SortKey3     = 1, 
        SortKey2     = 1, 
        SortKey1     = 2, 
        SortKey0     = 3, 
        GroupBy      = POS.BgPositionID,
        GroupHeader2 = @GroupHeader_Ausgaben, 
        GroupHeader1 = @GroupHeader_SituationsbedingteLeistungen, 
        [Text]       = POS.Buchungstext + ISNULL(' (' + PRS.NameVorname + ')', ''), 
        GroupFooter1 = @GroupFooter_SituationsbedingteLeistungen, 
        GroupFooter2 = @GroupFooter_Ausgaben, 
        GroupFooter3 = @GroupFooter_Fehlbetrag,
        Betrag       = POS.BetragBudget
  FROM @Positionen POS
    LEFT JOIN dbo.vwPersonSimple PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = POS.BaPersonID
  WHERE POS.BgKategorieCode = 2
    AND POS.Betrag IS NULL
    AND POS.BgSpezkontoID IS NULL;
  
  -----------------------------------
  -- EINNAHMEN
  -----------------------------------
  UPDATE POS
    SET SortKey3               = 1, 
        SortKey2               = 2, 
        SortKey1               = 1, 
        SortKey0               = 1, 
        GroupBy                = POS.BgPositionID,
        GroupHeader2           = @GroupHeader_Einnahmen, 
        GroupHeader1           = '', 
        [Text]                 = POS.Buchungstext + ISNULL(' (' + PRS.NameVorname + ')', ''), 
        GroupFooter1           = '', 
        GroupFooter2           = @GroupFooter_Einnahmen, 
        GroupFooter3           = @GroupFooter_Fehlbetrag,
        Betrag                 = CASE -- den effektiven Betrag anzeigen, falls er vorhanden ist
                                   WHEN EFF.OpBuchungID IS NULL THEN -POS.BetragPosition 
                                   ELSE -EFF.BetragEffektiv 
                                 END,
        AnKlient               = CASE WHEN POS.VerwaltungSD = 0 THEN 1 ELSE 0 END,
        ShowBetragPositiv      = 1
  FROM @Positionen POS
    LEFT JOIN dbo.vwPersonSimple PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = POS.BaPersonID
    LEFT JOIN (SELECT BKO.BgPositionID, 
                      OpBuchungID = MIN(OPA.OpBuchungID), 
                      BetragEffektiv = CASE 
                                         WHEN SUM(BUC.Betrag) = $0.00 THEN $0.00 
                                         ELSE SUM(BKO.Betrag * OPA.Total / (CASE WHEN BUC.Betrag <> 0 THEN BUC.Betrag ELSE 1 END)) 
                                       END
               FROM dbo.KbBuchungKostenart BKO
                 INNER JOIN KbBuchung  BUC ON BUC.KbBuchungID = BKO.KbBuchungID
                 INNER JOIN (SELECT OpBuchungID, Total = SUM(Betrag)
                             FROM KbOpAusgleich
                             GROUP BY OpBuchungID) OPA ON OPA.OpBuchungID = BUC.KbBuchungID
               GROUP BY BKO.BgPositionID) EFF ON EFF.BgPositionID = POS.BgPositionID
  WHERE POS.BgKategorieCode = 1; -- Einnahmen

  -----------------------------------
  -- ANZURECHENDE ABZÜGE
  -----------------------------------
  UPDATE POS
    SET SortKey3             = 2, 
        SortKey2             = 1, 
        SortKey1             = 1, 
        SortKey0             = SPK.BgSpezkontoTypCode, 
        GroupBy              = SPK.BgSpezkontoID,
        GroupHeader2         = @GroupHeader_AnzurechendeAbzuege, 
        GroupHeader1         = '', 
        [Text]               = SPK.NameSpezkonto,
        GroupFooter1         = '', 
        GroupFooter2         = @GroupFooter_AnzurechendeAbzuege, 
        GroupFooter3         = '',
        Betrag               = -POS.BetragBudget,
        AnKlient             = 1,
        ShowBetragPositiv    = 1,
        HideSumBetragDisplay = 1,
        HideBetragDisplaySD  = 1
  FROM @Positionen POS
    INNER JOIN dbo.BgSpezkonto SPK WITH (READUNCOMMITTED) ON SPK.BgSpezkontoID = POS.BgSpezkontoID
  WHERE SPK.BgSpezkontoTypCode IN (2, 3) -- Vorabzugskonti, Abzahlungskonti
    AND POS.BgKategorieCode <> 101; 
  
  ------------------------------------
  -- an Klient und an Dritte wie im Monatsbudget setzen falls es noch nicht definiert ist
  ------------------------------------
  UPDATE POS
    SET POS.AnKlient = CASE
                         WHEN POS.AnKlient IS NOT NULL THEN POS.AnKlient
                         WHEN EXISTS (SELECT TOP 1 1
                                      FROM @UnterstuetztePersonen
                                      WHERE BaPersonID = KRE.BaPersonID) THEN 1
                         WHEN EXISTS (SELECT TOP 1 1
                                      FROM dbo.BgAuszahlungPerson
                                      WHERE BgPositionID = POS.BgPositionID
                                        AND KbAuszahlungsartCode IN (103, 104)) THEN 1  --103: Cash/Barauszahlung oder 104: Check = AnKlient
                         WHEN KRE.BaZahlungswegID IS NULL THEN 0
                         ELSE 0
                       END,
        POS.AnDritte = CASE
                         WHEN POS.AnDritte IS NOT NULL THEN POS.AnDritte
                         WHEN KRE.BaZahlungswegID IS NULL THEN 0
                         WHEN EXISTS (SELECT TOP 1 1
                                      FROM @UnterstuetztePersonen
                                      WHERE BaPersonID = KRE.BaPersonID) THEN 0
                         ELSE 1
                       END
  FROM @Positionen POS
    LEFT  JOIN dbo.BgAuszahlungPerson BAP  ON BAP.BgPositionID = POS.BgPositionID 
                                          AND BAP.BgAuszahlungPersonID = (SELECT TOP 1 BgAuszahlungPersonID
                                                                           FROM dbo.BgAuszahlungPerson
                                                                           WHERE BgPositionID = POS.BgPositionID
                                                                           ORDER BY 
                                                                             CASE WHEN BaPersonID IS NULL THEN 1
                                                                                  WHEN BaPersonID = POS.BaPersonID THEN 2
                                                                                  ELSE 3
                                                                             END)
    LEFT  JOIN dbo.vwKreditor         KRE  ON KRE.BaZahlungswegID = BAP.BaZahlungswegID;
  
  ------------------------------------
  -- Seitenumbruch nach Ausgaben
  ------------------------------------
  UPDATE @Positionen
    SET AddPageBreakAfterGroup = 1
  WHERE GroupHeader2 = @GroupHeader_Ausgaben;

  ------------------------------------
  -- Output
  ------------------------------------
  ;WITH OutputCte AS
  (
    SELECT 
      SortKey3,
      SortKey2,
      SortKey1,
      SortKey0,

      [Text]                 = MIN([Text]),
                             
      Betrag                 = SUM(Betrag),
      BetragKlient           = SUM(CASE WHEN AnKlient = 1 THEN Betrag ELSE 0 END),
      BetragDritte           = SUM(CASE WHEN AnKlient = 0 AND VerwaltungSD = 0 THEN Betrag ELSE 0 END),
      BetragSD               = SUM(CASE WHEN VerwaltungSD = 1 THEN Betrag ELSE 0 END),
      BetragDisplay          = SUM(CASE WHEN ShowBetragPositiv = 1 THEN -Betrag ELSE Betrag END), -- Einnahmen und Abzüge Positiv enzeigen
      BetragAusgaben         = SUM(CASE WHEN AnKlient = 0 AND BgKategorieCode <> 1 THEN Betrag ELSE 0 END),
      BetragEinnahmen        = SUM(CASE WHEN AnKlient = 0 AND BgKategorieCode = 1 THEN -Betrag ELSE 0 END),
                             
      GroupHeader2           = MIN(GroupHeader2),
      GroupHeader1           = MIN(GroupHeader1),
      GroupFooter1           = MIN(GroupFooter1),
      GroupFooter2           = MIN(GroupFooter2),
      GroupFooter3           = MIN(GroupFooter3),
                             
      ShowBetragPositiv      = MIN(CONVERT(INT, ShowBetragPositiv)),
      HideSumBetragDisplay   = MIN(CONVERT(INT, ISNULL(HideSumBetragDisplay, 0))),
      HideBetragDisplaySD    = MIN(CONVERT(INT, ISNULL(HideBetragDisplaySD, 0))),
      AddPageBreakAfterGroup = MIN(CONVERT(INT, ISNULL(AddPageBreakAfterGroup, 0)))
    FROM @Positionen
    WHERE Betrag <> 0
    GROUP BY SortKey3, SortKey2, SortKey1, SortKey0, GroupBy
  )
  
  SELECT
    SortKey3,
    SortKey2,
    SortKey1,
    SortKey0,

    [Text],

    Betrag,
    BetragKlient,
    BetragDritteSD         = BetragDritte + BetragSD,
    BetragDisplay,
    BetragDisplayKlient    = CASE WHEN ShowBetragPositiv = 1 THEN -BetragKlient ELSE BetragKlient END, -- Einnahmen Positiv enzeigen
    BetragDisplayDritteSD  = CASE WHEN ShowBetragPositiv = 1 THEN -(BetragDritte + BetragSD) ELSE BetragDritte + BetragSD END, -- Einnahmen Positiv enzeigen
    Direktausgaben         = BetragAusgaben,
    Direkteinnahmen        = BetragEinnahmen,
                           
    GroupHeader2           = GroupHeader2,
    GroupHeader1           = GroupHeader1,
    GroupFooter1           = GroupFooter1,
    GroupFooter2           = GroupFooter2,
    GroupFooter3           = GroupFooter3,
    GroupFooter4           = @GroupFooter_AuszahlungAnKlient,
                           
    TextBudget             = @TextBudget,
    TextKlient             = @TextKlient,
    TextDritteSD           = @TextDritteSD,
    TextDirektausgaben     = @TextDirektausgaben,
    TextDirekteinnahmen    = @TextDirekteinnahmen,
                           
    HideSumBetragDisplay   = CONVERT(BIT, HideSumBetragDisplay),
    HideBetragDisplaySD    = CONVERT(BIT, HideBetragDisplaySD),
    AddPageBreakAfterGroup = CONVERT(BIT, AddPageBreakAfterGroup)
  FROM OutputCte
  ORDER BY SortKey3, SortKey2, SortKey1, SortKey0, [Text];

END;
