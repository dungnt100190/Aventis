SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
-------------------------------------------------------------------------------
-- we need to drop constraint first
-------------------------------------------------------------------------------
IF (EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_KbBuchung_DataIntegrity]') AND parent_object_id = OBJECT_ID(N'[dbo].[KbBuchung]')))
BEGIN
  ALTER TABLE [dbo].[KbBuchung] DROP CONSTRAINT [CK_KbBuchung_DataIntegrity];
  
  PRINT ('Info: Dropped constraint "CK_KbBuchung_DataIntegrity"');
END
-------------------------------------------------------------------------------
GO
EXECUTE dbo.spDropObject fnKbCKKbBuchungIntegrity;
GO

/*===============================================================================================
  $Revision: 9 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Check data integrity for table KbBuchung. This function only performs any checks
    @KbBuchungID:         The primary key id of the datarow to insert/update
    @KbBuchungStatusCode: The new value of the KbBuchungStatusCode column. A check is only performed if this parameter is equal to 13 (verbucht)
    @Betrag:              The new value of the Betrag column
    @SollKtoNr:           The new value of the SollKtoNr column
    @HabenKtoNr:          The new value of the HabenKtoNr column
  -
  RETURNS: "0" if data is valid or was not checked (for any KbBuchungStatusCode <> 13)
           "1" if invalid parameters are provided
           "2" if SollKtoNr AND HabenKtoNr have a value and there exist related KbBuchungKostenart records
           "3" if SollKtoNr OR HabenKtoNr have a value (and the other corresponding column hasn't any) and there exist no related KbBuchungKostenart records
           "4" if neither SollKtoNr nor HabenKtoNr has a value
           "5" if there are KbBuchungKostenart records and their sum does not correspond to the betrag column of the KbBuchung record
           "6" if there is more than one KbBuchung with the same KbZahlungseingangID
           "7" if the Soll-/Haben- or a Kostenart-Konto does not exist
=================================================================================================
  TEST:    
=================================================================================================*/

