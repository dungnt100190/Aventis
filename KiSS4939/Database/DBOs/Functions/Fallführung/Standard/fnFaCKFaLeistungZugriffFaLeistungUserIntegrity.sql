SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
-------------------------------------------------------------------------------
-- we need to drop constraint first
-------------------------------------------------------------------------------
IF (EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_FaLeistungZugriffFaLeistungUserIntegrity]') AND parent_object_id = OBJECT_ID(N'[dbo].[FaLeistungZugriff]')))
BEGIN
  ALTER TABLE [dbo].[FaLeistungZugriff] DROP CONSTRAINT [CK_FaLeistungZugriffFaLeistungUserIntegrity];
  
  PRINT ('Info: Dropped constraint "CK_FaLeistungZugriffFaLeistungUserIntegrity"');
END
-------------------------------------------------------------------------------
GO
EXECUTE dbo.spDropObject fnFaCKFaLeistungZugriffFaLeistungUserIntegrity;
GO

/*===============================================================================================
  $Revision: 3 $
=================================================================================================

  SUMMARY: Prüft die Integrität der Tabelle FaLeistungZugriff
  
  RETURNS: "0" für gültige Einträge
           "1" falls die Parameter nicht gültig sind
           "2" falls es für den gegebenen Benutzer und die Leistung Datumsüberscheidungen gibt
                  Das DatumBis ist beim Prüfen der Überschneidung nicht inklusiv (Bis am 31.01.2015 bedeutet, dass der Benutzer am 30.01.2015 Zugriff hat, aber am 31.01.2015 nicht mehr)

  TEST:    
=================================================================================================*/

CREATE FUNCTION dbo.fnFaCKFaLeistungZugriffFaLeistungUserIntegrity
(
  @FaLeistungZugriffID INT,
  @FaLeistungID INT,
  @UserID INT,
  @DatumVon DATETIME,
  @DatumBis DATETIME
)
RETURNS INT
AS
BEGIN

  IF (@DatumVon IS NULL)
  BEGIN
    RETURN 1;
  END;

  IF (@DatumVon > ISNULL(@DatumBis, '99991231'))
  BEGIN
    RETURN 1;
  END;

  IF EXISTS(SELECT TOP 1 1 
            FROM dbo.FaLeistungZugriff
            WHERE 1=1
              AND FaLeistungZugriffID <> @FaLeistungZugriffID
              AND FaLeistungID = @FaLeistungID
              AND UserID = @UserID
              AND ISNULL(DatumBis, '99991231') > ISNULL(@DatumVon, '17530101')
              AND ISNULL(DatumVon, '17530101') < ISNULL(@DatumBis, '99991231')
           )
  BEGIN
    RETURN 2;
  END;
     
  RETURN 0;
  
END;
GO

-------------------------------------------------------------------------------
-- we need to recreate constraint
-------------------------------------------------------------------------------
IF (EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FaLeistungZugriff]') AND type in (N'U')))
BEGIN
  ALTER TABLE [dbo].[FaLeistungZugriff] WITH NOCHECK 
  ADD CONSTRAINT [CK_FaLeistungZugriffFaLeistungUserIntegrity] 
  CHECK (([dbo].[fnFaCKFaLeistungZugriffFaLeistungUserIntegrity]([FaLeistungZugriffID], [FaLeistungID],[UserID],[DatumVon],[DatumBis])=(0)));
  
  ALTER TABLE [dbo].[FaLeistungZugriff] CHECK CONSTRAINT [CK_FaLeistungZugriffFaLeistungUserIntegrity];

  EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Checks for valid FaLeistungZugriff records' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistungZugriff', @level2type=N'CONSTRAINT',@level2name=N'CK_FaLeistungZugriffFaLeistungUserIntegrity';
  
  PRINT ('Info: ReCreated constraint "CK_FaLeistungZugriffFaLeistungUserIntegrity"');
END;
GO
-------------------------------------------------------------------------------

