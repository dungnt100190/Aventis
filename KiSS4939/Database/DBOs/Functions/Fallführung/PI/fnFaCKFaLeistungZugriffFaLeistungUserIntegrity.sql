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
  $Revision: 2 $
=================================================================================================

  SUMMARY: Prüft die Integrität der Tabelle FaLeistungZugriff
           Dummy Funktion da die Tabelle FaLeistungZugriff standardisiert ist, aber bei PI und ZH das DatumVon kein Mussfeld sein muss.

  RETURNS: "0" für gültige Einträge
           "1" falls die Parameter nicht gültig sind

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

