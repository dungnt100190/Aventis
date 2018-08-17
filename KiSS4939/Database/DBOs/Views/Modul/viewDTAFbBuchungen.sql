SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject viewDTAFbBuchungen
GO
/*===============================================================================================
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
=================================================================================================*/
CREATE VIEW dbo.viewDTAFbBuchungen
AS

SELECT
   FBB.FbBuchungID,
   FBB.Buchungsdatum,
   FBK.FbKontoId,
   FBDZ.FbDTAZugangID,
   FBDZ.KbFinanzInstitutCode,
   FBB.ValutaDatum,
   FBB.BelegNr,
   FBB.IBAN, 
   DTABankId       = FBDZ.BaBankID,
   FBDZ.VertragNr,
   FBB.ZahlungsArtCode,
   Mandant         = DMP.Name + IsNull(' ' + DMP.Vorname, ''),
   FBK.KontoNr,
   FBK.KontoName,
   DTAKontoNr      = FBDZ.KontoNr,
   DTAZugang       = FBDZ.Name,
   FBB.Betrag,
   Kreditor        = IsNull(FBB.Name + ', ', '') + IsNull(FBB.Zusatz + ', ', '') + IsNull(FBB.PLZ + ' ', '') + IsNull(FBB.Ort + ' ', '') + IsNull('PCKontoNr : ' + FBB.PCKontoNr + ' ', '') + IsNull('BankKontoNr : ' + FBB.BankKontoNr + ' ', ''),
   KreditorName    = FBB.Name,
   KreditorStrasse = FBB.Strasse,
   KreditorZusatz  = FBB.Zusatz,
   KreditorPLZ     = FBB.PLZ,
   KreditorOrt     = FBB.Ort,
   Zahlungsgrund   = IsNull(CONVERT(varchar(200), FBB.ReferenzNummer), FBB.Zahlungsgrund),
   FBB.PCKontoNr,
   FBB.BankKontoNr,
   BankName        = FBBA.Name,
   BankStrasse     = FBBA.Strasse,
   BankPLZ         = FBBA.PLZ,
   BankOrt         = FBBA.Ort,
   FBBA.ClearingNr,
   StatusText      = IsNull(XLOV.Text, 'Nicht Übermittelt'),
   DTAB.Status,
   DTAB.FbDTAJournalID,
   DTAStatusEdit   = CASE (SELECT MAX(FbDTAJournalID)
                           FROM dbo.FbDTABuchung WITH (READUNCOMMITTED) 
                           WHERE FbBuchungID = DTAB.FbBuchungID)
                       WHEN DTAB.FbDTAJournalID
                       THEN 1
                       ELSE 0
                     END
FROM dbo.FbBuchung             FBB
  INNER JOIN dbo.FbKonto       FBK  WITH (READUNCOMMITTED) ON FBB.HabenKtoNr = FBK.KontoNr AND FBB.FbPeriodeID = FBK.FbPeriodeID
  INNER JOIN dbo.FbDTAZugang   FBDZ WITH (READUNCOMMITTED) ON FBK.FbDTAZugangID = FBDZ.FbDTAZugangID
  INNER JOIN dbo.FbPeriode     FBP  WITH (READUNCOMMITTED) ON FBK.FbPeriodeID = FBP.FbPeriodeID
  INNER JOIN dbo.BaPerson      DMP  WITH (READUNCOMMITTED) ON FBP.BaPersonID = DMP.BaPersonID
  INNER JOIN dbo.FbZahlungsweg FBZ  WITH (READUNCOMMITTED) ON FBB.FbZahlungswegID = FBZ.FbZahlungswegID
  INNER JOIN dbo.FbKreditor    FBKR WITH (READUNCOMMITTED) ON FBZ.FbKreditorID = FBKR.FbKreditorID
  LEFT OUTER JOIN dbo.FbDTABuchung  DTAB WITH (READUNCOMMITTED) ON FBB.FbBuchungID = DTAB.FbBuchungID
  LEFT OUTER JOIN dbo.XLOVCode      XLOV WITH (READUNCOMMITTED) ON DTAB.Status = XLOV.Code AND XLOV.LOVName = 'FbBuchungDTAStatus'
  LEFT OUTER JOIN dbo.BaBank        FBBA WITH (READUNCOMMITTED) ON FBZ.BaBankID = FBBA.BaBankID
WHERE FBK.FbDTAZugangID IS NOT NULL AND FBB.FbZahlungswegID IS NOT NULL

GO