SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhBudget_Get
GO
/*===============================================================================================
  $Revision: 30 $
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
=================================================================================================*/

CREATE PROCEDURE dbo.spWhBudget_Get
(
  @BgBudgetID int
)
AS

DECLARE @GetDate         datetime
DECLARE @Betrag          money
DECLARE @BgFinanzplanID  int
DECLARE @RefDate         datetime

DECLARE @Position table (
  -- BgPosition
  BgPositionID            int,
  BgBudgetID              int,
  BgKategorieCode         int,
  DatumVon                datetime,
  DatumBis                datetime,
  DatumVonKonsolidiert    datetime,
  DatumBisKonsolidiert    datetime,
  ZukuenftigeLeistung     bit,
  BgPositionID_CopyOf     int,
  BgPositionID_Parent     int,
  BaPersonID              int,
  BaInstitutionID         int,
  DebitorBaPersonID       int,
  BgPositionsartID        int,
  Buchungstext            varchar(100),
  Betrag                  money,
  Reduktion               money,
  Abzug                   money,
  BgSpezkontoID           int,
  Bemerkung               text,
  VerwPeriodeVon          datetime,
  VerwPeriodeBis          datetime,
  FaelligAm               datetime,
  RechnungDatum           datetime,
  VerwaltungSD            bit,
  BgBewilligungStatusCode int,
  ErstelltUserID          int,
  ErstelltDatum           datetime,
  MutiertUserID           int,
  MutiertDatum            datetime,
  -- BgAuszahlungPerson
  BgAuszahlungPersonID    int,
  KbAuszahlungsArtCode    int,
  BgAuszahlungsTerminCode int,
  BgWochentagCodes        varchar(20),
  BaZahlungswegID         int,
  MitteilungZeile1        varchar(35),
  MitteilungZeile2        varchar(35),
  MitteilungZeile3        varchar(35),
  MitteilungZeile4        varchar(35),
  ReferenzNummer          varchar(50),
  -- Darstellung Budget
  Kategorie               bit,
  Gruppe                  bit,
  Style                   int,
  KOA                     varchar(10),
  Bezeichnung             varchar(200),
  EffektivBetrag          money,
  Total                   money,
  DetailPos               varchar(5),
  SD                      varchar(5),
  Dri                     varchar(5),
  Doc                     int,
  Info                    varchar(200),
  AnzahlZahlinfos         int,
  Status                  int,
  AnzahlBelege            varchar(10),
  StatusMin               int,
  M                       varchar(1),
  -- Lookup/Calculated
  BgGruppeCode            int,
  Dritte                  bit,
  Kostenart               varchar(100),
  BgKostenartID           int,
  Masterbudget_EditMask   int,
  Monatsbudget_EditMask   int,
  ProPerson               bit,
  ProUE                   bit,
  BgSplittingArtCode      int,
  Debitor                 varchar(150),
  Kreditor                varchar(200),
  ZusatzInfo              varchar(500),
  PscdFehlermeldung       varchar(200),
  EffektivText            varchar(200),
  ValutaDatum             datetime,
  ValutaTermine           varchar(1000),
  EinzahlungsscheinCode   int,
  Quoting                 bit,
  BetragBudget            money,
  BetragRechnung          money,
  GruppeFilter            varchar(50),
  BaZahlungswegIDFix      int,
  HVTVAufPositionsart     bit,
  BgPositionTS_TEMP       bigint
)

SELECT @BgFinanzplanID = BBG.BgFinanzplanID,
       @RefDate =  dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15),
       @GetDate = CASE WHEN BBG.MasterBudget = 1
                  THEN dbo.fnDateOf(CONVERT(datetime, dbo.fnMIN(dbo.fnMAX(GetDate(), IsNull(BFP.DatumVon, BFP.GeplantVon)), IsNull(BFP.DatumBis, BFP.GeplantBis))))
                  ELSE dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15)
                  END
FROM   dbo.BgBudget BBG WITH (READUNCOMMITTED)
    INNER JOIN dbo.BgFinanzplan  BFP WITH (READUNCOMMITTED) ON BFP.BgFinanzplanID = BBG.BgFinanzplanID
WHERE  BBG.BgBudgetID = @BgBudgetID

