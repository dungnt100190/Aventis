/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to print the content of table log.UserSession to the output.
=================================================================================================*/
-------------------------------------------------------------------------------
-- init vars and table
-------------------------------------------------------------------------------
DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @UserSessionID INT;
DECLARE @UserID INT;
DECLARE @LogonName VARCHAR(200);
DECLARE @LoginDatum DATETIME;
DECLARE @LogoutDatum DATETIME;
DECLARE @UserName VARCHAR(200);
DECLARE @UserDomainName VARCHAR(200);
DECLARE @MachineName VARCHAR(50);
DECLARE @ClientVersion VARCHAR(50);
DECLARE @WindowsVersion VARCHAR(50);
DECLARE @DotNetVersion VARCHAR(50);
DECLARE @AufloesungBreite INT;
DECLARE @AufloesungHoehe INT;
DECLARE @OfficeVersionWord VARCHAR(50);
DECLARE @OfficeVersionExcel VARCHAR(50);
DECLARE @OfficeVersionOutlook VARCHAR(50);
DECLARE @CultureInfo VARCHAR(50);
DECLARE @Creator VARCHAR(50);
DECLARE @Created DATETIME;
DECLARE @Modifier VARCHAR(50);
DECLARE @Modified DATETIME;
DECLARE @Delimiter VARCHAR(1);
SET @Delimiter = ';';

DECLARE @TempTable TABLE
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
  UserSessionID INT,
  UserID INT,
  LogonName VARCHAR(200),
  LoginDatum DATETIME,
  LogoutDatum DATETIME,
  UserName VARCHAR(200),
  UserDomainName VARCHAR(200),
  MachineName VARCHAR(50),
  ClientVersion VARCHAR(50),
  WindowsVersion VARCHAR(50),
  DotNetVersion VARCHAR(50),
  AufloesungBreite INT,
  AufloesungHoehe INT,
  OfficeVersionWord VARCHAR(50),
  OfficeVersionExcel VARCHAR(50),
  OfficeVersionOutlook VARCHAR(50),
  CultureInfo VARCHAR(50),
  Creator VARCHAR(50),
  Created DATETIME,
  Modifier VARCHAR(50),
  Modified DATETIME
);

-------------------------------------------------------------------------------
-- insert entries into temp table
-------------------------------------------------------------------------------

-- Filter : Beispiel : CurrentYear = 2015, dann nehmen wir von 1.1.14 'bis ohne' 1.1.16
DECLARE @dateBegin AS DATETIME,
        @dateEnd AS DATETIME;
        
SET @dateBegin = dbo.fnDateSerial(YEAR(GETDATE()) - 1,1,1);
SET @dateEnd = dbo.fnDateSerial(YEAR(GETDATE())+1,1,1); -- weil Datumbereich < 1.1.16 00:00:00

INSERT INTO @TempTable (UserSessionID, 
                        --UserID, 
                        LogonName, 
                        LoginDatum, 
                        LogoutDatum, 
                        --UserName, 
                        UserDomainName/*, 
                        MachineName, 
                        ClientVersion, 
                        WindowsVersion, 
                        DotNetVersion, 
                        AufloesungBreite, 
                        AufloesungHoehe, 
                        OfficeVersionWord, 
                        OfficeVersionExcel, 
                        OfficeVersionOutlook, 
                        CultureInfo, 
                        Creator, 
                        Created, 
                        Modifier, 
                        Modified*/
                        )
  SELECT  UserSessionID,
          --UserID,
          LogonName,
          LoginDatum,
          LogoutDatum,
          --UserName,
          UserDomainName--,
          --MachineName,
          --ClientVersion,
          --WindowsVersion,
          --DotNetVersion,
          --AufloesungBreite,
          --AufloesungHoehe,
          --OfficeVersionWord,
          --OfficeVersionExcel,
          --OfficeVersionOutlook,
          --CultureInfo,
          --Creator,
          --Created,
          --Modifier,
          --Modified
  FROM log.UserSession LUS WITH (READUNCOMMITTED)
  WHERE ISNULL(LogoutDatum,'99991231') >= @dateBegin
    AND LoginDatum < @dateEnd;

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

/*
-- DATUM Filter Testen
SELECT * 
FROM (--SELECT LoginDatum, LogoutDatum FROM log.UserSession UNION ALL
      SELECT LoginDatum = '2013-12-31 23:59:59', LogoutDatum = '2013-12-31 23:59:59' UNION ALL
      SELECT LoginDatum = '2013-12-31 23:59:59', LogoutDatum = '2014-01-01 00:00:00' UNION ALL
      SELECT LoginDatum = '2014-01-01 00:00:00', LogoutDatum = '2015-12-31 23:59:59' UNION ALL
      SELECT LoginDatum = '2014-01-01 00:00:00', LogoutDatum = '2016-01-01 00:00:00' UNION ALL
      SELECT LoginDatum = '2015-12-31 23:59:59', LogoutDatum = '2016-01-01 00:00:00' UNION ALL
      SELECT LoginDatum = '2016-01-01 00:00:00', LogoutDatum = '2016-01-01 00:00:00' UNION ALL

      SELECT LoginDatum = '2013-12-31 23:59:59', LogoutDatum = NULL UNION ALL
      SELECT LoginDatum = '2014-01-01 00:00:00', LogoutDatum = NULL UNION ALL
      SELECT LoginDatum = '2015-12-31 23:59:59', LogoutDatum = NULL UNION ALL
      SELECT LoginDatum = '2016-01-01 00:00:00', LogoutDatum = NULL      
      ) US
WHERE 1=1
  AND ISNULL(LogoutDatum,'99991231')  >= @dateBegin
  AND LoginDatum < @dateEnd

*/


