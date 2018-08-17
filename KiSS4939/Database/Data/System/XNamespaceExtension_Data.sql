SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [XNamespaceExtension]
GO
SET IDENTITY_INSERT [XNamespaceExtension] ON
GO
INSERT INTO [XNamespaceExtension] ([XNamespaceExtensionID], [NamespaceExtension], [Creator], [Created], [Modifier], [Modified]) VALUES (1, N'BOL', N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120), N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120))
INSERT INTO [XNamespaceExtension] ([XNamespaceExtensionID], [NamespaceExtension], [Creator], [Created], [Modifier], [Modified]) VALUES (2, N'BSS', N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120), N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120))
INSERT INTO [XNamespaceExtension] ([XNamespaceExtensionID], [NamespaceExtension], [Creator], [Created], [Modifier], [Modified]) VALUES (3, N'CAR', N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120), N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120))
INSERT INTO [XNamespaceExtension] ([XNamespaceExtensionID], [NamespaceExtension], [Creator], [Created], [Modifier], [Modified]) VALUES (4, N'IBE', N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120), N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120))
INSERT INTO [XNamespaceExtension] ([XNamespaceExtensionID], [NamespaceExtension], [Creator], [Created], [Modifier], [Modified]) VALUES (5, N'ITT', N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120), N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120))
INSERT INTO [XNamespaceExtension] ([XNamespaceExtensionID], [NamespaceExtension], [Creator], [Created], [Modifier], [Modified]) VALUES (6, N'MAD', N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120), N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120))
INSERT INTO [XNamespaceExtension] ([XNamespaceExtensionID], [NamespaceExtension], [Creator], [Created], [Modifier], [Modified]) VALUES (7, N'MBU', N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120), N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120))
INSERT INTO [XNamespaceExtension] ([XNamespaceExtensionID], [NamespaceExtension], [Creator], [Created], [Modifier], [Modified]) VALUES (8, N'MOS', N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120), N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120))
INSERT INTO [XNamespaceExtension] ([XNamespaceExtensionID], [NamespaceExtension], [Creator], [Created], [Modifier], [Modified]) VALUES (9, N'MUN', N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120), N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120))
INSERT INTO [XNamespaceExtension] ([XNamespaceExtensionID], [NamespaceExtension], [Creator], [Created], [Modifier], [Modified]) VALUES (10, N'PI', N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120), N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120))
INSERT INTO [XNamespaceExtension] ([XNamespaceExtensionID], [NamespaceExtension], [Creator], [Created], [Modifier], [Modified]) VALUES (11, N'SRK', N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120), N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120))
INSERT INTO [XNamespaceExtension] ([XNamespaceExtensionID], [NamespaceExtension], [Creator], [Created], [Modifier], [Modified]) VALUES (12, N'VES', N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120), N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120))
INSERT INTO [XNamespaceExtension] ([XNamespaceExtensionID], [NamespaceExtension], [Creator], [Created], [Modifier], [Modified]) VALUES (13, N'WOH', N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120), N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120))
INSERT INTO [XNamespaceExtension] ([XNamespaceExtensionID], [NamespaceExtension], [Creator], [Created], [Modifier], [Modified]) VALUES (14, N'WOR', N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120), N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120))
INSERT INTO [XNamespaceExtension] ([XNamespaceExtensionID], [NamespaceExtension], [Creator], [Created], [Modifier], [Modified]) VALUES (15, N'WYN', N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120), N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120))
INSERT INTO [XNamespaceExtension] ([XNamespaceExtensionID], [NamespaceExtension], [Creator], [Created], [Modifier], [Modified]) VALUES (16, N'ZH', N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120), N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120))
INSERT INTO [XNamespaceExtension] ([XNamespaceExtensionID], [NamespaceExtension], [Creator], [Created], [Modifier], [Modified]) VALUES (17, N'ZOL', N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120), N'cjaeggi', CONVERT(datetime, '2010-01-25 11:27:09', 120))
GO
SET IDENTITY_INSERT [XNamespaceExtension] OFF
GO
COMMIT
GO