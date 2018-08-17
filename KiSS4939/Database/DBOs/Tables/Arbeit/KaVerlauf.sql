CREATE TABLE [dbo].[KaVerlauf](
	[KaVerlaufID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[UserID] [int] NULL,
	[Datum] [datetime] NULL,
	[KaAllgemKontaktartCode] [int] NULL,
	[Kontaktperson] [varchar](255) NULL,
	[Stichwort] [varchar](255) NULL,
	[KaAllgemThemaCodes] [varchar](255) NULL,
	[InhaltRTF] [varchar](max) NULL,

	[SichtbarSDFlag] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KaVerlaufTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaVerlauf] PRIMARY KEY CLUSTERED 
(
	[KaVerlaufID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_KaVerlauf_FaLeistungID]    Script Date: 01/29/2014 09:24:48 ******/
CREATE NONCLUSTERED INDEX [IX_KaVerlauf_FaLeistungID] ON [dbo].[KaVerlauf] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


/****** Object:  Index [IX_KaVerlauf_UserID]    Script Date: 01/29/2014 09:24:48 ******/
CREATE NONCLUSTERED INDEX [IX_KaVerlauf_UserID] ON [dbo].[KaVerlauf] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVerlauf', @level2type=N'COLUMN',@level2name=N'KaVerlaufID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaVermittlungBIBIP_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVerlauf', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVerlauf', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVerlauf', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVerlauf', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVerlauf', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVerlauf', @level2type=N'COLUMN',@level2name=N'KaVerlaufTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Lucas Loreggia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVerlauf'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabelle für Maske KA Allgemein - Verlauf' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVerlauf'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Arbeit' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVerlauf'
GO

ALTER TABLE [dbo].[KaVerlauf]  WITH CHECK ADD  CONSTRAINT [FK_KaVerlauf_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KaVerlauf] CHECK CONSTRAINT [FK_KaVerlauf_FaLeistung]
GO

ALTER TABLE [dbo].[KaVerlauf]  WITH CHECK ADD  CONSTRAINT [FK_KaVerlauf_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[KaVerlauf] CHECK CONSTRAINT [FK_KaVerlauf_XUser]
GO

ALTER TABLE [dbo].[KaVerlauf] ADD  CONSTRAINT [DF_KaVerlauf_SichtbarSDFlag]  DEFAULT ((0)) FOR [SichtbarSDFlag]
GO

ALTER TABLE [dbo].[KaVerlauf] ADD  CONSTRAINT [DF_KaVerlauf_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KaVerlauf] ADD  CONSTRAINT [DF_KaVerlauf_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


