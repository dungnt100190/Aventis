SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmKaVermittlungSI;
GO
/*===============================================================================================
  $Revision: 1$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken-View für Tabelle KaVermittlungSI
  -
  RETURNS: 
  -
  TEST:    SELECT TOP 10 * FROM dbo.vwTmKaVermittlungSI;
=================================================================================================*/

CREATE VIEW dbo.vwTmKaVermittlungSI
AS
SELECT FAL.FaLeistungID,
       KVS.KaVermittlungSIID,
       DatumEroeffnung           = FAL.DatumVon,
       DatumEroeffnungAbklaerung = (SELECT TOP 1 FAL2.DatumVon
                                    FROM FaLeistung FAL2 WITH(READUNCOMMITTED)
                                    WHERE FAL2.FaProzessCode = 701
                                      AND FAL2.BaPersonID = FAL.BaPersonID
                                      AND FAL2.DatumVon <= FAL.DatumVon
                                    ORDER BY FAL2.DatumVon DESC),
       DatumAbschluss            = KVS.AbschlussDatum,
	   ZustaendigKA              = USR.LastName + isnull(', ' + USR.FirstName,'')
FROM dbo.KaVermittlungSI KVS WITH(READUNCOMMITTED)
  INNER JOIN dbo.FaLeistung FAL WITH(READUNCOMMITTED) ON FAL.FaLeistungID = KVS.FaLeistungID	
  LEFT JOIN XUser USR ON USR.UserID = FAL.UserID 		
GO
