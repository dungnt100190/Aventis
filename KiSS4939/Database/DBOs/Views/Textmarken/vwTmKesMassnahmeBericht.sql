SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmKesMassnahmeBericht;
GO
/*===============================================================================================
  $Revision: 3$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: View für Textmarken: KES > Massnahmenführung > Berichts-/R.ablage und > Auftrage/Anträge
  -
  RETURNS: Alle Textmarken: KES > Massnahmenfürhung > Berichts-/R.ablage und > Auftrage/Anträge
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwTmKesMassnahmeBericht;
=================================================================================================*/

CREATE VIEW dbo.vwTmKesMassnahmeBericht
AS
SELECT
  -------------------------
  -- KesMassnahme
  -------------------------
  MAS.KesMassnahmeID,

  ArtikelNummer = dbo.ConcDistinct(ART.ArtikelNummer),
  ArtikelTextKurz = dbo.ConcDistinct(ART.BezeichnungKurz),
  ArtikelTextLang = dbo.ConcDistinct(ART.BezeichnungLang),
  ArtNmrTextKurz = dbo.ConcDistinct(ART.ArtikelNummer + ' ' + ART.BezeichnungKurz),
  ArtNmrTextLang = dbo.ConcDistinct(ART.ArtikelNummer + ' ' + ART.BezeichnungLang),

  DatErchtsbschlss = MAS.DatumVon,

  MFPNameVorname = MFP.NameVorname,
  MFPNmVrnmOhnKmma = MFP.NameVornameOhneKomma,
  MFPVornameName = MFP.VornameName,
  MFPAdrssEinzeilg = MFP.AdresseEinzeilig,
  MFPAdrssMhrzeilg = MFP.AdresseMehrzeilig,
  MFPErnanntSeit = MFP.DatumMandatVon,
  MFPPrmVrgchlSDAm = MFP.DatumVorgeschlagenAm,
  MFPPrmRchfrngVon= MFP.DatumRechnungsfuehrungVon,
  MFPPrmRchfrngBis= MFP.DatumRechnungsfuehrungBis,
    
  SARFrauHerr = USR.FrauHerr,
  SARFrauHerrn = USR.FrauHerrn,
  SARNameVorname = USR.NameVorname,
  SARNamVrnmOhnKma = USR.NameVornameOhneKomma,
  SARVornameName = USR.VornameName,
  SARAbteilungEMai = USR.AbteilungEMail,
  SARAbteilungFax = USR.AbteilungFax,
  SARAbteilungName = USR.AbteilungName,
  SARAbteilungTel = USR.AbteilungTelefon,
  SARNachname = USR.Nachname,
  SARVorname = USR.Vorname,
  SARKuerzel = USR.Kuerzel,
  SARTelephon = USR.Telephon,
  SAREMail = USR.EMail,
  
  ElterlicheSorgeD = dbo.fnLOVMLText('KesElterlicheSorgeObhut', MAS.KesElterlicheSorgeObhutCode_ElterlicheSorge, 1),
  ElterlicheSorgeF = dbo.fnLOVMLText('KesElterlicheSorgeObhut', MAS.KesElterlicheSorgeObhutCode_ElterlicheSorge, 2),
  ElterlicheSorgeI = dbo.fnLOVMLText('KesElterlicheSorgeObhut', MAS.KesElterlicheSorgeObhutCode_ElterlicheSorge, 3),  
  MassAuftragstext =  MAS.Auftragstext,

  -------------------------
  -- KesMassnahmeBericht
  -------------------------
  BER.KesMassnahmeBerichtID,

  PeriodeVon = BER.DatumVon,
  PeriodeBis = BER.DatumBis,
  Berichtsdatum = (SELECT DateLastSave FROM XDocument WHERE DocumentID = BER.DocumentID_Bericht),
  Rechnungsdatum = (SELECT DateLastSave FROM XDocument WHERE DocumentID = BER.DocumentID_Rechnung),
  BrchtArtDsBrchtD = dbo.fnLOVMLText('KesMassnahmeBerichtsart', BER.KesMassnahmeBerichtsartCode, 1),
  BrchtArtDsBrchtF = dbo.fnLOVMLText('KesMassnahmeBerichtsart', BER.KesMassnahmeBerichtsartCode, 2),
  BrchtArtDsBrchtI = dbo.fnLOVMLText('KesMassnahmeBerichtsart', BER.KesMassnahmeBerichtsartCode, 3),

  -------------------------
  -- KesMassnahmeAuftrag
  -------------------------
  KesMassnahmeAuftragID = AUF.KesMassnahmeAuftragID,
  AuftragAuftrag = AUF.Auftrag,
  AuftrgrtGschftsD = dbo.fnLOVMLText('KesMassnahmeGeschaeftsart', AUF.KesMassnahmeGeschaeftsartCode, 1),
  AuftrgrtGschftsF = dbo.fnLOVMLText('KesMassnahmeGeschaeftsart', AUF.KesMassnahmeGeschaeftsartCode, 2),
  AuftrgrtGschftsI = dbo.fnLOVMLText('KesMassnahmeGeschaeftsart', AUF.KesMassnahmeGeschaeftsartCode, 3)
  


  --Klient... via Standard-Textmarken: Klient...

