SET NOCOUNT ON
BEGIN TRANSACTION
GO
--=============================================================================
DISABLE TRIGGER trHist_XUser ON XUser;
GO
--=============================================================================
DELETE FROM [XUser] WHERE IsUserAdmin=1 OR IsUserBIAGAdmin=1
GO
SET IDENTITY_INSERT [XUser] ON
GO
INSERT INTO [XUser] ([UserID], [ChiefID], [PrimaryUserID], [PermissionGroupID], [GrantPermGroupID], [XProfileID], [ModulID], [SachbearbeiterID], [MitarbeiterNr], [LogonName], [PasswordHash], [FirstName], [LastName], [ShortName], [IsLocked], [IsUserAdmin], [IsUserBIAGAdmin], [IsMandatsTraeger], [GenderCode], [Geburtstag], [LanguageCode], [Phone], [PhoneOffice], [PhoneIntern], [PhonePrivat], [EMail], [UserProfileCode], [Funktion], [Bemerkungen], [Text1], [Text2], [JobPercentage], [HoursPerYearForCaseMgmt], [Eintrittsdatum], [Austrittsdatum], [LohntypCode], [Kostentraeger], [Kostenart], [MigHerkunft], [MigMAKuerzel], [MigUserFix], [visdat36Area], [visdat36SourceFile], [visdat36ID], [visdat36Name], [VerID], [Creator], [Created], [Modifier], [Modified]) VALUES (1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'biag_admin', N'i1lT9iY9e24=', N'Support', N'Born', N'bs', 0, 1, 1, 0, 1, NULL, 1, N'0319984309', N'0319984309', NULL, NULL, N'kiss@diartis.ch', NULL, NULL, N'Wird für die Wartung verwendet', NULL, NULL, NULL, NULL, CONVERT(datetime, '20080101', 112), NULL, 1, 1, 1, NULL, NULL, 0, NULL, NULL, NULL, NULL, 99076, N'Nobody (-1)', CONVERT(datetime, '2011-07-08 18:19:46', 120), N'Nobody (-1)', CONVERT(datetime, '2011-07-08 18:19:46', 120))
INSERT INTO [XUser] ([UserID], [ChiefID], [PrimaryUserID], [PermissionGroupID], [GrantPermGroupID], [XProfileID], [ModulID], [SachbearbeiterID], [MitarbeiterNr], [LogonName], [PasswordHash], [FirstName], [LastName], [ShortName], [IsLocked], [IsUserAdmin], [IsUserBIAGAdmin], [IsMandatsTraeger], [GenderCode], [Geburtstag], [LanguageCode], [Phone], [PhoneOffice], [PhoneIntern], [PhonePrivat], [EMail], [UserProfileCode], [Funktion], [Bemerkungen], [Text1], [Text2], [JobPercentage], [HoursPerYearForCaseMgmt], [Eintrittsdatum], [Austrittsdatum], [LohntypCode], [Kostentraeger], [Kostenart], [MigHerkunft], [MigMAKuerzel], [MigUserFix], [visdat36Area], [visdat36SourceFile], [visdat36ID], [visdat36Name], [VerID], [Creator], [Created], [Modifier], [Modified]) VALUES (2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'kiss_sys', N'i1lT9iY9e24=', NULL, N'System', N'kiss_sys', 1, 1, 1, 0, 1, NULL, 1, NULL, NULL, NULL, NULL, N'kiss@diartis.ch', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, 99076, N'Nobody (-1)', CONVERT(datetime, '2011-07-08 18:19:46', 120), N'Nobody (-1)', CONVERT(datetime, '2011-07-08 18:19:46', 120))
GO
SET IDENTITY_INSERT [XUser] OFF
GO
ENABLE TRIGGER trHist_XUser ON XUser;
GO
COMMIT
GO