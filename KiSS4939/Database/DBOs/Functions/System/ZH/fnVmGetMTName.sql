SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[fnVmGetMTName]') AND xtype in (N'FN', N'IF', N'TF'))
DROP FUNCTION [dbo].[fnVmGetMTName]
GO
/*===============================================================================================
  $Revision: 7 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnVmGetMTName(@BaPersonID int)
RETURNS varchar (150)
AS

BEGIN

DECLARE @MTName varchar(150)
SET @MTName = ''

SELECT TOP 1 @MTName = USR.NameVorname + ' (' + USR.OrgUnit + ')'
FROM   dbo.FaLeistung LEI WITH (READUNCOMMITTED)
  INNER JOIN vwUser USR ON USR.UserID = LEI.UserID
WHERE  LEI.BaPersonID = @BaPersonID AND
       LEI.FaProzessCode = 210
ORDER BY CASE WHEN ISNULL(LEI.DatumBis, '99991231') > GETDATE() THEN 1 ELSE 0 END DESC, --Wir wollen in jedem Fall zuerst die aktiven
         LEI.DatumVon DESC --Falls mehrere aktive (oder nur inaktive), dann den der aktuellsten Leistung (die am spätesten erstellt wurde)

RETURN @MTName
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
