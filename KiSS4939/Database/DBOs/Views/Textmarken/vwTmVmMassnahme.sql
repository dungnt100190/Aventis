SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmVmMassnahme;
GO

/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken um die Daten einer Massnahme und die letzte Mandatsführende Person zu bekommen

  TEST:    SELECT TOP 10 * FROM dbo.vwTmVmMassnahme;
=================================================================================================*/

CREATE VIEW dbo.vwTmVmMassnahme
AS
  SELECT 
    MAS.KesMassnahmeID,

    -- Massnahme
    BeschlussVom   = CONVERT(VARCHAR(10), MAS.DatumVon, 104),
    Aufhebung      = CONVERT(VARCHAR(10), MAS.DatumBis, 104),
    ZGBArtikel     = STUFF((SELECT ', ' + ART.Artikel + IsNull('.' + ART.Absatz, '') + IsNull('.' + ART.Ziffer, '') + ' ' + ART.Gesetz
                            FROM dbo.KesMassnahme_KesArtikel KMA WITH (READUNCOMMITTED)
                              INNER JOIN dbo.KesArtikel      ART WITH (READUNCOMMITTED) ON ART.KesArtikelID = KMA.KesArtikelID
                            WHERE KMA.KesMassnahmeID = MAS.KesMassnahmeID
                            ORDER BY ART.Artikel, ART.Absatz, ART.Ziffer, ART.Gesetz
                            FOR XML PATH('')),
                            1,
                            2, 
                            ''),
    ZGBBez         = STUFF((SELECT ', ' + ART.Bezeichnung
                            FROM dbo.KesMassnahme_KesArtikel KMA WITH (READUNCOMMITTED)
                              INNER JOIN dbo.KesArtikel      ART WITH (READUNCOMMITTED) ON ART.KesArtikelID = KMA.KesArtikelID
                            WHERE KMA.KesMassnahmeID = MAS.KesMassnahmeID
                            ORDER BY ART.Artikel, ART.Absatz, ART.Ziffer, ART.Gesetz
                            FOR XML PATH('')),
                            1,
                            2, 
                            ''),


    -- Mandatsführende Person
    MTAnrede       = CASE WHEN USR.UserID IS NOT NULL
                       THEN CASE USR.GenderCode
                              WHEN 1 THEN 'Herr'
                              WHEN 2 THEN 'Frau'
                              ELSE ''
                            END
                       ELSE dbo.fnBaGetAnredeAnschriftBaInstitution(INS.BaInstitutionID, INS.GeschlechtCode, 1, 'herrfrau', '')
                     END,
    MTGeehrte      = CASE WHEN USR.UserID IS NOT NULL
                       THEN CASE USR.GenderCode
                              WHEN 1 THEN 'Herr'
                              WHEN 2 THEN 'Frau'
                              ELSE ''
                            END
                       ELSE dbo.fnBaGetAnredeAnschriftBaInstitution(INS.BaInstitutionID, INS.GeschlechtCode, 1, 'geehrte', '')
                     END,
    MTName         = CASE WHEN USR.UserID IS NOT NULL
                       THEN ISNULL(USR.FirstName + ' ','') + USR.LastName
                       ELSE ISNULL(INS.Vorname + ' ','') + INS.[Name]
                     END,
    MTNachname     = ISNULL(USR.LastName, INS.[Name]),
    MTVorname      = ISNULL(USR.FirstName, INS.Vorname),
    MTPLZOrt       = ISNULL(ADR.PLZ + ' ','') + ADR.Ort,
    MTStrasseNr    = ADR.Strasse + ISNULL(' ' + ADR.HausNr,''),
    MTTelefonG     = ISNULL(USR.Phone, INS.Telefon2),
    MTTelefonMobil = ISNULL(USR.PhoneMobile, INS.Telefon3),
    MTTelefonP     = ISNULL(USR.PhonePrivat, INS.Telefon),
    MTEmail        = ISNULL(USR.EMail, INS.EMail),
    MTErnennung    = CONVERT(VARCHAR(10), MFP.DatumErnennungsurkunde, 104)
  FROM dbo.KesMassnahme                      MAS WITH (READUNCOMMITTED) 
    LEFT  JOIN dbo.KesMandatsfuehrendePerson MFP WITH (READUNCOMMITTED) ON MFP.KesMassnahmeID = MAS.KesMassnahmeID
                                                                       AND MFP.KesMandatsfuehrendePersonID = (SELECT TOP 1 MFP2.KesMandatsfuehrendePersonID
                                                                                                              FROM dbo.KesMandatsfuehrendePerson MFP2 WITH (READUNCOMMITTED)
                                                                                                              WHERE MFP2.KesMassnahmeID = MFP.KesMassnahmeID
                                                                                                              ORDER BY MFP2.DatumErnennungsurkunde DESC)
    LEFT  JOIN dbo.XUser                     USR WITH (READUNCOMMITTED) ON USR.UserID = MFP.UserID
    LEFT  JOIN dbo.BaInstitution             INS WITH (READUNCOMMITTED) ON INS.BaInstitutionID = MFP.BaInstitutionID
    LEFT  JOIN dbo.BaAdresse                 ADR WITH (READUNCOMMITTED) ON ADR.BaInstitutionID = INS.BaInstitutionID OR ADR.UserID = USR.UserID
GO
