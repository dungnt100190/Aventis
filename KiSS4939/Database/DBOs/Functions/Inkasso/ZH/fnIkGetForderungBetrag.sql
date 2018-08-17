SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnIkGetForderungBetrag
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Functions/fnIkGetForderungBetrag.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 10:33 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Functions/fnIkGetForderungBetrag.sql $
 * 
 * 3     11.12.09 11:01 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:08 Rstahel
 * Abgleich der Functions aus KISS4_MASTER_ZH
=================================================================================================*/
-- =====================================================================================
-- Author:      R. Hesterberg
-- Create date: 27.02.2008
-- Description: Ermitteln des Betrags bei 2 Zahlungswegen
-- -------------------------------------------------------------------------------------
-- Tests:
/*
select 
  Normal = dbo.fnIkGetForderungBetrag(0, 3, NULL, 50, 300), 
  Zusatz = dbo.fnIkGetForderungBetrag(1, 3, NULL, 50, 300)
union all
select
  Normal = dbo.fnIkGetForderungBetrag(0, 3, 50, NULL, 300), 
  Zusatz = dbo.fnIkGetForderungBetrag(1, 3, 50, NULL, 300)

select
  Normal = dbo.fnIkGetForderungBetrag(0, 3, NULL, 50, 40), 
  Zusatz = dbo.fnIkGetForderungBetrag(1, 3, NULL, 50, 40)
union all
select
  Normal = dbo.fnIkGetForderungBetrag(0, 3, 50, NULL, 40), 
  Zusatz = dbo.fnIkGetForderungBetrag(1, 3, 50, NULL, 40)


*/

-- =====================================================================================
CREATE FUNCTION [dbo].[fnIkGetForderungBetrag]
(
  -- IstZusatzBetrag : 0 = Betrag ermitteln, 1 = Zusatzbetrag ermitteln
  @IstZusatz BIT,
  -- IstEinmalig
  @IstEinmalig BIT,
  -- Zusatzzahlungsweg
  @ZusatzZahlungswegID INT,
  -- Betrag
  @ZwNormalBetrag money,
  -- Zusatzbetrag
  @ZwZusatzBetrag money,
  -- Einmaligbetrag
  @Einmaligbetrag money,
  -- Originalbetrag
  @OriginalBetrag money
)
RETURNS money
AS BEGIN
  DECLARE @Result money
  SET @Result = NULL
  IF @IstEinmalig = 1
  BEGIN
    -- Einmalige Beträge werden 1:1 zurückgeliefert
    IF @IstZusatz = 0
      SET @Result = @EinmaligBetrag ELSE
      SET @Result = NULL
  END ELSE IF @ZusatzZahlungswegID IS NULL
  BEGIN
    -- kein Zusatz-Zahlungsweg angegeben, also Originalbetrag 
    IF @IstZusatz = 0
       SET @Result = @OriginalBetrag ELSE
       SET @Result =  NULL
    IF @Result < 0 SET @Result =  NULL
  END ELSE IF @ZwZusatzBetrag IS NULL
  BEGIN
    -- Zusatz-Zahlungsweg ist angegeben, Normal-Betrag ist definiert
    -- also Normalbetrag -> Normalbetrag vom Zahlungsweg
    -- also Zusatzbetrag -> Originalbetrag - Normalbetrag vom Zahlungsweg
    IF @IstZusatz = 0 BEGIN
      -- Normal-Betrag zurückliefern
      IF @ZwNormalBetrag < @OriginalBetrag
        SET @Result = @ZwNormalBetrag ELSE
        SET @Result = @OriginalBetrag
    END ELSE BEGIN
      -- Zusatz-Betrag zurückliefern
      IF @ZwNormalBetrag < @OriginalBetrag
        SET @Result = @OriginalBetrag - @ZwNormalBetrag ELSE
        SET @Result = NULL
    END
    IF @Result < 0 SET @Result =  NULL
  END ELSE
  BEGIN
    -- Zusatz-Zahlungsweg ist angegeben, Zusatz-Betrag ist definiert
    -- also Zusatzbetrag -> Normalbetrag vom Zahlungsweg
    -- also Normalbetrag -> Originalbetrag - Normalbetrag vom Zahlungsweg
    IF @IstZusatz = 0 BEGIN
      -- Normal-Betrag zurückliefern
      IF @ZwZusatzBetrag < @OriginalBetrag
        SET @Result = @OriginalBetrag - @ZwZusatzBetrag ELSE
        SET @Result = NULL
    END ELSE BEGIN
      -- Zusatz-Betrag zurückliefern
      IF @ZwZusatzBetrag < @OriginalBetrag
        SET @Result = @ZwZusatzBetrag ELSE
        SET @Result = @OriginalBetrag
    END
    IF @Result < 0 SET @Result =  NULL
  END
  RETURN @Result
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
