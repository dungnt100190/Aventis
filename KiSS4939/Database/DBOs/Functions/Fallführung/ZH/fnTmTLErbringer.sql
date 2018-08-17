SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnTmTLErbringer
GO
/*===============================================================================================
  $Revision: 4 $
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

CREATE FUNCTION dbo.fnTmTLErbringer (
  @FTPersonID	INT,
  @FaFallID		INT,
  @Type			varchar(15)
)

RETURNS varchar(5000)
AS 

BEGIN
  DECLARE @Result VARCHAR(5000)
  DECLARE @Value VARCHAR(200)
  DECLARE @actFallNr INT
  DECLARE @oldFallNr INT
  SET @Result = ''

  IF @Type = 'FT' BEGIN
  
	DECLARE csrTLErbringer CURSOR FOR 
    SELECT	LEI.FaFallID, 
            IsNull(USR.FirstName, '') + IsNull(', ' + USR.LastName, '')
			+ IsNull(', ' + USR.Funktion, '')
			+ IsNull(', ' + ORG.ItemName, '')
			+ CASE WHEN TLE.DatumVon IS NULL OR TLE.DatumVon = '' THEN '' ELSE ', ' + CONVERT(varchar, TLE.DatumVon, 104) END
			+ CASE WHEN TLE.DatumBis IS NULL OR TLE.DatumBis = '' THEN '' ELSE ' - ' + CONVERT(varchar, TLE.DatumBis, 104) END
	FROM   dbo.FaTeilLeistungserbringer TLE WITH (READUNCOMMITTED) 
		LEFT  JOIN dbo.XUser         USR WITH (READUNCOMMITTED) ON USR.UserID = TLE.UserID
		LEFT  JOIN dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED) ON OUU.UserID = TLE.UserID AND
                                       OUU.OrgUnitMemberCode = 2
		LEFT  JOIN dbo.XOrgUnit      ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
		LEFT  JOIN dbo.FaLeistung    LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = TLE.FaLeistungID
	WHERE TLE.FaLeistungID IN (SELECT FaLeistungID 
							FROM  dbo.FaLeistung WITH (READUNCOMMITTED)  
							WHERE BaPersonID = @FTPersonID
							AND   FaFallID = @FaFallID)
	AND LEI.DatumBis IS NULL
	ORDER BY  TLE.DatumBis, IsNull(TLE.DatumVon,GetDate()) DESC, USR.LastName

	SET @oldFallNr = 0

	OPEN csrTLErbringer
	WHILE 1 = 1 BEGIN
		FETCH NEXT FROM csrTLErbringer INTO @actFallNr, @Value
		IF NOT @@FETCH_STATUS = 0 BREAK
		
		IF NOT @oldFallNr = @actFallNr BEGIN
			SET @Result = @Result + 'Fall-Nr.: ' + CONVERT(varchar, @actFallNr) 
			SET @oldFallNr = @actFallNr 
		END 

		IF NOT @Result = '' BEGIN 
			SET @Result = @Result + CHAR(13) + CHAR(10) 		
		END
		SET @Result = @Result + ISNULL(@Value, '')
	END
	CLOSE csrTLErbringer
	DEALLOCATE csrTLErbringer
 
  END ELSE IF @Type = 'AKTIV' BEGIN

	DECLARE csrTLErbringer CURSOR FOR 
	SELECT	LEI.FaFallID, 
            IsNull(USR.FirstName, '') + IsNull(', ' + USR.LastName, '')
			+ IsNull(', ' + USR.Funktion, '')
			+ IsNull(', ' + ORG.ItemName, '')
			+ CASE WHEN TLE.DatumVon IS NULL OR TLE.DatumVon = '' THEN '' ELSE ', ' + CONVERT(varchar, TLE.DatumVon, 104) END
			+ CASE WHEN TLE.DatumBis IS NULL OR TLE.DatumBis = '' THEN '' ELSE ' - ' + CONVERT(varchar, TLE.DatumBis, 104) END
	FROM   dbo.FaTeilLeistungserbringer TLE WITH (READUNCOMMITTED) 
		LEFT  JOIN dbo.XUser         USR WITH (READUNCOMMITTED) ON USR.UserID = TLE.UserID
		LEFT  JOIN dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED) ON OUU.UserID = TLE.UserID AND
                                       OUU.OrgUnitMemberCode = 2
		LEFT  JOIN dbo.XOrgUnit      ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
		LEFT  JOIN dbo.FaLeistung    LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = TLE.FaLeistungID
	WHERE TLE.FaLeistungID NOT IN (SELECT FaLeistungID 
							FROM  dbo.FaLeistung WITH (READUNCOMMITTED) 
							WHERE BaPersonID = @FTPersonID
							AND   FaFallID = @FaFallID)
	AND TLE.FaLeistungID IN (SELECT FaLeistungID 
							FROM    dbo.FaLeistung WITH (READUNCOMMITTED) 
							WHERE   BaPersonID = @FTPersonID)
	AND LEI.DatumBis IS NULL
	ORDER BY  TLE.DatumBis, IsNull(TLE.DatumVon,GetDate()) DESC, USR.LastName

    SET @oldFallNr = 0

	OPEN csrTLErbringer
	WHILE 1 = 1 BEGIN
		FETCH NEXT FROM csrTLErbringer INTO @actFallNr, @Value
		IF NOT @@FETCH_STATUS = 0 BREAK

		IF NOT @oldFallNr = @actFallNr BEGIN
			SET @Result = @Result + 'Fall-Nr.: ' + CONVERT(varchar, @actFallNr) 
			SET @oldFallNr = @actFallNr 
		END 

		IF NOT @Result = '' BEGIN 
			SET @Result = @Result + CHAR(13) + CHAR(10) 		
		END
		SET @Result = @Result + ISNULL(@Value, '')
	END
	CLOSE csrTLErbringer
	DEALLOCATE csrTLErbringer

  END ELSE IF @Type = 'NICHTAKTIV' BEGIN

	DECLARE csrTLErbringer CURSOR FOR 
	SELECT	LEI.FaFallID, 
            IsNull(USR.FirstName, '') + IsNull(', ' + USR.LastName, '')
			+ IsNull(', ' + USR.Funktion, '')
			+ IsNull(', ' + ORG.ItemName, '')
			+ CASE WHEN TLE.DatumVon IS NULL OR TLE.DatumVon = '' THEN '' ELSE ', ' + CONVERT(varchar, TLE.DatumVon, 104) END
			+ CASE WHEN TLE.DatumBis IS NULL OR TLE.DatumBis = '' THEN '' ELSE ' - ' + CONVERT(varchar, TLE.DatumBis, 104) END
	FROM   dbo.FaTeilLeistungserbringer TLE WITH (READUNCOMMITTED) 
		LEFT  JOIN dbo.XUser         USR WITH (READUNCOMMITTED) ON USR.UserID = TLE.UserID
		LEFT  JOIN dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED) ON OUU.UserID = TLE.UserID AND
                                       OUU.OrgUnitMemberCode = 2
		LEFT  JOIN dbo.XOrgUnit      ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
		LEFT  JOIN dbo.FaLeistung    LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = TLE.FaLeistungID
	WHERE TLE.FaLeistungID NOT IN (SELECT FaLeistungID 
							FROM  dbo.FaLeistung WITH (READUNCOMMITTED) 
							WHERE BaPersonID = @FTPersonID
							AND   FaFallID = @FaFallID)
	AND TLE.FaLeistungID IN (SELECT FaLeistungID 
							FROM    dbo.FaLeistung WITH (READUNCOMMITTED) 
							WHERE   BaPersonID = @FTPersonID)
	AND LEI.DatumBis IS NOT NULL
	ORDER BY  IsNull(TLE.DatumBis,GetDate()) DESC, USR.LastName

	SET @oldFallNr = 0

	OPEN csrTLErbringer
	WHILE 1 = 1 BEGIN
		FETCH NEXT FROM csrTLErbringer INTO @actFallNr, @Value
		IF NOT @@FETCH_STATUS = 0 BREAK

		IF NOT @oldFallNr = @actFallNr BEGIN
			SET @Result = @Result + 'Fall-Nr.: ' + CONVERT(varchar, @actFallNr) 
			SET @oldFallNr = @actFallNr 
		END 

		IF NOT @Result = '' BEGIN 
			SET @Result = @Result + CHAR(13) + CHAR(10) 		
		END
		SET @Result = @Result + ISNULL(@Value, '')
	END
	CLOSE csrTLErbringer
	DEALLOCATE csrTLErbringer
  END 

  RETURN @Result
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
