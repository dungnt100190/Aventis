SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmFaDokumente;
GO
/*===============================================================================================
  $Revision: 11 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this view to get textmarken for FaDokumente
           Info: FaDokumentAdressTyp   1   Benutzer
                 FaDokumentAdressTyp   2   Klient/in
                 FaDokumentAdressTyp   3   Institution
  -
  RETURNS: Output used for bookmarks within word/excel.
           Hint: If contact person cannot be determined exactly, it is possible to have multiple
                 rows because of fnFaDokumentAdressatKontaktperson-call. in this case, a filter
                 for vwTmFaDokumente.AdressatKPInkID is required!
=================================================================================================
  TEST:    SELECT TOP 100 * FROM dbo.vwTmFaDokumente ORDER BY FaDokumenteID DESC;
=================================================================================================*/

CREATE VIEW dbo.vwTmFaDokumente
AS
SELECT
  FaDokumenteID   = DOC.FaDokumenteID,
  BaPersonID      = DOC.BaPersonID,
  Datum           = DOC.Datum,
  --
  DienstleistungD = dbo.fnGetLOVMLText('FaModulDienstleistungen', DOC.DienstleistungCode, 1),
  DienstleistungF = dbo.fnGetLOVMLText('FaModulDienstleistungen', DOC.DienstleistungCode, 2),
  DienstleistungI = dbo.fnGetLOVMLText('FaModulDienstleistungen', DOC.DienstleistungCode, 3),
  --
  Stichworte      = DOC.Stichworte,
  --
  ThemenD         = dbo.fnLOVMLColumnListe('FaLebensbereich', DOC.ThemenCodes, NULL, 1),
  ThemenF         = dbo.fnLOVMLColumnListe('FaLebensbereich', DOC.ThemenCodes, NULL, 2),
  ThemenI         = dbo.fnLOVMLColumnListe('FaLebensbereich', DOC.ThemenCodes, NULL, 3),
  
  -----------------------------------------------------------------------------
  -- Autor
  -----------------------------------------------------------------------------
  AutorTypID = AutorAdressTypCode,
  DOC.AutorID,
  --
  AutorMANameVorname           = CASE 
                                   WHEN AutorAdressTypCode = 1 THEN dbo.fnGetLastFirstName(NULL, USRAU.LastName, USRAU.FirstName)
                                   ELSE NULL
                                 END,
  AutorMANameVornameOhneKomma  = CASE 
                                   WHEN AutorAdressTypCode = 1 THEN REPLACE(dbo.fnGetLastFirstName(NULL, USRAU.LastName, USRAU.FirstName), ',', '')
                                   ELSE NULL
                                 END,
  AutorMAVornameName           = CASE 
                                   WHEN AutorAdressTypCode = 1 THEN REPLACE(dbo.fnGetLastFirstName(NULL, USRAU.FirstName, USRAU.LastName), ',', '')
                                   ELSE NULL
                                 END,
  --
  AutorAnschriftEinzD  = CASE 
                           WHEN AutorAdressTypCode = 1 THEN dbo.fnGetFlexibleAdress(DOC.AutorID, NULL, 1, 0, 'orgunit', 0, 1, 'vornach', dbo.fnGetGenderMLTitle(USRAU.GenderCode, 'dbGeneral', 'Herr', 'Frau', NULL, 1, NULL), 0, 1, 1, 0, 1, 0, 0, 0, 0)
                           WHEN AutorAdressTypCode = 2 THEN dbo.fnGetFlexibleAdress(DOC.AutorID, NULL, 1, 0, 'anschrift', 0, 1, 'vornach', dbo.fnGetGenderMLTitle(PRSAU.GeschlechtCode, 'dbGeneral', 'Herr', 'Frau', NULL, 1, NULL), 1, 1, 1, 1, 1, 0, 0, 1, 1)
                           WHEN AutorAdressTypCode = 3 THEN dbo.fnGetFlexibleAdress(DOC.AutorID, NULL, 1, 0, 'institution', 1, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                           ELSE NULL
                         END,
  AutorAnschriftEinzF  = CASE 
                           WHEN AutorAdressTypCode = 1 THEN dbo.fnGetFlexibleAdress(DOC.AutorID, NULL, 2, 0, 'orgunit', 0, 1, 'vornach', dbo.fnGetGenderMLTitle(USRAU.GenderCode, 'dbGeneral', 'Herr', 'Frau', NULL, 2, NULL), 0, 1, 1, 0, 1, 0, 0, 0, 0)
                           WHEN AutorAdressTypCode = 2 THEN dbo.fnGetFlexibleAdress(DOC.AutorID, NULL, 2, 0, 'anschrift', 0, 1, 'vornach', dbo.fnGetGenderMLTitle(PRSAU.GeschlechtCode, 'dbGeneral', 'Herr', 'Frau', NULL, 2, NULL), 1, 1, 1, 1, 1, 0, 0, 1, 1)
                           WHEN AutorAdressTypCode = 3 THEN dbo.fnGetFlexibleAdress(DOC.AutorID, NULL, 2, 0, 'institution', 1, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                           ELSE NULL
                         END,
  AutorAnschriftEinzI  = CASE 
                           WHEN AutorAdressTypCode = 1 THEN dbo.fnGetFlexibleAdress(DOC.AutorID, NULL, 3, 0, 'orgunit', 0, 1, 'vornach', dbo.fnGetGenderMLTitle(USRAU.GenderCode, 'dbGeneral', 'Herr', 'Frau', NULL, 3, NULL), 0, 1, 1, 0, 1, 0, 0, 0, 0)
                           WHEN AutorAdressTypCode = 2 THEN dbo.fnGetFlexibleAdress(DOC.AutorID, NULL, 3, 0, 'anschrift', 0, 1, 'vornach', dbo.fnGetGenderMLTitle(PRSAU.GeschlechtCode, 'dbGeneral', 'Herr', 'Frau', NULL, 3, NULL), 1, 1, 1, 1, 1, 0, 0, 1, 1)
                           WHEN AutorAdressTypCode = 3 THEN dbo.fnGetFlexibleAdress(DOC.AutorID, NULL, 3, 0, 'institution', 1, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                           ELSE NULL
                         END,
  --
  AutorAnschriftMehrzD = CASE 
                           WHEN AutorAdressTypCode = 1 THEN dbo.fnGetFlexibleAdress(DOC.AutorID, NULL, 1, 1, 'orgunit', 0, 1, 'vornach', dbo.fnGetGenderMLTitle(USRAU.GenderCode, 'dbGeneral', 'Herr', 'Frau', NULL, 1, NULL), 0, 1, 1, 0, 1, 0, 0, 0, 0)
                           WHEN AutorAdressTypCode = 2 THEN dbo.fnGetFlexibleAdress(DOC.AutorID, NULL, 1, 1, 'anschrift', 0, 1, 'vornach', dbo.fnGetGenderMLTitle(PRSAU.GeschlechtCode, 'dbGeneral', 'Herr', 'Frau', NULL, 1, NULL), 1, 1, 1, 1, 1, 0, 0, 1, 1)
                           WHEN AutorAdressTypCode = 3 THEN dbo.fnGetFlexibleAdress(DOC.AutorID, NULL, 1, 1, 'institution', 1, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                           ELSE NULL
                         END,
  AutorAnschriftMehrzF = CASE 
                           WHEN AutorAdressTypCode = 1 THEN dbo.fnGetFlexibleAdress(DOC.AutorID, NULL, 2, 1, 'orgunit', 0, 1, 'vornach', dbo.fnGetGenderMLTitle(USRAU.GenderCode, 'dbGeneral', 'Herr', 'Frau', NULL, 2, NULL), 0, 1, 1, 0, 1, 0, 0, 0, 0)
                           WHEN AutorAdressTypCode = 2 THEN dbo.fnGetFlexibleAdress(DOC.AutorID, NULL, 2, 1, 'anschrift', 0, 1, 'vornach', dbo.fnGetGenderMLTitle(PRSAU.GeschlechtCode, 'dbGeneral', 'Herr', 'Frau', NULL, 2, NULL), 1, 1, 1, 1, 1, 0, 0, 1, 1)
                           WHEN AutorAdressTypCode = 3 THEN dbo.fnGetFlexibleAdress(DOC.AutorID, NULL, 2, 1, 'institution', 1, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                           ELSE NULL
                         END,
  AutorAnschriftMehrzI = CASE 
                           WHEN AutorAdressTypCode = 1 THEN dbo.fnGetFlexibleAdress(DOC.AutorID, NULL, 3, 1, 'orgunit', 0, 1, 'vornach', dbo.fnGetGenderMLTitle(USRAU.GenderCode, 'dbGeneral', 'Herr', 'Frau', NULL, 3, NULL), 0, 1, 1, 0, 1, 0, 0, 0, 0)
                           WHEN AutorAdressTypCode = 2 THEN dbo.fnGetFlexibleAdress(DOC.AutorID, NULL, 3, 1, 'anschrift', 0, 1, 'vornach', dbo.fnGetGenderMLTitle(PRSAU.GeschlechtCode, 'dbGeneral', 'Herr', 'Frau', NULL, 3, NULL), 1, 1, 1, 1, 1, 0, 0, 1, 1)
                           WHEN AutorAdressTypCode = 3 THEN dbo.fnGetFlexibleAdress(DOC.AutorID, NULL, 3, 1, 'institution', 1, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                           ELSE NULL
                         END,
  --
  AutorFax             = CASE 
                           WHEN AutorAdressTypCode = 1 THEN ORGAU.Fax
                           WHEN AutorAdressTypCode = 2 THEN PRSAU.Fax
                           WHEN AutorAdressTypCode = 3 THEN INSAU.Fax
                           ELSE NULL
                         END,
  AutorTelefon         = CASE 
                           WHEN AutorAdressTypCode = 1 THEN USRAU.PhoneOffice
                           WHEN AutorAdressTypCode = 2 THEN PRSAU.Telefon_P
                           WHEN AutorAdressTypCode = 3 THEN INSAU.Telefon
                           ELSE NULL
                         END,
  AutorEmail           = CASE 
                           WHEN AutorAdressTypCode = 1 THEN USRAU.EMail
                           WHEN AutorAdressTypCode = 2 THEN PRSAU.EMail
                           WHEN AutorAdressTypCode = 3 THEN INSAU.EMail
                           ELSE NULL
                         END,
  --
  AutorKontaktperson   = CASE 
                           WHEN AutorAdressTypCode = 3 THEN (SELECT TOP 1 REPLACE(dbo.fnGetLastFirstName(NULL, INK.Name, INK.Vorname), ',', '')
                                                             FROM dbo.BaPerson_BaInstitution       BPI WITH(READUNCOMMITTED)
                                                               INNER JOIN dbo.BaInstitutionKontakt INK WITH (READUNCOMMITTED) ON INK.BaInstitutionKontaktID = BPI.BaInstitutionKontaktID
                                                             WHERE BPI.BaInstitutionID = DOC.AutorID 
                                                               AND BPI.BaPersonID = ISNULL(DOC.BaPersonID, -1)
                                                             ORDER BY BPI.BaPerson_BaInstitutionID DESC)
                              ELSE NULL
                         END,
  
  -----------------------------------------------------------------------------
  -- Adressat
  -----------------------------------------------------------------------------
  AdressatTypID = AdressatAdressTypCode,
  DOC.AdressatID,
  --
  AdressatMANameVorname           = CASE 
                                      WHEN AdressatAdressTypCode = 1 THEN dbo.fnGetLastFirstName(NULL, USRAD.LastName, USRAD.FirstName)
                                      ELSE NULL
                                    END,
  AdressatMANameVornameOhneKomma  = CASE 
                                      WHEN AdressatAdressTypCode = 1 THEN REPLACE(dbo.fnGetLastFirstName(NULL, USRAD.LastName, USRAD.FirstName), ',', '')
                                      ELSE NULL
                                    END,
  AdressatMAVornameName           = CASE 
                                      WHEN AdressatAdressTypCode = 1 THEN REPLACE(dbo.fnGetLastFirstName(NULL, USRAD.FirstName, USRAD.LastName), ',', '')
                                      ELSE NULL
                                    END,
  --
  AdressatAnschriftEinzD  = CASE 
                              WHEN AdressatAdressTypCode = 1 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 1, 0, 'orgunit', 0, 1, 'vornach', '<herrfraumanuell>', 0, 1, 1, 0, 1, 0, 0, 0, 0)
                              WHEN AdressatAdressTypCode = 2 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 1, 0, 'anschrift', 0, 1, 'vornach', '<herrfraumanuell>', 1, 1, 1, 1, 1, 0, 0, 1, 1)
                              WHEN AdressatAdressTypCode = 3 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 1, 0, 'institution', 1, 1, 'vornach', '<herrfraumanuell>', 1, 1, 1, 1, 1, 0, 0, 1, 1)
                              ELSE NULL
                            END,
  AdressatAnschriftEinzF  = CASE 
                              WHEN AdressatAdressTypCode = 1 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 2, 0, 'orgunit', 0, 1, 'vornach', '<herrfraumanuell>', 0, 1, 1, 0, 1, 0, 0, 0, 0)
                              WHEN AdressatAdressTypCode = 2 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 2, 0, 'anschrift', 0, 1, 'vornach', '<herrfraumanuell>', 1, 1, 1, 1, 1, 0, 0, 1, 1)
                              WHEN AdressatAdressTypCode = 3 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 2, 0, 'institution', 1, 1, 'vornach', '<herrfraumanuell>', 1, 1, 1, 1, 1, 0, 0, 1, 1)
                              ELSE NULL
                            END,
  AdressatAnschriftEinzI  = CASE 
                              WHEN AdressatAdressTypCode = 1 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 3, 0, 'orgunit', 0, 1, 'vornach', '<herrfraumanuell>', 0, 1, 1, 0, 1, 0, 0, 0, 0)
                              WHEN AdressatAdressTypCode = 2 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 3, 0, 'anschrift', 0, 1, 'vornach', '<herrfraumanuell>', 1, 1, 1, 1, 1, 0, 0, 1, 1)
                              WHEN AdressatAdressTypCode = 3 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 3, 0, 'institution', 1, 1, 'vornach', '<herrfraumanuell>', 1, 1, 1, 1, 1, 0, 0, 1, 1)
                              ELSE NULL
                            END,
  --
  AdressatAnschriftMehrzD = CASE 
                              WHEN AdressatAdressTypCode = 1 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 1, 1, 'orgunit', 0, 1, 'vornach', '<herrfraumanuell>', 0, 1, 1, 0, 1, 0, 0, 0, 0)
                              WHEN AdressatAdressTypCode = 2 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 1, 1, 'anschrift', 1, 1, 'vornach', '<herrfraumanuell>', 1, 1, 1, 1, 1, 0, 0, 1, 1)
                              WHEN AdressatAdressTypCode = 3 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 1, 1, 'institution', 1, 1, 'vornach', '<herrfraumanuell>', 1, 1, 1, 1, 1, 0, 0, 1, 1)
                              ELSE NULL
                            END,
  AdressatAnschriftMehrzF = CASE 
                              WHEN AdressatAdressTypCode = 1 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 2, 1, 'orgunit', 0, 1, 'vornach', '<herrfraumanuell>', 0, 1, 1, 0, 1, 0, 0, 0, 0)
                              WHEN AdressatAdressTypCode = 2 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 2, 1, 'anschrift', 1, 1, 'vornach', '<herrfraumanuell>', 1, 1, 1, 1, 1, 0, 0, 1, 1)
                              WHEN AdressatAdressTypCode = 3 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 2, 1, 'institution', 1, 1, 'vornach', '<herrfraumanuell>', 1, 1, 1, 1, 1, 0, 0, 1, 1)
                              ELSE NULL
                            END,
  AdressatAnschriftMehrzI = CASE 
                              WHEN AdressatAdressTypCode = 1 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 3, 1, 'orgunit', 0, 1, 'vornach', '<herrfraumanuell>', 0, 1, 1, 0, 1, 0, 0, 0, 0)
                              WHEN AdressatAdressTypCode = 2 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 3, 1, 'anschrift', 1, 1, 'vornach', '<herrfraumanuell>', 1, 1, 1, 1, 1, 0, 0, 1, 1)
                              WHEN AdressatAdressTypCode = 3 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 3, 1, 'institution', 1, 1, 'vornach', '<herrfraumanuell>', 1, 1, 1, 1, 1, 0, 0, 1, 1)
                              ELSE NULL
                            END,
  --
  AdressatFax             = CASE 
                              WHEN AdressatAdressTypCode = 1 THEN ORGAU.Fax
                              WHEN AdressatAdressTypCode = 2 THEN PRSAD.Fax
                              WHEN AdressatAdressTypCode = 3 THEN INSAD.Fax
                              ELSE NULL
                            END,
  AdressatTelefon         = CASE 
                              WHEN AdressatAdressTypCode = 1 THEN USRAD.PhoneOffice
                              WHEN AdressatAdressTypCode = 2 THEN PRSAD.Telefon_P
                              WHEN AdressatAdressTypCode = 3 THEN INSAD.Telefon
                              ELSE NULL
                            END,
  AdressatEmail           = CASE 
                              WHEN AdressatAdressTypCode = 1 THEN USRAD.EMail
                              WHEN AdressatAdressTypCode = 2 THEN PRSAD.EMail
                              WHEN AdressatAdressTypCode = 3 THEN INSAD.EMail
                              ELSE NULL
                            END,
  
  -----------------------------------------------------------------------------
  -- Adressat with handling of contact person
  -- see: #7763 for further information
  -----------------------------------------------------------------------------
  AdressatKontaktperson   = CASE 
                              WHEN AdressatAdressTypCode = 3 THEN (SELECT REPLACE(dbo.fnGetLastFirstName(NULL, INK.Name, INK.Vorname), ',', '')
                                                                   FROM dbo.BaInstitutionKontakt INK WITH (READUNCOMMITTED)
                                                                   WHERE INK.BaInstitutionKontaktID = FNINKAD.BaInstitutionKontaktID)
                              ELSE NULL
                            END,
  --
  AdressatKPInsID         = FNINKAD.BaInstitutionID,
  AdressatKPPrsID         = FNINKAD.BaPersonID_Betrifft,
  AdressatKPInkID         = FNINKAD.BaInstitutionKontaktID,
  --
  AdressatKPAnschrEinzD   = CASE 
                              WHEN AdressatAdressTypCode = 1 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 1, 0, 'orgunit', 0, 1, 'vornach', dbo.fnGetGenderMLTitle(USRAD.GenderCode, 'dbGeneral', 'Herr', 'Frau', NULL, 1, NULL), 0, 1, 1, 0, 1, 0, 0, 0, 0)
                              WHEN AdressatAdressTypCode = 2 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 1, 0, 'anschrift', 0, 1, 'vornach', dbo.fnGetGenderMLTitle(PRSAD.GeschlechtCode, 'dbGeneral', 'Herr', 'Frau', NULL, 1, NULL), 1, 1, 1, 1, 1, 0, 0, 1, 1)
                              WHEN AdressatAdressTypCode = 3 THEN 
                                CASE 
                                  WHEN FNINKAD.BaInstitutionKontaktID IS NULL 
                                    THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 1, 0, 'institution', 1, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                                  ELSE dbo.fnGetFlexibleAdress(DOC.AdressatID, FNINKAD.BaInstitutionKontaktID, 1, 0, 'institution', 1, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                                END
                              ELSE NULL
                            END,
  AdressatKPAnschrEinzF   = CASE 
                              WHEN AdressatAdressTypCode = 1 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 2, 0, 'orgunit', 0, 1, 'vornach', dbo.fnGetGenderMLTitle(USRAD.GenderCode, 'dbGeneral', 'Herr', 'Frau', NULL, 2, NULL), 0, 1, 1, 0, 1, 0, 0, 0, 0)
                              WHEN AdressatAdressTypCode = 2 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 2, 0, 'anschrift', 0, 1, 'vornach', dbo.fnGetGenderMLTitle(PRSAD.GeschlechtCode, 'dbGeneral', 'Herr', 'Frau', NULL, 2, NULL), 1, 1, 1, 1, 1, 0, 0, 1, 1)
                              WHEN AdressatAdressTypCode = 3 THEN 
                                CASE 
                                  WHEN FNINKAD.BaInstitutionKontaktID IS NULL 
                                    THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 2, 0, 'institution', 1, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                                  ELSE dbo.fnGetFlexibleAdress(DOC.AdressatID, FNINKAD.BaInstitutionKontaktID, 2, 0, 'institution', 1, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                                END
                              ELSE NULL
                            END,
  AdressatKPAnschrEinzI   = CASE 
                              WHEN AdressatAdressTypCode = 1 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 3, 0, 'orgunit', 0, 1, 'vornach', dbo.fnGetGenderMLTitle(USRAD.GenderCode, 'dbGeneral', 'Herr', 'Frau', NULL, 3, NULL), 0, 1, 1, 0, 1, 0, 0, 0, 0)
                              WHEN AdressatAdressTypCode = 2 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 3, 0, 'anschrift', 0, 1, 'vornach', dbo.fnGetGenderMLTitle(PRSAD.GeschlechtCode, 'dbGeneral', 'Herr', 'Frau', NULL, 3, NULL), 1, 1, 1, 1, 1, 0, 0, 1, 1)
                              WHEN AdressatAdressTypCode = 3 THEN 
                                CASE 
                                  WHEN FNINKAD.BaInstitutionKontaktID IS NULL 
                                    THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 3, 0, 'institution', 1, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                                  ELSE dbo.fnGetFlexibleAdress(DOC.AdressatID, FNINKAD.BaInstitutionKontaktID, 3, 0, 'institution', 1, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                                END
                              ELSE NULL
                            END,
  --
  AdressatKPAnschrMehrzD  = CASE 
                              WHEN AdressatAdressTypCode = 1 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 1, 1, 'orgunit', 0, 1, 'vornach', dbo.fnGetGenderMLTitle(USRAD.GenderCode, 'dbGeneral', 'Herr', 'Frau', NULL, 1, NULL), 0, 1, 1, 0, 1, 0, 0, 0, 0)
                              WHEN AdressatAdressTypCode = 2 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 1, 1, 'anschrift', 1, 1, 'vornach', dbo.fnGetGenderMLTitle(PRSAD.GeschlechtCode, 'dbGeneral', 'Herr', 'Frau', NULL, 1, NULL), 1, 1, 1, 1, 1, 0, 0, 1, 1)
                              WHEN AdressatAdressTypCode = 3 THEN 
                                CASE 
                                  WHEN FNINKAD.BaInstitutionKontaktID IS NULL 
                                    THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 1, 1, 'institution', 1, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                                  ELSE dbo.fnGetFlexibleAdress(DOC.AdressatID, FNINKAD.BaInstitutionKontaktID, 1, 1, 'institution', 1, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                                END
                              ELSE NULL
                            END,
  AdressatKPAnschrMehrzF  = CASE 
                              WHEN AdressatAdressTypCode = 1 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 2, 1, 'orgunit', 0, 1, 'vornach', dbo.fnGetGenderMLTitle(USRAD.GenderCode, 'dbGeneral', 'Herr', 'Frau', NULL, 2, NULL), 0, 1, 1, 0, 1, 0, 0, 0, 0)
                              WHEN AdressatAdressTypCode = 2 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 2, 1, 'anschrift', 1, 1, 'vornach', dbo.fnGetGenderMLTitle(PRSAD.GeschlechtCode, 'dbGeneral', 'Herr', 'Frau', NULL, 2, NULL), 1, 1, 1, 1, 1, 0, 0, 1, 1)
                              WHEN AdressatAdressTypCode = 3 THEN 
                                CASE 
                                  WHEN FNINKAD.BaInstitutionKontaktID IS NULL 
                                    THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 2, 1, 'institution', 1, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                                  ELSE dbo.fnGetFlexibleAdress(DOC.AdressatID, FNINKAD.BaInstitutionKontaktID, 2, 1, 'institution', 1, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                                END
                              ELSE NULL
                            END,
  AdressatKPAnschrMehrzI  = CASE 
                              WHEN AdressatAdressTypCode = 1 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 3, 1, 'orgunit', 0, 1, 'vornach', dbo.fnGetGenderMLTitle(USRAD.GenderCode, 'dbGeneral', 'Herr', 'Frau', NULL, 3, NULL), 0, 1, 1, 0, 1, 0, 0, 0, 0)
                              WHEN AdressatAdressTypCode = 2 THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 3, 1, 'anschrift', 1, 1, 'vornach', dbo.fnGetGenderMLTitle(PRSAD.GeschlechtCode, 'dbGeneral', 'Herr', 'Frau', NULL, 3, NULL), 1, 1, 1, 1, 1, 0, 0, 1, 1)
                              WHEN AdressatAdressTypCode = 3 THEN 
                                CASE 
                                  WHEN FNINKAD.BaInstitutionKontaktID IS NULL 
                                    THEN dbo.fnGetFlexibleAdress(DOC.AdressatID, NULL, 3, 1, 'institution', 1, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                                  ELSE dbo.fnGetFlexibleAdress(DOC.AdressatID, FNINKAD.BaInstitutionKontaktID, 3, 1, 'institution', 1, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                                END
                              ELSE NULL
                            END,
  --
  AdressatKPFax           = CASE 
                              WHEN AdressatAdressTypCode = 1 THEN ORGAU.Fax
                              WHEN AdressatAdressTypCode = 2 THEN PRSAD.Fax
                              WHEN AdressatAdressTypCode = 3 THEN 
                                CASE 
                                  WHEN FNINKAD.BaInstitutionKontaktID IS NULL 
                                    THEN INSAD.Fax
                                  ELSE INKAD.Fax
                                END
                              ELSE NULL
                            END,
  AdressatKPTelefon       = CASE 
                              WHEN AdressatAdressTypCode = 1 THEN USRAD.PhoneOffice
                              WHEN AdressatAdressTypCode = 2 THEN PRSAD.Telefon_P
                              WHEN AdressatAdressTypCode = 3 THEN 
                                CASE 
                                  WHEN FNINKAD.BaInstitutionKontaktID IS NULL 
                                    THEN INSAD.Telefon
                                  ELSE INKAD.Telefon
                                END
                              ELSE NULL
                            END,
  AdressatKPEmail         = CASE 
                              WHEN AdressatAdressTypCode = 1 THEN USRAD.EMail
                              WHEN AdressatAdressTypCode = 2 THEN PRSAD.EMail
                              WHEN AdressatAdressTypCode = 3 THEN 
                                CASE 
                                  WHEN FNINKAD.BaInstitutionKontaktID IS NULL 
                                    THEN INSAD.EMail
                                  ELSE INKAD.EMail
                                END
                              ELSE NULL
                            END,
  -- Name/Vorname
  AdressatKPName          = CASE 
                              WHEN AdressatAdressTypCode = 1 THEN USRAD.LastName
                              WHEN AdressatAdressTypCode = 2 THEN PRSAD.Name
                              WHEN AdressatAdressTypCode = 3 THEN 
                                CASE 
                                  WHEN FNINKAD.BaInstitutionKontaktID IS NULL 
                                    THEN INSAD.Name
                                  ELSE INKAD.Name
                                END
                              ELSE NULL
                            END,
  AdressatKPVorname       = CASE 
                              WHEN AdressatAdressTypCode = 1 THEN USRAD.FirstName
                              WHEN AdressatAdressTypCode = 2 THEN PRSAD.Vorname
                              WHEN AdressatAdressTypCode = 3 THEN 
                                CASE 
                                  WHEN FNINKAD.BaInstitutionKontaktID IS NULL 
                                    THEN INSAD.Vorname
                                  ELSE INKAD.Vorname
                                END
                              ELSE NULL
                            END,
  AdressatKPNameVornMitK  = CASE 
                              WHEN AdressatAdressTypCode = 1 THEN dbo.fnGetLastFirstName(NULL, USRAD.LastName, USRAD.FirstName)
                              WHEN AdressatAdressTypCode = 2 THEN dbo.fnGetLastFirstName(NULL, PRSAD.Name, PRSAD.Vorname)
                              WHEN AdressatAdressTypCode = 3 THEN 
                                CASE 
                                  WHEN FNINKAD.BaInstitutionKontaktID IS NULL 
                                    THEN dbo.fnGetLastFirstName(NULL, INSAD.Name, INSAD.Vorname)
                                  ELSE dbo.fnGetLastFirstName(NULL, INKAD.Name, INKAD.Vorname)
                                END
                              ELSE NULL
                            END,
  AdressatKPNameVornOhneK = CASE 
                              WHEN AdressatAdressTypCode = 1 THEN REPLACE(dbo.fnGetLastFirstName(NULL, USRAD.LastName, USRAD.FirstName), ',', '')
                              WHEN AdressatAdressTypCode = 2 THEN REPLACE(dbo.fnGetLastFirstName(NULL, PRSAD.Name, PRSAD.Vorname), ',', '')
                              WHEN AdressatAdressTypCode = 3 THEN 
                                CASE 
                                  WHEN FNINKAD.BaInstitutionKontaktID IS NULL 
                                    THEN REPLACE(dbo.fnGetLastFirstName(NULL, INSAD.Name, INSAD.Vorname), ',', '')
                                  ELSE REPLACE(dbo.fnGetLastFirstName(NULL, INKAD.Name, INKAD.Vorname), ',', '')
                                END
                              ELSE NULL
                            END,
  AdressatKPVornNameOhneK = CASE 
                              WHEN AdressatAdressTypCode = 1 THEN REPLACE(dbo.fnGetLastFirstName(NULL, USRAD.FirstName, USRAD.LastName), ',', '')
                              WHEN AdressatAdressTypCode = 2 THEN REPLACE(dbo.fnGetLastFirstName(NULL, PRSAD.Vorname, PRSAD.Name), ',', '')
                              WHEN AdressatAdressTypCode = 3 THEN 
                                CASE 
                                  WHEN FNINKAD.BaInstitutionKontaktID IS NULL 
                                    THEN REPLACE(dbo.fnGetLastFirstName(NULL, INSAD.Vorname, INSAD.Name), ',', '')
                                  ELSE REPLACE(dbo.fnGetLastFirstName(NULL, INKAD.Vorname, INKAD.Name), ',', '')
                                END
                              ELSE NULL
                            END,  
  -- Anrede/Briefanrede
  AdressatKPAnredeD       = CASE 
                              WHEN AdressatAdressTypCode = 1 THEN dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, '1900-01-01', NULL, USRAD.GenderCode, 1, 'famherrfrau', '', 0, NULL, NULL)
                              WHEN AdressatAdressTypCode = 2 THEN dbo.fnBaGetAnredeAnschriftBaPerson(DOC.BaPersonID, NULL, NULL, NULL, NULL, 1, 'famherrfrau', '', NULL, NULL, NULL)
                              WHEN AdressatAdressTypCode = 3 THEN  
                                CASE 
                                  WHEN FNINKAD.BaInstitutionKontaktID IS NULL 
                                    THEN dbo.fnBaGetAnredeAnschriftBaInstitution(INSAD.BaInstitutionID, NULL, 1, 'herrfrau', '')
                                  ELSE dbo.fnBaGetAnredeAnschriftBaInstitutionKontakt(FNINKAD.BaInstitutionKontaktID, NULL, 1, 'herrfrau', '')
                                END
                              ELSE NULL
                            END,
  AdressatKPAnredeF       = CASE 
                              WHEN AdressatAdressTypCode = 1 THEN dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, '1900-01-01', NULL, USRAD.GenderCode, 2, 'famherrfrau', '', 0, NULL, NULL)
                              WHEN AdressatAdressTypCode = 2 THEN dbo.fnBaGetAnredeAnschriftBaPerson(DOC.BaPersonID, NULL, NULL, NULL, NULL, 2, 'famherrfrau', '', NULL, NULL, NULL)
                              WHEN AdressatAdressTypCode = 3 THEN  
                                CASE 
                                  WHEN FNINKAD.BaInstitutionKontaktID IS NULL 
                                    THEN dbo.fnBaGetAnredeAnschriftBaInstitution(INSAD.BaInstitutionID, NULL, 2, 'herrfrau', '')
                                  ELSE dbo.fnBaGetAnredeAnschriftBaInstitutionKontakt(FNINKAD.BaInstitutionKontaktID, NULL, 2, 'herrfrau', '')
                                END
                              ELSE NULL
                            END,
  AdressatKPAnredeI       = CASE 
                              WHEN AdressatAdressTypCode = 1 THEN dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, '1900-01-01', NULL, USRAD.GenderCode, 3, 'famherrfrau', '', 0, NULL, NULL)
                              WHEN AdressatAdressTypCode = 2 THEN dbo.fnBaGetAnredeAnschriftBaPerson(DOC.BaPersonID, NULL, NULL, NULL, NULL, 3, 'famherrfrau', '', NULL, NULL, NULL)
                              WHEN AdressatAdressTypCode = 3 THEN  
                                CASE 
                                  WHEN FNINKAD.BaInstitutionKontaktID IS NULL 
                                    THEN dbo.fnBaGetAnredeAnschriftBaInstitution(INSAD.BaInstitutionID, NULL, 3, 'herrfrau', '')
                                  ELSE dbo.fnBaGetAnredeAnschriftBaInstitutionKontakt(FNINKAD.BaInstitutionKontaktID, NULL, 3, 'herrfrau', '')
                                END
                              ELSE NULL
                            END,
  
  AdressatKPBriefanredeD  = CASE 
                              WHEN AdressatAdressTypCode = 1 THEN dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, '1900-01-01', NULL, USRAD.GenderCode, 1, 'geehrte', '', 0, NULL, NULL)
                              WHEN AdressatAdressTypCode = 2 THEN dbo.fnBaGetAnredeAnschriftBaPerson(DOC.BaPersonID, NULL, NULL, NULL, NULL, 1, 'geehrte', '', NULL, NULL, NULL)
                              WHEN AdressatAdressTypCode = 3 THEN  
                                CASE 
                                  WHEN FNINKAD.BaInstitutionKontaktID IS NULL 
                                    THEN dbo.fnBaGetAnredeAnschriftBaInstitution(INSAD.BaInstitutionID, NULL, 1, 'geehrte', '')
                                  ELSE dbo.fnBaGetAnredeAnschriftBaInstitutionKontakt(FNINKAD.BaInstitutionKontaktID, NULL, 1, 'geehrte', '')
                                END
                              ELSE NULL
                            END,
  AdressatKPBriefanredeF  = CASE 
                              WHEN AdressatAdressTypCode = 1 THEN dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, '1900-01-01', NULL, USRAD.GenderCode, 2, 'geehrte', '', 0, NULL, NULL)
                              WHEN AdressatAdressTypCode = 2 THEN dbo.fnBaGetAnredeAnschriftBaPerson(DOC.BaPersonID, NULL, NULL, NULL, NULL, 2, 'geehrte', '', NULL, NULL, NULL)
                              WHEN AdressatAdressTypCode = 3 THEN  
                                CASE 
                                  WHEN FNINKAD.BaInstitutionKontaktID IS NULL 
                                    THEN dbo.fnBaGetAnredeAnschriftBaInstitution(INSAD.BaInstitutionID, NULL, 2, 'geehrte', '')
                                  ELSE dbo.fnBaGetAnredeAnschriftBaInstitutionKontakt(FNINKAD.BaInstitutionKontaktID, NULL, 2, 'geehrte', '')
                                END
                              ELSE NULL
                            END,
  AdressatKPBriefanredeI  = CASE 
                              WHEN AdressatAdressTypCode = 1 THEN dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, '1900-01-01', NULL, USRAD.GenderCode, 3, 'geehrte', '', 0, NULL, NULL)
                              WHEN AdressatAdressTypCode = 2 THEN dbo.fnBaGetAnredeAnschriftBaPerson(DOC.BaPersonID, NULL, NULL, NULL, NULL, 3, 'geehrte', '', NULL, NULL, NULL)
                              WHEN AdressatAdressTypCode = 3 THEN  
                                CASE 
                                  WHEN FNINKAD.BaInstitutionKontaktID IS NULL 
                                    THEN dbo.fnBaGetAnredeAnschriftBaInstitution(INSAD.BaInstitutionID, NULL, 3, 'geehrte', '')
                                  ELSE dbo.fnBaGetAnredeAnschriftBaInstitutionKontakt(FNINKAD.BaInstitutionKontaktID, NULL, 3, 'geehrte', '')
                                END
                              ELSE NULL
                            END
  -- Anrede/Briefanrede including Name or combine in Word??

