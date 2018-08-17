SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmKaBetrieb;
GO
/*===============================================================================================
  $Revision: 15 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken für die Maske KA - Betriebe
  -
  RETURNS: .
=================================================================================================
  TEST:    SELECT TOP 10 * FROM vwTmKaBetrieb;
=================================================================================================*/

CREATE VIEW dbo.vwTmKaBetrieb
AS
SELECT -- Betrieb
       KaBetriebID             = BET.KaBetriebID,
       [Name]                  = BET.BetriebName,
       AdressZusatz            = ADR.Zusatz,
       AdresseMehrzeilig       = ISNULL(ADR.Strasse + ISNULL(' ' + ADR.HausNr, '') + CHAR(13) + CHAR(10), '') +
                                 ISNULL(dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                                 ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, ''),
       Land                    = LAN.Text,
       [TeilbetriebVon]        = TBE.BetriebName,
       Telefon                 = BET.Telefon,
       Fax                     = BET.Fax,
       [EMail]                 = BET.EMail,
       Internet                = BET.Homepage,
       Akt                     = BET.Aktiv,
       [AuVe]                  = BET.InAusbildungsverbund,
       Charakter               = dbo.fnLOVText('KaBetriebCharakter', BET.CharakterCode),
       
       -- Dokument 
       KaBetriebDokumentID     = BED.KaBetriebDokumentID,    
       DokDatum                = BED.Datum,
       DokStichworte           = BED.Stichwort,
       DokAbsenderVornameName  = CASE 
                                   WHEN BED.AbsenderID > 0 THEN USR.FirstName + ISNULL(' ' + USR.LastName, '')
                                   ELSE KON.Vorname + ISNULL(' ' + KON.Name, '')
                                 END,
       
       -- Kontakt
       DokAdressatAnrede       = CASE 
                                   WHEN BED.AdressatID > 0 THEN CASE USR1.GenderCode
                                                                  WHEN 1 THEN 'Herr'
                                                                  WHEN 2 THEN 'Frau'
                                                                  ELSE 'Frau/Herr'
                                                                END
                                   ELSE CASE KON1.GeschlechtCode
                                          WHEN 1 THEN 'Herr'
                                          WHEN 2 THEN 'Frau'
                                          ELSE 'Frau/Herr'
                                        END
                                 END,
       DokAdressatSehrGeehrte  = CASE 
                                   WHEN BED.AdressatID > 0 THEN CASE USR1.GenderCode
                                                                  WHEN 1 THEN 'Sehr geehrter Herr ' + ISNULL(USR1.LastName, '')
                                                                  WHEN 2 THEN 'Sehr geehrte Frau ' + ISNULL(USR1.LastName, '')
                                                                  ELSE 'Sehr geehrte/r Frau/Herr ' + ISNULL(USR1.LastName, '')
                                                                END
                                   ELSE CASE KON1.GeschlechtCode
                                          WHEN 1 THEN 'Sehr geehrter Herr ' + ISNULL(KON1.Name, '')
                                          WHEN 2 THEN 'Sehr geehrte Frau ' + ISNULL(KON1.Name, '')
                                          ELSE 'Sehr geehrte/r Frau/Herr ' + ISNULL(KON1.Name, '')
                                        END
                                 END,
       DokAdressatLieberLiebe  = CASE 
                                   WHEN BED.AdressatID > 0 THEN CASE USR1.GenderCode
                                                                  WHEN 1 THEN 'Lieber'
                                                                  WHEN 2 THEN 'Liebe'
                                                                  ELSE 'Lieber / Liebe'
                                                                END
                                   ELSE CASE KON1.GeschlechtCode
                                          WHEN 1 THEN 'Lieber'
                                          WHEN 2 THEN 'Liebe'
                                          ELSE 'Lieber / Liebe'
                                        END
                                 END,  
       DokAdressatName         = CASE 
                                   WHEN BED.AdressatID > 0 THEN USR1.LastName
                                   ELSE KON1.Name
                                 END,
       DokAdressatVorname      = CASE 
                                   WHEN BED.AdressatID > 0 THEN USR1.FirstName
                                   ELSE KON1.Vorname
                                 END,   
       DokAdressatVornameName  = CASE 
                                   WHEN BED.AdressatID > 0 THEN USR1.FirstName + ISNULL(' ' + USR1.LastName, '')
                                   ELSE KON1.Vorname + ISNULL(' ' + KON1.Name, '')
                                 END,
       DokAdressatTel          = CASE 
                                   WHEN BED.AdressatID > 0 THEN USR1.Phone
                                   ELSE KON1.Telefon
                                 END,
       DokAdressatMobil        = CASE 
                                   WHEN BED.AdressatID > 0 THEN ''
                                   ELSE KON1.TelefonMobil
                                 END,
       DokAdressatAdresseMehrz = CASE
                                   WHEN KON1.UseZusatzadresse IS NULL OR KON1.UseZusatzadresse = 0 THEN 
                                     ISNULL(ADR.Zusatz + CHAR(13) + CHAR(10), '') +
                                     ISNULL(ADR.Strasse + ISNULL(' ' + ADR.HausNr, '') + CHAR(13) + CHAR(10), '') +
                                     ISNULL(dbo.fnBaGetPostfachText(NULL, ADR.Postfach, ADR.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                                     ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, '')
                                   ELSE
                                     ISNULL(KADR.Strasse + ISNULL(' ' + KADR.HausNr, '') + CHAR(13) + CHAR(10), '') +
                                     ISNULL(dbo.fnBaGetPostfachText(NULL, KADR.Postfach, KADR.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                                     ISNULL(KADR.PLZ + ' ', '') + ISNULL(KADR.Ort, '')
                                 END
FROM dbo.KaBetrieb                BET  WITH (READUNCOMMITTED)
  LEFT JOIN dbo.KaBetriebDokument BED  WITH (READUNCOMMITTED) ON BET.KaBetriebID = BED.KaBetriebID
  LEFT JOIN dbo.XUser             USR  WITH (READUNCOMMITTED) ON USR.UserID = BED.AbsenderID
  LEFT JOIN dbo.KaBetriebKontakt  KON  WITH (READUNCOMMITTED) ON KON.KaBetriebKontaktID = -BED.AbsenderID
  LEFT JOIN dbo.XUser             USR1 WITH (READUNCOMMITTED) ON USR1.UserID = BED.AdressatID
  LEFT JOIN dbo.KaBetriebKontakt  KON1 WITH (READUNCOMMITTED) ON KON1.KaBetriebKontaktID = -BED.AdressatID   
  LEFT JOIN dbo.BaAdresse         ADR  WITH (READUNCOMMITTED) ON ADR.BaAdresseID = dbo.fnBaGetBaAdresseID('KaBetriebID', BET.KaBetriebID, NULL, NULL)
  LEFT JOIN dbo.BaAdresse         KADR WITH (READUNCOMMITTED) ON KADR.BaAdresseID = dbo.fnBaGetBaAdresseID('KaBetriebKontaktID', KON1.KaBetriebKontaktID, NULL, NULL)
  LEFT JOIN dbo.BaLand            LAN  WITH (READUNCOMMITTED) ON LAN.BaLandID = ADR.BaLandID
  LEFT JOIN dbo.KaBetrieb         TBE  WITH (READUNCOMMITTED) ON TBE.KaBetriebID = BET.TeilbetriebID;
GO
