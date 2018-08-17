SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnGetBaName
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Functions/fnGetBaName.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 10:28 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Functions/fnGetBaName.sql $
 * 
 * 3     11.12.09 11:01 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:08 Rstahel
 * Abgleich der Functions aus KISS4_MASTER_ZH
=================================================================================================*/

-- =============================================
-- Author:		R. Hesterberg
-- Create date: 23.08.2007
-- Description:	Suchen des Namens anhand des Keys:
--   - negativ bei Mitarbeiter
--   - 0...500'000 bei Personen
--   - 500'000... bei Institutionen
-- =============================================
CREATE FUNCTION dbo.fnGetBaName(@Key int)
RETURNS varchar(200)
AS
BEGIN
  -- Declare the return variable here
  DECLARE @Name varchar(200)
  SET @Name = ''

  IF (@Key<0) BEGIN
    -- Mitarbeiter:
    SELECT TOP 1 @Name = LastName + IsNull(' ' + FirstName, '')
    FROM dbo.XUser WITH (READUNCOMMITTED)
    WHERE UserID = -@Key
  END ELSE
  IF (@Key BETWEEN 0 AND 499999) BEGIN
    -- Personen:
    SELECT TOP 1 @Name = Name + IsNull(' ' + Vorname, '')
    FROM dbo.BaPerson WITH (READUNCOMMITTED)
    WHERE BaPersonID = @Key
  END ELSE
  IF (@Key >= 5000000) BEGIN
    -- Institutionen:
    SELECT TOP 1 @Name = Name
    FROM dbo.BaInstitution WITH (READUNCOMMITTED)
    WHERE BaInstitutionID = @Key
  END

  -- Return the result of the function
  RETURN @Name

END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
