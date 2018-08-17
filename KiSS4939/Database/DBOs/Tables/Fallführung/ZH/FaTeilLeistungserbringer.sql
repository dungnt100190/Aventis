CREATE TABLE [dbo].[FaTeilLeistungserbringer](
	[FaLeistungserbringerID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[UserID] [int] NOT NULL,
	[Bemerkung] [text] NULL,
	[FaTeilLeistungserbringerTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaTeilLeistungserbringer] PRIMARY KEY CLUSTERED 
(
	[FaLeistungserbringerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Index [IX_FaTeilLeistungserbringer_FaLeistungID]    Script Date: 11/23/2011 15:04:16 ******/
CREATE NONCLUSTERED INDEX [IX_FaTeilLeistungserbringer_FaLeistungID] ON [dbo].[FaTeilLeistungserbringer] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaTeilLeistungserbringer_UserID]    Script Date: 11/23/2011 15:04:16 ******/
CREATE NONCLUSTERED INDEX [IX_FaTeilLeistungserbringer_UserID] ON [dbo].[FaTeilLeistungserbringer] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FaTeilLeistungserbringer]  WITH CHECK ADD  CONSTRAINT [FK_FaTeilLeistungserbringer_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO
ALTER TABLE [dbo].[FaTeilLeistungserbringer] CHECK CONSTRAINT [FK_FaTeilLeistungserbringer_FaLeistung]
GO
ALTER TABLE [dbo].[FaTeilLeistungserbringer]  WITH CHECK ADD  CONSTRAINT [FK_FaTeilLeistungserbringer_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[FaTeilLeistungserbringer] CHECK CONSTRAINT [FK_FaTeilLeistungserbringer_XUser]