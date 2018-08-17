SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEGetHistKostentraegerPerDate;
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get historised default Kostentraeger for user and date
    @UserID:            The user to get data from
    @BDELeistungsartID: The leistungsart to get data from
    @Date:              The date the Pensum has to be calculated to.
  -
  RETURNS: The default value to specified date, or -1 if invalid
=================================================================================================
  TEST:    SELECT * FROM [dbo].[fnBDEGetHistKostentraegerPerDate](2, 453, '2008-01-28')
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEGetHistKostentraegerPerDate
(
  @UserID INT,
  @BDELeistungsartID INT,
  @Date DATETIME
)
RETURNS @Result TABLE
(
  Kostentraeger INT
)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- if not all values are passed, we cannot do anything
  IF (@UserID IS NULL OR @BDELeistungsartID IS NULL OR @Date IS NULL)
  BEGIN
    INSERT INTO @Result (Kostentraeger) VALUES (-1);
    RETURN;
  END;

  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @Kostentraeger INT;
  DECLARE @WeitereKostentraeger VARCHAR(500);

  -----------------------------------------------------------------------------
  -- get hist-value from leistungsart
  --   latest value is also in history, so we only have to check this table
  ----------------------------------------------------------------------------- 
  SELECT TOP 1 @Kostentraeger = BLA.KTRStandard
  FROM dbo.Hist_BDELeistungsart BLA WITH (READUNCOMMITTED)
    INNER JOIN dbo.HistoryVersion HIS WITH (READUNCOMMITTED) ON HIS.VerID = BLA.VerID
  WHERE BLA.BDELeistungsartID = @BDELeistungsartID AND DATEADD(d, 0, DATEDIFF(d, 0, HIS.VersionDate)) <= @Date
  ORDER BY HIS.VersionDate DESC, HIS.VerID DESC;

  -----------------------------------------------------------------------------
  -- if we have a value on leistungsart, return this, 
  --   otherwise get value from user
  ----------------------------------------------------------------------------- 
  IF (@Kostentraeger IS NOT NULL)
  BEGIN
    -- return value we found
    INSERT INTO @Result (Kostentraeger) VALUES (@Kostentraeger);
    RETURN;
  END;

  -----------------------------------------------------------------------------
  -- get value from user
  ----------------------------------------------------------------------------- 
  SELECT TOP 1 
    @Kostentraeger = USR.Kostentraeger,
    @WeitereKostentraeger = USR.WeitereKostentraeger
  FROM dbo.Hist_XUser USR WITH (READUNCOMMITTED)
    INNER JOIN dbo.HistoryVersion HIS WITH (READUNCOMMITTED) ON HIS.VerID = USR.VerID
  WHERE USR.UserID = @UserID AND DATEADD(d, 0, DATEDIFF(d, 0, HIS.VersionDate)) <= @Date
  ORDER BY HIS.VersionDate DESC, HIS.VerID DESC;

  -- return the Standard-Kostenträger if Weitere Kostenträger is empty
  IF (@WeitereKostentraeger IS NULL)
  BEGIN
    INSERT INTO @Result (Kostentraeger) VALUES (ISNULL(@Kostentraeger, -1));
    RETURN;
  END;
  
  -- return all values from User
  INSERT INTO @Result (Kostentraeger) 
    SELECT @Kostentraeger
    WHERE @Kostentraeger IS NOT NULL
    UNION ALL
    SELECT SplitValue
    FROM dbo.fnSplitStringToValues(@WeitereKostentraeger, ',', 1) 
    WHERE SplitValue <> ISNULL(@Kostentraeger, -1);

  -----------------------------------------------------------------------------
  -- check and return value
  ----------------------------------------------------------------------------- 
  RETURN;
END;
GO