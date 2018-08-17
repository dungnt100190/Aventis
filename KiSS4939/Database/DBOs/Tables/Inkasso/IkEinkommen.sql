CREATE TABLE [dbo].[IkEinkommen](
	[IkEinkommenID] [int] IDENTITY(1,1) NOT NULL,
	[IkRechtstitelID] [int] NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[IkEinkommenTypCode] [int] NOT NULL,
	[GueltigVon] [datetime] NOT NULL,
	[GueltigBis] [datetime] NULL,
	[Betrag] [money] NOT NULL,
	[Bemerkung] [varchar](max) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[IkEinkommenTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_IkEinkommen] PRIMARY KEY CLUSTERED 
(
	[IkEinkommenID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_IkEinkommen_BaPersonID]    Script Date: 09/19/2014 09:48:43 ******/
CREATE NONCLUSTERED INDEX [IX_IkEinkommen_BaPersonID] ON [dbo].[IkEinkommen] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_IkEinkommen_IkRechtstitelID]    Script Date: 09/19/2014 09:48:43 ******/
CREATE NONCLUSTERED INDEX [IX_IkEinkommen_IkRechtstitelID] ON [dbo].[IkEinkommen] 
(
	[IkRechtstitelID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel Ik Einkommen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkEinkommen', @level2type=N'COLUMN',@level2name=N'IkEinkommenID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_IkEinkommen_IkRechtstitelID) => IkRechtstitelID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkEinkommen', @level2type=N'COLUMN',@level2name=N'IkRechtstitelID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BaPersonID eines Gläubigers' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkEinkommen', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code des Einkommentyps (LOV IkEinkommenTyp), wird mit Value3 in 3 DropDown gesplitet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkEinkommen', @level2type=N'COLUMN',@level2name=N'IkEinkommenTypCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Anfangsdatum der Leistung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkEinkommen', @level2type=N'COLUMN',@level2name=N'GueltigVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Enddatum der Leistung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkEinkommen', @level2type=N'COLUMN',@level2name=N'GueltigBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkEinkommen', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkEinkommen', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkEinkommen', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkEinkommen', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkEinkommen', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkEinkommen', @level2type=N'COLUMN',@level2name=N'IkEinkommenTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Raphael Jacober' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkEinkommen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ik Einkommen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkEinkommen'
GO

ALTER TABLE [dbo].[IkEinkommen]  WITH CHECK ADD  CONSTRAINT [FK_IkEinkommen_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[IkEinkommen] CHECK CONSTRAINT [FK_IkEinkommen_BaPerson]
GO

ALTER TABLE [dbo].[IkEinkommen]  WITH CHECK ADD  CONSTRAINT [FK_IkEinkommen_IkRechtstitel] FOREIGN KEY([IkRechtstitelID])
REFERENCES [dbo].[IkRechtstitel] ([IkRechtstitelID])
GO

ALTER TABLE [dbo].[IkEinkommen] CHECK CONSTRAINT [FK_IkEinkommen_IkRechtstitel]
GO

ALTER TABLE [dbo].[IkEinkommen] ADD  CONSTRAINT [DF_IkEinkommen_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[IkEinkommen] ADD  CONSTRAINT [DF_IkEinkommen_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


