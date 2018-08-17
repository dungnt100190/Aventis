SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnGetFunktionsProfil
GO
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Anzeigen des Funktionprofils in CtlFaLeistung
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE function dbo.fnGetFunktionsProfil(@FaFallID int)
RETURNS varchar(100)
AS

BEGIN
  -- Familienprofil, wenn mindestens eine Person im Klientensystem
  -- 1. unter 16 Jahre alt ist und
  -- 2. zum Bezug von Leistungen berechtigt ist

  IF EXISTS (
    SELECT 1 FROM dbo.FaFallPerson FAP WITH (READUNCOMMITTED)
    INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) on PRS.BaPersonID = FAP.BaPersonID
      AND PRS.PersonOhneLeistung = 0
      -- 15.01.2009 : sozheo : Die Grenze soll neu 18 Jahre sein
      --and convert(int, ((datediff(dd,PRS.Geburtsdatum,getDate())+.5)/365.25)) < 16
      AND CONVERT(int, ((DateDiff(dd,PRS.Geburtsdatum,GetDate())+.5)/365.25)) < 18
    WHERE FAP.FaFallID = @FaFallID
      AND GetDate() BETWEEN IsNull(FAP.DatumVon,GetDate())
      AND IsNull(FAP.DatumBis,GetDate()) )
    RETURN 'Familienprofil'

  RETURN 'Erwachsenenprofil'
END
                 

--select dbo.fnGetFunktionsProfil(1200)
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
