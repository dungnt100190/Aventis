/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to translate the Fiel XLOVCode.Value1
  
=================================================================================================*/

/*
SELECT LOVName, Code, LOC.Value1, Value1DE = LAND.Text, Value1FR = LANF.Text,
  s = '   UNION ALL SELECT ''' + LOVName + ''', ' + CONVERT(VARCHAR(MAX), Code) + ', ''' + ISNULL(LAND.Text, LOC.Value1) + ''', ''' + ISNULL(LANF.Text, 'ValueFR') + ''''
  , *
FROM dbo.XLOVCode LOC WITH (READUNCOMMITTED)
  LEFT JOIN dbo.XLangText LAND WITH (READUNCOMMITTED) ON LAND.TID = LOC.Value1TID AND LAND.LanguageCode = 1
  LEFT JOIN dbo.XLangText LANF WITH (READUNCOMMITTED) ON LANF.TID = LOC.Value1TID AND LANF.LanguageCode = 2
WHERE LOVName = 'TaskType'
*/


-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO


DECLARE @value1TID INT;
DECLARE @value1DE VARCHAR(2000);
DECLARE @value1FR VARCHAR(2000);
DECLARE @code INT;
DECLARE @lovName VARCHAR(255);
DECLARE @isWithUpdateXLOVCodeValue1FR BIT;

DECLARE @LOVText TABLE
(
  ID INT IDENTITY(1, 1) NOT NULL,
  Value1TID INT,
  LOVName VARCHAR(255),
  Code INT,
  Value1DE VARCHAR(2000),
  Value1FR VARCHAR(2000),
  IsWithUpdateXLOVCodeValue1FR BIT
);

DECLARE @EntriesIterator INT;
DECLARE @EntriesCount INT;

-- Fill the list of items to be translated here
;WITH LOVTextCTE (LOVName, Code, Value1DE, Value1FR, IsWithUpdateXLOVCodeValue1FR)
AS
(
   SELECT 'TaskType', 20, 'Person wird am {0} 14 Jahre alt', 'La personne aura 14 ans le {0}',1
   UNION ALL SELECT 'TaskType', 21, 'Person wird am {0} 18 Jahre alt', 'La personne aura 18 ans le {0}',1
   UNION ALL SELECT 'TaskType', 22, 'Person wird am {0} 25 Jahre alt', 'La personne aura 25 ans le {0}',1
   UNION ALL SELECT 'TaskType', 25, 'EFB Erwerbsaufnahme max. bis {0}', 'Franchise sur le revenu jusqu''au {0} max.',1
   UNION ALL SELECT 'TaskType', 26, 'Person erreicht am {0} das Alter für AHV-Vorbezug', 'La personne atteindra le {0} l''âge pour la retraite anticipée',1
   UNION ALL SELECT 'TaskType', 27, 'Person erreicht am {0} das Alter für AHV-Vorbezug', 'La personne atteindra le {0} l''âge pour la retraite anticipée',1
   UNION ALL SELECT 'TaskType', 28, 'Auswertungsgespräch vorbereiten', 'Préparation d''une évaluation d''entretien',1
   UNION ALL SELECT 'TaskType', 29, 'Frist Kategorisierung', 'Délai catégorisation',1
   UNION ALL SELECT 'TaskType', 30, 'Auswertungsgespräch vorbereiten', 'Préparer une évaluation d''entretien',1
   UNION ALL SELECT 'TaskType', 31, 'Person erreicht am {0} das Pensionsalter', 'La personne atteint le {0} l''âge de la retraite',1
   UNION ALL SELECT 'TaskType', 32, 'Person erreicht am {0} das Pensionsalter', 'La personne atteint le {0} l''âge de la retraite',1
   UNION ALL SELECT 'TaskType', 33, 'Finanzplan läuft am {0} ab', 'Le plan financier arrive à échéance le {0}',1
   UNION ALL SELECT 'TaskType', 40, 'Das Dienstleistungspaket läuft am {0} ab', 'Le paquet de prestation expire le {0}',1
   UNION ALL SELECT 'TaskType', 41, 'KES - Abklärung/Aufträge Erledigung SD', 'M - Demande/Clarification - Service social',1
   UNION ALL SELECT 'TaskType', 42, 'KES - Abklärung/Aufträge', 'M - Demande/Clarification',1
   UNION ALL SELECT 'TaskType', 43, 'KES - Massnahmen Berichts- und Rechnungsablage', 'M - Expiration du délai - Gestion des mesures - Rapports d''activités et comptes',1
   UNION ALL SELECT 'TaskType', 44, 'KES - Massnahmen - Berichts- und Rechnungsablage', 'M - Expiration du délai - Gestion des mesures - Rapports d''activités et comptes',1
   UNION ALL SELECT 'TaskType', 45, 'KES - Massnahmen - Abklärung/Aufträge','M - Expiration du délai - Gestion des mesures - Mandats/Demandes - Envoi',1
   UNION ALL SELECT 'TaskType', 46, 'KES - Massnahmen - Abklärung/Aufträge','M - Expiration du délai - Gestion des mesures - Mandats/Demandes - Effectuer',1
   UNION ALL SELECT 'TaskType', 51, 'Unbefristetes Gastrecht erteilen','Attribuer un accès invité pour une période illimitée',1
   UNION ALL SELECT 'TaskType', 52, 'Befristetes Gastrecht erteilen', 'Attribuer un accès invité pour une période limitée',1
--   UNION ALL SELECT 'LOVName', Code, 'Value1DE', 'Value1FR',1

)



INSERT INTO @LOVText
  SELECT LOC.Value1TID,
         CTE.LOVName,
         CTE.Code,
         CTE.Value1DE,
         CTE.Value1FR,
         CTE.IsWithUpdateXLOVCodeValue1FR
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
  SELECT @value1TID = TMP.Value1TID,
         @lovName = TMP.LOVName,
         @code    = TMP.Code,
         @value1DE  = TMP.Value1DE,
         @value1FR  = TMP.Value1FR,
         @isWithUpdateXLOVCodeValue1FR = TMP.IsWithUpdateXLOVCodeValue1FR
  FROM @LOVText TMP
  WHERE TMP.ID = @EntriesIterator;
                   
  EXEC spXSetXLangText @value1TID, 
                       1, -- LanguageCodeDE
                       @value1DE,
                       @lovName,
                       NULL,
                       6/*TypeCode=6: Value1*/,
                       @code/*Code*/, 
                       @value1TID OUT;
                       
  EXEC spXSetXLangText @value1TID, 
                       2,  -- LanguageCodeFr
                       @value1FR,
                       @lovName,
                       NULL,
                       6/*TypeCode=6: Value1*/,
                       @code/*Code*/, 
                       @value1TID OUT;    
                       
  PRINT 'LOV ' + @lovName + ' Code=' + CONVERT(VARCHAR(10),@code) + ' Übersetzungen im xLangText aktualisiert';

  IF @isWithUpdateXLOVCodeValue1FR = 1
  BEGIN

      UPDATE dbo.XLOVCode
      SET Value1 = @value1FR
      FROM dbo.XLOVCode 
      WHERE LOVName = @lovName
        AND Code = @code;

      PRINT 'LOV ' + @lovName + ' Code=' + CONVERT(VARCHAR(10),@code) + ' Text auf fr. im XLOVCode.Valu1 mit überschrieben';

  END                       

  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO