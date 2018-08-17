SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnTmWhLeistungsentscheid
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnTmWhLeistungsentscheid
(
  @BaFinanzplanID int
)
  RETURNS @OUTPUT TABLE (BgBudgetID int, GeehrteFrauHerrName varchar(100), Title1 varchar(200), Title2 varchar(200), Adresse varchar(200), TotIn varchar(20), TotOut varchar(20), BetragGBL varchar(20), BetragMiete varchar(20), Stand varchar(100), DatumUnterschriftAntrag varchar(10), VonDatum varchar(10), BisDatum varchar(10), MaFallName varchar(100), OrgEinheitText1 varchar(2000), OrgLogoMitFMT text, StellenleiterName varchar(100), Sachbearbeiter varchar(100), Sozialarbeiter varchar(100), MaFallFunktion varchar(100))
 
AS 

BEGIN 
--- Leistungsentscheid Test: Select * from fnTmWhLeistungsentscheid 
    DECLARE @BgBudgetID  int
    DECLARE @UserID  int
    DECLARE @GetDate     datetime 

    SELECT @BgBudgetID = BgBudgetID, @GetDate = GetDate() 
    FROM   dbo.BgBudget WITH (READUNCOMMITTED)  
    WHERE BgFinanzplanID = @BaFinanzplanID AND MasterBudget = 1

    DECLARE @TotIn money 
    DECLARE @TotOut money 
    DECLARE @BetragGBL money 
    DECLARE @BetragMiete money 

    SELECT @TotIn = SUM(Betrag) 
    FROM   dbo.fnWhGetFinanzplan(@BgBudgetID, @GetDate)  TMP 
           INNER JOIN dbo.XLOVCode  XPC WITH (READUNCOMMITTED) ON XPC.LOVName = 'BgKategorie' AND XPC.Code = TMP.BgKategorieCode 
    WHERE BgKategorieCode = 1 

    SELECT @TotOut = SUM(CASE WHEN BgKategorieCode = 2 THEN TMP.Betrag ELSE -TMP.Betrag END) 
    FROM   dbo.fnWhGetFinanzplan(@BgBudgetID, @GetDate)  TMP 
           INNER JOIN dbo.XLOVCode  XPC WITH (READUNCOMMITTED) ON XPC.LOVName = 'BgKategorie' AND XPC.Code = TMP.BgKategorieCode 
    WHERE BgKategorieCode IN (2, 4) 

    SELECT @BetragGBL = SUM(Betrag) 
    FROM   dbo.fnWhGetFinanzplan(@BgBudgetID, @GetDate)  TMP 
    WHERE BgKategorieCode = 2 AND BgGruppeCode in (3201) 

    SELECT @BetragMiete = SUM(Betrag) 
    FROM   dbo.fnWhGetFinanzplan(@BgBudgetID, @GetDate)  TMP 
    WHERE BgKategorieCode = 2 AND BgGruppeCode in (3206) 


    DECLARE @TMP TABLE (BgBudgetID int, GeehrteFrauHerrName varchar(100), Title1 varchar(200), Title2 varchar(200), Adresse varchar(200), TotIn varchar(20), TotOut varchar(20), BetragGBL varchar(20), BetragMiete varchar(20), Stand varchar(100), DatumUnterschriftAntrag varchar(10), VonDatum varchar(10), BisDatum varchar(10), UserID int, Sachbearbeiter varchar(100))
    INSERT @TMP(BgBudgetID, GeehrteFrauHerrName, Title1, Title2, Adresse, TotIn, TotOut, BetragGBL, BetragMiete, Stand, DatumUnterschriftAntrag, VonDatum, BisDatum, UserID, Sachbearbeiter)
    SELECT BBG.BgBudgetID, 
           GeehrteFrauHerrName = 
                 CASE PRS.GeschlechtCode 
                         WHEN 1 THEN 'Sehr geehrter Herr ' 
                         WHEN 2 THEN 'Sehr geehrte Frau ' 
                 ELSE '' 
                 END + PRS.Name, 
           Title1          = PRS.Name + ' ' + PRS.Vorname + ', Fall-Nr. ' + CONVERT(varchar, LEI.FaFallID) + ', Wirtschaftliche Hilfe',
           Title2          = 'Leistungsentscheid für die Zeit vom ' + IsNull(CONVERT(varchar, SFP.DatumVon, 104), CONVERT(varchar, SFP.GeplantVon, 104)) + ' bis ' + IsNull(CONVERT(varchar, SFP.DatumBis, 104), CONVERT(varchar, SFP.GeplantBis, 104)),
           Adresse         = IsNull(CASE PRS.GeschlechtCode WHEN 1 THEN 'Herr' WHEN 2 THEN 'Frau' END + char(13) + char(10),'') +
                                         PRS.Vorname + ' ' + PRS.Name + char(13) + char(10) + 
                                         PRS.WohnsitzStrasseHausNr + char(13) + char(10) + 
                                         PRS.WohnsitzPLZOrt, 
           TotIn           = IsNull(LTrim(STR(@TotIn, 19, 2)), ''),
           TotOut          = IsNull(LTrim(STR(@TotOut, 19, 2)), ''),
           BetragGBL       = IsNull(LTrim(STR(@BetragGBL, 19, 2)), ''),
           BetragMiete     = IsNull(LTrim(STR(@BetragMiete, 19, 2)), ''),
           Stand           = IsNull(CONVERT(varchar, BBW.Datum, 104), ''),
           DatumUnterschriftAntrag = IsNull(CONVERT(varchar, SFP.UnterschriftAntrag, 104), ''),
           VonDatum        = IsNull(CONVERT(varchar, SFP.DatumVon, 104), CONVERT(varchar, SFP.GeplantVon, 104)),
           BisDatum        = IsNull(CONVERT(varchar, SFP.DatumBis, 104), CONVERT(varchar, SFP.GeplantBis, 104)),
           LEI.UserID, 
           LEI.SachbearbeiterID
    FROM   dbo.BgBudget BBG WITH (READUNCOMMITTED) 
           INNER JOIN dbo.BgFinanzplan  SFP  WITH (READUNCOMMITTED) ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
           INNER JOIN dbo.FaLeistung    LEI  WITH (READUNCOMMITTED) ON LEI.FaLeistungID = SFP.FaLeistungID 
           INNER JOIN dbo.vwPerson      PRS  ON PRS.BaPersonID = LEI.BaPersonID 
           LEFT  JOIN dbo.FaFall        FAL  WITH (READUNCOMMITTED) ON FAL.FaFallID = LEI.FaFallID 
           LEFT  JOIN dbo.BgBewilligung BBW  WITH (READUNCOMMITTED) ON BBW.BgFinanzplanID = SFP.BgFinanzplanID
                                                                   AND BBW.BgBewilligungID = (SELECT TOP 1 BgBewilligungID
                                                                                              FROM dbo.BgBewilligung WITH (READUNCOMMITTED) 
                                                                                              WHERE BgFinanzplanID = SFP.BgFinanzplanID
                                                                                                AND BgBewilligungCode = 2 
                                                                                                AND BgBudgetID IS NULL 
                                                                                              ORDER BY Datum DESC)
    WHERE LEI.ModulID = 3 
    AND BBG.BgBudgetID = @BgBudgetID 
    --AND SFP.BgBewilligungStatusCode in (5, 9) -- nur bewilligte 
    --lov BewilligungStatus

  -- Himnzujoinen der User View
    INSERT @OUTPUT(BgBudgetID, GeehrteFrauHerrName, Title1, Title2, Adresse, TotIn, TotOut, BetragGBL, BetragMiete, Stand, DatumUnterschriftAntrag, VonDatum, BisDatum, MaFallName, OrgEinheitText1, OrgLogoMitFMT, StellenleiterName, Sachbearbeiter, Sozialarbeiter, MaFallFunktion)
    SELECT BgBudgetID, 
           GeehrteFrauHerrName, 
           Title1, 
           Title2, 
           Adresse, 
           TotIn, 
           TotOut, 
           BetragGBL, 
           BetragMiete, 
           Stand, 
           DatumUnterschriftAntrag, 
           VonDatum,
           BisDatum,
           MaFallName        = USR.FirstName + ' ' + USR.LastName,
           OrgEinheitText1   = USR.OrgEinheitText1, 
           OrgLogoMitFMT     = USR.OrgEinheitText1RTF, 
           StellenleiterName = SL.FirstName + ' ' + SL.LastName,
           SachbearbeiterID  = IsNull(SA.LogonName, 'nicht zugewiesen'),
           Sozialarbeiter	= USR.Logonname,
           MaFallFunktion	= USR.Funktion
    FROM @TMP TMP
         LEFT JOIN dbo.vwUser USR  ON USR.UserID = TMP.UserID
         LEFT JOIN dbo.XUser  SA   WITH (READUNCOMMITTED) ON SA.UserID = TMP.Sachbearbeiter
         LEFT JOIN dbo.XUser  SL   WITH (READUNCOMMITTED) ON SL.UserID = USR.StellenleiterID
         
               
  RETURN 
END 

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
