SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmBwEinsatzvereinbarung
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Views/Textmarken/vwTmBwEinsatzvereinbarung.sql $
  $Author: Cjaeggi $
  $Modtime: 22.12.09 16:37 $
  $Revision: 10 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: View for Bookmarks in BwEinsatzvereinbarung
  -
  RETURNS: Prepared data used for bookmarks in BWEinsatzvereinbarung
  -
  TEST:    SELECT * FROM dbo.vwTmBwEinsatzvereinbarung
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Views/Textmarken/vwTmBwEinsatzvereinbarung.sql $
 * 
 * 10    22.12.09 16:37 Cjaeggi
 * #5185: BugFix with dublicate entries
 * 
 * 9     22.12.09 13:17 Cjaeggi
 * #5185: Removed comment
 * 
 * 8     22.12.09 13:08 Cjaeggi
 * #5185: Removed bookmarks for reduction
 * 
 * 7     27.11.09 11:37 Cjaeggi
 * #5185: Renaming of wrong named views
 * 
 * 6     10.11.09 10:17 Cjaeggi
 * #5185: Minor refactoring
 * 
 * 5     10.11.09 9:38 Cjaeggi
 * #5185: Minor refactoring
 * 
 * 4     5.11.09 16:37 Spsota
 * #5185 Einträge für BwTyp hinzugefügt
 * 
 * 3     26.10.09 9:47 Spsota
 * #5185 Entries used for Bookmarks in BwEinsatzvereinbarung added
 * 
 * 2     22.10.09 12:26 Spsota
 * #5185 EdMitarbiter und Textmarken BwEinsatzvereinbarung
 * 
 * 1     21.10.09 13:17 Spsota
 * #5185 View für Textmarken BwEinsatzvereinbarung hinzugefügt
 
=================================================================================================*/

