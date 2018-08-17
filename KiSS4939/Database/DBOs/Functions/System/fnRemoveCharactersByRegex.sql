SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnRemoveCharactersByRegex;
GO
/*===============================================================================================
  $Revision: 1$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Mit Hilfe dieser Funktion kann man einen beliebigen String mit einem Regex filtern.
           Wenn man als Regex zum Beispiel '%[^0-9]%' eingibt, wird es alle non-numerischen
           Charaktere herausfiltern.
    @strText: String welcher gefiltert werden soll
    @regex: Regexpattern
  -
  RETURNS: Der um das Regex getrimmte String.
=================================================================================================
  TEST:    SELECT dbo.fnRemoveCharactersByRegex(PRS.Telefon_P, '%[^0-9]%') FROM dbo.BaPerson PRS;
=================================================================================================*/

CREATE Function dbo.fnRemoveCharactersByRegex
(
  @strText VARCHAR(1000), 
  @regex VARCHAR(40)
)
RETURNS VARCHAR(1000)
AS
BEGIN
  WHILE PATINDEX(@regex, @strText) > 0
  BEGIN
    SET @strText = STUFF(@strText, PATINDEX(@regex, @strText), 1, '');
  END;
  RETURN @strText;
END;
GO
