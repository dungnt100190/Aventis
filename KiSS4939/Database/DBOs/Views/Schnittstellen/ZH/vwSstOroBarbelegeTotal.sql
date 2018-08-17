SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwSstOroBarbelegeTotal
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Im Rahmen der Anpassung AERIS-Schnittstelle wurden die beiden bestehenden AERIS-Views
           für jeweil K- und W-Belege zu einer View zusammengefasst. Mittels UNION ALL
           Diese View wurde durch Frank Bestebreurtje erstellt
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================*/
CREATE VIEW dbo.vwSstOroBarbelegeTotal
AS


-- K-Barbelege
SELECT DISTINCT
  Quelle             = 'K-Barbelege',
  BelegNr            = BUC.PscdBelegNr,
  PersonNr           = PLT.BaPersonID,
  PersonName         = PLT.Name,
  PersonVorname      = PLT.Vorname,
  PersonGeburtsdatum = PLT.Geburtsdatum,
  PersonGeschlecht   = PLT.GeschlechtCode,
  AusbezahlenAn      = COALESCE(BUC.MitteilungZeile1 +
                                ISNULL(', ' + BUC.MitteilungZeile2, '') +
                                ISNULL(', ' + BUC.MitteilungZeile3, '') +
                                ISNULL(', ' + BUC.MitteilungZeile4, ''),
                                
                                BUC.BeguenstigtName + ', ' +
                                ISNULL(BUC.BeguenstigtStrasse + ', ','') +
                                ISNULL(BUC.BeguenstigtPLZ + ' ','') +
                                ISNULL(BUC.BeguenstigtOrt,''),
                                
                                ISNULL(PLT.Vorname + ' ', '') + PLT.Name + ', ' +
                                ISNULL(ADR1.Zusatz + ', ', '') +
                                ISNULL(ADR1.Postfach + ', ', '') +
                                ISNULL(ADR1.Strasse + ISNULL(' ' + ADR1.HausNr, '') + ', ', '') +
                                ISNULL(ADR1.PLZ + ' ', '') + 
                                ISNULL(ADR1.Ort, '')),
  Betrag             = BUC.Betrag,
  GueltigAb          = COALESCE(BUC.BarbelegGueltigVon, BUC.BarbelegDatum, BUC.ValutaDatum),
  GueltigBis         = DATEADD(DAY, 
                               CASE DATEPART(WEEKDAY, COALESCE(BUC.BarbelegGueltigVon, BUC.BarbelegDatum, BUC.ValutaDatum))
                                 WHEN 1 THEN 9 -- So
                                 WHEN 2 THEN 9 -- Mo
                                 WHEN 3 THEN 9 -- Di
                                 WHEN 4 THEN 9 -- Mi
                                 WHEN 5 THEN 11 -- Do
                                 WHEN 6 THEN 11 -- Fr
                                 WHEN 7 THEN 10 -- Sa
                               END,
                               COALESCE(BUC.BarbelegGueltigVon, BUC.BarbelegDatum, BUC.ValutaDatum)),
  VerbuchtDatum      = BUC.BarbelegAuszahlDatum
FROM dbo.KgBuchung          BUC  WITH(READUNCOMMITTED)
  INNER JOIN dbo.KgPeriode  PER  WITH(READUNCOMMITTED) ON PER.KgPeriodeID = BUC.KgPeriodeID
  INNER JOIN dbo.FaLeistung LEI  WITH(READUNCOMMITTED) ON LEI.FaLeistungID = PER.FaLeistungID
  INNER JOIN dbo.BaPerson   PLT  WITH(READUNCOMMITTED) ON PLT.BaPersonID = LEI.BaPersonID
  LEFT  JOIN dbo.BaAdresse  ADR1 WITH(READUNCOMMITTED) ON ADR1.BaPersonID = PLT.BaPersonID 
                                                      AND ADR1.AdresseCode = 1
                                                      AND GETDATE() BETWEEN ISNULL(ADR1.DatumVon, GETDATE()) AND ISNULL(ADR1.DatumBis, GETDATE())
