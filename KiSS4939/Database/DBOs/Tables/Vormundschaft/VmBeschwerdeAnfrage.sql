CREATE TABLE [dbo].[VmBeschwerdeAnfrage](
	[VmBeschwerdeAnfrageID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[Eingang] [datetime] NULL,
	[Absender] [varchar](100) NULL,
	[Stichworte] [varchar](max) NULL,
	[VmBsBeschwerdeBehandlungCode] [int] NULL,
	[Abschluss] [datetime] NULL,
	[DocumentID] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[VmBeschwerdeAnfrageTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_VmBeschwerdeAnfrage] PRIMARY KEY CLUSTERED 
(
	[VmBeschwerdeAnfrageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_VmBeschwerdeAnfrage_DocumentID]    Script Date: 11/11/2010 15:23:53 ******/
CREATE NONCLUSTERED INDEX [IX_VmBeschwerdeAnfrage_DocumentID] ON [dbo].[VmBeschwerdeAnfrage] 
(
	[DocumentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_VmBeschwerdeAnfrage_FaLeistungID]    Script Date: 11/11/2010 15:23:53 ******/
CREATE NONCLUSTERED INDEX [IX_VmBeschwerdeAnfrage_FaLeistungID] ON [dbo].[VmBeschwerdeAnfrage] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel von VaBeschwerdeAnfrage' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmBeschwerdeAnfrage', @level2type=N'COLUMN',@level2name=N'VmBeschwerdeAnfrageID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf die Leistung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmBeschwerdeAnfrage', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum Eingang  der Beschwerde.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmBeschwerdeAnfrage', @level2type=N'COLUMN',@level2name=N'Eingang'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Absender der Beschwerde oder Anfrage.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmBeschwerdeAnfrage', @level2type=N'COLUMN',@level2name=N'Absender'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stichworte über die Beschwerde oder Anfrage.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmBeschwerdeAnfrage', @level2type=N'COLUMN',@level2name=N'Stichworte'
GO

EXEC sys.sp_addextendedproperty @name=N'LOV_Name', @value=N'Behandlung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmBeschwerdeAnfrage', @level2type=N'COLUMN',@level2name=N'VmBsBeschwerdeBehandlungCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV Code. Beispiele: EKS Kommission, Regierungsstatthalter' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmBeschwerdeAnfrage', @level2type=N'COLUMN',@level2name=N'VmBsBeschwerdeBehandlungCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum Abschluss der Beschwerde oder Anfrage.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmBeschwerdeAnfrage', @level2type=N'COLUMN',@level2name=N'Abschluss'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die Id des binären Dokuments.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmBeschwerdeAnfrage', @level2type=N'COLUMN',@level2name=N'DocumentID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob ein Datensatz logisch gelöscht ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmBeschwerdeAnfrage', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz (Beschwerde oder Anfrage) erstellt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmBeschwerdeAnfrage', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde (Beschwerde oder Anfrage)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmBeschwerdeAnfrage', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz (Beschwerde oder Anfrage) zuletzt geändert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmBeschwerdeAnfrage', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert worden ist (Beschwerde oder Anfrage).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmBeschwerdeAnfrage', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp für optimistic Locking' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmBeschwerdeAnfrage', @level2type=N'COLUMN',@level2name=N'VmBeschwerdeAnfrageTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Claude Glauser' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmBeschwerdeAnfrage'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Descrioption', @value=N'Tabelle für Beschwerde und Anfrage.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmBeschwerdeAnfrage'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'Migriert von Eigene-Masken' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmBeschwerdeAnfrage'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'Vormundschaft und Fallführung.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmBeschwerdeAnfrage'
GO

ALTER TABLE [dbo].[VmBeschwerdeAnfrage]  WITH CHECK ADD  CONSTRAINT [FK_VmBeschwerdeAnfrage_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[VmBeschwerdeAnfrage] CHECK CONSTRAINT [FK_VmBeschwerdeAnfrage_FaLeistung]
GO

ALTER TABLE [dbo].[VmBeschwerdeAnfrage] ADD  CONSTRAINT [DF_VmBeschwerdeAnfrage_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[VmBeschwerdeAnfrage] ADD  CONSTRAINT [DF_VmBeschwerdeAnfrage_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[VmBeschwerdeAnfrage] ADD  CONSTRAINT [DF_VmBeschwerdeAnfrage_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


