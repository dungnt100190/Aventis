SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnBFSGetLeistungsartCode
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnBFSGetLeistungsartCode.sql $
  $Author: Lgreulich $
  $Modtime: 20.01.10 11:16 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnBFSGetLeistungsartCode.sql $
 * 
 * 2     20.01.10 11:19 Lgreulich
 * 
 * 2     20.01.10 11:17 Lgreulich
 * 
 * 1     19.01.10 15:06 Lgreulich
 * 
 * VSS First
=================================================================================================*/

CREATE FUNCTION dbo.fnBFSGetLeistungsartCode
  (@FaProzessCode int,
   @FaLeistungID  int)
  RETURNS int
AS BEGIN
  DECLARE @BFSLeistungsartCode int
  SET @BFSLeistungsartCode = NULL

  --IF NOT EXISTS (SELECT TOP 1 1 FROM syscolumns WHERE id = object_id('FaLeistung') AND name = 'LeistungsartCode') BEGIN
    -- für ZH -> hat kein LeistungsartCode!
    SET @BFSLeistungsartCode =
      (CASE @FaProzessCode 
	    WHEN 300 THEN 2   -- Sozialhilfe --> Regulärer Fall MIT Vertrag
	    WHEN 405 THEN 25  -- ALBV        --> Alimentenbevorschussung
	    WHEN 407 THEN 23  -- KKBB        --> KKBB
      END)
  --END ELSE BEGIN
  --  -- Für alle anderen mit LeistungsartCode 
  --  SET @BFSLeistungsartCode =
  --    (SELECT TOP 1 dbo.fnBFSCode('Leistungsart', LEI.LeistungsartCode)
  --     FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
  --     WHERE LEI.FaLeistungID = @FaLeistungID)
  --END
	
  IF @BFSLeistungsartCode IS NULL BEGIN
	SET @BFSLeistungsartCode = 2
  END

  RETURN (@BFSLeistungsartCode)
END
GO 