CREATE TABLE [dbo].[OLD_30_ShBurgergemeindeSupport](
	[BurgergemeindeSupportID] [int] IDENTITY(1,1) NOT NULL,
	[BurgergemeindeID] [int] NOT NULL,
	[Year] [int] NULL,
	[Amount] [money] NULL,
	[ShBurgergemeindeSupportTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_ShBurgergemeindeSupport] PRIMARY KEY NONCLUSTERED 
(
	[BurgergemeindeSupportID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE UNIQUE CLUSTERED INDEX [IX_ShBurgergemeindeSupport] ON [dbo].[OLD_30_ShBurgergemeindeSupport] 
(
	[BurgergemeindeID] ASC,
	[Year] ASC
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OLD_30_ShBurgergemeindeSupport]  WITH CHECK ADD  CONSTRAINT [FK_tcoKissBurgergemeindeSupport_tcoKissBurgergemeinde] FOREIGN KEY([BurgergemeindeID])
REFERENCES [OLD_30_ShBurgergemeinde] ([BurgergemeindeID])
GO

ALTER TABLE [dbo].[OLD_30_ShBurgergemeindeSupport] CHECK CONSTRAINT [FK_tcoKissBurgergemeindeSupport_tcoKissBurgergemeinde]
GO