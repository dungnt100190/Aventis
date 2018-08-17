CREATE TABLE [dbo].[BgBudget](
	[BgBudgetID] [int] IDENTITY(1,1) NOT NULL,
	[BgBewilligungStatusCode] [int] NOT NULL,
	[BgFinanzplanID] [int] NULL,
	[Jahr] [int] NULL,
	[Monat] [int] NULL,
	[Bemerkung] [varchar](max) NULL,
	[OldID] [int] NULL,
	[BgBudgetTS] [timestamp] NOT NULL,
	[MasterBudget] [bit] NOT NULL,
 CONSTRAINT [PK_BgBudget] PRIMARY KEY CLUSTERED 
(
	[BgBudgetID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_BgBudget_BgBudgetTS] ON [dbo].[BgBudget] 
(
	[BgBudgetTS] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


CREATE NONCLUSTERED INDEX [IX_BgBudget_BgFinanzplanID] ON [dbo].[BgBudget] 
(
	[BgFinanzplanID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


CREATE NONCLUSTERED INDEX [IX_BgBudget_BgFinanzplanID_BgBudgetID_MasterBudget] ON [dbo].[BgBudget] 
(
	[BgFinanzplanID] ASC,
	[BgBudgetID] ASC,
	[MasterBudget] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für BgBudget Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgBudget', @level2type=N'COLUMN',@level2name=N'BgBudgetID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgBudget_BgFinanzplan) => BgFinanzplan.BgFinanzplanID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgBudget', @level2type=N'COLUMN',@level2name=N'BgFinanzplanID'
GO

ALTER TABLE [dbo].[BgBudget]  WITH CHECK ADD  CONSTRAINT [FK_BgBudget_BgFinanzplan] FOREIGN KEY([BgFinanzplanID])
REFERENCES [dbo].[BgFinanzplan] ([BgFinanzplanID])
GO

ALTER TABLE [dbo].[BgBudget] CHECK CONSTRAINT [FK_BgBudget_BgFinanzplan]
GO

ALTER TABLE [dbo].[BgBudget] ADD  CONSTRAINT [DF_BgBudget_MasterBudget]  DEFAULT ((0)) FOR [MasterBudget]
GO