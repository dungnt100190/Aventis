CREATE TABLE [dbo].[FaZugriff](
	[FaZugriffID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[FaFallID] [int] NULL,
	[FaLeistungID] [int] NULL,
	[FaLeistungCode] [int] NULL,
	[DatumZugriff] [datetime] NOT NULL,
	[FaZugriffTS] [timestamp] NOT NULL,
	[FaZugriffActivityCode] [int] NULL,
	[WinLogonName] [varchar](127) NULL,
	[FaZugriffItemCode] [int] NULL,
	[FaZugriffItemID] [int] NULL,
 CONSTRAINT [PK_FaZugriff] PRIMARY KEY CLUSTERED 
(
	[FaZugriffID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_FaZugriff_UserID]    Script Date: 03/22/2012 10:26:28 ******/
CREATE NONCLUSTERED INDEX [IX_FaZugriff_UserID] ON [dbo].[FaZugriff] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

ALTER TABLE [dbo].[FaZugriff]  WITH CHECK ADD  CONSTRAINT [FK_FaZugriff_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaZugriff] CHECK CONSTRAINT [FK_FaZugriff_XUser]
GO

ALTER TABLE [dbo].[FaZugriff] ADD  CONSTRAINT [DF_FaZugriff_DatumZugriff]  DEFAULT (getdate()) FOR [DatumZugriff]
GO

