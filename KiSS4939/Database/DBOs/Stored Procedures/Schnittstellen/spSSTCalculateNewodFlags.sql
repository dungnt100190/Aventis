 SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spSSTCalculateNewodFlags
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spSSTCalculateNewodFlags.sql $
  $Author: Mboss $
  $Modtime: 13.10.09 15:27 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spSSTCalculateNewodFlags.sql $
 * 
 * 5     13.10.09 15:27 Mboss
 * 
 * 5     13.10.09 11:23 Mboss
 * 
 * 3     24.09.09 10:26 Mboss
 * 
 * 2     21.09.09 14:28 Mboss
 * 
 * 1     21.09.09 14:23 Mboss

=================================================================================================*/

/*
  KiSS 4.0
  --------
  DB-Object: LOV
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:53
*/

CREATE PROCEDURE dbo.spSSTCalculateNewodFlags
 (@BaPersonID int)
AS

DECLARE @Stichtag DATETIME
SET @Stichtag = GETDATE()
SELECT
PRS.BaPersonID, PRS.NationalitaetCode,
  NewodPersonID = BAN.NewodPersonID,
  [SchweizerAktiveSozialhilfe]  = CASE WHEN PRS.NationalitaetCode = 147 AND LSH.FaLeistungID IS NOT NULL THEN convert(bit, 1) ELSE convert(bit,0) END,
  [AuslaenderAktiveSozialhilfe] = CASE WHEN PRS.NationalitaetCode <> 147 AND LSH.FaLeistungID IS NOT NULL THEN convert(bit,1) ELSE convert(bit,0) END,
  [SchweizerAktiveVormundschaft] = CASE WHEN LVM.FaLeistungID IS NOT NULL THEN convert(bit,1) ELSE convert(bit,0) END
FROM dbo.vwPerson          PRS 
  INNER JOIN BaPerson_NewodPerson BAN ON PRS.BaPersonID = BAN.BaPersonID
  LEFT JOIN dbo.FaLeistung LSH WITH (READUNCOMMITTED) ON LSH.BaPersonID = PRS.BaPersonID 
                                                     AND LSH.ModulID = 3  -- SH
                                                     AND @Stichtag BETWEEN LSH.DatumVon AND ISNULL(LSH.DatumBis, '99990101')  -- aktiv am Stichtag
                                                     AND LSH.FaLeistungID = (SELECT MAX(FaLeistungID)  -- Damit sicher nur ein Result pro Person
                                                                             FROM FaLeistung
                                                                             WHERE BaPersonID = PRS.BaPersonID
                                                                               AND ModulID = LSH.ModulID
                                                                               AND FaProzessCode = LSH.FaProzessCode)
  LEFT JOIN dbo.FaLeistung LVM WITH (READUNCOMMITTED) ON LVM.BaPersonID = PRS.BaPersonID 
                                                     AND LVM.ModulID = 5          -- Vormundschaft
                                                     AND LVM.FaProzessCode = 501  -- Vormundschaftliche Massnahme
                                                     AND @Stichtag BETWEEN LVM.DatumVon AND ISNULL(LVM.DatumBis, '99990101')  -- aktiv am Stichtag
                                                     AND LVM.FaLeistungID = (SELECT MAX(FaLeistungID)   -- Damit sicher nur ein Result pro Person
                                                                             FROM FaLeistung
                                                                             WHERE BaPersonID = PRS.BaPersonID
                                                                               AND ModulID = LVM.ModulID
                                                                               AND FaProzessCode = LVM.FaProzessCode)
-- Einschränken auf Person?
 WHERE PRS.BaPersonID = @BaPersonID

/*
	--Probleme, Fragen:
	-- Nur Fallträger oder UE? --> SELECT wird nur für Fallträger 1er Werte liefern!
	-- Nur Leistung prüfen? einfach nicht abgeschlossen? FP? --> Select prüft nur Leistung!
	-- Nur VM heisst es darf keine SH-Leistung geben? aktive?

	--> Es gibt Personen mit mehreren aktiven SH's --> das geht wenn man einfach neue Sh anlegt!
	--> man kann dann aber Daten nicht mehr ändern. diese müssen sie bereinigen. Betroffene PRS:
	-- Select liefert aber wegen einschränkung auf LeistungID = MAX(LeistungID)... doch nur ein result pro Person!
	SELECT
	  LSH.BaPersonID, count(*)
	FROM dbo.FaLeistung LSH WITH (READUNCOMMITTED) 
	WHERE LSH.ModulID = 3  -- SH
	  AND GETDATE() BETWEEN LSH.DatumVon AND ISNULL(LSH.DatumBis, '99990101')
	GROUP By LSH.BaPersonID
	HAVING COUNT(*) > 1

	-- dito für VM, aber da darf es evtl. so sein. Deshalb das select angepasst mit den LeistungID = MAX(LeistungID)...
	SELECT
	  LSV.BaPersonID, count(*)
	FROM dbo.FaLeistung LSV WITH (READUNCOMMITTED) 
	WHERE LSV.ModulID = 5  -- SH
	  AND LSV.FaProzessCode = 501
	  AND GETDATE() BETWEEN LSV.DatumVon AND ISNULL(LSV.DatumBis, '99990101')
	GROUP By LSV.BaPersonID
	HAVING COUNT(*) > 1
*/

GO

