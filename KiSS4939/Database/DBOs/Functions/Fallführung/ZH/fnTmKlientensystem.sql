SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnTmKlientensystem
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnTmKlientensystem (
  @BaPersonID INT,
  @FaFallID   INT
)

RETURNS varchar(5000)
AS BEGIN
  DECLARE @Result VARCHAR(5000)
  DECLARE @Value VARCHAR(200)
  SET @Result = ''

  DECLARE csrKlientensystem CURSOR FOR 

  SELECT PRS.NameVorname + IsNull('; ' + CONVERT(varchar, IsNull(PRS.[Alter], '')), '')
  FROM   dbo.FaFall FAL WITH (READUNCOMMITTED) 
         INNER JOIN dbo.FaFallPerson FAP WITH (READUNCOMMITTED) ON FAP.FaFallID = FAL.FaFallID
         INNER JOIN dbo.vwPerson     PRS ON PRS.BaPersonID = FAP.BaPersonID
  WHERE  FAL.BaPersonID = @BaPersonID
  AND	 FAL.FaFallID = @FaFallID
  ORDER BY CASE WHEN FAL.BaPersonID = FAP.BaPersonID THEN 0 ELSE 1 END, PRS.Geburtsdatum ASC
  
  OPEN csrKlientensystem

  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM csrKlientensystem INTO @Value
    IF NOT @@FETCH_STATUS = 0 BREAK
    IF NOT @Result = '' BEGIN 
		SET @Result = @Result + CHAR(13) + CHAR(10) 
		
	END
    SET @Result = @Result + ISNULL(@Value, '')
  END

  CLOSE csrKlientensystem
  DEALLOCATE csrKlientensystem

  RETURN @Result
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
