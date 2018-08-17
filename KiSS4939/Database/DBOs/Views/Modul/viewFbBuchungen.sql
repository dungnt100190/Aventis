SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject viewFbBuchungen
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Views/viewFbBuchungen.sql $
  $Author: Lloreggia $
  $Modtime: 16.11.09 14:20 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Views/viewFbBuchungen.sql $
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

CREATE VIEW dbo.viewFbBuchungen
AS

-- set rowcount 1000
SELECT 
  FBU.FbBuchungID, 
  FBU.FbPeriodeID, 
  FBU.BuchungTypCode, 
  FBU.Code, 
  FBU.BelegNr, 
  FBU.BelegNrPos, 
  FBU.BuchungsDatum, 
  FBU.SollKtoNr, 
  FBU.HabenKtoNr, 
  FBU.Betrag, 
  FBU.Text, 
  FBU.ValutaDatum, 
  FBU.Zahlungsfrist, 
  FBU.BuchungStatusCode, 
  FBU.FbDauerauftragID, 
  FBU.ErfassungsDatum, 
  FBU.UserID, 
  FBU.FbZahlungswegID, 
  FBU.PCKontoNr, 
  FBU.BankKontoNr,
  FBU.IBAN,
  FBU.ZahlungsArtCode, 
  FBU.ReferenzNummer, 
  FBU.Zahlungsgrund, 
  FBU.Name, 
  FBU.Zusatz, 
  FBU.Strasse, 
  FBU.PLZ, 
  FBU.Ort, 
  FBU.Creator,
  FBU.Created,
  FBU.Modifier,
  FBU.Modified,
  FBU.FbBuchungTS,
  SollKtoName       = KTOS.KontoName,
  HabenKtoName      = KTOH.KontoName,
  SollKontoTypCode  = KTOS.KontoTypCode,
  HabenKontoTypCode = KTOH.KontoTypCode,
  Mandant = PRS.NameVorname,
  PRS.BaPersonID,
  PlzOrt     = PRS.WohnsitzPLZOrt,
  MTLogon    = USR1.LogonName,
  MTName     = IsNull(USR1.LastName,'') + IsNull(', ' + USR1.FirstName,''),
  ErfLogon   = USR2.LogonName,
  ErfName    = IsNull(USR2.LastName,'') + IsNull(', ' + USR2.FirstName,''),
  DTAB.Status,
  StatusText = XLOV.Text,
  PER.PeriodeStatusCode,
  PER.FbTeamID
FROM   
  dbo.FbBuchung FBU WITH (READUNCOMMITTED) 
  INNER JOIN dbo.FbKonto          KTOS WITH (READUNCOMMITTED) ON KTOS.FbPeriodeID = FBU.FbPeriodeID AND KTOS.KontoNr = FBU.SollKtoNr
  INNER JOIN dbo.FbKonto          KTOH WITH (READUNCOMMITTED) ON KTOH.FbPeriodeID = FBU.FbPeriodeID AND KTOH.KontoNr = FBU.HabenKtoNr
  INNER JOIN dbo.FbPeriode        PER  WITH (READUNCOMMITTED) ON PER.FbPeriodeID = FBU.FbPeriodeID
  INNER JOIN dbo.vwPerson         PRS  ON PRS.BaPersonID = PER.BaPersonID
  LEFT OUTER JOIN dbo.FaLeistung       LST  WITH (READUNCOMMITTED) ON LST.BaPersonID = PER.BaPersonID AND
                                     LST.ModulID IN (5, 29)
  LEFT OUTER JOIN dbo.XUser            USR1 WITH (READUNCOMMITTED) ON USR1.UserID = LST.UserID
  LEFT OUTER JOIN dbo.XUser            USR2 WITH (READUNCOMMITTED) ON USR2.UserID = FBU.UserID
  LEFT OUTER JOIN dbo.FbDTABuchung     DTAB WITH (READUNCOMMITTED) ON FBU.FbBuchungID = DTAB.FbBuchungID AND DTAB.FbDTAJournalID = (SELECT MAX(FbDTAJournalID) FROM dbo.FbDTABuchung WITH (READUNCOMMITTED) WHERE FbDTABuchung.FbBuchungID = FBU.FbBuchungID)
  LEFT OUTER JOIN dbo.XLOVCode         XLOV WITH (READUNCOMMITTED) ON DTAB.Status = XLOV.Code AND XLOV.LOVName = 'FbBuchungDTAStatus'
WHERE (LST.FaLeistungID IS NULL OR LST.FaLeistungID = dbo.fnVmGetLeistungID(PER.BaPersonID))


GO
