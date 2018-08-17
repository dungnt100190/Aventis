CREATE TABLE [dbo].[BgPositionsart](
	[BgPositionsartID] [int] IDENTITY(101,1) NOT NULL,
	[BgKategorieCode] [int] NOT NULL,
	[BgGruppeCode] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[HilfeText] [varchar](max) NULL,
	[SortKey] [int] NOT NULL,
	[BgKostenartID] [int] NULL,
	[NrmKontoCode] [int] NULL,
	[VerwaltungSD_Default] [bit] NULL,
	[Spezkonto] [bit] NOT NULL,
	[ProPerson] [bit] NOT NULL,
	[ProUE] [bit] NOT NULL,
	[Masterbudget_EditMask] [int] NOT NULL,
	[Monatsbudget_EditMask] [int] NOT NULL,
	[ModulID] [int] NOT NULL,
	[sqlRichtlinie] [varchar](3000) NULL,
	[BgPositionsartTS] [timestamp] NOT NULL,
	[VarName] [varchar](50) NULL,
	[Verrechenbar] [bit] NOT NULL,
	[ErzeugtBfsDossier] [bit] NOT NULL,
	[Bemerkung] [varchar](max) NULL,
	[NameTID] [int] NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[BgPositionsartCode] [int] NULL,
	[BgPositionsartID_CopyOf] [int] NULL,
	[System] [bit] NOT NULL,
	[KreditorEingeschraenkt] [bit] NOT NULL,
 CONSTRAINT [PK_BgPositionsart] PRIMARY KEY CLUSTERED 
(
	[BgPositionsartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_BgPositionsart_BgKostenartID] ON [dbo].[BgPositionsart] 
(
	[BgKostenartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


CREATE UNIQUE NONCLUSTERED INDEX [IX_BgPositionsart_BgPositionsartIDBgKategorieCode_Unique] ON [dbo].[BgPositionsart] 
(
	[BgPositionsartID] ASC,
	[BgKategorieCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


CREATE NONCLUSTERED INDEX [IX_BgPositionsart_ModulID] ON [dbo].[BgPositionsart] 
(
	[ModulID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_ShPositionTyp_BgKostenart) => BgKostenart.BgKostenartID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPositionsart', @level2type=N'COLUMN',@level2name=N'BgKostenartID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgPositionsart_XModul) => XModul.ModulID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPositionsart', @level2type=N'COLUMN',@level2name=N'ModulID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beginn der Gültigkeit der Positionsart' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPositionsart', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ende der Gültigkeit der Positionsart' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPositionsart', @level2type=N'COLUMN',@level2name=N'DatumBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifikationsnummer einer Positionsart, die für terminierte Positionsarten und ihre Nachfolge-Positionsarten identisch ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPositionsart', @level2type=N'COLUMN',@level2name=N'BgPositionsartCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel einer Nachfolge-Positionsart auf ihre terminierte Vorgänger-Positionsart' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPositionsart', @level2type=N'COLUMN',@level2name=N'BgPositionsartID_CopyOf'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sagt aus, ob die Positionsart vom System vorgegeben oder kundenspezifisch ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPositionsart', @level2type=N'COLUMN',@level2name=N'System'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die Auswahl des Kreditors beschränkt sich auf die Zahlungsverbindungen im Klientensystem (Personen + Institutionen) sowie auf die Instititution des Spezialkontos bei einer Einzelzahlung ab Spezialkonto mit konfigurierter Institution die Institution des Spezialkontos.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPositionsart', @level2type=N'COLUMN',@level2name=N'KreditorEingeschraenkt'
GO

ALTER TABLE [dbo].[BgPositionsart]  WITH CHECK ADD  CONSTRAINT [FK_BgPositionsart_BgKostenart] FOREIGN KEY([BgKostenartID])
REFERENCES [dbo].[BgKostenart] ([BgKostenartID])
GO

ALTER TABLE [dbo].[BgPositionsart] CHECK CONSTRAINT [FK_BgPositionsart_BgKostenart]
GO

ALTER TABLE [dbo].[BgPositionsart]  WITH CHECK ADD  CONSTRAINT [FK_BgPositionsart_XModul] FOREIGN KEY([ModulID])
REFERENCES [dbo].[XModul] ([ModulID])
GO

ALTER TABLE [dbo].[BgPositionsart] CHECK CONSTRAINT [FK_BgPositionsart_XModul]
GO

ALTER TABLE [dbo].[BgPositionsart] ADD  CONSTRAINT [DF_BgPositionsart_Spezkonto]  DEFAULT ((0)) FOR [Spezkonto]
GO

ALTER TABLE [dbo].[BgPositionsart] ADD  CONSTRAINT [DF_BgPositionsart_ProPerson]  DEFAULT ((0)) FOR [ProPerson]
GO

ALTER TABLE [dbo].[BgPositionsart] ADD  CONSTRAINT [DF_BgPositionsart_ProUE]  DEFAULT ((0)) FOR [ProUE]
GO

ALTER TABLE [dbo].[BgPositionsart] ADD  CONSTRAINT [DF_BgPositionsart_Masterbudget_EditMask]  DEFAULT ((16773120)) FOR [Masterbudget_EditMask]
GO

ALTER TABLE [dbo].[BgPositionsart] ADD  CONSTRAINT [DF_BgPositionsart_Monatsbudget_EditMask]  DEFAULT ((4095)) FOR [Monatsbudget_EditMask]
GO

ALTER TABLE [dbo].[BgPositionsart] ADD  CONSTRAINT [DF_BgPositionsart_ModulID]  DEFAULT ((3)) FOR [ModulID]
GO

ALTER TABLE [dbo].[BgPositionsart] ADD  CONSTRAINT [DF_BgPositionsart_Verrechenbar]  DEFAULT ((1)) FOR [Verrechenbar]
GO

ALTER TABLE [dbo].[BgPositionsart] ADD  CONSTRAINT [DF_BgPositionsart_ErzeugtBfsDossier]  DEFAULT ((0)) FOR [ErzeugtBfsDossier]
GO

ALTER TABLE [dbo].[BgPositionsart] ADD  CONSTRAINT [DF_BgPositionsart_System]  DEFAULT ((0)) FOR [System]
GO

ALTER TABLE [dbo].[BgPositionsart] ADD  CONSTRAINT [DF_BgPositionsart_KreditorEingeschraenkt]  DEFAULT ((0)) FOR [KreditorEingeschraenkt]
GO