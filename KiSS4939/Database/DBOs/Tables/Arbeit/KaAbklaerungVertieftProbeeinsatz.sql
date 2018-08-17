CREATE TABLE [dbo].[KaAbklaerungVertieftProbeeinsatz](
	[KaAbklaerungVertieftProbeeinsatzID] [int] IDENTITY(1,1) NOT NULL,
	[KaAbklaerungVertieftID] [int] NOT NULL,
	[Datum] [datetime] NULL,
	[KaAbklaerungProzessschrittCode] [int] NULL,
	[DocumentID_Prozessschritt] [int] NULL,
	[HatStattgefunden] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KaAbklaerungVertieftProbeeinsatzTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaAbklaerungVertieftProbeeinsatz] PRIMARY KEY CLUSTERED 
(
	[KaAbklaerungVertieftProbeeinsatzID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_KaAbklaerungVertieftProbeeinsatz_KaAbklaerungVertieftID]    Script Date: 01/14/2014 13:26:17 ******/
CREATE NONCLUSTERED INDEX [IX_KaAbklaerungVertieftProbeeinsatz_KaAbklaerungVertieftID] ON [dbo].[KaAbklaerungVertieftProbeeinsatz] 
(
	[KaAbklaerungVertieftID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle KaAbklaerungVertieftProbeeinsatz' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieftProbeeinsatz', @level2type=N'COLUMN',@level2name=N'KaAbklaerungVertieftProbeeinsatzID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zur Tabelle KaAbklaerungVertieft' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieftProbeeinsatz', @level2type=N'COLUMN',@level2name=N'KaAbklaerungVertieftID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum des Probeeinsatzes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieftProbeeinsatz', @level2type=N'COLUMN',@level2name=N'Datum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Prozessschritt, gehört zum Probeeinsatz' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieftProbeeinsatz', @level2type=N'COLUMN',@level2name=N'KaAbklaerungProzessschrittCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dokument des Probeeinsatzes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieftProbeeinsatz', @level2type=N'COLUMN',@level2name=N'DocumentID_Prozessschritt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ob der Probeeinsatz stattgefunden hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieftProbeeinsatz', @level2type=N'COLUMN',@level2name=N'HatStattgefunden'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieftProbeeinsatz', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieftProbeeinsatz', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieftProbeeinsatz', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieftProbeeinsatz', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieftProbeeinsatz', @level2type=N'COLUMN',@level2name=N'KaAbklaerungVertieftProbeeinsatzTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Corinne Meuwly' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieftProbeeinsatz'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'KA - Abklärung - Vertiefte Abklärungen - Probeeinsatz' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungVertieftProbeeinsatz'
GO

ALTER TABLE [dbo].[KaAbklaerungVertieftProbeeinsatz]  WITH CHECK ADD  CONSTRAINT [FK_KaAbklaerungVertieftProbeeinsatz_KaAbklaerungVertieft] FOREIGN KEY([KaAbklaerungVertieftID])
REFERENCES [dbo].[KaAbklaerungVertieft] ([KaAbklaerungVertieftID])
GO

ALTER TABLE [dbo].[KaAbklaerungVertieftProbeeinsatz] CHECK CONSTRAINT [FK_KaAbklaerungVertieftProbeeinsatz_KaAbklaerungVertieft]
GO

ALTER TABLE [dbo].[KaAbklaerungVertieftProbeeinsatz] ADD  CONSTRAINT [DF_KaAbklaerungVertieftProbeeinsatz_HatStattgefunden]  DEFAULT ((0)) FOR [HatStattgefunden]
GO

ALTER TABLE [dbo].[KaAbklaerungVertieftProbeeinsatz] ADD  CONSTRAINT [DF_KaAbklaerungVertieftProbeeinsatz_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KaAbklaerungVertieftProbeeinsatz] ADD  CONSTRAINT [DF_KaAbklaerungVertieftProbeeinsatz_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