-- Header
PRINT ('TODO: Start copy here');
PRINT ('UserSessionID' + @Delimiter + 
       --'UserID' + @Delimiter + 
       'LogonName' + @Delimiter + 
       'LoginDatum' + @Delimiter + 
       'LogoutDatum' + @Delimiter + 
       --'UserName' + @Delimiter + 
       'UserDomainName' + @Delimiter -- + 
       --'MachineName' + @Delimiter + 
       --'ClientVersion' + @Delimiter + 
       --'WindowsVersion' + @Delimiter + 
       --'DotNetVersion' + @Delimiter + 
       --'AufloesungBreite' + @Delimiter + 
       --'AufloesungHoehe' + @Delimiter + 
       --'OfficeVersionWord' + @Delimiter + 
       --'OfficeVersionExcel' + @Delimiter + 
       --'OfficeVersionOutlook' + @Delimiter + 
       --'CultureInfo' + @Delimiter + 
       --'Creator' + @Delimiter + 
       --'Created' + @Delimiter + 
       --'Modifier' + @Delimiter + 
       /*'Modified'*/);

-------------------------------------------------------------------------------
-- loop all entries
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @UserSessionID        = TMP.UserSessionID,
         --@UserID               = TMP.UserID,
         @LogonName            = TMP.LogonName,
         @LoginDatum           = TMP.LoginDatum,
         @LogoutDatum          = TMP.LogoutDatum,
         --@UserName             = TMP.UserName,
         @UserDomainName       = TMP.UserDomainName--,
         --@MachineName          = TMP.MachineName,
         --@ClientVersion        = TMP.ClientVersion,
         --@WindowsVersion       = TMP.WindowsVersion,
         --@DotNetVersion        = TMP.DotNetVersion,
         --@AufloesungBreite     = TMP.AufloesungBreite,
         --@AufloesungHoehe      = TMP.AufloesungHoehe,
         --@OfficeVersionWord    = TMP.OfficeVersionWord,
         --@OfficeVersionExcel   = TMP.OfficeVersionExcel,
         --@OfficeVersionOutlook = TMP.OfficeVersionOutlook,
         --@CultureInfo          = TMP.CultureInfo,
         --@Creator              = TMP.Creator,
         --@Created              = TMP.Created,
         --@Modifier             = TMP.Modifier,
         --@Modified             = TMP.Modified
  FROM @TempTable TMP
  WHERE TMP.ID = @EntriesIterator;
  
  -----------------------------------------------------------------------------
  -- do something
  -----------------------------------------------------------------------------
  PRINT (CONVERT(VARCHAR(MAX), @UserSessionID) + @Delimiter + 
         --CONVERT(VARCHAR(MAX), @UserID) + @Delimiter + 
         '"' + @LogonName + '"' + @Delimiter + 
         CONVERT(VARCHAR(MAX), @LoginDatum, 104) + ' ' + CONVERT(VARCHAR(MAX), @LoginDatum, 114) + @Delimiter + 
         ISNULL(CONVERT(VARCHAR(MAX), @LogoutDatum, 104) + ' ' + CONVERT(VARCHAR(MAX), @LogoutDatum, 114), 'NULL') + @Delimiter + 
         --ISNULL('"' + @UserName + '"', 'NULL') + @Delimiter + 
         ISNULL('"' + @UserDomainName + '"', 'NULL') + @Delimiter --+ 
         --ISNULL('"' + @MachineName + '"', 'NULL') + @Delimiter + 
         --ISNULL('"' + @ClientVersion + '"', 'NULL') + @Delimiter + 
         --ISNULL('"' + @WindowsVersion + '"', 'NULL') + @Delimiter + 
         --ISNULL('"' + @DotNetVersion + '"', 'NULL') + @Delimiter + 
         --ISNULL(CONVERT(VARCHAR(MAX), @AufloesungBreite), 'NULL') + @Delimiter + 
         --ISNULL(CONVERT(VARCHAR(MAX), @AufloesungHoehe), 'NULL') + @Delimiter + 
         --ISNULL('"' + @OfficeVersionWord + '"', 'NULL') + @Delimiter + 
         --ISNULL('"' + @OfficeVersionExcel + '"', 'NULL') + @Delimiter + 
         --ISNULL('"' + @OfficeVersionOutlook + '"', 'NULL') + @Delimiter + 
         --ISNULL('"' + @CultureInfo + '"', 'NULL') + @Delimiter + 
         --'"' + @Creator + '"' + @Delimiter + 
         --CONVERT(VARCHAR(MAX), @Created, 104) + ' ' + CONVERT(VARCHAR(MAX), @Created, 114) + @Delimiter +
         --'"' + @Modifier + '"' + @Delimiter + 
         --CONVERT(VARCHAR(MAX), @Modified, 104) + ' ' + CONVERT(VARCHAR(MAX), @Modified, 114)
         );
  -----------------------------------------------------------------------------
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;

PRINT ('TODO: Stop copy here');
