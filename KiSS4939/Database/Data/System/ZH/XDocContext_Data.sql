SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [XDocContext]
GO
SET IDENTITY_INSERT [XDocContext] ON
GO
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (72, N'BaPersonDatenblatt', N'CtlBaPerson
Verwendung in:
B:Klientensystem - Aktive Person
B:Klientensystem - Inaktive Person', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (73, N'FaDokumente', N'Alle Vorlagen in der Dokumentation
Verwendung in:
F:Fallführung - Dokumentation - Dokumente (CtlFaDokumente)
F:Fallführung - Dokumentation - Vertrauliches - Dokumente (CtlFaDokumente)', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (74, N'FaAktennotizen', N'CtlFaAktennotizen
Verwendung in:
F:Fallführung - Dokumentation - Aktennotizen
F:Fallführung - Dokumentation - Vertrauliches - Aktennotizen
F:Fallführung Alimentenstelle - Aktennotizen', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (75, N'FaRessourcenkarte', N'Ressourcenkarte drucken zur Unterzeichnung durch Klient
CtlFaRessourcenkarte
Verwendung in:
F:Fallführung - Dokumentation - Ressourcenkarte', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (76, N'FaAbmachungen', N'CtlFaAbmachungen
Verwendung in:
F:Fallführung - Dokumentation - Auflagen/Sanktionen', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (87, N'FaAbklaerungAuswertungsbogen', N'Auswertungsbogen für Abklärungen
CtlFaAbklaerung
Verwendung in:
F:Fallführung - Lösungsprozess - Abklärung / Auswertung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (88, N'FaAssessmentbericht', N'CtlFaAssessmentbericht Bericht
Verwendung in:
F:Fallführung - Aufnahmeprozess - Assessment - Assessmentbericht', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (90, N'FaZielvereinbarung', N'CtlFaZielvereinbarung
Verwendung in:
F:Fallführung - Lösungsprozess - Zielvereinbarung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (91, N'FaZielvereinbarungAuswertung', N'FaZielvereinbarungAuswertung
Verwendung in:
F:Fallführung - Lösungsprozess - Zielvereinbarung - Zielauswertung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (93, N'FaAssesmentUebergabe', N'CtlFaAssessment
Verwendung in:
F:Fallführung - Aufnahmeprozess - Assessment', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (94, N'FaCheckInUebergabe', N'CtlFaCheckIn
Verwendung in:
F:Fallführung - Aufnahmeprozess - Check In', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (96, N'FaVoranmeldung', N'CtlFaVoranmeldung
Verwendung in:
F:Fallführung - Aufnahmeprozess - Voranmeldung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (97, N'FaUnterlagenliste', N'CtlFaUnterlagenliste. Verwendung in: F:Fallführung - Dokumentation - Unterlagenliste', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (98, N'FaDokumenteAlim', N'Alle Vorlagen in der Dokumentation
Verwendung in:
F:Fallführung Alimentenstelle - Dokumentation - Dokumente (CtlFaDokumente)', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (100, N'FaUnterlagenlisteAlim', N'CtlFaUnterlagenliste. Verwendung in: F:Fallführung Alimentenstelle - Dokumentation - Unterlagenliste', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (101, N'WhEkEntscheid', N'CtlWhEkEntscheid
Verwendung in:
W:Wirtschaftliche Hilfe - EK-Entscheide', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (103, N'KgBudget', N'CtlKgBudget', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (104, N'FaAktennotizenAlim', N'CtlFaAktennotizen
Verwendung in:
FA:Fallführung - Dokumentation - Aktennotizen', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (106, N'AmVerfuegungKKBB', N'Zum Drucken der Verfügung bei AnspruchsberechnungenKKBB', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (108, N'AmVerfuegungBeiblatt', N'Beiblatt (Adresse) für die Verfügung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (110, N'Einkommens-', N'Alimente: Ausdruck der Anspruchsberechnung KKBB', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (111, N'AmVerfuegung', N'Zum Drucken der Verfügung bei Anspruchsberechnungen', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (113, N'WhFinanzplanLeistungsentscheid', N'CtlWhFinanzplan', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (114, N'WhAbrechnung', N'Klientenkontoabrechnung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (115, N'WhBudgetblatt', N'Das Budgetblatt ohne Begleitbrief', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (116, N'WhBudgetBlattMitBegleitbrief', N'Das Budgetblatt mit Begleitbrief', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (117, N'WhDetailblatt', N'Detailblatt der Klientenkontoabrechnung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (118, N'WhErgaenzungsblatt', N'Ergaenzungsblatt zum Detailblatt einer Klientenkontoabrechnung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (119, N'WhKontoauszug', N'Ausdruck des Kontoauszugs', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (120, N'WhOffeneForderung', N'Offene Forderungen in einer Klientenkontoabrechnung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (121, N'WIK - Kontoauszug', N'Kontoauszug für W Inkasso', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (122, N'Rechenschaftsbericht', N'Template für den Rechenschaftsbericht für KES-Massnahmen', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (123, N'BDE_ZLEUebersicht', N'Übersicht auf ZLE-Erfassung ausdrucken', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (124, N'WhFinanzplanKiJu', N'WhFinanzplan Ki/Ju', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (125, N'WhFinanzplanKlaerungsphase', N'WhFinanzplan Klärungsphase', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (126, N'GV_Gesuch', N'Register Gesuch in der Gesuchverwaltung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (127, N'GV_Antrag', N'Register Antrag in der Gesuchverwaltung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (128, N'GV_Beilagen', N'Register Beilagen/Dokumente in der Gesuchverwaltung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (129, N'GV_Bewilligung_Kompetenzstufe1', N'Register Bewilligung in der Gesuchverwaltung, Dokumente für Kompetenzstufe 1', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (130, N'GV_Bewilligung_Kompetenzstufe2', N'Register Bewilligung in der Gesuchverwaltung, Dokumente für Kompetenzstufe 2', 0)
GO
SET IDENTITY_INSERT [XDocContext] OFF
GO
COMMIT
GO