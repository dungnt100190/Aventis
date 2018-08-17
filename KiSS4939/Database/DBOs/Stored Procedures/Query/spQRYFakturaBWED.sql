SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spQRYFakturaBWED;
GO
/*===============================================================================================
  $Revision: 15 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Use this sp to get values for query "Faktura BW und ED"
    @LanguageCode:    The language code to use for varchar output
    @AuswFakturaCode: The code for faktura mode where means (LOV: BDELeistungsartAuswFaktura):
                      - 0=BW
                      - 1=ED
    @OrgUnitID:       The costcenter orgunit id
    @ZeitraumVon:     Search limit by from date
    @ZeitraumBis:     Search limit by to date,
    @BaPersonID:      The BaPersonID to filter for specific person
  -
  RETURNS: Result depending on given search parameters and search mode
=================================================================================================
  TEST:    EXEC dbo.spQRYFakturaBWED 1, 0, NULL, '2008-01-01', '2008-12-31', NULL
           EXEC dbo.spQRYFakturaBWED 1, 1, NULL, '2008-01-01', '2008-12-31', NULL
           
           EXEC dbo.spQRYFakturaBWED 1, 0, 102, '2008-01-01', '2008-12-31', NULL  -- 102="323 BW Glarus"
           EXEC dbo.spQRYFakturaBWED 1, 0, 125, '2008-01-01', '2008-12-31', NULL  -- 125="425 BW Luzern"
           EXEC dbo.spQRYFakturaBWED 1, 1, 122, '2008-01-01', '2008-12-31', NULL  -- 122="422 ED Luzern"
=================================================================================================*/

