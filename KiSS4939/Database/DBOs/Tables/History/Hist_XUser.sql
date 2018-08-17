CREATE TABLE [dbo].[Hist_XUser](
	[UserID] [int] NOT NULL,
	[ChiefID] [int] NULL,
	[PrimaryUserID] [int] NULL,
	[PermissionGroupID] [int] NULL,
	[GrantPermGroupID] [int] NULL,
	[XProfileID] [int] NULL,
	[ModulID] [int] NULL,
	[SachbearbeiterID] [int] NULL,
	[MitarbeiterNr] [varchar](50) NULL,
	[LogonName] [varchar](200) NOT NULL,
	[PasswordHash] [varchar](200) NULL,
	[FirstName] [varchar](200) NULL,
	[LastName] [varchar](200) NOT NULL,
	[ShortName] [varchar](10) NULL,
	[IsLocked] [bit] NOT NULL,
	[IsUserAdmin] [bit] NOT NULL,
	[IsUserBIAGAdmin] [bit] NOT NULL,
	[IsMandatsTraeger] [bit] NOT NULL,
	[GenderCode] [int] NULL,
	[Geburtstag] [datetime] NULL,
	[LanguageCode] [int] NULL,
	[Phone] [varchar](100) NULL,
	[PhoneMobile] [varchar](100) NULL,
	[PhoneOffice] [varchar](100) NULL,
	[PhoneIntern] [varchar](100) NULL,
	[PhonePrivat] [varchar](100) NULL,
	[Fax] [varchar](100) NULL,
	[EMail] [varchar](100) NULL,
	[UserProfileCode] [int] NULL,
	[Funktion] [varchar](100) NULL,
	[RoleTitleCode] [int] NULL,
	[QualificationTitleCode] [int] NULL,
	[Bemerkungen] [varchar](1000) NULL,
	[Text1] [varchar](2000) NULL,
	[Text2] [varchar](2000) NULL,
	[JobPercentage] [float] NULL,
	[HoursPerYearForCaseMgmt] [int] NULL,
	[Eintrittsdatum] [datetime] NULL,
	[Austrittsdatum] [datetime] NULL,
	[LohntypCode] [int] NULL,
	[Kostentraeger] [int] NULL,
	[WeitereKostentraeger] [varchar](500) NULL,
	[Kostenart] [int] NULL,
	[KeinBDEExport] [bit] NOT NULL,
	[MigHerkunft] [varchar](50) NULL,
	[MigMAKuerzel] [varchar](50) NULL,
	[MigUserFix] [bit] NOT NULL,
	[visdat36Area] [varchar](255) NULL,
	[visdat36SourceFile] [varchar](255) NULL,
	[visdat36ID] [varchar](50) NULL,
	[visdat36Name] [varchar](255) NULL,
	[VerID] [int] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[VerID_DELETED] [int] NULL,
 CONSTRAINT [PK_Hist_XUser] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[VerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob Benutzer BIAG Super-Administrator ist und somit über alle Rechte verfügt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hist_XUser', @level2type=N'COLUMN',@level2name=N'IsUserBIAGAdmin'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Standard Telefonnummer (wird für PI nicht benutzt, da spezifische Telefonnummern zur Verfügung stehen)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hist_XUser', @level2type=N'COLUMN',@level2name=N'Phone'
GO

ALTER TABLE [dbo].[Hist_XUser] ADD  CONSTRAINT [DF_Hist_XUser_KeinBDEExport]  DEFAULT ((0)) FOR [KeinBDEExport]
GO


