SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spFaGetSozialsystem
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spFaGetSozialsystem.sql $
  $Author: Ckaeser $
  $Modtime: 12.08.09 14:22 $
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spFaGetSozialsystem.sql $
 * 
 * 6     12.08.09 14:27 Ckaeser
 * #4932 Alter2Create Bereinigung DBO's
 * 
 * 5     3.08.09 11:15 Nweber
 * 
 * 2     18.12.08 9:41 Lgreulich
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/

/*
  KiSS 4.0
  --------
  DB-Object: spFaGetSozialsystem
  Branch   : KiSS_PROD
  BuildNr  : 1
  Datum    : 24.06.2008 14:54
*/
-- ===================================================================================================
-- Create date: ?
-- Description:	StoredProceure für Anzeigen des Sozialsystems

-- Test examples
-- select * from BaPerson where name like 'Dagdas%'
-- Test Dagdaas Esma
-- exec [dbo].[spFaGetSozialsystem] 4707
-- Test Dagdaas Esma
-- exec [dbo].[spFaGetSozialsystem] 5065

-- History:
-- 09.11.2007 : RH : SQL von BE übernommen
-- 21.11.2007 : RH : SQL Teil 4 angepasst
-- ===================================================================================================

CREATE PROCEDURE dbo.spFaGetSozialsystem (@BaPersonID int) AS
BEGIN
  DECLARE @Person TABLE (
    BaPersonID int
  )

  INSERT INTO @Person
  SELECT BaPersonID FROM dbo.BaPerson WITH (READUNCOMMITTED) WHERE BaPersonID = @BaPersonID

  -- get all persons of sozialsystem
  WHILE @@rowcount > 0 BEGIN

    INSERT @Person
    SELECT DISTINCT PR.BaPersonID_1
    FROM @Person P
      INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = P.BaPersonID
      INNER JOIN dbo.BaPerson_Relation PR WITH (READUNCOMMITTED) ON PR.BaPersonID_2 = P.BaPersonID
      LEFT  JOIN @Person X ON X.BaPersonID = PR.BaPersonID_1
    WHERE  X.BaPersonID IS NULL AND
           IsNull(PRS.Fiktiv,0) = 0
    UNION
    SELECT DISTINCT PR.BaPersonID_2
    FROM @Person P
      INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = P.BaPersonID
      INNER JOIN dbo.BaPerson_Relation PR WITH (READUNCOMMITTED) ON PR.BaPersonID_1 = P.BaPersonID
      LEFT  JOIN @Person X ON X.BaPersonID = PR.BaPersonID_2
    WHERE  X.BaPersonID IS NULL AND
           IsNull(PRS.Fiktiv,0) = 0

  END

  -- result set 1: Person
  SELECT P.BaPersonID, PRS.Name, PRS.Vorname, PRS.Geburtsdatum, PRS.GeschlechtCode
  FROM @Person P
  INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = P.BaPersonID

  -- result set 1: Relation
  SELECT R.BaRelationID,PR.BaPersonID_1,PR.BaPersonID_2,
    CASE PA.GeschlechtCode
      WHEN 1 THEN R.NameMaennlich1
      WHEN 2 THEN R.NameWeiblich1
      ELSE R.NameGenerisch1
    END RelationName1,
    CASE PB.GeschlechtCode
      WHEN 1 THEN R.NameMaennlich2
      WHEN 2 THEN R.NameWeiblich2
      ELSE R.NameGenerisch2
    END RelationName2,
    CASE
      WHEN R.BaRelationID in (1,2,4,5,6,7,8,9,13,14,15,24) THEN 1
      WHEN R.BaRelationID in (3,10,11,12,16,17,23,28,30,31) THEN 2
      WHEN R.BaRelationID in (18,19,20,21,22,25,26,27,29,32) THEN 3
      ELSE 4
    END RelationPriority,
    symmetrisch
  FROM (
    SELECT A.BaPersonID PersonA, B.BaPersonID PersonB
    FROM  @Person A, @Person B -- cartesian
    WHERE A.BaPersonID <> B.BaPersonID) X
    LEFT JOIN dbo.BaPerson_Relation PR WITH (READUNCOMMITTED) ON PR.BaPersonID_1 = X.PersonA 
      AND PR.BaPersonID_2 = X.PersonB
    LEFT JOIN dbo.BaRelation R WITH (READUNCOMMITTED) ON R.BaRelationID = PR.BaRelationID
    LEFT JOIN dbo.BaPerson PA WITH (READUNCOMMITTED) ON PA.BaPersonID = X.PersonA
    LEFT JOIN dbo.BaPerson PB WITH (READUNCOMMITTED) ON PB.BaPersonID = X.PersonB
  WHERE  R.BaRelationID IS NOT NULL

  -- result set 3: Fall
  SELECT
    FAL.FaLeistungID,
    FAL.ModulID,
    ModulStatusCode = CASE
      WHEN FAL.DatumBis IS NULL THEN 1
      ELSE CASE WHEN ARC.FaLeistungID IS NULL THEN 2 ELSE 3 END
    END,
    FAL.BaPersonID Falltraeger,
    MA.UserID,
    MA.FirstName,
    MA.LastName,
    MA.LogonName
  FROM @Person P
         INNER JOIN dbo.FaLeistung       FAL WITH (READUNCOMMITTED) ON FAL.BaPersonID = P.BaPersonID
         LEFT  JOIN dbo.FaLeistungArchiv ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = FAL.FaLeistungID 
    AND ARC.CheckOut IS NULL
  INNER JOIN dbo.XUser MA WITH (READUNCOMMITTED) ON MA.UserID = FAL.UserID

  -- result set 4: FallPerson
  SELECT
    FAL.FaLeistungID,
    X.BaPersonID,
    FPP.IstUnterstuetzt
  FROM   @Person P
    INNER JOIN dbo.FaLeistung            FAL WITH (READUNCOMMITTED) ON FAL.BaPersonID = P.BaPersonID 
      AND FAL.ModulID = 3 -- Sozialhilfe
    INNER JOIN dbo.BgFinanzplan          FPL WITH (READUNCOMMITTED) ON FPL.FaLeistungID = FAL.FaLeistungID 
      AND GetDate() BETWEEN FPL.DatumVon
      AND IsNull(FPL.DatumBis,GetDate())
    INNER JOIN dbo.BgFinanzplan_BaPerson FPP WITH (READUNCOMMITTED) ON FPP.BgFinanzplanID = FPL.BgFinanzplanID
    INNER JOIN @Person                     X ON X.BaPersonID = FPP.BaPersonID
  WHERE P.BaPersonID <> X.BaPersonID
  UNION
  SELECT FAL.FaLeistungID,
         X.BaPersonID,
         IstUnterstuetzt = 0
  FROM   @Person P
         INNER JOIN dbo.FaLeistung   FAL WITH (READUNCOMMITTED) ON FAL.BaPersonID = P.BaPersonID 
           AND FAL.ModulID = 4 -- Inkasso
         INNER JOIN dbo.IkGlaeubiger GLA WITH (READUNCOMMITTED) ON GLA.FaLeistungID = FAL.FaLeistungID
         INNER JOIN @Person          X   ON X.BaPersonID = GLA.BaPersonID

  ORDER BY 1,2

END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
