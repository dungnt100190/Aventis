SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmAllgemein
GO
/*===============================================================================================
  $Author: lloreggia $
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
  $Log: /Database/KISS4_BSS_MasterDev/Views/vwTmAllgemein.sql $
 * 
 * 2     25.06.09 13:07 Ckaeser
 * Alter2Create
 * 
 * 1     11.09.08 14:52 Aklopfenstein
 * VSS First
=================================================================================================*/

CREATE VIEW dbo.vwTmAllgemein
AS

SELECT	
    KaIntegBildungID = IBI.KaIntegBildungID,
    Bemerkungen      = IBI.Bemerkung,
    Kursabschluss    = dbo.fnLOVText('KaInteBildKursAbschl', IBI.AbschlussCode),
    Kursaustritt     = IsNull(CONVERT(varchar, IBI.Austritt, 104), ''),
    Kurseintritt     = IsNull(CONVERT(varchar, IBI.Eintritt, 104), ''),
    Kursname         = KUR.Name
FROM dbo.KaIntegBildung IBI WITH (READUNCOMMITTED) 
  LEFT JOIN dbo.KaKurserfassung KUE WITH (READUNCOMMITTED) on KUE.KaKurserfassungID = IBI.KaKurserfassungID
  LEFT JOIN dbo.KaKurs KUR WITH (READUNCOMMITTED) on KUR.KaKursID = KUE.KursID;
GO