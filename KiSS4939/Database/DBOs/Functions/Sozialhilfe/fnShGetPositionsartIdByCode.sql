SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnShGetPositionsartIdByCode;
GO
/*
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
 Holt die ID der Positionsart, welche zum Zeitpunkt und zum PositionsartCode
 gültig ist.
 
=================================================================================================
=================================================================================================*/

CREATE FUNCTION dbo.fnShGetPositionsartIdByCode
(
  @BgPositionsartCode INT,
  @Date DATETIME
)
RETURNS INT
AS BEGIN
  
   DECLARE @FirstDayOfMonth DATETIME;
   DECLARE @LastDayOfMonth  DATETIME;
   DECLARE @BgPositionsartId INT;
   
   SELECT @FirstDayOfMonth = dbo.fnFirstDayOf(@Date);
   SELECT @LastDayOfMonth =  dbo.fnLastDayOf(@Date);
  
   SELECT TOP 1 @BgPositionsartId = POA.BgPositionsartID
   FROM BgPositionsart POA
   WHERE POA.BgPositionsartCode = @BgPositionsartCode
     AND ISNULL(POA.DatumVon, '1900-01-01') <= @LastDayOfMonth AND ISNULL(POA.DatumBis, '2999-12-31') >= @FirstDayOfMonth

  RETURN @BgPositionsartId;
  
END
GO