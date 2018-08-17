SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spKaGetStatistikQJ;
GO
/*===============================================================================================
  $Revision: 14 $
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
CREATE PROCEDURE dbo.spKaGetStatistikQJ
(
  @DatumVon DATETIME,
  @DatumBis DATETIME,
  @NiveauCode INT,
  @auswZuweiser INT,
  @APVCode INT,
  @APVZusatzCode INT,
  @Rohdaten BIT
)
AS
BEGIN
  SET NOCOUNT ON
  
  DECLARE @tmp TABLE 
  (
    ID             INT IDENTITY,
    FaLeistungID   INT,
    BaPersonID     INT,
    [Alter]        INT,
    FachbereichID  INT,
    NiveauCode     INT,
    [Finanzierende Stelle] VARCHAR(200),
    Fallfuehrung    VARCHAR(200),
    [Zuweisende Stelle] VARCHAR(200),
    EintrittDatum  DATETIME,
    AustrittDatum  DATETIME,
    Austrittgrund  VARCHAR(200), -- KaQjGrundProgEnde
    GrundAbbruch   VARCHAR(200), -- KaQjGrundProgAbbruch
    Einsatzdauer   INT,
    Geschlecht     INT,
    Vorbildung     VARCHAR(200),
    Erstsprache    VARCHAR(200),
    Hauptsprache   VARCHAR(200),
    toDelete       BIT DEFAULT(0) 
    PRIMARY KEY (ID)
  );
  

  


  INSERT INTO @tmp (FaLeistungID, 
                    BaPersonID, 
                    [Alter], 
                    FachbereichID, 
                    NiveauCode, 
                    [Finanzierende Stelle],
                    Fallfuehrung, 
                    [Zuweisende Stelle],
                    EintrittDatum, 
                    AustrittDatum, 
                    Austrittgrund, 
                    GrundAbbruch, 
                    Geschlecht, 
                    Vorbildung, 
                    Erstsprache, 
                    Hauptsprache)
  SELECT FaLeistungID   = LEI.FaLeistungID,
         BaPersonID     = LEI.BaPersonID,
         [Alter]        = dbo.fnGetAge(PRS.Geburtsdatum, CONVERT(DATETIME, '01.01.' + CONVERT(VARCHAR, Year(@DatumBis)), 104)),
         FachbereichID  = KZF.FachbereichID, 
         NiveauCode     = KZF.NiveauCode,
         [Finanzierende Stelle] = CASE 
                                    WHEN EIN.ZuweiserID < 0 THEN ISNULL(XOE.ItemName, '') + ' (' + VUE.NameVorname + ')' 
                                    ELSE ISNULL(ORE.[Name], '') + ' (' + OKE.Name + ISNULL(', ' + OKE.Vorname, '') + ')'
                                  END,
         Fallfuehrung    = CASE 
                            WHEN KPZ.FallfuehrungID < 0 THEN ISNULL(XOU.ItemName, '') + ' (' + VUU.NameVorname + ')' 
                            ELSE ISNULL(ORU.[Name], '') + ' (' + OKU.Name + ISNULL(', ' + OKU.Vorname, '') + ')'
                          END,
         [Zuweisende Stelle] = CASE 
                                    WHEN QJI.ZuweiserID < 0 THEN ISNULL(XOI.ItemName, '') + ' (' + VUI.NameVorname + ')' 
                                    ELSE ISNULL(ORI.[Name], '') + ' (' + OKI.Name + ISNULL(', ' + OKI.Vorname, '') + ')'
                                  END,
         EintrittDatum  = EIN.DatumVon,
         AustrittDatum  = KPZ.ProgEnde,
         Austrittgrund  = CASE 
                            WHEN KPZ.ProgEnde IS NULL THEN  '' 
                            ELSE CASE 
                                   WHEN dbo.fnDateOf(KPZ.ProgEnde) <= dbo.fnDateOf(@DatumBis) THEN CASE KPZ.ProgEndeGrund
                                                                                                     WHEN 1 THEN dbo.fnLOVText('KaQjGrundProgEnde', KPZ.ProgEndeCode)
                                                                                                     WHEN 2 THEN 'Arbeitgeber Abbruch'
                                                                                                     WHEN 3 THEN 'Arbeitnehmer Abbruch'
                                                                                                     WHEN 4 THEN 'Gegenseitiger Abbruch'
                                                                                                     ELSE ''
                                                                                                   END
                                 END   
                          END,
         GrundAbbruch   = CASE 
                            WHEN KPZ.ProgEnde IS NULL THEN '' 
                            ELSE CASE 
                                   WHEN dbo.fnDateOf(KPZ.ProgEnde) <= dbo.fnDateOf(@DatumBis) THEN dbo.fnLOVText('KaQjGrundProgAbbruch', KPZ.AbbruchCode)
                                   ELSE '' 
                                 END
                          END,
         Geschlecht     = PRS.GeschlechtCode,
         Vorbildung     = dbo.fnLOVText('KaAusbildungVorbildung', KA.KaAusbildungVorbildungCode),
         Erstsprache    = dbo.fnLOVText('KaQjIntakeSprache', QJI.KaQjIntakeSpracheCode_Erstsprache),
         Hauptsprache   = dbo.fnLOVText('KaQjIntakeSprache', QJI.KaQjIntakeSpracheCode_Hauptsprache)
  FROM dbo.FaLeistung                  LEI WITH (READUNCOMMITTED) 
    LEFT JOIN dbo.KaQJProzess          KPZ WITH (READUNCOMMITTED) ON KPZ.FaLeistungID = LEI.FaLeistungID
    INNER JOIN dbo.KaEinsatz           EIN WITH (READUNCOMMITTED) ON EIN.FaLeistungID = LEI.FaLeistungID
    LEFT JOIN dbo.KaEinsatzplatz2      EIP WITH (READUNCOMMITTED) ON EIN.KaEinsatzplatzID = EIP.KaEinsatzplatzID
    INNER JOIN dbo.vwPerson            PRS ON PRS.BaPersonID = LEI.BaPersonID
    LEFT  JOIN dbo.KaZuteilFachbereich KZF WITH (READUNCOMMITTED) ON KZF.BaPersonID = LEI.BaPersonID
                                                                 AND KZF.KaZuteilFachbereichID = (SELECT TOP 1 KaZuteilFachbereichID
                                                                                                  FROM dbo.KaZuteilFachbereich WITH (READUNCOMMITTED)
                                                                                                  WHERE BaPersonID = LEI.BaPersonID
                                                                                                    AND ZuteilungVon BETWEEN dbo.fnDateOf(LEI.DatumVon) 
                                                                                                                         AND dbo.fnDateOf(ISNULL(LEI.DatumBis, @DatumBis))

                                                                                                  ORDER BY ZuteilungVon DESC) 
    /*[Finanzierende Stelle]*/
    LEFT JOIN dbo.vwUser               VUE WITH (READUNCOMMITTED) ON VUE.UserID = -EIN.ZuweiserID
    LEFT JOIN dbo.XOrgUnit_User        OUE WITH (READUNCOMMITTED) ON OUE.UserID = -EIN.ZuweiserID
                                                                 AND (OUE.OrgUnitMemberCode = 1 OR OUE.OrgUnitMemberCode = 2)      
    LEFT JOIN dbo.XOrgUnit             XOE WITH (READUNCOMMITTED) ON XOE.OrgUnitID = OUE.OrgUnitID
    LEFT JOIN dbo.BaInstitutionKontakt OKE WITH (READUNCOMMITTED) ON OKE.BaInstitutionKontaktID = EIN.ZuweiserID
    LEFT JOIN dbo.BaInstitution        ORE WITH (READUNCOMMITTED) ON ORE.BaInstitutionID = OKE.BaInstitutionID
    /*Institution*/                                                                                            
    LEFT JOIN dbo.vwUser               VUU WITH (READUNCOMMITTED) ON VUU.UserID = -KPZ.FallfuehrungID
    LEFT JOIN dbo.XOrgUnit_User        OUU WITH (READUNCOMMITTED) ON OUU.UserID = -KPZ.FallfuehrungID
                                                                 AND (OUU.OrgUnitMemberCode = 1 OR OUU.OrgUnitMemberCode = 2)
    LEFT JOIN dbo.XOrgUnit             XOU WITH (READUNCOMMITTED) ON XOU.OrgUnitID = OUU.OrgUnitID
    LEFT JOIN dbo.BaInstitutionKontakt OKU WITH (READUNCOMMITTED) ON OKU.BaInstitutionKontaktID = KPZ.FallfuehrungID
    LEFT JOIN dbo.BaInstitution        ORU WITH (READUNCOMMITTED) ON ORU.BaInstitutionID = OKU.BaInstitutionID
    /*Zuweisende Stelle*/ 
    LEFT JOIN dbo.KaQJIntake           QJI WITH (READUNCOMMITTED) ON QJI.FaLeistungID = LEI.FaLeistungID
    LEFT JOIN dbo.vwUser               VUI WITH (READUNCOMMITTED) ON VUI.UserID = -QJI.ZuweiserID
    LEFT JOIN dbo.XOrgUnit_User        OUI WITH (READUNCOMMITTED) ON OUI.UserID = -QJI.ZuweiserID
                                                                 AND (OUI.OrgUnitMemberCode = 1 OR OUI.OrgUnitMemberCode = 2)
    LEFT JOIN dbo.XOrgUnit             XOI WITH (READUNCOMMITTED) ON XOI.OrgUnitID = OUI.OrgUnitID
    LEFT JOIN dbo.BaInstitutionKontakt OKI WITH (READUNCOMMITTED) ON OKI.BaInstitutionKontaktID = QJI.ZuweiserID
    LEFT JOIN dbo.BaInstitution        ORI WITH (READUNCOMMITTED) ON ORI.BaInstitutionID = OKI.BaInstitutionID                                                                                               
    
    
    
    LEFT JOIN ( SELECT KAK.KaAusbildungVorbildungCode, LEIK.BaPersonID
                FROM dbo.KaAusbildung KAK
                INNER JOIN dbo.FaLeistung LEIK ON LEIK.FaLeistungID = KAK.FaLeistungID
                WHERE KaAusbildungVorbildungCode IS NOT NULL) KA ON KA.BaPersonID = LEI.BaPersonID
    
  WHERE LEI.ModulID = 7              -- KA
    AND LEI.FaProzessCode = 703      -- QJ
    AND EIN.AnweisungCode IN (2, 3, 4) -- 2 = Anweisung, 3 = Verlängerung, 4 = Einsatz ohne Anweisung
    AND dbo.fnDateOf(EIN.DatumVon) <= dbo.fnDateOf(@DatumBis)
    AND dbo.fnDateOf(ISNULL(KPZ.ProgEnde, @DatumBis)) >= dbo.fnDateOf(@DatumVon) --dbo.fnDateOf(ISNULL(KPZ.ProgEnde, EIN.DatumBis)) >= dbo.fnDateOf(@DatumVon)
    AND (@NiveauCode IS NULL OR NiveauCode = @NiveauCode)
    AND (@APVCode IS NULL OR EIP.APVCode = @APVCode)
    AND (@APVZusatzCode IS NULL OR EIN.APVZusatzCode = @APVZusatzCode);
  
  -- Update rows, create one row with data from all Anweisungen for one FaLeistungID!
  DECLARE @actID INT;
  DECLARE @actFaLeistungID INT;
  DECLARE @actAustrittDatum DATETIME;
  DECLARE @actFachbereichID INT;
  DECLARE @actNiveauCode INT;
  DECLARE @prevID INT;
  DECLARE @prevFaLeistungID INT;
  DECLARE @actAustrittgrund VARCHAR(200);
  DECLARE @actGrundAbbruch  VARCHAR(200);
  
  SET @prevID = -1;
  SET @prevFaLeistungID = -1;
  
  DECLARE cur CURSOR FOR
    SELECT ID, FaLeistungID, AustrittDatum, FachbereichID, NiveauCode, Austrittgrund, GrundAbbruch
    FROM @tmp
    ORDER BY FaLeistungID, EintrittDatum ASC;

  OPEN cur
  FETCH NEXT FROM cur INTO @actID, @actFaLeistungID, @actAustrittDatum, @actFachbereichID, @actNiveauCode, @actAustrittgrund, @actGrundAbbruch
  
  WHILE (@@FETCH_STATUS = 0)
  BEGIN
    IF (@actFaLeistungID > 0)
    BEGIN
      IF (@actFaLeistungID = @prevFaLeistungID)
      BEGIN
        UPDATE @tmp
        SET AustrittDatum = @actAustrittDatum,
            FachbereichID = @actFachbereichID,
            NiveauCode    = @actNiveauCode,
            Austrittgrund = @actAustrittgrund,
            GrundAbbruch  = @actGrundAbbruch
        WHERE ID = @prevID;
      
        UPDATE @tmp
        SET toDelete = 1 
        WHERE ID = @actID
      END
      ELSE BEGIN
        SET @prevID = @actID
      END;

      SET @prevFaLeistungID = @actFaLeistungID
    END;

    FETCH NEXT FROM cur INTO @actID, @actFaLeistungID, @actAustrittDatum, @actFachbereichID, @actNiveauCode, @actAustrittgrund, @actGrundAbbruch;
  END;
  CLOSE cur;
  DEALLOCATE cur;

  -- Delete not used rows in @tmp
  DELETE FROM @tmp
  WHERE toDelete = 1;

  -- Delete rows not matching search criteria
  -- 1 = RAV, 2 = SD Bern, 3 = alle SD exkl. SD Bern
  IF (@auswZuweiser = 1)
  BEGIN
    DELETE FROM @tmp
    WHERE [Finanzierende Stelle] NOT LIKE 'RAV%';
  END
  ELSE IF (@auswZuweiser = 2)
  BEGIN
    DELETE FROM @tmp
    WHERE [Finanzierende Stelle] NOT IN (
      SELECT ItemName
      FROM dbo.XOrgUnit WITH (READUNCOMMITTED)
      WHERE ParentID = 30
         OR OrgUnitID = 30
         OR ParentID IN (SELECT OrgUnitID
                         FROM dbo.XOrgUnit WITH (READUNCOMMITTED)
                         WHERE ParentID = 30));
  END
  ELSE IF (@auswZuweiser = 3)
  BEGIN
    DELETE FROM @tmp
    WHERE [Finanzierende Stelle] IN (SELECT ItemName
                          FROM dbo.XOrgUnit WITH (READUNCOMMITTED)
                          WHERE ParentID = 30
                             OR OrgUnitID = 30
                             OR ParentID IN (SELECT OrgUnitID
                                             FROM dbo.XOrgUnit WITH (READUNCOMMITTED)
                                             WHERE ParentID = 30))
       OR [Finanzierende Stelle] LIKE 'RAV%';
  END;

  -- Calculate Einsatzdauer in each row
  UPDATE @tmp
  SET Einsatzdauer = 
      CONVERT(INT,
        ROUND(
          (CONVERT(FLOAT, DateDiff(DAY, EintrittDatum, AustrittDatum)) / CONVERT(FLOAT, 30))
          , 0 
        )
      )
  WHERE AustrittDatum IS NOT NULL;

  -- 0 = Statistik, 1 = Rohdaten 
  IF (@Rohdaten = 0)
  BEGIN
    -- declare table for result-set  
    DECLARE @rslt TABLE 
    (
      ID          int identity,
      Bezeichnung varchar(500),
      Anzahl      float
      primary key (ID)
    );

    -- Anzahl Teilnehmende total
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT 'Anzahl Teilnehmende total', COUNT(*)
      FROM @tmp;

    -- Anzahl männliche Teilnehmende
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT 'Anzahl männliche Teilnehmende', COUNT(*)
      FROM @tmp
      WHERE Geschlecht = 1;

    -- Anzahl weibliche Teilnehmende
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT 'Anzahl weibliche Teilnehmende', COUNT(*)
      FROM @tmp
      WHERE Geschlecht = 2;
  
    -- Niveau
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT dbo.fnLOVText('KaQjNiveau', NiveauCode), COUNT(*)
      FROM @tmp
      WHERE NiveauCode IS NOT NULL
      GROUP BY NiveauCode
      ORDER BY NiveauCode;

    -- Fachbereich
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT dbo.fnLOVText('KAFachbereich', FachbereichID), COUNT(*)
      FROM @tmp
      WHERE NiveauCode IS NOT NULL
      GROUP BY FachbereichID
      ORDER BY FachbereichID;
  
    -- Leerzeile
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT '', NULL;
  
    -- Zuweiser RAV
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT 'Zuweiser RAV', COUNT(*)
      FROM @tmp
      WHERE [Finanzierende Stelle] LIKE 'RAV%';
  
    -- Zuweiser Sozialdienst Bern
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT 'Zuweiser Sozialdienst Bern', COUNT(*)
      FROM @tmp
      WHERE [Finanzierende Stelle] IN (
          SELECT ItemName
          FROM dbo.XOrgUnit WITH (READUNCOMMITTED)
          WHERE ParentID = 30
             OR OrgUnitID = 30
             OR ParentID IN (SELECT OrgUnitID
                             FROM dbo.XOrgUnit WITH (READUNCOMMITTED)
                             WHERE ParentID = 30));
  
    -- Zuweiser Sozialdienste Aussengemeinden
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT 'Zuweiser Sozialdienste Aussengemeinden', COUNT(*)
      FROM @tmp
      WHERE [Finanzierende Stelle] NOT IN (SELECT ItemName
                                FROM dbo.XOrgUnit WITH (READUNCOMMITTED)
                                WHERE ParentID = 30
                                   OR OrgUnitID = 30
                                   OR ParentID IN (SELECT OrgUnitID
                                                   FROM dbo.XOrgUnit WITH (READUNCOMMITTED)
                                                   WHERE ParentID = 30))
        AND [Finanzierende Stelle] NOT LIKE 'RAV%';
                      
    -- Leerzeile
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT '', NULL;
  
    -- Eintritte Vorjahr
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT 'Eintritte Vorjahr', COUNT(*)
      FROM @tmp
      WHERE dbo.fnDateOf(EintrittDatum) < dbo.fnDateOf(@DatumVon);
  
    DECLARE @searchYear INT;
    SET @searchYear = YEAR(@DatumBis);
  
    -- Eintritte Januar
    INSERT INTO @rslt (Bezeichnung, Anzahl) 
      SELECT 'Eintritte Januar', COUNT(*) FROM @tmp WHERE MONTH(EintrittDatum) = 1 AND YEAR(EintrittDatum) = @searchYear;
    -- Austritte Januar
    INSERT INTO @rslt (Bezeichnung, Anzahl) 
      SELECT 'Austritte Januar', COUNT(*) FROM @tmp WHERE MONTH(AustrittDatum) = 1 AND YEAR(AustrittDatum) = @searchYear;
  
    -- Eintritte Februar
    INSERT INTO @rslt (Bezeichnung, Anzahl) 
      SELECT 'Eintritte Februar', COUNT(*) FROM @tmp WHERE MONTH(EintrittDatum) = 2 AND YEAR(EintrittDatum) = @searchYear;
    -- Austritte Februar
    INSERT INTO @rslt (Bezeichnung, Anzahl) 
      SELECT 'Austritte Februar', COUNT(*) FROM @tmp WHERE MONTH(AustrittDatum) = 2 AND YEAR(AustrittDatum) = @searchYear;
  
    -- Eintritte März
    INSERT INTO @rslt (Bezeichnung, Anzahl) 
      SELECT 'Eintritte März', COUNT(*) FROM @tmp WHERE MONTH(EintrittDatum) = 3 AND YEAR(EintrittDatum) = @searchYear;
    -- Austritte März
    INSERT INTO @rslt (Bezeichnung, Anzahl) 
      SELECT 'Austritte März', COUNT(*) FROM @tmp WHERE MONTH(AustrittDatum) = 3 AND YEAR(AustrittDatum) = @searchYear;
  
    -- Eintritte April
    INSERT INTO @rslt (Bezeichnung, Anzahl) 
      SELECT 'Eintritte April', COUNT(*) FROM @tmp WHERE MONTH(EintrittDatum) = 4 AND YEAR(EintrittDatum) = @searchYear;
    -- Austritte April
    INSERT INTO @rslt (Bezeichnung, Anzahl) 
      SELECT 'Austritte April', COUNT(*) FROM @tmp WHERE MONTH(AustrittDatum) = 4 AND YEAR(AustrittDatum) = @searchYear;

    -- Eintritte Mai
    INSERT INTO @rslt (Bezeichnung, Anzahl) 
      SELECT 'Eintritte Mai', COUNT(*) FROM @tmp WHERE MONTH(EintrittDatum) = 5 AND YEAR(EintrittDatum) = @searchYear;
    -- Austritte Mai
    INSERT INTO @rslt (Bezeichnung, Anzahl) 
      SELECT 'Austritte Mai', COUNT(*) FROM @tmp WHERE MONTH(AustrittDatum) = 5 AND YEAR(AustrittDatum) = @searchYear;
  
    -- Eintritte Juni
    INSERT INTO @rslt (Bezeichnung, Anzahl) 
      SELECT 'Eintritte Juni', COUNT(*) FROM @tmp WHERE MONTH(EintrittDatum) = 6 AND YEAR(EintrittDatum) = @searchYear;
    -- Austritte Juni
    INSERT INTO @rslt (Bezeichnung, Anzahl) 
      SELECT 'Austritte Juni', COUNT(*) FROM @tmp WHERE MONTH(AustrittDatum) = 6 AND YEAR(AustrittDatum) = @searchYear;
  
    -- Eintritte Juli
    INSERT INTO @rslt (Bezeichnung, Anzahl) 
      SELECT 'Eintritte Juli', COUNT(*) FROM @tmp WHERE MONTH(EintrittDatum) = 7 AND YEAR(EintrittDatum) = @searchYear;
    -- Austritte Juli
    INSERT INTO @rslt (Bezeichnung, Anzahl) 
      SELECT 'Austritte Juli', COUNT(*) FROM @tmp WHERE MONTH(AustrittDatum) = 7 AND YEAR(AustrittDatum) = @searchYear;
  
    -- Eintritte August
    INSERT INTO @rslt (Bezeichnung, Anzahl) 
      SELECT 'Eintritte August', COUNT(*) FROM @tmp WHERE MONTH(EintrittDatum) = 8 AND YEAR(EintrittDatum) = @searchYear;
    -- Austritte August
    INSERT INTO @rslt (Bezeichnung, Anzahl) 
      SELECT 'Austritte August', COUNT(*) FROM @tmp WHERE MONTH(AustrittDatum) = 8 AND YEAR(AustrittDatum) = @searchYear;
  
    -- Eintritte September
    INSERT INTO @rslt (Bezeichnung, Anzahl) 
      SELECT 'Eintritte September', COUNT(*) FROM @tmp WHERE MONTH(EintrittDatum) = 9 AND YEAR(EintrittDatum) = @searchYear;
    -- Austritte September
    INSERT INTO @rslt (Bezeichnung, Anzahl) 
      SELECT 'Austritte September', COUNT(*) FROM @tmp WHERE MONTH(AustrittDatum) = 9 AND YEAR(AustrittDatum) = @searchYear;
  
    -- Eintritte Oktober
    INSERT INTO @rslt (Bezeichnung, Anzahl) 
      SELECT 'Eintritte Oktober', COUNT(*) FROM @tmp WHERE MONTH(EintrittDatum) = 10 AND YEAR(EintrittDatum) = @searchYear;
    -- Austritte Oktober
    INSERT INTO @rslt (Bezeichnung, Anzahl) 
      SELECT 'Austritte Oktober', COUNT(*) FROM @tmp WHERE MONTH(AustrittDatum) = 10 AND YEAR(AustrittDatum) = @searchYear;
  
    -- Eintritte November
    INSERT INTO @rslt (Bezeichnung, Anzahl) 
      SELECT 'Eintritte November', COUNT(*) FROM @tmp WHERE MONTH(EintrittDatum) = 11 AND YEAR(EintrittDatum) = @searchYear;
    -- Austritte November
    INSERT INTO @rslt (Bezeichnung, Anzahl) 
      SELECT 'Austritte November', COUNT(*) FROM @tmp WHERE MONTH(AustrittDatum) = 11 AND YEAR(AustrittDatum) = @searchYear;
  
    -- Eintritte Dezember
    INSERT INTO @rslt (Bezeichnung, Anzahl) 
      SELECT 'Eintritte Dezember', COUNT(*) FROM @tmp WHERE MONTH(EintrittDatum) = 12 AND YEAR(EintrittDatum) = @searchYear;
    -- Austritte Dezember
    INSERT INTO @rslt (Bezeichnung, Anzahl) 
      SELECT 'Austritte Dezember', COUNT(*) FROM @tmp WHERE MONTH(AustrittDatum) = 12 AND YEAR(AustrittDatum) = @searchYear;
  
    -- Leerzeile
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT '', NULL;
  
    -- Leerzeile
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT 'Austrittsgrund', null;

    -- Austrittsgrund
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT Austrittgrund, COUNT(*)
      FROM @tmp
      WHERE Austrittgrund IS NOT NULL
        AND Austrittgrund NOT IN ('Arbeitgeber Abbruch', 'Arbeitnehmer Abbruch','Gegenseitiger Abbruch')
      GROUP BY Austrittgrund
      ORDER BY Austrittgrund;
  
    -- Leerzeile
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT '', NULL;

    -- Leerzeile
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT 'Abbruchgrund', NULL;

    -- Grund Abbruch
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT GrundAbbruch, COUNT(*)
      FROM @tmp
      WHERE GrundAbbruch IS NOT NULL
      GROUP BY GrundAbbruch
      ORDER BY GrundAbbruch;
  
    -- Leerzeile
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT '', NULL;
  
    -- Bis 3 Monate
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT 'Bis 3 Monate', COUNT(*)
      FROM @tmp
      WHERE Einsatzdauer < 4;
  
    -- 4 bis 6 Monate
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT '4 bis 6 Monate', COUNT(*)
      FROM @tmp
      WHERE Einsatzdauer BETWEEN 4 AND 6;

    -- 7 bis 9 Monate
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT '7 bis 9 Monate', COUNT(*)
      FROM @tmp
      WHERE Einsatzdauer BETWEEN 7 AND 9;
  
    -- 10 bis 12 Monate
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT '10 bis 12 Monate', COUNT(*)
      FROM @tmp
      WHERE Einsatzdauer BETWEEN 10 AND 12;

    -- mehr als 12 Monate
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT 'mehr als 12 Monate', COUNT(*)
      FROM @tmp
      WHERE Einsatzdauer > 12;

    -- Leerzeile
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT '', NULL;
  
    -- Bis 16 Jahre
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT 'Bis 16 Jahre', COUNT(*)
      FROM @tmp
      WHERE [Alter] < 17;
  
    -- 17 bis 18 Jahre
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT '17 bis 18 Jahre', COUNT(*)
      FROM @tmp
      WHERE [Alter] BETWEEN 17 AND 18;
  
    -- 19 bis 20 Jahre
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT '19 bis 20 Jahre', COUNT(*)
      FROM @tmp
      WHERE [Alter] BETWEEN 19 AND 20;
  
    -- 21 bis 22 Jahre
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT '21 bis 22 Jahre', COUNT(*)
      FROM @tmp
      WHERE [Alter] BETWEEN 21 AND 22;
  
    -- Ab 23 Jahre
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT 'Ab 23 Jahre', COUNT(*)
      FROM @tmp
      WHERE [Alter] > 22;
  
    -- Leerzeile
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT '', NULL;

    -- Vorbildung
    INSERT INTO @rslt (Bezeichnung, Anzahl)
      SELECT Vorbildung, COUNT(*)
      FROM @tmp
      WHERE Vorbildung IS NOT NULL
      GROUP BY Vorbildung
      ORDER BY Vorbildung;

    -- Final select
    SELECT Bezeichnung, Anzahl
    FROM @rslt
    ORDER BY ID;
  END
  ELSE BEGIN  
    SELECT  [Name]         = PRS.Name,
            [Vorname]      = PRS.Vorname,
            [Geburtsdatum] = dbo.fnDateOf(PRS.Geburtsdatum),
            [Altergruppe]  = CASE 
                               WHEN T.[Alter] < 17 THEN 'bis 16 Jahre'
                               WHEN T.[Alter] BETWEEN 17 AND 18 THEN '17 bis 18 Jahre'
                               WHEN T.[Alter] BETWEEN 19 AND 20 THEN '19 bis 20 Jahre'
                               WHEN T.[Alter] BETWEEN 21 AND 22 THEN '21 bis 22 Jahre'
                               WHEN T.[Alter] > 22 THEN 'ab 23 Jahre'
                               ELSE 'keine Angabe'
                             END,
            [m/w]          = CASE T.Geschlecht
                               WHEN 1 THEN 'm'
                               WHEN 2 THEN 'w'
                               ELSE ''
                             END,
            [Nationalität]   = PRS.Nationalitaet,
            [Status]         = dbo.fnLOVText('Aufenthaltsstatus', PRS.AuslaenderStatusCode),
            [Vorbildung]     = T.Vorbildung,
            [Erstsprache]    = T.Erstsprache,
            [Hauptsprache]   = T.Hauptsprache,
            [Finanzierende Stelle] = T.[Finanzierende Stelle],
            [Fallführung]    = T.Fallfuehrung,
            [Zuweisende Stelle] = T.[Zuweisende Stelle],
            [Niveau]         = dbo.fnLOVText('KaQjNiveau', T.NiveauCode),
            [Fachbereich]    = dbo.fnLOVText('KAFachbereich', T.FachbereichID),
            [Datum Eintritt] = T.EintrittDatum,
            [Eintrittsmonat] = dbo.fnXMonat(MONTH(T.EintrittDatum)),
            [Datum Austritt] = T.AustrittDatum,
            [Austrittsmonat] = dbo.fnXMonat(MONTH(T.AustrittDatum)),
            [Austrittsgrund] = CASE 
                                 WHEN T.Austrittgrund = 'Arbeitgeber Abbruch' THEN T.GrundAbbruch
                                 WHEN T.Austrittgrund = 'Arbeitnehmer Abbruch' THEN T.GrundAbbruch
                                 WHEN T.Austrittgrund = 'Gegenseitiger Abbruch' THEN T.GrundAbbruch
                                 ELSE T.Austrittgrund
                               END,
            [Dauer Einsatz]  = CASE 
                                 WHEN T.Einsatzdauer < 4 THEN 'bis 3 Monate'
                                 WHEN T.Einsatzdauer BETWEEN 4 AND 6 THEN '4 bis 6 Monate'
                                 WHEN T.Einsatzdauer BETWEEN 7 AND 9 THEN '7 bis 9 Monate'
                                 WHEN T.Einsatzdauer BETWEEN 10 AND 12 THEN '10 bis 12 Monate'
                                 WHEN T.Einsatzdauer > 12 THEN 'mehr als 12 Monate'
                                 ELSE 'kein Austritt'
                               END,
            BaPersonID$      = PRS.BaPersonID
    FROM @tmp T
      INNER JOIN dbo.vwPerson  PRS ON PRS.BaPersonID = T.BaPersonID    
    ORDER BY PRS.NameVorname;
  END;
END;
GO