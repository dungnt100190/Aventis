SET NOCOUNT ON;
BEGIN TRANSACTION;

IF (NOT EXISTS (SELECT TOP 1 1
                FROM dbo.XUser
                WHERE LogonName = 'admin'))
BEGIN
  INSERT INTO dbo.HistoryVersion (AppUser) VALUES ('kiss_sys');

  INSERT INTO [XUser] ([ChiefID], [PrimaryUserID], [PermissionGroupID], [GrantPermGroupID], [XProfileID], [ModulID], [SachbearbeiterID], [MitarbeiterNr], [LogonName], [PasswordHash], [FirstName], [LastName], [ShortName], [IsLocked], [IsUserAdmin], [IsUserBIAGAdmin], [IsMandatsTraeger], [GenderCode], [Geburtstag], [LanguageCode], [Phone], [PhoneOffice], [PhoneIntern], [PhonePrivat], [EMail], [UserProfileCode], [Funktion], [Bemerkungen], [Text1], [Text2], [JobPercentage], [HoursPerYearForCaseMgmt], [Eintrittsdatum], [Austrittsdatum], [LohntypCode], [Kostentraeger], [Kostenart], [MigHerkunft], [MigMAKuerzel], [MigUserFix], [visdat36Area], [visdat36SourceFile], [visdat36ID], [visdat36Name], [VerID], [Creator], [Created], [Modifier], [Modified]) 
  VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'admin', N'9C04uaoYSHE=', NULL, N'Administrator', N'admin', 0, 1, 0, 0, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, 1, NULL, NULL, 0, NULL, NULL, NULL, NULL, 99076, N'System (-1)', GETDATE(), N'System (-1)', GETDATE());
  
  PRINT ('Info: Created user "admin"');
END;

IF (NOT EXISTS (SELECT TOP 1 1
                FROM dbo.XUser
                WHERE LogonName = 'biag_admin'))
BEGIN
  INSERT INTO dbo.HistoryVersion (AppUser) VALUES ('kiss_sys');
  
  INSERT INTO [XUser] ([ChiefID], [PrimaryUserID], [PermissionGroupID], [GrantPermGroupID], [XProfileID], [ModulID], [SachbearbeiterID], [MitarbeiterNr], [LogonName], [PasswordHash], [FirstName], [LastName], [ShortName], [IsLocked], [IsUserAdmin], [IsUserBIAGAdmin], [IsMandatsTraeger], [GenderCode], [Geburtstag], [LanguageCode], [Phone], [PhoneOffice], [PhoneIntern], [PhonePrivat], [EMail], [UserProfileCode], [Funktion], [Bemerkungen], [Text1], [Text2], [JobPercentage], [HoursPerYearForCaseMgmt], [Eintrittsdatum], [Austrittsdatum], [LohntypCode], [Kostentraeger], [Kostenart], [MigHerkunft], [MigMAKuerzel], [MigUserFix], [visdat36Area], [visdat36SourceFile], [visdat36ID], [visdat36Name], [VerID], [Creator], [Created], [Modifier], [Modified]) 
  VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'biag_admin', N'9C04uaoYSHE=', N'Support', N'Diartis', N'ds', 0, 1, 1, 0, 1, NULL, 1, N'0793890385', NULL, NULL, NULL, N'kiss@diartis.ch', NULL, NULL, N'Wird für die Wartung verwendet', NULL, NULL, NULL, NULL, GETDATE(), NULL, 1, 1, 1, NULL, NULL, 0, NULL, NULL, NULL, NULL, 99076, N'System (-1)', GETDATE(), N'System (-1)', GETDATE());
  
  PRINT ('Info: Created user "biag_admin"');
END;

COMMIT;
GO