SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnIkPosition_Solllstellung
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Sollstellung
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    
  declare
  @FallID int,
  @FilterMonatAlle bit,
  @Datum Datetime,
  @Jahr int,
  @Monat int,
  @ModulFilter int,
  @Modul int,
  @FilterStatus int

set @FallID = NULL
set @FilterMonatAlle = 1
set @Datum = '20080701'
set @Jahr = 2008
set @Monat = 7
set @ModulFilter = 6
set @Modul = 4
set @FilterStatus = 0

select * from dbo.fnIkPosition_Solllstellung(
  1,
  @Jahr,
  @Monat,
  dbo.fnDateSerial(@Jahr, @Monat, 1),
  @FallID,
  @Modul,
  @ModulFilter,
  @FilterStatus,
  NULL
)
=================================================================================================*/

CREATE FUNCTION dbo.fnIkPosition_Solllstellung 
(
  @FilterMonatAlle BIT,
  @Jahr INT,
  @Monat INT,
  @Datum DATETIME,
  @FallID INT,
  @Modul INT,
  @ModulFilter INT,
  @FilterStatus INT,
  @UserID INT
)
RETURNS @OUTPUT TABLE (
  IstSelektiert BIT,
  IkPositionID INT,
  Monat INT,
  Jahr INT, 
  Datum DATETIME,
  ErledigterMonat BIT,
  Unterstuetzungsfall BIT,
  Glaubiger VARCHAR(200),
  ZahlungAn VARCHAR(200),
  ZusatzzahlungAn VARCHAR(200),
  Geburtsdatum DATETIME,
  Schuldner VARCHAR(200),
  ForderungTitel VARCHAR(200), 
  Username VARCHAR(200),
  Betrag MONEY, 
  ZahlBetrag MONEY,
  ZusatzBetrag MONEY, 
  IstGesendet BIT,
  TotalStornoIstMoeglich BIT,
  Status VARCHAR(200),
  FallPersonID INT,
  FaProzessCode INT,
  Einmalig BIT,
  IstBarzahlung BIT
)
AS BEGIN

  INSERT @OUTPUT

  SELECT 
    IstSelektiert = CONVERT(BIT, 0),
    F.IkPositionID,
    F.Monat, F.Jahr, F.Datum,
    F.ErledigterMonat,
    F.Unterstuetzungsfall,
    Glaubiger = P.Name + ISNULL(' ' + P.Vorname, ''),
    ZahlungAn = CASE 
      WHEN Z.BaPersonID IS NULL THEN Zi.Name 
      ELSE Zp.Name + ISNULL(' ' + Zp.Vorname, '')
    END +
    CASE 
      WHEN Z.AdresseName IS NOT NULL
        AND Z.AdressePLZ IS NOT NULL
        AND Z.AdresseOrt IS NOT NULL 
        THEN ' ('+Z.AdresseName + ')'
      ELSE ''
    END,
    ZusatzzahlungAn = CASE 
      WHEN G.ZusatzBaZahlungswegID IS NULL THEN NULL
      WHEN XZ.BaPersonID IS NULL THEN XZi.Name 
      ELSE XZp.Name + ISNULL(' ' + XZp.Vorname, '')
    END +
    CASE 
      WHEN XZ.AdresseName IS NOT NULL
        AND XZ.AdressePLZ IS NOT NULL
        AND XZ.AdresseOrt IS NOT NULL
        THEN ' ('+XZ.AdresseName + ')'
      ELSE ''
    END,
    P.Geburtsdatum,
    Schuldner = Ps.Name + ISNULL(' ' + Ps.Vorname, ''),
    ForderungTitel = CASE 
      WHEN F.Einmalig = 1 THEN dbo.fnLOVText('IkForderungEinmalig', F.IkForderungEinmaligCode)
      WHEN L.FaProzessCode = 405 AND G.IstElternteil = 1 THEN 'Erwachsenenalimente'
      WHEN L.FaProzessCode = 405 AND ( ISNULL(F.BetragALBV,0) + ISNULL(F.BetragALBVverrechnung,0)<= 0) THEN 'ALV'
      WHEN L.FaProzessCode = 405 THEN 'ALBV'
      WHEN L.FaProzessCode = 406 THEN 'UeBH'
      WHEN L.FaProzessCode = 407 THEN 'KKBB'
      --when L.FaProzessCode = 408 then 'Rückforderung ALBV'
      --when L.FaProzessCode = 409 then 'Rückforderung UeBH'
      --when L.FaProzessCode = 410 then 'Rückforderung KKBB'
      WHEN F.Einmalig = 0 THEN dbo.fnLOVText('IkForderungPeriodisch', F.IkForderungEinmaligCode)
      ELSE NULL
    END,
    Username = U.DisplayText,
    Betrag = CASE 
      WHEN F.Einmalig = 1 THEN F.BetragEinmalig
      WHEN L.FaProzessCode IN (301,302,304,408,409,410) THEN F.TotalAliment
      WHEN L.FaProzessCode IN (406,407) THEN F.BetragALBV
      WHEN G.IstElternteil = 1 
        THEN dbo.fnIkGetForderungBetrag(0, F.Einmalig,
          G.ZusatzBaZahlungswegID, G.Betrag, G.ZusatzBetrag, F.BetragEinmalig,
          ISNULL(F.TotalAliment,0) )
      WHEN ISNULL(F.BetragALBV,0) > 0 
        THEN dbo.fnIkGetForderungBetrag(0, F.Einmalig,
          G.ZusatzBaZahlungswegID, G.Betrag, G.ZusatzBetrag, F.BetragEinmalig,
          ISNULL(F.BetragZahlung,0) ) 
      ELSE dbo.fnIkGetForderungBetrag(0, F.Einmalig,
        G.ZusatzBaZahlungswegID, G.Betrag, G.ZusatzBetrag, F.BetragEinmalig,
        ISNULL(F.TotalAliment, 0) ) 
    END,
    ZahlBetrag = CASE 
      WHEN F.Einmalig = 1 AND F.IkForderungEinmaligCode IN (151,152,161,162,171,172) THEN F.BetragEinmalig
      WHEN F.BetragZahlung > 0 THEN F.BetragZahlung
      ELSE NULL
    END,
    ZusatzBetrag = CASE 
      WHEN F.Einmalig = 1 THEN NULL
      WHEN L.FaProzessCode in (301,302,304,408,409,410) THEN NULL
      WHEN G.IstElternteil = 1 
        THEN dbo.fnIkGetForderungBetrag(1, F.Einmalig,
          G.ZusatzBaZahlungswegID, G.Betrag, G.ZusatzBetrag, F.BetragEinmalig,
          ISNULL(F.TotalAliment,0))
      ELSE dbo.fnIkGetForderungBetrag(1, F.Einmalig,
        G.ZusatzBaZahlungswegID, G.Betrag, G.ZusatzBetrag, F.BetragEinmalig,
        ISNULL(F.BetragALBV,0) + ISNULL(F.BetragALBVverrechnung,0))
    END,
    IstGesendet = CONVERT(BIT, 
      CASE WHEN EXISTS(
        SELECT K.KbBuchungStatusCode FROM KbBuchung K 
        WHERE K.IkPositionID = F.IkPositionID AND NOT K.KbBuchungStatusCode IN (2,5,8) ) 
      THEN 1 ELSE 0 END),
    TotalStornoIstMoeglich = CONVERT(BIT, 
      CASE WHEN EXISTS(
        SELECT K.KbBuchungStatusCode FROM KbBuchung K 
        WHERE K.IkPositionID = F.IkPositionID 
          AND ((K.KbBuchungStatusCode != 3 AND K.StorniertKbBuchungID IS NULL) OR K.IkForderungArtCode in (10,11,12,13,14,15,31,32))
          AND (K.KbBuchungStatusCode != 8)        
      ) 
      THEN 0 ELSE 1 END),
    Status = CASE
      WHEN F.ErledigterMonat = 0 THEN 'nicht verbucht'
      ELSE 'verbucht'
    END,
    FallPersonID = FF.BaPersonID,
    L.FaProzessCode,
    F.Einmalig,
    IstBarzahlung = CONVERT(BIT, CASE WHEN EXISTS(
      SELECT QK.KbBuchungID FROM KbBuchung QK
      WHERE QK.IkPositionID = F.IkPositionID 
        AND QK.BarbelegDatum IS NOT NULL
        AND QK.BarbelegUserID IS NOT NULL
    ) THEN 1 ELSE 0 END)
  FROM dbo.IkPosition F WITH (READUNCOMMITTED) 
  LEFT JOIN dbo.BaPerson P WITH (READUNCOMMITTED) ON P.BaPersonID = F.BaPersonID
  LEFT JOIN dbo.IkRechtstitel R WITH (READUNCOMMITTED) ON R.IkRechtstitelID = F.IkRechtstitelID 
  LEFT JOIN dbo.IkGlaeubiger G WITH (READUNCOMMITTED) ON G.IkRechtstitelID = R.IkRechtstitelID AND G.BaPersonID = F.BaPersonID
  -- 1. Zahlungsweg
  LEFT JOIN dbo.BaZahlungsweg Z WITH (READUNCOMMITTED) ON Z.BaZahlungswegID = G.BaZahlungswegID
  LEFT JOIN dbo.BaPerson Zp WITH (READUNCOMMITTED) ON Zp.BaPersonID = Z.BaPersonID
  LEFT JOIN dbo.BaInstitution Zi WITH (READUNCOMMITTED) ON Zi.BaInstitutionID = Z.BaInstitutionID
  -- 2. Zahlungsweg
  LEFT JOIN dbo.BaZahlungsweg XZ WITH (READUNCOMMITTED) ON XZ.BaZahlungswegID = G.ZusatzBaZahlungswegID
  LEFT JOIN dbo.BaPerson XZp WITH (READUNCOMMITTED) ON XZp.BaPersonID = XZ.BaPersonID
  LEFT JOIN dbo.BaInstitution XZi WITH (READUNCOMMITTED) ON XZi.BaInstitutionID = XZ.BaInstitutionID

  LEFT JOIN dbo.FaLeistung L WITH (READUNCOMMITTED) ON L.FaLeistungID = COALESCE(R.FaLeistungID, F.FaLeistungID)
  LEFT JOIN dbo.FaFall FF WITH (READUNCOMMITTED) ON FF.FaFallID = L.FaFallID
  LEFT JOIN dbo.BaPerson Ps WITH (READUNCOMMITTED) ON Ps.BaPersonID = L.SchuldnerBaPersonID
  LEFT JOIN dbo.vwUser U ON U.UserID = L.UserID
  LEFT JOIN dbo.XLOVCode X WITH (READUNCOMMITTED) ON X.LOVName = 'IkForderungEinmalig' AND X.Code = F.IkForderungEinmaligCode

  -- FILTERN
  -- -------
  WHERE
    -- Suchen nach Fall
    (@FallID IS NULL OR FF.FaFallID = @FallID)
    -- Suchen nach Modul
    AND (
      (@Modul = 4 AND L.FaProzessCode BETWEEN 400 AND 499) OR
      (@Modul = 3 AND L.FaProzessCode BETWEEN 300 AND 399) 
    )
    -- Suchen nach Fall-Nummer
    AND (
      (@FilterMonatAlle = 0 AND F.Jahr = @Jahr AND F.Monat = @Monat) OR
      (@FilterMonatAlle = 1 AND F.Datum < @Datum) 
    ) 
    AND (
      L.FaProzessCode NOT IN (405,406,407) OR
      F.ErledigterMonat = 1 OR 
      G.IkGlaeubigerStatusCode = 2
    )
    AND (@Modul = 4 AND (
      (@ModulFilter = 6) OR
      (@ModulFilter = 1 AND F.Einmalig = 0 AND L.FaProzessCode = 405 AND G.IstElternteil = 0 AND F.BetragZahlung > 0) OR
      (@ModulFilter = 2 AND F.Einmalig = 0 AND L.FaProzessCode = 406) OR
      (@ModulFilter = 3 AND F.Einmalig = 0 AND L.FaProzessCode = 407) OR
      (@ModulFilter = 4 AND F.Einmalig = 0 AND L.FaProzessCode = 405 AND F.BetragZahlung > 0) OR
      (@ModulFilter = 5 AND F.Einmalig = 1 AND X.Value1 IN ('0','1','4','5')) OR
      (@ModulFilter = 7 AND F.Einmalig = 1 AND X.Value1 IN ('2','3'))
    ))
    -- suchen nach User
    AND (@UserID IS NULL OR @UserID = L.UserID OR @UserID = FF.UserID)
    -- suchen nach Status
    AND (
      (@FilterStatus = 0) OR
      (@FilterStatus = 1 AND F.ErledigterMonat = 0) OR
      (@FilterStatus = 2 AND F.ErledigterMonat = 1) OR
      (@FilterStatus = 3 AND F.ErledigterMonat = 1 AND EXISTS(
        SELECT K.KbBuchungID FROM dbo.KbBuchung K WITH (READUNCOMMITTED) 
        WHERE K.IkPositionID = F.IkPositionID AND K.KbBuchungStatusCode = 5
      ))
    )
  ORDER BY Username, F.Jahr, F.Monat, Glaubiger

  RETURN
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
