SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnQryGetHashCode;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Query/fnQryGetHashCode.sql $
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to calculate an MD5 HashCode for the specified Report. For this,
           it calculates the HashCode for the following columns and adds the obtained values:
           - LayoutXML
           - ParameterXML
           - SQLQuery

   @QueryName:   The name of the report
  -
  RETURNS: The combined MD5 HashCode of the specified report
  -
  TEST:    SELECT [dbo].[fnQryGetHashCode]('ReportName') 
=================================================================================================*/

CREATE FUNCTION dbo.fnQryGetHashCode
(
  @QueryName VARCHAR(100)
)
RETURNS VARCHAR(200)
AS BEGIN

  -----------------------------------------------------------------------------
  -- init temp variables
  -----------------------------------------------------------------------------
  DECLARE @LayoutXML VARCHAR(8000),
          @ParameterXML VARCHAR(8000),
          @SQLQuery VARCHAR(8000),
          @HashLayoutXML VARBINARY(8000),
          @HashParameterXML VARBINARY(8000),
          @HashSQLQuery VARBINARY(8000);

  -----------------------------------------------------------------------------
  -- read values from report
  -----------------------------------------------------------------------------
  SELECT @LayoutXML = SUBSTRING(LayoutXML, 0, 8000),
         @ParameterXML = SUBSTRING(ParameterXML, 0, 8000),
         @SQLQuery = SUBSTRING(SQLQuery, 0, 8000)
  FROM XQuery
  WHERE QueryName = @QueryName;

  -----------------------------------------------------------------------------
  -- calculate hashvalues
  -----------------------------------------------------------------------------
  SELECT @HashLayoutXML = HashBytes('MD5', @LayoutXML),
         @HashParameterXML = HashBytes('MD5', @ParameterXML), 
         @HashSQLQuery = HashBytes('MD5', @SQLQuery);

  -----------------------------------------------------------------------------
  -- return calculated hashvalues
  -----------------------------------------------------------------------------
  DECLARE @Hashes VARCHAR(200);
  SET @Hashes = ISNULL(UPPER(sys.fn_varbintohexstr(@HashLayoutXML)),'') + '_' + ISNULL(UPPER(sys.fn_varbintohexstr(@HashParameterXML)),'') + '_' + ISNULL(UPPER(sys.fn_varbintohexstr(@HashSQLQuery)),'');

  RETURN @Hashes;
END
