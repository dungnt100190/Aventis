SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnFaGetBeteiligtePersonenInstitutionen;
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get list of possible related persons and institutions for given
           client
    @BaPersonID:   The ID of the person to get data from
    @CurrentIDsCSV: The current assigned connected persons and instituions as CSV
  -
  RETURNS: Table containing all possible related persons (if assigned: even those who are no more
           connected to person directly)
=================================================================================================
  TEST:    SELECT * FROM dbo.fnFaGetBeteiligtePersonenInstitutionen(42773, NULL)
=================================================================================================*/

CREATE FUNCTION dbo.fnFaGetBeteiligtePersonenInstitutionen
(
  @BaPersonID INT,
  @CurrentIDsCSV VARCHAR(255)
)
RETURNS @Result TABLE
(
  [ID$] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
  [Code] INT UNIQUE NOT NULL,
  [Text] VARCHAR(255) NOT NULL,
  [Typ] VARCHAR(50) NOT NULL
)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (ISNULL(@BaPersonID, -1) < 1)
  BEGIN
    -- invalid person, do nothing
    RETURN;
  END;
  
  -----------------------------------------------------------------------------
  -- create temporary table for proper sorting later on (same as result!)
  -----------------------------------------------------------------------------
  DECLARE @TmpData TABLE
  (
    [ID$] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    [Code] INT UNIQUE NOT NULL,
    [Text] VARCHAR(255) NOT NULL,
    [Typ] VARCHAR(50) NOT NULL
  );
  
  -----------------------------------------------------------------------------
  -- get current related persons and institutions
  -- search within Klientensysten and KlientenInstitutionen
  -----------------------------------------------------------------------------
  INSERT INTO @TmpData ([Code], [Text], [Typ])
    -- (+): all persons (including current client)
    SELECT DISTINCT
           [Code]	= PRS.BaPersonID,
           [Text] = dbo.fnGetLastFirstName(NULL, Name, Vorname),
           [Typ]  = 'Person'
    FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
    WHERE PRS.BaPersonID IN (SELECT BaPersonID_1
                             FROM dbo.BaPerson_Relation WITH (READUNCOMMITTED)
                             WHERE BaPersonID_2 = @BaPersonID
                             
                             UNION ALL
                             
                             SELECT BaPersonID_2
                             FROM dbo.BaPerson_Relation WITH (READUNCOMMITTED)
                             WHERE BaPersonID_1 = @BaPersonID
                             
                             UNION ALL
                             
                             SELECT @BaPersonID)
    
    UNION ALL
    
    -- (-): all institutions
    SELECT DISTINCT
           [Code] = -INS.BaInstitutionID,
           [Text] = dbo.fnGetLastFirstName(NULL, INS.Name, INS.Vorname) + ISNULL(', ' + ADR.Zusatz, '') + ISNULL(', ' + ADR.Ort, ''),
           [Typ]  = 'Institution'
    FROM dbo.BaInstitution                  INS WITH (READUNCOMMITTED)
      INNER JOIN dbo.BaPerson_BaInstitution BPI WITH (READUNCOMMITTeD) ON BPI.BaInstitutionID = INS.BaInstitutionID
      LEFT  JOIN dbo.BaAdresse              ADR WITH (READUNCOMMITTED) ON ADR.BaAdresseID = dbo.fnBaGetBaAdresseID('BaInstitutionID', INS.BaInstitutionID, NULL, NULL)
    WHERE BPI.BaPersonID IN (SELECT BaPersonID_1
                             FROM dbo.BaPerson_Relation WITH (READUNCOMMITTED)
                             WHERE BaPersonID_2 = @BaPersonID
                             
                             UNION ALL
                             
                             SELECT BaPersonID_2
                             FROM dbo.BaPerson_Relation WITH (READUNCOMMITTED)
                             WHERE BaPersonID_1 = @BaPersonID
                             
                             UNION ALL
                             
                             SELECT @BaPersonID);
  
  -----------------------------------------------------------------------------
  -- add missing entries if defined
  -----------------------------------------------------------------------------
  IF (ISNULL(@CurrentIDsCSV, '') <> '')
  BEGIN
    -- valid current value, so create another temporary table for split
    DECLARE @TmpCurrentIDs TABLE
    (
      CurrentID INT NOT NULL
    );
    
    ---------------------------------------------------------------------------
    -- split csv-values to temp table
    ---------------------------------------------------------------------------
    INSERT INTO @TmpCurrentIDs
      SELECT CurrentID = CONVERT(INT, FCN.SplitValue)
      FROM dbo.fnSplitStringToValues(@CurrentIDsCSV, ',', 1) FCN;
    
    ---------------------------------------------------------------------------
    -- add missing ids
    ---------------------------------------------------------------------------
    INSERT INTO @TmpData ([Code], [Text], [Typ])
      -- (+): all missing but assigned persons
      SELECT DISTINCT
             [Code]	= CID.CurrentID,
             [Text] = dbo.fnGetLastFirstName(NULL, Name, Vorname),
             [Typ]  = 'Person'
      FROM @TmpCurrentIDs CID
        INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = CID.CurrentID
      WHERE CID.CurrentID > 0 AND
            CID.CurrentID NOT IN (SELECT [Code]
                                  FROM @TmpData TMP)
      
      UNION ALL
      
      -- (-): all missing but assigned institutions
      SELECT DISTINCT
             [Code] = CID.CurrentID,  -- is already (-)
             [Text] = dbo.fnGetLastFirstName(NULL, INS.Name, INS.Vorname) + ISNULL(', ' + ADR.Zusatz, '') + ISNULL(', ' + ADR.Ort, ''),
             [Typ]  = 'Institution'
      FROM @TmpCurrentIDs            CID
        INNER JOIN dbo.BaInstitution INS WITH (READUNCOMMITTED) ON INS.BaInstitutionID = -(CID.CurrentID)
        LEFT  JOIN dbo.BaAdresse     ADR WITH (READUNCOMMITTED) ON ADR.BaAdresseID = dbo.fnBaGetBaAdresseID('BaInstitutionID', INS.BaInstitutionID, NULL, NULL)
      WHERE CID.CurrentID < 0 AND
            CID.CurrentID NOT IN (SELECT [Code]
                                  FROM @TmpData TMP);
  END;
  
  -----------------------------------------------------------------------------
  -- copy output to result with proper sorting
  -----------------------------------------------------------------------------
  INSERT INTO @Result ([Code], [Text], [Typ])
    SELECT [Code],
           [Text],
           [Typ]
    FROM @TmpData TMP
    ORDER BY CASE WHEN [Code] > 0 AND [Code] = @BaPersonID THEN 0 -- current @BaPersonID always has to be first entry
                  ELSE 1
             END,
             [Typ] DESC,
             [Text];
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN;
END;
GO