CREATE TABLE [dbo].[GvAntragPosition](
	[GvAntragPositionID] [int] IDENTITY(1,1) NOT NULL,
	[GvGesuchID] [int] NOT NULL,
	[GvAntragPositionTypCode] [int] NOT NULL,
	[Bezeichnung] [varchar](max) NOT NULL,
	[Betrag] [money] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[GvAntragPositionTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_GvAntragPosition] PRIMARY KEY CLUSTERED 
(
	[GvAntragPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_GvAntragPosition_GvGesuchID]    Script Date: 05/30/2012 15:27:17 ******/
CREATE NONCLUSTERED INDEX [IX_GvAntragPosition_GvGesuchID] ON [dbo].[GvAntragPosition] 
(
	[GvGesuchID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für GvAntragPosition Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAntragPosition', @level2type=N'COLUMN',@level2name=N'GvAntragPositionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_GvAntragPosition_GvGesuch) => GvGesuchID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAntragPosition', @level2type=N'COLUMN',@level2name=N'GvGesuchID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV GvAntragPositionTyp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAntragPosition', @level2type=N'COLUMN',@level2name=N'GvAntragPositionTypCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet Text in "Kostenbezeichnung" bzw. "Quelle"' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAntragPosition', @level2type=N'COLUMN',@level2name=N'Bezeichnung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betrag der Position' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAntragPosition', @level2type=N'COLUMN',@level2name=N'Betrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAntragPosition', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAntragPosition', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAntragPosition', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAntragPosition', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAntragPosition', @level2type=N'COLUMN',@level2name=N'GvAntragPositionTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Peter Salajan' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAntragPosition'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet die Informationen zu den einzelnen Positionen eines Antrags in der Gesuchverwaltung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAntragPosition'
GO

ALTER TABLE [dbo].[GvAntragPosition]  WITH CHECK ADD  CONSTRAINT [FK_GvAntragPosition_GvGesuch] FOREIGN KEY([GvGesuchID])
REFERENCES [dbo].[GvGesuch] ([GvGesuchID])
GO

ALTER TABLE [dbo].[GvAntragPosition] CHECK CONSTRAINT [FK_GvAntragPosition_GvGesuch]
GO

ALTER TABLE [dbo].[GvAntragPosition] ADD  CONSTRAINT [DF_GvAntragPosition_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[GvAntragPosition] ADD  CONSTRAINT [DF_GvAntragPosition_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


