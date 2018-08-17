SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnPscdGetAbstimmungProKostenart
GO
/*===============================================================================================
  $Revision: 4 $
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

CREATE FUNCTION dbo.fnPscdGetAbstimmungProKostenart
(
  @FROM datetime,
  @To   datetime
)
RETURNS @Summen TABLE
(
  KontoNr varchar(20),
  Hauptvorgang int,
  Teilvorgang int,
  Soll  money,
  Haben money,
  Datum datetime
)
AS BEGIN

DECLARE @StartDate datetime, @EndDate datetime
SET @FROM = CASE WHEN @FROM IS NULL THEN DateAdd(d,-1,GetDate()) ELSE @FROM END
SET @To   = CASE WHEN @To   IS NULL THEN @FROM ELSE @To END

SET @StartDate = dbo.fnDateSerial(DatePart(yyyy,@FROM),DatePart(m,@FROM),DatePart(d,@FROM))
SET @EndDate   = DateAdd(ms, 990, DateAdd(s,-1,dbo.fnDateSerial(DatePart(yyyy,@To),DatePart(m,@To),DatePart(d,@To)+1)))

INSERT INTO @Summen
SELECT BKA.KontoNr, KBB.Hauptvorgang, KBB.Teilvorgang, Soll  = -SUM(CASE WHEN KBB.Betrag > 0 THEN 0 ELSE KBB.Betrag END),
                                                       Haben =  SUM(CASE WHEN KBB.Betrag < 0 THEN 0 ELSE KBB.Betrag END), Datum = CONVERT(varchar,KBB.TransferDatum,104)
FROM dbo.KbBuchungBrutto     KBB WITH (READUNCOMMITTED) 
  INNER JOIN dbo.BgKostenart BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID = KBB.BgKostenartID
WHERE KBB.TransferDatum IS NOT NULL AND KBB.TransferDatum >= @StartDate AND KBB.TransferDatum <= @EndDate
GROUP BY BKA.KontoNr, KBB.Hauptvorgang, KBB.Teilvorgang, CONVERT(varchar,KBB.TransferDatum,104)

RETURN

END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
