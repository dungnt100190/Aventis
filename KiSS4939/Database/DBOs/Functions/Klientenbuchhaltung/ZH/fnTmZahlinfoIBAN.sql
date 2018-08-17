SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject [fnTmZahlinfoIBAN]
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Functions/fnTmZahlinfoIBAN.sql $
  $Author: Mmarghitola $
  $Modtime: 1.06.10 10:20 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Functions/fnTmZahlinfoIBAN.sql $
 * 
 * 2     1.06.10 10:21 Mmarghitola
 * Fehlerhaftes Zeichen im Kommentar entfernt
 * 
 * 1     31.05.10 16:26 Rstahel
 * Neue Funktionen von Urs Stäuble für Textmarken mit IBAN-Nummer
=================================================================================================*/

Create FUNCTION [dbo].[fnTmZahlinfoIBAN] (
  @BaPersonID INT
)

RETURNS varchar(5000)
AS BEGIN
  DECLARE @Result VARCHAR(5000)
  DECLARE @Value VARCHAR(200)
  SET @Result = ''

  DECLARE csrZahlinfo CURSOR FOR 

	SELECT	IsNull(B.Name, 'Postfinance') + isNull(', '+ B.Ort, '')
			+ ', IBAN: ' + IsNull(Z.IBANNummer, IsNull(dbo.fnTnToPc(Z.PostKontoNummer), ''))
	FROM	dbo.BaZahlungsweg Z WITH (READUNCOMMITTED) 
		LEFT Join dbo.BaBank B WITH (READUNCOMMITTED) on B.baBankID = Z.baBankID
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
