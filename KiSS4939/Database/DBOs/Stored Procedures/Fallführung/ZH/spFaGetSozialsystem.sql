SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spFaGetSozialsystem
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spFaGetSozialsystem.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 11:17 $
  $Revision: 4 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spFaGetSozialsystem.sql $
 * 
 * 4     11.12.09 11:57 Lloreggia
 * Header aktualisiert
 * 
 * 3     11.11.09 11:26 Mmarghitola
 * #5377: nur aktuelle Personen im Sozialsystem anzeigen
 * 
 * 2     10.03.09 17:58 Rstahel
 * Abgleich der Stored Procedures aus KISS4_MASTER_ZH
=================================================================================================*/

-- ===================================================================================================
-- Create date: ?
-- Description:	StoredProceure für Anzeigen des Sozialsystems
-- wird in CtlAmAbAnspruchsberechnugn verwendet

-- Test examples
-- exec [dbo].[spFaGetSozialsystem] 28808, 47245, NULL
-- exec [dbo].[spFaGetSozialsystem] 100016, 49697, NULL

-- History:
-- 20.09.2007 : sozheo : SQL angepasst für erste Einbindung in DB MASTER_ZH
-- 23.09.2007 : sozheo : Korrektur Leistungsträger "Distinct"
-- 28.09.2007 : sozheo : Neues SQL für Icons bei den Leistungserbringer
-- 28.09.2007 : sozheo : Neues SQL für Icons bei den Klienten
-- 29.09.2007 : sozheo : Rolle korrigiert, HasConnection korrigiert
-- ===================================================================================================


CREATE PROCEDURE [dbo].[spFaGetSozialsystem] (@BaPersonID int, @FaFallID int, @Datum datetime) AS
BEGIN

  -- ------------------------------------------------------------------------------------
  -- Validierung
  -- ------------------------------------------------------------------------------------
  IF( @BaPersonID IS NULL )
  BEGIN
    -- wenn keine person übergeben wurde, suche id von fall
    SELECT @BaPersonID = BaPersonID
    FROM dbo.FaFall WITH (READUNCOMMITTED)
    WHERE FaFallID = @FaFallID
  END

  IF( @Datum IS NULL )
  BEGIN
    -- wenn kein Datum übergeben wurde, verwende heute
    SET @Datum = GetDate()
  END

  -- ------------------------------------------------------------------------------------
  -- Variablen
  -- ------------------------------------------------------------------------------------


  -- ------------------------------------------------------------------------------------
  -- Klienten
  -- ------------------------------------------------------------------------------------

  -- temporäre tabelle für alle personen im klientensystem
  DECLARE @Klienten TABLE
  (
    BaPersonID int
  )

  -- füge aktuelle person des falls ein
  INSERT INTO @Klienten
    SELECT BaPersonID FROM dbo.BaPerson WITH (READUNCOMMITTED) WHERE BaPersonID = @BaPersonID

  -- alle personen des aktuellen falls vom klientensystem ausser der aktuellen person
  INSERT INTO @Klienten
    SELECT BaPersonID FROM dbo.FaFallPerson WITH (READUNCOMMITTED) WHERE FaFallID = @FaFallID AND BaPersonID <> @BaPersonID AND
      (DatumBis IS NULL OR DatumBis > @Datum)

  -- result set 1: Klienten
  SELECT KLI.BaPersonID,
         PRS.Name,
         PRS.Vorname,
         [Alter] = IsNull(dbo.fnGetAge(PRS.Geburtsdatum, IsNull(PRS.Sterbedatum, GetDate())), -1),
         PRS.GeschlechtCode			-- Geschlecht: m=1, w=2
  FROM   @Klienten KLI
  INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = KLI.BaPersonID


  -- ------------------------------------------------------------------------------------
  -- Relationen
  -- ------------------------------------------------------------------------------------

  -- result set 2: Relationen
  SELECT REL.BaRelationID,
         PREL.BaPersonID_1,
         PREL.BaPersonID_2,
         CASE PRSA.GeschlechtCode
           WHEN 1 THEN REL.NameMaennlich1
           WHEN 2 THEN REL.NameWeiblich1
           ELSE REL.NameGenerisch1
         END RelationName1,
         CASE PRSB.GeschlechtCode
           WHEN 1 THEN REL.NameMaennlich2
           WHEN 2 THEN REL.NameWeiblich2
           ELSE REL.NameGenerisch2
         END RelationName2,
         REL.symmetrisch,
         CASE REL.BaRelationID
			WHEN 1 THEN 1 -- Eltern : Kind
			WHEN 4 THEN 2 -- Grosseltern : Enkelkind
			WHEN 5 THEN 1 -- Adoptiveltern : Adoptivkind
			WHEN 6 THEN 1 -- Pflegeltern : Pflegkind
			WHEN 7 THEN 1 -- Stiefeltern : Stiefkind
			WHEN 8 THEN 1 -- Schwiegereltern : Schwiegerkinder
			WHEN 9 THEN 2 -- Schwiegergrosseltern : Schwiegerenkel
			WHEN 10 THEN 1 -- Onkel / Tante : Neffe / Nichte
			WHEN 23 THEN 1 -- Pate / Patin : Patekind
			WHEN 24 THEN 2 -- Stiefgrosseltern : Stiefenkelkind
            ELSE 0
         END AS SymmetricStep,
         Qualitaet = NULL,					-- todo: rename field to BaQualitaetCode --> get string value from LOV
         PREL.Bemerkung
  FROM   ( SELECT PSA.BaPersonID PersonA, PSB.BaPersonID PersonB
           FROM   @Klienten PSA, @Klienten PSB	-- kartesisches produkt: jede person mit jeder (AxB) in temporärer tabelle Klienten
           WHERE PSA.BaPersonID <> PSB.BaPersonID
         ) PRSAB
         LEFT OUTER JOIN dbo.BaPerson_Relation  PREL  WITH (READUNCOMMITTED) ON PREL.BaPersonID_1 = PRSAB.PersonA AND PREL.BaPersonID_2 = PRSAB.PersonB
         LEFT OUTER JOIN dbo.BaRelation         REL   WITH (READUNCOMMITTED) ON REL.BaRelationID = PREL.BaRelationID
         LEFT OUTER JOIN dbo.BaPerson           PRSA  WITH (READUNCOMMITTED) ON PRSA.BaPersonID = PRSAB.PersonA
         LEFT OUTER JOIN dbo.BaPerson           PRSB  WITH (READUNCOMMITTED) ON PRSB.BaPersonID = PRSAB.PersonB
  WHERE  REL.BaRelationID IS NOT NULL AND
         @Datum BETWEEN IsNull(PREL.DatumVon, @Datum) AND IsNull(PREL.DatumBis, @Datum)
  ORDER BY PREL.BaPersonID_1, PREL.BaPersonID_2				-- todo: is this ok?


  -- ------------------------------------------------------------------------------------
  -- Leistungen
  -- ------------------------------------------------------------------------------------

  -- result set 3: Leistungen
  -- 20.09.2007 : sozheo : Korrektur Leistungsträger "Distinct"
