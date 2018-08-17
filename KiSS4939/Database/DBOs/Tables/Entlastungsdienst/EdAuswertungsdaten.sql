CREATE TABLE [dbo].[EdAuswertungsdaten](
	[EdAuswertungsdatenID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[FamiliensituationCode] [int] NULL,
	[BetreuungCode] [int] NULL,
	[AnzahlGeschwister] [int] NULL,
	[WohnsituationCode] [int] NULL,
	[LeistungenDritterCodes] [varchar](255) NULL,
	[LetzteStandortbestimmung] [datetime] NULL,
	[FinanzielleRessourcen] [varchar](max) NULL,
	[FinanzierungDurchFLB] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[EdAuswertungsdatenTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_EdAuswertungsdaten] PRIMARY KEY CLUSTERED 
(
	[EdAuswertungsdatenID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_EdAuswertungsdaten_FaLeistungID] UNIQUE NONCLUSTERED 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PrimaryKey, wird als ID benutzt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdAuswertungsdaten', @level2type=N'COLUMN',@level2name=N'EdAuswertungsdatenID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf FaLeistung.FaLeistungID (unique)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdAuswertungsdaten', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code von Werteliste' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdAuswertungsdaten', @level2type=N'COLUMN',@level2name=N'FamiliensituationCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code von Werteliste' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdAuswertungsdaten', @level2type=N'COLUMN',@level2name=N'BetreuungCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Anzahl Geschwister (0..99)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdAuswertungsdaten', @level2type=N'COLUMN',@level2name=N'AnzahlGeschwister'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code von Werteliste' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdAuswertungsdaten', @level2type=N'COLUMN',@level2name=N'WohnsituationCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Codes von Werteliste als CSV' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdAuswertungsdaten', @level2type=N'COLUMN',@level2name=N'LeistungenDritterCodes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum der letzten Standortbestimmung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdAuswertungsdaten', @level2type=N'COLUMN',@level2name=N'LetzteStandortbestimmung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Finanzielle Ressourcen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdAuswertungsdaten', @level2type=N'COLUMN',@level2name=N'FinanzielleRessourcen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Finanzierung durch FLB' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdAuswertungsdaten', @level2type=N'COLUMN',@level2name=N'FinanzierungDurchFLB'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdAuswertungsdaten', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdAuswertungsdaten', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz modifiziert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdAuswertungsdaten', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum, wann der Datensatz verändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdAuswertungsdaten', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdAuswertungsdaten', @level2type=N'COLUMN',@level2name=N'EdAuswertungsdatenTS'
GO

ALTER TABLE [dbo].[EdAuswertungsdaten]  WITH CHECK ADD  CONSTRAINT [FK_EdAuswertungsdaten_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[EdAuswertungsdaten] CHECK CONSTRAINT [FK_EdAuswertungsdaten_FaLeistung]
GO

ALTER TABLE [dbo].[EdAuswertungsdaten] ADD  CONSTRAINT [DF_EdAuswertungsdaten_FinanzierungDurchFLB]  DEFAULT ((0)) FOR [FinanzierungDurchFLB]
GO

ALTER TABLE [dbo].[EdAuswertungsdaten] ADD  CONSTRAINT [DF_EdAuswertungsdaten_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[EdAuswertungsdaten] ADD  CONSTRAINT [DF_EdAuswertungsdaten_Modified]  DEFAULT (getdate()) FOR [Modified]
GO