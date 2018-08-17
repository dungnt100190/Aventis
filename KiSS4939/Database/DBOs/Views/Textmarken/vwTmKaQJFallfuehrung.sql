SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmKaQJFallfuehrung;
GO
/*===============================================================================================
  $Revision: 3$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
   SUMMARY: View für das Erstellen der Textmarke
  -
  RETURNS: Alle Datensätze zur Fallführung in KaQJProzess
=================================================================================================
  TEST:    SELECT TOP 10 <Columns> FROM dbo.vwTmKaQJFallfuehrung;
=================================================================================================*/

CREATE VIEW dbo.vwTmKaQJFallfuehrung
AS
SELECT
KAP.KaQJProzessID,
KAP.FaLeistungID,
Vorname = CASE WHEN KAP.FallfuehrungID < 0 THEN XURF.Vorname ELSE OKOF.Vorname END,
Name    = CASE WHEN KAP.FallfuehrungID < 0 THEN XURF.Nachname ELSE OKOF.Name END,
Adressat = CASE WHEN KAP.FallfuehrungID < 0 THEN XURF.VornameName ELSE OKOF.Name END,
Adresse = CASE WHEN KAP.FallfuehrungID < 0 THEN ISNULL(OKOFI.Name + CHAR(13) + CHAR(10), '') +
                                                ISNULL(XURF.VornameName + CHAR(13) + CHAR(10), '') +
                                                XURF.AdresseMehrzOhneName 
                                           ELSE ISNULL(OKOFI.Name + CHAR(13) + CHAR(10), '') +
                                                ISNULL(OKOF.Vorname + ' ', '') + OKOF.Name + ' ' + CHAR(13) + CHAR(10) +
                                                OKOFI.AdresseMehrzeilig 
                                           END,
Briefanrede = CASE WHEN KAP.FallfuehrungID < 0 THEN XURF.Briefanrede
                                               ELSE 
                                                 CASE WHEN OKOF.ManuelleAnrede = 1 THEN OKOF.Briefanrede
                                                      WHEN OKOF.GeschlechtCode IS NULL AND OKOF.Anrede = 'Herr' THEN dbo.fnGetGenderMLTitle(1, 'dbGeneral', 'SehrGeehrterHerr', 'SehrGeehrteFrau', NULL, 1, NULL)
                                                      WHEN OKOF.GeschlechtCode IS NULL AND OKOF.Anrede = 'Frau' THEN dbo.fnGetGenderMLTitle(2, 'dbGeneral', 'SehrGeehrterHerr', 'SehrGeehrteFrau', NULL, 1, NULL)
                                                      WHEN OKOF.GeschlechtCode IS NOT NULL THEN dbo.fnGetGenderMLTitle(OKOF.GeschlechtCode, 'dbGeneral', 'SehrGeehrterHerr', 'SehrGeehrteFrau', NULL, 1, NULL)
                                                      ELSE OKOF.Anrede
                                                  END
                                               END,
Anrede =  CASE WHEN KAP.FallfuehrungID < 0 THEN XURF.FrauHerr
                                           ELSE 
                                             CASE WHEN OKOF.ManuelleAnrede = 1 THEN OKOF.Anrede 
                                                  WHEN OKOF.GeschlechtCode IS NULL THEN OKOF.Anrede 
                                                  ELSE dbo.fnGetGenderMLTitle(OKOF.GeschlechtCode, 'dbGeneral', 'Herr', 'Frau', NULL, 1, NULL)
                                              END
                                           END,
EMail  =  CASE WHEN KAP.FallfuehrungID < 0 THEN XURF.Email 
                                           ELSE OKOF.Email 
                                           END, 
Telefon = CASE WHEN KAP.FallfuehrungID < 0 THEN XURF.Telephon 
                                           ELSE OKOF.Telefon 
                                           END,
Institution = CASE WHEN KAP.FallfuehrungID < 0 THEN XURF.AbteilungName
                                               ELSE OKOFI.Name
                                               END

FROM	KaQJProzess KAP WITH (READUNCOMMITTED)
    LEFT JOIN BaInstitutionKontakt	 OKOF WITH (READUNCOMMITTED) ON OKOF.BaInstitutionKontaktID = KAP.FallfuehrungID
    LEFT JOIN vwInstitution         OKOFI WITH (READUNCOMMITTED) ON OKOFI.BaInstitutionID = OKOF.BaInstitutionID 
    LEFT JOIN vwTmUser               XURF WITH (READUNCOMMITTED) ON XURF.UserID = -KAP.FallfuehrungID
GO
