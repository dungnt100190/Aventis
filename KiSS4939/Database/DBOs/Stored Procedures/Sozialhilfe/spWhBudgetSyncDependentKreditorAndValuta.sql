SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spWhBudgetSyncDependentKreditorAndValuta;
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Kreditor und Valutadatum von abhängige Positionen synchronisieren.
           BgSpezkontoID löschen wenn ein Kreditor gesetzt ist.
           Kreditor/Valuta nicht mehr ändern, wenn bereits Belege existieren.

    @BgPositionID_Parent : Hauptposition, deren abhängige Positionen synchronisiert werden soll
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spWhBudgetSyncDependentKreditorAndValuta
(
  @BgPositionID_Parent INT -- Hauptposition, deren abhängige Positionen synchronisiert werden soll
)
AS 
BEGIN
  SET NOCOUNT ON;

  BEGIN TRY
    BEGIN TRANSACTION
    
    DECLARE @MainBgAuszahlungPersonID      VARCHAR(30);
    DECLARE @DetailBgPositionID            INT;
    DECLARE @WhereClause                   VARCHAR(200);
    DECLARE @BgAuszahlungPersonID_inserted INT;

    SELECT @MainBgAuszahlungPersonID = CONVERT(VARCHAR(30),BgAuszahlungPersonID)
    FROM BgAuszahlungPerson
    WHERE BgPositionID = @BgPositionID_Parent;

    DECLARE cDetailPos CURSOR LOCAL STATIC FOR
      SELECT BgPositionID
      FROM dbo.BgPosition
      WHERE BgPositionID_Parent = @BgPositionID_Parent;
    
    OPEN cDetailPos;
    FETCH NEXT FROM cDetailPos INTO @DetailBgPositionID;
    WHILE @@FETCH_STATUS = 0 
    BEGIN
      -- Wenn bereits Buchungen bestehen, dürfen Kreditor und Valuta der Budgetposition nicht mehr geändert werden
      IF (EXISTS(SELECT TOP 1 1 
                 FROM dbo.KbBuchungKostenart 
                 WHERE BgPositionID = @DetailBgPositionID)) 
      BEGIN
        FETCH NEXT FROM cDetailPos INTO @DetailBgPositionID;
        CONTINUE;
      END;
      
      -- alte Auszahlinfo löschen
      DELETE BAP
      FROM dbo.BgAuszahlungPerson BAP
        INNER JOIN dbo.BgPosition BPO ON BPO.BgPositionID = BAP.BgPositionID
      WHERE  BPO.BgPositionID_Parent = @BgPositionID_Parent;

      -- BgAuszahlungPerson
      SET @WhereClause = 'BgAuszahlungPersonID = ' + @MainBgAuszahlungPersonID;
      EXEC spDuplicateRows 'BgAuszahlungPerson', @WhereClause, 'BgPositionID', @DetailBgPositionID;
        
      -- SET @BgAuszahlungPersonID_inserted = SCOPE_IDENTITY(); --Problem: spDuplicateRows ist nicht in diesem Scope
      -- SET @BgAuszahlungPersonID_inserted = @@IDENTITY;       --Problem: Trigger könnte row inserten -> falsche ID
      SELECT @BgAuszahlungPersonID_inserted = BgAuszahlungPersonID
      FROM BgAuszahlungPerson
      WHERE BgPositionID = @DetailBgPositionID; -- Funktioniert wegen 1:1-Beziehung zwischen BgPosition und BgAuszahlungPerson
      
      -- BgSpezkontoID löschen wenn ein Kreditor gesetzt ist
      IF (@BgAuszahlungPersonID_inserted IS NOT NULL)
      BEGIN
        UPDATE POS
          SET BgSpezkontoID = NULL
        FROM dbo.BgPosition POS
        WHERE BgPositionID = @DetailBgPositionID;
      END;
      
      -- BgAuszahlungPersonTermin
      SET @WhereClause = 'BgAuszahlungPersonID = ' + @MainBgAuszahlungPersonID;
      EXEC spDuplicateRows 'BgAuszahlungPersonTermin', @WhereClause, 'BgAuszahlungPersonID', @BgAuszahlungPersonID_inserted;

      FETCH NEXT FROM cDetailPos INTO @DetailBgPositionID;
    END;

    CLOSE cDetailPos;
    DEALLOCATE cDetailPos;
    
    COMMIT TRANSACTION;
  END TRY
  BEGIN CATCH
    ROLLBACK TRANSACTION
    DECLARE @ErrorMsg VARCHAR(MAX);
    SET @ErrorMsg = ERROR_MESSAGE();
    RAISERROR(@ErrorMsg, 18, 1)
  END CATCH;
END;
