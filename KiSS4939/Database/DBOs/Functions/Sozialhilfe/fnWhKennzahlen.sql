SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnWhKennzahlen
GO
/*===============================================================================================
  $Revision: 1 $
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

CREATE FUNCTION dbo.fnWhKennzahlen
  (@BgFinanzplanID   int)
  RETURNS @OUTPUT TABLE
   (HgGrundbedarf    int,
    UeGrundbedarf    int,
    HgWohnkosten     float,
    UeWohnkosten     float,
    HgZuschlagI      int,
    UeZuschlagI      int,
    B23Amount        money,
    GBUseHgUeFactor  int,
    RntUseHgUeFactor int,
    GBHgUeFactor     float,
    RntHgUeFactor    float,
    RefDate          datetime)
AS 

BEGIN
  DECLARE @RefDate          datetime,
          @F51Age           int,
          @F51Factor        float,
          @B23Age           int,
          @B23Offset        int,
          @B23Amount        money,
          @GBUseHgUeFactor  int,
          @RntUseHgUeFactor int


  -- Referenzdatum = Anfangsdatum des Finanzplans (effektiv oder geplant)
  SELECT  @RefDate = IsNull(SFP.DatumVon, SFP.GeplantVon)
  FROM    dbo.BgFinanzplan SFP WITH (READUNCOMMITTED) 
  WHERE   SFP.BgFinanzplanID = @BgFinanzplanID

  SET @F51Age           = CONVERT(int,   dbo.fnXConfig('System\Sozialhilfe\SKOS\F51_Age'        , @RefDate))
  SET @F51Factor        = CONVERT(float, dbo.fnXConfig('System\Sozialhilfe\SKOS\F51_Factor'     , @RefDate))
  SET @B23Age           = CONVERT(int,   dbo.fnXConfig('System\Sozialhilfe\SKOS\B23_Age'        , @RefDate))
  SET @B23Offset        = CONVERT(int,   dbo.fnXConfig('System\Sozialhilfe\SKOS\B23_Offset'     , @RefDate))
  SET @B23Amount        = CONVERT(money, dbo.fnXConfig('System\Sozialhilfe\SKOS\B23_Amount'     , @RefDate))
  SET @GBUseHgUeFactor  = CONVERT(int, dbo.fnXConfig('System\Sozialhilfe\SKOS\GB_UseHgUeFactor' , @RefDate))
  SET @RntUseHgUeFactor = CONVERT(int, dbo.fnXConfig('System\Sozialhilfe\SKOS\Rnt_UseHgUeFactor', @RefDate))

  INSERT @OUTPUT
                          -- alle Personen im Haushalt
  SELECT HgGrundbedarf = (SELECT COUNT(*)
			  FROM   dbo.BgFinanzplan_BaPerson    SPP WITH (READUNCOMMITTED) 
			  WHERE  SPP.BgFinanzplanID = @BgFinanzplanID),

                          -- alle unterstützen Personen
         UeGrundbedarf = (SELECT COUNT(*)
			  FROM   dbo.BgFinanzplan_BaPerson    SPP WITH (READUNCOMMITTED) 
			  WHERE  SPP.BgFinanzplanID = @BgFinanzplanID AND
                                 SPP.IstUnterstuetzt = 1),

                          -- alle Personen im Haushalt, die >= [@F51Age] alt sind +
                          -- alle Personen im Haushalt x @F51Factor, die <= [@F51Age] alt sind
         HgWohnkosten  = (SELECT SUM(CASE WHEN dbo.fnGetAge(PRS.Geburtsdatum, @RefDate) >= @F51Age
                                     THEN CONVERT(float,1)
                                     ELSE @F51Factor
                                     END)
                          FROM   dbo.BgFinanzplan_BaPerson SPP WITH (READUNCOMMITTED) 
                                 INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = SPP.BaPersonID
                          WHERE  SPP.BgFinanzplanID = @BgFinanzplanID),

                          -- alle unterstützen Personen, die >= [@F51Age] alt sind +
                          -- alle unterstützen Personen x @F51Factor, die <= [@F51Age] alt sind
         UeWohnkosten  = (SELECT SUM(CASE WHEN dbo.fnGetAge(PRS.Geburtsdatum, @RefDate) >= @F51Age
                                     THEN CONVERT(float,1)
                                     ELSE @F51Factor
                                     END)
                          FROM   dbo.BgFinanzplan_BaPerson SPP WITH (READUNCOMMITTED) 
                                 INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = SPP.BaPersonID
                          WHERE  SPP.BgFinanzplanID = @BgFinanzplanID AND
                                 SPP.IstUnterstuetzt = 1),

                          -- alle Personen im Haushalt, die über [@B23Age] alt sind 
         HgZuschlagI   = (SELECT COUNT(*)
                          FROM   dbo.BgFinanzplan_BaPerson  SPP WITH (READUNCOMMITTED) 
                                 INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = SPP.BaPersonID
                          WHERE  SPP.BgFinanzplanID = @BgFinanzplanID AND
                                 dbo.fnGetAge(PRS.Geburtsdatum, @RefDate) >= @B23Age),

                          -- alle unterstützen Personen, die über [@B23Age] alt sind
         UeZuschlagI   = (SELECT COUNT(*)
                          FROM   dbo.BgFinanzplan_BaPerson  SPP WITH (READUNCOMMITTED) 
                                 INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = SPP.BaPersonID
                          WHERE  SPP.BgFinanzplanID = @BgFinanzplanID AND
                                 SPP.IstUnterstuetzt = 1 AND
                                 dbo.fnGetAge(PRS.Geburtsdatum, @RefDate) >= @B23Age),
         B23Amount     = IsNull(@B23Amount,0),

         GBUseHgUeFactor  = @GBUseHgUeFactor,
         RntUseHgUeFactor = @RntUseHgUeFactor,
         GBHgUeFactor     = NULL,
         RntHgUeFactor    = NULL,
         RefDate          = @RefDate

  UPDATE @OUTPUT
  SET    HgZuschlagI   = CASE WHEN HgZuschlagI <= @B23Offset
                         THEN 0
                         ELSE HgZuschlagI - @B23Offset
                         END,
         UeZuschlagI   = CASE WHEN UeZuschlagI <= @B23Offset
                         THEN 0
                         ELSE UeZuschlagI - @B23Offset
                         END,
         GBHgUeFactor  = CASE WHEN HgGrundbedarf = 0
                         THEN 1
                         ELSE CONVERT(float,UeGrundbedarf) / CONVERT(float,HgGrundbedarf)
                         END,
         RntHgUeFactor = CASE WHEN HgWohnkosten = 0
                         THEN 1
                         ELSE CONVERT(float,UeWohnkosten) / CONVERT(float,HgWohnkosten)
                         END
  RETURN
END
GO