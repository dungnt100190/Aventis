SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spCopyFall
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spCopyFall.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 11:08 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spCopyFall.sql $
 * 
 * 3     11.12.09 11:57 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 17:58 Rstahel
 * Abgleich der Stored Procedures aus KISS4_MASTER_ZH
=================================================================================================*/

--drop procedure CopyFall
CREATE PROCEDURE dbo.spCopyFall (
   @FaFallID int,
   @KlientNamePostfix varchar(10),
   @NewMALogon varchar(50))
AS

DECLARE @BaPersonID int
DECLARE @BaWohnsituationID int
DECLARE @FaLeistungID int
DECLARE @FaUnterlagenID int
DECLARE @FaDokumenteID int
DECLARE @DocumentID int
DECLARE @BgFinanzplanID int
DECLARE @BgBudgetID int

DECLARE @NewBaPersonID int
DECLARE @NewBaWohnsituationID int
DECLARE @NewFaFallID int
DECLARE @NewFaLeistungID int
DECLARE @NewFaUnterlagenID int
DECLARE @NewFaDokumenteID int
DECLARE @NewDocumentID int
DECLARE @NewBgFinanzplanID int
DECLARE @NewBgBudgetID int

DECLARE @WhereClause varchar(400)
DECLARE @NewUserID int

DECLARE @CreatorModifier VARCHAR(50);

SELECT @NewUserID = UserID FROM XUser WHERE LogonName = @NewMALogon

SET @CreatorModifier = dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID());

IF @NewUserID IS NULL BEGIN
  PRINT 'Benutzer ' + @NewMALogon + ' existiert nicht'
  RETURN
END

IF OBJECT_ID('tempdb..#FallPerson') IS NOT NULL
  DROP table #FallPerson

SELECT BaPersonID, NewBaPersonID = CONVERT(int,NULL)
INTO #FallPerson
FROM FaFallPerson
WHERE FaFallID = @FaFallID

-- Loop über alle Fallpersonen
DECLARE cPerson CURSOR STATIC FOR
  SELECT BaPersonID FROM #FallPerson

OPEN cPerson
FETCH NEXT FROM cPerson INTO @BaPersonID
WHILE @@fetch_status = 0 BEGIN

  -- BaPerson duplizieren
  SET @WhereClause = 'BaPersonID = ' + CONVERT(varchar,@BaPersonID)
  EXEC spDuplicateRows 'BaPerson',@WhereClause
  SET @NewBaPersonID = @@identity
  UPDATE #FallPerson SET NewBaPersonID = @NewBaPersonID WHERE BaPersonID = @BaPersonID

  -- Adressen
  SET @WhereClause = 'BaPersonID = ' + CONVERT(varchar,@BaPersonID)
  EXEC spDuplicateRows 'BaAdresse',@WhereClause,'BaPersonID',@NewBaPersonID

  -- Krankenkasse
  SET @WhereClause = 'BaPersonID = ' + CONVERT(varchar,@BaPersonID)
  EXEC spDuplicateRows 'BaKrankenversicherung',@WhereClause,'BaPersonID',@NewBaPersonID

  -- Arbeit
  SET @WhereClause = 'BaPersonID = ' + CONVERT(varchar,@BaPersonID)
  EXEC spDuplicateRows 'BaArbeit',@WhereClause,'BaPersonID',@NewBaPersonID

  -- Ersatzeinkommen
  SET @WhereClause = 'BaPersonID = ' + CONVERT(varchar,@BaPersonID)
  EXEC spDuplicateRows 'BaErsatzeinkommen',@WhereClause,'BaPersonID',@NewBaPersonID

  -- Vermögen
  SET @WhereClause = 'BaPersonID = ' + CONVERT(varchar,@BaPersonID)
  EXEC spDuplicateRows 'BaVermoegen',@WhereClause,'BaPersonID',@NewBaPersonID

  -- Zahlungsweg
  SET @WhereClause = 'BaPersonID = ' + CONVERT(varchar,@BaPersonID)
  EXEC spDuplicateRows 'Bazahlungsweg',@WhereClause,'BaPersonID',@NewBaPersonID

  -- WV-Code
  SET @WhereClause = 'BaPersonID = ' + CONVERT(varchar,@BaPersonID)
  EXEC spDuplicateRows 'BaWVCode',@WhereClause,'BaPersonID',@NewBaPersonID

  -- alte FallNr
  SET @WhereClause = 'BaPersonID = ' + CONVERT(varchar,@BaPersonID)
  EXEC spDuplicateRows 'BaAlteFallNr',@WhereClause,'BaPersonID',@NewBaPersonID

  FETCH NEXT FROM cPerson INTO @BaPersonID
