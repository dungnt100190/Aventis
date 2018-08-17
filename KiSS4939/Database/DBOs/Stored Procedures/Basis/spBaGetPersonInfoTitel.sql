SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spBaGetPersonInfoTitel;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Stored Procedures/Basis/spBaGetPersonInfoTitel.sql $
  $Author: Cjaeggi $
  $Modtime: 9.08.10 9:46 $
  $Revision: 10 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Get specific information for given person used for title-bar in CtlFall.
            If user is BiagAdmin, the title will also show the BaPersonID for info purpose.
            --
            Reads data from XConfig:
            > System\GUI\Basis\PersonInfoTitelText:
              > "<{BaPersonID}>"               Tag: Will be replaced by given BaPersonID
              > "<{NameVorname}>"              Tag: Will be replaced by "Name, Vorname" of the person
              > "<{Age}>"                      Tag: Will be replaced by the age of the person
              > "<{GebDatum}>"                 Tag: Will be replaced by BaPerson.Geburtsdatum as dd.mm.yyyy
              > "<{GebTodDatum}>"              Tag: Will be replaced by BaPerson.Geburtsdatum as dd.mm.yyyy and
                                                    " - " + BaPerson.Sterbedatum as dd.mm.yyyy if at least one of
                                                    thouse values are given
              > "<{AHVNr}>"                    Tag: Will be replaced by BaPerson.AHVNummer
              > "<{VersNr}>"                   Tag: Will be replaced by BaPerson.Versichertennummer
              > "<{NNr}>"                      Tag: Will be replaced by BaPerson.NNummer
              > "<{AuslaenderStatus:LOVName}>" Tag: Will be replaced by BaPerson.AuslaenderStatusCode as ml-text from given LOV
              > "<{WohnsitzOrt}>"              Tag: Will be replaced by vwPerson.WohnsitzOrt
              ----
              > "<{PI:WohnsitzOrt}>"           Tag: Will be replaced by the place of residence of the person (PI specific)
              > "<{PI:TelNrs}>"                Tag: Will be replaced by private, business and mobile phone numbers (PI specific)
              ----
              > "{-}" Token: Will be replaced by "-" if the followed value has content (e.g. "-Value")
              > "{,}" Token: Will be replaced by "," if the followed value has content (e.g. ",Value")
              > "{(}" Token: Will be replaced by "(" if the followed value has content (e.g. "(Value")
              > "{)}" Token: Will be replaced by ")" if the followed value has content (e.g. "Value)")
              > "{#}" Token: Will be replaced by " " if the followed value has content (e.g. " Value")
              ----
              Example: "<{NameVorname}><{#}{-}{#}{PI:WohnsitzOrt}><{,}{#}{Age}><{#}{-}{#}{PI:TelNrs}>"
            > System\GUI\Basis\PersonInfoTitelImage:
              > "Number"                          Tag: If no special handling is required, this value is the image index number
              > "<{PI:IF:WichtigerHinweis:%:%:}>" Tag: Will take the first number (%) if WichtigerHinweis is empty, 
                                                       otherwise the second number (%) (PI specific)
              ----
              Example: "132" or "<{PI:IF:WichtigerHinweis:5020:5021:}>"
            > System\GUI\Basis\PersonInfoToolTipText:
              > ""                           Tag: No tooltip text will be shown
              > "<{PI:IF:WichtigerHinweis}>" Tag: Will take the text of WichtigerHinweis if any defined, otherwise empty (PI specific)
    @BaPersonID:   The id of the person to get data for
    @UserID:       The id of the user who requests the data
    @LanguageCode: The language code used for multilanguage content
  -
  RETURNS: Three columns within one table: TitleText, ImageIndex, ToolTipText
  -
  TEST:    EXEC dbo.spBaGetPersonInfoTitel 333, 2, 1
=================================================================================================
  WARNING: This object is shared in Visual SourceSafe, beware of changes!
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Stored Procedures/Basis/spBaGetPersonInfoTitel.sql $
 * 
 * 10    9.08.10 9:50 Cjaeggi
 * #4167: Fixed after changes
 * 
 * 9     13.04.10 14:33 Cjaeggi
 * #6071: Fixed length problem with GebTodDatum
 * 
 * 8     13.04.10 14:28 Cjaeggi
 * #6071: Update person title handling
 * 
 * 7     14.01.10 11:52 Cjaeggi
 * #672: Optimized with ELSE
 * 
 * 6     14.01.10 11:38 Cjaeggi
 * #672: Updated tokens
 * 
 * 5     14.01.10 11:35 Cjaeggi
 * #672: Added more tokens
 * 
 * 4     14.01.10 11:19 Cjaeggi
 * #672: Added more tags for getting data
 * 
 * 3     13.01.10 16:16 Cjaeggi
 * #672: Updated items
 * 
 * 2     13.01.10 11:28 Cjaeggi
 * #672: Replaced fn GetPersonTitle
 * 
 * 1     13.01.10 10:18 Cjaeggi
 * #672: Updated content
 * 
 * 1     13.01.10 9:08 Cjaeggi
 * #672: Fall info titel
