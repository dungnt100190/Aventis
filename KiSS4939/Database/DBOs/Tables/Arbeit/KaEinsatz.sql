CREATE TABLE [dbo].[KaEinsatz](
	[KaEinsatzID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[KaEinsatzplatzID] [int] NOT NULL,
	[FaLeistungID] [int] NULL,
	[AnweisungCode] [int] NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NOT NULL,
	[SamstagAktiv] [bit] NOT NULL,
	[SonntagAktiv] [bit] NOT NULL,
	[BeschGrad] [int] NULL,
	[APVZusatzCode] [int] NULL,
	[PersonenNr] [int] NULL,
	[RahmenfristBis] [datetime] NULL,
	[ALKasseID] [int] NULL,
	[ZuweiserID] [int] NULL,
	[SichtbarSDFlag] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KaEinsatzTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaEinsatz] PRIMARY KEY CLUSTERED 
(
	[KaEinsatzID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

CREATE NONCLUSTERED INDEX [IX_KaEinsatz_BaPersonID] ON [dbo].[KaEinsatz] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

CREATE NONCLUSTERED INDEX [IX_KaEinsatz_FaLeistungID] ON [dbo].[KaEinsatz] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

CREATE NONCLUSTERED INDEX [IX_KaEinsatz_KaEinsatzplatzID] ON [dbo].[KaEinsatz] 
(
	[KaEinsatzplatzID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KaEinsatz Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEinsatz', @level2type=N'COLUMN',@level2name=N'KaEinsatzID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf die methodische Leistung.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEinsatz', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Definition ob der Einsatz an Samstagen erlaubt ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEinsatz', @level2type=N'COLUMN',@level2name=N'SamstagAktiv'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Definition ob der Einsatz an Sonntagen erlaubt ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEinsatz', @level2type=N'COLUMN',@level2name=N'SonntagAktiv'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEinsatz', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEinsatz', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEinsatz', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaEinsatz', @level2type=N'COLUMN',@level2name=N'Modified'
GO

ALTER TABLE [dbo].[KaEinsatz]  WITH CHECK ADD  CONSTRAINT [FK_KaEinsatz_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[KaEinsatz] CHECK CONSTRAINT [FK_KaEinsatz_BaPerson]
GO

ALTER TABLE [dbo].[KaEinsatz]  WITH CHECK ADD  CONSTRAINT [FK_KaEinsatz_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KaEinsatz] CHECK CONSTRAINT [FK_KaEinsatz_FaLeistung]
GO

ALTER TABLE [dbo].[KaEinsatz]  WITH CHECK ADD  CONSTRAINT [FK_KaEinsatz_KaEinsatzplatz2] FOREIGN KEY([KaEinsatzplatzID])
REFERENCES [dbo].[KaEinsatzplatz2] ([KaEinsatzplatzID])
GO

ALTER TABLE [dbo].[KaEinsatz] CHECK CONSTRAINT [FK_KaEinsatz_KaEinsatzplatz2]
GO

ALTER TABLE [dbo].[KaEinsatz] ADD  CONSTRAINT [DF_KaEinsatz_SamstagAktiv]  DEFAULT ((0)) FOR [SamstagAktiv]
GO

ALTER TABLE [dbo].[KaEinsatz] ADD  CONSTRAINT [DF_KaEinsatz_SonntagAktiv]  DEFAULT ((0)) FOR [SonntagAktiv]
GO

ALTER TABLE [dbo].[KaEinsatz] ADD  CONSTRAINT [DF_KaEinsatz_SichtbarSDFlag]  DEFAULT ((0)) FOR [SichtbarSDFlag]
GO

ALTER TABLE [dbo].[KaEinsatz] ADD  CONSTRAINT [DF_KaEinsatz_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KaEinsatz] ADD  CONSTRAINT [DF_KaEinsatz_Modified]  DEFAULT (getdate()) FOR [Modified]
GO
