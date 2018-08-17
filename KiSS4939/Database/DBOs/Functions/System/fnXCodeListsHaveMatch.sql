SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnXCodeListsHaveMatch;
GO
/*===============================================================================================
  $Author: Claude Glauser
  $Revision: 1 $
=================================================================================================
  Vergleicht zwei Listen und gibt true zurück, wenn es mindestens ein
  Eintrag gibt, der in beiden Listen vorhanden ist.
-------------------------------------------------------------------------------------------------
  SUMMARY: Vergleicht zwei Listen, ob es mindestens einen Eintrag
           in beiden Listen gibt.
    @Param1: Varchar in der Form 'val1, val2, val3' Trennungszeichen ist Colon (,).
    @Param2: Varchar in der Form 'val1, val2, val3'  Trennungszeichen ist Colon (,).
  -
  RETURNS: 1, wenn es einen Eintrag gibt, der in beiden Listen vorhanden ist. sonst 0.
  -
  TEST:    SELECT dbo. fnXCodeListsHaveMatch('1,2,3', '3,4,5'); -> 1
           SELECT dbo. fnXCodeListsHaveMatch('1,2,3', '4,5,6'); -> 0  
=================================================================================================
  $Log: $
=================================================================================================*/

CREATE FUNCTION dbo.fnXCodeListsHaveMatch
(
  @List1 VARCHAR(MAX),
  @List2 VARCHAR(MAX)
)
RETURNS BIT
AS 
BEGIN
  -- Einträge in der LOV sind Zahlen vom SQL Typ int, darum Länge 11.
  DECLARE @RowCount INT;
  
  SELECT @RowCount = COUNT(1)
  FROM dbo.fnSplit(@List1, ',')         LST1
    INNER JOIN dbo.fnSplit(@List2, ',') LST2 ON LST2.[Value] = LST1.[Value];
  
  IF (ISNULL(@RowCount, 0) > 0)
  BEGIN
    RETURN 1;
  END;
  
  RETURN 0;
END;
GO
