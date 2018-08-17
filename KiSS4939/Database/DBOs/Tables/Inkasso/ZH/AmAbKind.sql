CREATE TABLE [dbo].[AmAbKind](
	[AmAbKindID] [int] IDENTITY(1,1) NOT NULL,
	[AmAnspruchsberechnungID] [int] NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[BerechtigtCode] [int] NOT NULL CONSTRAINT [DF_AmAbKind_BerechtigtCode]  DEFAULT ((9)),
	[DatumBis] [datetime] NULL,
	[IkRechtstitelID] [int] NULL,
	[AmAbKindTS] [timestamp] NULL,
 CONSTRAINT [PK_AmAbKind] PRIMARY KEY CLUSTERED 
(
	[AmAbKindID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Index [IX_AmAbKind_AmAnspruchsberechnungID]    Script Date: 11/23/2011 10:31:02 ******/
CREATE NONCLUSTERED INDEX [IX_AmAbKind_AmAnspruchsberechnungID] ON [dbo].[AmAbKind] 
(
	[AmAnspruchsberechnungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_AmAbKind_BaPersonID]    Script Date: 11/23/2011 10:31:02 ******/
CREATE NONCLUSTERED INDEX [IX_AmAbKind_BaPersonID] ON [dbo].[AmAbKind] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_AmAbKind_IkRechtstitelID]    Script Date: 11/23/2011 10:31:02 ******/
CREATE NONCLUSTERED INDEX [IX_AmAbKind_IkRechtstitelID] ON [dbo].[AmAbKind] 
(
	[IkRechtstitelID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AmAbKind]  WITH CHECK ADD  CONSTRAINT [FK_AmAbKind_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[AmAbKind] CHECK CONSTRAINT [FK_AmAbKind_BaPerson]
GO
ALTER TABLE [dbo].[AmAbKind]  WITH CHECK ADD  CONSTRAINT [FK_AmAbKind_IkRechtstitel] FOREIGN KEY([IkRechtstitelID])
REFERENCES [dbo].[IkRechtstitel] ([IkRechtstitelID])
GO
ALTER TABLE [dbo].[AmAbKind] CHECK CONSTRAINT [FK_AmAbKind_IkRechtstitel]
GO
ALTER TABLE [dbo].[AmAbKind]  WITH CHECK ADD  CONSTRAINT [FK_AmAnspruchsberechnungKind_AmAnspruchsberechnung] FOREIGN KEY([AmAnspruchsberechnungID])
REFERENCES [dbo].[AmAnspruchsberechnung] ([AmAnspruchsberechnungID])
GO
ALTER TABLE [dbo].[AmAbKind] CHECK CONSTRAINT [FK_AmAnspruchsberechnungKind_AmAnspruchsberechnung]