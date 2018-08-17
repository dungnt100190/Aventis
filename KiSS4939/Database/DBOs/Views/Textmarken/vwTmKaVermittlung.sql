SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmKaVermittlung;
GO
/*===============================================================================================
  $Revision: 1$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken-View für Tabelle KaVermittlungSI / KaVermittlungBIBIP
  -
  RETURNS: 
  -
  TEST:    SELECT TOP 10 * FROM dbo.vwTmKaVermittlung;
=================================================================================================*/

CREATE VIEW dbo.vwTmKaVermittlung
AS
SELECT
  -----------------------------------------------------------------------------
  -- Allgemein
  -----------------------------------------------------------------------------
  BaPersonID = PRS.BaPersonID,
  -----------------------------------------------------------------------------
  -- SI
  -----------------------------------------------------------------------------
  --SIID                  = VSI.KaVermittlungSIID,
  SIZuweiserVornameName = SUS.VornameName,
  SIZuweiserAnrede      = CASE
                          WHEN SUS.GenderCode = 1 THEN 'Herr'
                          WHEN SUS.GenderCode = 2 THEN 'Frau'
                          ELSE ''
                        END,
  SIZuweiserSektion     = SUS.OrgEinheitName,
  -----------------------------------------------------------------------------
  -- BI/BIP
  -----------------------------------------------------------------------------
  --BIBIPID                  = VBI.KaVermittlungBIBIPID,
  BIBIPZuweiserVornameName = BUS.VornameName,
  BIBIPZuweiserAnrede      = CASE
                               WHEN BUS.GenderCode = 1 THEN 'Herr'
                               WHEN BUS.GenderCode = 2 THEN 'Frau'
                               ELSE ''
                             END,
  BIBIPZuweiserSektion     = BUS.OrgEinheitName

FROM dbo.BaPerson                  PRS WITH(READUNCOMMITTED)
  LEFT JOIN dbo.FaLeistung         LBI WITH(READUNCOMMITTED) ON LBI.BaPersonID = PRS.BaPersonID
                                                            AND LBI.FaProzessCode = 705 -- Vermittlung BIBIP
                                                            AND ISNULL(LBI.DatumBis, '99990101') > GETDATE()
  LEFT JOIN dbo.KaVermittlungBIBIP VBI WITH(READUNCOMMITTED) ON VBI.FaLeistungID = LBI.FaLeistungID
  LEFT JOIN dbo.vwUser             BUS                       ON BUS.UserID = -VBI.ZuweiserID
  LEFT JOIN dbo.FaLeistung         LSI WITH(READUNCOMMITTED) ON LSI.BaPersonID = PRS.BaPersonID
                                                            AND LSI.FaProzessCode = 706 -- Vermittlung SI
                                                            AND ISNULL(LSI.DatumBis, '99990101') > GETDATE()
  LEFT JOIN dbo.KaVermittlungSI    VSI WITH(READUNCOMMITTED) ON VSI.FaLeistungID = LSI.FaLeistungID
  LEFT JOIN dbo.vwUser             SUS                       ON SUS.UserID = -VSI.ZuweiserID
WHERE VSI.KaVermittlungSIID IS NOT NULL
   OR VBI.KaVermittlungBIBIPID IS NOT NULL;
GO
