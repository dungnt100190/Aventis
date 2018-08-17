SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnBFSLeistungsartTOProzess
GO
/*===============================================================================================
$Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
  @BaPersonID: Fallträger
  @Jahr: Auswertungsjahr
  @Monat: Monat

  -
  RETURNS: 
  -
  TEST:    
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
           WHEN 35 THEN 300   -- Sozialhilfe --> Kantonale Beihilfen zur Altersrente
           WHEN 36 THEN 300   -- Sozialhilfe --> Kantonale Beihilfen zur Invalidentrente
           WHEN 37 THEN 300   -- Sozialhilfe --> Kantonale Beihilfen zur Hinterlassenenrente
           WHEN 25 THEN 400   -- ALBV        --> Alimentenbevorschussung
           WHEN 40 THEN 600   -- Asyl (Flüchtlings-Fall)
           WHEN 50 THEN 600   -- Asyl (Asyl-Fall)
           --WHEN 23 THEN 407   -- KKBB        --> KKBB
         END;
END;
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
