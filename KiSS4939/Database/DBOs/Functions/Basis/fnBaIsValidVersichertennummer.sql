SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnBaIsValidVersichertennummer
GO

/*===============================================================================================
	$Archive: /KiSS4/Database/DBOs/Functions/System/fnBaIsValidVersichertennummer.sql $
	$Author: DFE $
	$Modtime: 06.11.17 08:00 $
	$Revision: 1 $
=================================================================================================
	Description
-------------------------------------------------------------------------------------------------
	SUMMARY: Check if Versichertennummer is Valid
	 @VersNrChars: The versichertennummer
	-
	RETURNS: True if is valid, otherwise false
	-
	TEST:    SELECT dbo.fnBaIsValidVersichertennummer('000.0000.0000.00', DEFAULT)
					 SELECT dbo.fnBaIsValidVersichertennummer('222.2222.2222.22', DEFAULT)
					 SELECT dbo.fnBaIsValidVersichertennummer('756.1234.5678.97', DEFAULT)
=================================================================================================*/

CREATE FUNCTION [dbo].[fnBaIsValidVersichertennummer]
(
	@VersNrChars NVARCHAR(255),
	@IsAltWertValid BIT = 0
)
RETURNS BIT
AS BEGIN
	
	IF dbo.fnIsNullOrEmpty(@VersNrChars, NULL, NULL, NULL) IS NULL
	BEGIN
		-- Empty new AVS Number is forbidden
		RETURN @IsAltWertValid
	END

	DECLARE @isOldFormatValid NVARCHAR(255) = '[0-9][0-9][0-9].[0-9][0-9].[0-9][0-9][0-9].[0-9][0-9][0-9]'
	IF PATINDEX(@isOldFormatValid, @VersNrChars) = 1
	BEGIN
		IF PATINDEX('000.00.000.000', @VersNrChars) = 1 OR @IsAltWertValid = 0
		BEGIN
			RETURN 0
		END
		RETURN 1
	END

	DECLARE @isNewFormatValid NVARCHAR(255) = '[0-9][0-9][0-9].[0-9][0-9][0-9][0-9].[0-9][0-9][0-9][0-9].[0-9][0-9]'
	IF (PATINDEX(@isNewFormatValid, @VersNrChars) <> 1 OR PATINDEX('000.0000.0000.00', @VersNrChars) = 1)
	BEGIN
		RETURN 0
	END

	-- Kontrollzifferprüfung gemäss EAN-13 (siehe http://www.ahv-iv-ar.ch/site/index.cfm?id_art=32126, https://de.wikipedia.org/wiki/European_Article_Number#Pr.C3.BCfziffer)
	DECLARE @sum INT = 0;-- store the sum of all multiplied values
	DECLARE @isEvenNumber BIT = 0;-- flag if current entry is a even position (true = digit 2, 4, 6, 8, 10, 12 from right hand, started with 2nd digit)
	DECLARE @numbers TABLE(ID TINYINT IDENTITY(1,1),val CHAR)

	SET @VersNrChars = REPLACE(@VersNrChars,'.','')

	-- split current validated value of versNr to single chars for parsing
	DECLARE @count INT = 1
	WHILE @count <= LEN(@VersNrChars)
	BEGIN
		INSERT @numbers(val) VALUES (SUBSTRING(@VersNrChars, @count, 1))
		SET @count = @count + 1
	END

	SET @sum = (SELECT 
		SUM(
			CASE (ID % 2)
				WHEN 0 THEN CAST(val AS INT)*3
				WHEN 1 THEN CAST(val AS INT)
			END
		)
	FROM @numbers
	WHERE ID < 13)
	
	--// calculate checknumber as defined
	DECLARE @checkNumber INT = (10 - (@sum % 10)) % 10

	--// compare with current last digit
	IF EXISTS(SELECT val FROM @numbers WHERE ID = 13 AND val = @checkNumber)
	BEGIN
		RETURN 1
	END

	-----------------------------------------------------------------------------
	-- if we are here, the Versichertennummer is not valid
	-----------------------------------------------------------------------------
	RETURN 0
END
GO