/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to evaluate the table XLog for user-logins and compare with licenses
=================================================================================================*/

-------------------------------------------------------------------------------
-- Setup conditions
-------------------------------------------------------------------------------
-- declare vars
DECLARE @Year INT;
DECLARE @WorkdaysPerYear INT;
DECLARE @LogMessage VARCHAR(255);

-- Vars für Ausgabe
DECLARE @message VARCHAR(8000); 
DECLARE @Jahr VARCHAR(50), @Monat VARCHAR(50), @AnzahlLogins VARCHAR(50), 
@AnzahlUser VARCHAR(50), @LoginsProArbeitsTag VARCHAR(50), @OE VARCHAR(50)

DECLARE @ExcludedUsers TABLE
(
  UserID INT NOT NULL PRIMARY KEY
);

-- set vars
SET @Year = YEAR(GETDATE());
SET @WorkdaysPerYear = 220;
SET @LogMessage = 'User logged in successfully';

-- setup excluded users such as biag-admins or other criteria
INSERT INTO @ExcludedUsers (UserID)
  SELECT UserID = CONVERT(INT, FCN.SplitValue)
  FROM dbo.fnSplitStringToValues('-1', ',', 1) FCN
  
  UNION 
  
  SELECT USR.UserID
  FROM dbo.XUser USR
  WHERE USR.IsUserBiagAdmin = 1;

-------------------------------------------------------------------------------
-- Basis-Join: Liste der Login's
-------------------------------------------------------------------------------
/*
SELECT Created = XLG.Created, 
       FirstName = USR.FirstName, 
       LastName = USR.LastName, 
       OrgUnit = USR.OrgUnit
FROM dbo.XLog XLG
  INNER JOIN dbo.vwUser USR ON USR.UserID = XLG.ReferenceID
WHERE XLG.[Message] = @LogMessage
  AND USR.UserID NOT IN (SELECT TMP.UserID
                         FROM @ExcludedUsers TMP);
--*/

-------------------------------------------------------------------------------
-- Anzahl eingeloggte, verschiedene User im Jahr
-------------------------------------------------------------------------------
--/*
DECLARE db_cursor CURSOR FOR 
SELECT Jahr = YEAR(XLG.Created), 
       AnzahlLogins = COUNT(1), 
       AnzahlUser = COUNT(DISTINCT USR.UserID),
       LoginsProArbeitsTag = CONVERT(FLOAT(2), CASE
                                                 WHEN COUNT(1) < 1 THEN 0
                                                 ELSE ROUND(COUNT(1) / CONVERT(FLOAT, @WorkdaysPerYear), 2)
                                               END)
FROM dbo.XLog XLG
  INNER JOIN dbo.vwUser USR ON USR.UserID = XLG.ReferenceID
WHERE XLG.[Message] = @LogMessage
  AND YEAR(XLG.Created) = @Year
  AND USR.UserID NOT IN (SELECT TMP.UserID
                         FROM @ExcludedUsers TMP)
GROUP BY YEAR(XLG.Created)
ORDER BY Jahr
;

OPEN db_cursor 
FETCH NEXT FROM db_cursor 
INTO @Jahr, @AnzahlLogins, @AnzahlUser, @LoginsProArbeitsTag
PRINT 'Anzahl eingeloggte, verschiedene User im Jahr: '
WHILE @@FETCH_STATUS = 0 
BEGIN 
       SELECT @message = 'Jahr: ' + @Jahr + ' AnzahlLogins: ' + @AnzahlLogins + ' AnzahlUser: ' +@AnzahlUser + ' LoginsProArbeitstag : ' + @LoginsProArbeitsTag
       PRINT @message
       FETCH NEXT FROM db_cursor INTO @Jahr, @AnzahlLogins, @AnzahlUser, @LoginsProArbeitsTag
END 
CLOSE db_cursor 
DEALLOCATE db_cursor 



--*/

