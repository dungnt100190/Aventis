﻿CREATE TABLE [dbo].[BFSLOVCode](
	[LOVName] [varchar](100) NOT NULL,
	[Code] [int] NOT NULL,
	[Text] [varchar](200) NOT NULL,
	[TextTID] [int] NULL,
	[KurzText] [varchar](20) NULL,
	[KurzTextTID] [int] NULL,
	[Filter] [varchar](50) NULL,
	[SortKey] [int] NULL,
	[BFSLOVCodeTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BFSLOVCode] PRIMARY KEY CLUSTERED 
(
	[LOVName] ASC,
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[BFSLOVCode]  WITH CHECK ADD  CONSTRAINT [FK_BFSLOVCode_BFSLOV] FOREIGN KEY([LOVName])
REFERENCES [dbo].[BFSLOV] ([LOVName])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BFSLOVCode] CHECK CONSTRAINT [FK_BFSLOVCode_BFSLOV]