 SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
EXECUTE dbo.spDropObject spEdMaKursTextmarkeListe
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Stored Procedures/Entlastungsdienst/spEdMaKursTextmarkeListe.sql $
  $Author: Cjaeggi $
  $Modtime: 29.09.09 15:19 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this stored procedure to get data for bookmarks on EdMitarbeiter_Kurs
    @MaKursIDsCsv:  The EdMitarbeiter_KursID's as a csv-List
    @LanguageCode:  The language code to use for multilanguage output
  -
  RETURNS: The desired table output for EdMitarbeiter / Weiterbildung as shown on gui (@MaKursIDsCsv) for resulttable
  -
  TEST:    EXEC [dbo].[spEdMaKursTextmarkeListe] '7,8,9', 1
           EXEC [dbo].[spEdMaKursTextmarkeListe] '7,8,9', NULL
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Stored Procedures/Entlastungsdienst/spEdMaKursTextmarkeListe.sql $
 * 
 * 2     29.09.09 15:20 Cjaeggi
 * #5043: Fixed some minor behaviour bugs
 * 
 * 1     8.09.09 15:41 Spsota
 * #5043 SP for MaKursTextmarken
=================================================================================================*/

CREATE PROCEDURE [dbo].[spEdMaKursTextmarkeListe]
(
  @MaKursIDsCsv VARCHAR(1000),
  @LanguageCode INT
)
AS 
BEGIN
  -------------------------------------------------------------------------------
  -- start call
  -------------------------------------------------------------------------------
  SET NOCOUNT ON
  PRINT ('start call: ' + CONVERT(VARCHAR, GETDATE(), 113))
  
  -------------------------------------------------------------------------------
  -- validate
  -------------------------------------------------------------------------------
  IF (ISNULL(@MaKursIDsCsv, '') = '')
  BEGIN
    -- do nothing
    RETURN
  END
  
  -- set default values
  SET @LanguageCode = ISNULL(@LanguageCode, 1)  -- by default german
  
  -------------------------------------------------------------------------------
  -- fill temporary table with csv-values separated as rows
  -------------------------------------------------------------------------------
  -- init temp table to store csv values
  DECLARE @MaKursIDs TABLE
  (
    ID INT IDENTITY(1, 1),
    OccurenceID INT NOT NULL,
    EdMaKursID INT NOT NULL
  )
  
  -- fill table
  INSERT INTO @MaKursIDs (OccurenceID, EdMaKursID)
    SELECT OccurenceID = FCN.OccurenceID,
           EdMaKursID  = CONVERT(INT, FCN.SplitValue)
    FROM dbo.fnSplitStringToValues(@MaKursIDsCsv, ',', 1) FCN
  
  -- info
  PRINT ('done with init, getting data now: ' + CONVERT(VARCHAR, GETDATE(), 113))
  
  --=============================================================================
  -- OUTPUT
  --=============================================================================
  SELECT Kurs         = dbo.fnGetMLTextByDefault(EDK.BezeichnungTID, @LanguageCode, EDK.Bezeichnung) + ISNULL(' (' + ORG.ItemName + ')', ''), 
         --
         NextCell     = NULL,
         --
         Frist        = CASE WHEN EMK.Dispensiert = 1 THEN NULL
                             ELSE EMK.ZuAbsolvierenBis
                        END,
         --
         NextCell     = NULL,
         --
         Absolviert   = EMK.AbsolviertAm,
         --
         NextCell     = NULL,
         --
         Dispensiert  = dbo.fnGetYesNoMLText(EMK.Dispensiert, @LanguageCode, 0),
         --
         NextCell     = NULL,
         --
         Bemerkungen  = EMK.Bemerkungen,
         --
         NextCell     = NULL
  FROM dbo.EdMitarbeiter_Kurs EMK WITH (READUNCOMMITTED)
    INNER JOIN @MaKursIDs   IDS                        ON EMK.EdMitarbeiter_KursID = IDS.EdMaKursID
    LEFT  JOIN dbo.EdKurs   EDK WITH (READUNCOMMITTED) ON EMK.EdKursID = EDK.EdKursID
    LEFT  JOIN dbo.XOrgUnit ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = EDK.OrgUnitID
  ORDER BY EMK.AbsolviertAm, EMK.ZuAbsolvierenBis, Kurs
  
  -- info
  PRINT ('done output: ' + CONVERT(VARCHAR, GETDATE(), 113))
END
