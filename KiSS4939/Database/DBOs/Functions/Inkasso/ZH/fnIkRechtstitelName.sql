SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnIkRechtstitelName
GO
/*===============================================================================================
  $Revision: 9 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Holt den Namen des Rechtstitels zu einer Position.
    @Param1:   IkPositionID.
  -
  RETURNS: Namen des Rechtstitels.
  -
=================================================================================================
  TEST:    SELECT dbo.fnIkRechtstitelName(-1)
=================================================================================================*/

CREATE FUNCTION dbo.fnIkRechtstitelName
(
  @IkPositionID INT,
  @FaLeistungID INT,
  @Jahr INT,
  @Monat INT,
  @BaPersonID INT
)
RETURNS VARCHAR(MAX)
AS BEGIN

  DECLARE @Anzahl INT
  IF @IkPositionID IS NULL
  BEGIN
    -- Wenn die Ansicht nach Jahr, Monat, Person zusammengezogen ist
    SELECT @Anzahl = COUNT(DISTINCT RP.IkRechtstitelID) FROM dbo.IkRechtstitelPosition RP
    LEFT JOIN dbo.IkPosition P ON P.IkPositionID = RP.IkPositionID
    WHERE P.FaLeistungID = @FaLeistungID
      AND P.Jahr = @Jahr
      AND P.Monat = @Monat
      AND P.BaPersonID = @BaPersonID
  END ELSE
  BEGIN
    -- Wenn die Ansicht nicht zusammengezogen ist
    SELECT @Anzahl = COUNT(DISTINCT RP.IkRechtstitelID) FROM dbo.IkRechtstitelPosition RP
    WHERE RP.IkPositionID = @IkPositionID
  END

  IF @Anzahl > 1
  BEGIN
    RETURN '[diverse]'
  END

  IF @Anzahl < 1
  BEGIN
    RETURN ''
  END

  -- Jetzt den Namen des Rechtstitesl holen
  DECLARE @Result VARCHAR(MAX)
  IF @IkPositionID IS NULL
  BEGIN
    -- Wenn die Ansicht nach Jahr, Monat, Person zusammengezogen ist
    -- vor 01.08.2009, provisorisch ausgeklammert, bis Konzept klar ist
    /*
    SELECT TOP 1 @Result = R.Bezeichnung FROM dbo.IkRechtstitelPosition RP
    LEFT JOIN dbo.IkPosition P ON P.IkPositionID = RP.IkPositionID
    LEFT JOIN dbo.IkRechtstitel R ON R.IkRechtstitelID = RP.IkRechtstitelID
    WHERE P.FaLeistungID = @FaLeistungID
      AND P.Jahr = @Jahr
      AND P.Monat = @Monat
      AND P.BaPersonID = @BaPersonID
    */

    -- nach 01.08.2009
    SELECT TOP 1 @Result = CASE
      WHEN L.FaProzessCode = 407 THEN R.Bezeichnung
      ELSE LOV.Text + ISNULL(', ' + CONVERT(VARCHAR, RI.RechtstitelDatumVon, 104), '')
    END
    FROM dbo.IkRechtstitelPosition RP
    LEFT JOIN dbo.IkPosition P ON P.IkPositionID = RP.IkPositionID
    LEFT JOIN dbo.FaLeistung L WITH(READUNCOMMITTED) ON L.FaLeistungID = P.FaLeistungID
    LEFT JOIN dbo.IkRechtstitel R WITH(READUNCOMMITTED) ON R.IkRechtstitelID = RP.IkRechtstitelID
    LEFT JOIN dbo.IkRechtstitelInfos RI WITH(READUNCOMMITTED) ON RI.IkRechtstitelInfosID = (
      SELECT MAX(RIX.IkRechtstitelInfosID) FROM dbo.IkRechtstitelInfos RIX WITH(READUNCOMMITTED)
      WHERE RIX.IkRechtstitelID = R.IkRechtstitelID
    )
    LEFT JOIN dbo.XLOVCode LOV WITH(READUNCOMMITTED) ON LOV.LOVName = 'IkRechtstitel' AND LOV.Code = RI.IkRechtstitelCode
    WHERE P.FaLeistungID = @FaLeistungID
      AND P.Jahr = @Jahr
      AND P.Monat = @Monat
      AND P.BaPersonID = @BaPersonID
  END ELSE
  BEGIN
    -- Wenn die Ansicht nicht zusammengezogen ist
    -- vor 01.08.2009, provisorisch ausgeklammert, bis Konzept klar ist
    /*
    SELECT TOP 1 @Result = R.Bezeichnung FROM dbo.IkRechtstitelPosition RP
    LEFT JOIN dbo.IkRechtstitel R ON R.IkRechtstitelID = RP.IkRechtstitelID
    WHERE RP.IkPositionID = @IkPositionID
    */
    -- nach 01.08.2009
    SELECT TOP 1 @Result = CASE
      WHEN L.FaProzessCode = 407 THEN R.Bezeichnung
      ELSE LOV.Text + ISNULL(', ' + CONVERT(VARCHAR, RI.RechtstitelDatumVon, 104), '')
    END
    FROM dbo.IkRechtstitelPosition RP
    LEFT JOIN dbo.IkRechtstitel R WITH(READUNCOMMITTED) ON R.IkRechtstitelID = RP.IkRechtstitelID
    LEFT JOIN dbo.FaLeistung L WITH(READUNCOMMITTED) ON L.FaLeistungID = R.FaLeistungID
    LEFT JOIN dbo.IkRechtstitelInfos RI WITH(READUNCOMMITTED) ON RI.IkRechtstitelInfosID = (
      SELECT MAX(RIX.IkRechtstitelInfosID) FROM dbo.IkRechtstitelInfos RIX WITH(READUNCOMMITTED)
      WHERE RIX.IkRechtstitelID = R.IkRechtstitelID
    )
    LEFT JOIN dbo.XLOVCode LOV WITH(READUNCOMMITTED) ON LOV.LOVName = 'IkRechtstitel' AND LOV.Code = RI.IkRechtstitelCode
    WHERE RP.IkPositionID = @IkPositionID
  END

  RETURN @Result
END

GO
