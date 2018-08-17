SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spXAnonymizeField
GO
/*===============================================================================================
  Description
------------------------------------------------------------------------------------------------- 
  TEST:

    exec spXAnonymizeField 'BaArbeit','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'BaPerson','Geburtsdatum','','','','','','x'
    exec spXAnonymizeField 'GvAbklaerendeStelle','HausNr','','','{N}','1','99',''
    exec spXAnonymizeField 'DynaValue','Value','','DynaValue','','','',''


=================================================================================================
*/

  create procedure spXAnonymizeField (
  @Tablename varchar(100),
  @Columnname varchar(100),
  @delete varchar(1),
  @Lookup varchar(50),
  @Pattern varchar(100),
  @RandomFrom varchar(10),
  @RandomTo varchar(10),
  @RandomBirthdaySameAge varchar(1)
)
 
as
  begin try

  ---------------
  -- declarations
  ---------------
  declare @xtype int
  declare @sql nvarchar(4000)
  declare @valuesql nvarchar(4000)
  declare @start datetime
  declare @RowCount int
  declare @ParmDefinition nvarchar(500)
  declare @MaxID int
  declare @IDColumnname varchar(100)
  declare @Prms varchar(100)
  declare @Time varchar(10)
  declare @Duration_ms int
  declare @TableColumn varchar(100)
  declare @ValidationError varchar(200)
  
  ---------------
  -- Start
  ---------------
  set nocount on
  set @start = GetDate();
  set @time = substring(convert(varchar(20), @start, 120),12,99)
  set @TableColumn = isnull(@Tablename,'<no tablename>') + '.' + isnull(@Columnname,'<no Columnname>')
  set @Prms = substring(
        case when @delete = 'x' then ',delete' else '' end +
        case when len(isnull(@Lookup,'')) > 0 then ',Lookup: ' + @Lookup else '' end +
        case when len(isnull(@Pattern,'')) > 0  then ',Pattern: ' + @Pattern else '' end +
        case when len(isnull(@RandomFrom,'')) > 0  and
                  len(isnull(@RandomTo,'')) > 0  then ',' + @RandomFrom + '-' + @RandomTo else '' end +
        case when len(isnull(@RandomBirthdaySameAge,'')) > 0  then ',SameAge' + @Lookup else '' end,
        2,1000)
  
  ---------------
  -- Inconsisten ID Columns
  ---------------
  select @IDColumnname = 
    case @Tablename
    when 'BaArbeit' then 'BaArbeit'
    when 'FaAktennotizen' then 'FaAktennotizID'
    when 'BaPerson_NewodPerson' then 'BaPersonID'
    when 'BgFinanzplan_BaPerson' then 'BaPersonID'
    when 'XUser'          then 'UserID'
    else @Tablename + 'ID'
    end
  
  ----------------------------------------
  -- Validation checks
  ----------------------------------------
  
  set @ValidationError = null
  
  select @xtype = xtype from syscolumns where id = object_id(@Tablename) and name = @Columnname
  if @xtype is null begin
    set @ValidationError = 'not found in DB ' + DB_Name()
  end

  if @Pattern is not null begin 
    if charindex('{N}',@Pattern) > 0 and (@RandomFrom = 0 or @RandomTo = 0) begin
      set @ValidationError = ': missing RandomFrom or RandomTo'
    end
  end

  if @RandomBirthdaySameAge = 'x' and @xtype not in (42,61) begin
      set @ValidationError = ': has not expected datatype ''datetime''/''datetime2'
  end
  
  if @ValidationError is not null begin
    print 'Error: ' + @TableColumn + ' ' + @ValidationError
    insert MigLog ([Function],[Table],[Column],[Time],[Prms],[Error]) values ('spXAnonymizeField',@Tablename,@Columnname,@Time,@Prms,ERROR_MESSAGE())
    return
  end
  
  -----------------------
  -- delete field content
  -----------------------
  if @delete = 'x' begin
     set @sql = '
     update ' + @Tablename + ' 
     set ' +  @Columnname + ' = null

     select @RowCountOUT = @@RowCount
     '
  end
  
  -----------------------------------
  -- random birthday with same age as the original date
  -- @value: 
  --  - wenn Geburtstag im aktuellen Jahr schon vorbei:  TagHeute.MonatHeute.Geburtsjahr+1 - random(0-364) Tage 
  --  - wenn Geburtstag im aktuellen Jahr bevorstehend:  TagHeute.MonatHeute.Geburtsjahr - random(0-364) Tage 
  -----------------------------------
  if @RandomBirthdaySameAge = 'x' begin
    set @valuesql = '
      declare @d datetime
      begin try
        set @d = dateadd(d, -convert(int,rand() * 364), dbo.fnDateSerial(year(@oldvalue),month(getdate()),day(getdate())))
        if (month(getdate()) * 100 + day(getdate())) < (month(@oldvalue) * 100 + day(@oldvalue)) begin
          set @d = dateadd(year, 1, @d)
        end      
        set @value = @d
      end try
      begin catch
        set @value = null
      end catch'
  end
  
  -----------------------------------
  -- patterns
  -----------------------------------
  if len(@Pattern) > 0 begin
    if len(@RandomFrom) > 0 and len(@RandomTo) > 0 begin
      set @valuesql = '
       set @value = replace(''' + @Pattern + ''', ''{N}'', convert(varchar,' + @RandomFrom + ' + convert(int,rand() * (' + @RandomTo + ' - ' + @RandomFrom + '))))
      '
    end else begin
      set @valuesql = '
       set @value = ''' + @Pattern + '''
      '
    end

    set @valuesql = @valuesql + '
     declare @pos int
     set @pos = charindex(''x'',@value)
     while @pos > 0 begin
       set @value = substring(@value,1,@pos-1) + convert(varchar,convert(int,rand() * 10)) + substring(@value,@pos+1,10000)
       set @pos = charindex(''x'',@value)
     end
    '   
  end
  
  -----------------------------------
  -- Lookup Name, Strasse
  -----------------------------------
  
  if @Lookup in ('Strasse','Name') begin
    select @MaxID = max(RowID) from MigLookup where Lookup = @Lookup
    
    set @valuesql = '  
    
     set @value = null  
     select @value = newvalue from MigAssignment
     where Lookup = ''' + @Lookup + ''' and OldValue = @oldvalue
    
      if @value is null begin
        select @value = value from MigLookup
        where Lookup = ''' + @Lookup + ''' and RowID = (@id % ' + convert(varchar,@MaxID) + ') + 1
      
        insert MigAssignment (Lookup, OldValue, NewValue)
        values (''' + @Lookup + ''',@oldvalue, @value)
      end'
  end

  -----------------------------------
  -- Lookup Vorname
  -----------------------------------
  
  if @Lookup = 'Vorname' and @Tablename <> 'BaPerson' begin
    select @MaxID = max(RowID) from MigLookup where Lookup = 'VornameM'
  
    set @valuesql = '
    
     set @value = null  
     select top 1 @value = newvalue 
     from MigAssignment
     where Lookup = ''Vorname'' and OldValue = @oldvalue
    
     if @value is null begin
       select @value = value from MigLookup
       where Lookup in (''VornameM'',''VornameW'') and RowID = (@id % ' + convert(varchar,@MaxID) + ') + 1
      
       insert MigAssignment (Lookup, OldValue, NewValue)
       values (''Vorname'',@oldvalue, @value)
     end'
  end
  
  -----------------------------------
  -- Lookup VornameName
  -----------------------------------
  
  if @Lookup = 'VornameName' begin
    declare @MaxIDVorname varchar(200)
    declare @MaxIDName varchar(200)
    select @MaxIDVorname = max(RowID) from MigLookup where Lookup = 'VornameM'
    select @MaxIDName = max(RowID) from MigLookup where Lookup = 'Name'
  
    set @valuesql = '
     declare @name varchar(200)
     declare @vorname varchar(200)
    
     select top 1 @value = newvalue 
     from MigAssignment
     where Lookup = ''VornameName'' and OldValue = @oldvalue
    
     if @value is null begin
       select @vorname = value from MigLookup
       where Lookup in (''VornameM'',''VornameW'') and RowID = (@id % ' + convert(varchar,@MaxIDVorname) + ') + 1

       select @name = value from MigLookup
       where Lookup = ''Name'' and RowID = (@id % ' + convert(varchar,@MaxIDName) + ') + 1

       select @value = isnull(@vorname + '' '','''') + isnull(@name,'''')
       
       insert MigAssignment (Lookup, OldValue, NewValue)
       values (''VornameName'',@oldvalue, @value)
     end
     '   
  end
  
  -----------------------------------
  -- Lookup Vorname / BaPerson
  -----------------------------------
  
  if @Lookup = 'Vorname' and @Tablename = 'BaPerson' begin
    select @MaxID = max(RowID) from MigLookup where Lookup = 'VornameM'
  
    set @valuesql = '
    
     declare @AddOnInfo varchar(10)
     select @AddOnInfo = isnull(ShortText,''M'')
     from   BaPerson PRS
            left join XLOVCode GES on GES.LOVName = ''Geschlecht'' and GES.Code = PRS.GeschlechtCode
     where  BaPersonID = @ID
      
     set @value = null  
     select @value = newvalue 
     from MigAssignment
     where Lookup = ''Vorname'' and OldValue = @oldvalue
    
     if @value is null begin
       select @value = value from MigLookup
       where Lookup = ''Vorname''  + @AddOnInfo and RowID = (@id % ' + convert(varchar,@MaxID) + ') + 1
      
       insert MigAssignment (Lookup, OldValue, NewValue)
       values (''Vorname'', @oldvalue, @value)
     end'
  end
  
  -----------------------------------
  -- Lookup PLZ, Ort, PLZOrt
  -----------------------------------
  
  if @Lookup in ('PLZ','Ort','PLZOrt') begin
    
    set @valuesql = '
    
     set @value = null  
     select top 1 @value = newvalue 
     from MigAssignment
     where Lookup = ''' + @Lookup + ''' and OldValue = @oldvalue
    
     if @value is null begin
       select top 1 @value = case ''' + @Lookup + '''
                             when ''PLZ'' then convert(varchar,PLZ) 
                             when ''Ort'' then Name 
                             when ''PLZOrt'' then convert(varchar,PLZ) + '' '' + Name
                             end
       from BaPLZ
       where PLZ <= (1000 + convert(int,rand() * 9600))
       order by PLZ desc
      
       insert MigAssignment (Lookup, OldValue, NewValue)
       values (''' + @Lookup + ''', @oldvalue, @value)
     end'
  end

  -----------------------------------
  -- Lookup DokVorlage
  -----------------------------------
  
  if @Lookup = 'DokVorlage' begin
    set @sql = '
     update TBL
     set ' +  @Columnname + ' = isnull(DOT.DocTemplateName,''Dokument '' + convert(varchar,1000 + convert(int,rand() * 8999)))
     from ' + @Tablename + ' TBL
          left join XDocument    DOC on DOC.DocumentID = TBL.DocumentID
          left join XDocTemplate DOT on DOT.DocTemplateID = DOC.DocTemplateID

     select @RowCountOUT = @@RowCount
     '
  end

  -----------------------------------
  -- Lookup Kontoname / FbKonto
  -----------------------------------
  
  if @Lookup = 'Kontoname' and @Tablename = 'FbKonto' begin
    set @sql = '
     update KTO
     set Kontoname = isnull(KTO2.Kontoname, ''Konto '' + convert(varchar,1000 + convert(int,rand() * 8999)))
     from FbKonto KTO
          left join FbKonto KTO2 on KTO2.KontoNr = KTO.KontoNr and KTO2.FbPeriodeID is null
     where KTO.Kontoname <> isnull(KTO2.Kontoname,'''')

     select @RowCountOUT = @@RowCount
     '
  end

  -----------------------------------
  -- Lookup Kostenart
  -----------------------------------
  
  if @Lookup = 'Kostenart' begin
    set @sql = '
     update TBL
     set ' +  @Columnname + ' = isnull(KOA.Name,''Kostenart '' + convert(varchar,1000 + convert(int,rand() * 8999)))
     from ' + @Tablename + ' TBL
          left join BgKostenart KOA on KOA.BgKostenartID = TBL.BgKostenartID
     where TBL.' +  @Columnname + ' <> isnull(KOA.Name,'''')

     select @RowCountOUT = @@RowCount
     '
  end

  -----------------------------------
  -- Lookup Positionsart
  -----------------------------------
  
  if @Lookup = 'Positionsart' begin
    set @sql = '
     update TBL
     set ' +  @Columnname + ' = coalesce(BPA.Name, ''Buchungstext '' + convert(varchar,1000 + convert(int,rand() * 8999)))
     from ' + @Tablename + ' TBL
          left join BgPositionsart BPA on BPA.BgPositionsartID = TBL.BgPositionsartID
     where TBL.' +  @Columnname + ' <> isnull(BPA.Name,'''')

     select @RowCountOUT = @@RowCount
     '
  end

  -----------------------------------
  -- Lookup Text
  -----------------------------------
  
  if @Lookup = 'Text' begin
    select @MaxID = max(RowID) from MigLookup where Lookup = @Lookup

    set @sql = ' 
     update TBL
     set ' +  @Columnname + ' =  convert(varchar(8000), substring(LUP.Value,1,len(convert(varchar(8000),TBL.' +  @Columnname + '))))
     from ' + @Tablename + ' TBL
          inner join MigLookup LUP on LUP.Lookup = ''Text'' and LUP.RowID = (' + @IDColumnname + ' % ' + convert(varchar,@MaxID) + ') + 1
     where TBL.' +  @Columnname + ' is not null

     select @RowCountOUT = @@RowCount
     '
  end

  -----------------------------------
  -- Lookup DynaValue
  -----------------------------------
  
  if @Lookup = 'DynaValue' begin
    select @MaxID = max(RowID) from MigLookup where Lookup = 'Text'

    set @sql = ' 
     update VAL
     set  Value =  convert(varchar(8000), substring(LUP.Value,1,len(convert(varchar(8000),VAL.Value))))
     from DynaValue VAL
          inner join DynaField FLD on FLD.DynaFieldID = VAL.DynaFieldID
          inner join MigLookup LUP on LUP.Lookup = ''Text'' and LUP.RowID = (VAL.DynaValueID % ' + convert(varchar,@MaxID) + ') + 1
     where FLD.FieldCode in (2,3,15) and
          VAL.Value is not null

     select @RowCountOUT = @@RowCount
     '
  end

  -----------------------------------
  -- Pendenz
  -----------------------------------
  
  if @Lookup = 'Pendenz' begin
    set @sql = '
     declare @MaxRowID int
     select @MaxRowID = max(RowID) from MigLookup where Lookup = ''' + @Lookup + '''
    
     update TBL
     set ' +  @Columnname + ' =  LUP.Value
     from ' + @Tablename + ' TBL
          inner join MigLookup LUP on LUP.Lookup = ''' + @Lookup + ''' and LUP.RowID = (' + @IDColumnname + ' % @MaxRowID) + 1
     where TBL.' +  @Columnname + ' is not null

     select @RowCountOUT = @@RowCount
     '
  end

  -----------------------------------
  -- UserID
  -----------------------------------
  
  if @Lookup = 'UserID' and @Tablename = 'XUser' begin
    set @sql = '
     update XUser
     set ' +  @Columnname + ' =  convert(varchar,UserID)

     select @RowCountOUT = @@RowCount
     '
  end

  -----------------------------------
  -- build up cursor
  -----------------------------------
  
  if @valuesql is not null begin

   set @sql = '
   set nocount on

   declare @id int
   declare @value nvarchar(4000)
   declare @oldvalue nvarchar(4000)

   select @RowCountOUT = count(*) 
   from ' + @Tablename + '
   where ' + @Columnname + ' is not null 

   declare cur cursor for
   select ' + @IDColumnname + ', ' + @Columnname + '
   from ' + @Tablename + '
   where ' + @Columnname + ' is not null 
   order by 1

   open cur;
   fetch next from cur into @id, @oldvalue

   while  @@fetch_status = 0 begin
     ' + @valuesql + '
     
     update ' + @Tablename + '
     set    ' + @Columnname + ' = @value
     where  ' + @IDColumnname + ' = @id
     fetch next from cur into @id, @oldvalue
   end
 
   close cur
   deallocate cur
  '
  end

  -----------------------------------
  -- run anonymization
  -----------------------------------
  if @sql is null begin
    print 'Error: ' + @TableColumn + ': no sql script generated'
    return
  end

  -- print @sql
  
  set @ParmDefinition = N'@RowCountOUT int OUTPUT';
  exec sp_executesql @sql, @ParmDefinition, @RowCountOUT=@RowCount output;

  ---------------
  -- End-Log
  ---------------
  
  set @Duration_ms = datediff(ms, @start, GetDate())
  
  print 'spXAnonymizeField, ' + 
        left(@TableColumn + space(50),50) + ',  ' + 
        @Time + ',  ' + 
        right(space(6) + convert(varchar, @RowCount), 6) + ' rows,  ' +
        right(space(6) + convert(varchar(20), @Duration_ms), 6) + ' ms,  ' + 
        @Prms

  insert MigLog ([Function],[Table],[Column],[Time],[Rows],[Duration_ms],[Prms]) values ('spXAnonymizeField',@Tablename,@Columnname,@Time,@RowCount,@duration_ms,@Prms)

end try
begin catch
  print 'spXAnonymizeField,  ' + 
        left(@TableColumn + space(50),50) + ',  ' + 
        @Time + ',  ' + 
        'Error: ' + ERROR_MESSAGE()

  insert MigLog ([Function],[Table],[Column],[Time],[Prms],[Error]) values ('spXAnonymizeField',@Tablename,@Columnname,@Time,@Prms,ERROR_MESSAGE())
end catch