INSERT INTO @Position (
  BgPositionID,BgBudgetID,BgKategorieCode,DatumVon,DatumBis,
  DatumVonKonsolidiert, 
  DatumBisKonsolidiert, 
  ZukuenftigeLeistung,
  BgPositionID_CopyOf,BgPositionID_Parent,
  BaPersonID,BaInstitutionID,DebitorBaPersonID,BgPositionsartID,Buchungstext,Betrag,Reduktion,Abzug,BgSpezkontoID,
  Bemerkung,VerwPeriodeVon,VerwPeriodeBis,FaelligAm,RechnungDatum,VerwaltungSD,BgBewilligungStatusCode,
  ErstelltUserID,ErstelltDatum,MutiertUserID,MutiertDatum,
  BgAuszahlungPersonID,KbAuszahlungsArtCode,BgAuszahlungsTerminCode,BgWochentagCodes,BaZahlungswegID,
  MitteilungZeile1,MitteilungZeile2,MitteilungZeile3,MitteilungZeile4,ReferenzNummer,
  Kategorie,Gruppe,Style,KOA,Bezeichnung,EffektivBetrag,Total,DetailPos,SD,Dri,Doc,Info,AnzahlZahlinfos,Status,AnzahlBelege,StatusMin,M,
  BgGruppeCode,Dritte,Kostenart,BgKostenartID,Masterbudget_EditMask,Monatsbudget_EditMask,ProPerson,ProUE,
  BgSplittingArtCode,Debitor,Kreditor,ZusatzInfo,PscdFehlermeldung,
  EffektivText,ValutaDatum,ValutaTermine,EinzahlungsscheinCode, Quoting, BetragBudget, BetragRechnung, GruppeFilter, BaZahlungswegIDFix, HVTVAufPositionsart, BgPositionTS_TEMP)
