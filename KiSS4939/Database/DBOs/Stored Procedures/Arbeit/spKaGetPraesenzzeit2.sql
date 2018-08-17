SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKaGetPraesenzzeit2
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spKaGetPraesenzzeit2.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:21 $
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
  TEST:    .
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spKaGetPraesenzzeit2.sql $
 * 
 * 3     25.06.09 11:37 Ckaeser
 * Alter2Create
 * 
 * 2     13.02.09 8:58 Lgreulich
 * Ticket 4155: ORDER BY mit BaPersonID angepasst
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
CREATE PROCEDURE dbo.spKaGetPraesenzzeit2
 (@KlientID int)
AS BEGIN
  SET NOCOUNT ON

DECLARE @tmp TABLE (
  ID          int identity,
  BaPersonID  int,
  Tag         int,
  Monat	      int,
  Jahr        int,
  Datum	      datetime,
  AM_AnwCode  int,
  PM_AnwCode  int
  primary key (BaPersonID,Tag,ID))

DECLARE @rslt TABLE (
  ID          int identity,
  BaPersonID  int,
  KlientName  varchar(100),
  KlientVorname varchar(100),
  Monat       int,
  Jahr        int,
  KlientNameVorname varchar(200),
  [Code01V]   int,
  [Code02V]   int,
  [Code03V]   int,
  [Code04V]   int,
  [Code05V]   int,
  [Code06V]   int,
  [Code07V]   int,
  [Code08V]   int,
  [Code09V]   int,
  [Code10V]   int,
  [Code11V]   int,
  [Code12V]   int,
  [Code13V]   int,
  [Code14V]   int,
  [Code15V]   int,
  [Code16V]   int,
  [Code17V]   int,
  [Code18V]   int,
  [Code19V]   int,
  [Code20V]   int,
  [Code21V]   int,
  [Code22V]   int,
  [Code23V]   int,
  [Code24V]   int,
  [Code25V]   int,
  [Code26V]   int,
  [Code27V]   int,
  [Code28V]   int,
  [Code29V]   int,
  [Code30V]   int,
  [Code31V]   int,
  [Code01N]   int,
  [Code02N]   int,
  [Code03N]   int,
  [Code04N]   int,
  [Code05N]   int,
  [Code06N]   int,
  [Code07N]   int,
  [Code08N]   int,
  [Code09N]   int,
  [Code10N]   int,
  [Code11N]   int,
  [Code12N]   int,
  [Code13N]   int,
  [Code14N]   int,
  [Code15N]   int,
  [Code16N]   int,
  [Code17N]   int,
  [Code18N]   int,
  [Code19N]   int,
  [Code20N]   int,
  [Code21N]   int,
  [Code22N]   int,
  [Code23N]   int,
  [Code24N]   int,
  [Code25N]   int,
  [Code26N]   int,
  [Code27N]   int,
  [Code28N]   int,
  [Code29N]   int,
  [Code30N]   int,
  [Code31N]   int,
  [Stat01]    float,
  [Stat02]    float,
  [Stat03]    float,
  [Stat04]    float,
  [Stat05]    float,
  [Stat06]    float,
  [Stat07]    float,
  [Stat08]    float
  primary key (BaPersonID,ID))

INSERT @tmp
SELECT BaPersonID,
       DAY(Datum),
       MONTH(Datum),
       YEAR(Datum),
       Datum,
       AM_AnwCode,
       PM_AnwCode
