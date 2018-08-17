SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spPscdGetAbstimmungProKostenart
GO
/*===============================================================================================
  $Revision: 12 $
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

CREATE PROCEDURE dbo.spPscdGetAbstimmungProKostenart
(
  @From datetime = NULL,
  @To   datetime = NULL
)
AS

--SET @From = dbo.fnDateSerial(2008,3,30)
--SET @To   = dbo.fnDateSerial(2008,6,23)

DECLARE @StartDate datetime, @EndDate datetime
SET @From = CASE WHEN @From IS NULL THEN DateAdd(d,-1,GetDate()) ELSE @From END
SET @To   = CASE WHEN @To   IS NULL THEN @From ELSE @To END

DECLARE @KontoklasseDebitor int
DECLARE @KontoklasseKreditor int
SET @KontoklasseDebitor = 1
SET @KontoklasseKreditor = 2


SET @StartDate = dbo.fnDateOf(@From)
--nur 1 Tag--
SET @EndDate   = DateAdd(ms, -10, DateAdd(d, 1, @To))

--alles bis gestern
--SET @To = DateAdd(d,-1,GetDate())
--SET @EndDate   = DateAdd(ms, -10, DateAdd(d, 1, @To))

-- W-Bruttobelege
SELECT BKA.KontoNr, 
       Hauptvorgang = COALESCE(KBB.Hauptvorgang, KBP.SpezHauptvorgang, CASE WHEN KBB.Abgetreten = 1 THEN BKA.HauptvorgangAbtretung ELSE BKA.Hauptvorgang END),
       Teilvorgang  = COALESCE(KBB.Teilvorgang,  KBP.SpezTeilvorgang,  CASE WHEN KBB.Abgetreten = 1 THEN BKA.TeilvorgangAbtretung  ELSE BKA.Teilvorgang  END),
       Soll  =  (CASE WHEN KBP.Betrag > 0 THEN KBP.Betrag ELSE 0 END),
       Haben = -(CASE WHEN KBP.Betrag < 0 THEN KBP.Betrag ELSE 0 END), CONVERT(varchar,KBB.TransferDatum,104) AS TransferDatum,
       KBB.BelegNr, KBP.PositionImBeleg, CONVERT(varchar,KBB.BelegDatum,104) AS BelegDatum, KBB.KbBuchungStatusCode, TransferDatum AS TransferDatumOrder
FROM KbBuchungBrutto               KBB
  INNER JOIN KbBuchungBruttoPerson KBP ON KBP.KbBuchungBruttoID = KBB.KbBuchungBruttoID
  INNER JOIN BgKostenart           BKA ON BKA.BgKostenartID     = IsNull(KBB.BgKostenartID,KBP.SpezBgKostenartID)
WHERE KBB.TransferDatum IS NOT NULL AND KBB.TransferDatum >= @StartDate AND KBB.TransferDatum <= @EndDate
  AND KBP.PositionImBeleg IS NOT NULL AND KBP.PositionImBeleg <> 0

UNION ALL

-- W-Nettobelege
SELECT '', 2000, 2100, Soll  = -(CASE WHEN KBB.Betrag > 0 THEN 0 ELSE KBB.Betrag END),
                       Haben =  (CASE WHEN KBB.Betrag < 0 THEN 0 ELSE KBB.Betrag END), CONVERT(varchar,KBB.TransferDatum,104) AS TransferDatum,
       KBB.BelegNr, 1, CONVERT(varchar,KBB.BelegDatum,104) AS BelegDatum, KBB.KbBuchungStatusCode, TransferDatum AS TransferDatumOrder
FROM KbBuchung                  KBB
WHERE KBB.TransferDatum IS NOT NULL AND KBB.TransferDatum >= @StartDate AND KBB.TransferDatum <= @EndDate AND KBB.Betrag <> 0 AND KBB.ModulID = 3 AND BgBudgetID IS NOT NULL
  AND KBB.StorniertKbBuchungID IS NULL

UNION

-- W-Nettobelege, Stornobuchungen
SELECT '', 2000, 2100, Soll  =  (CASE WHEN KBB.Betrag < 0 THEN 0 ELSE KBB.Betrag END),
                       Haben = -(CASE WHEN KBB.Betrag > 0 THEN 0 ELSE KBB.Betrag END), CONVERT(varchar,KBB.TransferDatum,104) AS TransferDatum,
       KBB.BelegNr, 1, CONVERT(varchar,KBB.BelegDatum,104) AS BelegDatum, KBB.KbBuchungStatusCode, TransferDatum AS TransferDatumOrder
FROM KbBuchung                  KBB
WHERE KBB.TransferDatum IS NOT NULL AND KBB.TransferDatum >= @StartDate AND KBB.TransferDatum <= @EndDate AND KBB.Betrag <> 0 AND KBB.ModulID = 3 AND BgBudgetID IS NOT NULL
  AND KBB.StorniertKbBuchungID IS NOT NULL
  AND KBB.BelegNr IS NOT NULL /*Stornobuchungen innerhalb KiSS ausschliessen. Leider ist bei diesen das Transferdatum gesetzt*/


