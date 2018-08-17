﻿SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [XDocContext]
GO
SET IDENTITY_INSERT [XDocContext] ON
GO
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (8, N'VmBsInventar', N'vormundschaftliches Inventar - Dokument neu', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (11, N'VmErnennungsurkunde', N'Ernennungsurkunde für vormundschaftliche Massnahmen', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (15, N'VmMfBericht', N'vormundschaftliche Berichtserstattung - Dokument neu', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (16, N'VmIcBericht', N'Bericht und Antrag des IV für vorm. Massnahmen', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (17, N'VmMfBudget', N'Mandatsführung Administration Budget - Dokument neu', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (18, N'VmMfAntragEKSK', N'zustimmungsbedürftige Geschäfte EKSK', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (19, N'VmVaterschaftenDoku', N'Vaterschaftsabklärungen Dokumente', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (26, N'VmMfSituationsberichtSH', N'Situationsberichte für Sozialhilfe', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (27, N'VmMfElKrankheitskostenWord', N'El Krankheistkosten Vorlage Word', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (29, N'VmMfSachversicherungMitteilung', N'Sachverischerungen Mitteilung der Massnahme / Neuanmeldung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (30, N'VmMfSachversicherungMutation', N'Sachversicherungen Mutationsmeldungen', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (31, N'VmMfSachversicherungAufhebung', N'Sachversicherungen Aufhebund der Massnahme / Kündigung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (32, N'VmMfSchuldenDokumente', N'Schulden Dokumente', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (33, N'FaKorrespondenz', N'Allgemeine Korrespondenz Fallführung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (34, N'VmTypisierung', N'Hinterlegte Beschreibung des Mandatsbewirtschaftungssystems', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (35, N'VmSozialversicherungenKorre', N'Korrespondenz Sozialversicherungen', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (36, N'VmSozialversicherungenDrittauszahlung', N'Drittauszahlungsvormular Sozialversicherungen / Renten', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (37, N'VmVaterschaftenMerkblätter', N'Sammlung von Merkblättern zur Vaterschaft', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (38, N'FaDokBesprBericht', NULL, 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (39, N'BaPerson', N'Basis/Stammdaten Person', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (41, N'VmBsKorrespondenz', N'Korrespondenz im Behördenteil Vormundschaftliche Massnahmen', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (42, N'FaIntakeprotokollDokument', N'Fallführung Intakeprotokolle der Abteilungen', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (43, N'FaZusammenarbeitsvertragDokument', N'Fallführung Zusammenarbeitsvertrag der Abteilungen', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (44, N'FaAuswertungDokument', N'Fallführung Auswertung der Abteilungen Beratungsphase', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (45, N'FaUebergabeberichtDokument', N'Fallführung Uebergabebericht der Abteilungen', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (47, N'VmBsBeschwerdeDok', NULL, 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (48, N'VmMfAhvMindesbeitragIkAuszug', N'Brief Auszug aus dem individuellen AHV Konto', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (49, N'VmMfAhvMindesbeitragNeAnmeldung', N'Formular AHV Andmeldung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (50, N'VmMfAhvMindesbeitragNeutral', N'Neutrale Vorlagen zum Thema AHV Beitrag', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (51, N'VmMfDienstleistungNeu', N'Vorlage Mitteilung Massnahme oder Neuanmeldung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (52, N'VmMfDienstleistungMutation', N'Vorlage Mitteilung von Aenderungen ', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (53, N'VmMfDienstleistungEnde', N'Vorlage Ende Dienstleitstung Kündigung oder Aufhebung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (55, N'VmBsDokBesprBericht', N'Dokuteil Behörde Zusammenzug der Besprechungen', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (57, N'FaIntZusammenarbeitsvertragDok', N'Zusammenarbeitsvertrag in Intakephase', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (58, N'VmMfAntragSHExcel', N'Sozialhilfeanträge Excel Formular', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (59, N'VmErbeSiegelungsprotokoll', N'Erbschaftsdienst Siegelungsprotokoll', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (60, N'VmErbeEroeffnungVoll', NULL, 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (61, N'VmErbeEroeffnungAuszug', NULL, 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (62, N'VmErbeEroeffnungsadressen', NULL, 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (63, N'VmErbeVerfuegung', NULL, 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (64, N'VmErbeWiderruf', NULL, 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (65, N'VmErbeBescheinigung', NULL, 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (66, N'VmErbeKorrespondenz', NULL, 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (67, N'VmErbeLiquidationsAbr', NULL, 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (68, N'VmErbeAnschriftErben', NULL, 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (69, N'VmErbeSdErbenliste', NULL, 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (70, N'FaIntakeAuswertungDokument', N'Auswertung Zusammenarbeitsvertag Intake', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (71, N'VmAdoptionBesprBericht', NULL, 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (72, N'FaFinanzantragJa', N'Finanzantrag Jugendamt Beratungsphase', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (73, N'FaIntakeberichtJA', N'Intakebericht JA', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (74, N'FaSituationsberichtJa', N'Situationsbericht JA', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (75, N'FaIntFinanzantragJa', N'Finanzantrag Jugendamt Intakephase', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (76, N'VmErbeUeberweisungRSTA', NULL, 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (77, N'FbDauerauftrag', N'EKS Daueraufräge', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (78, N'VmErbeVollmachtAusl.', NULL, 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (79, N'VmErbeVollmachto.A', NULL, 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (80, N'VmErbeBetreibungsausz.', NULL, 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (81, N'VmErbeEröfSchluss', N'Versand Schlussrechnung (ED)', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (82, N'VmErbeFamilienschein', N'Einholen Familienschein (ED)', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (83, N'VmErbeAdrAnfrage', N'Adressanfrage Miterben (ED)', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (84, N'VmErbeAntrag', NULL, 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (85, N'VmMfSteuernSteuererlass', N'Steuererlassgesuch', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (86, N'VmIcFinanzblatt', N'Dokumentation zur Fallübergabe (Intake Center)', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (88, N'KaAKAsDFragen', N'Abklärung AsD Fragen', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (89, N'KaAKEinzelgespraech', N'Abklärung Ziele Einzelgespräch', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (90, N'KaAKIntAnmeldung', N'Abklärung Anmeldung zur Abklärung', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (91, N'KaAKIntBeurteilung', N'Abklärung Integrationsbeurteilung', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (92, N'KaAKIntSchlussbericht', N'Abklärung Schlussbericht', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (93, N'KaAKPraktikum', N'Abklärung Ziele Praktikumsvereinbarung', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (94, N'KaAKZielvereinbarung', N'Abklärung Ziele Zielvereinbarung', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (95, N'KAAllgKorreDokument', N'Korrespondenz KA', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (96, N'KaAllgVerlaufDokument', N'KA Verlauf', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (97, N'KaIntegBildungAbschluss', N'Integrierte Bildung Abschluss', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (98, N'KaIntegBildungRueckmeldung', N'Integrierte Bildung Rückmeldung', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (99, N'KaPraesenzUebersicht', N'Gesamtübersicht Präsenz', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (100, N'KaQEAustrittCheckliste', N'QE Jobtimum Austrittscheckliste', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (101, N'KaQEAustrittFrageboden', N'QE Jobtimum Austrittsfragebogen', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (102, N'KaQECheckliste', N'QE Jobtimum Intake Checkliste', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (103, N'KaQEEinladung', N'QE Intake Einladung', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (104, N'KaQEEPQArbeitszeugnis', N'QE EPQ Arbeitszeugnis', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (105, N'KaQEEPQAufforderung', N'QE EPQ Aufforderung', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (106, N'KaQEEPQEinladung', N'QE EPQ Einladung', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (107, N'KaQEEPQPersonalblatt', N'QE EPQ Personalblatt', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (108, N'KaQEEPQProgAbbruch', N'QE EPQ Programmabbruch', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (109, N'KaQEEPQZwischenzeugnis', N'QE EPQ Zwischenzeugnis', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (110, N'KaQEEPQProgBeginn', N'QE EPQ Einladung Programmbeginn', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (111, N'KaQEEPQRueckantwort', N'QE EPQ Rückantwort Anbieter Zuweisung', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (112, N'KaQEEPQSchlussbericht', N'QE EPQ Schlussbericht', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (113, N'KaQEEPQTaetigProgramm', N'QE EPQ Tätigkeitsprogramm', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (114, N'KaQEEPQVereinbarung', N'QE EPQ Vereinbarung', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (115, N'KaQEEPQVerlaengerung', N'QE EPQ Verlängerung', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (116, N'KaQEEPQZieleRAV', N'QE EPQ individuelle Ziele RAV', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (117, N'KaQEEPQZwischenbericht', N'QE EPQ Zwischenbericht', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (118, N'KaQEHausordnung', N'QE Jobtimum Intake Best. Hausordnung', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (119, N'KaQEProgAbbruch', N'QE Jobtimum Programmabbruch', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (120, N'KaQESchlussbericht', N'QE Jobtimum Schlussbericht', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (121, N'KaQESchlussberichtBegleitbrief', N'QE Jobtimum Schlussbericht Begleitbrief', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (122, N'KaQETeilnahmebest', N'QE Teilnahmebestätigung', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (123, N'KaQEVerwarnung', N'QE Jobtimum Verwarnung', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (124, N'KaQEVerwarnungBegleitbrief', N'QE Jobtimum Verwarnung Begleitbrief', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (125, N'KaQEZielvereinbarung', N'QE Jobtimum Zielvereinbarung', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (126, N'KaQEZwischenbericht', N'QE Jobtimum Zwischenbericht', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (127, N'KAQJAssessment', N'QJ Assessment', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (128, N'KaQJExternStageEinladung', N'QJ Extern Einladung', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (129, N'KaQJExternStageVereinbarung', N'QJ Extern Stage Vereinbarung', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (130, N'KaQJProzessAusbildungsprog', N'Ausbildungsprogramm Bildung', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (131, N'KaQJProzessBonus', N'Dokument in QJ Prozess Bonus', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (132, N'KaQJProzessKompetenznachweis', N'Kompetenznachweis', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (133, N'KaQJProzessSEMOBericht', N'QJ Beilage SEMO Bericht', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (134, N'KaQJProzessStandortbestimmung', N'Standortbestimmungsformular', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (135, N'KaQJProzessZwischenzeugnis', N'Zwischenzeugnis', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (136, N'KaQJPZSchlussbericht', N'Dokument in QJ Prozess Schlussbericht', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (137, N'KaQJPZZielvereinbarung', N'Dokument in QJ Prozess Zielvereinbarung', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (138, N'KaQJUebersicht', N'Dokument in QJ Übersicht', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (139, N'KaQjVereinbarung', N'Gelbe oder rote Vereinbarung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (140, N'KaQJZwbBeilageSemoBericht', N'KaQJZwbBeilageSemoBericht', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (141, N'KaQJZwbSemoBericht', N'Semo Bericht', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (142, N'KaZuteilFachbereich', N'KA - Allgemein Zuteilung Fachbereich', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (143, N'VmJAGefaehrdungsmeldung', N'Dokument Auflagen', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (144, N'KaQEEPQVerwRegelverstoss', N'QE EPQ Verwarnung Regelverstoss', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (145, N'KaQEEPQVerwNichterscheinen', N'QE EPQ Verwarnung Nichterscheinen', 1)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (146, N'KaBetriebBetriebDokument', N'Dokument in KA-Einsatzorte->Betriebe->Betrieb', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (147, N'KaInizioUebersichtBegleitbrief', N'KA - Inizio Übersicht Begleitbrief', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (148, N'KaInizioUebersichtErstgespraech', N'KA - Inizio Übersicht Einladung Erstgespräch', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (149, N'KaVermBIEAZVereinbarung', N'KA - Vermittlung BI EAZ Vereinbarung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (150, N'KaVermBIPEinsatzVereinbarung', N'KA - Vermittlung BIP Praktikumsvereinbarung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (151, N'KaVermBIStelleFestanstellung', N'KA - Vermittlung BI Festanstellungsbestägigung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (152, N'KaVermProfilBIBIPVermGespraech', N'KA - Vermittlung BI/BIP Vermittlungsprofil Vermittlungsgespräch', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (153, N'KaVermProfilInizioVermErstgespraech', N'KA - Vermittlung Inizio Vermittlungsprofil Erstgespräch/Verlauf', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (154, N'KaVermProfilSIVermGespraech', N'KA - Vermittlung SI Vermittlungsprofil Vermittlungsgespräch', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (155, N'KaVermSIEinsatzAttest', N'KA - Vermittlung SI Attest', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (156, N'KaVermSIEinsatzVereinbarung', N'KA - Vermittlung SI Vereinbarung', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (157, N'KaBetriebGrunddaten', N'Grunddaten in Betriebsmaske KA', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (158, N'KaBetriebVerlauf', N'Verlauf in Betriebsmaske KA', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (159, N'KaEinsatzplatz', N'Grunddaten in Einsatzplatzmaske KA', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (160, N'FaWeisung', N'Fallführung - Weisungen', 0)
INSERT INTO [XDocContext] ([DocContextID], [DocContextName], [Description], [System]) VALUES (161, N'BA_InstitutionFachperson', N'Datenblatt der Institution anzeigen im Institutionenstamm und auf der Basis-Maske Institutionen, Fachpersonen', 0)
GO
SET IDENTITY_INSERT [XDocContext] OFF
GO
COMMIT
GO