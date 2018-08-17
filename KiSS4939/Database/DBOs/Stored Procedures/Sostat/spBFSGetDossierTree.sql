SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spBFSGetDossierTree;
GO
/*===============================================================================================
  $Revision: 13 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:          Generate the tree filtered by search criterias used for editing and fixing 
                    BFS-Dossiers
    @Jahr:          Search value for filtering by year
    @UserID:        Search value for filtering by user-id
    @BaPersonID:    Search value for filtering by person's id
    @Stichtag:      Search value for filtering by flag Stichtag
    @AnfZustCode:   Search value for filtering by flag Anfangszustand
    @LeistArtCodes: Search value for filtering by LOV "BFSLeistungsart"
    @BFSDossierNr:  Search value for filtering by unique BFSDossier-number (generated from various 
                    values by specific function)
    @BFSDossierID:  Search value for filtering by BFSDossier.BFSDossierID
  -
  RETURNS: The tree used for BFSDossier-management in CtlBfsDossiers
=================================================================================================
  TEST:    EXECUTE dbo.spBfsGetDossierTree NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL
           EXECUTE dbo.spBfsGetDossierTree NULL, NULL, NULL, 1, NULL, NULL, 67426035100, NULL
=================================================================================================*/

CREATE PROCEDURE dbo.spBFSGetDossierTree
(
  @Jahr INT,
  @UserID INT,
  @BaPersonID INT,
  @Stichtag BIT,
  @AnfZustCode BIT,
  @LeistArtCodes VARCHAR(50),
  @BFSDossierNr VARCHAR(50),
  @BFSDossierID INT
)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- Init
  -----------------------------------------------------------------------------
  DECLARE @Tree TABLE 
  (
    TreeID INT IDENTITY(1,1) NOT NULL,
    ID VARCHAR(250) PRIMARY KEY,
    ParentID VARCHAR(250),
    Text VARCHAR(150),
    BFSDossierID INT,
    BFSDossierNr BIGINT,
    BFSKatalogVersionID INT,
    Jahr INT,
    BFSLeistungsfilterCode INT,
    Stichtag BIT,
    BFSPersonCode INT,
    PersonIndex INT,
    BFSDossierPersonID INT,
    BFSKategorieCode INT,
    Fehler INT,
    Anzahl INT
  );
  
  DECLARE @BFSLeistungsfilter TABLE
  (
    BFSKatalogVersionID INT,
    BFSLeistungsfilterCode INT,
    BFSPersonCode INT,
    Person VARCHAR(200),
    PersonIndex INT,
    BFSKategorieCode INT,
    Kategorie VARCHAR(200)
  );
  
  -----------------------------------------------------------------------------
  -- BFSLeistungsfilter
  -----------------------------------------------------------------------------
  INSERT INTO @BFSLeistungsfilter
    SELECT DISTINCT 
      FRA.BFSKatalogVersionID, 
      BLC.Code, 
      FRA.BFSPersonCode, 
      PRS.Text, 
      FRA.PersonIndex, 
      FRA.BFSKategorieCode, 
      KAT.Text
    FROM dbo.BFSFrage           FRA WITH (READUNCOMMITTED)
      INNER JOIN dbo.BFSLOVCode BLC WITH (READUNCOMMITTED) ON BLC.LOVName = 'BFSLeistungsfilter' 
                                                          AND ',' + FRA.BFSLeistungsfilterCodes + ',' LIKE '%,' + CONVERT(VARCHAR, BLC.Code) + ',%'
      INNER JOIN dbo.BFSLOVCode KAT WITH (READUNCOMMITTED) ON KAT.LOVName = 'BFSKategorie'       
                                                          AND KAT.Code = FRA.BFSKategorieCode
      INNER JOIN dbo.BFSLOVCode PRS WITH (READUNCOMMITTED) ON PRS.LOVName = 'BFSPerson'          
                                                          AND PRS.Code = FRA.BFSPersonCode;
  
  -----------------------------------------------------------------------------
  -- Tree: BFSDossier
  -----------------------------------------------------------------------------
  INSERT INTO @Tree
  (
    ID, 
    ParentID, 
    Text, 
    BFSKatalogVersionID, 
    BFSDossierID, 
    BFSDossierNr,
    Jahr, 
    BFSLeistungsfilterCode, 
    Stichtag
  )
    SELECT
      ID                     = 'DOS_' + CONVERT(VARCHAR, DOS.BFSDossierID),
      ParentID               = CONVERT(VARCHAR, Jahr) + '_PRS_' + COALESCE(PRS.NameVorname, DOP.PersonName, '???'),
      Text                   = LEI.Text + CASE 
                                            WHEN Stichtag = 1 THEN '' 
                                            ELSE ' (Anfangszustand)' 
                                          END,
      BFSKatalogVersionID    = DOS.BFSKatalogVersionID,
      BFSDossierID           = DOS.BFSDossierID,
      BFSDossierNr           = dbo.fnBFSConcatDossierNr(DOP.BaPersonID, DOS.ZustaendigeGemeinde, DOS.LaufNr, DOS.BFSLeistungsartCode, DOS.Stichtag),
      Jahr                   = DOS.Jahr,
      BFSLeistungsfilterCode = LEI.Filter,
      Stichtag               = DOS.Stichtag
    FROM dbo.BFSDossier               DOS WITH (READUNCOMMITTED)
      INNER JOIN dbo.BFSDossierPerson DOP WITH (READUNCOMMITTED) ON DOP.BFSDossierID = DOS.BFSDossierID 
                                                                AND DOP.BFSPersonCode = 1
      LEFT  JOIN dbo.vwPerson         PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = DOP.BaPersonID
      LEFT  JOIN dbo.BFSLOVCode       LEI WITH (READUNCOMMITTED) ON LEI.LOVName = 'BFSLeistungsart'
                                                                AND LEI.Code = DOS.BFSLeistungsartCode
    WHERE ISNULL(@BFSDossierID, DOS.BFSDossierID) = DOS.BFSDossierID
      AND (@BFSDossierNr IS NULL OR dbo.fnBFSConcatDossierNr(DOP.BaPersonID, DOS.ZustaendigeGemeinde, DOS.LaufNr, DOS.BFSLeistungsartCode, DOS.Stichtag) = REPLACE(@BFSDossierNr,'.',''))
      AND (@Jahr IS NULL OR DOS.Jahr = @Jahr)
      AND (@UserID IS NULL OR DOS.UserID = @UserID)
      AND (@BaPersonID IS NULL OR DOP.BaPersonID = @BaPersonID)
      AND (DOS.Stichtag IN (CASE 
                              WHEN (@AnfZustCode = 1 AND @Stichtag = 0) THEN 0
                              WHEN (@AnfZustCode = 0 AND @Stichtag = 1) THEN 1
                              WHEN (@AnfZustCode = 0 AND @Stichtag = 0) THEN NULL
                              ELSE DOS.Stichtag
                            END))
      AND (@LeistArtCodes IS NULL OR ',' + @LeistArtCodes + ',' LIKE '%,' + CONVERT(VARCHAR, DOS.BFSLeistungsartCode) + ',%');
  
  UPDATE TRE 
  SET Fehler = (SELECT COUNT(1) 
                FROM dbo.BFSWert WRT WITH (READUNCOMMITTED)
                WHERE WRT.BFSDossierID = TRE.BFSDossierID 
                  AND WRT.PlausiFehler IS NOT NULL)
  FROM @Tree TRE;

  -- Jahr
  INSERT INTO @Tree (ID, Text, Jahr)
    SELECT DISTINCT Jahr, Jahr, Jahr 
    FROM @Tree;

  -- Antragsteller
  INSERT INTO @Tree (ID, ParentID, Text, Jahr)
    SELECT DISTINCT ParentID, Jahr, COALESCE(PRS.NameVorname, DOP.PersonName, '???'), Jahr
    FROM @Tree                        TRE
      INNER JOIN dbo.BFSDossierPerson DOP WITH (READUNCOMMITTED) ON DOP.BFSDossierID = TRE.BFSDossierID 
                                                                AND DOP.BFSPersonCode = 1
      LEFT  JOIN dbo.vwPerson         PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = DOP.BaPersonID;
  
  -----------------------------------------------------------------------------
  -- Tree: BFSKategorien
  -----------------------------------------------------------------------------
  INSERT INTO @Tree 
  (
    ID, 
    ParentID, 
    Text, 
    BFSKatalogVersionID, 
    BFSDossierID, 
    BFSDossierNr,
    Jahr, 
    BFSLeistungsfilterCode, 
    Stichtag,
    BFSPersonCode, 
    PersonIndex, 
    BFSDossierPersonID, 
    BFSKategorieCode, 
    Fehler
  )
    SELECT DISTINCT
      ID = 'DOS_' + CONVERT(VARCHAR, DOS.BFSDossierID) + 
           '_' + CONVERT(VARCHAR, DOP.BFSPersonCode) + 
           '_' + CONVERT(VARCHAR, DOP.PersonIndex) + 
           '_' + CONVERT(VARCHAR, KAT.BFSKategorieCode),
      --
      ParentID = 'DOS_' + CONVERT(VARCHAR, DOS.BFSDossierID) + 
                 CASE 
                   WHEN DOP.BFSPersonCode > 1 AND KAT.BFSKategorieCode > 2 THEN '_' + CONVERT(VARCHAR, DOP.BFSPersonCode) + 
                                                                                '_' + CONVERT(VARCHAR, DOP.PersonIndex) + '_2'
                   ELSE ''
                 END,
      --
      Text = CASE 
               WHEN DOP.BFSPersonCode = 1 OR KAT.BFSKategorieCode > 2 THEN KAT.Kategorie COLLATE DATABASE_DEFAULT
               ELSE KAT.Person COLLATE DATABASE_DEFAULT + ' - ' + COALESCE(PRS.NameVorname, DOP.PersonName, '???') COLLATE DATABASE_DEFAULT
             END COLLATE DATABASE_DEFAULT,
      --
      BFSKatalogVersionID    = DOS.BFSKatalogVersionID,
      BFSDossierID           = DOS.BFSDossierID,
      BFSDossierNr           = DOS.BFSDossierNr,   
      Jahr                   = DOS.Jahr,
      BFSLeistungsfilterCode = DOS.BFSLeistungsfilterCode,
      Stichtag               = DOS.Stichtag,

      BFSPersonCode          = DOP.BFSPersonCode,
      PersonIndex            = DOP.PersonIndex,
      BFSDossierPersonID     = DOP.BFSDossierPersonID,
      BFSKategorieCode       = KAT.BFSKategorieCode,
      --
      Fehler = (SELECT COUNT(1) 
                FROM dbo.BFSWert          WRT WITH (READUNCOMMITTED)
                  INNER JOIN dbo.BFSFrage FRG WITH (READUNCOMMITTED) ON FRG.BFSFrageID = WRT.BFSFrageID
                WHERE WRT.BFSDossierID = DOS.BFSDossierID
                  AND WRT.PlausiFehler IS NOT NULL
                  AND WRT.BFSDossierPersonID = DOP.BFSDossierPersonID
                  AND FRG.BFSKategorieCode = KAT.BFSKategorieCode)
  FROM @Tree DOS
    INNER JOIN @BFSLeistungsfilter  KAT                        ON KAT.BFSKatalogVersionID = DOS.BFSKatalogVersionID 
                                                              AND KAT.BFSLeistungsfilterCode = DOS.BFSLeistungsfilterCode
    INNER JOIN dbo.BFSDossierPerson DOP WITH (READUNCOMMITTED) ON DOP.BFSDossierID = DOS.BFSDossierID
                                                              AND DOP.BFSPersonCode = KAT.BFSPersonCode 
                                                              AND DOP.PersonIndex = KAT.PersonIndex
    LEFT  JOIN dbo.vwPerson         PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = DOP.BaPersonID
  ORDER BY DOS.BFSDossierID, DOP.BFSPersonCode, DOP.PersonIndex, KAT.BFSKategorieCode;
  
  -----------------------------------------------------------------------------
  -- Anzahl Dossiers zusammenzählen ...
  -----------------------------------------------------------------------------
  DECLARE @AnzahlDossiers INT;
  
  SELECT @AnzahlDossiers = COUNT(DISTINCT BFSDossierID) 
  FROM @Tree
  WHERE BFSDossierID IS NOT NULL;
  
  -- ... und in Tabelle @Tree speichern
  UPDATE @Tree 
  SET Anzahl = @AnzahlDossiers;
  
  -----------------------------------------------------------------------------
  -- Tabelle @Tree übergeben
  -----------------------------------------------------------------------------
  SELECT
    TreeID,
    ID,
    ParentID,
    Text,
    BFSDossierID,
    BFSDossierNr,
    BFSKatalogVersionID,
    Jahr,
    BFSLeistungsfilterCode,
    Stichtag,
    BFSPersonCode,
    PersonIndex,
    BFSDossierPersonID,
    BFSKategorieCode,
    Fehler,
    Anzahl
  FROM @Tree
  ORDER BY Jahr, ID;
END;
GO