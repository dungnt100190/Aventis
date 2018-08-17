SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [XModul]
GO
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [Licensed], [System]) VALUES (-10, N'Messages', N'MSG', -10, N'KiSS4.Messages', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [Licensed], [System]) VALUES (-9, N'DB', N'DB', -9, N'KiSS4.DB', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [Licensed], [System]) VALUES (-8, N'Gui', N'GUI', -8, N'KiSS4.Gui', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [Licensed], [System]) VALUES (-7, N'Common', N'COM', -7, N'KiSS4.Common', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [Licensed], [System]) VALUES (-2, N'GraphLib', N'GLB', -2, N'KiSS4.GraphLib', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [Licensed], [System]) VALUES (-1, N'Main', N'MAN', -1, N'KiSS4.Main', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [Licensed], [System]) VALUES (0, N'Allgemein', N'ALG', 0, NULL, NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [Licensed], [System]) VALUES (1, N'Basis', N'P', 1, N'KiSS4.Basis', N'Ba', 1, N'Basis-Modul (PI=Person)', 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [Licensed], [System]) VALUES (2, N'Fallführung', N'FV', 2, N'KiSS4.Fallfuehrung', N'Fa', 1, N'Hauptmodul für die Fallführung (PI=Fallverlauf). Haupt-Node für Fallverlauf.', 1, 0)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [Licensed], [System]) VALUES (3, N'Sozialberatung', N'SB', 4, N'KiSS4.Sozialberatung', N'Sb', 1, N'Dienstleistung: Sozialberatung (SB)', 1, 0)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [Licensed], [System]) VALUES (4, N'Case Management', N'CM', 5, N'KiSS4.CaseManagement', N'Cm', 1, N'Dienstleistung: Case Management (CM)', 1, 0)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [Licensed], [System]) VALUES (5, N'Begleitetes Wohnen', N'BW', 6, N'KiSS4.BegleitetesWohnen', N'Bw', 1, N'Dienstleistung: Begleitetes Wohnen (BW)', 1, 0)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [Licensed], [System]) VALUES (6, N'Entlastungsdienst', N'ED', 7, N'KiSS4.Entlastungsdienst', N'Ed', 1, N'Dienstleistung: Entlastungsdienst (ED)', 1, 0)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [Licensed], [System]) VALUES (7, N'Intake', N'IN', 3, N'KiSS4.Intake', N'In', 1, N'Intake-Prozess (IN)', 1, 0)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [Licensed], [System]) VALUES (10, N'Administration', N'ADM', 10, N'KiSS4.Administration', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [Licensed], [System]) VALUES (11, N'KiSS-Designer', N'DSG', 11, N'KiSS4.DesignerHost', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [Licensed], [System]) VALUES (12, N'Query', N'QRY', 12, N'KiSS4.Query', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [Licensed], [System]) VALUES (13, N'Dokument', N'DOC', 13, N'KiSS4.Dokument', NULL, 0, NULL, 1, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [Licensed], [System]) VALUES (14, N'Schnittstellen', N'ABA', 14, N'KiSS4.Schnittstellen.Abacus', NULL, 0, N'Schnittstellen zu Abacus, Masken unter <KiSS4.Schnittstellen.Abacus> im Core', 1, 0)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [Licensed], [System]) VALUES (17, N'Klientenbuchhaltung', N'KB', 17, N'KiSS4.Klientenbuchhaltung', N'Kb', 0, NULL, 1, 0)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [Licensed], [System]) VALUES (20, N'BDE', N'BDE', 20, N'KiSS4.BDE', N'BDE', 0, N'Modul: Betriebsdaten- und Zeitleistungserfassung', 1, 0)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (25, N'Schnittstellen', N'SST', 25, N'KiSS4.Schnittstellen', NULL, 0, N'Schnittstellen für Newod, etc.', 0, 1)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [Licensed], [System]) VALUES (26, N'Fallsteuerung', N'FS', 26, N'Kiss.UI.Container.Fs', N'Fs', 0, N'Fallsteuerung als Anwendung und Integration in die Fallführung', 0, 0)
INSERT INTO [XModul] ([ModulID], [Name], [ShortName], [SortKey], [NameSpace], [DB_Prefix], [ModulTree], [Description], [System], [Licensed]) VALUES (27, N'Gesuch-/Fondsverwaltung', N'GV', 27, N'KiSS4.Gesuchverwaltung', N'Gv', 0, N'Gesuch-/Fondsverwaltung', 1, 0)
GO
COMMIT
GO