SELECT
  BPO.BgPositionID,BPO.BgBudgetID,BPO.BgKategorieCode,BPO.DatumVon,BPO.DatumBis,
  DatumVonKonsolidiert	= CASE WHEN BPO.DatumVon IS NOT NULL OR BPO.DatumBis IS NOT NULL THEN CONVERT(DATETIME, dbo.fnMAX(BPO.DatumVon, ISNULL(FPL.DatumVon, FPL.GeplantVon))) ELSE ISNULL(FPL.DatumVon, FPL.GeplantVon) END,	-- Wenn das Positons-Datum Von oder Bis überschrieben wurde, dann zeige die Positions-Periode an, sonst die FP-Periode
  DatumBisKonsolidiert	= CASE WHEN BPO.DatumVon IS NOT NULL OR BPO.DatumBis IS NOT NULL THEN BPO.DatumBis ELSE ISNULL(FPL.DatumBis, FPL.GeplantBis) END,
  ZukuenftigeLeistung = CASE WHEN COALESCE(BPO.DatumVon, FPL.DatumVon, FPL.GeplantVon) > dbo.fnMAX(@GetDate, IsNull(FPL.DatumVon, FPL.GeplantVon)) THEN 1 ELSE 0 END,	-- Wenn die Position erst nach dem Start des FPs oder erst nach heute startet, dann ist es eine Zukünftige Leistung
  BPO.BgPositionID_CopyOf,BPO.BgPositionID_Parent,
  BPO.BaPersonID,BPO.BaInstitutionID,BPO.DebitorBaPersonID,BPO.BgPositionsartID,BPO.Buchungstext,BPO.Betrag,BPO.Reduktion,BPO.Abzug,BPO.BgSpezkontoID,
  BPO.Bemerkung,BPO.VerwPeriodeVon,BPO.VerwPeriodeBis,BPO.FaelligAm,BPO.RechnungDatum,BPO.VerwaltungSD,BPO.BgBewilligungStatusCode,
  BPO.ErstelltUserID,BPO.ErstelltDatum,BPO.MutiertUserID,BPO.MutiertDatum,
  BAP.BgAuszahlungPersonID,BAP.KbAuszahlungsArtCode,BAP.BgAuszahlungsTerminCode,BAP.BgWochentagCodes,BAP.BaZahlungswegID,
  BAP.MitteilungZeile1,MitteilungZeile2,BAP.MitteilungZeile3,BAP.MitteilungZeile4,BAP.ReferenzNummer,
  Kategorie             = 0,
  Gruppe                = 0,
  Style                 = CASE
                            WHEN BPO.BgKategorieCode = 1   AND BPO.VerwaltungSD = 1             THEN 12
                            WHEN BPO.BgKategorieCode = 2   AND BPO.BgSpezkontoID IS NOT NULL    THEN 23
                            WHEN BPO.BgKategorieCode = 101 AND BPO.BgSpezkontoID IS NULL        THEN 81
                            WHEN BPO.BgKategorieCode = 101 AND BPO.BgSpezkontoID IS NOT NULL    THEN 82
                            WHEN BPO.BgKategorieCode = 100 AND BPO.BgBewilligungStatusCode = 1  THEN 83
                            WHEN BPO.BgKategorieCode = 100 AND BPO.BgBewilligungStatusCode = 3  THEN 84
                            WHEN BPO.BgKategorieCode = 100 AND BPO.BgBewilligungStatusCode = 5  THEN 85
                            ELSE BPO.BgKategorieCode * 10 + 1
                          END,
  KOA                   = BKA.KontoNr,
  Bezeichnung           = '    ' + COALESCE(BPO.Buchungstext, BPA.Name, BSK.NameSpezkonto) + IsNull(' (' + PRS.NameVorname + ')', ''),
  EffektivBetrag        = NULL,--EFF.BetragEffektiv, --TODO
  Total                 = NULL,
  DetailPos             = CASE WHEN BPO.BgKategorieCode in (100, 101)
                            THEN CASE 
                                   WHEN BPO.BgPositionID_Parent IS NOT NULL THEN '+'  -- DetailPosition
                                   WHEN EXISTS(SELECT TOP 1 1 
                                               FROM dbo.BgPosition POS
                                               WHERE BgPositionID_Parent = BPO.BgPositionID
                                                 AND POS.BgKategorieCode <> 3) THEN '*' -- HauptPosition
                                 END
                          END,
  SD                    = CASE WHEN BPO.VerwaltungSD = 1 THEN 'S' END,
  Dri                   = CASE WHEN KRE.BaZahlungswegID IS NOT NULL AND KRE.BaPersonID IS NULL THEN 'D' END,
  Doc                   = (SELECT CASE WHEN SUM(AnzahlDok) > 0 THEN SUM(AnzahlDok) END
                           FROM (                        
                                    SELECT AnzahlDok = COUNT(1) -- Budgetposition
                                    FROM dbo.BgDokument 
                                    WHERE BgPositionID = BPO.BgPositionID    
                                  UNION ALL     
                                    SELECT AnzahlDok = COUNT(1) -- Monatsbudget
                                    FROM dbo.BgPosition POS  
                                    INNER JOIN dbo.BgDokument BDO ON BDO.BgBudgetID = POS.BgBudgetID
                                    WHERE POS.BgPositionID = BPO.BgPositionID    
                                  UNION ALL
                                    SELECT AnzahlDok = COUNT(1) -- Finanzplan
                                    FROM dbo.BgPosition POS
                                    INNER JOIN dbo.BgBudget   BDG ON BDG.BgBudgetID = POS.BgBudgetID
                                    INNER JOIN dbo.BgDokument BDO ON BDO.BgFinanzplanID = BDG.BgFinanzplanID
                                    WHERE POS.BgPositionID = BPO.BgPositionID                                       
                                  UNION ALL
                                    SELECT AnzahlDok = COUNT(1) -- Masterbudgetposition
                                    FROM dbo.BgPosition POS 
                                    INNER JOIN dbo.BgDokument BDO ON BDO.BgPositionID = POS.BgPositionID_CopyOf                            
                                    WHERE POS.BgPositionID = BPO.BgPositionID                                                    
                           
                            ) A
                           WHERE 1=1),  
  Info                  = (SELECT CASE WHEN COUNT(*) > 1 THEN '(+' + CONVERT(varchar,COUNT(*)-1) + ') ' ELSE '' END FROM dbo.BgAuszahlungPerson WHERE BgPositionID = BPO.BgPositionID) +
                          CASE
                          WHEN BAP.KbAuszahlungsArtCode = 103 OR (KRE.BaZahlungswegID IS NOT NULL AND KRE.BaPersonID IS NOT NULL)  -- bar oder Auszahlung an Person
                               THEN AZA.ShortText + CASE BAP.BgAuszahlungsTerminCode
                                                    WHEN 4 THEN IsNull(', ' + CONVERT(varchar,VAL.Datum,104),'')
                                                    WHEN 6 THEN ' (' + dbo.fnLOVTextListe('BgWochentag',BAP.BgWochentagCodes) + ')'
                                                    ELSE ', ' + AZT.Text + IsNull(', ' + KRE.Kreditor,'')
                                                    END
                          WHEN KRE.BaZahlungswegID IS NOT NULL AND KRE.BaPersonID IS NULL  -- Auszahlung an Dritte
                               THEN CASE BAP.BgAuszahlungsTerminCode
                                    WHEN 4 THEN IsNull(CONVERT(varchar,VAL.Datum,104),'?') + IsNull(', ' + KRE.InstitutionName,'')
                                    WHEN 6 THEN ' (' + dbo.fnLOVTextListe('BgWochentag',BAP.BgWochentagCodes) + ')'
                                    ELSE AZT.Text + IsNull(', ' + KRE.InstitutionName,'')
                                    END
                          WHEN KRE.BaZahlungswegID IS NULL AND BPO.BgSpezkontoID IS NOT NULL  -- Auszahlung/Verrechnung an Spezialkonto
                               THEN SPT.ShortText + ': ' + BSK.NameSpezkonto
                          WHEN BPO.BgKategorieCode = 1 -- Einnahme
                               THEN IsNull(CONVERT(varchar,BPO.FaelligAm,104),'') + IsNull(', ' + IsNull(DEBI.Name,DEBP.NameVorname),'')
                          END,
  AnzahlZahlinfo        = (SELECT COUNT(*) FROM dbo.BgAuszahlungPerson WHERE BgPositionID = BPO.BgPositionID),
  Status                = CASE WHEN BDG.MasterBudget = 0
                          THEN CASE WHEN STA.Status IS NULL
                               THEN CASE
                                     WHEN BPO.BgKategorieCode = 2 AND KRE.BaZahlungswegID IS NULL AND BPO.BgSpezkontoID IS NOT NULL -- Auszahlung an Spezialkonto
                                          THEN CASE WHEN BDG.BgBewilligungStatusCode in (5,9) THEN 2 ELSE 1 END
                                     WHEN BPO.BgKategorieCode = 100 AND KRE.BaZahlungswegID IS NULL AND BPO.BgSpezkontoID IS NOT NULL -- Zusätzliche Leistung an Spezialkonto
                                          THEN
                                            CASE BPO.BgBewilligungStatusCode
                                              WHEN 1 THEN 1   -- grau
                                              WHEN 2 THEN 15  -- abgelehnt
                                              WHEN 3 THEN 12  -- angefragt
                                              WHEN 5 THEN 14  -- bewilligt
                                              WHEN 9 THEN 7   -- gesperrt
                                            END
                                     WHEN BPO.BgKategorieCode = 1 AND BPO.VerwaltungSD = 0 -- nicht abgetretene Einnahmen
                                          THEN CASE WHEN BDG.BgBewilligungStatusCode in (5,9) THEN 2 ELSE 1 END
                                     WHEN BPO.BgKategorieCode = 3 -- Verrechnungen
                                          THEN CASE WHEN BDG.BgBewilligungStatusCode in (5,9) THEN 2 ELSE 1 END
                                     ELSE CASE WHEN BPO.BgKategorieCode = 2 AND KRE.BaZahlungswegID IS NOT NULL AND KRE.BaPersonID IS NOT NULL -- Ausgaben an Klient (ohne tatsähliche Auszahlung)
