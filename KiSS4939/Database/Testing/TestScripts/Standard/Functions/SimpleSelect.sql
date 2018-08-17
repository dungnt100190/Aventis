/*
Generiert dummes Select (mit NULL Parametern) aller Skalarfunktionen
 SELECT  
  TestSql  = REPLACE('SELECT ' + name+ ' = dbo.' + 
             name +
             '(' +
             REPLICATE('NULL,', (SELECT COUNT(1) -1  FROM sys.all_parameters WHERE object_id = OBJ.id)) +
             + ')', ',)', ')')
FROM sysobjects OBJ
WHERE xtype = 'FN' 
ORDER BY 1
*/


SELECT fn_diagramobjects = dbo.fn_diagramobjects()
SELECT fnAySpezkonto = dbo.fnAySpezkonto(NULL,NULL,NULL,NULL)
SELECT fnBaRelation = dbo.fnBaRelation(NULL,NULL)
SELECT fnBFSCode = dbo.fnBFSCode(NULL,NULL)
SELECT fnBFSGetMonatlicheZahlung = dbo.fnBFSGetMonatlicheZahlung(NULL,NULL,NULL,NULL,NULL)
SELECT fnBgGetValutaTermine = dbo.fnBgGetValutaTermine(NULL)
SELECT fnBgSpezkonto = dbo.fnBgSpezkonto(NULL,NULL,NULL,NULL)
SELECT fnCSVSplit = dbo.fnCSVSplit(NULL,NULL)
SELECT fnDateOf = dbo.fnDateOf(NULL)
SELECT fnDateSerial = dbo.fnDateSerial(NULL,NULL,NULL)
SELECT fnDatumUeberschneidung = dbo.fnDatumUeberschneidung(NULL,NULL,NULL,NULL)
SELECT fnDaysInMonthOf = dbo.fnDaysInMonthOf(NULL)
SELECT fnDynaFieldID = dbo.fnDynaFieldID(NULL)
SELECT fnFirstDayOf = dbo.fnFirstDayOf(NULL)
SELECT fnGetAge = dbo.fnGetAge(NULL,NULL)
SELECT fnGetAppCodeNamedValue = dbo.fnGetAppCodeNamedValue(NULL,NULL)
SELECT fnGetForeignKeyColumnsOfForeignKey = dbo.fnGetForeignKeyColumnsOfForeignKey(NULL)
SELECT fnGetKeyColumnsOfIndex = dbo.fnGetKeyColumnsOfIndex(NULL,NULL)
SELECT fnGetMLText = dbo.fnGetMLText(NULL,NULL)
SELECT fnGetPersonSichtbarFlag = dbo.fnGetPersonSichtbarFlag(NULL)
SELECT fnGetReferencedKeyColumnsOfForeignKey = dbo.fnGetReferencedKeyColumnsOfForeignKey(NULL)
SELECT fnGetSQLMLText = dbo.fnGetSQLMLText(NULL,NULL,NULL,NULL)
SELECT fnGleicherHaushalt = dbo.fnGleicherHaushalt(NULL,NULL,NULL)
SELECT fnIkAlimenteRunden = dbo.fnIkAlimenteRunden(NULL,NULL)
SELECT fnImage2VarChar = dbo.fnImage2VarChar(NULL)
SELECT fnKbCheckBelegDatum = dbo.fnKbCheckBelegDatum(NULL,NULL)
SELECT fnKbCheckBelegNr = dbo.fnKbCheckBelegNr(NULL,NULL,NULL,NULL,NULL)
SELECT fnKbGetKostenstelle = dbo.fnKbGetKostenstelle(NULL)
SELECT fnKbGetPeriodeID = dbo.fnKbGetPeriodeID(NULL,NULL,NULL,NULL,NULL)
SELECT fnKbGetPeriodeInfo = dbo.fnKbGetPeriodeInfo(NULL,NULL,NULL)
SELECT fnLastDayOf = dbo.fnLastDayOf(NULL)
SELECT fnLOVColumnListe = dbo.fnLOVColumnListe(NULL,NULL,NULL)
SELECT fnLOVMLColumnListe = dbo.fnLOVMLColumnListe(NULL,NULL,NULL,NULL)
SELECT fnLOVMLText = dbo.fnLOVMLText(NULL,NULL,NULL)
SELECT fnLOVShortText = dbo.fnLOVShortText(NULL,NULL)
SELECT fnLOVText = dbo.fnLOVText(NULL,NULL)
SELECT fnLOVTextListe = dbo.fnLOVTextListe(NULL,NULL)
SELECT fnMAX = dbo.fnMAX(NULL,NULL)
SELECT fnMIN = dbo.fnMIN(NULL,NULL)
SELECT fnOrgUnitOfUser = dbo.fnOrgUnitOfUser(NULL, 0)
SELECT fnReplaceWildcard = dbo.fnReplaceWildcard(NULL)
SELECT fnShGrundbedarfI = dbo.fnShGrundbedarfI(NULL)
SELECT fnShGrundbedarfI_Hg = dbo.fnShGrundbedarfI_Hg(NULL)
SELECT fnShGrundbedarfI_Person = dbo.fnShGrundbedarfI_Person(NULL,NULL)
SELECT fnShGrundbedarfII = dbo.fnShGrundbedarfII(NULL,NULL)
SELECT fnShGrundbedarfII_Hg = dbo.fnShGrundbedarfII_Hg(NULL,NULL)
SELECT fnShGrundbedarfII_Person = dbo.fnShGrundbedarfII_Person(NULL,NULL)
SELECT fnShGrundbedarfIZuschlag = dbo.fnShGrundbedarfIZuschlag(NULL)
SELECT fnShGrundbedarfIZuschlag_Hg = dbo.fnShGrundbedarfIZuschlag_Hg(NULL)
SELECT fnShWohnkosten = dbo.fnShWohnkosten(NULL, NULL)
SELECT fnShWohnkosten_Hg = dbo.fnShWohnkosten_Hg(NULL, NULL)
SELECT fnShWohnkosten_Person = dbo.fnShWohnkosten_Person(NULL,NULL)
SELECT fnSortLOVList = dbo.fnSortLOVList(NULL)
SELECT fnTnToPc = dbo.fnTnToPc(NULL)
SELECT fnUnterstuetzt = dbo.fnUnterstuetzt(NULL,NULL,NULL)
SELECT fnUserHasRight = dbo.fnUserHasRight(NULL,NULL)
SELECT fnUserMayReadFall = dbo.fnUserMayReadFall(NULL,NULL)
SELECT fnVmGetDateFrom = dbo.fnVmGetDateFrom(NULL)
SELECT fnVmGetLeistungID = dbo.fnVmGetLeistungID(NULL)
SELECT fnWhExistsBelegForPosition = dbo.fnWhExistsBelegForPosition(NULL)
SELECT fnWhGetBetragKontoauszug = dbo.fnWhGetBetragKontoauszug(NULL,NULL,NULL,NULL,NULL,NULL)
SELECT fnWhPosition_Permission = dbo.fnWhPosition_Permission(NULL,NULL)
SELECT fnXAHVNummer = dbo.fnXAHVNummer(NULL,NULL,NULL)
SELECT fnXCompareSQL_VARIANT = dbo.fnXCompareSQL_VARIANT(NULL,NULL)
SELECT fnXCompareTEXT = dbo.fnXCompareTEXT(NULL,NULL)
SELECT fnXConfig = dbo.fnXConfig(NULL,NULL)
SELECT fnXDbObjectMLMsg = dbo.fnXDbObjectMLMsg(NULL,NULL,NULL)
SELECT fnXKurzMonat = dbo.fnXKurzMonat(NULL)
SELECT fnXKurzMonatJahr = dbo.fnXKurzMonatJahr(NULL)
SELECT fnXModul10 = dbo.fnXModul10(NULL)
SELECT fnXMonat = dbo.fnXMonat(NULL)
SELECT fnXMonatJahr = dbo.fnXMonatJahr(NULL)


