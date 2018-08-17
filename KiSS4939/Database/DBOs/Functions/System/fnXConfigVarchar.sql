SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnXConfigVarchar;
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Ruft den Konfigurationstext für den angegebenen Pfad ab.
    @KeyPath: Der Pfad in der Form 'A\B\C'.
    @DatumVon: Das Gültigkeitsdatum für die Abfrage des Wertes, falls mehrere Werte erfasst sind.
  -
  RETURNS: Der für diesen Wert konfigurierte Text.
=================================================================================================
  TEST:    SELECT dbo.fnXConfigVarchar('System\Adresse\Sozialhilfe\Organisation', GETDATE());
=================================================================================================*/

CREATE FUNCTION dbo.fnXConfigVarchar
(
  @KeyPath VARCHAR(500),
  @DatumVon DATETIME = NULL
)
RETURNS VARCHAR(MAX)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- init vars
  -----------------------------------------------------------------------------
  DECLARE @ConfigValue VARCHAR(MAX);
  SET @ConfigValue = NULL;

  SELECT TOP 1
    @ConfigValue = CASE
                     WHEN CNF.DatumVon IS NULL THEN CNF.OriginalValueVarchar
                     ELSE CNF.ValueVarchar
                   END
  FROM dbo.XConfig CNF WITH (READUNCOMMITTED)
  WHERE CNF.KeyPath = @KeyPath
    AND (ISNULL(CNF.DatumVon, '17530101') <= ISNULL(@DatumVon, '17530101'))
  ORDER BY DatumVon DESC;  
  
  -----------------------------------------------------------------------------
  -- if no value is given, try to get any original value
  -----------------------------------------------------------------------------
  IF (@ConfigValue IS NULL)
  BEGIN
    SELECT TOP 1
      @ConfigValue = CNF.OriginalValueVarchar
    FROM dbo.XConfig CNF WITH (READUNCOMMITTED)
    WHERE CNF.KeyPath = @KeyPath
      AND CNF.OriginalValueVarchar IS NOT NULL
    ORDER BY DatumVon DESC;
  END;

  RETURN @ConfigValue;
END;
GO