WHERE BUC.KgAuszahlungsArtCode = 103 --Cash / Barauszahlung
  AND BUC.BarbelegDatum IS NOT NULL 
  AND BUC.KgBuchungStatusCode IN (3,4,5) -- Zahlauftrag erstellt, ausgedruckt oder fehlerhafter Zahlauftrag


UNION ALL

-- W-Barbelege
SELECT DISTINCT 
  Quelle             = 'W-Barbelege',
  BelegNr            = BUC.BelegNr,
  PersonNr           = PLT.BaPersonID,
  PersonName         = PLT.Name,
  PersonVorname      = PLT.Vorname,
  PersonGeburtsdatum = PLT.Geburtsdatum,
  PersonGeschlecht   = PLT.GeschlechtCode,
  AusbezahlenAn      = ISNULL(BUC.BeguenstigtName + ', ' + 
                              ISNULL(BUC.BeguenstigtStrasse + ', ','') +
                              ISNULL(BUC.BeguenstigtPLZ + ' ','') +
                              ISNULL(BUC.BeguenstigtOrt,''),
                              
                              ISNULL(PLT.Vorname + ' ', '') + PLT.Name + ', ' +
                              ISNULL(ADR1.Zusatz + ', ', '') +
                              ISNULL(ADR1.Postfach + ', ', '') +
                              ISNULL(ADR1.Strasse + ISNULL(' ' + ADR1.HausNr, '') + ', ', '') +
                              ISNULL(ADR1.PLZ + ' ', '') + 
                              ISNULL(ADR1.Ort, '')),
  Betrag             = BUC.Betrag,
  GueltigAb          = COALESCE(BUC.BarbelegGueltigVon, BUC.BarbelegDatum, BUC.ValutaDatum),
  GueltigBis         =  DATEADD(DAY, 
                                CASE DATEPART(WEEKDAY, COALESCE(BUC.BarbelegGueltigVon, BUC.BarbelegDatum, BUC.ValutaDatum))
                                  WHEN 1 THEN 2 -- So
                                  WHEN 2 THEN 2 -- Mo
                                  WHEN 3 THEN 2 -- Di
                                  WHEN 4 THEN 2 -- Mi
                                  WHEN 5 THEN 4 -- Do
                                  WHEN 6 THEN 4 -- Fr
                                  WHEN 7 THEN 3 -- Sa
                                END,
                                COALESCE(BUC.BarbelegGueltigVon, BUC.BarbelegDatum, BUC.ValutaDatum)),
  VerbuchtDatum      = BUC.BarbelegAuszahlDatum
FROM dbo.KbBuchung          BUC  WITH(READUNCOMMITTED)
  INNER JOIN dbo.FaLeistung LEI  WITH(READUNCOMMITTED) ON LEI.FaLeistungID = BUC.FaLeistungID
  INNER JOIN dbo.BaPerson   PLT  WITH(READUNCOMMITTED) ON PLT.BaPersonID = LEI.BaPersonID
  LEFT  JOIN dbo.BaAdresse  ADR1 WITH(READUNCOMMITTED) ON ADR1.BaPersonID = PLT.BaPersonID 
                                                      AND ADR1.AdresseCode = 1
                                                      AND GETDATE() BETWEEN ISNULL(ADR1.DatumVon, GETDATE()) AND ISNULL(ADR1.DatumBis, GETDATE())
WHERE BUC.KbAuszahlungsArtCode = 103 --Cash / Barauszahlung
  AND BUC.BarbelegDatum IS NOT NULL
  AND BUC.KbBuchungStatusCode IN (3,4,5) -- Zahlauftrag erstellt, ausgedruckt oder fehlerhafter Zahlauftrag 



GO
IF EXISTS(SELECT TOP 1 1 FROM sysusers WHERE name = 'soz_user_r_kiss')
BEGIN
  GRANT SELECT ON [dbo].[vwSstOroBarbelegeTotal] TO [soz_user_r_kiss];
END;
