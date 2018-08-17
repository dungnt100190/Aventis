SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwKlientLeistung
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwKlientLeistung.sql $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwKlientLeistung.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwKlientLeistung]
AS
SELECT DISTINCT
       Rolle        = CASE LEI.FaProzessCode
                      WHEN 200 THEN 'Klient/in'
                      WHEN 201 THEN 'Klient/in'
                      WHEN 210 THEN 'Person mit zivilr. Massn.'
                      WHEN 300 THEN 'unterstützt'
                      WHEN 301 THEN 'Schuldner/in'
                      WHEN 302 THEN 'Schuldner/in'
                      WHEN 304 THEN 'Schuldner/in'
                      WHEN 402 THEN 'Anspruchsperson'
                      WHEN 404 THEN 'Anspruchsperson'
                      WHEN 405 THEN 'Gläubiger/in'
                      WHEN 406 THEN 'Gläubiger/in'
                      WHEN 407 THEN 'Gläubiger/in'
                      WHEN 408 THEN 'Schuldner/in'
                      WHEN 409 THEN 'Schuldner/in'
                      WHEN 410 THEN 'Schuldner/in'
                      WHEN 500 THEN 'Person mit zivilr. Massn.'
                      END,
       FaLeistungID = LEI.FaLeistungID,
       BaPersonID   = COALESCE(FAP.BaPersonID,FPP.BaPersonID,GLA.BaPersonID,LEI.BaPersonID)
FROM   dbo.FaLeistung LEI WITH (READUNCOMMITTED)
       LEFT OUTER JOIN dbo.FaFallPerson FAP WITH (READUNCOMMITTED) ON FAP.FaFallID = LEI.FaFallID AND
                                              LEI.FaProzessCode = 200
       LEFT OUTER JOIN dbo.BgFinanzplan FPL WITH (READUNCOMMITTED) ON FPL.FaLeistungID = LEI.FaLeistungID
       LEFT OUTER JOIN dbo.BgFinanzplan_BaPerson FPP WITH (READUNCOMMITTED) ON FPP.BgFinanzplanID = FPL.BgFinanzplanID AND
                                              FPP.IstUnterstuetzt = 1
       LEFT OUTER JOIN dbo.IkRechtstitel         RTI WITH (READUNCOMMITTED) ON RTI.FaLeistungID = LEI.FaLeistungID
       LEFT OUTER JOIN dbo.IkGlaeubiger          GLA WITH (READUNCOMMITTED) ON GLA.IkRechtstitelID = RTI.IkRechtstitelID

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
GRANT  SELECT  ON [dbo].[vwKlientLeistung]  TO [tools_access]
GO
