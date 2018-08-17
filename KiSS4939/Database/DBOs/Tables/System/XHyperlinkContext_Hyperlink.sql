CREATE TABLE [dbo].[XHyperlinkContext_Hyperlink](
	[XHyperlinkContext_HyperlinkID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NULL,
	[SortKey] [int] NULL,
	[FolderName] [varchar](100) NULL,
	[XHyperlinkContextID] [int] NOT NULL,
	[XHyperlinkID] [int] NULL,
	[UserProfileCode] [int] NULL,
	[XHyperlinkContext_HyperlinkTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XHyperlinkContext_Hyperlink] PRIMARY KEY NONCLUSTERED 
(
	[XHyperlinkContext_HyperlinkID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE CLUSTERED INDEX [IX_XHyperlinkContext_Hyperlink] ON [dbo].[XHyperlinkContext_Hyperlink] 
(
	[XHyperlinkContextID] ASC,
	[ParentID] ASC,
	[SortKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für XHyperlinkContext_Hyperlink Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XHyperlinkContext_Hyperlink', @level2type=N'COLUMN',@level2name=N'XHyperlinkContext_HyperlinkID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_XHyperlinkContext_Hyperlink_XHyperlinkContext) => XHyperlinkContext.XHyperlinkContextID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XHyperlinkContext_Hyperlink', @level2type=N'COLUMN',@level2name=N'XHyperlinkContextID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_XHyperlinkContext_Hyperlink_XHyperlink) => XHyperlink.XHyperlinkID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XHyperlinkContext_Hyperlink', @level2type=N'COLUMN',@level2name=N'XHyperlinkID'
GO

ALTER TABLE [dbo].[XHyperlinkContext_Hyperlink]  WITH CHECK ADD  CONSTRAINT [FK_XHyperlinkContext_Hyperlink_XHyperlink] FOREIGN KEY([XHyperlinkID])
REFERENCES [dbo].[XHyperlink] ([XHyperlinkID])
GO

ALTER TABLE [dbo].[XHyperlinkContext_Hyperlink] CHECK CONSTRAINT [FK_XHyperlinkContext_Hyperlink_XHyperlink]
GO

ALTER TABLE [dbo].[XHyperlinkContext_Hyperlink]  WITH CHECK ADD  CONSTRAINT [FK_XHyperlinkContext_Hyperlink_XHyperlinkContext] FOREIGN KEY([XHyperlinkContextID])
REFERENCES [dbo].[XHyperlinkContext] ([XHyperlinkContextID])
GO

ALTER TABLE [dbo].[XHyperlinkContext_Hyperlink] CHECK CONSTRAINT [FK_XHyperlinkContext_Hyperlink_XHyperlinkContext]
GO

ALTER TABLE [dbo].[XHyperlinkContext_Hyperlink]  WITH CHECK ADD  CONSTRAINT [FK_XHyperlinkContext_Hyperlink_XHyperlinkContext_Hyperlink] FOREIGN KEY([ParentID])
REFERENCES [dbo].[XHyperlinkContext_Hyperlink] ([XHyperlinkContext_HyperlinkID])
GO

ALTER TABLE [dbo].[XHyperlinkContext_Hyperlink] CHECK CONSTRAINT [FK_XHyperlinkContext_Hyperlink_XHyperlinkContext_Hyperlink]
GO