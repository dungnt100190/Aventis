CREATE TABLE [dbo].[VmGefaehrdungsMeldung](
	[VmGefaehrdungsMeldungID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[DocumentID] [int] NULL,
	[DatumEingang] [datetime] NULL,
	[FaKontaktveranlasserCode] [int] NULL,
	[VmGefaehrdungNSBCodes] [varchar](255) NULL,
	[FaThemaCodes] [varchar](255) NULL,
	[Ausgangslage] [varchar](max) NULL,
	[Auflagen] [varchar](max) NULL,
	[Ueberpruefung] [varchar](max) NULL,
	[Konsequenzen] [varchar](max) NULL,
	[AuflageDatum] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[VmGefaehrdungsMeldungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_VmGefaehrdungsMeldung] PRIMARY KEY CLUSTERED 
(
	[VmGefaehrdungsMeldungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_VmGefaehrdungsMeldung_DocumentID]    Script Date: 11/15/2010 15:05:26 ******/
CREATE NONCLUSTERED INDEX [IX_VmGefaehrdungsMeldung_DocumentID] ON [dbo].[VmGefaehrdungsMeldung] 
(
	[DocumentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_VmGefaehrdungsMeldung_FaLeistungID]    Script Date: 11/15/2010 15:05:26 ******/
CREATE NONCLUSTERED INDEX [IX_VmGefaehrdungsMeldung_FaLeistungID] ON [dbo].[VmGefaehrdungsMeldung] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel von VmGefaehrdungsMeldung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmGefaehrdungsMeldung', @level2type=N'COLUMN',@level2name=N'VmGefaehrdungsMeldungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf die Leistung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmGefaehrdungsMeldung', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Document', @value=N'Id des physikalischen Dokuments.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmGefaehrdungsMeldung', @level2type=N'COLUMN',@level2name=N'DocumentID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Eingangsdatum.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmGefaehrdungsMeldung', @level2type=N'COLUMN',@level2name=N'DatumEingang'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Melder/In. Beispiele: Selber, Polizei' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmGefaehrdungsMeldung', @level2type=N'COLUMN',@level2name=N'FaKontaktveranlasserCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Descripton', @value=N'NSB (Neue Stadtverwaltung Bern), Beispiele: unabgeklärte GM, GM Pflegeplatz' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmGefaehrdungsMeldung', @level2type=N'COLUMN',@level2name=N'VmGefaehrdungNSBCodes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Themen wie Wohnen, Gesundheit u.s.w.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmGefaehrdungsMeldung', @level2type=N'COLUMN',@level2name=N'FaThemaCodes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ausgangslage' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmGefaehrdungsMeldung', @level2type=N'COLUMN',@level2name=N'Ausgangslage'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Auflagen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmGefaehrdungsMeldung', @level2type=N'COLUMN',@level2name=N'Auflagen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Überprüfung/Zusammenarbeit mit anderen Institutionen.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmGefaehrdungsMeldung', @level2type=N'COLUMN',@level2name=N'Ueberpruefung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Konsequenzen b. Nichteinhalten der Auflagen.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmGefaehrdungsMeldung', @level2type=N'COLUMN',@level2name=N'Konsequenzen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Auflagen aufg.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmGefaehrdungsMeldung', @level2type=N'COLUMN',@level2name=N'AuflageDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ob der Datensatz gelöscht worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmGefaehrdungsMeldung', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz  erstellt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmGefaehrdungsMeldung', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmGefaehrdungsMeldung', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz zuletzt geändert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmGefaehrdungsMeldung', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmGefaehrdungsMeldung', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp für optimistic Locking' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmGefaehrdungsMeldung', @level2type=N'COLUMN',@level2name=N'VmGefaehrdungsMeldungTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Claude Glauser' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmGefaehrdungsMeldung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabelle für Vormundschaft -> Auftrag Jugendamt -> Gefährdungsmeldung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmGefaehrdungsMeldung'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Vormundschaft' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmGefaehrdungsMeldung'
GO

ALTER TABLE [dbo].[VmGefaehrdungsMeldung]  WITH CHECK ADD  CONSTRAINT [FK_VmGefaehrdungsMeldung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[VmGefaehrdungsMeldung] CHECK CONSTRAINT [FK_VmGefaehrdungsMeldung_FaLeistung]
GO

ALTER TABLE [dbo].[VmGefaehrdungsMeldung] ADD  CONSTRAINT [VmGefaehrdungsMeldung_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[VmGefaehrdungsMeldung] ADD  CONSTRAINT [DF_VmGefaehrdungsMeldung_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[VmGefaehrdungsMeldung] ADD  CONSTRAINT [DF_VmGefaehrdungsMeldung_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


