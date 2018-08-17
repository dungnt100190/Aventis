SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBFSBudgetStichtagPerson;
GO
/*===============================================================================================
  $Revision: 4 $
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
  TEST:    SELECT * FROM dbo.fnBFSBudgetStichtagPerson(...)
=================================================================================================*/

CREATE FUNCTION dbo.fnBFSBudgetStichtagPerson
(
  @AntragstellerID     INT,
  @BFSLeistungsartCode INT,
  @Jahr                INT,
  @Monat			         INT
)
RETURNS @BgPosition TABLE
(
  BgBudgetID              INT,
  KbBuchungBruttoID       INT,
  KbBuchungBruttoPersonID INT,
  KontoNr                 VARCHAR(10),
  FaFachbereichCode       INT,
  Belegart                VARCHAR(4),
  Betrag                  money,
  BaPersonID              INT,
  BFSVariable             VARCHAR(10)
)
AS
BEGIN
  DECLARE @FaProzessCode INT;
  SET @FaProzessCode = dbo.fnBFSLeistungsartTOProzess(@BFSLeistungsartCode);

  INSERT INTO @BgPosition
    SELECT KBB.BgBudgetID,
           KBB.KbBuchungBruttoId,
           BUP.KbBuchungBruttoPersonID,
           KOA.KontoNr, 
           FaFachbereichCode,
           KOA.Belegart,
           BUP.Betrag,
           ISNULL(POS.BaPersonID,@AntragstellerID), 
           MAX(BPA.VarName)
    FROM dbo.KbBuchungBrutto               KBB WITH(READUNCOMMITTED)
      INNER JOIN dbo.KbBuchungBruttoPerson BUP WITH(READUNCOMMITTED) ON BUP.KbBuchungBruttoID = KBB.KbBuchungBruttoID
      LEFT  JOIN dbo.BgPosition            POS WITH(READUNCOMMITTED) ON POS.BgPositionID = BUP.BgPositionID
      INNER JOIN dbo.BgKostenart           KOA WITH(READUNCOMMITTED) ON KBB.BgKostenartID = KOA.BgKostenartID 
      INNER JOIN dbo.FaLeistung            FAL WITH(READUNCOMMITTED) ON FAL.FaLeistungID = KBB.FaLeistungID
      INNER JOIN dbo.BgPositionsart        BPA WITH(READUNCOMMITTED) ON BPA.BgKostenartID = KOA.BgKostenartID
    WHERE FAL.BaPersonID = @AntragstellerID
      AND YEAR(KBB.TransferDatum) = @Jahr
      AND MONTH(KBB.TransferDatum) = @Monat
      AND KBB.KbBuchungStatusCode in (3, 6, 10)
      AND FAL.FaProzessCode = @FaProzessCode 
    GROUP BY KBB.BgBudgetID, KBB.KbBuchungBruttoId, BUP.KbBuchungBruttoPersonID, KOA.KontoNr, 
             FaFachbereichCode, KOA.Belegart, BUP.Betrag, ISNULL(POS.BaPersonID, @AntragstellerID)
    HAVING MAX(BPA.VarName) IS NOT NULL; -- nur via LA-Mapping Tool zugeteilte BFS Variablen berücksichtigen
  RETURN;
END;
