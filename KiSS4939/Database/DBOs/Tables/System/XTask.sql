CREATE TABLE [dbo].[XTask](
	[XTaskID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NULL,
	[FaFallID] [int] NULL,
	[FaLeistungID] [int] NULL,
	[UserID_Erledigt] [int] NULL,
	[UserID_InBearbeitung] [int] NULL,
	[FaAktennotizID] [int] NULL,
	[FaDokumenteID] [int] NULL,
	[TaskTypeCode] [int] NULL,
	[TaskStatusCode] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[StartDate] [datetime] NULL,
	[ExpirationDate] [datetime] NULL,
	[DoneDate] [datetime] NULL,
	[Subject] [varchar](100) NULL,
	[TaskDescription] [varchar](2500) NULL,
	[SenderID] [int] NULL,
	[TaskSenderCode] [int] NULL,
	[ReceiverID] [int] NULL,
	[TaskReceiverCode] [int] NULL,
	[ResponseText] [varchar](2500) NULL,
	[TaskResponseCode] [int] NULL,
	[JumpToPath] [varchar](1500) NULL,
	[XTaskTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XTask] PRIMARY KEY CLUSTERED 
(
	[XTaskID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_XTask_FaFallID]    Script Date: 07/27/2012 10:58:52 ******/
CREATE NONCLUSTERED INDEX [IX_XTask_FaFallID] ON [dbo].[XTask] 
(
	[FaFallID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_XTask_FaFallID_XTaskID_CreateDate_TaskSenderCode_BaPersonID]    Script Date: 07/27/2012 10:58:52 ******/
CREATE NONCLUSTERED INDEX [IX_XTask_FaFallID_XTaskID_CreateDate_TaskSenderCode_BaPersonID] ON [dbo].[XTask] 
(
	[FaFallID] ASC,
	[XTaskID] ASC,
	[CreateDate] ASC,
	[TaskSenderCode] ASC,
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_XTask_ReceiverID_TaskReceiverCode_TaskStatusCode_ExpirationDate]    Script Date: 07/27/2012 10:58:52 ******/
CREATE NONCLUSTERED INDEX [IX_XTask_ReceiverID_TaskReceiverCode_TaskStatusCode_ExpirationDate] ON [dbo].[XTask] 
(
	[ReceiverID] ASC,
	[TaskReceiverCode] ASC,
	[TaskStatusCode] ASC,
	[ExpirationDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_XTask_SenderID]    Script Date: 07/27/2012 10:58:52 ******/
CREATE NONCLUSTERED INDEX [IX_XTask_SenderID] ON [dbo].[XTask] 
(
	[SenderID] ASC,
	[TaskSenderCode] ASC,
	[TaskStatusCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_XTask_SenderID_TaskSenderCode_TaskStatusCode_XTaskID_TaskTypeCode_ExpirationDate_ReceiverID_TaskReceiverCode]    Script Date: 07/27/2012 10:58:52 ******/
CREATE NONCLUSTERED INDEX [IX_XTask_SenderID_TaskSenderCode_TaskStatusCode_XTaskID_TaskTypeCode_ExpirationDate_ReceiverID_TaskReceiverCode] ON [dbo].[XTask] 
(
	[SenderID] ASC,
	[TaskSenderCode] ASC,
	[TaskStatusCode] ASC,
	[XTaskID] ASC,
	[TaskTypeCode] ASC,
	[ExpirationDate] ASC,
	[ReceiverID] ASC,
	[TaskReceiverCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_XTask_TaskSenderCode_FaFallID_BaPersonID]    Script Date: 07/27/2012 10:58:52 ******/
CREATE NONCLUSTERED INDEX [IX_XTask_TaskSenderCode_FaFallID_BaPersonID] ON [dbo].[XTask] 
(
	[TaskSenderCode] ASC
)
INCLUDE ( [FaFallID],
[BaPersonID]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_XTask_TaskTypeCode_XTaskID_TaskStatusCode_ReceiverID_TaskReceiverCode]    Script Date: 07/27/2012 10:58:52 ******/
CREATE NONCLUSTERED INDEX [IX_XTask_TaskTypeCode_XTaskID_TaskStatusCode_ReceiverID_TaskReceiverCode] ON [dbo].[XTask] 
(
	[TaskTypeCode] ASC,
	[XTaskID] ASC,
	[TaskStatusCode] ASC,
	[ReceiverID] ASC,
	[TaskReceiverCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_XTask_XTaskID_TaskTypeCode]    Script Date: 07/27/2012 10:58:52 ******/
CREATE NONCLUSTERED INDEX [IX_XTask_XTaskID_TaskTypeCode] ON [dbo].[XTask] 
(
	[XTaskID] ASC,
	[TaskTypeCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für XTask Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTask', @level2type=N'COLUMN',@level2name=N'XTaskID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Foreign Key auf Benutzer, welcher den Task erledigt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTask', @level2type=N'COLUMN',@level2name=N'UserID_Erledigt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Foreign Key auf Benutzer, welcher den Taks in Bearbeitung setzt.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTask', @level2type=N'COLUMN',@level2name=N'UserID_InBearbeitung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Foreign Key auf Aktennotiz' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTask', @level2type=N'COLUMN',@level2name=N'FaAktennotizID'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTask', @level2type=N'COLUMN',@level2name=N'FaAktennotizID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Foreign Key auf Dokument' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTask', @level2type=N'COLUMN',@level2name=N'FaDokumenteID'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTask', @level2type=N'COLUMN',@level2name=N'FaDokumenteID'
GO

ALTER TABLE [dbo].[XTask]  WITH NOCHECK ADD  CONSTRAINT [FK_XTask_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[XTask] CHECK CONSTRAINT [FK_XTask_BaPerson]
GO

ALTER TABLE [dbo].[XTask]  WITH NOCHECK ADD  CONSTRAINT [FK_XTask_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[XTask] CHECK CONSTRAINT [FK_XTask_FaLeistung]
GO

ALTER TABLE [dbo].[XTask]  WITH CHECK ADD  CONSTRAINT [FK_XTask_XUser_Bearbeitung] FOREIGN KEY([UserID_InBearbeitung])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[XTask] CHECK CONSTRAINT [FK_XTask_XUser_Bearbeitung]
GO

ALTER TABLE [dbo].[XTask]  WITH CHECK ADD  CONSTRAINT [FK_XTask_XUser_Erledigt] FOREIGN KEY([UserID_Erledigt])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[XTask] CHECK CONSTRAINT [FK_XTask_XUser_Erledigt]
GO

ALTER TABLE [dbo].[XTask] ADD  CONSTRAINT [DF_XTask_TaskStatusCode]  DEFAULT ((1)) FOR [TaskStatusCode]
GO

ALTER TABLE [dbo].[XTask] ADD  CONSTRAINT [DF_XTask_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