END
CLOSE cPerson
DEALLOCATE cPerson

-- Präfix bei Personenname setzen
UPDATE BaPerson SET Name = Name + ' ' + @KlientNamePostfix WHERE BaPersonID in (SELECT NewBaPersonID FROM #FallPerson)

-- Beziehungen
INSERT BaPerson_Relation (BaPersonID_1,BaPersonID_2,BaRelationID,DatumVon,DatumBis,BaRelationQualitaetCode,Bemerkung)
SELECT TMP.NewBaPersonID,TMP2.NewBaPersonID,PRE.BaRelationID,PRE.DatumVon,PRE.DatumBis,PRE.BaRelationQualitaetCode,PRE.Bemerkung
FROM   #FallPerson TMP
       INNER JOIN BaPerson_Relation PRE  on PRE.BaPersonID_1 = TMP.BaPersonID
       INNER JOIN #FallPerson       TMP2 on TMP2.BaPersonID = PRE.BaPersonID_2

-- Loop über alle Wohnsituation
DECLARE cWohnsituation CURSOR STATIC FOR
  SELECT DISTINCT BaWohnsituationID
  FROM   #FallPerson TMP
         INNER JOIN BaWohnsituationPerson WOP on WOP.BaPersonID = TMP.BaPersonID

OPEN cWohnsituation
FETCH NEXT FROM cWohnsituation INTO @BaWohnsituationID
WHILE @@fetch_status = 0 BEGIN

  -- BaWohnsituation duplizieren
  SET @WhereClause = 'BaWohnsituationID = ' + CONVERT(varchar,@BaWohnsituationID)
  EXEC spDuplicateRows 'BaWohnsituation',@WhereClause
  SET @NewBaWohnsituationID = @@identity

  -- BaWohnsituationPerson duplizieren
  INSERT BaWohnsituationPerson (BaWohnsituationID,BaPersonID)
  SELECT @NewBaWohnsituationID, TMP.NewBaPersonID
  FROM   BaWohnsituationPerson WOP
         INNER JOIN #FallPerson TMP on TMP.BaPersonID = WOP.BaPersonID
  WHERE  BaWohnsituationID = @BaWohnsituationID

  FETCH NEXT FROM cWohnsituation INTO @BaWohnsituationID
END
CLOSE cWohnsituation
DEALLOCATE cWohnsituation

-- Fall duplizieren
SET @WhereClause = 'FaFallID = ' + CONVERT(varchar,@FaFallID)
EXEC spDuplicateRows 'FaFall',@WhereClause
SET @NewFaFallID = @@identity

UPDATE FAL
SET    BaPersonID = TMP.NewBaPersonID,
       UserID = @NewUserID
FROM   FaFall FAL
       INNER JOIN #FallPerson TMP on TMP.BaPersonID = FAL.BaPersonID
WHERE  FaFallID = @NewFaFallID

-- Fallpersonen duplizieren
INSERT FaFallPerson  (FaFallID,BaPersonID,DatumVon,DatumBis)
SELECT @NewFaFallID, TMP.NewBaPersonID, FAP.DatumVon, FAP.DatumBis
FROM   FaFallPerson FAP
       INNER JOIN #FallPerson TMP on TMP.BaPersonID = FAP.BaPersonID
WHERE  FaFallID = @FaFallID

--involvierte Personen
SET @WhereClause = 'FaFallID = ' + CONVERT(varchar,@FaFallID)
EXEC spDuplicateRows 'FaInvolviertePerson',@WhereClause,'FaFallID',@NewFaFallID

UPDATE T
SET    BaPersonID = TMP.NewBaPersonID
FROM   FaInvolviertePerson T
       INNER JOIN #FallPerson TMP on TMP.BaPersonID = T.BaPersonID
WHERE  FaFallID = @NewFaFallID

--involvierte Stellen
SET @WhereClause = 'FaFallID = ' + CONVERT(varchar,@FaFallID)
EXEC spDuplicateRows 'FaInvolvierteInstitution',@WhereClause,'FaFallID',@NewFaFallID

UPDATE T
SET    BaPersonID = TMP.NewBaPersonID
FROM   FaInvolvierteInstitution T
       INNER JOIN #FallPerson TMP on TMP.BaPersonID = T.BaPersonID
WHERE  FaFallID = @NewFaFallID

-- Fallführung
SET @FaLeistungID = NULL
SELECT @FaLeistungID = FaLeistungID FROM FaLeistung WHERE FaFallID = @FaFallID AND FaProzessCode = 200

IF @FaLeistungID IS NOT NULL BEGIN

  --FaLeistung - ProzessCode 200
  SET @WhereClause = 'FaFallID = ' + CONVERT(varchar,@FaFallID) + ' and FaProzessCode = 200'
  EXEC spDuplicateRows 'FaLeistung',@WhereClause,'FaFallID',@NewFaFallID
  SET @NewFaLeistungID = @@identity

  UPDATE T
  SET    BaPersonID = TMP.NewBaPersonID,
         UserID = @NewUserID
  FROM   FaLeistung T
         INNER JOIN #FallPerson TMP on TMP.BaPersonID = T.BaPersonID
  WHERE  FaLeistungID = @NewFaLeistungID

  --Aktennotizen
  SET @WhereClause = 'FaLeistungID = ' + CONVERT(varchar,@FaLeistungID)
  EXEC spDuplicateRows 'FaAktennotizen',@WhereClause,'FaLeistungID',@NewFaLeistungID

  --Ressourcenkarte
  SET @WhereClause = 'FaLeistungID = ' + CONVERT(varchar,@FaLeistungID)
  EXEC spDuplicateRows 'FaRessourcenkarte',@WhereClause,'FaLeistungID',@NewFaLeistungID

  UPDATE T
  SET    BaPersonID = TMP.NewBaPersonID
  FROM   FaRessourcenkarte T
         INNER JOIN #FallPerson TMP on TMP.BaPersonID = T.BaPersonID
  WHERE  FaLeistungID = @NewFaLeistungID

  --Aufträge/Auflagen/Verwarnungen
  SET @WhereClause = 'FaLeistungID = ' + CONVERT(varchar,@FaLeistungID)
  EXEC spDuplicateRows 'FaAbmachung',@WhereClause,'FaLeistungID',@NewFaLeistungID

  UPDATE T
  SET    Klient1ID = TMP1.NewBaPersonID,
         Klient2ID = TMP2.NewBaPersonID
  FROM   FaAbmachung T
         LEFT JOIN #FallPerson TMP1 on TMP1.BaPersonID = T.Klient1ID
         LEFT JOIN #FallPerson TMP2 on TMP2.BaPersonID = T.Klient2ID
  WHERE  FaLeistungID = @NewFaLeistungID

  --Teilleistungserbringer
  SET @WhereClause = 'FaLeistungID = ' + CONVERT(varchar,@FaLeistungID)
  EXEC spDuplicateRows 'FaTeilLeistungserbringer',@WhereClause,'FaLeistungID',@NewFaLeistungID

  --Voranmeldung
  SET @WhereClause = 'FaLeistungID = ' + CONVERT(varchar,@FaLeistungID)
  EXEC spDuplicateRows 'FaVoranmeldung',@WhereClause,'FaLeistungID',@NewFaLeistungID

  --Checkin
  SET @WhereClause = 'FaLeistungID = ' + CONVERT(varchar,@FaLeistungID)
  EXEC spDuplicateRows 'FaCheckin',@WhereClause,'FaLeistungID',@NewFaLeistungID

  --Assessment
  SET @WhereClause = 'FaLeistungID = ' + CONVERT(varchar,@FaLeistungID)
  EXEC spDuplicateRows 'FaAssessment',@WhereClause,'FaLeistungID',@NewFaLeistungID

  --Zielvereinbarungen
  SET @WhereClause = 'FaLeistungID = ' + CONVERT(varchar,@FaLeistungID)
  EXEC spDuplicateRows 'FaZielvereinbarung',@WhereClause,'FaLeistungID',@NewFaLeistungID

  UPDATE T
  SET    BaPersonID = TMP.NewBaPersonID
  FROM   FaZielvereinbarung T
         INNER JOIN #FallPerson TMP on TMP.BaPersonID = T.BaPersonID
  WHERE  FaLeistungID = @NewFaLeistungID

  --Abklärungen
  SET @WhereClause = 'FaLeistungID = ' + CONVERT(varchar,@FaLeistungID)
  EXEC spDuplicateRows 'FaAbklaerung',@WhereClause,'FaLeistungID',@NewFaLeistungID

  UPDATE T
  SET    BaPersonID = TMP.NewBaPersonID
  FROM   FaAbklaerung T
         INNER JOIN #FallPerson TMP on TMP.BaPersonID = T.BaPersonID
  WHERE  FaLeistungID = @NewFaLeistungID

  -- Loop über alle FaDokumente
  DECLARE cDokumente CURSOR STATIC FOR
    SELECT FaDokumenteID,DocumentID FROM FaDokumente WHERE FaLeistungID = @FaLeistungID

  OPEN cDokumente
  FETCH NEXT FROM cDokumente INTO @FaDokumenteID,@DocumentID
  WHILE @@fetch_status = 0 BEGIN

    IF @DocumentID IS NOT NULL BEGIN
      -- XDocument duplizieren
      SET @WhereClause = 'DocumentID = ' + CONVERT(varchar,@DocumentID)
      EXEC spDuplicateRows 'XDocument',@WhereClause
      SET @NewDocumentID = @@identity

      -- FaDokumente duplizieren
      SET @WhereClause = 'FaDokumenteID = ' + CONVERT(varchar,@FaDokumenteID)
      EXEC spDuplicateRows 'FaDokumente',@WhereClause,'DocumentID',@NewDocumentID,'FaLeistungID',@NewFaLeistungID
    END ELSE BEGIN
      -- FaDokumente duplizieren
      SET @WhereClause = 'FaDokumenteID = ' + CONVERT(varchar,@FaDokumenteID)
      EXEC spDuplicateRows 'FaDokumente',@WhereClause,'FaLeistungID',@NewFaLeistungID
    END

    FETCH NEXT FROM cDokumente INTO @FaDokumenteID,@DocumentID
  END
  CLOSE cDokumente
  DEALLOCATE cDokumente

  UPDATE T
  SET    BaPersonID = TMP.NewBaPersonID
  FROM   FaDokumente T
         INNER JOIN #FallPerson TMP on TMP.BaPersonID = T.BaPersonID
  WHERE  FaLeistungID = @NewFaLeistungID

  -- Loop über alle Unterlagenlisten
  DECLARE cUnterlagen CURSOR STATIC FOR
    SELECT FaUnterlagenID FROM FaUnterlagen WHERE FaLeistungID = @FaLeistungID

  OPEN cUnterlagen
  FETCH NEXT FROM cUnterlagen INTO @FaUnterlagenID
  WHILE @@fetch_status = 0 BEGIN

    -- FaUnterlagen duplizieren
    SET @WhereClause = 'FaUnterlagenID = ' + CONVERT(varchar,@FaUnterlagenID)
    EXEC spDuplicateRows 'FaUnterlagen',@WhereClause,'FaLeistungID',@NewFaLeistungID
    SET @NewFaUnterlagenID = @@identity

    -- FaUnterlagenliste duplizieren
    SET @WhereClause = 'FaUnterlagenID = ' + CONVERT(varchar,@FaUnterlagenID)
    EXEC spDuplicateRows 'FaUnterlagenliste',@WhereClause,'FaUnterlagenID',@NewFaUnterlagenID

    FETCH NEXT FROM cUnterlagen INTO @FaUnterlagenID
  END
  CLOSE cUnterlagen
  DEALLOCATE cUnterlagen

  --Fallverlaufsprotokoll (Leistungsebene)
  INSERT FaJournal(FaFallID,FaLeistungID,BaPersonID,UserID,Datum,FaJournalCode,Text,ManuellerEintrag)
  SELECT @NewFaFallID,@NewFaLeistungID,TMP.NewBaPersonID,UserID,Datum,FaJournalCode,Text,ManuellerEintrag
  FROM   FaJournal JOU
         INNER JOIN #FallPerson TMP on TMP.BaPersonID = JOU.BaPersonID
  WHERE  FaFallID = @FaFallID AND
         FaLeistungID = @FaLeistungID

END -- if @FaLeistungID is not null begin

-- wirtschaftliche Hilfe
SET @FaLeistungID = NULL
SELECT @FaLeistungID = FaLeistungID FROM FaLeistung WHERE FaFallID = @FaFallID AND FaProzessCode = 300

IF @FaLeistungID IS NOT NULL BEGIN

  --FaLeistung - ProzessCode 300
  SET @WhereClause = 'FaFallID = ' + CONVERT(varchar,@FaFallID) + ' and FaProzessCode = 300'
  EXEC spDuplicateRows 'FaLeistung',@WhereClause,'FaFallID',@NewFaFallID
  SET @NewFaLeistungID = @@identity

  UPDATE T
  SET    BaPersonID = TMP.NewBaPersonID,
         UserID = @NewUserID
  FROM   FaLeistung T
         INNER JOIN #FallPerson TMP on TMP.BaPersonID = T.BaPersonID
  WHERE  FaLeistungID = @NewFaLeistungID

  -- Loop über BgFinanplan
  DECLARE cFinanzplan CURSOR STATIC FOR
    SELECT BgFinanzplanID FROM BgFinanzplan WHERE FaLeistungID = @FaLeistungID

  OPEN cFinanzplan
  FETCH NEXT FROM cFinanzplan INTO @BgFinanzplanID
  WHILE @@fetch_status = 0 BEGIN

    -- FaFinanzplan duplizieren
    SET @WhereClause = 'BgFinanzplanID = ' + CONVERT(varchar,@BgFinanzplanID)
    EXEC spDuplicateRows 'BgFinanzplan',@WhereClause,'FaLeistungID',@NewFaLeistungID
    SET @NewBgFinanzplanID = @@identity

    -- BgFinanzplan_BaPerson duplizieren
    INSERT BgFinanzplan_BaPerson (BgFinanzplanID,BaPersonID,IstUnterstuetzt,ZahlungswegWieFT)
    SELECT @NewBgFinanzplanID,TMP.NewBaPersonID,FPP.IstUnterstuetzt,FPP.ZahlungswegWieFT
    FROM   BgFinanzplan_BaPerson FPP
           INNER JOIN #FallPerson TMP on TMP.BaPersonID = FPP.BaPersonID
    WHERE  FPP.BgFinanzplanID = @BgFinanzplanID

    --Masterbudget
    SELECT @BgBudgetID = BgBudgetID FROM BgBudget WHERE BgFinanzplanID = @BgFinanzplanID AND MasterBudget = 1
    SET @WhereClause = 'BgBudgetID = ' + CONVERT(varchar,@BgBudgetID)
    EXEC spDuplicateRows 'BgBudget',@WhereClause,'BgFinanzplanID',@NewBgFinanzplanID
    SET @NewBgBudgetID = @@identity

    --BgPosition
    SET @WhereClause = 'BgBudgetID = ' + CONVERT(varchar,@BgBudgetID)
    EXEC spDuplicateRows 'BgPosition',@WhereClause,'BgBudgetID',@NewBgBudgetID
    -- inkonsistent! 

    FETCH NEXT FROM cFinanzplan INTO @BgFinanzplanID
  END
  CLOSE cFinanzplan
  DEALLOCATE cFinanzplan

END -- if @FaLeistungID is not null begin

--Fallverlaufsprotokoll (Fallebene)
INSERT FaJournal(FaFallID,BaPersonID,UserID,Datum,FaJournalCode,Text,ManuellerEintrag)
SELECT @NewFaFallID,TMP.NewBaPersonID,UserID,Datum,FaJournalCode,Text,ManuellerEintrag
FROM   FaJournal JOU
       INNER JOIN #FallPerson TMP on TMP.BaPersonID = JOU.BaPersonID
WHERE  FaFallID = @FaFallID AND
       FaLeistungID IS NULL

IF OBJECT_ID('tempdb..#FallPerson') IS NOT NULL
  DROP table #FallPerson

-- Aufräumhilfe
SELECT 'neue FaFallID = ' + CONVERT(varchar,@NewFaFallID)
