SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnXIsDocTemplatePublic;
GO

/*===============================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Überprüft, ob auf einer Vorlage Berechtigungen definiert sind.  
           Existiert die Vorlage nicht, dann wird 1 zurückgegeben.   
    @DocTemplateID: Die Id der Vorlage
  -
  RETURNS: 1 wenn die Vorlage öffentlich ist oder wennd die Vorlage nicht existiert.
           0 wenn Berechtigungen nötig sind, um die Vorlage
             zu verwenden.
  -
  TEST:    SELECT dbo.fnXIsDocTemplatePublic(23);
=================================================================================================
  $Log: $
=================================================================================================*/

CREATE FUNCTION dbo.fnXIsDocTemplatePublic
(
  @DocTemplateID INT
)
RETURNS BIT
AS 
BEGIN

  
  IF  EXISTS(SELECT TOP 1 1 FROM dbo.XUser_XDocTemplate UDC WHERE  UDC.DocTemplateID = @DocTemplateID)
  BEGIN
    RETURN  0;
  END  

  IF  EXISTS(SELECT TOP 1 1 FROM dbo.XOrgUnit_XDocTemplate UDC WHERE  UDC.DocTemplateID = @DocTemplateID)
  BEGIN
    RETURN  0;
  END    
  
  RETURN 1;
  
END;
GO