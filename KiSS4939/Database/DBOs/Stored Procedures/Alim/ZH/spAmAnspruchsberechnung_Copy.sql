SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spAmAnspruchsberechnung_Copy
GO
/*===============================================================================================
  $Revision: 4$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

-- =================================================================================================
-- Author:		sozheo
-- Create date: 07.10.2007
-- Description:	Anspruchsberechnung kopieren
-- Testen: EXEC dbo.spAmAnspruchsberechnung_Copy 25
-- =================================================================================================
-- History:
-- 07.10.2007 : sozheo : Neu
-- 30.10.2007 : sozheo : Neue Paramteer
-- 04.11.2007 : sozheo : Anpassungen für KKBB
-- 09.11.2007 : sozheo : Status = in Vorbereitung
-- 14.11.2007 : sozheo : Anpassungen für KKBB
-- 20.11.2007 : sozheo : Anpassungen für Zusammmenzug ALBV und UeBH
-- 22.11.2007 : sozheo : Anpassungen für Zusammmenzug ALBV und UeBH
-- 10.01.2008 : sozheo : AmAbKind.DatumBis wird jetzt auch kopiert
-- 02.02.2008 : sozheo : Tabellen umbennen
-- 05.02.2008 : sozheo : Neue Felder auch kopieren
-- 25.03.2008 : sozheo : Entscheiddatum entfernt
-- 25.03.2008 : sozheo : neu Rechtstitel

-- =================================================================================================

CREATE PROCEDURE [dbo].[spAmAnspruchsberechnung_Copy]
  -- Typ: 1 = ALBV, 2 = üBH, 3 = KKBB
  @Typ INT,
  -- Schlüssel Anspruchsberechnung:
  @AnspruchsberechnungID INT,
  -- Neue Bezeichnung:
  @NewCaption varchar(100),
  -- Neues Datum BerechnungAb:
  @NewDate DATETIME,
  -- Neuer Lohnbetrag 1 des 1. Verdieners:
  @NewSalary1 money,
  -- Neuer Lohnbetrag 1 des 2. Verdieners:
  @NewSalary2 money
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON

  IF @Typ IS NULL OR @Typ > 3 OR @Typ < 1  BEGIN
    SELECT 1 AS HasError, 'Der Parameter @Typ ist ungültig.' AS ErrorText
    RETURN
  END
  IF @AnspruchsberechnungID IS NULL BEGIN
    SELECT 1 AS HasError, 'Der Parameter @AnspruchsberechnungID ist ungültig.' AS ErrorText
    RETURN
  END

  DECLARE @NewAnspruchsberechnungID INT
  DECLARE @ZivilstandCode INT


  -- Alte Daten holen
  SELECT
    @ZivilstandCode = A.AmBerechnungTypCode
  FROM dbo.AmAnspruchsberechnung A WITH (READUNCOMMITTED)
  WHERE A.AmAnspruchsberechnungID = @AnspruchsberechnungID

  -- AmAnspruchsberechnung:
  INSERT INTO AmAnspruchsberechnung (
    FaLeistungID,
    Bezeichnung,
    BerechnungDatumAb,
    AmBerechnungTypCode,
    AmBerechnungsStatusCode,
    AmEinkommensvarianteCode,
    ErstkontaktDatum,
    UserID,
    Mandant_UserID,
    Mandant_InstitutionID,
    ArbeitspensumKKBBProz,
    KinderbetreuungKKBBTgWoche
  )
  SELECT
    A.FaLeistungID,
    @NewCaption,
    @NewDate,
    A.AmBerechnungTypCode,
    1, -- A.AmBerechnungsStatusCode, : Angefragt: Besser in Vorbereitung
    A.AmEinkommensvarianteCode,
    A.ErstkontaktDatum,
    A.UserID,
    A.Mandant_UserID,
    A.Mandant_InstitutionID,
    A.ArbeitspensumKKBBProz,
    A.KinderbetreuungKKBBTgWoche
  FROM dbo.AmAnspruchsberechnung A WITH (READUNCOMMITTED)
  WHERE A.AmAnspruchsberechnungID = @AnspruchsberechnungID
  SET @NewAnspruchsberechnungID = SCOPE_IDENTITY()


  DECLARE @AmAbKindID INT
  DECLARE @NewAmAbKindID INT
  DECLARE @BaPersonID INT
  DECLARE @AmAbPositionsartID1 INT
  DECLARE @AmAbPositionsartID2 INT
  DECLARE @BerechtigtCode INT
  DECLARE @IkRechtstitelID INT
  DECLARE @TabChilds TABLE ( OldChildID INT, NewChildID INT )

  -- Kinder einfügen
  DECLARE CursorChilds CURSOR FOR
    SELECT
      K.AmAbKindID,
      K.BaPersonID,
      K.BerechtigtCode,
      K.IkRechtstitelID
    FROM AmAbKind K
    WHERE K.AmAnspruchsberechnungID = @AnspruchsberechnungID
  OPEN CursorChilds

  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM CursorChilds INTO @AmAbKindID, @BaPersonID, @BerechtigtCode, @IkRechtstitelID
    IF NOT @@FETCH_STATUS = 0 BREAK

    -- AmAbKind:
    INSERT INTO AmAbKind (
      AmAnspruchsberechnungID,
      BaPersonID,
      BerechtigtCode,
      DatumBis,
      IkRechtstitelID )
    SELECT
      @NewAnspruchsberechnungID,
      K.BaPersonID,
      K.BerechtigtCode,
      K.DatumBis,
      K.IkRechtstitelID
    FROM dbo.AmAbKind K WITH (READUNCOMMITTED)
    WHERE K.AmAbKindID = @AmAbKindID
    SET @NewAmAbKindID = SCOPE_IDENTITY()

    INSERT INTO @TabChilds (OldChildID, NewChildID) VALUES (@AmAbKindID, @NewAmAbKindID)
  END
  CLOSE CursorChilds
  DEALLOCATE CursorChilds


  -- AmAbPosition:
  INSERT INTO AmAbPosition (
    AmAnspruchsberechnungID,
    AmAbPositionsartID,
    AmAbKindID,
    ParentID,
    Text,
    DatumVon,
    Sortierung1,
    Sortierung2,
    Wert1,
    Mengeneinheit1,
    Format1,
    Wert2,
    Mengeneinheit2,
    Format2,
    Wert3,
    Bemerkung
  )
  SELECT
    @NewAnspruchsberechnungID,
    A.AmAbPositionsartID,
    CASE
      WHEN A.AmAbKindID IS NULL THEN NULL
      ELSE ( SELECT Q.NewChildID FROM @TabChilds Q WHERE Q.OldChildID = A.AmAbKindID )
    END,
    A.ParentID,
    A.Text,
    A.DatumVon,
    A.Sortierung1,
    A.Sortierung2,
    A.Wert1,
    A.Mengeneinheit1,
    A.Format1,
    A.Wert2,
    A.Mengeneinheit2,
    A.Format2,
    A.Wert3,
    A.Bemerkung
  FROM dbo.AmAbPosition A WITH (READUNCOMMITTED)
  WHERE A.AmAnspruchsberechnungID = @AnspruchsberechnungID

  -- Daten aus der Konfiguration holen:
  EXEC dbo.spAmAnspruchsberechnung_UpdateConfigAll @Typ, @NewAnspruchsberechnungID, @ZivilstandCode, @NewDate

  -- Neue Daten einfügen:
  IF @Typ = 1 BEGIN
    SET @AmAbPositionsartID1 = 31
    SET @AmAbPositionsartID2 = 131
  END ELSE BEGIN
    SET @AmAbPositionsartID1 = 3031
    SET @AmAbPositionsartID2 = 3131
  END
  -- Lohn 1 des 1. Verdieners
  UPDATE AmAbPosition SET Wert1 = @NewSalary1
  WHERE AmAnspruchsberechnungID = @NewAnspruchsberechnungID
    AND AmAbPositionsartID = @AmAbPositionsartID1
  -- Lohn 1 des 1. Verdieners
  UPDATE AmAbPosition SET Wert1 = @NewSalary2
  WHERE AmAnspruchsberechnungID = @NewAnspruchsberechnungID
    AND AmAbPositionsartID = @AmAbPositionsartID2

  -- Resultat liefern:
  SELECT 0 AS HasError, '' AS ErrorText, @NewAnspruchsberechnungID AS NewAnspruchsberechnungID

END

