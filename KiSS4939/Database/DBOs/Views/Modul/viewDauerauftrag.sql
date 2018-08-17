SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject viewDauerauftrag
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Views/viewDauerauftrag.sql $
  $Author: Lloreggia $
  $Modtime: 16.11.09 14:19 $
  $Revision: 5 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Views/viewDauerauftrag.sql $
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

CREATE VIEW dbo.viewDauerauftrag
AS

SELECT  
  FBA.FbDauerauftragID, 
  FBA.Text, 
  FBA.BaPersonID, 
  FBA.SollKtoNr, 
  FBA.HabenKtoNr, 
  FBA.Betrag, 
  FBA.FbZahlungswegID, 
  FBA.DatumVon, 
  FBA.PeriodizitaetCode,
  FBA.WochentagCode, 
  FBA.Monatstag1, 
  FBA.Monatstag2, 
  FBA.VorWochenende,
  FBA.DatumBis, 
  FBA.ReferenzNummer, 
  FBA.Zahlungsgrund, 
  FBA.Status, 
  FBA.FbDauerauftragTS, 
  FBA.DauerauftragDokID,
  AuftragStatus = LOV.Text,
  LetzteAusfuehrung = (SELECT MAX(ValutaDatum) FROM dbo.FbBuchung WITH (READUNCOMMITTED) 
                       WHERE FbDauerauftragID = FBA.FbDauerauftragID),
  AuftragPeriodizitaet = LOV2.Text,
  Mandant      = PRS.NameVorname,
  HabenKtoName = FBK1.KontoName,
  SollKtoName  = FBK2.KontoName,
  PlzOrt       = PRS.WohnsitzPLZOrt,
  FbTeamID = (SELECT MAX(FbTeamID) FROM dbo.FbPeriode WITH (READUNCOMMITTED) 
              WHERE  BaPersonID = FBA.BaPersonID AND
                     PeriodeVon = (SELECT MAX(PeriodeVon) FROM dbo.FbPeriode WITH (READUNCOMMITTED) 
                                   WHERE  BaPersonID = FBA.BaPersonID))
FROM 
  dbo.FbDauerauftrag FBA WITH (READUNCOMMITTED) 
        INNER JOIN dbo.vwPerson         PRS  ON FBA.BaPersonID = PRS.BaPersonID
        INNER JOIN dbo.XLOVCode         LOV  WITH (READUNCOMMITTED) ON LOV.Code = FBA.Status AND LOV.LOVName = 'FbDauerAuftragStatus'
        INNER JOIN dbo.XLOVCode         LOV2 WITH (READUNCOMMITTED) ON LOV2.Code = FBA.PeriodizitaetCode AND LOV2.LOVName = 'ZahlungsPeriode'
        LEFT OUTER JOIN dbo.FbKonto          FBK1 WITH (READUNCOMMITTED) ON FBK1.KontoNr = FBA.HabenKtoNr AND FBK1.FbPeriodeID IS NULL
        LEFT OUTER JOIN dbo.FbKonto          FBK2 WITH (READUNCOMMITTED) ON FBK2.KontoNr = FBA.SollKtoNr AND FBK2.FbPeriodeID IS NULL


GO


