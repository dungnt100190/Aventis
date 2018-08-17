

SELECT
  'Fall-Nr' = MAX(LEI.FaFallID),
  'Beleg-Nr.' = MAX(KBB.BelegNr),
  'Klientin Name, Vorname' = dbo.ConcDistinct(PER.NameVorname),
  'Klientin Personennr.' = dbo.ConcDistinct(convert(varchar(10),PER.BaPersonID)),
  'Verw. Von' = CONVERT(varchar(20), MIN(KBP.VerwPeriodeVon), 104),
  'Verw. Bis' = CONVERT(varchar(20), MAX(KBP.VerwPeriodeBis), 104),
  'Fälligkeit' = CONVERT(varchar(20), MAX(KBB.ValutaDatum), 104),
  'LA' = MAX(KOS.KontoNr),
  'Buchungstext' = MAX(POS.Buchungstext),
  'Soll' = MAX(KBB.Betrag),
--    'Diff.' = ,
  'Debitor' = MAX(ISNULL(SCP.DisplayText, SCI.InstitutionName)),
  'Debitor_Zusatz' = MAX(SCI.Adresse),
  'SZ_FV' = MAX(USRF.SozialzentrumKurz),
  'QT_FV' = MAX(USRF.OrgUnitShort),
  'SA_FV' = MAX(USRF.NameVorname),
  'SF-LV' = MAX(USR.SozialzentrumKurz),
  'QT_LV' = MAX(USR.OrgUnitShort),
  'SA_LV' = MAX(USR.NameVorname),
	kbp.kbbuchungbruttoid
FROM dbo.KbBuchungBruttoPerson    KBP WITH (READUNCOMMITTED)
	INNER JOIN dbo.KbBuchungBrutto  KBB WITH (READUNCOMMITTED) ON KBB.KbBuchungBruttoID = KBP.KbBuchungBruttoID
	INNER JOIN dbo.FaLeistung       LEI	WITH (READUNCOMMITTED) ON LEI.FaLeistungID = KBB.FaLeistungID AND LEI.ModulID = 3 -- W
	INNER JOIN dbo.FaFall           FAL	WITH (READUNCOMMITTED) ON LEI.FaFallID = FAL.FaFallID
	INNER JOIN dbo.vwUser           USR WITH (READUNCOMMITTED) ON LEI.UserID = USR.UserID
	INNER JOIN dbo.vwUser           USRF WITH (READUNCOMMITTED) ON FAL.UserID = USRF.UserID
  INNER JOIN dbo.BgPosition		POS WITH (READUNCOMMITTED) ON POS.BgPositionID = KBP.BgPositionID
    AND POS.VerwaltungSD = 1
	INNER JOIN dbo.BgKostenart		KOS WITH (READUNCOMMITTED) ON KOS.BgKostenartID = KBB.BgKostenartID
  LEFT JOIN dbo.vwInstitution SCI WITH (READUNCOMMITTED) ON SCI.BaInstitutionID = KBP.Schuldner_BaInstitutionID
  LEFT JOIN dbo.vwPerson      SCP WITH (READUNCOMMITTED) ON SCP.BaPersonID = KBP.Schuldner_BaPersonID
  LEFT JOIN dbo.vwPerson      PER WITH (READUNCOMMITTED) ON PER.BaPersonID = KBP.BaPersonID
  OUTER APPLY dbo.fnBruttoToNettos(KBP.KbBuchungBruttoPersonID, KBP.BgPositionID, KBB.Betrag, KBB.ValutaDatum) AS NET
WHERE
	KBB.Abgetreten = 1 AND KBB.KbBuchungStatusCode = 3 -- NOT IN (7, 8, 9, 6, 10)
  AND KOS.KontoNr IN
  (
    /*736, 750, 753, 754, 755, 756, 757, 758, 760, 762,
    820, 821, 822, 830, 831, 832, 833, 834, 850, 851, 852, 853, 854, 855, 863, 864, 870, 871, 872, 873, 874, 875, 876, 877, 880, 881*/
736,
750, 753, 754, 755, 756, 757, 758, 
760, 762,
820, 821, 822, 
830, 831, 832, 833, 834,
850, 851, 852, 853, 854, 855,
863, 864,
870, 871, 872, 873, 874, 875, 876, 877,
880, 881
)
/*
(
736,
750, 753, 754, 755, 756, 757, 758, 
760, 762,
820, 821, 822, 
830, 831, 832, 833, 834,
850, 851, 852, 853, 854, 855,
863, 864,
870, 871, 872, 873, 874, 875, 876, 877,
880, 881
)

*/
  AND KBB.ValutaDatum < '2011-01-11'--<= convert(datetime,'20111031 23:59:59.997')
  AND (NET.Anteil = 0.0 OR NET.Anteil IS NULL AND NET.Betrag IS NOT NULL AND NET.BetragEffektiv = $0.00)
--  AND (KOS.KontoNr NOT IN (820,821,822) OR (SCP.BaPersonID IS NULL AND (SCI.InstitutionName IS NULL OR SCI.InstitutionName <> 'Soziale Dienste, Zürich')))
--  AND USRF.SozialzentrumKurz IN ('SZD', 'SZA', 'SZS', 'SZAL', 'SZH')
-- and belegnr = 57000146692
--  AND KBP.KBBuchungBruttoID = 108818
GROUP BY KBP.KbBuchungBruttoID
ORDER BY MAX(USRF.SozialzentrumKurz), MAX(LEI.FaFallID) ASC, MAX(KBB.ValutaDatum) ASC, MAX(KBP.BaPersonID) ASC


--select * from kbbuchungbrutto where belegnr = 57000146692
--select * from bgkostenart where bgkostenartid = 329
--
--select * from kbbuchungbrutto where kbbuchungbruttoid = 372589
--select * from kbbuchungbruttoperson where kbbuchungbruttoid = 372589

--select * from kbbuchungbrutto where kbbuchungbruttoid = 151378
--select * from kbbuchungbruttoperson where kbbuchungbruttoid = 151378
--select * from kbbuchungkostenart where bgpositionid = 448677
--select * from kbbuchung where kbbuchungid = 185773
--select * from kbopausgleich where opbuchungid = 185773
--select * from kbbuchung where kbbuchungid = 216047
--select * from kbopausgleich where ausgleichbuchungid = 216047
--
--select * from kbbuchungbrutto where kbbuchungbruttoid = 1534884
--select * from kbbuchungbruttoperson where kbbuchungbruttoid = 1534884
--select * from kbbuchungkostenart where bgpositionid = 3224630
--select * from kbbuchung where kbbuchungid = 2110820
--select * from kbopausgleich where opbuchungid = 2110820
--select * from kbbuchung where kbbuchungid = 2114648
--
----lov ausgleich
--select top 10 * from pscdausgleich where opbel = 12000702901
--select top 10 * from pscdausgleich where opbel = 51000860531