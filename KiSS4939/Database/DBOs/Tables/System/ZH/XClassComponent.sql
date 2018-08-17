CREATE TABLE [dbo].[XClassComponent](
	[ClassName] [varchar](255) NOT NULL,
	[ComponentName] [varchar](255) NOT NULL,
	[TypeName] [varchar](500) NOT NULL,
	[ComponentTID] [int] NULL,
	[SelectStatement] [text] NULL,
	[TableName] [varchar](255) NULL,
	[PropertiesXML] [text] NULL,
	[System] [bit] NOT NULL CONSTRAINT [DF_XClassComponent_System]  DEFAULT ((0)),
	[XClassComponentTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XClassComponent] PRIMARY KEY CLUSTERED 
(
	[ClassName] ASC,
	[ComponentName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [SYSTEM]
) ON [SYSTEM] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[XClassComponent]  WITH CHECK ADD  CONSTRAINT [FK_XClassComponent_XClass] FOREIGN KEY([ClassName])
REFERENCES [dbo].[XClass] ([ClassName])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[XClassComponent] CHECK CONSTRAINT [FK_XClassComponent_XClass]