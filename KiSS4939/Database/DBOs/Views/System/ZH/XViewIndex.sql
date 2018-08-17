SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject XViewIndex
GO

CREATE VIEW dbo.XViewIndex AS
SELECT IndexName = si.Name,
       TableName = so.Name,
       PrimaryKey = CAST( ( CASE (si.Status & 2048) WHEN 2048 THEN 1 ELSE 0 END ) AS bit ),
       [Unique] = CAST( INDEXPROPERTY(si.id, si.Name, 'IsUnique') AS bit ),
       [Clustered] = CAST( INDEXPROPERTY(si.id, si.Name, 'IsClustered') AS bit ),
       Keys = dbo.fnGetKeyColumnsOfIndex( so.Name, si.Name )

FROM sysindexes si
  INNER JOIN sysobjects so
  ON so.id = si.id

WHERE si.indid > 0 AND
      si.indid < 255 AND
      INDEXPROPERTY(si.id, si.Name, 'IsStatistics') = 0 AND
      INDEXPROPERTY(si.id, si.Name, 'IsHypothetical') = 0

GO
GRANT SELECT ON [dbo].[XViewIndex] TO [tools_access]