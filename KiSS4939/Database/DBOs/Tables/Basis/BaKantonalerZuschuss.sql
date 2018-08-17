CREATE TABLE [dbo].[BaKantonalerZuschuss](
	[BaKantonalerZuschussID] [int] IDENTITY(1,1) NOT NULL,
	[Bezeichnung] [varchar](255) NOT NULL,
	[BezeichnungTID] [int] NULL,
	[KantonCode] [int] NOT NULL,
	[Aktiv] [bit] NOT NULL,
	[Bemerkungen] [varchar](2000) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[BaKantonalerZuschussTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaKantonalerZuschuss] PRIMARY KEY CLUSTERED 
(
	[BaKantonalerZuschussID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PrimaryKey, wird als ID benutzt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaKantonalerZuschuss', @level2type=N'COLUMN',@level2name=N'BaKantonalerZuschussID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bezeichnung des kantonalen Zuschusses' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaKantonalerZuschuss', @level2type=N'COLUMN',@level2name=N'Bezeichnung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Multilanguage-TID der Bezeichnung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaKantonalerZuschuss', @level2type=N'COLUMN',@level2name=N'BezeichnungTID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaKantonalerZuschuss', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaKantonalerZuschuss', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaKantonalerZuschuss', @level2type=N'COLUMN',@level2name=N'BaKantonalerZuschussTS'
GO

ALTER TABLE [dbo].[BaKantonalerZuschuss] ADD  CONSTRAINT [DF_BaKantonalerZuschuss_Aktiv]  DEFAULT ((0)) FOR [Aktiv]
GO

ALTER TABLE [dbo].[BaKantonalerZuschuss] ADD  CONSTRAINT [DF_BaKantonalerZuschuss_Created]  DEFAULT (getdate()) FOR [Created]
GO