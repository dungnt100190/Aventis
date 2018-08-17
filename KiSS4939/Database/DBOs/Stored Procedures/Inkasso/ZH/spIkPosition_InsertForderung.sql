SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spIkPosition_InsertForderung
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spIkPosition_InsertForderung.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 11:22 $
  $Revision: 6 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spIkPosition_InsertForderung.sql $
 * 
 * 6     11.12.09 11:23 Lloreggia
 * Header aktualisiert, ALTER -> CREATE
 * 
 * 5     12.10.09 17:00 Nweber
 * #5325: IkForderungEinmaligCode ist immer 121 beim Saldo berechnen auf
 * der Saldo-Maske
 * 
 * 4     10.03.09 14:39 Rhesterberg
 * 
 * 3     21.01.09 14:45 Rhesterberg
 * 
 * 2     6.01.09 13:15 Rhesterberg
 * 
 * 1     9.09.08 14:59 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

/*
===================================================================================================
Author:      sozheo
Create date: 26.06.2008
Description: Neue Einmalige Forderung erstellen

===================================================================================================
History:
03.07.2008 : sozheo : neu erstellt
14.07.2008 : sozheo : Verwendungsperiode eingefügt
04.08.2008 : sozheo : Neu auch negative Beträge (bei einmaligen Zahlungen)
05.08.2008 : sozheo : IkPosition.ErledigterMonat entfernt
21.08.2008 : sozheo : Korrekturen SQL Performance
07.11.2008 : sozheo : Betrag kann jetzt auch negativ sein
10.11.2008 : sozheo : In ZH gemachte Korrekturen vom 07.11.2008 noch übernehmen
10.11.2008 : sozheo : Bei Verwendungsperiode immer 01 des Monats angeben
17.11.2008 : sozheo : Bei Verwendungsperiode BIS immer letzter des Monats angeben
21.01.2009 : sozheo : für bessere Performance wird neu LeistungID auch gespeichert
10.03.2009 : sozheo : IkPosition.Unterstuetzungsfall eliminiert
===================================================================================================
*/

CREATE PROCEDURE [dbo].[spIkPosition_InsertForderung]
  -- Leistung
  @FaLeistungID INT,
  -- Rechtstitel
  @IkRechtstitelID INT,
  -- BaPersonID
  @BaPersonID INT,
  -- BetragEinmalig
  @BetragEinmalig MONEY,
  -- ProzessCode
  @ProzessCode INT,
  -- VerwPeriodeVon
  @VerwPeriodeVon DATETIME,
  -- VerwPeriodeBis
  @VerwPeriodeBis DATETIME
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON


  -- ---------------------------------------------------
  -- Kontrollen der Parameter
  -- ---------------------------------------------------
  IF (@FaLeistungID IS NULL OR @FaLeistungID = 0) BEGIN
    RAISERROR ('Der Aufruf-Parameter @LeistungID ist null.', 18, 1)
    RETURN -1
  END
  IF (@IkRechtstitelID IS NULL OR @IkRechtstitelID = 0) AND (@FaLeistungID IS NULL OR @FaLeistungID = 0) BEGIN
    RAISERROR ('Der Aufruf-Parameter @LeistungID oder @RechtstitelID ist null.', 18, 1)
    RETURN -1
  END
  IF (@BetragEinmalig IS NULL OR @BetragEinmalig = 0) BEGIN
    RAISERROR ('Der Aufruf-Parameter @BetragEinmalig ist null oeder 0.--.', 18, 1)
    RETURN -1
  END
  IF @ProzessCode NOT IN (405,406,407) BEGIN
    RAISERROR ('Der Aufruf-Parameter @ProzessCode ist ungültig.', 18, 1)
    RETURN -1
  END

  IF @BetragEinmalig = 0 BEGIN
    RAISERROR ('Der Betrag kann nicht 0.00 sein.', 18, 1)
    RETURN -1
  END

  DECLARE
    @NewID INT,
    @ErrorMsg VARCHAR(200),
    @Datum DATETIME


  SELECT TOP 1 @Datum = Datum FROM dbo.fnIkZahlungslaufvaluta(GETDATE())
  IF @Datum IS NULL BEGIN
    RAISERROR ('Es konnte kein Zahlungsavaluta-Datum gefunden werden.', 18, 1)
    RETURN -1
  END

  BEGIN TRANSACTION
  BEGIN TRY
    -- Neue einmalige Zahlung erstellen lov einmalig
    -- --------------------------------
    INSERT INTO dbo.IkPosition (
      FaLeistungID, IkRechtstitelID, Einmalig, Datum, Monat, Jahr, BaPersonID, 
      BetragEinmalig, IkForderungEinmaligCode, BetragIstNegativ,  
      Bemerkung, VerwPeriodeVon, VerwPeriodeBis, IkBuchungsartCode 
    )
    VALUES (
      @FaLeistungID, @IkRechtstitelID, 1, @Datum, MONTH(@Datum), YEAR(@Datum), @BaPersonID, 
      -- 04.08.2008 : sozheo : Neu auch negative Beträge 
      --CASE WHEN @BetragEinmalig > 0 THEN @BetragEinmalig ELSE -@BetragEinmalig END, 
      @BetragEinmalig,
      -- 07.11.2008 : sozheo : Betrag kann jetzt auch negativ sein
      --CASE WHEN @BetragEinmalig > 0 THEN 121 ELSE 122 END, 
      --CASE WHEN @BetragEinmalig > 0 THEN 122 ELSE 121 END, 
      121,
      CASE WHEN @BetragEinmalig > 0 THEN 0 ELSE 1 END, 
      NULL, 
      dbo.fnFirstDayOf(@VerwPeriodeVon), 
      dbo.fnLastDayOf(@VerwPeriodeBis),
      CASE WHEN @BetragEinmalig > 0 THEN 4 ELSE 5 END
    )
    SET @NewID = SCOPE_IDENTITY()

    -- Speichern
    -- ---------
    COMMIT TRANSACTION
  END TRY
  BEGIN CATCH

    -- Bei Fehler
    -- ----------
    ROLLBACK TRANSACTION
    SET @ErrorMsg = ERROR_MESSAGE()
    RAISERROR (@ErrorMsg, 18, 1)
    RETURN -1
  END CATCH

  RETURN 1
END

GO