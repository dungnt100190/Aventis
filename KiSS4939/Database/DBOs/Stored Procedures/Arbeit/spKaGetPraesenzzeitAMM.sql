SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKaGetPraesenzzeitAMM
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spKaGetPraesenzzeitAMM.sql $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spKaGetPraesenzzeitAMM.sql $
 * 
 * 3     25.06.09 11:35 Ckaeser
 * Alter2Create
 * 
 * 2     13.02.09 8:58 Lgreulich
 * Ticket 4155: ORDER BY mit BaPersonID angepasst
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
CREATE PROCEDURE dbo.spKaGetPraesenzzeitAMM
 (@KlientID int,
  @Monat int,
  @Jahr int,
  @DatumVon datetime,
  @DatumBis datetime)
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
  [Code31N]   int
  primary key (BaPersonID,ID))

INSERT @tmp
SELECT BaPersonID,
       day(Datum),
       month(Datum),
       Year(Datum),
       Datum,
       AM_AnwCode,
       PM_AnwCode
FROM   dbo.KaArbeitsrapport  KAR WITH (READUNCOMMITTED) 
--where  Datum >= (SELECT MIN(datumvon) 
--	      FROM FaLeistung
--	      WHERE BaPersonID = isNull(@KlientID, BaPersonID)
--	      AND ModulID = 7
--	      AND FaProzessCode between 701 and 720
--	      AND DatumBis IS NULL)
WHERE Datum BETWEEN @DatumVon AND @DatumBis
AND    BaPersonID = IsNull(@KlientID, BaPersonID)
AND    month(Datum) = @Monat
AND    Year(Datum) = @Jahr

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
       [Code31N] = (SELECT MAX(PM_AnwCode) FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 31 AND Monat = @actMonth AND Jahr = @actYear)
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
  C01V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code01V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code01V] END),
  C02V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code02V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code02V] END),
  C03V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code03V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code03V] END),
  C04V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code04V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code04V] END),
  C05V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code05V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code05V] END),
  C06V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code06V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code06V] END),
  C07V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code07V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code07V] END),
  C08V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code08V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code08V] END),
  C09V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code09V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code09V] END),
  C10V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code10V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code10V] END),
  C11V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code11V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code11V] END),
  C12V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code12V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code12V] END),
  C13V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code13V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code13V] END),
  C14V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code14V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code14V] END),
  C15V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code15V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code15V] END),
  C16V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code16V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code16V] END),
  C17V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code17V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code17V] END),
  C18V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code18V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code18V] END),
  C19V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code19V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code19V] END),
  C20V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code20V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code20V] END),
  C21V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code21V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code21V] END),
  C22V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code22V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code22V] END),
  C23V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code23V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code23V] END),
  C24V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code24V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code24V] END),
  C25V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code25V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code25V] END),
  C26V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code26V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code26V] END),
  C27V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code27V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code27V] END),
  C28V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code28V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code28V] END),
  C29V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code29V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code29V] END),
  C30V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code30V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code30V] END),
  C31V = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code31V] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code31V] END),
  C01N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code01N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code01N] END),
  C02N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code02N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code02N] END),
  C03N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code03N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code03N] END),
  C04N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code04N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code04N] END),
  C05N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code05N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code05N] END),
  C06N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code06N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code06N] END),
  C07N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code07N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code07N] END),
  C08N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code08N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code08N] END),
  C09N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code09N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code09N] END),
  C10N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code10N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code10N] END),
  C11N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code11N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code11N] END),
  C12N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code12N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code12N] END),
  C13N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code13N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code13N] END),
  C14N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code14N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code14N] END),
  C15N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code15N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code15N] END),
  C16N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code16N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code16N] END),
  C17N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code17N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code17N] END),
  C18N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code18N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code18N] END),
  C19N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code19N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code19N] END),
  C20N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code20N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code20N] END),
  C21N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code21N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code21N] END),
  C22N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code22N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code22N] END),
  C23N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code23N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code23N] END),
  C24N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code24N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code24N] END),
  C25N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code25N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code25N] END),
  C26N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code26N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code26N] END),
  C27N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code27N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code27N] END),
  C28N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code28N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code28N] END),
  C29N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code29N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code29N] END),
  C30N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code30N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code30N] END),
  C31N = dbo.fnLOVShortText('KaPraesenzCode', CASE [Code31N] WHEN 10 THEN -1 WHEN 11 THEN -1 ELSE [Code31N] END),
  Day28 = CASE WHEN day(dbo.fnLastDayOf(CONVERT(datetime, '01.' + CONVERT(varchar, Monat) + '.' + CONVERT(varchar, Jahr) , 104))) > 27 THEN '28' ELSE '' END,
  Day29 = CASE WHEN day(dbo.fnLastDayOf(CONVERT(datetime, '01.' + CONVERT(varchar, Monat) + '.' + CONVERT(varchar, Jahr) , 104))) > 28 THEN '29' ELSE '' END,
  Day30 = CASE WHEN day(dbo.fnLastDayOf(CONVERT(datetime, '01.' + CONVERT(varchar, Monat) + '.' + CONVERT(varchar, Jahr) , 104))) > 29 THEN '30' ELSE '' END,
  Day31 = CASE WHEN day(dbo.fnLastDayOf(CONVERT(datetime, '01.' + CONVERT(varchar, Monat) + '.' + CONVERT(varchar, Jahr) , 104))) > 30 THEN '31' ELSE '' END
FROM @rslt
ORDER BY  KlientName, KlientVorname, BaPersonID, Monat, Jahr

END
GO