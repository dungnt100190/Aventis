SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject XViewIndex;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Views/System/XViewIndex.sql $
  $Author: Cjaeggi $
  $Modtime: 21.05.10 11:38 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this view to get view indexes
  -
  RETURNS: Indexes of views
  -
  TEST:    SELECT TOP 30 * FROM dbo.XViewIndex
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Views/System/XViewIndex.sql $
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

CREATE VIEW dbo.XViewIndex
AS
SELECT IndexName   = SIX.Name,
       TableName   = SOB.Name,
       PrimaryKey  = CAST((CASE(SIX.status & 2048) 
                             WHEN 2048 THEN 1 
                             ELSE 0 
                           END) AS BIT),
       [Unique]    = CAST(INDEXPROPERTY(SIX.id, SIX.Name, 'IsUnique') AS BIT),
       [Clustered] = CAST(INDEXPROPERTY(SIX.id, SIX.Name, 'IsClustered') AS BIT),
       Keys        = dbo.fnGetKeyColumnsOfIndex(SOB.Name, SIX.Name)
FROM dbo.sysindexes SIX WITH (READUNCOMMITTED)
  INNER JOIN dbo.sysobjects SOB WITH (READUNCOMMITTED) ON SOB.id = SIX.id
WHERE SIX.indid > 0 
  AND SIX.indid < 255 
  AND INDEXPROPERTY(SIX.id, SIX.Name, 'IsStatistics') = 0 
  AND INDEXPROPERTY(SIX.id, SIX.Name, 'IsHypothetical') = 0;
GO
