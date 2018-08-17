CREATE TABLE [dbo].[BwEinsatzvereinbarung](
	[BwEinsatzvereinbarungID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[BwTypCode] [int] NULL,
	[ErstellungEV] [datetime] NOT NULL,
	[ErsterEinsatzAm] [datetime] NULL,
	[Ziele] [varchar](max) NULL,
	[Auftrag] [varchar](max) NULL,
	[VereinbarteEinsatzzeiten] [varchar](max) NULL,
	[TarifTag] [money] NULL,
	[TarifNacht] [money] NULL,
	[Bemerkungen] [varchar](max) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[BwEinsatzvereinbarungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BwEinsatzvereinbarung] PRIMARY KEY CLUSTERED 
(
	[BwEinsatzvereinbarungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_BwEinsatzvereinbarung_FaLeistungID] UNIQUE NONCLUSTERED 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel in form einer ID.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'BwEinsatzvereinbarungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID der zugehörigen Leistung. Fremdschlüssel auf FaLeistung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Typ Code der Einsatzvereinbarung. Codes aus LOV BwTyp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'BwTypCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zeitpunkt der Erfassung der Einsatzvereinbarung.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'ErstellungEV'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum an welchem der erste Einsatz erfolgt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'ErsterEinsatzAm'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ziele der Intervention.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'Ziele'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Auftrag an den Mitarbeiter' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'Auftrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Vereinbarung über Zeiten der Einsätze.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'VereinbarteEinsatzzeiten'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Normaltarif am Tag.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'TarifTag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tarif in der Nacht' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'TarifNacht'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Allgemeine Bemerkungen zur Vereinbarung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'Bemerkungen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angabe zum Benutzer welcher der Eintrag erstellt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zeitpunkt an welchem der Eintrag erstellt wurde.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Benutzer welcher als letztes den Eintrag mutiert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zeitpunkt an welchem der Eintrag zum letzten mal mutiert wurde.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp für Konsistenzprüfung.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'BwEinsatzvereinbarungTS'
GO

ALTER TABLE [dbo].[BwEinsatzvereinbarung]  WITH CHECK ADD  CONSTRAINT [FK_BwEinsatzvereinbarung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BwEinsatzvereinbarung] CHECK CONSTRAINT [FK_BwEinsatzvereinbarung_FaLeistung]
GO

ALTER TABLE [dbo].[BwEinsatzvereinbarung] ADD  CONSTRAINT [DF_BwEinsatzvereinbarung_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[BwEinsatzvereinbarung] ADD  CONSTRAINT [DF_BwEinsatzvereinbarung_Modified]  DEFAULT (getdate()) FOR [Modified]
GO