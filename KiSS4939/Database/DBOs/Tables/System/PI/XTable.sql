CREATE TABLE [dbo].[XTable](
	[TableName] [varchar](255) NOT NULL,
	[Alias] [char](3) NULL,
	[System] [bit] NOT NULL CONSTRAINT [DF_XTable_System]  DEFAULT (0),
	[ModulID] [int] NULL,
	[DataWareHouse] [bit] NOT NULL CONSTRAINT [DF_XTable_DataWareHouse]  DEFAULT (0),
	[Comment] [varchar](2000) NULL,
	[XTableTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XTable] PRIMARY KEY CLUSTERED 
(
	[TableName] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[XTable]  WITH CHECK ADD  CONSTRAINT [FK_XTable_XModul] FOREIGN KEY([ModulID])
REFERENCES [XModul] ([ModulID])
ON UPDATE CASCADE
GO