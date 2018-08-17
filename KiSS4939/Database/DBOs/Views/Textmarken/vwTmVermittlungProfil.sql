SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmVermittlungProfil
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================*/

CREATE VIEW dbo.vwTmVermittlungProfil
AS

SELECT	KaVermittlungProfilID		= PRO.KaVermittlungProfilID,
		LeistungID					= PRO.FaLeistungID,
		Branchen					= REPLACE(dbo.fnLOVTextListe('KaBranche', PRO.BrancheCodes), ',', char(13) + char(10)),
		Betriebe					= REPLACE(dbo.fnLOVTextListe('KaVermittlungKaBetriebe', PRO.KaBetriebCodes), ',', char(13) + char(10)),
		Einsatzbereiche				= REPLACE(dbo.fnLOVTextListe('KaVermittlungEinsatzbereich', PRO.EinsatzbereichCodes), ',', char(13) + char(10)),
		Lehrberuf					= dbo.fnLOVText('KaLehrberuf', PRO.LehrberufCode),
		[DeutschMuendlich]			= dbo.fnLOVText('KaDeutschkenntnisse', PRO.DeutschMuendlichCode),
		[DeutschSchriftlich]		= dbo.fnLOVText('KaDeutschkenntnisse', PRO.DeutschSchriftlichCode),
		[AmTelVerst]				= PRO.KannSichAmTelVerstaendigen,
		Sprachstandermittlung		= dbo.fnLOVText('KaVermittlungSprachstandermittlung', PRO.Sprachstandermittlung),
		[VermittelbarkeitBIBIP]		= dbo.fnLOVText('KaVermittlungBIBIPVermittelbarkeit', PRO.VermittelbarkeitBIBIPCode),
		[VermittelbarkeitSI]		= dbo.fnLOVText('KaVermittlungSiVermittelbarkeit', PRO.VermittelbarkeitSICode),
		[VermittelbarkeitBemerkung] = PRO.VermittelbarkeitBemerkung,
		Sucht						= dbo.fnLOVText('JaNeinUnklar', PRO.SuchtCode),
		Suchtart				 	= dbo.fnLOVText('KaVermittlungSuchtart', PRO.SuchtartCode),
		Gesundheit					= dbo.fnLOVText('KaVermittlungBIBIPGesundheit', PRO.GesundheitCode),
		[GesundheitEinschraenkungen] = PRO.GesundheitEinschraenkungen,
		[GesundheitKoerperlich]		 = dbo.fnLOVText('KaVermittlungSiGesundheit', PRO.GesundheitKoerperlichCode),
		[EinschraenkungenKoerperlich] = PRO.GesundheitBemerkung,
		[GesundheitBemerkung] = PRO.GesundheitBemerkung,
		[GesundheitPsychisch]		= dbo.fnLOVText('KaVermittlungSiGesundheit', PRO.GesundheitPsychischCode),
		Therapie					= dbo.fnLOVText('JaNein', PRO.TherpieCode),
		[Zuverlaessigkeit]			= dbo.fnLOVText('JaNeinBedingt', PRO.ZuverlaessigkeitCode),
		[MotivationInizio]			= dbo.fnLOVText('KaInizioMotivation', PRO.MotivationInizioCode),
		[MotivationBIBIPSI]			= dbo.fnLOVText('JaNeinBedingt', PRO.MotivationBIBIPSICode),
		[AeussereErscheinungBIBIP]	= dbo.fnLOVText('KaVermittlungBIBIPAeussereErscheinung', PRO.AeussereErscheinungCode),
		[AeussereErscheinungSI]		= dbo.fnLOVText('KaVermittlungSIAeussereErscheinung', PRO.AeussereErscheinungCode),
		InfoAnSDErfolgt				= PRO.InfoAnSDErfolgt,
		Kinderbetreuung				= dbo.fnLOVText('KaVermittlungSIKinderbetreuung', PRO.Kinderbetreuung),
		Einsatzpensum				= PRO.Einsatzpensum,
		EinsatzpensumVon			= PRO.EinsatzpensumVon,
		EinsatzpensumBis			= PRO.EinsatzpensumBis,
		BesondereWuensche			= PRO.BesondereWuensche,
		BesondereFaehigkeiten		= PRO.BesondereFaehigkeiten,
		Fuehrerausweis				= dbo.fnLOVText('JaNein', PRO.FuehrerausweisCode),
		FuehrerausweisKategorie		= dbo.fnLOVText('KaFuehrerausweisKategorie', PRO.FuehrerausweisKategorieCode),
		PCKenntnisse				= dbo.fnLOVText('JaNein', PRO.PCKenntnisseCode),
		Ausbildung					= dbo.fnLOVText('KaAusbildung', PRO.AusbildungCode),
		Arbeitszeiten				= REPLACE(dbo.fnLOVTextListe('KaVermittlungSIArbeitszeit', PRO.ArbeitszeitenCodes), ',', char(13) + char(10)),
		Unterstützung				= REPLACE(dbo.fnLOVTextListe('KaInizioUnterstuetzung', PRO.UnterstuetzungInizioCodes), ',', char(13) + char(10)),
		SIGespraech					= PRO.SIGespraech,
		SIGespraechfuehrerin		= USR.NameVorname,
		GespraechInizio				= PRO.GespraechDatum,
		Ausbildungswunsch			= dbo.fnLOVText('KaBerufsausbildungTyp', PRO.AusbildungstypWunschCode),
		Berufswunsch				= dbo.fnLOVText('KaLehrberuf', PRO.LehrberufWunschCode),
		Bemerkungen					= PRO.Bemerkungen,
		ArbeitsgebietBemerkung		= PRO.ArbeitsgebietBemerkungen,
		GesundheitKoerperlichBewertung = PRO.GesundheitKoerperlichBewertung,
		GesundheitPsychischBewertung = PRO.GesundheitPsychischBewertung,
		ZuverlaessigkeitBewertung   = PRO.ZuverlaessigkeitBewertung,
		MotivationBIBIPSIBewertung  = PRO.MotivationBIBIPSIBewertung,
    Schweizerdeutsch = dbo.fnLOVText('KaSchweizerdeutsch', PRO.KaSchweizerdeutschCode),
    LohnabtretungSD = dbo.fnLOVText('JaNein', PRO.KaLohnabtretungSDCode),
    LaufendeBetreibungen = dbo.fnLOVText('JaNein', PRO.KaLaufendeBetreibungenCode),
    AktuelleTaetigkeit = PRO.AktuelleTaetigkeit,
    Verfuegbarkeit = dbo.fnLOVText('KaVerfuegbarkeit', PRO.KaVerfuegbarkeitCode),
    EinschraenkungMontag = PRO.EinschraenkungMO,
    EinschraenkungDienstag = PRO.EinschraenkungDI,
    EinschraenkungMittwoch = PRO.EinschraenkungMI,
    EinschraenkungDonnerstag = PRO.EinschraenkungDO,
    EinschraenkungFreitag = PRO.EinschraenkungFR,
    EinschraenkungSamstag = PRO.EinschraenkungSA,
    EinschraenkungSonntag = PRO.EinschraenkungSO,
    Nachtarbeit = dbo.fnLOVText('JaNein', PRO.KaNachtarbeitCode)
FROM	dbo.KaVermittlungProfil PRO WITH (READUNCOMMITTED) 
	LEFT JOIN dbo.vwUser USR ON USR.UserID = PRO.SIGespraechfuehrerinID
GO