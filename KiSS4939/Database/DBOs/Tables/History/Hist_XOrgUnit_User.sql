CREATE TABLE [dbo].[Hist_XOrgUnit_User](
  [XOrgUnit_UserID] [int] NOT NULL,
	[OrgUnitID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[OrgUnitMemberCode] [int] NOT NULL,
	[MayInsert] [bit] NOT NULL,
	[MayUpdate] [bit] NOT NULL,
	[MayDelete] [bit] NOT NULL,
	[VerID] [int] NOT NULL,
	[VerID_DELETED] [int] NULL,
 CONSTRAINT [PK_Hist_XOrgUnit_User] PRIMARY KEY CLUSTERED 
(
	[OrgUnitID] ASC,
	[UserID] ASC,
	[VerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE NONCLUSTERED INDEX [IX_Hist_XOrgUnit_User_OrgUnitMemberCode] ON [dbo].[Hist_XOrgUnit_User] 
(
	[OrgUnitMemberCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_Hist_XOrgUnit_User_UserID] ON [dbo].[Hist_XOrgUnit_User] 
(
	[UserID] ASC,
	[OrgUnitMemberCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_Hist_XOrgUnit_User_UserIDMemberCodeOrgUnitIDVerID] ON [dbo].[Hist_XOrgUnit_User] 
(
	[UserID] ASC,
	[OrgUnitMemberCode] ASC,
	[OrgUnitID] ASC,
	[VerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO