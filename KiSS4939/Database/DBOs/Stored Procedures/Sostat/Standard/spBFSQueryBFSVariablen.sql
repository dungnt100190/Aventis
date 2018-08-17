SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spBFSQueryBFSVariablen
GO
/*===============================================================================================
  $Revision: 11 $
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
=================================================================================================*/

CREATE PROCEDURE dbo.spBFSQueryBFSVariablen (
    @Erhebungsjahr INT,
    @UserID INT,
    @KlientID INT,
    @BFSLeistungsartCode INT,
    @NurDossiertraeger BIT,
    @ExcelExport BIT,
    @OrgUnitID INT = NULL,
    @Stichtag BIT = 1,
    @AnfZustCode BIT = 1
)
AS

SET NOCOUNT ON
DECLARE @SQL VARCHAR(7000)
DECLARE @value VARCHAR(1000)
DECLARE @BaseType VARCHAR(20)


-- temporäre Basistabelle, die später dynamisch durch die Anzahl darzustellender Variablen erweitert wird
CREATE table #tmp (
    BFSDossierID$       int NOT NULL,
    BFSDossierPersonID$ int,
    BFSPersonCode$      int,
    PersonIndex$        int,
    Jahr                int,
    Stichtag            varchar(4),
    [Dossier-Nr.]       int,
    FallNr              int,
    PersonenTyp         varchar(20),
    [Person-Nr.]        int,
    Person              varchar(200),
    AHVNummer           varchar(20))

IF @ExcelExport = 0 
BEGIN
    -- künstliche Info-Zeilen anlegen 
    INSERT #tmp (BFSDossierID$,Person) VALUES (-10,'Frage')
    INSERT #tmp (BFSDossierID$,Person) VALUES ( -9,'Variable Antragsteller')
    INSERT #tmp (BFSDossierID$,Person) VALUES ( -8,'Variable UE-Mitglied')
    INSERT #tmp (BFSDossierID$,Person) VALUES ( -7,'Variable HH-Mitglied')
    INSERT #tmp (BFSDossierID$,Person) VALUES ( -6,'Datentyp')
END

-- Lade alle zutreffenden Dossiers in die Basistabelle
INSERT #tmp
SELECT 
    BFSDossierID$       = DOS.BFSDossierID,
    BFSDossierPersonID$ = PER.BFSDossierPersonID,
    BFSPersonCode$      = PER.BFSPersonCode,
    PersonIndex$        = PER.PersonIndex,
    Jahr                = DOS.Jahr,
    Stichtag            = CASE DOS.Stichtag WHEN 1 THEN 'ja' ELSE 'nein' END,
    [Dossier-Nr.]       = DOS.FaLeistungID,
    FallNr              = LEI.FaFallID,
    PersonenTyp         = TYP.Text,
    [Person-Nr.]        = PER.BaPersonID,
    Person              = PER.PersonName,
    AHVNummer           = replace(PRS.AHVNummer,'.','')
FROM dbo.BFSDossier DOS
INNER JOIN dbo.BFSDossierPerson PER ON PER.BFSDossierID = DOS.BFSDossierID
INNER JOIN dbo.BFSDossierPerson ANT ON ANT.BFSDossierID = DOS.BFSDossierID 
    AND ANT.BFSPersonCode = 1 -- Antragsteller    
LEFT JOIN dbo.BFSLOVCode TYP ON TYP.LOVName = 'BFSPerson' AND TYP.Code = PER.BFSPersonCode
INNER JOIN dbo.FaLeistung LEI ON LEI.FaLeistungID = DOS.FaLeistungID
INNER JOIN dbo.BaPerson PRS ON PRS.BaPersonID = PER.BaPersonID
WHERE DOS.BFSLeistungsartCode = @BFSLeistungsartCode 
  AND DOS.Jahr = ISNULL(@Erhebungsjahr,DOS.Jahr)
  AND LEI.UserID = ISNULL(@UserID, LEI.UserID)
  AND ANT.BaPersonID = ISNULL(@KlientID,ANT.BaPersonID)
  AND (@NurDossiertraeger = 0 OR PER.BFSPersonCode = 1)
  AND (CASE WHEN @OrgUnitID IS NULL THEN 1 ELSE CASE WHEN EXISTS (SELECT TOP 1 1 FROM dbo.XOrgUnit_User OE WHERE OE.UserID = LEI.UserID AND OE.OrgUnitID = @OrgUnitID) THEN 1 ELSE 0 END END) = 1
  AND (DOS.Stichtag IN (
    CASE 
        WHEN (@AnfZustCode = 1 AND @Stichtag = 0) THEN 0
        WHEN (@AnfZustCode = 0 AND @Stichtag = 1) THEN 1
        WHEN (@AnfZustCode = 0 AND @Stichtag = 0) THEN NULL
        ELSE DOS.Stichtag
    END
  ))

