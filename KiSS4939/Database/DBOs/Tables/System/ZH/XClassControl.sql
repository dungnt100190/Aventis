CREATE TABLE [dbo].[XClassControl](
	[ClassName] [varchar](255) NOT NULL,
	[ControlName] [varchar](255) NOT NULL,
	[ParentControl] [varchar](255) NULL,
	[TypeName] [varchar](255) NOT NULL,
	[ControlTID] [int] NULL,
	[DataMember] [varchar](255) NULL,
	[DataSource] [varchar](255) NULL,
	[LOVName] [varchar](255) NULL,
	[TabIndex] [int] NOT NULL,
	[X] [int] NOT NULL,
	[Y] [int] NOT NULL,
	[Width] [int] NULL,
	[Height] [int] NULL,
	[PropertiesXML] [text] NULL,
	[System] [bit] NOT NULL CONSTRAINT [DF_XClassControl_System]  DEFAULT ((0)),
	[XClassControlTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XClassControl] PRIMARY KEY CLUSTERED 
(
	[ClassName] ASC,
	[ControlName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [SYSTEM]
) ON [SYSTEM] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[XClassControl]  WITH CHECK ADD  CONSTRAINT [FK_XClassControl_XClass] FOREIGN KEY([ClassName])
REFERENCES [dbo].[XClass] ([ClassName])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[XClassControl] CHECK CONSTRAINT [FK_XClassControl_XClass]