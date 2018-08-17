SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject CopyLOV
GO
/*===============================================================================================
  $Revision: 4$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .

=================================================================================================*/
CREATE PROCEDURE dbo.CopyLOV 
(
  @LOVName  varchar(100),
  @TargetDB varchar(100) = 'KiSS4_Maskentest_ZH'
)
AS
DECLARE @SQL      nvarchar(4000)

SET @SQL      = '

set nocount on

if not exists (select 1 from ' + db_name() + '..XLOVCode where LOVName = ''' + @LOVName + ''') begin 
  raiserror (''LOV ' + @LOVName + ' existiert nicht in ' + db_name() + '.dbo.XLOV'',16,0)
  return 
end

begin tran

delete ' + @TargetDB + '..XLOVCode
where LOVName = ''' + @LOVName + '''

if @@error <> 0 begin rollback return end

delete ' + @TargetDB + '..XLOV
where LOVName = ''' + @LOVName + '''

if @@error <> 0 begin rollback return end

insert ' + @TargetDB + '..XLOV 
       (LOVName,Description,System,Expandable,ModulID,LastUpdated,
       Translatable,NameValue1,NameValue2,NameValue3)
select LOVName,Description,System,Expandable,ModulID,LastUpdated,
       Translatable,NameValue1,NameValue2,NameValue3
from   dbo.XLOV 
where  LOVName = ''' + @LOVName + '''

if @@error <> 0 begin rollback return end

insert ' + @TargetDB + '..XLOVCode
       (LOVName,Code,Text,TextTID,SortKey,ShortText,ShortTextTID,BFSCode,
       Value1,Value1TID,Value2,Value2TID,Value3,Value3TID,Description,System)
select LOVName,Code,Text,TextTID,SortKey,ShortText,ShortTextTID,BFSCode,
       Value1,Value1TID,Value2,Value2TID,Value3,Value3TID,Description,System
from   dbo.XLOVCode 
where  LOVName = ''' + @LOVName + '''

if @@error <> 0 begin rollback return end

commit
print ''LOV ' + @LOVName + ' copied from ' + db_name() + ' to ' + @TargetDB + ''''

--print @sql
exec (@sql)


