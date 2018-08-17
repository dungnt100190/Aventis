USE [KiSS4_BSS_Demo]
GO
/****** Object:  StoredProcedure [dbo].[spCopyFall]    Script Date: 03/11/2009 13:48:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--drop procedure CopyFall
ALTER procedure [dbo].[spCopyFall] (
   @BaPersonID int,
   @KlientNamePostfix varchar(10))
as

--declare @BaPersonID int
declare @BaWohnsituationID int
declare @FaLeistungID int
declare @FaUnterlagenID int
declare @FaDokumenteID int
declare @DocumentID int
declare @BgFinanzplanID int
declare @BgBudgetID int

declare @NewBaPersonID int
declare @NewBaWohnsituationID int
declare @NewFaFallID int
declare @NewFaLeistungID int
declare @NewFaUnterlagenID int
declare @NewFaDokumenteID int
declare @NewDocumentID int
declare @NewBgFinanzplanID int
declare @NewBgBudgetID int

declare @AiInkassofallID int
declare @NewAiInkassofallID int
declare @BaPersonRelationId int
declare @NewBaPersonRelationId int

declare @WhereClause varchar(400)

  -- Historisierungs-Trigger in BaPerson und BaAdresse 'überlisten'
  INSERT INTO HistoryVersion (AppUser) VALUES ('copyFall')
  
  -- BaPerson duplizieren  
  set @WhereClause = 'BaPersonID = ' + convert(varchar,@BaPersonID)
  exec spDuplicateRows 'BaPerson',@WhereClause
  set @NewBaPersonID = @@identity
  --update #FallPerson set NewBaPersonID = @NewBaPersonID where BaPersonID = @BaPersonID

  -- Kostenstelle  
  exec spKbKostenstelleAnlegen @NewBaPersonID

  -- Adressen
  set @WhereClause = 'BaPersonID = ' + convert(varchar,@BaPersonID)
  exec spDuplicateRows 'BaAdresse',@WhereClause,'BaPersonID',@NewBaPersonID

/* zusammengesetzter Primary-Key
  -- Ausbildung
  set @WhereClause = 'BaPersonID = ' + convert(varchar,@BaPersonID)
  exec spDuplicateRows 'BaArbeitAusbildung',@WhereClause,'BaPersonID',@NewBaPersonID
*/

/* zusammengesetzter Primary-Key
-- Gesundheit
  set @WhereClause = 'BaPersonID = ' + convert(varchar,@BaPersonID)
  exec spDuplicateRows 'BaGesundheit',@WhereClause,'BaPersonID',@NewBaPersonID
*/
  
  -- Mietvertrag
  set @WhereClause = 'BaPersonID = ' + convert(varchar,@BaPersonID)
  exec spDuplicateRows 'BaMietvertrag',@WhereClause,'BaPersonID',@NewBaPersonID

  -- Institutionen
  set @WhereClause = 'BaPersonID = ' + convert(varchar,@BaPersonID)
  exec spDuplicateRows 'BaPerson_Institution',@WhereClause,'BaPersonID',@NewBaPersonID
  
  -- Kinder kopieren, damit nicht plötzlich ein Kind 2 Mütter hat...
  declare cPerson_Relation cursor static for 
  select BaPersonID_2 from BaPerson_Relation where BaPersonID_1 = @BaPersonID
  open cPerson_Relation
  fetch next from cPerson_Relation into @BaPersonRelationId
  while @@fetch_status = 0 begin
	-- BaPerson duplizieren  
	set @WhereClause = 'BaPersonID = ' + convert(varchar,@BaPersonRelationId)
	exec spDuplicateRows 'BaPerson',@WhereClause
	set @NewBaPersonRelationId = @@identity
	
  -- Kostenstelle
	exec spKbKostenstelleAnlegen @NewBaPersonRelationId

	-- Postfix bei neuem Personenname setzen
	update BaPerson set Name = Name + ' ' + @KlientNamePostfix where BaPersonID = @NewBaPersonRelationId 
	
	-- Beziehung herstellen
	set @WhereClause = 'BaPersonID_1 = ' + convert(varchar,@BaPersonID) + ' AND BaPersonID_2 = ' + convert(varchar,@BaPersonRelationId)
	exec spDuplicateRows 'BaPerson_Relation',@WhereClause,'BaPersonID_1',@NewBaPersonID, 'BaPersonID_2',@NewBaPersonRelationId

	fetch next from cPerson_Relation into @BaPersonRelationId
   end
  close cPerson_Relation
  deallocate cPerson_Relation

  -- Eltern und andere Personen kopieren, damit nicht plötzlich ein Fallträger 2 Mütter hat...
  declare cPerson_Relation cursor static for 
  select BaPersonID_1 from BaPerson_Relation where BaPersonID_2 = @BaPersonID
  open cPerson_Relation
  fetch next from cPerson_Relation into @BaPersonRelationId
  while @@fetch_status = 0 begin
	-- BaPerson duplizieren  
	set @WhereClause = 'BaPersonID = ' + convert(varchar,@BaPersonRelationId)
	exec spDuplicateRows 'BaPerson',@WhereClause
	set @NewBaPersonRelationId = @@identity

	-- Postfix bei neuem Personenname setzen
	update BaPerson set Name = Name + ' ' + @KlientNamePostfix where BaPersonID = @NewBaPersonRelationId 
	
	-- Beziehung herstellen
	set @WhereClause = 'BaPersonID_2 = ' + convert(varchar,@BaPersonID) + ' AND BaPersonID_1 = ' + convert(varchar,@BaPersonRelationId)
	exec spDuplicateRows 'BaPerson_Relation',@WhereClause,'BaPersonID_2',@NewBaPersonID, 'BaPersonID_1',@NewBaPersonRelationId

	fetch next from cPerson_Relation into @BaPersonRelationId
   end
  close cPerson_Relation
  deallocate cPerson_Relation

