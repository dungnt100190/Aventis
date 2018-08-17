SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnKaGetAustrittDatumCode;
GO
/*===============================================================================================
  $Revision: 7 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Holt in Abhängigkeit des FaProzessCode der übergebenen methodischen Leistung das 
           'AustrittDatum' und den 'AustrittCode'.
    @FaLeistungID: Die ID der methodischen Leistung
    @KaEinsatzID: Die ID des KaEinsatz records (optional)
  -
  RETURNS: Spalten: 'AustrittDatum' und 'AustrittCode' etc. - Nur eine Zeile wird zurückgegeben, sonst Error
=================================================================================================
  TEST:    SELECT AustrittDatum, AustrittCode FROM dbo.fnKaGetAustrittDatumCode(66626, 5185); --Abklärung (DatumBis > AustrittDatum) -> AustrittDatum = 2007-02-08
           SELECT AustrittDatum, AustrittCode FROM dbo.fnKaGetAustrittDatumCode(66626, NULL); --Abklärung (KaEinsatzID IS NULL) -> AustrittDatum = 2007-02-08
           SELECT AustrittDatum, AustrittCode FROM dbo.fnKaGetAustrittDatumCode(64690, 5174); --Abklärung (DatumBis < AustrittDatum) -> AustrittDatum = NULL
           SELECT AustrittDatum, AustrittCode FROM dbo.fnKaGetAustrittDatumCode(64690, NULL); --Abklärung (KaEinsatzID IS NULL) -> AustrittDatum = 2007-03-22

           SELECT AustrittDatum, AustrittCode FROM dbo.fnKaGetAustrittDatumCode(116713, NULL); --Inizio -> AustrittDatum immer NULL

           SELECT AustrittDatum, AustrittCode FROM dbo.fnKaGetAustrittDatumCode(67356, 4685); --Qualifizierung Jugend (DatumBis > AustrittDatum) -> AustrittDatum = 2007-01-18
           SELECT AustrittDatum, AustrittCode FROM dbo.fnKaGetAustrittDatumCode(67356, NULL); --Qualifizierung Jugend (KaEinsatzID IS NULL) -> AustrittDatum = 2007-01-18
           SELECT AustrittDatum, AustrittCode FROM dbo.fnKaGetAustrittDatumCode(64592, 4654); --Qualifizierung Jugend (DatumBis < AustrittDatum) -> AustrittDatum = NULL
           SELECT AustrittDatum, AustrittCode FROM dbo.fnKaGetAustrittDatumCode(64592, NULL); --Qualifizierung Jugend (KaEinsatzID IS NULL) -> AustrittDatum = 2007-07-31

           SELECT AustrittDatum, AustrittCode FROM dbo.fnKaGetAustrittDatumCode(64210, 4682); --QE Jobtimum (DatumBis > AustrittDatum) -> AustrittDatum = 2007-02-02
           SELECT AustrittDatum, AustrittCode FROM dbo.fnKaGetAustrittDatumCode(64210, NULL); --QE Jobtimum (KaEinsatzID IS NULL) -> AustrittDatum = 2007-02-02
           SELECT AustrittDatum, AustrittCode FROM dbo.fnKaGetAustrittDatumCode(64110, 4756); --QE Jobtimum (DatumBis < AustrittDatum) -> AustrittDatum = NULL
           SELECT AustrittDatum, AustrittCode FROM dbo.fnKaGetAustrittDatumCode(64832, NULL); --QE Jobtimum (KaEinsatzID IS NULL) -> AustrittDatum = 2007-03-16

           SELECT AustrittDatum, AustrittCode FROM dbo.fnKaGetAustrittDatumCode(63988, 4714); --QE EPQ (DatumBis > AustrittDatum) -> AustrittDatum = 2007-01-19
           SELECT AustrittDatum, AustrittCode FROM dbo.fnKaGetAustrittDatumCode(63988, NULL); --QE EPQ (KaEinsatzID IS NULL) -> AustrittDatum = 2007-01-19
           SELECT AustrittDatum, AustrittCode FROM dbo.fnKaGetAustrittDatumCode(64832, 4754); --QE EPQ (DatumBis < AustrittDatum) -> AustrittDatum = NULL
           SELECT AustrittDatum, AustrittCode FROM dbo.fnKaGetAustrittDatumCode(64832, NULL); --QE EPQ (KaEinsatzID IS NULL) -> AustrittDatum = 2007-03-09

           SELECT AustrittDatum, AustrittCode FROM dbo.fnKaGetAustrittDatumCode(121150, NULL); --Vermittlung BI/BIP (immer NULL, '')

           SELECT AustrittDatum, AustrittCode FROM dbo.fnKaGetAustrittDatumCode(89227, NULL); --Vermittlung SI (immer NULL, '')

           SELECT AustrittDatum, AustrittCode FROM dbo.fnKaGetAustrittDatumCode(63500, 6004); --Assistenz (DatumBis > AustrittDatum) -> AustrittDatum = 2007-10-19
           SELECT AustrittDatum, AustrittCode FROM dbo.fnKaGetAustrittDatumCode(63500, NULL); --Assistenz (KaEinsatzID IS NULL) -> AustrittDatum = 2007-01-19
           SELECT AustrittDatum, AustrittCode FROM dbo.fnKaGetAustrittDatumCode(63500, 5794); --Assistenz (DatumBis < AustrittDatum) -> AustrittDatum = NULL
           SELECT AustrittDatum, AustrittCode FROM dbo.fnKaGetAustrittDatumCode(63500, NULL); --Assistenz (KaEinsatzID IS NULL) -> AustrittDatum = 2007-10-19
=================================================================================================*/

