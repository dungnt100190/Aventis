CREATE TABLE [dbo].[Hist_XOrgUnit](
	[OrgUnitID] [int] NOT NULL,
	[ParentID] [int] NULL,
	[ModulID] [int] NULL,
	[ChiefID] [int] NULL,
	[RechtsdienstUserID] [int] NULL,
	[RepresentativeID] [int] NULL,
	[StellvertreterID] [int] NULL,
	[XProfileID] [int] NULL,
	[ItemName] [varchar](100) NOT NULL,
	[OEItemTypCode] [int] NULL,
	[ParentPosition] [int] NULL,
	[Kostenstelle] [int] NULL,
	[Mandantennummer] [int] NULL,
	[StundenLohnlaufNr] [int] NULL,
	[LeistungLohnlaufNr] [int] NULL,
	[Sammelkonto] [int] NULL,
	[PCKonto] [varchar](100) NULL,
	[AD_Abteilung] [varchar](2000) NULL,
	[Logo] [varchar](max) NULL,
	[Adressat] [varchar](2000) NULL,
	[Adresse] [varchar](2000) NULL,
	[AdresseKGS] [varchar](100) NULL,
	[AdresseAbteilung] [varchar](100) NULL,
	[AdresseStrasse] [varchar](100) NULL,
	[Postfach] [varchar](100) NULL,
	[PostfachOhneNr] [bit] NOT NULL,
	[AdresseHausNr] [varchar](10) NULL,
	[AdressePLZ] [varchar](10) NULL,
	[AdresseOrt] [varchar](50) NULL,
	[Phone] [varchar](100) NULL,
	[Telefon] [varchar](100) NULL,
	[Fax] [varchar](100) NULL,
	[EMail] [varchar](100) NULL,
	[WWW] [varchar](100) NULL,
	[Internet] [varchar](100) NULL,
	[UserProfileCode] [int] NULL,
	[Text1] [varchar](2000) NULL,
	[Text2] [varchar](2000) NULL,
	[Text3] [varchar](2000) NULL,
	[Text4] [varchar](2000) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[VerID] [int] NOT NULL,
	[VerID_DELETED] [int] NULL,
 CONSTRAINT [PK_Hist_XOrgUnit] PRIMARY KEY CLUSTERED 
(
	[OrgUnitID] ASC,
	[VerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_Hist_XOrgUnit_ChiefID] ON [dbo].[Hist_XOrgUnit] 
(
	[ChiefID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_Hist_XOrgUnit_Kostenstelle] ON [dbo].[Hist_XOrgUnit] 
(
	[Kostenstelle] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_Hist_XOrgUnit_Mandantennummer] ON [dbo].[Hist_XOrgUnit] 
(
	[Mandantennummer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_Hist_XOrgUnit_OEItemTypCode] ON [dbo].[Hist_XOrgUnit] 
(
	[OEItemTypCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_Hist_XOrgUnit_OrgUnitID] ON [dbo].[Hist_XOrgUnit] 
(
	[OrgUnitID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_Hist_XOrgUnit_OrgUnitID_VerID_Kostenstelle] ON [dbo].[Hist_XOrgUnit] 
(
	[OrgUnitID] ASC,
	[VerID] ASC,
	[Kostenstelle] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_Hist_XOrgUnit_ParentID] ON [dbo].[Hist_XOrgUnit] 
(
	[ParentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_Hist_XOrgUnit_ParentID_MandantenNr_VerID_OrgUnitID] ON [dbo].[Hist_XOrgUnit] 
(
	[ParentID] ASC,
	[Mandantennummer] ASC,
	[VerID] ASC,
	[OrgUnitID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_Hist_XOrgUnit_RepresentativeID] ON [dbo].[Hist_XOrgUnit] 
(
	[RepresentativeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO