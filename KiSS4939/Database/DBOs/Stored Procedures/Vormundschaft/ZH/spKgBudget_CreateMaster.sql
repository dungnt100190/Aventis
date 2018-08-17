SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKgBudget_CreateMaster
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spKgBudget_CreateMaster.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 11:34 $
  $Revision: 7 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spKgBudget_CreateMaster.sql $
 * 
 * 7     11.12.09 11:58 Lloreggia
 * Header aktualisiert
 * 
 * 6     3.12.09 22:41 Mmarghitola
 * #5331: Korrektur der Berechnung des Valuta-Datums
 * 
 * 5     23.10.09 11:25 Mmarghitola
 * #5331: Berechnung der Valuta-Daten von neuen Masterbudgetpositionen
 * anpassen
 * 
 * 4     29.06.09 18:30 Rstahel
 * #4712: Bugfix: DatumVon und DatumBis werden nun kopiert, wenn neue
 * Positionen erstellt werden
 * 
 * 3     28.06.09 18:56 Rstahel
 * #4712: Diverse Anpassungen Stored Procedures
 * 
 * 2     10.03.09 17:58 Rstahel
 * Abgleich der Stored Procedures aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE PROCEDURE [dbo].[spKgBudget_CreateMaster]
 (@FaLeistungID   int)
AS BEGIN

  DECLARE @LastKgBudgetID int
  DECLARE @LastBewilligtBis datetime
  DECLARE @LastBewilligtVon datetime

  DECLARE @NewKgBudgetID int
  DECLARE @NewBewilligtVon datetime

  DECLARE @KgPositionID int
  DECLARE @NewKgPositionID int

  --letztes Masterbudget abfragen
  SELECT TOP 1 @LastKgBudgetID = KgBudgetID,
         @LastBewilligtVon = BewilligtVon,
         @LastBewilligtBis = BewilligtBis
  FROM dbo.KgBudget
  WHERE  FaLeistungID = @FaLeistungID AND
         KgMasterBudgetID IS NULL
  ORDER BY BewilligtBis DESC

  IF @LastKgBudgetID  IS NULL
    SET @NewBewilligtVon = dbo.fnFirstDayOf(GetDate())
  ELSE
    SET @NewBewilligtVon = DateAdd(d,1,@LastBewilligtBis)

  INSERT KgBudget (FaLeistungID, KgBewilligungCode, BewilligtVon,BewilligtBis)
  VALUES (@FaLeistungID, 1, @NewBewilligtVon, dbo.fnDateSerial(year(@NewBewilligtVon),12,31))

  SET @NewKgBudgetID = @@identity

  -- Positionen/Valuta kopieren des letzten Masterbudgets
  IF @LastKgBudgetID IS NOT NULL BEGIN

    DECLARE C CURSOR FOR
      SELECT KgPositionID
      FROM dbo.KgPosition 
      WHERE KgBudgetID = @LastKgBudgetID
		     AND KgBewilligungCode = 5	-- Nur bewilligte Masterbudget-Positionen
		     AND IsNull(DatumBis, @NewBewilligtVon) >= @NewBewilligtVon	-- Nur Positionen, die nicht terminiert sind oder immer noch gültig sind im neuen Budget

    OPEN C
    FETCH NEXT FROM C INTO @KgPositionID
    WHILE @@fetch_status = 0 BEGIN

      INSERT KgPosition
        (KgBudgetID,KgPositionsKategorieCode,MasterbudgetPositionID,KontoNr,Buchungstext,Betrag,Bemerkung,
         BuchungDatum,BaInstitutionID,
         KgAuszahlungsArtCode,KgAuszahlungsTerminCode,BaZahlungswegID,ReferenzNummer,DatumVon,DatumBis)
      SELECT
         @NewKgBudgetID,KgPositionsKategorieCode,KgPositionID,KontoNr,Buchungstext,Betrag,Bemerkung,
         BuchungDatum = dbo.fnDateSerial(Year(@NewBewilligtVon),Month(@NewBewilligtVon),Day(BuchungDatum)),
         BaInstitutionID,
         KgAuszahlungsArtCode,KgAuszahlungsTerminCode,BaZahlungswegID,ReferenzNummer,DatumVon,DatumBis
      FROM dbo.KgPosition
      WHERE KgPositionID = @KgPositionID

      SET @NewKgPositionID = @@identity

      INSERT KgPositionValuta (KgPositionID,Datum)
      SELECT @NewKgPositionID, DateAdd(m,DateDiff(m, convert(datetime,dbo.fnMax(POS.DatumVon, @LastBewilligtVon)), @NewBewilligtVon), VAL.Datum)
      FROM dbo.KgPositionValuta   VAL
        LEFT JOIN dbo.KgPosition  POS ON POS.KgPositionID = VAL.KgPositionID
      WHERE  VAL.KgPositionID = @KgPositionID

      FETCH NEXT FROM C INTO @KgPositionID
    END
    CLOSE C
    DEALLOCATE C
  END

  SELECT NewKgBudgetID = @NewKgBudgetID
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
