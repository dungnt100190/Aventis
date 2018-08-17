/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to translate entries in the Table XConfig
=================================================================================================*/
-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

PRINT 'Übersetzung in der Tabelle XConfig'

DECLARE @keyPathTID INT;
DECLARE @keyPathDE VARCHAR(500);
DECLARE @keyPathFR VARCHAR(500);
DECLARE @keyPath VARCHAR(500);
DECLARE @descriptionTID INT;
DECLARE @descriptionDE VARCHAR(1000);
DECLARE @descriptionFR VARCHAR(1000);
DECLARE @xConfigID INT;

DECLARE @XConfigTmp TABLE
(
  ID INT IDENTITY(1, 1) NOT NULL,
  KeyPathTID INT,
  KeyPathDE VARCHAR(500),
  KeyPathFR VARCHAR(500),
  KeyPath VARCHAR(500),
  DescriptionTID INT,
  DescriptionDE VARCHAR(1000),
  DescriptionFR VARCHAR(1000),
  XConfigID INT
);

DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;

-- Fill the list of items to be translated here
;WITH XConfigCTE (KeyPathDE, KeyPathFR, KeyPath, DescriptionDE,  DescriptionFR)
AS
(
SELECT           'System\Pendenzen\KesFrist\AuftragsAbklaerungsErledigung\Aktiv',
                    'Système\Tâches\DélaisPEA\DemandeClarificationEffectuer\Actif',
                      'System\Pendenzen\KesFrist\AuftragsAbklaerungsErledigung\Aktiv',
                        'Wenn Wahr wird eine Kes-Pendenz zur Abklärung/Aufträge Erledigung erstellt sobald ein Versand-Dokument eingefügt wird.',
                          'Si activé, une tâche PEA sera générée pour effectuer une demande/clarification lorsqu''un document sera saisi dans le champ envoi.'
UNION ALL SELECT 'System\Pendenzen\KesFrist\AuftragsAbklaerungsErledigung\AnzahlTage',
                    'Système\Tâches\DélaisPEA\DemandeClarificationEffectuer\Nombredejours',                
                      'System\Pendenzen\KesFrist\AuftragsAbklaerungsErledigung\AnzahlTage',
                        'AnzahlTage vor dem Erreichen der Kes-Frist zur Abklärung/Aufträge Erledigung.',
                          'Délai en jour pour effectuer la demande/clarification.'
UNION ALL SELECT 'System\Pendenzen\KesFrist\ErledigungSD\Aktiv',
                   'Système\Tâches\DélaisPEA\Effectuéparleservicesocial\Actif',
                     'System\Pendenzen\KesFrist\ErledigungSD\Aktiv',
                        'Wenn Wahr wird eine Kes-Pendenz zur Abklärung/Aufträge Erledigung SD erstellt sobald ein Frist-Datum muss gesetzt wird.',
                          'Si activé, une tâche PEA sera générée pour effectuer la demande/clarification par le service social si une date de délai doit être saisie.'
UNION ALL SELECT 'System\Pendenzen\KesFrist\MassnahmeAuftragVersandBericht\Aktiv',
                    'Système\Tâches\DélaisPEA\MesureDemandeEnvoiRapport\Actif',
                      'System\Pendenzen\KesFrist\MassnahmeAuftragVersandBericht\Aktiv',
                        'Wenn Wahr wird eine Kes-Pendenz in der Massnahme Aufträge/Anträge erstellt sobald ein Versand-Dokument eingefügt wird.',
                          'Si activé, une tâche PEA sera générée pour la mesure dans mandats/demandes dès qu''un document sera saisi dans le champ envoi.'
UNION ALL SELECT 'System\Pendenzen\KesFrist\MassnahmeAuftragVersandBericht\AnzahlTage',
                    'Système\Tâches\DélaisPEA\MesureDemandeEnvoiRapport\Nombredejours',
                      'System\Pendenzen\KesFrist\MassnahmeAuftragVersandBericht\AnzahlTage',
                        'AnzahlTage vor dem Erreichen der Kes-Frist zur Massnahme Aufträge/Anträge.',
                          'Nombre de jour pour le délai des mandats/demandes dans la mesure.'
UNION ALL SELECT 'System\Pendenzen\KesFrist\MassnahmePeriode\Aktiv',
                    'Système\Tâches\DélaisPEA\MesurePériode\Actif',
                      'System\Pendenzen\KesFrist\MassnahmePeriode\Aktiv',
                        'Wenn Wahr wird eine Kes-Pendenz in der Massnahme zum Register Berichts- und Rechnunsablage erstellt sobald ein Datum Periode Bis eingefügt wird.',
                          'Si activé, une tâche PEA dans l''onglet ''Rapports d''activités et comptes'' sera générée lorsqu''une date ''à faire jusqu''au'' sera saisie.'
UNION ALL SELECT 'System\Pendenzen\KesFrist\MassnahmeVersandBericht\Aktiv',
                    'Système\Tâches\DélaisPEA\MesureRapportdactiviteEnvoiRapport\Actif',
                      'System\Pendenzen\KesFrist\MassnahmeVersandBericht\Aktiv',
                        'Wenn Wahr wird eine Kes-Pendenz in der Massnahme Berichts- und Rechnungsablage erstellt sobald ein Versand-Dokument eingefügt wird.',
                          'Si activé, une tâche PEA pour la mesure dans rapport d''activité et comptes sera générée lorsqu''un document sera inséré dans le champ envoi.'
UNION ALL SELECT 'System\Pendenzen\KesFrist\MassnahmeVersandBericht\AnzahlTage',
                   'Système\Tâches\DélaisPEA\MesureRapportdactiviteEnvoiRapport\Nombredejours',
                      'System\Pendenzen\KesFrist\MassnahmeVersandBericht\AnzahlTage',
                        'AnzahlTage vor dem Erreichen der Kes-Frist zur Massnahme Berichts- und Rechnungsablage.',
                          'Nombre de jour pour le délai pour une mesure dans rapport d''activité et comptes pour un rapport dans envoi.'
UNION ALL SELECT 'System\Fibu\SaldoGruppeName\KassePc',
                   'Système\Cofi\Nomdugroupedesolde\CaisseCP',
                     'System\Fibu\SaldoGruppeName\KassePc',                       
                         'Name der "Kasse + PC" Saldogruppe',
                           'Nom du groupe de solde "Caisse PC"'
UNION ALL SELECT 'System\Fibu\SaldoGruppeName\Betriebskonto',
                   'Système\Cofi\Nomdugroupedesolde\CompteCourant',
                     'System\Fibu\SaldoGruppeName\Betriebskonto',                       
                         'Name der "Betriebskonto" Saldogruppe',
                           'Nom du groupe de solde compte courant"'
UNION ALL SELECT 'System\Fibu\SaldoGruppeName\DepotBs',
                   'Système\Cofi\Nomdugroupedesolde\DepotBs',
                     'System\Fibu\SaldoGruppeName\DepotBs',                       
                         'Name der "Depot BS" Saldogruppe',
                           'Nom du groupe de solde dépot Bs'


                           

)


