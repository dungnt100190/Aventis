SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetFlexibleAdress;
GO
/*===============================================================================================
  $Revision: 29 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get specific address text for textmarken
    @TableID:        The ID of the person/institution/orgunit to get address from
    @SubTableID:     The ID of a subtable to get some corresponding data (e.g. related person...)
    @LanguageCode:   The language code (1=D, 2=F, 3=I)
    @LineBreakMode:  0=',', 1=CRLF, 2=' '
    @AddressType:    - Person:            'wohnsitz', 'aufenthalt', 'post', 'heimat', 'anschrift'=priority mode (1.post, 2.aufenthalt, 3.wohnsitz), 
                     - Institution:       'institution' (TableID=BaInstitutionID, SubTableID=BaInstitutionKontaktID --> ZuhandenVon=Kontaktperson)
                     - User:              'orgunit' (TableID=UserID, Zusatz=KGS, ZuhandenVon=Abteilung)
                     - EDMitarbeiter:     'edmitarbeiter'
                     - BWMitarbeiter:     'bwmitarbeiter'
                     - Rechnungsadressen: 'rasb', 'racm', 'rabw1', 'rabw2', 'raed1', raed2', 'raab1', 'raab2', 'raab3'
                     - BaZahlungsweg:     'bazahlungsweg'
                     - BaBank:            'babank'
    @ShowTitle:      1=Show title/anrede, 0=Hide title/anrede (only for institution, BaPerson.Wohnsitz, BaPerson.Heimatort)
    @ShowName:       1=Show name, 0=Hide name
    @NameMode:       NULL="name vorname", 'nvkomma'="name, vorname", 'vornach'="vorname nachname"
    @NamePrefix:     The prefix to use before writing name (e.g. 'Herr' --> 'Herr Müller Heinz'), only important if showing name
                     Special handling for tag '<herrfraumanuell>' (see code below)
    @ShowZusatz:     1=Show zusatz, 0=Hide zusatz
    @ShowZuhandenVon 1=Show zuhandenvon (post only, institution = Kontaktperson if SubTableID is given), 0=Hide zuhandenvon
    @ShowStrasseNr:  1=Show strasse+hausnr, 0=Hide strasse+hausnr
    @ShowPostfach:   1=Show postfach, 0=Hide postfach
    @ShowPLZOrt:     1=Show plz+ort, 0=Hide plz+ort
    @ShowKanton:     1=Show kanton, 0=Hide kanton
    @ShowBezirk:     1=Show bezirk, 0=Hide bezirk
    @ShowLand:       1=Show land, 0=Hide land
    @LandMode:       1=Show land only if not switzerland, 0=show land always
  -
  RETURNS: The desired address in specified format or '' if nothing found or error
=================================================================================================
  TEST:    SELECT dbo.fnGetFlexibleAdress(74660, NULL, 1, 2, 'wohnsitz', 1, 1, 'vornach', 'Herr', 1, 1, 1, 1, 1, 1, 1, 1, 1)
           SELECT dbo.fnGetFlexibleAdress(74660, NULL, 1, 1, 'anschrift', 1, 1, 'nvkomma', 'Herr', 1, 1, 1, 1, 1, 1, 1, 1, 1)
           SELECT dbo.fnGetFlexibleAdress(74660, NULL, 1, 1, 'aufenthalt', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 1, 1, 1, 1)
           SELECT dbo.fnGetFlexibleAdress(74660, NULL, 2, 1, 'post', 0, 1, NULL, 'Herr', 1, 1, 1, 1, 1, 1, 1, 1, 0)
           SELECT dbo.fnGetFlexibleAdress(87159 , NULL, 2, 1, 'raed1', 0, 1, NULL, 'Herr', 1, 1, 1, 1, 1, 1, 1, 1, 0)
           SELECT dbo.fnGetFlexibleAdress(87159 , NULL, 2, 1, 'rabw', 0, 1, NULL, 'Herr', 1, 1, 1, 1, 1, 1, 1, 1, 0)
           SELECT dbo.fnGetFlexibleAdress(25 , NULL, 2, 1, 'bwmitarbeiter', 0, 1, NULL, 'Herr', 1, 1, 1, 1, 1, 1, 1, 1, 1)
           SELECT dbo.fnGetFlexibleAdress(25 , NULL, 2, 1, 'edmitarbeiter', 0, 1, NULL, 'Herr', 1, 1, 1, 1, 1, 1, 1, 1, 1)
           --
           SELECT dbo.fnGetFlexibleAdress(540, NULL, 1, 1, 'bazahlungsweg', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
           SELECT dbo.fnGetFlexibleAdress(1, NULL, 1, 1, 'babank', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
           --
           SELECT dbo.fnGetFlexibleAdress(77771, NULL, 1, 1, 'anschrift', 0, 1, 'vornach', 'Herr', 1, 1, 1, 1, 1, 0, 0, 1, 1)
=================================================================================================*/

