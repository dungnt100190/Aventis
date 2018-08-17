SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnCodeListsHaveMatch;
GO

/*===============================================================================================
  $Archive: $
  $Author: Claude Glauser
  $Modtime: $
  $Revision: $
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
  TEST:    SELECT dbo. fnCodeListsHaveMatch('1,2,3', '3,4,5'); -> 1
           SELECT dbo. fnCodeListsHaveMatch('1,2,3', '4,5,6'); -> 0  
=================================================================================================
  $Log: $
=================================================================================================*/


CREATE FUNCTION [dbo].[fnCodeListsHaveMatch]
(
  @List1  VARCHAR(max),
  @List2  VARCHAR(max)
)
RETURNS BIT
AS BEGIN
  
  -- Einträge in der LOV sind Zahlen vom SQL Typ int, darum Länge 11.
  DECLARE @CodeTable1 TABLE (Code VARCHAR(11)); 
  DECLARE @CodeTable2 TABLE (Code VARCHAR(11));
  DECLARE @RowCount INT;
  
  DECLARE @L1L2 TABLE(Column1 VARCHAR(11), Column2 VARCHAR(11));
  
  INSERT INTO @CodeTable1 (Code)
    SELECT * FROM dbo.fnSplit(@List1, ',');
  
  INSERT INTO @CodeTable2 (Code)
    SELECT * FROM dbo.fnSplit(@List2, ',');  
  
  INSERT INTO @L1L2 (Column1, Column2)
    SELECT L1.CODE, L2.CODE 
    FROM @CodeTable1 L1,
         @CodeTable2 L2
    WHERE L1.CODE = L2.CODE; 
    
  SELECT @RowCount = (COUNT(Column1))
  FROM @L1L2;
  
  IF @RowCount > 0
    RETURN 1
                   
  RETURN 0;
END;

GO
