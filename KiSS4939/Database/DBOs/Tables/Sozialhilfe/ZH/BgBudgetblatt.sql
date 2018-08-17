CREATE TABLE [dbo].[BgBudgetblatt](
	[BgBudgetblattID] [int] IDENTITY(1,1) NOT NULL,
	[BgBudgetID] [int] NOT NULL,
	[Begleitbrief] [bit] NOT NULL CONSTRAINT [DF__BgBudgetb__Begle__6BCA63B8]  DEFAULT ((1)),
	[Stichworte] [varchar](2000) NULL,
	[AdressatID] [int] NULL,
	[DocumentID] [int] NULL,
	[BgBudgetblattTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BgBudgetblatt] PRIMARY KEY CLUSTERED 
(
	[BgBudgetblattID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_BgBudgetblatt_BgBudgetID]    Script Date: 11/23/2011 11:45:31 ******/
CREATE NONCLUSTERED INDEX [IX_BgBudgetblatt_BgBudgetID] ON [dbo].[BgBudgetblatt] 
(
	[BgBudgetID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_BgBudgetblatt_DocumentID]    Script Date: 11/23/2011 11:45:31 ******/
CREATE NONCLUSTERED INDEX [IX_BgBudgetblatt_DocumentID] ON [dbo].[BgBudgetblatt] 
(
	[DocumentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Trigger [dbo].[BgBudgetblatt_OnDelete]    Script Date: 11/23/2011 11:45:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[BgBudgetblatt_OnDelete]
ON [dbo].[BgBudgetblatt]
AFTER DELETE
AS
	DELETE FROM XDocument WHERE DocumentID IN (SELECT DocumentID FROM deleted WHERE DocumentID IS NOT NULL)

GO
ALTER TABLE [dbo].[BgBudgetblatt]  WITH CHECK ADD  CONSTRAINT [FK_BgBudgetblatt_BgBudget] FOREIGN KEY([BgBudgetID])
REFERENCES [dbo].[BgBudget] ([BgBudgetID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BgBudgetblatt] CHECK CONSTRAINT [FK_BgBudgetblatt_BgBudget]