SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwShMassendruckPapierverfuegung
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Views/vwShMassendruckPapierverfuegung.sql $
  $Author: Lgreulich $
  $Modtime: 30.07.09 15:24 $
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Template für neue Views
  -
  RETURNS: .
  -
  TEST:    SELECT * FROM vwTable
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Views/vwShMassendruckPapierverfuegung.sql $
 * 
 * 5     30.07.09 15:24 Lgreulich
 * 
 * 4     30.07.09 15:08 Lgreulich
 * 
 * 3     30.07.09 14:16 Lgreulich
 * 
 * 2     30.07.09 12:40 Lgreulich
 * 
 * 1     15.07.09 12:36 Lgreulich
 * Für neue Abfrage Massendruck Papierverfügung
 * 
 * 
 * VSS First
=================================================================================================*/

CREATE VIEW dbo.vwShMassendruckPapierverfuegung
AS

SELECT USR.UserID,
         FAL.BaPersonID,
         BDG.BgBudgetID,
         BDG.Monat,
         BDG.Jahr,
         FBL.KbBuchungID, --FBL.FlBelegID,

         SAR         = IsNull(USR.FirstName + ' ', '') + USR.LastName,
         Klient      = PRS.NameVorname,
         BudgetMonat = dbo.fnXMonat(BDG.Monat) + ' ' + CONVERT(varchar, BDG.Jahr),
         Intern      = (SELECT TOP 1 FKA.Buchungstext
                        FROM  dbo.KbBuchungKostenart FKA WITH (READUNCOMMITTED)                              
                        WHERE FKA.KbBuchungID = FBL.KbBuchungID
                        ORDER BY CASE
                          WHEN FKA.Buchungstext LIKE 'Grundbedarf 2%'  THEN -9
                          WHEN FKA.Buchungstext LIKE 'Grundbedarf%'    THEN -10
                          WHEN FKA.Buchungstext LIKE 'Nebenkosten%'    THEN 900
                          WHEN FKA.Buchungstext LIKE 'VVG%'            THEN 999
                          ELSE FKA.BgKostenartID
                        END), -- dadurch: Grundbedarf zuerst
         FBL.Betrag,
         SelPrint   = CONVERT(bit,0),
         SFP.BgFinanzplanID
  FROM   dbo.FaLeistung FAL WITH (READUNCOMMITTED)
         INNER JOIN dbo.BgFinanzplan SFP WITH (READUNCOMMITTED) on SFP.FaLeistungID = FAL.FaLeistungID
         INNER JOIN dbo.BgBudget     BDG WITH (READUNCOMMITTED) on BDG.BgFinanzplanID = SFP.BgFinanzplanID
         INNER JOIN dbo.KbBuchung    FBL WITH (READUNCOMMITTED) on FBL.BgBudgetID = BDG.BgBudgetID
                                        AND FBL.KbAuszahlungsArtCode = 102 -- via Papierverfügung
                                        AND FBL.KbBuchungTypCode = 1 -- Budget
                                        AND FBL.KbBuchungStatusCode = 2 -- freigegeben
         INNER JOIN dbo.XUser        USR WITH (READUNCOMMITTED) on USR.UserID = FAL.UserID
         INNER JOIN dbo.vwPerson     PRS on PRS.BaPersonID = FAL.BaPersonID
 WHERE   FAL.ModulID = 3

GO