/* zusammengesetzter Primary-Key
  -- Kostenstellen
  set @WhereClause = 'BaPersonID = ' + convert(varchar,@BaPersonID)
  exec spDuplicateRows 'BaPersonKbKostenstelle',@WhereClause,'BaPersonID',@NewBaPersonID
*/
  
  -- WV-Code
  set @WhereClause = 'BaPersonID = ' + convert(varchar,@BaPersonID)
  exec spDuplicateRows 'BaWVCode',@WhereClause,'BaPersonID',@NewBaPersonID
  
  -- Zahlungsweg
  set @WhereClause = 'BaPersonID = ' + convert(varchar,@BaPersonID)
  exec spDuplicateRows 'BaZahlungsweg',@WhereClause,'BaPersonID',@NewBaPersonID


-- Postfix bei neuem Personenname setzen
update BaPerson set Name = Name + ' ' + @KlientNamePostfix where BaPersonID = @NewBaPersonID


-- Loop über FaLeistung
declare cFaLeistung cursor static for 
select FaLeistungID from FaLeistung where BaPersonID = @BaPersonID

open cFaLeistung
fetch next from cFaLeistung into @FaLeistungID
while @@fetch_status = 0 begin

--FaLeistung - ProzessCode 200
  set @WhereClause = 'FaLeistungID = ' + convert(varchar,@FaLeistungID)
  
  -- Achtung: Fehler in spDuplicateRows, Replace() ersetzt innerhalb von Feldnamen
  --exec spDuplicateRows 'FaLeistung',@WhereClause,'BaPersonID,', @NewBaPersonID
  exec spDuplicateRows 'FaLeistung',@WhereClause,'SchuldnerBaPersonID',@NewBaPersonID,'BaPersonID',@NewBaPersonID, 'FaFallID',@NewBaPersonID
  set @NewFaLeistungID = @@identity
  --update FaLeistung SET SchuldnerBaPersonID=@NewBaPersonID where FaLeistungID=@NewFaLeistungID and isnull(SchuldnerBaPersonID,0)>0
  
  -- DynaValues (Aktennotizen, Besprechungen, Dokumente,...)
  set @WhereClause = 'FaLeistungID = ' + convert(varchar,@FaLeistungID)
  exec spDuplicateRows 'DynaValue',@WhereClause,'FaLeistungID',@NewFaLeistungID

