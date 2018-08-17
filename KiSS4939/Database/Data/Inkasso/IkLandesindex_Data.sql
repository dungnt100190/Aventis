SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [IkLandesindex]
GO
SET IDENTITY_INSERT [IkLandesindex] ON
GO
INSERT INTO [IkLandesindex] ([IkLandesindexID], [Name], [Creator], [Created], [Modifier], [Modified]) VALUES (1, N'BFS1966', N'System (2290)', CONVERT(datetime, '2011-10-13 00:20:07', 120), N'System (2290)', CONVERT(datetime, '2011-10-13 00:20:07', 120))
INSERT INTO [IkLandesindex] ([IkLandesindexID], [Name], [Creator], [Created], [Modifier], [Modified]) VALUES (2, N'BFS1977', N'System (2290)', CONVERT(datetime, '2011-10-13 00:20:07', 120), N'System (2290)', CONVERT(datetime, '2011-10-13 00:20:07', 120))
INSERT INTO [IkLandesindex] ([IkLandesindexID], [Name], [Creator], [Created], [Modifier], [Modified]) VALUES (3, N'BFS1982', N'System (2290)', CONVERT(datetime, '2011-10-13 00:20:07', 120), N'System (2290)', CONVERT(datetime, '2011-10-13 00:20:07', 120))
INSERT INTO [IkLandesindex] ([IkLandesindexID], [Name], [Creator], [Created], [Modifier], [Modified]) VALUES (4, N'BFS1993', N'System (2290)', CONVERT(datetime, '2011-10-13 00:20:07', 120), N'System (2290)', CONVERT(datetime, '2011-10-13 00:20:07', 120))
INSERT INTO [IkLandesindex] ([IkLandesindexID], [Name], [Creator], [Created], [Modifier], [Modified]) VALUES (5, N'BFS2000', N'System (2290)', CONVERT(datetime, '2011-10-13 00:20:07', 120), N'System (2290)', CONVERT(datetime, '2011-10-13 00:20:07', 120))
INSERT INTO [IkLandesindex] ([IkLandesindexID], [Name], [Creator], [Created], [Modifier], [Modified]) VALUES (6, N'BFS2005', N'System (2290)', CONVERT(datetime, '2011-10-13 00:20:07', 120), N'System (2290)', CONVERT(datetime, '2011-10-13 00:20:07', 120))
GO
SET IDENTITY_INSERT [IkLandesindex] OFF
GO
COMMIT
GO