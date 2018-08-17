SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmKaVermittlungBIBIP;
GO
/*===============================================================================================
  $Revision: 2$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken-View für Tabelle KaVermittlungBIBIP
  -
  RETURNS: 
  -
  TEST:    SELECT TOP 10 * FROM dbo.vwTmKaVermittlungBIBIP;
=================================================================================================*/

CREATE VIEW dbo.vwTmKaVermittlungBIBIP
AS
SELECT FAL.FaLeistungID,
       KVB.KaVermittlungBIBIPID,
       DatumEroeffnung           = FAL.DatumVon,
       DatumEroeffnungAbklaerung = (SELECT TOP 1 FAL2.DatumVon
                                    FROM FaLeistung FAL2 WITH(READUNCOMMITTED)
                                    WHERE FAL2.FaProzessCode = 701
                                      AND FAL2.BaPersonID = FAL.BaPersonID
                                      AND FAL2.DatumVon <= FAL.DatumVon
                                    ORDER BY FAL2.DatumVon DESC),
       DatumAbschluss            = KVB.AbschlussDatum,
	   ZustaendigKA              = USR.LastName + isnull(', ' + USR.FirstName,'')
FROM dbo.KaVermittlungBIBIP KVB WITH(READUNCOMMITTED)
  INNER JOIN dbo.FaLeistung FAL WITH(READUNCOMMITTED) ON FAL.FaLeistungID = KVB.FaLeistungID	
  LEFT JOIN XUser USR ON USR.UserID = FAL.UserID 		
GO