-- BgSpezKonto (Ausgabekonto, Abzahlungskonto, Vorabzugskonto)
  set @WhereClause = 'FaLeistungID = ' + convert(varchar,@FaLeistungID)
  exec spDuplicateRows 'BgSpezkonto',@WhereClause,'FaLeistungID',@NewFaLeistungID, 'BaPersonID',@NewBaPersonID

 -- Loop über BgFinanplan
  declare cFinanzplan cursor static for 
  select BgFinanzplanID from BgFinanzplan where FaLeistungID = @FaLeistungID

  open cFinanzplan
  fetch next from cFinanzplan into @BgFinanzplanID
  while @@fetch_status = 0 begin

    -- FaFinanzplan duplizieren
    set @WhereClause = 'BgFinanzplanID = ' + convert(varchar,@BgFinanzplanID)
    exec spDuplicateRows 'BgFinanzplan',@WhereClause,'FaLeistungID',@NewFaLeistungID
    set @NewBgFinanzplanID = @@identity

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
    set @WhereClause = 'BgBudgetID = ' + convert(varchar,@BgBudgetID)
    exec spDuplicateRows 'BgBudget',@WhereClause,'BgFinanzplanID',@NewBgFinanzplanID
    set @NewBgBudgetID = @@identity

    -- Budgetpositionen
    set @WhereClause = 'BgBudgetID = ' + convert(varchar,@BgBudgetID)
    exec spDuplicateRows 'BgPosition',@WhereClause,'BgBudgetID',@NewBgBudgetID--,'BaPersonID',@NewBaPersonID
	
	update BgPosition set BapersonID=@NewBaPersonID where BgBudgetID=@NewBgBudgetID and BaPersonID=@BaPersonID
    
    -- inkonsistent! ??

    fetch next from cFinanzplan into @BgFinanzplanID
  end
  close cFinanzplan
  deallocate cFinanzplan
  
  -- Loop über AiInkassoFall
  declare cAiInkassofall cursor static for 
  select AiInkassofallID from AiInkassoFall where FaLeistungID = @FaLeistungID

  open cAiInkassofall
  fetch next from cAiInkassofall into @AiInkassofallID
  while @@fetch_status = 0 begin
	
	-- AiInkassofall duplizieren
    set @WhereClause = 'AiInkassofallID = ' + convert(varchar,@AiInkassofallID)
    exec spDuplicateRows 'AiInkassoFall',@WhereClause,'FaLeistungID',@NewFaLeistungID
    set @NewAiInkassofallID = @@identity

	--  dbo.AiZahlung
	set @WhereClause = 'AiInkassofallID = ' + convert(varchar,@AiInkassofallID)
    exec spDuplicateRows 'AiZahlung',@WhereClause,'AiInkassofallID',@NewAiInkassofallID
    
    --  dbo.AiAnzeige
	set @WhereClause = 'AiInkassofallID = ' + convert(varchar,@AiInkassofallID)
    exec spDuplicateRows 'AiAnzeige',@WhereClause,'AiInkassofallID',@NewAiInkassofallID
    
    --  dbo.AiBetreibung
	set @WhereClause = 'AiInkassofallID = ' + convert(varchar,@AiInkassofallID)
    exec spDuplicateRows 'AiBetreibung',@WhereClause,'AiInkassofallID',@NewAiInkassofallID
    
    --  dbo.AiForderung
	set @WhereClause = 'AiInkassofallID = ' + convert(varchar,@AiInkassofallID)
    exec spDuplicateRows 'AiForderung',@WhereClause,'AiInkassofallID',@NewAiInkassofallID

  
	fetch next from cAiInkassofall into @AiInkassofallID
  end
  close cAiInkassofall
  deallocate cAiInkassofall
  
	-- Inkasso	
	set @WhereClause = 'FaLeistungID = ' + convert(varchar,@FaLeistungID)
    exec spDuplicateRows 'IkRechtstitel',@WhereClause,'FaLeistungID',@NewFaLeistungID

	update IkRechtstitel set BaPersonID=@NewBaPersonID where FaLeistungID=@NewFaLeistungID and BapersonID=@BaPersonID

	-- Vormundschaftliche Massnahmen
	set @WhereClause = 'FaLeistungID = ' + convert(varchar,@FaLeistungID)
    exec spDuplicateRows 'VmMassnahme',@WhereClause,'FaLeistungID',@NewFaLeistungID

	-- Vaterschaft
	set @WhereClause = 'FaLeistungID = ' + convert(varchar,@FaLeistungID)
    exec spDuplicateRows 'VmVaterschaft',@WhereClause,'FaLeistungID',@NewFaLeistungID

	-- Siegelung
	set @WhereClause = 'FaLeistungID = ' + convert(varchar,@FaLeistungID)
    exec spDuplicateRows 'VmSiegelung',@WhereClause,'FaLeistungID',@NewFaLeistungID

	-- Erbschaftsdienst
	set @WhereClause = 'FaLeistungID = ' + convert(varchar,@FaLeistungID)
    exec spDuplicateRows 'VmErbschaftsdienst',@WhereClause,'FaLeistungID',@NewFaLeistungID

	-- Bewertung
	set @WhereClause = 'FaLeistungID = ' + convert(varchar,@FaLeistungID)
    exec spDuplicateRows 'VmBewertung',@WhereClause,'FaLeistungID',@NewFaLeistungID

	-- Bericht
	set @WhereClause = 'FaLeistungID = ' + convert(varchar,@FaLeistungID)
    exec spDuplicateRows 'VmBericht',@WhereClause,'FaLeistungID',@NewFaLeistungID


	fetch next from cFaLeistung into @FaLeistungID
end
close cFaLeistung
deallocate cFaLeistung


-- Aufräumhilfe
select 'neue BaPersonID = ' + convert(varchar,@NewBaPersonID)

