SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spFaFallFusion
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spFaFallFusion.sql $
  $Author: Mmarghitola $
  $Modtime: 26.08.10 14:40 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spFaFallFusion.sql $
 * 
 * 5     27.08.10 8:38 Mmarghitola
 * #6389: Klientenkontoabrechnungen bei FallFusion berücksichtigen,
 * Transaktion in den Client verlagern
 * 
 * 4     11.12.09 11:57 Lloreggia
 * Header aktualisiert
 * 
 * 3     14.05.09 10:09 Rhesterberg
 * #4468: Logik Abschluss FF und FA korrigiert
 * 
 * 2     10.03.09 17:58 Rstahel
 * Abgleich der Stored Procedures aus KISS4_MASTER_ZH
=================================================================================================*/


/*
===================================================================================================
Author:      sozheo
Create date: ??.??.????
Description: Fallfusion
===================================================================================================
History:
--------
??.??.???? : sozheo : neu erstellt
31.03.2009 : sozheo : Logik Abschluss FF und FA korrigiert
===================================================================================================
*/

CREATE PROCEDURE [dbo].[spFaFallFusion]
 (@FaFallIDSrc       int,
  @FaFallIDDst       int,
  @UserID            int,
  @OrgUnitID         int)
AS BEGIN
  /*
    Fusioniert zwei Fälle: Aus dem Quellfall werden alle Leistungen in den Zielfall umgehängt.
    Weiter werden alle der Quell-Fallführung angehängte Daten der Ziel-Fallführung angehängt
  */
  SET NOCOUNT ON

  IF NOT( @@TRANCOUNT > 0) BEGIN
    -- Das Transaktionshandling wird vom Client durchgeführt (weniger fehleranfällig)
    RAISERROR('Keine Transaktion offen. spFaFallFusion darf nur innerhalb einer Transaktion durchgeführt werden', 15, 1)
    RETURN -2
  END

  DECLARE 
    @FaFallIDDstVon    datetime,
    @FaFallIDDstBis    datetime,
    @FaFallIDSrcVon    datetime,
    @FaFallIDSrcBis    datetime,

    @FaLeistungFFDstID int,
    @FaLeistungFFDstVon datetime,
    @FaLeistungFFDstBis datetime,
    @FaLeistungFFSrcID int,
    @FaLeistungFFSrcVon datetime,
    @FaLeistungFFSrcBis datetime,
    @FfIstAktivSrc BIT,
    @FfIstAktivDst BIT,

    @FaLeistungAlimDstID int,
    @FaLeistungAlimDstVon datetime,
    @FaLeistungAlimDstBis datetime,
    @FaLeistungAlimSrcID int,
    @FaLeistungAlimSrcVon datetime,
    @FaLeistungAlimSrcBis datetime,
    @FaIstAktivSrc BIT,
    @FaIstAktivDst BIT,

    @DateMax datetime,

    @CreatorModifier VARCHAR(50);


  SELECT @DateMax = dbo.fnDateSerial(9999,12,31),
      @CreatorModifier = dbo.fnGetDBRowCreatorModifier(@UserID);

  -- Datums des Ziel-FaFall bestimmen
  SELECT TOP 1 @FaFallIDDstVon = DatumVon, @FaFallIDDstBis = IsNull(DatumBis, @DateMax)
  FROM   dbo.FaFall WITH (READUNCOMMITTED)
  WHERE  FaFallID = @FaFallIDDst

  -- Datums des Quell-FaFall bestimmen
  SELECT TOP 1 @FaFallIDSrcVon = DatumVon, @FaFallIDSrcBis = IsNull(DatumBis, @DateMax)
  FROM   dbo.FaFall WITH (READUNCOMMITTED)
  WHERE  FaFallID = @FaFallIDSrc

  -- Die Fallführungs-FaLeistung bestimmen, die übrig bleibt
  SELECT TOP 1 
    @FaLeistungFFDstID = FaLeistungID,
    @FaLeistungFFDstVon = DatumVon, 
    @FaLeistungFFDstBis = DatumBis,
    @FfIstAktivDst = CONVERT(BIT, CASE WHEN DatumBis IS NULL THEN 1 ELSE 0 END)
  FROM   dbo.FaLeistung WITH (READUNCOMMITTED)
  WHERE  FaFallID = @FaFallIDDst AND FaProzessCode = 200 --Fallführung
  ORDER BY DatumVon DESC -- es dürfte nur eine FF-Leistung geben

  -- Datums der Quell-FF-Leistung bestimmen
  SELECT TOP 1 
    @FaLeistungFFSrcID = FaLeistungID, 
    @FaLeistungFFSrcVon = DatumVon, 
    @FaLeistungFFSrcBis = DatumBis,
    @FfIstAktivSrc = CONVERT(BIT, CASE WHEN DatumBis IS NULL THEN 1 ELSE 0 END)
  FROM   dbo.FaLeistung WITH (READUNCOMMITTED)
  WHERE  FaFallID = @FaFallIDSrc AND FaProzessCode = 200 --Fallführung
  ORDER BY DatumVon DESC -- es dürfte nur eine FF-Leistung geben

  -- Die Ziel-F(a)-Leistung bestimmen
  SELECT TOP 1 
    @FaLeistungAlimDstID  = FaLeistungID,
    @FaLeistungAlimDstVon = DatumVon, 
    @FaLeistungAlimDstBis = DatumBis,
    @FaIstAktivDst = CONVERT(BIT, CASE WHEN DatumBis IS NULL THEN 1 ELSE 0 END)
  FROM   dbo.FaLeistung WITH (READUNCOMMITTED)
  WHERE  FaFallID = @FaFallIDDst AND FaProzessCode = 201 --Fallführung Alim
  ORDER BY DatumVon DESC -- es dürfte nur eine Fa-Leistung geben

  -- Datums der Quell-F(a)-Leistung bestimmen
  SELECT TOP 1 
    @FaLeistungAlimSrcID  = FaLeistungID, 
    @FaLeistungAlimSrcVon = DatumVon, 
    @FaLeistungAlimSrcBis = DatumBis,
    @FaIstAktivSrc = CONVERT(BIT, CASE WHEN DatumBis IS NULL THEN 1 ELSE 0 END)
  FROM   dbo.FaLeistung WITH (READUNCOMMITTED)
  WHERE  FaFallID = @FaFallIDSrc AND FaProzessCode = 201 --Fallführung Alim
  ORDER BY DatumVon DESC -- es dürfte nur eine FF-Leistung geben

  -- Falls keine FF-Leistung im Zielfall da ist, diejenige des Quellfalls übernehmen (sollte eigentlich nicht vorkommen)
  IF( @FaLeistungFFDstID IS NULL ) BEGIN
	SET @FaLeistungFFDstID = @FaLeistungFFSrcID
  END

  -- Falls keine F(a)-Leistung im Zielfall da ist, diejenige des Quellfalls übernehmen
  IF( @FaLeistungAlimDstID IS NULL ) BEGIN
	SET @FaLeistungAlimDstID = @FaLeistungAlimSrcID
  END

  --Bis-Datum für FaFall bestimmen
  DECLARE @DatumBis datetime , @DatumVon datetime

  SET @DatumBis = CASE WHEN @FaFallIDSrcBis > @FaFallIDDstBis THEN @FaFallIDSrcBis ELSE @FaFallIDDstBis END
  SET @DatumVon = CASE WHEN @FaFallIDSrcVon < @FaFallIDDstVon THEN @FaFallIDSrcVon ELSE @FaFallIDDstVon END

  UPDATE FaFall
    SET  DatumBis = CASE WHEN @DatumBis = @DateMax THEN NULL ELSE @DatumBis END,
         DatumVon = IsNull(@DatumVon, DatumVon)
  WHERE  FaFallID = @FaFallIDDst

  --Bis-Datum für Fallführung bestimmen
  --SET @DatumBis = CASE WHEN @FaLeistungFFSrcBis > @FaLeistungFFDstBis THEN @FaLeistungFFSrcBis ELSE @FaLeistungFFDstBis END
  --SET @DatumVon = CASE WHEN @FaLeistungFFSrcVon < @FaLeistungFFDstVon THEN @FaLeistungFFSrcVon ELSE @FaLeistungFFDstVon END

  -- 31.03.2009 : sozheo : Logik Fallabschluss korrigiert, Mantis ##4468
  UPDATE FaLeistung SET
    DatumBis = CASE 
      -- Altes FF inaktiv, neues FF inaktiv -> fusioniertes FF inaktiv (Grösstes DatumBis wird gesetzt)? => JA.
      WHEN (@FfIstAktivSrc IS NULL OR @FfIstAktivSrc = 0)
       AND (@FfIstAktivDst IS NULL OR @FfIstAktivDst = 0)
        THEN CONVERT(DATETIME, dbo.fnMax(@FaLeistungFFDstBis, @FaLeistungFFSrcBis))
      -- Altes FF aktiv, neues FF aktiv -> fusioniertes FF aktiv? => JA
      -- Altes FF aktiv, neues FF inaktiv -> fusioniertes FF inaktiv? => Nein, FF muss aktiv bleiben.
      -- Altes FF inaktiv, neues FF aktiv -> fusioniertes FF aktiv? => JA
      ELSE  NULL 
    END,
    DatumVon = CONVERT(DATETIME, dbo.fnMin(@FaLeistungFFDstVon, @FaLeistungFFSrcVon))
  WHERE  FaLeistungID = @FaLeistungFFDstID

  --Bis-Datum für Alim-Fallführung bestimmen
  --SET @DatumBis = CASE WHEN @FaLeistungAlimSrcBis > @FaLeistungAlimDstBis THEN @FaLeistungAlimSrcBis ELSE @FaLeistungAlimDstBis END
  --SET @DatumVon = CASE WHEN @FaLeistungAlimSrcVon < @FaLeistungAlimDstVon THEN @FaLeistungAlimSrcVon ELSE @FaLeistungAlimDstVon END


  /*
  31.03.2009 : sozheo : Logik Fallabschluss korrigiert
  Mantis ##4468:
  Konstellation war so: Fall X - inaktives Fa. Fall Y - kein Fa. Nach Fusion aktives Fa.
  Gemäss der Logik-Anfrage folgende Rückmeldung:
  Altes FA aktiv, neues FA aktiv -> fusioniertes FA aktiv? => JA
  Altes FA aktiv, neues FA inaktiv -> fusioniertes FA inaktiv? => Nein, Fa muss aktiv bleiben.
  Altes FA inaktiv, neues FA aktiv -> fusioniertes FA aktiv? => JA
  Altes FA inaktiv, neues FA inaktiv -> fusioniertes FA inaktiv (Grösstes DatumBis wird gesetzt)? => JA.
  */

  UPDATE FaLeistung SET 
    DatumBis = CASE 
      -- Altes FA inaktiv, neues FA inaktiv -> fusioniertes FA inaktiv (Grösstes DatumBis wird gesetzt)? => JA.
      WHEN (@FaIstAktivSrc IS NULL OR @FaIstAktivSrc = 0)
       AND (@FaIstAktivDst IS NULL OR @FaIstAktivDst = 0)
        THEN CONVERT(DATETIME, dbo.fnMax(@FaLeistungAlimDstBis, @FaLeistungAlimSrcBis))
      -- Altes FA aktiv, neues FA aktiv -> fusioniertes FA aktiv? => JA
      -- Altes FA aktiv, neues FA inaktiv -> fusioniertes FA inaktiv? => Nein, Fa muss aktiv bleiben.
      -- Altes FA inaktiv, neues FA aktiv -> fusioniertes FA aktiv? => JA
      ELSE  NULL 
    END,
    DatumVon = CONVERT(DATETIME, dbo.fnMin(@FaLeistungAlimDstVon, @FaLeistungAlimSrcVon))
  WHERE  FaLeistungID = @FaLeistungAlimDstID


  -- umhängen FaLeistung-Daten
  UPDATE FaDokumente
    SET  FaLeistungID = @FaLeistungFFDstID
  WHERE  FaLeistungID = @FaLeistungFFSrcID
  UPDATE FaDokumente
    SET  FaLeistungID = @FaLeistungAlimDstID
  WHERE  FaLeistungID = @FaLeistungAlimSrcID

  UPDATE FaAssessment
    SET  FaLeistungID = @FaLeistungFFDstID
  WHERE  FaLeistungID = @FaLeistungFFSrcID
  UPDATE FaAssessment
    SET  FaLeistungID = @FaLeistungAlimDstID
  WHERE  FaLeistungID = @FaLeistungAlimSrcID

  UPDATE FaCheckin
    SET  FaLeistungID = @FaLeistungFFDstID
  WHERE  FaLeistungID = @FaLeistungFFSrcID
  UPDATE FaCheckinAlim
    SET  FaLeistungID = @FaLeistungAlimDstID
  WHERE  FaLeistungID = @FaLeistungAlimSrcID

  UPDATE FaVoranmeldung
    SET  FaLeistungID = @FaLeistungFFDstID
  WHERE  FaLeistungID = @FaLeistungFFSrcID
  UPDATE FaVoranmeldung
    SET  FaLeistungID = @FaLeistungAlimDstID
  WHERE  FaLeistungID = @FaLeistungAlimSrcID

  UPDATE FaAbklaerung
    SET  FaLeistungID = @FaLeistungFFDstID
  WHERE  FaLeistungID = @FaLeistungFFSrcID
  UPDATE FaAbklaerung
    SET  FaLeistungID = @FaLeistungAlimDstID
  WHERE  FaLeistungID = @FaLeistungAlimSrcID

  UPDATE FaUnterlagen
    SET  FaLeistungID = @FaLeistungFFDstID
  WHERE  FaLeistungID = @FaLeistungFFSrcID
  UPDATE FaUnterlagen
    SET  FaLeistungID = @FaLeistungAlimDstID
  WHERE  FaLeistungID = @FaLeistungAlimSrcID

  UPDATE FaRessourcenkarte
    SET  FaLeistungID = @FaLeistungFFDstID
  WHERE  FaLeistungID = @FaLeistungFFSrcID
  UPDATE FaRessourcenkarte
    SET  FaLeistungID = @FaLeistungAlimDstID
  WHERE  FaLeistungID = @FaLeistungAlimSrcID

  UPDATE FaPhase
    SET  FaLeistungID = @FaLeistungFFDstID
  WHERE  FaLeistungID = @FaLeistungFFSrcID
  UPDATE FaPhase
    SET  FaLeistungID = @FaLeistungAlimDstID
  WHERE  FaLeistungID = @FaLeistungAlimSrcID

  UPDATE FaAktennotizen
    SET  FaLeistungID = @FaLeistungFFDstID
  WHERE  FaLeistungID = @FaLeistungFFSrcID
  UPDATE FaAktennotizen
    SET  FaLeistungID = @FaLeistungAlimDstID
  WHERE  FaLeistungID = @FaLeistungAlimSrcID

  UPDATE FaJournal
    SET  FaLeistungID = @FaLeistungFFDstID
  WHERE  FaLeistungID = @FaLeistungFFSrcID
  UPDATE FaJournal
    SET  FaLeistungID = @FaLeistungAlimDstID
  WHERE  FaLeistungID = @FaLeistungAlimSrcID

  UPDATE FaLeistungArchiv
    SET  FaLeistungID = @FaLeistungFFDstID
  WHERE  FaLeistungID = @FaLeistungFFSrcID
  UPDATE FaLeistungArchiv
    SET  FaLeistungID = @FaLeistungAlimDstID
  WHERE  FaLeistungID = @FaLeistungAlimSrcID

  UPDATE SRC
    SET  FaLeistungID = @FaLeistungFFDstID
  FROM   FaLeistungZugriff      SRC
    LEFT JOIN FaLeistungZugriff DST ON SRC.UserID = DST.UserID AND SRC.FaLeistungID = @FaLeistungFFSrcID AND DST.FaLeistungID = @FaLeistungFFDstID
  WHERE  SRC.FaLeistungID = @FaLeistungFFSrcID AND DST.FaLeistungID IS NULL

  UPDATE SRC
    SET  FaLeistungID = @FaLeistungAlimDstID
  FROM   FaLeistungZugriff      SRC
    LEFT JOIN FaLeistungZugriff DST ON SRC.UserID = DST.UserID AND SRC.FaLeistungID = @FaLeistungAlimSrcID AND DST.FaLeistungID = @FaLeistungAlimDstID
  WHERE  SRC.FaLeistungID = @FaLeistungAlimSrcID AND DST.FaLeistungID IS NULL

  UPDATE FaZielvereinbarung
    SET  FaLeistungID = @FaLeistungFFDstID
  WHERE  FaLeistungID = @FaLeistungFFSrcID
  UPDATE FaZielvereinbarung
    SET  FaLeistungID = @FaLeistungAlimDstID
  WHERE  FaLeistungID = @FaLeistungAlimSrcID

  UPDATE FaRessourcenpaket
    SET  FaLeistungID = @FaLeistungFFDstID
  WHERE  FaLeistungID = @FaLeistungFFSrcID
  UPDATE FaRessourcenpaket
    SET  FaLeistungID = @FaLeistungAlimDstID
  WHERE  FaLeistungID = @FaLeistungAlimSrcID

  UPDATE FaZugriff
    SET  FaLeistungID = @FaLeistungFFDstID
  WHERE  FaLeistungID = @FaLeistungFFSrcID
  UPDATE FaZugriff
    SET  FaLeistungID = @FaLeistungAlimDstID
  WHERE  FaLeistungID = @FaLeistungAlimSrcID

  UPDATE FaCheckinAlim
    SET  FaLeistungID = @FaLeistungFFDstID
  WHERE  FaLeistungID = @FaLeistungFFSrcID
  UPDATE FaCheckinAlim
    SET  FaLeistungID = @FaLeistungAlimDstID
  WHERE  FaLeistungID = @FaLeistungAlimSrcID

  UPDATE FaAbmachung
    SET  FaLeistungID = @FaLeistungFFDstID
  WHERE  FaLeistungID = @FaLeistungFFSrcID
  UPDATE FaAbmachung
    SET  FaLeistungID = @FaLeistungAlimDstID
  WHERE  FaLeistungID = @FaLeistungAlimSrcID

  UPDATE FaWeitereLeistungserbringer
    SET  FaLeistungID = @FaLeistungFFDstID
  WHERE  FaLeistungID = @FaLeistungFFSrcID
  UPDATE FaWeitereLeistungserbringer
    SET  FaLeistungID = @FaLeistungAlimDstID
  WHERE  FaLeistungID = @FaLeistungAlimSrcID

  UPDATE XTask
    SET  FaLeistungID = @FaLeistungFFDstID
  WHERE  FaLeistungID = @FaLeistungFFSrcID
  UPDATE XTask
    SET  FaLeistungID = @FaLeistungAlimDstID
  WHERE  FaLeistungID = @FaLeistungAlimSrcID

  UPDATE FaTeilLeistungserbringer
    SET  FaLeistungID = @FaLeistungFFDstID
  WHERE  FaLeistungID = @FaLeistungFFSrcID
  UPDATE FaTeilLeistungserbringer
    SET  FaLeistungID = @FaLeistungAlimDstID
  WHERE  FaLeistungID = @FaLeistungAlimSrcID

  UPDATE FaAbklaerung
    SET  FaLeistungID = @FaLeistungFFDstID
  WHERE  FaLeistungID = @FaLeistungFFSrcID
  UPDATE FaAbklaerung
    SET  FaLeistungID = @FaLeistungAlimDstID
  WHERE  FaLeistungID = @FaLeistungAlimSrcID

  UPDATE FaCheckinAlim
    SET  FaLeistungID = @FaLeistungFFDstID
  WHERE  FaLeistungID = @FaLeistungFFSrcID
  UPDATE FaCheckinAlim
    SET  FaLeistungID = @FaLeistungAlimDstID
  WHERE  FaLeistungID = @FaLeistungAlimSrcID

  -- umhängen FaFall
  UPDATE FaInvolvierteInstitution
    SET FaFallID = @FaFallIDDst
  WHERE FaFallID = @FaFallIDSrc

  UPDATE FaInvolviertePerson
    SET FaFallID = @FaFallIDDst
  WHERE FaFallID = @FaFallIDSrc

  UPDATE FaJournal
    SET FaFallID = @FaFallIDDst
  WHERE FaFallID = @FaFallIDSrc

  UPDATE FaZugriff
    SET FaFallID = @FaFallIDDst
  WHERE FaFallID = @FaFallIDSrc

  UPDATE XTask
    SET FaFallID = @FaFallIDDst
  WHERE FaFallID = @FaFallIDSrc

  UPDATE dbo.WhAbrechnung
    SET FaFallID = @FaFallIDDst
  WHERE FaFallID = @FaFallIDSrc

  INSERT INTO FaJournal( FaFallID, FaLeistungID, BaPersonID, UserID, Datum, FaJournalCode, [Text], ManuellerEintrag, OrgUnitID )
  SELECT FaFallID, FaLeistungID, LEI.BaPersonID, @UserID, GetDate(), 1, 'Leistung in Fall eingefügt. Typ: ' + dbo.fnLOVText('FaProzess', FaProzessCode) + ', Leistungsträger: ' + PRS.NameVorname + ', Leistungsverantwortlicher' + USR.DisplayText, 0, @OrgUnitID
  FROM dbo.FaLeistung       LEI WITH (READUNCOMMITTED)
    INNER JOIN vwUser   USR ON USR.UserID     = LEI.UserID
    INNER JOIN vwPerson PRS ON PRS.BaPersonID = LEI.BaPersonID
  WHERE FaFallID = @FaFallIDSrc
     AND (FaLeistungID <> @FaLeistungFFSrcID   OR @FaLeistungFFSrcID   = @FaLeistungFFDstID)   -- FF-Leistung übernehmen, falls keine im Ziel-Fall
     AND (FaLeistungID <> @FaLeistungAlimSrcID OR @FaLeistungAlimSrcID = @FaLeistungAlimDstID) -- F(a)-Leistung übernehmen, falls keine im Ziel-Fall

  UPDATE FaLeistung
    SET FaFallID = @FaFallIDDst, Modifier = @CreatorModifier, Modified = GetDate()
  WHERE FaFallID = @FaFallIDSrc
     AND (@FaLeistungFFSrcID IS NULL OR FaLeistungID <> @FaLeistungFFSrcID   OR @FaLeistungFFSrcID   = @FaLeistungFFDstID)   -- FF-Leistung übernehmen, falls keine im Ziel-Fall
     AND (@FaLeistungAlimSrcID IS NULL OR FaLeistungID <> @FaLeistungAlimSrcID OR @FaLeistungAlimSrcID = @FaLeistungAlimDstID) -- F(a)-Leistung übernehmen, falls keine im Ziel-Fall

  -- Klientensystem fusionieren
  INSERT INTO FaFallPerson (FaFallID, BaPersonID, DatumVon, DatumBis)
  SELECT @FaFallIDDst, BaPersonID, MIN(DatumVon), MAX(DatumBis)
  FROM dbo.FaFallPerson WITH (READUNCOMMITTED)
  WHERE FaFallID = @FaFallIDSrc AND BaPersonID NOT IN (SELECT BaPersonID FROM FaFallPerson WHERE FaFallID = @FaFallIDDst) AND BaPersonID IS NOT NULL
  GROUP BY BaPersonID

  DELETE FROM FaFallPerson
  WHERE FaFallID = @FaFallIDSrc

  -- WV-Einheiten fusionieren
  UPDATE WhWVEinheit
  SET Ungueltig = 1, FaFallID = @FaFallIDDst
  WHERE FaFallID = @FaFallIDSrc

  BEGIN TRY
    EXEC dbo.spWhWVModifyUnits @FaFallIDDst
  END TRY
  BEGIN CATCH
  END CATCH

  -- Die übriggebliebenen Leistungen (FF, F(a)) löschen
  SELECT *
  FROM FaLeistung
  WHERE FaFallID = @FaFallIDSrc

  DELETE FROM FaLeistung
  WHERE FaFallID = @FaFallIDSrc

  -- Den Quell-Fall löschen
  DELETE FROM FaFall
  WHERE FaFallID = @FaFallIDSrc

END

