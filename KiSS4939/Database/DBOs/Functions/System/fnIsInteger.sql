SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnIsInteger
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnIsInteger.sql $
  $Author: Lgreulich $
  $Modtime: 1.12.09 8:44 $
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
   @UserID: .
  -
  RETURNS: .
  -
  TEST:    SELECT [dbo].[fnIsInteger]('gugus')
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnIsInteger.sql $
 * 
 * 1     1.12.09 8:57 Lgreulich
 * 
=================================================================================================*/

CREATE FUNCTION dbo.fnIsInteger
(
  @Value VARCHAR(255)
)
RETURNS BIT
AS BEGIN
  
  RETURN ISNULL(              
    (SELECT    
       CASE WHEN CHARINDEX('.', @Value) > 0 THEN                             
         CASE WHEN CONVERT(int, PARSENAME(@Value, 1)) <> 0  THEN 0  ELSE 1 END                      
       ELSE 1                     
       END                
     WHERE ISNUMERIC(@Value + 'e0') = 1), 0)
END

