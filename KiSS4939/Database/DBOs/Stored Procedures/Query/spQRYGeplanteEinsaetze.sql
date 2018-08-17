SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spQRYGeplanteEinsaetze;
GO
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Use this sp to get values for query "Geplante Einsaetze" within BW/ED-module
    @LanguageCode:  The language code to use for ML values
    @SearchMode:    The search mode for searching data
                    - 0 = searching client (@SearchID is BaPersonID)
                    - 1 = searching user   (@SearchID is UserID)
    @SearchID:      The search-id, depending on SearchMode (see above)
    @ZeitraumVon:   The beginning date to use
    @ZeitraumBis:   The ending date to use
    @TypCode:       The type-code to search for
    @CurrentUserID: The userid of the user who is currently logged in and using KiSS
  -
  RETURNS: Result depending on given search parameters and search mode
  -
  TEST:    EXEC dbo.spQRYGeplanteEinsaetze 5, 1, 0, NULL, NULL, NULL, NULL, 2
           EXEC dbo.spQRYGeplanteEinsaetze 5, 1, 1, NULL, NULL, NULL, NULL, 2
           --
           EXEC dbo.spQRYGeplanteEinsaetze 6, 1, 0, NULL, NULL, NULL, NULL, 2
           EXEC dbo.spQRYGeplanteEinsaetze 6, 1, 1, NULL, NULL, NULL, NULL, 2
=================================================================================================*/

