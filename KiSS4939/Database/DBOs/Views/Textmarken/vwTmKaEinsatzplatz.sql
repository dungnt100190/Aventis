SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmKaEinsatzplatz
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Views/vwTmKaEinsatzplatz.sql $
  $Author: Lgreulich $
  $Modtime: 31.08.09 13:09 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken für die Maske KA - Einsatzplatz
  -
  RETURNS: .
  -
  TEST:    SELECT * FROM vwTmKaEinsatzplatz
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Views/vwTmKaEinsatzplatz.sql $
 * 
 * 2     31.08.09 13:09 Lgreulich
 * 
 * 1     31.08.09 12:47 Lgreulich
 * 
 * 
 * 
 * VSS First
=================================================================================================*/

CREATE VIEW dbo.vwTmKaEinsatzplatz
AS

SELECT
	-- Grundinformationen
	KaEinsatzplatzID    = EIN.KaEinsatzplatzID,
	Aktiv               = CASE WHEN EIN.Aktiv = 1 THEN 'aktiv' ELSE 'inaktiv' END,
	Bezeichnung         = EIN.Bezeichnung,
	Branche             = dbo.fnLOVText('KaBranche', EIN.BrancheCode),
	Betrieb             = BET.BetriebName,
	BetriebAdresse      = IsNull(ADR.Strasse, '') + IsNull(' ' + ADR.HausNr, '') + IsNull(', ' + ADR.PLZ, '') + IsNull(' ' + ADR.Ort, ''),
	Stellenbeschreibung = EIN.Details,
	KAProgramm          = dbo.fnLOVText('KaVermittlungProgramm', EIN.KAProgrammCode),
	ZustaendigKA        = USR.LastName + IsNull(', ' + USR.FirstName, ''),
	Lehrberuf           = dbo.fnLOVText('KaLehrberuf', EIN.LehrberufCode),
	TypAusbildung       = dbo.fnLOVText('KaBerufsausbildungTyp', EIN.BerufsausbildungTyp),
	NeuGeschLehrstelle  = CASE WHEN EIN.NeuGeschaffeneLehrstelle = 1 THEN 'ja' ELSE 'nein' END,
  
	-- Dauer/Pensum
	ErfasstAm        = EIN.ErfassungsDatum,
	EinsatzAb        = EIN.EinsatzAb,
	unbefristet      = CASE WHEN EIN.DauerUnbefristet = 1 THEN 'ja' ELSE 'nein' END,
	Gesamtpensum     = EIN.GesamtPensum,
	aufteilbar       = CASE WHEN EIN.PensumAufteilbar = 1 THEN 'ja' ELSE 'nein' END,
	PensumUnbestimmt = CASE WHEN EIN.PensumUnbestimmt = 1 THEN 'ja' ELSE 'nein' END,
	EinzelpensumVon  = EIN.EinzelpensumMinimum,
	EinzelpensumBis  = EIN.EinzelpensumMaximum,     
  
	-- Anforderungen
	Fuehrerausweis       = CASE WHEN EIN.Fuehrerausweis = 1 THEN 'ja' ELSE 'nein' END,
	FuehrerausweisKat    = dbo.fnLOVText('KaFuehrerausweisKategorie', EIN.FuehrerausweisKategorieCode),
	PCKenntnisse         = CASE WHEN EIN.PCKenntnisse = 1 THEN 'ja' ELSE 'nein' END,
	Geschlecht           = dbo.fnLOVText('KaEinsatzplatzGeschlecht', EIN.GeschlechtCode),
	WeitereAnforderungen = EIN.WeitereAnforderungen,
	DeutschMuendlich     = dbo.fnLOVText('KaDeutschkenntnisse', EIN.DeutschMuendlichCode),
	DeutschSchriftlich   = dbo.fnLOVText('KaDeutschkenntnisse', EIN.DeutschSchriftlichCode),
	Ausbildung           = dbo.fnLOVText('KaAusbildung', EIN.AusbildungCode),
   
	-- Kontaktperson
	Kontaktperson       = IsNull(Name + ', ', '') + IsNull(Vorname, ''),
	KontaktFunktion     = dbo.fnLOVText('KaEinsatzplatzKontaktFunktion', EIN.FunktionCode),            
	KontaktBemerkung    = EIN.Bemerkung,
	KontaktTelefon      = KON.Telefon,
	KontaktTelefonMobil = KON.TelefonMobil,
	KontaktFax          = KON.Fax,
	KontaktEMail        = KON.Email
      
FROM dbo.KaEinsatzplatz            EIN WITH (READUNCOMMITTED)
	LEFT JOIN dbo.KaBetrieb        BET WITH (READUNCOMMITTED) ON BET.KaBetriebID = EIN.KaBetriebID
	LEFT JOIN dbo.BaAdresse        ADR WITH (READUNCOMMITTED) ON ADR.KaBetriebID = BET.KaBetriebID
                             AND GetDate() BETWEEN IsNull(ADR.DatumVon, GetDate()) AND IsNull(ADR.DatumBis, GetDate())
	LEFT JOIN dbo.XUser            USR WITH (READUNCOMMITTED) ON USR.UserID = EIN.ZustaendigKA
	LEFT JOIN dbo.KaBetriebKontakt KON WITH (READUNCOMMITTED) ON KON.KaBetriebKontaktID = EIN.KaKontaktpersonID 

GO 