CREATE VIEW dbo.vwTmBwEinsatzvereinbarung
AS
SELECT 
  -----------------------------------------------------------------------------
  -- IDs
  -----------------------------------------------------------------------------
  EVB.BwEinsatzvereinbarungID, 
  EVB.FaLeistungID, 
  
  -----------------------------------------------------------------------------
  -- Themen
  -----------------------------------------------------------------------------
  ThemenD = STUFF((SELECT CONVERT(VARCHAR(50), SUB.Text)
                   FROM (SELECT [Text]  = ', ' + BWT.Text,
                                [Order] = BWT.BwThemaID
                         FROM dbo.BwEinsatzvereinbarung_BwThema EVT WITH (READUNCOMMITTED)
                           LEFT JOIN dbo.BwThema                BWT WITH (READUNCOMMITTED) ON EVT.BwThemaID = BWT.BwThemaID
                         WHERE EVT.BwEinsatzvereinbarungID = EVB.BwEinsatzvereinbarungID) AS SUB 
                   ORDER BY SUB.[Order]
                   FOR XML PATH('')), 1, 2, ''),
  
  ThemenF = STUFF((SELECT CONVERT(VARCHAR(50), SUB.Text)
                   FROM (SELECT [Text]  = ', ' + ISNULL(TXT.Text, BWT.Text),
                                [Order] = BWT.BwThemaID
                         FROM dbo.BwEinsatzvereinbarung_BwThema EVT WITH (READUNCOMMITTED)
                           LEFT JOIN dbo.BwThema                BWT WITH (READUNCOMMITTED) ON EVT.BwThemaID = BWT.BwThemaID
                           LEFT JOIN dbo.XLangText              TXT WITH (READUNCOMMITTED) ON BWT.TextTID = TXT.TID 
                                                                                          AND TXT.LanguageCode = 2
                         WHERE EVT.BwEinsatzvereinbarungID = EVB.BwEinsatzvereinbarungID) AS SUB 
                   ORDER BY SUB.[Order]
                   FOR XML PATH('')), 1, 2, ''),
  
  ThemenI = STUFF((SELECT CONVERT(VARCHAR(50), SUB.Text)
                   FROM (SELECT [Text]  = ', ' + ISNULL(TXT.Text, BWT.Text),
                                [Order] = BWT.BwThemaID
                         FROM dbo.BwEinsatzvereinbarung_BwThema EVT WITH (READUNCOMMITTED)
                           LEFT JOIN dbo.BwThema                BWT WITH (READUNCOMMITTED) ON EVT.BwThemaID = BWT.BwThemaID
                           LEFT JOIN dbo.XLangText              TXT WITH (READUNCOMMITTED) ON BWT.TextTID = TXT.TID 
                                                                                          AND TXT.LanguageCode = 3
                         WHERE EVT.BwEinsatzvereinbarungID = EVB.BwEinsatzvereinbarungID) AS SUB 
                   ORDER BY SUB.[Order]
                   FOR XML PATH('')), 1, 2, ''),
  
  -----------------------------------------------------------------------------
  -- Reduktionen
  -----------------------------------------------------------------------------
  -- <add only if required, feature is disabled at the moment>
  
  -----------------------------------------------------------------------------
  -- Andere
  -----------------------------------------------------------------------------
  TypD                     = dbo.fnGetLOVMLText('BwTyp', EVB.BwTypCode, 1),
  TypF                     = dbo.fnGetLOVMLText('BwTyp', EVB.BwTypCode, 2),
  TypI                     = dbo.fnGetLOVMLText('BwTyp', EVB.BwTypCode, 3),
  --
  ErstellungEV             = CONVERT(VARCHAR, EVB.ErstellungEV, 104), 
  ErsterEinsatzAm          = CONVERT(VARCHAR, EVB.ErsterEinsatzAm, 104), 
  ZieleNORTF               = EVB.Ziele, 
  AuftragNORTF             = EVB.Auftrag, 
  VereinbarteEinsatzzeiten = EVB.VereinbarteEinsatzzeiten, 
  TarifTag                 = CONVERT(DECIMAL(10, 2), EVB.TarifTag), 
  TarifNacht               = CONVERT(DECIMAL(10, 2), EVB.TarifNacht), 
  Bemerkungen              = EVB.Bemerkungen,
  
  -----------------------------------------------------------------------------
  -- BegleiterIn 1
  -----------------------------------------------------------------------------
  Begl1Name                 = BL1.Name,
  Begl1Vorname              = BL1.Vorname,
  Begl1NameVorname          = BL1.NameVorname,
  Begl1NameVornameOhneKomma = BL1.NameVornameOhneKomma,
  
  Begl1AdresseEinzD         = BL1.GrunddatenAdresseEinzD,
  Begl1AdresseEinzF         = BL1.GrunddatenAdresseEinzF,
  Begl1AdresseEinzI         = BL1.GrunddatenAdresseEinzI,
  
  Begl1AdrEinzOhneNameD     = BL1.GrunddatenAdrEinzOhneNameD,
  Begl1AdrEinzOhneNameF     = BL1.GrunddatenAdrEinzOhneNameF,
  Begl1AdrEinzOhneNameI     = BL1.GrunddatenAdrEinzOhneNameI,
  
  Begl1AdresseMehrzD        = BL1.GrunddatenAdresseMehrzD,
  Begl1AdresseMehrzF        = BL1.GrunddatenAdresseMehrzF,
  Begl1AdresseMehrzI        = BL1.GrunddatenAdresseMehrzI,
  
  Begl1AdrMehrzOhneNameD    = BL1.GrunddatenAdrMehrzOhneNameD,
  Begl1AdrMehrzOhneNameF    = BL1.GrunddatenAdrMehrzOhneNameF,
  Begl1AdrMehrzOhneNameI    = BL1.GrunddatenAdrMehrzOhneNameI,
  
  Begl1Bezirk               = BL1.GrunddatenAdresseBezirk,
  Begl1Kanton               = BL1.GrunddatenAdresseKanton,
  
  Begl1KontaktTelD          = BL1.TelefonD,
  Begl1KontaktTelF          = BL1.TelefonF,
  Begl1KontaktTelI          = BL1.TelefonI,
  
  Begl1MobilTel             = BL1.MobilTel,
  Begl1Fax                  = BL1.Fax,
  
  Begl1KontaktEmailD        = BL1.EmailD,
  Begl1KontaktEmailF        = BL1.EmailF,
  Begl1KontaktEmailI        = BL1.EmailI,
  
  Begl1FrauHerrD            = BL1.FrauHerrD,
  Begl1FrauHerrF            = BL1.FrauHerrF,
  Begl1FrauHerrI            = BL1.FrauHerrI,
  
  Begl1GeehrteFrauHerrD     = BL1.GeehrteFrauHerrD,
  Begl1GeehrteFrauHerrF     = BL1.GeehrteFrauHerrF,
  Begl1GeehrteFrauHerrI     = BL1.GeehrteFrauHerrI,
  
  -----------------------------------------------------------------------------
  -- BegleiterIn 2
  -----------------------------------------------------------------------------
  Begl2Name                 = BL2.Name,
  Begl2Vorname              = BL2.Vorname,
  Begl2NameVorname          = BL2.NameVorname,
  Begl2NameVornameOhneKomma = BL2.NameVornameOhneKomma,
  
  Begl2AdresseEinzD         = BL2.GrunddatenAdresseEinzD,
  Begl2AdresseEinzF         = BL2.GrunddatenAdresseEinzF,
  Begl2AdresseEinzI         = BL2.GrunddatenAdresseEinzI,
  
  Begl2AdrEinzOhneNameD     = BL2.GrunddatenAdrEinzOhneNameD,
  Begl2AdrEinzOhneNameF     = BL2.GrunddatenAdrEinzOhneNameF,
  Begl2AdrEinzOhneNameI     = BL2.GrunddatenAdrEinzOhneNameI,
  
  Begl2AdresseMehrzD        = BL2.GrunddatenAdresseMehrzD,
  Begl2AdresseMehrzF        = BL2.GrunddatenAdresseMehrzF,
  Begl2AdresseMehrzI        = BL2.GrunddatenAdresseMehrzI,
  
  Begl2AdrMehrzOhneNameD    = BL2.GrunddatenAdrMehrzOhneNameD,
  Begl2AdrMehrzOhneNameF    = BL2.GrunddatenAdrMehrzOhneNameF,
  Begl2AdrMehrzOhneNameI    = BL2.GrunddatenAdrMehrzOhneNameI,
  
  Begl2Bezirk               = BL2.GrunddatenAdresseBezirk,
  Begl2Kanton               = BL2.GrunddatenAdresseKanton,
  
  Begl2KontaktTelD          = BL2.TelefonD,
  Begl2KontaktTelF          = BL2.TelefonF,
  Begl2KontaktTelI          = BL2.TelefonI,
  
  Begl2MobilTel             = BL2.MobilTel,
  Begl2Fax                  = BL2.Fax,
  
  Begl2KontaktEmailD        = BL2.EmailD,
  Begl2KontaktEmailF        = BL2.EmailF,
  Begl2KontaktEmailI        = BL2.EmailI,
  
  Begl2FrauHerrD            = BL2.FrauHerrD,
  Begl2FrauHerrF            = BL2.FrauHerrF,
  Begl2FrauHerrI            = BL2.FrauHerrI,
  
  Begl2GeehrteFrauHerrD     = BL2.GeehrteFrauHerrD,
  Begl2GeehrteFrauHerrF     = BL2.GeehrteFrauHerrF,
  Begl2GeehrteFrauHerrI     = BL2.GeehrteFrauHerrI,
  
  -----------------------------------------------------------------------------
  -- BegleiterIn 3
  -----------------------------------------------------------------------------
  Begl3Name                 = BL3.Name,
  Begl3Vorname              = BL3.Vorname,
  Begl3NameVorname          = BL3.NameVorname,
  Begl3NameVornameOhneKomma = BL3.NameVornameOhneKomma,
  
  Begl3AdresseEinzD         = BL3.GrunddatenAdresseEinzD,
  Begl3AdresseEinzF         = BL3.GrunddatenAdresseEinzF,
  Begl3AdresseEinzI         = BL3.GrunddatenAdresseEinzI,
  
  Begl3AdrEinzOhneNameD     = BL3.GrunddatenAdrEinzOhneNameD,
  Begl3AdrEinzOhneNameF     = BL3.GrunddatenAdrEinzOhneNameF,
  Begl3AdrEinzOhneNameI     = BL3.GrunddatenAdrEinzOhneNameI,
  
  Begl3AdresseMehrzD        = BL3.GrunddatenAdresseMehrzD,
  Begl3AdresseMehrzF        = BL3.GrunddatenAdresseMehrzF,
  Begl3AdresseMehrzI        = BL3.GrunddatenAdresseMehrzI,
  
  Begl3AdrMehrzOhneNameD    = BL3.GrunddatenAdrMehrzOhneNameD,
  Begl3AdrMehrzOhneNameF    = BL3.GrunddatenAdrMehrzOhneNameF,
  Begl3AdrMehrzOhneNameI    = BL3.GrunddatenAdrMehrzOhneNameI,
  
  Begl3Bezirk               = BL3.GrunddatenAdresseBezirk,
  Begl3Kanton               = BL3.GrunddatenAdresseKanton,
  
  Begl3KontaktTelD          = BL3.TelefonD,
  Begl3KontaktTelF          = BL3.TelefonF,
  Begl3KontaktTelI          = BL3.TelefonI,
  
  Begl3MobilTel             = BL3.MobilTel,
  Begl3Fax                  = BL3.Fax,
  
  Begl3KontaktEmailD        = BL3.EmailD,
  Begl3KontaktEmailF        = BL3.EmailF,
  Begl3KontaktEmailI        = BL3.EmailI,
  
  Begl3FrauHerrD            = BL3.FrauHerrD,
  Begl3FrauHerrF            = BL3.FrauHerrF,
  Begl3FrauHerrI            = BL3.FrauHerrI,
  
  Begl3GeehrteFrauHerrD     = BL3.GeehrteFrauHerrD,
  Begl3GeehrteFrauHerrF     = BL3.GeehrteFrauHerrF,
  Begl3GeehrteFrauHerrI     = BL3.GeehrteFrauHerrI,
  
  -----------------------------------------------------------------------------
  -- BegleiterIn 4
  -----------------------------------------------------------------------------
  Begl4Name                 = BL4.Name,
  Begl4Vorname              = BL4.Vorname,
  Begl4NameVorname          = BL4.NameVorname,
  Begl4NameVornameOhneKomma = BL4.NameVornameOhneKomma,
  
  Begl4AdresseEinzD         = BL4.GrunddatenAdresseEinzD,
  Begl4AdresseEinzF         = BL4.GrunddatenAdresseEinzF,
  Begl4AdresseEinzI         = BL4.GrunddatenAdresseEinzI,
  
  Begl4AdrEinzOhneNameD     = BL4.GrunddatenAdrEinzOhneNameD,
  Begl4AdrEinzOhneNameF     = BL4.GrunddatenAdrEinzOhneNameF,
  Begl4AdrEinzOhneNameI     = BL4.GrunddatenAdrEinzOhneNameI,
  
  Begl4AdresseMehrzD        = BL4.GrunddatenAdresseMehrzD,
  Begl4AdresseMehrzF        = BL4.GrunddatenAdresseMehrzF,
  Begl4AdresseMehrzI        = BL4.GrunddatenAdresseMehrzI,
  
  Begl4AdrMehrzOhneNameD    = BL4.GrunddatenAdrMehrzOhneNameD,
  Begl4AdrMehrzOhneNameF    = BL4.GrunddatenAdrMehrzOhneNameF,
  Begl4AdrMehrzOhneNameI    = BL4.GrunddatenAdrMehrzOhneNameI,
  
  Begl4Bezirk               = BL4.GrunddatenAdresseBezirk,
  Begl4Kanton               = BL4.GrunddatenAdresseKanton,
  
  Begl4KontaktTelD          = BL4.TelefonD,
  Begl4KontaktTelF          = BL4.TelefonF,
  Begl4KontaktTelI          = BL4.TelefonI,
  
  Begl4MobilTel             = BL4.MobilTel,
  Begl4Fax                  = BL4.Fax,
  
  Begl4KontaktEmailD        = BL4.EmailD,
  Begl4KontaktEmailF        = BL4.EmailF,
  Begl4KontaktEmailI        = BL4.EmailI,
  
  Begl4FrauHerrD            = BL4.FrauHerrD,
  Begl4FrauHerrF            = BL4.FrauHerrF,
  Begl4FrauHerrI            = BL4.FrauHerrI,
  
  Begl4GeehrteFrauHerrD     = BL4.GeehrteFrauHerrD,
  Begl4GeehrteFrauHerrF     = BL4.GeehrteFrauHerrF,
  Begl4GeehrteFrauHerrI     = BL4.GeehrteFrauHerrI,
  
  -----------------------------------------------------------------------------
  -- BegleiterIn 5
  -----------------------------------------------------------------------------
  Begl5Name                 = BL5.Name,
  Begl5Vorname              = BL5.Vorname,
  Begl5NameVorname          = BL5.NameVorname,
  Begl5NameVornameOhneKomma = BL5.NameVornameOhneKomma,
  
  Begl5AdresseEinzD         = BL5.GrunddatenAdresseEinzD,
  Begl5AdresseEinzF         = BL5.GrunddatenAdresseEinzF,
  Begl5AdresseEinzI         = BL5.GrunddatenAdresseEinzI,
  
  Begl5AdrEinzOhneNameD     = BL5.GrunddatenAdrEinzOhneNameD,
  Begl5AdrEinzOhneNameF     = BL5.GrunddatenAdrEinzOhneNameF,
  Begl5AdrEinzOhneNameI     = BL5.GrunddatenAdrEinzOhneNameI,
  
  Begl5AdresseMehrzD        = BL5.GrunddatenAdresseMehrzD,
  Begl5AdresseMehrzF        = BL5.GrunddatenAdresseMehrzF,
  Begl5AdresseMehrzI        = BL5.GrunddatenAdresseMehrzI,
  
  Begl5AdrMehrzOhneNameD    = BL5.GrunddatenAdrMehrzOhneNameD,
  Begl5AdrMehrzOhneNameF    = BL5.GrunddatenAdrMehrzOhneNameF,
  Begl5AdrMehrzOhneNameI    = BL5.GrunddatenAdrMehrzOhneNameI,
  
  Begl5Bezirk               = BL5.GrunddatenAdresseBezirk,
  Begl5Kanton               = BL5.GrunddatenAdresseKanton,
  
  Begl5KontaktTelD          = BL5.TelefonD,
  Begl5KontaktTelF          = BL5.TelefonF,
  Begl5KontaktTelI          = BL5.TelefonI,
  
  Begl5MobilTel             = BL5.MobilTel,
  Begl5Fax                  = BL5.Fax,
  
  Begl5KontaktEmailD        = BL5.EmailD,
  Begl5KontaktEmailF        = BL5.EmailF,
  Begl5KontaktEmailI        = BL5.EmailI,
  
  Begl5FrauHerrD            = BL5.FrauHerrD,
  Begl5FrauHerrF            = BL5.FrauHerrF,
  Begl5FrauHerrI            = BL5.FrauHerrI,
  
  Begl5GeehrteFrauHerrD     = BL5.GeehrteFrauHerrD,
  Begl5GeehrteFrauHerrF     = BL5.GeehrteFrauHerrF,
  Begl5GeehrteFrauHerrI     = BL5.GeehrteFrauHerrI
  
