CREATE TABLE [dbo].[FaDokumente](
	[FaDokumenteID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[Vertraulich] [bit] NOT NULL CONSTRAINT [DF_FaDokumente_Vetraulich]  DEFAULT ((0)),
	[Archiviert] [bit] NOT NULL CONSTRAINT [DF_FaDokumente_Archiviert]  DEFAULT ((0)),
	[DatumErstellung] [datetime] NOT NULL CONSTRAINT [DF_FaDokumente_DatumErstellung]  DEFAULT (getdate()),
	[FaDokStatusCode] [int] NOT NULL CONSTRAINT [DF_FaDokumente_FaDokStatusCode]  DEFAULT ((1)),
	[StatusLetztUserID] [int] NULL,
	[StatusLetztDatum] [datetime] NULL,
	[Absender] [int] NULL,
	[Absender_Freitext] [varchar](100) NULL,
	[Adressat] [int] NULL,
	[Adressat_Freitext] [varchar](100) NULL,
	[Stichwort] [varchar](200) NOT NULL,
	[FaDokVerwendungCode] [int] NULL,
	[DocumentID] [int] NULL,
	[FaDokThemaCode] [int] NULL,
	[BaPersonID] [int] NULL,
	[VisumXTaskID] [int] NULL,
	[FaDokVisumStatusCode] [int] NULL,
	[VisumStatusDatum] [datetime] NULL,
	[VisumStatusUserID] [int] NULL,
	[Bemerkung] [text] NULL,
	[NichtKlibuRelevant] [bit] NOT NULL CONSTRAINT [DF_FaDokumente_NichtKlibuRelevant]  DEFAULT ((0)),
	[ErstelltUserID] [int] NULL,
	[ErstelltDatum] [datetime] NULL,
	[MutiertUserID] [int] NULL,
	[MutiertDatum] [datetime] NULL,
	[FaDokumenteTS] [timestamp] NOT NULL,
	[MigHerkunftCode] [int] NULL,
 CONSTRAINT [PK_FaDokumente] PRIMARY KEY CLUSTERED 
(
	[FaDokumenteID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
) ON [DATEN1] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_FaDokumente_BaPersonID]    Script Date: 11/23/2011 14:56:49 ******/
CREATE NONCLUSTERED INDEX [IX_FaDokumente_BaPersonID] ON [dbo].[FaDokumente] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO

/****** Object:  Index [IX_FaDokumente_DocumentID]    Script Date: 11/23/2011 14:56:49 ******/
CREATE NONCLUSTERED INDEX [IX_FaDokumente_DocumentID] ON [dbo].[FaDokumente] 
(
	[DocumentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO

/****** Object:  Index [IX_FaDokumente_FaLeistungID]    Script Date: 11/23/2011 14:56:49 ******/
CREATE NONCLUSTERED INDEX [IX_FaDokumente_FaLeistungID] ON [dbo].[FaDokumente] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO

/****** Object:  Index [IX_FaDokumente_StatusLetztUserID]    Script Date: 11/23/2011 14:56:49 ******/
CREATE NONCLUSTERED INDEX [IX_FaDokumente_StatusLetztUserID] ON [dbo].[FaDokumente] 
(
	[StatusLetztUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO

/****** Object:  Index [IX_FaDokumente_VisumStatusUserID]    Script Date: 11/23/2011 14:56:49 ******/
CREATE NONCLUSTERED INDEX [IX_FaDokumente_VisumStatusUserID] ON [dbo].[FaDokumente] 
(
	[VisumStatusUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO

/****** Object:  Index [IX_FaDokumente_VisumXTaskID]    Script Date: 11/23/2011 14:56:49 ******/
CREATE NONCLUSTERED INDEX [IX_FaDokumente_VisumXTaskID] ON [dbo].[FaDokumente] 
(
	[VisumXTaskID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO
ALTER TABLE [dbo].[FaDokumente]  WITH CHECK ADD  CONSTRAINT [FK_FaDokumente_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[FaDokumente] CHECK CONSTRAINT [FK_FaDokumente_BaPerson]
GO
ALTER TABLE [dbo].[FaDokumente]  WITH CHECK ADD  CONSTRAINT [FK_FaDokumente_FaFall] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO
ALTER TABLE [dbo].[FaDokumente] CHECK CONSTRAINT [FK_FaDokumente_FaFall]
GO
ALTER TABLE [dbo].[FaDokumente]  WITH CHECK ADD  CONSTRAINT [FK_FaDokumente_XTask] FOREIGN KEY([VisumXTaskID])
REFERENCES [dbo].[XTask] ([XTaskID])
GO
ALTER TABLE [dbo].[FaDokumente] CHECK CONSTRAINT [FK_FaDokumente_XTask]
GO
ALTER TABLE [dbo].[FaDokumente]  WITH CHECK ADD  CONSTRAINT [FK_FaDokumente_XUser_Status] FOREIGN KEY([StatusLetztUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[FaDokumente] CHECK CONSTRAINT [FK_FaDokumente_XUser_Status]
GO
ALTER TABLE [dbo].[FaDokumente]  WITH CHECK ADD  CONSTRAINT [FK_FaDokumente_XUser_Visum] FOREIGN KEY([VisumStatusUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[FaDokumente] CHECK CONSTRAINT [FK_FaDokumente_XUser_Visum]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Archivierte Dokumente ausserhalb von KiSS' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumente', @level2type=N'COLUMN',@level2name=N'Archiviert'
