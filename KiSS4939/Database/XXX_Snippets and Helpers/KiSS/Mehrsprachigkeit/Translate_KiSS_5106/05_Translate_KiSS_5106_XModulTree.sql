/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to translate entries in the Table XModulTree
=================================================================================================*/
-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

PRINT 'Übersetzungen in der Tabelle XModulTree beginnt'

DECLARE @nameTID INT;
DECLARE @nameDE VARCHAR(100);
DECLARE @nameFR VARCHAR(100);
DECLARE @className VARCHAR(255);
DECLARE @modulID INT;

DECLARE @XModulTreeText TABLE
(
  ID INT IDENTITY(1, 1) NOT NULL,
  NameTID INT,
  NameDE VARCHAR(100),
  NameFR VARCHAR(100),
  ClassName VARCHAR(255),
  ModulID INT
);

DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;

-- Fill the list of items to be translated here
;WITH XModulTreeCTE (NameDE, NameFR, ClassName, ModulID)
AS
(
            SELECT 'Sozialhilfe', 'Aide sociale', 'CtlWhLeistung', 3
  UNION ALL SELECT 'Reguläre Sozialhilfe','Aide sociale ordinaire', 'CtlWhFinanzplan',3
  UNION ALL SELECT 'Vorabzugskonti','Comptes de prélèvement','CtlWhSpezialkonto',3
  UNION ALL SELECT 'Abzahlungskonti','Comptes de remboursement','CtlWhSpezialkonto',3
  UNION ALL SELECT 'Ausgabekonti','Comptes de dépense','CtlWhSpezialkonto',3
  UNION ALL SELECT 'Kürzungen','Réductions','CtlWhSpezialkonto',3
  UNION ALL SELECT 'Klientenabrechnung','Décompte client','CtlWhKlientenabrechnung',3
  UNION ALL SELECT 'Kontoauszug','Extrait de compte','CtlWhKontoauszug',3
  UNION ALL SELECT 'ASV','OAS','CtlWhASVSErfassung',3
  UNION ALL SELECT 'AHV Beiträge','Cotisations AVS','CtlBgSilAHVBeitrag',3
  UNION ALL SELECT 'Wiedereingliederung','Réintégration sociale','CtlBgSilWiedereingliederung',3
  UNION ALL SELECT 'Kosten von Therapie und Entzugsmassnahmen','Coûts de thérapie et sevrage','CtlBgSilTherapieEntzug',3
  UNION ALL SELECT 'Krankheits- und behinderungsbedingte Leistungen','Prestations dues à la maladie et au handicap','CtlBgSilKrankheitBehinderungLeistung',3
  UNION ALL SELECT 'Situationsbedingte Leistungen','Prestations circonstancielles','CtlBgSilSituationsbedingteLeistungen',3
  UNION ALL SELECT 'Personen im Haushalt','Personnes dans le ménage','CtlWhPersonen',3
  UNION ALL SELECT 'Finanzplan','Plan financier','CtlBgUebersicht',3
  UNION ALL SELECT 'Masterbudget','Budget directeur','CtlWhBudget',3
  UNION ALL SELECT 'Monatsbudget','Budget mensuel','CtlWhBudget',3
  UNION ALL SELECT 'Erwerbseinkommen', 'Revenu professionnel' ,'CtlBgErwerbseinkommen',3
  UNION ALL SELECT 'Alimentenguthaben','Avoirs de pension alimentaire','CtlBgAlimente',3
  UNION ALL SELECT 'Einkommen aus Versicherungsleistungen','Revenu de prestations d''assurance', 'CtlBgVersicherung',3
  UNION ALL SELECT 'Vermögen und Vermögensverbrauch','Fortune et consommation de fortune','CtlBgVermoegen',3
  UNION ALL SELECT 'Grundbedarf','Besoins de base', 'CtlBgGrundbedarf',3
  UNION ALL SELECT 'Wohnkosten','Coûts de logement', 'CtlBgWohnkosten',3
  UNION ALL SELECT 'Med. Grundversorgung','Soins de base', 'CtlBgKrankenkasse',3
  UNION ALL SELECT 'Zulagen / EFB','Complément - Franchise sur le revenu','CtlBgZulagenEFB',3
  UNION ALL SELECT 'Situationsbedingte Leistungen','Prestations circonstancielles',NULL,3
)


-- insert entries into temp table
INSERT INTO @XModulTreeText
 SELECT 
   TRE.NameTID,
   CTE.NameDE, 
   CTE.NameFR,
   CTE.ClassName, 
   CTE.ModulID
 FROM XModulTreeCTE CTE
   LEFT JOIN dbo.XModulTree TRE ON TRE.Name = CTE.NameDE 
                               AND ISNULL(TRE.ClassName,'NULLZZZ') = ISNULL(CTE.ClassName,'NULLZZZ')
                               AND TRE.ModulID = CTE.ModulID


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
         @className     = TMP.ClassName,
         @modulID       = TMP.ModulID
  FROM @XModulTreeText TMP
  WHERE TMP.ID = @EntriesIterator;

  EXEC spXSetXLangText @nameTID, 1, @nameDE, NULL,NULL,NULL,NULL,@nameTID OUT;
  EXEC spXSetXLangText @nameTID, 2, @nameFR, NULL,NULL,NULL,NULL,@nameTID OUT;

  UPDATE dbo.XModulTree 
  SET NameTID = @nameTID
  WHERE Name = @nameDE
    AND ISNULL(ClassName,'NULLZZZ') = ISNULL(@className ,'NULLZZZ')
    AND ModulID = @modulID;  
    
  PRINT 'NameTID mit Name=' + @nameDE  + ' ClassName=' + ISNULL(@className,'NULL') + ' ModulID=' + CONVERT(VARCHAR(MAX),@modulID) + ' aktualisiert';
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;
  

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO