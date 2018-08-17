SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spBFSDossier_Delete
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spBFSDossier_Delete
(
  @Jahr                INT,
  @BaPersonID          INT,
  @BFSLeistungsartCode INT,
  @FaLeistungID        INT,
  @Stichtag            BIT = 1
)
AS
BEGIN
  DECLARE @AntragstellerBaPersonID INT;

  -- BFS Antragsteller suchen (analog zu spBFSDossier_Create)
  IF (@BFSLeistungsartCode = 23 OR @BFSLeistungsartCode = 25)
  BEGIN
    -- bei Inkasso (ALBV und KKBB) ist Antragsteller der älteste Gläubiger
--		SELECT TOP 1 @AntragstellerBaPersonID = GLB.BaPersonID
--		FROM dbo.FaLeistung            LST WITH (READUNCOMMITTED)
--		  INNER JOIN dbo.IkRechtstitel RTT WITH (READUNCOMMITTED) ON RTT.FaLeistungID = LST.FaLeistungID
--  		  INNER JOIN dbo.IkGlaeubiger  GLB WITH (READUNCOMMITTED) ON GLB.IkRechtstitelID = RTT.IkRechtstitelID
--  		  INNER JOIN dbo.vwPerson      PRS ON PRS.BaPersonID = GLB.BaPersonID
--		WHERE LST.FaLeistungID = @FaLeistungID
--		ORDER BY Geburtsdatum ASC
    SELECT @AntragstellerBaPersonID = NULL; --TODO? dbo.[fnFindInkassoMutter](@FaLeistungID,NULL)
  END
  ELSE BEGIN
    -- bei SH ist Antragsteller die BaPerson
    SET @AntragstellerBaPersonID = @BaPersonID;
  END;

  DECLARE @DossierIDS TABLE
  (
    BFSDossierID INT
  );

  INSERT INTO @DossierIDS
    SELECT DISTINCT
      DOS.BFSDossierID
    FROM dbo.BFSDossier DOS
      INNER JOIN dbo.BFSDossierPerson DOP ON DOS.BFSDossierID = DOP.BFSDossierID
    WHERE DOS.Jahr = @Jahr
      AND DOP.BaPersonID = ISNULL(@AntragstellerBaPersonID, DOP.BaPersonID)
      AND DOP.BFSPersonCode = 1
      AND DOS.Stichtag = @Stichtag
      AND DOS.FaLeistungID = ISNULL(@FaLeistungID, DOS.FaLeistungID);

     -- Löschen aller BFS Werte aller Anfangs- oder Stichtag-Dossiers mit diesem Antragsteller für dieses Jahr und Leistungsart
  DELETE FROM dbo.BFSWert 
  WHERE BFSDossierID IN (SELECT BFSDossierID FROM @DossierIDS);

  -- Löschen aller Mitglieder-Personen aller Anfangs- oder Stichtag-Dossiers mit diesem Antragsteller  für dieses Jahr und Leistungsart
  DELETE FROM dbo.BFSDossierPerson
  WHERE BFSDossierID IN (SELECT BFSDossierID FROM @DossierIDS);

  -- Löschen aller Anfangs- oder Stichtag-Dossiers mit diesem Antragsteller  für dieses Jahr und Leistungsart
  DELETE FROM dbo.BFSDossier
  WHERE BFSDossierID IN (SELECT BFSDossierID FROM @DossierIDS);
END;

GO