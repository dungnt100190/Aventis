SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmVmAntragEKSK;
GO

/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken für alle Felder der Tabelle VmAntragEKSK.
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwTmVmAntragEKSK;
=================================================================================================*/

CREATE VIEW dbo.vwTmVmAntragEKSK
AS
SELECT VmAntragEKSKID = ANT.VmAntragEKSKID,
       FaLeistungID   = ANT.FaLeistungID,
       Titel          = ANT.Titel,
       Begruendung    = ANT.Begruendung,
       DatumAntrag    = CONVERT(VARCHAR(10), ANT.DatumAntrag, 104),
       Antrag         = ANT.Antrag,
       GenehmigtEKSK  = CONVERT(VARCHAR(10), ANT.DatumGenehmigtEKSK, 104),
       --
       Autor          = USR.VornameName
FROM dbo.VmAntragEKSK  ANT WITH (READUNCOMMITTED)
  LEFT JOIN dbo.vwUser USR WITH (READUNCOMMITTED) ON USR.UserID = ANT.UserID;
GO