SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnIkZahlungslaufValuta
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Zahlungsvaluta Daten holen
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnIkZahlungslaufValuta
(
  @Today DATETIME
)
RETURNS @OUTPUT TABLE (
  Datum DATETIME
)
AS BEGIN

  INSERT @OUTPUT
  SELECT Datum = Datum1  FROM dbo.IkZahlungslaufValuta WITH (READUNCOMMITTED) WHERE Datum1 >=  @Today AND Datum1  IS NOT NULL
  UNION ALL
  SELECT Datum = Datum2  FROM dbo.IkZahlungslaufValuta WITH (READUNCOMMITTED) WHERE Datum2 >=  @Today AND Datum2  IS NOT NULL
  UNION ALL
  SELECT Datum = Datum3  FROM dbo.IkZahlungslaufValuta WITH (READUNCOMMITTED) WHERE Datum3 >=  @Today AND Datum3  IS NOT NULL
  UNION ALL
  SELECT Datum = Datum4  FROM dbo.IkZahlungslaufValuta WITH (READUNCOMMITTED) WHERE Datum4 >=  @Today AND Datum4  IS NOT NULL
  UNION ALL
  SELECT Datum = Datum5  FROM dbo.IkZahlungslaufValuta WITH (READUNCOMMITTED) WHERE Datum5 >=  @Today AND Datum5  IS NOT NULL
  UNION ALL
  SELECT Datum = Datum6  FROM dbo.IkZahlungslaufValuta WITH (READUNCOMMITTED) WHERE Datum6 >=  @Today AND Datum6  IS NOT NULL
  UNION ALL
  SELECT Datum = Datum7  FROM dbo.IkZahlungslaufValuta WITH (READUNCOMMITTED) WHERE Datum7 >=  @Today AND Datum7  IS NOT NULL
  UNION ALL
  SELECT Datum = Datum8  FROM dbo.IkZahlungslaufValuta WITH (READUNCOMMITTED) WHERE Datum8 >=  @Today AND Datum8  IS NOT NULL
  UNION ALL
  SELECT Datum = Datum9  FROM dbo.IkZahlungslaufValuta WITH (READUNCOMMITTED) WHERE Datum9 >=  @Today AND Datum9  IS NOT NULL
  UNION ALL
  SELECT Datum = Datum10 FROM dbo.IkZahlungslaufValuta WITH (READUNCOMMITTED) WHERE Datum10 >= @Today AND Datum10 IS NOT NULL
  ORDER BY Datum ASC

  RETURN
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
