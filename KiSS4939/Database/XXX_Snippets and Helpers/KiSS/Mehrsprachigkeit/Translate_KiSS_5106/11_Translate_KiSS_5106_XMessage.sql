/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: XMessage übersetzen
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO



-------------------------------------------------------------------------------
-- Step 1: XMessage
-------------------------------------------------------------------------------

DECLARE @MaskName VARCHAR(100),
        @MessageName VARCHAR(100),
        @MessageDE VARCHAR(2000),
        @MessageFR VARCHAR(2000),
        @MessageCode INT, -- MsgInfo = 1,MsgError = 2,MsgQuestion = 3,Text = 4
        @MessageTID INT,
        @HasEntryAlready INT;

DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;

DECLARE @MessageTmp TABLE
(
  ID INT IDENTITY(1, 1) NOT NULL,
  MaskName VARCHAR(100),
  MessageName VARCHAR(100),
  MessageDE VARCHAR(2000),
  MessageFR VARCHAR(2000),
  MessageCode INT,
  MessageTID INT,
  HasEntryAlready BIT
);

;WITH MessageCTE (MaskName, MessageName, MessageDE, MessageFR, MessageCode)
AS
(
  SELECT 'CtlFibuZahlungsWeg', 'Postkonto', 'Postkonto', 'Compte postal',4 UNION ALL
  SELECT 'CtlFibuZahlungsWeg', 'PostkontoDerBank', 'Postkonto der Bank', 'Compte postal de la banque',4 UNION ALL
  SELECT 'CtlFibuZahlungsWeg', 'Bankkonto', 'Bankkonto', 'Compte bancaire',4 UNION ALL
  SELECT 'CtlFibuZahlungsWeg', 'BankkontoNr', 'Bankkonto Nr', 'No compte bancaire',4  UNION ALL
  SELECT 'CtlFibuZahlungsWeg', 'FolgendeFelderimZahlunswegveraendert',
                                 'Folgende Felder wurden im Zahlungsweg verändert :', 
                                    'Les champs suivants ont été modifiés dans le moyen de paiement:', 
                                      4 UNION ALL
  SELECT 'CtlFibuZahlungsWeg', 'AenderungenaufdenZahlungswegstamm',
                                 'Möchten Sie die Änderungen auf den Zahlungswegstamm übernehmen ?', 
                                    'Voulez-vous apporter des modifications dans le répertoire des moyens de paiement?', 
                                      4 UNION ALL
  SELECT 'CtlFibuZahlungsWeg', 'KontoNrKreditorIBAN',
                                 'KontoNr/Kreditor/IBAN', 
                                    'NCompt/Créan/IBAN', 
                                      4 UNION ALL
  SELECT 'CtlFibuDTAZugang', 'Post','Post','Poste', 4 UNION ALL
  SELECT 'CtlFibuDTAZugang', 'Bank','Bank','Banque', 4 UNION ALL
  SELECT 'CtlFibuKreditor', 
          'AlleKreditorenDeaktivieren',
            'Alle angezeigten Kreditoren werden deaktiviert.\r\nDiese Aktion kann nicht rückgängig gemacht werden.\r\nSind Sie sicher, dass Sie weiterfahren möchten?',
              'Attention! Tous les créanciers affichés seront désactivés.\r\nCette opération est irréversible.\r\nVoulez-vous continuer?',
                3 UNION ALL
  SELECT 'CtlFibuKreditor', 
          'DatenGehenVerloren',
            'Existierende Daten werden verloren wenn Sie die Zahlungsart ändern\r\n\r\nWollen Sie es trotzdem ändern',
              'Des données seront supprimées si vous modifiez le mode de paiement.\r\n\r\nVoulez-vous tout de même effectuer ces modifications?',
                3 UNION ALL
  SELECT 'CtlFibuKreditor', 
           'NonMatchingIBANWithPrevious',
              'Generierte IBAN {0} stimmt nicht mit bisheriger ({1}) überein. Löschen Sie die bestehende IBAN oder korrigieren Sie die Kontonummer / Clearingnummer.',
                'L''IBAN généré {0} ne correspond pas à l''actuel {1}. Supprimez l''IBAN actuel, ou, corrigez le numéro de compte/numéro de clearing.',
                  4 UNION ALL
  SELECT 'CtlFibuBankPost', 
            'LetzteAktualisierungAm',  
              'letzte Aktualisierung am',
                'Dernière mise à jour le',
                  4 UNION ALL
  SELECT 'DlgBankenabgleich', 
            'LetzteAktualisierungAm',  
              'letzte Aktualisierung am',
                'Dernière mise à jour le',
                  4 UNION ALL
  -- MaskName=spFnName, MessageName=TextName, MessageDE, MessageFR, MessageCode
  SELECT 'spFbGetBilanzErfolg', 'Aktiven', 'Aktiven', 'Actifs',  4 UNION ALL
  SELECT 'spFbGetBilanzErfolg', 'Passiven', 'Passiven', 'Passifs',  4 UNION ALL
  SELECT 'spFbGetBilanzErfolg', 'TotalAktiven', 'Total Aktiven', 'Total actifs' ,  4 UNION ALL
  SELECT 'spFbGetBilanzErfolg', 'TotalPassiven',  'Total Passiven','Total passifs',  4 UNION ALL
  SELECT 'spFbGetBilanzErfolg', 'Vermoegenszunahme',  'Vermögenszunahme','Augmentation de fortune',  4 UNION ALL
  SELECT 'spFbGetBilanzErfolg', 'Vermoegensabnahme', 'Vermögensabnahme' ,'Diminution de fortune', 4  UNION ALL
  SELECT 'spFbGetBilanzErfolg', 'Aufwand','Aufwand','Charge', 4  UNION ALL
  SELECT 'spFbGetBilanzErfolg', 'Ertrag','Ertrag','Produit', 4  UNION ALL
  SELECT 'spFbGetBilanzErfolg', 'TotalAufwand','Total Aufwand','Total Charge', 4 UNION ALL
  SELECT 'spFbGetBilanzErfolg', 'TotalErtrag','Total Ertrag','Total des produits', 4 UNION ALL
  SELECT 'spFbGetBilanzErfolg', 'Saldogruppen','Saldogruppen','Grouppes de solde', 4 UNION ALL
  SELECT 'spFbGetBilanzErfolg', 'TotalSaldoGruppen','Total SaldoGruppen','Total groupes de solde', 4 UNION ALL
  SELECT 'spFbGetBilanzErfolg', 'Total','Total','Total', 4 
)

