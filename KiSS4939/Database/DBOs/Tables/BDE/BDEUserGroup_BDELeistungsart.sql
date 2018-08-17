CREATE TABLE [dbo].[BDEUserGroup_BDELeistungsart](
	[BDEUserGroupID] [int] NOT NULL,
	[BDELeistungsartID] [int] NOT NULL,
	[BDEUserGroup_BDELeistungsartTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BDEUserGroup_BDELeisungsart] PRIMARY KEY CLUSTERED 
(
	[BDEUserGroupID] ASC,
	[BDELeistungsartID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[BDEUserGroup_BDELeistungsart] ADD  CONSTRAINT [FK_BDEUserGroup_BDELeisungsart_BDELeistungsart] FOREIGN KEY([BDELeistungsartID])
REFERENCES [BDELeistungsart] ([BDELeistungsartID])
GO

ALTER TABLE [dbo].[BDEUserGroup_BDELeistungsart] CHECK CONSTRAINT [FK_BDEUserGroup_BDELeisungsart_BDELeistungsart]
GO

ALTER TABLE [dbo].[BDEUserGroup_BDELeistungsart] ADD  CONSTRAINT [FK_BDEUserGroup_BDELeisungsart_BDEUserGroup] FOREIGN KEY([BDEUserGroupID])
REFERENCES [BDEUserGroup] ([BDEUserGroupID])
GO

ALTER TABLE [dbo].[BDEUserGroup_BDELeistungsart] CHECK CONSTRAINT [FK_BDEUserGroup_BDELeisungsart_BDEUserGroup]
GO