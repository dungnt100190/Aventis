SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmRessourcenkarte
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwTmRessourcenkarte.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:58 $
  $Revision: 3 $
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
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwTmRessourcenkarte.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:03 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwTmRessourcenkarte]
AS

SELECT
  FAR.FaRessourcenkarteID,
  Sozialarbeiter			= IsNull(USR.FirstName, '') + IsNull(' ' + USR.LastName, ''),
  PersoenlicheRessourcen	= FAR.RessourcenPersoenlich,
  SozialeRessourcen			= RessourcenSozial,
  MaterielleRessourcen		= RessourcenMateriell,
  InfrastrukturelleRessourcen = RessourcenInfrastrukturell
FROM dbo.FaRessourcenkarte FAR WITH (READUNCOMMITTED)
  LEFT OUTER JOIN dbo.FaLeistung	LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = FAR.FaLeistungID
  LEFT OUTER JOIN dbo.XUser		USR WITH (READUNCOMMITTED) ON USR.UserID = LEI.UserID

GO
GRANT SELECT ON [dbo].[vwTmRessourcenkarte] TO [tools_access]