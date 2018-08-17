SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetMLText;
GO
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -

=================================================================================================
   TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnGetMLText
(
  @TID INT,
  @LanguageCode INT
)
RETURNS VARCHAR(2000) WITH SCHEMABINDING
AS 
BEGIN
  RETURN (SELECT TOP 1 Text
          FROM dbo.XLangText WITH (READUNCOMMITTED)
          WHERE TID = @TID 
            AND LanguageCode IN (1, @LanguageCode)
          ORDER BY LanguageCode DESC);
END;
GO