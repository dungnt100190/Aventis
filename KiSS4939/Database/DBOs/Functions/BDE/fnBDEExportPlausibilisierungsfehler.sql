SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEExportPlausibilisierungsfehler;
GO
/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Erstellt die Validierungsmeldung für den ABAKUS Export.
    @Visiert: Ob alle BDELeistugnsexport Objekte visiert ist
    @KeinExportMin: Ob es einen Datensatz auf Ebene BDE-Leistungsexport gibt, der in diesem Feld ein 0 hat.
    @KeinExportMax: Ob es einen Datensatz auf Ebene BDE-Leistungsexport gibt, der in diesem Feld ein 1 hat.
    @NichtVerbucht: Ob der Datensatz schon verbucht ist.  
    @LanguageCode:  Sprache, in der der Plausibilisierungsfehler angezeigt werden soll.
  -
  RETURNS: Plausi-fehlertext.
=================================================================================================
  TEST:    SELECT dbo.fnBDEExportPlausi ...
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEExportPlausibilisierungsfehler
(
  @Visiert BIT,
  @KeinExportMin BIT,
  @KeinExportMax BIT,
  @NichtVerbucht BIT,
  @LanguageCode INT
)
RETURNS VARCHAR(500)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- <Block>
  -----------------------------------------------------------------------------
  DECLARE @Plausibilisierungsfehler VARCHAR(500);
  SET @Plausibilisierungsfehler = '';
  
  -- Visum fehlt
  IF @Visiert = 0
  BEGIN
	SELECT @Plausibilisierungsfehler = @Plausibilisierungsfehler + ' ' + ISNULL(dbo.fnGetMLTextFromName('CtlAbaStundenlohn', 'VisumFehlt', @LanguageCode), ''); 
  END
   
  IF @KeinExportMin <> @KeinExportMax
  BEGIN
	SELECT @Plausibilisierungsfehler = @Plausibilisierungsfehler + ' ' + ISNULL(dbo.fnGetMLTextFromName('CtlAbaStundenlohn', 'KeinExport', @LanguageCode), '');		
  END
  
  IF @NichtVerbucht = 0
  BEGIN
	SELECT @Plausibilisierungsfehler = @Plausibilisierungsfehler + ' ' + ISNULL(dbo.fnGetMLTextFromName('CtlAbaStundenlohn', 'NichtVerbucht', @LanguageCode), ''); 
  END
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN @Plausibilisierungsfehler;
END;
GO