SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnXConcatStrings
GO
/*===============================================================================================
  $Revision: 4 $
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

CREATE FUNCTION dbo.fnXConcatStrings
  (@originalString varchar(4000),
   @stringToAppend varchar(4000))
RETURNS varchar(8000)
AS
BEGIN
    DECLARE @validString varchar(8000)
    SET @stringToAppend = REPLACE( @stringToAppend, CHAR(39),CHAR(39) + ' + CHAR(39) + ' + CHAR(39) )
    SET @validString = @originalString + @stringToAppend
/*
    SET @validString = REPLACE( @validString,',','')
    SET @validString = REPLACE( @validString,'+','')
    SET @validString = REPLACE( @validString,'-','')
    SET @validString = REPLACE( @validString,'*','')
    SET @validString = REPLACE( @validString,'/','')
    SET @validString = REPLACE( @validString,'\','')
    SET @validString = REPLACE( @validString,' ','')
    SET @validString = REPLACE( @validString,'"','')
    SET @validString = REPLACE( @validString,'ç','')
    SET @validString = REPLACE( @validString,'%','')
    SET @validString = REPLACE( @validString,'@','')
    SET @validString = REPLACE( @validString,'#','')
    SET @validString = REPLACE( @validString,'&','')
    SET @validString = REPLACE( @validString,'=','')
    SET @validString = REPLACE( @validString,'?','')
    SET @validString = REPLACE( @validString,'!','')
    SET @validString = REPLACE( @validString,'(','')
    SET @validString = REPLACE( @validString,')','')
    SET @validString = REPLACE( @validString,'<','')
    SET @validString = REPLACE( @validString,'>','')
    SET @validString = REPLACE( @validString,'[','')
    SET @validString = REPLACE( @validString,']','')
    SET @validString = REPLACE( @validString,'{','')
    SET @validString = REPLACE( @validString,'}','')
    SET @validString = REPLACE( @validString,':','')
    SET @validString = REPLACE( @validString,';','')
    SET @validString = REPLACE( @validString,'ä','ae')
    SET @validString = REPLACE( @validString,'ö','oe')
    SET @validString = REPLACE( @validString,'ü','ue')
    SET @validString = REPLACE( @validString,'Ä','Ae')
    SET @validString = REPLACE( @validString,'Ö','Oe')
    SET @validString = REPLACE( @validString,'Ü','Ue')
*/
    
    RETURN (@validString)
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
