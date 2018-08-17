/*===============================================================================================
  $Archive: /KiSS4/Database/Data/Basis/PI/BaInstitutionTyp_Data.sql $
  $Author: Cjaeggi $
  $Modtime: 19.07.10 14:20 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to insert default data into table BaInstitutionTyp. The following 
           settings are important to use:
           
           Last used database:
           KiSS_PI_Dev on CHBEHVS004
           
  INFO:    .
  
  TEST:    SELECT *
           FROM dbo.BaInstitutionTyp
           ORDER BY BaInstitutionTypID;
=================================================================================================
  $Log: /KiSS4/Database/Data/Basis/PI/BaInstitutionTyp_Data.sql $
 * 
 * 3     19.07.10 14:21 Cjaeggi
 * #4167: Added data script for bainstitutiontyp
 * 
 * 2     19.07.10 13:42 Cjaeggi
 * #4167: Updated creator/modifier to "new"
 * 
 * 1     19.07.10 13:21 Cjaeggi
 * #4167: Added new tables including data
=================================================================================================*/

-------------------------------------------------------------------------------
-- insert scripts of data
-------------------------------------------------------------------------------
DELETE FROM [BaInstitutionTyp];
DBCC CHECKIDENT ([BaInstitutionTyp], RESEED, 0);
GO

SET IDENTITY_INSERT [BaInstitutionTyp] ON;
GO

INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (01, N'AHV-Zweigstellen / EL-Stellen', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (02, N'Anwalt/Anwältin', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (03, N'Arbeitgeber/-geberin', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (04, N'Arbeitslosenkasse/RAV', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (05, N'Arzt/Ärztin', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (06, N'Bank/Post', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (07, N'Soz. Beratungsstellen', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (08, N'Freiwillige/r Helfer/in', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (09, N'Geldquellen, Stiftungen', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (10, N'Fürsorgeämter / Sozialhilfe / Gemeindesozialdienste', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (11, N'Heime/Wohnheime', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (12, N'Krankenkassen', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (13, N'Schulen', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (14, N'Spitäler', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (15, N'Spitex', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (16, N'Physiotherapeut/-therapeutin', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (17, N'Vermieter / Liegenschaftsverwaltungen', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (18, N'Versicherungsgesellschaften', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (19, N'Erwachsenenschutzbehörde', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (20, N'Eingl.-, Werkstätten', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (21, N'Zahnarzt/-ärztin', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (22, N'Altersheime', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (23, N'Architekt/Architektin', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (24, N'Assistenzdienste', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (25, N'Ausbildungsstätten', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (26, N'Behindertentransporte', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (27, N'Beistand/Vormund/Beirat', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (28, N'Bildungsangebote', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (29, N'Bildungsklub Institutionen', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (30, N'Bildungsklub Interessenten/Interessentinnen', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (31, N'Bildungsklub Kursleiter/-innen', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (32, N'Bildungsklub Teilnehmer/-innen', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (33, N'Bügergemeinden', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (34, N'Ehemalige Mitarbeiterinnen', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (35, N'Entlastungsdienste', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (36, N'FLB-Kommission', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (37, N'Freizeitangebote', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (38, N'Gemeindeverwaltung', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (39, N'Hilfsmittellieferanten', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (40, N'institutionelle Sozialdienste', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (41, N'IV-Stellen', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (42, N'Jahresbericht mit Begleitbrief allgemein', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (43, N'Kantonale Behörden', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (44, N'Kantonalkommission', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (45, N'Kinderarzt/-ärztin', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (46, N'Kirche / Kirchengemeinden', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (47, N'Mitglieder Behindertenkonferenz', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (48, N'Online-Dienste', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (49, N'Pensionskassen / Vorsorgestiftungen', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (50, N'Printmedien', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (51, N'Psychotherapeut/-therapeutin', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (52, N'Rehabilitationsstätten', 1, 'new', 'new')
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [Name], [Aktiv], [Creator], [Modifier]) VALUES (53, N'Selbsthilfeorganisation', 1, 'new', 'new')
GO

SET IDENTITY_INSERT [BaInstitutionTyp] OFF;
GO