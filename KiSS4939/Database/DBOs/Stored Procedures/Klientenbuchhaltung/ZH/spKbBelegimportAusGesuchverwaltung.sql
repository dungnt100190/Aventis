SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spKbBelegimportAusGesuchverwaltung;
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Belege aus der Gesuchverwaltung in der Klibu importieren.
    @GvAuszahlungPositionID ID der Auszahlungsposition
    @Belegdatum             Belegdatum
    @KbPeriodeID            ID aktive Geschäftsperiode
    @UserID                 UserID vom Ersteller
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spKbBelegimportAusGesuchverwaltung
(
  @GvAuszahlungPositionID INT,
  @Belegdatum             DATETIME,
  @KbPeriodeID            INT,
  @UserID                 INT
)
AS 
BEGIN
  /************************************************************************************************/
  /* Check parameters                                                                             */
  /************************************************************************************************/
  IF (@GvAuszahlungPositionID IS NULL)
  BEGIN
    RAISERROR ('Der Aufruf-Parameter @GvAuszahlungPositionID ist null!', 18, 1)
    RETURN -1
  END

  IF (@Belegdatum IS NULL)
  BEGIN
    RAISERROR ('Der Aufruf-Parameter @Belegdatum ist null!', 18, 1)
    RETURN -1
  END

  IF (@KbPeriodeID IS NULL)
  BEGIN
    RAISERROR ('Der Aufruf-Parameter @KbPeriodeID ist null!', 18, 1)
    RETURN -1
  END
  
  
  /************************************************************************************************/
  /* Init variables                                                                               */
  /************************************************************************************************/
  DECLARE @PeriodeVon DATETIME;
  DECLARE @PeriodeBis DATETIME;
  DECLARE @KontoNr_Kreditor VARCHAR(10);
  DECLARE @PeriodeStatusCode INT;
  DECLARE @KbBuchungID_New INT;
  DECLARE @Belegnummer INT;
  DECLARE @KbBelegkreisCode INT;
  DECLARE @KbBelegkreisID INT;
  DECLARE @ValutaDatum DATETIME;
  DECLARE @BaZahlungswegID INT;
  DECLARE @Betrag MONEY;
  DECLARE @KontoNr VARCHAR(10);
  DECLARE @BgKostenartID INT;
  DECLARE @BaPersonID INT;
  DECLARE @KbKostenstelleID INT;
  DECLARE @BgSplittingArtCode INT;
  DECLARE @Weiterverrechenbar BIT;
  DECLARE @Quoting BIT;
  DECLARE @Buchungstext VARCHAR(200);
  
  DECLARE @KRE_BaBankID INT;
  DECLARE @KRE_BaPersonID INT;
  DECLARE @KRE_BankName VARCHAR(70);
  DECLARE @KRE_BankStrasse VARCHAR(50);
  DECLARE @KRE_BankPLZ VARCHAR(10);
  DECLARE @KRE_BankOrt VARCHAR(50);
  DECLARE @KRE_PCKontoNr VARCHAR(20);
  DECLARE @KRE_BankKontoNr VARCHAR(50);
  DECLARE @KRE_IBAN VARCHAR(50);
  DECLARE @KRE_Referenznummer VARCHAR(30);
  DECLARE @KRE_BeguenstigtName VARCHAR(35);
  DECLARE @KRE_BeguenstigtName2 VARCHAR(35);
  DECLARE @KRE_BeguenstigtStrasse VARCHAR(35);
  DECLARE @KRE_BeguenstigtPLZ VARCHAR(10);
  DECLARE @KRE_BeguenstigtOrt VARCHAR(25);
  DECLARE @KRE_ClearingNr VARCHAR(15);
  DECLARE @KRE_ClearingNrNeu VARCHAR(15);
  DECLARE @KRE_KreditorMehrZeilig VARCHAR(2000);

  SET @KbBelegkreisCode = 11; -- Belegimport Gesuchverwaltung

  --Kreditor-Konto ermitteln
  SELECT @PeriodeVon        = PRD.PeriodeVon,
         @PeriodeBis        = PRD.PeriodeBis,
         @KontoNr_Kreditor  = KTO.KontoNr,
         @PeriodeStatusCode = PRD.PeriodeStatusCode
  FROM dbo.KbPeriode      PRD
    LEFT JOIN dbo.KbKonto KTO ON KTO.KbPeriodeID = PRD.KbPeriodeID
                             AND ',' + KTO.KbKontoartCodes + ',' LIKE '%,30,%' --30: Kreditor
  WHERE PRD.KbPeriodeID = @KbPeriodeID;          
    
  IF (@PeriodeStatusCode <> 1)
  BEGIN
    RAISERROR ('Die Periode ist nicht aktiv!', 18, 1)
    RETURN;
  END;

  --Passt Belegdatum in Periode?
  IF(@BelegDatum NOT BETWEEN @PeriodeVon AND @PeriodeBis)
  BEGIN
    RAISERROR ('Der Aufruf-Parameter @BelegDatum liegt nicht innerhalb der übergebenen Periode!', 18, 1)
    RETURN -1
  END;
  
  IF(@KontoNr_Kreditor IS NULL)
  BEGIN
    RAISERROR ('Das Kreditor-Konto für die übergebene Periode kann nicht ermittelt werden!', 18, 1)
    RETURN -1
  END;
  
  RAISERROR ('Not implemented', 18, 1);

END;
GO
