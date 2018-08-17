SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKaGetPraesenzzeit
GO
/*===============================================================================================
  $Revision: 9 $
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
CREATE PROCEDURE dbo.spKaGetPraesenzzeit
(
  @IsUserKA      INT,
  @Monat         INT,
  @Jahr          INT,
  @KlientID      INT,
  @APVNr         INT,
  @Zusatz        INT,
  @CoachID       INT,
  @FachbereichID INT,
  @FachleitungID INT,
  @KursID        INT
)
AS BEGIN
  -----------------------------------------------------------------------------
  -- start call
  -----------------------------------------------------------------------------
  SET NOCOUNT ON;

  -----------------------------------------------------------------------------
  -- declare and set variables
  -----------------------------------------------------------------------------

DECLARE @tmp TABLE 
  (
    ID           INT IDENTITY,
    BaPersonID   INT,
    KaEinsatzID  INT,
    Tag          INT,
    AM_AnwCode   INT,
    PM_AnwCode   INT,
    AM_Bemerkung VARCHAR(MAX),
    PM_Bemerkung VARCHAR(MAX),
    SamstagAktiv BIT,
    SonntagAktiv BIT,
    PRIMARY KEY (BaPersonID,Tag,ID)
  );

  DECLARE @SichtbarSD INT;
  DECLARE @MonatStr   VARCHAR(2);
  DECLARE @JahrStr    VARCHAR(4);
  
  SET @MonatStr = CONVERT(VARCHAR(2), @Monat);
  SET @JahrStr  = CONVERT(VARCHAR(4), @Jahr);

  IF @IsUserKA = 0 
  BEGIN
    SET @SichtbarSD = 0;
  END 
  ELSE 
  BEGIN
    SET @SichtbarSD = 1;
  END;

  -----------------------------------------------------------------------------
  -- insert into temp table
  -----------------------------------------------------------------------------
  INSERT @tmp
    SELECT KAR.BaPersonID,
           KAE.KaEinsatzID,
           DAY(Datum),
           AM_AnwCode,
           PM_AnwCode,
           AM_Bemerkung,
           PM_Bemerkung,
           SamstagAktiv = ISNULL(KAE.SamstagAktiv,0),
           SonntagAktiv = ISNULL(KAE.SonntagAktiv,0)
    FROM dbo.KaArbeitsrapport  KAR WITH (READUNCOMMITTED) 
      INNER JOIN dbo.KAEinsatz KAE WITH (READUNCOMMITTED) ON KAE.KaEinsatzID=KAR.KaEinsatzID
    WHERE YEAR(Datum) = @Jahr 
      AND MONTH(Datum) = @Monat
      AND (KAR.SichtbarSDFlag = @SichtbarSD 
       OR (KAR.SichtbarSDFlag = (SELECT PER.SichtbarSDFlag 
                                 FROM dbo.BaPerson PER WITH (READUNCOMMITTED) 
                                 WHERE PER.BaPersonID = KAR.BaPersonID) 
       OR KAR.SichtbarSDFlag = 1))
      AND KAR.BaPersonID = ISNULL(@KlientID, KAR.BaPersonID)
      AND KAR.KaEinsatzID IN (SELECT KAE.KaEinsatzID
                              FROM dbo.KaEinsatz KAE WITH (READUNCOMMITTED) 
                              WHERE KAE.KaEinsatzplatzID = ISNULL(@APVNr, KAE.KaEinsatzplatzID))
      AND KAR.KaEinsatzID IN (SELECT KAE1.KaEinsatzID
                              FROM dbo.KaEinsatz KAE1 WITH (READUNCOMMITTED) 
                              WHERE @Zusatz IS NULL 
                                OR  @Zusatz = KAE1.APVZusatzCode)
      AND (@CoachID IS NULL 
        OR EXISTS (SELECT TOP 1 1 
                   FROM  dbo.KaZuteilFachbereich ZUT1 WITH (READUNCOMMITTED) 
                   WHERE ZUT1.ZustaendigKaID = @CoachID 
                     AND BaPersonID = KAR.BaPersonID
                     AND dbo.fnDateOf(ZUT1.ZuteilungVon) < DATEADD(MONTH, 1, dbo.fnDateSerial(@Jahr, @Monat, 1))
                     AND (dbo.fnDateOf(ZUT1.ZuteilungBis) >= dbo.fnDateSerial(@Jahr, @Monat, 1)
                      OR ZUT1.ZuteilungBis IS NULL)))
      AND (@FachbereichID IS NULL 
       OR KAR.BaPersonID IN (SELECT DISTINCT ZUT.BaPersonID
                             FROM  dbo.KaZuteilFachbereich ZUT WITH (READUNCOMMITTED) 
                             WHERE @FachbereichID = ZUT.FachbereichID
                               AND dbo.fnDateOf(ZUT.ZuteilungVon) < DATEADD(MONTH, 1, dbo.fnDateSerial(@Jahr, @Monat, 1))
                               AND (dbo.fnDateOf(ZUT.ZuteilungBis) >= dbo.fnDateSerial(@Jahr, @Monat, 1)
                                OR ZUT.ZuteilungBis IS NULL)))
      AND (@FachleitungID IS NULL 
       OR KAR.BaPersonID IN (SELECT DISTINCT ZUT2.BaPersonID
                             FROM  dbo.KaZuteilFachbereich ZUT2 WITH (READUNCOMMITTED) 
                             WHERE ZUT2.FachleitungID = @FachleitungID
                               AND dbo.fnDateOf(ZUT2.ZuteilungVon) < DATEADD(MONTH, 1, dbo.fnDateSerial(@Jahr, @Monat, 1))
                               AND (dbo.fnDateOf(ZUT2.ZuteilungBis) >= dbo.fnDateSerial(@Jahr, @Monat, 1)
                                OR ZUT2.ZuteilungBis IS NULL)))
      AND (@KursID IS NULL 
       OR KAR.BaPersonID IN (SELECT DISTINCT IBI.BaPersonID
                             FROM  dbo.KaIntegBildung IBI WITH (READUNCOMMITTED) 
                             WHERE IBI.KaKurserfassungID = @KursID 
                               AND dbo.fnDateOf(IBI.Eintritt)< DATEADD(MONTH, 1, dbo.fnDateSerial(@Jahr, @Monat, 1))
                               AND dbo.fnDateOf(IBI.Austritt) >= dbo.fnDateSerial(@Jahr, @Monat, 1))
       OR KAR.BaPersonID IN (SELECT DISTINCT LEI.BaPersonID 
                             FROM FaLeistung LEI WITH (READUNCOMMITTED)
                             WHERE LEI.FaLeistungID IN (SELECT KAV.FaLeistungID 
                                                        FROM dbo.KaAbklaerungVertieft KAV WITH (READUNCOMMITTED) 
                                                        WHERE KAV.KaKurserfassungID = @KursID)));

  -----------------------------------------------------------------------------
  -- output
  -----------------------------------------------------------------------------
  SELECT T.BaPersonID,
         PRS.Name,
         PRS.Vorname,
         Klient = PRS.Name + IsNull(', ' + PRS.Vorname,''),
         BG = STUFF(( SELECT DISTINCT ', ' + CONVERT(VARCHAR, KAE.BeschGrad)
                      FROM @tmp TI
                        INNER JOIN KaEinsatz KAE ON KAE.KaEinsatzID = TI.KaEinsatzID 
                      WHERE TI.BaPersonID = T.BaPersonID
                      FOR XML PATH('')),
                      1,
                      2, 
                      ''),
         VN = 'V',
         [Code01] = T01.AM_AnwCode,
         [Code02] = T02.AM_AnwCode,
         [Code03] = T03.AM_AnwCode,
         [Code04] = T04.AM_AnwCode,
         [Code05] = T05.AM_AnwCode,
         [Code06] = T06.AM_AnwCode,
         [Code07] = T07.AM_AnwCode,
         [Code08] = T08.AM_AnwCode,
         [Code09] = T09.AM_AnwCode,
         [Code10] = T10.AM_AnwCode,
         [Code11] = T11.AM_AnwCode,
         [Code12] = T12.AM_AnwCode,
         [Code13] = T13.AM_AnwCode,
         [Code14] = T14.AM_AnwCode,
         [Code15] = T15.AM_AnwCode,
         [Code16] = T16.AM_AnwCode,
         [Code17] = T17.AM_AnwCode,
         [Code18] = T18.AM_AnwCode,
         [Code19] = T19.AM_AnwCode,
         [Code20] = T20.AM_AnwCode,
         [Code21] = T21.AM_AnwCode,
         [Code22] = T22.AM_AnwCode,
         [Code23] = T23.AM_AnwCode,
         [Code24] = T24.AM_AnwCode,
         [Code25] = T25.AM_AnwCode,
         [Code26] = T26.AM_AnwCode,
         [Code27] = T27.AM_AnwCode,
         [Code28] = T28.AM_AnwCode,
         [Code29] = T29.AM_AnwCode,
         [Code30] = T30.AM_AnwCode,
         [Code31] = T31.AM_AnwCode,

         [Bem01]  = T01.AM_Bemerkung,
         [Bem02]  = T02.AM_Bemerkung,
         [Bem03]  = T03.AM_Bemerkung,
         [Bem04]  = T04.AM_Bemerkung,
         [Bem05]  = T05.AM_Bemerkung,
         [Bem06]  = T06.AM_Bemerkung,
         [Bem07]  = T07.AM_Bemerkung,
         [Bem08]  = T08.AM_Bemerkung,
         [Bem09]  = T09.AM_Bemerkung,
         [Bem10]  = T10.AM_Bemerkung,
         [Bem11]  = T11.AM_Bemerkung,
         [Bem12]  = T12.AM_Bemerkung,
         [Bem13]  = T13.AM_Bemerkung,
         [Bem14]  = T14.AM_Bemerkung,
         [Bem15]  = T15.AM_Bemerkung,
         [Bem16]  = T16.AM_Bemerkung,
         [Bem17]  = T17.AM_Bemerkung,
         [Bem18]  = T18.AM_Bemerkung,
         [Bem19]  = T19.AM_Bemerkung,
         [Bem20]  = T20.AM_Bemerkung,
         [Bem21]  = T21.AM_Bemerkung,
         [Bem22]  = T22.AM_Bemerkung,
         [Bem23]  = T23.AM_Bemerkung,
         [Bem24]  = T24.AM_Bemerkung,
         [Bem25]  = T25.AM_Bemerkung,
         [Bem26]  = T26.AM_Bemerkung,
         [Bem27]  = T27.AM_Bemerkung,
         [Bem28]  = T28.AM_Bemerkung,
         [Bem29]  = T29.AM_Bemerkung,
         [Bem30]  = T30.AM_Bemerkung,
         [Bem31]  = T31.AM_Bemerkung,

         [SamstagAktiv01]  = T01.SamstagAktiv,
         [SamstagAktiv02]  = T02.SamstagAktiv,
         [SamstagAktiv03]  = T03.SamstagAktiv,
         [SamstagAktiv04]  = T04.SamstagAktiv,
         [SamstagAktiv05]  = T05.SamstagAktiv,
         [SamstagAktiv06]  = T06.SamstagAktiv,
         [SamstagAktiv07]  = T07.SamstagAktiv,
         [SamstagAktiv08]  = T08.SamstagAktiv,
         [SamstagAktiv09]  = T09.SamstagAktiv,
         [SamstagAktiv10]  = T10.SamstagAktiv,
         [SamstagAktiv11]  = T11.SamstagAktiv,
         [SamstagAktiv12]  = T12.SamstagAktiv,
         [SamstagAktiv13]  = T13.SamstagAktiv,
         [SamstagAktiv14]  = T14.SamstagAktiv,
         [SamstagAktiv15]  = T15.SamstagAktiv,
         [SamstagAktiv16]  = T16.SamstagAktiv,
         [SamstagAktiv17]  = T17.SamstagAktiv,
         [SamstagAktiv18]  = T18.SamstagAktiv,
         [SamstagAktiv19]  = T19.SamstagAktiv,
         [SamstagAktiv20]  = T20.SamstagAktiv,
         [SamstagAktiv21]  = T21.SamstagAktiv,
         [SamstagAktiv22]  = T22.SamstagAktiv,
         [SamstagAktiv23]  = T23.SamstagAktiv,
         [SamstagAktiv24]  = T24.SamstagAktiv,
         [SamstagAktiv25]  = T25.SamstagAktiv,
         [SamstagAktiv26]  = T26.SamstagAktiv,
         [SamstagAktiv27]  = T27.SamstagAktiv,
         [SamstagAktiv28]  = T28.SamstagAktiv,
         [SamstagAktiv29]  = T29.SamstagAktiv,
         [SamstagAktiv30]  = T30.SamstagAktiv,
         [SamstagAktiv31]  = T31.SamstagAktiv,

         [SonntagAktiv01]  = T01.SonntagAktiv,
         [SonntagAktiv02]  = T02.SonntagAktiv,
         [SonntagAktiv03]  = T03.SonntagAktiv,
         [SonntagAktiv04]  = T04.SonntagAktiv,
         [SonntagAktiv05]  = T05.SonntagAktiv,
         [SonntagAktiv06]  = T06.SonntagAktiv,
         [SonntagAktiv07]  = T07.SonntagAktiv,
         [SonntagAktiv08]  = T08.SonntagAktiv,
         [SonntagAktiv09]  = T09.SonntagAktiv,
         [SonntagAktiv10]  = T10.SonntagAktiv,
         [SonntagAktiv11]  = T11.SonntagAktiv,
         [SonntagAktiv12]  = T12.SonntagAktiv,
         [SonntagAktiv13]  = T13.SonntagAktiv,
         [SonntagAktiv14]  = T14.SonntagAktiv,
         [SonntagAktiv15]  = T15.SonntagAktiv,
         [SonntagAktiv16]  = T16.SonntagAktiv,
         [SonntagAktiv17]  = T17.SonntagAktiv,
         [SonntagAktiv18]  = T18.SonntagAktiv,
         [SonntagAktiv19]  = T19.SonntagAktiv,
         [SonntagAktiv20]  = T20.SonntagAktiv,
         [SonntagAktiv21]  = T21.SonntagAktiv,
         [SonntagAktiv22]  = T22.SonntagAktiv,
         [SonntagAktiv23]  = T23.SonntagAktiv,
         [SonntagAktiv24]  = T24.SonntagAktiv,
         [SonntagAktiv25]  = T25.SonntagAktiv,
         [SonntagAktiv26]  = T26.SonntagAktiv,
         [SonntagAktiv27]  = T27.SonntagAktiv,
         [SonntagAktiv28]  = T28.SonntagAktiv,
         [SonntagAktiv29]  = T29.SonntagAktiv,
         [SonntagAktiv30]  = T30.SonntagAktiv,
         [SonntagAktiv31]  = T31.SonntagAktiv,

         [StatA] = CONVERT(float, ((SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND AM_AnwCode = 1) +
                    (SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND PM_AnwCode = 1))) / 2,
         [StatB] = CONVERT(float, ((SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND AM_AnwCode = 2) +
                    (SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND PM_AnwCode = 2))) / 2,
         [StatC] = CONVERT(float, ((SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND AM_AnwCode = 3) +
                    (SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND PM_AnwCode = 3))) / 2,
         [StatE] = CONVERT(float, ((SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND AM_AnwCode = 4) +
                    (SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND PM_AnwCode = 4))) / 2,
         [StatF] = CONVERT(float, ((SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND AM_AnwCode = 5) +
                    (SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND PM_AnwCode = 5))) / 2,
         [StatG] = CONVERT(float, ((SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND AM_AnwCode = 6) +
                    (SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND PM_AnwCode = 6))) / 2,
         [StatH] = CONVERT(float, ((SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND AM_AnwCode = 7) +
                    (SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND PM_AnwCode = 7))) / 2,
         [StatI] = CONVERT(float, ((SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND AM_AnwCode = 8) +
                    (SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND PM_AnwCode = 8))) / 2,
         [StatX] = CONVERT(float, ((SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND AM_AnwCode = 9) +
                    (SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND PM_AnwCode = 9))) / 2,
         [StatY] = CONVERT(float, ((SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND AM_AnwCode = 10) +
                    (SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND PM_AnwCode = 10))) / 2,
     [StatZ] = CONVERT(float, ((SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND AM_AnwCode = 11) +
                    (SELECT COUNT(*) FROM @tmp WHERE BaPersonID = T.BaPersonID AND PM_AnwCode = 11))) / 2
  FROM (SELECT DISTINCT BaPersonID FROM @tmp) T
    INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) on PRS.BaPersonID = T.BaPersonID

    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 01) T01
    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 02) T02
    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 03) T03
    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 04) T04
    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 05) T05
    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 06) T06
    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 07) T07
    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 08) T08
    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 09) T09

    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 10) T10
    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 11) T11
    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 12) T12
    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 13) T13
    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 14) T14
    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 15) T15
    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 16) T16
    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 17) T17
    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 18) T18
    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 19) T19

    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 20) T20
    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 21) T21
    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 22) T22
    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 23) T23
    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 24) T24
    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 25) T25
    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 26) T26
    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 27) T27
    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 28) T28
    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 29) T29

    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 30) T30
    OUTER APPLY (SELECT TOP 1 AM_AnwCode, AM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 31) T31

  UNION ALL

  SELECT T.BaPersonID,
         PRS.Name,
         PRS.Vorname,
         Klient = NULL,
         BG = NULL,
         VN = 'N',

         [Code01] = T01.PM_AnwCode,
         [Code02] = T02.PM_AnwCode,
         [Code03] = T03.PM_AnwCode,
         [Code04] = T04.PM_AnwCode,
         [Code05] = T05.PM_AnwCode,
         [Code06] = T06.PM_AnwCode,
         [Code07] = T07.PM_AnwCode,
         [Code08] = T08.PM_AnwCode,
         [Code09] = T09.PM_AnwCode,
         [Code10] = T10.PM_AnwCode,
         [Code11] = T11.PM_AnwCode,
         [Code12] = T12.PM_AnwCode,
         [Code13] = T13.PM_AnwCode,
         [Code14] = T14.PM_AnwCode,
         [Code15] = T15.PM_AnwCode,
         [Code16] = T16.PM_AnwCode,
         [Code17] = T17.PM_AnwCode,
         [Code18] = T18.PM_AnwCode,
         [Code19] = T19.PM_AnwCode,
         [Code20] = T20.PM_AnwCode,
         [Code21] = T21.PM_AnwCode,
         [Code22] = T22.PM_AnwCode,
         [Code23] = T23.PM_AnwCode,
         [Code24] = T24.PM_AnwCode,
         [Code25] = T25.PM_AnwCode,
         [Code26] = T26.PM_AnwCode,
         [Code27] = T27.PM_AnwCode,
         [Code28] = T28.PM_AnwCode,
         [Code29] = T29.PM_AnwCode,
         [Code30] = T30.PM_AnwCode,
         [Code31] = T31.PM_AnwCode,

         [Bem01]  = T01.PM_Bemerkung,
         [Bem02]  = T02.PM_Bemerkung,
         [Bem03]  = T03.PM_Bemerkung,
         [Bem04]  = T04.PM_Bemerkung,
         [Bem05]  = T05.PM_Bemerkung,
         [Bem06]  = T06.PM_Bemerkung,
         [Bem07]  = T07.PM_Bemerkung,
         [Bem08]  = T08.PM_Bemerkung,
         [Bem09]  = T09.PM_Bemerkung,
         [Bem10]  = T10.PM_Bemerkung,
         [Bem11]  = T11.PM_Bemerkung,
         [Bem12]  = T12.PM_Bemerkung,
         [Bem13]  = T13.PM_Bemerkung,
         [Bem14]  = T14.PM_Bemerkung,
         [Bem15]  = T15.PM_Bemerkung,
         [Bem16]  = T16.PM_Bemerkung,
         [Bem17]  = T17.PM_Bemerkung,
         [Bem18]  = T18.PM_Bemerkung,
         [Bem19]  = T19.PM_Bemerkung,
         [Bem20]  = T20.PM_Bemerkung,
         [Bem21]  = T21.PM_Bemerkung,
         [Bem22]  = T22.PM_Bemerkung,
         [Bem23]  = T23.PM_Bemerkung,
         [Bem24]  = T24.PM_Bemerkung,
         [Bem25]  = T25.PM_Bemerkung,
         [Bem26]  = T26.PM_Bemerkung,
         [Bem27]  = T27.PM_Bemerkung,
         [Bem28]  = T28.PM_Bemerkung,
         [Bem29]  = T29.PM_Bemerkung,
         [Bem30]  = T30.PM_Bemerkung,
         [Bem31]  = T31.PM_Bemerkung,

         [SamstagAktiv01]  = T01.SamstagAktiv,
         [SamstagAktiv02]  = T02.SamstagAktiv,
         [SamstagAktiv03]  = T03.SamstagAktiv,
         [SamstagAktiv04]  = T04.SamstagAktiv,
         [SamstagAktiv05]  = T05.SamstagAktiv,
         [SamstagAktiv06]  = T06.SamstagAktiv,
         [SamstagAktiv07]  = T07.SamstagAktiv,
         [SamstagAktiv08]  = T08.SamstagAktiv,
         [SamstagAktiv09]  = T09.SamstagAktiv,
         [SamstagAktiv10]  = T10.SamstagAktiv,
         [SamstagAktiv11]  = T11.SamstagAktiv,
         [SamstagAktiv12]  = T12.SamstagAktiv,
         [SamstagAktiv13]  = T13.SamstagAktiv,
         [SamstagAktiv14]  = T14.SamstagAktiv,
         [SamstagAktiv15]  = T15.SamstagAktiv,
         [SamstagAktiv16]  = T16.SamstagAktiv,
         [SamstagAktiv17]  = T17.SamstagAktiv,
         [SamstagAktiv18]  = T18.SamstagAktiv,
         [SamstagAktiv19]  = T19.SamstagAktiv,
         [SamstagAktiv20]  = T20.SamstagAktiv,
         [SamstagAktiv21]  = T21.SamstagAktiv,
         [SamstagAktiv22]  = T22.SamstagAktiv,
         [SamstagAktiv23]  = T23.SamstagAktiv,
         [SamstagAktiv24]  = T24.SamstagAktiv,
         [SamstagAktiv25]  = T25.SamstagAktiv,
         [SamstagAktiv26]  = T26.SamstagAktiv,
         [SamstagAktiv27]  = T27.SamstagAktiv,
         [SamstagAktiv28]  = T28.SamstagAktiv,
         [SamstagAktiv29]  = T29.SamstagAktiv,
         [SamstagAktiv30]  = T30.SamstagAktiv,
         [SamstagAktiv31]  = T31.SamstagAktiv,

         [SonntagAktiv01]  = T01.SonntagAktiv,
         [SonntagAktiv02]  = T02.SonntagAktiv,
         [SonntagAktiv03]  = T03.SonntagAktiv,
         [SonntagAktiv04]  = T04.SonntagAktiv,
         [SonntagAktiv05]  = T05.SonntagAktiv,
         [SonntagAktiv06]  = T06.SonntagAktiv,
         [SonntagAktiv07]  = T07.SonntagAktiv,
         [SonntagAktiv08]  = T08.SonntagAktiv,
         [SonntagAktiv09]  = T09.SonntagAktiv,
         [SonntagAktiv10]  = T10.SonntagAktiv,
         [SonntagAktiv11]  = T11.SonntagAktiv,
         [SonntagAktiv12]  = T12.SonntagAktiv,
         [SonntagAktiv13]  = T13.SonntagAktiv,
         [SonntagAktiv14]  = T14.SonntagAktiv,
         [SonntagAktiv15]  = T15.SonntagAktiv,
         [SonntagAktiv16]  = T16.SonntagAktiv,
         [SonntagAktiv17]  = T17.SonntagAktiv,
         [SonntagAktiv18]  = T18.SonntagAktiv,
         [SonntagAktiv19]  = T19.SonntagAktiv,
         [SonntagAktiv20]  = T20.SonntagAktiv,
         [SonntagAktiv21]  = T21.SonntagAktiv,
         [SonntagAktiv22]  = T22.SonntagAktiv,
         [SonntagAktiv23]  = T23.SonntagAktiv,
         [SonntagAktiv24]  = T24.SonntagAktiv,
         [SonntagAktiv25]  = T25.SonntagAktiv,
         [SonntagAktiv26]  = T26.SonntagAktiv,
         [SonntagAktiv27]  = T27.SonntagAktiv,
         [SonntagAktiv28]  = T28.SonntagAktiv,
         [SonntagAktiv29]  = T29.SonntagAktiv,
         [SonntagAktiv30]  = T30.SonntagAktiv,
         [SonntagAktiv31]  = T31.SonntagAktiv,

         [Stat01] = NULL,
         [Stat02] = NULL,
         [Stat03] = NULL,
         [Stat04] = NULL,
         [Stat05] = NULL,
         [Stat06] = NULL,
         [Stat07] = NULL,
         [Stat08] = NULL,
         [Stat09]	= NULL,
         [Stat10]	= NULL,
         [Stat11]	= NULL
  FROM (SELECT DISTINCT BaPersonID FROM @tmp) T
    INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = T.BaPersonID

    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 01) T01
    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 02) T02
    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 03) T03
    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 04) T04
    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 05) T05
    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 06) T06
    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 07) T07
    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 08) T08
    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 09) T09

    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 10) T10
    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 11) T11
    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 12) T12
    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 13) T13
    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 14) T14
    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 15) T15
    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 16) T16
    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 17) T17
    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 18) T18
    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 19) T19

    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 20) T20
    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 21) T21
    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 22) T22
    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 23) T23
    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 24) T24
    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 25) T25
    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 26) T26
    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 27) T27
    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 28) T28
    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 29) T29

    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 30) T30
    OUTER APPLY (SELECT TOP 1 PM_AnwCode, PM_Bemerkung, SamstagAktiv, SonntagAktiv FROM @tmp WHERE BaPersonID = T.BaPersonID AND Tag = 31) T31

  ORDER BY 2, 3, 1, 5 DESC;
END
GO