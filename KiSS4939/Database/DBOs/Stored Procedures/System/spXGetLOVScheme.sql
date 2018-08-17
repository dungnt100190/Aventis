SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spXGetLOVScheme;
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spXGetLOVScheme.sql $
  $Author: Lloreggia $
  $Modtime: 22.01.10 18:27 $
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Reads LOV and LOVCode information
  -
  RETURNS: 2 datasets containing LOV and LOVCode information
  -
  TEST:    EXEC dbo.spXGetLOVScheme;
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spXGetLOVScheme.sql $
 * 
 * 4     25.01.10 9:35 Lloreggia
 * 
 * 3     22.01.10 18:00 Lloreggia
 * 
 * 2     21.01.10 16:22 Lloreggia
 * 
 * 1     20.01.10 17:40 Lloreggia
 * spXGetLOVScheme
=================================================================================================*/

CREATE PROCEDURE dbo.spXGetLOVScheme
AS 
BEGIN
  -------------------------------------------------------------------------------
  -- start call
  -------------------------------------------------------------------------------
  SET NOCOUNT ON;

  -----------------------------------------------------------------------------
  -- output the LOV table
  -----------------------------------------------------------------------------
  SELECT [LOVName],
         [Description],
         [System],
         [Expandable],
         [Translatable],
         [NameValue1],
         [NameValue2],
         [NameValue3],
         [ModulID]
  FROM dbo.XLOV
  ORDER BY LOVName;

  -----------------------------------------------------------------------------
  -- output the LOVCode table
  -----------------------------------------------------------------------------
  SELECT [LOVName],
         [Description],
         [System],
         [Code],
         [LOVCodeName],
         [Text],
         [ShortText],
         [BFSCode],
         [Value1],
         [Value2],
         [Value3]
  FROM dbo.XLOVCode
  ORDER BY LOVName, Code;

END;
GO
