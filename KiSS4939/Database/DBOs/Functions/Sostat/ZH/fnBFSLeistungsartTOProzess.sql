SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBFSLeistungsartTOProzess;
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
=================================================================================================
  TEST:    SELECT dbo.fnBFSLeistungsartTOProzess(0);
=================================================================================================*/

CREATE FUNCTION fnBFSLeistungsartTOProzess
(
  @BFSLeistungsartCode INT
)
RETURNS INT
AS
BEGIN
	RETURN CASE @BFSLeistungsartCode 
				  WHEN  1 THEN 300   -- Sozialhilfe --> Regulärer Fall OHNE Vertrag
				  WHEN  2 THEN 300   -- Sozialhilfe --> Regulärer Fall MIT Vertrag
				  WHEN 25 THEN 405  -- ALBV        --> Alimentenbevorschussung
				  WHEN 23 THEN 407  -- KKBB        --> KKBB
         END;
END;
GO