SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [XPermissionGroup]
GO
SET IDENTITY_INSERT [XPermissionGroup] ON
GO
INSERT INTO [XPermissionGroup] ([PermissionGroupID], [PermissionGroupName], [Description], [Kompetenzstufe]) VALUES (4, N'Bereichsleitung Sozialdienst', NULL, 3)
INSERT INTO [XPermissionGroup] ([PermissionGroupID], [PermissionGroupName], [Description], [Kompetenzstufe]) VALUES (5, N'Sektionsleitung Sozialdienst', NULL, 2)
INSERT INTO [XPermissionGroup] ([PermissionGroupID], [PermissionGroupName], [Description], [Kompetenzstufe]) VALUES (6, N'Sozialarbeiter/in Sozialdienst', NULL, 1)
INSERT INTO [XPermissionGroup] ([PermissionGroupID], [PermissionGroupName], [Description], [Kompetenzstufe]) VALUES (7, N'Sekretariat Sozialdienst', NULL, 1)
INSERT INTO [XPermissionGroup] ([PermissionGroupID], [PermissionGroupName], [Description], [Kompetenzstufe]) VALUES (8, N'Sozialarbeiter/in Sozialdienst ohne Kompetenzen', NULL, 1)
INSERT INTO [XPermissionGroup] ([PermissionGroupID], [PermissionGroupName], [Description], [Kompetenzstufe]) VALUES (9, N'Abteilungsleitung', NULL, 4)
INSERT INTO [XPermissionGroup] ([PermissionGroupID], [PermissionGroupName], [Description], [Kompetenzstufe]) VALUES (10, N'Sozialarbeiter/in Jugendamt', NULL, 1)
GO
SET IDENTITY_INSERT [XPermissionGroup] OFF
GO
COMMIT
GO