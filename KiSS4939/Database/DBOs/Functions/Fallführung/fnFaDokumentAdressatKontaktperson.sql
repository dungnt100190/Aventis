SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnFaDokumentAdressatKontaktperson;
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Search all possible contact persons for the Adressat of a FaDokument entry.
           For further details see #7763. (LOV=FaDokumentAdressTyp)
    @FaDokumenteID:         The id of the entry in FaDokumente for which the contact-persons have
                            to be searched (if required)
  -
  RETURNS: Returns all possible BaInstitutionKontaktIDs and its belonging BaInstitutionID for given
           FaDokumenteID or nothing in case of error or no required search
=================================================================================================
  TEST:    SELECT * FROM dbo.fnFaDokumentAdressatKontaktperson(…);
=================================================================================================*/

CREATE FUNCTION dbo.fnFaDokumentAdressatKontaktperson
(
  @FaDokumenteID INT
)
RETURNS @Result TABLE
(
  BaInstitutionID INT NOT NULL,
  BaPersonID_Betrifft INT NOT NULL,
  BaInstitutionKontaktID INT NOT NULL
)
AS
BEGIN
  -----------------------------------------------------------------------------
  -- init and get all data
  -----------------------------------------------------------------------------
  DECLARE @BaPersonID INT;
  DECLARE @BaInstitutionID_Adressat INT;
  DECLARE @AdressatAdressTypCode INT;
  
  SELECT @BaPersonID               = FDO.BaPersonID,
         @BaInstitutionID_Adressat = FDO.AdressatID,
         @AdressatAdressTypCode    = FDO.AdressatAdressTypCode
  FROM dbo.FaDokumente FDO WITH (READUNCOMMITTED)
  WHERE FDO.FaDokumenteID = @FaDokumenteID;
  
  -----------------------------------------------------------------------------
  -- validate data
  -----------------------------------------------------------------------------
  IF (ISNULL(@BaPersonID, -1) < 1)
  BEGIN
    -- invalid person, cannot get data
    RETURN;
  END;
  
  IF (ISNULL(@AdressatAdressTypCode, -1) <> 3)
  BEGIN
    -- no need to search contact persons
    RETURN;
  END;
  
  -----------------------------------------------------------------------------
  -- get all possible institutions
  -----------------------------------------------------------------------------
  DECLARE @TmpRelatedInsAndInk TABLE
  (
    BaInstitutionID INT NOT NULL,
    BaPersonID_Betrifft INT NOT NULL,
    BaInstitutionKontaktID INT NOT NULL
  );
  
  INSERT INTO @TmpRelatedInsAndInk (BaInstitutionID, BaPersonID_Betrifft, BaInstitutionKontaktID)
    SELECT DISTINCT
           BaInstitutionID          = BPI.BaInstitutionID,
           BaPersonID_Betrifft      = BPI.BaPersonID,
           BaInstitutionKontaktID   = INK.BaInstitutionKontaktID
    FROM dbo.BaPerson_BaInstitution       BPI WITH (READUNCOMMITTED)
      INNER JOIN dbo.BaInstitutionKontakt INK WITH (READUNCOMMITTED) ON INK.BaInstitutionKontaktID = BPI.BaInstitutionKontaktID
    WHERE BPI.BaInstitutionID = @BaInstitutionID_Adressat                         -- only for current institution of adressat
      AND BPI.BaPersonID IN (SELECT BaPersonID_1                                  -- only for current person and its related persons
                             FROM dbo.BaPerson_Relation WITH (READUNCOMMITTED)
                             WHERE BaPersonID_2 = @BaPersonID

                             UNION ALL

                             SELECT BaPersonID_2
                             FROM dbo.BaPerson_Relation WITH (READUNCOMMITTED)
                             WHERE BaPersonID_1 = @BaPersonID

                             UNION ALL

                             SELECT @BaPersonID)
    ORDER BY BPI.BaInstitutionID;
  
  -----------------------------------------------------------------------------
  -- 1. if institution exists only once with contact person, we return this row
  -----------------------------------------------------------------------------
  IF ((SELECT COUNT(1)
       FROM @TmpRelatedInsAndInk TMP) = 1)
  BEGIN
    INSERT INTO @Result (BaInstitutionID, BaPersonID_Betrifft, BaInstitutionKontaktID)
      SELECT TMP.BaInstitutionID,
             TMP.BaPersonID_Betrifft,
             TMP.BaInstitutionKontaktID
      FROM @TmpRelatedInsAndInk TMP;
    
    RETURN;
  END;
  
  -----------------------------------------------------------------------------
  -- 2. if institution exists only once with contact person for given BaPersonID, 
  --    we return this row
  -----------------------------------------------------------------------------
  IF ((SELECT COUNT(1)
       FROM @TmpRelatedInsAndInk TMP
       WHERE TMP.BaPersonID_Betrifft = @BaPersonID) = 1)
  BEGIN
    INSERT INTO @Result (BaInstitutionID, BaPersonID_Betrifft, BaInstitutionKontaktID)
      SELECT TMP.BaInstitutionID,
             TMP.BaPersonID_Betrifft,
             TMP.BaInstitutionKontaktID
      FROM @TmpRelatedInsAndInk TMP
      WHERE TMP.BaPersonID_Betrifft = @BaPersonID;
    
    RETURN;
  END;
  
  -----------------------------------------------------------------------------
  -- 3. institution with contact person exists multiple times and cannot assigned
  --    unequivocal - return all data and let user decide
  -----------------------------------------------------------------------------
  INSERT INTO @Result (BaInstitutionID, BaPersonID_Betrifft, BaInstitutionKontaktID)
    SELECT TMP.BaInstitutionID,
           TMP.BaPersonID_Betrifft,
           TMP.BaInstitutionKontaktID
    FROM @TmpRelatedInsAndInk TMP
    ORDER BY TMP.BaPersonID_Betrifft, TMP.BaInstitutionKontaktID;
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN;
END;
GO
