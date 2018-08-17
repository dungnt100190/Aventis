CREATE TABLE [dbo].[XUser](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
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
	[VerID] [int] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[XUserTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XUser] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_XUser_LogonName] UNIQUE NONCLUSTERED 
(
	[LogonName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_XUser_ChiefID]    Script Date: 03/22/2012 11:16:18 ******/
CREATE NONCLUSTERED INDEX [IX_XUser_ChiefID] ON [dbo].[XUser] 
(
	[ChiefID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_XUser_GrantPermGroupID]    Script Date: 03/22/2012 11:16:18 ******/
CREATE NONCLUSTERED INDEX [IX_XUser_GrantPermGroupID] ON [dbo].[XUser] 
(
	[GrantPermGroupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_XUser_IsLocked]    Script Date: 03/22/2012 11:16:18 ******/
CREATE NONCLUSTERED INDEX [IX_XUser_IsLocked] ON [dbo].[XUser] 
(
	[IsLocked] ASC
)
INCLUDE ( [UserID],
[LogonName],
[FirstName],
[LastName]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_XUser_LastName_FirstName]    Script Date: 03/22/2012 11:16:18 ******/
CREATE NONCLUSTERED INDEX [IX_XUser_LastName_FirstName] ON [dbo].[XUser] 
(
	[LastName] ASC,
	[FirstName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_XUser_PermissionGroupID]    Script Date: 03/22/2012 11:16:18 ******/
CREATE NONCLUSTERED INDEX [IX_XUser_PermissionGroupID] ON [dbo].[XUser] 
(
	[PermissionGroupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_XUser_PrimaryUserID]    Script Date: 03/22/2012 11:16:18 ******/
CREATE NONCLUSTERED INDEX [IX_XUser_PrimaryUserID] ON [dbo].[XUser] 
(
	[PrimaryUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_XUser_SachbearbeiterID]    Script Date: 03/22/2012 11:16:18 ******/
CREATE NONCLUSTERED INDEX [IX_XUser_SachbearbeiterID] ON [dbo].[XUser] 
(
	[SachbearbeiterID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_XUser_UserID_IsUserAdmin_IsUserBIAGAdmin]    Script Date: 03/22/2012 11:16:18 ******/
CREATE NONCLUSTERED INDEX [IX_XUser_UserID_IsUserAdmin_IsUserBIAGAdmin] ON [dbo].[XUser] 
(
	[UserID] ASC,
	[IsUserAdmin] ASC,
	[IsUserBIAGAdmin] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_XUser_UserID_LastName_FirstName_LogonName]    Script Date: 03/22/2012 11:16:18 ******/
CREATE NONCLUSTERED INDEX [IX_XUser_UserID_LastName_FirstName_LogonName] ON [dbo].[XUser] 
(
	[UserID] ASC,
	[LastName] ASC,
	[FirstName] ASC,
	[LogonName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_XUser_UserID_LastName_FirstName_ShortName_LogonName]    Script Date: 03/22/2012 11:16:18 ******/
CREATE NONCLUSTERED INDEX [IX_XUser_UserID_LastName_FirstName_ShortName_LogonName] ON [dbo].[XUser] 
(
	[UserID] ASC,
	[LastName] ASC,
	[FirstName] ASC,
	[ShortName] ASC,
	[LogonName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_XUser_UserID_MitarbeiterNr_FirstName_LastName_IsUserAdmin]    Script Date: 03/22/2012 11:16:18 ******/
CREATE NONCLUSTERED INDEX [IX_XUser_UserID_MitarbeiterNr_FirstName_LastName_IsUserAdmin] ON [dbo].[XUser] 
(
	[UserID] ASC,
	[MitarbeiterNr] ASC,
	[FirstName] ASC,
	[LastName] ASC,
	[IsUserAdmin] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_XUser_UserID_MitarbeiterNr_FirstName_LastName_LohntypCode]    Script Date: 03/22/2012 11:16:18 ******/
CREATE NONCLUSTERED INDEX [IX_XUser_UserID_MitarbeiterNr_FirstName_LastName_LohntypCode] ON [dbo].[XUser] 
(
	[UserID] ASC,
	[MitarbeiterNr] ASC,
	[FirstName] ASC,
	[LastName] ASC,
	[LohntypCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_XUser_XProfileID]    Script Date: 03/22/2012 11:16:18 ******/
CREATE NONCLUSTERED INDEX [IX_XUser_XProfileID] ON [dbo].[XUser] 
(
	[XProfileID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Default Profil für die Dokumentgeneration.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser', @level2type=N'COLUMN',@level2name=N'XProfileID'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser', @level2type=N'COLUMN',@level2name=N'MitarbeiterNr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob Benutzer BIAG Super-Administrator ist und somit über alle Rechte verfügt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser', @level2type=N'COLUMN',@level2name=N'IsUserBIAGAdmin'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Standard Telefonnummer (wird für PI nicht benutzt, da spezifische Telefonnummern zur Verfügung stehen)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser', @level2type=N'COLUMN',@level2name=N'Phone'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Benutzerprofil (TODO: XProfileID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser', @level2type=N'COLUMN',@level2name=N'UserProfileCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Freitext 1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser', @level2type=N'COLUMN',@level2name=N'Text1'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Freitext 2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser', @level2type=N'COLUMN',@level2name=N'Text2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Spalte um weiter Kostenträger zu erfassen (Int komma separiert)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser', @level2type=N'COLUMN',@level2name=N'WeitereKostentraeger'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag für die Stundenlohn- und Leistungsdaten-Schnittstelle. Erfasste Leistungen eines Benutzers mit BDEExport = 1 werden nicht über die Schnittstelle exportiert.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser', @level2type=N'COLUMN',@level2name=N'KeinBDEExport'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser', @level2type=N'COLUMN',@level2name=N'XUserTS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabelle für KiSS Benutzer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser'
GO

/****** Object:  Trigger [dbo].[trHist_XUser]    Script Date: 03/22/2012 11:16:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE TRIGGER [dbo].[trHist_XUser]
  ON [dbo].[XUser]
  FOR INSERT, UPDATE, DELETE
AS BEGIN
  SET NOCOUNT ON
  DECLARE @VerID     INT

  SELECT TOP 1 @VerID = VerID FROM HistoryVersion
  WHERE SessionID = @@SPID AND DateDiff(n, VersionDate, GetDate()) < 60
  ORDER BY VerID DESC

  IF @VerID IS NULL BEGIN
    RAISERROR ('Table [XUser] is under Version Control you must first create a new HistoryVersion entry', 16, 1)
    ROLLBACK TRANSACTION
  END

  DECLARE @Changes TABLE (
    [UserID] int NOT NULL,
    VerID         int NULL,
    ActionCode    int NOT NULL
    PRIMARY KEY (ActionCode, [UserID])
  )

  INSERT INTO @Changes
    SELECT IsNull(INS.[UserID], DEL.[UserID]), TBL.VerID,
      CASE WHEN (INS.[UserID] IS NULL) THEN 3 WHEN (DEL.[UserID] IS NULL) THEN 1 ELSE 2 END
    FROM INSERTED                                INS
      FULL OUTER JOIN DELETED                    DEL ON DEL.[UserID] = INS.[UserID]
      LEFT       JOIN [Hist_XUser]  TBL ON TBL.[UserID] = DEL.[UserID] AND TBL.VerID_DELETED IS NULL
    WHERE (INS.[UserID] IS NULL) OR (DEL.[UserID] IS NULL)
      OR CHECKSUM(INS.[UserID], INS.[ChiefID], INS.[PrimaryUserID], INS.[PermissionGroupID], INS.[GrantPermGroupID], INS.[XProfileID], INS.[ModulID], INS.[SachbearbeiterID], INS.[MitarbeiterNr], INS.[LogonName], INS.[PasswordHash], INS.[FirstName], INS.[LastName], INS.[ShortName], INS.[IsLocked], INS.[IsUserAdmin], INS.[IsUserBIAGAdmin], INS.[IsMandatsTraeger], INS.[GenderCode], INS.[Geburtstag], INS.[LanguageCode], INS.[Phone], INS.[PhoneOffice], INS.[PhoneIntern], INS.[PhonePrivat], INS.[EMail], INS.[UserProfileCode], INS.[Funktion], INS.[Bemerkungen], INS.[Text1], INS.[Text2], INS.[JobPercentage], INS.[HoursPerYearForCaseMgmt], INS.[Eintrittsdatum], INS.[Austrittsdatum], INS.[LohntypCode], INS.[Kostentraeger], INS.[WeitereKostentraeger], INS.[Kostenart], INS.[KeinBDEExport], INS.[MigHerkunft], INS.[MigMAKuerzel], INS.[MigUserFix], INS.[visdat36Area], INS.[visdat36SourceFile], INS.[visdat36ID], INS.[visdat36Name], INS.[Creator], INS.[Created], INS.[Modifier], INS.[Modified])
      <> CHECKSUM(TBL.[UserID], TBL.[ChiefID], TBL.[PrimaryUserID], TBL.[PermissionGroupID], TBL.[GrantPermGroupID], TBL.[XProfileID], TBL.[ModulID], TBL.[SachbearbeiterID], TBL.[MitarbeiterNr], TBL.[LogonName], TBL.[PasswordHash], TBL.[FirstName], TBL.[LastName], TBL.[ShortName], TBL.[IsLocked], TBL.[IsUserAdmin], TBL.[IsUserBIAGAdmin], TBL.[IsMandatsTraeger], TBL.[GenderCode], TBL.[Geburtstag], TBL.[LanguageCode], TBL.[Phone], TBL.[PhoneOffice], TBL.[PhoneIntern], TBL.[PhonePrivat], TBL.[EMail], TBL.[UserProfileCode], TBL.[Funktion], TBL.[Bemerkungen], TBL.[Text1], TBL.[Text2], TBL.[JobPercentage], TBL.[HoursPerYearForCaseMgmt], TBL.[Eintrittsdatum], TBL.[Austrittsdatum], TBL.[LohntypCode], TBL.[Kostentraeger], TBL.[WeitereKostentraeger], TBL.[Kostenart], TBL.[KeinBDEExport], TBL.[MigHerkunft], TBL.[MigMAKuerzel], TBL.[MigUserFix], TBL.[visdat36Area], TBL.[visdat36SourceFile], TBL.[visdat36ID], TBL.[visdat36Name], TBL.[Creator], TBL.[Created], TBL.[Modifier], TBL.[Modified])
     
     

  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode = 2)
    DELETE TBL
    FROM [Hist_XUser]  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode = 2 AND UPD.[UserID] = TBL.[UserID]
    WHERE TBL.VerID = @VerID

  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode > 1)
    UPDATE TBL
      SET VerID_DELETED = @VerID
    FROM [Hist_XUser]  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode > 1 AND UPD.[UserID] = TBL.[UserID] AND UPD.VerID = TBL.VerID

  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode < 3) BEGIN
    INSERT INTO Hist_XUser ([UserID], [ChiefID], [PrimaryUserID], [PermissionGroupID], [GrantPermGroupID], [XProfileID], [ModulID], [SachbearbeiterID], [MitarbeiterNr], [LogonName], [PasswordHash], [FirstName], [LastName], [ShortName], [IsLocked], [IsUserAdmin], [IsUserBIAGAdmin], [IsMandatsTraeger], [GenderCode], [Geburtstag], [LanguageCode], [Phone], [PhoneOffice], [PhoneIntern], [PhonePrivat], [EMail], [UserProfileCode], [Funktion], [Bemerkungen], [Text1], [Text2], [JobPercentage], [HoursPerYearForCaseMgmt], [Eintrittsdatum], [Austrittsdatum], [LohntypCode], [Kostentraeger], [WeitereKostentraeger], [Kostenart], [KeinBDEExport], [MigHerkunft], [MigMAKuerzel], [MigUserFix], [visdat36Area], [visdat36SourceFile], [visdat36ID], [visdat36Name], [Creator], [Created], [Modifier], [Modified], VerID)
      SELECT TBL.[UserID], TBL.[ChiefID], TBL.[PrimaryUserID], TBL.[PermissionGroupID], TBL.[GrantPermGroupID], TBL.[XProfileID], TBL.[ModulID], TBL.[SachbearbeiterID], TBL.[MitarbeiterNr], TBL.[LogonName], TBL.[PasswordHash], TBL.[FirstName], TBL.[LastName], TBL.[ShortName], TBL.[IsLocked], TBL.[IsUserAdmin], TBL.[IsUserBIAGAdmin], TBL.[IsMandatsTraeger], TBL.[GenderCode], TBL.[Geburtstag], TBL.[LanguageCode], TBL.[Phone], TBL.[PhoneOffice], TBL.[PhoneIntern], TBL.[PhonePrivat], TBL.[EMail], TBL.[UserProfileCode], TBL.[Funktion], TBL.[Bemerkungen], TBL.[Text1], TBL.[Text2], TBL.[JobPercentage], TBL.[HoursPerYearForCaseMgmt], TBL.[Eintrittsdatum], TBL.[Austrittsdatum], TBL.[LohntypCode], TBL.[Kostentraeger], TBL.[WeitereKostentraeger], TBL.[Kostenart], TBL.[KeinBDEExport], TBL.[MigHerkunft], TBL.[MigMAKuerzel], TBL.[MigUserFix], TBL.[visdat36Area], TBL.[visdat36SourceFile], TBL.[visdat36ID], TBL.[visdat36Name], TBL.[Creator], TBL.[Created], TBL.[Modifier], TBL.[Modified], @VerID
      FROM [XUser]  TBL
        INNER JOIN @Changes  UPD ON UPD.ActionCode < 3 AND UPD.[UserID] = TBL.[UserID]

    UPDATE TBL
      SET VerID = @VerID
    FROM [XUser]  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode < 3 AND UPD.[UserID] = TBL.[UserID]
    WHERE IsNull(TBL.VerID, -1) != @VerID
  END
  SET NOCOUNT OFF
END



GO

ALTER TABLE [dbo].[XUser]  WITH CHECK ADD  CONSTRAINT [FK_XUser_XModul] FOREIGN KEY([ModulID])
REFERENCES [dbo].[XModul] ([ModulID])
GO

ALTER TABLE [dbo].[XUser] CHECK CONSTRAINT [FK_XUser_XModul]
GO

ALTER TABLE [dbo].[XUser]  WITH CHECK ADD  CONSTRAINT [FK_XUser_XPermissionGroup_GrantPermGroupID] FOREIGN KEY([GrantPermGroupID])
REFERENCES [dbo].[XPermissionGroup] ([PermissionGroupID])
GO

ALTER TABLE [dbo].[XUser] CHECK CONSTRAINT [FK_XUser_XPermissionGroup_GrantPermGroupID]
GO

ALTER TABLE [dbo].[XUser]  WITH CHECK ADD  CONSTRAINT [FK_XUser_XPermissionGroup_PermissionGroupID] FOREIGN KEY([PermissionGroupID])
REFERENCES [dbo].[XPermissionGroup] ([PermissionGroupID])
GO

ALTER TABLE [dbo].[XUser] CHECK CONSTRAINT [FK_XUser_XPermissionGroup_PermissionGroupID]
GO

ALTER TABLE [dbo].[XUser]  WITH CHECK ADD  CONSTRAINT [FK_XUser_XProfile] FOREIGN KEY([XProfileID])
REFERENCES [dbo].[XProfile] ([XProfileID])
GO

ALTER TABLE [dbo].[XUser] CHECK CONSTRAINT [FK_XUser_XProfile]
GO

ALTER TABLE [dbo].[XUser]  WITH CHECK ADD  CONSTRAINT [FK_XUser_XUser_ChiefID] FOREIGN KEY([ChiefID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[XUser] CHECK CONSTRAINT [FK_XUser_XUser_ChiefID]
GO

ALTER TABLE [dbo].[XUser]  WITH CHECK ADD  CONSTRAINT [FK_XUser_XUser_PrimaryUserID] FOREIGN KEY([PrimaryUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[XUser] CHECK CONSTRAINT [FK_XUser_XUser_PrimaryUserID]
GO

ALTER TABLE [dbo].[XUser]  WITH CHECK ADD  CONSTRAINT [FK_XUser_XUser_SachbearbeiterID] FOREIGN KEY([SachbearbeiterID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[XUser] CHECK CONSTRAINT [FK_XUser_XUser_SachbearbeiterID]
GO

ALTER TABLE [dbo].[XUser] ADD  CONSTRAINT [DF_XUser_PasswordHash]  DEFAULT ([dbo].[fnXGetUserRNDPwd](newid())) FOR [PasswordHash]
GO

ALTER TABLE [dbo].[XUser] ADD  CONSTRAINT [DF_XUser_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO

ALTER TABLE [dbo].[XUser] ADD  CONSTRAINT [DF_XUser_IsUserAdmin]  DEFAULT ((0)) FOR [IsUserAdmin]
GO

ALTER TABLE [dbo].[XUser] ADD  CONSTRAINT [DF_XUser_IsUserBIAGAdmin]  DEFAULT ((0)) FOR [IsUserBIAGAdmin]
GO

ALTER TABLE [dbo].[XUser] ADD  CONSTRAINT [DF_XUser_IsMandatstraeger]  DEFAULT ((0)) FOR [IsMandatsTraeger]
GO

ALTER TABLE [dbo].[XUser] ADD  CONSTRAINT [DF_XUser_KeinBDEExport]  DEFAULT ((0)) FOR [KeinBDEExport]
GO

ALTER TABLE [dbo].[XUser] ADD  CONSTRAINT [DF_XUser_MigUserFix]  DEFAULT ((0)) FOR [MigUserFix]
GO

ALTER TABLE [dbo].[XUser] ADD  CONSTRAINT [DF_XUser_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[XUser] ADD  CONSTRAINT [DF_XUser_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


