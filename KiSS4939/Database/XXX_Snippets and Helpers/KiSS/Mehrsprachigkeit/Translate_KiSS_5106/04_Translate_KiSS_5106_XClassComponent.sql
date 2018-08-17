/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: XClassComponent übersetzen
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- Step 1: XClassComponent
-------------------------------------------------------------------------------
DECLARE @TID INT;
DECLARE @Text VARCHAR(2000);
DECLARE @ClassName VARCHAR(255);
DECLARE @ComponentName VARCHAR(200);

DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @TextDE VARCHAR(2000);
DECLARE @TextFR VARCHAR(2000);
DECLARE @TextTID INT;

DECLARE @ComponentText TABLE
(
  ID INT IDENTITY(1, 1) NOT NULL,
  ClassName VARCHAR(200),
  ComponentName VARCHAR(200),
  TextDE VARCHAR(2000),
  TextFR VARCHAR(2000),
  TextTID INT
);

;WITH ComponentCTE (TextDE, TextFR, ClassName, ComponentName)
AS
(
  SELECT 'Fallinfo', 'Info sur le cas', 'CtlIkModulTree', 'btnFallInfo' UNION ALL
  SELECT 'Fallzugriff', 'Accès au cas', 'CtlIkModulTree', 'btnFallZugriff' UNION ALL
  SELECT 'Fallzuteilung', 'Attribution des cas', 'CtlIkModulTree', 'btnFallZuteilung' UNION ALL
  SELECT 'Neue Abklärung', 'Nouvelle clarification', 'CtlIkModulTree', 'btnNeueAbklaerung' UNION ALL
  SELECT 'Neues Alimentinkasso', 'Nouvelle pension alimentaire', 'CtlIkModulTree', 'btnNeuesAlimentinkasso' UNION ALL
  SELECT 'Neuer Elternbeitrag', 'Nouvelle contribution parentale', 'CtlIkModulTree', 'btnNeuerElternbeitrag' UNION ALL
  SELECT 'Neue Rückerstattung', 'Nouveau remboursement', 'CtlIkModulTree', 'btnNeueRueckerstattung' UNION ALL
  SELECT 'Neue Rückerstattung POM', 'Nouveau remboursement exigé', 'CtlIkModulTree', 'btnNeueRueckerstattungPOM' UNION ALL
  SELECT 'Neuer Verwandtenbeitrag', 'Nouvelle contribution aux personnes apparentées', 'CtlIkModulTree', 'btnNeuerVerwandtenbeitrag' UNION ALL
  SELECT 'Neuer Nachlass', 'Nouvelle remise', 'CtlIkModulTree', 'btnNeuerNachlass' UNION ALL
  SELECT 'FT','Cl','CtlPersonenStamm', 'colFT' UNION ALL 
  SELECT 'Nr','No.','CtlPersonenStamm','colNr'  UNION ALL 
  SELECT 'Name','Nom','CtlPersonenStamm','colName'   UNION ALL 
  SELECT 'Vorname','Prénom','CtlPersonenStamm','colVorname'  UNION ALL 
  SELECT 'Strasse','Adresse','CtlPersonenStamm','colStrasse'  UNION ALL
  SELECT 'Ort','Localité','CtlPersonenStamm','colOrt'  UNION ALL 
  SELECT 'm/w','m/f','CtlPersonenStamm','colGeschlecht'  UNION ALL 
  SELECT 'Alter','Age','CtlPersonenStamm','colAlter'  UNION ALL 
  SELECT 'Geburt','Naissance','CtlPersonenStamm','colGeburtsdatum'  UNION ALL 
  SELECT 'Nationalität','Nationalité','CtlPersonenStamm','colNationalitaet'  UNION ALL 
  SELECT 'AHV-Nr.','No.AVS','CtlPersonenStamm','colAHVNr' UNION ALL 
  SELECT 'Vers.-Nr.','No. d''assuré','CtlPersonenStamm','colVersNr' UNION ALL 
  SELECT 'Code', 'Code', 'CtlPendenzVorlagentexte', 'colCode' UNION ALL
  SELECT 'Typ', 'Type', 'CtlPendenzVorlagentexte', 'colTyp' UNION ALL
  SELECT 'Betreff', 'Concerne', 'CtlPendenzVorlagentexte', 'colBetreff' UNION ALL
  SELECT 'Beschreibung', 'Description', 'CtlPendenzVorlagentexte', 'colBeschreibung' UNION ALL
  SELECT 'Sortierung', 'Ordre', 'CtlPendenzVorlagentexte', 'colSortKey' UNION ALL
  SELECT 'Soll', 'Débit', 'CtlFibuDauerauftrag', 'colListeSoll' UNION ALL
  SELECT 'Haben', 'Crédit', 'CtlFibuDauerauftrag', 'colListeHaben' UNION ALL
  SELECT 'Haben','Crédit','CtlFibuBuchungCode','colKtoHabenNr'  UNION ALL
  SELECT 'Soll','Débit', 'CtlFibuBuchungCode','colKtoSollNr'  UNION ALL
  SELECT 'Mandant','Mandant', 'CtlFibuBuchungCode','colMandant' UNION ALL  
  SELECT 'Aktiv','Actif', 'CtlFibuKreditor','colAktiv' UNION ALL
  SELECT 'Aktiv','Actif', 'CtlFibuKreditor','colAktiv2' UNION ALL
  SELECT 'AufwandKonto','Compte de dépenses', 'CtlFibuKreditor','colAufwandKonto' UNION ALL
  SELECT 'Bank-KtoNr.','No-Cte-bancaire', 'CtlFibuKreditor','colBankKtoNr' UNION ALL
  SELECT 'Finanzinstitut','Institut financier', 'CtlFibuKreditor','colFinanziellinstitution' UNION ALL
  SELECT 'Letzte Buchung','Dernière écriture', 'CtlFibuKreditor','colLetzteBuchung' UNION ALL
  SELECT 'Name','Nom', 'CtlFibuKreditor','colName' UNION ALL
  SELECT 'Ort','Localité', 'CtlFibuKreditor','colOrt' UNION ALL
  SELECT 'PC-KtoNr','NCpt-CP','CtlFibuKreditor','colPCKtoNr' UNION ALL
  SELECT 'PLZ','NPA','CtlFibuKreditor','colPLZ' UNION ALL
  SELECT 'ZahlungsArt','Mode de paiement','CtlFibuKreditor','colZahlungsArt' UNION ALL
  SELECT 'Clearing Nr','No de Clearing','CtlFibuBankPost','colClearingNr' UNION ALL
  SELECT 'neue Clearing Nr','Nouveau no Clearing','CtlFibuBankPost','colClearingNrNeu' UNION ALL
  SELECT 'Filiale Nr','No filiale','CtlFibuBankPost','colFilialeNr' UNION ALL
  SELECT 'Name','Nom','CtlFibuBankPost','colName' UNION ALL
  SELECT 'Ort','Localité','CtlFibuBankPost','colOrt' UNION ALL
  SELECT 'PostKonto Nr','No compte postale','CtlFibuBankPost','colPcKontoNr' UNION ALL
  SELECT 'PLZ','NPA','CtlFibuBankPost','colPLZ' UNION ALL
  SELECT 'SicUpdated','SicUpdated','CtlFibuBankPost','colSicUpdated' UNION ALL
  SELECT 'Strasse','Rue','CtlFibuBankPost','colStrasse' UNION ALL
  SELECT 'Mandatsträger','Mandataire', 'DlgAuswahl', 'MTName' UNION ALL
  SELECT 'Benutzer','Utilistaeur','DlgAuswahl','UserID' UNION ALL
  SELECT 'Login','Login','DlgAuswahl','MTLogon' UNION ALL
  SELECT 'Manant','Mandant','DlgAuswahl','Mandant' UNION ALL
  SELECT 'PLZOrt','NPALocalité','DlgAuswahl','PLZOrt' UNION ALL
  SELECT 'Nr.','No.','DlgAuswahl','BaPersonID' UNION ALL
  SELECT 'LogonName','Identification','DlgAuswahl','LogonName' UNION ALL
  SELECT 'SollKtoNr','NoCompteDébit','DlgAuswahl','SollKtoNr' UNION ALL
  SELECT 'SollKtoName','NomCompteDébit','DlgAuswahl','SollKtoName' UNION ALL
  SELECT 'KontoNr','No compte','DlgAuswahl','KontoNr' UNION ALL
  SELECT 'KontoName','Nom de compte','DlgAuswahl','KontoName' UNION ALL
  SELECT 'ClearingNr','No Clearing','DlgBankenabgleich','colClearingNr' UNION ALL
  SELECT 'ClearingNr neu','Clearing nouveau no','DlgBankenabgleich','colClearingNrNeu' UNION ALL
  SELECT 'Datum','Date','DlgBankenabgleich','colDatum' UNION ALL
  SELECT 'Filiale Nr','No Filiale','DlgBankenabgleich','colFilialeNr' UNION ALL
  SELECT 'Gültig ab','Valable dès le','DlgBankenabgleich','colGueltigAb' UNION ALL
  SELECT 'Hauptsitz BCL','Siège principal BCL','DlgBankenabgleich','colHauptsitzBCL' UNION ALL
  SELECT 'Land','Pays','DlgBankenabgleich','colLandCode' UNION ALL
  SELECT 'Name','Nom','DlgBankenabgleich','colName' UNION ALL
  SELECT 'Ort','Localité','DlgBankenabgleich','colOrt' UNION ALL
  SELECT 'Pc Konto Nr','No compte postal','DlgBankenabgleich','colPcKontoNr' UNION ALL
  SELECT 'PLZ','NPA','DlgBankenabgleich','colPLZ' UNION ALL
  SELECT 'Strasse','Rue','DlgBankenabgleich','colStrasse' UNION ALL
  SELECT 'Zusatz','Complément','DlgBankenabgleich','colZusatz' UNION ALL
  SELECT 'Saldogruppe','Groupe de solde','CtlFibuKonto','colSaldoGruppeName' UNION ALL
  SELECT 'Kto-Nr.','No.Cpte','CtlFibuBilanzErfolg', 'colKtoNr'

  
)

