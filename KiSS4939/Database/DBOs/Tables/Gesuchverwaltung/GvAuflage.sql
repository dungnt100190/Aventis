CREATE TABLE [dbo].[GvAuflage](
	[GvAuflageID] [int] IDENTITY(1,1) NOT NULL,
	[GvGesuchID] [int] NOT NULL,
	[GvAuflageTypCode] [int] NOT NULL,
	[Erfasst] [datetime] NOT NULL,
	[Gegenstand] [varchar](200) NOT NULL,
	[Betrag] [money] NULL,
	[Faellig] [datetime] NOT NULL,
	[SchriftlicheVerpflichtung] [bit] NOT NULL,
	[Erledigt] [bit] NOT NULL,
	[Erlassen] [bit] NOT NULL,
	[Bemerkung] [varchar](max) NULL,
	[Erlassungsgrund] [varchar](max) NULL,
	[Rate1Betrag] [money] NULL,
	[Rate1Datum] [datetime] NULL,
	[Rate2Betrag] [money] NULL,
	[Rate2Datum] [datetime] NULL,
	[Rate3Betrag] [money] NULL,
	[Rate3Datum] [datetime] NULL,
	[Rate4Betrag] [money] NULL,
	[Rate4Datum] [datetime] NULL,
	[Rate5Betrag] [money] NULL,
	[Rate5Datum] [datetime] NULL,
	[Rate6Betrag] [money] NULL,
	[Rate6Datum] [datetime] NULL,
	[Rate7Betrag] [money] NULL,
	[Rate7Datum] [datetime] NULL,
	[Rate8Betrag] [money] NULL,
	[Rate8Datum] [datetime] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[GvAuflageTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_GvAuflage] PRIMARY KEY CLUSTERED 
(
	[GvAuflageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_GvAuflage_GvGesuchID]    Script Date: 06/14/2012 17:43:55 ******/
CREATE NONCLUSTERED INDEX [IX_GvAuflage_GvGesuchID] ON [dbo].[GvAuflage] 
(
	[GvGesuchID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für GvAuflage Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuflage', @level2type=N'COLUMN',@level2name=N'GvAuflageID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_GvAuflage_GvGesuch) => GvGesuchID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuflage', @level2type=N'COLUMN',@level2name=N'GvGesuchID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV GvAuflageTyp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuflage', @level2type=N'COLUMN',@level2name=N'GvAuflageTypCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum der Erfassung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuflage', @level2type=N'COLUMN',@level2name=N'Erfasst'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Gegenstand der Auflage' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuflage', @level2type=N'COLUMN',@level2name=N'Gegenstand'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betrag der Auflage' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuflage', @level2type=N'COLUMN',@level2name=N'Betrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum der Faelligkeit' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuflage', @level2type=N'COLUMN',@level2name=N'Faellig'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Gibt an, ob es sich um eine schriftliche Verpflichtung handelt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuflage', @level2type=N'COLUMN',@level2name=N'SchriftlicheVerpflichtung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Gibt an, ob die Auflage erledigt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuflage', @level2type=N'COLUMN',@level2name=N'Erledigt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Gibt an, ob die Auflage erlassen wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuflage', @level2type=N'COLUMN',@level2name=N'Erlassen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuflage', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuflage', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuflage', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuflage', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuflage', @level2type=N'COLUMN',@level2name=N'GvAuflageTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Peter Salajan' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuflage'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet die Auflagen-Informationen zu einem Gesuch' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuflage'
GO

ALTER TABLE [dbo].[GvAuflage]  WITH CHECK ADD  CONSTRAINT [FK_GvAuflage_GvGesuch] FOREIGN KEY([GvGesuchID])
REFERENCES [dbo].[GvGesuch] ([GvGesuchID])
GO

ALTER TABLE [dbo].[GvAuflage] CHECK CONSTRAINT [FK_GvAuflage_GvGesuch]
GO

ALTER TABLE [dbo].[GvAuflage] ADD  CONSTRAINT [DF_GvAuflage_Erfasst]  DEFAULT (getdate()) FOR [Erfasst]
GO

ALTER TABLE [dbo].[GvAuflage] ADD  CONSTRAINT [DF_GvAuflage_SchriftlicheVerpflichtung]  DEFAULT ((0)) FOR [SchriftlicheVerpflichtung]
GO

ALTER TABLE [dbo].[GvAuflage] ADD  CONSTRAINT [DF_GvAuflage_Erledigt]  DEFAULT ((0)) FOR [Erledigt]
GO

ALTER TABLE [dbo].[GvAuflage] ADD  CONSTRAINT [DF_GvAuflage_Erlassen]  DEFAULT ((0)) FOR [Erlassen]
GO

ALTER TABLE [dbo].[GvAuflage] ADD  CONSTRAINT [DF_GvAuflage_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[GvAuflage] ADD  CONSTRAINT [DF_GvAuflage_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