FROM dbo.FaDokumente          DOC WITH(READUNCOMMITTED)
  -- autor
  LEFT JOIN dbo.XUser         USRAU WITH(READUNCOMMITTED) ON USRAU.UserID = DOC.AutorID
  LEFT JOIN dbo.XOrgUnit      ORGAU WITH(READUNCOMMITTED) ON ORGAU.OrgUnitID = CONVERT(INT, dbo.fnOrgUnitOfUser(USRAU.UserID, 1))
  LEFT JOIN dbo.BaPerson      PRSAU WITH(READUNCOMMITTED) ON PRSAU.BaPersonID = DOC.AutorID
  LEFT JOIN dbo.BaInstitution INSAU WITH(READUNCOMMITTED) ON INSAU.BaInstitutionID = DOC.AutorID
  
  -- addressat
  LEFT JOIN dbo.XUser         USRAD WITH(READUNCOMMITTED) ON USRAD.UserID = DOC.AdressatID
  LEFT JOIN dbo.XOrgUnit      ORGAD WITH(READUNCOMMITTED) ON ORGAD.OrgUnitID = CONVERT(INT, dbo.fnOrgUnitOfUser(USRAD.UserID, 1))
  LEFT JOIN dbo.BaPerson      PRSAD WITH(READUNCOMMITTED) ON PRSAD.BaPersonID = DOC.AdressatID
  LEFT JOIN dbo.BaInstitution INSAD WITH(READUNCOMMITTED) ON INSAD.BaInstitutionID = DOC.AdressatID
  
  -- kontaktperson (see #7763)
  OUTER APPLY dbo.fnFaDokumentAdressatKontaktperson(DOC.FaDokumenteID) FNINKAD
  LEFT JOIN dbo.BaInstitutionKontakt                                   INKAD   WITH (READUNCOMMITTED) ON INKAD.BaInstitutionKontaktID = FNINKAD.BaInstitutionKontaktID;
GO