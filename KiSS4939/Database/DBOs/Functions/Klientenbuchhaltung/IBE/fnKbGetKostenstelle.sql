SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnKbGetKostenstelle
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description: Kostenstelle einer Person (CAR/SRK)
-------------------------------------------------------------------------------------------------
  SUMMARY: Liefert die aktuellste Kostenstelle einer Person
    @BaPersonID: Personen-Nr
  -
  RETURNS: <Kostenstellen-Nr>: <NameVorname>
  -
  TEST: SELECT dbo.fnKbGetKostenstelle(@BaPersonID)
=================================================================================================*/

CREATE FUNCTION dbo.fnKbGetKostenstelle
(
  @BaPersonID INT
)
RETURNS VARCHAR(100)
AS 
BEGIN
  RETURN (
    SELECT TOP 1 KST.Nr + ': ' + PRS.NameVorname
    FROM dbo.KbKostenstelle_BaPerson KSP WITH(READUNCOMMITTED)
      INNER JOIN dbo.KbKostenstelle  KST WITH(READUNCOMMITTED) ON KST.KbKostenstelleID = KSP.KbKostenstelleID
      INNER JOIN dbo.vwPersonSimple  PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = KSP.BaPersonID
    WHERE KSP.BaPersonID = @BaPersonID
    ORDER BY KSP.DatumVon DESC)
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