--                                          THEN CASE WHEN BDG.BgBewilligungStatusCode in (5,9) THEN 2 ELSE 1 END
                                          THEN 
                                            CASE BDG.BgBewilligungStatusCode
                                              WHEN 5 THEN CASE WHEN dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1) < '2009-12-31' THEN 2 ELSE 1 END -- im grünen Budget grün - früher, da noch keine 0er-Positionen erstellt wurden
                                              WHEN 9 THEN 7 -- im roten Budget gesperrt
                                              ELSE 1
                                            END
                                          ELSE
                                            CASE BPO.BgBewilligungStatusCode
                                              WHEN 1 THEN 1   -- grau
                                              WHEN 2 THEN 15  -- abgelehnt
                                              WHEN 3 THEN 12  -- angefragt
                                              WHEN 5 THEN 14  -- bewilligt
                                              WHEN 9 THEN 7   -- gesperrt
                                            END
                                          END
                                     END
                               ELSE STA.Status
                               END
                          END,
  AnzahlBelege          = CASE WHEN BDG.MasterBudget = 0 AND STA.AnzahlBelege > 1 THEN CONVERT(varchar,STA.AnzahlBelege)
                               WHEN BDG.MasterBudget = 0 AND BPO.BgKategorieCode = 1 THEN
                                    (SELECT MAX(M.ShortText)
                                     FROM KbBuchungBrutto B
                                          INNER JOIN KbBuchungBruttoPerson P on P.KbBuchungBruttoID = B.KbBuchungBruttoID
                                          INNER JOIN XLOVCode              M on M.LOVName = 'WhMahnstufe' AND
                                                                                M.Code = CASE
                                                                                         WHEN Mahnsperre = 1 THEN 6
                                                                                         WHEN Fakturasperre = 1 THEN 5
                                                                                         WHEN B.Mahnstufe in (1,2,3,4) THEN B.Mahnstufe
                                                                                         WHEN Fakturiert = 1 THEN 0
                                                                                         END
                                     WHERE P.BgPositionID = BPO.BgPositionID)
                          END,
  StatusMin             = CASE WHEN BDG.MasterBudget = 0 AND STA.Status <> STA.StatusMin THEN STA.StatusMin END,
  M                     = CASE WHEN BDG.MasterBudget = 0 AND BPO.BgPositionID_CopyOf IS NOT NULL THEN 'M' END,
  BgGruppeCode          = BPA.BgGruppeCode,
  Dritte                = CASE WHEN KRE.BaZahlungswegID IS NOT NULL AND KRE.BaPersonID IS NOT NULL THEN 1 ELSE 0 END,
  Kostenart             = BKA.KontoNr + ' ' + IsNull(BPA.Name,BKA.Name),
  BgKostenartID         = BPA.BgKostenartID,
  Masterbudget_EditMask = BPA.Masterbudget_EditMask,
  Monatsbudget_EditMask = BPA.Monatsbudget_EditMask,
  ProPerson             = BPA.ProPerson,
  ProUE                 = BPA.ProUE,
  BgSplittingArtCode    = BKA.BgSplittingArtCode,
  Debitor               = IsNull(DEBI.Name,DEBP.NameVorname),
  Kreditor              = KRE.Kreditor,
  ZusatzInfo            = CASE
                          WHEN BAP.BaZahlungswegID IS NOT NULL THEN KRE.ZusatzInfo
                          WHEN IsNull(BPO.BaInstitutionID,BPO.DebitorBaPersonID) IS NOT NULL THEN IsNull(DEBI.AdresseMehrzeilig,DEBP.WohnsitzMehrzeilig)
                          END,
  PscdFehlermeldung     = NULL,
  EffektivText          = NULL,--EFF.Text,
  ValutaDatum           = CASE WHEN BAP.BgAuszahlungsTerminCode = 4 THEN VAL.Datum END,
  ValutaTermine         = dbo.fnBgGetValutaTermine(BAP.BgAuszahlungPersonID),
  EinzahlungsscheinCode = KRE.EinzahlungsscheinCode,
  Quoting               = IsNull(BKA.Quoting,0),
  BetragBudget          = BPO.BetragBudget,
  BetragRechnung        = BPO.BetragRechnung,
  GruppeFilter          = CONVERT(varchar(50),GRP.Value3),
  BaZahlungswegIDFix    = BKA.BaZahlungswegIDFix,
  HVTVAufPositionsart   = CASE WHEN BPA.SpezHauptvorgang IS NOT NULL OR BPA.SpezTeilvorgang IS NOT NULL THEN 1 ELSE 0 END,
  BgPositionTS          = BPO.BgPositionTS

