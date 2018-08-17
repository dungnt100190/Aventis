SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnWhGetPositionStatus;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/Sozialhilfe/fnWhGetPositionStatus.sql $
  $Author: Cjaeggi $
  $Modtime: 14.05.10 14:25 $
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Get KbBuchungsStatus value for position depending on given flags and position state
    @BgPositionID:         The id within BgPosition that identifies the entry
    @OnlyThisBgPositionID: 1 = get status only of given BgPositionID, do not handle master/detail position
                           0 = get status depending on all master/detail positions
    @OnlyPositionNoKlibu:  1 = get status only from BgPosition, do not check if position is in KbBuchung
                           0 = handle in first priority status within KbBuchung, second BgPosition
    @ReturnMinStatus:      1 = return minimum status for all found entries
                           0 = return maximum status for all found entries
  -
  RETURNS: The state as defined in LOV KbBuchungStatus for given BgPositionID and flags or NULL if invalid/no data
  -
  TEST:    SELECT dbo.fnWhGetPositionStatus(3809161, 1, 0, 0);
           SELECT dbo.fnWhGetPositionStatus(3809161, 1, 0, 1);
           SELECT dbo.fnWhGetPositionStatus(3809161, 0, 0, 0);
           SELECT dbo.fnWhGetPositionStatus(3809161, 0, 0, 1);
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/Sozialhilfe/fnWhGetPositionStatus.sql $
 * 
 * 6     14.05.10 14:25 Cjaeggi
 * #5478: BugFix: Status is now shown from BgPosition if minimum and not
 * all entries in klibu
 * 
 * 5     14.05.10 13:34 Cjaeggi
 * #5478: Fix status pos/klibu
 * 
 * 4     14.05.10 12:04 Cjaeggi
 * #5478: Implemented status function and added new indexes
 * 
 * 3     14.05.10 10:23 Cjaeggi
 * Updated sys-admin user to fix display name
 * 
 * 2     12.05.10 12:06 Cjaeggi
 * 
 * 1     12.05.10 9:58 Cjaeggi
 * #5478: Added new scalar function fnWhGetPositionStatus
=================================================================================================*/

