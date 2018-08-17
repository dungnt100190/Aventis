SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnIkGetLandesindexWert;
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Gets the IkLandesindexWert.Wert value for the given parameters
    @IkIndexTypCode: The Code of the LOV IkIndexTyp used for mapping LOVCode.Value1 to IkLandesindexID
    @Jahr:           The year to use for getting the value
    @Monat:          The month to use for getting the value
  -
  RETURNS: The IkLandesindexWert.Wert value or NULL if none was found for given parameters
=================================================================================================
  TEST:    SELECT dbo.fnIkGetLandesindexWert(2, 2008, 11);
=================================================================================================*/

CREATE FUNCTION dbo.fnIkGetLandesindexWert
(
  @IkIndexTypCode INT,
  @Jahr INT,
  @Monat INT
)
RETURNS MONEY
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- get and return the value
  -----------------------------------------------------------------------------
  RETURN (SELECT LIW.Wert
          FROM dbo.IkLandesindexWert     LIW WITH (READUNCOMMITTED)
            INNER JOIN dbo.IkLandesindex LIN WITH (READUNCOMMITTED) ON LIN.IkLandesindexID = LIW.IkLandesindexID
            INNER JOIN dbo.XLOVCode      LOC WITH (READUNCOMMITTED) ON LOC.LOVName = 'IkIndexTyp'
                                                                   AND CONVERT(INT, LOC.Value1) = LIN.IkLandesindexID
                                                                   AND LOC.Code = @IkIndexTypCode
          WHERE LIW.Jahr = @Jahr
            AND LIW.Monat = @Monat);
END;
GO
