CREATE TABLE [dbo].[EdEinsatzvereinbarung](
	[EdEinsatzvereinbarungID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[TypCode] [int] NOT NULL,
	[AnlassCode] [int] NULL,
	[ErstellungEV] [datetime] NOT NULL,
	[ErsterEinsatzAm] [datetime] NULL,
	[Auftrag] [text] NULL,
	[VereinbarteEinsatzzeiten] [text] NULL,
	[TarifTag] [money] NULL,
	[TarifNacht] [money] NULL,
	[TarifZuschlag] [money] NULL,
	[Bemerkungen] [text] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[EdEinsatzvereinbarungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_EdEinsatzvereinbarung] PRIMARY KEY CLUSTERED 
(
	[EdEinsatzvereinbarungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_EdEinsatzvereinbarung_FaLeistungID] UNIQUE NONCLUSTERED 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_EdEinsatzvereinbarung_FaLeistungIDAnlassCode] ON [dbo].[EdEinsatzvereinbarung] 
(
	[FaLeistungID] ASC,
	[AnlassCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PrimaryKey, wird als ID benutzt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'EdEinsatzvereinbarungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf FaLeistung.FaLeistungID (unique)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code aus der Werteliste' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'TypCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code aus der Werteliste' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'AnlassCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Erstelldatum der Einsatzvereinbarung (manuell)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'ErstellungEV'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum für erster Einsatz' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'ErsterEinsatzAm'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beschreibung des Auftrags' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'Auftrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Vereinbarte Einsatzzeiten' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'VereinbarteEinsatzzeiten'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tagestarif' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'TarifTag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nachttarif' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'TarifNacht'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zuschlagstarif' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'TarifZuschlag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkungen zu der Einsatzvereinbarung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'Bemerkungen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'EdEinsatzvereinbarungTS'
GO

ALTER TABLE [dbo].[EdEinsatzvereinbarung]  WITH CHECK ADD  CONSTRAINT [FK_EdEinsatzvereinbarung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[EdEinsatzvereinbarung] CHECK CONSTRAINT [FK_EdEinsatzvereinbarung_FaLeistung]
GO

ALTER TABLE [dbo].[EdEinsatzvereinbarung] ADD  CONSTRAINT [DF_EdEinsatzvereinbarung_Created]  DEFAULT (getdate()) FOR [Created]
GO