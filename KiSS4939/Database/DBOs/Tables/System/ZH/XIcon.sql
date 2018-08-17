﻿CREATE TABLE [dbo].[XIcon](
	[XIconID] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Icon] [image] NULL,
	[XIconTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XICON] PRIMARY KEY CLUSTERED 
(
	[XIconID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [SYSTEM]
) ON [SYSTEM] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON