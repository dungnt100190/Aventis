SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmVmMandBericht;
GO

/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken für alle Felder der Tabelle VmMandBericht, Maske CtlVmMandBericht.
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwTmVmMandBericht;
=================================================================================================*/

CREATE VIEW dbo.vwTmVmMandBericht
AS
SELECT VmMandBerichtID            = BER.VmMandBerichtID,
       FaLeistungID               = BER.FaLeistungID,
       VmBerichtID                = BER.VmBerichtID,
       GrundMassnahme             = LOVGM.Text,
       Berichtstitel              = LOVBT.Text,
       BerichtDatumVon            = CONVERT(VARCHAR(10), BER.BerichtDatumVon, 104),
       BerichtDatumBis            = CONVERT(VARCHAR(10), BER.BerichtDatumBis, 104),
       GrundMassnahmeText         = BER.GrundMassnahmeText,
       AuftragZielsetzungText     = BER.AuftragZielsetzungText,
       ZielErreicht               = LOVZE.Text,
       VIP                        = BER.VeraenderungInPeriode,            -- Beschränkung Word auf 20 Zeichen für Checkboxen
       VeraenderungInPeriodCBText = CASE 
                                      WHEN BER.VeraenderungInPeriode = 0 THEN 'Nein'
                                      ELSE 'Ja'
                                    END,
       Begruendung                = BER.Begruendung,
       NeueZieleText              = BER.NeueZieleText,
       Wohnen                     = LOVWO.Text,
       Gesundheit                 = LOVGE.Text,
       Verhalten                  = LOVVH.Text,
       Taetigkeit                 = LOVTA.Text,
       FS                         = BER.FamiliaereSituation,              -- Beschränkung Word auf 20 Zeichen für Checkboxen
       FamiliaereSituationCBText  = CASE 
                                      WHEN BER.FamiliaereSituation = 0 THEN 'Nein'
                                      ELSE 'Ja'
                                    END,
       SK                         = BER.SozialeKompetenzen,               -- Beschränkung Word auf 20 Zeichen für Checkboxen
       SozialeKompetenzenCBText   = CASE 
                                      WHEN BER.SozialeKompetenzen = 0 THEN 'Nein'
                                      ELSE 'Ja'
                                    END,
       FZ                         = BER.Freizeit,                         -- Beschränkung Word auf 20 Zeichen für Checkboxen
       FreizeitCBText             = CASE 
                                      WHEN BER.Freizeit = 0 THEN 'Nein'
                                      ELSE 'Ja'
                                    END,
       RES                        = BER.Resourcen,
       ResourcenCBText            = CASE
                                      WHEN BER.Resourcen = 0 THEN 'Nein'
                                      ELSE 'Ja'
                                    END,
       WohnenText                 = BER.WohnenText,
       GesundheitText             = BER.GesundheitText,
       VerhaltenText              = BER.VerhaltenText,
       TaetigkeitText             = BER.TaetigkeitText,
       FamSituationText           = BER.FamSituationText,
       SozialeKompetenzenText     = BER.SozialeKompetenzenText,
       FreizeitText               = BER.FreizeitText,
       BesondereRessourcenText    = BER.BesondereRessourcenText,
       HandlungenText             = BER.HandlungenText,
       BesSchwierigkeitenText     = BER.BesondereSchwierigkeitenText,
       KL                         = BER.Klient,                           -- Beschränkung Word auf 20 Zeichen für Checkboxen
       KlientCBText               = CASE 
                                      WHEN BER.Klient = 0 THEN 'Nein'
                                      ELSE 'Ja'
                                    END,
       DR                         = BER.Dritte,                           -- Beschränkung Word auf 20 Zeichen für Checkboxen
       DritteCBText               = CASE 
                                      WHEN BER.Dritte = 0 THEN 'Nein'
                                      ELSE 'Ja'
                                    END,
       I                          = BER.Institutionen,                    -- Beschränkung Word auf 20 Zeichen für Checkboxen
       InstitutionenCBText        = CASE 
                                      WHEN BER.Institutionen = 0 THEN 'Nein'
                                      ELSE 'Ja'
                                    END,
       KlientText                 = BER.KlientText,
       DritteText                 = BER.DritteText,
       InstitutionenText          = BER.InstitutionenText,
       MCSCMandat                 = LOVMCMD.Text,
       BerichtBelastAngMCSCAdmin  = LOVMCAD.Text,
       BelastungMandatText        = BER.BelastungMandatText,
       BelastungAdminText         = BER.BelastungAdminText,
       EinnahmenAngaben           = dbo.fnLOVTextListe('VmEinnahmenAngaben', BER.VmEinnahmenAngabenCodes),
       EA                         = BER.VmEinnahmenAngabenCodes,          -- Beschränkung Word auf 20 Zeichen für Checkboxen
       BerichtVersicherungen      = dbo.fnLOVTextListe('VmBerichtVersicherungen', BER.VmBerichtVersicherungenCodes),
       BV                         = BER.VmBerichtVersicherungenCodes,     -- Beschränkung Word auf 20 Zeichen für Checkboxen
       BerichtBesondereAngaben    = dbo.fnLOVTextListe('VmBerichtBesondereAngaben', BER.VmBerichtBesondereAngabenCodes),
       BBA                        = BER.VmBerichtBesondereAngabenCodes,   -- Beschränkung Word auf 20 Zeichen für Checkboxen
       EinnahmenBemerkungen       = BER.EinnahmenBemerkungen,
       VersicherungenBemerkungen  = BER.VersicherungenBemerkungen,
       BesondereAngabenBem        = BER.BesondereAngabenBemerkungen,
       AU                         = BER.AbrechnungUnterschrieben,         -- Beschränkung Word auf 20 Zeichen für Checkboxen
       AbrechnungUnterschrieben   = CASE 
                                      WHEN BER.AbrechnungUnterschrieben = 0 THEN 'Nein'
                                      ELSE 'Ja'
                                    END,
       PT                         = BER.PassationTeilnahme,               -- Beschränkung Word auf 20 Zeichen für Checkboxen
       PassationTeilnahmeCBText   = CASE 
                                      WHEN BER.PassationTeilnahme = 0 THEN 'Nein'
                                      ELSE 'Ja'
                                    END,
       PassationBemerkung         = BER.PassationBemerkung,
       AntragBericht              = LOVBA.Text,
       AntragBegruendung          = BER.AntragBegruendung,
       ErstellungDatum            = CONVERT(VARCHAR(10), BER.ErstellungDatum, 104),
       BerichtBeilagen            = LOVBB.Text,
       BsDatum                    = CONVERT(VARCHAR(10), BER.BsDatum, 104),
       BelegeZurueckRevision      = CONVERT(VARCHAR(10), BER.BelegeZurueckRevision, 104),
       ZurueckVomBS               = CONVERT(VARCHAR(10), BER.ZurueckVomBS, 104),
       Berichtsart                = LOVAR.Text,
       Autor                      = USR.VornameName
