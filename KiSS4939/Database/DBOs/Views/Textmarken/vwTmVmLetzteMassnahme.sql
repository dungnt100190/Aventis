SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmVmLetzteMassnahme;
GO

/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken um die Daten der Massnahme und die Mandatsführende Person der letzten Massnahme einer Person zu bekommen

  TEST:    SELECT TOP 10 * FROM dbo.vwTmVmLetzteMassnahme;
=================================================================================================*/

CREATE VIEW dbo.vwTmVmLetzteMassnahme
AS
  SELECT 
    PRS.BaPersonID,

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
                              WHEN 1 THEN 'geehrter Herr'
                              WHEN 2 THEN 'geehrte Frau'
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
  FROM dbo.BaPerson                          PRS WITH (READUNCOMMITTED)
    INNER JOIN dbo.KesMassnahme              MAS WITH (READUNCOMMITTED) ON MAS.KesMassnahmeID = (SELECT TOP 1 MAS2.KesMassnahmeID
                                                                                                 FROM dbo.KesMassnahme MAS2 WITH (READUNCOMMITTED)
                                                                                                   INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = MAS2.FaLeistungID
                                                                                                 WHERE LEI.BaPersonID = PRS.BaPersonID
                                                                                                 ORDER BY MAS2.DatumVon DESC)
    LEFT  JOIN dbo.KesMandatsfuehrendePerson MFP WITH (READUNCOMMITTED) ON MFP.KesMassnahmeID = MAS.KesMassnahmeID
                                                                       AND MFP.KesMandatsfuehrendePersonID = (SELECT TOP 1 MFP2.KesMandatsfuehrendePersonID
                                                                                                              FROM dbo.KesMandatsfuehrendePerson MFP2 WITH (READUNCOMMITTED)
                                                                                                              WHERE MFP2.KesMassnahmeID = MFP.KesMassnahmeID
                                                                                                              ORDER BY MFP2.DatumErnennungsurkunde DESC)
    LEFT  JOIN dbo.XUser                     USR WITH (READUNCOMMITTED) ON USR.UserID = MFP.UserID
    LEFT  JOIN dbo.BaInstitution             INS WITH (READUNCOMMITTED) ON INS.BaInstitutionID = MFP.BaInstitutionID
    LEFT  JOIN dbo.BaAdresse                 ADR WITH (READUNCOMMITTED) ON ADR.BaInstitutionID = INS.BaInstitutionID OR ADR.UserID = USR.UserID
GO
