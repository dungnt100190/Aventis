SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spABAUpdateVerbucht
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Stored Procedures/BDE/spABAUpdateVerbucht.sql $
  $Author: Cjaeggi $
  $Modtime: 1.09.09 13:57 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this sp to udpate Verbucht in BDELeistung for users with Stundenlohn, 
           to prevent inserting more data into an exported month
    @UserLogonName:  The id of the user who calls the sp
    @MandatenNr:     The MandatenNr which users belong to
    @DatumVon:       Starting date to check if entries exists for user
    @DatumBis:       Ending date to check if entries exists for user
    @Schnittstelle:  The type of the call: 'stunden'=Stundenlohn (default), 'leistung'=Leistungsdaten
    @RemoveVerbucht: 0=set current date, 1=remove date and set NULL in BDELeistung.Verbucht
  -
  RETURNS: One column-resultset with columnname = [Done] where > -1 = ok, < 0 = nok
  -
  TEST:    EXEC spABAUpdateVerbucht 'cjaeggi', 1, '2008-01-01', '2008-01-31', 'stunden', 0
           EXEC spABAUpdateVerbucht 'cjaeggi', 1, '2008-01-01', '2008-01-31', 'leistung', 0
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Stored Procedures/BDE/spABAUpdateVerbucht.sql $
 * 
 * 3     1.09.09 13:58 Cjaeggi
 * Changed format and spaces
 * 
 * 2     27.08.09 13:00 Spsota
 * #4835 ZLE Performance verbesserungen
 * 
 * 1     3.09.08 17:54 Aklopfenstein
 * 
 * 1     3.09.08 11:13 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE PROCEDURE dbo.spABAUpdateVerbucht
(
  @UserLogonName VARCHAR(200),
  @MandantenNr INT,
  @DatumVon DATETIME,
  @DatumBis DATETIME,
  @Schnittstelle VARCHAR(10),
  @RemoveVerbucht BIT = 0
)
AS
BEGIN
  -------------------------------------------------------------------------------
  -- Validate
  -------------------------------------------------------------------------------
  IF (@UserLogonName IS NULL OR @MandantenNr IS NULL OR @DatumVon IS NULL OR @DatumBis IS NULL OR @Schnittstelle IS NULL)
  BEGIN
    -- invalid values
    SELECT [Done] = -1
    RETURN
  END
  
  -------------------------------------------------------------------------------
  -- Vars
  -------------------------------------------------------------------------------
  DECLARE @AffectedRows INT
  
  -------------------------------------------------------------------------------
  -- Deadlock priority as high
  -------------------------------------------------------------------------------
  SET DEADLOCK_PRIORITY HIGH
  
  -------------------------------------------------------------------------------
  -- New history version (!)
  -------------------------------------------------------------------------------
  INSERT INTO dbo.HistoryVersion (AppUser) VALUES (@UserLogonName)
  
  -------------------------------------------------------------------------------
  -- Update Verbucht
  -------------------------------------------------------------------------------
  IF (@Schnittstelle = 'leistung')
  BEGIN
    -----------------------------------------------------------------------------
    -- Leistungsdaten-Schnittstelle
    -----------------------------------------------------------------------------
    UPDATE dbo.BDELeistung
    SET VerbuchtLD = CASE WHEN @RemoveVerbucht = 1 THEN NULL
                          ELSE GETDATE()
                     END
    WHERE Datum BETWEEN @DatumVon AND @DatumBis AND         -- filter date range
          Verbucht IS NOT NULL AND                          -- default verbucht has to be set
          (@RemoveVerbucht = 1 OR VerbuchtLD IS NULL) AND   -- only those which are not yet verbucht on leistungsdaten
          HistMandantNr = @MandantenNr                      -- filter MandantenNr
    
    -- count rows we inserted
    SET @AffectedRows = @@ROWCOUNT
  END
  ELSE IF (@Schnittstelle = 'stunden')
  BEGIN
    -----------------------------------------------------------------------------
    -- Stundenlohn-Schnittstelle (includes Leistungsdaten-Schnittstelle)
    -----------------------------------------------------------------------------
    UPDATE dbo.BDELeistung
    SET Verbucht     = CASE WHEN @RemoveVerbucht = 1 THEN NULL
                            ELSE GETDATE()
                       END,
        VerbuchtLD   = NULL                               -- when calling stundenlohn-schnittstelle for this month, VerbuchtLD always has to be NULL (set: is always before LD; remove: invalidates LD)
    WHERE Datum BETWEEN @DatumVon AND @DatumBis AND       -- filter date range
          (@RemoveVerbucht = 1 OR Verbucht IS NULL) AND   -- only those which are not yet verbucht
          HistMandantNr = @MandantenNr                    -- filter MandantenNr
    
    -- count rows we inserted
    SET @AffectedRows = @@ROWCOUNT
  END
  
  -------------------------------------------------------------------------------
  -- Deadlock priority as normal (default)
  -------------------------------------------------------------------------------
  SET DEADLOCK_PRIORITY NORMAL
  
  -------------------------------------------------------------------------------
  -- Done, return inserted rows (ok: >= 0)
  -------------------------------------------------------------------------------
  SELECT [Done] = ISNULL(@AffectedRows, -1)
END
GO