FROM dbo.VmMandBericht   BER     WITH (READUNCOMMITTED)
  LEFT JOIN dbo.vwUser   USR     WITH (READUNCOMMITTED) ON USR.UserID = BER.UserID
  LEFT JOIN dbo.XLovCode LOVGM   WITH (READUNCOMMITTED) ON LOVGM.LOVName = 'VmGrundMassnahme'
                                                       AND LOVGM.Code = BER.VmGrundMassnahmeCode
  LEFT JOIN dbo.XLovCode LOVBT   WITH (READUNCOMMITTED) ON LOVBT.LOVName = 'VmBerichtstitel'
                                                       AND LOVBT.Code = BER.VmBerichtstitelCode
  LEFT JOIN dbo.XLovCode LOVZE   WITH (READUNCOMMITTED) ON LOVZE.LOVName = 'VmZielErreicht'
                                                       AND LOVZE.Code = BER.VmZielErreichtCode
  LEFT JOIN dbo.XLovCode LOVWO   WITH (READUNCOMMITTED) ON LOVWO.LOVName = 'VmWohnen'
                                                       AND LOVWO.Code = BER.VmWohnenCode
  LEFT JOIN dbo.XLovCode LOVGE   WITH (READUNCOMMITTED) ON LOVGE.LOVName = 'VmGesundheit'
                                                       AND LOVGE.Code = BER.VmGesundheitCode
  LEFT JOIN dbo.XLovCode LOVVH   WITH (READUNCOMMITTED) ON LOVVH.LOVName = 'VmVerhalten'
                                                       AND LOVVH.Code = BER.VmVerhaltenCode
  LEFT JOIN dbo.XLovCode LOVTA   WITH (READUNCOMMITTED) ON LOVTA.LOVName = 'VmTätigkeit'
                                                       AND LOVTA.Code = BER.VmTaetigkeitCode
  LEFT JOIN dbo.XLovCode LOVMCMD WITH (READUNCOMMITTED) ON LOVMCMD.LOVName = 'VmBerichtBelastungsangabeMCSC'
                                                       AND LOVMCMD.Code = BER.VmBerichtBelastungsangabeMCSCCode_Mandat
  LEFT JOIN dbo.XLovCode LOVMCAD WITH (READUNCOMMITTED) ON LOVMCAD.LOVName = 'VmBerichtBelastungsangabeMCSC'
                                                       AND LOVMCAD.Code = BER.VmBerichtBelastungsangabeMCSCCode_Admin
  LEFT JOIN dbo.XLovCode LOVBA   WITH (READUNCOMMITTED) ON LOVBA.LOVName = 'VmAntragBericht'
                                                       AND LOVBA.Code = BER.VmAntragBerichtCode
  LEFT JOIN dbo.XLovCode LOVBB   WITH (READUNCOMMITTED) ON LOVBB.LOVName = 'VmMfBerichtBeilagen'
                                                       AND LOVBB.Code = BER.VmMfBerichtBeilagenCode
  LEFT JOIN dbo.XLovCode LOVAR   WITH (READUNCOMMITTED) ON LOVAR.LOVName = 'VmBerichtsart'
                                                       AND LOVAR.Code = BER.VmBerichtsartCode;
GO
