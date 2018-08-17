SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKaGetStatistikGEF
GO
/*===============================================================================================
  $Revision: 12 $
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
CREATE PROCEDURE dbo.spKaGetStatistikGEF
(
  @datVon DATETIME,
  @datBis DATETIME,
  @auswAngebot INT
)
AS BEGIN
  SET NOCOUNT ON;

  SELECT
    [BaPersonID$]      = PRS.BaPersonID,
    [Nr]               = EIP.KaEinsatzplatzID,
    [Einsatzplatz]     = EIP.Bezeichnung,
    [Einsatzbeginn]    = EIN.EinsatzVon,
    [Einsatzende]      = EIN.Abschluss,
    [GeplEinsatzende]  = CASE WHEN EIP.KaProgrammCode = 5 THEN NULL -- bei SI Einsatz bleibt das Feld leer 
                              ELSE EIN.EinsatzBis
                         END,
    [GrundEinsatzende] = CASE EIP.KaProgrammCode
                           WHEN 3 THEN dbo.fnLOVText('KaVermittlungBIStellenendeGrund', EIN.BIAbschlussGrundCode)
                           WHEN 4 THEN dbo.fnLOVText('KaVermittlungBIPEinsatzendeGrund', EIN.BIPAbschlussGrundCode)
                           WHEN 5 THEN dbo.fnLOVText('KaVermittlungSiEinsatzendeGrund', EIN.SIAbschlussGrundCode)
                         END,
    [Arbeitspensum]    = EIN.Arbeitspensum,
    [EAZ]              = EIN.BIFinanzierungsgradEAZ,
    [Betrieb]          = BET.BetriebName,
    [Betriebstyp]      = dbo.fnLOVText('KaBetriebCharakter', BET.CharakterCode),
    [Angebotstyp]      = dbo.fnLOVText('KaVermittlungProgramm', EIP.KaProgrammCode),
    [NameSTES]         = PRS.Name,
    [VornameSTES]      = PRS.Vorname,
    [Nationalitaet]    = PRS.Nationalitaet,
    [Geschlecht]       = dbo.fnLOVText('Geschlecht', PRS.GeschlechtCode),
    [Ausbildung]       = dbo.fnLOVText('KaVermittlBiBerufsbil', KA.KaVermittlBiBerufsbilCode),
    [Berufserfahrung]  = dbo.fnLOVText('KaVermittlBiBerufserf', KA.KaVermittlBiBerufserfCode),
    [Alter]            = PRS.[Alter],
    [Coach]            = USR.NameVorname,
    [Zuweiser]         = (SELECT TOP 1 
                            (SELECT Zuweiser = CASE
                                                 WHEN VBI.ZuweiserID < 0 THEN ISNULL(XOU.ItemName, '')
                                                 ELSE ISNULL(ORG.[Name], '') 
                                               END
                             FROM dbo.KaVermittlungBIBIP          VBI WITH (READUNCOMMITTED)
                               LEFT JOIN dbo.BaInstitutionKontakt OKO WITH (READUNCOMMITTED) ON OKO.BaInstitutionKontaktID = VBI.ZuweiserID
                               LEFT JOIN dbo.BaInstitution        ORG WITH (READUNCOMMITTED) ON ORG.BaInstitutionID = OKO.BaInstitutionID
                               LEFT JOIN dbo.XUser                XUR WITH (READUNCOMMITTED) ON XUR.UserID = -VBI.ZuweiserID
                               LEFT JOIN dbo.XOrgUnit_User        OUU WITH (READUNCOMMITTED) ON OUU.UserID = -VBI.ZuweiserID
                                                                                            AND (OUU.OrgUnitMemberCode = 1 OR OUU.OrgUnitMemberCode = 2)
                               LEFT JOIN dbo.XOrgUnit             XOU WITH (READUNCOMMITTED) ON XOU.OrgUnitID = OUU.OrgUnitID
                             WHERE VBI.FaLeistungID = VOR.FaLeistungID

                             UNION ALL

                             SELECT Zuweiser = CASE
                                                 WHEN VSI.ZuweiserID < 0 THEN ISNULL(XOU.ItemName, '')
                                                 ELSE ISNULL(ORG.[Name], '')
                                               END
                             FROM dbo.KaVermittlungSI             VSI WITH (READUNCOMMITTED)
                               LEFT JOIN dbo.BaInstitutionKontakt OKO WITH (READUNCOMMITTED) ON OKO.BaInstitutionKontaktID = VSI.ZuweiserID
                               LEFT JOIN dbo.BaInstitution        ORG WITH (READUNCOMMITTED) ON ORG.BaInstitutionID = OKO.BaInstitutionID
                               LEFT JOIN dbo.XUser                XUR WITH (READUNCOMMITTED) ON XUR.UserID = -VSI.ZuweiserID
                               LEFT JOIN dbo.XOrgUnit_User        OUU WITH (READUNCOMMITTED) ON OUU.UserID = -VSI.ZuweiserID
                                                                                            AND (OUU.OrgUnitMemberCode = 1 OR OUU.OrgUnitMemberCode = 2)
                               LEFT JOIN dbo.XOrgUnit             XOU WITH (READUNCOMMITTED) ON XOU.OrgUnitID = OUU.OrgUnitID
                             WHERE VSI.FaLeistungID = VOR.FaLeistungID)),
    [Einsatzmonate] = CONVERT(FLOAT, DATEDIFF(DAY, CASE
                                                     WHEN @datVon > EIN.EinsatzVon THEN @datVon
                                                     ELSE EIN.EinsatzVon
                                                   END,
                                                   CASE
                                                     WHEN @datBis < ISNULL(EIN.Abschluss, '99991231') THEN @datBis 
                                                     ELSE ISNULL(EIN.Abschluss, @datBis)
                                                   END) + 1) / 30.0,
    [Massnahmetage] = CONVERT(FLOAT, DATEDIFF(DAY, CASE
                                                     WHEN @datVon > EIN.EinsatzVon THEN @datVon
                                                     ELSE EIN.EinsatzVon
                                                   END,
                                                   CASE
                                                     WHEN @datBis < ISNULL(EIN.Abschluss, '99991231') THEN @datBis 
                                                     ELSE ISNULL(EIN.Abschluss, @datBis)
                                                   END) + 1) / 30.0 * 21.7
  FROM dbo.KaVermittlungVorschlag       VOR WITH (READUNCOMMITTED)
    INNER JOIN dbo.KaVermittlungEinsatz EIN WITH (READUNCOMMITTED) ON EIN.KaVermittlungVorschlagID = VOR.KaVermittlungVorschlagID
                                                                  AND EIN.EinsatzVon IS NOT NULL
    LEFT JOIN dbo.KaEinsatzplatz        EIP WITH (READUNCOMMITTED) ON EIP.KaEinsatzplatzID = VOR.KaEinsatzplatzID
    LEFT JOIN dbo.FaLeistung            LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = VOR.FaLeistungID
    LEFT JOIN dbo.vwPerson              PRS ON PRS.BaPersonID = LEI.BaPersonID
    LEFT JOIN dbo.KaBetrieb             BET WITH (READUNCOMMITTED) ON BET.KaBetriebID = EIP.KaBetriebID
    LEFT JOIN (SELECT KA.KaVermittlBiBerufsbilCode, 
                      KA.KaVermittlBiBerufserfCode,
                      LEI2.BaPersonID
               FROM dbo.KaAusbildung KA
               INNER JOIN dbo.FaLeistung LEI2 ON LEI2.FaLeistungID = KA.FaLeistungID
               WHERE LEI2.ModulID = 7
                 AND LEI2.FaProzessCode = 700) KA ON KA.BaPersonID = PRS.BaPersonID
    LEFT JOIN dbo.vwUser                USR ON USR.UserID = LEI.UserID
  WHERE EIP.KaProgrammCode IN (3,4,5)
    AND (Abschluss IS NULL OR Abschluss >= @datVon)
    AND (EinsatzVon IS NULL OR EinsatzVon <= @datBis)
    AND (@auswAngebot = 0 OR EIP.KaProgrammCode = @auswAngebot);
END;
GO