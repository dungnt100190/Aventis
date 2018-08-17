SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spFaGetFallInfoData
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Stored Procedures/Fallführung/spFaGetFallInfoData.sql $
  $Author: Lloreggia $
  $Modtime: 6.01.10 18:18 $
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this sp to get all data of case information
    @BaPersonID:   The id of the person of which data has to be retrieved
    @LanguageCode: The languagecode to use (1=german)
  -
  RETURNS: Table containing all neccessary data to use for displaying case information
  -
  TEST:    EXEC dbo.spFaGetFallInfoData 333, 1
           EXEC dbo.spFaGetFallInfoData 333, 2
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Stored Procedures/Fallführung/spFaGetFallInfoData.sql $
 * 
 * 6     6.01.10 18:21 Lloreggia
 * Alter to Create
 * 
 * 5     6.08.09 11:38 Cjaeggi
 * #5023: Fixed default value behaviour
 * 
 * 4     2.12.08 16:55 Cjaeggi
 * Added FaLeistungID (for debugging others)
 * 
 * 3     6.11.08 9:42 Cjaeggi
 * Changed ordering of data
 * 
 * 2     28.10.08 16:02 Cjaeggi
 * BugFix labels
 * 
 * 1     27.10.08 16:38 Cjaeggi
 * New created
=================================================================================================*/

CREATE PROCEDURE dbo.spFaGetFallInfoData
(
 @BaPersonID INT,
 @LanguageCode INT = 1 -- by default 'german'
)
AS
  -------------------------------------------------------------------------------
  -- validate
  -------------------------------------------------------------------------------
  -- set default values
  SET @BaPersonID   = ISNULL(@BaPersonID, -1)
  SET @LanguageCode = ISNULL(@LanguageCode, 1)
  
  -------------------------------------------------------------------------------
  -- run query
  -------------------------------------------------------------------------------
  SELECT -- info only
         LEI.FaLeistungID,
         
         -- header
         [Key]                      = CONVERT(VARCHAR, LFV.FaLeistungID) + CONVERT(VARCHAR, LEI.FaLeistungID),
         Fallverlauf                = dbo.fnXDbObjectMLMsg('spFaGetFallInfoData', 'GroupHeaderFallverlauf', @LanguageCode) + ' ' + 
                                      CONVERT(VARCHAR, ISNULL(LFV.FaLeistungID, -1)) + ' ' +
                                      '(' + 
                                      CASE WHEN LFV.DatumBis IS NULL THEN dbo.fnXDbObjectMLMsg('spFaGetFallInfoData', 'GroupHeaderAktiv', @LanguageCode)
                                           ELSE dbo.fnXDbObjectMLMsg('spFaGetFallInfoData', 'GroupHeaderAbgeschlossen_v01', @LanguageCode)
                                      END + ')' +
                                      '  -  ' +
                                      dbo.fnXDbObjectMLMsg('spFaGetFallInfoData', 'GroupHeaderMitarbeiter_v01', @LanguageCode) + ': ' + 
                                      dbo.fnGetLastFirstName(LFV.UserID, NULL, NULL),
        
         -- Fallverlauf
         IsFallverlauf              = CONVERT(BIT, CASE WHEN LEI.ModulID = 2 THEN 1
                                                        ELSE 0
                                                   END),
         FVDatumVon                 = LFV.DatumVon,
         FVDatumBis                 = LFV.DatumBis,
         
         -- Leistung
         Icon                       = ICO.Icon,
         ModulID                    = LEI.ModulID,
         
         DatumVon                   = LEI.DatumVon,
         DatumBis                   = LEI.DatumBis,
         LeistungModulName          = dbo.fnGetLOVMLText('Modul', LEI.ModulID, @LanguageCode),
         
         -- Mitarbeiter
         MANameVorname              = dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName) + ISNULL(' (' + USR.LogonName + ')', ''),
         MAAbteilung                = dbo.fnOrgUnitOfUser(LEI.UserID, 0),
         MATelefon                  = COALESCE(USR.PhoneOffice, USR.PhoneIntern, USR.PhonePrivat),
         MAEmail                    = USR.EMail
         
  FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
    -- Fallverlauf
    LEFT JOIN dbo.FaLeistung       LFV WITH (READUNCOMMITTED) ON LFV.FaLeistungID = dbo.fnFaGetFallIDOfDL(LEI.FaLeistungID, NULL)
    
    -- Leistung
    LEFT JOIN dbo.FaLeistungArchiv ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = LEI.FaLeistungID AND ARC.CheckOut IS NULL
    LEFT JOIN dbo.XIcon            ICO WITH (READUNCOMMITTED) ON ICO.XIconID = 1000 + 100 * LEI.ModulID + ISNULL(CASE WHEN ARC.FaLeistungID IS NOT NULL THEN 3 -- archived
                                                                                                                      WHEN LEI.DatumBis IS NOT NULL     THEN 2 -- closed
                                                                                                                      ELSE 1 -- open
                                                                                                                 END, 0)
    LEFT JOIN dbo.XUser            USR WITH (READUNCOMMITTED) ON USR.UserID = LEI.UserID
    
  WHERE LEI.BaPersonID = @BaPersonID -- only current person
  ORDER BY IsFallverlauf DESC, FVDatumVon DESC, DatumVon DESC, [Key] DESC




 