/*
  SELECT LEI.FaLeistungID,
         LEI.ModulID,
         ModulStatusCode = CASE WHEN LEI.DatumBis IS NULL THEN 1
                                ELSE CASE WHEN ARC.FaLeistungID IS NULL THEN 2 
                                          ELSE 3 
                                     END
                           END,
         IconID = CASE WHEN LEI.DatumBis IS NULL THEN 1
                       ELSE CASE WHEN ARC.FaLeistungID IS NULL THEN 2 
                                 ELSE 3 
                            END
                  END + 1000 + LEI.ModulID * 100,
         LeistungstraegerID = LEI.BaPersonID,
         USR.UserID,
         [Function] = NULL,	-- todo: new fields from XUser
         USR.FirstName,
         USR.LastName,
         OrgUnit = ORG.ItemName, 
         Contact = ISNULL(USR.Phone, USR.Email)        
  FROM   @Klienten KLI
         INNER JOIN FaLeistung        LEI ON LEI.BaPersonID = KLI.BaPersonID
         LEFT  JOIN FaLeistungArchiv  ARC ON ARC.FaLeistungID = LEI.FaLeistungID AND ARC.CheckOut IS NULL  -- todo: new table FaLeistungArchiv
         INNER JOIN XUser             USR ON USR.UserId = LEI.UserID
         LEFT  JOIN XOrgUnit_User     OUU ON OUU.UserID = USR.UserID AND
									         OUU.OrgUnitMemberCode = 2 AND
									         OUU.OrgUnitID = ( SELECT MAX(OrgUnitID) 
											                   FROM XOrgUnit_User
											                   WHERE UserID = USR.UserID AND OrgUnitMemberCode = 2 )
         LEFT  JOIN XOrgUnit          ORG ON ORG.OrgUnitID = OUU.OrgUnitID
  WHERE @Datum BETWEEN ISNULL(LEI.DatumVon, @Datum) AND ISNULL(LEI.DatumBis, @Datum)
  ORDER BY LeistungstraegerID, LEI.ModulID		-- todo: is this ok?
*/

  DECLARE @FallUserID INT
  SELECT @FallUserID = F.UserID FROM dbo.FaFall F  WITH (READUNCOMMITTED)
  WHERE F.FaFallID = @FaFallID

  SELECT
    USR.UserID,
    [FUNCTION] = NULL,	-- todo: new fields from XUser
    USR.FirstName,
    USR.LastName,
    Contact = IsNull(USR.Phone, USR.EMail),
    OrgUnit = (
      SELECT TOP 1 ORG.ItemName FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
      WHERE ORG.OrgUnitID = (
        SELECT TOP 1 OUU.OrgUnitID FROM dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED)
        WHERE OUU.UserID = USR.UserID
        AND OUU.OrgUnitMemberCode = 2
        ORDER BY OrgUnitID DESC ) ),
      LeistungstraegerID = 0,
      IconID = (
      -- TODO: ? : Geht jetzt wohl nicht mehr
        SELECT TOP 1 CASE
          WHEN L1.DatumBis IS NULL THEN 1
          ELSE CASE WHEN ARC.FaLeistungID IS NULL THEN 2 ELSE 3 END
        END + 1000 + L1.ModulID * 100
        FROM dbo.FaLeistung L1 WITH (READUNCOMMITTED)
        LEFT OUTER JOIN dbo.FaLeistungArchiv ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = L1.FaLeistungID AND ARC.CheckOut IS NULL
        WHERE L1.FaFallID = @FaFallID )
  FROM dbo.XUser USR WITH (READUNCOMMITTED)
  WHERE USR.UserID IN (
    SELECT L.UserID FROM dbo.FaLeistung L WITH (READUNCOMMITTED)
    WHERE L.FaFallID = @FaFallID
    AND L.BaPersonID IN (SELECT BaPersonID FROM @Klienten)
    AND @Datum BETWEEN IsNull(L.DatumVon, @Datum) AND IsNull(L.DatumBis, @Datum)
    -- TODO: ? : LEFT  JOIN FaLeistungArchiv  ARC ON ARC.FaLeistungID = LEI.FaLeistungID AND ARC.CheckOut IS NULL
  )
  ORDER BY (CASE WHEN @FallUserID = USR.UserID THEN 1 ELSE 0 END) DESC,
    USR.LastName + IsNull(' '+USR.FirstName, '') ASC

  -- ------------------------------------------------------------------------------------
  -- Leistungeseinheiten
  -- ------------------------------------------------------------------------------------

  -- result set 4: Leistungeseinheiten
  SELECT LEI.FaLeistungID,
         LEI.BaPersonID,
         IstUnterstuetzt = 0 -- TODO: ISNULL(FIPPRS.IstUnterstuetzt, 1)
  FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
  /*
       INNER JOIN AmFall AMF ON AMF.FaLeistungID = LEI.FaLeistungID
       INNER JOIN AmFall_Person AMFPRS ON AMFPRS.AmFallID = AMF.AmFallID

       INNER JOIN BgFinanzPlan FIP ON FIP.FaLeistungID = LEI.FaLeistungID
       INNER JOIN BgFinanzPlan_BaPerson FIPPRS ON FIPPRS.BgFinanzPlanID = FIP.BgFinanzPlanID

       INNER JOIN IkFall IKF ON IKF.FaLeistungID = LEI.FaLeistungID
       INNER JOIN IkFall_Person IKFPRS ON IKFPRS.IkFallID = IKF.IkFallID
  */

		-- todo: more...
  WHERE LEI.FaFallID = @FaFallID
  /*
        AND 
        @Datum BETWEEN ISNULL(LEI.DatumVon, @Datum) AND ISNULL(LEI.DatumBis, @Datum) AND 
        @Datum BETWEEN ISNULL(FIP.DatumVon, @Datum) AND ISNULL(FIP.DatumBis, @Datum)
  */


  -- ------------------------------------------------------------------------------------
  -- Involvierte Personen
  -- ------------------------------------------------------------------------------------
    -- result set 5: Involvierte Personen
  SELECT IVP.BaPersonID,
         HasConnection = CASE WHEN IVP.BaPersonID IS NULL THEN 0 ELSE 1 END,
         IVP.Name,
         IVP.Vorname,
         IVP.GeschlechtCode,
         Rolle = IsNull(IVP.RolleBemerkung,dbo.fnLOVText('BaRolle', IVP.RolleCode)),
         Contact = '-> ' + IsNull(PRS.Vorname + ' ','') + PRS.Name,
