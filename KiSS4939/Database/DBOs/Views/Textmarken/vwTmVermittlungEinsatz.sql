SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmVermittlungEinsatz;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Views/Textmarken/vwTmVermittlungEinsatz.sql $
  $Author: Cjaeggi $
  $Modtime: 20.07.10 16:06 $
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    SELECT TOP 100 * FROM dbo.vwTmVermittlungEinsatz WITH (READUNCOMMITTED); 
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Views/Textmarken/vwTmVermittlungEinsatz.sql $
 * 
 * 5     20.07.10 16:07 Cjaeggi
 * #4167: Renamed column LandCode to BaLandID
 * 
 * 4     13.07.10 13:36 Cjaeggi
 * #4167: Fixed view after changes of BaAdresse, Refactoring
 * 
 * 3     6.08.09 10:24 Spsota
 * Views angepasst für neue Tabelle BaLand
 * 
 * 2     25.06.09 13:07 Ckaeser
 * Alter2Create
 * 
 * 1     11.09.08 14:52 Aklopfenstein
 * VSS First
=================================================================================================*/

CREATE VIEW dbo.vwTmVermittlungEinsatz
AS
SELECT KaVermittlungEinsatzID      = EIN.KaVermittlungEinsatzID,
       KaVermittlungVorschlagID    = EIN.KaVermittlungVorschlagID,
       KaEinsatzplatzID            = VOR.KaEinsatzplatzID,
       FaLeistungID                = VOR.FaLeistungID,
       EinsatzVon                  = EIN.EinsatzVon,
       EinsatzBis                  = EIN.EinsatzBis,
       Verlaengerung               = EIN.Verlaengerung,
       Arbeitspensum               = EIN.Arbeitspensum,
       BIEAZDatumVon               = EIN.BIEAZDatumVon,
       BIEAZDatumBis               = EIN.BIEAZDatumBis,
       BIEAZVerl                   = EIN.BIEAZVerlaengert,
       BIBruttolohn                = EIN.BIBruttolohn,
       BIEAZFinanzierungsgrad      = EIN.BIFinanzierungsgradEAZ,
       Abschluss                   = EIN.Abschluss,
       
       -- Zuständig KA
       ZustKANachname              = USR.LastName,
       ZustKAVorname               = USR.FirstName,
       ZustKAKuerzel               = USR.ShortName,
       ZustKATelephon              = USR.Phone,
       ZustKAEMail                 = USR.EMail,
       ZustKANameVorname           = USR.LastName + ISNULL(', ' + USR.FirstName, ''),
       ZustKANameVornameOhneKomma  = USR.LastName + ISNULL(' ' + USR.FirstName, ''),
       ZustKAVornameName           = ISNULL(USR.FirstName + ' ', '') + USR.LastName,
       
       -- Einsatzplatz
       Einsatzplatz                = EIP.Bezeichnung,
       EPBranche                   = dbo.fnLOVText('KaBranche', EIP.BrancheCode),
       EPKaProgramm                = dbo.fnLOVText('KaVermittlungProgramm', EIP.KaProgrammCode),
       EPLehrberuf                 = dbo.fnLOVText('KaLehrberuf', EIP.LehrberufCode),
       EPBerufsausbildung          = dbo.fnLOVText('KaBerufsausbildungTyp', EIP.BerufsAusbildungTyp),
       
       -- Betrieb
       Betrieb                     = BET.BetriebName,
       BetriebAdressZusatz         = ADR.Zusatz,
       BetriebStrasse              = ADR.Strasse,
       BetriebHausNr               = ADR.HausNr,
       BetriebPostfach             = ADR.Postfach,
       BetriebPLZ                  = ADR.PLZ,
       BetriebOrt                  = ADR.Ort,
       BetriebKanton               = ADR.Kanton,
       BetriebLand                 = LAN.Text,
       BetriebAdresseMehrzeilig    = ISNULL(ADR.Zusatz + CHAR(13) + CHAR(10), '') +
                                     ISNULL(ADR.Postfach + CHAR(13) + CHAR(10), '') +
                                     ISNULL(ADR.Strasse + ISNULL(' ' + ADR.HausNr, '') + CHAR(13) + CHAR(10), '') +
                                     ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, ''),
       
       -- Betrieb-Kontakt
       KontaktTitel                = KON.Titel,
       KontaktName                 = KON.Name,
       KontaktVorname              = KON.Vorname,
       KontaktGeschlecht           = dbo.fnLOVText('Geschlecht', KON.GeschlechtCode),
       KontaktTelefon              = KON.Telefon,
       KontaktTelefonMobil         = KON.TelefonMobil,
       KontaktFax                  = KON.Fax,
       KontaktEmail                = KON.EMail,
       KontaktNameVorname          = ISNULL(KON.Name + ', ', '') + ISNULL(KON.Vorname, ''),
       KontaktVornameName          = ISNULL(KON.Vorname + ' ', '') + ISNULL(KON.Name, ''),
       KontaktLieberLiebe          = CASE KON.GeschlechtCode
                                       WHEN 1 THEN 'Lieber'
                                       WHEN 2 THEN 'Liebe'
                                       ELSE 'Lieber / Liebe'
                                     END
FROM dbo.KaVermittlungEinsatz          EIN WITH (READUNCOMMITTED) 
  LEFT JOIN dbo.KaVermittlungVorschlag VOR WITH (READUNCOMMITTED) ON VOR.KaVermittlungVorschlagID = EIN.KaVermittlungVorschlagID
  LEFT JOIN dbo.KaEinsatzplatz         EIP WITH (READUNCOMMITTED) ON EIP.KaEinsatzplatzID = VOR.KaEinsatzplatzID
  LEFT JOIN dbo.KaBetrieb              BET WITH (READUNCOMMITTED) ON BET.KaBetriebID = EIP.KaBetriebID
  LEFT JOIN dbo.BaAdresse              ADR WITH (READUNCOMMITTED) ON ADR.BaAdresseID = dbo.fnBaGetBaAdresseID('KaBetriebID', EIP.KaBetriebID, NULL, NULL)
  LEFT JOIN dbo.KaBetriebKontakt       KON WITH (READUNCOMMITTED) ON KON.KaBetriebKontaktID = EIP.KaKontaktpersonID
  LEFT JOIN dbo.vwUser                 USR WITH (READUNCOMMITTED) ON USR.UserID = EIP.ZustaendigKA
  LEFT JOIN dbo.BaLand                 LAN WITH (READUNCOMMITTED) ON ADR.BaLandID = LAN.BaLandID;
GO