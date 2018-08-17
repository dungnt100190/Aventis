SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwBaNamen
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwBaNamen.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:53 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwBaNamen.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/


CREATE VIEW [dbo].[vwBaNamen]
AS

SELECT
		-UserID AS ID,
		'Mitarbeiter' AS Typ,
		LastName + IsNull(' ' + FirstName, '') AS Name,
		NULL AS Strasse,
		NULL AS Ort
FROM
		dbo.XUser WITH (READUNCOMMITTED)
UNION ALL
SELECT
		P.BaPersonID AS ID,
		'Person' AS Typ,
		P.Name + IsNull(' ' + P.Vorname, '') AS Name,
		A.Strasse + IsNull(' ' + A.HausNr, '') AS Strasse,
		A.PLZ + IsNull(' ' + A.Ort, '') AS Ort
FROM
		dbo.BaPerson P WITH (READUNCOMMITTED)
		LEFT OUTER JOIN dbo.BaAdresse A WITH (READUNCOMMITTED)
				ON A.BaPersonID=P.BaPersonID
				AND A.BaAdresseID = (		SELECT TOP 1 Q.BaAdresseID
																FROM dbo.BaAdresse Q WITH (READUNCOMMITTED)
																WHERE Q.BaPersonID = P.BaPersonID
																				AND Q.AdresseCode = 1  -- Wohnsitz
																				AND GetDate() BETWEEN IsNull(Q.DatumVon, GetDate())
																				AND IsNull(Q.DatumBis, GetDate())
														)
UNION ALL
SELECT
		B.BaInstitutionID AS ID,
		'Institution' AS Typ,
		B.Name AS Name,
		A.Strasse + IsNull(' ' + A.HausNr, '') AS Strasse,
		A.PLZ + IsNull(' ' + A.Ort, '') AS Ort
FROM
		dbo.BaInstitution B WITH (READUNCOMMITTED)
		LEFT OUTER JOIN dbo.BaAdresse A WITH (READUNCOMMITTED)
				ON A.BaInstitutionID=B.BaInstitutionID

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
GRANT  SELECT  ON [dbo].[vwBaNamen]  TO [tools_access]
GO
