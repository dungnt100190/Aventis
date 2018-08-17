/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Create the partition function for the partition scheme that will be used by XDocument 
           on production
  -
  RETURNS: 
=================================================================================================
  TEST: DROP PARTITION FUNCTION [YearlyDateRangePFN]
=================================================================================================*/

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.partition_functions WHERE name = N'YearlyDateRangePFN')
BEGIN
  EXEC sp_executesql 'CREATE PARTITION FUNCTION [YearlyDateRangePFN](datetime) AS RANGE LEFT FOR VALUES (N''1997-12-31T23:59:59'', N''1998-12-31T23:59:59'', N''1999-12-31T23:59:59'', N''2000-12-31T23:59:59'', N''2001-12-31T23:59:59'', N''2002-12-31T23:59:59'', N''2003-12-31T23:59:59'', N''2004-12-31T23:59:59'', N''2005-12-31T23:59:59'', N''2006-12-31T23:59:59'', N''2007-12-31T23:59:59'', N''2008-12-31T23:59:59'', N''2009-12-31T23:59:59'', N''2010-12-31T23:59:59'');';
END
ELSE
BEGIN
  PRINT ('Warning: PARTITION FUNCTION [YearlyDateRangePFN] already exists and could not be created.');
END;
