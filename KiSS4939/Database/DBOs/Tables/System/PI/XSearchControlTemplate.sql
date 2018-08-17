CREATE TABLE [dbo].[XSearchControlTemplate](
	[XSearchControlTemplateID] [int] IDENTITY(1,1) NOT NULL,
	[ParentXSearchControlTemplateID] [int] NULL,
	[ClassName] [varchar](255) NULL,
	[UserID] [int] NULL,
	[ModulTreeID] [int] NULL,
	[Name] [varchar](100) NOT NULL,
	[SortKey] [int] NOT NULL CONSTRAINT [DF_XSearchControlTemplate_SortKey]  DEFAULT ((0)),
	[ColLayout] [varchar](max) NULL,
	[SearchImmediately] [bit] NOT NULL CONSTRAINT [DF_XSearchControlTemplate_SearchImmediately]  DEFAULT ((0)),
	[XSearchControlTemplateTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XSearchControlTemplate] PRIMARY KEY CLUSTERED 
(
	[XSearchControlTemplateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[XSearchControlTemplate]  WITH CHECK ADD  CONSTRAINT [FK_XSearchControlTemplate_XClass] FOREIGN KEY([ClassName])
REFERENCES [dbo].[XClass] ([ClassName])
GO
ALTER TABLE [dbo].[XSearchControlTemplate] CHECK CONSTRAINT [FK_XSearchControlTemplate_XClass]
GO
ALTER TABLE [dbo].[XSearchControlTemplate]  WITH CHECK ADD  CONSTRAINT [FK_XSearchControlTemplate_XModulTree] FOREIGN KEY([ModulTreeID])
REFERENCES [dbo].[XModulTree] ([ModulTreeID])
GO
ALTER TABLE [dbo].[XSearchControlTemplate] CHECK CONSTRAINT [FK_XSearchControlTemplate_XModulTree]
GO
ALTER TABLE [dbo].[XSearchControlTemplate]  WITH CHECK ADD  CONSTRAINT [FK_XSearchControlTemplate_XSearchControlTemplate] FOREIGN KEY([ParentXSearchControlTemplateID])
REFERENCES [dbo].[XSearchControlTemplate] ([XSearchControlTemplateID])
GO
ALTER TABLE [dbo].[XSearchControlTemplate] CHECK CONSTRAINT [FK_XSearchControlTemplate_XSearchControlTemplate]
GO
ALTER TABLE [dbo].[XSearchControlTemplate]  WITH CHECK ADD  CONSTRAINT [FK_XSearchControlTemplate_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[XSearchControlTemplate] CHECK CONSTRAINT [FK_XSearchControlTemplate_XUser]