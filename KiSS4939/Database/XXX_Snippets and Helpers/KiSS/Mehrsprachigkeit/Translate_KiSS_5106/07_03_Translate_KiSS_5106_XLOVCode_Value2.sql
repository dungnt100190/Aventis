/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to translate the Fiel XLOVCode.Value2
  
=================================================================================================*/

/*
SELECT LOVName, Code, LOC.Value2, Value2DE = LAND.Text, Value2FR = LANF.Text,
  s = '   UNION ALL SELECT ''' + LOVName + ''', ' + CONVERT(VARCHAR(MAX), Code) + ', ''' + ISNULL(LAND.Text, LOC.Value2) + ''', ''' + ISNULL(LANF.Text, 'ValueFR') + ''''
  , *
FROM dbo.XLOVCode LOC WITH (READUNCOMMITTED)
  LEFT JOIN dbo.XLangText LAND WITH (READUNCOMMITTED) ON LAND.TID = LOC.Value2TID AND LAND.LanguageCode = 1
  LEFT JOIN dbo.XLangText LANF WITH (READUNCOMMITTED) ON LANF.TID = LOC.Value2TID AND LANF.LanguageCode = 2
WHERE LOVName = 'TaskType'
*/


-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO


DECLARE @value2TID INT;
DECLARE @value2DE VARCHAR(2000);
DECLARE @value2FR VARCHAR(2000);
DECLARE @code INT;
DECLARE @lovName VARCHAR(255);
DECLARE @isWithUpdateXLOVCodeValue2FR BIT;


DECLARE @LOVText TABLE
(
  ID INT IDENTITY(1, 1) NOT NULL,
  Value2TID INT,
  LOVName VARCHAR(255),
  Code INT,
  Value2DE VARCHAR(2000),
  Value2FR VARCHAR(2000),
  IsWithUpdateXLOVCodeValue2FR BIT
);

DECLARE @EntriesIterator INT;
DECLARE @EntriesCount INT;

