SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmEdEinsatzvereinbarung;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Views/Textmarken/vwTmEdEinsatzvereinbarung.sql $
  $Author: Cjaeggi $
  $Modtime: 22.12.09 16:36 $
  $Revision: 7 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this view to get textmarken for EdEinsatzvereinbarung
  -
  RETURNS: Bookmarks for EdEinsatzvereinbarung
  -
  TEST:    SELECT TOP 30 * FROM vwTmEdEinsatzvereinbarung
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Views/Textmarken/vwTmEdEinsatzvereinbarung.sql $
 * 
 * 7     22.12.09 16:37 Cjaeggi
 * #5185: BugFix with dublicate entries
 * 
 * 6     22.12.09 13:17 Cjaeggi
 * #5185: Added new columns for reductions
 * 
 * 5     27.11.09 11:37 Cjaeggi
 * #5185: Renaming of wrong named views
 * 
 * 4     27.05.09 13:45 Cjaeggi
 * #4339: Anpassungen für Textmarken
 * 
 * 3     12.12.08 11:06 Cjaeggi
 * 
 * 2     12.12.08 10:41 Cjaeggi
 * Shorted names because of word-crash
 * 
 * 1     12.12.08 10:21 Cjaeggi
 * First version
=================================================================================================*/

CREATE VIEW dbo.vwTmEdEinsatzvereinbarung
AS
SELECT
  -----------------------------------------------------------------------------
  -- IDs
  -----------------------------------------------------------------------------
  EVB.EdEinsatzvereinbarungID,
  EVB.FaLeistungID,
  
  -----------------------------------------------------------------------------
  -- Reduktionen
  -----------------------------------------------------------------------------
  ReduktionenD = STUFF((SELECT CONVERT(VARCHAR(50), SUB.Text)
                        FROM (SELECT [Text]  = ', ' + EDR.Text,
                                     [Order] = EDR.EdReduktionID
                              FROM dbo.EdEinsatzvereinbarung_EdReduktion EVR WITH (READUNCOMMITTED)
                                LEFT JOIN dbo.EdReduktion                EDR WITH (READUNCOMMITTED) ON EDR.EdReduktionID = EVR.EdReduktionID
                              WHERE EVR.EdEinsatzvereinbarungID = EVB.EdEinsatzvereinbarungID ) AS SUB 
                        ORDER BY SUB.[Order]
                        FOR XML PATH('')), 1, 2, ''),
  
  ReduktionenF = STUFF((SELECT CONVERT(VARCHAR(50), SUB.Text)
                        FROM (SELECT [Text]  = ', ' + ISNULL(TXT.Text, EDR.Text),
                                     [Order] = EDR.EdReduktionID
                              FROM dbo.EdEinsatzvereinbarung_EdReduktion EVR WITH (READUNCOMMITTED)
                                LEFT JOIN dbo.EdReduktion                EDR WITH (READUNCOMMITTED) ON EDR.EdReduktionID = EVR.EdReduktionID
                                LEFT JOIN dbo.XLangText                  TXT WITH (READUNCOMMITTED) ON TXT.TID = EDR.TextTID
                                                                                                   AND TXT.LanguageCode = 2   -- F
                              WHERE EVR.EdEinsatzvereinbarungID = EVB.EdEinsatzvereinbarungID ) AS SUB 
                        ORDER BY SUB.[Order]
                        FOR XML PATH('')), 1, 2, ''),
  
  ReduktionenI = STUFF((SELECT CONVERT(VARCHAR(50), SUB.Text)
                        FROM (SELECT [Text]  = ', ' + ISNULL(TXT.Text, EDR.Text),
                                     [Order] = EDR.EdReduktionID
                              FROM dbo.EdEinsatzvereinbarung_EdReduktion EVR WITH (READUNCOMMITTED)
                                LEFT JOIN dbo.EdReduktion                EDR WITH (READUNCOMMITTED) ON EDR.EdReduktionID = EVR.EdReduktionID
                                LEFT JOIN dbo.XLangText                  TXT WITH (READUNCOMMITTED) ON TXT.TID = EDR.TextTID
                                                                                                   AND TXT.LanguageCode = 3   -- I
                              WHERE EVR.EdEinsatzvereinbarungID = EVB.EdEinsatzvereinbarungID ) AS SUB 
                        ORDER BY SUB.[Order]
                        FOR XML PATH('')), 1, 2, ''),
  
  -----------------------------------------------------------------------------
  -- Others
  -----------------------------------------------------------------------------
  TypD = dbo.fnGetLOVMLText('EdTyp', EVB.TypCode, 1),
  TypF = dbo.fnGetLOVMLText('EdTyp', EVB.TypCode, 2),
  TypI = dbo.fnGetLOVMLText('EdTyp', EVB.TypCode, 3),
  
  AnlassD = dbo.fnGetLOVMLText('EdAnlass', EVB.AnlassCode, 1),
  AnlassF = dbo.fnGetLOVMLText('EdAnlass', EVB.AnlassCode, 2),
  AnlassI = dbo.fnGetLOVMLText('EdAnlass', EVB.AnlassCode, 3),
  
  ErstellungEV    = CONVERT(VARCHAR, EVB.ErstellungEV, 104),
  ErsterEinsatzAm = CONVERT(VARCHAR, EVB.ErsterEinsatzAm, 104),
  
  AuftragMITFMT = EVB.Auftrag,
  AuftragNORTF  = EVB.Auftrag,
  EVB.VereinbarteEinsatzzeiten,
  
  TarifTag      = CONVERT(DECIMAL(10, 2), EVB.TarifTag),
  TarifNacht    = CONVERT(DECIMAL(10, 2), EVB.TarifNacht),
  TarifZuschlag = CONVERT(DECIMAL(10, 2), EVB.TarifZuschlag),
  
  EVB.Bemerkungen,
  
  -----------------------------------------------------------------------------
  -- EntlasterIn 1
  -----------------------------------------------------------------------------
  Entl1Name                 = EL1.Name,
  Entl1Vorname              = EL1.Vorname,
  Entl1NameVorname          = EL1.NameVorname,
  Entl1NameVornameOhneKomma = EL1.NameVornameOhneKomma,
  
  Entl1AdresseEinzD         = EL1.GrunddatenAdresseEinzD,
  Entl1AdresseEinzF         = EL1.GrunddatenAdresseEinzF,
  Entl1AdresseEinzI         = EL1.GrunddatenAdresseEinzI,
  
  Entl1AdrEinzOhneNameD     = EL1.GrunddatenAdrEinzOhneNameD,
  Entl1AdrEinzOhneNameF     = EL1.GrunddatenAdrEinzOhneNameF,
  Entl1AdrEinzOhneNameI     = EL1.GrunddatenAdrEinzOhneNameI,
  
  Entl1AdresseMehrzD        = EL1.GrunddatenAdresseMehrzD,
  Entl1AdresseMehrzF        = EL1.GrunddatenAdresseMehrzF,
  Entl1AdresseMehrzI        = EL1.GrunddatenAdresseMehrzI,
  
  Entl1AdrMehrzOhneNameD    = EL1.GrunddatenAdrMehrzOhneNameD,
  Entl1AdrMehrzOhneNameF    = EL1.GrunddatenAdrMehrzOhneNameF,
  Entl1AdrMehrzOhneNameI    = EL1.GrunddatenAdrMehrzOhneNameI,
  
  Entl1Bezirk               = EL1.GrunddatenAdresseBezirk,
  Entl1Kanton               = EL1.GrunddatenAdresseKanton,
  
  Entl1KontaktTelD          = EL1.TelefonD,
  Entl1KontaktTelF          = EL1.TelefonF,
  Entl1KontaktTelI          = EL1.TelefonI,
  
  Entl1MobilTel             = EL1.MobilTel,
  Entl1Fax                  = EL1.Fax,
  
  Entl1KontaktEmailD        = EL1.EmailD,
  Entl1KontaktEmailF        = EL1.EmailF,
  Entl1KontaktEmailI        = EL1.EmailI,
  
  Entl1FrauHerrD            = EL1.FrauHerrD,
  Entl1FrauHerrF            = EL1.FrauHerrF,
  Entl1FrauHerrI            = EL1.FrauHerrI,
  
  Entl1GeehrteFrauHerrD     = EL1.GeehrteFrauHerrD,
  Entl1GeehrteFrauHerrF     = EL1.GeehrteFrauHerrF,
  Entl1GeehrteFrauHerrI     = EL1.GeehrteFrauHerrI,
  
  -----------------------------------------------------------------------------
  -- EntlasterIn 2
  -----------------------------------------------------------------------------
  Entl2Name                 = EL2.Name,
  Entl2Vorname              = EL2.Vorname,
  Entl2NameVorname          = EL2.NameVorname,
  Entl2NameVornameOhneKomma = EL2.NameVornameOhneKomma,
  
  Entl2AdresseEinzD         = EL2.GrunddatenAdresseEinzD,
  Entl2AdresseEinzF         = EL2.GrunddatenAdresseEinzF,
  Entl2AdresseEinzI         = EL2.GrunddatenAdresseEinzI,
  
  Entl2AdrEinzOhneNameD     = EL2.GrunddatenAdrEinzOhneNameD,
  Entl2AdrEinzOhneNameF     = EL2.GrunddatenAdrEinzOhneNameF,
  Entl2AdrEinzOhneNameI     = EL2.GrunddatenAdrEinzOhneNameI,
  
  Entl2AdresseMehrzD        = EL2.GrunddatenAdresseMehrzD,
  Entl2AdresseMehrzF        = EL2.GrunddatenAdresseMehrzF,
  Entl2AdresseMehrzI        = EL2.GrunddatenAdresseMehrzI,
  
  Entl2AdrMehrzOhneNameD    = EL2.GrunddatenAdrMehrzOhneNameD,
  Entl2AdrMehrzOhneNameF    = EL2.GrunddatenAdrMehrzOhneNameF,
  Entl2AdrMehrzOhneNameI    = EL2.GrunddatenAdrMehrzOhneNameI,
  
  Entl2Bezirk               = EL2.GrunddatenAdresseBezirk,
  Entl2Kanton               = EL2.GrunddatenAdresseKanton,
  
  Entl2KontaktTelD          = EL2.TelefonD,
  Entl2KontaktTelF          = EL2.TelefonF,
  Entl2KontaktTelI          = EL2.TelefonI,
  
  Entl2MobilTel             = EL2.MobilTel,
  Entl2Fax                  = EL2.Fax,
  
  Entl2KontaktEmailD        = EL2.EmailD,
  Entl2KontaktEmailF        = EL2.EmailF,
  Entl2KontaktEmailI        = EL2.EmailI,
  
  Entl2FrauHerrD            = EL2.FrauHerrD,
  Entl2FrauHerrF            = EL2.FrauHerrF,
  Entl2FrauHerrI            = EL2.FrauHerrI,
  
  Entl2GeehrteFrauHerrD     = EL2.GeehrteFrauHerrD,
  Entl2GeehrteFrauHerrF     = EL2.GeehrteFrauHerrF,
  Entl2GeehrteFrauHerrI     = EL2.GeehrteFrauHerrI,
  
  -----------------------------------------------------------------------------
  -- EntlasterIn 3
  -----------------------------------------------------------------------------
  Entl3Name                 = EL3.Name,
  Entl3Vorname              = EL3.Vorname,
  Entl3NameVorname          = EL3.NameVorname,
  Entl3NameVornameOhneKomma = EL3.NameVornameOhneKomma,
  
  Entl3AdresseEinzD         = EL3.GrunddatenAdresseEinzD,
  Entl3AdresseEinzF         = EL3.GrunddatenAdresseEinzF,
  Entl3AdresseEinzI         = EL3.GrunddatenAdresseEinzI,
  
  Entl3AdrEinzOhneNameD     = EL3.GrunddatenAdrEinzOhneNameD,
  Entl3AdrEinzOhneNameF     = EL3.GrunddatenAdrEinzOhneNameF,
  Entl3AdrEinzOhneNameI     = EL3.GrunddatenAdrEinzOhneNameI,
  
  Entl3AdresseMehrzD        = EL3.GrunddatenAdresseMehrzD,
  Entl3AdresseMehrzF        = EL3.GrunddatenAdresseMehrzF,
  Entl3AdresseMehrzI        = EL3.GrunddatenAdresseMehrzI,
  
  Entl3AdrMehrzOhneNameD    = EL3.GrunddatenAdrMehrzOhneNameD,
  Entl3AdrMehrzOhneNameF    = EL3.GrunddatenAdrMehrzOhneNameF,
  Entl3AdrMehrzOhneNameI    = EL3.GrunddatenAdrMehrzOhneNameI,
  
  Entl3Bezirk               = EL3.GrunddatenAdresseBezirk,
  Entl3Kanton               = EL3.GrunddatenAdresseKanton,
  
  Entl3KontaktTelD          = EL3.TelefonD,
  Entl3KontaktTelF          = EL3.TelefonF,
  Entl3KontaktTelI          = EL3.TelefonI,
  
  Entl3MobilTel             = EL3.MobilTel,
  Entl3Fax                  = EL3.Fax,
  
  Entl3KontaktEmailD        = EL3.EmailD,
  Entl3KontaktEmailF        = EL3.EmailF,
  Entl3KontaktEmailI        = EL3.EmailI,
  
  Entl3FrauHerrD            = EL3.FrauHerrD,
  Entl3FrauHerrF            = EL3.FrauHerrF,
  Entl3FrauHerrI            = EL3.FrauHerrI,
  
  Entl3GeehrteFrauHerrD     = EL3.GeehrteFrauHerrD,
  Entl3GeehrteFrauHerrF     = EL3.GeehrteFrauHerrF,
  Entl3GeehrteFrauHerrI     = EL3.GeehrteFrauHerrI,
  
  -----------------------------------------------------------------------------
  -- EntlasterIn 4
  -----------------------------------------------------------------------------
  Entl4Name                 = EL4.Name,
  Entl4Vorname              = EL4.Vorname,
  Entl4NameVorname          = EL4.NameVorname,
  Entl4NameVornameOhneKomma = EL4.NameVornameOhneKomma,
  
  Entl4AdresseEinzD         = EL4.GrunddatenAdresseEinzD,
  Entl4AdresseEinzF         = EL4.GrunddatenAdresseEinzF,
  Entl4AdresseEinzI         = EL4.GrunddatenAdresseEinzI,
  
  Entl4AdrEinzOhneNameD     = EL4.GrunddatenAdrEinzOhneNameD,
  Entl4AdrEinzOhneNameF     = EL4.GrunddatenAdrEinzOhneNameF,
  Entl4AdrEinzOhneNameI     = EL4.GrunddatenAdrEinzOhneNameI,
  
  Entl4AdresseMehrzD        = EL4.GrunddatenAdresseMehrzD,
  Entl4AdresseMehrzF        = EL4.GrunddatenAdresseMehrzF,
  Entl4AdresseMehrzI        = EL4.GrunddatenAdresseMehrzI,
  
  Entl4AdrMehrzOhneNameD    = EL4.GrunddatenAdrMehrzOhneNameD,
  Entl4AdrMehrzOhneNameF    = EL4.GrunddatenAdrMehrzOhneNameF,
  Entl4AdrMehrzOhneNameI    = EL4.GrunddatenAdrMehrzOhneNameI,
  
  Entl4Bezirk               = EL4.GrunddatenAdresseBezirk,
  Entl4Kanton               = EL4.GrunddatenAdresseKanton,
  
  Entl4KontaktTelD          = EL4.TelefonD,
  Entl4KontaktTelF          = EL4.TelefonF,
  Entl4KontaktTelI          = EL4.TelefonI,
  
  Entl4MobilTel             = EL4.MobilTel,
  Entl4Fax                  = EL4.Fax,
  
  Entl4KontaktEmailD        = EL4.EmailD,
  Entl4KontaktEmailF        = EL4.EmailF,
  Entl4KontaktEmailI        = EL4.EmailI,
  
  Entl4FrauHerrD            = EL4.FrauHerrD,
  Entl4FrauHerrF            = EL4.FrauHerrF,
  Entl4FrauHerrI            = EL4.FrauHerrI,
  
  Entl4GeehrteFrauHerrD     = EL4.GeehrteFrauHerrD,
  Entl4GeehrteFrauHerrF     = EL4.GeehrteFrauHerrF,
  Entl4GeehrteFrauHerrI     = EL4.GeehrteFrauHerrI,
  
  -----------------------------------------------------------------------------
  -- EntlasterIn 5
  -----------------------------------------------------------------------------
  Entl5Name                 = EL5.Name,
  Entl5Vorname              = EL5.Vorname,
  Entl5NameVorname          = EL5.NameVorname,
  Entl5NameVornameOhneKomma = EL5.NameVornameOhneKomma,
  
  Entl5AdresseEinzD         = EL5.GrunddatenAdresseEinzD,
  Entl5AdresseEinzF         = EL5.GrunddatenAdresseEinzF,
  Entl5AdresseEinzI         = EL5.GrunddatenAdresseEinzI,
  
  Entl5AdrEinzOhneNameD     = EL5.GrunddatenAdrEinzOhneNameD,
  Entl5AdrEinzOhneNameF     = EL5.GrunddatenAdrEinzOhneNameF,
  Entl5AdrEinzOhneNameI     = EL5.GrunddatenAdrEinzOhneNameI,
  
  Entl5AdresseMehrzD        = EL5.GrunddatenAdresseMehrzD,
  Entl5AdresseMehrzF        = EL5.GrunddatenAdresseMehrzF,
  Entl5AdresseMehrzI        = EL5.GrunddatenAdresseMehrzI,
  
  Entl5AdrMehrzOhneNameD    = EL5.GrunddatenAdrMehrzOhneNameD,
  Entl5AdrMehrzOhneNameF    = EL5.GrunddatenAdrMehrzOhneNameF,
  Entl5AdrMehrzOhneNameI    = EL5.GrunddatenAdrMehrzOhneNameI,
  
  Entl5Bezirk               = EL5.GrunddatenAdresseBezirk,
  Entl5Kanton               = EL5.GrunddatenAdresseKanton,
  
  Entl5KontaktTelD          = EL5.TelefonD,
  Entl5KontaktTelF          = EL5.TelefonF,
  Entl5KontaktTelI          = EL5.TelefonI,
  
  Entl5MobilTel             = EL5.MobilTel,
  Entl5Fax                  = EL5.Fax,
  
  Entl5KontaktEmailD        = EL5.EmailD,
  Entl5KontaktEmailF        = EL5.EmailF,
  Entl5KontaktEmailI        = EL5.EmailI,
  
  Entl5FrauHerrD            = EL5.FrauHerrD,
  Entl5FrauHerrF            = EL5.FrauHerrF,
  Entl5FrauHerrI            = EL5.FrauHerrI,
  
  Entl5GeehrteFrauHerrD     = EL5.GeehrteFrauHerrD,
  Entl5GeehrteFrauHerrF     = EL5.GeehrteFrauHerrF,
  Entl5GeehrteFrauHerrI     = EL5.GeehrteFrauHerrI
  
FROM dbo.EdEinsatzvereinbarung EVB WITH (READUNCOMMITTED)
  -- Entlaster1
  LEFT JOIN dbo.vwTmEdEinsatzEDMitarbeiter EL1 ON EL1.UserID = (SELECT UEV.UserID
                                                                FROM dbo.XUser_EdEinsatzvereinbarung UEV
                                                                WHERE UEV.EdEinsatzvereinbarungID = EVB.EdEinsatzvereinbarungID AND
                                                                      UEV.SortKey = 0)
                                              AND EL1.XModulID = 6 -- ED
  -- Entlaster2
  LEFT JOIN dbo.vwTmEdEinsatzEDMitarbeiter EL2 ON EL2.UserID = (SELECT UEV.UserID
                                                                FROM dbo.XUser_EdEinsatzvereinbarung UEV
                                                                WHERE UEV.EdEinsatzvereinbarungID = EVB.EdEinsatzvereinbarungID AND
                                                                      UEV.SortKey = 1)
                                              AND EL2.XModulID = 6 -- ED
  -- Entlaster3
  LEFT JOIN dbo.vwTmEdEinsatzEDMitarbeiter EL3 ON EL3.UserID = (SELECT UEV.UserID
                                                                FROM dbo.XUser_EdEinsatzvereinbarung UEV
                                                                WHERE UEV.EdEinsatzvereinbarungID = EVB.EdEinsatzvereinbarungID AND
                                                                      UEV.SortKey = 2)
                                              AND EL3.XModulID = 6 -- ED
  -- Entlaster4
  LEFT JOIN dbo.vwTmEdEinsatzEDMitarbeiter EL4 ON EL4.UserID = (SELECT UEV.UserID
                                                                FROM dbo.XUser_EdEinsatzvereinbarung UEV
                                                                WHERE UEV.EdEinsatzvereinbarungID = EVB.EdEinsatzvereinbarungID AND
                                                                      UEV.SortKey = 3)
                                              AND EL4.XModulID = 6 -- ED
  -- Entlaster5
  LEFT JOIN dbo.vwTmEdEinsatzEDMitarbeiter EL5 ON EL5.UserID = (SELECT UEV.UserID
                                                                FROM dbo.XUser_EdEinsatzvereinbarung UEV
                                                                WHERE UEV.EdEinsatzvereinbarungID = EVB.EdEinsatzvereinbarungID AND
                                                                      UEV.SortKey = 4)
                                              AND EL5.XModulID = 6 -- ED
GO
