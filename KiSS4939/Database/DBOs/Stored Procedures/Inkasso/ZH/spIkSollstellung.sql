SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spIkSollstellung
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spIkSollstellung.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 11:23 $
  $Revision: 19 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1: Jahr.
    @Param2: Monat.
    @Param3: ModulID.
    @Param4: UserID.
    @Param5: faFallID.
    @Param6: Filtern nach Monat.
    @Param7: Filtern nach Typ.
    @Param8: Filtern nach Status.
    @Param9: Zusatzdaten für Sollstellung Poweruser hinzufügen.
  -
  RETURNS: Ansicht für Sollstellung Mitarbeiter und Sollstellung Poweruser.
  -
  TEST: Siehe weiter unten.
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spIkSollstellung.sql $
 * 
 * 19    11.12.09 11:57 Lloreggia
 * Header aktualisiert
 * 
 * 18    1.12.09 13:07 Nweber
 * #5529: für interne Verrechnungen muss das Datum der Position anstatt
 * der Verwendungsperiode genommen werden wenn die Verwendungsperiode leer
 * ist.
 * 
 * 17    25.09.09 11:04 Nweber
 * #5155: Interne Verrechnung suchen mit dem VerwPeriodeBis und nicht
 * Datum von der Position
 * 
 * 16    16.09.09 9:12 Mmarghitola
 * #5103: 0er-Betraege ausblenden
 * 
 * 15    8.08.09 18:09 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 14    23.07.09 10:25 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 13    16.07.09 20:02 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 12    12.07.09 19:05 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 11    6.07.09 1:59 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 10    28.06.09 17:36 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 9     28.06.09 17:30 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 8     28.06.09 17:21 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 7     28.06.09 16:56 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 6     3.06.09 16:34 Rhesterberg
 * #4814: Neues Filtern nach Betrag korrigiert, es kamen keine
 * periodischen W-Forderungen
 * 
 * 5     29.04.09 15:49 Rhesterberg
 * #30: interne Verrechnung, Ermittlung Beträge DEBI1 korrigiert
 * 
 * 4     10.03.09 14:39 Rhesterberg
 * 
 * 3     28.02.09 18:02 Rhesterberg
 * 
 * 2     18.01.09 20:35 Rhesterberg
 * 
 * 1     12.01.09 16:23 Rhesterberg
 * 
 * 2     6.01.09 13:15 Rhesterberg
 * 
 * 1     9.09.08 14:59 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

/*
===================================================================================================
Author:      sozheo
Create date: 06.10.2007
Description: Erstellen der Buchungen aus Forderungen
Tests:       
EXEC dbo.spIkSollstellung 2009, 1,     4,    0,   0,     '1',        '6',      '9',         1
                          Jahr  Monat  Modul User FallID FilterMonat FilterTyp FilterStatus InklusiveZusatzDaten
                                                         0, 1,       1-7       1, 2, 3, 9 
===================================================================================================
History:
--------
08.01.2009 : sozheo : neu erstellt
12.01.2009 : sozheo : korrigiert
13.01.2009 : sozheo : korrigiert
28.02.2009 : sozheo : IkPosition.Unterstuetzungsfall eliminiert
28.02.2009 : sozheo : Barzahlung korrigiert
28.02.2009 : sozheo : Zahlungswege korrigiert
09.03.2009 : sozheo : Interneverrechnung erweitert mit ALV und KiZu
31.03.2009 : sozheo : Neues Filtern nach Betrag
07.04.2009 : sozheo : Korrektur für Filtern einmalige Forderungen
03.06.2009 : sozheo : Neues Filtern nach Betrag korrigiert, es kamen keine periodischen W-Forderungen
28.06.2009 : sozheo : #32: Monatszahlen übergeordnet (ALIM5)
06.07.2009 : sozheo : #32: beim neuen Konzept sind Monate mit mehreren RT immer verbucht
12.07.2009 : sozheo : #32: HatMehrereAlteRT mit ISNULL ergänzt
16.07.2009 : sozheo : #32: bei "unverbuchte" Daten mit alten Konzept nicht anzeigen
22.07.2009 : sozheo : #32: bei "unverbuchte" einmalige Forderungen anzeigen
06.08.2009 : sozheo : Key FaLeistung hinzugefügt
===================================================================================================
*/

