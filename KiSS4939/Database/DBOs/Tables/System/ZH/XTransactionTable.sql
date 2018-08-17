CREATE TABLE [dbo].[XTransactionTable](
	[pkTransaction] [int] IDENTITY(1,1) NOT NULL,
	[TransactionId] [nvarchar](50) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[CallId] [nvarchar](50) NOT NULL,
	[ObjectID] [int] NULL,
	[SendTime] [datetime] NOT NULL,
	[RecieveTime] [datetime] NULL,
	[Message] [nvarchar](250) NULL,
 CONSTRAINT [PK_XTransactionTable] PRIMARY KEY CLUSTERED 
(
	[pkTransaction] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
