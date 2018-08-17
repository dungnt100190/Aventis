SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spAmAnspruchsberechnung_InsertRow
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

-- =================================================================================
-- Author:		R. Hesterberg
-- Create date: 11.07.2007
-- Description:	Hilfs-StoredProcedure für Erstellen einer Art Anspruchsberechnung
-- =================================================================================

CREATE PROCEDURE [dbo].[spAmAnspruchsberechnung_InsertRow] (
  @Text varchar(200),
  @ID int,
  @ParentID int,
  @Typ int,
  @Kind bit,
  @Sort1 char(1),
  @Sort2 varchar(10),
  @Editierbar1 bit,
  @Editierbar2 bit,
  @Einheit1 varchar(50),
  @Einheit2 varchar(50),
  @Default1 money,
  @Default2 money,
  @ConfigName1 varchar(50),
  @ConfigName2 varchar(50),
  @Format1 varchar(20),
  @Format2 varchar(20),
  @Kommentar varchar (1000)
)
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON;

  -- Insert statements for procedure here
  IF EXISTS(SELECT AmAbPositionsartID FROM AmAbPositionsart WHERE AmAbPositionsartID = @ID)
  BEGIN
    UPDATE AmAbPositionsart SET
      [ParentID] = @ParentID,
      [Kind] = @Kind,
      [Typ] = @Typ,
      [Sortierung1] = @Sort1,
      [Sortierung2] = @Sort2,
      [Editierbar1] = @Editierbar1,
      [Editierbar2] = @Editierbar2,
      [Text] = @Text,
      [Mengeneinheit1] = @Einheit1,
      [Mengeneinheit2] = @Einheit2,
      [ConfigName1] = @ConfigName1,
      [ConfigName2] = @ConfigName2,
      [Default1] = @Default1,
      [Default2] = @Default2,
      [Format1] = @Format1,
      [Format2] = @Format2,
      [Kommentar] = @Kommentar
    WHERE AmAbPositionsartID = @ID
  END ELSE BEGIN
    INSERT INTO AmAbPositionsart (
      [AmAbPositionsartID],
      [ParentID],
      [Typ],
      [Kind],
      [Sortierung1],
      [Sortierung2],
      [Editierbar1],
      [Editierbar2],
      [Text],
      [Mengeneinheit1],
      [Mengeneinheit2],
      [ConfigName1],
      [ConfigName2],
      [Default1],
      [Default2],
      [Format1],
      [Format2],
      [Kommentar]
    )
    VALUES (
      @ID,
      @ParentID,
      @Typ,
      @Kind,
      @Sort1,
      @Sort2,
      @Editierbar1,
      @Editierbar2,
      @Text,
      @Einheit1,
      @Einheit2,
      @ConfigName1,
      @ConfigName2,
      @Default1,
      @Default2,
      @Format1,
      @Format2,
      @Kommentar
    )
  END
END

