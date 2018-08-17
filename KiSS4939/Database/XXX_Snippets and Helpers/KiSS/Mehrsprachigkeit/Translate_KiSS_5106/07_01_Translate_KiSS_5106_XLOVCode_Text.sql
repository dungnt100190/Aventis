/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to translate the Fiel XLOVCode.Text
  
=================================================================================================*/

/*
SELECT LOVName, Code, LOC.Text, TextDE = LAND.Text, TextFR = LANF.Text,
  s = '   UNION ALL SELECT ''' + LOVName + ''', ' + CONVERT(VARCHAR(MAX), Code) + ', ''' + ISNULL(LAND.Text, LOC.Text) + ''', ''' + ISNULL(LANF.Text, 'TextFR') + ''''
  , *
FROM dbo.XLOVCode LOC WITH (READUNCOMMITTED)
  LEFT JOIN dbo.XLangText LAND WITH (READUNCOMMITTED) ON LAND.TID = LOC.TextTID AND LAND.LanguageCode = 1
  LEFT JOIN dbo.XLangText LANF WITH (READUNCOMMITTED) ON LANF.TID = LOC.TextTID AND LANF.LanguageCode = 2
WHERE LOVName = 'baadresstyp'
*/


-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO


DECLARE @textTID INT;
DECLARE @textDE VARCHAR(2000);
DECLARE @textFR VARCHAR(2000);
DECLARE @code INT;
DECLARE @lovName VARCHAR(255);
DECLARE @isWithUpdateXLOVCodeTextFR BIT;

DECLARE @LOVText TABLE
(
  ID INT IDENTITY(1, 1) NOT NULL,
  TextTID INT,
  LOVName VARCHAR(255),
  Code INT,
  TextDE VARCHAR(2000),
  TextFR VARCHAR(2000),
  IsWithUpdateXLOVCodeTextFR BIT
);

DECLARE @EntriesIterator INT;
DECLARE @EntriesCount INT;