CREATE PROCEDURE dbo.spQRYFakturaBWED
(
  @LanguageCode INT,
  @AuswFakturaCode INT, -- BW=0, ED=1 (LOV: BDELeistungsartAuswFaktura)
  @OrgUnitID INT,
  @ZeitraumVon DATETIME,
  @ZeitraumBis DATETIME,
  @BaPersonID INT
)
AS 
BEGIN
  -------------------------------------------------------------------------------
  -- start call
  -------------------------------------------------------------------------------
  SET NOCOUNT ON;
  
  -- init start
  DECLARE @StartTimeOfCode DATETIME;
  SET @StartTimeOfCode = GETDATE();
  
  PRINT ('start call: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  
  -------------------------------------------------------------------------------
  -- validate
  -------------------------------------------------------------------------------
  IF (@LanguageCode IS NULL OR ISNULL(@AuswFakturaCode, -1) NOT IN (0, 1, 2) OR @ZeitraumVon IS NULL OR @ZeitraumBis IS NULL)
  BEGIN
    -- invalid data
    SELECT [Error] = 'Error: Invalid parametes, cannot search data!',
           [BaPersonID$] = NULL;
    
    -- do not continue
    RETURN;
  END;
  
  -------------------------------------------------------------------------------
  -- vars
  -------------------------------------------------------------------------------
  DECLARE @ZeitraumString VARCHAR(50);
  
  -- set periode
  SET @ZeitraumString = dbo.fnGetZeitraumString(@ZeitraumVon, @ZeitraumBis);
  
  -- info
  PRINT ('done init: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  
  -------------------------------------------------------------------------------
  -- collect data
  -------------------------------------------------------------------------------
  SELECT [BaPersonID$]          = PRS.BaPersonID,
         [Name]                 = PRS.Name,
         [Vorname]              = PRS.Vorname,
         [Geb.Dat.]             = PRS.Geburtsdatum,
         [Datum]                = LEI.Datum,
         [KTR + LA]             = CONVERT(VARCHAR(100), LEI.HistKostentraeger) + ' - ' + 
                                  dbo.fnGetMLTextByDefault(BLA.BezeichnungTID, @LanguageCode, BLA.Bezeichnung),
         [Mitarbeiter/in BW/ED] = dbo.fnGetLastFirstName(LEI.UserID, NULL, NULL),
         [Stunden]              = SUM(LEI.Dauer),
         [Kostenstelle]         = dbo.fnCombineKSTOrgUnitItemName(ORG.Kostenstelle, ORG.ItemName),
         [PLZ]                  = ADRW.PLZ,
         [Wohnort]              = ADRW.Ort,
         [Bezirk]               = ADRW.Bezirk,
         --
         [Tag]                  = CASE @AuswFakturaCode
                                    WHEN 0 THEN BWE.TarifTag    -- BW
                                    WHEN 1 THEN EDE.TarifTag    -- ED
                                    ELSE NULL
                                  END,
         [Nacht]                = CASE @AuswFakturaCode
                                    WHEN 0 THEN BWE.TarifNacht  -- BW
                                    WHEN 1 THEN EDE.TarifNacht  -- ED
                                    ELSE NULL
                                  END,
         [Zuschlag]             = CASE @AuswFakturaCode
                                    WHEN 0 THEN NULL               -- BW
                                    WHEN 1 THEN EDE.TarifZuschlag  -- ED
                                    ELSE NULL
                                  END,
         --
         [Mitglied insieme]     = dbo.fnEdHasClientReduction(EDE.EdEinsatzvereinbarungID, 'insieme'),
         [Mitglied cerebral]    = dbo.fnEdHasClientReduction(EDE.EdEinsatzvereinbarungID, 'cerebral'),
         [Reduktion Brantomy]   = dbo.fnEdHasClientReduction(EDE.EdEinsatzvereinbarungID, 'brantomy'),
         --
         [Korrespondenz]        = dbo.fnGetLOVMLText('BaKorrespondenzSprache', PRS.KorrespondenzSpracheCode, @LanguageCode),
         --
         [Anschrift]            = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 1, 'anschrift', 0, 1, 'vornach', dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, @LanguageCode, 'famherrfrau', NULL, PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede), 1, 1, 1, 1, 1, 0, 0, 1, 1),
         [Anrede]               = dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, @LanguageCode, 'geehrte', NULL, PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede),
         [Rechnungsadresse ED1] = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 1, 'raed1', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
         [Rechnungsadresse ED2] = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 1, 'raed2', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
         [Rechnungsadresse BW1] = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 1, 'rabw1', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
         [Rechnungsadresse BW2] = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 1, 'rabw2', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
         --
         [Bemerkung]            = LEI.Bemerkung,
         [Zeitraum]             = @ZeitraumString
  FROM dbo.BDELeistung                   LEI WITH (READUNCOMMITTED)
    -- additional info
    INNER JOIN dbo.BaPerson              PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
    
    -- filtering
    INNER JOIN dbo.BDELeistungsart       BLA WITH (READUNCOMMITTED) ON BLA.BDELeistungsartID = LEI.BDELeistungsartID 
                                                                   AND BLA.AuswFakturaCode = @AuswFakturaCode
    
    -- cost center
    LEFT  JOIN dbo.XOrgUnit              ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = LEI.KostenstelleOrgUnitID
    
    -- last BWEinsatzvereinbarung
    LEFT  JOIN dbo.BwEinsatzvereinbarung BWE WITH (READUNCOMMITTED) ON BWE.FaLeistungID = dbo.fnFaGetLastFaLeistungID(PRS.BaPersonID, 5) -- last BW-entry
    
    -- last EDEinsatzvereinbarung
    LEFT  JOIN dbo.EdEinsatzvereinbarung EDE WITH (READUNCOMMITTED) ON EDE.FaLeistungID = dbo.fnFaGetLastFaLeistungID(PRS.BaPersonID, 6) -- last ED-entry
    
    -- wohnsitz
    LEFT JOIN dbo.BaAdresse ADRW WITH (READUNCOMMITTED) ON ADRW.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 1, NULL)
                                                                 
  WHERE (ISNULL(@OrgUnitID, -1) < 1 OR LEI.KostenstelleOrgUnitID = @OrgUnitID)
    AND (ISNULL(@BaPersonID, -1) < 1 OR LEI.BaPersonID = @BaPersonID)
    AND LEI.Datum >= @ZeitraumVon
    AND LEI.Datum <= @ZeitraumBis
  
  GROUP BY PRS.BaPersonID, PRS.Name, PRS.Vorname, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode,
           PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede,
           ADRW.PLZ, ADRW.Ort, ADRW.Bezirk, PRS.KorrespondenzSpracheCode,
           LEI.UserID, LEI.Datum, LEI.BDELeistungsartID, LEI.Bemerkung,
           dbo.fnGetMLTextByDefault(BLA.BezeichnungTID, @LanguageCode, BLA.Bezeichnung),
           LEI.HistKostentraeger,
           dbo.fnCombineKSTOrgUnitItemName(ORG.Kostenstelle, ORG.ItemName),
           EDE.EdEinsatzvereinbarungID, BWE.TarifTag, BWE.TarifNacht,
           EDE.TarifTag, EDE.TarifNacht, EDE.TarifZuschlag
  
  ORDER BY PRS.Name, PRS.Vorname, BaPersonID$, LEI.Datum;
  
  -- info
  PRINT ('done: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
END;
GO