FROM dbo.KesMassnahme MAS WITH (READUNCOMMITTED)
  INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = MAS.FaLeistungID
  INNER JOIN vwTmUser USR WITH (READUNCOMMITTED) ON USR.UserID = LEI.UserID
  OUTER APPLY (SELECT TOP 1 
				NameVorname           = ISNULL(USRI.NameVorname, INSI.NameVorname),
				NameVornameOhneKomma  = ISNULL(USRI.NameVornameOhneKomma, INSI.Name + ISNULL(' ' + INSI.Vorname, '')),
				VornameName           = ISNULL(USRI.VornameName, ISNULL(INSI.Vorname + ' ', '') + INSI.Name),
				AdresseEinzeilig      = ISNULL(USRI.AdresseEinzeilig, INSI.AdresseEinzeilig),
				AdresseMehrzeilig	  = ISNULL(USRI.AdresseMehrzeilig, INSI.AdresseMehrzeilig),
				MFPI.DatumMandatVon,
				MFPI.DatumMandatBis,
				MFPI.DatumVorgeschlagenAm,	
				MFPI.DatumRechnungsfuehrungVon,
				MFPI.DatumRechnungsfuehrungBis
			   FROM dbo.KesMandatsfuehrendePerson MFPI
			     LEFT JOIN dbo.vwTmUser USRI ON USRI.UserID = MFPI.UserID
			     LEFT JOIN dbo.vwTmInstitution INSI ON INSI.BaInstitutionID = MFPI.BaInstitutionID
			   WHERE MFPI.KesMassnahmeID = MAS.KesMassnahmeID
			   ORDER BY ISNULL(MFPI.DatumMandatBis, '99991231') DESC) MFP 
  LEFT JOIN dbo.KesMassnahme_KesArtikel KMA ON KMA.KesMassnahmeID = MAS.KesMassnahmeID
  OUTER APPLY (SELECT 
				ArtikelNummer = Artikel + ISNULL('.' + Absatz, '') + ISNULL('.' + Ziffer, '') + ' ' + Gesetz,
				BezeichnungKurz,
				BezeichnungLang = Bezeichnung
			   FROM dbo.KesArtikel 
			   WHERE KesArtikelID = KMA.KesArtikelID) ART
  LEFT JOIN dbo.KesMassnahmeBericht BER WITH (READUNCOMMITTED) ON BER.KesMassnahmeID = MAS.KesMassnahmeID
  LEFT JOIN dbo.KesMassnahmeAuftrag AUF WITH (READUNCOMMITTED) ON AUF.KesMassnahmeID = MAS.KesMassnahmeID
GROUP BY MAS.KesMassnahmeID, MAS.DatumVon, 
         MFP.NameVorname, MFP.NameVornameOhneKomma, MFP.VornameName, MFP.AdresseEinzeilig, MFP.AdresseMehrzeilig, MFP.DatumMandatVon, MFP.DatumVorgeschlagenAm, MFP.DatumRechnungsfuehrungVon, MFP.DatumRechnungsfuehrungBis,
         USR.FrauHerr, USR.FrauHerrn, USR.NameVorname, USR.NameVornameOhneKomma, USR.VornameName, USR.AbteilungEMail, USR.AbteilungFax, USR.AbteilungName, USR.AbteilungTelefon, USR.Nachname, USR.Vorname, USR.Kuerzel, USR.Telephon, USR.EMail, 
         MAS.KesElterlicheSorgeObhutCode_ElterlicheSorge, MAS.Auftragstext, 
         BER.KesMassnahmeBerichtID, BER.DatumVon, BER.DatumBis, BER.DocumentID_Bericht, BER.DocumentID_Rechnung, BER.KesMassnahmeBerichtsartCode,
         AUF.KesMassnahmeAuftragID, AUF.Auftrag,  AUF.KesMassnahmeGeschaeftsartCode
         
         
         
;
GO
