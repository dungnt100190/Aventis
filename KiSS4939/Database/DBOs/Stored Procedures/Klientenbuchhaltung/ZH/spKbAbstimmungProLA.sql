SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spKbAbstimmungProLA;
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  .
    @LAs:      
    @DatumVon: 
    @DatumBis: 
    @BelegNr:  
  -
  RETURNS: Tabelle für ...
           Table 0: ...
           Table 1: ...
  -
  TEST:    EXEC dbo.spKbAbstimmungProLA '121';
           EXEC dbo.spKbAbstimmungProLA 'NULL';
=================================================================================================*/

CREATE PROCEDURE dbo.spKbAbstimmungProLA
(
  @LAs       VARCHAR(MAX),
  @DatumVon  DATETIME = NULL,
  @DatumBis  DATETIME = NULL,
  @BelegNr   BIGINT = NULL
)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- start call
  -----------------------------------------------------------------------------
  SET NOCOUNT ON;
  
  SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

  IF(@LAs IS NULL)
  BEGIN
    SET @LAs = '814,850,810,820,140,821,120,121,170,720';
  END;

  DECLARE @Leistungsarten TABLE
  (
    KontoNr int
  )

  INSERT INTO @Leistungsarten
    SELECT CONVERT(int,Splitvalue) FROM dbo.fnSplitStringToValues(@LAs,',',0);

  DECLARE @Output TABLE
  (
    PSCDBelegNr BIGINT, 
    PositionImBeleg INT,
    KontoNr VARCHAR(10), 
    BetragEffektiv MONEY, 
    ValutaDatum VARCHAR(101),
    BuchungsStatus VARCHAR(200),
    Buchungstext VARCHAR(200), 
    OriginalPSCDBelegNr VARCHAR(200),
    FallNummer INT,
    BaPersonID INT,
    PeriodeVon VARCHAR(101),
    PeriodeBis VARCHAR(101),
    Sozialzentrum VARCHAR(200),
    OrgUnit VARCHAR(100),
    Fallfuehrung VARCHAR(400),
    Masterbudget VARCHAR(10),
    Jahr INT,
    Monat INT,
    TechnischeInfo VARCHAR(100)
  )

  --Ausgaben
  INSERT INTO @Output(PSCDBelegNr, PositionImBeleg, KontoNr, BetragEffektiv, ValutaDatum, BuchungsStatus, Buchungstext, OriginalPSCDBelegNr, FallNummer, BaPersonID, 
                      PeriodeVon, PeriodeBis, Sozialzentrum, OrgUnit, Fallfuehrung, Masterbudget, Jahr, Monat, TechnischeInfo)
  SELECT
    PSCDBelegNr         = KBB.BelegNr, 
    PositionImBeleg     = BBP.PositionImBeleg, 
    KontoNr             = KOA.KontoNr, 
    BetragEffektiv      = BBP.Betrag, 
    ValutaDatum         = CONVERT(VARCHAR(101), KBB.ValutaDatum, 104),
    BuchungsStatus      = XA.Text,
    Buchungstext        = BBP.Buchungstext, 
    OriginalPSCDBelegNr = NULL,
    FallNummer          = LEI.FaFallID,
    BaPersonID          = BBP.BaPersonID,
    PeriodeVon          = CONVERT(VARCHAR(101), BBP.VerwPeriodeVon, 104),
    PeriodeBis          = CONVERT(VARCHAR(101), BBP.VerwPeriodeBis, 104), 
    Sozialzentrum       = LOC.Text,
    OrgUnit             = ORG.ItemName,
    Fallfuehrung        = USR.NameVorname,
    Masterbudget        = CASE BDG.Masterbudget
                            WHEN 1 THEN 'M'
                            ELSE NULL
                          END,
    Jahr                = BDG.Jahr,
    Monat               = BDG.Monat,
    TechnischeInfo      = 'ausgaben'
  FROM dbo.KbBuchungBrutto               KBB
    INNER JOIN dbo.KbBuchungBruttoPerson BBP ON BBP.KbBuchungBruttoID =KBB.KbBuchungBruttoID
    INNER JOIN dbo.BgKostenart           KOA ON KOA.BgKostenartID = KBB.BgKostenartID
    LEFT  JOIN dbo.FaLeistung            LEI ON LEI.FaLeistungID = KBB.FaLeistungID
    LEFT  JOIN dbo.BgBudget              BDG ON BDG.BgBudgetID = KBB.BgBudgetID
    LEFT  JOIN dbo.vwUserSimple          USR ON USR.UserID = LEI.UserID
    LEFT  JOIN dbo.XOrgUnit_User         OUU ON OUU.UserID = USR.UserID
                        AND OUU.OrgUnitMemberCode = 2 --2: Mitglied
    LEFT  JOIN dbo.XOrgUnit              ORG ON ORG.OrgUnitID = OUU.OrgUnitID
    LEFT  JOIN dbo.XLOVCode              LOC ON LOC.Value1 = ORG.ParentID
                        AND LOC.LOVName = 'FaSozialzentrum'
    INNER JOIN @Leistungsarten           L   ON L.KontoNr = KOA.KontoNr
    INNER JOIN (SELECT Code, TEXT FROM XlovCode WHERE LovName = 'KbBuchungsStatus') XA ON XA.Code = KBB.KbBuchungStatusCode
  WHERE KBB.StorniertKbBuchungBruttoID IS NULL
    AND KBB.NeubuchungVonKbBuchungBruttoID IS NULL 
    AND KBB.MigDetailBuchungID IS NULL
    AND (   BBP.Betrag <= $0.00 --Ausgabe
      OR BBP.Betrag  > $0.00 AND KBB.Abgetreten = 0)  --nicht abgetretene Einnahme
    AND KBB.TransferDatum IS NOT NULL --Suchregel: Nur Buchungen anzeigen, die ins PSCD übertragen wurden
    AND KBB.ValutaDatum BETWEEN @DatumVon AND @DatumBis
    AND (@BelegNr IS NULL OR kbb.BelegNr = @BelegNr)
  

  UNION ALL

  -- Zahlungseingänge  
  SELECT 
    PSCDBelegNr         = ISNULL(BUC_STO.BelegNr,BUC_AUS.BelegNr), 
    PositionImBeleg     = 1, 
    KontoNr             = KOA.KontoNr, 
    BetragEffektiv      = OPA.Betrag,
    ValutaDatum         = CONVERT(VARCHAR(101), ISNULL(BUC_STO.BelegDatum,BUC_AUS.BelegDatum), 104),
    BuchungsStatus      = XA.Text,
    Buchungstext        = KBB.Text,
    OriginalPSCDBelegNr = CONVERT(VARCHAR(200), KBB.BelegNr),
    FallNummer          = LEI.FaFallID,
    BaPersonID          = NULL, 
    PeriodeVon          = NULL, 
    PeriodeBis          = NULL, 
    Sozialzentrum       = LOC.Text,
    OrgUnit             = ORG.ItemName,
    Fallfuehrung        = USR.NameVorname,
    Masterbudget        = CASE BDG.Masterbudget
                            WHEN 1 THEN 'M'
                            ELSE NULL
                          END,
    Jahr                = BDG.Jahr,
    Monat               = BDG.Monat,
    TechnischeInfo      = 'zahlungseingänge:' + CONVERT(VARCHAR, KBB.KbBuchungBruttoID) + '/' + ISNULL(CONVERT(VARCHAR, BUC_STO.BelegDatum), '-') + '/' + ISNULL(CONVERT(VARCHAR, BUC_AUS.BelegDatum), '-')
  FROM dbo.KbBuchungBrutto               KBB
    INNER JOIN dbo.BgKostenart           KOA ON KOA.BgKostenartID = KBB.BgKostenartID
    LEFT  JOIN dbo.FaLeistung            LEI ON LEI.FaLeistungID = KBB.FaLeistungID
    LEFT  JOIN dbo.BgBudget              BDG ON BDG.BgBudgetID = KBB.BgBudgetID
    LEFT  JOIN dbo.vwUserSimple          USR ON USR.UserID = LEI.UserID
    LEFT  JOIN dbo.XOrgUnit_User         OUU ON OUU.UserID = USR.UserID
                                            AND OUU.OrgUnitMemberCode = 2 --2: Mitglied
    LEFT  JOIN dbo.XOrgUnit              ORG ON ORG.OrgUnitID = OUU.OrgUnitID
    LEFT  JOIN dbo.XLOVCode              LOC ON LOC.Value1 = ORG.ParentID
                                            AND LOC.LOVName = 'FaSozialzentrum'
    INNER JOIN @Leistungsarten           L   ON L.KontoNr = KOA.KontoNr
    LEFT  JOIN dbo.KbBuchungBrutto  KBB_Orig ON KBB_Orig.KbBuchungBruttoID = KBB.NeubuchungVonKbBuchungBruttoID
    INNER JOIN dbo.KbBuchung          BUC_OP ON BUC_OP.KbBuchungID = dbo.fnBruttoToNetto(KBB.KbBuchungBruttoID)
    INNER JOIN dbo.KbOpAusgleich         OPA ON OPA.OpBuchungID = BUC_OP.KbBuchungID
    INNER JOIN dbo.KbBuchung         BUC_AUS ON BUC_AUS.KbBuchungID = OPA.AusgleichBuchungID
                                            AND BUC_AUS.StorniertKbBuchungID IS NULL -- Von PSCD ausgelöste Stornos von Forderungen herausfiltern (nur statistisch)

    OUTER APPLY (SELECT AusgleichBuchungID
                 FROM dbo.KbOpAusgleich
                 WHERE OpBuchungID = OPA.AusgleichBuchungID 
                   AND KbAusgleichGrundCode = OPA.KbAusgleichGrundCode 
                   AND Betrag = -OPA.Betrag
                 GROUP BY AusgleichBuchungID) OPAS
                                          
    LEFT  JOIN dbo.KbBuchung         BUC_STO ON BUC_STO.KbBuchungID = OPAS.AusgleichBuchungID
    INNER JOIN (SELECT Code, TEXT FROM XlovCode WHERE LovName = 'KbBuchungsStatus') XA ON XA.Code = KBB.KbBuchungStatusCode
  WHERE KBB.StorniertKbBuchungBruttoID     IS NULL
    AND KBB.NeubuchungVonKbBuchungBruttoID IS NULL 
    AND KBB.MigDetailBuchungID IS NULL
    AND KBB.Betrag > $0.00 AND KBB.Abgetreten = 1   -- abgetretene Einnahme
    AND KBB.TransferDatum IS NOT NULL               -- Suchregel: Nur Buchungen anzeigen, die ins PSCD übertragen wurden
    AND ISNULL(BUC_STO.BelegDatum,BUC_AUS.BelegDatum) BETWEEN @DatumVon AND @DatumBis
    AND (@BelegNr IS NULL OR kbb.BelegNr = @BelegNr /*OR buc_op.BelegNr = @BelegNr OR buc_aus.belegNr = @BelegNr*/)
  
  UNION ALL

  -- Umbuchungen 
  SELECT 
    PSCDBelegNr         = KBB.BelegNr, 
    PositionImBeleg     = BBP.PositionImBeleg, 
    KontoNr             = KOA.KontoNr, 
    BetragEffektiv      = BBP.Betrag, 
    ValutaDatum         = CONVERT(VARCHAR(101), KBB.ValutaDatum, 104),
    BuchungsStatus      = XA.Text,
    Buchungstext        = BBP.Buchungstext, 
    OriginalPSCDBelegNr = KBB_Orig.BelegNr,
    FallNummer          = LEI.FaFallID,
    BaPersonID          = BBP.BaPersonID,
    PeriodeVon          = CONVERT(VARCHAR(101), BBP.VerwPeriodeVon, 104),
    PeriodeBis          = CONVERT(VARCHAR(101), BBP.VerwPeriodeBis, 104), 
    Sozialzentrum       = LOC.Text,
    OrgUnit             = ORG.ItemName,
    Fallfuehrung        = USR.NameVorname,
    Masterbudget        = CASE BDG.Masterbudget
                            WHEN 1 THEN 'M'
                            ELSE NULL
                          END,
    Jahr                = BDG.Jahr,
    Monat               = BDG.Monat,
    TechnischeInfo      = CONVERT(VARCHAR, KBB_Orig.Abgetreten) + '/' + CONVERT(VARCHAR, KBB_Orig.Betrag)
  FROM dbo.KbBuchungBrutto               KBB
    INNER JOIN dbo.KbBuchungBruttoPerson BBP ON BBP.KbBuchungBruttoID =KBB.KbBuchungBruttoID
    INNER JOIN dbo.BgKostenart           KOA ON KOA.BgKostenartID = KBB.BgKostenartID
    LEFT  JOIN dbo.FaLeistung            LEI ON LEI.FaLeistungID = KBB.FaLeistungID
    LEFT  JOIN dbo.BgBudget              BDG ON BDG.BgBudgetID = KBB.BgBudgetID
    LEFT  JOIN dbo.vwUserSimple          USR ON USR.UserID = LEI.UserID
    LEFT  JOIN dbo.XOrgUnit_User         OUU ON OUU.UserID = USR.UserID
                                            AND OUU.OrgUnitMemberCode = 2 --2: Mitglied
    LEFT  JOIN dbo.XOrgUnit              ORG ON ORG.OrgUnitID = OUU.OrgUnitID
    LEFT  JOIN dbo.XLOVCode              LOC ON LOC.Value1 = ORG.ParentID
                                            AND LOC.LOVName = 'FaSozialzentrum'
    INNER JOIN @Leistungsarten           L   ON L.KontoNr = KOA.KontoNr
    INNER JOIN (SELECT Code, TEXT FROM XlovCode WHERE LovName = 'KbBuchungsStatus') XA ON XA.Code = KBB.KbBuchungStatusCode
    CROSS APPLY (SELECT BelegNr = CONVERT(VARCHAR(200), BelegNr), Betrag, KbBuchungBruttoID, Abgetreten, PscdKennzeichen
                 FROM dbo.KbBuchungBrutto
                 WHERE KbBuchungBruttoID = KBB.NeubuchungVonKbBuchungBruttoID 
                    OR KbBuchungBruttoID = KBB.StorniertKbBuchungBruttoID 
                 UNION ALL
                 SELECT BelegNr = NummernKreis + '-' + CONVERT(VARCHAR(200), BelegNummer), Betrag, KbBuchungBruttoID=MigDetailBuchungID, Abgetreten = KBB.Abgetreten, PscdKennzeichen = NULL
                 FROM dbo.MigDetailBuchung 
                 WHERE MigDetailBuchungID = KBB.MigDetailBuchungID) KBB_Orig 
  WHERE KBB.TransferDatum IS NOT NULL --Suchregel: Nur Buchungen anzeigen, die ins PSCD übertragen wurden
    AND KBB.ValutaDatum BETWEEN @DatumVon AND @DatumBis
    --Bei statistischen Buchungen (sprich: abgetretenen Einnahmen) wollen wir nur Umbuchungen, aber keine Stornierungen. D.h.: Stornobuchung nur wenn es auch eine Neubuchung gibt
    AND (KBB_Orig.Betrag < $0.00 AND (KBB_Orig.PscdKennzeichen IS NULL OR KBB_Orig.PscdKennzeichen <> 'E') -- Ausgaben, aber keine negativen Einnahmen
      OR KBB_Orig.Abgetreten = 0 --Nicht abgetreten
      --oder bei nicht-abgetretenen Einnahmen: nur Umbuchungen, das heisst: nur anzeigen wenn es eine Neubuchung gibt
      OR KBB_Orig.KbBuchungBruttoID IN (SELECT NeubuchungVonKbBuchungBruttoID FROM dbo.KbBuchungBrutto WHERE NeubuchungVonKbBuchungBruttoID IS NOT NULL)
      )
    AND (@BelegNr IS NULL OR kbb_orig.BelegNr = @BelegNr)

  SELECT KontoNr, Total=SUM(BetragEffektiv)
  FROM @Output
  GROUP BY KontoNr

  SELECT
    [PSCD-BelegNr]     = PSCDBelegNr,
    [Pos. im Beleg]    = PositionImBeleg,
    [Konto-Nr]         = KontoNr,
    [Betrag effektiv]  = BetragEffektiv,
    [Valutadatum]      = ValutaDatum,
    [Buchungs-Status]  = BuchungsStatus,
    Buchungstext       = Buchungstext,
    [Original-BelegNr] = OriginalPSCDBelegNr,
    [Fall-Nummer]      = FallNummer,
    [Person]           = PRS.NameVorname,
    [Verw.von]         = PeriodeVon,
    [Verw.bis]         = PeriodeBis,
    Sozialzentrum      = Sozialzentrum,
    OE                 = OrgUnit,
    [Fallführung]      = Fallfuehrung,
    Masterbudget       = Masterbudget,
    Jahr               = Jahr,
    Monat              = Monat,
    [Technische Info$] = TechnischeInfo
  FROM @Output OUT
    LEFT JOIN dbo.vwPersonSimple PRS ON PRS.BaPersonID = OUT.BaPersonID
  ORDER BY ValutaDatum
END;
GO