CREATE PROCEDURE dbo.spQRYGeplanteEinsaetze
(
  @ModulID INT,
  @LanguageCode INT,
  @SearchMode INT,
  @SearchID INT,
  @ZeitraumVon DATETIME,
  @ZeitraumBis DATETIME,
  @TypCode INT,
  @CurrentUserID INT
)
AS
BEGIN
  -------------------------------------------------------------------------------
  -- start call
  -------------------------------------------------------------------------------
  SET NOCOUNT ON;
  PRINT ('start call: ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  -------------------------------------------------------------------------------
  -- set default values
  -------------------------------------------------------------------------------
  SET @LanguageCode = ISNULL(@LanguageCode, 1);
  
  -------------------------------------------------------------------------------
  -- vars
  -------------------------------------------------------------------------------
  DECLARE @ZeitraumString VARCHAR(100);
  
  -------------------------------------------------------------------------------
  -- validate
  -------------------------------------------------------------------------------
  IF (@ModulID NOT IN (5, 6) OR @SearchMode NOT IN (0, 1) OR @CurrentUserID IS NULL)
  BEGIN
    -- do not continue
    RETURN;
  END;
  
  -- set periode
  SET @ZeitraumString = dbo.fnGetZeitraumString(@ZeitraumVon, @ZeitraumBis);
  
  -------------------------------------------------------------------------------
  -- INFO: 
  -- Depending on given @ModulID, we search data either for BW or ED. The columns
  -- of the resulting datatable always need to have the same name! Changing one
  -- of the sql-script may result in chaning the others, too.
  -------------------------------------------------------------------------------
  
  -- ============================================================================
  -- BW
  -- ============================================================================
  IF (@ModulID = 5)
  BEGIN
    PRINT ('search BW: ' + CONVERT(VARCHAR, GETDATE(), 113));
    
    -- depending on search-mode, we search other data
    IF (@SearchMode = 0)
    BEGIN
      -- searching client (almost same as below)
      SELECT DISTINCT
             BaPersonID$     = PRS.BaPersonID,
             UserID$         = UEV.UserID,
             Klient          = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname) + ' (' + CONVERT(VARCHAR, PRS.BaPersonID) + ')',
             Mitarbeiter     = dbo.fnGetLastFirstName(UEV.UserID, NULL, NULL),
             TypCode         = dbo.fnGetLOVMLText('BwTyp', BWE.TypCode, @LanguageCode),
             AnzahlEinsaetze = COUNT(1),
             Zeitraum        = @ZeitraumString
      FROM dbo.BwEinsatz                           BWE WITH (READUNCOMMITTED)
        INNER JOIN dbo.XUser_BwEinsatzvereinbarung UEV WITH (READUNCOMMITTED) ON UEV.XUser_BwEinsatzvereinbarungID = BWE.XUser_BwEinsatzvereinbarungID
        INNER JOIN dbo.FaLeistung                  LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = BWE.FaLeistungID
        INNER JOIN dbo.BaPerson                    PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
        
        -- rights
        INNER JOIN dbo.fnGetCantonsOrgUnitsUsers(@CurrentUserID)            COU ON COU.UserID = UEV.UserID
        INNER JOIN dbo.fnGetCantonsOrgUnitsPersons(@CurrentUserID, 0, NULL) COP ON COP.BaPersonID = LEI.BaPersonID
        
      WHERE (@ZeitraumVon IS NULL OR dbo.fnDateOf(BWE.Beginn) >= @ZeitraumVon) 
        AND (@ZeitraumBis IS NULL OR dbo.fnDateOf(BWE.Ende) <= @ZeitraumBis) 
        AND (@TypCode     IS NULL OR BWE.TypCode = @TypCode) 
        AND (@SearchID    IS NULL OR LEI.BaPersonID = @SearchID)  -- different search condition
      GROUP BY PRS.BaPersonID,
               UEV.UserID,
               dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname) + ' (' + CONVERT(VARCHAR, PRS.BaPersonID) + ')',
               dbo.fnGetLastFirstName(UEV.UserID, NULL, NULL),
               dbo.fnGetLOVMLText('BwTyp', BWE.TypCode, @LanguageCode)
      ORDER BY Klient, Mitarbeiter, TypCode;                      -- different ordering
    END
    -------------------------------------------------------------------------------
    ELSE
    BEGIN
      -- searching user (almost same as above)
      SELECT DISTINCT
             BaPersonID$     = PRS.BaPersonID,
             UserID$         = UEV.UserID,
             Klient          = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname) + ' (' + CONVERT(VARCHAR, PRS.BaPersonID) + ')',
             Mitarbeiter     = dbo.fnGetLastFirstName(UEV.UserID, NULL, NULL),
             TypCode         = dbo.fnGetLOVMLText('BwTyp', BWE.TypCode, @LanguageCode),
             AnzahlEinsaetze = COUNT(1),
             Zeitraum        = @ZeitraumString
      FROM dbo.BwEinsatz                           BWE WITH (READUNCOMMITTED)
        INNER JOIN dbo.XUser_BwEinsatzvereinbarung UEV WITH (READUNCOMMITTED) ON UEV.XUser_BwEinsatzvereinbarungID = BWE.XUser_BwEinsatzvereinbarungID
        INNER JOIN dbo.FaLeistung                  LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = BWE.FaLeistungID
        INNER JOIN dbo.BaPerson                    PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
        
        -- rights
        INNER JOIN dbo.fnGetCantonsOrgUnitsUsers(@CurrentUserID)      COU ON COU.UserID = UEV.UserID
        INNER JOIN dbo.fnGetCantonsOrgUnitsPersons(@CurrentUserID, 0, NULL) COP ON COP.BaPersonID = LEI.BaPersonID
        
      WHERE (@ZeitraumVon IS NULL OR dbo.fnDateOf(BWE.Beginn) >= @ZeitraumVon) 
        AND (@ZeitraumBis IS NULL OR dbo.fnDateOf(BWE.Ende) <= @ZeitraumBis) 
        AND (@TypCode     IS NULL OR BWE.TypCode = @TypCode) 
        AND (@SearchID    IS NULL OR UEV.UserID = @SearchID)      -- different search condition
      GROUP BY PRS.BaPersonID, 
               UEV.UserID,
               dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname) + ' (' + CONVERT(VARCHAR, PRS.BaPersonID) + ')',
               dbo.fnGetLastFirstName(UEV.UserID, NULL, NULL),
               dbo.fnGetLOVMLText('BwTyp', BWE.TypCode, @LanguageCode)
      ORDER BY Mitarbeiter, Klient, TypCode;                      -- different ordering
    END;
  END;
  
  -- ============================================================================
  -- ED
  -- ============================================================================
  IF (@ModulID = 6)
  BEGIN
    PRINT ('search ED: ' + CONVERT(VARCHAR, GETDATE(), 113));
    
    -- depending on search-mode, we search other data
    IF (@SearchMode = 0)
    BEGIN
      -- searching client (almost same as below)
      SELECT DISTINCT
             BaPersonID$     = PRS.BaPersonID,
             UserID$         = UEV.UserID,
             Klient          = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname) + ' (' + CONVERT(VARCHAR, PRS.BaPersonID) + ')',
             Mitarbeiter     = dbo.fnGetLastFirstName(UEV.UserID, NULL, NULL),
             TypCode         = dbo.fnGetLOVMLText('EdTyp', EDE.TypCode, @LanguageCode),
             AnzahlEinsaetze = COUNT(1),
             Zeitraum        = @ZeitraumString
      FROM dbo.EdEinsatz                           EDE WITH (READUNCOMMITTED)
        INNER JOIN dbo.XUser_EdEinsatzvereinbarung UEV WITH (READUNCOMMITTED) ON UEV.XUser_EdEinsatzvereinbarungID = EDE.XUser_EdEinsatzvereinbarungID
        INNER JOIN dbo.FaLeistung                  LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = EDE.FaLeistungID
        INNER JOIN dbo.BaPerson                    PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
        
        -- rights
        INNER JOIN dbo.fnGetCantonsOrgUnitsUsers(@CurrentUserID)      COU ON COU.UserID = UEV.UserID
        INNER JOIN dbo.fnGetCantonsOrgUnitsPersons(@CurrentUserID, 0, NULL) COP ON COP.BaPersonID = LEI.BaPersonID
        
      WHERE (@ZeitraumVon IS NULL OR dbo.fnDateOf(EDE.Beginn) >= @ZeitraumVon) 
        AND (@ZeitraumBis IS NULL OR dbo.fnDateOf(EDE.Ende) <= @ZeitraumBis) 
        AND (@TypCode     IS NULL OR EDE.TypCode = @TypCode) 
        AND (@SearchID    IS NULL OR LEI.BaPersonID = @SearchID)  -- different search condition
      GROUP BY PRS.BaPersonID,
               UEV.UserID,
               dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname) + ' (' + CONVERT(VARCHAR, PRS.BaPersonID) + ')',
               dbo.fnGetLastFirstName(UEV.UserID, NULL, NULL),
               dbo.fnGetLOVMLText('EdTyp', EDE.TypCode, @LanguageCode)
      ORDER BY Klient, Mitarbeiter, TypCode;                      -- different ordering
    END
    -------------------------------------------------------------------------------
    ELSE
    BEGIN
      -- searching user (almost same as above)
      SELECT DISTINCT
             BaPersonID$     = PRS.BaPersonID,
             UserID$         = UEV.UserID,
             Klient          = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname) + ' (' + CONVERT(VARCHAR, PRS.BaPersonID) + ')',
             Mitarbeiter     = dbo.fnGetLastFirstName(UEV.UserID, NULL, NULL),
             TypCode         = dbo.fnGetLOVMLText('EdTyp', EDE.TypCode, @LanguageCode),
             AnzahlEinsaetze = COUNT(1),
             Zeitraum        = @ZeitraumString
      FROM dbo.EdEinsatz                           EDE WITH (READUNCOMMITTED)
        INNER JOIN dbo.XUser_EdEinsatzvereinbarung UEV WITH (READUNCOMMITTED) ON UEV.XUser_EdEinsatzvereinbarungID = EDE.XUser_EdEinsatzvereinbarungID
        INNER JOIN dbo.FaLeistung                  LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = EDE.FaLeistungID
        INNER JOIN dbo.BaPerson                    PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
        
        -- rights
        INNER JOIN dbo.fnGetCantonsOrgUnitsUsers(@CurrentUserID)      COU ON COU.UserID = UEV.UserID
        INNER JOIN dbo.fnGetCantonsOrgUnitsPersons(@CurrentUserID, 0, NULL) COP ON COP.BaPersonID = LEI.BaPersonID
        
      WHERE (@ZeitraumVon IS NULL OR dbo.fnDateOf(EDE.Beginn) >= @ZeitraumVon) 
        AND (@ZeitraumBis IS NULL OR dbo.fnDateOf(EDE.Ende) <= @ZeitraumBis) 
        AND (@TypCode     IS NULL OR EDE.TypCode = @TypCode) 
        AND (@SearchID    IS NULL OR UEV.UserID = @SearchID)      -- different search condition
      GROUP BY PRS.BaPersonID, 
               UEV.UserID,
               dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname) + ' (' + CONVERT(VARCHAR, PRS.BaPersonID) + ')',
               dbo.fnGetLastFirstName(UEV.UserID, NULL, NULL),
               dbo.fnGetLOVMLText('EdTyp', EDE.TypCode, @LanguageCode)
      ORDER BY Mitarbeiter, Klient, TypCode;                      -- different ordering
    END;
  END;
  
  -------------------------------------------------------------------------------
  -- done
  -------------------------------------------------------------------------------
  RETURN;
END;
GO