-- Fill the list of items to be translated here
;WITH LOVTextCTE (LOVName, Code, TextDE, TextFR, IsWithUpdateXLOVCodeTextFR)
AS
(
             SELECT 'WhHilfeTyp', 1, 'Überbrückungshilfe', 'Contribution transitoire',0
   UNION ALL SELECT 'WhHilfeTyp', 2, 'Regulärer Finanzplan' , 'Plan financier ordinaire',0
   UNION ALL SELECT 'WhHilfeTyp', 3, 'Admin. Fallführung', 'Suivi admin. de cas',0
   UNION ALL SELECT 'BaAdresstyp', 1, 'Wohn-/Meldeadresse', 'Adresse de domicile',0
   UNION ALL SELECT 'BaAdresstyp', 3, 'Aufenthaltsadresse', 'Adresse de séjour',0
   UNION ALL SELECT 'BaAdresstyp', 8, 'Korrespondenzadresse', 'Adresse de correspondance',0
   UNION ALL SELECT 'BaAdresstyp', 13, 'Stationäre Aufenthaltsadresse', 'Adresse de séjour en institution',0
   UNION ALL SELECT 'BaAdresstyp', 4, 'Rechnungsadresse', 'Adresse de facturation',0
   UNION ALL SELECT 'BaAdresstyp', 5, 'Zustell-/Amtsadresse', 'Adresse de notification/de l''office',0
   UNION ALL SELECT 'BaAdresstyp', 9, 'Wegzugsadresse', 'Adresse de départ',0
   UNION ALL SELECT 'BaAdresstyp', 6, 'Zweitwohnungunsadresse', 'Adresse de résidence secondaire',0
   UNION ALL SELECT 'BaAdresstyp', 99, 'sonstige Adresse', 'autre adresse',0
   UNION ALL SELECT 'TaskType',6,'Anfrage','Demande',1
   UNION ALL SELECT 'TaskType',7,'Auftragserteilung','Attribution du mandat',1
   UNION ALL SELECT 'TaskType',3,'Bearbeitung','Traitement',1
   UNION ALL SELECT 'TaskType',10,'Diverses','Divers',1
   UNION ALL SELECT 'TaskType',4,'Fristablauf','Expiration du délai',1
   UNION ALL SELECT 'TaskType',12,'Gespräch vorbereiten','Préparer l’entretien',1
   UNION ALL SELECT 'TaskType',14,'Kontrolle Anfangszustand BFS','Contrôle état initial OFS',1
   UNION ALL SELECT 'TaskType',8,'Newod-Daten Meldung','Données-NEWOD Information',1
   UNION ALL SELECT 'TaskType',5,'Rückmeldung','Accusé de réception',1
   UNION ALL SELECT 'TaskType',1,'Überprüfung','Vérification',1
   UNION ALL SELECT 'TaskType',15,'Kontrolle','Contrôle',1
   UNION ALL SELECT 'TaskType', 8, 'Newod-Daten Meldung',	'Données-NEWOD Information',1
   UNION ALL SELECT 'TaskType',20, 'Fristablauf Person 14','Délai personne 14 ans',1
   UNION ALL SELECT 'TaskType',21, 'Fristablauf Person 18','Délai personne 18 ans',1
   UNION ALL SELECT 'TaskType',22, 'Fristablauf Person 25','Délai personne 25 ans',1
   UNION ALL SELECT 'TaskType', 25, 'Ablauf EFB Erwerbsaufnahme', 'Délai - Franchise sur le revenu',1
   UNION ALL SELECT 'TaskType', 26, 'AHV Vorbezug Pension Frau', 'Rente AVS anticipée femme',1
   UNION ALL SELECT 'TaskType', 27, 'AHV Vorbezug Pension Mann', 'Rente AVS anticipée homme',1
   UNION ALL SELECT 'TaskType', 28, 'Beratung Ausstattung Vertrag Auswertung Am', 'Consultation - inventaire - contrat - évaluation au',1
   UNION ALL SELECT 'TaskType', 29, 'Frist Kategorisierung', 'Délai catégorisation',1
   UNION ALL SELECT 'TaskType', 30, 'Intake Ausstattung Vertrag Auswertung Am', 'Admission - inventaire - contrat - évalutation au',1
   UNION ALL SELECT 'TaskType', 31, 'Pensionsalter Frau', 'Age de la retraite femme',1
   UNION ALL SELECT 'TaskType', 32, 'Pensionsalter Mann', 'Age de la retraite homme',1
   UNION ALL SELECT 'TaskType', 33, 'Warnung vor Ende Finanzplan', 'Avertissement avant l''échéance du plan financier',1
   UNION ALL SELECT 'TaskType',40, 'Ablauf Dienstleistungspaket', 'Le paquet de prestation arrive à échéance',1
   UNION ALL SELECT 'TaskType',41, 'Fristablauf Abklärung/Auftrag Erledigung SD', 'Echéance pour terminer une demande/clarification du service social dans le module M',1
   UNION ALL SELECT 'TaskType',	42, 'Fristablauf Abklärung/Auftrag Erledigung', 'Echéance pour terminer une demande/clarification dans le module M ',1
   UNION ALL SELECT 'TaskType',	43, 'Fristablauf Massnahmen - Berichts- und Rechnungsablage Versand', 'Expiration du délai - M - Gestion des mesures - Rapports d''activités et comptes - Envoi',1
   UNION ALL SELECT 'TaskType',	44, 'Fristablauf Massnahmen - Berichts- und Rechnungsablage Verfügung Kesb', 'Expiration du délai - M - Gestion des mesures - Rapports d''activités et comptes - APEA',1
   UNION ALL SELECT 'TaskType',	45, 'Fristablauf Massnahmen - Aufträge/Anträge Versand', 'Expiration du délai - M - Gestion des mesures - Mandats/Demandes - Envoi',1
   UNION ALL SELECT 'TaskType',	46, 'Fristablauf Massnahmen - Aufträge/Anträge Erledigung', 'Expiration du délai - M - Gestion des mesures - Mandats/Demandes - Effectuer',1
   UNION ALL SELECT 'TaskType',	51, 'Unbefristetes Gastrecht erteilen', 'Attribuer un accès invité pour une période illimitée',1
   UNION ALL SELECT 'TaskType',	52, 'Befristetes Gastrecht erteilen', 'Attribuer un accès invité pour une période limitée',1
   UNION ALL SELECT 'DynaPhase',1, 'Intake', 'Admissions',0
   UNION ALL SELECT 'DynaPhase',2, 'Beratung', 'Conseil/Consultation',0   
   UNION ALL SELECT 'FbZahlungsArtCode',1,'Oranger Einzahlungsschein','Bulletin de versement orange',0
   UNION ALL SELECT 'FbZahlungsArtCode',2,'Blau/Orange ESR ueber Bank (inaktiv)','BVR bleu/orange par banque (inactif)',0
   UNION ALL SELECT 'FbZahlungsArtCode',3,'Roter Einzahlungsschein Post','Bulletin de versement rouge - Poste',0
   UNION ALL SELECT 'FbZahlungsArtCode',4,'Bankzahlung Schweiz','Paiement bancaire - Suisse',0
   UNION ALL SELECT 'FbZahlungsArtCode',5,'Bank Überweisung (inaktiv)','Transfert bancaire (inactif)', 0
   UNION ALL SELECT 'FbZahlungsArtCode',6,'Postmandat','Mandat postal', 0


--   UNION ALL SELECT 'LOVName', Code, 'TextDE', 'TextFR',0
)


