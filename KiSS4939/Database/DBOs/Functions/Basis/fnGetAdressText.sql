SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetAdressText;
GO
/*===============================================================================================
  $Revision: 7 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Gibt die Adresse (PLZ Ort) oder mit Strasse (Strasse HausNr, PLZ Ort) des Klienten zurück
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
    @BaPersonID:  The ID of the person to get address from
    @ShowStrasse: flag if needed to show street
    @AddressType: 0=Wohnsitz, 1=Aufenthalt, 2=Post, 3=Heimatort
  -
  RETURNS: The desired address or NULL if nothing found or error
=================================================================================================
  TEST:    SELECT dbo.fnGetAdressText(3333, 1, 0)
           SELECT dbo.fnGetAdressText(3333, 0, 0)
           --
           SELECT dbo.fnGetAdressText(87159, 1, 0)
           SELECT dbo.fnGetAdressText(87159, 0, 0)
           --
           SELECT dbo.fnGetAdressText(87159, 1, 1)
           SELECT dbo.fnGetAdressText(87159, 0, 1)
           --
           SELECT dbo.fnGetAdressText(87159, 1, 2)
           SELECT dbo.fnGetAdressText(87159, 0, 2)
           --
           SELECT dbo.fnGetAdressText(87159, 1, 3)
           SELECT dbo.fnGetAdressText(87159, 0, 3)
=================================================================================================*/

CREATE FUNCTION dbo.fnGetAdressText
(
  @BaPersonID INT,
  @ShowStrasse BIT = 0,
  @AddressType INT = 0
)
RETURNS VARCHAR(255) WITH SCHEMABINDING
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- validate first
  -----------------------------------------------------------------------------
  -- validate
  IF (@BaPersonID IS NULL)
  BEGIN
   RETURN NULL;
  END;
  
  -----------------------------------------------------------------------------
  -- get data
  -----------------------------------------------------------------------------
  -- init vars
  DECLARE @Output VARCHAR(255);
  DECLARE @AdresseCode INT;
  
  -- matching code to new address type
  SET @AdresseCode = CASE @AddressType
                       WHEN 1 THEN 2 -- Aufenthalt
                       WHEN 2 THEN 3 -- Post
                       WHEN 3 THEN NULL
                       ELSE 1        -- Wohnsitz
                     END;
  
  IF (@AddressType <> 3)
  BEGIN
    -- Aufenthalt, Post, Wohnsitz
    SELECT @Output = CASE @ShowStrasse
                       WHEN 1 THEN ISNULL(ADR.Strasse + ISNULL(' ' + ADR.HausNr, '') + ', ', '')
                       ELSE ''
                     END + ISNULL(ADR.PLZ + ' ', '') + ISNULL(ADR.Ort, '')
    FROM dbo.BaPerson         PRS WITH (READUNCOMMITTED)
      LEFT JOIN dbo.BaAdresse ADR WITH (READUNCOMMITTED) ON ADR.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, @AdresseCode, NULL)
    WHERE PRS.BaPersonID = @BaPersonID;
  END
  ELSE
  BEGIN
    -- Heimatort (always without street information)
    SELECT @Output = ISNULL(CONVERT(VARCHAR, GDE.PLZ) + ' ', '') + ISNULL(GDE.Name, '')
    FROM dbo.BaPerson           PRS WITH (READUNCOMMITTED)
      INNER JOIN dbo.BaGemeinde GDE WITH (READUNCOMMITTED) ON GDE.BaGemeindeID = PRS.HeimatgemeindeBaGemeindeID
    WHERE PRS.BaPersonID = @BaPersonID;
  END;
  
  -- return value
  RETURN @Output;
END;
GO