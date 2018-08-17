CREATE TABLE [dbo].[KgDokument](
	[KgDokumentID] [int] IDENTITY(1,1) NOT NULL,
	[KgBudgetID] [int] NULL,
	[KgPositionID] [int] NULL,
	[KgBuchungID] [int] NULL,
	[KgDokumentTypCode] [int] NOT NULL,
	[DocumentID] [int] NULL,
	[Stichwort] [varchar](200) NOT NULL,
	[KgDocumentTS] [timestamp] NOT NULL,
	[KgKontoID] [int] NULL,
	[Stichtag] [datetime] NULL,
	[BaPersonID] [int] NULL,
 CONSTRAINT [PK_KgDokument] PRIMARY KEY CLUSTERED 
(
	[KgDokumentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_KgDokument_KgBuchungID]    Script Date: 11/23/2011 16:01:35 ******/
CREATE NONCLUSTERED INDEX [IX_KgDokument_KgBuchungID] ON [dbo].[KgDokument] 
(
	[KgBuchungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_KgDokument_KgBudgetID]    Script Date: 11/23/2011 16:01:35 ******/
CREATE NONCLUSTERED INDEX [IX_KgDokument_KgBudgetID] ON [dbo].[KgDokument] 
(
	[KgBudgetID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_KgDokument_KgKontoID]    Script Date: 11/23/2011 16:01:35 ******/
CREATE NONCLUSTERED INDEX [IX_KgDokument_KgKontoID] ON [dbo].[KgDokument] 
(
	[KgKontoID] ASC
)
INCLUDE ( [Stichtag]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_KgDokument_KgPositionID]    Script Date: 11/23/2011 16:01:35 ******/
CREATE NONCLUSTERED INDEX [IX_KgDokument_KgPositionID] ON [dbo].[KgDokument] 
(
	[KgPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[KgDokument]  WITH CHECK ADD  CONSTRAINT [FK_KgDokument_KgBuchung] FOREIGN KEY([KgBuchungID])
REFERENCES [dbo].[KgBuchung] ([KgBuchungID])
GO
ALTER TABLE [dbo].[KgDokument] CHECK CONSTRAINT [FK_KgDokument_KgBuchung]
GO
ALTER TABLE [dbo].[KgDokument]  WITH CHECK ADD  CONSTRAINT [FK_KgDokument_KgBudget] FOREIGN KEY([KgBudgetID])
REFERENCES [dbo].[KgBudget] ([KgBudgetID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KgDokument] CHECK CONSTRAINT [FK_KgDokument_KgBudget]
GO
ALTER TABLE [dbo].[KgDokument]  WITH CHECK ADD  CONSTRAINT [FK_KgDokument_KgBudgetPosition] FOREIGN KEY([KgPositionID])
REFERENCES [dbo].[KgPosition] ([KgPositionID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KgDokument] CHECK CONSTRAINT [FK_KgDokument_KgBudgetPosition]
GO
ALTER TABLE [dbo].[KgDokument]  WITH CHECK ADD  CONSTRAINT [KgDokument_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[KgDokument] CHECK CONSTRAINT [KgDokument_BaPerson]
GO
ALTER TABLE [dbo].[KgDokument]  WITH CHECK ADD  CONSTRAINT [KgDokument_KgKonto] FOREIGN KEY([KgKontoID])
REFERENCES [dbo].[KgKonto] ([KgKontoID])
GO
ALTER TABLE [dbo].[KgDokument] CHECK CONSTRAINT [KgDokument_KgKonto]