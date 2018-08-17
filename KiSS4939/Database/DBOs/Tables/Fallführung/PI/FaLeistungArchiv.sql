CREATE TABLE [dbo].[FaLeistungArchiv](
	[FaLeistungArchivID] [int] IDENTITY(1,1) NOT NULL,
	[ArchiveID] [int] NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[ArchivNr] [varchar](100) NULL,
	[CheckIn] [datetime] NOT NULL,
	[CheckOut] [datetime] NULL,
	[CheckInUserID] [int] NOT NULL,
	[CheckOutUserID] [int] NULL,
	[FaLeistungArchivTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaLeistungArchiv] PRIMARY KEY CLUSTERED 
(
	[FaLeistungArchivID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_FaLeistungArchiv] ON [dbo].[FaLeistungArchiv] 
(
	[FaLeistungID] ASC,
	[CheckOut] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[FaLeistungArchiv]  WITH CHECK ADD  CONSTRAINT [FK_FaLeistungArchiv_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[FaLeistungArchiv] CHECK CONSTRAINT [FK_FaLeistungArchiv_FaLeistung]
GO

ALTER TABLE [dbo].[FaLeistungArchiv]  WITH CHECK ADD  CONSTRAINT [FK_FaLeistungArchiv_XArchive] FOREIGN KEY([ArchiveID])
REFERENCES [dbo].[XArchive] ([ArchiveID])
GO

ALTER TABLE [dbo].[FaLeistungArchiv] CHECK CONSTRAINT [FK_FaLeistungArchiv_XArchive]
GO

ALTER TABLE [dbo].[FaLeistungArchiv]  WITH CHECK ADD  CONSTRAINT [FK_FaLeistungArchiv_XUser] FOREIGN KEY([CheckInUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaLeistungArchiv] CHECK CONSTRAINT [FK_FaLeistungArchiv_XUser]
GO

ALTER TABLE [dbo].[FaLeistungArchiv]  WITH CHECK ADD  CONSTRAINT [FK_FaLeistungArchiv_XUser1] FOREIGN KEY([CheckOutUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaLeistungArchiv] CHECK CONSTRAINT [FK_FaLeistungArchiv_XUser1]
GO

ALTER TABLE [dbo].[FaLeistungArchiv] ADD  CONSTRAINT [DF_FaLeistungArchiv_CheckIn]  DEFAULT (getdate()) FOR [CheckIn]
GO