-- insert entries into temp table
INSERT INTO @XConfigTmp
 SELECT 
   ITY.KeyPathTID,
   CTE.KeyPathDE, 
   CTE.KeyPathFR,
   CTE.KeyPath, 
   ITY.DescriptionTID,
   CTE.DescriptionDE, 
   CTE.DescriptionFR, 
   ITY.XConfigID
 FROM XConfigCTE CTE
   LEFT JOIN dbo.XConfig ITY ON ITY.KeyPath = CTE.KeyPath


-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

-- loop all entries
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN

  -- get current entry
  SELECT @keyPathTID       = TMP.KeyPathTID,
         @keyPathDE        = TMP.KeyPathDE,
         @keyPathFR        = TMP.KeyPathFR,
         @keyPath          = TMP.KeyPath,
         @descriptionTID   = TMP.DescriptionTID,
         @descriptionDE    = TMP.DescriptionDE,
         @descriptionFR    = TMP.DescriptionFR,
         @xConfigID        = TMP.XConfigID
  FROM @XConfigTmp TMP
  WHERE TMP.ID = @EntriesIterator;
  
  IF @xConfigID IS NULL 
  BEGIN
    PRINT 'Für XConfig.KeyPath=' + @keyPathDE + ' konnte das xConfigID nicht gefunden werden. Die Texten konnten dann nicht aktualisiert werden.'
  END
  ELSE
  BEGIN

    EXEC spXSetXLangText @keyPathTID, 1, @keyPathDE, NULL,NULL,NULL,NULL,@keyPathTID OUT;
    EXEC spXSetXLangText @keyPathTID, 2, @keyPathFR, NULL,NULL,NULL,NULL,@keyPathTID OUT;
    
    EXEC spXSetXLangText @descriptionTID, 1, @descriptionDE, NULL,NULL,NULL,NULL,@descriptionTID OUT;
    EXEC spXSetXLangText @descriptionTID, 2, @descriptionFR, NULL,NULL,NULL,NULL,@descriptionTID OUT;  

    UPDATE dbo.XConfig 
    SET KeyPathTID = @keyPathTID,
        DescriptionTID = @descriptionTID
    WHERE KeyPath = @keyPath
      AND XConfigID = @xConfigID;    
    
    PRINT ' XConfigID=' + CONVERT(VARCHAR(MAX),@xConfigID) + ' aktualisiert - ' + 'KeyPath=' + @keyPath + ' Description=' + @descriptionDE;
    
  END;
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;
  

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO