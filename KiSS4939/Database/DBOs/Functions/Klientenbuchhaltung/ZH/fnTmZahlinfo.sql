SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnTmZahlinfo
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

CREATE FUNCTION dbo.fnTmZahlinfo
(
  @BaPersonID INT
)

RETURNS varchar(5000)
AS BEGIN
  DECLARE @Result VARCHAR(5000)
  DECLARE @Value VARCHAR(200)
  SET @Result = ''

  DECLARE csrZahlinfo CURSOR FOR 

	SELECT	'Bank- und/oder Postverbindung: ' + IsNull(B.Name, '') + IsNull(', '+ B.Ort, '')
			+ ', Kto-Nr. ' + IsNull(Z.BankKontoNummer, IsNull(dbo.fnTnToPc(Z.PostKontoNummer), ''))
	FROM	dbo.BaZahlungsweg Z WITH (READUNCOMMITTED) 
		LEFT JOIN dbo.BaBank B WITH (READUNCOMMITTED) on B.BaBankID = Z.BaBankID
	WHERE Z.BaPersonID = @BaPersonID
  
  OPEN csrZahlinfo

  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM csrZahlinfo INTO @Value
    IF NOT @@FETCH_STATUS = 0 BREAK
    IF NOT @Result = '' BEGIN 
		SET @Result = @Result + CHAR(13) + CHAR(10) 
		
	END
    SET @Result = @Result + ISNULL(@Value, '')
  END

  CLOSE csrZahlinfo
  DEALLOCATE csrZahlinfo

  RETURN @Result
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
