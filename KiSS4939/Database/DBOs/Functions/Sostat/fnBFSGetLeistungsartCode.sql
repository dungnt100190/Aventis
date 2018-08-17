SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnBFSGetLeistungsartCode
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnBFSGetLeistungsartCode
(
  @FaProzessCode INT,
  @FaLeistungID  INT
)
RETURNS INT
AS 
BEGIN
  DECLARE @BFSLeistungsartCode INT;

  -- Für alle anderen mit LeistungsartCode 
  SET @BFSLeistungsartCode = (SELECT TOP 1 COALESCE(dbo.fnBFSCode('Leistungsart', LEI.LeistungsartCode),
                                                    dbo.fnBFSCode('FaProzess', @FaProzessCode),
                                                    2)
                              FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                                INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
                              WHERE LEI.FaLeistungID = @FaLeistungID);
  
  RETURN @BFSLeistungsartCode;
END
GO 