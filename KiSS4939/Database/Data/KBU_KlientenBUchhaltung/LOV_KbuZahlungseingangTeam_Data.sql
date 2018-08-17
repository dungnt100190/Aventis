/*===============================================================================================
  $Revision: 1$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: (Re)Creates the LOV "KbuBelegstatus" by adding its entries to dbo.XLOV and dbo.XLOVCode
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps 
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- drop the LOV if existing
-------------------------------------------------------------------------------
IF (EXISTS (SELECT TOP 1 1
            FROM dbo.XLOV
            WHERE LOVName = 'KbuZahlungseingangTeam'))
BEGIN
  DELETE LOC
  FROM dbo.XLOVCode LOC
  WHERE LOC.LOVName = 'KbuZahlungseingangTeam';
  
  DELETE LOV
  FROM dbo.XLOV LOV
  WHERE LOV.LOVName = 'KbuZahlungseingangTeam';
  
  PRINT ('Info: Deleted LOV "KbuZahlungseingangTeam" with its codes');
END;
GO

-------------------------------------------------------------------------------
-- create the data in XLOV
-------------------------------------------------------------------------------
INSERT INTO dbo.XLOV (LOVName, Description, System, Expandable, ModulID, LastUpdated, 
                      NameValue1, NameValue2, NameValue3, Translatable)
  SELECT LOVName      = 'KbuZahlungseingangTeam',
         Description  = 'Teams, denen ein Zahlungseingang zugeordnet werden kann',
         System       = 1,
         Expandable   = 1,
         ModulID      = 117,
         LastUpdated  = GETDATE(),
         NameValue1   = NULL,
         NameValue2   = NULL,
         NameValue3   = NULL,
         Translatable = 1;

-------------------------------------------------------------------------------
-- create the data in XLOVCode
-------------------------------------------------------------------------------
INSERT INTO dbo.XLOVCode (LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3,
                          Description, System, LOVCodeName)
  -- Code 1
  SELECT LOVName     = 'KbuZahlungseingangTeam',
         Code        = 1,
         Text        = 'Krankenkasse',
         SortKey     = 1,
         ShortText   = 'KK',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 0,
         LOVCodeName = 'Krankenkasse'

  UNION ALL
  
  -- Code 2
  SELECT LOVName     = 'KbuZahlungseingangTeam',
         Code        = 2,
         Text        = 'Sicherheitsleistungen',
         SortKey     = 2,
         ShortText   = 'SiLei',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 0,
         LOVCodeName = 'SiLei'
  
  UNION ALL
  
   -- Code 3
  SELECT LOVName     = 'KbuZahlungseingangTeam',
         Code        = 3,
         Text        = 'AHV/IV',
         SortKey     = 3,
         ShortText   = 'AHV/IV',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 0,
         LOVCodeName = 'AHV_IV'

  UNION ALL
  
  -- Code 4
  SELECT LOVName     = 'KbuZahlungseingangTeam',
         Code        = 4,
         Text        = 'Interne Verrechnung',
         SortKey     = 4,
         ShortText   = 'WI',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 0,
         LOVCodeName = 'WI'
  
  UNION ALL
  
  -- Code 5
  SELECT LOVName     = 'KbuZahlungseingangTeam',
         Code        = 5,
         Text        = 'Amt für Zusatzleistungen',
         SortKey     = 5,
         ShortText   = 'AZL',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 0,
         LOVCodeName = 'AZL'
  
  UNION ALL
  
  -- Code 6
  SELECT LOVName     = 'KbuZahlungseingangTeam',
         Code        = 6,
         Text        = 'Weiterverrechnung',
         SortKey     = 6,
         ShortText   = 'WV',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 0,
         LOVCodeName = 'WV'
  
  UNION ALL
  
  -- Code 7
  SELECT LOVName     = 'KbuZahlungseingangTeam',
         Code        = 7,
         Text        = 'W-Inkasso',
         SortKey     = 7,
         ShortText   = 'WIK',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 0,
         LOVCodeName = 'WIK'
  
  UNION ALL
  
  -- Code 8
  SELECT LOVName     = 'KbuZahlungseingangTeam',
         Code        = 8,
         Text        = 'Unterstützungsbeiträge',
         SortKey     = 8,
         ShortText   = 'UB',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 0,
         LOVCodeName = 'UB'
  
  UNION ALL
  
  -- Code 9
  SELECT LOVName     = 'KbuZahlungseingangTeam',
         Code        = 9,
         Text        = 'Rückläufer',
         SortKey     = 9,
         ShortText   = 'RL',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 0,
         LOVCodeName = 'RL'
  
  UNION ALL
  
  -- Code 10
  SELECT LOVName     = 'KbuZahlungseingangTeam',
         Code        = 10,
         Text        = 'Diverse',
         SortKey     = 10,
         ShortText   = 'Div',
         BFSCode     = NULL,
         Value1      = NULL,
         Value2      = NULL,
         Value3      = NULL,
         Description = NULL,
         System      = 0,
         LOVCodeName = 'Div'

-- info
PRINT ('Info: Created LOV "KbuZahlungseingangTeam" with its codes');
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO