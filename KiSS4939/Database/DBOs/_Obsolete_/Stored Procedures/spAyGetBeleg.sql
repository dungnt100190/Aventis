SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spAyGetBeleg
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spAyGetBeleg.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:32 $
  $Revision: 2 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spAyGetBeleg.sql $
 * 
 * 2     25.06.09 11:40 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spAyGetBeleg
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:53
*/
CREATE PROCEDURE dbo.spAyGetBeleg
 (@BgBudgetID   int)
AS BEGIN
--  DECLARE @Belege TABLE (
  CREATE TABLE #Belege (
    FlBelegID          int   NOT NULL ,
    Betrag             money NULL ,

    Verfalldatum       datetime NULL ,
    CashOrCheckAm      datetime NULL ,

    Buchungstext       varchar (120) NULL ,

    KreditorName       varchar (200) NULL ,
    BankName           varchar (50)  NULL ,

    FlTransferCode     int NOT NULL ,
    FlBelegStatusCode  int NOT NULL ,
    IdFibuLaufnummer   int NULL ,
    GeneriertAm        datetime NOT NULL ,
    VerbuchtAm         datetime NULL ,

    Belegnummer        varchar (12) NULL
  )

  INSERT INTO #Belege
    SELECT FLB.FlBelegID,
      (SELECT SUM(Betrag)
       FROM dbo.FlBelegKostenart            FLA WITH (READUNCOMMITTED) 
         INNER JOIN dbo.FlBelegKostenstelle FLS WITH (READUNCOMMITTED) ON FLS.FlBelegKostenartID = FLA.FlBelegKostenartID
       WHERE FLA.FlBelegID = FLB.FlBelegID),

      FLB.Verfalldatum, FLB.CashOrCheckAm,

      FLB.Buchungstext,

      FLK.Name + IsNull(', ' + FLK.Vorname, '') AS KreditorName,
      FLW.BankName,

      FLB.FlTransferCode, FLB.FlBelegStatusCode, FLB.IdFibuLaufnummer,
      FLB.GeneriertAm, FLB.VerbuchtAm, FLB.Belegnummer

    FROM dbo.FlBeleg                FLB WITH (READUNCOMMITTED) 
      LEFT  JOIN dbo.FlZahlungsweg  FLW WITH (READUNCOMMITTED) ON FLW.FlZahlungswegID = FLB.FlZahlungswegID
      LEFT  JOIN dbo.FlKreditor     FLK WITH (READUNCOMMITTED) ON FLK.FlKreditorID = FLW.FlKreditorID

      LEFT  JOIN sShEinzelzahlung  SEZ WITH (READUNCOMMITTED) ON SEZ.BgBudgetID = @BgBudgetID AND SEZ.ShBelegID = FLB.IdSource
    WHERE (FLB.IdSource = @BgBudgetID  AND FLB.FlTypSourceCode = 102)
       OR (SEZ.ShBelegID IS NOT NULL   AND FLB.FlTypSourceCode = 105)

  -- Output Mainview
  SELECT * FROM #Belege
  ORDER BY GeneriertAm, FlBelegID

  -- Output Subview
  SELECT FLB.FlBelegID, FLA.FlKostenartID, FLS.FlKostenstelleID, FLS.NrmKontoCode, FLS.Betrag,
    KST.NameFbKostenstelle + ', ' + KST.NameInhaber  AS Kostenstelle,
    FLA.Intern                                       AS BuchungstextIntern
  FROM #Belege                     FLB
    LEFT JOIN dbo.FlBelegKostenart     FLA WITH (READUNCOMMITTED) ON FLA.FlBelegID = FLB.FlBelegID
    LEFT JOIN dbo.FlBelegKostenstelle  FLS WITH (READUNCOMMITTED) ON FLS.FlBelegKostenartID = FLA.FlBelegKostenartID
    LEFT JOIN dbo.FlKostenstelle       KST WITH (READUNCOMMITTED) ON KST.FlKostenstelleID = FLS.FlKostenstelleID

  DROP TABLE #Belege
END
GO