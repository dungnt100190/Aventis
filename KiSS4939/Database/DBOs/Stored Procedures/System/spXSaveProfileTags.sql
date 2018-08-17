
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spXSaveProfileTags;
GO
/*===============================================================================================
  $Archive: $
  $Author: $
  $Modtime: $
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Speichert die ProfileTags (XProfileTag) eines Profils (XProfile). 
    Ist der parameter @ProfileID = 0, dann wird ein neues Profil angelegt.
    
    @ProfileID: Die ID des Profils
    @ProfieTags: ID's der ProfileTags, separiert mit ,
  -
  RETURNS: Die Id des profils. Ist identisch mit dem Parameter @ProfileID. Hat 
           Parameter @ProfileID den Wert 0, dann die ID des neu erstellten Profils.
  -
  TEST:    EXEC dbo.spXSaveProfileTags …;
=================================================================================================
  $Log: $
=================================================================================================*/

CREATE PROCEDURE dbo.spXSaveProfileTags
(
  @ProfileID INT,
  @ProfieTags VARCHAR(MAX)
)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- start call
  -----------------------------------------------------------------------------
  SET NOCOUNT ON;
  
  -- 0. Wenn es noch kein Profil gibt, dann Profil anlegen. (Pro Vorlage ein Profil).
  IF @ProfileID = 0  
  BEGIN    
    INSERT INTO XProfile (Name, XProfileTypeCode, Creator, Modifier) 
    VALUES ('Vorlageprofil',2,'','') --XProfileType 2: Vorlage
    SET @ProfileID = SCOPE_IDENTITY()
  END

  
  
  --1. Alle bestehenden Beziehungen zwischen XProfile und XProfileTag löschen  
  DELETE FROM dbo.XProfile_XProfileTag 
  WHERE XProfileID = @ProfileID;
  
  --2. Liste einfügen  
  INSERT INTO dbo.XProfile_XProfileTag (XProfileID, XProfileTagID, Creator, Modifier)
  SELECT 
    @ProfileID, 
    Value,
    '',
    '' 
  FROM dbo.fnSplit(@ProfieTags, ',') SLT WHERE SLT.Value <> '';
  
  RETURN @ProfileID;
           
END;
GO
