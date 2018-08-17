SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spIkSollstellung_KbBuchung_Undo;
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
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spIkSollstellung_KbBuchung_Undo
  -- IkPositionID:
  @IkPositionID INT
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON;

  -- ==========================
  -- Kontrolle der Parameter:
  -- ==========================
  IF @IkPositionID IS NULL OR @IkPositionID = 0 
  BEGIN
    SELECT HasErrors = 1, ErrorText = 'Fehler in Parameter: Der Parameter @IkPositionID ist ungültig.';
    RETURN;
  END;
  
  -- =======================================================
  -- Kontrolle, ob rückgängig gemacht werden darf:
  -- =======================================================
  DECLARE @AnzahlGesperrt INT;
  SELECT @AnzahlGesperrt = COUNT(*)
  FROM dbo.KbBuchung               BUC WITH (READUNCOMMITTED) 
    LEFT OUTER JOIN dbo.IkPosition IPO WITH (READUNCOMMITTED) ON IPO.IkPositionID = BUC.IkPositionID
  WHERE BUC.IkPositionID = @IkPositionID
    AND (BUC.KbBuchungStatusCode NOT IN (1, 2, 13) OR BUC.StorniertKbBuchungID IS NOT NULL);
  
  IF @AnzahlGesperrt > 0 
  BEGIN
    SELECT HasErrors = 1, ErrorText = 'Dieser Monat ist gesperrt und kann nicht mehr rückgängig gemacht werden.';
    RETURN;
  END;

  -- =======================================================
  -- Anzahl holen:
  -- =======================================================
  DECLARE @UndoCount INT;
  SELECT @UndoCount = COUNT(IkPositionID) 
  FROM dbo.KbBuchung WITH (READUNCOMMITTED) 
  WHERE IkPositionID = @IkPositionID;

  DECLARE @RechtstitelID INT, 
          @BaPersonID    INT;

  SELECT TOP 1 
    @RechtstitelID = IkRechtstitelID, 
    @BaPersonID    = BaPersonID 
  FROM dbo.IkPosition WITH (READUNCOMMITTED) 
  WHERE IkPositionID = @IkPositionID;

  -- =======================================================
  -- Löschen KbForderungAuszahlung:
  -- =======================================================
  DELETE dbo.KbForderungAuszahlung
  WHERE KbBuchungID_Forderung IN (SELECT B.KbBuchungID 
                                  FROM dbo.KbBuchung B
                                  WHERE B.IkPositionID = @IkPositionID 
                                    AND IkPositionID IS NOT NULL);

  -- =======================================================
  -- Löschen KbBuchungKstArt:
  -- =======================================================
  DELETE dbo.KbBuchungKostenart
  WHERE KbBuchungID IN (SELECT B.KbBuchungID 
                        FROM dbo.KbBuchung B
                        WHERE B.IkPositionID = @IkPositionID 
                          AND IkPositionID IS NOT NULL);

  -- =======================================================
  -- Löschen KbBuchung:
  -- =======================================================
  DELETE KbBuchung 
  WHERE IkPositionID = @IkPositionID 
    AND IkPositionID IS NOT NULL;

  -- =======================================================
  -- Ändern IkForderungBetrag:
  -- =======================================================
  UPDATE IkPosition 
    SET ErledigterMonat = 0
  WHERE IkPositionID = @IkPositionID;

  -- =======================================================
  -- Ändern IkVerrechnungskonto:
  -- =======================================================
  IF NOT @RechtstitelID IS NULL 
  BEGIN
    -- mark IkVerrechnungskonto as non-finished if last IkPosition is not done
    UPDATE VRK
      SET IstErledigt = 0
    FROM dbo.IkVerrechnungskonto VRK WITH (READUNCOMMITTED)
    WHERE VRK.BaPersonID = @BaPersonID
      AND VRK.IstErledigt = 1
      AND NOT EXISTS (SELECT TOP 1 1
                      FROM dbo.IkPosition IPO
                      WHERE IPO.IkRechtstitelID = VRK.IkRechtstitelID
                        AND IPO.BaPersonID = VRK.BaPersonID
                        AND IPO.Einmalig = 0
                        AND IPO.ErledigterMonat = 1
                        AND dbo.fnLastDayOf(dbo.fnDateSerial(IPO.Jahr, IPO.Monat, 1)) >= dbo.fnLastDayOf(ISNULL(VRK.AnnulliertAm, VRK.DatumBis)));
  END;

  -- Alles ok, Anzahl Buchung zurückgeben
  SELECT HasErrors = 0, UndoCount = @UndoCount;
END;
GO