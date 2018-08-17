CREATE TABLE [dbo].[BgFinanzplan_BaPerson](
	[BgFinanzplanID] [int] NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[IstUnterstuetzt] [bit] NOT NULL CONSTRAINT [DF_BgFinanzplan_BaPerson_IstUnterstuetzt]  DEFAULT ((1)),
	[BgFinanzplan_BaPersonTS] [timestamp] NOT NULL,
	[BgFinanzplan_BaPersonID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_BgFinanzplan_BaPerson] PRIMARY KEY CLUSTERED 
(
	[BgFinanzplan_BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Index [IX_BgFinanzplan_BaPerson_BaPersonID]    Script Date: 11/23/2011 15:20:51 ******/
CREATE NONCLUSTERED INDEX [IX_BgFinanzplan_BaPerson_BaPersonID] ON [dbo].[BgFinanzplan_BaPerson] 
(
	[BaPersonID] ASC
)
INCLUDE ( [BgFinanzplanID],
[IstUnterstuetzt]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_BgFinanzplan_BaPerson_BgFinanzplanID]    Script Date: 11/23/2011 15:20:51 ******/
CREATE NONCLUSTERED INDEX [IX_BgFinanzplan_BaPerson_BgFinanzplanID] ON [dbo].[BgFinanzplan_BaPerson] 
(
	[BgFinanzplanID] ASC
)
INCLUDE ( [BaPersonID],
[IstUnterstuetzt]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BgFinanzplan_BaPerson]  WITH CHECK ADD  CONSTRAINT [FK_BgFinanzplan_BaPerson_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BgFinanzplan_BaPerson] CHECK CONSTRAINT [FK_BgFinanzplan_BaPerson_BaPerson]
GO
ALTER TABLE [dbo].[BgFinanzplan_BaPerson]  WITH CHECK ADD  CONSTRAINT [FK_BgFinanzplan_BaPerson_BgFinanzplan] FOREIGN KEY([BgFinanzplanID])
REFERENCES [dbo].[BgFinanzplan] ([BgFinanzplanID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BgFinanzplan_BaPerson] CHECK CONSTRAINT [FK_BgFinanzplan_BaPerson_BgFinanzplan]