-- insert entries into temp table
INSERT INTO @ComponentText
 SELECT 
   CTE.ClassName, 
   CTE.ComponentName,
   CTE.TextDE, 
   CTE.TextFR,
   CTL.ComponentTID
 FROM ComponentCTE CTE
   LEFT JOIN dbo.XClassComponent CTL ON CTL.ClassName = CTE.ClassName AND CTL.ComponentName = CTE.ComponentName

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

-- loop all entries
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @ClassName     = TMP.ClassName,
         @ComponentName = TMP.ComponentName,
         @TextDE        = TMP.TextDE,
         @TextFR        = TMP.TextFR,
         @TextTID       = TMP.TextTID
  FROM @ComponentText TMP
  WHERE TMP.ID = @EntriesIterator;
  
  -----------------------------------------------------------------------------
  -- translate
  IF (@TextFR = '' OR @TextFR IS NULL)
  BEGIN
    PRINT ('Info: TextFR ist leer, wurde nicht übersetzt bei ' + @ClassName + ' - ' + @ComponentName);
  END
  ELSE
  BEGIN
    EXEC dbo.spXSetXLangText @TextTID, 1, @TextDE, NULL, NULL, NULL, NULL, @TextTID OUT
    EXEC dbo.spXSetXLangText @TextTID, 2, @TextFR, NULL, NULL, NULL, NULL, @TextTID OUT

    UPDATE dbo.XClassComponent
      SET ComponentTID = @TextTID
    WHERE ClassName = @ClassName
      AND ComponentName = @ComponentName
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
