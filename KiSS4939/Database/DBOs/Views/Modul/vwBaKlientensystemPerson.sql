SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwBaKlientensystemPerson;
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Eine übergreifende View, um FaFallPerson aus ZH und Standard zu abstrahieren
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwBaKlientensystemPerson;
=================================================================================================*/

CREATE VIEW dbo.vwBaKlientensystemPerson
AS
SELECT FaFallID,
       BaPersonID,
       DatumVon,
       DatumBis
FROM dbo.FaFallPerson FFP WITH (READUNCOMMITTED);
GO
