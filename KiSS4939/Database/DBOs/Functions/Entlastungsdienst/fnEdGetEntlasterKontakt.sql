SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnEdGetEntlasterKontakt;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Entlastungsdienst/fnEdGetEntlasterKontakt.sql $
  $Author: Cjaeggi $
  $Modtime: 13.01.10 11:22 $
  $Revision: 7 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get contact information about Entlaster-user
    @UserID:  The user of which the contact information has to be retrieved
    @IncludePhone: 1=include phone information, 0=do not show phone information
    @IncludeEmail: 1=include email information, 0=do not show email information
    @LanguageCode: The language to use for the details
  -
  RETURNS: The contact information for the given Entlaster-user or '' if invalid or empty
  -
  TEST:    SELECT [dbo].[fnEdGetEntlasterKontakt](565, 1, 1, 1)
           SELECT [dbo].[fnEdGetEntlasterKontakt](565, 0, 1, 1)
           SELECT [dbo].[fnEdGetEntlasterKontakt](565, 1, 0, 1)
           SELECT [dbo].[fnEdGetEntlasterKontakt](565, 0, 0, 1)
           SELECT [dbo].[fnEdGetEntlasterKontakt](2, 1, 1, 1)
           SELECT [dbo].[fnEdGetEntlasterKontakt](2, 0, 1, 1)
           SELECT [dbo].[fnEdGetEntlasterKontakt](2, 1, 0, 1)
           SELECT [dbo].[fnEdGetEntlasterKontakt](2, 0, 0, 1)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Entlastungsdienst/fnEdGetEntlasterKontakt.sql $
 * 7	 05.03.12 13:38 Psalajan
 * #5817: changed to USR.PhoneMobile from Phone number in EdMitarbeiter
 *
 * 6     13.01.10 11:28 Cjaeggi
 * #672: Replaced fn GetPersonTitle
 * 
 * 5     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 4     30.01.09 13:31 Cjaeggi
 * Added mobile number to filter and fixed bugs
 * 
 * 3     11.12.08 15:06 Cjaeggi
 * Changed output
 * 
 * 2     10.12.08 12:08 Cjaeggi
 * 
 * 1     10.12.08 11:11 Cjaeggi
 * First version
=================================================================================================*/

CREATE FUNCTION dbo.fnEdGetEntlasterKontakt
(
  @UserID INT,
  @IncludePhone BIT,
  @IncludeEmail BIT,
  @LanguageCode INT
)
RETURNS VARCHAR(255)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- if not date is passed, invalid value
  IF (@UserID IS NULL OR @LanguageCode IS NULL)
  BEGIN
    RETURN ''
  END
  
  -- setup bits
  SET @IncludePhone = ISNULL(@IncludePhone, 0)
  SET @IncludeEmail = ISNULL(@IncludeEmail, 0)  
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @ReturnValue VARCHAR(255)
  SET @ReturnValue = ''
  
  -----------------------------------------------------------------------------
  -- get data
  -----------------------------------------------------------------------------
  -- check if need to add phone
  IF (@IncludePhone = 1)
  BEGIN
    -- get data for phone (G > G(Interal) > P > M)
    SELECT @ReturnValue = COALESCE(USR.PhoneOffice + ' (' + dbo.fnXDbObjectMLMsg('dbGeneral', 'TelefonGeschaeft', @LanguageCode) + ')', 
                                   USR.PhoneIntern + ' (' + dbo.fnXDbObjectMLMsg('dbGeneral', 'TelefonGeschaeft', @LanguageCode) + ')', 
                                   USR.PhonePrivat + ' (' + dbo.fnXDbObjectMLMsg('dbGeneral', 'TelefonPrivat', @LanguageCode) + ')', 
                                   USR.PhoneMobile + ' (' + dbo.fnXDbObjectMLMsg('dbGeneral', 'TelefonMobil', @LanguageCode) + ')')
    FROM dbo.XUser USR WITH (READUNCOMMITTED)
    WHERE USR.UserID = @UserID
  END
  
  -- check if need to add email
  IF (@IncludeEmail = 1)
  BEGIN
    -- get data for email-address (check if @ReturnValue already contains data >> split by char)
    SELECT @ReturnValue = @ReturnValue + CASE WHEN ISNULL(@ReturnValue, '') <> '' THEN ISNULL('; ' + USR.EMail, '')
                                              ELSE USR.EMail
                                         END
    FROM dbo.XUser USR WITH (READUNCOMMITTED)
    WHERE USR.UserID = @UserID
  END
  
  -----------------------------------------------------------------------------
  -- check and return value
  ----------------------------------------------------------------------------- 
  RETURN ISNULL(@ReturnValue, '')
END