UNION

-- A-Belege
SELECT BKA.KontoNr, KBK.Hauptvorgang, KBK.Teilvorgang,
       Soll  = CASE WHEN KBK.Betrag > 0 AND (SOL.KbKontoKlasseCode = 1 /*Forderung*/  OR SOL.KbKontoKlasseCode = 2 /*Storno einer Auszahlung*/) THEN  KBK.Betrag
                    WHEN KBK.Betrag < 0 AND (HAB.KbKontoKlasseCode = 2 /*Auszahlung*/ OR HAB.KbKontoKlasseCode = 1 /*Storno einer Forderung*/ ) THEN -KBK.Betrag
                    ELSE 0
               END,
       Haben = CASE WHEN KBK.Betrag > 0 AND (HAB.KbKontoKlasseCode = 2 /*Auszahlung*/ OR HAB.KbKontoKlasseCode = 1 /*Storno einer Forderung*/ ) THEN  KBK.Betrag
                    WHEN KBK.Betrag < 0 AND (SOL.KbKontoKlasseCode = 1 /*Forderung*/  OR SOL.KbKontoKlasseCode = 2 /*Storno einer Auszahlung*/) THEN -KBK.Betrag
                    ELSE 0 
               END,
       CONVERT(varchar,CASE WHEN KBB.StorniertKbBuchungID IS NOT NULL THEN KBB.ErstelltDatum ELSE KBB.TransferDatum END,104) AS TransferDatum, 
       KBB.BelegNr, KBK.PositionImBeleg, CONVERT(varchar,KBB.BelegDatum,104) AS BelegDatum, KBB.KbBuchungStatusCode,
       CASE WHEN KBB.StorniertKbBuchungID IS NOT NULL THEN KBB.ErstelltDatum ELSE KBB.TransferDatum END AS TransferDatumOrder
---,SOL.*, HAB.*
FROM KbBuchung                  KBB
  INNER JOIN KbBuchungKostenart KBK ON KBK.KbBuchungID   = KBB.KbBuchungID
  INNER JOIN BgKostenart        BKA ON BKA.BgKostenartID = KBK.BgKostenartID
  LEFT  JOIN KbKonto            SOL ON SOL.KbPeriodeID   = KBB.KbPeriodeID AND SOL.KontoNr = KBB.SollKtoNr
  LEFT  JOIN KbKonto            HAB ON HAB.KbPeriodeID   = KBB.KbPeriodeID AND HAB.KontoNr = KBB.HabenKtoNr
WHERE KBB.TransferDatum IS NOT NULL AND 
      KBB.TransferDatum >= @StartDate AND KBB.TransferDatum <= @EndDate AND
      KBK.Betrag <> 0 AND
     (KBB.ModulID = 4 OR (KBB.ModulID = 3 AND KBB.BgBudgetID IS NULL))

UNION

-- K-Belege
SELECT '', 9000, 9000, Soll  = -(CASE WHEN KGB.Betrag > 0 THEN 0 ELSE KGB.Betrag END),
                       Haben =  (CASE WHEN KGB.Betrag < 0 THEN 0 ELSE KGB.Betrag END), CONVERT(varchar,KGB.TransferDatum,104) AS TransferDatum,
       KGB.PscdBelegNr, 1, CONVERT(varchar,KGB.BuchungsDatum,104) AS BelegDatum, KGB.KgBuchungStatusCode, TransferDatum AS TransferDatumOrder
FROM KgBuchung                  KGB
WHERE KGB.TransferDatum IS NOT NULL AND KGB.PscdBelegNr IS NOT NULL AND KGB.TransferDatum >= @StartDate AND KGB.TransferDatum <= @EndDate AND KGB.Betrag <> 0

UNION

-- WV-Belege
SELECT '', WVP.Hauptvorgang, WVP.Teilvorgang, Soll  =  (CASE WHEN WVP.Betrag < 0 THEN 0 ELSE  WVP.Betrag END),
                                              Haben =  (CASE WHEN WVP.Betrag > 0 THEN 0 ELSE -WVP.Betrag END), CONVERT(varchar,WVP.TransferDatum,104) AS TransferDatum,
       WVP.PscdBelegNr, 1, CONVERT(varchar,WVP.TransferDatum,104) AS BelegDatum, WVP.KbWVEinzelpostenStatusCode, TransferDatum AS TransferDatumOrder
FROM KbWVEinzelposten WVP
WHERE WVP.TransferDatum IS NOT NULL AND WVP.PscdBelegNr IS NOT NULL AND WVP.TransferDatum >= @StartDate AND WVP.TransferDatum <= @EndDate AND WVP.Betrag <> 0

ORDER BY TransferDatumOrder, PositionImBeleg

