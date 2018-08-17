CREATE TABLE [dbo].[BgDokument](
	[BgDokumentID] [int] IDENTITY(1,1) NOT NULL,
	[BgFinanzplanID] [int] NULL,
	[BgBudgetID] [int] NULL,
	[BgPositionID] [int] NULL,
	[BgDokumentTypCode] [int] NULL,
	[DocumentID] [int] NULL,
	[Stichwort] [varchar](200) NULL,
	[BgDocumentTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BgDokument] PRIMARY KEY CLUSTERED 
(
	[BgDokumentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_BgDokument_BgBudgetID]    Script Date: 11/23/2011 11:45:49 ******/
CREATE NONCLUSTERED INDEX [IX_BgDokument_BgBudgetID] ON [dbo].[BgDokument] 
(
	[BgBudgetID] ASC
)
INCLUDE ( [BgDokumentTypCode],
[DocumentID],
[Stichwort],
[BgPositionID],
[BgFinanzplanID],
[BgDocumentTS]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_BgDokument_BgFinanzplanID]    Script Date: 11/23/2011 11:45:49 ******/
CREATE NONCLUSTERED INDEX [IX_BgDokument_BgFinanzplanID] ON [dbo].[BgDokument] 
(
	[BgFinanzplanID] ASC
)
INCLUDE ( [BgDokumentTypCode],
[DocumentID],
[Stichwort],
[BgBudgetID],
[BgPositionID],
[BgDocumentTS]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_BgDokument_BgPositionID]    Script Date: 11/23/2011 11:45:49 ******/
CREATE NONCLUSTERED INDEX [IX_BgDokument_BgPositionID] ON [dbo].[BgDokument] 
(
	[BgPositionID] ASC
)
INCLUDE ( [BgDokumentTypCode],
[DocumentID],
[Stichwort],
[BgBudgetID],
[BgFinanzplanID],
[BgDocumentTS]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BgDokument]  WITH CHECK ADD  CONSTRAINT [FK_BgDokument_BgBudget] FOREIGN KEY([BgBudgetID])
REFERENCES [dbo].[BgBudget] ([BgBudgetID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BgDokument] CHECK CONSTRAINT [FK_BgDokument_BgBudget]
GO
ALTER TABLE [dbo].[BgDokument]  WITH CHECK ADD  CONSTRAINT [FK_BgDokument_BgFinanzplan] FOREIGN KEY([BgFinanzplanID])
REFERENCES [dbo].[BgFinanzplan] ([BgFinanzplanID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BgDokument] CHECK CONSTRAINT [FK_BgDokument_BgFinanzplan]
GO
ALTER TABLE [dbo].[BgDokument]  WITH CHECK ADD  CONSTRAINT [FK_BgDokument_BgPosition] FOREIGN KEY([BgPositionID])
REFERENCES [dbo].[BgPosition] ([BgPositionID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BgDokument] CHECK CONSTRAINT [FK_BgDokument_BgPosition]