-- insert entries into temp table
INSERT INTO @MessageTmp
 SELECT 
   CTE.MaskName, 
   CTE.MessageName,
   CTE.MessageDE, 
   CTE.MessageFR,
   CTE.MessageCode,
   CTL.MessageTID,
   CASE WHEN CTL.MaskName IS NULL THEN 0 ELSE 1 END -- HasEntryAlready
 FROM MessageCTE CTE
   LEFT JOIN dbo.XMessage CTL ON CTL.MessageName = CTE.MessageName 
                             AND CTL.MaskName = CTE.MaskName

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

-- loop all entries
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @MaskName         = TMP.MaskName,
         @MessageName      = TMP.MessageName,
         @MessageDE        = TMP.MessageDE,
         @MessageFR        = TMP.MessageFR,
         @MessageCode      = TMP.MessageCode,
         @MessageTID       = TMP.MessageTID,
         @HasEntryAlready  = TMP.HasEntryAlready
  FROM @MessageTmp TMP
  WHERE TMP.ID = @EntriesIterator;
  
  -----------------------------------------------------------------------------
  -- translate
  IF (@MessageFR = '' OR @MessageFR IS NULL)
  BEGIN
    PRINT ('Info: MessageFR ist leer, wurde nicht übersetzt bei ' + @MaskName + ' - ' + @MessageName);
  END
  ELSE
  BEGIN

    EXEC spXSetXLangText @MessageTID, 1, @MessageDE, NULL,NULL,NULL,NULL,@MessageTID OUT;
    EXEC spXSetXLangText @MessageTID, 2, @MessageFR, NULL,NULL,NULL,NULL,@MessageTID OUT;
    
    IF @HasEntryAlready = 1
    BEGIN
    
      UPDATE dbo.XMessage
      SET MessageTID = @MessageTID
      WHERE MaskName = @MaskName
        AND MessageName = @MessageName;
        
      PRINT 'XMessage MaskName=' + @MaskName + ' MessageName=' + @MessageName + ' - Übersetzung aktualisiert';
    
    END
    ELSE
    BEGIN
    
      INSERT INTO dbo.XMessage
              (MaskName,
               MessageName,
               MessageTID,
               MessageCode)
      SELECT @MaskName,
             @MessageName,
             @MessageTID,
             @MessageCode;
             
      PRINT 'XMessage MaskName=' + @MaskName + ' MessageName=' + @MessageName + ' - Neuer Eintrag mit MessageTID';             
    
    END
          
    
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


