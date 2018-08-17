CREATE TABLE [dbo].[BgBewilligung](
	[BgBewilligungID] [int] IDENTITY(1,1) NOT NULL,
	[BgFinanzplanID] [int] NULL,
	[BgBudgetID] [int] NULL,
	[UserID] [int] NOT NULL,
	[UserID_An] [int] NULL,
	[Datum] [datetime] NOT NULL,
	[BgBewilligungCode] [int] NOT NULL,
	[Bemerkung] [varchar](max) NULL,
	[PerDatum] [datetime] NULL,
	[BgBewilligungTS] [timestamp] NOT NULL,
	[BgPositionID] [int] NULL,
	[UserID_Zustaendig] [int] NULL,
	[OrgUnitID_ChefZustaendig] [int] NULL,
	[Zurueckgewiesen] [bit] NOT NULL,
 CONSTRAINT [PK_BgBewilligung] PRIMARY KEY NONCLUSTERED 
(
	[BgBewilligungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE CLUSTERED INDEX [IX_BgBewilligung] ON [dbo].[BgBewilligung] 
(
	[BgBudgetID] ASC,
	[Datum] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_BgBewilligung_BgPositionID] ON [dbo].[BgBewilligung] 
(
	[BgPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_BgBewilligung_ShFinanzPlanID] ON [dbo].[BgBewilligung] 
(
	[BgFinanzplanID] ASC,
	[Datum] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für BgBewilligung Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgBewilligung', @level2type=N'COLUMN',@level2name=N'BgBewilligungID'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgBewilligung_BgFinanzplan) => BgFinanzplan.BgFinanzplanID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgBewilligung', @level2type=N'COLUMN',@level2name=N'BgFinanzplanID'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgBewilligung_BgBudget) => BgBudget.BgBudgetID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgBewilligung', @level2type=N'COLUMN',@level2name=N'BgBudgetID'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgBewilligung_User) => XUser.UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgBewilligung', @level2type=N'COLUMN',@level2name=N'UserID'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgBewilligung_User_An) => XUser.UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgBewilligung', @level2type=N'COLUMN',@level2name=N'UserID_An'
GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgBewilligung_BgPosition) => BgPosition.BgPositionID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgBewilligung', @level2type=N'COLUMN',@level2name=N'BgPositionID'
GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'UserID vom Benutzer der für diese Aktion zuständig ist, unabhängig von der Stellvertretung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgBewilligung', @level2type=N'COLUMN',@level2name=N'UserID_Zustaendig'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID der Abteilung des Leiters der Abteilung von UserID_Zustaendig.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgBewilligung', @level2type=N'COLUMN',@level2name=N'OrgUnitID_ChefZustaendig'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zum wissen ob die Weiterempfehlung oder die Anfrage zurückgewiesen wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgBewilligung', @level2type=N'COLUMN',@level2name=N'Zurueckgewiesen'
GO

ALTER TABLE [dbo].[BgBewilligung]  WITH CHECK ADD  CONSTRAINT [FK_BgBewilligung_BgBudget] FOREIGN KEY([BgBudgetID])
REFERENCES [dbo].[BgBudget] ([BgBudgetID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BgBewilligung] CHECK CONSTRAINT [FK_BgBewilligung_BgBudget]
GO

ALTER TABLE [dbo].[BgBewilligung]  WITH CHECK ADD  CONSTRAINT [FK_BgBewilligung_BgFinanzplan] FOREIGN KEY([BgFinanzplanID])
REFERENCES [dbo].[BgFinanzplan] ([BgFinanzplanID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BgBewilligung] CHECK CONSTRAINT [FK_BgBewilligung_BgFinanzplan]
GO

ALTER TABLE [dbo].[BgBewilligung]  WITH CHECK ADD  CONSTRAINT [FK_BgBewilligung_BgPosition] FOREIGN KEY([BgPositionID])
REFERENCES [dbo].[BgPosition] ([BgPositionID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BgBewilligung] CHECK CONSTRAINT [FK_BgBewilligung_BgPosition]
GO

ALTER TABLE [dbo].[BgBewilligung]  WITH CHECK ADD  CONSTRAINT [FK_BgBewilligung_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[BgBewilligung] CHECK CONSTRAINT [FK_BgBewilligung_User]
GO

ALTER TABLE [dbo].[BgBewilligung]  WITH CHECK ADD  CONSTRAINT [FK_BgBewilligung_User_An] FOREIGN KEY([UserID_An])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[BgBewilligung] CHECK CONSTRAINT [FK_BgBewilligung_User_An]
GO

ALTER TABLE [dbo].[BgBewilligung]  WITH CHECK ADD  CONSTRAINT [FK_BgBewilligung_XOrgUnit_An] FOREIGN KEY([OrgUnitID_ChefZustaendig])
REFERENCES [dbo].[XOrgUnit] ([OrgUnitID])
GO

ALTER TABLE [dbo].[BgBewilligung] CHECK CONSTRAINT [FK_BgBewilligung_XOrgUnit_An]
GO

ALTER TABLE [dbo].[BgBewilligung]  WITH CHECK ADD  CONSTRAINT [FK_BgBewilligung_XUser_Zustaendig] FOREIGN KEY([UserID_Zustaendig])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[BgBewilligung] CHECK CONSTRAINT [FK_BgBewilligung_XUser_Zustaendig]
GO

ALTER TABLE [dbo].[BgBewilligung] ADD  CONSTRAINT [DF_BgBewilligung_Datum]  DEFAULT (getdate()) FOR [Datum]
GO

ALTER TABLE [dbo].[BgBewilligung] ADD  CONSTRAINT [DF_BgBewilligung_Zurueckgewiesen]  DEFAULT ((0)) FOR [Zurueckgewiesen]
GO