-- used in 3012, 3013
CREATE FUNCTION dbo.fnRepShBudget
 (@BgBudgetID int,
  @RefDate    datetime)
 RETURNS @budget TABLE (
  BgPositionCode     int,
  BgPositionText     varchar(100),
  ShPositionTypCode  int,
  ShPositionTypText  varchar(100),
  ShPositionTypID    int,

  Dritte             bit,
  ShZahlungsmodusID  int,
  ShSpezkontoID      int,

  GroupText          varchar(100),

  Bezeichnung        varchar(500) null,
  Betrag             money,
  KOA                int null
)
AS BEGIN
  DECLARE @ShFinanzPlanID  int

  SELECT 
    @ShFinanzPlanID = ShFinanzPlanID,
    @RefDate = CASE WHEN BgBudgetCode BETWEEN 1 AND 9 THEN @RefDate ELSE dbo.fnDateSerial(Jahr, Monat, 15) END    
  FROM BgBudget WHERE BgBudgetID = @BgBudgetID

  DECLARE @BgPosition  TABLE (
    BgPositionID       int,
    BgPositionCode     int,
    ShPositionTypCode  int,
    ShPositionTypID    int,

    Dritte             bit,
    ShZahlungsmodusID  int,
    ShSpezkontoID      int,

    Bezeichnung        varchar(500),
    Betrag             money,
    FlKostenartID      int null
  )

  INSERT INTO @BgPosition
    SELECT BPO.BgPositionID, BPO.BgPositionCode, SPT.ShPositionTypCode, SPT.ShPositionTypID,
      CONVERT(bit, CASE BPO.BgPositionCode
        WHEN 1 THEN MAX(CONVERT(int, BPO.VerwaltungSD))
        WHEN 2 THEN MAX(CONVERT(int, STZ.Dritte))
      END),
      STZ.ShZahlungsmodusID, MAX(SPK.ShSpezkontoID),
      MIN(IsNull(IsNull(NullIf(RTrim(BPO.Buchungstext), ''), SPT.Name + IsNull(' (' + PRS.Name + ' ' + PRS.Vorname1 + ')', '')), SPK.NameSpezkonto)),
      SUM(IsNull(STZ.PersonFactor, 1) * BPO.BetragBudget) AS Betrag,
      MIN(SPT.FlKostenartID)
    FROM vwBgPosition             BPO
      LEFT  JOIN ShPositionTyp    SPT ON SPT.ShPositionTypID = BPO.ShPositionTypID
      LEFT  JOIN DmgPerson        PRS ON PRS.DmgPersonID = BPO.DmgPersonID
      LEFT  JOIN (SELECT SBL.ShBelegID, STZ.ShZahlungsmodusID, SPP.DmgPersonID,
                   (SELECT CONVERT(real, 1) / Count(*) AS PersonFactor
                    FROM ShFinanzPlan_DmgPerson
                    WHERE ShFinanzPlanID = BBG.ShFinanzPlanID AND IstUnterstuetzt = 1
                   ) AS PersonFactor,
                   CASE WHEN EXISTS (SELECT *
                                     FROM ShZahlungsmodus          SZM
                                       LEFT  JOIN FlZahlungsweg    FLW ON FLW.FlZahlungswegID = IsNull(STZ.FlZahlungswegID, SZM.FlZahlungswegID)
                                     WHERE SZM.ShZahlungsmodusID = STZ.ShZahlungsmodusID
                                       AND ( (FLW.FlKreditorID IS NULL AND STZ.ShZahlungsartCode BETWEEN 103 AND 104)
                                          OR FLW.FlKreditorID IN (SELECT FLZ2.FlKreditorID
                                                                  FROM ShFinanzPlan_DmgPerson  SPP
                                                                    INNER JOIN FlZahlungsweg   FLZ2 ON FLZ2.FlZahlungswegID = SPP.FlZahlungswegID
                                                                  WHERE SPP.ShFinanzPlanID = @ShFinanzPlanID) ) )
                   THEN 0 ELSE 1 END AS Dritte
                 FROM BgBudget                        BBG
                   INNER JOIN ShBeleg                 SBL ON SBL.BgBudgetID     = BBG.BgBudgetID
                   INNER JOIN ShTeilzahlung           STZ ON STZ.ShBelegID      = SBL.ShBelegID
                   INNER JOIN ShFinanzPlan_DmgPerson  SPP ON SPP.ShFinanzPlanID = BBG.ShFinanzPlanID
                 WHERE BBG.BgBudgetID = @BgBudgetID
                   AND SPP.IstUnterstuetzt = 1
                   AND (STZ.DmgPersonID IS NULL OR STZ.DmgPersonID = SPP.DmgPersonID)
                )                 STZ ON STZ.ShBelegID = BPO.ShBelegID
      LEFT  JOIN ShZahlungsmodus  SZM ON SZM.ShZahlungsmodusID = STZ.ShZahlungsmodusID
      LEFT  JOIN ShSpezkonto      SPK ON SPK.ShSpezkontoID = BPO.ShSpezkontoID
    WHERE BPO.BgBudgetID = @BgBudgetID
      AND BPO.BgPositionCode != 5  -- Vermögen
      AND @RefDate BETWEEN IsNull(BPO.GueltigVon, '19000101') AND IsNull(BPO.GueltigBis, '20790606')
      AND (IsNull(STZ.PersonFactor, 1) * BPO.BetragBudget > $0.00)
    GROUP BY BPO.BgPositionID, BPO.BgPositionCode, SPT.ShPositionTypCode, SPT.ShPositionTypID, STZ.ShZahlungsmodusID


  INSERT INTO @BgPosition (BgPositionID, BgPositionCode, ShZahlungsmodusID, ShSpezkontoID, ShPositionTypID, Bezeichnung, Betrag, FlKostenartID)
    SELECT SEZ.ShEinzelzahlungID, 100, SZM.ShZahlungsmodusID, SEZ.ShSpezkontoID, SEZ.ShPositionTypID,
           SEZ.NameEinzelzahlung, SEZ.Betrag, SEZ.FlKostenartID
    FROM ShEinzelzahlung          SEZ
      LEFT  JOIN XLOVCode         XLC ON XLC.LOVName = 'ShStatusEinzelzahlung' AND XLC.Code = SEZ.ShStatusEinzelzahlungCode
      LEFT  JOIN ShPositionTyp    SPT ON SPT.ShPositionTypID   = SEZ.ShPositionTypID
      LEFT  JOIN ShSpezkonto      SSK ON SSK.ShSpezkontoID     = SEZ.ShSpezkontoID
      LEFT  JOIN ShTeilzahlung    STL ON STL.ShBelegID         = SEZ.ShBelegID
      LEFT  JOIN ShZahlungsmodus  SZM ON SZM.ShZahlungsmodusID = STL.ShZahlungsmodusID
    WHERE SEZ.BgBudgetID = @BgBudgetID


  INSERT INTO @budget
    SELECT BPO.BgPositionCode, XPC.Text,
      BPO.ShPositionTypCode, XPT.Text,
      BPO.ShPositionTypID,
      BPO.Dritte, BPO.ShZahlungsmodusID, BPO.ShSpezkontoID,
      CASE BPO.BgPositionCode
        WHEN 1   THEN 'Einnahmen, ' + CASE WHEN BPO.Dritte = 1 THEN 'vom Sozialdienst' ELSE 'von Klient' END + ' verwaltet'
        WHEN 2   THEN CASE WHEN BPO.ShSpezkontoID IS NULL
          THEN 'Vergütung an ' + CASE WHEN BPO.Dritte = 1 THEN 'Dritte' ELSE 'Klient' END
          ELSE 'Gutschrift auf Ausgabekonti'
        END
        WHEN 100 THEN
          CASE
            WHEN BPO.ShSpezkontoID IS NOT NULL THEN 'Finanzierung durch ' + dbo.fnLOVText('ShSpezkontoTyp', SPK.ShSpezkontoTypCode)
            WHEN SPT.ShPositionTypCode = 100   THEN 'Finanzierung als SIL ' + SPT.Name
            ELSE 'Finanzierung durch Grundbedarf'
          END
      END,
      BPO.Bezeichnung, BPO.Betrag, KOA.IdFibuKostenart
    FROM @BgPosition  BPO
      INNER JOIN XLOVCode       XPC ON XPC.LOVName = 'BgPosition' AND XPC.Code = BPO.BgPositionCode
      LEFT  JOIN XLOVCode       XPT ON XPT.LOVName = 'ShPositionTyp' AND XPT.Code = BPO.ShPositionTypCode
      LEFT  JOIN ShPositionTyp  SPT ON SPT.ShPositionTypID = BPO.ShPositionTypID
      LEFT  JOIN ShSpezkonto    SPK ON SPK.ShSpezkontoID = BPO.ShSpezkontoID
      LEFT  JOIN FlKostenart    KOA ON KOA.FlKostenartID = BPO.FlKostenartID
    ORDER BY CASE WHEN XPC.SortKey = -1 THEN 100 ELSE XPC.SortKey END, XPT.SortKey
  RETURN
END
GO