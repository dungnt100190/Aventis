SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[XSearchControlTemplate]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[XSearchControlTemplate](
	[XSearchControlTemplateID] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [varchar](255) NULL,
	[UserID] [int] NOT NULL,
	[ModulTreeID] [int] NULL,
	[Name] [varchar](100) NOT NULL,
	[ParentXSearchControlTemplateID] [int] NULL,
	[SortKey] [int] NOT NULL CONSTRAINT [DF_XSearchControlTemplate_SortKey]  DEFAULT ((0)),
	[ColLayout] [varchar](MAX) NULL,
	[SearchImmediately] [bit] NOT NULL CONSTRAINT [DF_XSearchControlTemplate_SearchImmediately]  DEFAULT ((0)),
 CONSTRAINT [PK_XSearchControlTemplate] PRIMARY KEY CLUSTERED 
(
	[XSearchControlTemplateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO



IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_XSearchControlTemplate_XClass]') AND parent_object_id = OBJECT_ID(N'[dbo].[XSearchControlTemplate]'))
ALTER TABLE [dbo].[XSearchControlTemplate]  WITH CHECK ADD  CONSTRAINT [FK_XSearchControlTemplate_XClass] FOREIGN KEY([ClassName])
REFERENCES [dbo].[XClass] ([ClassName])
GO
ALTER TABLE [dbo].[XSearchControlTemplate] CHECK CONSTRAINT [FK_XSearchControlTemplate_XClass]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_XSearchControlTemplate_XModulTree]') AND parent_object_id = OBJECT_ID(N'[dbo].[XSearchControlTemplate]'))
ALTER TABLE [dbo].[XSearchControlTemplate]  WITH CHECK ADD  CONSTRAINT [FK_XSearchControlTemplate_XModulTree] FOREIGN KEY([ModulTreeID])
REFERENCES [dbo].[XModulTree] ([ModulTreeID])
GO
ALTER TABLE [dbo].[XSearchControlTemplate] CHECK CONSTRAINT [FK_XSearchControlTemplate_XModulTree]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_XSearchControlTemplate_XSearchControlTemplate]') AND parent_object_id = OBJECT_ID(N'[dbo].[XSearchControlTemplate]'))
ALTER TABLE [dbo].[XSearchControlTemplate]  WITH CHECK ADD  CONSTRAINT [FK_XSearchControlTemplate_XSearchControlTemplate] FOREIGN KEY([ParentXSearchControlTemplateID])
REFERENCES [dbo].[XSearchControlTemplate] ([XSearchControlTemplateID])
GO
ALTER TABLE [dbo].[XSearchControlTemplate] CHECK CONSTRAINT [FK_XSearchControlTemplate_XSearchControlTemplate]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_XSearchControlTemplate_XUser]') AND parent_object_id = OBJECT_ID(N'[dbo].[XSearchControlTemplate]'))
ALTER TABLE [dbo].[XSearchControlTemplate]  WITH CHECK ADD  CONSTRAINT [FK_XSearchControlTemplate_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[XSearchControlTemplate] CHECK CONSTRAINT [FK_XSearchControlTemplate_XUser]
GO