CREATE PROCEDURE [dbo].[spIkSollstellung] 
  @Jahr INT,
  @Monat INT,
  @ModulID INT,
  @UserID INT,
  @FallID INT,
  @FilterMonat CHAR(1),
  @FilterTyp CHAR(1),
  @FilterStatus CHAR(1),
  @InklusiveZusatzDaten BIT
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON

  DECLARE @SQLString NVARCHAR(MAX)

  DECLARE @Datum DATETIME, @DatumString VARCHAR(10)
  SET @Datum = DATEADD(MONTH, 1, dbo.fnDateSerial(@Jahr, @Monat, 1))
  SET @DatumString = 
      CONVERT(VARCHAR, YEAR(@Datum))
    + CASE WHEN MONTH(@Datum)<10 THEN '0' ELSE '' END + CONVERT(VARCHAR, MONTH(@Datum))
    + CASE WHEN DAY(@Datum)<10 THEN '0' ELSE '' END + CONVERT(VARCHAR, DAY(@Datum))


  SET @SQLString = '
  SELECT 
    IstSelektiert = CONVERT(BIT, 0), F.IkPositionID, F.Monat, F.Jahr, F.Datum,
    F.IkRechtstitelID, HatMehrereAlteRT = ISNULL(F.HatMehrereAlteRT, 0),'

  SET @SQLString = @SQLString + CASE
    -- nur unverbuchte anzeigen, also kann hier fix Erledigt = 0 gesetzt werden
    WHEN @FilterStatus = '1' THEN '
    ErledigterMonat = CONVERT(BIT, 0),'
    -- nur verbuchte anzeigen, also kann hier fix Erledigt = 1 gesetzt werden
    WHEN @FilterStatus = '2' THEN '
    ErledigterMonat = CONVERT(BIT, 1),'
    -- nur fehlerhafte anzeigen, also kann hier fix Erledigt = 1 gesetzt werden
    WHEN @FilterStatus = '3' THEN '
    ErledigterMonat = CONVERT(BIT, 1),'
    -- 06.07.2009 : #32: beim neuen Konzept sind Monate mit mehreren RT immer verbucht
    ELSE '
    ErledigterMonat = CONVERT(BIT, CASE 
      WHEN F.IkRechtstitelID IS NULL AND ISNULL(F.HatMehrereAlteRT, 0) = 1 THEN 1 
      WHEN EXISTS(
        SELECT TOP 1 BUC.KbBuchungID FROM dbo.KbBuchung BUC WITH(READUNCOMMITTED) 
        WHERE BUC.IkPositionID = F.IkPositionID
        AND BUC.KbBuchungStatusCode != 8
      ) THEN 1 
     ELSE 0 END),'
  END

  SET @SQLString = @SQLString + '
    IntVerrechnung_ALBV = IV.IntVerrechnung_ALBV,
    IntVerrechnung_ALV  = CASE WHEN L.FaProzessCode = 405 THEN IV.IntVerrechnung_ALV ELSE NULL END,
    IntVerrechnung_KiZu = CASE WHEN L.FaProzessCode = 405 THEN IV.IntVerrechnung_KiZu ELSE NULL END,
    Glaubiger = P.Name + ISNULL('' '' + P.Vorname, ''''),
    ZahlungAn = CASE 
      WHEN Z.BaPersonID is NULL THEN Zi.Name 
      ELSE Zp.Name + ISNULL('' '' + Zp.Vorname, '''')
    END +
    CASE 
      WHEN Z.AdresseName IS NOT NULL 
        AND Z.AdressePLZ IS NOT NULL 
        AND Z.AdresseOrt IS NOT NULL 
        THEN '' (''+Z.AdresseName + '')''
      ELSE ''''
    END,
    ZusatzzahlungAn = CASE 
      WHEN IV.BaZahlungswegID_ALBVZusatz IS NULL THEN NULL
      WHEN XZ.BaPersonID is NULL then XZi.Name 
      ELSE XZp.Name + ISNULL('' '' + XZp.Vorname, '''')
    END +
    case 
      WHEN XZ.AdresseName IS NOT NULL
        AND XZ.AdressePLZ IS NOT NULL
        AND XZ.AdresseOrt IS NOT NULL
        THEN '' (''+XZ.AdresseName + '')''
      ELSE ''''
    END,
    P.Geburtsdatum,
    Schuldner = Ps.Name + IsNull('' '' + Ps.Vorname, ''''),
    ForderungTitel = CASE 
      WHEN F.Einmalig = 1 THEN X.Text
      WHEN L.FaProzessCode = 405 AND G.IstElternteil = 1 THEN ''Erwachsenenalimente''
      WHEN L.FaProzessCode = 405 AND ( ISNULL(F.BetragALBV,0) + ISNULL(F.BetragALBVverrechnung,0)<= 0) THEN ''ALV''
      WHEN L.FaProzessCode = 405 THEN ''ALBV''
      WHEN L.FaProzessCode = 406 THEN ''UeBH''
      WHEN L.FaProzessCode = 407 THEN ''KKBB''
      WHEN F.Einmalig = 0 THEN XLOV2.Text
      ELSE NULL
    END,
    Username = U.Displaytext,
    Betrag = CASE 
      WHEN F.Einmalig = 1 THEN F.BetragEinmalig
      WHEN L.FaProzessCode IN (301,302,304,408,409,410) THEN F.TotalAliment
      WHEN L.FaProzessCode IN (406,407) THEN F.BetragALBV
      WHEN G.IstElternteil = 1 
        THEN dbo.fnIkGetForderungBetrag(0, F.Einmalig,
          IV.BaZahlungswegID_ALBVZusatz, IV.Betrag, IV.BetragZusatz, F.BetragEinmalig,
          ISNULL(F.TotalAliment,0) )
      WHEN ISNULL(F.BetragALBV,0) > 0 
        THEN dbo.fnIkGetForderungBetrag(0, F.Einmalig,
          IV.BaZahlungswegID_ALBVZusatz, IV.Betrag, IV.BetragZusatz, F.BetragEinmalig,
          ISNULL(F.BetragZahlung,0) ) 
      ELSE dbo.fnIkGetForderungBetrag(0, F.Einmalig,
        IV.BaZahlungswegID_ALBVZusatz, IV.Betrag, IV.BetragZusatz, F.BetragEinmalig,
        ISNULL(F.TotalAliment, 0) ) 
    END,
    ZahlBetrag = CASE 
      WHEN F.Einmalig = 1 AND F.IkForderungEinmaligCode in (151,152,161,162,171,172) THEN F.BetragEinmalig
      WHEN F.BetragZahlung > 0 THEN F.BetragZahlung
      ELSE NULL
    END,
    ZusatzBetrag = CASE 
      WHEN F.Einmalig = 1 THEN NULL
      WHEN L.FaProzessCode in (301,302,304,408,409,410) THEN NULL
      WHEN G.IstElternteil = 1 
        THEN dbo.fnIkGetForderungBetrag(1, F.Einmalig,
          IV.BaZahlungswegID_ALBVZusatz, IV.Betrag, IV.BetragZusatz, F.BetragEinmalig,
          ISNULL(F.TotalAliment,0))
      ELSE dbo.fnIkGetForderungBetrag(1, F.Einmalig,
        IV.BaZahlungswegID_ALBVZusatz, IV.Betrag, IV.BetragZusatz, F.BetragEinmalig,
        ISNULL(F.BetragALBV,0) + ISNULL(F.BetragALBVverrechnung,0))
    END,'

  SET @SQLString = @SQLString + CASE
    -- nur unverbuchte anzeigen, also kann hier fix IstGesendet = 0 gesetzt werden
    WHEN @FilterStatus = '1' THEN '
    IstGesendet = CONVERT(BIT, 0),'
    -- 06.07.2009 : #32: beim neuen Konzept sind Monate mit mehreren RT immer verbucht
    ELSE '
    IstGesendet = CONVERT(BIT, CASE 
      WHEN (F.IkRechtstitelID IS NULL AND ISNULL(F.HatMehrereAlteRT, 0) = 1) THEN 1
      WHEN EXISTS(
        SELECT BUC.KbBuchungStatusCode FROM dbo.KbBuchung BUC WITH(READUNCOMMITTED) 
        WHERE BUC.IkPositionID = F.IkPositionID
        AND NOT BUC.KbBuchungStatusCode IN (2,5,8)
      ) THEN 1 
      ELSE 0 END),'
  END

   -- 06.07.2009 : #32: beim neuen Konzept sind Monate mit mehreren RT immer verbucht
  IF @InklusiveZusatzDaten = 1 SET @SQLString = @SQLString + '
    TotalStornoIstMoeglich = Convert(bit, CASE 
        WHEN (F.IkRechtstitelID IS NULL AND ISNULL(F.HatMehrereAlteRT, 0) = 1) THEN 0
        WHEN EXISTS(
          select K.KbBuchungStatusCode FROM dbo.KbBuchung K WITH(READUNCOMMITTED) 
          where K.IkPositionID = F.IkPositionID 
            AND (K.KbBuchungStatusCode NOT IN (3,8) OR K.IkForderungArtCode IN (10,11,12,13,14,15,31,32))
        ) THEN 0 
        ELSE 1 END),'

/*
    Status = CASE
      WHEN EXISTS(
        select top 1 BUC.KbBuchungID FROM dbo.KbBuchung BUC WITH(READUNCOMMITTED)
        where BUC.IkPositionID = F.IkPositionID 
          AND BUC.KbBuchungStatusCode != 8
      ) THEN ''verbucht''
      ELSE ''nicht verbucht''
    END,'
*/

    -- 06.07.2009 : #32: beim neuen Konzept sind Monate mit mehreren RT immer verbucht
    SET @SQLString = @SQLString + '
    FallPersonID = FF.BaPersonID,
    F.FaLeistungID,
    L.FaProzessCode,
    F.Einmalig,
    IstBarzahlung = CONVERT(BIT, CASE 
      WHEN (F.IkRechtstitelID IS NULL AND ISNULL(F.HatMehrereAlteRT, 0) = 1) THEN 0 
      WHEN EXISTS(
        SELECT QK.KbBuchungID FROM dbo.KbBuchung QK WITH(READUNCOMMITTED) 
        WHERE QK.IkPositionID = F.IkPositionID 
          AND QK.KbAuszahlungsArtCode = 103 -- Bar
          AND QK.IkForderungartCode IN (10,11,12)
      ) THEN 1 
      ELSE 0 END)
  FROM dbo.IkPosition F WITH(READUNCOMMITTED) 
  LEFT OUTER JOIN dbo.IkGlaeubiger G WITH(READUNCOMMITTED) ON G.IkGlaeubigerID = (
    SELECT TOP 1 Q.IkGlaeubigerID from dbo.IkGlaeubiger Q
    LEFT JOIN dbo.IkRechtstitel R ON R.IkRechtstitelID = Q.IkRechtstitelID
    WHERE R.FaLeistungID = F.FaLeistungID
      AND Q.BaPersonID = F.BaPersonID
    -- zuerst den aktiven, dann in Vorbereitung, dann prov eingestellt, dann ungültig alle anderen
    ORDER BY CASE Q.IkGlaeubigerStatusCode WHEN 2 THEN 1 WHEN 1 THEN 2 WHEN 3 THEN 3 ELSE 4 END ASC
  )
  LEFT OUTER JOIN dbo.FaLeistung L WITH(READUNCOMMITTED) ON L.FaLeistungID = F.FaLeistungID
  LEFT OUTER JOIN dbo.FaFall FF WITH(READUNCOMMITTED) ON FF.FaFallID = L.FaFallID
  LEFT OUTER JOIN dbo.BaPerson P WITH(READUNCOMMITTED) ON P.BaPersonID = F.BaPersonID

  LEFT OUTER JOIN dbo.IkInterneVerrechnung IV WITH(READUNCOMMITTED) ON IV.IkInterneVerrechnungID = (
    SELECT TOP 1 IV1.IkInterneVerrechnungID FROM dbo.IkInterneVerrechnung IV1
    WHERE IV1.FaLeistungID = L.FaLeistungID
      AND IV1.BaPersonID = G.BaPersonID
      AND IV1.DatumVon <= CASE WHEN F.VerwPeriodeBis IS NOT NULL THEN F.VerwPeriodeBis ELSE F.Datum END
    ORDER BY IV1.DatumVon DESC
  )
  -- 1. Zahlungsweg
  LEFT OUTER JOIN dbo.BaZahlungsweg Z WITH(READUNCOMMITTED) ON Z.BaZahlungswegID = IV.BaZahlungswegID_ALBV
  LEFT OUTER JOIN dbo.BaPerson Zp WITH(READUNCOMMITTED) ON Zp.BaPersonID = Z.BaPersonID
  LEFT OUTER JOIN dbo.BaInstitution Zi WITH(READUNCOMMITTED) ON Zi.BaInstitutionID = Z.BaInstitutionID
  -- 2. Zahlungsweg
  LEFT OUTER JOIN dbo.BaZahlungsweg XZ WITH(READUNCOMMITTED) ON XZ.BaZahlungswegID = IV.BaZahlungswegID_ALBVZusatz
  LEFT OUTER JOIN dbo.BaPerson XZp WITH(READUNCOMMITTED) ON XZp.BaPersonID = XZ.BaPersonID
  LEFT OUTER JOIN dbo.BaInstitution XZi WITH(READUNCOMMITTED) ON XZi.BaInstitutionID = XZ.BaInstitutionID

  LEFT OUTER JOIN dbo.BaPerson Ps WITH(READUNCOMMITTED) ON Ps.BaPersonID = L.SchuldnerBaPersonID
  LEFT OUTER JOIN dbo.vwUser U ON U.UserID = L.UserID
  LEFT OUTER JOIN dbo.XLOVCode X WITH(READUNCOMMITTED) ON X.LOVName = ''IkForderungEinmalig'' AND X.Code = F.IkForderungEinmaligCode
  LEFT OUTER JOIN dbo.XLOVCode XLOV2 WITH(READUNCOMMITTED) ON XLOV2.LOVName = ''IkForderungPeriodisch'' AND XLOV2.Code = F.IkForderungEinmaligCode'


  -- Filtern nach Datum
  SET @SQLString = @SQLString + CASE 
    WHEN @FilterMonat = '1' THEN '
    WHERE F.Jahr = ' + CONVERT(VARCHAR, @Jahr) + ' AND F.Monat = ' + CONVERT(VARCHAR, @Monat)
    --ELSE 'where F.Datum < DATEADD(MONTH, 1, dbo.fnDateSerial(' + CONVERT(VARCHAR, @Jahr) + ', ' + CONVERT(VARCHAR, @Monat) + ', 1))'
    ELSE '
    WHERE F.Datum < CONVERT(DATETIME, ''' + @DatumString + ''')'
  END
  
  SET @SQLString = @SQLString + '
    AND (NOT (F.IkRechtstitelID IS NULL AND IsNull(F.HatMehrereAlteRT, 0) = 1))'

  -- Filtern nach Typ
  SET @SQLString = @SQLString + '
    AND (L.FaProzessCode NOT IN (405,406,407)
       OR EXISTS(
         SELECT TOP 1 BUC.KbBuchungID FROM dbo.KbBuchung BUC WITH(READUNCOMMITTED)  
         WHERE BUC.IkPositionID = F.IkPositionID AND BUC.KbBuchungStatusCode != 8)
       OR G.IkGlaeubigerStatusCode = 2
       OR F.BaPersonID is NULL )'

  -- Filtern nach FallNummer
  IF ISNULL(@FallID, 0) > 0 BEGIN
    SET @SQLString = @SQLString + CHAR(10) + CHAR(13) + 'AND FF.FaFallID = ' + CONVERT(VARCHAR, @FallID)
  END

  -- Filtern nach Modul
  SET @SQLString = @SQLString + CHAR(10) + CHAR(13) + CASE 
    WHEN @ModulID = 3 THEN 'AND L.FaProzessCode BETWEEN 300 AND 399'
    WHEN @ModulID = 4 THEN 'AND L.FaProzessCode BETWEEN 400 AND 499'
    ELSE ''
  END

  -- 
  -- 31.03.2009 : sozheo : Neues Filtern nach Betrag
  -- 03.06.2009 : sozheo : Neues Filtern nach Betrag korrigiert, es kamen keine periodischen W-Forderungen
  SET @SQLString = @SQLString + CHAR(10) + CHAR(13) + 
    'AND ( ' + CHAR(10) + CHAR(13) + 
    '  L.FaProzessCode NOT IN (405,406,407)  ' + CHAR(10) + CHAR(13) + 
    '  OR (L.FaProzessCode = 405 AND (' + CHAR(10) + CHAR(13) + 
    '    ISNULL(F.BetragALBV,0) + ISNULL(F.BetragALBVverrechnung,0)>0 OR ' +
    '    ISNULL(F.TotalAliment,0) != 0 OR ' +
    '    ISNULL(F.BetragKiZulage,0) != 0) ) ' + CHAR(10) + CHAR(13) + 
    '  OR (L.FaProzessCode IN (406, 407) AND ISNULL(F.BetragZahlung,0) != 0 OR F.Einmalig = 1)' +
    ')'
  
  -- Filtern nach Art
  IF @ModulID = 4 BEGIN
    SET @SQLString = @SQLString + CHAR(10) + CHAR(13) + CASE 
      -- ALBV Auszahlung/Forderung
      WHEN @FilterTyp = '1' THEN 
        'AND F.Einmalig = 0 AND L.FaProzessCode = 405 AND G.IstElternteil = 0 ' + 
        'AND ( ISNULL(F.BetragALBV,0) + ISNULL(F.BetragALBVverrechnung,0)>0 )'
      -- UeBH Auszahlung
      WHEN @FilterTyp = '2' THEN 
        'AND F.Einmalig = 0 AND L.FaProzessCode = 406'
      -- KKBB Auszahlung
      WHEN @FilterTyp = '3' THEN 
        'AND F.Einmalig = 0 AND L.FaProzessCode = 407'
      -- ALV Forderung
      WHEN @FilterTyp = '4' THEN 
        'AND F.Einmalig = 0 AND L.FaProzessCode = 405 ' +
        'AND ( ISNULL(F.BetragALBV,0) + ISNULL(F.BetragALBVverrechnung,0)<=0 )'
      -- einmalige Forderungen
      WHEN @FilterTyp = '5' THEN 
        'AND F.Einmalig = 1 AND X.Value1 in (''0'',''1'',''4'',''5'')'
      -- einmalige Zahlungen
      WHEN @FilterTyp = '7' THEN 
        'AND F.Einmalig = 1 AND X.Value1 in (''2'',''3'')'
      -- alle Daten
      ELSE ''
    END
  END

  -- Filtern nach User
  IF @UserID > 0 BEGIN
    SET @SQLString = @SQLString + CHAR(10) + CHAR(13) + 
      'AND (FF.UserID = ' + CONVERT(VARCHAR, @UserID) + ' OR L.UserID = ' + CONVERT(VARCHAR, @UserID) + ')'
  END

  -- Filtern nach Status
  SET @SQLString = @SQLString + CHAR(10) + CHAR(13) + CASE
    -- 30.10.2008 : sozheo : neu Filtern: stornierte, einmaligen Forderungen nicht anzeigen
    -- Alle Daten (ohne einmalige stornierte und ohne Null-Beträge)
    WHEN @FilterStatus = '9' THEN 
      'AND (F.Einmalig = 0 OR NOT EXISTS(
         SELECT TOP 1 BUC.KbBuchungID FROM dbo.KbBuchung BUC WITH(READUNCOMMITTED)
         WHERE BUC.IkPositionID = F.IkPositionID
         AND BUC.KbBuchungStatusCode = 8)) 
       AND (
         L.FaProzessCode NOT IN (301,302,304,405,406,407) OR F.Einmalig = 1 OR
         ISNULL(F.BetragALBV + F.BetragALBVverrechnung, 0) != 0 OR
         ISNULL(F.TotalAliment, 0) != 0 OR
         ISNULL(F.BetragKiZulage, 0) != 0 )'
    -- nur unverbuchte
    WHEN @FilterStatus = '1' THEN 
      -- 06.07.2009 : #32: beim neuen Konzept sind Monate mit mehreren RT immer verbucht
      -- 22.07.2009 : einmalige Forderungen müssen immer sichtbar sein
      -- AND (IsNull(F.HatMehrereAlteRT, 0) = 0 AND F.IkRechtstitelID IS NULL)
      'AND ((IsNull(F.HatMehrereAlteRT, 0) = 0 AND F.IkRechtstitelID IS NULL) OR F.Einmalig = 1)
       AND (NOT EXISTS(
         SELECT K.KbBuchungID FROM dbo.KbBuchung K WITH(READUNCOMMITTED) 
         WHERE K.IkPositionID = F.IkPositionID AND K.KbBuchungStatusCode != 8 ))
       AND (F.Einmalig = 0 OR NOT EXISTS(
         SELECT TOP 1 BUC.KbBuchungID FROM dbo.KbBuchung BUC WITH(READUNCOMMITTED)
         WHERE BUC.IkPositionID = F.IkPositionID AND BUC.KbBuchungStatusCode = 8)) 
       AND (
         L.FaProzessCode NOT IN (301,302,304,405,406,407) OR F.Einmalig = 1 OR
         ISNULL(F.BetragALBV + F.BetragALBVverrechnung, 0) != 0 OR
         ISNULL(F.TotalAliment, 0) != 0 OR
         ISNULL(F.BetragKiZulage, 0) != 0 )'
    -- nur verbuchte
    WHEN @FilterStatus = '2' THEN 
      -- 06.07.2009 : #32: beim neuen Konzept sind Monate mit mehreren RT immer verbucht
      --'AND EXISTS(
      --   SELECT K.KbBuchungID FROM dbo.KbBuchung K WITH(READUNCOMMITTED)
      --   WHERE K.IkPositionID = F.IkPositionID and K.KbBuchungStatusCode != 8 )'
      'AND ( 
         EXISTS (
           SELECT K.KbBuchungID FROM dbo.KbBuchung K WITH(READUNCOMMITTED)
           WHERE K.IkPositionID = F.IkPositionID and K.KbBuchungStatusCode != 8 )
         OR (F.IkRechtstitelID IS NULL AND ISNULL(F.HatMehrereAlteRT, 0) = 1) )'

    -- nur fehlerhafte
    WHEN @FilterStatus = '3' THEN 
      'AND EXISTS(
         SELECT K.KbBuchungID FROM dbo.KbBuchung K WITH(READUNCOMMITTED)
         WHERE K.IkPositionID = F.IkPositionID and K.KbBuchungStatusCode = 5 )'
    ELSE ''
  END

  -- Sortierung
  SET @SQLString = @SQLString + CHAR(10) + CHAR(13) + 
    'ORDER BY Username, F.Jahr, F.Monat, Glaubiger'

  -- SQL ausführen
/*
  DECLARE @SQLStringTmp VARCHAR(4000)
  SET @SQLStringTmp = SUBSTRING(@SQLString, 1, 4000)
  PRINT @SQLStringTmp
  SET @SQLStringTmp = CHAR(10) + CHAR(13)
  PRINT @SQLStringTmp
  SET @SQLStringTmp = SUBSTRING(@SQLString, 4001, 8000)
  PRINT @SQLStringTmp
  SET @SQLStringTmp = CHAR(10) + CHAR(13)
  PRINT @SQLStringTmp
  SET @SQLStringTmp = SUBSTRING(@SQLString, 8001, 12000)
  PRINT @SQLStringTmp
*/

  EXECUTE sp_executesql @SQLString

END

GO
