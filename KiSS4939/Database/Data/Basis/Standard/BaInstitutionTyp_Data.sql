/*===============================================================================================
  $Archive: /KiSS4/Database/Data/Basis/Standard/BaInstitutionTyp_Data.sql $
  $Author: Cjaeggi $
  $Modtime: 19.07.10 14:20 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to insert default data into table BaInstitutionTyp. The following 
           settings are important to use:
           
           Last used database:
           KiSS_BSS_Dev on CHBEHVS004
           
  INFO:    .
  
  TEST:    SELECT *
           FROM dbo.BaInstitutionTyp
           ORDER BY BaInstitutionTypID;
=================================================================================================
  $Log: /KiSS4/Database/Data/Basis/Standard/BaInstitutionTyp_Data.sql $
 * 
 * 2     19.07.10 14:21 Cjaeggi
 * #4167: Added data script for bainstitutiontyp
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

INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [OrgUnitID], [Name], [NameTID], [Aktiv], [Bemerkung], [Creator], [Created], [Modifier], [Modified]) VALUES (1, NULL, N'Arbeitgeber/-in', NULL, 1, NULL, N'new', CONVERT(datetime, '2010-07-19 14:13:21', 120), N'new', CONVERT(datetime, '2010-07-19 14:13:21', 120))
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [OrgUnitID], [Name], [NameTID], [Aktiv], [Bemerkung], [Creator], [Created], [Modifier], [Modified]) VALUES (2, NULL, N'Arzt/Ärztin, Zahnarzt/-ärztin', NULL, 1, NULL, N'new', CONVERT(datetime, '2010-07-19 14:13:21', 120), N'new', CONVERT(datetime, '2010-07-19 14:13:21', 120))
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [OrgUnitID], [Name], [NameTID], [Aktiv], [Bemerkung], [Creator], [Created], [Modifier], [Modified]) VALUES (3, NULL, N'Krankenkasse', NULL, 1, NULL, N'new', CONVERT(datetime, '2010-07-19 14:13:21', 120), N'new', CONVERT(datetime, '2010-07-19 14:13:21', 120))
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [OrgUnitID], [Name], [NameTID], [Aktiv], [Bemerkung], [Creator], [Created], [Modifier], [Modified]) VALUES (4, NULL, N'Spital/Klinik', NULL, 1, NULL, N'new', CONVERT(datetime, '2010-07-19 14:13:21', 120), N'new', CONVERT(datetime, '2010-07-19 14:13:21', 120))
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [OrgUnitID], [Name], [NameTID], [Aktiv], [Bemerkung], [Creator], [Created], [Modifier], [Modified]) VALUES (5, NULL, N'Vermieter/-in', NULL, 1, NULL, N'new', CONVERT(datetime, '2010-07-19 14:13:21', 120), N'new', CONVERT(datetime, '2010-07-19 14:13:21', 120))
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [OrgUnitID], [Name], [NameTID], [Aktiv], [Bemerkung], [Creator], [Created], [Modifier], [Modified]) VALUES (6, NULL, N'Andere', NULL, 1, NULL, N'new', CONVERT(datetime, '2010-07-19 14:13:21', 120), N'new', CONVERT(datetime, '2010-07-19 14:13:21', 120))
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [OrgUnitID], [Name], [NameTID], [Aktiv], [Bemerkung], [Creator], [Created], [Modifier], [Modified]) VALUES (7, NULL, N'Amt, Behörde', NULL, 1, NULL, N'new', CONVERT(datetime, '2010-07-19 14:13:21', 120), N'new', CONVERT(datetime, '2010-07-19 14:13:21', 120))
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [OrgUnitID], [Name], [NameTID], [Aktiv], [Bemerkung], [Creator], [Created], [Modifier], [Modified]) VALUES (8, NULL, N'Stat. Einrichtung, Tagesstätte', NULL, 1, NULL, N'new', CONVERT(datetime, '2010-07-19 14:13:21', 120), N'new', CONVERT(datetime, '2010-07-19 14:13:21', 120))
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [OrgUnitID], [Name], [NameTID], [Aktiv], [Bemerkung], [Creator], [Created], [Modifier], [Modified]) VALUES (9, NULL, N'Beratungsstelle, amb. Dienst, Spitex', NULL, 1, NULL, N'new', CONVERT(datetime, '2010-07-19 14:13:21', 120), N'new', CONVERT(datetime, '2010-07-19 14:13:21', 120))
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [OrgUnitID], [Name], [NameTID], [Aktiv], [Bemerkung], [Creator], [Created], [Modifier], [Modified]) VALUES (10, NULL, N'Schule / Kindergarten', NULL, 1, NULL, N'new', CONVERT(datetime, '2010-07-19 14:13:21', 120), N'new', CONVERT(datetime, '2010-07-19 14:13:21', 120))
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [OrgUnitID], [Name], [NameTID], [Aktiv], [Bemerkung], [Creator], [Created], [Modifier], [Modified]) VALUES (11, NULL, N'Sach- / Sozialversicherung', NULL, 1, NULL, N'new', CONVERT(datetime, '2010-07-19 14:13:21', 120), N'new', CONVERT(datetime, '2010-07-19 14:13:21', 120))
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [OrgUnitID], [Name], [NameTID], [Aktiv], [Bemerkung], [Creator], [Created], [Modifier], [Modified]) VALUES (12, NULL, N'Zivilstandsamt', NULL, 1, NULL, N'new', CONVERT(datetime, '2010-07-19 14:13:21', 120), N'new', CONVERT(datetime, '2010-07-19 14:13:21', 120))
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [OrgUnitID], [Name], [NameTID], [Aktiv], [Bemerkung], [Creator], [Created], [Modifier], [Modified]) VALUES (13, NULL, N'Bank', NULL, 1, NULL, N'new', CONVERT(datetime, '2010-07-19 14:13:21', 120), N'new', CONVERT(datetime, '2010-07-19 14:13:21', 120))
INSERT INTO [BaInstitutionTyp] ([BaInstitutionTypID], [OrgUnitID], [Name], [NameTID], [Aktiv], [Bemerkung], [Creator], [Created], [Modifier], [Modified]) VALUES (14, NULL, N'Notar/-in', NULL, 1, NULL, N'new', CONVERT(datetime, '2010-07-19 14:13:21', 120), N'new', CONVERT(datetime, '2010-07-19 14:13:21', 120))
GO

SET IDENTITY_INSERT [BaInstitutionTyp] OFF;
GO