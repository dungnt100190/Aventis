SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwXConfig_public;
GO
/*===============================================================================================
  $Revision: 3$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this view to get details for SingleSignOn. 
  -
  RETURNS: Details of table XConfig.
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwXConfig_public;
=================================================================================================*/

CREATE VIEW dbo.vwXConfig_public
AS
SELECT
  CNF.XNamespaceExtensionID,
  CNF.KeyPath,
  CNF.System,
  CNF.DatumVon,
  CNF.ValueCode,
  CNF.LOVName,
  CNF.ValueBit,
  CNF.OriginalValueBit,
  CNF.ValueDateTime,
  CNF.OriginalValueDateTime,
  CNF.ValueDecimal,
  CNF.OriginalValueDecimal,
  CNF.ValueInt,
  CNF.OriginalValueInt,
  CNF.ValueMoney,
  CNF.OriginalValueMoney,
  CNF.ValueVarchar,
  CNF.OriginalValueVarchar
FROM dbo.XConfig CNF WITH (READUNCOMMITTED)
  OUTER APPLY (SELECT TOP 1 DatumBis = DatumVon
               FROM dbo.XConfig CNFI WITH (READUNCOMMITTED)
               WHERE CNFI.KeyPath = CNF.KeyPath
                 AND CNFI.DatumVon > CNF.DatumVon
               ORDER BY CNFI.DatumVon ASC
               ) CNF2
WHERE CNF.KeyPath IN ('System\Allgemein\SingleSignOn',
                      'System\Allgemein\SingleSignOn\Domain',
                      'System\Allgemein\SingleSignOn\Gruppe',
                      'System\Allgemein\Benutzername_TechnischerBenutzer',
                      'System\Allgemein\Passwort_TechnischerBenutzer')
  AND GETDATE() BETWEEN CNF.DatumVon AND ISNULL(CNF2.DatumBis, '99991231');
  
GO

-- DO NOT REMOVE!
IF (EXISTS(SELECT TOP 1 1
           FROM sys.database_principals WITH (READUNCOMMITTED)
           WHERE name = 'kiss_public'))
BEGIN
  GRANT SELECT ON [dbo].[vwXConfig_public] TO [kiss_public];
END
ELSE
BEGIN
  PRINT ('Warning: login [kiss_public] does not exists.');
END;

GO
