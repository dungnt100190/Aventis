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
) ON [PRIMARY]
) ON [PRIMARY]

GO