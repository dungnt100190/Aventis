SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEGetLohnartDropDown;
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get a user-specific lov-like result for lohnart
    @UserID:       The user to get data from
    @LanguageCode: The language code to use for display
  -
  RETURNS: Table containing all clients of all orgunits of current user's canton
  -
=================================================================================================
  TEST:    SELECT * FROM [dbo].[fnBDEGetLohnartDropDown](17, 1)
           SELECT * FROM [dbo].[fnBDEGetLohnartDropDown](915, 1)
           SELECT * FROM [dbo].[fnBDEGetLohnartDropDown](1584, 1)
           SELECT * FROM [dbo].[fnBDEGetLohnartDropDown](1168, 1)
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEGetLohnartDropDown
(
  @UserID INT,
  @LanguageCode INT
)
RETURNS @Result TABLE
(
  [Code] INT,
  [Text] VARCHAR(200) NOT NULL
)
AS BEGIN
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @LohnType INT;
  DECLARE @KeinExport BIT;

  -----------------------------------------------------------------------------
  -- get data
  -----------------------------------------------------------------------------
  SELECT @LohnType       = LohntypCode, -- 1 = Monatslohn, 2 = Stundenlohn
         @KeinExport     = KeinBDEExport
  FROM dbo.XUser WITH (READUNCOMMITTED)
  WHERE UserID = @UserID;

  -----------------------------------------------------------------------------
  -- validate type
  -----------------------------------------------------------------------------
  IF (@LohnType IS NULL OR @LohnType NOT IN (1, 2))
  BEGIN
    -- invalid value, cannot display a result
    RETURN;
  END;

  -----------------------------------------------------------------------------
  -- check which type
  -----------------------------------------------------------------------------
  IF (@LohnType = 1)
  BEGIN
    -- Monatslohn, add row for monatslohn (default value)
    INSERT INTO @Result
      SELECT -1,
             dbo.fnXDbObjectMLMsg('fnBDEGetLohnartDropDown', 'MonatslohnEntry', @LanguageCode);
  END;

  -----------------------------------------------------------------------------
  -- add lohnart values
  -----------------------------------------------------------------------------
  INSERT INTO @Result
    SELECT LOV.Code,
           dbo.fnGetLOVMLText(LOV.LOVName, LOV.Code, @LanguageCode) +
             ISNULL(' (' + CONVERT(VARCHAR(255), COALESCE(USA1.Lohnart1, USA2.Lohnart2, USA3.Lohnart3, USA4.Lohnart4, USA5.Lohnart5,
                                                          USA6.Lohnart6, USA7.Lohnart7, USA8.Lohnart8, USA9.Lohnart9, USA10.Lohnart10,
                                                          USA11.Lohnart11, USA12.Lohnart12, USA13.Lohnart13, USA14.Lohnart14, USA15.Lohnart15,
                                                          USA16.Lohnart16, USA17.Lohnart17, USA18.Lohnart18, USA19.Lohnart19, USA20.Lohnart20)) + ' SFr.)', '')
    FROM dbo.XLOVCode                  LOV   WITH(READUNCOMMITTED)
      LEFT JOIN dbo.XUserStundenansatz USA1  WITH(READUNCOMMITTED) ON USA1.UserID = @UserID AND USA1.Lohnart1 > 0 AND LOV.Value1 = 'LA1'
      LEFT JOIN dbo.XUserStundenansatz USA2  WITH(READUNCOMMITTED) ON USA2.UserID = @UserID AND USA2.Lohnart2 > 0 AND LOV.Value1 = 'LA2'
      LEFT JOIN dbo.XUserStundenansatz USA3  WITH(READUNCOMMITTED) ON USA3.UserID = @UserID AND USA3.Lohnart3 > 0 AND LOV.Value1 = 'LA3'
      LEFT JOIN dbo.XUserStundenansatz USA4  WITH(READUNCOMMITTED) ON USA4.UserID = @UserID AND USA4.Lohnart4 > 0 AND LOV.Value1 = 'LA4'
      LEFT JOIN dbo.XUserStundenansatz USA5  WITH(READUNCOMMITTED) ON USA5.UserID = @UserID AND USA5.Lohnart5 > 0 AND LOV.Value1 = 'LA5'
      LEFT JOIN dbo.XUserStundenansatz USA6  WITH(READUNCOMMITTED) ON USA6.UserID = @UserID AND USA6.Lohnart6 > 0 AND LOV.Value1 = 'LA6'
      LEFT JOIN dbo.XUserStundenansatz USA7  WITH(READUNCOMMITTED) ON USA7.UserID = @UserID AND USA7.Lohnart7 > 0 AND LOV.Value1 = 'LA7'
      LEFT JOIN dbo.XUserStundenansatz USA8  WITH(READUNCOMMITTED) ON USA8.UserID = @UserID AND USA8.Lohnart8 > 0 AND LOV.Value1 = 'LA8'
      LEFT JOIN dbo.XUserStundenansatz USA9  WITH(READUNCOMMITTED) ON USA9.UserID = @UserID AND USA9.Lohnart9 > 0 AND LOV.Value1 = 'LA9'
      LEFT JOIN dbo.XUserStundenansatz USA10 WITH(READUNCOMMITTED) ON USA10.UserID = @UserID AND USA10.Lohnart10 > 0 AND LOV.Value1 = 'LA10'
      LEFT JOIN dbo.XUserStundenansatz USA11 WITH(READUNCOMMITTED) ON USA11.UserID = @UserID AND USA11.Lohnart11 > 0 AND LOV.Value1 = 'LA11'
      LEFT JOIN dbo.XUserStundenansatz USA12 WITH(READUNCOMMITTED) ON USA12.UserID = @UserID AND USA12.Lohnart12 > 0 AND LOV.Value1 = 'LA12'
      LEFT JOIN dbo.XUserStundenansatz USA13 WITH(READUNCOMMITTED) ON USA13.UserID = @UserID AND USA13.Lohnart13 > 0 AND LOV.Value1 = 'LA13'
      LEFT JOIN dbo.XUserStundenansatz USA14 WITH(READUNCOMMITTED) ON USA14.UserID = @UserID AND USA14.Lohnart14 > 0 AND LOV.Value1 = 'LA14'
      LEFT JOIN dbo.XUserStundenansatz USA15 WITH(READUNCOMMITTED) ON USA15.UserID = @UserID AND USA15.Lohnart15 > 0 AND LOV.Value1 = 'LA15'
      LEFT JOIN dbo.XUserStundenansatz USA16 WITH(READUNCOMMITTED) ON USA16.UserID = @UserID AND USA16.Lohnart16 > 0 AND LOV.Value1 = 'LA16'
      LEFT JOIN dbo.XUserStundenansatz USA17 WITH(READUNCOMMITTED) ON USA17.UserID = @UserID AND USA17.Lohnart17 > 0 AND LOV.Value1 = 'LA17'
      LEFT JOIN dbo.XUserStundenansatz USA18 WITH(READUNCOMMITTED) ON USA18.UserID = @UserID AND USA18.Lohnart18 > 0 AND LOV.Value1 = 'LA18'
      LEFT JOIN dbo.XUserStundenansatz USA19 WITH(READUNCOMMITTED) ON USA19.UserID = @UserID AND USA19.Lohnart19 > 0 AND LOV.Value1 = 'LA19'
      LEFT JOIN dbo.XUserStundenansatz USA20 WITH(READUNCOMMITTED) ON USA20.UserID = @UserID AND USA20.Lohnart20 > 0 AND LOV.Value1 = 'LA20'
    WHERE LOV.LOVName = 'BDELohnart'
      AND COALESCE(USA1.Lohnart1, USA2.Lohnart2, USA3.Lohnart3, USA4.Lohnart4, USA5.Lohnart5,
                   USA6.Lohnart6, USA7.Lohnart7, USA8.Lohnart8, USA9.Lohnart9, USA10.Lohnart10,
                   USA11.Lohnart11, USA12.Lohnart12, USA13.Lohnart13, USA14.Lohnart14, USA15.Lohnart15,
                   USA16.Lohnart16, USA17.Lohnart17, USA18.Lohnart18, USA19.Lohnart19, USA20.Lohnart20) > 0;

  -----------------------------------------------------------------------------
  -- Dummy-Eintrag für MA ohne Lohnanspruch
  -----------------------------------------------------------------------------
  IF ((SELECT COUNT(1) FROM @Result) = 0 AND @LohnType = 2 AND @KeinExport = 1)
  BEGIN
    INSERT INTO @Result
      SELECT LOV.Code,
             dbo.fnGetLOVMLText(LOV.LOVName, LOV.Code, @LanguageCode)
      FROM dbo.XLOVCode LOV WITH (READUNCOMMITTED)
      WHERE LOVName = 'BDELohnart'
        AND Value1 = 'LA1';
  END;

  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN;
END;
GO