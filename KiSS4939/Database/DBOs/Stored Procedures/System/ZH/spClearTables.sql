SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spClearTables
GO

CREATE  PROCEDURE [dbo].[spClearTables]
AS
  -- don't do this to our beloved MasterDB!
  IF( DB_NAME() = 'KiSS4_MASTER_ZH' )
    RETURN -1

  DELETE FROM XTask
  DELETE FROM FaCheckin
  DELETE FROM FaAbklaerung
  DELETE FROM FaVoranmeldung
  DELETE FROM FaRessourcenpaket
  DELETE FROM FaDokumente
  DELETE FROM FaAktennotizen
  DELETE FROM FaZielvereinbarung
  DELETE FROM FaVoranmeldung
  DELETE FROM AmAbPosition
  DELETE FROM AmAbKind
  DELETE FROM AmAnspruchsberechnung
  DELETE FROM FaUnterlagenliste
  DELETE FROM FaUnterlagen
  DELETE FROM FaAssessment
  DELETE FROM FaTeilLeistungserbringer
  DELETE FROM FaWeitereLeistungserbringer
  DELETE FROM FaCheckinAlim
  DELETE FROM FaRessourcenkarte
  DELETE FROM FaAbmachung
  DELETE FROM KbBuchungKostenartBrutto
  DELETE FROM KbBuchungBrutto
  DELETE FROM KbBuchungKostenart
  DELETE FROM KbBuchung
  DELETE FROM BgPosition
  DELETE FROM BgBudget
  DELETE FROM BgFinanzplan_BaPerson
  DELETE FROM BgFinanzplan
  DELETE FROM FaPhase
  DELETE FROM IkZahlungBetreibung
  DELETE FROM IkBetreibung
  DELETE FROM IkForderungBetrag
  DELETE FROM IkForderung
  DELETE FROM IkGlaeubiger
  DELETE FROM IkRatenplan
  DELETE FROM IkRechtstitel
  DELETE FROM IkAnzeige
  DELETE FROM IkLeistung
  DELETE FROM KgBuchung
  DELETE FROM KgZahlungseingang
  --DELETE FROM KgTeamMitglied
  --DELETE FROM KgTeam
  DELETE FROM KgKonto
  DELETE FROM KgPeriode
  DELETE FROM KgPosition
  DELETE FROM KgBudget
  --DELETE FROM KgFinanzPlan
  DELETE FROM FaDienstleistungspaketOld
  DELETE FROM WhEkEntscheid
  DELETE FROM VmMassnahme
  DELETE FROM VmMandat
  DELETE FROM WhWVEinheitMitglied
  DELETE FROM WhWVEinheit
  DELETE FROM FaJournal
  DELETE FROM FaPendenzgruppe_XUser
  DELETE FROM FaInvolvierteInstitution
  DELETE FROM FaInvolviertePerson
  --DELETE FROM BaPerson_Relation
  DELETE FROM FaFallPerson
  DELETE FROM FaLeistung
  DELETE FROM FaFall
  DELETE FROM BaArbeit
  --DELETE FROM BaZahlungsweg
  --DELETE FROM BaAdresse
  DELETE FROM BgAuszahlungPerson
  DELETE FROM BaWohnsituationPerson
  DELETE FROM BaWohnsituation
  DELETE FROM BaErsatzeinkommen
  DELETE FROM BaKrankenversicherung
  DELETE FROM BaWVCode
  DELETE FROM BaVermoegen
  DELETE FROM BaAlteFallNr
  DELETE FROM BaPraemienuebernahme
  DELETE FROM BaPraemienverbilligung
  --DELETE FROM BaPerson
  --DELETE FROM BaInstitutionKontakt
  --DELETE FROM BaInstitution
  DELETE FROM XArchive
  DELETE FROM XUser_Archive
  DELETE FROM XChangeLog
