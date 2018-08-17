SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnCKWshHaushaltPersonIntegrity;
GO
/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Checks data integrity on table WshHaushaltPerson.
    @BaPersonID: BaPersonID to check
    @DatumVon:   date from
    @DatumBis:   date to
  -
  RETURNS: 0 = OK, !0 = Error
=================================================================================================
  TEST:    SELECT dbo.fnCKWshHaushaltPersonIntegrity(NULL, 1, 1, 1, '20110101', '20111231');
=================================================================================================*/

CREATE FUNCTION dbo.fnCKWshHaushaltPersonIntegrity
(
  @WshHaushaltPersonID INT,
  @FaLeistungID INT,
  @BaPersonID INT,
  @Unterstuetzt BIT,
  @DatumVon DATETIME,
  @DatumBis DATETIME
)
RETURNS BIT
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- Data integrity checks
  -----------------------------------------------------------------------------
  -- DatumVon > DatumBis
  IF (@DatumVon > @DatumBis)
  BEGIN
    RETURN 1;
  END;

  -- Ist diese Person in dieser Zeitdauer bereits unterstützt
  DECLARE @MehrfachUnterstuetzt BIT;
  SET @MehrfachUnterstuetzt = CONVERT(BIT, dbo.fnXConfig('System\Sozialhilfe\FinanzPlan\Check_PersonIn2FpUnterstuetzt', GETDATE()));

  IF (@MehrfachUnterstuetzt = 1)
  BEGIN
    IF (EXISTS (SELECT TOP 1 1
                FROM dbo.WshHaushaltPerson WHP
                WHERE WHP.WshHaushaltPersonID <> ISNULL(@WshHaushaltPersonID, -1)
                  AND WHP.Unterstuetzt = 1
                  AND @Unterstuetzt = 1
                  AND WHP.BaPersonID = @BaPersonID
                  AND dbo.fnDatumUeberschneidung(WHP.DatumVon, WHP.DatumBis, @DatumVon, @DatumBis) <> 0))
    BEGIN
      RETURN 2;
    END;
  END;

  -- TODO: wieder aktivieren, sobald die Migration mit bereinigten Daten ausgeführt wird
  ---- Ist diese Person bereits in diesem Haushalt
  --IF (EXISTS (SELECT TOP 1 1
  --            FROM dbo.WshHaushaltPerson WHP
  --            WHERE WHP.WshHaushaltPersonID <> ISNULL(@WshHaushaltPersonID, -1)
  --              AND WHP.FaLeistungID = @FaLeistungID
  --              AND WHP.BaPersonID = @BaPersonID
  --              AND dbo.fnDatumUeberschneidung(WHP.DatumVon, WHP.DatumBis, @DatumVon, @DatumBis) <> 0))
  --BEGIN
  --  RETURN 3;
  --END;

  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN 0;
END;
GO
