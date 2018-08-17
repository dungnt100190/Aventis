SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEGetHistKostenartPerDate;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetHistKostenartPerDate.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:15 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get historised default Kostenart for user and date
    @UserID:            The user to get data from
    @BDELeistungsartID: The leistungsart to get data from
    @Date:              The date the Pensum has to be calculated to.
  -
  RETURNS: The default value to specified date, or -1 if invalid
  -
  TEST:    SELECT [dbo].[fnBDEGetHistKostenartPerDate](2, 453, '2008-01-28')
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetHistKostenartPerDate.sql $
 * 
 * 3     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 2     18.09.08 12:04 Cjaeggi
 * Test-Statement, CaseFix
 * 
 * 1     3.09.08 17:50 Aklopfenstein
 * 
 * 1     29.08.08 15:04 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEGetHistKostenartPerDate
(
  @UserID INT,
  @BDELeistungsartID INT,
  @Date DATETIME
)
RETURNS INT
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- if not all values are passed, we cannot do anything
  IF (@UserID IS NULL OR @BDELeistungsartID IS NULL OR @Date IS NULL)
  BEGIN
    RETURN -1
  END

  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @Kostenart INT

  -----------------------------------------------------------------------------
  -- get hist-value from leistungsart
  --   latest value is also in history, so we only have to check this table
  ----------------------------------------------------------------------------- 
  SELECT TOP 1 @Kostenart = BLA.KostenartCode
  FROM dbo.Hist_BDELeistungsart BLA WITH (READUNCOMMITTED)
    INNER JOIN dbo.HistoryVersion HIS WITH (READUNCOMMITTED) ON HIS.VerID = BLA.VerID
  WHERE BLA.BDELeistungsartID = @BDELeistungsartID AND DATEADD(d, 0, DATEDIFF(d, 0, HIS.VersionDate)) <= @Date
  ORDER BY HIS.VersionDate DESC, HIS.VerID DESC

  -----------------------------------------------------------------------------
  -- if we have a value on leistungsart, return this, 
  --   otherwise get value from user
  ----------------------------------------------------------------------------- 
  IF (@Kostenart IS NOT NULL)
  BEGIN
    -- return value we found
    RETURN @Kostenart
  END

  -----------------------------------------------------------------------------
  -- get value from user
  ----------------------------------------------------------------------------- 
  SELECT TOP 1 @Kostenart = USR.Kostenart
  FROM dbo.Hist_XUser USR WITH (READUNCOMMITTED)
    INNER JOIN dbo.HistoryVersion HIS WITH (READUNCOMMITTED) ON HIS.VerID = USR.VerID
  WHERE USR.UserID = @UserID AND DATEADD(d, 0, DATEDIFF(d, 0, HIS.VersionDate)) <= @Date
  ORDER BY HIS.VersionDate DESC, HIS.VerID DESC

  -----------------------------------------------------------------------------
  -- check and return value
  ----------------------------------------------------------------------------- 
  RETURN ISNULL(@Kostenart, -1)
END
GO