SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spFaJournal_Insert
GO
/*===============================================================================================
  $Revision: 4$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: FaJournal einfügen
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .

=================================================================================================*/

CREATE PROCEDURE dbo.spFaJournal_Insert
  -- @FaFallID
  @FaFallID INT,
  -- @FaLeistungID
  @FaLeistungID INT,
  -- @BaPersonID
  @BaPersonID INT,
  -- UserID
  @UserID INT,
  -- Modus
  -- 1 = Einfügen
  -- 2 = Abschliesssen
  -- 3 = Wiedereröffnen
  @Modus INT,
  -- Buchungstext
  @Text varchar(200)
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON

  IF (@FaFallID IS NULL AND @FaLeistungID IS NOT NULL)
  BEGIN
    -- FaFallID von FaLeistung holen
    SELECT @FaFallID = LEI.FaFallID
    FROM dbo.FaLeistung LEI WITH(READUNCOMMITTED)
    WHERE LEI.FaLeistungID = @FaLeistungID
  END

  IF (@FaFallID IS NULL AND @BaPersonID IS NOT NULL)
  BEGIN
    -- FaFallID über BaPersonID holen
    SELECT TOP 1 @FaFallID = FAL.FaFallID
    FROM dbo.FaFall FAL WITH(READUNCOMMITTED)
    WHERE FAL.BaPersonID = @BaPersonID
    ORDER BY FAL.DatumBis, FAL.DatumVon DESC
  END

  IF (@BaPersonID IS NULL AND @FaLeistungID IS NOT NULL)
  BEGIN
    -- BaPersonID über FaLeistung holen
    SELECT TOP 1 @BaPersonID = L.BaPersonID
    FROM dbo.FaLeistung L WITH(READUNCOMMITTED)
    WHERE L.FaLeistungID = @FaLeistungID
  END

  IF (@BaPersonID IS NULL AND @FaFallID IS NOT NULL)
  BEGIN
    -- BaPersonID über FaFallID holen
    SELECT TOP 1 @BaPersonID = F.BaPersonID
    FROM dbo.FaFall F WITH(READUNCOMMITTED)
    WHERE F.FaFallID = @FaFallID
  END

  IF (@BaPersonID IS NOT NULL AND @FaFallID IS NULL AND NOT EXISTS (
    SELECT TOP 1 FaFallID FROM dbo.FaFall WITH(READUNCOMMITTED)
    WHERE BaPersonID = @BaPersonID)
  )
  BEGIN
    -- Wenn kein Fall existiert, dann soll nichts eingefügt werden 
    RETURN -2
  END


  -- Kontrolle der Parameter
  -- -----------------------
  IF @FaFallID IS NULL BEGIN
    RAISERROR ('Der Aufruf-Parameter @FaFallID ist null!', 18, 1)
    RETURN -1
  END
  IF @BaPersonID IS NULL BEGIN
    RAISERROR ('Der Aufruf-Parameter @BaPersonID ist null!', 18, 1)
    RETURN -1
  END
  IF @UserID IS NULL BEGIN
    RAISERROR ('Der Aufruf-Parameter @UserID ist null!', 18, 1)
    RETURN -1
  END
  IF @Modus NOT IN (0,1,2,3) BEGIN
    RAISERROR ('Der Aufruf-Parameter @Modus hat nicht den Wert 0, 1, 2 oder 3!', 18, 1)
    RETURN -1
  END
  IF @Modus = 0 AND @Text IS NULL BEGIN
    RAISERROR ('Beim Modus = 0 darf der Text nicht leer sein!', 18, 1)
    RETURN -1
  END


  DECLARE
    @OrgUnitID INT,
    @OrgName varchar(200),
    @JournalModusText varchar(200),
    @Message varchar(500)

  -- Angaben zur OrgUnit holen
  SELECT TOP 1
    @OrgUnitID = O2U.OrgUnitID,
    @OrgName = ORG.ItemName
  FROM dbo.XOrgUnit_User O2U WITH(READUNCOMMITTED)
  LEFT JOIN dbo.XOrgUnit ORG WITH(READUNCOMMITTED) ON ORG.OrgUnitID = O2U.OrgUnitID
  WHERE O2U.UserID = @UserID
    AND O2U.OrgUnitMemberCode = 2  -- Mitglied

  -- Text anhand @Modus setzen
  SET @JournalModusText = CASE @Modus
    WHEN 0 THEN @Text
    WHEN 1 THEN 'Eröffnung'
    WHEN 2 THEN 'Abschluss'
    WHEN 3 THEN 'Wiedereröffnung'
    ELSE '[unbekannter Modus]'
  END

  BEGIN TRY
    IF @FaLeistungID IS NULL
    BEGIN
      -- Journal für Änderungen an FaFall
      -- --------------------------------
      INSERT dbo.FaJournal (
        FaFallID, BaPersonID, BaPersonName, BaPersonVorname,
        UserID, UserLastName, UserFirstName, UserLogonName,
        OrgUnitID, OrgUnitItemName, Text)
      SELECT
        @FaFallID, @BaPersonID, P.Name, P.Vorname,
        @UserID, U.LastName, U.FirstName, U.LogonName,
        @OrgUnitID, @OrgName, @JournalModusText
      FROM dbo.FaFall F WITH(READUNCOMMITTED)
      LEFT JOIN dbo.BaPerson P WITH(READUNCOMMITTED) ON P.BaPersonID = @BaPersonID
      LEFT JOIN dbo.XUser U WITH(READUNCOMMITTED) ON U.UserID = @UserID
      WHERE F.FaFallID = @FaFallID
    END ELSE
    BEGIN
      -- Journal für Änderungen an FaLeistung
      -- ------------------------------------
      INSERT dbo.FaJournal (
        FaFallID, FaLeistungID, BaPersonID, BaPersonName, BaPersonVorname,
        UserID, UserLastName, UserFirstName, UserLogonName,
        OrgUnitID, OrgUnitItemName, Text)
      SELECT
        @FaFallID, @FaLeistungID, @BaPersonID, P.Name, P.Vorname,
        @UserID, U.LastName, U.FirstName, U.LogonName,
        @OrgUnitID, @OrgName,
        @JournalModusText + ' '
          + IsNull(dbo.fnLOVText('FaProzess', L.FaProzessCode), '[unbekannte Leistung]')
          + IsNull(CASE
            WHEN @Modus = 2 THEN '(Abschlussgrund ' + IsNull(dbo.fnLOVText('AbschlussGrund', L.AbschlussGrundCode), '[unbekannter Abschlussgrund]') + ')'
            ELSE NULL
          END, '')
      FROM dbo.FaLeistung L WITH(READUNCOMMITTED)
      LEFT JOIN dbo.FaFall F WITH(READUNCOMMITTED) ON F.FaFallID = L.FaFallID
      LEFT JOIN dbo.BaPerson P WITH(READUNCOMMITTED) ON P.BaPersonID = @BaPersonID
      LEFT JOIN dbo.XUser U WITH(READUNCOMMITTED) ON U.UserID = @UserID
      WHERE L.FaLeistungID = @FaLeistungID
    END
  END TRY

  BEGIN CATCH
    SET @Message = ERROR_MESSAGE()
    RAISERROR(@Message,18,1)
    RETURN -1
  END CATCH

  -- Neue ID FaLeistung zurückgeben
  -- ------------------------------
  RETURN IsNull(SCOPE_IDENTITY(), 0)
END
