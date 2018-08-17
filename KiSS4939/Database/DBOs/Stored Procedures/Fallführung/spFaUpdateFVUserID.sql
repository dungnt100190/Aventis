SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spFaUpdateFVUserID
GO
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Update user on Fallverlauf-responsible-UserID depending on existing open modules
           Prio: CM > SB > BW > ED > IN > FV
    @BaPersonID: The id of the person to get data for
  -
  RETURNS: Nothing to return
  -
  TEST:    EXEC dbo.spFaUpdateFVUserID 333
=================================================================================================*/

CREATE PROCEDURE dbo.spFaUpdateFVUserID
(
  @BaPersonID INT
)
AS
BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (ISNULL(@BaPersonID, -1) < 1)
  BEGIN
    -- failure
    RETURN
  END
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @UserID INT
  
  -----------------------------------------------------------------------------
  -- get userid depending on priority list
  -----------------------------------------------------------------------------
  -- Priorities:
  /*
    1. CM: Case Management (Modul 4)
    2. SB: Sozialberatung (Modul 3)
    3. BW: Begleitetes Wohnen (Modul 5)
    4. ED: Entlastungsdienst (Modul 6)
    5. IN: Intake (Modul 7)
    6. AB: Assistenzberatung (Modul 8)
    7. FV: Fallverlauf (Modul 2) (leave value from Fallverlauf)
  */
  
  -- CM
  SELECT TOP 1 @UserID = LEI.UserID 
  FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED) 
  WHERE LEI.BaPersonID = @BaPersonID AND 
        LEI.ModulID = 4 AND                         -- CM
        LEI.DatumBis IS NULL                        -- only open ones!
  ORDER BY LEI.DatumVon DESC, LEI.FaLeistungID DESC

  IF (@UserID IS NULL)
  BEGIN
    -- SB
    SELECT TOP 1 @UserID = LEI.UserID 
    FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED) 
    WHERE LEI.BaPersonID = @BaPersonID AND 
          LEI.ModulID = 3 AND                       -- SB
          LEI.DatumBis IS NULL                      -- only open ones!
    ORDER BY LEI.DatumVon DESC, LEI.FaLeistungID DESC
  END
  
  IF (@UserID IS NULL)
  BEGIN
    -- BW
    SELECT TOP 1 @UserID = LEI.UserID 
    FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED) 
    WHERE LEI.BaPersonID = @BaPersonID AND 
          LEI.ModulID = 5 AND                       -- BW
          LEI.DatumBis IS NULL                      -- only open ones!
    ORDER BY LEI.DatumVon DESC, LEI.FaLeistungID DESC
  END
  
  IF (@UserID IS NULL)
  BEGIN
    -- ED
    SELECT TOP 1 @UserID = LEI.UserID 
    FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED) 
    WHERE LEI.BaPersonID = @BaPersonID AND 
          LEI.ModulID = 6 AND                       -- ED
          LEI.DatumBis IS NULL                      -- only open ones!
    ORDER BY LEI.DatumVon DESC, LEI.FaLeistungID DESC
  END
  
  IF (@UserID IS NULL)
  BEGIN
    -- IN
    SELECT TOP 1 @UserID = LEI.UserID 
    FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED) 
    WHERE LEI.BaPersonID = @BaPersonID AND 
          LEI.ModulID = 7 AND                       -- IN
          LEI.DatumBis IS NULL                      -- only open ones!
    ORDER BY LEI.DatumVon DESC, LEI.FaLeistungID DESC
  END

  IF (@UserID IS NULL)
  BEGIN
    -- AB
    SELECT TOP 1 @UserID = LEI.UserID 
    FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED) 
    WHERE LEI.BaPersonID = @BaPersonID AND 
          LEI.ModulID = 8 AND                       -- AB
          LEI.DatumBis IS NULL                      -- only open ones!
    ORDER BY LEI.DatumVon DESC, LEI.FaLeistungID DESC
  END
  
  IF (@UserID IS NULL)
  BEGIN
    -- FV
    SELECT TOP 1 @UserID = LEI.UserID 
    FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED) 
    WHERE LEI.BaPersonID = @BaPersonID AND 
          LEI.ModulID = 2 AND                       -- FV
          LEI.DatumBis IS NULL                      -- only open ones!
    ORDER BY LEI.DatumVon DESC, LEI.FaLeistungID DESC
  END
  
  -- update latest Fallverlauf with new userid (only if changed)
  UPDATE LEI
  SET UserID = @UserID
  FROM dbo.FaLeistung LEI
  WHERE LEI.UserID <> @UserID AND
        ISNULL(@UserID, -1) > 0 AND
        LEI.FaLeistungID = (SELECT TOP 1 SUB.FaLeistungID                   -- get last open FV and update this one, there should only be one open FV at once
                            FROM dbo.FaLeistung SUB WITH (READUNCOMMITTED) 
                            WHERE SUB.BaPersonID = @BaPersonID AND 
                                  SUB.ModulID = 2 AND                       -- FV
                                  SUB.DatumBis IS NULL                      -- only open ones!
                            ORDER BY SUB.DatumVon DESC, SUB.FaLeistungID DESC)
END
GO