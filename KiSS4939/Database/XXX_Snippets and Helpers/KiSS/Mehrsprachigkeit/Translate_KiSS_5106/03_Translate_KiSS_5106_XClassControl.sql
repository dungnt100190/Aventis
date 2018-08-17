/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: XClassControl übersetzen
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- Step 1: XClassControl
-------------------------------------------------------------------------------
DECLARE @TID INT;
DECLARE @Text VARCHAR(2000);
DECLARE @ClassName VARCHAR(255);
DECLARE @ControlName VARCHAR(255);
DECLARE @ComponentName VARCHAR(200);

DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @TextDE VARCHAR(2000);
DECLARE @TextFR VARCHAR(2000);
DECLARE @TextTID INT;

DECLARE @ControlText TABLE
(
  ID INT IDENTITY(1, 1) NOT NULL,
  ClassName VARCHAR(200),
  ControlName VARCHAR(200),
  TextDE VARCHAR(2000),
  TextFR VARCHAR(2000),
  TextTID INT
);

DECLARE @UpdateTextDE BIT;
DECLARE @UpdateTextFR BIT;
SET @UpdateTextDE = 0;
SET @UpdateTextFR = 1;


-- needs to start just at the same value as IDENTITY column on table
SELECT @EntriesIterator = ISNULL(MAX(ID), 0) + 1 
FROM @ControlText;

DELETE FROM @ControlText

