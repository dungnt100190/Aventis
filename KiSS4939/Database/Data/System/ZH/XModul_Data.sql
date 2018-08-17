SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [XModul]
GO
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (-10, N'Messages', N'MSG', NULL, N'KiSS4.Messages', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (-9, N'DB', N'DB', NULL, N'KiSS4.DB', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (-8, N'Gui', N'GUI', NULL, N'KiSS4.Gui', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (-7, N'Common', N'COM', NULL, N'KiSS4.Common', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (-2, N'GraphLib', N'GLB', NULL, N'KiSS4.GraphLib', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (-1, N'Main', N'MAN', NULL, N'KiSS4.Main', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (0, N'Allgemein', N'ALG', NULL, NULL, NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (1, N'Basis', N'B', 1, N'KiSS4.Basis', N'Ba', 1, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (2, N'Fallführung', N'F', 2, N'KiSS4.Fallfuehrung', N'Fa', 1, NULL, 0, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (3, N'Wirtschaftliche Hilfe', N'W', 3, N'KiSS4.Sozialhilfe', N'Wh', 1, NULL, 0, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (4, N'Alimentwesen', N'A', 4, N'KiSS4.Inkasso', N'Am', 0, NULL, 0, 0)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (5, N'Klientengelder', N'K', 5, N'KiSS4.Vormundschaft', N'Vm', 1, NULL, 0, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (10, N'Administration', N'ADM', NULL, N'KiSS4.Administration', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (11, N'KiSS-Designer', N'DSG', NULL, N'KiSS4.DesignerHost', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (12, N'Query', N'QRY', NULL, N'KiSS4.Query', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (13, N'Dokument', N'DOC', NULL, N'KiSS4.Dokument', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (14, N'Fibu', N'FIB', NULL, N'KiSS4.Fibu', N'Fb', 0, NULL, 0, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (15, N'Fibu-Link', N'FL', NULL, N'KiSS4.FibuLink', N'Fl', 0, NULL, 0, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (16, N'Sostat', N'BFS', NULL, N'KiSS4.Sostat', N'XBfs', 0, NULL, 0, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (17, N'Klientenbuchhaltung', N'KB', NULL, N'KiSS4.Klientenbuchhaltung', N'Kb', 0, NULL, 0, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (20, N'BDE', N'BDE', 20, N'KiSS4.BDE', N'BDE', 0, N'Modul: Betriebsdaten- und Zeitleistungserfassung', 0, 0)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (21, N'Pendenzverwaltung', NULL, 21, N'KiSS4.Pendenzen', NULL, 0, N'KISS Pendenzenverwaltung', 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (26, N'Fallsteuerung', N'FS', 26, N'Kiss.UI.Container.Fs', N'Fs', 0, N'Fallsteuerung als Anwendung und Integration in die Fallführung', 0, 0)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (27, N'Gesuch-/Fondsverwaltung', N'GV', 27, N'KiSS4.Gesuchverwaltung', N'Gv', 0, N'Gesuch-/Fondsverwaltung', 1, 0)
GO
COMMIT
GO