CREATE FUNCTION dbo.fnKbCKKbBuchungIntegrity
(
  @KbBuchungID INT,
  @KbBuchungStatusCode INT,
  @Betrag MONEY,
  @SollKtoNr VARCHAR(10),
  @HabenKtoNr VARCHAR(10)
)
RETURNS INT
AS
BEGIN

  -----------------------------------------------------------------------------
  -- check mode
  -----------------------------------------------------------------------------
  IF (@KbBuchungStatusCode IS NULL OR @KbBuchungStatusCode <> 13)
  BEGIN
    -- don't perform any check
    RETURN 0;
  END;

  -----------------------------------------------------------------------------
  -- validate parameter
  -----------------------------------------------------------------------------
  IF (@KbBuchungID IS NULL)
  BEGIN
    -- invalid parameter
    RETURN 1;
  END;

  -----------------------------------------------------------------------------
  -- Pro Zahlungseingang darf es höchstens eine KbBuchung haben
  -----------------------------------------------------------------------------
  DECLARE @KbZahlungseingangID INT;
  DECLARE @KbPeriodeID INT;
  DECLARE @PeriodeStatus INT;
  
  SELECT  @KbZahlungseingangID = BUC.KbZahlungseingangID,
          @KbPeriodeID = PER.KbPeriodeID,
          @PeriodeStatus = PER.PeriodeStatusCode
  FROM dbo.KbBuchung BUC
    INNER JOIN dbo.KbPeriode PER ON PER.KbPeriodeID = BUC.KbPeriodeID
  WHERE BUC.KbBuchungID = @KbBuchungID
  
  IF(@KbZahlungseingangID IS NOT NULL AND (SELECT COUNT(*) FROM dbo.KbBuchung BUC WHERE BUC.KbZahlungseingangID = @KbZahlungseingangID) > 1)
  BEGIN
    RETURN 6;
  END;

  -----------------------------------------------------------------------------
  -- Es werden nur Buchungen aus aktiven Perioden geprüft
  -----------------------------------------------------------------------------
  IF(@PeriodeStatus <> 1)
  BEGIN
    RETURN 0;
  END;

  -----------------------------------------------------------------------------
  -- Neither Soll nor Haben have a value -> FAIL
  -----------------------------------------------------------------------------
  IF (@SollKtoNr IS NULL AND @HabenKtoNr IS NULL)
  BEGIN
    RETURN 4;
  END;

  DECLARE @KbBuchungKostenartAnzahl INT;
  DECLARE @KbBuchungKostenartSum MONEY;
  DECLARE @AnzahlKostenartBuchungenOhneKonto INT;
  
  SELECT @KbBuchungKostenartAnzahl = COUNT(BKO.KbBuchungKostenartID), 
         @KbBuchungKostenartSum = SUM(BKO.Betrag),
         @AnzahlKostenartBuchungenOhneKonto = SUM(CASE WHEN KTO.KbKontoID IS NOT NULL THEN 0 ELSE 1 END)
  FROM dbo.KbBuchungKostenart BKO
    LEFT JOIN dbo.KbKonto KTO ON KTO.KontoNr = BKO.KontoNr
                             AND KTO.KbPeriodeID = @KbPeriodeID
  WHERE BKO.KbBuchungID = @KbBuchungID;
  
  -----------------------------------------------------------------------------
  -- Soll & Haben have a value -> no KbBuchungKostenart records allowed
  -----------------------------------------------------------------------------
  IF (@SollKtoNr IS NOT NULL AND @HabenKtoNr IS NOT NULL AND @KbBuchungKostenartAnzahl <> 0)
  BEGIN
    -- KbBuchungKostenart records exist which should not
    RETURN 2;
  END;
  
  -----------------------------------------------------------------------------
  -- Soll OR Haben have a value (and the other hasn't any) -> KbBuchungKostenart records required
  -----------------------------------------------------------------------------
  IF ((@SollKtoNr IS NOT NULL AND @HabenKtoNr IS NULL) OR (@SollKtoNr IS NULL AND @HabenKtoNr IS NOT NULL))
  BEGIN
    IF (@KbBuchungKostenartAnzahl = 0)
    BEGIN
      -- No KbbuchungKostenart records exist, but should
      RETURN 3;
    END;
    ELSE
    BEGIN
      IF (ABS(@KbBuchungKostenartSum - @Betrag) >= $0.05)
      BEGIN
        -- the sum of KbBuchungKostenart does not correspond to the betrag of KbBuchung
        RETURN 5;
      END;
    END
  END;
  
  -----------------------------------------------------------------------------
  -- Check if Soll-/Haben-/Kostenart-Konti exist
  -----------------------------------------------------------------------------
  IF(@AnzahlKostenartBuchungenOhneKonto > 0
     OR @SollKtoNr IS NOT NULL AND NOT EXISTS(SELECT TOP 1 1 FROM KbKonto WHERE KontoNr = @SollKtoNr AND KbPeriodeID = @KbPeriodeID)
     OR @HabenKtoNr IS NOT NULL AND NOT EXISTS(SELECT TOP 1 1 FROM KbKonto WHERE KontoNr = @HabenKtoNr AND KbPeriodeID = @KbPeriodeID))
  BEGIN
    RETURN 7;
  END;
  
  -----------------------------------------------------------------------------
  -- if we are here, everything is alright
  -----------------------------------------------------------------------------
  RETURN 0;
END;
GO

-------------------------------------------------------------------------------
-- we need to recreate constraint
-------------------------------------------------------------------------------
IF (EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KbBuchung]') AND type in (N'U')))
BEGIN
  ALTER TABLE [dbo].[KbBuchung] WITH NOCHECK 
  ADD CONSTRAINT [CK_KbBuchung_DataIntegrity] 
  CHECK (([dbo].[fnKbCKKbBuchungIntegrity]([KbBuchungID],[KbBuchungStatusCode],[Betrag],[SollKtoNr],[HabenKtoNr])=(0)));
  
  ALTER TABLE [dbo].[KbBuchung] CHECK CONSTRAINT [CK_KbBuchung_DataIntegrity];

  EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Checks for valid KbBuchung records with verbuchen state' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbBuchung', @level2type=N'CONSTRAINT',@level2name=N'CK_KbBuchung_DataIntegrity';
  
  PRINT ('Info: ReCreated constraint "CK_KbBuchung_DataIntegrity"');
END;
GO
-------------------------------------------------------------------------------