-- Falls keine Dossiers selektiert, vorzeitiger Abbruch
IF (SELECT COUNT(*) FROM #tmp WHERE BFSDossierID$ > 0) = 0 
BEGIN
    SELECT
        BFSDossierID$,
        BFSDossierPersonID$,
        BFSPersonCode$,
        PersonIndex$,
        Jahr,
        Stichtag,
        [Dossier-Nr.],
        FallNr,
        PersonenTyp,
        [Person-Nr.],
        Person,
        AHVNummer
    FROM #tmp WHERE 1=2
    DROP table #tmp
    RETURN
END


-- Cursor über alle selektierten Variablen
DECLARE @BFSFrageID   int
DECLARE @Variable     varchar(10)
DECLARE @Frage        varchar(200)
DECLARE @BFSFeldCode  int
DECLARE @Feldtyp      varchar(20)
DECLARE @BFSFormat    varchar(20)
DECLARE @BFSLOVName   varchar(50)
DECLARE @UEVariable   varchar(10)
DECLARE @HHVariable   varchar(10)
DECLARE @ColName      varchar(200)

DECLARE C CURSOR FOR
    SELECT 
        BFSFrageID   = FRA.BFSFrageID,
        Variable     = FRA.Variable,
        Frage        = SubString(FRA.Frage,1,100),
        BFSFeldCode  = FRA.BFSFeldCode,
        FeldTyp      = FLD.Text,
        BFSFormat    = FRA.BFSFormat,
        BFSLOVName   = FRA.BFSLOVName,
        UEVariable   = IsNull(replace(UEV.Variable,'.1.','.x.'),''),
        HHVariable   = IsNull(replace(HHV.Variable,'.a.','.y.'),''),
        ColName      = 'V' + FRA.Variable + CASE 
            WHEN RIGHT(FRA.VariableExpandiert,1) BETWEEN 'a' AND 'z' THEN RIGHT(FRA.VariableExpandiert,1)
            ELSE ''
        END
  FROM dbo.BFSFrage FRA
    LEFT JOIN dbo.XLOVCode FLD on FLD.LOVName = 'BFSFeld' 
        AND FLD.Code = FRA.BFSFeldCode
    LEFT JOIN dbo.BFSFrage UEV on UEV.BFSKatalogVersionID = FRA.BFSKatalogVersionID 
        AND UEV.VariableAntragsteller = FRA.Variable 
        AND UEV.BFSPersonCode = 2 
        AND UEV.PersonIndex = 1
    LEFT JOIN BFSFrage HHV on HHV.BFSKatalogVersionID = FRA.BFSKatalogVersionID 
        AND HHV.VariableAntragsteller = FRA.Variable 
        AND HHV.BFSPersonCode = 3 
        AND HHV.PersonIndex = 1
    INNER JOIN dbo.BFSLOVCode       BLC ON BLC.LOVName = 'BFSLeistungsart'
                                       AND BLC.Code = @BFSLeistungsartCode
  WHERE FRA.BFSKatalogVersionID = dbo.fnBFSGetKatalogVersion(@Erhebungsjahr) 
    AND ',' + FRA.BFSLeistungsfilterCodes + ',' LIKE '%,' + CONVERT(VARCHAR, BLC.Filter) + '%,'
    AND (
      FRA.BFSPersonCode = 1 
      OR FRA.VariableAntragsteller IS NULL 
      OR FRA.Variable in ('5.1.01','5.a.2')
    )
  ORDER BY FRA.VariableExpandiert

OPEN C

FETCH NEXT FROM C INTO 
    @BFSFrageID,
    @Variable,
    @Frage,
    @BFSFeldCode,
    @Feldtyp,
    @BFSFormat,
    @BFSLOVName,
    @UEVariable,
    @HHVariable,
    @ColName
    
WHILE @@fetch_status = 0 
BEGIN

    -- dynamische Erweiterung der Basistabelle um eine Spalte
    -- Datentyp aufgrund tatsächlicher Werte in BFSWert bestimmen, anstelle von BFSFrage.BFSFeldCode
    SET @BaseType = NULL -- Zurücksetzen, damit nicht der vorherige Wert in der Variablen bleibt, falls keine rows gefunden werden
  
    SELECT TOP 1 @BaseType = BaseType
    FROM 
    (
      SELECT BaseType = CONVERT(varchar(20), SQL_VARIANT_PROPERTY(VAL.Wert, 'BaseType'))
      FROM dbo.BFSWert            VAL
        INNER JOIN dbo.BFSDossier DOS ON DOS.BFSDossierID = VAL.BFSDossierID
      WHERE VAL.BFSFrageID = @BFSFrageID 
        AND DOS.Jahr = @Erhebungsjahr
        AND VAL.Wert IS NOT NULL
      GROUP BY CONVERT(varchar(20), SQL_VARIANT_PROPERTY(VAL.Wert, 'BaseType'))
    ) TMP
    ORDER BY CASE BaseType 
               WHEN 'nvarchar' THEN 1 
               WHEN 'varchar' THEN 2
               WHEN 'bigint' THEN 3
               WHEN 'int' THEN 4
               ELSE 2
             END
             
    --print @BaseType + ' Variable ' + @Variable + ' ' + @Frage + ' ' + convert(varchar,@BFSFrageID)

    IF @ExcelExport = 1 
    BEGIN
        SET @ColName = @ColName + ' ' + @Frage
        SET @SQL = CASE @BaseType
            WHEN 'varchar' THEN 'alter table #tmp add [' + @ColName + '] varchar(200) collate database_default' -- Text
            WHEN 'int' THEN CASE 
                WHEN @BFSFeldCode in (7,8) THEN 'alter table #tmp add [' + @ColName + '] varchar(200) collate database_default'  -- Checkbox, Auswahl
                ELSE 'alter table #tmp add [' + @ColName + '] bigint' -- Zahl (Ganzzahl)
            END
            WHEN 'bigint' THEN CASE 
                WHEN @BFSFeldCode in (7,8) THEN 'alter table #tmp add [' + @ColName + '] varchar(200) collate database_default'  -- Checkbox, Auswahl
                ELSE 'alter table #tmp add [' + @ColName + '] bigint' -- Zahl (Ganzzahl)
            END
            WHEN 'money'    THEN 'alter table #tmp add [' + @ColName + '] money'        -- Zahl (Betrag)
            WHEN 'decimal'  THEN 'alter table #tmp add [' + @ColName + '] money'        -- Zahl (Betrag)
            WHEN 'datetime' THEN 'alter table #tmp add [' + @ColName + '] datetime'     -- Datum
            WHEN 'bit'      THEN 'alter table #tmp add [' + @ColName + '] varchar(20) collate database_default'  -- CheckBox
            ELSE 'alter table #tmp add [' + @ColName + '] sql_variant'                  -- übrige
        END
    END ELSE 
    BEGIN
        SET @SQL = 'alter table #tmp add [' + @ColName + '] sql_variant '
    END
    EXECUTE (@SQL)

    -- befüllen der Infozellen
    IF @ExcelExport = 0 
    BEGIN
        SET @SQL = 
            'update #tmp set [' + @ColName + '] = ''' + @Frage      + ''' where BFSDossierID$ = -10
             update #tmp set [' + @ColName + '] = ''' + @Variable   + ''' where BFSDossierID$ = -9
             update #tmp set [' + @ColName + '] = ''' + @UEVariable + ''' where BFSDossierID$ = -8
             update #tmp set [' + @ColName + '] = ''' + @HHVariable + ''' where BFSDossierID$ = -7
             update #tmp set [' + @ColName + '] = ''' + @Feldtyp    + ''' where BFSDossierID$ = -6'
        EXECUTE (@SQL)
    END

    -- setzen der Variablenwerte
    IF @ExcelExport = 1 
    BEGIN
        SET @value = CASE @BaseType
            WHEN 'varchar'  THEN 'convert(varchar(200),VAL.Wert)' -- Text
            WHEN 'int'      THEN 'convert(bigint,VAL.Wert) '      -- Zahl (Ganzzahl)
            WHEN 'bigint'   THEN 'convert(bigint,VAL.Wert) '      -- Zahl (Ganzzahl)
            WHEN 'money'    THEN 'convert(money,VAL.Wert)'        -- Zahl (Betrag)
            WHEN 'decimal'  THEN 'convert(money,VAL.Wert)'        -- Zahl (Betrag)
            WHEN 'datetime' THEN 'convert(datetime,VAL.Wert)'     -- Datum
            WHEN 'bit'      THEN 'convert(varchar(20),VAL.Wert)'  -- CheckBox
            ELSE 'convert(varchar(200),VAL.Wert)'                 -- übrige
        END
    END ELSE 
    BEGIN
        SET @value = 
            'case SQL_VARIANT_PROPERTY(Wert,''BaseType'')
                when ''varchar''  then convert(varchar(200),VAL.Wert)    -- Text
                when ''int''      then convert(varchar(20),VAL.Wert)     -- Ganzzahl
                when ''bigint''   then convert(varchar(20),VAL.Wert)     -- Ganzzahl
                when ''money''    then convert(varchar(20),VAL.Wert,0)   -- Betrag
                when ''datetime'' then convert(varchar(20),VAL.Wert,104) -- Datum
                when ''bit''      then convert(varchar(20),VAL.Wert)     -- Checkbox
                else convert(varchar(200),VAL.Wert)                      -- übrige
             end'
    END

    -- Werte für Antraggsteller
    SET @SQL = 'update T set [' + @ColName + '] = ' + @value + '
        from #tmp T
        inner join dbo.BFSFrage FRA on FRA.BFSFrageID = ' + CONVERT(varchar,@BFSFrageID) + '
        inner join dbo.BFSWert  VAL on VAL.BFSFrageID = FRA.BFSFrageID 
            and VAL.BFSDossierID = T.BFSDossierID$ 
            and VAL.BFSDossierPersonID = T.BFSDossierPersonID$ 
        where T.BFSPersonCode$ = 1'
    EXECUTE (@SQL)

    IF len(@UEVariable) > 0 
    BEGIN
        -- Werte für UE-Mitglieder
        SET @SQL = 'update T set [' + @ColName + '] = ' + @value + '
            from #tmp T
            inner join dbo.BFSFrage FRA on FRA.Variable = replace(''' + @UEVariable + ''',''x'',convert(varchar,PersonIndex$)) 
            inner join dbo.BFSWert  VAL on VAL.BFSFrageID = FRA.BFSFrageID 
                and VAL.BFSDossierID = T.BFSDossierID$ 
                and VAL.BFSDossierPersonID = T.BFSDossierPersonID$ 
            where T.BFSPersonCode$ = 2'
        EXECUTE (@SQL)
    END

    IF len(@HHVariable) > 0 
    BEGIN
        -- Werte für HH-Mitglieder
        SET @SQL = 'update T set [' + @ColName + '] = ' + @value + '
            from #tmp T
            inner join dbo.BFSFrage FRA on FRA.Variable = replace(''' + @HHVariable + ''',''y'',char(ascii(''a'') + PersonIndex$ -1)) 
            inner join dbo.BFSWert VAL on VAL.BFSFrageID = FRA.BFSFrageID 
                and VAL.BFSDossierID = T.BFSDossierID$ 
                and VAL.BFSDossierPersonID = T.BFSDossierPersonID$ 
            where T.BFSPersonCode$ = 3'
        EXECUTE (@SQL)
    END


    -- Wertelisten-Code ergänzen mit Text
    IF @BFSFeldCode in (7,8) 
    BEGIN -- Checkbox, Auswahl
        SET @SQL = 'update T set [' + @ColName + '] = convert(varchar,[' + @ColName + ']) + isnull('' - '' + LOV.Text,'''')
            from #tmp T
            left join dbo.BFSLOVCode LOV on LOV.LOVName = ''' + IsNull(@BFSLOVName,' ') + ''' and LOV.Code = convert(int,T.[' + @ColName + '])
            where BFSDossierID$ > 0'
        EXECUTE (@SQL)
    END

    FETCH NEXT FROM C INTO @BFSFrageID,@Variable,@Frage,@BFSFeldCode,@Feldtyp,@BFSFormat,@BFSLOVName,@UEVariable,@HHVariable,@ColName
END
CLOSE C
DEALLOCATE C

SELECT * 
FROM   #tmp
ORDER BY BFSDossierID$, BFSPersonCode$, PersonIndex$

DROP table #tmp

GO
