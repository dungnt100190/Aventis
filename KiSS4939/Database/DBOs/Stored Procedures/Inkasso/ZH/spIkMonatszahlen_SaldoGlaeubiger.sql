SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spIkMonatszahlen_SaldoGlaeubiger
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spIkMonatszahlen_SaldoGlaeubiger.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 11:22 $
  $Revision: 21 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Ansicht der Gläubiger bei Monatszahlen Saldo
    @Param0:   FaLeistungID.
    @Param1:   BeapersonID.
    @Param2:   Saldo berechnen bis.
  -
  TEST:    EXEC dbo.spIkMonatszahlen_SaldoGlaeubiger -1, 1, '20090101'
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spIkMonatszahlen_SaldoGlaeubiger.sql $
 * 
 * 21    11.12.09 11:57 Lloreggia
 * Header aktualisiert
 * 
 * 20    6.11.09 8:45 Nweber
 * #5333: Änderung der Suchregel um den aktuellen gültiger Rechtstitel zu
 * finden.
 * 
 * 19    4.11.09 8:04 Nweber
 * #5437: Gläubiger vom aktuellen gültigen Rechtstitel nur für
 * Alimenteninkasso ALBV/ALV Leistungen.
 * 
 * 18    2.11.09 9:53 Nweber
 * #5333: Wenn zwei Rechtstitel bestehen muss der Gläubiger des aktuell
 * gültigen Rechtstitels angezeigt werden
 * 
 * 17    15.10.09 15:05 Nweber
 * #5333: Gläubiger von alle Rechtstitel anzeigen.
 * 
 * 16    12.10.09 12:29 Nweber
 * #5333: Gläubiger vom aktuellster Rechtstitel anzeigen
 * 
 * 15    28.09.09 12:03 Nweber
 * #5283:  BetragSaldo und BetragSaldoVermittelt müssen unabhängig vom
 * eingegebenen "Saldo berechnen bis" Datum sein
 * 
 * 14    27.09.09 12:43 Nweber
 * #5116: nur Gläubiger vom aktuellster Rechtstitel auflisten.
 * 
 * 12    21.08.09 18:59 Rhesterberg
 * #5116: ALBV / ALV - Fehler Nachzahlungen
 * 
 * 11    21.08.09 18:56 Rhesterberg
 * #5116: ALBV / ALV - Fehler Nachzahlungen
 * 
 * 10    18.08.09 19:11 Rhesterberg
 * #5116: ALBV / ALV - Fehler Nachzahlungen
 * 
 * 9     18.08.09 18:10 Rhesterberg
 * #5116: ALBV / ALV - Fehler Nachzahlungen
 * 
 * 8     18.08.09 17:16 Rhesterberg
 * #5116: ALBV / ALV - Fehler Nachzahlungen
 * 
 * 7     8.08.09 18:09 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 6     2.08.09 13:36 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 5     1.08.09 19:44 Rhesterberg
 * #5116: ALBV / ALV - Fehler Nachzahlungen
 * 
 * 4     1.08.09 19:11 Rhesterberg
 * #5116: ALBV / ALV - Fehler Nachzahlungen
 * 
 * 3     30.07.09 11:14 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 2     4.07.09 13:57 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 1     28.06.09 2:27 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
=================================================================================================*/

