SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spFaTextmarkenSBCM
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Stored Procedures/Fallführung/spFaTextmarkenSBCM.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:01 $
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Use this sp to get bookmarks for SB and CM (Zielvereinbarung and Evaluation)
    @FaLeistungID:      The id within FaLeistung and module-depending table
    @ModulID:           The modulid to get bookmarks (SB=3, CM=4)
    @ShowEvalCol:       0=Evaluation-column will not be appended, 1=include evaluation column
    @OnlyNonEvaluated:  0=All entries will be shown, 1=only non-evaluated entries will be shown
    @LanguageCode:      The languagecode to use (by default german=1)
  -
  RETURNS: Data for bookmarks for given module with or without evaluation column
  -
  TEST:    EXEC dbo.spFaTextmarkenSBCM 142589, 3, 0, 0, 1   -- Lopes, Manuel
           EXEC dbo.spFaTextmarkenSBCM 142589, 3, 1, 0, 1
           --
           EXEC dbo.spFaTextmarkenSBCM 166776, 4, 0, 0, 1   -- Lussi, Bruno
           EXEC dbo.spFaTextmarkenSBCM 166776, 4, 1, 0, 1
           --
           EXEC dbo.spFaTextmarkenSBCM 166776, 4, 0, 1, 1   -- Lussi, Bruno (only non evaluated)
           EXEC dbo.spFaTextmarkenSBCM 166776, 4, 1, 1, 1
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Stored Procedures/Fallführung/spFaTextmarkenSBCM.sql $
 * 
 * 5     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 4     13.07.09 15:46 Cjaeggi
 * 
 * 3     13.07.09 15:45 Cjaeggi
 * #4782: Changed sorting of output and depending on this some logic-parts
 * 
 * 2     5.06.09 9:24 Cjaeggi
 * #4782: Implemented filter for evaluated entries
 * 
 * 1     19.03.09 14:51 Cjaeggi
 * New stored procedure for sb/cm bookmarks
=================================================================================================*/

