SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spXSetMsgBox;
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: XMessage Einträge erstellen
      @LanguageCode:       Sprache (1=de, 2=fr, 3=it)
      @MsgText:            Text der Meldung
      @MaskName:           Klassenname
      @MessageName:        Name der Meldung
      @MessageCode:        Art des Texts (1=Info, 2=Error, 3=Question, 4=Text)
      @UpdateTextIfExists: Flag ob der Text angepasst werden muss wenn die Übersetzung bereits vorhanden ist
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spXSetMsgBox
(
  @LanguageCode INT,
  @MsgText VARCHAR(2000),
  @MaskName VARCHAR(100),
  @MessageName VARCHAR(100),
  @MessageCode INT,
  @UpdateTextIfExists BIT = 0
)
AS 
BEGIN
  DECLARE @actTID INT;
  
  SELECT @actTID = MessageTID 
  FROM dbo.XMessage WITH (READUNCOMMITTED) 
  WHERE MaskName = @MaskName 
    AND MessageName = @MessageName;
  
  IF (@actTID IS NOT NULL)
  BEGIN
    IF (NOT EXISTS(SELECT TOP 1 1 
                   FROM dbo.XLangText WITH (READUNCOMMITTED) 
                   WHERE LanguageCode = @LanguageCode 
                     AND TID = @actTID))
    BEGIN
      SET IDENTITY_INSERT XLangText ON;
      
      INSERT INTO dbo.XLangText (TID, LanguageCode, Text) 
      VALUES (@actTID, @LanguageCode, @MsgText);
      
      SET IDENTITY_INSERT XLangText OFF;
    END
    ELSE
    BEGIN
      IF (@UpdateTextIfExists = 1)
      BEGIN
        UPDATE dbo.XLangText
          SET Text = @MsgText
        WHERE TID = @actTID
          AND LanguageCode = @LanguageCode
      END;
    END;
  END 
  ELSE 
  BEGIN
    INSERT INTO dbo.XLangText (LanguageCode, Text) 
    VALUES (@LanguageCode, @MsgText);
    
    SET @actTID = SCOPE_IDENTITY();
    
    INSERT INTO dbo.XMessage (MessageName, MaskName, MessageTID, MessageCode)
    VALUES (@MessageName, @MaskName, @actTID, @MessageCode);
  END;
  
  -- Neuer Schlüssel zurückgeben
  RETURN @actTID;
END;
GO