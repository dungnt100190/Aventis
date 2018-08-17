SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spIkMonatszahlen_Saldo
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spIkMonatszahlen_Saldo.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 11:22 $
  $Revision: 9 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Ansicht der Monatszahlen für Saldo für einen Gläubiger
    @Param0:   FaLeistungID.
    @Param1:   BeapersonID.
    @Param2:   Saldo berechnen bis.
  -
  TEST:    EXEC dbo.spIkMonatszahlen_Saldo -1, -1, '20090101'
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spIkMonatszahlen_Saldo.sql $
 * 
 * 9     11.12.09 11:57 Lloreggia
 * Header aktualisiert
 * 
 * 8     21.08.09 18:56 Rhesterberg
 * #5116: ALBV / ALV - Fehler Nachzahlungen
 * 
 * 7     18.08.09 19:11 Rhesterberg
 * #5116: ALBV / ALV - Fehler Nachzahlungen
 * 
 * 6     8.08.09 18:09 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 5     30.07.09 11:14 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 4     4.07.09 13:49 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 3     2.07.09 4:55 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 2     28.06.09 15:02 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 1     28.06.09 2:27 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
=================================================================================================*/

CREATE Procedure dbo.spIkMonatszahlen_Saldo
(
  @FaLeistungID INT,
  @BaPersonID INT,
  @SaldoBis DATETIME
)
AS BEGIN

  select 
    P.IkPositionID,
    P.Datum, P.Monat, P.Jahr,
    ErledigterMonat = convert(bit, CASE 
      WHEN P.IkRechtstitelID IS NULL AND IsNull(P.HatMehrereAlteRT, 0) = 1 THEN 1
      WHEN Exists(
        select top 1 BUC.KbBuchungID from dbo.KbBuchung BUC WITH(READUNCOMMITTED)
        where BUC.IkPositionID = P.IkPositionID
          and BUC.KbBuchungStatusCode != 8
      ) THEN 1 
      ELSE 0 
    END),
    Titel = CASE
      WHEN G.IstElternteil = 1 THEN NULL 
      WHEN P.Einmalig = 0 THEN 'periodische Zahlung'
      WHEN P.BetragIstNegativ = 1 THEN dbo.fnLOVText('IkForderungEinmalig', P.IkForderungEinmaligCode)
      ELSE NULL
    END,
    Unterstuetzungsfall = IV.IntVerrechnung_ALBV,
    -- Verrechnung IST aus alten Daten
    BetragVerrechg = CASE
      WHEN G.IstElternteil = 1 THEN NULL 
      WHEN P.Einmalig = 1 THEN NULL
      WHEN P.IkRechtstitelID IS NULL AND IsNull(P.HatMehrereAlteRT, 0) = 1 THEN NULL
      ELSE IsNull(P.BetragALBVverrechnung,0)
    END, 
    -- Verrechnung SOLL aus neuen Daten
    BetragVerrechgSoll = CASE
      WHEN G.IstElternteil = 1 THEN NULL 
      WHEN P.Einmalig = 1 THEN NULL
      WHEN P.IkRechtstitelID IS NOT NULL THEN NULL
      ELSE IsNull(P.BetragALBVverrechnungSoll,0)
    END, 
    BetragALBVIst = CASE 
      WHEN G.IstElternteil = 1 THEN NULL 
      WHEN P.Einmalig = 1 THEN NULL
      WHEN P.IkRechtstitelID IS NULL AND IsNull(P.HatMehrereAlteRT, 0) = 1 THEN NULL
      ELSE IsNull(P.BetragALBV,0)
    END,
    BetragALBVSoll = CASE 
      WHEN G.IstElternteil = 1 THEN NULL 
      WHEN P.Einmalig = 1 THEN NULL
      WHEN P.IkRechtstitelID IS NOT NULL THEN NULL  -- bei Daten des alten Konzepts
      ELSE IsNull(P.BetragALBVSoll,0)
    END,
    Auszahlung = CASE 
      WHEN G.IstElternteil = 1 THEN NULL
      WHEN P.Einmalig = 1 THEN IsNull(P.BetragEinmalig, 0)
      WHEN P.IkRechtstitelID IS NULL AND IsNull(P.HatMehrereAlteRT, 0) = 1 THEN NULL
      ELSE IsNull(P.BetragZahlung,0)
    END,
    AuszahlungSoll = CASE 
      WHEN G.IstElternteil = 1 THEN NULL
      WHEN P.Einmalig = 1 THEN NULL -- IsNull(P.BetragEinmalig, 0)
      WHEN P.IkRechtstitelID IS NOT NULL AND IsNull(P.HatMehrereAlteRT, 0) = 1 THEN NULL  -- bei Daten des alten Konzepts
      ELSE IsNull(P.BetragZahlungSoll,0)
    END,
    ALBVDiff = CASE 
      WHEN G.IstElternteil = 1 THEN NULL 
      WHEN P.Einmalig = 1 THEN NULL
      WHEN P.IkRechtstitelID IS NOT NULL THEN -IsNull(P.BetragALBV,0)  -- bei Daten des alten Konzepts
      WHEN P.IkRechtstitelID IS NULL AND IsNull(P.HatMehrereAlteRT, 0) = 1 THEN IsNull(P.BetragALBVSoll,0)
      ELSE IsNull(P.BetragALBVSoll,0) - IsNull(P.BetragALBV,0)
    END,
    BetragVermittelt = CASE 
      WHEN P.Einmalig = 1 THEN NULL
      WHEN P.IkRechtstitelID IS NULL AND IsNull(P.HatMehrereAlteRT, 0) = 1 THEN NULL
      WHEN G.IstElternteil = 1 THEN IsNull(P.TotalAliment,0)
      WHEN IsNull(P.TotalAliment,0) > IsNull(P.BetragALBV,0) 
        THEN IsNull(P.TotalAliment,0) - IsNull(P.BetragALBV,0)
      ELSE 0
    END,
    BetragVermitteltSoll = CASE 
      WHEN P.Einmalig = 1 THEN NULL
      WHEN P.IkRechtstitelID IS NOT NULL THEN NULL  -- beim alten Konzept
      WHEN G.IstElternteil = 1 THEN IsNull(P.TotalAlimentSoll,0)
      WHEN IsNull(P.TotalAlimentSoll,0) > IsNull(P.BetragALBVSoll,0) 
        THEN IsNull(P.TotalAlimentSoll,0) - IsNull(P.BetragALBVSoll,0)
      ELSE 0
    END,
    Guthaben = Convert(money, 0.0),
    Saldo = Convert(money, 0.0),
    SaldoVerm = Convert(money, 0.0),
    Kommentar = convert(varchar(200), ''),
    P.Bemerkung,
    P.IkRechtstitelID,
    P.Einmalig,
    RTName = CASE
      WHEN P.IkRechtstitelID IS NOT NULL THEN R.Bezeichnung
      ELSE '* ' + IsNull(dbo.fnIkRechtstitelName(P.IkPositionID, P.FaLeistungID, P.Jahr, P.Monat, P.BaPersonID), '')
    END

  from dbo.IkPosition P WITH(READUNCOMMITTED)
  left outer join dbo.IkRechtstitel R WITH (READUNCOMMITTED) on R.IkRechtstitelID = P.IkRechtstitelID
  left outer join dbo.IkGlaeubiger G WITH (READUNCOMMITTED) on G.IkGlaeubigerID = (
    select top 1 Q.IkGlaeubigerID from dbo.IkGlaeubiger Q WITH(READUNCOMMITTED)
    left join dbo.IkRechtstitel R on R.IkRechtstitelID = Q.IkRechtstitelID
    where R.FaLeistungID = @FaLeistungID
      and Q.BaPersonID = P.BaPersonID
    -- zuerst den aktiven, dann in Vorbereitung, dann prov eingestellt, dann ungültig alle anderen
    order by case Q.IkGlaeubigerStatusCode when 2 then 1 when 1 then 2 when 3 then 3 else 4 end asc
  )
  left outer join dbo.IkInterneVerrechnung IV WITH (READUNCOMMITTED) on IV.IkInterneVerrechnungID = (
    select top 1 IVX.IkInterneVerrechnungID from dbo.IkInterneVerrechnung IVX WITH(READUNCOMMITTED)
    where IVX.FaLeistungID = P.FaLeistungID 
    and IVX.BaPersonID = P.BaPersonID
    and IVX.DatumVon <= case when P.Einmalig = 0 then P.Datum else IsNull(P.VerwPeriodeVon, P.Datum) end
    order by IVX.DatumVon desc
  )
  where P.FaLeistungID = @FaLeistungID
    and (P.Einmalig = 0 or P.IkBuchungsartCode in (2,3))
    and P.BaPersonID = @BaPersonID
    and P.Datum <= @SaldoBis
  order by P.Datum asc,
    case when P.IkRechtstitelID is null then 0 else 1 end desc, P.IkRechtstitelID asc
 
END

GO