SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spSstIKAuszugGeneriereAutomatischeAnforderungen
GO
/*===============================================================================================
  $Archive: /database/kiss4_master_zh/stored procedures/spSstIKAuszugGeneriereAutomatischeAnforderungen.sql $
  $Author: Rstahel $
  $Modtime: 3.05.10 14:47 $
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  This method ist intendend to be called periodically (e.g. each night once) to automatically create the necessary 
  request for SVA-IK-Auszüge. 
  Particularely 2 years and 5 years after the first finanzplan started, an IK-Auszug will be requested 
  automatically by this stored procedure
=================================================================================================
  $Log: /database/kiss4_master_zh/stored procedures/spSstIKAuszugGeneriereAutomatischeAnforderungen.sql $
 * 
 * 4     3.05.10 14:47 Rstahel
 * Fehlende DBOs in DBO-Solution zugefügt
 * 
 * 2     27.04.10 18:02 Rstahel
 * #5820: Checkin work in progress
 * 
 * 1     23.04.10 10:09 Rstahel
=================================================================================================*/
CREATE PROCEDURE dbo.spSstIKAuszugGeneriereAutomatischeAnforderungen
AS 
BEGIN
  DECLARE @MonthSinceFinanzplanBewilligung int;
  DECLARE @AfterXMonthFor2YearCheck int;
  DECLARE @AfterXMonthFor5YearCheck int;

  SELECT @MonthSinceFinanzplanBewilligung = ValueInt
  FROM XConfig
  WHERE KeyPath = 'System\IKAuszuege\AutomatischerAuszugXMonateNachErsterFinanzplanBewilligung';

  SELECT @AfterXMonthFor2YearCheck = ValueInt
  FROM XConfig
  WHERE KeyPath = 'System\IKAuszuege\2JahresKontrolleNachXMonaten';

  SELECT @AfterXMonthFor5YearCheck = ValueInt
  FROM XConfig
  WHERE KeyPath = 'System\IKAuszuege\5JahresKontrolleNachXMonaten';

  EXEC spSstIKAuszugGeneriereAutomatischeAnforderungenNachXMonaten @MonthSinceFinanzplanBewilligung, 1;
  EXEC spSstIKAuszugGeneriereAutomatischeAnforderungenNachXMonaten @AfterXMonthFor2YearCheck, 2;
  EXEC spSstIKAuszugGeneriereAutomatischeAnforderungenNachXMonaten @AfterXMonthFor5YearCheck, 3;
END
GO

