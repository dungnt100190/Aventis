/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Skript um Periode und Belegdatum von Ausgleichbuchungen von Zahlungsläufe zu korrigieren.
           z.B. #8983, #8961
=================================================================================================*/

SELECT BUCA.KbPeriodeID, BUCA.BelegDatum, *
-- UPDATE BUCA SET KbPeriodeID = 3, BelegDatum = '20121231'
FROM dbo.KbTransfer            TRF  WITH (READUNCOMMITTED)
  INNER JOIN dbo.KbBuchung     BUC  WITH (READUNCOMMITTED) ON BUC.KbBuchungID = TRF.KbBuchungID
  INNER JOIN dbo.KbOpAusgleich OPA  WITH (READUNCOMMITTED) ON OPA.OpBuchungID = BUC.KbBuchungID
  INNER JOIN dbo.KbBuchung     BUCA WITH (READUNCOMMITTED) ON BUCA.KbBuchungID = OPA.AusgleichBuchungID
WHERE KbZahlungslaufID IN (xxx)

GO
