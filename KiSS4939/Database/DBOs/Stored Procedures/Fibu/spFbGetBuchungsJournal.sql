SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spFbGetBuchungsJournal
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spFbGetBuchungsJournal.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:27 $
  $Revision: 2 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spFbGetBuchungsJournal.sql $
 * 
 * 2     25.06.09 11:40 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spFbGetBuchungsJournal
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:54
*/
CREATE PROCEDURE dbo.spFbGetBuchungsJournal
 (@FbPeriodeID   int,
  @DatumVon      datetime,
  @DatumBis      datetime)
AS
  SELECT 
    FbBuchungID, FbPeriodeID, BuchungTypCode, Code, BelegNr, BelegNrPos, BuchungsDatum, 
    SollKtoNr, HabenKtoNr, Betrag, Text, ValutaDatum, Zahlungsfrist, BuchungStatusCode, 
    FbDauerauftragID, ErfassungsDatum, UserID, FbZahlungswegID, PCKontoNr, BankKontoNr, 
    ZahlungsArtCode, ReferenzNummer, Zahlungsgrund, Name, Zusatz, Strasse, PLZ, Ort, FbBuchungTS
  FROM   
    dbo.FbBuchung WITH (READUNCOMMITTED) 
  WHERE  
    FbPeriodeID = @FbPeriodeID 
    AND BuchungsDatum BETWEEN @DatumVon AND @DatumBis
  ORDER BY 
    BuchungsDatum,BelegNr
GO