SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKaGetTeilnehmerstruktur
GO
/*===============================================================================================
  $Revision: 11 $
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
=================================================================================================*/

CREATE PROCEDURE dbo.spKaGetTeilnehmerstruktur
(
  @DatumVon DATETIME,
  @DatumBis DATETIME,
  @einsatzplatzCode INT,
  @zusatzCode INT
)
AS BEGIN
  SET NOCOUNT ON;

  DECLARE @tmp TABLE
  (
    ID          INT IDENTITY,
    Bezeichnung VARCHAR(100),
    Wert        INT
    PRIMARY KEY (ID)
  );

  /**************************/
  /* Main select            */
  /**************************/
  DECLARE @tmpMain TABLE
  (
    ID               INT IDENTITY,
    BaPersonID       INT,
    FaLeistungID     INT,
    FaProzessCode    INT,
    KaEinsatzID      INT,
    APVZusatzCode    INT,
    KaEinsatzplatzID INT,
    AnweisungCode    INT,
    GenderCode       INT,
    NatCode          INT,
    [Alter]          INT,
    BildungCode      INT,
    DatumVon	       DATETIME,
    DatumBis         DATETIME,
    Austritt         DATETIME,
    [Code Austritt]  VARCHAR(20)
    PRIMARY KEY (ID)
  );

  DECLARE @tmpCursor TABLE (
    ID               INT IDENTITY,
    BaPersonID       INT,
    FaLeistungID     INT,
    FaProzessCode    INT,
    KaEinsatzID      INT,
    APVZusatzCode    INT,
    KaEinsatzplatzID INT,
    AnweisungCode    INT,
    GenderCode       INT,
    NatCode          INT,
    [Alter]          INT,
    BildungCode      INT,
    DatumVon	       DATETIME,
    DatumBis         DATETIME,
    Austritt         DATETIME,
    [Code Austritt]  VARCHAR(20)
    PRIMARY KEY (ID)
  );

  INSERT INTO @tmpCursor (BaPersonID, 
                          FaLeistungID, 
                          FaProzessCode, 
                          KaEinsatzID, 
                          APVZusatzCode, 
                          KaEinsatzplatzID, 
                          AnweisungCode, 
                          DatumVon, 
                          DatumBis, 
                          Austritt, 
                          GenderCode, 
                          NatCode, 
                          [Alter], 
                          BildungCode,
                          [Code Austritt])
    SELECT LEI.BaPersonID, 
           LEI.FaLeistungID,
           LEI.FaProzessCode, 
           EIN.KaEinsatzID, 
           EIN.APVZusatzCode, 
           EIN.KaEinsatzplatzID, 
           EIN.AnweisungCode, 
           EIN.DatumVon, 
           EIN.DatumBis, 
           AUS.AustrittDatum,
           PRS.GeschlechtCode,	
           PRS.NationalitaetCode, 
           dbo.fnGetAge(PRS.Geburtsdatum, @DatumVon), 
           KA.KaBecoErlernterBerufCode,-- BildungCode 
           AUS.AustrittCodeTextKurz
    FROM dbo.FaLeistung         LEI WITH (READUNCOMMITTED)
      INNER JOIN  dbo.KaEinsatz EIN WITH (READUNCOMMITTED) ON EIN.FaLeistungID = LEI.FaLeistungID
      OUTER APPLY dbo.fnKaGetAustrittDatumCode(LEI.FaLeistungID, EIN.KaEinsatzID) AUS						
      LEFT JOIN   dbo.BaPerson  PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
      LEFT JOIN (SELECT LEI.BaPersonID, 
                        KA.KaBecoErlernterBerufCode
                FROM dbo.FaLeistung LEI
                INNER JOIN dbo.KaAusbildung KA ON KA.FaLeistungID = LEI.FaLeistungID
                WHERE LEI.ModulID = 7
                  AND LEI.FaProzessCode = 700
                  ) KA ON KA.BaPersonID = EIN.BaPersonID	                          
    WHERE LEI.ModulID = 7
      AND (LEI.FaProzessCode in (703, 704, 707, 701, 708, 709, 710))
      AND ISNULL(AUS.AustrittDatum, EIN.DatumBis) >= @DatumVon 
      AND EIN.DatumVon <= @DatumBis
      AND EIN.AnweisungCode IN (2,3,4)
    ORDER BY LEI.BaPersonID, LEI.FaLeistungID, EIN.DatumVon ASC;

  DELETE FROM @tmpCursor
  WHERE FaLeistungID NOT IN (SELECT DISTINCT FaLeistungID 
                             FROM @tmpCursor
                             WHERE (@zusatzCode IS NULL OR APVZusatzCode = @zusatzCode)
                               AND (@einsatzplatzCode IS NULL OR KaEinsatzplatzID = @einsatzplatzCode));

  /************************************************/
  /* Corrections: Only 1 FaLeistung, update date! */
  /************************************************/
  DECLARE @BaPersonID       INT;
  DECLARE @FaLeistungID     INT;
  DECLARE @FaProzessCode    INT;
  DECLARE @KaEinsatzID      INT;
  DECLARE @APVZusatzCode    INT;
  DECLARE @KaEinsatzplatzID INT;
  DECLARE @AnweisungCode    INT;
  DECLARE @GenderCode       INT;
  DECLARE @NatCode          INT;
  DECLARE @Alter            INT;
  DECLARE @BildungCode      INT;
  DECLARE @DatVon	          DATETIME;
  DECLARE @DatBis           DATETIME;
  DECLARE @Austritt         DATETIME;
  DECLARE @CodeAustritt     VARCHAR(20);

  DECLARE @prev_faLeistungID INT;
  SET @prev_faLeistungID = -1;

  DECLARE cur CURSOR FOR
    SELECT BaPersonID, FaLeistungID, FaProzessCode, KaEinsatzID, APVZusatzCode, KaEinsatzplatzID, AnweisungCode,
           GenderCode, NatCode, [Alter], BildungCode, DatumVon, DatumBis, Austritt, [Code Austritt]
     FROM @tmpCursor;

  OPEN cur;
  
  FETCH NEXT FROM cur INTO @BaPersonID, @FaLeistungID, @FaProzessCode, @KaEinsatzID, @APVZusatzCode, @KaEinsatzplatzID, @AnweisungCode,
                           @GenderCode, @NatCode, @Alter, @BildungCode, @DatVon, @DatBis, @Austritt, @CodeAustritt;
  WHILE (@@FETCH_STATUS = 0)
  BEGIN
    IF (@FaLeistungID = @prev_faLeistungID)
    BEGIN
      -- Update row with new date to!
      IF (@DatumBis >= CONVERT(DATETIME, COALESCE(@Austritt, @DatBis, '01.01.1900')))
      BEGIN
        UPDATE @tmpMain
        SET DatumBis = @DatBis, Austritt = @Austritt, [Code Austritt] = @CodeAustritt
        WHERE FaLeistungID = @FaLeistungID;
      END ELSE
      BEGIN
        UPDATE @tmpMain
        SET DatumBis = NULL, Austritt = NULL, [Code Austritt] = NULL
        WHERE FaLeistungID = @FaLeistungID;
      END;
      --print 'BaPersonID: ' + convert(varchar, @BaPersonID) + ', Datum von: ' + convert(varchar, @DatVon, 104) + ', Datum bis: ' + convert(varchar, @DatBis, 104) + ', Austritt: ' + convert(varchar, @Austritt, 104)
    END ELSE
    BEGIN
      -- Insert the data which not match with the data already exists!!
      INSERT INTO @tmpMain (BaPersonID, FaLeistungID, FaProzessCode, KaEinsatzID, APVZusatzCode, KaEinsatzplatzID, AnweisungCode,
                            GenderCode, NatCode, [Alter], BildungCode, DatumVon, DatumBis, Austritt, [Code Austritt])
      VALUES (@BaPersonID, @FaLeistungID, @FaProzessCode, @KaEinsatzID, @APVZusatzCode, @KaEinsatzplatzID, @AnweisungCode,
              @GenderCode, @NatCode, @Alter, @BildungCode, @DatVon, @DatBis, @Austritt, @CodeAustritt);
    END;

    SET @prev_faLeistungID = @FaLeistungID;

    FETCH NEXT FROM cur INTO @BaPersonID, @FaLeistungID, @FaProzessCode, @KaEinsatzID, @APVZusatzCode, @KaEinsatzplatzID, @AnweisungCode,
                             @GenderCode, @NatCode, @Alter, @BildungCode, @DatVon, @DatBis, @Austritt, @CodeAustritt;
  END;

  CLOSE cur;
  DEALLOCATE cur;


  /**************************************************/
  /* An-/Zuweisungen ausserhalb Suchbereich löschen */
  /**************************************************/
  DELETE FROM @tmpMain 
  WHERE COALESCE(Austritt, DatumBis, CONVERT(DATETIME, '01.01.9999', 104)) < @DatumVon;

  DELETE FROM @tmpMain 
  WHERE DatumVon > @DatumBis;

  UPDATE @tmpMain
  SET DatumBis = NULL, Austritt = NULL, [Code Austritt] = NULL
  WHERE COALESCE(Austritt, DatumBis, CONVERT(DATETIME, '01.01.9999', 104)) > @DatumBis;

  /**************************/
  /* Suchzeitraum           */
  /**************************/
  INSERT INTO @tmp SELECT 'Periode ' + CONVERT(varchar, @DatumVon, 104) + ' - ' + CONVERT(varchar, @DatumBis, 104), NULL;

  /*********************************/
  /* Eintritte in Periode          */
  /*********************************/
  INSERT INTO @tmp
  SELECT 'Eintritte in Periode', COUNT(*)
  FROM @tmpMain T
  WHERE T.DatumVon >= @DatumVon;

  /*********************************/
  /* Verlängerung von Vorperiode   */
  /*********************************/
  INSERT INTO @tmp
  SELECT 'Verlängerung von Vorperiode', COUNT(*)
  FROM @tmpMain T
  WHERE T.DatumVon < @DatumVon;

  /*********************************/
  /* PvB-Eintritte effektiv        */
  /*********************************/
  INSERT INTO @tmp
  SELECT 'PvB-Eintritte effektiv', COUNT(*)
  FROM @tmpMain T;

  /*********************************/
  /* Abbrüche                      */
  /*********************************/
  INSERT INTO @tmp
  SELECT 'Abbrüche', COUNT(*)
  FROM @tmpMain T
  WHERE T.Austritt IS NOT NULL
  AND T.DatumBis > T.Austritt;

  /*********************************/
  /* PvB beendet                   */
  /*********************************/
  INSERT INTO @tmp
  SELECT 'PvB beendet', COUNT(*)
  FROM @tmpMain T
  WHERE COALESCE(T.Austritt, T.DatumBis, CONVERT(DATETIME, '01.01.9999', 104)) <= @DatumBis
  AND ISNULL(T.Austritt, T.DatumBis) = T.DatumBis;

  /*********************************/
  /* Stellenantritt Total          */
  /*********************************/
  INSERT INTO @tmp
  SELECT 'Stellenantritt Total', COUNT(*)
  FROM @tmpMain T
  WHERE [Code Austritt] IN ('D', 'E');

  /*********************************/
  /* noch in PvB                   */
  /*********************************/
  INSERT INTO @tmp
  SELECT 'noch in PvB', COUNT(*)
  FROM @tmpMain T
  WHERE COALESCE(T.Austritt, T.DatumBis, CONVERT(DATETIME, '01.01.9999', 104)) > @DatumBis;

  /*********************************/
  /* PvB-Eintritte effektiv        */
  /*********************************/
  INSERT INTO @tmp SELECT '', NULL;
  INSERT INTO @tmp SELECT 'PvB-Eintritte effektiv', NULL;

  /* Schweizer */
  INSERT INTO @tmp
  SELECT 'Schweizer', COUNT(*) FROM @tmpMain T
  WHERE GenderCode = 1
  AND NatCode = 147;

  /* Schweizerinnen */
  INSERT INTO @tmp
  SELECT 'Schweizerinnen', COUNT(*) FROM @tmpMain T
  WHERE GenderCode = 2
  AND NatCode = 147;

  /* Ausländer */
  INSERT INTO @tmp
  SELECT 'Ausländer', COUNT(*) FROM @tmpMain T
  WHERE GenderCode = 1
  AND (NatCode <> 147 AND NatCode IS NOT NULL);

  /* Ausländerinnen */
  INSERT INTO @tmp
  SELECT 'Ausländerinnen', COUNT(*) FROM @tmpMain T
  WHERE GenderCode = 2
  AND (NatCode <> 147 AND NatCode IS NOT NULL);

  /* bis 19 */
  INSERT INTO @tmp
  SELECT '0 bis 19', COUNT(*) FROM @tmpMain T
  WHERE [Alter] < 20;

  /* 20 bis 29 */
  INSERT INTO @tmp
  SELECT '20 bis 29', COUNT(*) FROM @tmpMain T
  WHERE [Alter] BETWEEN 20 AND 29;

  /* 30 bis 39 */
  INSERT INTO @tmp
  SELECT '30 bis 39', COUNT(*) FROM @tmpMain T
  WHERE [Alter] BETWEEN 30 AND 39;

  /* 40 bis 49 */
  INSERT INTO @tmp
  SELECT '40 bis 49', COUNT(*) FROM @tmpMain T
  WHERE [Alter] BETWEEN 40 AND 49;

  /* 50 bis 59 */
  INSERT INTO @tmp
  SELECT '50 bis 59', COUNT(*) FROM @tmpMain T
  WHERE [Alter] BETWEEN 50 AND 59;

  /* über 60 */
  INSERT INTO @tmp
  SELECT 'über 60', COUNT(*) FROM @tmpMain T
  WHERE [Alter] > 59;

  /* ohne Beruf */
  INSERT INTO @tmp
  SELECT 'ohne Beruf', COUNT(*) FROM @tmpMain T
  WHERE BildungCode = 1;

  /* abgeschlossene Lehre */
  INSERT INTO @tmp
  SELECT 'abgeschlossene Lehre', COUNT(*) FROM @tmpMain T
  WHERE BildungCode = 2;

  /* andere Ausbildung */
  INSERT INTO @tmp
  SELECT 'andere Ausbildung', COUNT(*) FROM @tmpMain T
  WHERE BildungCode = 3;

  /* Hochschulabschluss */
  INSERT INTO @tmp
  SELECT 'Hochschulabschluss', COUNT(*) FROM @tmpMain T
  WHERE BildungCode = 4;

  /*********************************/
  /* Abbrüche                      */
  /*********************************/
  INSERT INTO @tmp SELECT '', NULL;
  INSERT INTO @tmp SELECT 'Abbrüche', NULL;

  /* Arbeitslos */
  INSERT INTO @tmp
  SELECT 'Arbeitslos', COUNT(*) FROM @tmpMain T
  WHERE T.[Code Austritt] IN ('I', 'K')
    AND T.Austritt IS NOT NULL
    AND T.DatumBis > T.Austritt;

  /* Andere Lösung */
  INSERT INTO @tmp
  SELECT 'Andere Lösung', COUNT(*) FROM @tmpMain T
  WHERE (T.[Code Austritt] IS NULL OR T.[Code Austritt] = '')
    AND T.Austritt IS NOT NULL
    AND T.DatumBis > T.Austritt;

  /* Stellenantritt */
  INSERT INTO @tmp
  SELECT 'Stellenantritt', COUNT(*) FROM @tmpMain T
  WHERE T.[Code Austritt] IN ('D', 'E')
    AND T.Austritt IS NOT NULL
    AND T.DatumBis > T.Austritt;

  /*********************************/
  /* PvB beendet                   */
  /*********************************/
  INSERT INTO @tmp SELECT '', NULL;
  INSERT INTO @tmp SELECT 'PvB beendet', NULL;

  /* Stellenantritt */
  INSERT INTO @tmp
  SELECT 'Stellenantritt', COUNT(*) FROM @tmpMain T
  WHERE T.[Code Austritt] IN ('D', 'E')
    AND COALESCE(T.Austritt, T.DatumBis, CONVERT(DATETIME, '01.01.9999', 104)) <= @DatumBis
    AND ISNULL(T.Austritt, T.DatumBis) = T.DatumBis;

  /* Andere Lösung */
  INSERT INTO @tmp
  SELECT 'Andere Lösung', COUNT(*) FROM @tmpMain T
  WHERE (T.[Code Austritt] IS NULL OR T.[Code Austritt] = '')
    AND COALESCE(T.Austritt, T.DatumBis, CONVERT(DATETIME, '01.01.9999', 104)) <= @DatumBis
    AND ISNULL(T.Austritt, T.DatumBis) = T.DatumBis;

  /* Arbeitslos */
  INSERT INTO @tmp
  SELECT 'Arbeitslos', COUNT(*) FROM @tmpMain T
  WHERE T.[Code Austritt] IN ('I', 'K')
    AND COALESCE(T.Austritt, T.DatumBis, CONVERT(DATETIME, '01.01.9999', 104)) <= @DatumBis
    AND ISNULL(T.Austritt, T.DatumBis) = T.DatumBis;

  /*********************************/
  /* Stellenantritt total         */
  /*********************************/
  INSERT INTO @tmp SELECT '', NULL;
  INSERT INTO @tmp SELECT 'Stellenantritt total', NULL;

  /* Schweizer */
  INSERT INTO @tmp
  SELECT 'Schweizer', COUNT(*) FROM @tmpMain T
  WHERE GenderCode = 1
    AND NatCode = 147
    AND T.[Code Austritt] IN ('D', 'E');

  /* Schweizerinnen */
  INSERT INTO @tmp
  SELECT 'Schweizerinnen', COUNT(*) FROM @tmpMain T
  WHERE GenderCode = 2
    AND NatCode = 147
    AND T.[Code Austritt] IN ('D', 'E');

  /* Ausländer */
  INSERT INTO @tmp
  SELECT 'Ausländer', COUNT(*) FROM @tmpMain T
  WHERE GenderCode = 1
    AND (NatCode <> 147 AND NatCode IS NOT NULL)
    AND T.[Code Austritt] IN ('D', 'E');

  /* Ausländerinnen */
  INSERT INTO @tmp
  SELECT 'Ausländerinnen', COUNT(*) FROM @tmpMain T
  WHERE GenderCode = 2
    AND (NatCode <> 147 AND NatCode IS NOT NULL)
    AND T.[Code Austritt] IN ('D', 'E');

  /* bis 19 */
  INSERT INTO @tmp
  SELECT '0 bis 19', COUNT(*) FROM @tmpMain T
  WHERE [Alter] < 20
    AND T.[Code Austritt] IN ('D', 'E');

  /* 20 bis 29 */
  INSERT INTO @tmp
  SELECT '20 bis 29', COUNT(*) FROM @tmpMain T
  WHERE [Alter] BETWEEN 20 AND 29
    AND T.[Code Austritt] IN ('D', 'E');

  /* 30 bis 39 */
  INSERT INTO @tmp
  SELECT '30 bis 39', COUNT(*) FROM @tmpMain T
  WHERE [Alter] BETWEEN 30 AND 39
    AND T.[Code Austritt] IN ('D', 'E');

  /* 40 bis 49 */
  INSERT INTO @tmp
  SELECT '40 bis 49', COUNT(*) FROM @tmpMain T
  WHERE [Alter] BETWEEN 40 AND 49
    AND T.[Code Austritt] IN ('D', 'E');

  /* 50 bis 59 */
  INSERT INTO @tmp
  SELECT '50 bis 59', COUNT(*) FROM @tmpMain T
  WHERE [Alter] BETWEEN 50 AND 59
    AND T.[Code Austritt] IN ('D', 'E');

  /* über 60 */
  INSERT INTO @tmp
  SELECT 'über 60', COUNT(*) FROM @tmpMain T
  WHERE [Alter] > 59
    AND T.[Code Austritt] IN ('D', 'E');

  /* ohne Beruf */
  INSERT INTO @tmp
  SELECT 'ohne Beruf', COUNT(*) FROM @tmpMain T
  WHERE BildungCode = 1
    AND T.[Code Austritt] IN ('D', 'E');

  /* abgeschlossene Lehre */
  INSERT INTO @tmp
  SELECT 'abgeschlossene Lehre', COUNT(*) FROM @tmpMain T
  WHERE BildungCode = 2
    AND T.[Code Austritt] IN ('D', 'E');

  /* andere Ausbildung */
  INSERT INTO @tmp
  SELECT 'andere Ausbildung', COUNT(*) FROM @tmpMain T
  WHERE BildungCode = 3
    AND T.[Code Austritt] IN ('D', 'E');

  /* Hochschulabschluss */
  INSERT INTO @tmp
  SELECT 'Hochschulabschluss', COUNT(*) FROM @tmpMain T
  WHERE BildungCode = 4
    AND T.[Code Austritt] IN ('D', 'E');

  /*****************/
  /* Get the list  */
  /*****************/
  SELECT Bezeichnung, Wert 
  FROM @tmp;
END;
GO