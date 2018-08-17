/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to translate entries in the Table BaInstitutionTyp
=================================================================================================*/
-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

PRINT 'Übersetzung in der Tabelle BaInstitutionTyp - Feld Name beginnt'

DECLARE @nameTID INT;
DECLARE @nameDE VARCHAR(100);
DECLARE @nameFR VARCHAR(100);
DECLARE @name VARCHAR(255);
DECLARE @baInstitutionTypID INT;

DECLARE @BaInstitutionTypText TABLE
(
  ID INT IDENTITY(1, 1) NOT NULL,
  NameTID INT,
  NameDE VARCHAR(100),
  NameFR VARCHAR(100),
  Name VARCHAR(255),
  BaInstitutionTypID INT
);

DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;

-- Fill the list of items to be translated here
;WITH BaInstitutionTypCTE (NameDE, NameFR, Name, BaInstitutionTypID)
AS
(
          SELECT 'Arbeitgeber/-in','Employeur/-euse','Arbeitgeber/-in',1
UNION ALL SELECT 'Arzt/Ärztin, Zahnarzt/-ärztin','Docteur, dentiste','Arzt/Ärztin, Zahnarzt/-ärztin',2
UNION ALL SELECT 'Krankenkasse','Caisse maladie','Krankenkasse',4
UNION ALL SELECT 'Spital/Klinik','Hôpital/Clinique','Spital/Klinik',9
UNION ALL SELECT 'Vermieter/-in','Propriétaire','Vermieter/-in',10
UNION ALL SELECT 'Andere','Autre','Andere',11
UNION ALL SELECT 'Amt, Behörde','Office, autorité','Amt, Behörde',12
UNION ALL SELECT 'Stat. Einrichtung, Tagesstätte','Instit. officielle/ Centre de jour','Stat. Einrichtung, Tagesstätte',13
UNION ALL SELECT 'Beratungsstelle, amb. Dienst, Spitex','Ctr consult,soins ambul,aide soins dom','Beratungsstelle, amb. Dienst, Spitex',14
UNION ALL SELECT 'Schule / Kindergarten','Ecole / Jardin d''enfants','Schule / Kindergarten',15
UNION ALL SELECT 'Sach- / Sozialversicherung','Assurance sociale/de biens','Sach- / Sozialversicherung',16
UNION ALL SELECT 'Zivilstandsamt','Etat civil','Zivilstandsamt',17
UNION ALL SELECT 'Bank','Banque','Bank',18
UNION ALL SELECT 'Notar/-in','Notaire','Notar/-in',19
UNION ALL SELECT 'Gemeinde','Communauté','Gemeinde',20
UNION ALL SELECT 'Behörden','Autorité','Behörden',10012
UNION ALL SELECT 'Institutionen','Institution','Institutionen',10013
UNION ALL SELECT 'Lieferanten','Fournisseur','Lieferanten',10014
UNION ALL SELECT 'Jurist','Juriste','Jurist',10016
UNION ALL SELECT 'Vorsorge','Prévoyance','Vorsorge',10017
UNION ALL SELECT 'Berufsbeistand','Curateur professionnel','Berufsbeistand',10018
UNION ALL SELECT 'Fachbeistand','Autre professionnel','Fachbeistand',10019
UNION ALL SELECT 'Privatperson (PriMa)','Curateur privé (mandataire privé)','Privatperson (PriMa)',10020

)


-- insert entries into temp table
INSERT INTO @BaInstitutionTypText
 SELECT 
   ITY.NameTID,
   CTE.NameDE, 
   CTE.NameFR,
   CTE.Name, 
   CTE.BaInstitutionTypID
 FROM BaInstitutionTypCTE CTE
   LEFT JOIN dbo.BaInstitutionTyp ITY ON ITY.Name = CTE.Name
                                     AND ITY.BaInstitutionTypID = CTE.BaInstitutionTypID


-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

-- loop all entries
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN

  -- get current entry
  SELECT @nameTID       = TMP.NameTID,
         @nameDE        = TMP.NameDE,
         @nameFR        = TMP.NameFR,
         @name          = TMP.Name,
         @baInstitutionTypID = TMP.BaInstitutionTypID
  FROM @BaInstitutionTypText TMP
  WHERE TMP.ID = @EntriesIterator;

  EXEC spXSetXLangText @nameTID, 1, @nameDE, NULL,NULL,NULL,NULL,@nameTID OUT;
  EXEC spXSetXLangText @nameTID, 2, @nameFR, NULL,NULL,NULL,NULL,@nameTID OUT;

  UPDATE dbo.BaInstitutionTyp 
  SET NameTID = @nameTID
  WHERE Name = @name
    AND BaInstitutionTypID = @baInstitutionTypID;  
    
  PRINT 'NameTID Name=' + @name + ' BaInstitutionTypID=' + CONVERT(VARCHAR(MAX),@baInstitutionTypID) + ' aktualisiert';
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;
  

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO