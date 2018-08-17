CREATE TABLE [dbo].[GvAbklaerendeStelle](
	[GvAbklaerendeStelleID] [int] IDENTITY(1,1) NOT NULL,
	[GvGesuchID] [int] NOT NULL,
	[BaZahlungswegID] [int] NULL,
	[BeantragendeStelle] [varchar](200) NULL,
	[Kontaktperson] [varchar](200) NULL,
	[Strasse] [varchar](200) NULL,
	[HausNr] [varchar](10) NULL,
	[Zusatz] [varchar](200) NULL,
	[PLZ] [varchar](10) NULL,
	[Ort] [varchar](50) NULL,
	[Kanton] [varchar](10) NULL,
	[Postfach] [varchar](100) NULL,
	[PostfachOhneNr] [bit] NOT NULL,
	[Region] [varchar](100) NULL,
	[Telefon] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
	[Bemerkungen] [varchar](max) NULL,
	[MitteilungZeile1] [varchar](35) NULL,
	[MitteilungZeile2] [varchar](35) NULL,
	[MitteilungZeile3] [varchar](35) NULL,
	[MitteilungZeile4] [varchar](35) NULL,
	[Zahlungsinstruktion] [varchar](max) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[GvAbklaerendeStelleTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_GvAbklaerendeStelle] PRIMARY KEY CLUSTERED 
(
	[GvAbklaerendeStelleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_GvAbklaerendeStelle_BaZahlungswegID]    Script Date: 11/12/2012 14:36:39 ******/
CREATE NONCLUSTERED INDEX [IX_GvAbklaerendeStelle_BaZahlungswegID] ON [dbo].[GvAbklaerendeStelle] 
(
	[BaZahlungswegID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_GvAbklaerendeStelle_GvGesuchID]    Script Date: 11/12/2012 14:36:39 ******/
CREATE NONCLUSTERED INDEX [IX_GvAbklaerendeStelle_GvGesuchID] ON [dbo].[GvAbklaerendeStelle] 
(
	[GvGesuchID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für GvAbklaerendeStelle Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAbklaerendeStelle', @level2type=N'COLUMN',@level2name=N'GvAbklaerendeStelleID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_GvAbklaerendeStelle_GvGesuch) => GvGesuchID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAbklaerendeStelle', @level2type=N'COLUMN',@level2name=N'GvGesuchID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_GvAbklaerendeStelle_BaZahlungsweg) => BaZahlungswegID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAbklaerendeStelle', @level2type=N'COLUMN',@level2name=N'BaZahlungswegID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAbklaerendeStelle', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAbklaerendeStelle', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAbklaerendeStelle', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAbklaerendeStelle', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAbklaerendeStelle', @level2type=N'COLUMN',@level2name=N'GvAbklaerendeStelleTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Lucas Loreggia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAbklaerendeStelle'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet zusätzliche Informationen eines Gesuchs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvAbklaerendeStelle'
GO

ALTER TABLE [dbo].[GvAbklaerendeStelle]  WITH CHECK ADD  CONSTRAINT [FK_GvAbklaerendeStelle_BaZahlungsweg] FOREIGN KEY([BaZahlungswegID])
REFERENCES [dbo].[BaZahlungsweg] ([BaZahlungswegID])
GO

ALTER TABLE [dbo].[GvAbklaerendeStelle] CHECK CONSTRAINT [FK_GvAbklaerendeStelle_BaZahlungsweg]
GO

ALTER TABLE [dbo].[GvAbklaerendeStelle]  WITH CHECK ADD  CONSTRAINT [FK_GvAbklaerendeStelle_GvGesuch] FOREIGN KEY([GvGesuchID])
REFERENCES [dbo].[GvGesuch] ([GvGesuchID])
GO

ALTER TABLE [dbo].[GvAbklaerendeStelle] CHECK CONSTRAINT [FK_GvAbklaerendeStelle_GvGesuch]
GO

ALTER TABLE [dbo].[GvAbklaerendeStelle] ADD  CONSTRAINT [DF_GvAbklaerendeStelle_PostfachOhneNr]  DEFAULT ((0)) FOR [PostfachOhneNr]
GO

ALTER TABLE [dbo].[GvAbklaerendeStelle] ADD  CONSTRAINT [DF_GvAbklaerendeStelle_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[GvAbklaerendeStelle] ADD  CONSTRAINT [DF_GvAbklaerendeStelle_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

