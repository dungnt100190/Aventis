﻿/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: use this script to remove E/M/L on all XUserGroup_Right on CtlWhSpezialkonto
=================================================================================================*/


-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- step 1
-------------------------------------------------------------------------------
UPDATE UGR SET MayInsert = 0, MayUpdate = 0, MayDelete = 0
FROM XUserGroup_Right UGR 
  INNER JOIN XRight RIG ON RIG.RightID = UGR.RightID
where UGR.ClassName = 'CtlWhSpezialkonto'
  and RIG.RightName = 'CtlWhSpezialkonto_Ausgabekonto'
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO