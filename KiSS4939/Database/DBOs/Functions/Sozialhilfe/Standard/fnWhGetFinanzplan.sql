SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnWhGetFinanzplan
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/Sozialhilfe/fnWhGetFinanzplan.sql $
  $Author: Tabegglen $
  $Modtime: 17.08.10 16:41 $
  $Revision: 9 $
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

CREATE FUNCTION dbo.fnWhGetFinanzplan
 (@BgBudgetID      int,
  @GetDate         datetime)
RETURNS
  @OUTPUT TABLE (
    Rec_ID            int,
    Parent_ID         int,
    SortKey           int PRIMARY KEY,

    Style             int,

    BgKategorieCode   int,
    BgGruppeCode      int,

    Bezeichnung       varchar(500),
    Betrag            money,
    Total             money,

    Info              varchar(4000)
  )
AS
BEGIN
 INSERT INTO @OUTPUT
  SELECT * FROM dbo.fnWhGetFinanzplanIndent(@BgBudgetID, @GetDate, 1);
  RETURN
END
GO