-------------------------------------------------------------------------------
-- Anzahl eingeloggte, verschiedene User pro Monat
-------------------------------------------------------------------------------
DECLARE db_cursor CURSOR FOR 
--/*
SELECT Jahr = YEAR(XLG.Created), 
       Monat = MONTH(XLG.Created), 
       AnzahlLogins = COUNT(1), 
       AnzahlUser = COUNT(DISTINCT USR.UserID)
FROM dbo.XLog XLG
  INNER JOIN dbo.vwUser USR ON USR.UserID = XLG.ReferenceID
WHERE XLG.[Message] = @LogMessage
  AND USR.UserID NOT IN (SELECT TMP.UserID
                         FROM @ExcludedUsers TMP)
GROUP BY YEAR(XLG.Created), MONTH(XLG.Created)
ORDER BY Jahr, Monat;
--*/

OPEN db_cursor 
FETCH NEXT FROM db_cursor 
INTO @Jahr, @Monat, @AnzahlLogins, @AnzahlUser
PRINT CHAR(13) + 'Anzahl eingeloggte, verschiedene User pro Monat: '
WHILE @@FETCH_STATUS = 0 
BEGIN 
       SELECT @message = 'Jahr: ' + @Jahr + ' Monat: ' + @Monat + ' AnzahlLogins: ' + @AnzahlLogins + ' AnzahlUser: ' +@AnzahlUser


       PRINT @message
       FETCH NEXT FROM db_cursor INTO @Jahr, @Monat, @AnzahlLogins, @AnzahlUser 
END 
CLOSE db_cursor 
DEALLOCATE db_cursor 


-------------------------------------------------------------------------------
-- Anzahl eingeloggte, verschiedene user pro OE im Jahr
-------------------------------------------------------------------------------
--/*
DECLARE db_cursor CURSOR FOR 

SELECT Jahr = YEAR(XLG.Created), 
       OE = USR.OrgEinheitName, 
       AnzahlUser = COUNT(DISTINCT USR.UserID)
FROM dbo.XLog XLG
  INNER JOIN dbo.vwUser USR ON USR.UserID = XLG.ReferenceID
WHERE XLG.[Message] = @LogMessage
  AND YEAR(XLG.Created) = @Year
  AND USR.UserID NOT IN (SELECT TMP.UserID
                         FROM @ExcludedUsers TMP)
GROUP BY YEAR(XLG.Created), USR.OrgEinheitName
ORDER BY Jahr, OE
--*/
OPEN db_cursor 
FETCH NEXT FROM db_cursor 
INTO @Jahr, @OE, @AnzahlUser
PRINT CHAR(13) + 'Anzahl eingeloggte, verschiedene user pro OE im Jahr: '

WHILE @@FETCH_STATUS = 0 
BEGIN 
       SELECT @message = 'Jahr: ' + @Jahr + ' OE: ' + @OE + ' AnzahlUser: ' +@AnzahlUser
       PRINT @message
       FETCH NEXT FROM db_cursor INTO @Jahr, @OE, @AnzahlUser
END 

CLOSE db_cursor 
DEALLOCATE db_cursor 
-------------------------------------------------------------------------------
-- Userliste, die im Jahr mindestens einmal eingeloggt waren
-------------------------------------------------------------------------------
/*
SELECT Jahr = YEAR(XLG.Created), 
       OE = USR.OrgEinheitName, 
       --
       UserID = USR.UserID, 
       Nachname = USR.LastName, 
       Vorname = USR.Firstname, 
       LogonName = LogonName,
       --
       AnzLogins = COUNT(1)
FROM dbo.XLog XLG
  INNER JOIN dbo.vwUser USR ON USR.UserID = XLG.ReferenceID
WHERE XLG.[Message] = @LogMessage
  AND YEAR(XLG.Created) = @Year
  AND USR.UserID NOT IN (SELECT TMP.UserID
                         FROM @ExcludedUsers TMP)
GROUP BY YEAR(XLG.Created), USR.OrgEinheitName, USR.Firstname, USR.LastName, USR.UserID, USR.LogonName
ORDER BY Jahr, OE, Nachname, Vorname
--*/