FROM   dbo.vwBgPosition BPO
       INNER JOIN dbo.BgBudget                 BDG WITH(READUNCOMMITTED) ON BDG.BgBudgetID = BPO.BgBudgetID
       INNER JOIN dbo.BgFinanzplan             FPL WITH(READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
       INNER JOIN dbo.FaLeistung               LEI WITH(READUNCOMMITTED) ON LEI.FaLeistungID = FPL.FaLeistungID
       LEFT  JOIN dbo.BgSpezkonto              SSK WITH(READUNCOMMITTED) ON SSK.BgSpezkontoID = BPO.BgSpezkontoID
       LEFT  JOIN dbo.BgPositionsart           BPA WITH(READUNCOMMITTED) ON BPA.BgPositionsartID = COALESCE(BPO.BgPositionsartID,SSK.BgPositionsartID)
       LEFT  JOIN dbo.vwPerson                 PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = BPO.BaPersonID
       LEFT  JOIN dbo.BgPositionsart           GBL WITH(READUNCOMMITTED) ON GBL.BgPositionsartID = FPL.WhGrundbedarfTypCode
       LEFT  JOIN dbo.BgKostenart              BKA WITH(READUNCOMMITTED) ON BKA.BgKostenartID = COALESCE(BPA.BgKostenartID,
          /*Anzeige analog Grünstellroutine: Verrechnungskonto zu irgendeiner GBL-LA (206...208) wird auf die aktuell gültige GBL-LA gebucht*/
          CASE WHEN SSK.BgKostenartID IN (206, 207, 208) THEN GBL.BgKostenartID ELSE SSK.BgKostenartID END, GBL.BgKostenartID)
       LEFT  JOIN dbo.BgAuszahlungPerson       BAP WITH(READUNCOMMITTED) ON BAP.BgPositionID = BPO.BgPositionID AND
                                                   BAP.BgAuszahlungPersonID = (SELECT TOP 1 BgAuszahlungPersonID
                                                                               FROM   dbo.BgAuszahlungPerson WITH(READUNCOMMITTED)
                                                                               WHERE  BgPositionID = BPO.BgPositionID
                                                                               ORDER BY
                                                                                 CASE WHEN BaPersonID IS NULL THEN 1
                                                                                      WHEN BaPersonID = BPO.BaPersonID THEN 2
                                                                                      WHEN BaPersonID = LEI.BaPersonID THEN 3
                                                                                       ELSE 4
                                                                                 END)
       LEFT  JOIN dbo.vwKreditor               KRE  ON KRE.BaZahlungswegID = BAP.BaZahlungswegID
       LEFT  JOIN dbo.vwInstitution            DEBI ON DEBI.BaInstitutionID = BPO.BaInstitutionID AND
                                                   BPO.BgKategorieCode = 1
       LEFT  JOIN dbo.vwPerson                 DEBP ON DEBP.BaPersonID = BPO.DebitorBaPersonID
       LEFT  JOIN dbo.BgSpezkonto              BSK WITH(READUNCOMMITTED) ON BSK.BgSpezkontoID = BPO.BgSpezkontoID
       LEFT  JOIN dbo.BgPosition               BP2 WITH(READUNCOMMITTED) ON BP2.BgPositionID = BPO.BgPositionID_CopyOf
       LEFT  JOIN dbo.BgPosition               BP3 WITH(READUNCOMMITTED) ON BP3.BgPositionID = BP2.BgPositionID_CopyOf
       LEFT  JOIN dbo.XLOVCode                 AZA WITH(READUNCOMMITTED) ON AZA.LOVName = 'KbAuszahlungsart' AND AZA.Code = BAP.KbAuszahlungsArtCode
       LEFT  JOIN dbo.XLOVCode                 AZT WITH(READUNCOMMITTED) ON AZT.LOVName = 'BgAuszahlungsTermin' AND AZT.Code = BAP.BgAuszahlungsTerminCode
       LEFT  JOIN dbo.XLOVCode                 SPT WITH(READUNCOMMITTED) ON SPT.LOVName = 'BgSpezkontoTyp' AND SPT.Code = BSK.BgSpezkontoTypCode
       LEFT  JOIN dbo.XLOVCode                 GRP WITH(READUNCOMMITTED) ON GRP.LOVName = 'BgGruppe' AND GRP.Code = BPA.BgGruppeCode
       LEFT  JOIN dbo.BgAuszahlungPersonTermin VAL WITH(READUNCOMMITTED) ON VAL.BgAuszahlungPersonID = BAP.BgAuszahlungPersonID AND
                                                   VAL.Datum = (SELECT TOP 1 Datum
                                                                FROM   dbo.BgAuszahlungPersonTermin WITH (READUNCOMMITTED)
                                                                WHERE  BgAuszahlungPersonID = BAP.BgAuszahlungPersonID
                                                                ORDER BY Datum)
       LEFT  JOIN   (SELECT BUC.BgBudgetID, BUK.BgPositionID,
                            Status       = MAX(BUC.KbBuchungStatusCode),
                            StatusMin    = MIN(BUC.KbBuchungStatusCode),
                            AnzahlBelege = COUNT(DISTINCT BUC.KbBuchungID)
                     FROM   dbo.KbBuchungKostenart BUK WITH(READUNCOMMITTED)
                            LEFT OUTER JOIN dbo.KbBuchung BUC WITH(READUNCOMMITTED) ON BUC.KbBuchungID = BUK.KbBuchungID
                     GROUP  BY BUC.BgBudgetID, BUK.BgPositionID) STA ON STA.BgBudgetID = BPO.BgBudgetID AND STA.BgPositionID = BPO.BgPositionID
/*
       LEFT  JOIN (SELECT KBK.BgPositionID, BetragEffektiv =                           CASE WHEN SUM(KBU.Betrag) = $0.00 THEN $0.00 ELSE SUM(KBK.Betrag * AUG.Total / KBU.Betrag) END,
                                            [Text] = 'effektiv ' + convert(varchar(20),CASE WHEN SUM(KBU.Betrag) = $0.00 THEN $0.00 ELSE SUM(KBK.Betrag * AUG.Total / KBU.Betrag) END,1) + ' (' + convert(varchar, max(AUG.Datum), 104) + ')'
                   FROM dbo.KbBuchungKostenart KBK WITH(READUNCOMMITTED)
                     INNER JOIN dbo.KbBuchung  KBU WITH(READUNCOMMITTED) ON KBU.KbBuchungID = KBK.KbBuchungID
                     INNER JOIN (SELECT OpBuchungID, Total = SUM(AUG.Betrag), Datum = MAX(BUC.BelegDatum)
                                 FROM dbo.KbOpAusgleich     AUG WITH(READUNCOMMITTED)
                                   INNER JOIN dbo.KbBuchung BUC WITH(READUNCOMMITTED) ON BUC.KbBuchungID = AUG.AusgleichBuchungID
                                 GROUP BY OpBuchungID) AUG ON AUG.OpBuchungID = KBU.KbBuchungID
                   GROUP BY KBK.BgPositionID) EFF ON EFF.BgPositionID = BPO.BgPositionID
*/
WHERE  BPO.BgBudgetID = @BgBudgetID AND
       CASE WHEN BPO.BgKategorieCode = 5       THEN 0   -- Vermögen
            --WHEN BPO.BgKategorieCode = 2 AND BPO.BgPositionsartID = 32021 THEN 0    -- VVG Prämie GBL
         ELSE 
           CASE WHEN BDG.MasterBudget = 1 THEN 
             CASE WHEN (FPL.BgBewilligungStatusCode < 5 OR BPO.BgBewilligungStatusCode = 5 OR BPO.BgKategorieCode = 1)-- Ausgaben müssen (bis jetzt) nicht bewilligt werden
                   AND COALESCE(BPO.DatumBis, FPL.DatumBis, FPL.GeplantBis) >= @GetDate THEN 1	-- Im bewilligten Master-Budget sollen nur bewilligte Positionen angezeigt werden, die nicht in der Vergangenheit liegen
             ELSE 0
             END
           ELSE
             CASE WHEN @RefDate BETWEEN IsNull(BPO.DatumVon, '19000101') AND IsNull(BPO.DatumBis, '20790606') THEN 1 
             ELSE 0 
             END
           END
       END = 1 AND
       (BPO.BetragBudget <> $0.00 OR
        BPO.BgPositionsartID IN (39900, 39910) OR /* Sanktionen immer anzeigen */
        BPO.BgKategorieCode IN (100, 101) )
    AND IsNull(Status,0) <> 8  -- 8 = Storno: Stornierte Positionen sollen nicht angezeigt werden

-- Effektivbetrag holen
UPDATE POS
SET EffektivText          = EFF.Text,
    EffektivBetrag        = EFF.BetragEffektiv
FROM @Position POS
   LEFT OUTER JOIN (SELECT KBK.BgPositionID, BetragEffektiv =                           CASE WHEN SUM(KBU.Betrag) = $0.00 THEN $0.00 ELSE SUM(KBK.Betrag * AUG.Total / KBU.Betrag) END,
                                        [Text] = 'effektiv ' + CONVERT(varchar(20),CASE WHEN SUM(KBU.Betrag) = $0.00 THEN $0.00 ELSE SUM(KBK.Betrag * AUG.Total / KBU.Betrag) END,1) + ' (' + CONVERT(varchar, MAX(AUG.Datum), 104) + ')'
               FROM dbo.KbBuchungKostenart KBK WITH(READUNCOMMITTED)
                 INNER JOIN dbo.KbBuchung  KBU WITH(READUNCOMMITTED) ON KBU.KbBuchungID = KBK.KbBuchungID
                 INNER JOIN (SELECT OpBuchungID, Total = SUM(AUG.Betrag), Datum = MAX(BUC.BelegDatum)
                             FROM dbo.KbOpAusgleich     AUG WITH(READUNCOMMITTED)
                               INNER JOIN dbo.KbBuchung BUC WITH(READUNCOMMITTED) ON BUC.KbBuchungID = AUG.AusgleichBuchungID
                             GROUP BY OpBuchungID) AUG ON AUG.OpBuchungID = KBU.KbBuchungID
               GROUP BY KBK.BgPositionID) EFF ON EFF.BgPositionID = POS.BgPositionID


-- Kategorien Code < 100
INSERT @Position (Kategorie, Gruppe, Style, BgKategorieCode, Bezeichnung, Buchungstext, Total, ZukuenftigeLeistung)
SELECT 1,0,1,KAT.Code,UPPER(KAT.Text),UPPER(KAT.Text),(SELECT SUM(BetragBudget) FROM @Position WHERE BgKategorieCode = KAT.Code), 0
FROM   dbo.XLOVCode KAT WITH(READUNCOMMITTED)
WHERE  LOVName = 'BgKategorie' AND
       EXISTS (SELECT * FROM @Position WHERE BgKategorieCode = KAT.Code AND KAT.Code < 100)

-- Kategorien Code >= 100 : Anderer Style
INSERT @Position (Kategorie, Gruppe, Style, BgKategorieCode, Bezeichnung, Buchungstext, Total, ZukuenftigeLeistung)
SELECT 1,0,3,KAT.Code,UPPER(KAT.Text),UPPER(KAT.Text),(SELECT SUM(BetragBudget) FROM @Position WHERE BgKategorieCode = KAT.Code), 0
FROM   dbo.XLOVCode KAT WITH(READUNCOMMITTED)
WHERE  LOVName = 'BgKategorie' AND
       EXISTS (SELECT * FROM @Position WHERE BgKategorieCode = KAT.Code AND KAT.Code >= 100)

-- Gruppen
INSERT @Position (Kategorie, Gruppe, Style, BgKategorieCode, BgGruppeCode, Bezeichnung, Buchungstext, Total, ZukuenftigeLeistung)
SELECT 0,1,2,POS.BgKategorieCode,POS.BgGruppeCode,'  ' + GRP.Text, GRP.Text, SUM(BetragBudget), 0
FROM   @Position POS
       INNER JOIN dbo.BgPositionsart  BPA WITH(READUNCOMMITTED) ON BPA.BgPositionsartID = POS.BgPositionsartID AND
                                         BPA.BgKategorieCode = POS.BgKategorieCode
       INNER JOIN dbo.XLOVCode GRP WITH(READUNCOMMITTED) ON GRP.LOVName = 'BgGruppe' AND GRP.Code = BPA.BgGruppeCode
GROUP BY POS.BgKategorieCode,POS.BgGruppeCode,GRP.Text

-- Output
SELECT POS.*, BgPositionTS = Convert(timestamp, BgPositionTS_TEMP)
FROM   @Position POS
       LEFT  JOIN dbo.BgPositionsart BPA WITH(READUNCOMMITTED) ON BPA.BgPositionsartID = POS.BgPositionsartID AND
                                        BPA.BgKategorieCode = POS.BgKategorieCode
       LEFT  JOIN dbo.XLOVCode       GRP WITH(READUNCOMMITTED) ON GRP.LOVName = 'BgGruppe' AND GRP.Code = POS.BgGruppeCode
       LEFT  JOIN dbo.XLOVCode       KAT WITH(READUNCOMMITTED) ON KAT.LOVName = 'BgKategorie' AND KAT.Code = POS.BgKategorieCode
ORDER BY KAT.SortKey, CASE WHEN Kategorie = 1 THEN -2 ELSE IsNull(GRP.SortKey, -1) END, GRP.Code, IsNull(BPA.SortKey, -1)
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO


