SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject viewFbBuchungCode
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Views/viewFbBuchungCode.sql $
  $Author: Lloreggia $
  $Modtime: 16.11.09 14:21 $
  $Revision: 4 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Views/viewFbBuchungCode.sql $
 * 
 * 4     16.11.09 14:29 Lloreggia
 * Header Updated
 * 
 * 2     25.06.09 13:07 Ckaeser
 * Alter2Create
 * 
 * 1     11.09.08 14:52 Aklopfenstein
 * VSS First
=================================================================================================*/

CREATE VIEW dbo.viewFbBuchungCode
AS

SELECT 
  FBC.FbBuchungCodeID, 
  FBC.Code, 
  FBC.BaPersonID, 
  FBC.SollKtoNr, 
  FBC.HabenKtoNr, 
  FBC.Betrag, 
  FBC.Text, 
  FBC.UserID, 
  FBC.FbBuchungCodeTS,
  SollKtoName =
                 (SELECT TOP 1 KontoName
                  FROM   dbo.FbPeriode P WITH (READUNCOMMITTED) 
                         INNER JOIN dbo.FbKonto K WITH (READUNCOMMITTED) ON K.FbPeriodeID = P.FbPeriodeID
                  WHERE  KontoNr = FBC.SollKtoNr
                  ORDER BY PeriodeVon DESC) ,
  HabenKtoName =
                 (SELECT TOP 1 KontoName
                  FROM   dbo.FbPeriode P WITH (READUNCOMMITTED) 
                         INNER JOIN dbo.FbKonto K WITH (READUNCOMMITTED) ON K.FbPeriodeID = P.FbPeriodeID
                  WHERE  KontoNr = FBC.HabenKtoNr
                  ORDER BY PeriodeVon DESC),
  Mandant   = PRS.NameVorname,
  PlzOrt    = PRS.WohnsitzPLZOrt,
  MTLogon   = USR.LogonName,
  MTName    = USR.LastName + IsNull(', ' + USR.FirstName,'')
FROM   
  dbo.FbBuchungCode FBC      WITH (READUNCOMMITTED) 
  LEFT  JOIN dbo.vwPerson         PRS  ON PRS.BaPersonID  = FBC.BaPersonID
  LEFT  JOIN dbo.XUser            USR  WITH (READUNCOMMITTED) ON USR.UserID      = FBC.UserID


GO