;WITH ControlCTE (TextDE, TextFR, ClassName, ControlName)
AS
(
  SELECT 'Verarbeiten...', 'Traiter...', 'CtlPendenzenVerwaltung', 'btnBatchApply' UNION ALL
  SELECT 'Erfassung', 'Saisie', 'CtlErfassungMutation', 'lblErfassung' UNION ALL
  SELECT 'Mutation', 'Modification', 'CtlErfassungMutation', 'lblMutation' UNION ALL
  
  -- DlgGeheZu
  SELECT 'Abbruch', 'Annuler', 'DlgGeheZu', 'btnCancel' UNION ALL
  SELECT 'Gehe zu', 'Atteindre', 'DlgGeheZu', 'btnGeheZu' UNION ALL
  SELECT 'EZ oder ZL Nr.', 'EZ oder ZL Nr.', 'DlgGeheZu', 'lblEinzelzahlung' UNION ALL
  SELECT 'Fall-Nr.', 'No. de dossier', 'DlgGeheZu', 'lblFaLeistung' UNION ALL
  SELECT 'Direktsprung zu ...', 'Aller directement vers ...', 'DlgGeheZu', 'lblTitel' UNION ALL
  SELECT 'Sozialhilfe', 'Aide Sociale', 'DlgGeheZu', 'lblLeistung' UNION ALL
  SELECT 'Asyl', 'Asile', 'DlgGeheZu', 'lblAsyl' UNION ALL
  SELECT 'Fall Nr.', 'No. du cas', 'DlgGeheZu', 'lblFaLeistung' UNION ALL
  SELECT 'Finanzplan Nr.', 'No. plan financier', 'DlgGeheZu', 'lblFinanzplan' UNION ALL
  SELECT 'Finanzplan SIL', 'Plan financier SIL', 'DlgGeheZu', 'lblFinanzplanSIL' UNION ALL
  SELECT 'Fallführung', 'Gestion de cas', 'DlgGeheZu', 'lblLeistung' UNION ALL
  SELECT 'Sozialhilfe', 'Aide Soc.', 'DlgGeheZu', 'lblSozialhilfe' UNION ALL
  SELECT 'Direktsprung zu ...', 'Aller vers ...', 'DlgGeheZu', 'lblTitel'  UNION ALL
  SELECT 'Fall-Info','Info sur le cas', 'CtlPersonenStamm','btnFallInfo' UNION ALL
  SELECT 'in Bearbeitung','En traitement', 'DlgPendenzSelektionVerarbeiten','btnSetBearbeitung' UNION ALL
  SELECT 'Erledigt', 'Effectuée', 'DlgPendenzSelektionVerarbeiten', 'btnSetErledigt' UNION ALL
   SELECT 'Beschreibung','Description','CtlPendenzVorlagentexte','lblBeschreibung'  UNION ALL 
   SELECT 'Betreff','Concerne','CtlPendenzVorlagentexte','lblBetreff' UNION ALL 
   SELECT 'Code','Code','CtlPendenzVorlagentexte','lblCode' UNION ALL 
   SELECT 'Sortierung','Ordre','CtlPendenzVorlagentexte','lblSortKey' UNION ALL 
   SELECT 'Typ','Type','CtlPendenzVorlagentexte','lblTyp' UNION ALL
   SELECT 'Haben','Crédit','CtlFibuDauerauftrag','lblHaben' UNION ALL
   SELECT 'Soll','Débit','CtlFibuDauerauftrag','lblSoll' UNION ALL
   SELECT 'Mandant','Mandant','CtlFibuBuchungCode','label40' UNION ALL
   SELECT 'Soll','Débit','CtlFibuBuchungCode','label4' UNION ALL
   SELECT 'Haben','Crédit','CtlFibuBuchungCode','label5' UNION ALL
  SELECT 'Alle Kreditoren deaktivieren','Désactiver tous les créanciers','CtlFibuKreditor','btnAlleKreditorenDeaktivieren' UNION ALL
  SELECT '(um einen neuen Zahlungsweg zu erfassen/löschen: zuerst in diesen Bereich wechseln, zB. mit einem Mausklick, dann F5/F8)','(pour ajouter/supprimer un mode de paiement, veuillez d''abord basculer dans cette zone à l''aide par exemple d''un clique de souris puis F5/F8)','CtlFibuKreditor','kissLabel15' UNION ALL
  SELECT 'PLZ/Ort','NPA/localité','CtlFibuKreditor','kissLabel5' UNION ALL
  SELECT 'Aufwand Konto','Compte dépense','CtlFibuKreditor','kissLabel6' UNION ALL
  SELECT 'Zahlungsart','Mode de paiement','CtlFibuKreditor','kissLabel7' UNION ALL
  SELECT 'Aktiv','Actif','CtlFibuKreditor','kissLabel8' UNION ALL
  SELECT 'Name','Nom','CtlFibuKreditor','label1' UNION ALL
  SELECT 'PLZ/Ort','NPA/localité','CtlFibuKreditor','label3' UNION ALL
  SELECT 'Aktiv','Actif','CtlFibuKreditor','label4' UNION ALL
  SELECT 'Strasse','Rue','CtlFibuKreditor','label5' UNION ALL
  SELECT 'AufwandKonto','Compte dépense','CtlFibuKreditor','label6' UNION ALL
  SELECT 'Aktiv','Actif','CtlFibuKreditor','lblAktiv' UNION ALL
  SELECT 'Bank','Banque','CtlFibuKreditor','lblBank' UNION ALL
  SELECT 'BankKontoNr','No compte bancaire','CtlFibuKreditor','lblBankKontoNr' UNION ALL
  SELECT 'IBAN','IBAN','CtlFibuKreditor','lblIBAN' UNION ALL
  SELECT 'Name','Nom','CtlFibuKreditor','lblName' UNION ALL
  SELECT 'PostkontoNr','No Compte postal','CtlFibuKreditor','lblPostKontoNr' UNION ALL
  SELECT 'Stichtag letzte Buchung','Jour réf. dernière écriture','CtlFibuKreditor','lblStichtag' UNION ALL
  SELECT 'Strasse','Rue','CtlFibuKreditor','lblStrasse' UNION ALL
  SELECT 'Zahlungsfrist','Délai paiement','CtlFibuKreditor','lblZahlungsfrist' UNION ALL
  SELECT 'Zusatz','Complément','CtlFibuKreditor','lblZusatz' UNION ALL
  SELECT 'Suchen','Rechercher','CtlFibuKreditor','kissSearchTitel1' UNION ALL
  SELECT 'Aktiv','actif','CtlFibuKreditor','IsActive' UNION ALL
  SELECT 'Liste','Liste','CtlFibuKreditor','tpgListe' UNION ALL
  SELECT 'Suchen','Chercher','CtlFibuKreditor','tpgSuchen' UNION ALL
  SELECT 'Bankenstamm-History','Historique du répertoire des banques','CtlFibuBankPost','btnBankHistory' UNION ALL
  SELECT 'Bankenstamm aktualisieren','Actualiser le répertoire des banques','CtlFibuBankPost','btnUpdate' UNION ALL
  SELECT 'auch inaktive Banken auflisten','Lister également les banques inactives','CtlFibuBankPost','edtAuchInaktiveBanken' UNION ALL
  SELECT 'Name','Nom','CtlFibuBankPost','kissLabel1' UNION ALL  
  SELECT 'Strasse','Rue','CtlFibuBankPost','kissLabel10' UNION ALL
  SELECT 'Zusatz','Complément','CtlFibuBankPost','kissLabel11' UNION ALL
  SELECT 'Name','Nom','CtlFibuBankPost','kissLabel12' UNION ALL
  SELECT 'Zusatz','Complément','CtlFibuBankPost','kissLabel2' UNION ALL
  SELECT 'Strasse','Rue','CtlFibuBankPost','kissLabel3' UNION ALL
  SELECT 'Plz/Ort','NPA/localité','CtlFibuBankPost','kissLabel4' UNION ALL
  SELECT 'Clearing Nr','No Clearing','CtlFibuBankPost','kissLabel5' UNION ALL
  SELECT 'Postkonto Nr','No compte postal','CtlFibuBankPost','kissLabel6' UNION ALL
  SELECT 'Postkonto Nr','No compte postal','CtlFibuBankPost','kissLabel7' UNION ALL
  SELECT 'Clearing Nr','No Clearing','CtlFibuBankPost','kissLabel8' UNION ALL
  SELECT 'Plz/Ort','NPA/localité','CtlFibuBankPost','kissLabel9' UNION ALL
  SELECT 'Suchen','Recherche','CtlFibuBankPost','kissSearchTitel1' UNION ALL
  SELECT 'neue Clearing Nr','Nouveau numéro de clearning','CtlFibuBankPost','lblClearingNrNeu' UNION ALL
  SELECT 'Filiale Nr','No filiale','CtlFibuBankPost','lblFilialeNr' UNION ALL
  SELECT 'Liste','Liste','CtlFibuBankPost','tpgListe' UNION ALL
  SELECT 'Suchen','Recherche','CtlFibuBankPost','tpgSuchen' UNION ALL
  SELECT 'letzte Aktualisierung am','Dernière mise à jour le','CtlFibuBankPost','lblLastUpdate' UNION ALL
  SELECT 'letzte Aktualisierung am','Dernière mise à jour le','DlgBankenabgleich','lblLastUpdate' UNION ALL
  SELECT 'Soll','Débit','CtlKbBuchung','lblSoll' UNION ALL
  SELECT 'Haben','Crédit','CtlKbBuchung','lblHaben' UNION ALL
  SELECT 'Name','Nom','CtlPersonenStamm','lblSucheName' UNION ALL
  SELECT 'Vorname','Prénom','CtlPersonenStamm','lblSucheVorname' UNION ALL
  SELECT 'Strasse','Rue','CtlPersonenStamm','lblSucheStrasse' UNION ALL
  SELECT 'PLZ / Ort','NPA / loc.','CtlPersonenStamm','lblSuchePlzOrt' UNION ALL
  SELECT 'nur Fallträger','Seulement le porteur du cas','CtlPersonenStamm','edtFT'  UNION ALL
  SELECT 'nur mit Serienbrief','Seulement avec publipostage', 'CtlPersonenStamm', 'edtSucheKeinSerienbrief'  UNION ALL
  SELECT 'Personen-Nr','No de personne', 'CtlPersonenStamm', 'lblSucheBaPersonID'  UNION ALL
  SELECT 'Geburt','Naissance', 'CtlPersonenStamm','lblSucheGeburtsdatum'  UNION ALL
  SELECT 'Nationalität','Nationalité', 'CtlPersonenStamm','lblSucheNationalitaet'  UNION ALL
  SELECT 'AHV- Nr.','No. AVS','CtlPersonenStamm', 'lblSucheAHVNummer' UNION ALL
  SELECT 'Vers.-Nr.','No. Vers.','CtlPersonenStamm','lblVersNr' UNION ALL
  SELECT 'Anzahl Datensätze:','Nb enregistr.:','CtlPersonenStamm','lblAnzahlDatensaetze' UNION ALL
  SELECT 'Soll','Débit','CtlFibuDauerauftrag','lblSuchenSoll' UNION ALL
  SELECT 'Haben','Crédit','CtlFibuDauerauftrag','lblSuchenHaben'
  
     
   


--SELECT 'TextDE', 'TextFR', 'ClassName', 'ControlName' UNION ALL
)
-- insert entries into temp table
INSERT INTO @ControlText
 SELECT 
   CTE.ClassName, 
   CTE.ControlName,
   CTE.TextDE, 
   CTE.TextFR,
   CTL.ControlTID
 FROM ControlCTE CTE
   LEFT JOIN dbo.XClassControl CTL ON CTL.ClassName = CTE.ClassName AND CTL.ControlName = CTE.ControlName

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!

-- loop all entries
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @ClassName   = TMP.ClassName,
         @ControlName = TMP.ControlName,
         @TextDE      = TMP.TextDE,
         @TextFR      = TMP.TextFR,
         @TextTID     = TMP.TextTID
  FROM @ControlText TMP
  WHERE TMP.ID = @EntriesIterator;
  
  -----------------------------------------------------------------------------
  -- translate
  IF (@TextFR = '' OR @TextFR IS NULL)
  BEGIN
    PRINT ('Info: TextFR ist leer, wurde nicht übersetzt bei ' + @ClassName + ' - ' + @ControlName);
  END
  ELSE
  BEGIN
    EXEC dbo.spXSetXLangText @TextTID, 1, @TextDE, NULL, NULL, NULL, NULL, @TextTID OUT
    EXEC dbo.spXSetXLangText @TextTID, 2, @TextFR, NULL, NULL, NULL, NULL, @TextTID OUT

    UPDATE dbo.XClassControl
      SET ControlTID = @TextTID
    WHERE ClassName = @ClassName
      AND ControlName = @ControlName
  END;
  -----------------------------------------------------------------------------
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;
GO


-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
