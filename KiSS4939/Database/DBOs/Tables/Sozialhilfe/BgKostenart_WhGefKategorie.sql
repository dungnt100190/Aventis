SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BgKostenart_WhGefKategorie](
	[BgKostenart_WhGefKategorieID] [int] IDENTITY(1,1) NOT NULL,
	[BgKostenartID] [int] NOT NULL,
	[WhGefKategorieID] [int] NOT NULL,
	[IsInkassoprovision] [bit] NOT NULL CONSTRAINT [DF_BgKostenart_WhGefKategorie_IsInkassoprovision]  DEFAULT ((0)),
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL CONSTRAINT [DF_BgKostenart_WhGefKategorie_Created]  DEFAULT (getdate()),
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL CONSTRAINT [DF_BgKostenart_WhGefKategorie_Modified]  DEFAULT (getdate()),
	[BgKostenart_WhGefKategorieTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BgKostenart_WhGefKategorie] PRIMARY KEY CLUSTERED 
(
	[BgKostenart_WhGefKategorieID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_BgKostenart_WhGefKategorie_BgKostenartID] ON [dbo].[BgKostenart_WhGefKategorie] 
(
	[BgKostenartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_BgKostenart_WhGefKategorie_WhGefKategorieID] ON [dbo].[BgKostenart_WhGefKategorie] 
(
	[WhGefKategorieID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel dieser Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgKostenart_WhGefKategorie', @level2type=N'COLUMN',@level2name=N'BgKostenart_WhGefKategorieID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf der Tabelle BgKostenart' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgKostenart_WhGefKategorie', @level2type=N'COLUMN',@level2name=N'BgKostenartID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf der Tabelle WhGefKategorie' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgKostenart_WhGefKategorie', @level2type=N'COLUMN',@level2name=N'WhGefKategorieID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zum wissen ob die Kostenart eine Inkassoprovision ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgKostenart_WhGefKategorie', @level2type=N'COLUMN',@level2name=N'IsInkassoprovision'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgKostenart_WhGefKategorie', @level2type=N'COLUMN',@level2name=N'Creator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgKostenart_WhGefKategorie', @level2type=N'COLUMN',@level2name=N'Created'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgKostenart_WhGefKategorie', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgKostenart_WhGefKategorie', @level2type=N'COLUMN',@level2name=N'Modified'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgKostenart_WhGefKategorie', @level2type=N'COLUMN',@level2name=N'BgKostenart_WhGefKategorieTS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mapping Tabelle zwischen Kostenarten und GEF-Gruppen. Dies ist für die Differenzierung der Sozialhilferechnung relevant' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgKostenart_WhGefKategorie'
GO
ALTER TABLE [dbo].[BgKostenart_WhGefKategorie]  WITH CHECK ADD  CONSTRAINT [FK_BgKostenart_WhGefKategorie_BgKostenart] FOREIGN KEY([BgKostenartID])
REFERENCES [dbo].[BgKostenart] ([BgKostenartID])
GO
ALTER TABLE [dbo].[BgKostenart_WhGefKategorie] CHECK CONSTRAINT [FK_BgKostenart_WhGefKategorie_BgKostenart]
GO
ALTER TABLE [dbo].[BgKostenart_WhGefKategorie]  WITH CHECK ADD  CONSTRAINT [FK_BgKostenart_WhGefKategorie_WhGefKategorie] FOREIGN KEY([WhGefKategorieID])
REFERENCES [dbo].[WhGefKategorie] ([WhGefKategorieID])
GO
ALTER TABLE [dbo].[BgKostenart_WhGefKategorie] CHECK CONSTRAINT [FK_BgKostenart_WhGefKategorie_WhGefKategorie]
