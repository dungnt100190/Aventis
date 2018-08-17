SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnTmErsatzeinkommen
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

CREATE FUNCTION dbo.fnTmErsatzeinkommen (
  @BaPersonID INT
)

RETURNS varchar(5000)
AS 

BEGIN
  DECLARE @Result VARCHAR(5000)
  DECLARE @Value VARCHAR(200)
  SET @Result = ''

  DECLARE csrErsatzeinkommen CURSOR FOR 

  SELECT	dbo.fnLOVText('BaErsatzeinkommen', BaErsatzeinkommenCode)
			+ CASE WHEN DatumAntrag IS NULL OR DatumAntrag = '' THEN '' ELSE ', beantragt ' + CONVERT(varchar, DatumAntrag, 104) END
			+ CASE WHEN DatumAbgelehnt IS NULL OR DatumAbgelehnt = '' THEN '' ELSE ', abgelehnt ' + CONVERT(varchar, DatumAbgelehnt, 104) END
			+ CASE WHEN DatumAnspruchAb IS NULL OR DatumAnspruchAb = '' THEN '' ELSE ', Anspruch ab ' + CONVERT(varchar, DatumAnspruchAb, 104) END
			+ CASE WHEN DatumBeendet IS NULL OR DatumBeendet = '' THEN '' ELSE ', Beendet ' + CONVERT(varchar, DatumBeendet, 104) END
			+ IsNull(', ' + CONVERT(varchar, Betrag), '')
  FROM		dbo.BaErsatzeinkommen WITH (READUNCOMMITTED) 
  WHERE		BaPersonID = @BaPersonID
  
  OPEN csrErsatzeinkommen

  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM csrErsatzeinkommen INTO @Value
    IF NOT @@FETCH_STATUS = 0 BREAK
    IF NOT @Result = '' BEGIN 
		SET @Result = @Result + CHAR(13) + CHAR(10) 
		
	END
    SET @Result = @Result + ISNULL(@Value, '')
  END

  CLOSE csrErsatzeinkommen
  DEALLOCATE csrErsatzeinkommen

  RETURN @Result
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
