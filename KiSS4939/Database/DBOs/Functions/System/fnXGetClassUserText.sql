SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnXGetClassUserText;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/System/fnXGetClassUserText.sql $
  $Author: Cjaeggi $
  $Modtime: 5.02.10 7:34 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Creates the user text as "MODUL - MaskName (ClassName)"
    @ClassName:    The name of the class within table XClass
    @LanguageCode: The language code to use for multilanguage content (not in use for the moment)
  -
  RETURNS: User text that can be shown to user for given class
  -
  TEST:    SELECT dbo.fnXGetClassUserText('FrmMain', 1);
=================================================================================================
  WARNING: This object is shared in Visual SourceSafe, beware of changes!
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/System/fnXGetClassUserText.sql $
 * 
 * 3     5.02.10 7:34 Cjaeggi
 * 
 * 2     4.02.10 15:10 Cjaeggi
 * #5631: Added warning
 * 
 * 1     4.02.10 14:40 Cjaeggi
 * #5631: Integrate favorites
=================================================================================================*/

CREATE FUNCTION dbo.fnXGetClassUserText
(
  @ClassName VARCHAR(100),
  @LanguageCode INT
)
RETURNS VARCHAR(765)   -- calculated amount of chars!
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@ClassName IS NULL)
  BEGIN
    -- no classname gives no usertext
    RETURN NULL;
  END;
  
  -----------------------------------------------------------------------------
  -- init vars
  -----------------------------------------------------------------------------  
  DECLARE @UserText VARCHAR(765);   -- calculated amount of chars!
  SET @LanguageCode = ISNULL(@LanguageCode, -1);
  
  -----------------------------------------------------------------------------
  -- init vars
  -----------------------------------------------------------------------------
  SELECT @UserText = ISNULL(MDL.ShortName + ' - ', '') + ISNULL(CLS.MaskName, '') + ISNULL(' (' + CLS.ClassName + ')', '')
  FROM dbo.XClass        CLS WITH (READUNCOMMITTED)
    LEFT JOIN dbo.XModul MDL WITH (READUNCOMMITTED) ON MDL.ModulID = CLS.ModulID
  WHERE CLS.ClassName = @ClassName;
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN @UserText;
END;
GO
