SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spBaPersonAnonymisieren
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spBaPersonAnonymisieren.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 11:07 $
  $Revision: 3 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spBaPersonAnonymisieren.sql $
 * 
 * 3     11.12.09 11:57 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 17:58 Rstahel
 * Abgleich der Stored Procedures aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE PROCEDURE [dbo].[spBaPersonAnonymisieren](@BaPersonID int)
AS BEGIN
  DELETE BaAdresse             WHERE BaPersonID = @BaPersonID
  DELETE BaAlteFallNr          WHERE BaPersonID = @BaPersonID
  DELETE BaArbeit              WHERE BaPersonID = @BaPersonID
  DELETE BaErsatzeinkommen     WHERE BaPersonID = @BaPersonID
  DELETE BaKrankenversicherung WHERE BaPersonID = @BaPersonID
  DELETE BaVermoegen           WHERE BaPersonID = @BaPersonID
  DELETE BaZahlungsweg         WHERE BaPersonID = @BaPersonID
  DELETE BaWVCode              WHERE BaPersonID = @BaPersonID

  DECLARE @ColName varchar(100),
          @SQL     nvarchar(4000)

  DECLARE cColumn CURSOR FOR
    SELECT Name
    FROM   syscolumns
    WHERE  id = OBJECT_ID('BaPerson')
      AND isnullable = 1 AND Name NOT IN ('Name', 'Geburtsdatum', 'GeschlechtCode', 'PersonOhneLeistung', 'InCHSeitGeburt')

  OPEN cColumn
  WHILE (1 = 1) BEGIN
    FETCH NEXT FROM cColumn INTO @ColName
    IF @@FETCH_STATUS < 0 BREAK

    SET @SQL = IsNull(@SQL + ', ' + char(13) + char(10) + '  ', '') + '[' + @ColName + '] = NULL'
  END
  DEALLOCATE cColumn

  SET @SQL = 'UPDATE BaPerson SET
  ' + @SQL + ', Modifier = dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID()), Modified = GetDate()
WHERE BaPersonID = ' + CONVERT(varchar, @BaPersonID)

  PRINT @SQL
  EXECUTE (@SQL)

  UPDATE BaPerson
    SET Name = 'Person ' + CONVERT(varchar, @BaPersonID),
      Vorname = 'Anonym',
      InCHSeitGeburt = 0,
      PersonOhneLeistung = 0,
      Modifier = dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID()),
      Modified = GETDATE()
  WHERE BaPersonID = @BaPersonID
END