CREATE FUNCTION dbo.fnGetFlexibleAdress
(
  @TableID INT,
  @SubTableID INT,
  --
  @LanguageCode INT,
  @LineBreakMode INT,
  @AddressType VARCHAR(50),
  --
  @ShowTitle BIT,
  @ShowName BIT,
  @NameMode VARCHAR(50),
  @NamePrefix VARCHAR(100),
  @ShowZusatz BIT,
  @ShowZuhandenVon BIT,
  @ShowStrasseNr BIT,
  @ShowPostfach BIT,
  @ShowPLZOrt BIT,
  @ShowKanton BIT,
  @ShowBezirk BIT,
  @ShowLand BIT,
  @LandMode BIT
)
RETURNS VARCHAR(3000)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- if no value is passed, we cannot continue
  IF (@TableID IS NULL)
  BEGIN
    -- invalid data
    RETURN '';
  END;
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @OUTPUT         VARCHAR(3000);
  
  DECLARE @LineBreakChar  VARCHAR(10);
  DECLARE @LenLineBreak   INT;
  DECLARE @NameVorname    VARCHAR(400);
  DECLARE @PostfachText   VARCHAR(255);
  
  DECLARE @BaAdresseIDAufenthalt INT;  
  DECLARE @BaAdresseIDPost INT;  
  
  DECLARE @CareOf         VARCHAR(200);
  DECLARE @TitelAnrede    VARCHAR(200);
  DECLARE @Name           VARCHAR(200);
  DECLARE @Vorname        VARCHAR(200);
  DECLARE @Zusatz         VARCHAR(200);
  DECLARE @ZuhandenVon    VARCHAR(200);
  DECLARE @Strasse        VARCHAR(100);
  DECLARE @HausNr         VARCHAR(10);
  DECLARE @Postfach       VARCHAR(100);
  DECLARE @PostfachOhneNr BIT;
  DECLARE @PLZ            VARCHAR(10);
  DECLARE @Ort            VARCHAR(50);
  DECLARE @Kanton         VARCHAR(10);
  DECLARE @Bezirk         VARCHAR(100);
  DECLARE @BaLandID       INT;
  DECLARE @GeschlechtCode INT;
  DECLARE @IsManuelleAnrede BIT;
  DECLARE @ManuelleAnrede VARCHAR(100);

  
  -- prepare vars
  SET @OUTPUT = '';
  
  -----------------------------------------------------------------------------
  -- setup line break
  -----------------------------------------------------------------------------
  IF (@LineBreakMode = 2)
  BEGIN
    -- only with space
    SET @LineBreakChar = ' ';
    SET @LenLineBreak = 1;
  END
  ELSE IF (@LineBreakMode = 1)
  BEGIN
    -- multiline
    SET @LineBreakChar = CHAR(13) + CHAR(10);
    SET @LenLineBreak = 2;
  END
  ELSE
  BEGIN
    -- comma separated (default)
    SET @LineBreakChar = ', ';
    SET @LenLineBreak = 2;
  END;
  
  -----------------------------------------------------------------------------
  -- get address-ids to enhance performance
  -----------------------------------------------------------------------------
  IF (@AddressType IN ('aufenthalt', 'post', 'anschrift'))
  BEGIN
    -- setup ids of Aufenthalt and Post as we use it anyway
    SET @BaAdresseIDAufenthalt = dbo.fnBaGetBaAdresseID('BaPersonID', @TableID, 2, NULL);
    SET @BaAdresseIDPost       = dbo.fnBaGetBaAdresseID('BaPersonID', @TableID, 3, NULL);
  END;
  
  -----------------------------------------------------------------------------
  -- check if priority mode to setup addresstype
  -----------------------------------------------------------------------------
  IF (@AddressType = 'anschrift')
  BEGIN
     -- 1.Prio=Post; 2.Prio=Aufenthalt; 3.Prio=Wohnsitz
    SET @AddressType = CASE 
                         WHEN (SELECT ISNULL(PLZ, '') 
                               FROM dbo.BaAdresse WITH(READUNCOMMITTED) 
                               WHERE BaAdresseID = @BaAdresseIDPost) <> '' THEN 'post'
                         WHEN (SELECT ISNULL(PLZ, '') 
                               FROM dbo.BaAdresse WITH(READUNCOMMITTED) 
                               WHERE BaAdresseID = @BaAdresseIDAufenthalt) <> '' THEN 'aufenthalt'
                         ELSE 'wohnsitz'
                       END;
  END;
  
  -----------------------------------------------------------------------------
  -- get data ('wohnsitz', 'aufenthalt', 'post', 'heimat', 'anschrift'=priority mode, 
  --           'institution', 'orgunit', 'edmitarbeiter')
  -----------------------------------------------------------------------------
  IF (@AddressType = 'wohnsitz')
  BEGIN
    -- Wohnsitz
    SELECT @TitelAnrede    = PRS.Titel,
           @IsManuelleAnrede = PRS.ManuelleAnrede,
           @ManuelleAnrede = PRS.Anrede,
           @GeschlechtCode = PRS.GeschlechtCode,
           @Name           = PRS.Name,
           @Vorname        = PRS.Vorname,
           @Zusatz         = ADR.Zusatz,
           @ZuhandenVon    = ADR.ZuhandenVon,
           @Strasse        = ADR.Strasse,
           @HausNr         = ADR.HausNr,
           @Postfach       = ADR.Postfach,
           @PostfachOhneNr = ADR.PostfachOhneNr,
           @PLZ            = ADR.PLZ,
           @Ort            = ADR.Ort,
           @Kanton         = ADR.Kanton,
           @Bezirk         = ADR.Bezirk,
           @BaLandID       = ADR.BaLandID
    FROM dbo.BaPerson         PRS WITH (READUNCOMMITTED)
      LEFT JOIN dbo.BaAdresse ADR WITH (READUNCOMMITTED) ON ADR.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 1, NULL)
    WHERE PRS.BaPersonID = @TableID;
  END
  -----------------------------------------------------------------------------
  ELSE IF (@AddressType = 'aufenthalt')
  BEGIN
    -- Aufenthalt (if we have a CareOf value, we just take this one, otherwise we take person title/name/vorname)
    SELECT @CareOf         = ADR.CareOf,
           @TitelAnrede    = CASE
                               WHEN ADR.CareOf IS NULL THEN PRS.Titel
                               ELSE NULL
                             END,
           @IsManuelleAnrede = CASE 
                                 WHEN ADR.CareOf IS NULL THEN PRS.ManuelleAnrede 
                                 ELSE 0
                               END,
           @ManuelleAnrede = CASE 
                               WHEN ADR.CareOf IS NULL THEN PRS.Anrede 
                               ELSE NULL
                             END,
           @GeschlechtCode = CASE 
                               WHEN ADR.CareOf IS NULL THEN PRS.GeschlechtCode 
                               ELSE NULL
                             END,
           @Name           = CASE
                               WHEN ADR.CareOf IS NULL THEN PRS.Name
                               ELSE ADR.CareOf
                             END,
           @Vorname        = CASE
                               WHEN ADR.CareOf IS NULL THEN PRS.Vorname
                               ELSE NULL
                             END,
           @Zusatz         = ADR.Zusatz,
           @ZuhandenVon    = ADR.ZuhandenVon,
           @Strasse        = ADR.Strasse,
           @HausNr         = ADR.HausNr,
           @Postfach       = ADR.Postfach,
           @PostfachOhneNr = ADR.PostfachOhneNr,
           @PLZ            = ADR.PLZ,
           @Ort            = ADR.Ort,
           @Kanton         = ADR.Kanton,
           @Bezirk         = ADR.Bezirk,
           @BaLandID       = ADR.BaLandID
    FROM dbo.BaAdresse ADR WITH (READUNCOMMITTED)
      INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = ADR.BaPersonID
    WHERE ADR.BaAdresseID = @BaAdresseIDAufenthalt;
    
    -- special handling if CareOf is given
    IF (@CareOf IS NOT NULL)
    BEGIN
      -- reset values for name mode and name prefix to prevent wrong output (performance optimized)
      SET @NameMode = 'nvkomma';
      SET @NamePrefix = '';
    END;
  END
  -----------------------------------------------------------------------------
  ELSE IF (@AddressType = 'post')
  BEGIN
    -- Post (if we have a CareOf value, we just take this one, otherwise we take person title/name/vorname)
    SELECT @CareOf         = ADR.CareOf,
           @TitelAnrede    = CASE
                               WHEN ADR.CareOf IS NULL THEN PRS.Titel
                               ELSE NULL
                             END,
           @IsManuelleAnrede = CASE 
                                 WHEN ADR.CareOf IS NULL THEN PRS.ManuelleAnrede 
                                 ELSE 0
                               END,
           @ManuelleAnrede = CASE 
                               WHEN ADR.CareOf IS NULL THEN PRS.Anrede 
                               ELSE NULL
                             END,
           @GeschlechtCode = CASE 
                               WHEN ADR.CareOf IS NULL THEN PRS.GeschlechtCode 
                               ELSE NULL
                             END,
           @Name           = CASE
                               WHEN ADR.CareOf IS NULL THEN PRS.Name
                               ELSE ADR.CareOf
                             END,
           @Vorname        = CASE
                               WHEN ADR.CareOf IS NULL THEN PRS.Vorname
                               ELSE NULL
                             END,
           @Zusatz         = ADR.Zusatz,
           @ZuhandenVon    = ADR.ZuhandenVon,
           @Strasse        = ADR.Strasse,
           @HausNr         = ADR.HausNr,
           @Postfach       = ADR.Postfach,
           @PostfachOhneNr = ADR.PostfachOhneNr,
           @PLZ            = ADR.PLZ,
           @Ort            = ADR.Ort,
           @Kanton         = ADR.Kanton,
           @Bezirk         = ADR.Bezirk,
           @BaLandID       = ADR.BaLandID
    FROM dbo.BaAdresse        ADR WITH (READUNCOMMITTED)
      INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = ADR.BaPersonID
    WHERE ADR.BaAdresseID = @BaAdresseIDPost;
    
    -- special handling if CareOf is given
    IF (@CareOf IS NOT NULL)
    BEGIN
      -- reset values for name mode and name prefix to prevent wrong output (performance optimized)
      SET @NameMode = 'nvkomma';
      SET @NamePrefix = '';
    END;
  END
  -----------------------------------------------------------------------------
  ELSE IF (@AddressType = 'heimat')
  BEGIN
    -- Heimatort
    SELECT @TitelAnrede    = PRS.Titel,
           @IsManuelleAnrede = PRS.ManuelleAnrede,
           @ManuelleAnrede = PRS.Anrede,
           @GeschlechtCode = PRS.GeschlechtCode,
           @Name           = PRS.Name,
           @Vorname        = PRS.Vorname,
           @Zusatz         = NULL,
           @ZuhandenVon    = NULL,
           @Strasse        = NULL,
           @HausNr         = NULL,
           @Postfach       = NULL,
           @PostfachOhneNr = NULL,
           @PLZ            = CONVERT(VARCHAR, GDE.PLZ),
           @Ort            = dbo.fnGetMLTextByDefault(GDE.NameTID, @LanguageCode, GDE.Name),
           @Kanton         = GDE.Kanton,
           @Bezirk         = dbo.fnGetMLTextByDefault(GDE.BezirkNameTID, @LanguageCode, GDE.BezirkName),
           @BaLandID       = 147 -- always Switzerland (no Heimatort if not Switzerland)
    FROM dbo.BaPerson          PRS WITH (READUNCOMMITTED)
      LEFT JOIN dbo.BaGemeinde GDE WITH (READUNCOMMITTED) ON GDE.BaGemeindeID = PRS.HeimatgemeindeBaGemeindeID
    WHERE BaPersonID = @TableID
  END
  -----------------------------------------------------------------------------
  ELSE IF (@AddressType = 'institution')
  BEGIN
    -- Institution
    SELECT @TitelAnrede    = INS.Titel,
           @IsManuelleAnrede = CASE 
                                 WHEN INS.BaInstitutionArtCode = 2 THEN INS.ManuelleAnrede 
                                 ELSE 0
                               END,
           @ManuelleAnrede = INS.Anrede,
           @GeschlechtCode = CASE 
                               WHEN INS.BaInstitutionArtCode = 2 THEN INS.GeschlechtCode 
                               ELSE NULL
                             END,
           @Name           = INS.[Name],
           @Vorname        = INS.Vorname,
           @Zusatz         = ADR.Zusatz,
           @ZuhandenVon    = (SELECT REPLACE(dbo.fnGetLastFirstName(NULL, INK.Name, INK.Vorname), ',', '')
                              FROM dbo.BaInstitutionKontakt INK WITH (READUNCOMMITTED)
                              WHERE INK.BaInstitutionKontaktID = ISNULL(@SubTableID, -1)),
           @Strasse        = ADR.Strasse,
           @HausNr         = ADR.HausNr,
           @Postfach       = ADR.Postfach,
           @PostfachOhneNr = ADR.PostfachOhneNr,
           @PLZ            = ADR.PLZ,
           @Ort            = ADR.Ort,
           @Kanton         = ADR.Kanton,
           @Bezirk         = ADR.Bezirk,
           @BaLandID       = ADR.BaLandID
    FROM dbo.BaInstitution    INS WITH (READUNCOMMITTED)
      LEFT JOIN dbo.BaAdresse ADR WITH (READUNCOMMITTED) ON ADR.BaAdresseID = dbo.fnBaGetBaAdresseID('BaInstitutionID', INS.BaInstitutionID, NULL, NULL)
    WHERE INS.BaInstitutionID = @TableID 
      AND INS.Aktiv = 1; -- only active institutions!!
  END
  -----------------------------------------------------------------------------
  ELSE IF (@AddressType = 'orgunit')
  BEGIN
    -- OrgUnit of user
    SELECT @TitelAnrede    = NULL,
           @Name           = USR.LastName,
           @Vorname        = USR.FirstName,
           @Zusatz         = ORG.AdresseKGS,
           @ZuhandenVon    = ORG.AdresseAbteilung,
           @Strasse        = ORG.AdresseStrasse,
           @HausNr         = ORG.AdresseHausNr,
           @Postfach       = ORG.Postfach,
           @PostfachOhneNr = ORG.PostfachOhneNr,
           @PLZ            = ORG.AdressePLZ,
           @Ort            = ORG.AdresseOrt,
           @Kanton         = NULL,
           @Bezirk         = NULL,
           @BaLandID       = 147 -- schweiz only
    FROM dbo.XUser           USR WITH (READUNCOMMITTED)
      LEFT JOIN dbo.XOrgUnit ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = CONVERT(INT, dbo.fnOrgUnitOfUser(USR.UserID, 1))  -- member only
    WHERE USR.UserID = @TableID;
  END
  -----------------------------------------------------------------------------
  ELSE IF (@AddressType IN ('bwmitarbeiter', 'edmitarbeiter'))
  BEGIN
    -- BWMitarbeiter and EDMitarbeiter
    SELECT @TitelAnrede    = NULL,
           @Name           = USR.LastName,
           @Vorname        = USR.FirstName,
           @Zusatz         = ADR.Zusatz,
           @ZuhandenVon    = NULL,
           @Strasse        = ADR.Strasse,
           @HausNr         = ADR.HausNr,
           @Postfach       = ADR.Postfach,
           @PostfachOhneNr = ADR.PostfachOhneNr,
           @PLZ            = ADR.PLZ,
           @Ort            = ADR.Ort,
           @Kanton         = ADR.Kanton,
           @Bezirk         = ADR.Bezirk,
           @BaLandID       = ADR.BaLandID
    FROM dbo.EDMitarbeiter EDM WITH (READUNCOMMITTED)
      INNER JOIN dbo.XUser USR WITH (READUNCOMMITTED) ON USR.UserID = EDM.UserID
      LEFT  JOIN dbo.BaAdresse ADR WITH (READUNCOMMITTED) ON ADR.UserID = USR.UserID
    WHERE EDM.EdMitarbeiterID = @TableID;
  END
  -----------------------------------------------------------------------------
  ELSE IF (@AddressType IN ('rasb', 'racm', 'rabw1', 'rabw2', 'raed1', 'raed2', 'raab1', 'raab2','raab3'))
  BEGIN
    -- Rechnungsadresse
    SELECT @TitelAnrede    = NULL,
           @Name           = BRA.AdresseName,
           @Vorname        = NULL,
           @Zusatz         = BRA.AdresseZusatz,
           @ZuhandenVon    = NULL,
           @Strasse        = BRA.AdresseStrasse,
           @HausNr         = BRA.AdresseHausNr,
           @Postfach       = BRA.AdressePostfach,
           @PostfachOhneNr = NULL,
           @PLZ            = BRA.AdressePLZ,
           @Ort            = BRA.AdresseOrt,
           @Kanton         = BRA.AdresseKanton,
           @Bezirk         = BRA.AdresseBezirk,
           @BaLandID       = BRA.AdresseLandCode
    FROM dbo.BaRechnungsadresse BRA WITH (READUNCOMMITTED)
    WHERE BRA.BaPersonID = @TableID AND
          BRA.DienstleistungCode = CASE
                                     WHEN @AddressType = 'rasb'  THEN 1 -- SB (>> LOV: BaRechnungsadresseModule)
                                     WHEN @AddressType = 'racm'  THEN 2 -- CM
                                     WHEN @AddressType = 'rabw1' THEN 3 -- BW1
                                     WHEN @AddressType = 'rabw2' THEN 6 -- BW2
                                     WHEN @AddressType = 'raed1' THEN 4 -- ED1
                                     WHEN @AddressType = 'raed2' THEN 5 -- ED2
                                     WHEN @AddressType = 'raab1' THEN 7 -- AB1
                                     WHEN @AddressType = 'raab2' THEN 8 -- AB2
                                     WHEN @AddressType = 'raab3' THEN 9 -- AB3
                                     ELSE -1
                                   END;
  END
  -----------------------------------------------------------------------------
  ELSE IF (@AddressType = 'bazahlungsweg')
  BEGIN
    -- BaZahlungsweg
    SELECT @TitelAnrede    = NULL,
           @Name           = ZLW.AdresseName,
           @Vorname        = NULL,
           @Zusatz         = ZLW.AdresseName2,
           @ZuhandenVon    = NULL,
           @Strasse        = ZLW.AdresseStrasse,
           @HausNr         = ZLW.AdresseHausNr,
           @Postfach       = ZLW.AdressePostfach,
           @PostfachOhneNr = NULL,
           @PLZ            = ZLW.AdressePLZ,
           @Ort            = ZLW.AdresseOrt,
           @Kanton         = NULL,
           @Bezirk         = NULL,
           @BaLandID       = ZLW.AdresseLandCode
    FROM dbo.BaZahlungsweg ZLW WITH (READUNCOMMITTED)
    WHERE ZLW.BaZahlungswegID = @TableID;
  END
  -----------------------------------------------------------------------------
  ELSE IF (@AddressType = 'babank')
  BEGIN
    -- BaBank
    SELECT @TitelAnrede    = NULL,
           @Name           = BNK.Name,
           @Vorname        = NULL,
           @Zusatz         = BNK.Zusatz,
           @ZuhandenVon    = NULL,
           @Strasse        = BNK.Strasse,
           @HausNr         = NULL,
           @Postfach       = NULL,
           @PostfachOhneNr = NULL,
           @PLZ            = BNK.PLZ,
           @Ort            = BNK.Ort,
           @Kanton         = NULL,
           @Bezirk         = NULL,
           @BaLandID       = BNK.LandCode
    FROM dbo.BaBank BNK WITH (READUNCOMMITTED)
    WHERE BNK.BaBankID = @TableID;
  END
  -----------------------------------------------------------------------------
  ELSE
  BEGIN
    -- invalid code
    RETURN '';
  END;
  
  -----------------------------------------------------------------------------
  -- setup name prefix depending on type
  ----------------------------------------------------------------------------- 
  IF (@NamePrefix = '<herrfraumanuell>')
  BEGIN
    IF @AddressType IN ('wohnsitz', 'aufenthalt', 'post')
    BEGIN
        IF @IsManuelleAnrede = 1
        BEGIN
            SET @NamePrefix = @ManuelleAnrede;
        END
        ELSE
        BEGIN
            SET @NamePrefix = dbo.fnGetGenderMLTitle(@GeschlechtCode, 'dbGeneral', 'Herr', 'Frau', NULL, @LanguageCode, NULL);
        END;
    END
    ELSE IF @AddressType = 'institution'
    BEGIN
        IF @GeschlechtCode IS NULL
        BEGIN
            SET @NamePrefix = NULL;
        END
        ELSE
        BEGIN
            IF @IsManuelleAnrede = 1
            BEGIN
                SET @NamePrefix = @ManuelleAnrede;
            END
            ELSE
            BEGIN
                SET @NamePrefix = dbo.fnGetGenderMLTitle(@GeschlechtCode, 'dbGeneral', 'Herr', 'Frau', NULL, @LanguageCode, NULL);
            END;
        END
    END
    ELSE
    BEGIN
        SET @NamePrefix = dbo.fnGetGenderMLTitle(@GeschlechtCode, 'dbGeneral', 'Herr', 'Frau', NULL, @LanguageCode, NULL);
    END
  END;

  -----------------------------------------------------------------------------
  -- setup name depending on type
  -- NULL="name vorname", 'nvkomma'="name, vorname", 'vornach'="vorname nachname"
  -- also works with other addresses than 'wohnsitz'
  ----------------------------------------------------------------------------- 
  IF (@NameMode = 'nvkomma')
  BEGIN
    -- "name, vorname"
    SET @NameVorname = dbo.fnGetLastFirstName(NULL, @Name, @Vorname);
  END
  ELSE IF (@NameMode = 'vornach')
  BEGIN
    -- "vorname name"    
    SET @NameVorname = REPLACE(dbo.fnGetLastFirstName(NULL, @Vorname, @Name), ',', '');
  END
  ELSE
  BEGIN
    -- "name vorname"
    SET @NameVorname = REPLACE(dbo.fnGetLastFirstName(NULL, @Name, @Vorname), ',', '');
  END;
  
  -- name prefix (only if we have a name)
  IF (ISNULL(@NamePrefix, '') <> '' AND ISNULL(@NameVorname, '') <> '')
  BEGIN
    -- special handling for title of person: e.g. Herr Dr. Sebastian Meier
    -- only if 'wohnsitz', 'aufenthalt', 'post' or 'institution' and title is given
    IF (@AddressType IN ('wohnsitz', 'aufenthalt', 'post', 'institution') AND @ShowTitle = 1 AND ISNULL(@TitelAnrede, '') <> '')
    BEGIN
      -- add title to NameVorname to have the same flow as usual below
      SET @NameVorname = ISNULL(@TitelAnrede + ' ', '') + ISNULL(@NameVorname, '');
      
      -- remove title-flag to prevent double title
      SET @ShowTitle = 0;
    END;
    
    -- add Prefix
    IF (@LineBreakMode = 1)
    BEGIN
      -- multiline
      SET @NameVorname = @NamePrefix + CHAR(13) + CHAR(10) + @NameVorname;
    END
    ELSE
    BEGIN
      -- singleline
      SET @NameVorname = @NamePrefix + ' ' + @NameVorname;
    END;
  END;
  
  -----------------------------------------------------------------------------
  -- combine data depending on settings
  -----------------------------------------------------------------------------
  -- titel/anrede
  IF (@ShowTitle = 1)
  BEGIN
    -- here, output should be = ''
    SET @OUTPUT = CASE 
                    WHEN ISNULL(@OUTPUT, '') = '' OR RIGHT(@OUTPUT, @LenLineBreak) = @LineBreakChar THEN @OUTPUT + ISNULL(@TitelAnrede, '')
                    ELSE @OUTPUT + ISNULL(@LineBreakChar + @TitelAnrede, '')
                  END;
  END;
  
  -- name
  IF (@ShowName = 1)
  BEGIN
    SET @OUTPUT = CASE 
                    WHEN ISNULL(@OUTPUT, '') = '' OR RIGHT(@OUTPUT, @LenLineBreak) = @LineBreakChar THEN @OUTPUT + ISNULL(@NameVorname, '')
                    ELSE @OUTPUT + ISNULL(@LineBreakChar + @NameVorname, '')
                  END;
  END;
  
  -- zusatz
  IF (@ShowZusatz = 1)
  BEGIN
    SET @OUTPUT = CASE
                    WHEN ISNULL(@OUTPUT, '') = '' OR RIGHT(@OUTPUT, @LenLineBreak) = @LineBreakChar THEN @OUTPUT + ISNULL(@Zusatz, '')
                    ELSE @OUTPUT + ISNULL(@LineBreakChar + @Zusatz, '')
                  END;
  END;
  
  -- zuhanden von
  IF (@ShowZuhandenVon = 1)
  BEGIN
    SET @OUTPUT = CASE 
                    WHEN ISNULL(@OUTPUT, '') = '' OR RIGHT(@OUTPUT, @LenLineBreak) = @LineBreakChar THEN @OUTPUT + ISNULL(@ZuhandenVon, '')
                    ELSE @OUTPUT + ISNULL(@LineBreakChar + @ZuhandenVon, '')
                  END;
  END;
  
  -- strasse nr
  IF (@ShowStrasseNr = 1)
  BEGIN
    SET @OUTPUT = CASE 
                    WHEN ISNULL(@OUTPUT, '') = '' OR RIGHT(@OUTPUT, @LenLineBreak) = @LineBreakChar THEN @OUTPUT + LTRIM(ISNULL(@Strasse + ISNULL(' ' + @HausNr, ''), ''))
                    ELSE @OUTPUT + ISNULL(@LineBreakChar + LTRIM(@Strasse + ISNULL(' ' + @HausNr, '')), '')
                  END;
  END;
  
  -- postfach (ML) (must be after StrasseNr and before PLZOrt)
  IF (@ShowPostfach = 1)
  BEGIN
    -- init var
    SET @PostfachText = dbo.fnBaGetPostfachText(NULL, @Postfach, @PostfachOhneNr, @LanguageCode);
    
    -- append postfach depending on content
    SET @OUTPUT = CASE
                    WHEN ISNULL(@OUTPUT, '') = '' OR RIGHT(@OUTPUT, @LenLineBreak) = @LineBreakChar THEN @OUTPUT + ISNULL(@PostfachText, '')
                    ELSE @OUTPUT + ISNULL(@LineBreakChar + @PostfachText, '')
                  END;
  END;
  
  -- plz ort
  IF (@ShowPLZOrt = 1)
  BEGIN
    SET @OUTPUT = CASE
                    WHEN ISNULL(@OUTPUT, '') = '' OR RIGHT(@OUTPUT, @LenLineBreak) = @LineBreakChar THEN @OUTPUT + RTRIM(ISNULL(@PLZ + ' ', '') + ISNULL(@Ort, ''))
                    ELSE @OUTPUT + ISNULL(@LineBreakChar + RTRIM(ISNULL(@PLZ + ' ', '') + @Ort), '')
                  END;
  END;
  
  -- kanton
  IF (@ShowKanton = 1)
  BEGIN
    SET @OUTPUT = CASE
                    WHEN ISNULL(@OUTPUT, '') = '' OR RIGHT(@OUTPUT, @LenLineBreak) = @LineBreakChar THEN @OUTPUT + ISNULL(@Kanton, '')
                    ELSE @OUTPUT + ISNULL(@LineBreakChar + @Kanton, '')
                  END;
  END;
  
  -- bezirk
  IF (@ShowBezirk = 1)
  BEGIN
    SET @OUTPUT = CASE
                    WHEN ISNULL(@OUTPUT, '') = '' OR RIGHT(@OUTPUT, @LenLineBreak) = @LineBreakChar THEN @OUTPUT + ISNULL(@Bezirk, '')
                    ELSE @OUTPUT + ISNULL(@LineBreakChar + @Bezirk, '')
                  END;
  END;
  
  -- land (ML)(special)
  IF (@ShowLand = 1)
  BEGIN
    SET @OUTPUT = CASE 
                    WHEN ISNULL(@OUTPUT, '') = '' OR RIGHT(@OUTPUT, @LenLineBreak) = @LineBreakChar THEN @OUTPUT + ISNULL(dbo.fnGetCountryName(@BaLandID, @LanguageCode, @LandMode), '')
                    ELSE @OUTPUT + ISNULL(@LineBreakChar + dbo.fnGetCountryName(@BaLandID, @LanguageCode, @LandMode), '')
                  END;
  END;
  
  -----------------------------------------------------------------------------
  -- return output
  ----------------------------------------------------------------------------- 
  RETURN ISNULL(@OUTPUT, '');
END;
GO