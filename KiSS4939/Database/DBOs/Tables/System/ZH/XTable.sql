﻿CREATE TABLE [dbo].[XTable](
	[TableName] [varchar](255) NOT NULL,
	[Alias] [char](3) NULL,
	[System] [bit] NOT NULL CONSTRAINT [DF_XTable_System]  DEFAULT ((0)),
	[ModulID] [int] NULL,
	[DataWareHouse] [bit] NOT NULL CONSTRAINT [DF_XTable_DataWareHouse]  DEFAULT ((0)),
	[Comment] [varchar](2000) NULL,
	[XTableTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XTable] PRIMARY KEY CLUSTERED 
(
	[TableName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [SYSTEM]
) ON [SYSTEM]

GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[XTable]  WITH CHECK ADD  CONSTRAINT [FK_XTable_XModul] FOREIGN KEY([ModulID])
REFERENCES [dbo].[XModul] ([ModulID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[XTable] CHECK CONSTRAINT [FK_XTable_XModul]