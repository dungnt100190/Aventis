CREATE TABLE [dbo].[XSearchControlTemplateField](
	[XSearchControlTemplateFieldID] [int] IDENTITY(1,1) NOT NULL,
	[XSearchControlTemplateID] [int] NOT NULL,
	[ControlName] [varchar](100) NOT NULL,
	[ControlType] [varchar](100) NOT NULL,
	[Value] [varchar](255) NULL,
	[XSearchControlTemplateFieldTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XSearchControlTemplateField] PRIMARY KEY CLUSTERED 
(
	[XSearchControlTemplateFieldID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[XSearchControlTemplateField]  WITH CHECK ADD  CONSTRAINT [FK_XSearchControlTemplateField_XSearchControlTemplate] FOREIGN KEY([XSearchControlTemplateID])
REFERENCES [dbo].[XSearchControlTemplate] ([XSearchControlTemplateID])
GO
ALTER TABLE [dbo].[XSearchControlTemplateField] CHECK CONSTRAINT [FK_XSearchControlTemplateField_XSearchControlTemplate]