CREATE FUNCTION dbo.fnWhGetPositionStatus
(
  @BgPositionID INT,
  @OnlyThisBgPositionID BIT,
  @OnlyPositionNoKlibu BIT,
  @ReturnMinStatus BIT
)
RETURNS INT
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate parameters
  -----------------------------------------------------------------------------
  SET @BgPositionID         = ISNULL(@BgPositionID, -1);
  SET @OnlyThisBgPositionID = ISNULL(@OnlyThisBgPositionID, 0);
  SET @OnlyPositionNoKlibu  = ISNULL(@OnlyPositionNoKlibu, 0);
  SET @ReturnMinStatus      = ISNULL(@ReturnMinStatus, 0);
  
  -----------------------------------------------------------------------------
  -- init vars
  -----------------------------------------------------------------------------
  DECLARE @ReturnKbBuchungsStatusCode INT;
  DECLARE @BgBewilligungStatusCode INT;
  
  SET @ReturnKbBuchungsStatusCode = NULL;
  SET @BgBewilligungStatusCode = NULL;
  
  DECLARE @TmpBgPosition TABLE
  (
    BgPositionID INT NOT NULL PRIMARY KEY,
    KbBuchungStatusCode INT NOT NULL,
    StatusMinOrdered INT NOT NULL
  );
  
  DECLARE @TmpKbBuchung TABLE
  (
    ID INT NOT NULL IDENTITY(1, 1),
    KbBuchungStatusCode INT NOT NULL,
    StatusMinOrdered INT NOT NULL
  );
  
  -----------------------------------------------------------------------------
  -- check if need to get master position (if this is child position)
  -----------------------------------------------------------------------------
  IF (@OnlyThisBgPositionID = 0)
  BEGIN
    -- get master BgPositionID if on detail position, otherwise keep id
    SELECT @BgPositionID = COALESCE(POS.BgPositionID_Parent, POS.BgPositionID)
    FROM dbo.BgPosition POS WITH (READUNCOMMITTED)
    WHERE POS.BgPositionID = @BgPositionID;
  END;
  
  -----------------------------------------------------------------------------
  -- get all required positions (all belonging or only current)
  -----------------------------------------------------------------------------
  INSERT INTO @TmpBgPosition (BgPositionID, KbBuchungStatusCode, StatusMinOrdered)    
    SELECT BgPositionID        = POS.BgPositionID,
           KbBuchungStatusCode = CASE POS.BgBewilligungStatusCode
                                   WHEN 1 THEN 1   -- in vorbereitung = vorbereitet
                                   WHEN 2 THEN 15  -- bew. abgelehnt  = abgelehnt
                                   WHEN 3 THEN 12  -- bew. angefragt  = angefragt
                                   WHEN 5 THEN 14  -- bew. erteilt    = bewilligt
                                   WHEN 9 THEN 7   -- gesperrt        = gesperrt
                                   ELSE NULL
                                 END,
           StatusMinOrdered    = CASE POS.BgBewilligungStatusCode
                                   WHEN 1 THEN 1  -- in vorbereitung
                                   WHEN 3 THEN 2  -- bew. angefragt
                                   WHEN 5 THEN 3  -- bew. erteilt
                                   WHEN 2 THEN 4  -- bew. abgelehnt
                                   WHEN 9 THEN 5  -- gesperrt
                                   ELSE NULL
                                 END
    FROM dbo.BgPosition POS WITH (READUNCOMMITTED)
    WHERE POS.BgPositionID = @BgPositionID
       OR (@OnlyThisBgPositionID = 0 AND POS.BgPositionID_Parent = @BgPositionID);
  
  -----------------------------------------------------------------------------
  -- check if position is within Klibu
  -----------------------------------------------------------------------------  
  IF (@OnlyPositionNoKlibu = 0)
  BEGIN
    -- get all possible status from KbBuchung for given position(s) (if already in klibu)
    INSERT INTO @TmpKbBuchung (KbBuchungStatusCode, StatusMinOrdered)    
      SELECT KbBuchungStatusCode = BUC.KbBuchungStatusCode,
             StatusMinOrdered    = CASE BUC.KbBuchungStatusCode
                                     WHEN 2  THEN 1   -- freigegeben
                                     WHEN 7  THEN 2   -- gesperrt
                                     WHEN 4  THEN 3   -- ausgedruckt
                                     WHEN 13 THEN 4   -- verbucht
                                     WHEN 3  THEN 5   -- zahlauftrag erstellt
                                     WHEN 11 THEN 6   -- barbezug
                                     WHEN 10 THEN 7   -- teilweise ausgeglichen
                                     WHEN 6  THEN 8   -- ausgeglichen
                                     WHEN 5  THEN 9   -- zahlauftrag fehlerhaft
                                     WHEN 9  THEN 10  -- ruecklaeufer
                                     WHEN 8  THEN 11  -- storno
                                     ELSE NULL
                                   END
      FROM dbo.KbBuchung BUC WITH (READUNCOMMITTED)
        INNER JOIN dbo.KbBuchungKostenart BKO WITH (READUNCOMMITTED) ON BKO.KbBuchungID = BUC.KbBuchungID
                                                                    AND BKO.BgPositionID IN (SELECT TMP.BgPositionID
                                                                                             FROM @TmpBgPosition TMP);
    
    -- check if we have any matching data
    IF (EXISTS(SELECT TOP 1 1
               FROM @TmpKbBuchung))
    BEGIN    
      -- get status depending on max/min flag
      IF (@ReturnMinStatus = 1)
      BEGIN
        -- remove all granted entries in TmpBgPosition that have matching entries in KbBuchungKostenart
        -- afterward, we expect having no more entries in TmpBgPosition
        DELETE TMP
        FROM @TmpBgPosition                 TMP
          INNER JOIN dbo.KbBuchungKostenart BKA ON BKA.BgPositionID = TMP.BgPositionID
        WHERE TMP.KbBuchungStatusCode = 14; -- bewilligt
        
        -- check if there are any entries in TmpBgPosition (otherwise get min-status from TmpBgPosition)
        IF (NOT EXISTS(SELECT TOP 1 1
                       FROM @TmpBgPosition))
        BEGIN
          -- get MIN status from TmpKbBuchung (no missing status within BgPosition)
          SELECT TOP 1 @ReturnKbBuchungsStatusCode = TMP.KbBuchungStatusCode
          FROM @TmpKbBuchung TMP
          ORDER BY TMP.StatusMinOrdered ASC;  -- min
        END;
      END;
      ELSE
      BEGIN
        -- get MAX status from TmpKbBuchung
        SELECT TOP 1 @ReturnKbBuchungsStatusCode = TMP.KbBuchungStatusCode
        FROM @TmpKbBuchung TMP
        ORDER BY TMP.StatusMinOrdered DESC; -- max
      END;
    END;
  END;
  
  -----------------------------------------------------------------------------
  -- check if need to get status from position
  ----------------------------------------------------------------------------- 
  IF (@ReturnKbBuchungsStatusCode IS NULL)
  BEGIN
    -- get status depending on max/min flag
    IF (@ReturnMinStatus = 1)
    BEGIN
      -- get MIN status from TmpBgPosition
      SELECT TOP 1 @ReturnKbBuchungsStatusCode = TMP.KbBuchungStatusCode
      FROM @TmpBgPosition TMP
      ORDER BY TMP.StatusMinOrdered ASC;  -- min
    END;
    ELSE
    BEGIN
      -- get MAX status from TmpBgPosition
      SELECT TOP 1 @ReturnKbBuchungsStatusCode = TMP.KbBuchungStatusCode
      FROM @TmpBgPosition TMP
      ORDER BY TMP.StatusMinOrdered DESC; -- max
    END;
  END;
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN @ReturnKbBuchungsStatusCode;
END;
GO