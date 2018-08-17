SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [XModul]
GO
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (-10, N'Messages', N'MSG', -10, N'KiSS4.Messages', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (-9, N'DB', N'DB', -9, N'KiSS4.DB', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (-8, N'Gui', N'GUI', -8, N'KiSS4.Gui', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (-7, N'Common', N'COM', -7, N'KiSS4.Common', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (-2, N'GraphLib', N'GLB', -2, N'KiSS4.GraphLib', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (-1, N'Main', N'MAN', -1, N'KiSS4.Main', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (0, N'Allgemein', N'ALG', 0, NULL, NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (1, N'Basis', N'B', 1, N'KiSS4.Basis', N'Ba', 1, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (2, N'Fallführung', N'F', 2, N'KiSS4.Fallfuehrung', N'Fa', 1, NULL, 0, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (3, N'Sozialhilfe', N'S', 3, N'KiSS4.Sozialhilfe', N'Sh', 1, NULL, 0, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (4, N'Inkasso', N'I', 4, N'KiSS4.Inkasso', N'Ik', 1, NULL, 0, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (5, N'Vormundschaft', N'V', 5, N'KiSS4.Vormundschaft', N'Vm', 1, NULL, 0, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (6, N'Asyl', N'A', 7, N'KiSS4.Asyl', N'Ay', 1, NULL, 0, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (7, N'Arbeit', N'K', 8, N'KiSS4.Arbeit', N'Ka', 1, NULL, 0, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (10, N'Administration', N'ADM', 11, N'KiSS4.Administration', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (11, N'KiSS-Designer', N'DSG', 12, N'KiSS4.DesignerHost', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (12, N'Query', N'QRY', 13, N'KiSS4.Query', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (13, N'Dokument', N'DOC', 14, N'KiSS4.Dokument', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (14, N'Fibu', N'FIB', 15, N'KiSS4.Fibu', N'Fb', 0, N'Mandatsbuchhaltung', 0, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (16, N'Sostat', N'BFS', 17, N'KiSS4.Sostat', N'XBfs', 0, NULL, 0, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (17, N'Klientenbuchhaltung', N'KB', 18, N'KiSS4.Klientenbuchhaltung', N'Kb', 0, NULL, 0, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (18, N'Protokollverwaltung', N'PV', 19, N'KiSS4.Protokollverwaltung', NULL, 0, NULL, 0, 0)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (20, N'BDE', N'BDE', 21, N'KiSS4.BDE', N'BDE', 0, N'Modul: Betriebsdaten- und Zeitleistungserfassung', 0, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (21, N'Pendenzverwaltung', N'PEN', 22, N'KiSS4.Pendenzen', NULL, 0, N'KISS Pendenzenverwaltung', 0, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (25, N'Schnittstellen', N'SST', 26, N'KiSS4.Schnittstellen', NULL, 0, N'Schnittstellen für Newod, etc.', 0, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (26, N'Fallsteuerung', N'FS', 27, N'Kiss.UI.Container.Fs', N'Fs', 0, N'Fallsteuerung als Anwendung und Integration in die Fallführung', 0, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (27, N'Gesuch-/Fondsverwaltung', N'GV', 28, N'KiSS4.Gesuchverwaltung', N'Gv', 0, N'Gesuch-/Fondsverwaltung', 1, 0)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (28, N'Fallführung Neu', N'F', 29, N'Kiss.UI.Container.Fa', N'Fa', 0, N'Fallführung', 0, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (29, N'KES', N'KES', 6, N'KiSS4.Vormundschaft', N'Kes', 1, N'Kindes- und Erwachsenenschutz', 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (30, N'Wohnschule', N'WS', 31, NULL, NULL, 0, N'fiktives Modul für Wohnschule', 1, 0)
GO
COMMIT
GO