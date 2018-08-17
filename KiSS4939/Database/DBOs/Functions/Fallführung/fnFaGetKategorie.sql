SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnFaGetKategorie;
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Funktion zum Berechnen der Fallkategorie
    @FaKategorisierungEksProduktID
    @FaKategorisierungEksOptionCode:      
    @FaKategorisierungKiStatusCode:       
    @FaKategorisierungIntakeCode:         
    @FaKategorisierungKooperationCode:    
    @FaKategorisierungRessourcenCode:     
    @FaKategorisierungAbschlussgrundCode: 
  -
  RETURNS: FaKategorieCode
=================================================================================================
  TEST:    SELECT dbo.fnFaGetKategorie(NULL, NULL, NULL, 5, 5, NULL);
=================================================================================================*/

CREATE FUNCTION dbo.fnFaGetKategorie
(
  @FaKategorisierungEksProduktID INT,
  @FaKategorisierungEksOptionCode INT,
  @FaKategorisierungKiStatusCode INT,
  @FaKategorisierungIntakeCode INT,
  @FaKategorisierungKooperationCode INT,
  @FaKategorisierungRessourcenCode INT,
  @FaKategorisierungAbschlussgrundCode INT
)
RETURNS INT
AS
BEGIN
  -- Declare the return variable here
  DECLARE @Kategorie INT;

  -- Kategorie nach EKSProduktID
  IF @FaKategorisierungEksProduktID IS NOT NULL
  BEGIN
    SELECT @Kategorie = FaKategorieCode
    FROM dbo.FaKategorisierungEksProdukt
    WHERE FaKategorisierungEksProduktID = @FaKategorisierungEksProduktID;
  END;

  -- Kategorie nach KiStatusCode
  IF @FaKategorisierungKiStatusCode = 1
    SET @Kategorie = 5;

  IF @FaKategorisierungKiStatusCode = 2
    SET @Kategorie = 6;

  -- Kategorie nach IntakeCode
  IF @FaKategorisierungIntakeCode IS NOT NULL
    SET @Kategorie = @FaKategorisierungIntakeCode;

  -- Kategorie nach Kooperation und Resourcenvergrauch
  IF (@FaKategorisierungKooperationCode IS NOT NULL 
    AND @FaKategorisierungRessourcenCode IS NOT NULL)
  BEGIN
    IF @FaKategorisierungKooperationCode > 5
    BEGIN
      IF @FaKategorisierungRessourcenCode < 6
      BEGIN
        SET @Kategorie = 1;
      END;
      ELSE
      BEGIN
        SET @Kategorie = 2;
      END;
    END;
    ELSE
    BEGIN
    IF @FaKategorisierungRessourcenCode < 6
      BEGIN
        SET @Kategorie = 3;
      END;
      ELSE
      BEGIN
        SET @Kategorie = 4;
      END;
    END;
  END;
  
  -- Return the result of the function
  RETURN @Kategorie;
END;
GO
