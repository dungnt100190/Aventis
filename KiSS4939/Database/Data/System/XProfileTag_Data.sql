SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [XProfileTag]
GO
SET IDENTITY_INSERT [XProfileTag] ON
GO
INSERT INTO [XProfileTag] ([XProfileTagID], [Name], [Description], [Creator], [Created], [Modifier], [Modified]) VALUES (1, N'Profil Allgemein', NULL, N'biag_admin', CONVERT(datetime, '2011-03-01 00:07:05', 120), N'biag_admin', CONVERT(datetime, '2011-03-01 00:07:05', 120))
INSERT INTO [XProfileTag] ([XProfileTagID], [Name], [Description], [Creator], [Created], [Modifier], [Modified]) VALUES (2, N'Basis', NULL, N'biag_admin', CONVERT(datetime, '2011-03-01 00:07:05', 120), N'biag_admin', CONVERT(datetime, '2011-03-01 00:07:05', 120))
INSERT INTO [XProfileTag] ([XProfileTagID], [Name], [Description], [Creator], [Created], [Modifier], [Modified]) VALUES (3, N'Fallführung', NULL, N'biag_admin', CONVERT(datetime, '2011-03-01 00:07:05', 120), N'biag_admin', CONVERT(datetime, '2011-03-01 00:07:05', 120))
INSERT INTO [XProfileTag] ([XProfileTagID], [Name], [Description], [Creator], [Created], [Modifier], [Modified]) VALUES (4, N'Sozialhilfe', NULL, N'biag_admin', CONVERT(datetime, '2011-03-01 00:07:05', 120), N'biag_admin', CONVERT(datetime, '2011-03-01 00:07:05', 120))
INSERT INTO [XProfileTag] ([XProfileTagID], [Name], [Description], [Creator], [Created], [Modifier], [Modified]) VALUES (5, N'Inkasso', NULL, N'biag_admin', CONVERT(datetime, '2011-03-01 00:07:05', 120), N'biag_admin', CONVERT(datetime, '2011-03-01 00:07:05', 120))
INSERT INTO [XProfileTag] ([XProfileTagID], [Name], [Description], [Creator], [Created], [Modifier], [Modified]) VALUES (6, N'Vormundschaft', NULL, N'biag_admin', CONVERT(datetime, '2011-03-01 00:07:05', 120), N'biag_admin', CONVERT(datetime, '2011-03-01 00:07:05', 120))
INSERT INTO [XProfileTag] ([XProfileTagID], [Name], [Description], [Creator], [Created], [Modifier], [Modified]) VALUES (7, N'Asyl', NULL, N'biag_admin', CONVERT(datetime, '2011-03-01 00:07:05', 120), N'biag_admin', CONVERT(datetime, '2011-03-01 00:07:05', 120))
INSERT INTO [XProfileTag] ([XProfileTagID], [Name], [Description], [Creator], [Created], [Modifier], [Modified]) VALUES (8, N'Arbeit', NULL, N'biag_admin', CONVERT(datetime, '2011-03-01 00:07:05', 120), N'biag_admin', CONVERT(datetime, '2011-03-01 00:07:05', 120))
GO
SET IDENTITY_INSERT [XProfileTag] OFF
GO
COMMIT
GO