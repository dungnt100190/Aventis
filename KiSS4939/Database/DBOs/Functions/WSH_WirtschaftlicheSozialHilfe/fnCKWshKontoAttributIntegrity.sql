SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnCKWshKontoAttributIntegrity;
GO
/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Prüft, ob sich WshKontoAttribut-Einträge überschneiden
  -
  RETURNS: 0 OK, >0 Fehler
=================================================================================================
  TEST:    SELECT dbo.fnCKWshKontoAttributIntegrity(…);

           -- oder
           BEGIN TRAN
           
           
           INSERT INTO [WshKontoAttribut](KbuKontoID, DatumVon, DatumBis, SysEditModeCode_BetrifftPerson, Creator, Modifier)
           VALUES (1, '2000-01-01', '2010-12-31', 1, '', '')
           
           INSERT INTO [WshKontoAttribut](KbuKontoID, DatumVon, DatumBis, SysEditModeCode_BetrifftPerson, Creator, Modifier)
           VALUES (1, '2010-01-01', '2013-12-31', 1, '', '')
           
           
           ROLLBACK

=================================================================================================*/

CREATE FUNCTION dbo.fnCKWshKontoAttributIntegrity
(
  @WshKontoAttributID INT,
  @KbuKontoID         INT,
  @DatumVon           DATETIME,
  @DatumBis           DATETIME
)
RETURNS INT
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- <Block>
  -----------------------------------------------------------------------------
  DECLARE @Count INT;

  SELECT @Count = COUNT(*)
  FROM WshKontoAttribut WKT
  WHERE KbuKontoID = @KbuKontoID
    AND dbo.fnDatumUeberschneidung(WKT.DatumVon, WKT.DatumBis, @DatumVon, @DatumBis) <> 0
	AND WKT.WshKontoAttributID <> ISNULL(@WshKontoAttributID, -1)

  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN @Count;
END;
GO