CREATE FUNCTION dbo.fnKaGetAustrittDatumCode
(
  @FaLeistungID INT,
  @KaEinsatzID INT
)
RETURNS @Result TABLE
(
  AustrittDatum DATETIME,
  AustrittCode  INT,
  AustrittCodeText VARCHAR(200),
  AustrittCodeTextKurz VARCHAR(10),
  AustrittCodeTextLang VARCHAR(2000),
  AustrittDurchOrg BIT,
  AustrittDurchVers BIT,
  AustrittGegenseitig BIT,
  --
  UKCheckID INT NOT NULL UNIQUE -- used to have error on duplicate entries (only one row is valid)
)
AS
BEGIN
  -----------------------------------------------------------------------------
  -- get data
  -----------------------------------------------------------------------------
  ;WITH cteAbklaerung (FaLeistungID, Datum, AustrittDatum, KaAbklaerungGrundDossCode)
  AS
  (
    SELECT KAV.FaLeistungID,
           KAV.Datum,
           KAV.DatumIntegration,
           KAV.KaAbklaerungGrundDossCode
    FROM dbo.KaAbklaerungVertieft KAV  WITH (READUNCOMMITTED)
  )

  INSERT @Result (AustrittDatum, AustrittCode, AustrittCodeText, AustrittCodeTextKurz, AustrittCodeTextLang, 
                  AustrittDurchOrg, AustrittDurchVers, AustrittGegenseitig, UKCheckID)
    SELECT
      AustrittDatum = CASE FAL.FaProzessCode    
                        WHEN 701 THEN AKP.AustrittDatum   -- 'Abklärung' 
                        WHEN 702 THEN NULL                -- 'Inizio' -->TBD
                        WHEN 703 THEN KPZ.ProgEnde        -- 'Qualifikation Jugendliche'
                        WHEN 704 THEN                     -- 'QE'                                  
                          CASE FAL.KaEpqJob
                            WHEN 0 THEN JOB.AustrittDatum -- 'QE Jobtimum'
                            WHEN 1 THEN EPQ.AustrittDatum -- 'QE EPQ'
                          END
                        WHEN 705 THEN NULL                -- 'Vermittlung BI/BIP' (immer leer)
                        WHEN 706 THEN NULL                -- 'Vermittlung SI' (immer leer)
                        WHEN 707 THEN ASS.Austrittsdatum  -- 'Assistenz'
                        WHEN 708 THEN TRA.AustrittDat	  -- 'Transfer'
                        WHEN 709 THEN ESB.AustrittDatum   -- 'EAF Sozioberufliche Bilanz'
                        WHEN 710 THEN KSE.AustrittDatum   -- 'EAF Spezifische Ermittlung'
                        WHEN 711 THEN NULL                -- 'Jobtimal' (immer leer, analog 'Vermittlung SI')
                        ELSE NULL
                      END,                                                     
      --                                                                       
      AustrittCode = CASE FAL.FaProzessCode                                    
                       WHEN 701 THEN AKP.KaAbklaerungGrundDossCode            -- 'Abklärung'
                       WHEN 702 THEN NULL                                     -- 'Inizio'
                       WHEN 703 THEN KPZ.ProgEndeGrund                        -- 'QJ'
                       WHEN 704 THEN                                          -- 'QE'                                  
                         CASE FAL.KaEpqJob                        
                           WHEN 0 THEN JOB.AustrittCode                       -- 'QE Jobtimum'
                           WHEN 1 THEN EPQ.AustrittGrund                      -- 'QE EPQ'
                         END                                      
                       WHEN 705 THEN NULL                                     -- 'Vermittlung BI/BIP' 
                       WHEN 706 THEN NULL                                     -- 'Vermittlung SI'
                       WHEN 707 THEN ASS.KaAssistenzprojektAustrittsgrundCode -- 'Assistenz'
                       WHEN 708 THEN TRA.AustrittGrund						            -- 'Transfer'
                       WHEN 709 THEN ESB.KaEafAustrittsgrundCode              -- 'EAF Sozioberufliche Bilanz'
                       WHEN 710 THEN KSE.KaEafAustrittsgrundCode              -- 'EAF Spezifische Ermittlung'
                       WHEN 711 THEN NULL                                     -- 'Jobtimal', analog 'Vermittlung SI'
                       ELSE NULL
                     END,
      --
      AustrittCodeText = CASE FAL.FaProzessCode
                           WHEN 703 THEN                      -- 'QJ'
                             CASE KPZ.ProgEndeGrund
                               WHEN 1 THEN LOV1.[Text]
                               ELSE LOV2.[Text]
                             END
                           WHEN 704 THEN                      -- 'QE'
                             CASE FAL.KaEpqJob
                               WHEN 0 THEN LOV3.[Text]        -- 'QE Jobtimum'
                               WHEN 1 THEN                    -- 'QE EPQ'
                                 CASE EPQ.AustrittGrund
                                   WHEN 1 THEN LOV4.[Text]
                                   WHEN 2 THEN 'Abbruch'
                                   WHEN 3 THEN 'Abbruch'
                                   WHEN 4 THEN 'Abbruch'
                                   ELSE ''
                                 END
                             END
                           WHEN 707 THEN LOV5.[Text]          -- 'Assistenz'
                           WHEN 701 THEN LOV6.[Text]          -- 'Abklärung'
                           WHEN 708 THEN                      -- 'Transfer'
                             CASE TRA.AustrittGrund
                               WHEN 1 THEN LOV4.[Text]
                               WHEN 2 THEN 'Abbruch'
                               WHEN 3 THEN 'Abbruch'
                               WHEN 4 THEN 'Abbruch'
                               ELSE ''
                             END
                           WHEN 709 THEN
                             CASE ESB.KaEafAustrittsgrundCode
                               WHEN 1 THEN XEMB.[Text]
                               ELSE XEAB.[Text]
                             END
                           WHEN 710 THEN
                             CASE KSE.KaEafAustrittsgrundCode
                               WHEN 1 THEN YEMB.[Text]
                               ELSE YEAB.[Text]
                             END
                           ELSE ''
                         END,
      --
      AustrittCodeTextKurz = CASE FAL.FaProzessCode    
                               WHEN 701 THEN -- 'Abklärung'
                                 CASE 
                                   WHEN AKP.KaAbklaerungGrundDossCode BETWEEN 1 AND 26 THEN LOV6.Value2 
                                   ELSE ''
                                 END
                               WHEN 702 THEN ''
                               WHEN 703 THEN -- 'QJ'
                                 CASE KPZ.ProgEndeGrund 
                                   WHEN 1 THEN LOV1.Value2
                                   WHEN 2 THEN LOV2.Value2
                                   WHEN 3 THEN LOV2.Value2
                                   WHEN 4 THEN LOV2.Value2
                                   ELSE ''
                                 END
                               WHEN 704 THEN -- 'QE'
                                 CASE FAL.KaEpqJob 
                                   WHEN 0 THEN -- 'QE Jobtimum'
                                     CASE 
                                       WHEN JOB.AustrittCode BETWEEN 1 AND 4 THEN	LOV3.Value2
                                       ELSE ''
                                     END
                                   WHEN 1 THEN -- 'QE EPQ'
                                     CASE EPQ.AustrittGrund
                                       WHEN 1 THEN LOV4.Value2
                                       WHEN 2 THEN 'K'
                                       WHEN 3 THEN 'K'
                                       WHEN 4 THEN 'K'
                                       ELSE ''
                                     END 			
                                 END
                               WHEN 705 THEN '' -- 'Vermittlung BI/BIP' 
                               WHEN 706 THEN '' -- 'Vermittlung SI'
                               WHEN 707 THEN -- 'Assistenz'
                                 CASE 
                                   WHEN ASS.KaAssistenzprojektAustrittsgrundCode BETWEEN 1 AND 6 THEN LOV5.Value1
                                   ELSE ''
                                 END
                               WHEN 708 THEN
                                 CASE TRA.AustrittGrund
                                   WHEN 1 THEN LOV4.Value2
                                   WHEN 2 THEN 'K'
                                   WHEN 3 THEN 'K'
                                   WHEN 4 THEN 'K'
                                   ELSE ''
                                 END 		
                               WHEN 709 THEN
                                 CASE ESB.KaEafAustrittsgrundCode
                                   WHEN 1 THEN XEMB.Value2
                                   ELSE XEAB.Value2
                                 END
                               WHEN 710 THEN
                                 CASE KSE.KaEafAustrittsgrundCode
                                   WHEN 1 THEN YEMB.Value2
                                   ELSE YEAB.Value2
                                 END
                               WHEN 711 THEN '' -- 'Jobtimal', analog 'Vermittlung SI'
                               ELSE ''
                             END,
      --
      AustrittCodeTextLang = CASE FAL.FaProzessCode
                             WHEN 703 THEN LOV1.Value3 -- 'QJ'
                             WHEN 704 THEN -- 'QE'
                               CASE FAL.KaEpqJob
                                 WHEN 0 THEN -- 'QE Jobtimum'
                                   CASE JOB.AustrittCode
                                     WHEN 1 THEN LOV3.Value1
                                     WHEN 2 THEN LOV3.Value1
                                     WHEN 3 THEN LOV3.Value1
                                     ELSE ''
                                   END
                                 WHEN 1 THEN LOV4.Value1 -- 'QE EPQ'
                               END
                             WHEN 707 THEN -- 'Assistenz'
                               CASE ISNULL(ASS.KaAssistenzprojektAustrittsgrundCode, -1)
                                 WHEN 1 THEN LOV5.Value2		
                                 WHEN 2 THEN LOV5.Value2
                                 WHEN 3 THEN LOV5.Value2
                                 ELSE ''
                               END
                             WHEN 701 THEN -- 'Abklärung'
                               CASE AKP.KaAbklaerungGrundDossCode 
                                 WHEN 21 THEN LOV6.Value1
                                 WHEN 23 THEN LOV6.Value1
                                 WHEN 24 THEN LOV6.Value1
                                 ELSE ''
                               END
                             WHEN 708 THEN LOV4.Value1   -- Transfer
                             WHEN 709 THEN
                               CASE ESB.KaEafAustrittsgrundCode
                                 WHEN 1 THEN XEMB.Value1
                                 ELSE XEAB.Value1
                               END
                             WHEN 710 THEN
                               CASE KSE.KaEafAustrittsgrundCode
                                 WHEN 1 THEN YEMB.Value1
                                 ELSE YEAB.Value1
                               END
                             ELSE ''
                           END,
      --
      AustrittDurchOrg = CASE FAL.FaProzessCode
                           WHEN 701 THEN -- 'Abklärung'
                             CASE AKP.KaAbklaerungGrundDossCode
                               WHEN 25 THEN CONVERT(BIT, 1)
                               ELSE CONVERT(BIT, 0)
                             END
                           WHEN 703 THEN -- 'QJ'
                             CASE KPZ.ProgEndeGrund
                               WHEN 2 THEN CONVERT(BIT, 1)
                               ELSE CONVERT(BIT, 0)
                             END
                           WHEN 704 THEN -- 'QE'
                             CASE FAL.KaEpqJob
                               WHEN 0 THEN -- 'QE Jobtimum'
                                 CASE JOB.AustrittCode
                                   WHEN 4 THEN
                                     CASE JOB.AustrittGrund
                                       WHEN 1 THEN CONVERT(BIT, 1)
                                       ELSE CONVERT(BIT, 0)
                                     END
                                   ELSE CONVERT(BIT, 0)
                                 END
                               WHEN 1 THEN -- 'QE EPQ'
                                 CASE EPQ.AustrittGrund
                                   WHEN 2 THEN CONVERT(BIT, 1)
                                   ELSE CONVERT(BIT, 0)
                                 END
                             END
                           WHEN 707 THEN -- 'Assistenz'
                             CASE ISNULL(ASS.KaAssistenzprojektAustrittsgrundCode, -1)
                               WHEN 5 THEN CONVERT(BIT, 1)		
                               ELSE CONVERT(BIT, 0)
                             END
                           WHEN 708 THEN
                             CASE TRA.AustrittGrund -- Transfer 
                               WHEN 2 THEN CONVERT(BIT, 1)
                               ELSE CONVERT(BIT, 0)
                             END
                           WHEN 709 THEN
                             CASE ESB.KaEafAustrittsgrundCode
                               WHEN 2 THEN CONVERT(BIT, 1)
                               ELSE CONVERT(BIT, 0)
                             END
                           WHEN 710 THEN
                             CASE KSE.KaEafAustrittsgrundCode
                               WHEN 2 THEN CONVERT(BIT, 1)
                               ELSE CONVERT(BIT, 0)
                             END
                           ELSE ''
                         END,
      --
      AustrittDurchVers = CASE FAL.FaProzessCode
                            WHEN 701 THEN -- 'Abklärung'
                              CASE AKP.KaAbklaerungGrundDossCode
                                WHEN 22 THEN CONVERT(BIT, 1)
                                ELSE CONVERT(BIT, 0)
                              END
                            WHEN 703 THEN -- 'QJ'
                              CASE KPZ.ProgEndeGrund
                                WHEN 3 THEN CONVERT(BIT, 1)
                                ELSE CONVERT(BIT, 0)
                              END
                            WHEN 704 THEN -- 'QE'
                              CASE FAL.KaEpqJob
                                WHEN 0 THEN -- 'QE Jobtimum'
                                  CASE JOB.AustrittCode
                                    WHEN 4 THEN
                                      CASE JOB.AustrittGrund
                                        WHEN 2 THEN CONVERT(BIT, 1)
                                        ELSE CONVERT(BIT, 0)
                                      END
                                    ELSE CONVERT(BIT, 0)
                                  END
                                WHEN 1 THEN -- 'QE EPQ'
                                  CASE EPQ.AustrittGrund
                                    WHEN 3 THEN CONVERT(BIT, 1)
                                    ELSE CONVERT(BIT, 0)
                                  END
                              END
                            WHEN 707 THEN -- 'Assistenz'
                              CASE ISNULL(ASS.KaAssistenzprojektAustrittsgrundCode, -1)
                                WHEN 4 THEN CONVERT(BIT, 1)		
                                ELSE CONVERT(BIT, 0)
                              END
                            WHEN 708 THEN
                              CASE TRA.AustrittGrund -- Transfer
                                WHEN 3 THEN CONVERT(BIT, 1)
                                ELSE CONVERT(BIT, 0)
                                END
                            WHEN 709 THEN
                              CASE ESB.KaEafAustrittsgrundCode
                                WHEN 3 THEN CONVERT(BIT, 1)
                                ELSE CONVERT(BIT, 0)
                              END
                            WHEN 710 THEN
                              CASE KSE.KaEafAustrittsgrundCode
                                WHEN 3 THEN CONVERT(BIT, 1)
                                ELSE CONVERT(BIT, 0)
                              END
                            ELSE ''
                          END,
      --
      AustrittGegenseitig = CASE FAL.FaProzessCode
                            WHEN 701 THEN -- 'Abklärung'
                              CASE AKP.KaAbklaerungGrundDossCode
                                WHEN 26 THEN CONVERT(BIT, 1)
                                ELSE CONVERT(BIT, 0)
                              END
                            WHEN 703 THEN -- 'QJ'
                              CASE KPZ.ProgEndeGrund
                                WHEN 4 THEN CONVERT(BIT, 1)
                                ELSE CONVERT(BIT, 0)
                              END
                            WHEN 704 THEN -- 'QE'
                              CASE FAL.KaEpqJob
                                WHEN 0 THEN -- 'QE Jobtimum'
                                  CASE JOB.AustrittCode
                                    WHEN 4 THEN
                                      CASE JOB.AustrittGrund
                                        WHEN 3 THEN CONVERT(BIT, 1)
                                        ELSE CONVERT(BIT, 0)
                                      END
                                    ELSE CONVERT(BIT, 0)
                                  END
                                WHEN 1 THEN -- 'QE EPQ'
                                  CASE EPQ.AustrittGrund
                                    WHEN 4 THEN CONVERT(BIT, 1)
                                    ELSE CONVERT(BIT, 0)
                                  END
                              END
                            WHEN 707 THEN -- 'Assistenz'
                              CASE ISNULL(ASS.KaAssistenzprojektAustrittsgrundCode, -1)
                                WHEN 6 THEN CONVERT(BIT, 1)
                                ELSE CONVERT(BIT, 0)
                              END
                            WHEN 708 THEN -- Transfer
                              CASE TRA.AustrittGrund
                                WHEN 4 THEN CONVERT(BIT, 1)
                                ELSE CONVERT(BIT, 0)
                              END
                            WHEN 709 THEN
                              CASE ESB.KaEafAustrittsgrundCode
                                WHEN 4 THEN CONVERT(BIT, 1)
                                ELSE CONVERT(BIT, 0)
                              END
                            WHEN 710 THEN
                              CASE KSE.KaEafAustrittsgrundCode
                                WHEN 4 THEN CONVERT(BIT, 1)
                                ELSE CONVERT(BIT, 0)
                              END
                        ELSE ''
                          END,
      --
      UKCheckID = 1
      --
    FROM dbo.FaLeistung                        FAL  WITH (READUNCOMMITTED) 
      LEFT JOIN dbo.KaQJProzess                KPZ  WITH (READUNCOMMITTED) ON KPZ.FaLeistungID = FAL.FaLeistungID
      LEFT JOIN dbo.KaQEJobtimum               JOB  WITH (READUNCOMMITTED) ON JOB.FaLeistungID = FAL.FaLeistungID
      LEFT JOIN dbo.KaQEEPQ                    EPQ  WITH (READUNCOMMITTED) ON EPQ.FaLeistungID = FAL.FaLeistungID
      LEFT JOIN dbo.KaTransfer		             TRA  WITH (READUNCOMMITTED) ON TRA.FaLeistungID = FAL.FaLeistungID
      OUTER APPLY (SELECT TOP 1 AustrittDatum, KaAbklaerungGrundDossCode 
                   FROM cteAbklaerung
                   WHERE cteAbklaerung.FaLeistungID = FAL.FaLeistungID
                   ORDER BY Datum DESC)        AKP
      LEFT JOIN dbo.KaVermittlungBIBIP         VBI  WITH (READUNCOMMITTED) ON VBI.FaLeistungID = FAL.FaLeistungID
      LEFT JOIN dbo.KaVermittlungSI            VSI  WITH (READUNCOMMITTED) ON VSI.FaLeistungID = FAL.FaLeistungID
      LEFT JOIN dbo.KaAssistenz                ASS  WITH (READUNCOMMITTED) ON ASS.FaLeistungID = FAL.FaLeistungID
      LEFT JOIN dbo.KaEafSozioberuflicheBilanz ESB  WITH (READUNCOMMITTED) ON ESB.FaLeistungID = FAL.FaLeistungID
      LEFT JOIN dbo.KaEafSpezifischeErmittlung KSE  WITH (READUNCOMMITTED) ON KSE.FaLeistungID = FAL.FaLeistungID
      LEFT JOIN dbo.XLOVCode                   LOV1 WITH (READUNCOMMITTED) ON LOV1.LOVName = 'KaQjGrundProgEnde' 
                                                                          AND LOV1.Code = KPZ.ProgEndeCode 
      LEFT JOIN dbo.XLOVCode                   LOV2 WITH (READUNCOMMITTED) ON LOV2.LOVName = 'KaQjGrundProgAbbruch' 
                                                                          AND LOV2.Code = KPZ.AbbruchCode 
      LEFT JOIN dbo.XLOVCode                   LOV3 WITH (READUNCOMMITTED) ON LOV3.LOVName = 'KaQeJobtimumAustrittsgrund' 
                                                                          AND LOV3.Code = JOB.AustrittCode 
      LEFT JOIN dbo.XLOVCode                   LOV4 WITH (READUNCOMMITTED) ON LOV4.LOVName = 'KaQeAustrittGrund'
                                                                          AND (LOV4.Code = EPQ.AustrittCode
                                                                               OR LOV4.Code = TRA.AustrittCode)
      LEFT JOIN dbo.XLOVCode                   LOV5 WITH (READUNCOMMITTED) ON LOV5.LOVName = 'KaAssistenzprojektAustrittsgrund'
                                                                          AND LOV5.Code = ASS.KaAssistenzprojektAustrittsgrundCode
      LEFT JOIN dbo.XLOVCode                   LOV6 WITH (READUNCOMMITTED) ON LOV6.LOVName = 'KaAbklärungGrundDoss'
                                                                          AND LOV6.Code = AKP.KaAbklaerungGrundDossCode
      LEFT JOIN dbo.XLOVCode                   XEAG WITH (READUNCOMMITTED) ON XEAG.LOVName = 'KaEafAustrittsgrund'
                                                                          AND XEAG.Code = ESB.KaEafAustrittsgrundCode
      LEFT JOIN dbo.XLOVCode                   XEMB WITH (READUNCOMMITTED) ON XEMB.LOVName = 'KaEafAustrittsgrundMassnahmeBeendet'
                                                                          AND XEMB.Code = ESB.KaEafAustrittsgrundMassnahmeBeendetCode
      LEFT JOIN dbo.XLOVCode                   XEAB WITH (READUNCOMMITTED) ON XEAB.LOVName = 'KaEafAustrittsgrundAbbruchAnbieter'
                                                                          AND XEAB.Code = ESB.KaEafAustrittsgrundAbbruchAnbieterCode
      LEFT JOIN dbo.XLOVCode                   YEAG WITH (READUNCOMMITTED) ON YEAG.LOVName = 'KaEafAustrittsgrund'
                                                                          AND YEAG.Code = KSE.KaEafAustrittsgrundCode
      LEFT JOIN dbo.XLOVCode                   YEMB WITH (READUNCOMMITTED) ON YEMB.LOVName = 'KaEafAustrittsgrundMassnahmeBeendet'
                                                                          AND YEMB.Code = KSE.KaEafAustrittsgrundMassnahmeBeendetCode
      LEFT JOIN dbo.XLOVCode                   YEAB WITH (READUNCOMMITTED) ON YEAB.LOVName = 'KaEafAustrittsgrundAbbruchAnbieter'
                                                                          AND YEAB.Code = KSE.KaEafAustrittsgrundAbbruchAnbieterCode
    WHERE FAL.FaLeistungID = @FaLeistungID;
  
  -----------------------------------------------------------------------------
  -- if a KaEinsatzID is specified, we have to check if the calculated AustrittDatum
  -- is relevant for the specified KaEinsatz (if there are multiple KaEinsatz
  -- records in a given FaLeistung, it is possible that some are not 'terminated'
  -- by this AustrittDatum, since they naturally ended earlier).
  DELETE RES
  FROM @Result RES 
    INNER JOIN KaEinsatz KAE ON KAE.KaEinsatzID = @KaEinsatzID
  WHERE KAE.DatumBis < RES.AustrittDatum;

  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN;
END;
GO