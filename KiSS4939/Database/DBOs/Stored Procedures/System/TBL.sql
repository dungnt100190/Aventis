SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject TBL;
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Show the table-definition (columns, additional data) for given table
    @DBOName:    The name of table to get definiton from 
                 (or only unique first part of the name)
    @OutputMode: - Tables: 
                   - 0 = default (both: table and columns)
                   - 1 = only table
                   - 2 = only columns
  -
  RETURNS: Shows the definition of the table
=================================================================================================
  TEST:    EXEC dbo.TBL 'BaPerson';
           EXEC dbo.TBL 'BaPerson', 0;
           EXEC dbo.TBL 'BaPerson', 1;
           EXEC dbo.TBL 'BaPerson', 2;
           --
           TBL BaPerson;
           TBL BaPerson, 1;
=================================================================================================*/

CREATE PROCEDURE dbo.TBL
(
  @DBOName VARCHAR(200),
  @OutputMode INT = NULL
)
AS
BEGIN
  EXEC dbo.spDBO @DBOName, @OutputMode, 'U';
END;
GO