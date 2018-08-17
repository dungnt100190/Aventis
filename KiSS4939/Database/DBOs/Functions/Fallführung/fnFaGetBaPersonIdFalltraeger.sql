SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnFaGetBaPersonIdFalltraeger;
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  TODO: FN kann im Release 4.7.09 gel�scht werden

  SUMMARY: Gibt die BaPersonID des Falltr�gers zur�ck
    @BaPersonID: ID der Person
    @RefDate:    Stichdatum

    Klientensystem, alle im gleichen Haushalt
      A: Kind
      B: Vater (FT)
      C: Mutter
      D: Geschwister von A; �ber 18

    Regeln:
      1. Wenn eine Person eine eigene aktive Leistung hat, ist sie Dossiertr�ger 
      2. Wenn eine Person (A) im aktiven S einer anderen Person (B) unterst�tzt ist, ist Person B Dossiertr�ger 
      3. Wenn eine Person (A) im aktiven S einer weiteren Person (D) ist, aber nicht unterst�tzt, ist die Person mit der �ltesten Leistung Dossiertr�ger, wo die Person (A) im FP ist

  -
  RETURNS: BaPersonID des Falltr�gers
=================================================================================================
  TEST:    SELECT dbo.fnFaGetBaPersonIdFalltraeger(1, GETDATE());
=================================================================================================*/

CREATE FUNCTION dbo.fnFaGetBaPersonIdFalltraeger
(
  @BaPersonID INT,
  @RefDate    DATETIME
)
RETURNS INT 
AS 
BEGIN
  DECLARE @retval INT;
  
  -- 1. Wenn eine Person eine eigene aktive Leistung hat, ist sie Dossiertr�ger
  IF EXISTS(SELECT TOP 1 1
            FROM dbo.FaLeistung LEI WITH(READUNCOMMITTED)
            WHERE LEI.BaPersonID = @BaPersonID
              AND LEI.ModulID = 2
              AND LEI.DatumBis IS NULL)
    RETURN @BaPersonID;
  
  -- 2. Wenn eine Person (A) im aktiven S einer anderen Person (B) unterst�tzt ist, ist Person B Dossiertr�ger
  SELECT @retval = (SELECT TOP 1 LEI.BaPersonID
                    FROM dbo.BgFinanzplan_BaPerson FPP WITH(READUNCOMMITTED)
                      INNER JOIN dbo.BgFinanzplan  FPL WITH(READUNCOMMITTED) ON FPL.BgFinanzplanID = FPP.BgFinanzplanID
                                                                            AND @RefDate BETWEEN ISNULL(FPL.DatumVon, FPL.GeplantVon) AND ISNULL(FPL.DatumBis, FPL.GeplantBis)
                      INNER JOIN dbo.FaLeistung    LEI WITH(READUNCOMMITTED) ON LEI.FaLeistungID = FPL.FaLeistungID
                                                                            AND LEI.DatumBis IS NULL 
                                                                            AND LEI.BaPersonID <> FPP.BaPersonID
                    WHERE FPP.BaPersonID = @BaPersonID 
                      AND FPP.IstUnterstuetzt = 1
                      AND FPL.DatumVon = (SELECT MAX(DatumVon)
                                          FROM dbo.BgFinanzplan FPL1 WITH (READUNCOMMITTED)
                                            INNER JOIN dbo.BgFinanzplan_BaPerson FPP1 WITH (READUNCOMMITTED) ON FPP1.BgFinanzplanID = FPL1.BgFinanzplanID
                                                                                                            AND FPP1.BaPersonID = FPP.BaPersonID
                                                                                                            AND FPP1.IstUnterstuetzt = FPP.IstUnterstuetzt
                                          WHERE @RefDate BETWEEN ISNULL(FPL1.DatumVon, FPL1.GeplantVon) AND ISNULL(FPL1.DatumBis, FPL1.GeplantBis)));

  IF (@retval IS NOT NULL)
  BEGIN
    RETURN @retval;
  END;
  
  -- 3. Wenn eine Person (A) im aktiven S einer weiteren Person (D) ist, aber nicht unterst�tzt, ist die Person mit der �ltesten Leistung Dossiertr�ger, wo die Person (A) im FP ist
  SELECT @retval = (SELECT TOP 1 LEI.BaPersonID
                    FROM dbo.BgFinanzplan_BaPerson FPP WITH(READUNCOMMITTED)
                      INNER JOIN dbo.BgFinanzplan  FPL WITH(READUNCOMMITTED) ON FPL.BgFinanzplanID = FPP.BgFinanzplanID
                                                                            AND @RefDate BETWEEN ISNULL(FPL.DatumVon, FPL.GeplantVon) AND ISNULL(FPL.DatumBis, FPL.GeplantBis)
                      INNER JOIN dbo.FaLeistung    LEI WITH(READUNCOMMITTED) ON LEI.FaLeistungID = FPL.FaLeistungID
                                                                            AND LEI.DatumBis IS NULL 
                                                                            AND LEI.BaPersonID <> FPP.BaPersonID
                    WHERE FPP.BaPersonID = @BaPersonID 
                      AND FPP.IstUnterstuetzt = 0
                      AND FPL.DatumVon = (SELECT MAX(DatumVon)
                                          FROM dbo.BgFinanzplan FPL1 WITH (READUNCOMMITTED)
                                            INNER JOIN dbo.BgFinanzplan_BaPerson FPP1 WITH (READUNCOMMITTED) ON FPP1.BgFinanzplanID = FPL1.BgFinanzplanID
                                                                                                            AND FPP1.BaPersonID = FPP.BaPersonID
                                                                                                            AND FPP1.IstUnterstuetzt = FPP.IstUnterstuetzt
                                          WHERE @RefDate BETWEEN ISNULL(FPL1.DatumVon, FPL1.GeplantVon) AND ISNULL(FPL1.DatumBis, FPL1.GeplantBis)));

   RETURN @retval;
END;
GO