-- Fill the list of items to be translated here
;WITH LOVTextCTE (LOVName, Code, Value2DE, Value2FR, IsWithUpdateXLOVCodeValue2FR)
AS
(
   SELECT 'TaskType', 20, 'Bitte Casemanagement-Massnahmen prüfen.', 'Veuillez vérifier les mesures "casemanagement"',1
   UNION ALL SELECT 'TaskType', 21, 'Person wird zu "Junger Erwachsener" (zwischen vollendetem 18. und vollendetem 25. Altersjahr)', 'La personne devient "Jeune adulte" (entre 18 et 25 ans révolu)',1
   UNION ALL SELECT 'TaskType', 22, 'Person ist kein "Junger Erwachsener" mehr (18-25 jährig SKOS H.11)', 'La personne n''est plus jeune adulte (CSIAS H.11 18-25 ans)',1
   UNION ALL SELECT 'TaskType', 25, 'Die EFB Erwerbsaufnahme darf maximal 6 Monate ausbezahlt werden.', 'La franchise sur le revenu doit être versée au maximum 6 mois à l''avance',1
   UNION ALL SELECT 'TaskType', 28, 'Die Beratungsphase muss am {0} ausgewertet werden.', 'La phase de consultation doit être évaluée le {0}.',1
   UNION ALL SELECT 'TaskType', 29, 'Die Frist der Kategorisierung vom {0} läuft am {1} ab.', 'Le délai pour la catégorisation de {0} expire le {1}.',1
   UNION ALL SELECT 'TaskType', 30, 'Die Intakephase muss am {0} ausgewertet werden.', 'La phase d''admission doit être évaluée le {0}.',1
   UNION ALL SELECT 'TaskType', 40, 'Der Start der Phase: {0} von "{1}" ist am {2} Das zugewiesene Dienstleistungspaket "{3}" hat eine maximale Laufzeit von {4} Monat(en).', 
                                      'Le début de la phase "{0}" de la personne "{1}" est le {2}. Le paquet de prestations attribué "{3}" a un délai maximal de {4} mois. ',1
   UNION ALL SELECT 'TaskType', 41, 'Frist für Auftragserledigung.', 'Echéance pour fermer la demande/clarification',1
   UNION ALL SELECT 'TaskType', 42, 'Frist für Auftrags- / Abklärungs-Erledigung läuft ab.', 'Echéance pour fermer la demande/clarification',1
   UNION ALL SELECT 'TaskType', 43, 'Frist für Auftragserledigung.', 'Echéance pour fermer le rapport.',1
   UNION ALL SELECT 'TaskType', 44, 'Die Verfügung KESB auf den Bericht ist fällig.', 'Echéance pour la mise à diposition du rapport APEA.',1
   UNION ALL SELECT 'TaskType', 45, 'Die Verfügung KESB auf den Geschäftsbericht ist fällig.', 'Echéance pour la mise à diposition du rapport d''activité APEA.',1
   UNION ALL SELECT 'TaskType', 46, 'Frist für Auftrags/Antrag-Erledigung läuft ab.', 'Echéance pour le mandat/la demande.',1
   UNION ALL SELECT 'TaskType', 51, '{0} {1} ({2}) wünscht unbefristetes Gastrecht in Modul: {3} des Falls: {4}  Bemerkungen: {5}  Möchten Sie {0} {1} ({2}) ein unbefristetes Gastrecht erteilen?', 
                                      '{0} {1} ({2}) souhaite un accès invité pour une période illimitée pour le module : {3} du cas: {4}  Remarques : {5}  Voulez-vous donner un accès invité à {0} {1} ({2})?',1
   UNION ALL SELECT 'TaskType', 52, '{0} {1} ({2}) wünscht ein auf {3} Monate befristetes Gastrecht in Modul: {4} des Falls: {5}.  Bemerkungen: {6}  Möchten Sie {0} {1} ({2}) ein befristetes Gastrecht erteilen?', 
                                        '{0} {1} ({2}) souhaite un accès invité pour une période de {3} mois pour le module : {4} du cas: {5}  Remarques : {6}  Voulez-vous donner un accès invité à durée limitée à {0} {1} ({2})?',1
--   UNION ALL SELECT 'LOVName', Code, 'Value2DE', 'Value2FR'

)



INSERT INTO @LOVText
  SELECT LOC.Value2TID,
         CTE.LOVName,
         CTE.Code,
         CTE.Value2DE,
         CTE.Value2FR,
         CTE.IsWithUpdateXLOVCodeValue2FR
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
  SELECT @value2TID = TMP.Value2TID,
         @lovName = TMP.LOVName,
         @code    = TMP.Code,
         @value2DE  = TMP.Value2DE,
         @value2FR  = TMP.Value2FR,
         @isWithUpdateXLOVCodeValue2FR = TMP.IsWithUpdateXLOVCodeValue2FR
  FROM @LOVText TMP
  WHERE TMP.ID = @EntriesIterator;
                   
  EXEC spXSetXLangText @value2TID, 
                       1, -- LanguageCodeDE
                       @value2DE,
                       @lovName,
                       NULL,
                       7/*TypeCode=7: Value2*/,
                       @code/*Code*/, 
                       @value2TID OUT;
                       
  EXEC spXSetXLangText @value2TID, 
                       2,  -- LanguageCodeFr
                       @value2FR,
                       @lovName,
                       NULL,
                       7/*TypeCode=7: Value2*/,
                       @code/*Code*/, 
                       @value2TID OUT;    

  PRINT 'LOV ' + @lovName + ' Code=' + CONVERT(VARCHAR(10),@code) + ' Übersetzungen im xLangText aktualisiert';

  IF @isWithUpdateXLOVCodeValue2FR = 1
  BEGIN

      UPDATE dbo.XLOVCode
      SET Value2 = @value2FR
      FROM dbo.XLOVCode 
      WHERE LOVName = @lovName
        AND Code = @code;

      PRINT 'LOV ' + @lovName + ' Code=' + CONVERT(VARCHAR(10),@code) + ' Text auf fr. im XLOVCode.Value2 mit überschrieben';

  END  

  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO