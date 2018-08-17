SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmFall;
GO
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE VIEW [dbo].[vwTmFall]
AS
SELECT 
  Fallnummer = F.FaFallID,
  FallaufnDat = CONVERT(VARCHAR,F.DatumVon,104),
  -- TODO: Unterstützungsdatum Beginn
  FaUnterstuetzungBeginnDat = CONVERT(VARCHAR, F.DatumVon, 104),
  FaPersonenAnzahl = ( SELECT COUNT(*) FROM dbo.FaFallPerson A WITH (READUNCOMMITTED) WHERE A.FaFallID = F.FaFallID ),
  AnzAktivePersMitLeistung = (	SELECT count(*) FROM dbo.FaFallPerson FPers WITH (READUNCOMMITTED)
								INNER JOIN dbo.vwPerson P ON FPers.BaPersonID = P. BaPersonID 
								WHERE P.PersonOhneLeistung = 0 AND (FPers.DatumBis IS Null OR FPers.DatumBis > GetDate()) AND FPers.FaFallID = F.FaFallID),
  AnzAktiveKinderMitLeistung = (SELECT count(*) FROM dbo.FaFallPerson FPers WITH (READUNCOMMITTED)
								INNER JOIN dbo.vwPerson P ON FPers.BaPersonID = P. BaPersonID 
								WHERE P.PersonOhneLeistung = 0 AND P.[Alter] < 18 AND (FPers.DatumBis IS Null OR FPers.DatumBis > GetDate()) AND FPers.FaFallID = F.FaFallID)

FROM dbo.FaFall F WITH (READUNCOMMITTED)

GO
GRANT SELECT ON [dbo].[vwTmFall] TO [tools_access]