/*
         Rolle = CASE 
           WHEN IVP.RolleCode IS NULL THEN IVP.RolleBemerkung
           WHEN IVP.RolleBemerkung IS NULL THEN dbo.fnLOVText('BaRolle', IVP.RolleCode)
           ELSE IVP.RolleBemerkung + ISNULL(', '+dbo.fnLOVText('BaRolle', IVP.RolleCode), '')
         END,
         Contact = COALESCE(IVP.Telefon_P, IVP.Telefon_G, IVP.MobilTel1, IVP.MobilTel2, IVP.Email),
*/
         IVP.Bemerkung
  FROM   dbo.FaInvolviertePerson IVP WITH (READUNCOMMITTED)
         LEFT OUTER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = IVP.BaPersonID
  WHERE  IVP.FaFallID = @FaFallID AND
         @Datum BETWEEN IsNull(IVP.DatumVon, @Datum) AND IsNull(IVP.DatumBis, @Datum)
  ORDER BY HasConnection DESC


  -- ------------------------------------------------------------------------------------
  -- Involvierte Stellen
  -- ------------------------------------------------------------------------------------
    -- result set 6: Involvierte Stellen
  SELECT IVI.BaPersonID,
         HasConnection = CASE WHEN IVI.BaPersonID IS NULL THEN 0 ELSE 1 END,
         INS.Name,
         ADR.PLZ,
         ADR.Ort,
         IVI.Ansprechperson,
         Contact = '-> ' + IsNull(PRS.Vorname + ' ','') + PRS.Name,
