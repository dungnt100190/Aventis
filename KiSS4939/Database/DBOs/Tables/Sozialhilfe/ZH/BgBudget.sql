CREATE TABLE [dbo].[BgBudget](
	[BgBudgetID] [int] IDENTITY(1,1) NOT NULL,
	[BgFinanzplanID] [int] NULL,
	[MasterBudget] [bit] NOT NULL,
	[BgBewilligungStatusCode] [int] NOT NULL,
	[Jahr] [int] NOT NULL,
	[Monat] [int] NOT NULL,
	[BgBudgetTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BgBudget] PRIMARY KEY CLUSTERED 
(
	[BgBudgetID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Index [IX_BgBudget_BgFinanzplanID]    Script Date: 11/23/2011 11:45:17 ******/
CREATE NONCLUSTERED INDEX [IX_BgBudget_BgFinanzplanID] ON [dbo].[BgBudget] 
(
	[BgFinanzplanID] ASC
)
INCLUDE ( [MasterBudget],
[Jahr],
[Monat]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_BgBudget_BgFinanzplanID_BgBudgetID_MasterBudget]    Script Date: 11/23/2011 11:45:17 ******/
CREATE NONCLUSTERED INDEX [IX_BgBudget_BgFinanzplanID_BgBudgetID_MasterBudget] ON [dbo].[BgBudget] 
(
	[BgFinanzplanID] ASC,
	[BgBudgetID] ASC,
	[MasterBudget] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO
ALTER TABLE [dbo].[BgBudget]  WITH CHECK ADD  CONSTRAINT [FK_BgBudget_BgFinanzplan] FOREIGN KEY([BgFinanzplanID])
REFERENCES [dbo].[BgFinanzplan] ([BgFinanzplanID])
GO
ALTER TABLE [dbo].[BgBudget] CHECK CONSTRAINT [FK_BgBudget_BgFinanzplan]