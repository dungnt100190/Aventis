SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [XPermissionGroup]
GO
SET IDENTITY_INSERT [XPermissionGroup] ON
GO
INSERT INTO [XPermissionGroup] ([PermissionGroupID], [PermissionGroupName], [Description]) VALUES (4, N'Stellenleiter/in', NULL)
INSERT INTO [XPermissionGroup] ([PermissionGroupID], [PermissionGroupName], [Description]) VALUES (11, N'Sozialarbeiter/in', NULL)
INSERT INTO [XPermissionGroup] ([PermissionGroupID], [PermissionGroupName], [Description]) VALUES (12, N'Sozialarbeiter/in Kompetenz WH', 'Finanzkompetenz WH für Sozialarbeitende - Neue Kompetenzordnung ab 10.6.2010')
GO
SET IDENTITY_INSERT [XPermissionGroup] OFF
GO
COMMIT
GO