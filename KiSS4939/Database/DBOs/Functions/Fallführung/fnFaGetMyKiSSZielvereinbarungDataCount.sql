SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnFaGetMyKiSSZielvereinbarungDataCount;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Fallführung/fnFaGetMyKiSSZielvereinbarungDataCount.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:28 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get count values for not evaluated Zielvereinbarungen used within
           MyKiSS for dbo.spFaGetMyKiSSData
    @UserID:      The userid to use for filtering
    @Date:        The specific date to use for filtering
    @ModulID:     The desired module id to get data for
                  - 3=SB
                  - 4=CM
    @ItemCode:    The desired result to display for data-output
                  - 1='Rahmenziel'
                  - 2='Handlungsziel'
                  - 3='Massnahme'
    @OnlyExpired: Flag if only expired items have to be counted
  -
  RETURNS: Counted items for given module and paramters. If invalid parameters are given -1 will be returned.
  -
  TEST:    SELECT [dbo].[fnFaGetMyKiSSZielvereinbarungDataCount](2, GETDATE(), 3, 87160, 1, 0)
           SELECT [dbo].[fnFaGetMyKiSSZielvereinbarungDataCount](2, GETDATE(), 3, 87160, 1, 1)
           -
           SELECT [dbo].[fnFaGetMyKiSSZielvereinbarungDataCount](2, GETDATE(), 4, 87160, 1, 0)
           SELECT [dbo].[fnFaGetMyKiSSZielvereinbarungDataCount](2, GETDATE(), 4, 87160, 1, 1)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Fallführung/fnFaGetMyKiSSZielvereinbarungDataCount.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     25.02.09 15:36 Cjaeggi
 * New function required for MyKiSS sp
=================================================================================================*/

CREATE FUNCTION dbo.fnFaGetMyKiSSZielvereinbarungDataCount
(
  @UserID INT,
  @Date DATETIME,
  @ModulID INT,
  @BaPersonID INT,
  @ItemCode INT,
  @OnlyExpired BIT
)
RETURNS INT
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- validate expected values
  IF (@UserID IS NULL OR 
      @Date IS NULL OR 
      ISNULL(@ModulID, -1) NOT IN (3, 4) OR 
      @BaPersonID IS NULL OR
      ISNULL(@ItemCode, -1) NOT IN (1, 2, 3))
  BEGIN
    -- wrong parameters, do nothing
    RETURN -1
  END
  
  -- set bits
  SET @OnlyExpired = ISNULL(@OnlyExpired, 0)
  
  -----------------------------------------------------------------------------
  -- init vars
  -----------------------------------------------------------------------------
  DECLARE @ReturnValue INT
  
  -----------------------------------------------------------------------------
  -- module depending action
  -----------------------------------------------------------------------------
  IF (@ModulID = 3)
  BEGIN
    ---------------------------------------------------------------------------
    -- get data for SB (same code as below except table SbSozialberatung)
    ---------------------------------------------------------------------------
    SELECT @ReturnValue = COUNT(1) 
    FROM dbo.SbSozialberatung SSB WITH (READUNCOMMITTED)
      INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = SSB.FaLeistungID AND  -- only current FaLeistungID
                                                              LEI.BaPersonID = @BaPersonID AND         -- only for current person
                                                              LEI.UserID = @UserID AND                 -- only for current user
                                                              LEI.DatumBis IS NULL                     -- only open items
    WHERE SSB.EvaluationDatum IS NULL AND                                 -- those which are not yet evaluated!
          ((@ItemCode = 1 AND SSB.IstRahmenziel = 1) OR                   -- RZ?
           (@ItemCode = 2 AND SSB.IstHandlungsziel = 1) OR                -- HZ?
           (@ItemCode = 3 AND SSB.IstMassnahme = 1)) AND                  -- MN?
          (@OnlyExpired = 0 OR ISNULL(SSB.BisWann, '1753-01-01') < @Date) -- those which are expired? 
  END
  ELSE IF (@ModulID = 4)
  BEGIN
    ---------------------------------------------------------------------------
    -- get data for CM (same code as above except table FaCaseManagement)
    ---------------------------------------------------------------------------
    SELECT @ReturnValue = COUNT(1) 
    FROM dbo.FaCaseManagement FCM WITH (READUNCOMMITTED)
      INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = FCM.FaLeistungID AND  -- only current FaLeistungID
                                                              LEI.BaPersonID = @BaPersonID AND         -- only for current person
                                                              LEI.UserID = @UserID AND                 -- only for current user
                                                              LEI.DatumBis IS NULL                     -- only open items
    WHERE FCM.EvaluationDatum IS NULL AND                                 -- those which are not yet evaluated!
          ((@ItemCode = 1 AND FCM.IstRahmenziel = 1) OR                   -- RZ?
           (@ItemCode = 2 AND FCM.IstHandlungsziel = 1) OR                -- HZ?
           (@ItemCode = 3 AND FCM.IstMassnahme = 1)) AND                  -- MN?
          (@OnlyExpired = 0 OR ISNULL(FCM.BisWann, '1753-01-01') < @Date) -- those which are expired? 
  END
  ELSE
  BEGIN
    -- invalid id, do nothing
    RETURN -1
  END
  
  -----------------------------------------------------------------------------
  -- done, return value
  -----------------------------------------------------------------------------
  RETURN ISNULL(@ReturnValue, -1)
END
