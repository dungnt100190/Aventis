CREATE TABLE [dbo].[WshKontoAttribut](
	[WshKontoAttributID] [int] IDENTITY(1,1) NOT NULL,
	[KbuKontoID] [int] NOT NULL,
	[IstGrundbudgetAktiv] [bit] NOT NULL,
	[IstMonatsbudgetAktiv] [bit] NOT NULL,
	[IstLeistungWsh] [bit] NOT NULL,
	[IstLeistungWshStationaer] [bit] NOT NULL,
	[SysEditModeCode_BetrifftPerson] [int] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[WshKontoAttributTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_WshKontoAttribut] PRIMARY KEY CLUSTERED 
(
	[WshKontoAttributID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_WshKontoAttribut_KbuKontoID] UNIQUE NONCLUSTERED 
(
	[KbuKontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_WshKontoAttribut_KbuKontoID]    Script Date: 09/02/2011 15:58:45 ******/
CREATE NONCLUSTERED INDEX [IX_WshKontoAttribut_KbuKontoID] ON [dbo].[WshKontoAttribut] 
(
	[KbuKontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Das KbuKonto (KOA) steht im Grundbudget zur Auswahl.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKontoAttribut', @level2type=N'COLUMN',@level2name=N'IstGrundbudgetAktiv'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Das KbuKonto (KOA) steht im Monatsbudget zur Auswahl.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKontoAttribut', @level2type=N'COLUMN',@level2name=N'IstMonatsbudgetAktiv'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Das KbuKonto (KOA) kann in der Leistung WSH verwendet werden. ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKontoAttribut', @level2type=N'COLUMN',@level2name=N'IstLeistungWsh'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Das KbuKonto (KOA) kann in der Leistung WshStationär verwendet werden.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKontoAttribut', @level2type=N'COLUMN',@level2name=N'IstLeistungWshStationaer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'In den Budgets muss für diese KOA eine Person ausgewählt werden (beim LOV Wert ''zwingend'').' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKontoAttribut', @level2type=N'COLUMN',@level2name=N'SysEditModeCode_BetrifftPerson'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz erstellt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKontoAttribut', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKontoAttribut', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz zuletzt geändert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKontoAttribut', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zulest geändert worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKontoAttribut', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKontoAttribut', @level2type=N'COLUMN',@level2name=N'WshKontoAttributTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Claude Glauser' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKontoAttribut'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabelle mit Steuerungsattributen für KbuKonto (also known as KOA). ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKontoAttribut'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'Je nach Inhalt stehen andere KOA in den Budgets (Monat und Grundbudget) zur Auswahl. Diese Tabelle enthält einen Teil der Steuerung. Siehe auch WshKategorie_KbuKonto.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKontoAttribut'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'Wsh' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKontoAttribut'
GO

ALTER TABLE [dbo].[WshKontoAttribut]  WITH CHECK ADD  CONSTRAINT [FK_WshKontoAttribut_KbKonto] FOREIGN KEY([KbuKontoID])
REFERENCES [dbo].[KbuKonto] ([KbuKontoID])
GO

ALTER TABLE [dbo].[WshKontoAttribut] CHECK CONSTRAINT [FK_WshKontoAttribut_KbKonto]
GO

ALTER TABLE [dbo].[WshKontoAttribut] ADD  CONSTRAINT [DF_WshKontoAttribut_IstGrundbudgetAktiv]  DEFAULT ((1)) FOR [IstGrundbudgetAktiv]
GO

ALTER TABLE [dbo].[WshKontoAttribut] ADD  CONSTRAINT [DF_WshKontoAttribut_IstMonatsbudgetAktiv]  DEFAULT ((1)) FOR [IstMonatsbudgetAktiv]
GO

ALTER TABLE [dbo].[WshKontoAttribut] ADD  CONSTRAINT [DF_WshKontoAttribut_IstLeistungWsh]  DEFAULT ((1)) FOR [IstLeistungWsh]
GO

ALTER TABLE [dbo].[WshKontoAttribut] ADD  CONSTRAINT [DF_WshKontoAttribut_IstLeistungWshStationaer]  DEFAULT ((1)) FOR [IstLeistungWshStationaer]
GO

ALTER TABLE [dbo].[WshKontoAttribut] ADD  CONSTRAINT [DF_WshKontoAttribut_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[WshKontoAttribut] ADD  CONSTRAINT [DF_WshKontoAttribut_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


