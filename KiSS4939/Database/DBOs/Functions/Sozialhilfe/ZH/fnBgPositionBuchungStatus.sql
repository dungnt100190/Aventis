SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnBgPositionBuchungStatus
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Falls zu einer BudgetPosition mehrere Nettobelege existieren, wird der maximale Status aller Belege zurückgegeben.
           Falls noch keine Nettobelege erzeugt wurden, wird entweder "grau","grün" oder einer der Bewilligungsstati zurückgegeben, je
           nach Art der BudgetPosition
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnBgPositionBuchungStatus
(
  @BgPositionID int
)
RETURNS int
AS
BEGIN
  DECLARE @Status int

  SELECT @Status =  ISNULL(MAX(BUC.KbBuchungStatusCode),
                           CASE WHEN BPO.BgKategorieCode IN (2,100) AND KRE.BaZahlungswegID IS NULL AND BPO.BgSpezkontoID IS NOT NULL -- Auszahlung/Zusätzliche Leistung an Spezialkonto
                                THEN CASE WHEN BDG.BgBewilligungStatusCode in (5,9) THEN 2 ELSE 1 END

                                WHEN BPO.BgKategorieCode = 1 AND BPO.VerwaltungSD = 0 -- nicht abgetretene Einnahmen
                                THEN CASE WHEN BDG.BgBewilligungStatusCode in (5,9) THEN 2 ELSE 1 END

                                WHEN BPO.BgKategorieCode = 3 -- Verrechnungen
                                THEN CASE WHEN BDG.BgBewilligungStatusCode in (5,9) THEN 2 ELSE 1 END

                                ELSE CASE WHEN BPO.BgKategorieCode = 2 AND KRE.BaZahlungswegID IS NOT NULL AND KRE.BaPersonID IS NOT NULL -- Ausgaben an Klient (ohne tatsähliche Auszahlung)
                                          THEN CASE BDG.BgBewilligungStatusCode
                                               WHEN 5 THEN 2 -- im grünen Budget grün
                                               WHEN 9 THEN 7 -- im roten Budget gesperrt
                                               ELSE 1 
                                               END
                                          ELSE CASE BPO.BgBewilligungStatusCode
                                               WHEN 1 THEN 1   -- grau
                                               WHEN 2 THEN 15  -- abgelehnt
                                               WHEN 3 THEN 12  -- angefragt
                                               WHEN 5 THEN 14  -- bewilligt
                                               WHEN 9 THEN 7   -- gesperrt
                                               END
  
                                     END
                           END)
  FROM dbo.BgPosition BPO
       INNER JOIN dbo.BgBudget           BDG WITH(READUNCOMMITTED) ON BDG.BgBudgetID = BPO.BgBudgetID
       INNER JOIN dbo.BgFinanzplan       FPL WITH(READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
       INNER JOIN dbo.FaLeistung         LEI WITH(READUNCOMMITTED) ON LEI.FaLeistungID = FPL.FaLeistungID
       LEFT  JOIN dbo.KbBuchungKostenart BUK WITH(READUNCOMMITTED) ON BUK.BgPositionID = BPO.BgPositionID
       LEFT  JOIN dbo.KbBuchung          BUC WITH(READUNCOMMITTED) ON BUC.KbBuchungID = BUK.KbBuchungID
       LEFT  JOIN dbo.BgAuszahlungPerson BAP WITH(READUNCOMMITTED) ON BAP.BgPositionID = BPO.BgPositionID AND
                                                                      BAP.BgAuszahlungPersonID = 
                                                                              (SELECT TOP 1 BgAuszahlungPersonID
                                                                               FROM   dbo.BgAuszahlungPerson WITH(READUNCOMMITTED)
                                                                               WHERE  BgPositionID = BPO.BgPositionID
                                                                               ORDER BY 
                                                                                 CASE WHEN BaPersonID IS NULL THEN 1
                                                                                      WHEN BaPersonID = BPO.BaPersonID THEN 2
                                                                                      WHEN BaPersonID = LEI.BaPersonID THEN 3
                                                                                      ELSE 4
                                                                                 END)
       LEFT  JOIN dbo.vwKreditor         KRE  ON KRE.BaZahlungswegID = BAP.BaZahlungswegID

  WHERE BPO.BgPositionID = @BgPositionID
  GROUP BY BUK.BgPositionID, BPO.BgKategorieCode, BPO.BgSpezkontoID, BPO.VerwaltungSD,BPO.BgBewilligungStatusCode,
           BDG.BgBewilligungStatusCode, 
           KRE.BaZahlungswegID, KRE.BaPersonID
  
  RETURN @Status

END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
