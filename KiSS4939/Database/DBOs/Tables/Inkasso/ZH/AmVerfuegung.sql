CREATE TABLE [dbo].[AmVerfuegung](
	[AmVerfuegungID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[Bezeichnung] [varchar](100) NULL,
	[AmVerfuegungStatusCode] [int] NULL,
	[EntscheidDatum] [datetime] NULL,
	[DokumentID] [int] NULL,
	[UserID] [int] NULL,
	[RevisionsDatum] [datetime] NULL,
	[AmVerfuegungTS] [timestamp] NULL,
 CONSTRAINT [PK_AmVerfuegung] PRIMARY KEY CLUSTERED 
(
	[AmVerfuegungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_AmVerfuegung_FaLeistungID]    Script Date: 03/22/2012 10:21:08 ******/
CREATE NONCLUSTERED INDEX [IX_AmVerfuegung_FaLeistungID] ON [dbo].[AmVerfuegung] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_AmVerfuegung_UserID]    Script Date: 03/22/2012 10:21:08 ******/
CREATE NONCLUSTERED INDEX [IX_AmVerfuegung_UserID] ON [dbo].[AmVerfuegung] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AmVerfuegung]  WITH CHECK ADD  CONSTRAINT [FK_AmVerfuegung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[AmVerfuegung] CHECK CONSTRAINT [FK_AmVerfuegung_FaLeistung]
GO

ALTER TABLE [dbo].[AmVerfuegung]  WITH CHECK ADD  CONSTRAINT [FK_AmVerfuegung_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[AmVerfuegung] CHECK CONSTRAINT [FK_AmVerfuegung_XUser]
GO

