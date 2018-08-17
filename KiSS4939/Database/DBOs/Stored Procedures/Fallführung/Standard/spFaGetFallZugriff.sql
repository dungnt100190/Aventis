SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spFaGetFallZugriff;
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Get case permissions for specific user
    @UserID:       The id of the user who want to get access to case
    @FaLeistungID: The id within FaLeistung to check for access
  -
  RETURNS: Various permission-flags for given user and case
  -
  TEST:    EXEC dbo.spFaGetFallZugriff 2, 3000
           EXEC dbo.spFaGetFallZugriff 333, 3000
=================================================================================================*/
CREATE PROCEDURE dbo.spFaGetFallZugriff
(
  @UserID INT, 
  @FaLeistungID INT
)
AS 
BEGIN
  SELECT
    MayRead      = IsNull(CASE WHEN ACL.Closed = 1 THEN NoAccess ELSE ACL.MayRead END, NoAccess),
    MayInsert    = IsNull(CASE WHEN ACL.Closed = 1 THEN NoAccess ELSE ACL.MayInsert END, NoAccess),
    MayUpdate    = IsNull(CASE WHEN ACL.Closed = 1 THEN NoAccess ELSE ACL.MayUpdate END, NoAccess),
    MayDelete    = IsNull(CASE WHEN ACL.Closed = 1 THEN NoAccess ELSE ACL.MayDelete END, NoAccess),

    ACL.Closed,
    ACL.Archived,

    MayClose     = CASE WHEN ACL.Archived = 1 THEN NoAccess ELSE ACL.MayUpdate END,
    MayReopen    = CASE WHEN ACL.Archived = 1 THEN NoAccess ELSE ACL.MayUpdate END
  FROM (SELECT NoAccess = CONVERT(bit, 0) )              TMP
    LEFT  JOIN dbo.fnUserAccess(@UserID, @FaLeistungID)  ACL ON 1 = 1;
END;

GO