--         Contact = ISNULL(IVI.AnsprechpersonTelefon, ISNULL(IVI.AnsprechpersonEmail, NULL)),
         IVI.Bemerkung
  FROM   dbo.FaInvolvierteInstitution IVI WITH (READUNCOMMITTED)
         INNER JOIN dbo.BaInstitution INS WITH (READUNCOMMITTED) ON INS.BaInstitutionID = IVI.BaInstitutionID
         LEFT  JOIN dbo.BaAdresse     ADR WITH (READUNCOMMITTED) ON ADR.BaInstitutionID = INS.BaInstitutionID
         LEFT JOIN dbo.BaPerson       PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = IVI.BaPersonID
  WHERE  IVI.FaFallID = @FaFallID AND
         @Datum BETWEEN IsNull(IVI.DatumVon, @Datum) AND IsNull(IVI.DatumBis, @Datum)
  ORDER BY HasConnection DESC


  -- ------------------------------------------------------------------------------------
  -- Icons bei den Klienten
  -- ------------------------------------------------------------------------------------
  -- 28.09.2007 : sozheo : Icons für die Klienten
  SELECT DISTINCT
    BaPersonID = IsNull(LEI.SchuldnerBaPersonID,KLI.BaPersonID),
    IconID = CASE
      WHEN LEI.DatumBis IS NULL THEN 1
      WHEN ARC.FaLeistungID IS NULL THEN 2
      ELSE 3
    END + 1000 + LEI.ModulID * 100
  FROM @Klienten KLI
    INNER JOIN dbo.FaLeistung         LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = KLI.BaPersonID
    LEFT OUTER JOIN dbo.FaLeistungArchiv    ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = LEI.FaLeistungID AND
                                         ARC.CheckOut IS NULL  -- todo: new table FaLeistungArchiv
  WHERE @Datum BETWEEN IsNull(LEI.DatumVon, @Datum) AND IsNull(LEI.DatumBis, @Datum)

  UNION

  -- FallPersonen
  SELECT
    FAP.BaPersonID,
    IconID = CASE
      WHEN LEI.DatumBis IS NULL THEN 1
      WHEN ARC.FaLeistungID IS NULL THEN 2
      ELSE 3
    END + 1000 + LEI.ModulID * 100
  FROM @Klienten KLI
    INNER JOIN dbo.FaLeistung           LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = KLI.BaPersonID AND
                                           LEI.FaProzessCode = 200

    LEFT JOIN dbo.FaLeistungArchiv      ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = LEI.FaLeistungID AND
                                           ARC.CheckOut IS NULL  -- todo: new table FaLeistungArchiv
    LEFT JOIN dbo.FaFallPerson          FAP WITH (READUNCOMMITTED) ON FAP.FaFallID = LEI.FaFallID AND
                                           FAP.BaPersonID NOT in (SELECT DISTINCT IsNull(SchuldnerBaPersonID,0)
                                                                  FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                                                                  WHERE FaFallID = LEI.FaFallID)
  WHERE @Datum BETWEEN IsNull(LEI.DatumVon, @Datum) AND IsNull(LEI.DatumBis, @Datum) AND
        FAP.BaPersonID IS NOT NULL

  UNION

  -- WH: Personen im Haushalt
  SELECT DISTINCT
    FPP.BaPersonID,
    IconID = CASE
      WHEN LEI.DatumBis IS NULL THEN 1
      WHEN ARC.FaLeistungID IS NULL THEN 2
      ELSE 3
    END + 1000 + LEI.ModulID * 100
  FROM @Klienten KLI
    INNER JOIN dbo.FaLeistung           LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = KLI.BaPersonID
    LEFT OUTER JOIN dbo.FaLeistungArchiv      ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = LEI.FaLeistungID AND
                                           ARC.CheckOut IS NULL  -- todo: new table FaLeistungArchiv
    LEFT OUTER JOIN dbo.BgFinanzplan          FPL WITH (READUNCOMMITTED) ON FPL.FaLeistungID = LEI.FaLeistungID AND
                                           FPL.BgBewilligungStatusCode in (5,9) AND
                                           @Datum BETWEEN FPL.DatumVon AND IsNull(FPL.DatumBis, @Datum)
    LEFT OUTER JOIN dbo.BgFinanzplan_BaPerson FPP WITH (READUNCOMMITTED) ON FPP.BgFinanzplanID = FPL.BgFinanzplanID AND
                                           FPP.BaPersonID <> LEI.BaPersonID

  WHERE @Datum BETWEEN IsNull(LEI.DatumVon, @Datum) AND IsNull(LEI.DatumBis, @Datum) AND
        FPP.BaPersonID IS NOT NULL

  UNION

  -- Gläubiger
  SELECT DISTINCT
    GLA.BaPersonID,
    IconID = CASE
      WHEN LEI.DatumBis IS NULL THEN 1
      WHEN ARC.FaLeistungID IS NULL THEN 2
      ELSE 3
    END + 1000 + LEI.ModulID * 100
  FROM @Klienten KLI
    INNER JOIN dbo.FaLeistung           LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = KLI.BaPersonID
    LEFT OUTER JOIN dbo.FaLeistungArchiv      ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = LEI.FaLeistungID AND
                                           ARC.CheckOut IS NULL  -- todo: new table FaLeistungArchiv
    LEFT OUTER JOIN dbo.IkRechtstitel         RTI WITH (READUNCOMMITTED) ON RTI.FaLeistungID = LEI.FaLeistungID AND
                                           @Datum BETWEEN RTI.IkRechtstitelGueltigVon AND IsNull(RTI.IkRechtstitelGueltigBis, @Datum)
    LEFT OUTER JOIN dbo.IkGlaeubiger          GLA WITH (READUNCOMMITTED) ON GLA.IkRechtstitelID = RTI.IkRechtstitelID

  WHERE @Datum BETWEEN IsNull(LEI.DatumVon, @Datum) AND IsNull(LEI.DatumBis, @Datum) AND
        GLA.BaPersonID IS NOT NULL

  ORDER BY 1, 2 ASC

  -- ------------------------------------------------------------------------------------
  -- Icons bei den Leistungserbringer
  -- ------------------------------------------------------------------------------------
  -- 28.09.2007 : sozheo : Icons für die Leistungserbringer
  -- Dieses SQL kann verwendet werden, um die einzelnen Leistungen unterhalb des 
  -- Tree-Eintrags "Sozialsystem" darzustellen
  /*
  SELECT 
    LEI.UserID,
    LEI.BaPersonID,
    LEI.FaLeistungID,
    LEI.ModulID,
    ModulStatusCode = CASE 
      WHEN LEI.DatumBis IS NULL THEN 1
      WHEN ARC.FaLeistungID IS NULL THEN 2 
      ELSE 3 
    END,
    IconID = CASE 
      WHEN LEI.DatumBis IS NULL THEN 1
      WHEN ARC.FaLeistungID IS NULL THEN 2 
      ELSE 3 
    END + 1000 + LEI.ModulID * 100
  FROM @Klienten KLI
    INNER JOIN FaLeistung LEI ON LEI.BaPersonID = KLI.BaPersonID
    LEFT JOIN FaLeistungArchiv ARC ON ARC.FaLeistungID = LEI.FaLeistungID 
      AND ARC.CheckOut IS NULL  -- todo: new table FaLeistungArchiv
  WHERE @Datum BETWEEN ISNULL(LEI.DatumVon, @Datum) AND ISNULL(LEI.DatumBis, @Datum)
  ORDER BY LEI.UserID, LEI.BaPersonID, 6 ASC
  */

  SELECT DISTINCT
    LEI.UserID,
    IconID = CASE
      WHEN LEI.DatumBis IS NULL THEN 1
      WHEN ARC.FaLeistungID IS NULL THEN 2
      ELSE 3
    END + 1000 + LEI.ModulID * 100
  FROM @Klienten KLI
    INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = KLI.BaPersonID
    LEFT OUTER JOIN dbo.FaLeistungArchiv ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = LEI.FaLeistungID
      AND ARC.CheckOut IS NULL  -- todo: new table FaLeistungArchiv
  WHERE @Datum BETWEEN IsNull(LEI.DatumVon, @Datum) AND IsNull(LEI.DatumBis, @Datum)
  ORDER BY LEI.UserID, 2 ASC


  -- ------------------------------------------------------------------------------------
  -- Alle Beziehungen Leistungserbringer - Klient
  -- ------------------------------------------------------------------------------------
  -- 28.09.2007 : sozheo : Icons für die Leistungserbringer
  SELECT DISTINCT
    LEI.UserID,
    BaPersonID = IsNull(LEI.SchuldnerBaPersonID,KLI.BaPersonID)
  FROM @Klienten KLI
    INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = KLI.BaPersonID
    LEFT OUTER JOIN dbo.FaLeistungArchiv ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = LEI.FaLeistungID
      AND ARC.CheckOut IS NULL  -- todo: new table FaLeistungArchiv
  WHERE @Datum BETWEEN IsNull(LEI.DatumVon, @Datum) AND IsNull(LEI.DatumBis, @Datum)

  UNION

  -- WH: Personen im Haushalt
  SELECT DISTINCT
    LEI.UserID,
    FPP.BaPersonID
  FROM @Klienten KLI
    INNER JOIN dbo.FaLeistung           LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = KLI.BaPersonID
    LEFT OUTER JOIN dbo.FaLeistungArchiv      ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = LEI.FaLeistungID AND
                                           ARC.CheckOut IS NULL  -- todo: new table FaLeistungArchiv
    LEFT OUTER JOIN dbo.BgFinanzplan          FPL WITH (READUNCOMMITTED) ON FPL.FaLeistungID = LEI.FaLeistungID AND
                                           FPL.BgBewilligungStatusCode in (5,9) AND
                                           @Datum BETWEEN FPL.DatumVon AND IsNull(FPL.DatumBis, @Datum)
    LEFT OUTER JOIN dbo.BgFinanzplan_BaPerson FPP WITH (READUNCOMMITTED) ON FPP.BgFinanzplanID = FPL.BgFinanzplanID AND
                                           FPP.BaPersonID <> LEI.BaPersonID

  WHERE @Datum BETWEEN IsNull(LEI.DatumVon, @Datum) AND IsNull(LEI.DatumBis, @Datum) AND
        FPP.BaPersonID IS NOT NULL

  UNION

  -- Gläubiger
  SELECT DISTINCT
    LEI.UserID,
    GLA.BaPersonID
  FROM @Klienten KLI
    INNER JOIN dbo.FaLeistung           LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = KLI.BaPersonID
    LEFT OUTER JOIN dbo.FaLeistungArchiv      ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = LEI.FaLeistungID AND
                                           ARC.CheckOut IS NULL  -- todo: new table FaLeistungArchiv
    LEFT OUTER JOIN dbo.IkRechtstitel         RTI WITH (READUNCOMMITTED) ON RTI.FaLeistungID = LEI.FaLeistungID AND
                                           @Datum BETWEEN RTI.IkRechtstitelGueltigVon AND IsNull(RTI.IkRechtstitelGueltigBis, @Datum)
    LEFT OUTER JOIN dbo.IkGlaeubiger          GLA WITH (READUNCOMMITTED) ON GLA.IkRechtstitelID = RTI.IkRechtstitelID

  WHERE @Datum BETWEEN IsNull(LEI.DatumVon, @Datum) AND IsNull(LEI.DatumBis, @Datum) AND
        GLA.BaPersonID IS NOT NULL

  ORDER BY 1,2
END