INSERT INTO @LOVText
  SELECT LOC.TextTID,
         CTE.LOVName,
         CTE.Code,
         CTE.TextDE,
         CTE.TextFR,
         CTE.IsWithUpdateXLOVCodeTextFR
  FROM LOVTextCTE CTE
    LEFT JOIN dbo.XLOVCode LOC ON LOC.LOVName = CTE.LOVName 
                              AND LOC.Code = CTE.Code
  
-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

-- loop all entries
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN

  -- get current entry
  SELECT @textTID = TMP.TextTID,
         @lovName = TMP.LOVName,
         @code    = TMP.Code,
         @textDE  = TMP.TextDE,
         @textFR  = TMP.TextFR,
         @isWithUpdateXLOVCodeTextFR = TMP.IsWithUpdateXLOVCodeTextFR
  FROM @LOVText TMP
  WHERE TMP.ID = @EntriesIterator;
                   
  EXEC spXSetXLangText @textTID, 
                       1, -- LanguageCodeDE
                       @textDE,
                       @lovName,
                       NULL,
                       4/*TypeCode=4: LOVText*/,
                       @code/*Code*/, 
                       @textTID OUT;
                       
  EXEC spXSetXLangText @textTID, 
                       2,  -- LanguageCodeFr
                       @textFR,
                       @lovName,
                       NULL,
                       4/*TypeCode=4: LOVText*/,
                       @code/*Code*/, 
                       @textTID OUT;  
                      

  PRINT 'LOV ' + @lovName + ' Code=' + CONVERT(VARCHAR(10),@code) + ' Übersetzungen im xLangText aktualisiert';

  IF @isWithUpdateXLOVCodeTextFR = 1
  BEGIN

      UPDATE dbo.XLOVCode
      SET [Text] = @textFR
      FROM dbo.XLOVCode 
      WHERE LOVName = @lovName
        AND Code = @code;

      PRINT 'LOV ' + @lovName + ' Code=' + CONVERT(VARCHAR(10),@code) + ' Text auf fr. im XLOVCode.[Text] mit überschrieben';

  END

  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO