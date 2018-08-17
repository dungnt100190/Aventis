SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
EXECUTE dbo.spDropObject spBaKantonalerZuschuss_Retrieve
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Stored Procedures/Basis/spBaKantonalerZuschuss_Retrieve.sql $
  $Author: Lloreggia $
  $Modtime: 6.01.10 18:20 $
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: This sp provides read access to the current available and assigned KantonalenZuschüsse 
           for given BaPersonID and date
    @Mode:         The desired data mode
                     - @Mode='available' = get all availables entries that are not connected to person
                     - @Mode='assigned' = get all availables entries that are connected to person
    @BaPersonID:   The id of the person to get data for
    @Date:         The date the data has to be gotten (NULL=current date)
    @LanguageCode: The language code to use (1=german (default))
  -
  RETURNS: The desired data for the given person and date
  -
  TEST:    EXEC dbo.spBaKantonalerZuschuss_Retrieve 'available', 77923, NULL, 1
           EXEC dbo.spBaKantonalerZuschuss_Retrieve 'assigned', 77923, NULL, 1
           
           EXEC dbo.spBaKantonalerZuschuss_Retrieve 'available', 1, NULL, 1
           EXEC dbo.spBaKantonalerZuschuss_Retrieve 'assigned', 1, NULL, 1
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Stored Procedures/Basis/spBaKantonalerZuschuss_Retrieve.sql $
 * 
 * 5     6.01.10 18:21 Lloreggia
 * Alter to Create
 * 
 * 4     1.12.08 11:53 Cjaeggi
 * Added cantone information
 * 
 * 3     1.12.08 9:16 Cjaeggi
 * Fixed comment
 * 
 * 2     1.12.08 8:38 Cjaeggi
 * Added filter 'Aktiv'
 * 
 * 1     28.11.08 17:17 Cjaeggi
 * First version
=================================================================================================*/

CREATE PROCEDURE dbo.spBaKantonalerZuschuss_Retrieve
(
  @Mode VARCHAR(20),
  @BaPersonID INT,
  @Date DATETIME,
  @LanguageCode INT
)
AS BEGIN
  -------------------------------------------------------------------------------
  -- Init temporary table
  -------------------------------------------------------------------------------
  DECLARE @TmpBaKantonalerZuschuss TABLE
  (
    BaKantonalerZuschussID INT NOT NULL PRIMARY KEY,
    BaPersonID INT NOT NULL,
    MLBezeichnung VARCHAR(255) NOT NULL
  )

  -------------------------------------------------------------------------------
  -- Validate
  -------------------------------------------------------------------------------
  IF (ISNULL(@BaPersonID, -1) < 1 OR @Mode NOT IN ('available', 'assigned'))
  BEGIN
    -- invalid values, show empty table
    SELECT TMP.*
    FROM @TmpBaKantonalerZuschuss TMP
    
    -- do not continue
    RETURN
  END
  
  -- set language code
  SET @LanguageCode = ISNULL(@LanguageCode, 1)
  SET @Date = ISNULL(@Date, GETDATE())
  
  -------------------------------------------------------------------------------
  -- Load mode-depending entries
  -------------------------------------------------------------------------------
  IF (@Mode = 'available')
  BEGIN 
    -----------------------------------------------------------------------------
    -- Get data for available entries
    -----------------------------------------------------------------------------
    INSERT INTO @TmpBaKantonalerZuschuss
      SELECT BaKantonalerZuschussID = KZS.BaKantonalerZuschussID,
             BaPersonID             = @BaPersonID,
             MLBezeichnung          = dbo.fnGetMLTextByDefault(KZS.BezeichnungTID, @LanguageCode, KZS.Bezeichnung) + ISNULL(' (' + LOV.ShortText + ')', '')
      FROM dbo.BaKantonalerZuschuss KZS WITH(READUNCOMMITTED)
        LEFT JOIN dbo.BaPerson_KantonalerZuschuss PKZ WITH (READUNCOMMITTED) ON PKZ.BaKantonalerZuschussID = KZS.BaKantonalerZuschussID AND 
                                                                                PKZ.BaPersonID = @BaPersonID
        LEFT JOIN dbo.XLOVCode                    LOV WITH (READUNCOMMITTED) ON LOV.LOVName = 'Kanton' AND 
                                                                                LOV.Code = KZS.KantonCode
      WHERE KZS.Aktiv = 1 AND
            PKZ.BaKantonalerZuschussID IS NULL
  END
  ELSE IF (@Mode = 'assigned')
  BEGIN
    -----------------------------------------------------------------------------
    -- Get data for assigned entries
    -----------------------------------------------------------------------------
    INSERT INTO @TmpBaKantonalerZuschuss
      SELECT BaKantonalerZuschussID = PKZ.BaKantonalerZuschussID,
             BaPersonID             = PKZ.BaPersonID,
             MLBezeichnung          = dbo.fnGetMLTextByDefault(KZS.BezeichnungTID, @LanguageCode, KZS.Bezeichnung) + ISNULL(' (' + LOV.ShortText + ')', '')
      FROM dbo.BaPerson_KantonalerZuschuss PKZ WITH (READUNCOMMITTED)
        INNER JOIN dbo.BaKantonalerZuschuss KZS WITH (READUNCOMMITTED) ON KZS.BaKantonalerZuschussID = PKZ.BaKantonalerZuschussID AND
                                                                          KZS.Aktiv = 1
        LEFT JOIN dbo.XLOVCode              LOV WITH (READUNCOMMITTED) ON LOV.LOVName = 'Kanton' AND 
                                                                          LOV.Code = KZS.KantonCode
      WHERE PKZ.BaPersonID = @BaPersonID
  END
  
  -------------------------------------------------------------------------------
  -- Show selected data
  -------------------------------------------------------------------------------
  SELECT TMP.*
  FROM @TmpBaKantonalerZuschuss TMP
  ORDER BY TMP.MLBezeichnung, TMP.BaKantonalerZuschussID
END
