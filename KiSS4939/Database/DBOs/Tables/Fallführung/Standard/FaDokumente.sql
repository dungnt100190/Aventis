CREATE TABLE [dbo].[FaDokumente](
	[FaDokumenteID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[BaPersonID_LT] [int] NULL,
	[BaPersonID_Adressat] [int] NULL,
	[BaInstitutionID_Adressat] [int] NULL,
	[VmPriMaID_Adressat] [int] NULL,
	[UserID_Absender] [int] NULL,
	[UserID_VisumBeantragtDurch] [int] NULL,
	[UserID_VisumBeantragtBei] [int] NULL,
	[UserID_VisiertDurch] [int] NULL,
	[UserID_EkVisumUser] [int] NULL,
	[DocumentID] [int] NULL,
	[DocumentID_Merkblatt] [int] NULL,
	[BaPersonIDs] [varchar](200) NULL,
	[DatumErstellung] [datetime] NULL,
	[StatusCode] [int] NULL,
	[PendenzDatum] [datetime] NULL,
	[PendenzErledigt] [bit] NULL,
	[VmErbDienstCode] [int] NULL,
	[FaDauerCode] [int] NULL,
	[Stichwort] [varchar](200) NULL,
	[EingangAusgang] [int] NULL,
	[ThemaCode] [int] NULL,
	[VisumBeantragtDatum] [datetime] NULL,
	[VisiertDatum] [datetime] NULL,
	[EkStatusCode] [int] NULL,
	[EkLaufNr] [int] NULL,
	[EkKW] [int] NULL,
	[EkJahr] [int] NULL,
	[EkVisumDatum] [datetime] NULL,
	[Bemerkung] [varchar](500) NULL,
	[FaThemaCodes] [varchar](200) NULL,
	[Vertraulich] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IstBericht] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[FaDokumenteTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaDokumente] PRIMARY KEY CLUSTERED 
(
	[FaDokumenteID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_FaDokumente_BaInstitutionID_Adressat]    Script Date: 01/25/2011 08:35:03 ******/
CREATE NONCLUSTERED INDEX [IX_FaDokumente_BaInstitutionID_Adressat] ON [dbo].[FaDokumente] 
(
	[BaInstitutionID_Adressat] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaDokumente_BaPersonID_Adressat]    Script Date: 01/25/2011 08:35:03 ******/
CREATE NONCLUSTERED INDEX [IX_FaDokumente_BaPersonID_Adressat] ON [dbo].[FaDokumente] 
(
	[BaPersonID_Adressat] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaDokumente_BaPersonID_LT]    Script Date: 01/25/2011 08:35:03 ******/
CREATE NONCLUSTERED INDEX [IX_FaDokumente_BaPersonID_LT] ON [dbo].[FaDokumente] 
(
	[BaPersonID_LT] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaDokumente_DocumentID]    Script Date: 01/25/2011 08:35:03 ******/
CREATE NONCLUSTERED INDEX [IX_FaDokumente_DocumentID] ON [dbo].[FaDokumente] 
(
	[DocumentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaDokumente_FaLeistungID]    Script Date: 01/25/2011 08:35:03 ******/
CREATE NONCLUSTERED INDEX [IX_FaDokumente_FaLeistungID] ON [dbo].[FaDokumente] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaDokumente_UserID_Absender]    Script Date: 01/25/2011 08:35:03 ******/
CREATE NONCLUSTERED INDEX [IX_FaDokumente_UserID_Absender] ON [dbo].[FaDokumente] 
(
	[UserID_Absender] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaDokumente_UserID_EkVisumUser]    Script Date: 01/25/2011 08:35:03 ******/
CREATE NONCLUSTERED INDEX [IX_FaDokumente_UserID_EkVisumUser] ON [dbo].[FaDokumente] 
(
	[UserID_EkVisumUser] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaDokumente_UserID_VisiertDurch]    Script Date: 01/25/2011 08:35:03 ******/
CREATE NONCLUSTERED INDEX [IX_FaDokumente_UserID_VisiertDurch] ON [dbo].[FaDokumente] 
(
	[UserID_VisiertDurch] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaDokumente_UserID_VisumBeantragtBei]    Script Date: 01/25/2011 08:35:03 ******/
CREATE NONCLUSTERED INDEX [IX_FaDokumente_UserID_VisumBeantragtBei] ON [dbo].[FaDokumente] 
(
	[UserID_VisumBeantragtBei] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaDokumente_VmPriMaID_Adressat]    Script Date: 01/25/2011 08:35:03 ******/
CREATE NONCLUSTERED INDEX [IX_FaDokumente_VmPriMaID_Adressat] ON [dbo].[FaDokumente] 
(
	[VmPriMaID_Adressat] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zum PriMa (Private Mandatsträger) für das Adressat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumente', @level2type=N'COLUMN',@level2name=N'VmPriMaID_Adressat'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Merkblatt Dokument' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumente', @level2type=N'COLUMN',@level2name=N'DocumentID_Merkblatt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BaPersonIDs der betroffenen Personen, kommasepariert' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumente', @level2type=N'COLUMN',@level2name=N'BaPersonIDs'
GO

EXEC sys.sp_addextendedproperty @name=N'Example', @value=N'1 für Sozialdienst (SD).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumente', @level2type=N'COLUMN',@level2name=N'VmErbDienstCode'
GO

EXEC sys.sp_addextendedproperty @name=N'LOVName', @value=N'VmErbDienst' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumente', @level2type=N'COLUMN',@level2name=N'VmErbDienstCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Welcher Dienst es ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumente', @level2type=N'COLUMN',@level2name=N'VmErbDienstCode'
GO

EXEC sys.sp_addextendedproperty @name=N'LOVName', @value=N'FaDauer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumente', @level2type=N'COLUMN',@level2name=N'FaDauerCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dauer, z.B. 15 Minuten' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumente', @level2type=N'COLUMN',@level2name=N'FaDauerCode'
GO

EXEC sys.sp_addextendedproperty @name=N'Obsolete', @value=N'Wird durch Themen-Code abgelöst.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumente', @level2type=N'COLUMN',@level2name=N'ThemaCode'
GO

EXEC sys.sp_addextendedproperty @name=N'Example', @value=N'Wohnen, Gesundheit.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumente', @level2type=N'COLUMN',@level2name=N'FaThemaCodes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Auflistung der Themen (aus LOV). Kommasepariert.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumente', @level2type=N'COLUMN',@level2name=N'FaThemaCodes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Hat den Wert 1, wenn das Dokument logisch gelöscht ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumente', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ob ein Dokument ein Bericht ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumente', @level2type=N'COLUMN',@level2name=N'IstBericht'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz angelegt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumente', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wan der Datensatz angelegt worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumente', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz zuletzt verändert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumente', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zulest verändert worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumente', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Records, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumente', @level2type=N'COLUMN',@level2name=N'FaDokumenteTS'
GO

ALTER TABLE [dbo].[FaDokumente]  WITH CHECK ADD  CONSTRAINT [FK_FaDokumente_BaInstitution_Adressat] FOREIGN KEY([BaInstitutionID_Adressat])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[FaDokumente] CHECK CONSTRAINT [FK_FaDokumente_BaInstitution_Adressat]
GO

ALTER TABLE [dbo].[FaDokumente]  WITH CHECK ADD  CONSTRAINT [FK_FaDokumente_BaPerson_Adressat] FOREIGN KEY([BaPersonID_Adressat])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[FaDokumente] CHECK CONSTRAINT [FK_FaDokumente_BaPerson_Adressat]
GO

ALTER TABLE [dbo].[FaDokumente]  WITH CHECK ADD  CONSTRAINT [FK_FaDokumente_BaPerson_LT] FOREIGN KEY([BaPersonID_LT])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[FaDokumente] CHECK CONSTRAINT [FK_FaDokumente_BaPerson_LT]
GO

ALTER TABLE [dbo].[FaDokumente]  WITH CHECK ADD  CONSTRAINT [FK_FaDokumente_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[FaDokumente] CHECK CONSTRAINT [FK_FaDokumente_FaLeistung]
GO

ALTER TABLE [dbo].[FaDokumente]  WITH CHECK ADD  CONSTRAINT [FK_FaDokumente_VmPriMa] FOREIGN KEY([VmPriMaID_Adressat])
REFERENCES [dbo].[VmPriMa] ([VmPriMaID])
GO

ALTER TABLE [dbo].[FaDokumente] CHECK CONSTRAINT [FK_FaDokumente_VmPriMa]
GO

ALTER TABLE [dbo].[FaDokumente]  WITH CHECK ADD  CONSTRAINT [FK_FaDokumente_XUser_Absender] FOREIGN KEY([UserID_Absender])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaDokumente] CHECK CONSTRAINT [FK_FaDokumente_XUser_Absender]
GO

ALTER TABLE [dbo].[FaDokumente]  WITH CHECK ADD  CONSTRAINT [FK_FaDokumente_XUser_EkVisumUserID] FOREIGN KEY([UserID_EkVisumUser])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaDokumente] CHECK CONSTRAINT [FK_FaDokumente_XUser_EkVisumUserID]
GO

ALTER TABLE [dbo].[FaDokumente]  WITH CHECK ADD  CONSTRAINT [FK_FaDokumente_XUser_VisiertDurchID] FOREIGN KEY([UserID_VisiertDurch])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaDokumente] CHECK CONSTRAINT [FK_FaDokumente_XUser_VisiertDurchID]
GO

ALTER TABLE [dbo].[FaDokumente]  WITH CHECK ADD  CONSTRAINT [FK_FaDokumente_XUser_VisumBeantragtBeiID] FOREIGN KEY([UserID_VisumBeantragtBei])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaDokumente] CHECK CONSTRAINT [FK_FaDokumente_XUser_VisumBeantragtBeiID]
GO

ALTER TABLE [dbo].[FaDokumente]  WITH CHECK ADD  CONSTRAINT [FK_FaDokumente_XUser_VisumBeantragtDurchID] FOREIGN KEY([UserID_VisumBeantragtDurch])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaDokumente] CHECK CONSTRAINT [FK_FaDokumente_XUser_VisumBeantragtDurchID]
GO

ALTER TABLE [dbo].[FaDokumente] ADD  CONSTRAINT [DF_FaDokumente_Vetraulich]  DEFAULT ((0)) FOR [Vertraulich]
GO

ALTER TABLE [dbo].[FaDokumente] ADD  CONSTRAINT [DF_FaDokumente_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[FaDokumente] ADD  CONSTRAINT [DF_FaDokumente_IstBericht]  DEFAULT ((0)) FOR [IstBericht]
GO

ALTER TABLE [dbo].[FaDokumente] ADD  CONSTRAINT [DF_FaDokumente_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[FaDokumente] ADD  CONSTRAINT [DF_FaDokumente_Modified]  DEFAULT (getdate()) FOR [Modified]
GO
