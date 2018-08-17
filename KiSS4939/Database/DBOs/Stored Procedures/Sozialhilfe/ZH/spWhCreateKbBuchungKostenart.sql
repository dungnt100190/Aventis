SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhCreateKbBuchungKostenart
GO

/*===============================================================================================
  $Revision: 4$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spWhCreateKbBuchungKostenart 
  @KbBuchungID int,
  @BgPositionID int,
  @BgKostenartID int,
  @BaPersonID int,
  @Buchungstext varchar(500),
  @Betrag money,
  @BaZahlungswegID int,
  @KbAuszahlungsartCode int,
  @Hauptvorgang int,
  @Teilvorgang int,
  @Belegart varchar(4),
  @Valutadatum datetime,
  @BgKategorieCode int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    IF @Betrag = $0.00 
	  RETURN

    INSERT INTO KbBuchungKostenart ( KbBuchungID, BgPositionID, BgKostenartID, BaPersonID, Buchungstext, Betrag, BaZahlungswegID, PCKontoNr, BankKontoNr, KbAuszahlungsArtCode, [Name], Zusatz, Strasse, PLZ, Ort, Hauptvorgang, Teilvorgang, Belegart, Valutadatum, BgKategorieCode )
      SELECT TOP 1 @KbBuchungID, @BgPositionID, @BgKostenartID, @BaPersonID, @Buchungstext, @Betrag, @BaZahlungswegID, ZAL.PostKontoNummer, ZAL.BankKontoNummer, @KbAuszahlungsartCode,
         CASE WHEN PRS.BaPersonID IS NOT NULL THEN PRS.NameVorname ELSE INS.Name END, NULL, 
         CASE WHEN PRS.BaPersonID IS NOT NULL THEN PRS.WohnsitzStrasseHausNr ELSE INS.StrasseHausNr END,
         CASE WHEN PRS.BaPersonID IS NOT NULL THEN PRS.WohnsitzPLZ ELSE INS.PLZ END,
         CASE WHEN PRS.BaPersonID IS NOT NULL THEN PRS.WohnsitzOrt ELSE INS.Ort END,
         @Hauptvorgang, @Teilvorgang, @Belegart, @Valutadatum, @BgKategorieCode
      FROM BaZahlungsweg ZAL
        LEFT JOIN vwPerson PRS      ON PRS.BaPersonID      = ZAL.BaPersonID
        LEFT JOIN vwInstitution INS ON INS.BaInstitutionID = ZAL.BaInstitutionID
      WHERE BaZahlungswegID = @BaZahlungswegID 

	--print 'Create KbBuchungKostenart, Betrag: ' + cast(@Betrag as varchar)+ ', Person ' + cast(@BaPersonID as varchar)
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
