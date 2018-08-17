SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spFaGetSozialsystem;
GO
/*===============================================================================================
  $Revision: 11 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Used to build up required datasets for displaying Sozialsystem
    @BaPersonID:   The ID of the person to show data from
    @Datum:        The date to use for data (NULL means today)
    @LanguageCode: The languagecode to use
  -
  RETURNS: Specified datasets used to build up Sozialsystem or -1 in case of error
  -
=================================================================================================
  TEST:    EXEC dbo.spFaGetSozialsystem 333, NULL
           EXEC dbo.spFaGetSozialsystem 74660, NULL, 1
           EXEC dbo.spFaGetSozialsystem 77926, NULL, 1
           EXEC dbo.spFaGetSozialsystem 77926, NULL, 2
=================================================================================================*/

CREATE PROCEDURE dbo.spFaGetSozialsystem
(
  @BaPersonID INT, 
  @Datum DATETIME, 
  @LanguageCode INT = 1
)
AS
BEGIN
  -- ------------------------------------------------------------------------------------
  -- validate parameters
  -- ------------------------------------------------------------------------------------
  IF (@BaPersonID IS NULL)
  BEGIN
    -- if no person is given, do nothing
    RETURN -1;
  END;
  
  -- set defaults
  SET @Datum = ISNULL(@Datum, GETDATE());       -- if no date is given, use current date by default
  SET @LanguageCode = ISNULL(@LanguageCode, 1); -- by default, use german
  
  -- ------------------------------------------------------------------------------------
  -- vars
  -- ------------------------------------------------------------------------------------
  -- iconoffsets for modul-status
  DECLARE @OffDisabled INT;
  DECLARE @OffActive INT;
  DECLARE @OffClosed INT;
  
  SET @OffDisabled = 0;
  SET @OffActive = 1;
  SET @OffClosed = 2;
  
  -- ------------------------------------------------------------------------------------
  -- search all clients to display
  -- ------------------------------------------------------------------------------------
  -- temporäre tabelle für alle personen im klientensystem
  DECLARE @Klienten TABLE 
  (
    BaPersonId INT NOT NULL PRIMARY KEY
  );
  
  -- insert current person into temporary table
  INSERT INTO @Klienten
    SELECT PRS.BaPersonID 
    FROM dbo.BaPerson PRS WITH (READUNCOMMITTED) 
    WHERE PRS.BaPersonID = @BaPersonID;

  -- alle personen des aktuellen falls vom klientensystem ausser der aktuellen person
  INSERT INTO @Klienten
    SELECT DISTINCT PRS.BaPersonID
    FROM dbo.BaPerson_Relation BRE WITH (READUNCOMMITTED)
      INNER JOIN dbo.BaPerson    PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID IN (BRE.BaPersonID_1, BRE.BaPersonID_2)
      LEFT  JOIN dbo.BaRelation  BRL WITH (READUNCOMMITTED) ON BRL.BaRelationID = BRE.BaRelationID
    WHERE (BRE.BaPersonID_1 = @BaPersonID OR BRE.BaPersonID_2 = @BaPersonID) 
      AND PRS.BaPersonID != @BaPersonID;
  
  -- ------------------------------------------------------------------------------------
  -- 1. Klienten
  -- ------------------------------------------------------------------------------------
  -- result set 1: Klienten
  SELECT KLI.BaPersonID, 
         PRS.Name, 
         PRS.Vorname, 
         [Alter]   = ISNULL(dbo.fnGetAge(PRS.Geburtsdatum, ISNULL(PRS.Sterbedatum, @Datum)), -1), 
         PRS.GeschlechtCode,                -- Geschlecht: m=1, w=2
         Gestorben = CONVERT(BIT, CASE WHEN PRS.Sterbedatum IS NULL THEN 0 ELSE 1 END)
  FROM @Klienten KLI
    INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = KLI.BaPersonID;
  
  -- ------------------------------------------------------------------------------------
  -- 2. Relationen
  -- ------------------------------------------------------------------------------------
  -- result set 2: Relationen
  SELECT REL.BaRelationID, 
         PREL.BaPersonID_1, 
         PREL.BaPersonID_2,
         
         RelationName1 = CASE PRSA.GeschlechtCode 
                           WHEN 1 THEN dbo.fnGetMLTextByDefault(REL.NameMaennlich1TID, @LanguageCode, REL.NameMaennlich1)
                           WHEN 2 THEN dbo.fnGetMLTextByDefault(REL.NameWeiblich1TID, @LanguageCode, REL.NameWeiblich1)
                           ELSE dbo.fnGetMLTextByDefault(REL.NameGenerisch1TID, @LanguageCode, REL.NameGenerisch1)
                         END,
         RelationName2 = CASE PRSB.GeschlechtCode 
                           WHEN 1 THEN dbo.fnGetMLTextByDefault(REL.NameMaennlich2TID, @LanguageCode, REL.NameMaennlich2)
                           WHEN 2 THEN dbo.fnGetMLTextByDefault(REL.NameWeiblich2TID, @LanguageCode, REL.NameWeiblich2)
                           ELSE dbo.fnGetMLTextByDefault(REL.NameGenerisch2TID, @LanguageCode, REL.NameGenerisch2)
                         END,
         
         REL.Symmetrisch,
         
         -- from BaRelation:
         -- 1 = one step between generations
         -- 2 = two steps between generations
         SymmetricStep = CASE REL.BaRelationID 
                           WHEN 1 THEN 1     -- Ehepaar
                           WHEN 2 THEN 1     -- Partner
                           WHEN 3 THEN 1     -- Eltern : Kind
                           WHEN 4 THEN 1     -- Adoptiveltern : Adoptivkind
                           WHEN 5 THEN 1     -- Stiefeltern : Stiefkind
                           WHEN 6 THEN 1     -- Pflegeltern : Pflegkind
                           WHEN 7 THEN 1     -- Bruder / Schwester
                           WHEN 8 THEN 1     -- Stiefbruder / Stiefschwester
                           WHEN 9 THEN 1     -- Freund/in
                           WHEN 10 THEN 1    -- geschiedener Partner / geschiedene Partnerin
                           WHEN 11 THEN 1    -- Schwiegereltern : Schwiegerkinder
                           WHEN 12 THEN 2    -- Grosseltern : Enkelkind
                           WHEN 13 THEN 2    -- Grosseltern des Partners : Enkelkind des Partners
                           WHEN 14 THEN 1    -- Nachbarschaftshilfe
                           WHEN 15 THEN 1    -- andere verwandte/verschwägerte Person
                           WHEN 16 THEN 1    -- falls fremdplatziert: andere, nicht verwandte Person
                           WHEN 99 THEN 1    -- andere, nicht verwandte Person
                           ELSE 0            -- step undefined
                         END,
         Qualitaet = NULL,  -- TODO: not yet implemented
         PREL.Bemerkung
  FROM (SELECT PersonA = PSA.BaPersonID, 
               PersonB = PSB.BaPersonID
        FROM @Klienten PSA, 
             @Klienten PSB -- kartesisches produkt: jede person mit jeder (AxB) in temporärer tabelle Klienten
        WHERE PSA.BaPersonID <> PSB.BaPersonID) PRSAB
    
    LEFT OUTER JOIN dbo.BaPerson_Relation  PREL WITH (READUNCOMMITTED) ON PREL.BaPersonID_1 = PRSAB.PersonA 
                                                                      AND PREL.BaPersonID_2 = PRSAB.PersonB
    LEFT OUTER JOIN dbo.BaRelation         REL  WITH (READUNCOMMITTED) ON REL.BaRelationID = PREL.BaRelationID
    LEFT OUTER JOIN dbo.BaPerson           PRSA WITH (READUNCOMMITTED) ON PRSA.BaPersonID = PRSAB.PersonA
    LEFT OUTER JOIN dbo.BaPerson           PRSB WITH (READUNCOMMITTED) ON PRSB.BaPersonID = PRSAB.PersonB
  
  WHERE REL.BaRelationID IS NOT NULL 
    AND @Datum BETWEEN ISNULL(PREL.DatumVon, @Datum) AND ISNULL(PREL.DatumBis, @Datum) -- take only within daterange
  ORDER BY PREL.BaPersonID_1, PREL.BaPersonID_2;
  
  -- ------------------------------------------------------------------------------------
  -- 3. Leistungserbringer
  -- ------------------------------------------------------------------------------------
  -- result set 3: Leistungserbringer
  SELECT DISTINCT
         USR.UserID,
         [Function] = NULL,	-- todo: new fields from XUser
         USR.FirstName,
         USR.LastName,
         Contact = ISNULL(USR.PhoneOffice, USR.Email),
         OrgUnit = dbo.fnOrgUnitOfUser(USR.UserID, 0),
         LeistungstraegerID = 0,
         IconID = -1
  FROM @Klienten KLI
    INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = KLI.BaPersonID
    INNER JOIN dbo.XUser USR WITH (READUNCOMMITTED) ON USR.UserID = LEI.UserID
  ORDER BY USR.LastName ASC, USR.FirstName ASC;
  
  -- ------------------------------------------------------------------------------------
  -- 4. Leistungen
  -- ------------------------------------------------------------------------------------
  -- result set 4: Leistungen
  SELECT LEI.FaLeistungID,
         LEI.BaPersonID,
         IstUnterstuetzt = PRS.Unterstuetzt
  FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
    INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
  WHERE LEI.BaPersonID = @BaPersonID 
    AND 1 = 2;
  
  -- ------------------------------------------------------------------------------------
  -- 5. Involvierte Personen
  -- ------------------------------------------------------------------------------------
  -- result set 5: Involvierte Personen
  SELECT BaPersonID     = 0,
         HasConnection  = 0,
         Name           = '',
         Vorname        = '',
         GeschlechtCode = 0,
         Rolle          = '',
         Contact        = '',
         Bemerkung      = ''
  WHERE 1 = 2; -- do not use this item for PI!
  
  -- ------------------------------------------------------------------------------------
  -- 6. Involvierte Stellen
  -- ------------------------------------------------------------------------------------
  -- result set 6: Involvierte Stellen
  SELECT BaPersonID      = BPI.BaPersonID,
         BaInstitutionID = BPI.BaInstitutionID,
         HasConnection   = CASE 
                             WHEN BPI.BaPersonID IS NULL THEN 0 
                             ELSE 1 
                           END,
         Name            = dbo.fnGetLastFirstName(NULL, INS.Name, INS.Vorname),
         PLZ             = INS.PLZ,
         Ort             = INS.Ort,
         AnsprechPerson  = dbo.fnGetLastFirstName(NULL, INK.Name, INK.Vorname),
         Contact         = COALESCE(INK.Telefon, INS.Telefon, INS.Telefon2, INS.Telefon3),
         EMail           = COALESCE(INK.Email, INS.Email),
         Relation        = dbo.fnGetMLTextByDefault(ITY.NameTID, @LanguageCode, ITY.Name),
         Bemerkung       = BPI.Bemerkung
  FROM dbo.BaPerson_BaInstitution       BPI WITH (READUNCOMMITTED)
    INNER JOIN dbo.vwInstitution        INS WITH (READUNCOMMITTED) ON INS.BaInstitutionID = BPI.BaInstitutionID
    LEFT  JOIN dbo.BaInstitutionKontakt INK WITH (READUNCOMMITTED) ON INK.BaInstitutionKontaktID = BPI.BaInstitutionKontaktID
                                                                  AND INK.Aktiv = 1
    LEFT  JOIN dbo.BaInstitutionTyp     ITY WITH (READUNCOMMITTED) ON ITY.BaInstitutionTypID = BPI.BaInstitutionTypID
  WHERE BPI.BaPersonID IN (SELECT BaPersonID_1 
                           FROM dbo.BaPerson_Relation WITH (READUNCOMMITTED) 
                           WHERE BaPersonID_2 = @BaPersonID
                           
                           UNION
                           
                           SELECT BaPersonID_2 
                           FROM dbo.BaPerson_Relation WITH (READUNCOMMITTED) 
                           WHERE BaPersonID_1 = @BaPersonID
                           
                           UNION
                           
                           SELECT @BaPersonID)
  ORDER BY HasConnection DESC, Name ASC, BaInstitutionID;
  
  -- ------------------------------------------------------------------------------------
  -- 7. Icons bei den Klienten
  -- ------------------------------------------------------------------------------------
  -- result set 7: Icons bei den Klienten
  SELECT DISTINCT
         BaPersonID = KLI.BaPersonID,
         IconID     = CASE 
                        WHEN LEI.DatumBis IS NULL THEN @OffActive
                        ELSE @OffClosed 
                      END + 1000 + LEI.ModulID * 100
  FROM @Klienten KLI
    INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = KLI.BaPersonID
  WHERE LEI.DatumVon <= @Datum -- use only entries in FaLeistung that started today or earlier
  ORDER BY BaPersonID, IconID ASC;
  
  -- ------------------------------------------------------------------------------------
  -- 8. Icons bei den Leistungserbringer
  -- ------------------------------------------------------------------------------------
  -- result set 8: Icons bei den Leistungserbringern
  SELECT DISTINCT
         UserID = LEI.UserID,
         IconID = CASE 
                    WHEN LEI.DatumBis IS NULL THEN @OffActive
                    ELSE @OffClosed 
                  END + 1000 + LEI.ModulID * 100
  FROM @Klienten KLI
    INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = KLI.BaPersonID
  WHERE LEI.DatumVon <= @Datum -- use only entries in FaLeistung that started today or earlier
  ORDER BY UserID, IconID ASC;
  
  -- ------------------------------------------------------------------------------------
  -- 9. Alle Beziehungen Leistungserbringer - Klient
  -- ------------------------------------------------------------------------------------
  -- result set 9: Alle Beziehungen Leistungserbringer - Klient 
  SELECT DISTINCT
         UserID     = LEI.UserID,
         BaPersonID = KLI.BaPersonID
  FROM @Klienten KLI
    INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = KLI.BaPersonID
  WHERE LEI.DatumVon <= @Datum -- use only entries in FaLeistung that started today or earlier
  ORDER BY UserID, BaPersonID;
END;
GO