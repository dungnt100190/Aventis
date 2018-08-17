SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spSstZKBDokumentSave
GO
CREATE PROCEDURE [dbo].[spSstZKBDokumentSave]
(
  @ZKBDokumentTypCode   int,
  @Filename varchar(100),
  @GeschaeftsNr varchar(50),
  @PartnerNr varchar(20),
  @FileBinary	image,
  @BelegDatum datetime
)
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON

  DECLARE @DocID int
  DECLARE @ZahlwegID int
  DECLARE @PersonID int
  DECLARE @PeriodeID int
  DECLARE @KontoID int
  DECLARE @Text varchar(100)
  
	-- Importiere das File ev. bereits schon mal importiert wurde (Filename ist eindeutig). Falls ja, ignorieren wir dieses File und gib -1 als Antwort zurück
	IF EXISTS(SELECT TOP 1 1 FROM dbo.SstZKBDokumente WHERE ZKBFileName = @Filename) BEGIN
			SELECT -1
			RETURN 
	END

  -- Suche die Person und das Konto anhand von BaZahlungsweg.BankKontoNummer = ZKBGeschaeftsNr
  SELECT @ZahlwegID = BaZahlungswegID, @PersonID = BaPersonID FROM BaZahlungsweg WHERE BankKontoNummer = @GeschaeftsNr  
  -- Suche die aktive Periode
  SELECT @PeriodeID = KgPeriodeID FROM KgPeriode WHERE @BelegDatum BETWEEN PeriodeVon AND PeriodeBis
  IF @PeriodeID IS NULL 
  BEGIN
	SELECT @PeriodeID = KgPeriodeID FROM KgPeriode WHERE BaZahlungswegID = @ZahlwegID AND KgPeriodeStatusCode = 1 /* 1 = aktiv */ 
  END
  -- Suche das Kontokorrent-Konto der aktiven Periode 
  SELECT @KontoID = KgKontoID FROM KgKonto WHERE KgPeriodeID = @PeriodeID AND KgKontoartCode = 1	/* 1 = Kontokorrentkonto */

  -- Speichere das Dokument selber
	INSERT INTO dbo.XDocument (DateCreation, FileBinary, DocFormatCode, FileExtension, DocReadonly, DocTypeCode) 
	VALUES
	(
		GETDATE(), 
		@FileBinary, 
		3,	-- DocFormatCode = PDF
		'.pdf', 
		1,		-- Readonly
		2     -- Dokument
	)
  Set @DocID = SCOPE_IDENTITY()
  
  -- Speichere die Metadaten des ZKB-Dokuments
  INSERT INTO dbo.SstZKBDokumente (ZKBPartnerNr, ZKBGeschaeftNr, ZKBFileName, Stichtag, ZKBDokumentTypCode, DocumentID)
  VALUES
  (
    @PartnerNr,
    @GeschaeftsNr,
    @Filename, 
    @BelegDatum,
    @ZKBDokumentTypCode,
    @DocID
  )

  -- Gib die DokumentID zurück
	Select @DocID as NewDocID
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
