SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBgGetKostenartIDByKontoNr;
GO
/*===============================================================================================
  Revision: 2
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Gets the ID from the BgKostenart having the given KontoNr
    @KontoNr the KontoNr to search
  -
  RETURNS: BgKostenartID
  -
  TEST: SELECT dbo.fnBgGetKostenartIDByKontoNr('682')
=================================================================================================*/
CREATE FUNCTION dbo.fnBgGetKostenartIDByKontoNr
(
  @KontoNr VARCHAR(10)
)
RETURNS INT
AS 
BEGIN

  DECLARE @BgKostenartID INT;

  SELECT @BgKostenartID = BgKostenartID
  FROM dbo.BgKostenart WITH (READUNCOMMITTED) 
  WHERE KontoNr = @KontoNr;

  RETURN (@BgKostenartID);
END;
GO