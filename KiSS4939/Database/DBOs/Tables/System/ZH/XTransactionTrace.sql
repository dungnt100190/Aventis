﻿CREATE TABLE [dbo].[XTransactionTrace](
	[XTransactionTraceID] [int] IDENTITY(1,1) NOT NULL,
	[Datum] [datetime] NULL,
	[UserID] [int] NULL,
	[Username] [varchar](100) NULL,
	[Trace] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[XTransactionTraceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON