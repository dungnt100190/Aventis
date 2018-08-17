SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spXAddDbObjectMLMsg;
GO
/*===============================================================================================
  $Revision: 21 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Run this stored procedure to insert all multilanguage texts for 
           database objects into database and let it translate on database or in KiSS
           The message may contain a '\r\n' if a newline is required.
  -
  RETURNS: Nothing but success message
  -
  EXECUTE: EXEC dbo.spXAddDbObjectMLMsg;  -- this call is required after each change!!
=================================================================================================
  TEST:    SELECT dbo.fnXDbObjectMLMsg('dbGeneral', 'Telefon', 1);
=================================================================================================*/

CREATE PROCEDURE dbo.spXAddDbObjectMLMsg
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- General:
  -----------------------------------------------------------------------------
  EXEC spXDbObjectMLMsg 'dbGeneral', 'Masculin', 'm';
  EXEC spXDbObjectMLMsg 'dbGeneral', 'Feminin', 'w';
  
  EXEC spXDbObjectMLMsg 'dbGeneral', 'Yes', 'Ja';
  EXEC spXDbObjectMLMsg 'dbGeneral', 'No', 'Nein';
  EXEC spXDbObjectMLMsg 'dbGeneral', 'Unknown', 'Unbekannt';
  
  EXEC spXDbObjectMLMsg 'dbGeneral', 'SehrGeehrteFamilie', 'Sehr geehrte Familie';
  EXEC spXDbObjectMLMsg 'dbGeneral', 'SehrGeehrterHerr', 'Sehr geehrter Herr';
  EXEC spXDbObjectMLMsg 'dbGeneral', 'SehrGeehrteFrau', 'Sehr geehrte Frau';
  EXEC spXDbObjectMLMsg 'dbGeneral', 'SehrGeehrteDamenHerren', 'Sehr geehrte Damen und Herren';
  
  EXEC spXDbObjectMLMsg 'dbGeneral', 'Familie', 'Familie';
  EXEC spXDbObjectMLMsg 'dbGeneral', 'Herr', 'Herr';
  EXEC spXDbObjectMLMsg 'dbGeneral', 'Frau', 'Frau';
  
  EXEC spXDbObjectMLMsg 'dbGeneral', 'Telefon', 'Tel.';
  EXEC spXDbObjectMLMsg 'dbGeneral', 'TelefonPrivat', 'P';
  EXEC spXDbObjectMLMsg 'dbGeneral', 'TelefonGeschaeft', 'G';
  EXEC spXDbObjectMLMsg 'dbGeneral', 'TelefonMobil', 'M';
  
  EXEC spXDbObjectMLMsg 'dbGeneral', 'Postfach', 'Postfach';
  EXEC spXDbObjectMLMsg 'dbGeneral', 'Geburtsdatum', 'Geburtsdatum';
  EXEC spXDbObjectMLMsg 'dbGeneral', 'ID', 'ID';
  
  -----------------------------------------------------------------------------
  -- Views:
  -----------------------------------------------------------------------------
  -- vwTmBaPerson
  EXEC spXDbObjectMLMsg 'vwTmBaPerson', 'AHVNr', 'AHV-Nr.';
  EXEC spXDbObjectMLMsg 'vwTmBaPerson', 'VersNr', 'Vers.-Nr.';
  
  -----------------------------------------------------------------------------
  -- Functions:
  -----------------------------------------------------------------------------
  -- fnBDEGetLohnartDropDown
  EXEC spXDbObjectMLMsg 'fnBDEGetLohnartDropDown', 'MonatslohnEntry', 'Monatslohn';
  
  -- fnGetWeekDayFromDate
  EXEC spXDbObjectMLMsg 'fnGetWeekDayFromDate', 'DaySonntagShort', 'So';
  EXEC spXDbObjectMLMsg 'fnGetWeekDayFromDate', 'DayMontagShort', 'Mo';
  EXEC spXDbObjectMLMsg 'fnGetWeekDayFromDate', 'DayDienstagShort', 'Di';
  EXEC spXDbObjectMLMsg 'fnGetWeekDayFromDate', 'DayMittwochShort', 'Mi';
  EXEC spXDbObjectMLMsg 'fnGetWeekDayFromDate', 'DayDonnerstagShort', 'Do';
  EXEC spXDbObjectMLMsg 'fnGetWeekDayFromDate', 'DayFreitagShort', 'Fr';
  EXEC spXDbObjectMLMsg 'fnGetWeekDayFromDate', 'DaySamstagShort', 'Sa';
  --
  EXEC spXDbObjectMLMsg 'fnGetWeekDayFromDate', 'DaySonntagLong', 'Sonntag';
  EXEC spXDbObjectMLMsg 'fnGetWeekDayFromDate', 'DayMontagLong', 'Montag';
  EXEC spXDbObjectMLMsg 'fnGetWeekDayFromDate', 'DayDienstagLong', 'Dienstag';
  EXEC spXDbObjectMLMsg 'fnGetWeekDayFromDate', 'DayMittwochLong', 'Mittwoch';
  EXEC spXDbObjectMLMsg 'fnGetWeekDayFromDate', 'DayDonnerstagLong', 'Donnerstag';
  EXEC spXDbObjectMLMsg 'fnGetWeekDayFromDate', 'DayFreitagLong', 'Freitag';
  EXEC spXDbObjectMLMsg 'fnGetWeekDayFromDate', 'DaySamstagLong', 'Samstag';
  
  -- fnEdGetEntlasterKontakt
  EXEC spXDbObjectMLMsg 'fnEdGetEntlasterKontakt', 'Email', 'E-Mail';
  
  -- fnGetFlexibleAdress
  EXEC spXDbObjectMLMsg 'fnGetFlexibleAdress', 'Postfach', 'Postfach';
  
  -- fnXKurzMonat
  EXEC spXDbObjectMLMsg 'fnXKurzMonat', 'Januar', 'Jan';
  EXEC spXDbObjectMLMsg 'fnXKurzMonat', 'Februar', 'Feb';
  EXEC spXDbObjectMLMsg 'fnXKurzMonat', 'Maerz', 'Mrz';
  EXEC spXDbObjectMLMsg 'fnXKurzMonat', 'April', 'Apr';
  EXEC spXDbObjectMLMsg 'fnXKurzMonat', 'Mai', 'Mai';
  EXEC spXDbObjectMLMsg 'fnXKurzMonat', 'Juni', 'Jun';
  EXEC spXDbObjectMLMsg 'fnXKurzMonat', 'Juli', 'Jul';
  EXEC spXDbObjectMLMsg 'fnXKurzMonat', 'August', 'Aug';
  EXEC spXDbObjectMLMsg 'fnXKurzMonat', 'September', 'Sep';
  EXEC spXDbObjectMLMsg 'fnXKurzMonat', 'Oktober', 'Okt';
  EXEC spXDbObjectMLMsg 'fnXKurzMonat', 'November', 'Nov';
  EXEC spXDbObjectMLMsg 'fnXKurzMonat', 'Dezember', 'Dez';
  
  -----------------------------------------------------------------------------
  -- Stored Procedures:
  -----------------------------------------------------------------------------
  -- spBDEGetLeistungWoche
  EXEC spXDbObjectMLMsg 'spBDEGetLeistungWoche', 'CalendarWeek', 'KW';
  
  -- spFaGetFallInfoData
  EXEC spXDbObjectMLMsg 'spFaGetFallInfoData', 'GroupHeaderFallverlauf', 'Fallverlauf';
  EXEC spXDbObjectMLMsg 'spFaGetFallInfoData', 'GroupHeaderAktiv', 'aktiv';
  EXEC spXDbObjectMLMsg 'spFaGetFallInfoData', 'GroupHeaderAbgeschlossen_v01', 'geschlossen';
  EXEC spXDbObjectMLMsg 'spFaGetFallInfoData', 'GroupHeaderKlient', 'Klient/in';
  EXEC spXDbObjectMLMsg 'spFaGetFallInfoData', 'GroupHeaderMitarbeiter_v01', 'Verantwortliche/r MA';
  
  -- spEdEinsatzTextmarkeListen
  EXEC spXDbObjectMLMsg 'spEdEinsatzTextmarkeListen', 'ValueFrom', 'von';
  EXEC spXDbObjectMLMsg 'spEdEinsatzTextmarkeListen', 'ValueTo', 'bis';
  
  -- spFaTextmarkenSBCM
  EXEC spXDbObjectMLMsg 'spFaTextmarkenSBCM', 'Rahmenziel', 'Rahmenziel';
  EXEC spXDbObjectMLMsg 'spFaTextmarkenSBCM', 'Handlungsziel', 'Handlungsziel';
  EXEC spXDbObjectMLMsg 'spFaTextmarkenSBCM', 'Massnahme', 'Massnahme';
  EXEC spXDbObjectMLMsg 'spFaTextmarkenSBCM', 'Lebensbereich', 'Lebensbereich';
  EXEC spXDbObjectMLMsg 'spFaTextmarkenSBCM', 'Durch', 'Durch';
  EXEC spXDbObjectMLMsg 'spFaTextmarkenSBCM', 'Indikatoren', 'Indikatoren';
  EXEC spXDbObjectMLMsg 'spFaTextmarkenSBCM', 'Kommentar', 'Kommentar';
  EXEC spXDbObjectMLMsg 'spFaTextmarkenSBCM', 'Frist', 'Frist';
  EXEC spXDbObjectMLMsg 'spFaTextmarkenSBCM', 'Evaluation', 'Evaluation';
  EXEC spXDbObjectMLMsg 'spFaTextmarkenSBCM', 'Erledigt', 'Erledigt';
  EXEC spXDbObjectMLMsg 'spFaTextmarkenSBCM', 'NichtErledigt', 'Nicht erledigt';

  -- spQRYAktiveNeueDossiers
  EXEC spXDbObjectMLMsg 'spQRYAktiveNeueDossiers', 'Befristet', 'Befristet';
  EXEC spXDbObjectMLMsg 'spQRYAktiveNeueDossiers', 'Unbefristet', 'Unbefristet';

  -- spWhPositionsart_Terminieren
  EXEC spXDbObjectMLMsg 'spWhPositionsart_Terminieren', 'FehlerhafteParameter', 'Fehlerhafte Parameter (@BgPositionsartID, @DatumBis) wurden übergeben.';
  EXEC spXDbObjectMLMsg 'spWhPositionsart_Terminieren', 'PositionsartBereitsTerminiert', 'Die Positionsart ist bereits auf: %s terminiert.'; -- %s: das bisherige Terminier-Datum
  EXEC spXDbObjectMLMsg 'spWhPositionsart_Terminieren', 'GrueneBudgetsExistieren', 'Die Positionsart kann frühestens auf: %s terminiert werden.\r\nEs existieren grüne Monatsbudgets mit dieser Positionsart nach dem eingegebenen Datum: %s'; -- %s: das früheste Terminier-Datum, %s: die Monatsbudgets mit Positionen dieser Positionsart
  EXEC spXDbObjectMLMsg 'spWhPositionsart_Terminieren', 'GraueBudgetsExistieren', 'Die Positionsart kann frühestens auf: %s terminiert werden.\r\nEs gibt graue Monatsbudgets mit dieser Positionsart nach dem eingegebenen Datum: %s'; -- %s: das früheste Terminier-Datum, %s: die Monatsbudgets mit Positionen dieser Positionsart
  EXEC spXDbObjectMLMsg 'spWhPositionsart_Terminieren', 'SpezialkontiExistieren', 'Die Positionsart kann nicht auf das eingegebene Datum terminiert werden.\r\nAuf der Positionsart gibt es Spezialkonti, welche nach dem eingegebenen Datum noch aktiv sein werden: %s'; -- %s: die noch aktiven Spezialkonti
  EXEC spXDbObjectMLMsg 'spWhPositionsart_Terminieren', 'AllgemeinerFehler', 'Die Positionsart kann nicht terminiert werden. Datenbank-Fehler: %s.'; --%s: die Fehlermeldung der Datenbank
  -----------------------------------------------------------------------------
  -- ClassNames:
  -----------------------------------------------------------------------------
  -- ...
  
  -----------------------------------------------------------------------------
  -- Done
  -----------------------------------------------------------------------------
  SELECT Info = 'Inserted dbo multilanguage texts into database.';
  RETURN 1;
END;
GO
