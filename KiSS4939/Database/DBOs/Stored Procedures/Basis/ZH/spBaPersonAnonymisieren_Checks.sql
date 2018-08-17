SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spBaPersonAnonymisieren_Checks
GO
/*===============================================================================================
  $Revision: 4$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .

=================================================================================================*/
-- =================================================================================================
-- Author:		sozheo
-- Create date: 14.12.2007
-- Description:	Checks, bevor das Anonymisieren einer Person gemacht werden darf
-- Test:        EXEC dbo.spBaPersonAnonymisieren_Checks 1234
-- =================================================================================================
-- History:
-- 15.12.2007 : sozheo : Neu
-- =================================================================================================

CREATE PROCEDURE [dbo].[spBaPersonAnonymisieren_Checks](
  @BaPersonID int
) AS
BEGIN
  DECLARE @ErrorText VARCHAR(250)
  SET @ErrorText = ''

  DECLARE @FaLeistung TABLE (
    FaLeistungID   int PRIMARY KEY,
    FaProzessCode  int,
    FaFallID       int)

  INSERT INTO @FaLeistung
    SELECT FLE.FaLeistungID, FLE.FaProzessCode, FLE.FaFallID
    FROM dbo.FaLeistung      FLE WITH (READUNCOMMITTED)
      INNER JOIN dbo.FaFall  FAL WITH (READUNCOMMITTED) ON FAL.FaFallID = FLE.FaFallID
    WHERE FAL.BaPersonID = @BaPersonID OR FLE.BaPersonID = @BaPersonID


  -- Checken, dass keine Leistung erbracht wurde (kein W, K, A)
  -- ==========================================================
  IF EXISTS(
    SELECT * FROM @FaLeistung WHERE FaProzessCode >= 300
  ) SET @ErrorText = 'Es sind bereits Leistungen erbracht worden.'
  IF NOT @ErrorText = '' BEGIN
    SELECT Error = @ErrorText
    RETURN
  END


  -- Checken, dass diese Person die einzige Person im Klientensystem ist
  -- ===================================================================
  DECLARE @CountPersonen INT
  DECLARE @FallID INT
  DECLARE @strFall VARCHAR(2000) 
  DECLARE crsFall CURSOR FAST_FORWARD FOR
    SELECT F.FaFallID, COUNT(*) FROM dbo.FaFall F WITH (READUNCOMMITTED)
      LEFT OUTER JOIN dbo.FaFallPerson P WITH (READUNCOMMITTED) ON P.FaFallID = F.FaFallID
    WHERE F.BaPersonID = @BaPersonID
    GROUP BY F.FaFallID
  OPEN crsFall
  SET @CountPersonen = 0
  SET @strFall = ''
  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM crsFall INTO @FallID, @CountPersonen
    IF NOT @@FETCH_STATUS = 0 BREAK
    IF @CountPersonen > 1 BEGIN
      IF NOT @strFall = '' SET @strFall = @strFall + ', '
      SET @strFall = @strFall + CONVERT(VARCHAR, @FallID)
    END
  END
  CLOSE crsFall 
  DEALLOCATE crsFall
  IF NOT @strFall = '' SET @ErrorText = 'Es existieren noch andere Personen im Klientensystem.'
  IF NOT @ErrorText = '' BEGIN
    SELECT Error = @ErrorText
    RETURN
  END


  -- Checken, dass es keine Relationen zu dieser Person gibt
  -- =======================================================
  IF EXISTS(
    SELECT 1 FROM dbo.BaPerson_Relation WITH (READUNCOMMITTED)
    WHERE BaPersonID_1 = @BaPersonID OR BaPersonID_2 = @BaPersonID
  ) SET @ErrorText = 'Es existieren bereits Relationen zu anderen Personen.'
  IF NOT @ErrorText = '' BEGIN
    SELECT Error = @ErrorText
    RETURN
  END


  -- Checken, dass es keine Aktennotizen zu dieser Person gibt
  -- =========================================================
  IF EXISTS(
    SELECT *
    FROM dbo.FaAktennotizen       FAN WITH (READUNCOMMITTED)
      INNER JOIN @FaLeistung  FLE ON FLE.FaLeistungID = FAN.FaLeistungID
  ) SET @ErrorText = 'Es existieren bereits Aktennotizen zu dieser Person.'
  IF NOT @ErrorText = '' BEGIN
    SELECT Error = @ErrorText
    RETURN
  END


  -- Checken, dass es keine Dokumente zu dieser Person gibt
  -- ======================================================
  IF EXISTS(
    SELECT *
    FROM dbo.FaDokumente          DOK WITH (READUNCOMMITTED)
      INNER JOIN @FaLeistung  FLE ON FLE.FaLeistungID = DOK.FaLeistungID
  ) SET @ErrorText = 'Es existieren bereits Dokumente zu dieser Person.'
  IF NOT @ErrorText = '' BEGIN
    SELECT Error = @ErrorText
    RETURN
  END


  -- Checken, dass es keine Alim-F zu dieser Person gibt
  -- ===================================================
  IF EXISTS(
    SELECT * FROM @FaLeistung FLE WHERE FaProzessCode = 201
  ) SET @ErrorText = 'Es existiert bereits eine Alimentenfallführung zu dieser Person.'
  IF NOT @ErrorText = '' BEGIN
    SELECT Error = @ErrorText
    RETURN
  END


  -- Checken, dass es kein Checkin zu dieser Person gibt
  -- ===================================================
  IF EXISTS(
    SELECT *
	FROM dbo.FaCheckin            CHK WITH (READUNCOMMITTED)
      INNER JOIN @FaLeistung  FLE ON FLE.FaLeistungID = CHK.FaLeistungID
  ) SET @ErrorText = 'Es existiert bereits ein Check-In zu dieser Person.'
  IF NOT @ErrorText = '' BEGIN
    SELECT Error = @ErrorText
    RETURN
  END


  -- Checken, dass es kein Assessment zu dieser Person gibt
  -- ======================================================
  IF EXISTS (
    SELECT *
	FROM dbo.FaAssessment         ASS WITH (READUNCOMMITTED)
      INNER JOIN @FaLeistung  FLE ON FLE.FaLeistungID = ASS.FaLeistungID
  ) SET @ErrorText = 'Es existiert bereits ein Assessment zu dieser Person.'
  IF NOT @ErrorText = '' BEGIN
    SELECT Error = @ErrorText
    RETURN
  END


  -- Checken, dass es kein Lösungsprozess (FaRessourcenpaket) zu dieser Person gibt
  -- ==============================================================================
  IF EXISTS(
    SELECT *
	FROM dbo.FaRessourcenpaket    RSP WITH (READUNCOMMITTED)
      LEFT  JOIN @FaLeistung  FLE ON FLE.FaLeistungID = RSP.FaLeistungID
    WHERE FLE.FaLeistungID IS NOT NULL OR RSP.BaPersonID = @BaPersonID
  ) SET @ErrorText = 'Es existiert bereits ein Ressourcenpaket zu dieser Person.'
  IF NOT @ErrorText = '' BEGIN
    SELECT Error = @ErrorText
    RETURN
  END


  -- Checken, dass es kein Lösungsprozess (FaZielvereinbarung) zu dieser Person gibt
  -- ===============================================================================
  IF EXISTS(
    SELECT *
	FROM dbo.FaZielvereinbarung   ZLV WITH (READUNCOMMITTED)
      LEFT  JOIN @FaLeistung  FLE ON FLE.FaLeistungID = ZLV.FaLeistungID
    WHERE FLE.FaLeistungID IS NOT NULL OR ZLV.BaPersonID = @BaPersonID
  ) SET @ErrorText = 'Es existiert bereits ein Ressourcenpaket zu dieser Person.'
  IF NOT @ErrorText = '' BEGIN
    SELECT Error = @ErrorText
    RETURN
  END


  -- Checken, dass es kein Lösungsprozess (FaAbklaerung) zu dieser Person gibt
  -- =========================================================================
  IF EXISTS(
    SELECT *
	FROM dbo.FaAbklaerung         ABK WITH (READUNCOMMITTED)
      LEFT  JOIN @FaLeistung  FLE ON FLE.FaLeistungID = ABK.FaLeistungID
    WHERE FLE.FaLeistungID IS NOT NULL OR ABK.BaPersonID = @BaPersonID
  ) SET @ErrorText = 'Es existiert bereits eine Abklärung zu dieser Person.'
  IF NOT @ErrorText = '' BEGIN
    SELECT Error = @ErrorText
    RETURN
  END


  -- Checken, dass es kein Teilleistungserbringer zu dieser Person gibt
  -- ==================================================================
  IF EXISTS(
    SELECT *
	FROM dbo.FaTeilLeistungserbringer  TLE WITH (READUNCOMMITTED)
      INNER  JOIN @FaLeistung      FLE ON FLE.FaLeistungID = TLE.FaLeistungID
  ) SET @ErrorText = 'Es existiert bereits eine Teilleistungserbringung zu dieser Person.'
  IF NOT @ErrorText = '' BEGIN
    SELECT Error = @ErrorText
    RETURN
  END


  -- Checken, dass es keine Abmachungen/Saktionen zu dieser Person gibt
  -- ==================================================================
  IF EXISTS(
    SELECT *
	FROM dbo.FaAbmachung          ABM WITH (READUNCOMMITTED)
      LEFT  JOIN @FaLeistung  FLE ON FLE.FaLeistungID = ABM.FaLeistungID
    WHERE FLE.FaLeistungID IS NOT NULL OR ABM.Klient1ID = @BaPersonID OR ABM.Klient2ID = @BaPersonID
  ) SET @ErrorText = 'Es existiert bereits eine Auflage/Sanktion zu dieser Person.'
  IF NOT @ErrorText = '' BEGIN
    SELECT Error = @ErrorText
    RETURN
  END


  -- Checken, dass es kein vorm. Massnahme zu dieser Person gibt
  -- ===========================================================
  IF EXISTS(
    SELECT * FROM @FaLeistung FLE WHERE FaProzessCode = 210
  ) SET @ErrorText = 'Es existiert bereits eine vormundschaftliche Massnahme zu dieser Person.'
  IF NOT @ErrorText = '' BEGIN
    SELECT Error = @ErrorText
    RETURN
  END


  -- Checken, dass es keine Ressourcenkarte zu dieser Person gibt
  -- ============================================================
  IF EXISTS(
    SELECT *
	FROM dbo.FaRessourcenkarte    RSK WITH (READUNCOMMITTED)
      LEFT  JOIN @FaLeistung  FLE ON FLE.FaLeistungID = RSK.FaLeistungID
    WHERE FLE.FaLeistungID IS NOT NULL OR RSK.BaPersonID = @BaPersonID
  ) SET @ErrorText = 'Es existiert bereits eine Ressourcenkarte zu dieser Person.'
  IF NOT @ErrorText = '' BEGIN
    SELECT Error = @ErrorText
    RETURN
  END


  -- Checken, dass es keine Unterlagenliste zu dieser Person gibt
  -- ============================================================
  IF EXISTS(
    SELECT *
	FROM dbo.FaUnterlagen         UNT WITH (READUNCOMMITTED)
      INNER JOIN @FaLeistung  FLE ON FLE.FaLeistungID = UNT.FaLeistungID
  ) SET @ErrorText = 'Es existieren bereits Unterlagen zu dieser Person.'
  IF NOT @ErrorText = '' BEGIN
    SELECT Error = @ErrorText
    RETURN
  END


  -- Checken, dass der Abschlussgrund nur "Klientin nicht erschienen" ist
  -- ====================================================================
  IF EXISTS(
    SELECT *
	FROM @FaLeistung     TMP
      INNER JOIN dbo.FaLeistung  FLE WITH (READUNCOMMITTED) ON FLE.FaLeistungID = TMP.FaLeistungID
    WHERE FLE.AbschlussGrundCode IS NOT NULL AND FLE.AbschlussGrundCode <> 20008
  ) SET @ErrorText = 'Es existiert mind. ein Fall, bei welchen der Abschlussgrund nicht "Klient/Klienten nicht erschienen" ist.'
  IF NOT @ErrorText = '' BEGIN
    SELECT Error = @ErrorText
    RETURN
  END


  -- Checken, dass in FaVoranmeldung das Datum 'Feedback gegeben am' ausgefüllt ist
  -- ==============================================================================
  IF NOT EXISTS(
    SELECT *
	FROM dbo.FaVoranmeldung       FVA WITH (READUNCOMMITTED)
      INNER JOIN @FaLeistung  FLE ON FLE.FaLeistungID = FVA.FaLeistungID
  ) SET @ErrorText = 'Es existiert keine Voranmeldung zu dieser Person.'
  IF NOT @ErrorText = '' BEGIN
    SELECT Error = @ErrorText
    RETURN
  END

  IF EXISTS(
    SELECT *
	FROM dbo.FaVoranmeldung       FVA WITH (READUNCOMMITTED)
      INNER JOIN @FaLeistung  FLE ON FLE.FaLeistungID = FVA.FaLeistungID
    WHERE FVA.FeedbackErteiltAm IS NULL
  ) SET @ErrorText = 'Es existiert mind. eine Voranmeldung, bei welcher das Datum "Feedback gegeben am" leer ist.'
  IF NOT @ErrorText = '' BEGIN
    SELECT Error = @ErrorText
    RETURN
  END

  SELECT Error = NULL
END

