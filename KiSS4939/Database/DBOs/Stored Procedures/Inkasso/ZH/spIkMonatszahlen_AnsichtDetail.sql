SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spIkMonatszahlen_AnsichtDetail
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spIkMonatszahlen_AnsichtDetail.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 11:21 $
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Ansicht der Monatszahlen, alle Details anzeigen
    @Param0:   FaLeistungID.
  -
  TEST:    EXEC dbo.spIkMonatszahlen_AnsichtDetail -1
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spIkMonatszahlen_AnsichtDetail.sql $
 * 
 * 5     11.12.09 11:57 Lloreggia
 * Header aktualisiert
 * 
 * 4     12.07.09 19:05 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 3     2.07.09 4:54 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 2     28.06.09 15:02 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 1     28.06.09 2:27 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
=================================================================================================*/

CREATE Procedure dbo.spIkMonatszahlen_AnsichtDetail
(
  @FaLeistungID INT
)
AS BEGIN
  -- Alle Details anzeigen, auch Zeilen nach altem Konzept (IkRechtstitel nicht leer)
SELECT
    B.IkPositionID, B.FaLeistungID, B.IkRechtstitelID,
    B.Datum, B.Monat, B.Jahr, B.BaPersonID,
    B.FehlerInfos,
    B.TotalAliment,
    B.TotalAlimentSoll,
    BetragALBV = CASE
      when G.IstElternteil = 1 then NULL
      else B.BetragALBV
    end,
    BetragALBVSoll = CASE
      when G.IstElternteil = 1 then NULL
      else B.BetragALBVSoll
    end,
    BetragKiZulage = CASE
      when G.IstElternteil = 1 then NULL
      else B.BetragKiZulage
    end,
    BetragKiZulageSoll = CASE
      when G.IstElternteil = 1 then NULL
      else B.BetragKiZulageSoll
    end,
    B.BetragALBVverrechnung,
    B.BetragALBVverrechnungSoll,
    BetragZahlung = CASE
      when G.IstElternteil = 1 then NULL
      else B.BetragZahlung
    end,
    BetragZahlungSoll = CASE
      when G.IstElternteil = 1 then NULL
      else B.BetragZahlungSoll
    end,
    B.IndexStandBeiBerechnung, B.IndexStandDatum,
    ErledigterMonat = convert(bit, case
      -- neues Konzept: immer erledigt, wenn neues Konzept mit alten Daten
      when (B.IkRechtstitelID IS NULL and IsNull(B.HatMehrereAlteRT, 0) = 1) then 1
      -- bei UeBH, KKBB erledigt, wenn Zahlung 0 ist
      when (L.FaProzessCode in (406,407) and B.BetragZahlung = 0)
        -- erledigt, wenn eine Buchung existiert, welche nicht storniert ist
        or Exists(
          select top 1 BUC.KbBuchungID from dbo.KbBuchung BUC WITH(READUNCOMMITTED)
          where BUC.IkPositionID = B.IkPositionID
          and BUC.KbBuchungStatusCode != 8
        )
        then 1
      else 0 end
    ),
    IntVerrechnung_ALBV = IV.IntVerrechnung_ALBV,
    IntVerrechnung_ALV = case
      when L.FaProzessCode = 405 then IV.IntVerrechnung_ALV else null
    end,
    IntVerrechnung_KiZu = case
      when L.FaProzessCode = 405 then IV.IntVerrechnung_KiZu else null
    end,
    B.Bemerkung, 
    BetragVermittelt = case
      when G.IstElternteil = 1 then IsNull(B.TotalAliment,0)
      when IsNull(B.TotalAliment,0) > IsNull(B.BetragALBV,0)
        then IsNull(B.TotalAliment,0) - IsNull(B.BetragALBV,0)
      else 0
    end,
    BetragVermitteltSoll = case
      when G.IstElternteil = 1 then IsNull(B.TotalAlimentSoll,0)
      when IsNull(B.TotalAlimentSoll,0) > IsNull(B.BetragALBVSoll,0)
        then IsNull(B.TotalAlimentSoll,0) - IsNull(B.BetragALBVSoll,0)
      else 0
    end,
    Person = case
      when L.FaProzessCode in (405,406,407) then P.Name + IsNull(' '+P.Vorname, '')
      else '[Stadt Zürich]'
    end,
    JahrMonat = Convert(DateTime, (Convert(varchar, B.Jahr) + '.' + Convert(varchar, B.Monat) + '.01')),
    IstBarzahlung = convert(bit, case when Exists(
      select K.KbBuchungID from dbo.KbBuchung K WITH(READUNCOMMITTED)
      where K.IkPositionID = B.IkPositionID
      and K.PscdZahlwegArt = 'C'
      and K.IkForderungArtCode in (10,11,12)
    ) then 1 else 0 end),
    BarzahlungID = (
      select top 1 K.KbBuchungID from dbo.KbBuchung K WITH(READUNCOMMITTED)
      where K.IkPositionID = B.IkPositionID
      and K.PscdZahlwegArt = 'C'
      and K.IkForderungArtCode in (10,11,12)
    ),
    RTName = case when R.IkRechtstitelID is null then '*' else R.Bezeichnung end,
    RTNameNeu = dbo.fnIkRechtstitelName(B.IkPositionID, NULL, NULL, NULL, NULL)

  from dbo.IkPosition B
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
  where B.FaleistungID = @FaleistungID
  and B.Einmalig = 0
  order by B.Jahr desc, B.Monat desc, 
    P.Name + IsNull(' ' + P.Vorname, '') asc, 
    case when B.IkRechtstitelID is null then 0 else 1 end asc, B.IkRechtstitelID desc

END

GO

