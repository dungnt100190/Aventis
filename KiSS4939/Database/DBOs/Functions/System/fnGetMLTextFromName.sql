SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetMLTextFromName;
GO

/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Funktion für das Holen von Übersetzungen.
  -
  RETURNS: liefert den übersetzten Text oder deutscher Text falls es keine Übersetzung gibt
  -
  TEST:
=================================================================================================*/

CREATE FUNCTION dbo.fnGetMLTextFromName 
(
  @MaskName VARCHAR(100),
  @MessageName VARCHAR(100),
  @LanguageCode INT
)
RETURNS VARCHAR(2000)
AS
BEGIN
  RETURN (
    SELECT TOP 1 ISNULL(LAN.[Text], LAND.[Text])
    FROM dbo.XMessage MSG WITH (READUNCOMMITTED)
      LEFT JOIN dbo.XLangText LAN  WITH (READUNCOMMITTED) ON LAN.TID = MSG.MessageTID
                                                         AND LAN.LanguageCode = @LanguageCode
      LEFT JOIN dbo.XLangText LAND WITH (READUNCOMMITTED) ON LAND.TID = MSG.MessageTID
                                                         AND LAND.LanguageCode = 1
    WHERE MSG.MaskName = @MaskName
      AND MSG.MessageName = @MessageName)
END;
GO