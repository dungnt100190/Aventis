SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnIkGetBaPersonForderungTyp;
GO
/*===============================================================================================
  $Revision: 5
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Text der Forderungstyp eines Gläubigers. Momentan nur für Alimente (Leistung mit Forderungen).
    @IkGlaeubigerID: ID des Gläubigers
  -
  RETURNS: Forderungstyp als Text. Z.B. 'ALBV' oder 'ALBV, Vermittlung'
  -
  TEST:    SELECT dbo.fnIkGetBaPersonForderungTyp(11304);
=================================================================================================*/

CREATE FUNCTION dbo.fnIkGetBaPersonForderungTyp
(
  @IkGlaeubigerID INT
)
RETURNS VARCHAR(50)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- Forderungstyp suchen
  -----------------------------------------------------------------------------
  DECLARE @IkRechtstitelID INT,
          @BaPersonID INT,
          @AlbvMax MONEY;
          
  SELECT 
    @IkRechtstitelID = IkRechtstitelID,
    @BaPersonID      = BaPersonID
  FROM dbo.IkGlaeubiger WITH (READUNCOMMITTED)
  WHERE IkGlaeubigerID = @IkGlaeubigerID;

  SELECT @AlbvMax = CONVERT(MONEY, dbo.fnXConfig('System\Inkasso\ALBVMaximalBetrag', GETDATE()));

  DECLARE @return VARCHAR(50);
  
  SELECT @return = STUFF((SELECT CONVERT(VARCHAR(100), SUB.Text)
                          FROM (SELECT DISTINCT
                                  [Text] = ', ' + CASE 
                                                    WHEN ALBVBerechtigt = 1 AND FRD.Betrag > @AlbvMax THEN T.SplitValue
                                                    WHEN ALBVBerechtigt = 1 THEN 'ALBV'
                                                    WHEN Unterstuetzungsfall = 1 THEN 'Unterstützung'
                                                    WHEN ALBVBerechtigt = 0 AND Unterstuetzungsfall = 0 THEN 'Vermittlung'
                                                    ELSE ''
                                                  END,
                                  Sort   = CASE 
                                             WHEN ALBVBerechtigt = 1 AND FRD.Betrag > @AlbvMax THEN T.OccurenceID + 1
                                             WHEN ALBVBerechtigt = 1 THEN 1
                                             WHEN Unterstuetzungsfall = 1 THEN 3
                                             WHEN ALBVBerechtigt = 0 AND Unterstuetzungsfall = 0 THEN 2
                                             ELSE 4
                                           END
                                FROM dbo.IkForderung FRD WITH (READUNCOMMITTED)
                                  LEFT JOIN (SELECT OccurenceID, SplitValue
                                             FROM dbo.fnSplitStringToValues('ALBV;Vermittlung', ';', 1)) T ON FRD.ALBVBerechtigt = 1 AND FRD.Betrag > @AlbvMax
                                WHERE FRD.IkRechtstitelID = @IkRechtstitelID
                                  AND FRD.BaPersonID = @BaPersonID
                                  AND FRD.IkForderungID IN (SELECT TOP 1 IkForderungID
                                                            FROM dbo.IkForderung F WITH (READUNCOMMITTED)
                                                            WHERE F.IkRechtstitelID = FRD.IkRechtstitelID
                                                              AND F.BaPersonID = FRD.BaPersonID
                                                              AND F.IkForderungPeriodischCode = FRD.IkForderungPeriodischCode
                                                            ORDER BY F.DatumAnpassenAb DESC, ISNULL(F.DatumGueltigBis, F.DatumAnpassenAb) DESC)
                                  AND dbo.fnDateOf(GETDATE()) BETWEEN ISNULL(DatumAnpassenAb, '17530101') AND ISNULL(DatumGueltigBis, '99991231')) AS SUB
                          ORDER BY SUB.Sort
                          FOR XML PATH('')),
                         1, 2, '');

  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN @return;
END;
GO
