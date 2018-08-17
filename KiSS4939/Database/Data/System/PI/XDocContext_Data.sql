SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [XDocContext]
GO
SET IDENTITY_INSERT [XDocContext] ON
GO
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (2, N'BA_Klientensystem', N'Übersicht Stammdaten auf Person/Klientensystem', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (3, N'FA_Dokumente', N'Dokument auf AKV/Dokumente', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (4, N'FA_Finanzgesuche_Dokumente', N'Dokument auf AKV/Finanzgesuche', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (5, N'FA_Finanzgesuche_Klientenkonto', N'Klientenkonto auf AKV/Finanzgesuche', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (6, N'FA_Finanzgesuche_Beleg', N'Beleg drucken auf AKV/Finanzen,Gesuche', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (7, N'SB_Zielvereinbarung_Handlungsplan', N'Handlungsplan auf CM/Zielvereinbarung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (8, N'CM_Zielvereinbarung_Handlungsplan', N'Handlungsplan auf CM/Zielvereinbarung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (11, N'ED_Einsatzvereinbarung_Einsatzvereinbarung', N'Einsatzvereinbarung auf ED/Einsatzvereinbarung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (12, N'FA_Situationsbeschreibung_Bericht', N'Bericht auf AKV/Situationsbeschreibung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (13, N'FA_Aktenotizen', N'Aktenotizen, einzeln oder alle angezeigten Datensätze', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (14, N'FA_Intake', N'Intake-Protokoll', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (15, N'BDE_ZLEUebersicht', N'Übersicht auf ZLE-Erfassung ausdrucken', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (16, N'FA_Betreuungsinfo_Bericht', N'Bericht auf AKV/Betreuungsinfo', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (17, N'ED_Auswertungsdaten_Bericht', N'Bericht auf ED/Auswertungsdaten', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (18, N'ED_Einsatz_Bestaetigung', N'Bestätigung auf ED/Einsatz', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (19, N'CM_Evaluation_Evaluation', N'Evaluation auf CM/Evaluation', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (20, N'SB_Evaluation_Evaluation', N'Evaluation auf SB/Evaluation', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (21, N'ED_Mitarbeiter_Dokument', N'Dokument auf ED/Mitarbeiterdaten', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (26, N'BW_Einsatzvereinbarung_Einsatzvereinbarung', N'Einsatzvereinbarung auf BW/Einsatzvereinbarung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (27, N'BW_AuswertungOrganisation_Bericht', N'Bericht auf BW/AuswertungOrganisation', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (28, N'BW_Einsatz_Bestaetigung', N'Bestätigung auf BW/Einsatz', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (29, N'GV_Gesuch', N'Register Gesuch in der Gesuchverwaltung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (30, N'GV_Antrag', N'Register Antrag in der Gesuchverwaltung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (31, N'GV_Beilagen', N'Register Beilagen/Dokumente in der Gesuchverwaltung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (32, N'GV_Bewilligung_Kompetenzstufe1', N'Register Bewilligung in der Gesuchverwaltung, Dokumente für Kompetenzstufe 1', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (33, N'GV_Bewilligung_Kompetenzstufe2', N'Register Bewilligung in der Gesuchverwaltung, Dokumente für Kompetenzstufe 2', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (34, N'GV_Auflagen', N'Register Auflagen in der Gesuchverwaltung', 0)
GO
SET IDENTITY_INSERT [XDocContext] OFF
GO
COMMIT
GO