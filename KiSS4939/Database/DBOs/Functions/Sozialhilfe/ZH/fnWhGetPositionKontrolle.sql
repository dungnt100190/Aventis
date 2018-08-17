SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnWhGetPositionKontrolle;
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Angaben zum Benutzer der die Position kontroliert hat
    @BgPositionID: ID der Position zu prüfen
    @ClassName:    Maske aus welcher die Funktion aufgerufen wird
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
=================================================================================================
  TEST:    SELECT * FROM dbo.fnWhGetPositionKontrolle(0, 'FrmWhEinzelzahlungen');
=================================================================================================*/

CREATE FUNCTION dbo.fnWhGetPositionKontrolle
(
  @BgPositionID INT,
  @ClassName VARCHAR(255)
)
RETURNS @Result TABLE
(
  ID INT NOT NULL IDENTITY(1, 1),
  UserID INT,
  LogonName VARCHAR(200),
  Datum DATETIME,
  DatumText VARCHAR(10),
  BgBewilligungCode INT
)
AS
BEGIN
  ;WITH TmpCte AS
  (
    SELECT TOP 1
      UserID            = USR.UserID,
      LogonName         = USR.LogonName,
      Datum             = BGB.Datum,
      DatumText         = CONVERT(VARCHAR(10), BGB.Datum, 104),
      BgBewilligungCode = BGB.BgBewilligungCode
    FROM dbo.BgPosition            POS
      INNER JOIN dbo.BgBewilligung BGB ON BGB.BgPositionID = POS.BgPositionID
      INNER JOIN dbo.XUser         USR ON USR.UserID = ISNULL(BGB.UserID_Erstellt, BGB.UserID)
    WHERE POS.BgPositionID = @BgPositionID
      AND BGB.BgBewilligungCode IN (1, 2, 11, 12) -- Anfrage zur Bewilligung, Bewilligung erteilt, Position zur Zahlung freigegeben, Freigabe der Zahlung aufgehoben
      AND ClassName = @ClassName -- Bewiligen oder Grünstellen auf anderen Masken haben keinen Einfluss auf das Feld Kontrolle
      AND EXISTS (SELECT TOP 1 1 
                  FROM dbo.BgBewilligung WITH (READUNCOMMITTED)
                  WHERE BgBewilligungCode = 10 -- Erstellt
                    AND ClassName = @ClassName 
                    AND BgPositionId = @BgPositionID)
    ORDER BY BGB.Datum DESC
  )
  
  -- Bei grauen Positionen muss das Kontrolle Feld leer sein
  INSERT INTO @Result (UserID, LogonName, Datum, DatumText, BgBewilligungCode)
    SELECT  
      UserID, 
      LogonName,
      Datum,
      DatumText,
      BgBewilligungCode
    FROM TmpCte
    WHERE BgBewilligungCode <> 12; -- Freigabe der Zahlung aufgehoben
  
  RETURN;
END;
GO
