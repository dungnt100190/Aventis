SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmGvGesuch;
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken-View für die Gesuchverwaltung
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwTmGvGesuch;
=================================================================================================*/

CREATE VIEW dbo.vwTmGvGesuch
AS
SELECT
  -----------------------------------------------------------------------------
  -- GvGesuch
  -----------------------------------------------------------------------------
  GvGesuchID              = GGE.GvGesuchID,
  BaPersonID              = GGE.BaPersonID,
  UserID                  = GGE.XUserID_Autor,
  GesuchsDatum            = GGE.GesuchsDatum,
  Gesuchsgrund            = GGE.Gesuchsgrund,
  BetragBewilligt         = GGE.BetragBewilligt,
  BewilligtAm             = GGE.BewilligtAm,
  BegruendungMitFmt       = GGE.Begruendung, -- RTF
  BegruendungOhneFmt      = GGE.Begruendung, -- NORTF
  Bemerkung               = GGE.Bemerkung,
  BewilligungBetragKS1    = GGE.BetragBewilligtKompetenzStufe1,
  BewilligungDatumKS1     = GGE.DatumBewilligtKompetenzStufe1,
  BewilligungBemerkungKS1 = GGE.BemerkungBewilligungKompetenzStufe1,
  BewilligungBetragKS2    = GGE.BetragBewilligtKompetenzStufe2,
  BewilligungDatumKS2     = GGE.DatumBewilligtKompetenzStufe2,
  BewilligungBemerkungKS2 = GGE.BemerkungBewilligungKompetenzStufe2,

  -----------------------------------------------------------------------------
  -- Bewilligung
  -----------------------------------------------------------------------------
  BewilligtVonName      = USRB.FirstName,
  BewilligtVonVorname   = USRB.LastName,
  BewilligtVonAbteilung = USRB.OrgEinheitName,

  -----------------------------------------------------------------------------
  -- Abschluss (externer Fonds)
  -----------------------------------------------------------------------------
  AbschlussDatum  = GGE.AbschlussDatum,
  AbschlussgrundD = dbo.fnGetLOVMLText('GvAbschlussgrund', GGE.GvAbschlussgrundCode, 1),
  AbschlussgrundF = dbo.fnGetLOVMLText('GvAbschlussgrund', GGE.GvAbschlussgrundCode, 2),
  AbschlussgrundI = dbo.fnGetLOVMLText('GvAbschlussgrund', GGE.GvAbschlussgrundCode, 3),

  -----------------------------------------------------------------------------
  -- Berechnet
  -----------------------------------------------------------------------------
  BetragBeantragt     = BBT.BetragBeantragt,
  BetragEigenleistung = ISNULL((SELECT SUM(CASE APO.GvAntragPositionTypCode
                                             WHEN 1 THEN APO.Betrag
                                             WHEN 2 THEN -APO.Betrag
                                             WHEN 3 THEN -APO.Betrag
                                           END)
                                FROM dbo.GvAntragPosition APO WITH (READUNCOMMITTED)
                                WHERE APO.GvGesuchID = GGE.GvGesuchID), $0),
  TotalAusFLBFond     = ISNULL((SELECT SUM(GGE1.BetragBewilligt)
                                FROM dbo.GvGesuch GGE1 WITH (READUNCOMMITTED)
                                WHERE GGE1.BaPersonID = GGE.BaPersonID
                                  AND YEAR(GGE1.GesuchsDatum) = YEAR(GETDATE())), $0),
  Kuerzung            = dbo.fnMax(BBT.BetragBeantragt - GGE.BetragBewilligt, $0),

  -----------------------------------------------------------------------------
  -- User
  -----------------------------------------------------------------------------
  Mitarbeiter  = USR.NameVorname,
  KGS          = KGS.ItemName,
  Kostenstelle = KST.ItemName,
  
  -----------------------------------------------------------------------------
  -- Person
  -----------------------------------------------------------------------------
  Klient = PRS.NameVorname,

  -----------------------------------------------------------------------------
  -- Fonds
  -----------------------------------------------------------------------------
  FondsNameKurz   = GFD.NameKurz,
  FondsNameLang   = GFD.NameLang,
  FondsBemerkungD = dbo.fnGetMLTextByDefault(GFD.BemerkungTID, 1, GFD.Bemerkung),
  FondsBemerkungF = dbo.fnGetMLTextByDefault(GFD.BemerkungTID, 2, GFD.Bemerkung),
  FondsBemerkungI = dbo.fnGetMLTextByDefault(GFD.BemerkungTID, 3, GFD.Bemerkung),
  FondsTypD       = dbo.fnGetLOVMLText('GvFondsTyp', GFD.GvFondsTypCode, 1),
  FondsTypF       = dbo.fnGetLOVMLText('GvFondsTyp', GFD.GvFondsTypCode, 2),
  FondsTypI       = dbo.fnGetLOVMLText('GvFondsTyp', GFD.GvFondsTypCode, 3),

  -----------------------------------------------------------------------------
  -- Verteiler
  -----------------------------------------------------------------------------
  Verteiler       = CASE 
                      WHEN AKS.Ort IS NULL THEN 'Pro Infirmis, '+  KST.ItemName + ', ' + USR.VornameName
                      ELSE AKS.BeantragendeStelle + ', ' + AKS.Kontaktperson + ', ' + AKS.Ort
                    END,
  VerteilerMehrzeilig = CASE 
                         WHEN AKS.Ort IS NULL THEN 'Pro Infirmis, '+  KST.ItemName + CHAR(13) + CHAR(10) + USR.VornameName
                         ELSE ISNULL(AKS.BeantragendeStelle + CHAR(13) + CHAR(10),'') +
                              ISNULL(AKS.Zusatz + CHAR(13) + CHAR(10), '') +
                              ISNULL(AKS.Kontaktperson + CHAR(13) + CHAR(10), '') +
                              ISNULL(AKS.Strasse + ISNULL(' ' + AKS.HausNr, '') + CHAR(13) + CHAR(10), '') +
                              ISNULL(dbo.fnBaGetPostfachText(NULL, AKS.Postfach, AKS.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                              ISNULL(AKS.PLZ + ' ', '') + ISNULL(AKS.Ort + CHAR(13) + CHAR(10), '')+
                              ISNULL(AKS.EMail, '')
                        END

FROM dbo.GvGesuch                    GGE  WITH (READUNCOMMITTED)
  INNER JOIN dbo.vwUser              USR  WITH (READUNCOMMITTED) ON USR.UserID = GGE.XUserID_Autor
  INNER JOIN dbo.vwPersonSimple      PRS  WITH (READUNCOMMITTED) ON PRS.BaPersonID = GGE.BaPersonID
  INNER JOIN dbo.GvFonds             GFD  WITH (READUNCOMMITTED) ON GFD.GvFondsID = GGE.GvFondsID
  OUTER APPLY (SELECT BetragBeantragt     = ISNULL((SELECT SUM(APO.Betrag)
                                                    FROM dbo.GvAntragPosition APO WITH (READUNCOMMITTED)
                                                    WHERE APO.GvGesuchID = GGE.GvGesuchID
                                                      AND APO.GvAntragPositionTypCode = 2), $0)) BBT
  -- Benutzer der zuletzt das Gesuch bewilligt hat (letzer Eintrag mit Status "Prüfung abschliessen")
  LEFT JOIN dbo.GvBewilligung        GBE  WITH (READUNCOMMITTED) ON GBE.GvGesuchID = GGE.GvGesuchID
                                                                AND GBE.GvBewilligungCode = 5 -- Prüfung abschliessen
                                                                AND NOT EXISTS(SELECT TOP 1 1
                                                                               FROM dbo.GvBewilligung GBE2 WITH (READUNCOMMITTED)
                                                                               WHERE GBE2.GvGesuchID = GBE.GvGesuchID
                                                                                 AND GvBewilligungCode NOT IN (7, 8, 9) -- Zahlungen ausführen, Auflagen erledigen, Gesuch abschliessen
                                                                                 AND GBE2.Created > GBE.Created)
  LEFT JOIN dbo.vwUser               USRB WITH (READUNCOMMITTED) ON USRB.UserID = GBE.UserID
  LEFT JOIN dbo.XOrgUnit             KST  WITH (READUNCOMMITTED) ON KST.OrgUnitID = CONVERT(INT, dbo.fnOrgUnitOfUser(GGE.XUserID_Autor, 1))
  LEFT JOIN dbo.XOrgUnit             KGS  WITH (READUNCOMMITTED) ON KGS.Mandantennummer = dbo.fnOrgUnitOfUserMandantenNr(GGE.XUserID_Autor)
  LEFT JOIN dbo.GvAbklaerendeStelle  AKS  WITH (READUNCOMMITTED) ON AKS.GvGesuchID = GGE.GvGesuchID
;
GO
