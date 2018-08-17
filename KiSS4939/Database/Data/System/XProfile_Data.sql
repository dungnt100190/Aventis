SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [XProfile] WHERE XProfileTypeCode = 1
GO
SET IDENTITY_INSERT [XProfile] ON
GO
INSERT INTO [XProfile] ([XProfileID], [XProfileTypeCode], [Name], [Description], [Creator], [Created], [Modifier], [Modified]) VALUES (781, 1, N'Arbeit', NULL, N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120), N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120))
INSERT INTO [XProfile] ([XProfileID], [XProfileTypeCode], [Name], [Description], [Creator], [Created], [Modifier], [Modified]) VALUES (782, 1, N'Asyl', NULL, N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120), N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120))
INSERT INTO [XProfile] ([XProfileID], [XProfileTypeCode], [Name], [Description], [Creator], [Created], [Modifier], [Modified]) VALUES (783, 1, N'Basis', NULL, N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120), N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120))
INSERT INTO [XProfile] ([XProfileID], [XProfileTypeCode], [Name], [Description], [Creator], [Created], [Modifier], [Modified]) VALUES (784, 1, N'Fallführung', NULL, N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120), N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120))
INSERT INTO [XProfile] ([XProfileID], [XProfileTypeCode], [Name], [Description], [Creator], [Created], [Modifier], [Modified]) VALUES (785, 1, N'Inkasso', NULL, N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120), N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120))
INSERT INTO [XProfile] ([XProfileID], [XProfileTypeCode], [Name], [Description], [Creator], [Created], [Modifier], [Modified]) VALUES (786, 1, N'Profil Allgemein', NULL, N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120), N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120))
INSERT INTO [XProfile] ([XProfileID], [XProfileTypeCode], [Name], [Description], [Creator], [Created], [Modifier], [Modified]) VALUES (787, 1, N'Sozialhilfe', NULL, N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120), N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120))
INSERT INTO [XProfile] ([XProfileID], [XProfileTypeCode], [Name], [Description], [Creator], [Created], [Modifier], [Modified]) VALUES (788, 1, N'Vormundschaft', NULL, N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120), N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120))
GO
SET IDENTITY_INSERT [XProfile] OFF
GO
COMMIT
GO