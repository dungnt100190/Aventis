CREATE TABLE [dbo].[XClassReference](
	[ClassName] [varchar](255) NOT NULL,
	[ClassName_Ref] [varchar](255) NOT NULL,
	[XClassReferenceTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XClassReference] PRIMARY KEY CLUSTERED 
(
	[ClassName] ASC,
	[ClassName_Ref] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE NONCLUSTERED INDEX [IX_XClassReference] ON [dbo].[XClassReference] 
(
	[ClassName_Ref] ASC
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[XClassReference]  WITH CHECK ADD  CONSTRAINT [FK_XClassReference_XClass] FOREIGN KEY([ClassName])
REFERENCES [XClass] ([ClassName])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[XClassReference] CHECK CONSTRAINT [FK_XClassReference_XClass]
GO

ALTER TABLE [dbo].[XClassReference]  WITH CHECK ADD  CONSTRAINT [FK_XClassReference_XClassRef] FOREIGN KEY([ClassName_Ref])
REFERENCES [XClass] ([ClassName])
GO

ALTER TABLE [dbo].[XClassReference] CHECK CONSTRAINT [FK_XClassReference_XClassRef]
GO