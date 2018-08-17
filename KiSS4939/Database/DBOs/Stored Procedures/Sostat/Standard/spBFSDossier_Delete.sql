SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spBFSDossier_Delete
GO
/*===============================================================================================
  $Revision: 7 $
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
      AND DOP.BaPersonID = ISNULL(@BaPersonID, DOP.BaPersonID)
      AND DOP.BFSPersonCode = 1
      AND DOS.Stichtag = @Stichtag
      AND DOS.FaLeistungID = ISNULL(@FaLeistungID, DOS.FaLeistungID)
      AND DOS.BFSLeistungsartCode = ISNULL(@BFSLeistungsartCode, DOS.BFSLeistungsartCode);

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