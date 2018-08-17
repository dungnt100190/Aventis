SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject XViewForeignKeys;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Views/System/XViewForeignKeys.sql $
  $Author: Cjaeggi $
  $Modtime: 21.05.10 11:31 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this view to get foreign keys on table and columns
  -
  RETURNS: All foreign keys of all tables
  -
  TEST:    SELECT TOP 30 * FROM dbo.XViewForeignKeys
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Views/System/XViewForeignKeys.sql $
 * 
 * 3     21.05.10 11:40 Cjaeggi
 * Merged and revised for coding rules
 * 
 * 2     7.01.10 10:45 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:53 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE VIEW dbo.XViewForeignKeys
AS
SELECT DISTINCT 
       ForeignKeyName = SOB.[Name],
       PKTable        = OBJECT_NAME(SFK.rkeyid),
       PKColumns      = dbo.fnGetReferencedKeyColumnsOfForeignKey(SFK.constid),
       FKTable        = OBJECT_NAME(SFK.fkeyid),
       FKColumns      = dbo.fnGetForeignKeyColumnsOfForeignKey(SFK.constid)
FROM dbo.sysforeignkeys     SFK WITH (READUNCOMMITTED)
  INNER JOIN dbo.sysobjects SOB WITH (READUNCOMMITTED) ON SFK.constid = SOB.id;
GO