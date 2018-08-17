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
VALUES (1340, 'Kl�rfallkonto AZ: Stadtinterne Verrechnungen vom Amt f�r Zusatzleistungen (AZL)', 'AZ', dbo.fnDateSerial(2008,1,1), 1, @CreatorModifier, @CreatorModifier)
SET @KbuKontoID = SCOPE_IDENTITY();
INSERT INTO dbo.SstPscdSachkontoInnenauftrag(KbuKontoID, Sachkonto, SachkontoErtragOhneGeldfluss, [Creator], [Modifier])
SELECT @KbuKontoID, '20090340', '20090340', @CreatorModifier, @CreatorModifier

INSERT INTO dbo.KbuKonto(KontoNr, Name, ExterneKontoNr, DatumVon, KbuKontoklasseCode, Creator, Modifier)
VALUES (1351, 'Kl�rfallkonto E2: ESR-Teilnehmernummer f�r den Bereich Unterhaltsbeitr�ge (ESR 01-69760-9)', 'E2', dbo.fnDateSerial(2008,1,1), 1, @CreatorModifier, @CreatorModifier)
SET @KbuKontoID = SCOPE_IDENTITY();
INSERT INTO dbo.SstPscdSachkontoInnenauftrag(KbuKontoID, Sachkonto, SachkontoErtragOhneGeldfluss, [Creator], [Modifier])
SELECT @KbuKontoID, '20090351', '20090351', @CreatorModifier, @CreatorModifier

INSERT INTO dbo.KbuKonto(KontoNr, Name, ExterneKontoNr, DatumVon, KbuKontoklasseCode, Creator, Modifier)
VALUES (1352, 'Kl�rfallkonto E4: ESR-Teilnehmernummer f�r den Bereich W-Inkasso (ESR 01-69761-7)', 'E4', dbo.fnDateSerial(2008,1,1), 1, @CreatorModifier, @CreatorModifier)
SET @KbuKontoID = SCOPE_IDENTITY();
INSERT INTO dbo.SstPscdSachkontoInnenauftrag(KbuKontoID, Sachkonto, SachkontoErtragOhneGeldfluss, [Creator], [Modifier])
SELECT @KbuKontoID, '20090352', '20090352', @CreatorModifier, @CreatorModifier

/*
INSERT INTO dbo.KbuKonto(KontoNr, Name, ExterneKontoNr, DatumVon, KbuKontoklasseCode, Creator, Modifier)
VALUES (1352, 'Kl�rfallkonto IV: Interne Verrechnung von KiSS an KiSS Modul W', 'IV', dbo.fnDateSerial(2008,1,1), 1, @CreatorModifier, @CreatorModifier)
SET @KbuKontoID = SCOPE_IDENTITY();
INSERT INTO dbo.SstPscdSachkontoInnenauftrag(KbuKontoID, Sachkonto, SachkontoErtragOhneGeldfluss, [Creator], [Modifier])
SELECT @KbuKontoID, '?', '?', @CreatorModifier, @CreatorModifier
*/

INSERT INTO dbo.KbuKonto(KontoNr, Name, ExterneKontoNr, DatumVon, KbuKontoklasseCode, Creator, Modifier)
VALUES (1343, 'Kl�rfallkonto PJ: PC-Konto 80-2036-3 f�r den Bereich Pflegegelder (auslaufend)', 'PJ', dbo.fnDateSerial(2008,1,1), 1, @CreatorModifier, @CreatorModifier)
SET @KbuKontoID = SCOPE_IDENTITY();
INSERT INTO dbo.SstPscdSachkontoInnenauftrag(KbuKontoID, Sachkonto, SachkontoErtragOhneGeldfluss, [Creator], [Modifier])
SELECT @KbuKontoID, '20090343', '20090343', @CreatorModifier, @CreatorModifier

/*
INSERT INTO dbo.KbuKonto(KontoNr, Name, ExterneKontoNr, DatumVon, KbuKontoklasseCode, Creator, Modifier)
VALUES (1343, 'Kl�rfallkonto RK: R�ckl�ufer zugunsten KiSS, Konto ZKB 1100-6116.002', 'RK', dbo.fnDateSerial(2008,1,1), 1, @CreatorModifier, @CreatorModifier)
SET @KbuKontoID = SCOPE_IDENTITY();
INSERT INTO dbo.SstPscdSachkontoInnenauftrag(KbuKontoID, Sachkonto, SachkontoErtragOhneGeldfluss, [Creator], [Modifier])
SELECT @KbuKontoID, '?', '?', @CreatorModifier, @CreatorModifier
*/

INSERT INTO dbo.KbuKonto(KontoNr, Name, ExterneKontoNr, DatumVon, KbuKontoklasseCode, Creator, Modifier)
VALUES (1353, 'Kl�rfallkonto WI: Manuell erfasste Zahlstapel von stadtinternen Verrechnungen', 'WI', dbo.fnDateSerial(2008,1,1), 1, @CreatorModifier, @CreatorModifier)
SET @KbuKontoID = SCOPE_IDENTITY();
INSERT INTO dbo.SstPscdSachkontoInnenauftrag(KbuKontoID, Sachkonto, SachkontoErtragOhneGeldfluss, [Creator], [Modifier])
SELECT @KbuKontoID, '20090353', '20090353', @CreatorModifier, @CreatorModifier

INSERT INTO dbo.KbuKonto(KontoNr, Name, ExterneKontoNr, DatumVon, KbuKontoklasseCode, Creator, Modifier)
VALUES (1342, 'Kl�rfallkonto WS: PC-Konto 80-2001-6 f�r den Bereich Wirtschaftliche Sozialhilfe', 'WS', dbo.fnDateSerial(2008,1,1), 1, @CreatorModifier, @CreatorModifier)
SET @KbuKontoID = SCOPE_IDENTITY();
INSERT INTO dbo.SstPscdSachkontoInnenauftrag(KbuKontoID, Sachkonto, SachkontoErtragOhneGeldfluss, [Creator], [Modifier])
SELECT @KbuKontoID, '20090342', '20090342', @CreatorModifier, @CreatorModifier

GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
