SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnXPrepareForXML;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/System/fnXPrepareForXML.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:53 $
  $Revision: 2 $
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
  $Log: /Database/KiSS4_PI_MasterDev/Functions/System/fnXPrepareForXML.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:51 Aklopfenstein
 * 
 * 1     29.08.08 17:29 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnXPrepareForXML
(
  @XmlString varchar(4000)
)
returns varchar(4000)
AS
BEGIN
      -- prepare sql statement for xml code
    SET @XmlString = REPLACE( @XmlString,'&','&amp;')
    SET @XmlString = REPLACE( @XmlString,'<','&lt;')
    SET @XmlString = REPLACE( @XmlString,'>','&gt;')

    RETURN (@XmlString)
END
GO