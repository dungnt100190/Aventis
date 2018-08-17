SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnCKKbuTransferlaufRunningCount;
GO
/*===============================================================================================
  $Revision: $
=================================================================================================  
-------------------------------------------------------------------------------------------------
  SUMMARY: Berechnet die Anzahl Transferläufe, die zur Zeit im Status "bin am arbeiten" sind.
  RETURNS: Anzahl Transferläufe, die im Status "bin am werklen" sind.
=================================================================================================
  TEST:    SELECT dbo.fnCKKbuTransferlaufRunningCount();
=================================================================================================*/

CREATE FUNCTION dbo.fnCKKbuTransferlaufRunningCount
(
)
RETURNS INT
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- <Block>
  -----------------------------------------------------------------------------
  
  DECLARE @Count INT;

  SELECT @Count = COUNT(*)
  FROM KbuTransferlauf
  WHERE KbuTransferlaufStatusCode NOT IN (3,4); --3:Cancelled, 4:Done

  RETURN @Count;

  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
END;
GO
