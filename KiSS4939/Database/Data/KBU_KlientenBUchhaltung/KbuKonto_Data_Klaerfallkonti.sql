/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to <description>.
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- step 1
-------------------------------------------------------------------------------
DECLARE @CreatorModifier VARCHAR(50);
DECLARE @KbuKontoID INT;
SELECT @CreatorModifier = dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID());

INSERT INTO dbo.KbuKonto(KontoNr, Name, ExterneKontoNr, DatumVon, KbuKontoklasseCode, Creator, Modifier)
VALUES (1340, 'Klärfallkonto AZ: Stadtinterne Verrechnungen vom Amt für Zusatzleistungen (AZL)', 'AZ', dbo.fnDateSerial(2008,1,1), 1, @CreatorModifier, @CreatorModifier)
SET @KbuKontoID = SCOPE_IDENTITY();
INSERT INTO dbo.SstPscdSachkontoInnenauftrag(KbuKontoID, Sachkonto, SachkontoErtragOhneGeldfluss, [Creator], [Modifier])
SELECT @KbuKontoID, '20090340', '20090340', @CreatorModifier, @CreatorModifier

INSERT INTO dbo.KbuKonto(KontoNr, Name, ExterneKontoNr, DatumVon, KbuKontoklasseCode, Creator, Modifier)
VALUES (1351, 'Klärfallkonto E2: ESR-Teilnehmernummer für den Bereich Unterhaltsbeiträge (ESR 01-69760-9)', 'E2', dbo.fnDateSerial(2008,1,1), 1, @CreatorModifier, @CreatorModifier)
SET @KbuKontoID = SCOPE_IDENTITY();
INSERT INTO dbo.SstPscdSachkontoInnenauftrag(KbuKontoID, Sachkonto, SachkontoErtragOhneGeldfluss, [Creator], [Modifier])
SELECT @KbuKontoID, '20090351', '20090351', @CreatorModifier, @CreatorModifier

INSERT INTO dbo.KbuKonto(KontoNr, Name, ExterneKontoNr, DatumVon, KbuKontoklasseCode, Creator, Modifier)
VALUES (1352, 'Klärfallkonto E4: ESR-Teilnehmernummer für den Bereich W-Inkasso (ESR 01-69761-7)', 'E4', dbo.fnDateSerial(2008,1,1), 1, @CreatorModifier, @CreatorModifier)
SET @KbuKontoID = SCOPE_IDENTITY();
INSERT INTO dbo.SstPscdSachkontoInnenauftrag(KbuKontoID, Sachkonto, SachkontoErtragOhneGeldfluss, [Creator], [Modifier])
SELECT @KbuKontoID, '20090352', '20090352', @CreatorModifier, @CreatorModifier

/*
INSERT INTO dbo.KbuKonto(KontoNr, Name, ExterneKontoNr, DatumVon, KbuKontoklasseCode, Creator, Modifier)
VALUES (1352, 'Klärfallkonto IV: Interne Verrechnung von KiSS an KiSS Modul W', 'IV', dbo.fnDateSerial(2008,1,1), 1, @CreatorModifier, @CreatorModifier)
SET @KbuKontoID = SCOPE_IDENTITY();
INSERT INTO dbo.SstPscdSachkontoInnenauftrag(KbuKontoID, Sachkonto, SachkontoErtragOhneGeldfluss, [Creator], [Modifier])
SELECT @KbuKontoID, '?', '?', @CreatorModifier, @CreatorModifier
*/

INSERT INTO dbo.KbuKonto(KontoNr, Name, ExterneKontoNr, DatumVon, KbuKontoklasseCode, Creator, Modifier)
VALUES (1343, 'Klärfallkonto PJ: PC-Konto 80-2036-3 für den Bereich Pflegegelder (auslaufend)', 'PJ', dbo.fnDateSerial(2008,1,1), 1, @CreatorModifier, @CreatorModifier)
SET @KbuKontoID = SCOPE_IDENTITY();
INSERT INTO dbo.SstPscdSachkontoInnenauftrag(KbuKontoID, Sachkonto, SachkontoErtragOhneGeldfluss, [Creator], [Modifier])
SELECT @KbuKontoID, '20090343', '20090343', @CreatorModifier, @CreatorModifier

/*
INSERT INTO dbo.KbuKonto(KontoNr, Name, ExterneKontoNr, DatumVon, KbuKontoklasseCode, Creator, Modifier)
VALUES (1343, 'Klärfallkonto RK: Rückläufer zugunsten KiSS, Konto ZKB 1100-6116.002', 'RK', dbo.fnDateSerial(2008,1,1), 1, @CreatorModifier, @CreatorModifier)
SET @KbuKontoID = SCOPE_IDENTITY();
INSERT INTO dbo.SstPscdSachkontoInnenauftrag(KbuKontoID, Sachkonto, SachkontoErtragOhneGeldfluss, [Creator], [Modifier])
SELECT @KbuKontoID, '?', '?', @CreatorModifier, @CreatorModifier
*/

INSERT INTO dbo.KbuKonto(KontoNr, Name, ExterneKontoNr, DatumVon, KbuKontoklasseCode, Creator, Modifier)
VALUES (1353, 'Klärfallkonto WI: Manuell erfasste Zahlstapel von stadtinternen Verrechnungen', 'WI', dbo.fnDateSerial(2008,1,1), 1, @CreatorModifier, @CreatorModifier)
SET @KbuKontoID = SCOPE_IDENTITY();
INSERT INTO dbo.SstPscdSachkontoInnenauftrag(KbuKontoID, Sachkonto, SachkontoErtragOhneGeldfluss, [Creator], [Modifier])
SELECT @KbuKontoID, '20090353', '20090353', @CreatorModifier, @CreatorModifier

INSERT INTO dbo.KbuKonto(KontoNr, Name, ExterneKontoNr, DatumVon, KbuKontoklasseCode, Creator, Modifier)
VALUES (1342, 'Klärfallkonto WS: PC-Konto 80-2001-6 für den Bereich Wirtschaftliche Sozialhilfe', 'WS', dbo.fnDateSerial(2008,1,1), 1, @CreatorModifier, @CreatorModifier)
SET @KbuKontoID = SCOPE_IDENTITY();
INSERT INTO dbo.SstPscdSachkontoInnenauftrag(KbuKontoID, Sachkonto, SachkontoErtragOhneGeldfluss, [Creator], [Modifier])
SELECT @KbuKontoID, '20090342', '20090342', @CreatorModifier, @CreatorModifier

GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
