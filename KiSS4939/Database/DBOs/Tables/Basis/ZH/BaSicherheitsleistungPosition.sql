CREATE TABLE [dbo].[BaSicherheitsleistungPosition](
	[BaSicherheitsleistungPositionID] [int] IDENTITY(1,1) NOT NULL,
	[BaSicherheitsleistungID] [int] NOT NULL,
	[BaSicherheitsleistungPositionCode] [int] NULL,
	[BgPositionID] [int] NULL,
	[KbBuchungID] [int] NULL,
	[KbBuchungBruttoID] [int] NULL,
	[MigDetailbuchungID] [int] NULL,
 CONSTRAINT [PK_BaSicherheitsleistungPosition] PRIMARY KEY CLUSTERED 
(
	[BaSicherheitsleistungPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Index [IX_BaSicherheitsleistungPosition_BaSicherheitsleistungID]    Script Date: 11/23/2011 10:46:55 ******/
CREATE NONCLUSTERED INDEX [IX_BaSicherheitsleistungPosition_BaSicherheitsleistungID] ON [dbo].[BaSicherheitsleistungPosition] 
(
	[BaSicherheitsleistungID] ASC
)
INCLUDE ( [KbBuchungBruttoID]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_BaSicherheitsleistungPosition_BgPositionID]    Script Date: 11/23/2011 10:46:55 ******/
CREATE NONCLUSTERED INDEX [IX_BaSicherheitsleistungPosition_BgPositionID] ON [dbo].[BaSicherheitsleistungPosition] 
(
	[BgPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_BaSicherheitsleistungPosition_KbBuchungID]    Script Date: 11/23/2011 10:46:55 ******/
CREATE NONCLUSTERED INDEX [IX_BaSicherheitsleistungPosition_KbBuchungID] ON [dbo].[BaSicherheitsleistungPosition] 
(
	[KbBuchungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_BaSicherheitsleistungPosition_MigDetailbuchungID]    Script Date: 11/23/2011 10:46:55 ******/
CREATE NONCLUSTERED INDEX [IX_BaSicherheitsleistungPosition_MigDetailbuchungID] ON [dbo].[BaSicherheitsleistungPosition] 
(
	[MigDetailbuchungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BaSicherheitsleistungPosition]  WITH CHECK ADD  CONSTRAINT [FK_BaSicherheitsleistungPosition_BaSicherheitsleistung] FOREIGN KEY([BaSicherheitsleistungID])
REFERENCES [dbo].[BaSicherheitsleistung] ([BaSicherheitsleistungID])
GO
ALTER TABLE [dbo].[BaSicherheitsleistungPosition] CHECK CONSTRAINT [FK_BaSicherheitsleistungPosition_BaSicherheitsleistung]
GO
ALTER TABLE [dbo].[BaSicherheitsleistungPosition]  WITH CHECK ADD  CONSTRAINT [FK_BaSicherheitsleistungPosition_BgPosition] FOREIGN KEY([BgPositionID])
REFERENCES [dbo].[BgPosition] ([BgPositionID])
GO
ALTER TABLE [dbo].[BaSicherheitsleistungPosition] CHECK CONSTRAINT [FK_BaSicherheitsleistungPosition_BgPosition]
GO
ALTER TABLE [dbo].[BaSicherheitsleistungPosition]  WITH CHECK ADD  CONSTRAINT [FK_BaSicherheitsleistungPosition_KbBuchung] FOREIGN KEY([KbBuchungID])
REFERENCES [dbo].[KbBuchung] ([KbBuchungID])
GO
ALTER TABLE [dbo].[BaSicherheitsleistungPosition] CHECK CONSTRAINT [FK_BaSicherheitsleistungPosition_KbBuchung]
GO
ALTER TABLE [dbo].[BaSicherheitsleistungPosition]  WITH CHECK ADD  CONSTRAINT [FK_BaSicherheitsleistungPosition_MigDetailbuchung] FOREIGN KEY([MigDetailbuchungID])
REFERENCES [dbo].[MigDetailBuchung] ([MigDetailBuchungID])
GO
ALTER TABLE [dbo].[BaSicherheitsleistungPosition] CHECK CONSTRAINT [FK_BaSicherheitsleistungPosition_MigDetailbuchung]