CREATE Procedure dbo.spIkMonatszahlen_SaldoGlaeubiger
(
  @FaLeistungID INT,
  @NurALBVGlaeubigerAnzeigen BIT,
  @SaldoBis DATETIME
)
AS BEGIN

  SELECT DISTINCT
    G.BaPersonID,
    G.IstElternteil,
    [Name] = P.Name + IsNull(' '+P.Vorname, '') + 
      IsNull(', ' + Convert(varchar, P.Geburtsdatum, 104) + ' ', ''),
    [Alter] = dbo.fnGetAge(P.Geburtsdatum, GetDate()),
    BetragALBV = CASE 
      WHEN G.IstElternteil = 1 THEN NULL 
      ELSE (
        SELECT TOP 1 P.Wert3 FROM dbo.AmAbPosition P WITH(READUNCOMMITTED)
        LEFT JOIN dbo.AmAbKind K WITH(READUNCOMMITTED) ON K.AmAbKindID = P.AmAbKindID
        LEFT JOIN dbo.AmAnspruchsberechnung A WITH(READUNCOMMITTED) ON A.AmAnspruchsberechnungID = P.AmAnspruchsberechnungID
        LEFT JOIN dbo.FaLeistung M WITH(READUNCOMMITTED) ON M.FaLeistungID = A.FaLeistungID
        WHERE M.FaFallID = L.FaFallID 
        AND L.FaProzessCode IN (402,403,404)
        AND K.BaPersonID = G.BaPersonID
        AND A.AmBerechnungsStatusCode = 3  -- bewilligt
        AND (
          (P.AmAbPositionsArtID =  730 AND L.FaProzessCode IN (402,403) AND K.BerechtigtCode IN (1,2)) OR 
          (P.AmAbPositionsArtID = 3290 AND L.FaProzessCode IN (404)     AND K.BerechtigtCode IN (3))
        )
        ORDER BY A.BerechnungDatumAb
      )
    END,
    BetragSaldo = CASE WHEN G.IstElternteil = 1 THEN NULL ELSE 
    (
      -- Nein, Vorsaldi ist mit einmaliger Forderung abgedeckt
      -- IsNull(G.VorSaldo,0) + (SELECT  
      -- TODO : Vorsaldo von wo?
      (SELECT  
        -- Betrag Zahlung IST : wenn mehrere RT bestehen, Betrag immer nur aus alten Daten nehmen
        -SUM(IsNull(CASE 
          WHEN S.Einmalig = 1 THEN IsNull(S.BetragEinmalig, 0)
          -- 0 bei Daten des neuen Konzepts:
          WHEN S.IkRechtstitelID IS NULL AND IsNull(S.HatMehrereAlteRT, 0) = 1 THEN 0
          ELSE IsNull(S.BetragZahlung,0)
        END,0)) 
        -- Betrag Zahlung SOLL : wenn mehrere RT bestehen, Betrag immer nur aus neuen Daten nehmen
        +SUM(IsNull(CASE
          WHEN S.Einmalig = 1 THEN 0 
          -- 0 bei Daten des alten Konzepts:
          WHEN S.IkRechtstitelID IS NOT NULL AND IsNull(S.HatMehrereAlteRT, 0) = 1 THEN 0  
          ELSE IsNull(S.BetragZahlungSoll,0)
        END,0)) 
      FROM dbo.IkPosition S WITH(READUNCOMMITTED)
      WHERE S.FaLeistungID = R.FaLeistungID 
      AND S.BaPersonID = G.BaPersonID 
      AND (S.Einmalig = 0 OR S.IkBuchungsartCode IN (2,3)) )
    )
    END,
    BetragSaldoTotal = CASE WHEN G.IstElternteil = 1 THEN NULL ELSE 
    (
      -- Nein, Vorsaldi ist mit einmaliger Forderung abgedeckt
      -- IsNull(G.VorSaldo,0) + (SELECT  
      -- TODO : Vorsaldo von wo?
      (SELECT  
        -- Betrag Zahlung IST : wenn mehrere RT bestehen, Betrag immer nur aus alten Daten nehmen
        -SUM(IsNull(CASE 
          WHEN S.Einmalig = 1 THEN IsNull(S.BetragEinmalig, 0)
          -- 0 bei Daten des neuen Konzepts:
          WHEN S.IkRechtstitelID IS NULL AND IsNull(S.HatMehrereAlteRT, 0) = 1 THEN 0
          ELSE IsNull(S.BetragZahlung,0)
        END,0)) 
        -- Betrag Zahlung SOLL : wenn mehrere RT bestehen, Betrag immer nur aus neuen Daten nehmen
        +SUM(IsNull(CASE
          WHEN S.Einmalig = 1 THEN 0
          -- 0 bei Daten des alten Konzepts:
          WHEN S.IkRechtstitelID IS NOT NULL AND IsNull(S.HatMehrereAlteRT, 0) = 1 THEN 0
          ELSE IsNull(S.BetragZahlungSoll,0)
        END,0))
      FROM dbo.IkPosition S WITH(READUNCOMMITTED)
      WHERE S.FaLeistungID = R.FaLeistungID 
      AND S.BaPersonID = G.BaPersonID 
      AND (S.Einmalig = 0 OR S.IkBuchungsartCode IN (2,3)))
    )
    END,
    BetragSaldoVermittelt = CASE WHEN G.IstElternteil = 1 THEN NULL ELSE (
      SELECT 
        SUM(CASE 
          -- SOLL Wert nur von neuen Daten
          WHEN S.Einmalig = 1 THEN 0
          -- 18.08.2009 : 
          -- bei Daten des alten Konzepts nicht verwenden, nur wenn keine neue MZ erstellt wurde
          -- WHEN S.IkRechtstitelID IS NOT NULL THEN 0  
          WHEN S.IkRechtstitelID IS NOT NULL AND IsNull(S.HatMehrereAlteRT, 0) = 1 THEN 0  
          WHEN IsNull(S.TotalAlimentSoll,0) > IsNull(S.BetragALBVSoll,0) 
            THEN IsNull(S.TotalAlimentSoll,0) - IsNull(S.BetragALBVSoll,0)
          ELSE 0 END)
        -SUM(CASE 
          -- IST Wert nur von alten Daten, wenn vorhanden
          WHEN S.Einmalig = 1 THEN 0
          WHEN S.IkRechtstitelID IS NULL AND IsNull(S.HatMehrereAlteRT, 0) = 1 THEN 0  -- bei Daten des neune Konzepts, aber mit alten Daten
          WHEN IsNull(S.TotalAliment,0) > IsNull(S.BetragALBV,0) 
            THEN IsNull(S.TotalAliment,0) - IsNull(S.BetragALBV,0)
          ELSE 0 END)
        +SUM(CASE 
          WHEN S.Einmalig = 0 THEN 0
          --ALV Anpassung: ist immer negativ:
          WHEN S.IkForderungEinmaligCode = 121 THEN IsNull(ABS(S.BetragEinmalig),0)
          --ALBV Anpassung: ist immer positiv:
          WHEN S.IkForderungEinmaligCode = 122 THEN -IsNull(ABS(S.BetragEinmalig),0)
          ELSE 0 END)
      FROM dbo.IkPosition S WITH(READUNCOMMITTED) 
      WHERE S.FaLeistungID = R.FaLeistungID 
      AND S.BaPersonID = G.BaPersonID 
      AND (S.Einmalig = 0 OR S.IkBuchungsartCode IN (4,5))
      AND (S.Einmalig = 0 OR not exists(
        SELECT top 1 1 FROM KbBuchung BUC WHERE BUC.IkPositionID = S.IkPositionID 
        AND BUC.KbBuchungStatusCode = 8
      ))
    )
    END,
    Guthaben = Convert(money, 0.0),
    Saldo = Convert(money, 0.0),
    VorSaldo = Convert(money, 0.0), 
    G.IkGlaeubigerStatusCode,  
    GZW.BaZahlungswegID_ALBV,
    GZW.BaZahlungswegID_ALBVZusatz,
    GZW.BetragZusatz,
    GZW.IntVerrechnung_ALBV,
    Info = Convert(varchar(200), '')
  FROM dbo.IkGlaeubiger G WITH(READUNCOMMITTED)
  LEFT JOIN dbo.IkRechtstitel R WITH(READUNCOMMITTED) ON R.IkRechtstitelID = G.IkRechtstitelID
  LEFT JOIN dbo.FaLeistung L WITH(READUNCOMMITTED) ON L.FaLeistungID = R.FaLeistungID
  LEFT JOIN dbo.BaPerson P WITH(READUNCOMMITTED) ON P.BaPersonID = G.BaPersonID
  LEFT JOIN dbo.IkInterneVerrechnung GZW WITH(READUNCOMMITTED) ON GZW.IkInterneVerrechnungID = (
    SELECT TOP 1 IV.IkInterneVerrechnungID FROM dbo.IkInterneVerrechnung IV WITH(READUNCOMMITTED)
    WHERE IV.FaLeistungID = L.FaLeistungID
      AND IV.BaPersonID = G.BaPersonID
      AND IV.DatumVon <= GetDate()
    ORDER BY IV.DatumVon DESC
  )
  WHERE R.FaLeistungID = @FaLeistungID
    -- Wenn zwei Rechtstitel bestehen, muss der/die Gläubiger/in des aktuell bzw. zu letzt gültigen Rechtstitel angezeigt werden (nur für Alimenteninkasso ALBV/ALV)
    AND (L.FaProzessCode != 405
      -- Gläubiger nur in einem Rechtstitel
      OR (SELECT Count(DISTINCT R1.IkRechtstitelID)
          FROM dbo.IkGlaeubiger G1 WITH(READUNCOMMITTED)
            LEFT JOIN dbo.IkRechtstitel R1 WITH(READUNCOMMITTED) ON R1.IkRechtstitelID = G1.IkRechtstitelID
          WHERE R1.FaLeistungID = L.FaLeistungID
            AND G1.BaPersonID = G.BaPersonID
            AND G1.IkGlaeubigerStatusCode != 9
      ) = 1 
      -- Reiter Forderung mit Eintrag aktuell gültiger Forderung oder zu letzt gültiger Forderung
      OR (SELECT TOP 1 F.IkRechtstitelID
          FROM IkForderung F
          WHERE F.DatumAnpassenAb <= GetDate()
            AND F.IkRechtstitelID IN (
              SELECT DISTINCT R1.IkRechtstitelID
              FROM dbo.IkGlaeubiger G1 WITH(READUNCOMMITTED)
                LEFT JOIN dbo.IkRechtstitel R1 WITH(READUNCOMMITTED) ON R1.IkRechtstitelID = G1.IkRechtstitelID
              WHERE R1.FaLeistungID = L.FaLeistungID
                AND G1.BaPersonID = G.BaPersonID
                AND G1.IkGlaeubigerStatusCode != 9)
          ORDER BY F.DatumAnpassenAb DESC
      ) = R.IkRechtstitelID
    )
    AND G.IkGlaeubigerStatusCode != 9
    AND (0 = @NurALBVGlaeubigerAnzeigen OR L.FaProzessCode IN (406,407) OR G.BaPersonID IN (
      SELECT K.BaPersonID FROM dbo.AmAbKind K WITH(READUNCOMMITTED) 
      LEFT JOIN dbo.AmAnspruchsberechnung A WITH(READUNCOMMITTED) ON A.AmAnspruchsberechnungID = K.AmAnspruchsberechnungID
      LEFT JOIN dbo.FaLeistung M WITH(READUNCOMMITTED) ON M.FaLeistungID = A.FaLeistungID
      WHERE L.FaFallID = M.FaFallID AND K.BerechtigtCode = 1 AND M.FaProzessCode IN (402,403)
        AND A.BerechnungDatumAb <= @SaldoBis
    ))
  GROUP BY 
    G.BaPersonID, P.Name, P.Vorname, P.Geburtsdatum, 
    L.FaFallID, L.FaProzessCode, R.FaLeistungID, 
    G.IstElternteil, G.IkGlaeubigerStatusCode,
    GZW.BaZahlungswegID_ALBV, GZW.BaZahlungswegID_ALBVZusatz, 
    GZW.BetragZusatz, GZW.IntVerrechnung_ALBV
  ORDER BY [Alter] DESC, [Name] 

END

GO 