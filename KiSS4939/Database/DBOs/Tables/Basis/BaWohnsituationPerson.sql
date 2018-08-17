CREATE TABLE [dbo].[BaWohnsituationPerson](
	[BaWohnsituationPersonID] [int] IDENTITY(1,1) NOT NULL,
	[BaWohnsituationID] [int] NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[BaWohnsituationPersonTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaWohnsituationPerson] PRIMARY KEY CLUSTERED 
(
	[BaWohnsituationPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Object:  Index [IX_BaWohnsituationPerson_BaPersonID]    Script Date: 03/22/2012 11:10:30 ******/
CREATE NONCLUSTERED INDEX [IX_BaWohnsituationPerson_BaPersonID] ON [dbo].[BaWohnsituationPerson] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO


/****** Object:  Index [IX_BaWohnsituationPerson_BaPersonID_BaWohnsituationPersonID_BaWohnsituationID]    Script Date: 03/22/2012 11:10:30 ******/
CREATE NONCLUSTERED INDEX [IX_BaWohnsituationPerson_BaPersonID_BaWohnsituationPersonID_BaWohnsituationID] ON [dbo].[BaWohnsituationPerson] 
(
	[BaPersonID] ASC,
	[BaWohnsituationPersonID] ASC,
	[BaWohnsituationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_BaWohnsituationPerson_BaWohnsituationID]    Script Date: 03/22/2012 11:10:30 ******/
CREATE NONCLUSTERED INDEX [IX_BaWohnsituationPerson_BaWohnsituationID] ON [dbo].[BaWohnsituationPerson] 
(
	[BaWohnsituationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BaWohnsituationPerson]  WITH CHECK ADD  CONSTRAINT [FK_BaWohnsituationPerson_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[BaWohnsituationPerson] CHECK CONSTRAINT [FK_BaWohnsituationPerson_BaPerson]
GO

ALTER TABLE [dbo].[BaWohnsituationPerson]  WITH CHECK ADD  CONSTRAINT [FK_BaWohnsituationPerson_BaWohnsituation] FOREIGN KEY([BaWohnsituationID])
REFERENCES [dbo].[BaWohnsituation] ([BaWohnsituationID])
GO

ALTER TABLE [dbo].[BaWohnsituationPerson] CHECK CONSTRAINT [FK_BaWohnsituationPerson_BaWohnsituation]
GO

