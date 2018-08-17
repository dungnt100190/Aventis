SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spIkMonatszahlen_DetailAll
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST: EXEC dbo.spIkMonatszahlen_DetailAll NULL, 2008, 1
===================================================================================================*/

CREATE PROCEDURE dbo.spIkMonatszahlen_DetailAll
  -- Leistung
  @LeistungID INT,
  -- Rechtstitel
  @RechtstitelID INT,
  -- Modus: 
  -- 1 = Alle Daten eines Rechtstitels
  -- 2 = Nur fehlende Monate am ergänzen
  @Modus INT
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON
  
  -- ---------------------------------------------------
  -- Kontrollen der Parameter
  -- ---------------------------------------------------
  IF (@RechtstitelID IS NULL OR @RechtstitelID = 0) AND (@LeistungID IS NULL OR @LeistungID = 0)
  BEGIN
    --SELECT 1 AS HasErrors, 'Fehler in Parameter: Der Parameter @RechtstitelID oder @LeistungID ist ungültig.' AS ErrorText
    RETURN -1;
  END;

  IF (@Modus IS NULL OR @Modus < 1 OR @Modus > 2)
  BEGIN
    --SELECT 1 AS HasErrors, 'Fehler in Parameter: Der Parameter @Modus ist ungültig.' AS ErrorText
    RETURN -2;
  END;

  DECLARE
    @MaxDatum            DATETIME,
    @MinDatum            DATETIME,
    @MinDatumForderung   DATETIME,
    @MinDatumPosition    DATETIME,
    @MinDatumVerrechg    DATETIME,
    @MinDatumAB          DATETIME,
    @ActDate             DATETIME,
    @Month               INT,
    @Year                INT,
    @LineCounts          INT,
    @ErrorCounts         INT,
    @ErrorResult         INT,
    @Result              INT,
    @monateVergangenheit INT,
    @monateZukunft       INT;

  SELECT @monateZukunft = CONVERT(INT, dbo.fnXConfig('System\Inkasso\MonatszahlenMonateZukunft', GETDATE()));

  IF (@monateZukunft IS NULL)
  BEGIN
    SET @monateZukunft = 2;
  END;

  -- Maximum holen    
  SET @MaxDatum = GETDATE();
  SET @MaxDatum = DATEADD(MONTH, @monateZukunft, @MaxDatum);
  SET @MaxDatum = dbo.fnDateSerial(YEAR(@MaxDatum), MONTH(@MaxDatum), 1);

  IF (@Modus = 1)
  BEGIN
    -- 1 = Alle Daten eines Rechtstitels
    -- ---------------------------------
    -- Wir müssen alle Daten eines Rechtstitel neu berechnen, 
    -- also zuerst das Minimum aller Daten suchen:
    -- Forderungen
    SELECT @MinDatumForderung = MIN(DatumAnpassenAb)
    FROM dbo.IkForderung WITH (READUNCOMMITTED)
    WHERE ((IkRechtstitelID = @RechtstitelID AND @LeistungID IS NULL)
       OR (FaLeistungID = @LeistungID AND @RechtstitelID IS NULL));

    -- Montaszahlen
    SELECT @MinDatumPosition = MIN(Datum) 
    FROM dbo.IkPosition WITH (READUNCOMMITTED) 
    WHERE ((IkRechtstitelID = @RechtstitelID AND @LeistungID IS NULL)
       OR (FaLeistungID = @LeistungID AND @RechtstitelID IS NULL))
      AND Einmalig = 0;

    -- Verrechnungskonto
    SELECT @MinDatumVerrechg = MIN(DatumVon)
    FROM dbo.IkVerrechnungskonto WITH (READUNCOMMITTED)
    WHERE IkRechtstitelID = @RechtstitelID;

    -- Miminum holen    
    SET @MinDatum = GETDATE();
    SET @MinDatum = CONVERT(DATETIME, (SELECT dbo.fnMIN(@MinDatum, ISNULL(@MinDatumForderung, '99990101'))));
    SET @MinDatum = CONVERT(DATETIME, (SELECT dbo.fnMIN(@MinDatum, ISNULL(@MinDatumPosition, '99990101'))));
    SET @MinDatum = CONVERT(DATETIME, (SELECT dbo.fnMIN(@MinDatum, ISNULL(@MinDatumAB, '99990101'))));
  END
  ELSE BEGIN
    -- 2 = Nur fehlende Monate am ergänzen
    -- -----------------------------------
    -- also zuerst zuletzt gespeicherter Monat suchen
    SELECT @MinDatum = MAX(Datum)
    FROM dbo.IkPosition WITH (READUNCOMMITTED)
    WHERE ((IkRechtstitelID = @RechtstitelID AND @LeistungID IS NULL)
       OR (FaLeistungID = @LeistungID AND @RechtstitelID IS NULL))
      AND Einmalig = 0;

    IF (@MinDatum IS NULL)
    BEGIN
      SET @MinDatum = GETDATE();
      SET @MinDatum = dbo.fnDateSerial(YEAR(@MinDatum), MONTH(@MinDatum), 1);
      SET @MinDatum = DateAdd(MONTH, -1, @MinDatum);
    END;
  END;

  SET @Month = MONTH(@MinDatum);
  SET @Year = YEAR(@MinDatum);
  SET @ActDate = dbo.fnDateSerial(@Year, @Month, 1);
  SET @LineCounts = 0;
  SET @ErrorCounts = 0;
  SET @ErrorResult = 0;

  -- für alle Monate berechnen
  WHILE (@ActDate <= @MaxDatum)
  BEGIN
    SET @Month = MONTH(@ActDate);
    SET @Year = YEAR(@ActDate);
    -- Berechnung eines Rechtstitels
    EXEC @Result = dbo.spIkMonatszahlen_Detail @LeistungID, @RechtstitelID, @Year, @Month;

    IF (@Result >= 0)
    BEGIN
      SET @LineCounts = @LineCounts + @Result;
    END
    ELSE BEGIN
      SET @ErrorCounts = @ErrorCounts + 1;
      SET @ErrorResult = @Result - 1000;
    END;

    SET @ActDate = DATEADD(MONTH, 1, @ActDate);
  END;

  -- Resultat
  IF (@ErrorCounts > 0)
  BEGIN
    RETURN @ErrorResult;
  END
  ELSE BEGIN
    RETURN @LineCounts;
  END;
END;
GO