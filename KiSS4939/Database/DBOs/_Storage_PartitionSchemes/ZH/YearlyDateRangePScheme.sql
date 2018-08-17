/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Create the partition function scheme that will be used by XDocument on production
  -
  RETURNS: 
=================================================================================================
  TEST: DROP PARTITION SCHEME [YearlyDateRangePScheme]
=================================================================================================*/

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.partition_schemes WHERE name = N'YearlyDateRangePScheme')
BEGIN
  EXEC sp_executesql 'CREATE PARTITION SCHEME [YearlyDateRangePScheme] AS PARTITION [YearlyDateRangePFN] TO ([KiSS4_ZH_DOC_FG2010], [KiSS4_ZH_DOC_FG2009], [KiSS4_ZH_DOC_FG2008], [KiSS4_ZH_DOC_FG2007], [KiSS4_ZH_DOC_FG2006], [KiSS4_ZH_DOC_FG2005], [KiSS4_ZH_DOC_FG2004], [KiSS4_ZH_DOC_FG2003], [KiSS4_ZH_DOC_FG2002], [KiSS4_ZH_DOC_FG2001], [KiSS4_ZH_DOC_FG2000], [KiSS4_ZH_DOC_FG1999], [KiSS4_ZH_DOC_FG1998], [KiSS4_ZH_DOC_FG1997], [PRIMARY]);';
END
ELSE
BEGIN
  PRINT ('Warning: PARTITION SCHEME [YearlyDateRangePScheme] already exists and could not be created.');
END;
