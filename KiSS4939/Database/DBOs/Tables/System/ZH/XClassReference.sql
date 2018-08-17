CREATE TABLE [dbo].[XClassReference](
	[ClassName] [varchar](255) NOT NULL,
	[ClassName_Ref] [varchar](255) NOT NULL,
	[XClassReferenceTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XClassReference] PRIMARY KEY CLUSTERED 
(
	[ClassName] ASC,
	[ClassName_Ref] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [SYSTEM]
) ON [SYSTEM]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_XClassReference]    Script Date: 11/23/2011 16:46:10 ******/
CREATE NONCLUSTERED INDEX [IX_XClassReference] ON [dbo].[XClassReference] 
(
	[ClassName_Ref] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [SYSTEM]
GO
ALTER TABLE [dbo].[XClassReference]  WITH CHECK ADD  CONSTRAINT [FK_XClassReference_XClass] FOREIGN KEY([ClassName])
REFERENCES [dbo].[XClass] ([ClassName])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[XClassReference] CHECK CONSTRAINT [FK_XClassReference_XClass]
GO
ALTER TABLE [dbo].[XClassReference]  WITH CHECK ADD  CONSTRAINT [FK_XClassReference_XClassRef] FOREIGN KEY([ClassName_Ref])
REFERENCES [dbo].[XClass] ([ClassName])
GO
ALTER TABLE [dbo].[XClassReference] CHECK CONSTRAINT [FK_XClassReference_XClassRef]