CREATE PROCEDURE dbo.spFaTextmarkenSBCM
(
  @FaLeistungID INT,
  @ModulID INT,
  @ShowEvalCol BIT,
  @OnlyNonEvaluated BIT,
  @LanguageCode INT
)
AS 
BEGIN
  -------------------------------------------------------------------------------
  -- start call
  -------------------------------------------------------------------------------
  SET NOCOUNT ON
  PRINT ('start call: ' + CONVERT(VARCHAR, GETDATE(), 113))
  
  -------------------------------------------------------------------------------
  -- validate
  -------------------------------------------------------------------------------
  IF (@FaLeistungID IS NULL OR ISNULL(@ModulID, -1) NOT IN (3, 4))
  BEGIN
    -- do not continue
    RAISERROR ('Error: Invalid FaLeistungID (''%d'') and/or ModulID (''%d''), cannot continue!', 18, 1, @FaLeistungID, @ModulID)
    RETURN
  END
  
  -- set vars
  SET @ShowEvalCol      = ISNULL(@ShowEvalCol, 0)       -- by default, hide eval column
  SET @OnlyNonEvaluated = ISNULL(@OnlyNonEvaluated, 1)  -- by default, show all
  SET @LanguageCode     = ISNULL(@LanguageCode, 1)      -- by default german
  
  -------------------------------------------------------------------------------
  -- init table for collecting data
  -------------------------------------------------------------------------------
  DECLARE @TmpBookmarkData TABLE
  (
    ID INT NOT NULL PRIMARY KEY,
    ParentID INT NULL,
    Datum DATETIME,
    RZText VARCHAR(50),
    HZText VARCHAR(50),
    MNText VARCHAR(50),
    ItemText VARCHAR(MAX),
    ItemEvaluation VARCHAR(2000),
    IsEvaluated BIT
  )
  
  -------------------------------------------------------------------------------
  -- init ml-texts
  -------------------------------------------------------------------------------
  -- init vars
  DECLARE @RZText VARCHAR(50)
  DECLARE @HZText VARCHAR(50)
  DECLARE @MNText VARCHAR(50)
  DECLARE @Lebensbereich VARCHAR(50)
  DECLARE @Durch VARCHAR(50)
  DECLARE @Indikatoren VARCHAR(50)
  DECLARE @Kommentar VARCHAR(50)
  DECLARE @Frist VARCHAR(50)
  DECLARE @Evaluation VARCHAR(50)
  DECLARE @Erledigt VARCHAR(50)
  DECLARE @NichtErledigt VARCHAR(50)
  DECLARE @CrLf VARCHAR(2)
  
  -- get texts
  SET @RZText        = dbo.fnXDbObjectMLMsg('spFaTextmarkenSBCM', 'Rahmenziel', @LanguageCode)
  SET @HZText        = dbo.fnXDbObjectMLMsg('spFaTextmarkenSBCM', 'Handlungsziel', @LanguageCode)
  SET @MNText        = dbo.fnXDbObjectMLMsg('spFaTextmarkenSBCM', 'Massnahme', @LanguageCode)
  SET @Lebensbereich = dbo.fnXDbObjectMLMsg('spFaTextmarkenSBCM', 'Lebensbereich', @LanguageCode)
  SET @Durch         = dbo.fnXDbObjectMLMsg('spFaTextmarkenSBCM', 'Durch', @LanguageCode)
  SET @Indikatoren   = dbo.fnXDbObjectMLMsg('spFaTextmarkenSBCM', 'Indikatoren', @LanguageCode)
  SET @Kommentar     = dbo.fnXDbObjectMLMsg('spFaTextmarkenSBCM', 'Kommentar', @LanguageCode)
  SET @Frist         = dbo.fnXDbObjectMLMsg('spFaTextmarkenSBCM', 'Frist', @LanguageCode)
  SET @Evaluation    = dbo.fnXDbObjectMLMsg('spFaTextmarkenSBCM', 'Evaluation', @LanguageCode)
  SET @Erledigt      = dbo.fnXDbObjectMLMsg('spFaTextmarkenSBCM', 'Erledigt', @LanguageCode)
  SET @NichtErledigt = dbo.fnXDbObjectMLMsg('spFaTextmarkenSBCM', 'NichtErledigt', @LanguageCode)
  SET @CrLf          = CHAR(13)+CHAR(10)
  
  -- info
  PRINT ('fill data for given module: ' + CONVERT(VARCHAR, GETDATE(), 113))
  
  -------------------------------------------------------------------------------
  -- fill temporary table depending on current module
  -------------------------------------------------------------------------------
  IF (@ModulID = 3)
  BEGIN
    -- get SB-data (almost same code as CM)
    INSERT INTO @TmpBookmarkData (ID, ParentID, Datum, RZText, HZText, MNText, ItemText, ItemEvaluation, IsEvaluated)
      SELECT -- fill identifying and sorting data
             ID             = TBL.SbSozialberatungID,
             ParentID       = TBL.ElterID,
             Datum          = TBL.Datum,
             
             -- get table data
             RZText         = CASE WHEN TBL.IstRahmenziel = 1 THEN @RZText 
                                   ELSE NULL 
                              END,
             HZText         = CASE WHEN TBL.IstHandlungsziel = 1 THEN @HZText 
                                   ELSE NULL 
                              END,
             MNText         = CASE WHEN TBL.IstMassnahme = 1 THEN @MNText 
                                   ELSE NULL 
                              END,
             
             ItemText       = ISNULL(CONVERT(VARCHAR, TBL.Datum, 104) + ': ', '') + ISNULL(TBL.Text, '') + @CrLf +
                              CASE WHEN TBL.LebensbereichCode IS NOT NULL THEN ISNULL(@Lebensbereich + ': ' + dbo.fnLOVMLText('FaLebensbereich', TBL.LebensbereichCode, @LanguageCode) + @CrLf, '')
                                   ELSE ''
                              END +
                              ISNULL(@Durch + ': ' + TBL.Wer + @CrLf, '') +
                              ISNULL(@Indikatoren + ': ' + TBL.Indikatoren + @CrLf, '') +
                              ISNULL(@Kommentar + ': ' + TBL.Kommentar + @CrLf, '') +
                              ISNULL(@Frist + ': ' + CONVERT(VARCHAR, TBL.BisWann, 104) + @CrLf, ''),
             
             ItemEvaluation = ISNULL(@Evaluation + ': ' + CONVERT(VARCHAR, TBL.EvaluationDatum, 104) + @CrLf, '') +
                              CASE WHEN TBL.EvaluationCode IS NOT NULL THEN ISNULL(dbo.fnLOVMLText('FaErreichungsgrad', TBL.EvaluationCode, @LanguageCode) + @CrLf, '')
                                   ELSE ''
                              END +
                              CASE WHEN TBL.IstMassnahme = 1 THEN CASE WHEN TBL.Erledigt = 1 THEN @Erledigt
                                                                       ELSE @NichtErledigt
                                                                  END + @CrLf
                                   ELSE ''
                              END +
                              ISNULL(TBL.EvaluationBegruendung, ''),
                              
             IsEvaluated    = CASE WHEN TBL.EvaluationDatum IS NULL THEN 0
                                   ELSE 1
                              END
      FROM dbo.SbSozialberatung TBL WITH (READUNCOMMITTED)
      WHERE TBL.FaLeistungID = @FaLeistungID AND
            TBL.IstHaupteintrag = 0
  END
  ELSE
  BEGIN
    -- get CM-data (almost same code as SB)
    INSERT INTO @TmpBookmarkData (ID, ParentID, Datum, RZText, HZText, MNText, ItemText, ItemEvaluation, IsEvaluated)
      SELECT -- fill identifying and sorting data
             ID             = TBL.FaCaseManagementID,
             ParentID       = TBL.ElterID,
             Datum          = TBL.Datum,
             
             -- get table data
             RZText         = CASE WHEN TBL.IstRahmenziel = 1 THEN @RZText 
                                   ELSE NULL 
                              END,
             HZText         = CASE WHEN TBL.IstHandlungsziel = 1 THEN @HZText 
                                   ELSE NULL 
                              END,
             MNText         = CASE WHEN TBL.IstMassnahme = 1 THEN @MNText 
                                   ELSE NULL 
                              END,
             
             ItemText       = ISNULL(CONVERT(VARCHAR, TBL.Datum, 104) + ': ', '') + ISNULL(TBL.Text, '') + @CrLf +
                              CASE WHEN TBL.LebensbereichCode IS NOT NULL THEN ISNULL(@Lebensbereich + ': ' + dbo.fnLOVMLText('FaLebensbereich', TBL.LebensbereichCode, @LanguageCode) + @CrLf, '')
                                   ELSE ''
                              END +
                              ISNULL(@Durch + ': ' + TBL.Wer + @CrLf, '') +
                              ISNULL(@Indikatoren + ': ' + TBL.Indikatoren + @CrLf, '') +
                              ISNULL(@Kommentar + ': ' + TBL.Kommentar + @CrLf, '') +
                              ISNULL(@Frist + ': ' + CONVERT(VARCHAR, TBL.BisWann, 104) + @CrLf, ''),
             
             ItemEvaluation = ISNULL(@Evaluation + ': ' + CONVERT(VARCHAR, TBL.EvaluationDatum, 104) + @CrLf, '') +
                              CASE WHEN TBL.EvaluationCode IS NOT NULL THEN ISNULL(dbo.fnLOVMLText('FaErreichungsgrad', TBL.EvaluationCode, @LanguageCode) + @CrLf, '')
                                   ELSE ''
                              END +
                              CASE WHEN TBL.IstMassnahme = 1 THEN CASE WHEN TBL.Erledigt = 1 THEN @Erledigt
                                                                       ELSE @NichtErledigt
                                                                  END + @CrLf
                                   ELSE ''
                              END +
                              ISNULL(TBL.EvaluationBegruendung, ''),
                              
             IsEvaluated    = CASE WHEN TBL.EvaluationDatum IS NULL THEN 0
                                   ELSE 1
                              END
      FROM dbo.FaCaseManagement TBL WITH (READUNCOMMITTED)
      WHERE TBL.FaLeistungID = @FaLeistungID AND
            TBL.IstHaupteintrag = 0
  END
  
  -------------------------------------------------------------------------------
  -- prepare data
  -------------------------------------------------------------------------------
  -- remove trailing crlf and remove unused spaces
  UPDATE TMP
  SET TMP.ItemText       = LTRIM(RTRIM(CASE WHEN (LEN(TMP.ItemText) > 1 AND RIGHT(TMP.ItemText, 2) = @CrLf) THEN LEFT(TMP.ItemText, LEN(TMP.ItemText) - 2)
                                            ELSE TMP.ItemText
                                       END)),
      TMP.ItemEvaluation = LTRIM(RTRIM(CASE WHEN (LEN(TMP.ItemEvaluation) > 1 AND RIGHT(TMP.ItemEvaluation, 2) = @CrLf) THEN LEFT(TMP.ItemEvaluation, LEN(TMP.ItemEvaluation) - 2)
                                            ELSE TMP.ItemEvaluation
                                       END))
  FROM @TmpBookmarkData TMP
  
  -- info
  PRINT ('show output depending on evaluation: ' + CONVERT(VARCHAR, GETDATE(), 113))
  
  -------------------------------------------------------------------------------
  -- show output depending on flag
  -------------------------------------------------------------------------------
  IF (@ShowEvalCol = 0)
  BEGIN  
    -----------------------------------------------------------------------------
    -- output without evaluation column (almost same code as below, see notes)
    -----------------------------------------------------------------------------
    ;--last statement MUST be semicolon-terminated to use a CTE
    WITH RES (ID, ParentID, Depth, Datum, SortKey) AS 
    (
        -- get top-level-entries
        SELECT ID       = TMP.ID, 
               ParentID = TMP.ParentID, 
               Depth    = 0,
               Datum    = TMP.Datum,
               SortKey  = CONVERT(VARCHAR(255), 'RZ' + CONVERT(VARCHAR(50), TMP.ID))
        FROM @TmpBookmarkData TMP
        WHERE TMP.ParentID IS NULL -- for all top-level-entries
        
        UNION ALL
        
        -- get all sub-level-entries
        SELECT ID       = SUB.ID, 
               ParentID = SUB.ParentID, 
               Depth    = TRE.Depth + 1,
               Datum    = TRE.Datum, -- use date of top-level-entries (used for first prio sorting)
               SortKey  = CONVERT(VARCHAR(255), TRE.SortKey + CASE WHEN (TRE.Depth + 1) = 0 THEN 'RZ' + CONVERT(VARCHAR(50), SUB.ID)
                                                                   WHEN (TRE.Depth + 1) = 1 THEN 'HZ' + CONVERT(VARCHAR(50), SUB.ID)
                                                                   WHEN (TRE.Depth + 1) = 2 THEN 'MN' + CONVERT(VARCHAR(50), SUB.ID)
                                                                   ELSE '--'
                                                              END)
        FROM @TmpBookmarkData AS SUB
          INNER JOIN RES AS TRE ON TRE.ID = SUB.ParentID
    )
    SELECT TMP.RZText,
           NextCell   = NULL,
           TMP.HZText,
           NextCell   = NULL,
           TMP.MNText,
           NextCell   = NULL,
           TMP.ItemText,
           NextCell   = NULL
    FROM RES
      INNER JOIN @TmpBookmarkData TMP ON TMP.ID = RES.ID
    WHERE (@OnlyNonEvaluated = 0 OR ISNULL(TMP.IsEvaluated, 0) = 0)  -- show all or only non-evaluated entries
    ORDER BY RES.Datum, RES.SortKey
  END
  ELSE
  BEGIN
    -----------------------------------------------------------------------------
    -- output including evaluation column (almost same code as above, see notes)
    -----------------------------------------------------------------------------
    ;--last statement MUST be semicolon-terminated to use a CTE
    WITH RES (ID, ParentID, Depth, Datum, SortKey) AS 
    (
        -- get top-level-entries
        SELECT ID       = TMP.ID, 
               ParentID = TMP.ParentID, 
               Depth    = 0,
               Datum    = TMP.Datum,
               SortKey  = CONVERT(VARCHAR(255), 'RZ' + CONVERT(VARCHAR(50), TMP.ID))
        FROM @TmpBookmarkData TMP
        WHERE TMP.ParentID IS NULL -- for all top-level-entries
        
        UNION ALL
        
        -- get all sub-level-entries
        SELECT ID       = SUB.ID, 
               ParentID = SUB.ParentID, 
               Depth    = TRE.Depth + 1,
               Datum    = TRE.Datum, -- use date of top-level-entries (used for first prio sorting)
               SortKey  = CONVERT(VARCHAR(255), TRE.SortKey + CASE WHEN (TRE.Depth + 1) = 0 THEN 'RZ' + CONVERT(VARCHAR(50), SUB.ID)
                                                                   WHEN (TRE.Depth + 1) = 1 THEN 'HZ' + CONVERT(VARCHAR(50), SUB.ID)
                                                                   WHEN (TRE.Depth + 1) = 2 THEN 'MN' + CONVERT(VARCHAR(50), SUB.ID)
                                                                   ELSE '--'
                                                              END)
        FROM @TmpBookmarkData AS SUB
          INNER JOIN RES AS TRE ON TRE.ID = SUB.ParentID
    )
    SELECT TMP.RZText,
           NextCell   = NULL,
           TMP.HZText,
           NextCell   = NULL,
           TMP.MNText,
           NextCell   = NULL,
           TMP.ItemText,
           NextCell   = NULL,
           TMP.ItemEvaluation,    -- only this column is additional to upper code (IF (@ShowEvalCol = 0))
           NextCell   = NULL      -- only this column is additional to upper code (IF (@ShowEvalCol = 0))
    FROM RES
      INNER JOIN @TmpBookmarkData TMP ON TMP.ID = RES.ID
    WHERE (@OnlyNonEvaluated = 0 OR ISNULL(TMP.IsEvaluated, 0) = 0)  -- show all or only non-evaluated entries
    ORDER BY RES.Datum, RES.SortKey
  END
END
GO
