/*
  KiSS 4.0
  --------
  DB-Object: fnShKennzahlen
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:56
*/
CREATE FUNCTION dbo.fnShKennzahlen
  (@ShFinanzPlanID   int)
  RETURNS @Output table 
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
AS BEGIN
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
  FROM    ShFinanzPlan SFP
  WHERE   SFP.ShFinanzPlanID = @ShFinanzPlanID

  SET @F51Age           = CONVERT(int,   dbo.fnXConfig('System\Sozialhilfe\SKOS\F51_Age'        , @RefDate))
  SET @F51Factor        = CONVERT(float, dbo.fnXConfig('System\Sozialhilfe\SKOS\F51_Factor'     , @RefDate))
  SET @B23Age           = CONVERT(int,   dbo.fnXConfig('System\Sozialhilfe\SKOS\B23_Age'        , @RefDate))
  SET @B23Offset        = CONVERT(int,   dbo.fnXConfig('System\Sozialhilfe\SKOS\B23_Offset'     , @RefDate))
  SET @B23Amount        = CONVERT(money, dbo.fnXConfig('System\Sozialhilfe\SKOS\B23_Amount'     , @RefDate))
  SET @GBUseHgUeFactor  = CONVERT(int, dbo.fnXConfig('System\Sozialhilfe\SKOS\GB_UseHgUeFactor' , @RefDate))
  SET @RntUseHgUeFactor = CONVERT(int, dbo.fnXConfig('System\Sozialhilfe\SKOS\Rnt_UseHgUeFactor', @RefDate))

  INSERT @Output
                          -- alle Personen im Haushalt
  SELECT HgGrundbedarf = (SELECT Count(*)
			  FROM   ShFinanzPlan_DmgPerson    SPP
			  WHERE  SPP.ShFinanzPlanID = @ShFinanzPlanID),

                          -- alle unterstützen Personen
         UeGrundbedarf = (SELECT Count(*)
			  FROM   ShFinanzPlan_DmgPerson    SPP
			  WHERE  SPP.ShFinanzPlanID = @ShFinanzPlanID AND
                                 SPP.IstUnterstuetzt = 1),

                          -- alle Personen im Haushalt, die > [@F51Age] alt sind +
                          -- alle Personen im Haushalt x @F51Factor, die <= [@F51Age] alt sind
         HgWohnkosten  = (SELECT SUM(CASE WHEN dbo.fnGetAge(PRS.Geburtsdatum, @RefDate) > @F51Age
                                     THEN CONVERT(float,1)
                                     ELSE @F51Factor
                                     END)
                          FROM   ShFinanzPlan_DmgPerson SPP
                                 INNER JOIN DmgPerson PRS ON PRS.DmgPersonID = SPP.DmgPersonID
                          WHERE  SPP.ShFinanzPlanID = @ShFinanzPlanID),

                          -- alle unterstützen Personen, die > [@F51Age] alt sind +
                          -- alle unterstützen Personen x @F51Factor, die <= [@F51Age] alt sind
         UeWohnkosten  = (SELECT SUM(CASE WHEN dbo.fnGetAge(PRS.Geburtsdatum, @RefDate) > @F51Age
                                     THEN CONVERT(float,1)
                                     ELSE @F51Factor
                                     END)
                          FROM   ShFinanzPlan_DmgPerson SPP
                                 INNER JOIN DmgPerson PRS ON PRS.DmgPersonID = SPP.DmgPersonID
                          WHERE  SPP.ShFinanzPlanID = @ShFinanzPlanID AND
                                 SPP.istUnterstuetzt = 1),

                          -- alle Personen im Haushalt, die über [@B23Age] alt sind 
         HgZuschlagI   = (SELECT Count(*)
                          FROM   ShFinanzPlan_DmgPerson  SPP
                                 INNER JOIN DmgPerson PRS ON PRS.DmgPersonID = SPP.DmgPersonID
                          WHERE  SPP.ShFinanzPlanID = @ShFinanzPlanID AND 
                                 dbo.fnGetAge(PRS.Geburtsdatum, @RefDate) >= @B23Age),

                          -- alle unterstützen Personen, die über [@B23Age] alt sind
         UeZuschlagI   = (SELECT Count(*)
                          FROM   ShFinanzPlan_DmgPerson  SPP
                                 INNER JOIN DmgPerson PRS ON PRS.DmgPersonID = SPP.DmgPersonID
                          WHERE  SPP.ShFinanzPlanID = @ShFinanzPlanID AND 
                                 SPP.istUnterstuetzt = 1 AND
                                 dbo.fnGetAge(PRS.Geburtsdatum, @RefDate) >= @B23Age),
         B23Amount     = isNull(@B23Amount,0),

         GBUseHgUeFactor  = @GBUseHgUeFactor,
         RntUseHgUeFactor = @RntUseHgUeFactor,
         GBHgUeFactor     = null,
         RntHgUeFactor    = null,
         RefDate          = @RefDate

  UPDATE @Output
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