SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spKbKostenstelleAnlegen;
GO
/*===============================================================================================
  $Revision: 10 $
=================================================================================================
  SUMMARY: SP um einen neuen Eintrag in der Tabelle KbKostenstelle und KbKostenstelle_BaPerson zu machen
    @BaPersonID  ID der neue Person
    @UserID      ID des Benutzers
  -
  RETURNS: -
  -
=================================================================================================
  TEST:    EXEC dbo.spKbKostenstelleAnlegen 0, 0;
=================================================================================================*/
CREATE PROCEDURE dbo.spKbKostenstelleAnlegen
(
  @BaPersonID INT,
  @UserID     INT
)
AS
BEGIN
  BEGIN TRAN;
  IF NOT EXISTS(SELECT TOP 1 1 
                FROM dbo.KbKostenstelle_BaPerson WITH (READUNCOMMITTED) 
                WHERE BaPersonID = @BaPersonID)
  BEGIN
    IF ((SELECT UPPER(CONVERT(VARCHAR, dbo.fnXConfig('System\KliBu\KliBuSys', GETDATE())))) = 'INTEGRIERT')
    BEGIN
      DECLARE @KbKostenstelleID INT;
      DECLARE @Modifier VARCHAR (50);
      DECLARE @AnzahlMonateRueckwirkend INT;
      SET @AnzahlMonateRueckwirkend = ISNULL(CONVERT(INT, dbo.fnXConfig('System\KliBu\AnzahlMonateKostenstelleRueckwirkendGueltig', GETDATE())), 6);
      
      INSERT INTO KbKostenstelle(Aktiv)
        SELECT 1;
      
      SET @KbKostenstelleID = SCOPE_IDENTITY();
      SELECT @Modifier = dbo.fnGetDBRowCreatorModifier(@UserID);
      
      INSERT INTO KbKostenstelle_BaPerson (BaPersonID, KbKostenstelleID, DatumVon, Creator, Modifier)
        SELECT @BaPersonID, @KbKostenstelleID, DATEADD(MONTH, -@AnzahlMonateRueckwirkend, dbo.fnFirstDayOf(GETDATE())), @Modifier, @Modifier;
    END;
  END;
  COMMIT;
END;
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
