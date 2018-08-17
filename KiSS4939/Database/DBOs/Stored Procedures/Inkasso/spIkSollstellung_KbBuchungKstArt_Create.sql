SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spIkSollstellung_KbBuchungKstArt_Create
GO
/*===============================================================================================
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
=================================================================================================*/

CREATE PROCEDURE dbo.spIkSollstellung_KbBuchungKstArt_Create
  -- ID der Hautpbuchung:
  @KbBuchungNewID INT,
  -- Typ:
  @Typ1 INT,
  -- Buchungstext:
  @Buchungstext varchar(200),
  -- Person:
  @BaPersonID INT,
  -- Betrag:
  @Betrag money,
  -- Belegnummer:
  @Beleg INT,
  -- BgKostenartID
  @BgKostenartID INT,
  -- Verwendete Periode
  @PeriodeDatum DATETIME
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON;

  -- --------------------------------
  -- Kontrollen:
  -- --------------------------------
  IF (@KbBuchungNewID IS NULL)
  BEGIN
    RETURN -1;
  END;

  IF (@Betrag IS NULL OR @Betrag = 0)
  BEGIN
    RETURN 0;
  END;

  -- ------------------------------------------
  -- Kontierung und Teilvorgänge bestimmen:
  -- ------------------------------------------
  DECLARE @KontoNr VARCHAR(10);

  SELECT TOP 1
    @KontoNr = KontoNr
  FROM dbo.BgKostenart WITH (READUNCOMMITTED) 
  WHERE BgKostenartID = @BgKostenartID;

  DECLARE @KbKostenstelleID INT;
  SELECT @KbKostenstelleID = KbKostenstelleID 
  FROM dbo.KbKostenstelle_BaPerson WITH (READUNCOMMITTED) 
  WHERE BaPersonID = @BaPersonID;

  IF (@KbKostenstelleID IS NULL)
  BEGIN
    SET @KbKostenstelleID = -1; -- Migrationskostenstelle!
  END;

  -- --------------------------------
  -- Werte von Kostenart abfragen:
  -- --------------------------------
  -- Variablen deklarieren
  DECLARE @BgSplittingArtCode INT;
  DECLARE @Weiterverrechenbar BIT;
  DECLARE @Quoting            BIT;

  -- Werte holen
  SELECT @BgSplittingArtCode = KOA.BgSplittingArtCode,
         @Weiterverrechenbar = CASE WHEN KOA.BaWVZeileCode IS NOT NULL THEN 1 ELSE 0 END,
         @Quoting            = KOA.Quoting
  FROM dbo.BgKostenart KOA WITH (READUNCOMMITTED)
  WHERE KOA.BgKostenartID = @BgKostenartID;

  -- --------------------------------
  -- Einfügen:
  -- --------------------------------
  INSERT INTO KbBuchungKostenart (
    KbBuchungID,
    KbKostenstelleID,
    BgKostenartID,
    BaPersonID,
    Buchungstext,
    Betrag,
    KontoNr,
    PositionImBeleg,
    KbForderungArtCode, 
    VerwPeriodeVon, VerwPeriodeBis,
    BgSplittingArtCode, Weiterverrechenbar, Quoting)
  VALUES (
    -- KbBuchungID,
    @KbBuchungNewID,
    -- KbKostenstelleID 
    @KbKostenstelleID,
    -- BgKostenartID
    @BgKostenartID,
    -- BaPersonID,
    @BaPersonID,
    -- Buchungstext,
    @Buchungstext,
    -- Betrag,
    @Betrag,
    -- KontoNr,
    @KontoNr,
    -- PositionImBeleg,
    @Beleg,
    -- KbForderungArtCode
    @Typ1,
    -- von
    dbo.fnFirstDayOf(@PeriodeDatum),
    -- bis
    dbo.fnLastDayOf(@PeriodeDatum),
    -- KOA-Werte
    @BgSplittingArtCode, @Weiterverrechenbar, @Quoting);

  RETURN 0;
END;
GO