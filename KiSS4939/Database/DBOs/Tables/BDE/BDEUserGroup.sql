CREATE TABLE [dbo].[BDEUserGroup](
	[BDEUserGroupID] [int] IDENTITY(1,1) NOT NULL,
	[UserGroupName] [varchar](100) NOT NULL,
	[UserGroupNameTID] [int] NULL,
	[Beschreibung] [varchar](1000) NULL,
	[BDEUserGroupTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BDEUserGroup] PRIMARY KEY CLUSTERED 
(
	[BDEUserGroupID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO