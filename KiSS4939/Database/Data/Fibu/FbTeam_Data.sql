SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [FbTeam]
GO
SET IDENTITY_INSERT [FbTeam] ON
GO
INSERT INTO [FbTeam] ([FbTeamID], [Name]) VALUES (1, N'Team A')
INSERT INTO [FbTeam] ([FbTeamID], [Name]) VALUES (2, N'Team B')
INSERT INTO [FbTeam] ([FbTeamID], [Name]) VALUES (4, N'Team Depot')
INSERT INTO [FbTeam] ([FbTeamID], [Name]) VALUES (5, N'Erbschaftsbuchhaltung')
INSERT INTO [FbTeam] ([FbTeamID], [Name]) VALUES (6, N'Team R')
GO
SET IDENTITY_INSERT [FbTeam] OFF
GO
COMMIT
GO 