SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [XProfile_XProfileTag] WHERE EXISTS (SELECT TOP 1 1 FROM dbo.XProfile SUB WHERE SUB.XProfileTypeCode = 1 AND SUB.XProfileID = XProfile_XProfileTag.XProfileID)
GO
SET IDENTITY_INSERT [XProfile_XProfileTag] ON
GO
INSERT INTO [XProfile_XProfileTag] ([XProfile_XProfileTagID], [XProfileID], [XProfileTagID], [Creator], [Created], [Modifier], [Modified]) VALUES (781, 781, 8, N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120), N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120))
INSERT INTO [XProfile_XProfileTag] ([XProfile_XProfileTagID], [XProfileID], [XProfileTagID], [Creator], [Created], [Modifier], [Modified]) VALUES (782, 782, 7, N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120), N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120))
INSERT INTO [XProfile_XProfileTag] ([XProfile_XProfileTagID], [XProfileID], [XProfileTagID], [Creator], [Created], [Modifier], [Modified]) VALUES (783, 783, 2, N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120), N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120))
INSERT INTO [XProfile_XProfileTag] ([XProfile_XProfileTagID], [XProfileID], [XProfileTagID], [Creator], [Created], [Modifier], [Modified]) VALUES (784, 784, 3, N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120), N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120))
INSERT INTO [XProfile_XProfileTag] ([XProfile_XProfileTagID], [XProfileID], [XProfileTagID], [Creator], [Created], [Modifier], [Modified]) VALUES (785, 785, 5, N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120), N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120))
INSERT INTO [XProfile_XProfileTag] ([XProfile_XProfileTagID], [XProfileID], [XProfileTagID], [Creator], [Created], [Modifier], [Modified]) VALUES (786, 786, 1, N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120), N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120))
INSERT INTO [XProfile_XProfileTag] ([XProfile_XProfileTagID], [XProfileID], [XProfileTagID], [Creator], [Created], [Modifier], [Modified]) VALUES (787, 787, 4, N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120), N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120))
INSERT INTO [XProfile_XProfileTag] ([XProfile_XProfileTagID], [XProfileID], [XProfileTagID], [Creator], [Created], [Modifier], [Modified]) VALUES (788, 788, 6, N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120), N'System (2094)', CONVERT(datetime, '2011-03-01 00:07:06', 120))
GO
SET IDENTITY_INSERT [XProfile_XProfileTag] OFF
GO
COMMIT
GO