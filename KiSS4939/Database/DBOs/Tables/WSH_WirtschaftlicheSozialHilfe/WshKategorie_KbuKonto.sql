CREATE TABLE [dbo].[WshKategorie_KbuKonto](
	[WshKategorie_KbuKontoID] [int] IDENTITY(1,1) NOT NULL,
	[WshKategorieID] [int] NOT NULL,
	[KbuKontoID] [int] NOT NULL,
	[NurMitSpezialrecht] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[WshKategorie_KbuKontoTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_WshKategorie_KbuKonto] PRIMARY KEY CLUSTERED 
(
	[WshKategorie_KbuKontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [Uk_WshKategorie_KbuKonto_WshKategorieID_KbuKontoID] UNIQUE NONCLUSTERED 
(
	[WshKategorieID] ASC,
	[KbuKontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_WshKategorie_KbuKonto_KbuKontoID]    Script Date: 08/30/2011 09:46:47 ******/
CREATE NONCLUSTERED INDEX [IX_WshKategorie_KbuKonto_KbuKontoID] ON [dbo].[WshKategorie_KbuKonto] 
(
	[KbuKontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_WshKategorie_KbuKonto_WshKategorieID]    Script Date: 08/30/2011 09:46:47 ******/
CREATE NONCLUSTERED INDEX [IX_WshKategorie_KbuKonto_WshKategorieID] ON [dbo].[WshKategorie_KbuKonto] 
(
	[WshKategorieID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKategorie_KbuKonto', @level2type=N'COLUMN',@level2name=N'WshKategorie_KbuKontoID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (WshKategorie_KbuKonto => KbuKonto)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKategorie_KbuKonto', @level2type=N'COLUMN',@level2name=N'KbuKontoID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (WshKategorie_KbuKonto => WshKategorie)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKategorie_KbuKonto', @level2type=N'COLUMN',@level2name=N'WshKategorieID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wenn true, dann kann die KOA in einem Budget für eine Kategorie nur mit Spezialrecht "Multifunktionales Vorzeichen" ausgewählt werden.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKategorie_KbuKonto', @level2type=N'COLUMN',@level2name=N'NurMitSpezialrecht'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz erstellt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKategorie_KbuKonto', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKategorie_KbuKonto', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz zuletzt geändert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKategorie_KbuKonto', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKategorie_KbuKonto', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKategorie_KbuKonto', @level2type=N'COLUMN',@level2name=N'WshKategorie_KbuKontoTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Claude Glauser' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKategorie_KbuKonto'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ManyToMany Verbindungstabelle zwischen KbuKonto und WshKategorie. ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKategorie_KbuKonto'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'Wenn kein Eintrag vorhanden ist, dann kann in einem Budget für die entsprechende Kategorie diese KOA nicht ausgewählt werden. ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKategorie_KbuKonto'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Wsh und Kbu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKategorie_KbuKonto'
GO

ALTER TABLE [dbo].[WshKategorie_KbuKonto]  WITH CHECK ADD  CONSTRAINT [FK_WshKategorie_KbuKonto_KbuKonto] FOREIGN KEY([KbuKontoID])
REFERENCES [dbo].[KbuKonto] ([KbuKontoID])
GO

ALTER TABLE [dbo].[WshKategorie_KbuKonto] CHECK CONSTRAINT [FK_WshKategorie_KbuKonto_KbuKonto]
GO

ALTER TABLE [dbo].[WshKategorie_KbuKonto]  WITH CHECK ADD  CONSTRAINT [FK_WshKategorie_KbuKonto_WshKategorie] FOREIGN KEY([WshKategorieID])
REFERENCES [dbo].[WshKategorie] ([WshKategorieID])
GO

ALTER TABLE [dbo].[WshKategorie_KbuKonto] CHECK CONSTRAINT [FK_WshKategorie_KbuKonto_WshKategorie]
GO

ALTER TABLE [dbo].[WshKategorie_KbuKonto] ADD  CONSTRAINT [DF_WshKategorie_KbuKonto_NurMitSpezialrecht]  DEFAULT ((0)) FOR [NurMitSpezialrecht]
GO

ALTER TABLE [dbo].[WshKategorie_KbuKonto] ADD  CONSTRAINT [DF_WshKategorie_KbuKonto_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[WshKategorie_KbuKonto] ADD  CONSTRAINT [DF_WshKategorie_KbuKonto_Modified]  DEFAULT (getdate()) FOR [Modified]
GO
