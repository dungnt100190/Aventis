SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spKbKostenstelleAnlegen;
GO
/*===============================================================================================
  $Revision: 8 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
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
  -- SpezialRegel Integration BE: (aufsteigende Nr, ab 90'000)
  DECLARE @MinKostenstelleNr INT;
  SET @MinKostenstelleNr = 90000;

  BEGIN TRY;
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

        INSERT INTO dbo.KbKostenstelle(Aktiv, Nr)
          SELECT Aktiv = 1,
                 Nr    = CONVERT(VARCHAR, (SELECT dbo.fnMAX(MAX(CONVERT(INT, Nr))+1, @MinKostenstelleNr) FROM dbo.KbKostenstelle));
          
        SET @KbKostenstelleID = SCOPE_IDENTITY();
        SELECT @Modifier = dbo.fnGetDBRowCreatorModifier(@UserID);
      
        INSERT INTO dbo.KbKostenstelle_BaPerson (BaPersonID, KbKostenstelleID, DatumVon, Creator, Modifier)
          SELECT @BaPersonID, @KbKostenstelleID, DATEADD(MONTH, -@AnzahlMonateRueckwirkend, dbo.fnFirstDayOf(GETDATE())), @Modifier, @Modifier;
      END;
    END;
    COMMIT;
  END TRY
  BEGIN CATCH
    DECLARE @errormsg varchar(500);
    SET @errormsg = ERROR_MESSAGE();
    ROLLBACK;
    RAISERROR(@errormsg,18,1);
  END CATCH;
END;
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
