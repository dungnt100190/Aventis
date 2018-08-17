SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spXRefreshAllViews
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

CREATE PROCEDURE spXRefreshAllViews
AS

DECLARE @viewname varchar(200)
DECLARE @result table ([VIEW] varchar(250), Error varchar(2000))

DECLARE C CURSOR FOR
  SELECT Name FROM sysobjects
  WHERE xtype = 'V'
  ORDER BY Name

OPEN C
FETCH NEXT FROM C INTO @viewname
WHILE @@fetch_status = 0 BEGIN
  BEGIN try
    EXECUTE sp_refreshview @viewname
  END try
  BEGIN catch
    INSERT @result VALUES (@viewname,error_message())
  END catch
  FETCH NEXT FROM C INTO @viewname
END
CLOSE C
DEALLOCATE C

SELECT [VIEW] = 'Total Views: ' + (SELECT CONVERT(varchar,count(*)) FROM sysobjects WHERE xtype = 'V'),
       Result = 'Views with Errors: ' + (SELECT CONVERT(varchar,count(*)) FROM @result)
UNION ALL
SELECT * FROM @result
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
