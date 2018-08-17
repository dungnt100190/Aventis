CREATE TABLE [dbo].[BaPLZ](
	[BaPLZID] [int] IDENTITY(1,1) NOT NULL,
	[PLZ] [int] NOT NULL,
	[PLZ6] [int] NULL,
	[PLZSuffix] [int] NULL,
	[Name] [varchar](100) NOT NULL,
	[NameTID] [int] NULL,
	[Kanton] [varchar](2) NOT NULL,
	[SortKey] [int] NOT NULL,
	[BFSCode] [int] NOT NULL,
  [ONRP] [int] NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[System] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[BaPLZTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaPLZ] PRIMARY KEY CLUSTERED 
(
	[BaPLZID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_BaPLZ] ON [dbo].[BaPLZ] 
(
	[PLZ] ASC,
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_BaPLZ_Name] ON [dbo].[BaPLZ] 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_BaPLZ_PLZ] ON [dbo].[BaPLZ] 
(
	[PLZ] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_BaPLZ_ONRP] ON [dbo].[BaPLZ] 
(
	[ONRP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO



EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für BaPLZ Records. Entspricht der ONRP von der Post.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPLZ', @level2type=N'COLUMN',@level2name=N'BaPLZID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die Ordnungsnummer Post ist der eindeutige, unveränderliche Schlüsselbegriff der Postleitzahl' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPLZ', @level2type=N'COLUMN',@level2name=N'ONRP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum ab welchem die PLZ gilt.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPLZ', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum bis welchem die PLZ gilt.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPLZ', @level2type=N'COLUMN',@level2name=N'DatumBis'
GO

ALTER TABLE [dbo].[BaPLZ] ADD  CONSTRAINT [DF_BaPLZ_System]  DEFAULT ((0)) FOR [System]
GO