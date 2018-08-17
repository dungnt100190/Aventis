﻿SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [XUserGroup]
GO
SET IDENTITY_INSERT [XUserGroup] ON
GO
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (51, N'Zentrumsleitung', 16888, 0, N'SOD SZ - Sozialzentrums-Leitung, Stellvertretung und Assistenz', 16887, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Eberle, Markus (8459)', CONVERT(datetime, '2012-05-08 14:18:11', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (52, N'Stellenleitung QT', 20327, 0, N'SOD SZ - Leitung und Stv.Leitung Quartierteam (Finanzkompetenz WH und Vermittlungsfälle)', 20326, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Eberle, Markus (8459)', CONVERT(datetime, '2012-05-08 14:17:44', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (53, N'Sozialarbeitende QT', 17058, 0, N'SOD SZ - Sozialarbeitende (Finanzkompetenz im K bei KES-Massnahme)', 17057, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Bedag, Support (8545)', CONVERT(datetime, '2012-07-25 14:09:16', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (54, N'Sachbearbeitung QT', 17052, 0, N'SOD SZ - Sachbearbeitung FaPro/ErwPro im Quatierteam', 17051, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Eberle, Markus (8459)', CONVERT(datetime, '2012-05-08 14:15:47', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (55, N'Mitarbeitende Arbeitsintegration QT', 17065, 0, N'SOD SZ - Arbeitsintegrations-Einsatz Sachbearbeitung FaPro/ErwPro Quartierteam', 17064, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Bedag, Support (8545)', CONVERT(datetime, '2012-07-25 13:51:38', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (56, N'Lernende QT', 17400, 0, N'SOD SZ - Lernende Sachbearbeitung FaPro/ErwPro im Quartierteam', 17399, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Eberle, Markus (8459)', CONVERT(datetime, '2011-08-15 16:20:39', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (57, N'Stellenleitung Intake/ZAV', 17498, 0, N'SOD SZ - Leitung und Stv.Leitung Intake und ZAV (Finanzkometenz WH und Vermittlungsfälle)', 17497, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Eberle, Markus (8459)', CONVERT(datetime, '2012-05-08 14:17:13', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (58, N'Sozialarbeitende Intake/ZAV', 16730, 0, N'SOD SZ - Sozialarbeitende mit FaPro/ErwPro im Intake/ZAV', 16729, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Eberle, Markus (8459)', CONVERT(datetime, '2012-05-08 14:16:16', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (59, N'Sachbearbeitung Intake/ZAV', 17087, 0, N'SOD SZ - Sachbearbeitung FaPro/ErwPro im Intake/ZAV', 17086, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Eberle, Markus (8459)', CONVERT(datetime, '2012-05-08 14:15:15', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (60, N'Mitarbeitende Arbeitsintegration Intake/ZAV', 17067, 0, N'SOD SZ - Arbeitsintegrations-Einsatz Sachbearbeitung FaPro/ErwPro Intake/ZAV', 17066, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Stäuble, Urs (2257)', CONVERT(datetime, '2011-07-05 17:32:06', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (61, N'Lernende Intake/ZAV', 17054, 0, N'SOD SZ - Lernende Sachbearbeitung FaPro/ErwPro Intake/ZAV', 17053, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Bestebreurtje, Frank (561)', CONVERT(datetime, '2011-06-22 09:29:46', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (62, N'KL-Kontoabrechnung', 20891, 0, N'SOD SZ - verantwortliche MA für Klienten-Kontoabrechnung WH (Modul W)', 20890, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Bedag, Support (8545)', CONVERT(datetime, '2012-07-24 18:00:50', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (63, N'MüVä-BeraterInnen', 17759, 0, N'SOD SZ - KKBB-MüVä-Berater/innen (können bei Bedarf eigene Fälle führen, analog SA Intake/ZAV)', 17758, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Stäuble, Urs (2257)', CONVERT(datetime, '2012-01-20 16:09:41', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (64, N'Coaching 16:25 Arbeitsintgration', 17719, 0, N'SOD - Coaching für Klient/innen zwischen 16 und 25 Jahren (Teilleistungserbingende)
SOD - Gemeinnützige Arbeit', 17718, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Eberle, Markus (8459)', CONVERT(datetime, '2011-12-19 15:41:58', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (66, N'Behörde SoBe, BR', 17013, 0, N'Sozialbehörde, Bezirksrat', 17012, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Eberle, Markus (8459)', CONVERT(datetime, '2011-06-16 08:57:44', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (67, N'Einsprache- & Geschäftsprüfungskommission SoBe', 17721, 0, N'SDS RD - EGPK-Sekretariat der SoBe, verantwortliche Mitarbeitende Rechtsdienst (Visumskompetenz EGPK-Entscheide)', 17720, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Eberle, Markus (8459)', CONVERT(datetime, '2011-12-19 15:41:59', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (68, N'Alimentenstelle Leitung', 16451, 0, N'SOD AS - Leitung und Stv.Leitung Alimentenstelle (Finanzkompetenz AS)', 16450, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Bestebreurtje, Frank (561)', CONVERT(datetime, '2011-04-20 21:35:55', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (69, N'Alimentenstelle Sachbearbeitung', 16883, 0, N'SOD AS - Sachbearbeitung Alimentenstelle', 16882, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Bestebreurtje, Frank (561)', CONVERT(datetime, '2011-05-31 08:54:13', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (70, N'Leitung Zentrale Rückerstattung', 17048, 0, N'SOD ZR - Leitung und Stv.Leitung', 17047, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Bestebreurtje, Frank (561)', CONVERT(datetime, '2011-06-22 08:30:46', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (71, N'Sachbearbeitung Zentrale Rückerstattung', 20895, 0, N'SOD ZR- Mitarbeitende mit Spezialaufgaben (Inkasso VU/UP und Rückerstattungen WH)', 20894, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Bedag, Support (8545)', CONVERT(datetime, '2012-07-24 18:00:57', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (73, N'EK Sekretariat', 17063, 0, N'SOD KPZ - verantwortliche Mitarbeitende für die Verarbeitung der SoBe Einzelfallkommissions-Entscheide (Visumskompetenz EK-Entscheide)', 17062, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Bestebreurtje, Frank (561)', CONVERT(datetime, '2011-07-05 12:20:55', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (74, N'Sozialstatistik', 18172, 0, N'SOD KPZ - Mitarbeitende der Sozialstatistik und Evaluation', 18171, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Bestebreurtje, Frank (561)', CONVERT(datetime, '2012-02-08 16:30:18', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (75, N'Fachsupport KPZ', 16618, 0, N'SOD KPZ - Fachteam Einzelfallarbeit (SHG, JHG, ZGB), GWA/Stadtentwicklung', 16617, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Stäuble, Urs (2257)', CONVERT(datetime, '2011-05-20 16:00:00', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (76, N'Fallkontrolle', 16616, 0, N'SOD KPZ/SoBe - Team Fallkontrolle KPZ und Inspektoren der SoBe', 16615, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Stäuble, Urs (2257)', CONVERT(datetime, '2011-05-20 14:30:29', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (77, N'Spezialteam Vertiefte Abklärungen', 18177, 0, N'SOD KPZ - Spezialteam Vertiefte Abklärungen, Team Revision Sozialversicherungen', 18176, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Bestebreurtje, Frank (561)', CONVERT(datetime, '2012-02-29 16:59:24', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (78, N'Leitung Finanzen', 17050, 0, N'SDS Finanzen - Abteilungsleitung Finanzen, Stellvertretung und Assistenz', 17049, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Bestebreurtje, Frank (561)', CONVERT(datetime, '2011-06-22 08:31:12', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (79, N'Finanzsupport W', 16455, 0, N'SDS Finanzen - verantwortliche Mitarbeitende KliBu für die Verarbeitung Buchungsdaten im Modul W', 16454, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Bestebreurtje, Frank (561)', CONVERT(datetime, '2011-04-20 21:47:28', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (80, N'Finanzsupport K', 17574, 0, N'SDS Finanzen - verantwortliche Mitarbeitende Klibu für die Verarbeitung Buchungsdaten im Modul K', 17573, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Dubach, Daniel (831)', CONVERT(datetime, '2011-10-12 13:39:39', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (81, N'Finanzsupport W - Rechnungen erfassen', 16881, 0, N'SDS Finanzen - verantwortliche Mitarbeitende Klibu für die Verarbeitung von Rechnungen', 16880, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Dubach, Daniel (831)', CONVERT(datetime, '2011-05-26 14:08:54', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (83, N'Telefonzentrale', 17723, 0, N'SOD SZ - Telefonzentrale', 17722, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Stäuble, Urs (2257)', CONVERT(datetime, '2012-01-03 10:30:22', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (84, N'Zentrale Dienste SZ', NULL, 0, N'SOD SZ - verantwortliche Mitarbeitende für Scannen/Zuordnen von Papierdokumenten (ohne Zahlungsverkehr ausserhalb der Teams)', NULL, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (85, N'Recht SzHilfe & SzVersRecht', 20893, 0, N'SDS RD - Mitarbeitende Rechtsdienst, Bereich WH und Sozialversicherungsrecht (ohne Visumskompetenz)', 20892, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Bedag, Support (8545)', CONVERT(datetime, '2012-07-24 18:00:56', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (86, N'Registratur und Archiv', 16420, 0, N'SDS Registratur - verantwortliche Mitarbeitende für Registratur und Archivierung der Dossier (alle Leistungen)', 16419, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Stäuble, Urs (2257)', CONVERT(datetime, '2011-04-19 10:28:30', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (87, N'Administration Vorlagen', 17037, 0, N'SDS/SOD - verantwortliche Mitarbeitende für die Vorlagen-Pflege für KiSS (alle Leistungen)', 17036, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Eberle, Markus (8459)', CONVERT(datetime, '2011-06-21 07:42:29', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (88, N'Administration Adressverwaltung', 16381, 0, N'SDS/SOD - verantwortliche Mitarbeitende für die Adress-Datenbank-Pflege KiSS
und Löschen von definitiv gesetzten Institutionen', 16380, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Stäuble, Urs (2257)', CONVERT(datetime, '2011-08-24 09:06:23', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (89, N'SYSTEM Administrator', 17060, 0, N'SDS - verantwortliche Mitarbeitende für die Systemadminstration KiSS', 17059, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Bestebreurtje, Frank (561)', CONVERT(datetime, '2012-03-28 09:46:48', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (93, N'Behörde KESB', 17717, 0, N'KESB - Behördenmitglieder, Berichtsprüfer/innen (zeitlich befristetes Gastrecht bei den betroffenen Fällen/Leistung K VM; alle Masken K ohne Master/Monatsbudget)', 17716, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Eberle, Markus (8459)', CONVERT(datetime, '2011-12-19 15:41:56', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (94, N'Finanzsupport MDAS', 17042, 0, N'SDS Finanzen - verantwortliche Mitarbeitende Klibu für die Bewirtschaftung von Mietzinsdepot und Anteilsscheine (WH)', 17041, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Bestebreurtje, Frank (561)', CONVERT(datetime, '2011-06-22 08:24:13', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (95, N'Finanzsupport Inkasso', 16622, 0, N'SDS Finanzen - verantwortliche Mitarbeitende für Inkasso VU/UP und Rückerstattungen WH', 16621, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Stäuble, Urs (2257)', CONVERT(datetime, '2011-05-20 16:33:09', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (104, N'Administration Benutzerverwaltung', 17033, 0, N'Verwaltung der Mitarbeitenden, der Rollen, der Kompetenzen und des Fallzugriffs', 17032, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Eberle, Markus (8459)', CONVERT(datetime, '2011-06-21 07:42:22', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (105, N'Alimentenstelle Support', 16728, 0, N'SOD AS - Sekretariat Alimentenstelle (Scannen, CheckIn erfassen; eingehende Rechnungen kontieren; Index-Pflege)', 16727, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Bestebreurtje, Frank (561)', CONVERT(datetime, '2011-05-23 13:17:18', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (106, N'Person ohne ZIP mit Leistung', 16886, 0, NULL, NULL, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Bestebreurtje, Frank (561)', CONVERT(datetime, '2011-05-31 08:54:30', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (107, N'Finanzsupport K - Rechnungen erfassen', 17572, 0, N'Benutzergruppe für Zahlungserfasser/innen im Team Klibu VM', 17571, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Eberle, Markus (8459)', CONVERT(datetime, '2012-05-08 14:14:27', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (108, N'Wohnsitzerfassung ZIP-Personen', 17707, 0, N'Erfassung/Verwaltung von zusätzlichen Wohnsitz Einträgen, trotz ALPHA-Kopplung via ZIP-Nr (speziell bei fehlendem Wohnsitz bei Alpha-passiven Personen)  - für Zahlungsadressen notwendig', 17706, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Stäuble, Urs (2257)', CONVERT(datetime, '2011-12-15 13:05:00', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (109, N'MKKP', 16418, 0, N'SB zuständig für Schlussabrechnungen und MKKP-Bereich mit Zugriff auf alle Fälle im eigenen Sozialzentrum', 16417, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Stäuble, Urs (2257)', CONVERT(datetime, '2011-04-19 10:27:37', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (110, N'MKKP+', 17044, 0, N'SB zuständig für Kontrolle MKKP mit Zugriff auf alle Fälle stadtweit (aktuell Dummy-Rolle ohne definierte Maskenzugriffe)', 17043, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Bestebreurtje, Frank (561)', CONVERT(datetime, '2011-06-22 08:24:20', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (111, N'Triagestelle SKZ', 18245, 0, N'SOD ZAV-MA mit Fallzugriff stadtweit mit Aufgabe sämtliche SKZ-Anfragen zu bearbeiten inkl. Mutationsrechte gem. ihrer Standardrolle (aktuell Dummy-Rolle ohne definierte Maskenzugriffe)', 18244, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Stäuble, Urs (2257)', CONVERT(datetime, '2012-03-23 16:59:21', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (112, N'Person_löschen', 17015, 0, N'Sonderrecht für Kerstin & al.', 17014, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Eberle, Markus (8459)', CONVERT(datetime, '2011-06-16 08:57:52', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (114, N'Finanzsupport K - Spezialaufgaben 2', 16385, 0, N'grünes, bewilligtes K-Masterbudget wieder auf grau (In Vorbereitung) stellen', 16384, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Dubach, Daniel (831)', CONVERT(datetime, '2011-04-18 15:01:30', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (116, N'Finanzsupport Weiterverrechnung', 16522, 0, N'SDS Finanzen - verantwortliche Mitarbeitende KliBu für die Weiterverrechnung', 16521, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Bestebreurtje, Frank (561)', CONVERT(datetime, '2011-05-19 13:26:23', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (117, N'Troubleshooter - Spezialrechte', NULL, 0, N'Temporäre Benutzergruppe für Troubleshooter. Zur Zeit nur Recht: COM - DlgFallZuteilung_FTWechsel', NULL, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (118, N'Mitarbeitende Arbeitsintegration ZD', 17069, 0, N'SOD SZ - Arbeitsintegrations-Einsatz Sachbearbeitung Zentrale Dienste im SZ (aktuelle Dummy-Rolle ohne Maskenzuteilung)', 17068, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Stäuble, Urs (2257)', CONVERT(datetime, '2011-07-05 18:19:12', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (119, N'Verantwortliche_SA_zuteilen', 17576, 0, N'Zuteilung von Sozialarbeitenden für Fälle, Leistungen', 17575, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Bestebreurtje, Frank (561)', CONVERT(datetime, '2011-10-31 19:52:58', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (121, N'Stellenleitung-Assistenz QT ohne FF', 17402, 0, N'SOD QT - Sachbearbeitende ohne Fallführung, die die Administration der Fallverteilung vornehmen', 17401, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Dubach, Daniel (831)', CONVERT(datetime, '2011-08-17 15:56:32', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (122, N'Fall-Liste_Test', 16885, 0, N'Gruppe für Testerinnen - Fallliste', 16884, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Bestebreurtje, Frank (561)', CONVERT(datetime, '2011-05-31 08:54:22', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (123, N'Administration Datenbereinigung', 17035, 0, N'verantworliche Mitarbeitende für die Bereinigung von Falldaten', 17034, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Eberle, Markus (8459)', CONVERT(datetime, '2011-06-21 07:42:23', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (124, N'Finanzsupport K - Spezialaufgaben', 16383, 0, N'Masterbudget K: Der Betrag von bewilligten Einnahmen kann verändert werdenDatumVon', 16382, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Dubach, Daniel (831)', CONVERT(datetime, '2011-04-18 15:04:55', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (125, N'Person Alphaimport', 18247, 0, N'Sonderrecht um Alphaimport auszuführen', 18246, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Stäuble, Urs (2257)', CONVERT(datetime, '2012-03-23 16:59:32', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (126, N'Finanzsupport A', 17056, 0, N'SDS Finanzen - verantwortliche Mitarbeitende Klibu für Alimente', 17055, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Bestebreurtje, Frank (561)', CONVERT(datetime, '2011-06-22 10:16:19', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (129, N'Finanzsupport W - Spezialaufgaben', 16387, 0, N'SDS Finanzen - Spezialaufgaben wie Zahlungslauf ausführen etc. (zur Zeit R. Specker, K. Eichenberger, P. Mettler, S. Joss und M. Sandmann)', 16386, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Dubach, Daniel (831)', CONVERT(datetime, '2011-04-18 15:05:40', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (130, N'W löschen für Fallbereinigung', NULL, 0, N'Spezialrecht für Fallbereinigung', NULL, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (131, N'Fallbereinigung - Spezialrechte', 17740, 0, N'Spezialrecht für die Leute, die Fallbereinigungen durchführen (z.Zt. Halil Toraman SZA, Walter Reist / Gerd Billiger (SZAL) und Andrea Erifilidis (SZD und Rest)', 17739, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Eberle, Markus (8459)', CONVERT(datetime, '2012-01-03 15:43:50', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (132, N'Finanzsupport W - Budget', 16879, 0, N'SDS Finanzen - verantwortliche Mitarbeitende, die Budgetpositionen erfassen und ändern können, insbesondere Einnahmen', 16878, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Dubach, Daniel (831)', CONVERT(datetime, '2011-05-26 14:08:13', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (133, N'Finanzsupport W - Institutionen', 16453, 0, N'SDS Finanzen - Einzelzahlungsmaske: Erfassung von beliebigen Kreditoren trotz Ausgabekonto mit Institutionsbindung
Institutionenstamm: Löschen von Institutionen', 16452, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Dubach, Daniel (831)', CONVERT(datetime, '2011-11-21 12:08:38', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (134, N'Fachbereich Pflegekinder', 16620, 0, N'SOD Fachbereich Pflegekinder ist zentrale Anlaufstelle bezüglich SVA für die Fallführenden und die Pflegeeltern. Zugriff nur über von Sozialarbeitenden erteiltes Gastrecht.', 16619, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Stäuble, Urs (2257)', CONVERT(datetime, '2012-03-23 16:58:34', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (135, N'Zentrale Dienste SZ - Leserecht W', NULL, 0, N'Personen der allgemeinen Sachbearbeitung (Zentrale Dienste SZ) brauchen zusätzlich zu ihren Rechten "Zentrale Dienste SZ" Leseberechtigung im W. Die Personen für diese Gruppe werden von den SZ gemeldet.', NULL, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (136, N'Alimentenstelle Poweruser', 16488, 0, N'Spezialrechte für Teamleiter und Poweruser aus der Alimentenstelle', 16487, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Bestebreurtje, Frank (561)', CONVERT(datetime, '2011-05-18 12:35:03', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (137, N'Sicherheitsleistung (InvMDAS)', 17040, 0, NULL, NULL, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Bestebreurtje, Frank (561)', CONVERT(datetime, '2011-06-22 08:23:42', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (141, N'Person an PSCD', 17046, 0, N'Spezialrecht zum Senden von B-Daten ans PSCD', 17045, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Bestebreurtje, Frank (561)', CONVERT(datetime, '2011-06-22 08:28:57', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (142, N'Finanzkontrolle', 20889, 0, N'Revisoren der Finanzkontrolle (Aufnahme mit befristetem Gastrecht nach Mitteilung Leitung SOD)', 20888, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Bedag, Support (8545)', CONVERT(datetime, '2012-07-24 18:00:44', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (144, N'Sozialarbeitende Kompetenz WH', 17398, 0, N'SOD SZ - Finanzkompetenz WH für Sozialarbeitende - Neue Kompetenzordnung ab 10.6.2010', 17397, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Dubach, Daniel (831)', CONVERT(datetime, '2011-08-10 14:21:44', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (146, N'FallKontrolle - Dokuerstellung', 16614, 0, N'Für Pilot SZD  ausschliesslich SOZGUD, SOZANS', 16613, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Stäuble, Urs (2257)', CONVERT(datetime, '2011-05-20 14:29:54', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (147, N'Export/Import IK-Auszug', 17039, 0, N'Ausführen des Exports resp. Imports der IK-Auszüge zum resp. vom SVA', 17038, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Bestebreurtje, Frank (561)', CONVERT(datetime, '2011-06-22 08:23:31', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (148, N'Finanzsupport K - Vermoegensabrechnung', 16491, 0, N'SDS Finanzen - Vermögensabrechnung im V erstellen', 16490, N'System (8601)', CONVERT(datetime, '2011-04-15 18:05:41', 120), N'Stäuble, Urs (2257)', CONVERT(datetime, '2012-03-23 16:59:01', 120))
INSERT INTO [XUserGroup] ([UserGroupID], [UserGroupName], [UserGroupNameTID], [OnlyAdminVisible], [Description], [DescriptionTID], [Creator], [Created], [Modifier], [Modified]) VALUES (149, N'Quartierkoordination', 18179, 0, N'Dezidierte Berechtigungsgruppe für MA Quartierkoordination - Möglichkeit als Teilleistungserbringer ein- und austragen. Zusätzlich zur Berechtigung Sachbearbeitung QT.', 18178, N'Bestebreurtje, Frank (561)', CONVERT(datetime, '2012-02-29 16:59:27', 120), N'Bestebreurtje, Frank (561)', CONVERT(datetime, '2012-04-25 12:06:28', 120))
GO
SET IDENTITY_INSERT [XUserGroup] OFF
GO
COMMIT
GO