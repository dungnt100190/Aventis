SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spABAGetKlientenstammdatenData;
GO
/*===============================================================================================
  $Revision: 12 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this sp to get all client data used for Abacus Klientenstammdaten-interface
    @MandantenNr:  The mandantennr to use for filtering data
    @LanguageCode: The languagecode to use (1=german)
  -
  RETURNS: Table containing all data used for export to abacus int 'Adresse' and 'Klientenkonto'
  -
  TEST:    EXEC spABAGetKlientenstammdatenData 41, 1
           EXEC spABAGetKlientenstammdatenData 41, 2
           EXEC spABAGetKlientenstammdatenData 41,  1
=================================================================================================*/

CREATE PROCEDURE [dbo].[spABAGetKlientenstammdatenData]
(
  @MandantenNr INT,
  @BaPersonID INT = NULL,
  @LanguageCode INT = 1 -- by default 'german'
)
AS 
BEGIN
  -------------------------------------------------------------------------------
  -- validate
  -------------------------------------------------------------------------------
  IF (ISNULL(@MandantenNr, -1) < 1)
  BEGIN
    -- invalid values
    RETURN;
  END;
  
  -------------------------------------------------------------------------------
  -- run query
  -------------------------------------------------------------------------------
  SELECT DoExport = CONVERT(BIT, 0),
         Mandantennummer = dbo.fnOrgUnitHierarchyValue(ORG.OrgUnitID, 'mndnr'),
         
         -- XUser
         USR.UserID,
         USR.MitarbeiterNr,
         USR.FirstName,
         USR.LastName,
         Sachbearbeiter = dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName) + ISNULL(' (' + USR.LogonName + ')', ''),
         
         -- XOrgUnit
         ORG.ItemName, 
         ORG.Kostenstelle, 
         
         -- BaPerson
         PRS.KontoFuehrung,
         PRS.KlientenkontoNr,
         PRS.DebitorUpdate,
         PRS.BaPersonId, 
         PRS.Name, 
         PRS.Vorname, 
         WohnsitzZusatz  = ADRW.Zusatz,
         WohnsitzStrasse = ADRW.Strasse, 
         WohnsitzHausNr  = ADRW.HausNr,
         StrasseHausNr   = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 0, 'wohnsitz', 0, 0, NULL, NULL, 0, 0, 1, 0, 0, 0, 0, 0, 0),
         Postfach        = dbo.fnBaGetPostfachText(NULL, ADRW.Postfach, ADRW.PostfachOhneNr, @LanguageCode),
         WohnsitzPLZ     = ADRW.PLZ, 
         WohnsitzOrt     = ADRW.Ort,    
         PlzOrt        = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 0, 'wohnsitz', 0, 0, NULL, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0),   
         WohnsitzLandCodeISO2 = (SELECT LAN.Iso2Code                               -- country as 2 chars
                                 FROM dbo.BaLand LAN WITH (READUNCOMMITTED)
                                 WHERE LAN.BaLandID = ISNULL(ADRW.BaLandID, 147)), -- 147 = LandCode für CH
         SpracheChar = CASE 
                         WHEN PRS.SprachCode = 1 THEN 'D'
                         WHEN PRS.SprachCode = 2 THEN 'F'
                         WHEN PRS.SprachCode = 3 THEN 'I'
                         WHEN PRS.SprachCode = 4 THEN 'E'
                         ELSE 'D'
                       END,
         
         -- additional      
         StatusInsUpd = dbo.fnLOVMLText('AbaKlientenstammdatenKlientenStatus', CONVERT(INT, CASE 
                                                                                              WHEN ISNULL(PRS.KlientenkontoNr, -1) < 0 THEN 0 -- 0='new'
                                                                                              ELSE 1                                    -- 1='update'
                                                                                            END), @LanguageCode),
         StatusExportResult = CONVERT(VARCHAR, ''),
         Waehrung           = 'CHF' -- const
  FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
    INNER JOIN dbo.FaLeistung LEI  WITH (READUNCOMMITTED) ON LEI.BaPersonID = PRS.BaPersonID 
                                                         AND LEI.FaLeistungID = dbo.fnFaGetLastFaLeistungID(PRS.BaPersonID, 2) -- get last FV!
                                                         AND LEI.DatumBis IS NULL                                              -- only open FV is important
    INNER JOIN dbo.XUser      USR  WITH (READUNCOMMITTED) ON USR.UserID = LEI.UserID
    INNER JOIN dbo.XOrgUnit   ORG  WITH (READUNCOMMITTED) ON ORG.OrgUnitID = CONVERT(INT, dbo.fnOrgUnitOfUser(LEI.UserID, 1)) -- only membership
    
    -- wohnsitz
    LEFT JOIN dbo.BaAdresse   ADRW WITH (READUNCOMMITTED) ON ADRW.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 1, NULL)
  WHERE ISNULL(PRS.KontoFuehrung, 0) = 1
    AND PRS.BaPersonID = ISNULL(@BaPersonID, PRS.BaPersonID)
    AND dbo.fnOrgUnitHierarchyValue(ORG.OrgUnitID, 'mndnr') = @MandantenNr;
END;
GO
