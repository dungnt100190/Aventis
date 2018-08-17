SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spCopyFall;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Stored Procedures/Fallführung/spCopyFall.sql $
  $Author: Cjaeggi $
  $Modtime: 10.08.10 8:32 $
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
    SUMMARY:            Kopiert eine Person inkl. Leistungsdaten und Bezugspersonen.
                        Angepasste Version für BSS, Original wurde von Marcel Weber für FAMOZ erstellt.
                        Achtung: es werden nicht alle Falldaten kopiert (z.B. Einträge in KliBu werden nicht kopiert).
    @BaPersonIID:       ID der Originalperson
    @KlientNamePostfix: Namenszusatz der kopierten Personen
  -
  RETURNS:      neue BaPersonID
  -
  TEST:    .
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Stored Procedures/Fallführung/spCopyFall.sql $
 * 
 * 3     10.08.10 8:33 Cjaeggi
 * #4167: Fixed sp pre-header, refactoring
 * 
 * 2     9.08.10 12:44 Rstahel
 * #4167: Tabellenname BaPerson_Institution durch neuen Namen
 * BaPerson_BaInstitution ersetzt
 * 
 * 1     7.04.09 13:23 Tberger
 * für BSS angepasste SP zum Kopieren einer Person inkl. Falldaten
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/

