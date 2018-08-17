CREATE TABLE [dbo].[BaInstitutionDokument](
	[BaInstitutionDokumentID] [int] IDENTITY(1,1) NOT NULL,
	[BaInstitutionID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[BaPersonID_Adressat] [int] NULL,
	[BaInstitutionID_Adressat] [int] NULL,
	[DocumentID] [int] NULL,
	[BaInstitutionDokumentKontaktartCode] [int] NULL,
	[BaInstitutionDokumentDienstleistungCode] [int] NULL,
	[FaDauerCode] [int] NULL,
	[Datum] [datetime] NULL,
	[Stichwort] [varchar](max) NULL,
	[Inhalt] [varchar](max) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[BaInstitutionDokumentTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaInstitutionDokument] PRIMARY KEY CLUSTERED 
(
	[BaInstitutionDokumentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_BaInstitutionDokument_BaInstitutionID]    Script Date: 03/03/2014 17:54:20 ******/
CREATE NONCLUSTERED INDEX [IX_BaInstitutionDokument_BaInstitutionID] ON [dbo].[BaInstitutionDokument] 
(
	[BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_BaInstitutionDokument_BaInstitutionID_Adressat]    Script Date: 03/03/2014 17:54:20 ******/
CREATE NONCLUSTERED INDEX [IX_BaInstitutionDokument_BaInstitutionID_Adressat] ON [dbo].[BaInstitutionDokument] 
(
	[BaInstitutionID_Adressat] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_BaInstitutionDokument_BaPersonID_Adressat]    Script Date: 03/03/2014 17:54:20 ******/
CREATE NONCLUSTERED INDEX [IX_BaInstitutionDokument_BaPersonID_Adressat] ON [dbo].[BaInstitutionDokument] 
(
	[BaPersonID_Adressat] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_BaInstitutionDokument_UserID]    Script Date: 03/03/2014 17:54:20 ******/
CREATE NONCLUSTERED INDEX [IX_BaInstitutionDokument_UserID] ON [dbo].[BaInstitutionDokument] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionDokument', @level2type=N'COLUMN',@level2name=N'BaInstitutionDokumentID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'zugehörige Institution' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionDokument', @level2type=N'COLUMN',@level2name=N'BaInstitutionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Verfasser des Dokuments' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionDokument', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BaPersonID, falls Adressat eine Person ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionDokument', @level2type=N'COLUMN',@level2name=N'BaPersonID_Adressat'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BaInstitutionID, falls Adressat eine Institution ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionDokument', @level2type=N'COLUMN',@level2name=N'BaInstitutionID_Adressat'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV BaInstitutionDokumentKontaktart' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionDokument', @level2type=N'COLUMN',@level2name=N'BaInstitutionDokumentKontaktartCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV BaInstitutionDokumentDienstleistung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionDokument', @level2type=N'COLUMN',@level2name=N'BaInstitutionDokumentDienstleistungCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV FaDauer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionDokument', @level2type=N'COLUMN',@level2name=N'FaDauerCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionDokument', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionDokument', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionDokument', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionDokument', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionDokument', @level2type=N'COLUMN',@level2name=N'BaInstitutionDokumentTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Lucas Loreggia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionDokument'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dokumente im Institutionenstamm' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionDokument'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Institutionenstamm' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionDokument'
GO

ALTER TABLE [dbo].[BaInstitutionDokument]  WITH CHECK ADD  CONSTRAINT [FK_BaInstitutionDokument_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[BaInstitutionDokument] CHECK CONSTRAINT [FK_BaInstitutionDokument_BaInstitution]
GO

ALTER TABLE [dbo].[BaInstitutionDokument]  WITH CHECK ADD  CONSTRAINT [FK_BaInstitutionDokument_BaInstitution_Adressat] FOREIGN KEY([BaInstitutionID_Adressat])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[BaInstitutionDokument] CHECK CONSTRAINT [FK_BaInstitutionDokument_BaInstitution_Adressat]
GO

ALTER TABLE [dbo].[BaInstitutionDokument]  WITH CHECK ADD  CONSTRAINT [FK_BaInstitutionDokument_BaPerson] FOREIGN KEY([BaPersonID_Adressat])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[BaInstitutionDokument] CHECK CONSTRAINT [FK_BaInstitutionDokument_BaPerson]
GO

ALTER TABLE [dbo].[BaInstitutionDokument]  WITH CHECK ADD  CONSTRAINT [FK_BaInstitutionDokument_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[BaInstitutionDokument] CHECK CONSTRAINT [FK_BaInstitutionDokument_XUser]
GO

ALTER TABLE [dbo].[BaInstitutionDokument] ADD  CONSTRAINT [DF_BaInstitutionDokument_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[BaInstitutionDokument] ADD  CONSTRAINT [DF_BaInstitutionDokument_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