FROM dbo.KaArbeitsrapport  KAR WITH (READUNCOMMITTED) 
WHERE Datum >= (SELECT MIN(DatumVon)
	            FROM dbo.FaLeistung WITH (READUNCOMMITTED) 
	            WHERE BaPersonID = ISNULL(@KlientID, BaPersonID)
	              AND ModulID = 7
	              AND FaProzessCode BETWEEN 701 AND 720
	              AND DatumBis IS NULL)
  AND BaPersonID = ISNULL(@KlientID, BaPersonID)
  AND Datum <= dbo.fnLastDayOf(GETDATE())         -- nur bis aktuellem Monat (#7156)

DECLARE @actMonth INT
DECLARE @actYear INT

DECLARE cur CURSOR FOR
SELECT DISTINCT Month(Datum), Year(Datum)
FROM @tmp
ORDER BY Year(Datum), Month(Datum)

OPEN cur
FETCH NEXT FROM cur INTO @actMonth, @actYear
WHILE (@@FETCH_STATUS=0) BEGIN

INSERT @rslt
SELECT T.BaPersonID,
       PRS.Name,
       PRS.Vorname,
       @actMonth,
       @actYear,
       PRS.Vorname + IsNull(' ' + PRS.Name, ''),
       [Code01V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 1 AND Monat = @actMonth AND Jahr = @actYear),
       [Code02V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 2 AND Monat = @actMonth AND Jahr = @actYear),
       [Code03V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 3 AND Monat = @actMonth AND Jahr = @actYear),
       [Code04V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 4 AND Monat = @actMonth AND Jahr = @actYear),
       [Code05V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 5 AND Monat = @actMonth AND Jahr = @actYear),
       [Code06V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 6 AND Monat = @actMonth AND Jahr = @actYear),
       [Code07V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 7 AND Monat = @actMonth AND Jahr = @actYear),
       [Code08V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 8 AND Monat = @actMonth AND Jahr = @actYear),
       [Code09V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 9 AND Monat = @actMonth AND Jahr = @actYear),
       [Code10V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 10 AND Monat = @actMonth AND Jahr = @actYear),
       [Code11V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 11 AND Monat = @actMonth AND Jahr = @actYear),
       [Code12V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 12 AND Monat = @actMonth AND Jahr = @actYear),
       [Code13V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 13 AND Monat = @actMonth AND Jahr = @actYear),
       [Code14V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 14 AND Monat = @actMonth AND Jahr = @actYear),
       [Code15V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 15 AND Monat = @actMonth AND Jahr = @actYear),
       [Code16V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 16 AND Monat = @actMonth AND Jahr = @actYear),
       [Code17V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 17 AND Monat = @actMonth AND Jahr = @actYear),
       [Code18V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 18 AND Monat = @actMonth AND Jahr = @actYear),
       [Code19V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 19 AND Monat = @actMonth AND Jahr = @actYear),
       [Code20V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 20 AND Monat = @actMonth AND Jahr = @actYear),
       [Code21V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 21 AND Monat = @actMonth AND Jahr = @actYear),
       [Code22V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 22 AND Monat = @actMonth AND Jahr = @actYear),
       [Code23V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 23 AND Monat = @actMonth AND Jahr = @actYear),
       [Code24V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 24 AND Monat = @actMonth AND Jahr = @actYear),
       [Code25V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 25 AND Monat = @actMonth AND Jahr = @actYear),
       [Code26V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 26 AND Monat = @actMonth AND Jahr = @actYear),
       [Code27V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 27 AND Monat = @actMonth AND Jahr = @actYear),
       [Code28V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 28 AND Monat = @actMonth AND Jahr = @actYear),
       [Code29V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 29 AND Monat = @actMonth AND Jahr = @actYear),
       [Code30V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 30 AND Monat = @actMonth AND Jahr = @actYear),
       [Code31V] = (SELECT MAX(AM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 31 AND Monat = @actMonth AND Jahr = @actYear),
       [Code01N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 1 AND Monat = @actMonth AND Jahr = @actYear),
       [Code02N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 2 AND Monat = @actMonth AND Jahr = @actYear),
       [Code03N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 3 AND Monat = @actMonth AND Jahr = @actYear),
       [Code04N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 4 AND Monat = @actMonth AND Jahr = @actYear),
       [Code05N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 5 AND Monat = @actMonth AND Jahr = @actYear),
       [Code06N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 6 AND Monat = @actMonth AND Jahr = @actYear),
       [Code07N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 7 AND Monat = @actMonth AND Jahr = @actYear),
       [Code08N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 8 AND Monat = @actMonth AND Jahr = @actYear),
       [Code09N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 9 AND Monat = @actMonth AND Jahr = @actYear),
       [Code10N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 10 AND Monat = @actMonth AND Jahr = @actYear),
       [Code11N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 11 AND Monat = @actMonth AND Jahr = @actYear),
       [Code12N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 12 AND Monat = @actMonth AND Jahr = @actYear),
       [Code13N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 13 AND Monat = @actMonth AND Jahr = @actYear),
       [Code14N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 14 AND Monat = @actMonth AND Jahr = @actYear),
       [Code15N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 15 AND Monat = @actMonth AND Jahr = @actYear),
       [Code16N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 16 AND Monat = @actMonth AND Jahr = @actYear),
       [Code17N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 17 AND Monat = @actMonth AND Jahr = @actYear),
       [Code18N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 18 AND Monat = @actMonth AND Jahr = @actYear),
       [Code19N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 19 AND Monat = @actMonth AND Jahr = @actYear),
       [Code20N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 20 AND Monat = @actMonth AND Jahr = @actYear),
       [Code21N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 21 AND Monat = @actMonth AND Jahr = @actYear),
       [Code22N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 22 AND Monat = @actMonth AND Jahr = @actYear),
       [Code23N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 23 AND Monat = @actMonth AND Jahr = @actYear),
       [Code24N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 24 AND Monat = @actMonth AND Jahr = @actYear),
       [Code25N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 25 AND Monat = @actMonth AND Jahr = @actYear),
       [Code26N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 26 AND Monat = @actMonth AND Jahr = @actYear),
       [Code27N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 27 AND Monat = @actMonth AND Jahr = @actYear),
       [Code28N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 28 AND Monat = @actMonth AND Jahr = @actYear),
       [Code29N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 29 AND Monat = @actMonth AND Jahr = @actYear),
       [Code30N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 30 AND Monat = @actMonth AND Jahr = @actYear),
       [Code31N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 31 AND Monat = @actMonth AND Jahr = @actYear),
       [Stat01]  = CONVERT(float, ((SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND AM_AnwCode = 1 AND Monat = @actMonth AND Jahr = @actYear) +
		   (SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND PM_AnwCode = 1 AND Monat = @actMonth AND Jahr = @actYear))) / 2,
       [Stat02]  = CONVERT(float, ((SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND AM_AnwCode = 2 AND Monat = @actMonth AND Jahr = @actYear) +
		   (SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND PM_AnwCode = 2 AND Monat = @actMonth AND Jahr = @actYear))) / 2,
       [Stat03]  = CONVERT(float, ((SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND AM_AnwCode = 3 AND Monat = @actMonth AND Jahr = @actYear) +
		   (SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND PM_AnwCode = 3 AND Monat = @actMonth AND Jahr = @actYear))) / 2,
       [Stat04]  = CONVERT(float, ((SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND AM_AnwCode = 4 AND Monat = @actMonth AND Jahr = @actYear) +
		   (SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND PM_AnwCode = 4 AND Monat = @actMonth AND Jahr = @actYear))) / 2,
       [Stat05]  = CONVERT(float, ((SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND AM_AnwCode = 5 AND Monat = @actMonth AND Jahr = @actYear) +
		   (SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND PM_AnwCode = 5 AND Monat = @actMonth AND Jahr = @actYear))) / 2,
       [Stat06]  = CONVERT(float, ((SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND AM_AnwCode = 7 AND Monat = @actMonth AND Jahr = @actYear) +
		   (SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND PM_AnwCode = 7 AND Monat = @actMonth AND Jahr = @actYear))) / 2,
       [Stat07]  = CONVERT(float, ((SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND AM_AnwCode = 6 AND Monat = @actMonth AND Jahr = @actYear) +
		   (SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND PM_AnwCode = 6 AND Monat = @actMonth AND Jahr = @actYear))) / 2,
       [Stat08]  = CONVERT(float, ((SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND AM_AnwCode = 9 AND Monat = @actMonth AND Jahr = @actYear) +
		   (SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND PM_AnwCode = 9 AND Monat = @actMonth AND Jahr = @actYear))) / 2

FROM  (SELECT DISTINCT BaPersonID FROM @tmp) T
      INNER JOIN BaPerson PRS on PRS.BaPersonID = T.BaPersonID

--order by 2,3, 5, 4 desc

FETCH NEXT FROM cur INTO @actMonth, @actYear
END
CLOSE cur
DEALLOCATE cur

SELECT BaPersonID, KlientName, KlientVorname,
  MonatText = dbo.fnXMonat(Monat),
  Jahr, KlientNameVorname,
  C01V = dbo.fnLOVShortText('KaPraesenzCode', [Code01V]),
  C02V = dbo.fnLOVShortText('KaPraesenzCode', [Code02V]),
  C03V = dbo.fnLOVShortText('KaPraesenzCode', [Code03V]),
  C04V = dbo.fnLOVShortText('KaPraesenzCode', [Code04V]),
  C05V = dbo.fnLOVShortText('KaPraesenzCode', [Code05V]),
  C06V = dbo.fnLOVShortText('KaPraesenzCode', [Code06V]),
  C07V = dbo.fnLOVShortText('KaPraesenzCode', [Code07V]),
  C08V = dbo.fnLOVShortText('KaPraesenzCode', [Code08V]),
  C09V = dbo.fnLOVShortText('KaPraesenzCode', [Code09V]),
  C10V = dbo.fnLOVShortText('KaPraesenzCode', [Code10V]),
  C11V = dbo.fnLOVShortText('KaPraesenzCode', [Code11V]),
  C12V = dbo.fnLOVShortText('KaPraesenzCode', [Code12V]),
  C13V = dbo.fnLOVShortText('KaPraesenzCode', [Code13V]),
  C14V = dbo.fnLOVShortText('KaPraesenzCode', [Code14V]),
  C15V = dbo.fnLOVShortText('KaPraesenzCode', [Code15V]),
  C16V = dbo.fnLOVShortText('KaPraesenzCode', [Code16V]),
  C17V = dbo.fnLOVShortText('KaPraesenzCode', [Code17V]),
  C18V = dbo.fnLOVShortText('KaPraesenzCode', [Code18V]),
  C19V = dbo.fnLOVShortText('KaPraesenzCode', [Code19V]),
  C20V = dbo.fnLOVShortText('KaPraesenzCode', [Code20V]),
  C21V = dbo.fnLOVShortText('KaPraesenzCode', [Code21V]),
  C22V = dbo.fnLOVShortText('KaPraesenzCode', [Code22V]),
  C23V = dbo.fnLOVShortText('KaPraesenzCode', [Code23V]),
  C24V = dbo.fnLOVShortText('KaPraesenzCode', [Code24V]),
  C25V = dbo.fnLOVShortText('KaPraesenzCode', [Code25V]),
  C26V = dbo.fnLOVShortText('KaPraesenzCode', [Code26V]),
  C27V = dbo.fnLOVShortText('KaPraesenzCode', [Code27V]),
  C28V = dbo.fnLOVShortText('KaPraesenzCode', [Code28V]),
  C29V = dbo.fnLOVShortText('KaPraesenzCode', [Code29V]),
  C30V = dbo.fnLOVShortText('KaPraesenzCode', [Code30V]),
  C31V = dbo.fnLOVShortText('KaPraesenzCode', [Code31V]),
  C01N = dbo.fnLOVShortText('KaPraesenzCode', [Code01N]),
  C02N = dbo.fnLOVShortText('KaPraesenzCode', [Code02N]),
  C03N = dbo.fnLOVShortText('KaPraesenzCode', [Code03N]),
  C04N = dbo.fnLOVShortText('KaPraesenzCode', [Code04N]),
  C05N = dbo.fnLOVShortText('KaPraesenzCode', [Code05N]),
  C06N = dbo.fnLOVShortText('KaPraesenzCode', [Code06N]),
  C07N = dbo.fnLOVShortText('KaPraesenzCode', [Code07N]),
  C08N = dbo.fnLOVShortText('KaPraesenzCode', [Code08N]),
  C09N = dbo.fnLOVShortText('KaPraesenzCode', [Code09N]),
  C10N = dbo.fnLOVShortText('KaPraesenzCode', [Code10N]),
  C11N = dbo.fnLOVShortText('KaPraesenzCode', [Code11N]),
  C12N = dbo.fnLOVShortText('KaPraesenzCode', [Code12N]),
  C13N = dbo.fnLOVShortText('KaPraesenzCode', [Code13N]),
  C14N = dbo.fnLOVShortText('KaPraesenzCode', [Code14N]),
  C15N = dbo.fnLOVShortText('KaPraesenzCode', [Code15N]),
  C16N = dbo.fnLOVShortText('KaPraesenzCode', [Code16N]),
  C17N = dbo.fnLOVShortText('KaPraesenzCode', [Code17N]),
  C18N = dbo.fnLOVShortText('KaPraesenzCode', [Code18N]),
  C19N = dbo.fnLOVShortText('KaPraesenzCode', [Code19N]),
  C20N = dbo.fnLOVShortText('KaPraesenzCode', [Code20N]),
  C21N = dbo.fnLOVShortText('KaPraesenzCode', [Code21N]),
  C22N = dbo.fnLOVShortText('KaPraesenzCode', [Code22N]),
  C23N = dbo.fnLOVShortText('KaPraesenzCode', [Code23N]),
  C24N = dbo.fnLOVShortText('KaPraesenzCode', [Code24N]),
  C25N = dbo.fnLOVShortText('KaPraesenzCode', [Code25N]),
  C26N = dbo.fnLOVShortText('KaPraesenzCode', [Code26N]),
  C27N = dbo.fnLOVShortText('KaPraesenzCode', [Code27N]),
  C28N = dbo.fnLOVShortText('KaPraesenzCode', [Code28N]),
  C29N = dbo.fnLOVShortText('KaPraesenzCode', [Code29N]),
  C30N = dbo.fnLOVShortText('KaPraesenzCode', [Code30N]),
  C31N = dbo.fnLOVShortText('KaPraesenzCode', [Code31N]),
  Day28 = CASE WHEN day(dbo.fnLastDayOf(CONVERT(datetime, '01.' + CONVERT(varchar, Monat) + '.' + CONVERT(varchar, Jahr) , 104))) > 27 THEN '28' ELSE '' END,
  Day29 = CASE WHEN day(dbo.fnLastDayOf(CONVERT(datetime, '01.' + CONVERT(varchar, Monat) + '.' + CONVERT(varchar, Jahr) , 104))) > 28 THEN '29' ELSE '' END,
  Day30 = CASE WHEN day(dbo.fnLastDayOf(CONVERT(datetime, '01.' + CONVERT(varchar, Monat) + '.' + CONVERT(varchar, Jahr) , 104))) > 29 THEN '30' ELSE '' END,
  Day31 = CASE WHEN day(dbo.fnLastDayOf(CONVERT(datetime, '01.' + CONVERT(varchar, Monat) + '.' + CONVERT(varchar, Jahr) , 104))) > 30 THEN '31' ELSE '' END,
  [Stat01], [Stat02], [Stat03], [Stat04],
  [Stat05], [Stat06], [Stat07], [Stat08]
FROM @rslt
ORDER BY  KlientName, KlientVorname, BaPersonID, Jahr, Monat

END
GO