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
) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[XClassComponent]  WITH CHECK ADD  CONSTRAINT [FK_XClassComponent_XClass] FOREIGN KEY([ClassName])
REFERENCES [XClass] ([ClassName])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[XClassComponent] CHECK CONSTRAINT [FK_XClassComponent_XClass]
GO