CREATE PROCEDURE dbo.spCopyFall 
(
  @BaPersonID INT,
  @KlientNamePostfix VARCHAR(10)
)
AS
BEGIN
  --DECLARE @BaPersonID INT;
  DECLARE @BaWohnsituationID INT;
  DECLARE @FaLeistungID INT;
  DECLARE @FaUnterlagenID INT;
  DECLARE @FaDokumenteID INT;
  DECLARE @DocumentID INT;
  DECLARE @BgFinanzplanID INT;
  DECLARE @BgBudgetID INT;

  DECLARE @NewBaPersonID INT;
  DECLARE @NewBaWohnsituationID INT;
  DECLARE @NewFaFallID INT;
  DECLARE @NewFaLeistungID INT;
  DECLARE @NewFaUnterlagenID INT;
  DECLARE @NewFaDokumenteID INT;
  DECLARE @NewDocumentID INT;
  DECLARE @NewBgFinanzplanID INT;
  DECLARE @NewBgBudgetID INT;

  DECLARE @AiInkassofallID INT;
  DECLARE @NewAiInkassofallID INT;
  DECLARE @BaPersonRelationId INT;
  DECLARE @NewBaPersonRelationId INT;

  DECLARE @WhereClause VARCHAR(400);

  -- Historisierungs-Trigger in BaPerson und BaAdresse 'überlisten'
  INSERT INTO HistoryVersion (AppUser) VALUES ('copyFall')
  
  -- BaPerson duplizieren  
  SET @WhereClause = 'BaPersonID = ' + CONVERT(VARCHAR, @BaPersonID)
  EXEC spDuplicateRows 'BaPerson', @WhereClause
  SET @NewBaPersonID = SCOPE_IDENTITY()
  --update #FallPerson set NewBaPersonID = @NewBaPersonID where BaPersonID = @BaPersonID

  -- Kostenstelle  
  EXEC spKbKostenstelleAnlegen @NewBaPersonID, 0

  -- Adressen
  SET @WhereClause = 'BaPersonID = ' + CONVERT(VARCHAR, @BaPersonID)
  EXEC spDuplicateRows 'BaAdresse', @WhereClause,'BaPersonID', @NewBaPersonID

  /* zusammengesetzter Primary-Key
  -- Ausbildung
  SET @WhereClause = 'BaPersonID = ' + CONVERT(VARCHAR, @BaPersonID)
  EXEC spDuplicateRows 'BaArbeitAusbildung', @WhereClause,'BaPersonID', @NewBaPersonID
  */
  
  /* zusammengesetzter Primary-Key
  -- Gesundheit
  SET @WhereClause = 'BaPersonID = ' + CONVERT(VARCHAR, @BaPersonID)
  EXEC spDuplicateRows 'BaGesundheit', @WhereClause,'BaPersonID', @NewBaPersonID
  */
    
  -- Mietvertrag
  SET @WhereClause = 'BaPersonID = ' + CONVERT(VARCHAR, @BaPersonID)
  EXEC spDuplicateRows 'BaMietvertrag', @WhereClause,'BaPersonID', @NewBaPersonID

  -- Institutionen
  SET @WhereClause = 'BaPersonID = ' + CONVERT(VARCHAR, @BaPersonID)
  EXEC spDuplicateRows 'BaPerson_BaInstitution', @WhereClause,'BaPersonID', @NewBaPersonID
  
  -- Kinder kopieren, damit nicht plötzlich ein Kind 2 Mütter hat...
  DECLARE cPerson_Relation cursor static for 
  select BaPersonID_2 from BaPerson_Relation where BaPersonID_1 = @BaPersonID
  open cPerson_Relation
  fetch next from cPerson_Relation into @BaPersonRelationId
  while @@fetch_status = 0 begin
    -- BaPerson duplizieren  
    SET @WhereClause = 'BaPersonID = ' + CONVERT(VARCHAR, @BaPersonRelationId)
    EXEC spDuplicateRows 'BaPerson', @WhereClause
    SET @NewBaPersonRelationId = SCOPE_IDENTITY()

    -- Postfix bei neuem Personenname setzen
    update BaPerson set Name = Name + ' ' + @KlientNamePostfix where BaPersonID = @NewBaPersonRelationId 
  
    -- Beziehung herstellen
    SET @WhereClause = 'BaPersonID_1 = ' + CONVERT(VARCHAR, @BaPersonID) + ' AND BaPersonID_2 = ' + CONVERT(VARCHAR, @BaPersonRelationId)
    EXEC spDuplicateRows 'BaPerson_Relation', @WhereClause,'BaPersonID_1', @NewBaPersonID, 'BaPersonID_2', @NewBaPersonRelationId

    fetch next from cPerson_Relation into @BaPersonRelationId
   end
  close cPerson_Relation
  deallocate cPerson_Relation

  -- Eltern und andere Personen kopieren, damit nicht plötzlich ein Fallträger 2 Mütter hat...
  DECLARE cPerson_Relation cursor static for 
  select BaPersonID_1 from BaPerson_Relation where BaPersonID_2 = @BaPersonID
  open cPerson_Relation
  fetch next from cPerson_Relation into @BaPersonRelationId
  while @@fetch_status = 0 begin
    -- BaPerson duplizieren  
    SET @WhereClause = 'BaPersonID = ' + CONVERT(VARCHAR, @BaPersonRelationId)
    EXEC spDuplicateRows 'BaPerson', @WhereClause
    SET @NewBaPersonRelationId = SCOPE_IDENTITY()

    -- Postfix bei neuem Personenname setzen
    update BaPerson set Name = Name + ' ' + @KlientNamePostfix where BaPersonID = @NewBaPersonRelationId 
  
    -- Beziehung herstellen
    SET @WhereClause = 'BaPersonID_2 = ' + CONVERT(VARCHAR, @BaPersonID) + ' AND BaPersonID_1 = ' + CONVERT(VARCHAR, @BaPersonRelationId)
    EXEC spDuplicateRows 'BaPerson_Relation', @WhereClause,'BaPersonID_2', @NewBaPersonID, 'BaPersonID_1', @NewBaPersonRelationId

    fetch next from cPerson_Relation into @BaPersonRelationId
   end
  close cPerson_Relation
  deallocate cPerson_Relation

  /* zusammengesetzter Primary-Key
    -- Kostenstellen
    SET @WhereClause = 'BaPersonID = ' + CONVERT(VARCHAR, @BaPersonID)
    EXEC spDuplicateRows 'BaPersonKbKostenstelle', @WhereClause,'BaPersonID', @NewBaPersonID
  */
    
  -- WV-Code
  SET @WhereClause = 'BaPersonID = ' + CONVERT(VARCHAR, @BaPersonID)
  EXEC spDuplicateRows 'BaWVCode', @WhereClause,'BaPersonID', @NewBaPersonID
  
  -- Zahlungsweg
  SET @WhereClause = 'BaPersonID = ' + CONVERT(VARCHAR, @BaPersonID)
  EXEC spDuplicateRows 'BaZahlungsweg', @WhereClause,'BaPersonID', @NewBaPersonID

  -- Postfix bei neuem Personenname setzen
  update BaPerson set Name = Name + ' ' + @KlientNamePostfix where BaPersonID = @NewBaPersonID
  
  -- Loop über FaLeistung
  DECLARE cFaLeistung cursor static for 
  select FaLeistungID from FaLeistung where BaPersonID = @BaPersonID

  open cFaLeistung
  fetch next from cFaLeistung into @FaLeistungID
  while @@fetch_status = 0 begin

  --FaLeistung - ProzessCode 200
    SET @WhereClause = 'FaLeistungID = ' + CONVERT(VARCHAR, @FaLeistungID)
    
    -- Achtung: Fehler in spDuplicateRows, Replace() ersetzt innerhalb von Feldnamen
    --EXEC spDuplicateRows 'FaLeistung', @WhereClause,'BaPersonID,', @NewBaPersonID
    EXEC spDuplicateRows 'FaLeistung', @WhereClause,'SchuldnerBaPersonID', @NewBaPersonID,'BaPersonID', @NewBaPersonID, 'FaFallID', @NewBaPersonID
    SET @NewFaLeistungID = SCOPE_IDENTITY()
    --update FaLeistung SET SchuldnerBaPersonID=@NewBaPersonID where FaLeistungID=@NewFaLeistungID and isnull(SchuldnerBaPersonID,0)>0
    
    -- DynaValues (Aktennotizen, Besprechungen, Dokumente,...)
    SET @WhereClause = 'FaLeistungID = ' + CONVERT(VARCHAR, @FaLeistungID)
    EXEC spDuplicateRows 'DynaValue', @WhereClause,'FaLeistungID', @NewFaLeistungID

  -- BgSpezKonto (Ausgabekonto, Abzahlungskonto, Vorabzugskonto)
    SET @WhereClause = 'FaLeistungID = ' + CONVERT(VARCHAR, @FaLeistungID)
    EXEC spDuplicateRows 'BgSpezkonto', @WhereClause,'FaLeistungID', @NewFaLeistungID, 'BaPersonID', @NewBaPersonID

   -- Loop über BgFinanplan
    DECLARE cFinanzplan cursor static for 
    select BgFinanzplanID from BgFinanzplan where FaLeistungID = @FaLeistungID

    open cFinanzplan
    fetch next from cFinanzplan into @BgFinanzplanID
    while @@fetch_status = 0 begin

      -- FaFinanzplan duplizieren
      SET @WhereClause = 'BgFinanzplanID = ' + CONVERT(VARCHAR, @BgFinanzplanID)
      EXEC spDuplicateRows 'BgFinanzplan', @WhereClause,'FaLeistungID', @NewFaLeistungID
      SET @NewBgFinanzplanID = SCOPE_IDENTITY()

      -- BgFinanzplan_BaPerson duplizieren (Haushaltsmitglieder)
      -- Achtung: Personen stamen aus dem originalen Fall!
      insert BgFinanzplan_BaPerson (BgFinanzPlanID,BaPersonID,IstUnterstuetzt,BaZahlungswegID)
      select @NewBgFinanzplanID,BaPersonID,FPP.IstUnterstuetzt,FPP.BaZahlungswegID
      from   BgFinanzplan_BaPerson FPP           
      where  FPP.BgFinanzplanID = @BgFinanzplanID

      -- Fallträger ersetzen
      update BgFinanzplan_BaPerson 
      set BaPersonID=@NewBaPersonID
      where BaPersonID=@BaPersonID and BgFinanzplanID = @NewBgFinanzplanID

      -- Masterbudget
      select @BgBudgetID = BgBudgetID from BgBudget where BgFinanzplanID = @BgFinanzplanID and Masterbudget = 1
      SET @WhereClause = 'BgBudgetID = ' + CONVERT(VARCHAR, @BgBudgetID)
      EXEC spDuplicateRows 'BgBudget', @WhereClause,'BgFinanzplanID', @NewBgFinanzplanID
      SET @NewBgBudgetID = SCOPE_IDENTITY()

      -- Budgetpositionen
      SET @WhereClause = 'BgBudgetID = ' + CONVERT(VARCHAR, @BgBudgetID)
      EXEC spDuplicateRows 'BgPosition', @WhereClause,'BgBudgetID', @NewBgBudgetID--,'BaPersonID', @NewBaPersonID
    
      update BgPosition set BapersonID=@NewBaPersonID where BgBudgetID=@NewBgBudgetID and BaPersonID=@BaPersonID
      
      -- inkonsistent! ??

      fetch next from cFinanzplan into @BgFinanzplanID
    end
    close cFinanzplan
    deallocate cFinanzplan
    
    -- Loop über AiInkassoFall
    DECLARE cAiInkassofall cursor static for 
    select AiInkassofallID from AiInkassoFall where FaLeistungID = @FaLeistungID

    open cAiInkassofall
    fetch next from cAiInkassofall into @AiInkassofallID
    while @@fetch_status = 0 begin
    
      -- AiInkassofall duplizieren
      SET @WhereClause = 'AiInkassofallID = ' + CONVERT(VARCHAR, @AiInkassofallID)
      EXEC spDuplicateRows 'AiInkassoFall', @WhereClause,'FaLeistungID', @NewFaLeistungID
      SET @NewAiInkassofallID = SCOPE_IDENTITY()

      --  dbo.AiZahlung
      SET @WhereClause = 'AiInkassofallID = ' + CONVERT(VARCHAR, @AiInkassofallID)
      EXEC spDuplicateRows 'AiZahlung', @WhereClause,'AiInkassofallID', @NewAiInkassofallID
      
      --  dbo.AiAnzeige
      SET @WhereClause = 'AiInkassofallID = ' + CONVERT(VARCHAR, @AiInkassofallID)
      EXEC spDuplicateRows 'AiAnzeige', @WhereClause,'AiInkassofallID', @NewAiInkassofallID
      
      --  dbo.AiBetreibung
      SET @WhereClause = 'AiInkassofallID = ' + CONVERT(VARCHAR, @AiInkassofallID)
      EXEC spDuplicateRows 'AiBetreibung', @WhereClause,'AiInkassofallID', @NewAiInkassofallID
      
      --  dbo.AiForderung
      SET @WhereClause = 'AiInkassofallID = ' + CONVERT(VARCHAR, @AiInkassofallID)
      EXEC spDuplicateRows 'AiForderung', @WhereClause,'AiInkassofallID', @NewAiInkassofallID

    
      fetch next from cAiInkassofall into @AiInkassofallID
    end
    close cAiInkassofall
    deallocate cAiInkassofall
    
      -- Inkasso    
      SET @WhereClause = 'FaLeistungID = ' + CONVERT(VARCHAR, @FaLeistungID)
      EXEC spDuplicateRows 'IkRechtstitel', @WhereClause,'FaLeistungID', @NewFaLeistungID

      update IkRechtstitel set BaPersonID=@NewBaPersonID where FaLeistungID=@NewFaLeistungID and BapersonID=@BaPersonID

      -- Vormundschaftliche Massnahmen
      SET @WhereClause = 'FaLeistungID = ' + CONVERT(VARCHAR, @FaLeistungID)
      EXEC spDuplicateRows 'VmMassnahme', @WhereClause,'FaLeistungID', @NewFaLeistungID

      -- Vaterschaft
      SET @WhereClause = 'FaLeistungID = ' + CONVERT(VARCHAR, @FaLeistungID)
      EXEC spDuplicateRows 'VmVaterschaft', @WhereClause,'FaLeistungID', @NewFaLeistungID

      -- Siegelung
      SET @WhereClause = 'FaLeistungID = ' + CONVERT(VARCHAR, @FaLeistungID)
      EXEC spDuplicateRows 'VmSiegelung', @WhereClause,'FaLeistungID', @NewFaLeistungID

      -- Erbschaftsdienst
      SET @WhereClause = 'FaLeistungID = ' + CONVERT(VARCHAR, @FaLeistungID)
      EXEC spDuplicateRows 'VmErbschaftsdienst', @WhereClause,'FaLeistungID', @NewFaLeistungID

      -- Bewertung
      SET @WhereClause = 'FaLeistungID = ' + CONVERT(VARCHAR, @FaLeistungID)
      EXEC spDuplicateRows 'VmBewertung', @WhereClause,'FaLeistungID', @NewFaLeistungID

      -- Bericht
      SET @WhereClause = 'FaLeistungID = ' + CONVERT(VARCHAR, @FaLeistungID)
      EXEC spDuplicateRows 'VmBericht', @WhereClause,'FaLeistungID', @NewFaLeistungID


      fetch next from cFaLeistung into @FaLeistungID
  end
  close cFaLeistung
  deallocate cFaLeistung
  
  -- Aufräumhilfe
  SELECT 'Neue BaPersonID = ' + CONVERT(VARCHAR, @NewBaPersonID)
END;
GO