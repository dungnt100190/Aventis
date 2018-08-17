CREATE TABLE [dbo].[OLD_30_ShBeleg](
	[ShBelegID] [int] IDENTITY(1,1) NOT NULL,
	[BgBudgetID] [int] NULL,
	[BelegKlientDirekt] [bit] NOT NULL CONSTRAINT [DF_ShBeleg_BelegKlientDirekt]  DEFAULT (0),
	[ShBelegTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_ShBeleg] PRIMARY KEY NONCLUSTERED 
(
	[ShBelegID] ASC
) ON [PRIMARY],
 CONSTRAINT [IXU_ShBeleg_ShBelegID] UNIQUE NONCLUSTERED 
(
	[ShBelegID] ASC,
	[BgBudgetID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE CLUSTERED INDEX [IX_ShBeleg] ON [dbo].[OLD_30_ShBeleg] 
(
	[BgBudgetID] ASC,
	[BelegKlientDirekt] ASC
) ON [PRIMARY]
GO