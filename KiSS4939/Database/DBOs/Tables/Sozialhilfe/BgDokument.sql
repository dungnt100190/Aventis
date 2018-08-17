CREATE TABLE [dbo].[BgDokument](
	[BgDokumentID] [int] IDENTITY(1,1) NOT NULL,
	[BgFinanzplanID] [int] NULL,
	[BgBudgetID] [int] NULL,
	[BgPositionID] [int] NULL,
	[BgDokumentTypCode] [int] NULL,
	[DocumentID] [int] NULL,
	[Stichwort] [varchar](200) NULL,
	[BgDocumentTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BgDokument] PRIMARY KEY NONCLUSTERED 
(
	[BgDokumentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_BgDokument_BgBudgetID] ON [dbo].[BgDokument] 
(
	[BgBudgetID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_BgDokument_BgFinanzplanID] ON [dbo].[BgDokument] 
(
	[BgFinanzplanID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_BgDokument_BgPositionID] ON [dbo].[BgDokument] 
(
	[BgPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für BgDokument Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgDokument', @level2type=N'COLUMN',@level2name=N'BgDokumentID'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgDokument_BgFinanzplan) => BgFinanzplan.BgFinanzplanID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgDokument', @level2type=N'COLUMN',@level2name=N'BgFinanzplanID'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgDokument_BgBudget) => BgBudget.BgBudgetID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgDokument', @level2type=N'COLUMN',@level2name=N'BgBudgetID'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgDokument_BgPosition) => BgPosition.BgPositionID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgDokument', @level2type=N'COLUMN',@level2name=N'BgPositionID'
GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


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
GO