/*
Generiert dummes Select (mit NULL Parametern) aller Tabellenfunktionen
 SELECT  
  TestSql  = REPLACE('SELECT ''' + name+ ''', *  FROM dbo.' + 
             name +
             '(' +
             REPLICATE('NULL,', (SELECT COUNT(1)  FROM sys.all_parameters WHERE object_id = OBJ.id)) +
             + ')', ',)', ')')
FROM sysobjects OBJ
WHERE xtype = 'TF' 
ORDER BY 1
*/

SELECT 'fnAyGetBudget', *  FROM dbo.fnAyGetBudget(NULL,NULL)
SELECT 'fnAyPersonEinAustritt', *  FROM dbo.fnAyPersonEinAustritt()
SELECT 'fnBFSBudget', *  FROM dbo.fnBFSBudget(NULL,NULL,NULL)
SELECT 'fnBFSGetZahlungDatum', *  FROM dbo.fnBFSGetZahlungDatum(NULL,NULL,NULL)
SELECT 'fnDynaValue_GridRowID', *  FROM dbo.fnDynaValue_GridRowID(NULL,NULL,NULL)
SELECT 'fnDynaValue_LOV', *  FROM dbo.fnDynaValue_LOV(NULL,NULL,NULL)
SELECT 'fnDynaValue_LOVList', *  FROM dbo.fnDynaValue_LOVList(NULL,NULL,NULL)
SELECT 'fnDynaValue_Value', *  FROM dbo.fnDynaValue_Value(NULL,NULL,NULL)
SELECT 'fnGetStandardBookmarks', *  FROM dbo.fnGetStandardBookmarks(NULL)
SELECT 'fnKbAuszahlTermine', *  FROM dbo.fnKbAuszahlTermine(NULL,NULL)
SELECT 'fnKbGetRelevanteBuchungen', *  FROM dbo.fnKbGetRelevanteBuchungen(NULL,NULL,NULL,NULL,NULL)
SELECT 'fnKbGetWVReportData', *  FROM dbo.fnKbGetWVReportData(NULL,NULL)
SELECT 'fnKbGetZugehoerigeBelegNr', *  FROM dbo.fnKbGetZugehoerigeBelegNr(NULL)
SELECT 'fnKbWVEinzelposten_WVEinheitenProBuchung', *  FROM dbo.fnKbWVEinzelposten_WVEinheitenProBuchung(NULL,NULL,NULL,NULL,NULL,NULL,NULL)
SELECT 'fnKbWVGetBuchungKandidaten', *  FROM dbo.fnKbWVGetBuchungKandidaten(NULL,NULL)
SELECT 'fnSplit', *  FROM dbo.fnSplit(NULL,NULL)
SELECT 'fnWhGetBudget', *  FROM dbo.fnWhGetBudget(NULL,NULL)
SELECT 'fnWhGetBudgetUebersicht', *  FROM dbo.fnWhGetBudgetUebersicht(NULL,NULL)
SELECT 'fnWhGetFinanzplan', *  FROM dbo.fnWhGetFinanzplan(NULL,NULL)
SELECT 'fnWhKennzahlen', *  FROM dbo.fnWhKennzahlen(NULL)
SELECT 'fnXConfigChild', *  FROM dbo.fnXConfigChild(NULL,NULL)