FROM dbo.BwEinsatzvereinbarung             EVB WITH (READUNCOMMITTED) 
  -- Begleiter1
  LEFT JOIN dbo.vwTmEdEinsatzEDMitarbeiter BL1 ON BL1.UserID = (SELECT UEV.UserID
                                                                FROM dbo.XUser_BwEinsatzvereinbarung UEV
                                                                WHERE UEV.BwEinsatzvereinbarungID = EVB.BwEinsatzvereinbarungID 
                                                                  AND UEV.SortKey = 0)
                                              AND BL1.XModulID = 5 -- BW
  -- Begleiter2
  LEFT JOIN dbo.vwTmEdEinsatzEDMitarbeiter BL2 ON BL2.UserID = (SELECT UEV.UserID
                                                                FROM dbo.XUser_BwEinsatzvereinbarung UEV
                                                                WHERE UEV.BwEinsatzvereinbarungID = EVB.BwEinsatzvereinbarungID 
                                                                  AND UEV.SortKey = 1)
                                              AND BL2.XModulID = 5 -- BW
  -- Begleiter3
  LEFT JOIN dbo.vwTmEdEinsatzEDMitarbeiter BL3 ON BL3.UserID = (SELECT UEV.UserID
                                                                FROM dbo.XUser_BwEinsatzvereinbarung UEV
                                                                WHERE UEV.BwEinsatzvereinbarungID = EVB.BwEinsatzvereinbarungID 
                                                                  AND UEV.SortKey = 2)
                                              AND BL3.XModulID = 5 -- BW
  -- Begleiter4
  LEFT JOIN dbo.vwTmEdEinsatzEDMitarbeiter BL4 ON BL4.UserID = (SELECT UEV.UserID
                                                                FROM dbo.XUser_BwEinsatzvereinbarung UEV
                                                                WHERE UEV.BwEinsatzvereinbarungID = EVB.BwEinsatzvereinbarungID 
                                                                  AND UEV.SortKey = 3)
                                              AND BL4.XModulID = 5 -- BW
  -- Begleiter5
  LEFT JOIN dbo.vwTmEdEinsatzEDMitarbeiter BL5 ON BL5.UserID = (SELECT UEV.UserID
                                                                FROM dbo.XUser_BwEinsatzvereinbarung UEV
                                                                WHERE UEV.BwEinsatzvereinbarungID = EVB.BwEinsatzvereinbarungID 
                                                                  AND UEV.SortKey = 4)
                                              AND BL5.XModulID = 5 -- BW
GO 