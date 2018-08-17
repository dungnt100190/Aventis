SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spSstZKBDokumenteZuordnen
GO
CREATE PROCEDURE [dbo].[spSstZKBDokumenteZuordnen]
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON

	DECLARE @Zuordnung TABLE
	(
	  SstZKBDokumenteID int,
		GeschaeftNr varchar(50),
		DocumentID int,
		Stichtag datetime,
		DokumentTypCode int,
		BaPersonID int,
		BaZahlungswegID int,
		KgKontoID int
	)

	-- Finde die fehlenden Zuordnungen
	INSERT INTO @Zuordnung
		SELECT ZKB.SstZKBDokumenteID, ZKB.ZKBGeschaeftNr, ZKB.DocumentID, ZKB.Stichtag, ZKB.ZKBDokumentTypCode, ZAW.BaPersonID, ZAW.BaZahlungswegID, KON.KgKontoID
		FROM SstZKBDokumente ZKB
			LEFT JOIN KgDokument DOK ON DOK.DocumentID = ZKB.DocumentID
			INNER JOIN BaZahlungsweg ZAW ON ZAW.BankKontoNummer = ZKB.ZKBGeschaeftNr
			LEFT JOIN KgPeriode PER ON PER.BaZahlungswegID = ZAW.BaZahlungswegID AND ZKB.Stichtag BETWEEN PER.PeriodeVon AND PER.PeriodeBis AND PER.KgPeriodeStatusCode = 1 -- 1 = aktiv 
			LEFT JOIN KgKonto KON ON KON.KgPeriodeID = PER.KgPeriodeID AND KON.KgKontoartCode = 1		-- 1 = Kontokorrentkonto 
		WHERE DOK.KgDokumentID IS NULL -- Es gibt noch keine Zuordnung
	--Neues ZKB-Format der Kontonummer
	INSERT INTO @Zuordnung
		SELECT ZKB.SstZKBDokumenteID, ZKB.ZKBGeschaeftNr, 
				ZKB.DocumentID, ZKB.Stichtag, 
				ZKB.ZKBDokumentTypCode, ZAW.BaPersonID, 
				ZAW.BaZahlungswegID, KON.KgKontoID
		FROM SstZKBDokumente ZKB
			LEFT JOIN KgDokument DOK ON DOK.DocumentID = ZKB.DocumentID
			INNER JOIN (SELECT KtoNr= '0-' + LEFT(BankKontoNummer,4) + '-0' + SUBSTRING(REPLACE(BankKontoNummer,'.',''),6,8), 
						* FROM BaZahlungsweg) ZAW ON ZAW.KtoNr = ZKB.ZKBGeschaeftNr
			LEFT JOIN KgPeriode PER ON PER.BaZahlungswegID = ZAW.BaZahlungswegID AND 
						ZKB.Stichtag BETWEEN PER.PeriodeVon AND PER.PeriodeBis AND PER.KgPeriodeStatusCode = 1 -- 1 = aktiv 
			LEFT JOIN KgKonto KON ON KON.KgPeriodeID = PER.KgPeriodeID AND KON.KgKontoartCode = 1		-- 1 = Kontokorrentkonto 
		WHERE DOK.KgDokumentID IS NULL -- Es gibt noch keine Zuordnung
		

  -- Speichere den Kontoauszug als neues KgDokument für das gefundene Konto ab
  INSERT INTO dbo.KgDokument (KgDokumentTypCode, DocumentID, Stichwort, Stichtag, KgKontoID, BaPersonID)
		SELECT 
			5, -- 5 = Konto 
			DocumentID,
			'Kontoauszug - ' + CONVERT(VARCHAR, Stichtag, 104),		-- Datum ist immer letzter Tag des Vormonats
			Stichtag,
			KgKontoID, 
			BaPersonID
		FROM @Zuordnung 
		WHERE DokumentTypCode = 1 -- 1 = Kontoauszug
			AND KgKontoID IS NOT NULL 
  
  -- Belastungen & Gutschrifen werden der Person zugewiesen
	INSERT INTO dbo.KgDokument (KgDokumentTypCode, DocumentID, Stichwort, Stichtag, BaPersonID)
    SELECT
      6, -- 6 = Mandant
      DocumentID,
			CASE 
				WHEN DokumentTypCode = 2 THEN 'Belastungsanzeige vom ' + CONVERT(varchar, Stichtag, 104)
				WHEN DokumentTypCode = 3 THEN 'Gutschriftsanzeige vom ' + CONVERT(varchar, Stichtag, 104)
			END,
			Stichtag,
			BaPersonID
		FROM @Zuordnung 
		WHERE DokumentTypCode IN (2,3) 
			AND BaPersonID IS NOT NULL 

END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO