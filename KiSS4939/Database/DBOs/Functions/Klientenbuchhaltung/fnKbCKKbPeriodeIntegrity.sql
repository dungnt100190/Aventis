SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
-------------------------------------------------------------------------------
-- drop constraint if it exists
-------------------------------------------------------------------------------
IF (EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_KbPeriode_DataIntegrity]') AND parent_object_id = OBJECT_ID(N'[dbo].[KbPeriode]')))
BEGIN
  ALTER TABLE [dbo].[KbPeriode] DROP CONSTRAINT [CK_KbPeriode_DataIntegrity];
  
  PRINT ('Info: Dropped constraint "CK_KbPeriode_DataIntegrity"');
END
-------------------------------------------------------------------------------
GO
EXECUTE dbo.spDropObject fnKbCKKbPeriodeIntegrity;
GO
/*===============================================================================================
  $Revision: 1$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Check data integrity for table KbPeriode
  -
  RETURNS: 0 if data is valid, 1 if the supplied date ranges are invalid, 2 if there is another time period at the same time
=================================================================================================
  TEST:    SELECT dbo.fnKbCKKbPeriodeIntegrity(x, x, '20140101', '20141231');
=================================================================================================*/

CREATE FUNCTION dbo.fnKbCKKbPeriodeIntegrity
(
  @KbPeriodeID INT,
  @KbMandantID INT,
  @PeriodeVon DATETIME,
  @PeriodeBis DATETIME
)
RETURNS INT
AS 
BEGIN
  SET @PeriodeVon = ISNULL(@PeriodeVon, '17530101');
  SET @PeriodeBis = ISNULL(@PeriodeBis, '99991231');

  -- PeriodeVon/-Bis
  IF (@PeriodeVon > @PeriodeBis)
  BEGIN
    RETURN 1;
  END;
  
  -- Andere Perioden prüfen
  IF (EXISTS(SELECT TOP 1 1
             FROM dbo.KbPeriode
             WHERE KbMandantID = @KbMandantID
               AND KbPeriodeID <> @KbPeriodeID
               AND dbo.fnDatumUeberschneidung(@PeriodeVon, @PeriodeBis, PeriodeVon, PeriodeBis) = 1))
  BEGIN
    RETURN 2;
  END;

  RETURN 0;
END;
GO

-------------------------------------------------------------------------------
-- create constraint
-------------------------------------------------------------------------------
IF (EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KbPeriode]') AND type in (N'U')))
BEGIN
  ALTER TABLE [dbo].[KbPeriode] WITH NOCHECK 
  ADD CONSTRAINT [CK_KbPeriode_DataIntegrity] 
  CHECK (([dbo].[fnKbCKKbPeriodeIntegrity]([KbPeriodeID],[KbMandantID],[PeriodeVon],[PeriodeBis])=(0)));
  
  ALTER TABLE [dbo].[KbPeriode] CHECK CONSTRAINT [CK_KbPeriode_DataIntegrity];

  EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Checks for valid KbPeriode records' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbPeriode', @level2type=N'CONSTRAINT',@level2name=N'CK_KbPeriode_DataIntegrity';
  
  PRINT ('Info: ReCreated constraint "CK_KbPeriode_DataIntegrity"');
END;
GO
