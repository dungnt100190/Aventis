SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetHauptpersonFuerMitglied;
GO
/*===============================================================================================
  $Revision: 12 $
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

CREATE FUNCTION dbo.fnGetHauptpersonFuerMitglied
(
  @BaPersonID INT
)
RETURNS INT
AS
BEGIN
  DECLARE @BaPersonID_FT INT;

  -- Prüfe zuerst, ob die Person selber Fallträger eines gültigen Falles ist
  SELECT TOP 1 @BaPersonID_FT = BaPersonID
  FROM dbo.FaFall WITH (READUNCOMMITTED)
  WHERE BaPersonID = @BaPersonID 
    AND DatumBis IS NULL;

  -- Prüfe dann, ob die Person in einem anderen gültigen Fall vorkommt. Falls mehr als ein Fall vorkommt, soll der Fall selektiert werden, der am meisten gültige Leistungen aufweist
  IF (@BaPersonID_FT IS NULL)
  BEGIN
    SELECT TOP 1 @BaPersonID_FT = FAL.BaPersonID
    FROM dbo.FaFallPerson      REL WITH (READUNCOMMITTED)
      LEFT JOIN dbo.FaFall     FAL WITH (READUNCOMMITTED) ON FAL.FaFallID = REL.FaFallID
      LEFT JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaFallID = FAL.FaFallID 
                                                         AND ISNULL(LEI.DatumBis, GETDATE()) >= GETDATE()-- selektiere nur gültige Leistungen
    WHERE REL.BaPersonID = @BaPersonID 
      AND FAL.DatumBis IS NULL
    GROUP BY FAL.BaPersonID, LEI.FaFallID
    ORDER BY COUNT(ISNULL(LEI.FaFallID, 0)) DESC; -- sortiere nach Anzahl gültigen Leistungen (mit der Annahme, dass der Fall mit mehr gültigen Leistungen tendenziell der interessantere ist)
  END;
  
  -- Prüfe dann, ob die Person Fallträger eines nicht mehr gültigen Falles ist
  IF (@BaPersonID_FT IS NULL)
  BEGIN
    SELECT TOP 1 @BaPersonID_FT = BaPersonID
    FROM dbo.FaFall WITH (READUNCOMMITTED)
    WHERE BaPersonID = @BaPersonID;
  END;
  
  -- Prüfe am Schluss, ob die Person in einem anderen nicht mehr gültigen Fall vorkommt
  IF (@BaPersonID_FT IS NULL)
  BEGIN
    SELECT TOP 1 @BaPersonID_FT = FAL.BaPersonID
    FROM dbo.FaFallPerson  REL WITH (READUNCOMMITTED)
      LEFT JOIN dbo.FaFall FAL WITH (READUNCOMMITTED) ON FAL.FaFallID = REL.FaFallID
    WHERE REL.BaPersonID = @BaPersonID
    ORDER BY FAL.DatumVon DESC;
  END;

  RETURN @BaPersonID_FT;
END

GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO