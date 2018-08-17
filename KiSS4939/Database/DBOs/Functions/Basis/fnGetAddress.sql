SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetAddress;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/Basis/fnGetAddress.sql $
  $Author: Cjaeggi $
  $Modtime: 20.07.10 16:41 $
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: This functions gets BaAdress records and returns them as a table
    @BaPersonID:      Person of record
    @BaInstitutionID: Institution of record
    @DateTime:        ValidFrom of record, if NULL the current date will be taken
  -
  RETURNS: Found addresses
  -
  TEST:    SELECT * FROM dbo.fnGetAddress(2334234, NULL, GETDATE())
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/Basis/fnGetAddress.sql $
 * 
 * 6     20.07.10 16:41 Cjaeggi
 * #4167: Fixed header
=================================================================================================*/

CREATE FUNCTION dbo.fnGetAddress
(
  @BaPersonID INT,
  @BaInstitutionID INT,
  @DateTime DATETIME
)
RETURNS @OutputTable TABLE 
(
  BaAdresseID INT NOT NULL,
  BaPersonID INT NULL,
  BaInstitutionID INT NULL,
  PlatzierungInstID INT NULL,
  VmMandantID INT NULL,
  VmPriMaID INT NULL,
  KaBetriebID INT NULL,
  KaBetriebKontaktID INT NULL,
  BaLandID INT NULL,
  DatumVon DATETIME NULL,
  DatumBis DATETIME NULL,
  Gesperrt BIT NOT NULL,
  AdresseCode INT NULL,
  CareOf VARCHAR(200) NULL,
  Zusatz VARCHAR(200) NULL,
  ZuhandenVon VARCHAR(200) NULL,
  Strasse VARCHAR(100) NULL,
  HausNr VARCHAR(10) NULL,
  Postfach VARCHAR(100) NULL,
  PostfachOhneNr BIT NOT NULL,
  PLZ VARCHAR(10) NULL,
  Ort VARCHAR(50) NULL,
  OrtschaftCode INT NULL,
  Kanton VARCHAR(10) NULL,
  Bezirk VARCHAR(100) NULL,
  Bemerkung VARCHAR(MAX) NULL,
  PlatzierungsartCode INT NULL,
  WohnStatusCode INT NULL,
  WohnungsgroesseCode INT NULL,
  MigrationKA INT NULL,
  VerID INT NULL,
  Creator VARCHAR(50) NOT NULL,
  Created DATETIME NOT NULL,
  Modifier VARCHAR(50) NOT NULL,
  Modified DATETIME NOT NULL
)
AS
BEGIN
  -----------------------------------------------------------------------------
  -- collect data
  -----------------------------------------------------------------------------
  INSERT INTO @OutputTable 
    SELECT ADR.BaAdresseID,
           ADR.BaPersonID,
           ADR.BaInstitutionID,
           ADR.PlatzierungInstID,
           ADR.VmMandantID,
           ADR.VmPriMaID,
           ADR.KaBetriebID,
           ADR.KaBetriebKontaktID,
           ADR.BaLandID,
           ADR.DatumVon,
           ADR.DatumBis,
           ADR.Gesperrt,
           ADR.AdresseCode,
           ADR.CareOf,
           ADR.Zusatz,
           ADR.ZuhandenVon,
           ADR.Strasse,
           ADR.HausNr,
           ADR.Postfach,
           ADR.PostfachOhneNr,
           ADR.PLZ,
           ADR.Ort,
           ADR.OrtschaftCode,
           ADR.Kanton,
           ADR.Bezirk,
           ADR.Bemerkung,
           ADR.PlatzierungsartCode,
           ADR.WohnStatusCode,
           ADR.WohnungsgroesseCode,
           ADR.MigrationKA,
           ADR.VerID,
           ADR.Creator,
           ADR.Created,
           ADR.Modifier,
           ADR.Modified
    FROM dbo.BaAdresse ADR WITH (READUNCOMMITTED)
    WHERE (@BaPersonID IS NULL OR ADR.BaPersonID = @BaPersonID) 
      AND (@BaInstitutionID IS NULL OR ADR.BaInstitutionID = @BaInstitutionID)
      AND (ADR.DatumVon IS NULL OR dbo.fnDateOf(ADR.DatumVon) <= dbo.fnDateOf(ISNULL(@DateTime, GETDATE())))
      AND (ADR.DatumBis IS NULL OR dbo.fnDateOf(ADR.DatumBis) >= dbo.fnDateOf(ISNULL(@DateTime, GETDATE())));
  
  -- done
  RETURN;
END;
GO
