CREATE TABLE [dbo].[XQueryContext](
	[QueryContextID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NULL,
	[ParentPosition] [int] NULL,
	[FolderName] [varchar](100) NULL,
	[QueryCode] [int] NOT NULL,
	[QueryName] [varchar](100) NULL,
	[XQueryContextTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XQueryContext] PRIMARY KEY NONCLUSTERED 
(
	[QueryContextID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [SYSTEM]
) ON [SYSTEM]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_XQueryContext]    Script Date: 11/23/2011 17:02:12 ******/
CREATE CLUSTERED INDEX [IX_XQueryContext] ON [dbo].[XQueryContext] 
(
	[ParentID] ASC,
	[ParentPosition] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [SYSTEM]
GO
ALTER TABLE [dbo].[XQueryContext]  WITH CHECK ADD  CONSTRAINT [FK_XQueryContext_XQueryContext] FOREIGN KEY([ParentID])
REFERENCES [dbo].[XQueryContext] ([QueryContextID])
GO
ALTER TABLE [dbo].[XQueryContext] CHECK CONSTRAINT [FK_XQueryContext_XQueryContext]