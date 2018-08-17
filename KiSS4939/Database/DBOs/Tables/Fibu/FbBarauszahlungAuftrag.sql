CREATE TABLE [dbo].[FbBarauszahlungAuftrag](
	[FbBarauszahlungAuftragID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[UserID_Creator] [int] NOT NULL,
	[UserID_Modifier] [int] NOT NULL,
	[XDocumentID] [int] NULL,
	[AuszahlungenVorhanden] [bit] NOT NULL,
	[Betrag] [money] NOT NULL,
	[Buchungstext] [varchar](200) NOT NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NULL,
	[FbBarauszahlungPeriodizitaetCode] [int] NOT NULL,
	[SollKtoNr] [int] NOT NULL,
	[HabenKtoNr] [int] NOT NULL,
	[Vorbezug] [int] NOT NULL,
	[Nachbezug] [int] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[FbBarauszahlungAuftragTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FbBarauszahlungAuftrag] PRIMARY KEY CLUSTERED 
(
	[FbBarauszahlungAuftragID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_FbBarauszahlungAuftrag_FaLeistungID]    Script Date: 01/22/2014 15:59:29 ******/
CREATE NONCLUSTERED INDEX [IX_FbBarauszahlungAuftrag_FaLeistungID] ON [dbo].[FbBarauszahlungAuftrag] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_FbBarauszahlungAuftrag_UserID_Creator]    Script Date: 01/22/2014 15:59:29 ******/
CREATE NONCLUSTERED INDEX [IX_FbBarauszahlungAuftrag_UserID_Creator] ON [dbo].[FbBarauszahlungAuftrag] 
(
	[UserID_Creator] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_FbBarauszahlungAuftrag_UserID_Modifier]    Script Date: 01/22/2014 15:59:29 ******/
CREATE NONCLUSTERED INDEX [IX_FbBarauszahlungAuftrag_UserID_Modifier] ON [dbo].[FbBarauszahlungAuftrag] 
(
	[UserID_Modifier] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel einem Barauszahlungsauftrag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAuftrag', @level2type=N'COLUMN',@level2name=N'FbBarauszahlungAuftragID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel der Leistung.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAuftrag', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel des Benutzers welcher den Auftrag erstellt hat. ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAuftrag', @level2type=N'COLUMN',@level2name=N'UserID_Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel des Benutzers welcher den Auftrag geändert hat. ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAuftrag', @level2type=N'COLUMN',@level2name=N'UserID_Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel von einem Dokument' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAuftrag', @level2type=N'COLUMN',@level2name=N'XDocumentID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'zum wissen ob Auszahlung bereits voranden' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAuftrag', @level2type=N'COLUMN',@level2name=N'AuszahlungenVorhanden'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betrag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAuftrag', @level2type=N'COLUMN',@level2name=N'Betrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Buchungstext' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAuftrag', @level2type=N'COLUMN',@level2name=N'Buchungstext'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Gültigkeitsdatum von' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAuftrag', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Gültigkeitsdatum bis' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAuftrag', @level2type=N'COLUMN',@level2name=N'DatumBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die Periodizität. Enum und LOV FbBarauszahlungPeriodizitaet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAuftrag', @level2type=N'COLUMN',@level2name=N'FbBarauszahlungPeriodizitaetCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Soll-Kontonummer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAuftrag', @level2type=N'COLUMN',@level2name=N'SollKtoNr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Haben-Kontonummer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAuftrag', @level2type=N'COLUMN',@level2name=N'HabenKtoNr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Anzahl Tage welche die Auszahlung im Voraus eingelöst werden kann' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAuftrag', @level2type=N'COLUMN',@level2name=N'Vorbezug'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Anzahl Tage welche die Auszahlung im Nachhinein eingelöst werden kann' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAuftrag', @level2type=N'COLUMN',@level2name=N'Nachbezug'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAuftrag', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAuftrag', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAuftrag', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAuftrag', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAuftrag', @level2type=N'COLUMN',@level2name=N'FbBarauszahlungAuftragTS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'beinhaltet Barauszahlungsaufträge' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAuftrag'
GO

ALTER TABLE [dbo].[FbBarauszahlungAuftrag]  WITH CHECK ADD  CONSTRAINT [FK_FbBarauszahlungAuftrag_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[FbBarauszahlungAuftrag] CHECK CONSTRAINT [FK_FbBarauszahlungAuftrag_FaLeistung]
GO

ALTER TABLE [dbo].[FbBarauszahlungAuftrag]  WITH CHECK ADD  CONSTRAINT [FK_FbBarauszahlungAuftrag_XUser_Creator] FOREIGN KEY([UserID_Creator])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FbBarauszahlungAuftrag] CHECK CONSTRAINT [FK_FbBarauszahlungAuftrag_XUser_Creator]
GO

ALTER TABLE [dbo].[FbBarauszahlungAuftrag]  WITH CHECK ADD  CONSTRAINT [FK_FbBarauszahlungAuftrag_XUser_Modifier] FOREIGN KEY([UserID_Modifier])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FbBarauszahlungAuftrag] CHECK CONSTRAINT [FK_FbBarauszahlungAuftrag_XUser_Modifier]
GO

ALTER TABLE [dbo].[FbBarauszahlungAuftrag]  WITH CHECK ADD  CONSTRAINT [CK_FbBarauszahlungAuftrag_Betrag] CHECK  (([Betrag]>(0)))
GO

ALTER TABLE [dbo].[FbBarauszahlungAuftrag] CHECK CONSTRAINT [CK_FbBarauszahlungAuftrag_Betrag]
GO

ALTER TABLE [dbo].[FbBarauszahlungAuftrag]  WITH CHECK ADD  CONSTRAINT [CK_FbBarauszahlungAuftrag_DatumVonBis] CHECK  (([DatumVon]<=[DatumBis]))
GO

ALTER TABLE [dbo].[FbBarauszahlungAuftrag] CHECK CONSTRAINT [CK_FbBarauszahlungAuftrag_DatumVonBis]
GO

ALTER TABLE [dbo].[FbBarauszahlungAuftrag]  WITH CHECK ADD  CONSTRAINT [CK_FbBarauszahlungAuftrag_Nachbezug] CHECK  (([Nachbezug]>=(0)))
GO

ALTER TABLE [dbo].[FbBarauszahlungAuftrag] CHECK CONSTRAINT [CK_FbBarauszahlungAuftrag_Nachbezug]
GO

ALTER TABLE [dbo].[FbBarauszahlungAuftrag]  WITH CHECK ADD  CONSTRAINT [CK_FbBarauszahlungAuftrag_Vorbezg] CHECK  (([Vorbezug]>=(0)))
GO

ALTER TABLE [dbo].[FbBarauszahlungAuftrag] CHECK CONSTRAINT [CK_FbBarauszahlungAuftrag_Vorbezg]
GO

ALTER TABLE [dbo].[FbBarauszahlungAuftrag] ADD  CONSTRAINT [DF_FbBarauszahlungAuftrag_Ausbezahlt]  DEFAULT ((0)) FOR [AuszahlungenVorhanden]
GO

ALTER TABLE [dbo].[FbBarauszahlungAuftrag] ADD  CONSTRAINT [DF_FbBarauszahlungAuftrag_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[FbBarauszahlungAuftrag] ADD  CONSTRAINT [DF_FbBarauszahlungAuftrag_Modified]  DEFAULT (getdate()) FOR [Modified]
GO