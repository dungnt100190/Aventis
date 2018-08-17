SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spKaAllgemein_RowMerge;
GO
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Used to merge data of KA-Allgemein views in KA-ModulTree
    @BaPersonID_Keep:   The id of the BaPerson to keep
    @BaPersonID_Delete: The id of the BaPerson to merge with @BaPersonID_Keep and delete afterwards
    @DebugOn:           Flag if debug information shall be written to output
  -
  RETURNS: Nothing to return
=================================================================================================
  TEST:    EXEC dbo.spKaAllgemein_RowMerge 1, 2;
=================================================================================================*/

CREATE PROCEDURE dbo.spKaAllgemein_RowMerge
(
  @BaPersonID_Keep INT,
  @BaPersonID_Delete INT,
  @DebugOn BIT = 0
)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- start call
  -----------------------------------------------------------------------------
  SET NOCOUNT ON;
  
  IF (@DebugOn = 1)
  BEGIN
    PRINT ('Info: <spKaAllgemein_RowMerge>');
  END;
  
  -----------------------------------------------------------------------------
  -- validate persons
  -----------------------------------------------------------------------------
  IF (ISNULL(@BaPersonID_Keep, -1) < 1 OR ISNULL(@BaPersonID_Delete, -1) < 1 OR @BaPersonID_Keep = @BaPersonID_Delete)
  BEGIN
    -- do not continue
    RAISERROR ('Error: Could not process merging of "KA-Allgemein". The given parameters for @BaPersonID have either the same or at least one NULL value.', 18, 1);
    RETURN;
  END;
  
  -----------------------------------------------------------------------------
  -- init vars
  -----------------------------------------------------------------------------
  DECLARE @FaLeistungID_KAAllg INT;
  DECLARE @FaLeistungDatumVon_KAAllg DATETIME;
  DECLARE @FaLeistungDatumBis_KAAllg DATETIME;
  --
  DECLARE @FaLeistungID_KAAllg_Delete INT;
  DECLARE @FaLeistungDatumVon_KAAllg_Delete DATETIME;
  DECLARE @FaLeistungDatumBis_KAAllg_Delete DATETIME;
  --
  DECLARE @MaskName_Ka_Ausbildung VARCHAR(100);
  --
  DECLARE @KaAusbErlerntBeruf_Code INT;
  DECLARE @KaAusbVorb_Code INT;
  DECLARE @KaAusbAusbildung_Code INT;
  DECLARE @KaAusbBerufserf_Code INT;
  --
  DECLARE @KaAusbErlerntBeruf_Code_Delete INT;
  DECLARE @KaAusbVorb_Code_Delete INT;
  DECLARE @KaAusbAusbildung_Code_Delete INT;
  DECLARE @KaAusbBerufserf_Code_Delete INT;
  --
  DECLARE @RowCount INT;
  
  -----------------------------------------------------------------------------
  -- set vars
  -----------------------------------------------------------------------------
  -------------------------------------
  -- const
  -------------------------------------
  SET @MaskName_Ka_Ausbildung = 'Ka_Ausbildung';
  
  -------------------------------------
  -- from FaLeistung
  -------------------------------------
  SELECT @FaLeistungID_KAAllg       = FaLeistungID,           -- if we already have more than one, we expect an error as this case is invalid
         @FaLeistungDatumVon_KAAllg = DatumVon,
         @FaLeistungDatumBis_KAAllg = DatumBis
  FROM dbo.FaLeistung
  WHERE ModulID = 7
    AND FaProzessCode = 700
    AND BaPersonID = @BaPersonID_Keep;
  
  SELECT @FaLeistungID_KAAllg_Delete       = FaLeistungID,    -- if we already have more than one, we expect an error as this case is invalid
         @FaLeistungDatumVon_KAAllg_Delete = DatumVon,
         @FaLeistungDatumBis_KAAllg_Delete = DatumBis
  FROM dbo.FaLeistung
  WHERE ModulID = 7
    AND FaProzessCode = 700
    AND BaPersonID = @BaPersonID_Delete;
  
  -- validate
  IF (@FaLeistungID_KAAllg IS NULL OR @FaLeistungDatumVon_KAAllg IS NULL OR
      @FaLeistungID_KAAllg_Delete IS NULL OR @FaLeistungDatumVon_KAAllg_Delete IS NULL)
  BEGIN
    -- do not continue
    RAISERROR ('Error: Invalid data for merging "KA-Allgemein", cannot continue within "spKaAllgemein_RowMerge".', 18, 1);
    RETURN;
  END;
  
  -- debug
  IF (@DebugOn = 1)
  BEGIN
    PRINT ('Info: @FaLeistungID_KAAllg="' + CONVERT(VARCHAR(50), @FaLeistungID_KAAllg) + '", @FaLeistungID_KAAllg_Delete="' + CONVERT(VARCHAR(50), @FaLeistungID_KAAllg_Delete) + '"');
  END;
  
  -------------------------------------
  -- from KaAusbildung
  -------------------------------------
  SELECT TOP 1 @KaAusbErlerntBeruf_Code = KA.KaBecoErlernterBerufCode,
               @KaAusbVorb_Code = KA.KaAusbildungVorbildungCode,
               @KaAusbAusbildung_Code = KA.KaVermittlBiBerufsbilCode,
               @KaAusbBerufserf_Code = KA.KaVermittlBiBerufserfCode
  FROM dbo.KaAusbildung KA WITH (READUNCOMMITTED)  
  WHERE KA.FaLeistungID = @FaLeistungID_KAAllg;
  
  SELECT TOP 1 @KaAusbErlerntBeruf_Code_Delete,
               @KaAusbVorb_Code_Delete,
               @KaAusbAusbildung_Code_Delete,
               @KaAusbBerufserf_Code_Delete
  FROM dbo.KaAusbildung KA WITH (READUNCOMMITTED) 
  WHERE KA.FaLeistungID = @FaLeistungID_KAAllg_Delete;
  
  -----------------------------------------------------------------------------
  -- merge FaLeistung status (open, closed, archived)
  -- - open + closed >> open
  -- - open + archived >> open
  -- - closed + archived >> closed
  -----------------------------------------------------------------------------
  -- handle DatumVon/DatumBis
  UPDATE LEI
  SET LEI.DatumVon = CONVERT(DATETIME, dbo.fnMIN(@FaLeistungDatumVon_KAAllg, @FaLeistungDatumVon_KAAllg_Delete)),  -- set earlier date
      LEI.DatumBis = CASE
                       -- both open or at least one open >> open
                       WHEN @FaLeistungDatumBis_KAAllg IS NULL OR @FaLeistungDatumBis_KAAllg_Delete IS NULL THEN NULL
                       
                       -- both closed, get latest >> closed
                       WHEN @FaLeistungDatumBis_KAAllg IS NOT NULL AND @FaLeistungDatumBis_KAAllg_Delete IS NOT NULL 
                         THEN CONVERT(DATETIME, dbo.fnMAX(@FaLeistungDatumBis_KAAllg, @FaLeistungDatumBis_KAAllg_Delete))

                       -- this case should not occure
                       ELSE @FaLeistungDatumBis_KAAllg
                     END
  FROM dbo.FaLeistung LEI
  WHERE LEI.FaLeistungID = @FaLeistungID_KAAllg;
  
  -- handle archived/not archived: delete archive-entry of the one to keep if the one to delete is not archived
  DELETE ARC
  FROM dbo.FaLeistungArchiv ARC
  WHERE ARC.FaLeistungID = @FaLeistungID_KAAllg
    AND NOT EXISTS (SELECT TOP 1 1
                    FROM dbo.FaLeistungArchiv DARC
                    WHERE DARC.FaLeistungID = @FaLeistungID_KAAllg_Delete);
  
  SET @RowCount = @@ROWCOUNT;
  
  -- debug
  IF (@DebugOn = 1)
  BEGIN
    PRINT ('Info: Deleted "' + CONVERT(VARCHAR(50), @RowCount) + '" rows in FaLeistungArchiv for @FaLeistungID_KAAllg');
  END;
  
  -- delete the archive-entry of the one to delete anyway to prevent merging
  DELETE DARC
  FROM dbo.FaLeistungArchiv DARC
  WHERE DARC.FaLeistungID = @FaLeistungID_KAAllg_Delete;
  
  SET @RowCount = @@ROWCOUNT;
  
  -- debug
  IF (@DebugOn = 1)
  BEGIN
    PRINT ('Info: Deleted "' + CONVERT(VARCHAR(50), @RowCount) + '" rows in FaLeistungArchiv for @FaLeistungID_KAAllg_Delete');
  END;
  
  -----------------------------------------------------------------------------
  -- merge KA-Allgemein-Ausbildung
  -----------------------------------------------------------------------------
  -------------------------------------
  -- Ka_Ausbildung.KaAusbErlerntBeruf
  -------------------------------------
  
  UPDATE dbo.KaAusbildung
  SET KaBecoErlernterBerufCode = CASE
                                    WHEN @KaAusbErlerntBeruf_Code IS NOT NULL AND @KaAusbErlerntBeruf_Code_Delete IS NOT NULL 
                                      THEN -- take newer entry by FaLeistung.DatumVon
                                           CASE
                                             WHEN @FaLeistungDatumVon_KAAllg >= @FaLeistungDatumVon_KAAllg_Delete THEN @KaAusbErlerntBeruf_Code
                                             ELSE @KaAusbErlerntBeruf_Code_Delete
                                           END
                                    ELSE COALESCE(@KaAusbErlerntBeruf_Code, @KaAusbErlerntBeruf_Code_Delete)
                                  END
  WHERE FaLeistungID = @FaLeistungID_KAAllg;
  
  
  SET @RowCount = @@ROWCOUNT;
  
  IF (@RowCount < 1 AND @KaAusbErlerntBeruf_Code_Delete IS NOT NULL)
  BEGIN
    -- we only have a to-delete entry, so move it to the to-keep-FaLeistungID    
    UPDATE KaAusbildung
    SET KaBecoErlernterBerufCode = (SELECT KaBecoErlernterBerufCode 
                                    FROM dbo.KaAusbildung 
                                    WHERE FaLeistungID = @FaLeistungID_KAAllg)
    WHERE FaLeistungID = @FaLeistungID_KAAllg_Delete;    
    
    -- debug
    IF (@DebugOn = 1)
    BEGIN
      PRINT ('Info: Moved "KaAusbErlerntBeruf"');
    END;
  END
  ELSE
  BEGIN
    -- debug
    IF (@DebugOn = 1)
    BEGIN
      PRINT ('Info: ' + CASE @RowCount 
                          WHEN 0 THEN 'No data for' 
                          WHEN 1 THEN 'Updated'
                          ELSE 'Updated more than one row (!!) for'
                        END + ' "KaAusbErlerntBeruf"');
    END;
  END;
  
  -------------------------------------
  -- Ka_Ausbildung.KaAusbVorb
  -------------------------------------

  UPDATE dbo.KaAusbildung
  SET KaAusbildungVorbildungCode = CASE
                                    WHEN @KaAusbVorb_Code IS NOT NULL AND @KaAusbVorb_Code_Delete IS NOT NULL 
                                      THEN -- take newer entry by FaLeistung.DatumVon
                                           CASE
                                             WHEN @FaLeistungDatumVon_KAAllg >= @FaLeistungDatumVon_KAAllg_Delete THEN @KaAusbVorb_Code
                                             ELSE @KaAusbVorb_Code_Delete
                                           END
                                    ELSE COALESCE(@KaAusbVorb_Code, @KaAusbVorb_Code_Delete)
                                  END
  WHERE FaLeistungID = @FaLeistungID_KAAllg
  
  SET @RowCount = @@ROWCOUNT;
  
  IF (@RowCount < 1 AND @KaAusbVorb_Code_Delete IS NOT NULL)
  BEGIN
    -- we only have a to-delete entry, so move it to the to-keep-FaLeistungID
    UPDATE dbo.KaAusbildung
    SET KaAusbildungVorbildungCode = (SELECT KaAusbildungVorbildungCode 
                                      FROM dbo.KaAusbildung 
                                      WHERE FaLeistungID = @FaLeistungID_KAAllg)
    WHERE FaLeistungID = @FaLeistungID_KAAllg_Delete;
        
    -- debug
    IF (@DebugOn = 1)
    BEGIN
      PRINT ('Info: Moved "KaAusbVorb"');
    END;
  END
  ELSE
  BEGIN
    -- debug
    IF (@DebugOn = 1)
    BEGIN
      PRINT ('Info: ' + CASE @RowCount 
                          WHEN 0 THEN 'No data for' 
                          WHEN 1 THEN 'Updated'
                          ELSE 'Updated more than one row (!!) for'
                        END + ' "KaAusbVorb"');
    END;
  END;
  
  -------------------------------------
  -- Ka_Ausbildung.KaAusbAusbildung
  -------------------------------------
  UPDATE dbo.KaAusbildung
  SET KaVermittlBiBerufsbilCode = CASE
                                    WHEN @KaAusbAusbildung_Code IS NOT NULL AND @KaAusbAusbildung_Code_Delete IS NOT NULL 
                                      THEN -- take newer entry by FaLeistung.DatumVon
                                           CASE
                                             WHEN @FaLeistungDatumVon_KAAllg >= @FaLeistungDatumVon_KAAllg_Delete THEN @KaAusbAusbildung_Code
                                             ELSE @KaAusbAusbildung_Code_Delete
                                           END
                                    ELSE COALESCE(@KaAusbAusbildung_Code, @KaAusbAusbildung_Code_Delete)
                                  END
  WHERE  FaLeistungID = @FaLeistungID_KAAllg
  
  SET @RowCount = @@ROWCOUNT;
  
  IF (@RowCount < 1 AND @KaAusbAusbildung_Code_Delete IS NOT NULL)
  BEGIN
    -- we only have a to-delete entry, so move it to the to-keep-FaLeistungID
    UPDATE dbo.KaAusbildung
    SET KaVermittlBiBerufsbilCode = (SELECT KaVermittlBiBerufsbilCode
                                     FROM dbo.KaAusbildung
                                     WHERE FaLeistungID = @FaLeistungID_KAAllg)
    WHERE FaLeistungID = @FaLeistungID_KAAllg_Delete;
    
    -- debug
    IF (@DebugOn = 1)
    BEGIN
      PRINT ('Info: Moved "KaAusbAusbildung"');
    END;
  END
  ELSE
  BEGIN
    -- debug
    IF (@DebugOn = 1)
    BEGIN
      PRINT ('Info: ' + CASE @RowCount 
                          WHEN 0 THEN 'No data for' 
                          WHEN 1 THEN 'Updated'
                          ELSE 'Updated more than one row (!!) for'
                        END + ' "KaAusbAusbildung"');
    END;
  END;
  
  -------------------------------------
  -- Ka_Ausbildung.KaAusbBerufserf
  -------------------------------------
  UPDATE dbo.KaAusbildung
  SET KaVermittlBiBerufserfCode = CASE
                                    WHEN @KaAusbBerufserf_Code IS NOT NULL AND @KaAusbBerufserf_Code_Delete IS NOT NULL 
                                      THEN -- take newer entry by FaLeistung.DatumVon
                                           CASE
                                             WHEN @FaLeistungDatumVon_KAAllg >= @FaLeistungDatumVon_KAAllg_Delete THEN @KaAusbBerufserf_Code
                                             ELSE @KaAusbBerufserf_Code_Delete
                                           END
                                    ELSE COALESCE(@KaAusbBerufserf_Code, @KaAusbBerufserf_Code_Delete)
                                  END
  WHERE FaLeistungID = @FaLeistungID_KAAllg;  
  
  SET @RowCount = @@ROWCOUNT;
  
  IF (@RowCount < 1 AND @KaAusbBerufserf_Code_Delete IS NOT NULL)
  BEGIN
    -- we only have a to-delete entry, so move it to the to-keep-FaLeistungID
    UPDATE dbo.KaAusbildung
    SET KaVermittlBiBerufserfCode = (SELECT KaVermittlBiBerufsbilCode 
                                     FROM dbo.KaAusbildung
                                     WHERE FaLeistungID = @FaLeistungID_KAAllg)
    WHERE FaLeistungID = @FaLeistungID_KAAllg_Delete;
    
    -- debug
    IF (@DebugOn = 1)
    BEGIN
      PRINT ('Info: Moved "KaAusbBerufserf"');
    END;
  END
  ELSE
  BEGIN
    -- debug
    IF (@DebugOn = 1)
    BEGIN
      PRINT ('Info: ' + CASE @RowCount 
                          WHEN 0 THEN 'No data for' 
                          WHEN 1 THEN 'Updated'
                          ELSE 'Updated more than one row (!!) for'
                        END + ' "KaAusbBerufserf"');
    END;
  END;
  
  -----------------------------------------------------------------------------
  -- remove the DynaValue entries of KA-Allgemein-Ausbildung of the FaLeistung 
  --   to delete - this will prevent merging the data in auto-merge part
  -----------------------------------------------------------------------------
  DELETE dbo.KaAusbildung
  WHERE FaLeistungID = @FaLeistungID_KAAllg_Delete;
  
  SET @RowCount = @@ROWCOUNT;
  
  -- debug
  IF (@DebugOn = 1)
  BEGIN
    PRINT ('Info: Deleted "' + CONVERT(VARCHAR(50), @RowCount) + '" rows in DynaValue for MaskName = "' + @MaskName_Ka_Ausbildung + '"');
  END;
  
  -----------------------------------------------------------------------------
  -- Validation of KaArbeitsrapport (Präsenzzeiterfassung)
  -----------------------------------------------------------------------------
  -- check if per day and person only one entry exists (merging is done with BaPerson-auto-merge)
  IF (EXISTS (SELECT TOP 1 1
              FROM dbo.KaArbeitsrapport KAR WITH (READUNCOMMITTED)
              WHERE KAR.BaPersonID IN (@BaPersonID_Keep, @BaPersonID_Delete)
              GROUP BY Datum
              HAVING COUNT(1) > 1))
  BEGIN
    -- do not continue
    RAISERROR ('Error: Cannot merge entries of table "KaArbeitsrapport". There are duplicate values for at least one date in "Präsenzzeiterfassung" of the two persons.', 18, 1);
    RETURN;
  END;
  
  -----------------------------------------------------------------------------
  -- merge the other belonging data of FaLeistung KA-Allgemein to the one
  --   we'd like to keep
  -----------------------------------------------------------------------------
  IF (@DebugOn = 1)
  BEGIN
    PRINT ('Info: <FaLeistung_KAAllgemein>');
  END;
  
  EXEC dbo.spXRowMerge 'FaLeistung', @FaLeistungID_KAAllg, @FaLeistungID_KAAllg_Delete, 1, @DebugOn, 'FaLeistungID';
  
  IF (@DebugOn = 1)
  BEGIN
    PRINT ('Info: </FaLeistung_KAAllgemein>');
  END;
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  IF (@DebugOn = 1)
  BEGIN
    PRINT ('Info: </spKaAllgemein_RowMerge>');
  END;
END;
GO