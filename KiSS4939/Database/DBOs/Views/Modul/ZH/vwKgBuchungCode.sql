SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwKgBuchungCode
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwKgBuchungCode.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:54 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwKgBuchungCode.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwKgBuchungCode] AS

SELECT
BCO.KgBuchungCodeID,
BCO.Code,
BCO.SollKtoNr,
BCO.HabenKtoNr,
BCO.Betrag,
BCO.Text,
BCO.UserID,
BCO.KgBuchungCodeTS,
SollKtoName =		(		SELECT TOP 1 KontoName
										FROM   dbo.KgPeriode P WITH (READUNCOMMITTED)
										INNER JOIN dbo.KgKonto K WITH (READUNCOMMITTED) ON K.KgPeriodeID = P.KgPeriodeID
										WHERE  KontoNr = BCO.SollKtoNr --ergibt bei bestimmter Datenkonstelation Fehler (varchar und int feld)!!!
										ORDER BY PeriodeVon DESC),
HabenKtoName =  (		SELECT TOP 1 KontoName
										FROM   dbo.KgPeriode P WITH (READUNCOMMITTED)
										INNER JOIN dbo.KgKonto K WITH (READUNCOMMITTED) ON K.KgPeriodeID = P.KgPeriodeID
										WHERE  KontoNr = BCO.HabenKtoNr --ergibt bei bestimmter Datenkonstelation Fehler (varchar und int feld)!!!
										ORDER BY PeriodeVon DESC),
MTLogon   = USR.LogonName,
MTName    = USR.LastName + IsNull(', ' + USR.FirstName,'')
FROM   dbo.KgBuchungCode BCO WITH (READUNCOMMITTED)
       LEFT OUTER JOIN dbo.XUser USR WITH (READUNCOMMITTED) ON USR.UserID = BCO.UserID

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
GRANT  SELECT  ON [dbo].[vwKgBuchungCode]  TO [tools_access]
GO
