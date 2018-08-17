SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spIkMonatszahlen_Ansicht
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spIkMonatszahlen_Ansicht.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 11:21 $
  $Revision: 8 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Ansicht der Monatszahlen, doppelte Rechtstitel zusammengezogen
    @Param0:   FaLeistungID.
  -
  TEST:    EXEC dbo.spIkMonatszahlen_Ansicht -1
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spIkMonatszahlen_Ansicht.sql $
 * 
 * 8     11.12.09 11:57 Lloreggia
 * Header aktualisiert
 * 
 * 7     22.08.09 17:33 Rhesterberg
 * #5116: ALBV / ALV - Fehler Nachzahlungen
 * 
 * 6     15.07.09 17:25 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 5     12.07.09 19:05 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 4     6.07.09 18:30 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 3     4.07.09 13:41 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 2     28.06.09 15:02 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 1     28.06.09 2:27 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
=================================================================================================*/

CREATE Procedure dbo.spIkMonatszahlen_Ansicht
(
  @FaLeistungID INT
)
AS BEGIN
  -- Kein Details anzeigen, doppelte Rechtstitel zusammenziehen
  select
    IkPositionID = CONVERT(INT, NULL), 
    B.FaLeistungID, 
    IkRechtstitelID = CONVERT(INT, NULL),
    Datum = dbo.fnDateSerial(B.Jahr, B.Monat, 1), B.Monat, B.Jahr, B.BaPersonID,
    FehlerInfos = CONVERT(VARCHAR, NULL),
    TotalAliment = SUM(case 
      when B.IkRechtstitelID is NULL and IsNull(B.HatMehrereAlteRT, 0) = 1 then 0  -- IST immer nur von alten Daten
      else B.TotalAliment 
    end),
    TotalAlimentSoll = SUM(case 
      when B.IkRechtstitelID is NULL then B.TotalAlimentSoll -- SOLL immer von neuen Daten
      else 0
    end),
    BetragALBV = SUM(CASE
      when G.IstElternteil = 1 then 0
      when B.IkRechtstitelID is NULL and IsNull(B.HatMehrereAlteRT, 0) = 1 then 0  -- IST immer nur von alten Daten
      else B.BetragALBV
    end),
    BetragALBVSoll = SUM(CASE
      when G.IstElternteil = 1 then 0
      when B.IkRechtstitelID is NULL then B.BetragALBVSoll  -- SOLL immer von neuen Daten
      else 0
    end),
    BetragKiZulage = SUM(CASE
      when G.IstElternteil = 1 then 0
      when B.IkRechtstitelID is NULL and IsNull(B.HatMehrereAlteRT, 0) = 1 then 0  -- IST immer nur von alten Daten
      else B.BetragKiZulage
    end),
    BetragKiZulageSoll = SUM(CASE
      when G.IstElternteil = 1 then 0
      when B.IkRechtstitelID is NULL then B.BetragKiZulageSoll -- SOLL immer von neuen Daten
      else 0
    end),
    BetragALBVverrechnung = SUM(case
      when G.IstElternteil = 1 then 0
      when B.IkRechtstitelID is NULL and IsNull(B.HatMehrereAlteRT, 0) = 1 then 0  -- IST immer nur von alten Daten
      else B.BetragALBVverrechnung
    end),
    BetragALBVverrechnungSoll = SUM(case
      when G.IstElternteil = 1 then 0
      when B.IkRechtstitelID is NULL then B.BetragALBVverrechnungSoll -- SOLL immer von neuen Daten
      else 0
    end),
    BetragZahlung = SUM(CASE
      when G.IstElternteil = 1 then 0
      when B.IkRechtstitelID is NULL and IsNull(B.HatMehrereAlteRT, 0) = 1 then 0  -- IST immer nur von alten Daten
      else B.BetragZahlung
    end),
    BetragZahlungSoll = SUM(CASE
      when G.IstElternteil = 1 then 0
      when B.IkRechtstitelID is NULL then B.BetragZahlungSoll  -- SOLL immer von neuen Daten
      else 0
    end),
    IndexStandBeiBerechnung = AVG(B.IndexStandBeiBerechnung), 
    IndexStandDatum = MAX(B.IndexStandDatum),
    ErledigterMonat = CONVERT(bit, case 
      when Exists(
        -- TRUE, wenn es Positionen der alten RT gibt, welche nicht verbucht sind
        select top 1 1 from dbo.IkPosition BX WITH(READUNCOMMITTED)
        where BX.FaLeistungID = B.FaLeistungID
        and BX.Einmalig = 0
        and BX.Monat = B.Monat
        and BX.Jahr = B.Jahr
        and BX.BaPersonID = B.BaPersonID
        and (not (BX.IkRechtstitelID is NULL and IsNull(BX.HatMehrereAlteRT, 0) = 1))
        -- nach allen unverbuchten Suchen:
        and (not Exists(
          -- TRUE, wenn es mind. 1 unstornierte Buchung gibt --> ist erledigt
          select top 1 1 from dbo.KbBuchung BU WITH(READUNCOMMITTED)
          where BU.IkPositionID = BX.IkPositionID
          and BU.KbBuchungStatusCode != 8
        ))
        and (not (L.FaProzessCode in (406,407) and BX.BetragZahlung = 0))
      ) then 0 else 1
    end),
    IntVerrechnung_ALBV = IV.IntVerrechnung_ALBV,
    IntVerrechnung_ALV = case
      when L.FaProzessCode = 405 then IV.IntVerrechnung_ALV else null
    end,
    IntVerrechnung_KiZu = case
      when L.FaProzessCode = 405 then IV.IntVerrechnung_KiZu else null
    end,
    Bemerkung = CONVERT(VARCHAR(500), NULL), 
    BetragVermittelt = SUM(case
      when B.IkRechtstitelID is NULL and IsNull(B.HatMehrereAlteRT, 0) = 1 then 0  -- IST immer nur von alten Daten
      when G.IstElternteil = 1 then IsNull(B.TotalAliment,0)
      when IsNull(B.TotalAliment,0) > IsNull(B.BetragALBV,0)
        then IsNull(B.TotalAliment,0) - IsNull(B.BetragALBV,0)
      else 0
    end),
    BetragVermitteltSoll = SUM(case
      when B.IkRechtstitelID is NOT NULL then 0 -- SOLL immer von neuen Daten
      when G.IstElternteil = 1 then IsNull(B.TotalAlimentSoll,0)
      when IsNull(B.TotalAlimentSoll,0) > IsNull(B.BetragALBVSoll,0)
        then IsNull(B.TotalAlimentSoll,0) - IsNull(B.BetragALBVSoll,0)
      else 0
    end),
    Person = case
      when L.FaProzessCode in (405,406,407) then P.Name + IsNull(' '+P.Vorname, '')
      else '[Stadt Zürich]'
    end,
    JahrMonat = Convert(DateTime, (Convert(varchar, B.Jahr) + '.' + Convert(varchar, B.Monat) + '.01')),
    IstBarzahlung = CONVERT(BIT, NULL),
    BarzahlungID = CONVERT(INT, NULL),
    RTName = CONVERT(VARCHAR, '*'),
    RTNameNeu = dbo.fnIkRechtstitelName(NULL, B.FaLeistungID, B.Jahr, B.Monat, B.BaPersonID)

  from dbo.IkPosition B
  -- hier dbo.IkRechtstitel nur noch für Abdeckung altes Konzept verwenden:
  left outer join dbo.IkRechtstitel R WITH(READUNCOMMITTED) on R.IkRechtstitelID = B.IkRechtstitelID
  left outer join dbo.FaLeistung L WITH(READUNCOMMITTED) on L.FaLeistungID = B.FaLeistungID
  left outer join dbo.BaPerson P WITH(READUNCOMMITTED) on P.BaPersonID = B.BaPersonID
  left outer join dbo.IkGlaeubiger G WITH(READUNCOMMITTED) on G.IkGlaeubigerID = (
    select top 1 GX.IkGlaeubigerID from dbo.IkGlaeubiger GX
    left outer join dbo.IkRechtstitel RX WITH(READUNCOMMITTED) on RX.IkRechtstitelID = GX.IkRechtstitelID
    where RX.FaLeistungID = @FaLeistungID
      and GX.BaPersonID = B.BaPersonID
    -- zuerst den aktiven, dann in Vorbereitung, dann prov eingestellt, dann ungültig alle anderen
    order by case GX.IkGlaeubigerStatusCode when 2 then 1 when 1 then 2 when 3 then 3 else 4 end asc
  )
  left outer join dbo.IkInterneVerrechnung IV WITH(READUNCOMMITTED) on IV.IkInterneVerrechnungID = (
    select top 1 IVX.IkInterneVerrechnungID FROM dbo.IkInterneVerrechnung IVX WITH(READUNCOMMITTED)
    where IVX.FaLeistungID = B.FaLeistungID
    and IVX.BaPersonID = B.BaPersonID
    and IVX.DatumVon <= B.Datum
    order by IVX.DatumVon DESC
  )
  where B.FaleistungID = @FaLeistungID
  and B.Einmalig = 0
  group by B.FaLeistungID, B.Monat, B.Jahr, B.BaPersonID, P.Name, P.VorName, L.FaProzessCode, 
    IntVerrechnung_ALBV, IntVerrechnung_ALV, IntVerrechnung_KiZu
  order by B.Jahr desc, B.Monat desc, P.Name + IsNull(' '+P.Vorname, '') asc 


END

GO


