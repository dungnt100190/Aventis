CREATE TABLE [dbo].[XMessage](
	[MaskName] [varchar](100) NOT NULL,
	[MessageName] [varchar](100) NOT NULL,
	[MessageTID] [int] NULL,
	[MessageCode] [int] NULL,
	[Context] [varchar](100) NULL,
	[XMessageTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XMessage] PRIMARY KEY CLUSTERED 
(
	[MaskName] ASC,
	[MessageName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [SYSTEM]
) ON [SYSTEM]

GO
SET ANSI_PADDING ON