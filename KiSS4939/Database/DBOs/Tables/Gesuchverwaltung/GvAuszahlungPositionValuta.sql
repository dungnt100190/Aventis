CREATE TABLE [dbo].[GvAuszahlungPositionValuta](
	[GvAuszahlungPositionValutaID] [int] IDENTITY(1,1) NOT NULL,
	[GvAuszahlungPositionID] [int] NOT NULL,
	[Datum] [datetime] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[GvAuszahlungPositionValutaTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_GvAuszahlungPositionValuta] PRIMARY KEY CLUSTERED 
(
	[GvAuszahlungPositionValutaID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_GvAuszahlungPositionValuta_GvAuszahlungPositionID]    Script Date: 06/20/2012 10:14:08 ******/
CREATE NONCLUSTERED INDEX [IX_GvAuszahlungPositionValuta_GvAuszahlungPositionID] ON [dbo].[GvAuszahlungPositionValuta] 
(
	[GvAuszahlungPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für GvAuszahlungPositionValuta Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPositionValuta', @level2type=N'COLUMN',@level2name=N'GvAuszahlungPositionValutaID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_GvAuszahlungPositionValuta_GvAuszahlungPosition) => GvAuszahlungPositionID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPositionValuta', @level2type=N'COLUMN',@level2name=N'GvAuszahlungPositionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPositionValuta', @level2type=N'COLUMN',@level2name=N'Datum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPositionValuta', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPositionValuta', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPositionValuta', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPositionValuta', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPositionValuta', @level2type=N'COLUMN',@level2name=N'GvAuszahlungPositionValutaTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Peter Salajan' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPositionValuta'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet die Informationen zu den einzelnen Valuta-Auszahlungspositionen in der Gesuchverwaltung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAuszahlungPositionValuta'
GO

ALTER TABLE [dbo].[GvAuszahlungPositionValuta]  WITH CHECK ADD  CONSTRAINT [FK_GvAuszahlungPositionValuta_GvAuszahlungPosition] FOREIGN KEY([GvAuszahlungPositionID])
REFERENCES [dbo].[GvAuszahlungPosition] ([GvAuszahlungPositionID])
GO

ALTER TABLE [dbo].[GvAuszahlungPositionValuta] CHECK CONSTRAINT [FK_GvAuszahlungPositionValuta_GvAuszahlungPosition]
GO

ALTER TABLE [dbo].[GvAuszahlungPositionValuta] ADD  CONSTRAINT [DF_GvAuszahlungPositionValuta_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[GvAuszahlungPositionValuta] ADD  CONSTRAINT [DF_GvAuszahlungPositionValuta_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


