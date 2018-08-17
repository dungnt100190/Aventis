SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnConvertZKBKontoNrToDTA
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

CREATE FUNCTION dbo.fnConvertZKBKontoNrToDTA
 (@ZKBKontoNrToDtaUser varchar(20))
 RETURNS varchar(12)
AS
BEGIN
  RETURN CASE 
    WHEN @ZKBKontoNrToDtaUser LIKE '11__-____.___%' THEN REPLACE( REPLACE( @ZKBKontoNrToDtaUser, '-', '0' ), '.', '' )
    WHEN @ZKBKontoNrToDtaUser LIKE '11__.____.___%' THEN SUBSTRING( @ZKBKontoNrToDtaUser, 1, 4) + '0' + SUBSTRING( @ZKBKontoNrToDtaUser, 6, 4) + SUBSTRING( @ZKBKontoNrToDtaUser, 11, 3)
    WHEN @ZKBKontoNrToDtaUser LIKE '3___-_.______._%' THEN REPLACE( REPLACE( @ZKBKontoNrToDtaUser, '-', '' ), '.', '' )
    WHEN @ZKBKontoNrToDtaUser LIKE '3___-_.______-_%' THEN REPLACE( REPLACE( @ZKBKontoNrToDtaUser, '-', '' ), '.', '' )
    ELSE @ZKBKontoNrToDtaUser
  END
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