=================================================================================================*/

CREATE PROCEDURE dbo.spBaGetPersonInfoTitel
(
  @BaPersonID INT,
  @UserID INT,
  @LanguageCode INT
)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- start call
  -----------------------------------------------------------------------------
  SET NOCOUNT ON;
  
  -----------------------------------------------------------------------------
  -- declare and init vars
  -----------------------------------------------------------------------------
  -- declare vars
  DECLARE @ConfigTitleText VARCHAR(500);
  DECLARE @ConfigTitleImage VARCHAR(500);
  DECLARE @ConfigTitleToolTipText VARCHAR(500);
  
  DECLARE @ReturnTitleText VARCHAR(4000);
  DECLARE @ReturnTitleImageIndex INT;
  DECLARE @ReturnTitleToolTipText VARCHAR(1000);
  
  DECLARE @SplitValue VARCHAR(200);
  DECLARE @SplitValueHasReplaceContent BIT;
  
  -- set vars
  SET @ConfigTitleText        = ISNULL(CONVERT(VARCHAR(500), dbo.fnXConfig('System\GUI\Basis\PersonInfoTitelText', GETDATE())), '');
  SET @ConfigTitleImage       = ISNULL(CONVERT(VARCHAR(500), dbo.fnXConfig('System\GUI\Basis\PersonInfoTitelImage', GETDATE())), '');
  SET @ConfigTitleToolTipText = ISNULL(CONVERT(VARCHAR(500), dbo.fnXConfig('System\GUI\Basis\PersonInfoToolTipText', GETDATE())), '');
  
  SET @ReturnTitleText = '';
  SET @ReturnTitleImageIndex = 0;
  SET @ReturnTitleToolTipText = NULL;
  
  SET @SplitValue = NULL;
  SET @SplitValueHasReplaceContent = 0;
  
  -- DEBUG ONLY
  /*
  SET @ConfigTitleText = '<{NameVorname}><{@}{GebDatum}><{@}{AHVNr}><{@}{WohnsitzOrt}><{@}{VersNr}><{@}{AuslaenderStatus:BaAuslaenderAufenthaltStatus}>'
  --*/
  
  -----------------------------------------------------------------------------
  -- append id if biagadmin
  -----------------------------------------------------------------------------
  IF ((SELECT dbo.fnIsUserBIAGAdmin(@UserID)) = 1)
  BEGIN
    -- append bapersonid for information
    SET @ConfigTitleText = @ConfigTitleText + ' - [Id: <{BaPersonID}>]';
  END
  
  --===========================================================================
  -- build @ReturnTitleText with cursor
  --===========================================================================
  -- setup cursor
  DECLARE curSplitTitleText CURSOR FAST_FORWARD FOR
    SELECT FCN.SplitValue
    FROM dbo.fnSplitStringToValues(@ConfigTitleText, '<', 1) FCN;
  
  -- iterate through cursor
  OPEN curSplitTitleText;
  WHILE (1 = 1)
  BEGIN
    -- read next row and check if we have one
    FETCH NEXT 
    FROM curSplitTitleText 
    INTO @SplitValue;
    
    IF (@@FETCH_STATUS != 0)
    BEGIN
      BREAK;
    END;
    
    -- reset flags
    SET @SplitValueHasReplaceContent = 0;
    
    -- replace final ">"
    SET @SplitValue = REPLACE(@SplitValue, '>', '');
    
    --=========================================================================
    -- replace tags
    --=========================================================================
    ---------------------------------------------------------------------------
    -- "{BaPersonID}"
    ---------------------------------------------------------------------------
    IF (@SplitValue LIKE '%{BaPersonID}%')
    BEGIN
      -- replace tag with data
      SET @SplitValue = REPLACE(@SplitValue, '{BaPersonID}', ISNULL(CONVERT(VARCHAR(10), @BaPersonID), ''));
    END;
    
    ---------------------------------------------------------------------------
    -- "{NameVorname}"
    ---------------------------------------------------------------------------
    ELSE IF (@SplitValue LIKE '%{NameVorname}%')
    BEGIN
      -- init var
      DECLARE @NameVorname VARCHAR(200);
      
      -- get data
      SELECT @NameVorname = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname),
             @SplitValueHasReplaceContent = 1 -- name is mandatory
      FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
      WHERE PRS.BaPersonID = @BaPersonID;
      
      -- replace tag with data
      SET @SplitValue = REPLACE(@SplitValue, '{NameVorname}', ISNULL(@NameVorname, ''));
    END;
    
    ---------------------------------------------------------------------------
    -- "{Age}"
    ---------------------------------------------------------------------------
    ELSE IF (@SplitValue LIKE '%{Age}%')
    BEGIN
      -- init var
      DECLARE @Age VARCHAR(4);
      
      -- get data
      SELECT @Age = CONVERT(VARCHAR(4), dbo.fnGetAge(PRS.Geburtsdatum, ISNULL(PRS.Sterbedatum, GETDATE()))),
             @SplitValueHasReplaceContent = CASE
                                              WHEN PRS.Geburtsdatum IS NULL THEN 0
                                              ELSE 1
                                            END
      FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
      WHERE PRS.BaPersonID = @BaPersonID;
      
      -- replace tag with data
      SET @SplitValue = REPLACE(@SplitValue, '{Age}', ISNULL(@Age, ''));
    END;
    
    ---------------------------------------------------------------------------
    -- "{GebDatum}"
    ---------------------------------------------------------------------------
    ELSE IF (@SplitValue LIKE '%{GebDatum}%')
    BEGIN
      -- init var
      DECLARE @GebDatum VARCHAR(10);
      
      -- get data
      SELECT @GebDatum = CONVERT(VARCHAR(10), PRS.Geburtsdatum, 104),
             @SplitValueHasReplaceContent = CASE
                                              WHEN PRS.Geburtsdatum IS NULL THEN 0
                                              ELSE 1
                                            END
      FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
      WHERE PRS.BaPersonID = @BaPersonID;
      
      -- replace tag with data
      SET @SplitValue = REPLACE(@SplitValue, '{GebDatum}', ISNULL(@GebDatum, ''));
    END;
    
    ---------------------------------------------------------------------------
    -- "{GebTodDatum}"
    ---------------------------------------------------------------------------
    ELSE IF (@SplitValue LIKE '%{GebTodDatum}%')
    BEGIN
      -- init var
      DECLARE @GebTodDatum VARCHAR(30);
      
      -- get data
      SELECT @GebTodDatum = LTRIM(ISNULL(CONVERT(VARCHAR(10), PRS.Geburtsdatum, 104), '') + 
                                  ISNULL(' - ' + CONVERT(VARCHAR(10), PRS.Sterbedatum, 104), '')),
             @SplitValueHasReplaceContent = CASE
                                              WHEN (PRS.Geburtsdatum IS NULL AND PRS.Sterbedatum IS NULL) THEN 0
                                              ELSE 1
                                            END
      FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
      WHERE PRS.BaPersonID = @BaPersonID;
      
      -- replace tag with data
      SET @SplitValue = REPLACE(@SplitValue, '{GebTodDatum}', ISNULL(@GebTodDatum, ''));
    END;
    
    ---------------------------------------------------------------------------
    -- "{AHVNr}"
    ---------------------------------------------------------------------------
    ELSE IF (@SplitValue LIKE '%{AHVNr}%')
    BEGIN
      -- init var
      DECLARE @AHVNr VARCHAR(16);
      
      -- get data
      SELECT @AHVNr = PRS.AHVNummer,
             @SplitValueHasReplaceContent = CASE
                                              WHEN PRS.AHVNummer IS NULL THEN 0
                                              ELSE 1
                                            END
      FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
      WHERE PRS.BaPersonID = @BaPersonID;
      
      -- replace tag with data
      SET @SplitValue = REPLACE(@SplitValue, '{AHVNr}', ISNULL(@AHVNr, ''));
    END;
    
    ---------------------------------------------------------------------------
    -- "{VersNr}"
    ---------------------------------------------------------------------------
    ELSE IF (@SplitValue LIKE '%{VersNr}%')
    BEGIN
      -- init var
      DECLARE @VersNr VARCHAR(18);
      
      -- get data
      SELECT @VersNr = PRS.VersichertenNummer,
             @SplitValueHasReplaceContent = CASE
                                              WHEN PRS.VersichertenNummer IS NULL THEN 0
                                              ELSE 1
                                            END
      FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
      WHERE PRS.BaPersonID = @BaPersonID;
      
      -- replace tag with data
      SET @SplitValue = REPLACE(@SplitValue, '{VersNr}', ISNULL(@VersNr, ''));
    END;
    
    ---------------------------------------------------------------------------
    -- "{NNr}"
    ---------------------------------------------------------------------------
    ELSE IF (@SplitValue LIKE '%{NNr}%')
    BEGIN
      -- init var
      DECLARE @NNr VARCHAR(20);
      
      -- get data (!column is not available everywhere!)
      EXEC sp_executesql N'
        SELECT @NNr = PRS.NNummer,
               @SplitValueHasReplaceContent = CASE
                                                WHEN PRS.NNummer IS NULL THEN 0
                                                ELSE 1
                                              END
        FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
        WHERE PRS.BaPersonID = @BaPersonID;', 
        N'@BaPersonID INT, @NNr VARCHAR(20) OUTPUT, @SplitValueHasReplaceContent BIT OUTPUT', 
        @BaPersonID, @NNr OUTPUT, @SplitValueHasReplaceContent OUTPUT;
      
      -- replace tag with data
      SET @SplitValue = REPLACE(@SplitValue, '{NNr}', ISNULL(@NNr, ''));
    END;
    
    ---------------------------------------------------------------------------
    -- "{AuslaenderStatus:%}"
    ---------------------------------------------------------------------------
    ELSE IF (@SplitValue LIKE '%{AuslaenderStatus:%}%')
    BEGIN
      -- init var
      DECLARE @AuslaenderStatus VARCHAR(255);
      DECLARE @AuslaenderStatusLOVName VARCHAR(100);
      
      -- split content
      SELECT @AuslaenderStatusLOVName = CONVERT(VARCHAR(100), FCN.SplitValue)
      FROM dbo.fnSplitStringToValues(RTRIM(@SplitValue), ':', 1) FCN
      WHERE FCN.OccurenceID = 1; -- second row is LOVName
      
      -- remove trailing content from LOVName
      SET @AuslaenderStatusLOVName = REPLACE(@AuslaenderStatusLOVName, 
                                             SUBSTRING(@AuslaenderStatusLOVName, 
                                                       CHARINDEX('}', @AuslaenderStatusLOVName), 
                                                       LEN(@AuslaenderStatusLOVName) - CHARINDEX('}', @AuslaenderStatusLOVName) + 1), '');
      
      -- remove ":LOVName}" from @SplitValue to "}" >> {AuslaenderStatus}
      SET @SplitValue = REPLACE(@SplitValue, ':' + @AuslaenderStatusLOVName + '}', '}');
      
      -- get data
      SELECT @AuslaenderStatus = dbo.fnGetLOVMLText(@AuslaenderStatusLOVName, PRS.AuslaenderStatusCode, @LanguageCode),
             @SplitValueHasReplaceContent = CASE
                                              WHEN PRS.AuslaenderStatusCode IS NULL THEN 0
                                              ELSE 1
                                            END
      FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
      WHERE PRS.BaPersonID = @BaPersonID;
      
      -- replace tag with data
      SET @SplitValue = REPLACE(@SplitValue, '{AuslaenderStatus}', ISNULL(@AuslaenderStatus, ''));
    END;
    
    ---------------------------------------------------------------------------
    -- "{WohnsitzOrt}"
    ---------------------------------------------------------------------------
    ELSE IF (@SplitValue LIKE '%{WohnsitzOrt}%')
    BEGIN
      -- init var
      DECLARE @WohnsitzOrt VARCHAR(50);
      
      -- get data
      SELECT @WohnsitzOrt = PRS.WohnsitzOrt,
             @SplitValueHasReplaceContent = CASE
                                              WHEN PRS.WohnsitzOrt IS NULL THEN 0
                                              ELSE 1
                                            END
      FROM dbo.vwPerson PRS WITH (READUNCOMMITTED)
      WHERE PRS.BaPersonID = @BaPersonID;
      
      -- replace tag with data
      SET @SplitValue = REPLACE(@SplitValue, '{WohnsitzOrt}', ISNULL(@WohnsitzOrt, ''));
    END;
    
    ---------------------------------------------------------------------------
    -- "{PI:TelNrs}"
    ---------------------------------------------------------------------------
    ELSE IF (@SplitValue LIKE '%{PI:TelNrs}%')
    BEGIN
      -- vars
      DECLARE @PITelNrsTelP VARCHAR(100);
      DECLARE @PITelNrsTelG VARCHAR(100);
      DECLARE @PITelNrsTelM VARCHAR(100);
      DECLARE @PITelNrsContainsPhone BIT;
      DECLARE @PITelNrsOutput VARCHAR(350);
      
      -- set default values
      SET @PITelNrsContainsPhone = 0;
      SET @PITelNrsOutput = '';
      
      -- get data (!column is not available everywhere!)
      EXEC sp_executesql N'
        SELECT @PITelNrsTelP = CASE 
                                 WHEN PRS.ZeigeTelPrivat = 1 THEN PRS.Telefon_P
                                 ELSE NULL
                               END,
               @PITelNrsTelG = CASE 
                                 WHEN PRS.ZeigeTelGeschaeft = 1 THEN PRS.Telefon_G 
                                 ELSE NULL
                               END,
               @PITelNrsTelM = CASE 
                                 WHEN PRS.ZeigeTelMobil = 1 THEN PRS.MobilTel
                                 ELSE NULL
                               END
        FROM dbo.BaPerson PRS WITH (READUNCOMMITTED) 
        WHERE PRS.BaPersonID = @BaPersonID;', 
        N'@BaPersonID INT, @PITelNrsTelP VARCHAR(100) OUTPUT, @PITelNrsTelG VARCHAR(100) OUTPUT, @PITelNrsTelM VARCHAR(100) OUTPUT', 
        @BaPersonID, @PITelNrsTelP OUTPUT, @PITelNrsTelG OUTPUT, @PITelNrsTelM OUTPUT;
      
      -- create phone specific output
      IF (@PITelNrsTelP IS NOT NULL OR @PITelNrsTelG IS NOT NULL OR @PITelNrsTelM IS NOT NULL)
      BEGIN
        -- init output for phone values
        SET @PITelNrsOutput = dbo.fnXDbObjectMLMsg('dbGeneral', 'Telefon', @LanguageCode) + ' ';
        
        -- private
        IF (@PITelNrsTelP IS NOT NULL)
        BEGIN
          SET @PITelNrsOutput = @PITelNrsOutput + @PITelNrsTelP + '(' + dbo.fnXDbObjectMLMsg('dbGeneral', 'TelefonPrivat', @LanguageCode) + ')';
          SET @PITelNrsContainsPhone = 1;
        END;
        
        -- office
        IF (@PITelNrsTelG IS NOT NULL)
        BEGIN
          IF (@PITelNrsContainsPhone = 1)
          BEGIN
            SET @PITelNrsOutput = @PITelNrsOutput + ', ';
          END;
          
          SET @PITelNrsOutput = @PITelNrsOutput + @PITelNrsTelG + '(' + dbo.fnXDbObjectMLMsg('dbGeneral', 'TelefonGeschaeft', @LanguageCode) + ')';
          SET @PITelNrsContainsPhone = 1;
        END;
        
        -- mobile
        IF (@PITelNrsTelM IS NOT NULL)
        BEGIN
          IF (@PITelNrsContainsPhone = 1)
          BEGIN
           SET @PITelNrsOutput = @PITelNrsOutput + ', ';
          END;
          
          SET @PITelNrsOutput = @PITelNrsOutput + @PITelNrsTelM + '(' + dbo.fnXDbObjectMLMsg('dbGeneral', 'TelefonMobil', @LanguageCode) + ')';
          SET @PITelNrsContainsPhone = 1;
        END;
      END;
      
      -- set flag
      SET @SplitValueHasReplaceContent = @PITelNrsContainsPhone;
      
      -- replace tag with data
      SET @SplitValue = REPLACE(@SplitValue, '{PI:TelNrs}', ISNULL(@PITelNrsOutput, ''));
    END;
    
    --=========================================================================
    -- replace tokens
    --=========================================================================
    ---------------------------------------------------------------------------
    -- "{-}" = "-"
    ---------------------------------------------------------------------------
    SET @SplitValue = REPLACE(@SplitValue, '{-}', CASE
                                                    WHEN @SplitValueHasReplaceContent = 1 THEN '-'
                                                    ELSE ''
                                                  END);
    
    ---------------------------------------------------------------------------
    -- "{,}" = ","
    ---------------------------------------------------------------------------
    SET @SplitValue = REPLACE(@SplitValue, '{,}', CASE
                                                    WHEN @SplitValueHasReplaceContent = 1 THEN ','
                                                    ELSE ''
                                                  END);
    
    ---------------------------------------------------------------------------
    -- "{(}" = "("
    ---------------------------------------------------------------------------
    SET @SplitValue = REPLACE(@SplitValue, '{(}', CASE
                                                    WHEN @SplitValueHasReplaceContent = 1 THEN '('
                                                    ELSE ''
                                                  END);
    
    ---------------------------------------------------------------------------
    -- "{)}" = ")"
    ---------------------------------------------------------------------------
    SET @SplitValue = REPLACE(@SplitValue, '{)}', CASE
                                                    WHEN @SplitValueHasReplaceContent = 1 THEN ')'
                                                    ELSE ''
                                                  END);
    
    ---------------------------------------------------------------------------
    -- "{#}" = " "
    ---------------------------------------------------------------------------
    SET @SplitValue = REPLACE(@SplitValue, '{#}', CASE
                                                    WHEN @SplitValueHasReplaceContent = 1 THEN ' '
                                                    ELSE ''
                                                  END);
    
    --=========================================================================
    -- append splitvalue to output
    --=========================================================================
    SET @ReturnTitleText = @ReturnTitleText + ISNULL(@SplitValue, '');
  END; -- [WHILE cursor]
  
  -- clean up cursor
  CLOSE curSplitTitleText;
  DEALLOCATE curSplitTitleText;
  
  --===========================================================================
  -- build image index
  --===========================================================================
  -----------------------------------------------------------------------------
  -- "<{PI:IF:WichtigerHinweis:%:%:}>"
  -----------------------------------------------------------------------------
  IF (@ConfigTitleImage LIKE '<{PI:IF:WichtigerHinweis:%:%:}>')
  BEGIN
    -- vars
    DECLARE @PIImgHasWichtigerHinweis BIT;
    
    -- get data (!column is not available everywhere!)
    EXEC sp_executesql N'
      SET @PIImgHasWichtigerHinweis = CASE 
                                        WHEN EXISTS(SELECT TOP 1 1 
                                                    FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
                                                    WHERE PRS.BaPersonID = @BaPersonID
                                                      AND PRS.WichtigerHinweis IS NOT NULL) THEN 1
                                        ELSE 0
                                      END;', 
      N'@BaPersonID INT, @PIImgHasWichtigerHinweis BIT OUTPUT', 
      @BaPersonID, @PIImgHasWichtigerHinweis OUTPUT;
    
    -- if WichigerHinweis is existing, take second number (position 4), otherwise take first number (position 3)
    SELECT @ReturnTitleImageIndex = CONVERT(INT, FCN.SplitValue)
    FROM dbo.fnSplitStringToValues(@ConfigTitleImage, ':', 1) FCN
    WHERE FCN.OccurenceID = CASE 
                              WHEN @PIImgHasWichtigerHinweis = 1 THEN 4 -- second number
                              ELSE 3 -- first number
                            END;
  END;
  
  -----------------------------------------------------------------------------
  -- ELSE
  -----------------------------------------------------------------------------
  ELSE
  BEGIN
    -- by default, we expect just an image-index
    SET @ReturnTitleImageIndex = CONVERT(INT, @ConfigTitleImage);
  END;
  
  --===========================================================================
  -- build tooltip text
  --===========================================================================
  -----------------------------------------------------------------------------
  -- "<{PI:IF:WichtigerHinweis}>"
  -----------------------------------------------------------------------------
  IF (@ConfigTitleToolTipText = '<{PI:IF:WichtigerHinweis}>')
  BEGIN
    -- apply tooltip text if any defined (!column is not available everywhere!)
    EXEC sp_executesql N'
      SELECT @ReturnTitleToolTipText = PRS.WichtigerHinweis
      FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
      WHERE PRS.BaPersonID = @BaPersonID
        AND PRS.WichtigerHinweis IS NOT NULL;', 
      N'@BaPersonID INT, @ReturnTitleToolTipText VARCHAR(1000) OUTPUT', 
      @BaPersonID, @ReturnTitleToolTipText OUTPUT;
  END;
  
  --===========================================================================
  -- show output as table
  --===========================================================================
  SELECT TitleText   = RTRIM(LTRIM(@ReturnTitleText)), 
         ImageIndex  = ISNULL(@ReturnTitleImageIndex, 0), 
         ToolTipText = @ReturnTitleToolTipText;
END;
GO
