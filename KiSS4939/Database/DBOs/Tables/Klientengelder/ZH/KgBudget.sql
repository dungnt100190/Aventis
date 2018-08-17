CREATE TABLE [dbo].[KgBudget](
	[KgBudgetID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[KgMasterBudgetID] [int] NULL,
	[KgBewilligungCode] [int] NOT NULL,
	[Jahr] [int] NULL,
	[Monat] [int] NULL,
	[BewilligtVon] [datetime] NULL,
	[BewilligtBis] [datetime] NULL,
	[Bemerkung] [text] NULL,
	[KgBudgetTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KgBudget] PRIMARY KEY CLUSTERED 
(
	[KgBudgetID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Index [IX_KgBudget_FaLeistungID]    Script Date: 11/23/2011 16:01:23 ******/
CREATE NONCLUSTERED INDEX [IX_KgBudget_FaLeistungID] ON [dbo].[KgBudget] 
(
	[FaLeistungID] ASC
)
INCLUDE ( [KgMasterBudgetID],
[KgBewilligungCode],
[Monat],
[Jahr]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_KgBudget_KgMasterBudgetID]    Script Date: 11/23/2011 16:01:23 ******/
CREATE NONCLUSTERED INDEX [IX_KgBudget_KgMasterBudgetID] ON [dbo].[KgBudget] 
(
	[KgMasterBudgetID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO
ALTER TABLE [dbo].[KgBudget]  WITH CHECK ADD  CONSTRAINT [FK_KgBudget_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO
ALTER TABLE [dbo].[KgBudget] CHECK CONSTRAINT [FK_KgBudget_FaLeistung]
GO
ALTER TABLE [dbo].[KgBudget]  WITH CHECK ADD  CONSTRAINT [FK_KgBudget_KgBudget] FOREIGN KEY([KgMasterBudgetID])
REFERENCES [dbo].[KgBudget] ([KgBudgetID])
GO
ALTER TABLE [dbo].[KgBudget] CHECK CONSTRAINT [FK_KgBudget_KgBudget]