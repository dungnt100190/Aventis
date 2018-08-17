
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[XSearchControlTemplateField]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[XSearchControlTemplateField](
	[XSearchControlTemplateFieldID] [int] IDENTITY(1,1) NOT NULL,
	[XSearchControlTemplateID] [int] NOT NULL,
	[ControlName] [varchar](100) NOT NULL,
	[ControlType] [varchar](100) NOT NULL,
	[Value] [varchar](255) NULL,
 CONSTRAINT [PK_XSearchControlTemplateField] PRIMARY KEY CLUSTERED 
(
	[XSearchControlTemplateFieldID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO



IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_XSearchControlTemplateField_XSearchControlTemplate]') AND parent_object_id = OBJECT_ID(N'[dbo].[XSearchControlTemplateField]'))
ALTER TABLE [dbo].[XSearchControlTemplateField]  WITH CHECK ADD  CONSTRAINT [FK_XSearchControlTemplateField_XSearchControlTemplate] FOREIGN KEY([XSearchControlTemplateID])
REFERENCES [dbo].[XSearchControlTemplate] ([XSearchControlTemplateID])
GO
ALTER TABLE [dbo].[XSearchControlTemplateField] CHECK CONSTRAINT [FK_XSearchControlTemplateField_XSearchControlTemplate]
GO
