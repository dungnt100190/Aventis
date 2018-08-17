CREATE TABLE [dbo].[FaVoranmeldung](
	[FaVoranmeldungID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[Datum] [datetime] NOT NULL,
	[UserID] [int] NULL,
	[StelleName] [varchar](200) NULL,
	[StelleTypCode] [int] NULL,
	[StelleTelefon] [varchar](100) NULL,
	[StelleEMail] [varchar](100) NULL,
	[FeedbackDatumBis] [datetime] NULL,
	[FeedbackUserID] [int] NULL,
	[FeedbackErteiltAm] [datetime] NULL,
	[FeedbackErteiltUserID] [int] NULL,
	[FaVoranmeldungAbschlussgrundCode] [int] NULL,
	[TaskID] [int] NULL,
	[Bemerkung] [varchar](1000) NULL,
	[FaVoranmeldungTS] [timestamp] NULL,
 CONSTRAINT [PK_FaVoranmeldung] PRIMARY KEY CLUSTERED 
(
	[FaVoranmeldungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_FaVoranmeldung_FeedbackErteiltUserID]    Script Date: 03/22/2012 10:25:00 ******/
CREATE NONCLUSTERED INDEX [IX_FaVoranmeldung_FeedbackErteiltUserID] ON [dbo].[FaVoranmeldung] 
(
	[FeedbackErteiltUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaVoranmeldung_FeedbackUserID]    Script Date: 03/22/2012 10:25:00 ******/
CREATE NONCLUSTERED INDEX [IX_FaVoranmeldung_FeedbackUserID] ON [dbo].[FaVoranmeldung] 
(
	[FeedbackUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaVoranmeldung_TaskID]    Script Date: 03/22/2012 10:25:00 ******/
CREATE NONCLUSTERED INDEX [IX_FaVoranmeldung_TaskID] ON [dbo].[FaVoranmeldung] 
(
	[TaskID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaVoranmeldung_FaLeistungID]    Script Date: 03/22/2012 10:25:00 ******/
CREATE NONCLUSTERED INDEX [IX_FaVoranmeldung_FaLeistungID] ON [dbo].[FaVoranmeldung] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaVoranmeldung_UserID]    Script Date: 03/22/2012 10:25:00 ******/
CREATE NONCLUSTERED INDEX [IX_FaVoranmeldung_UserID] ON [dbo].[FaVoranmeldung] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

ALTER TABLE [dbo].[FaVoranmeldung]  WITH CHECK ADD  CONSTRAINT [FK_FaVoranmeldung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[FaVoranmeldung] CHECK CONSTRAINT [FK_FaVoranmeldung_FaLeistung]
GO

ALTER TABLE [dbo].[FaVoranmeldung]  WITH CHECK ADD  CONSTRAINT [FK_FaVoranmeldung_FeedbackErteiltUser] FOREIGN KEY([FeedbackErteiltUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaVoranmeldung] CHECK CONSTRAINT [FK_FaVoranmeldung_FeedbackErteiltUser]
GO

ALTER TABLE [dbo].[FaVoranmeldung]  WITH CHECK ADD  CONSTRAINT [FK_FaVoranmeldung_XTask] FOREIGN KEY([TaskID])
REFERENCES [dbo].[XTask] ([XTaskID])
GO

ALTER TABLE [dbo].[FaVoranmeldung] CHECK CONSTRAINT [FK_FaVoranmeldung_XTask]
GO

ALTER TABLE [dbo].[FaVoranmeldung]  WITH CHECK ADD  CONSTRAINT [FK_FaVoranmeldung_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaVoranmeldung] CHECK CONSTRAINT [FK_FaVoranmeldung_XUser]
GO

ALTER TABLE [dbo].[FaVoranmeldung]  WITH CHECK ADD  CONSTRAINT [FK_FaVoranmeldung_XUser_Feedback] FOREIGN KEY([FeedbackUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaVoranmeldung] CHECK CONSTRAINT [FK_FaVoranmeldung_XUser_Feedback]
GO

