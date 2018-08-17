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
  SUMMARY: Textmarken f�r alle Felder der Tabelle VmMandBericht, Maske CtlVmMandBericht.
  -
  RETURNS: <Beschreibung des zur�ckgegebenen Results>
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
       VIP                        = BER.VeraenderungInPeriode,            -- Beschr�nkung Word auf 20 Zeichen f�r Checkboxen
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
       FS                         = BER.FamiliaereSituation,              -- Beschr�nkung Word auf 20 Zeichen f�r Checkboxen
       FamiliaereSituationCBText  = CASE 
                                      WHEN BER.FamiliaereSituation = 0 THEN 'Nein'
                                      ELSE 'Ja'
                                    END,
       SK                         = BER.SozialeKompetenzen,               -- Beschr�nkung Word auf 20 Zeichen f�r Checkboxen
       SozialeKompetenzenCBText   = CASE 
                                      WHEN BER.SozialeKompetenzen = 0 THEN 'Nein'
                                      ELSE 'Ja'
                                    END,
       FZ                         = BER.Freizeit,                         -- Beschr�nkung Word auf 20 Zeichen f�r Checkboxen
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
       KL                         = BER.Klient,                           -- Beschr�nkung Word auf 20 Zeichen f�r Checkboxen
       KlientCBText               = CASE 
                                      WHEN BER.Klient = 0 THEN 'Nein'
                                      ELSE 'Ja'
                                    END,
       DR                         = BER.Dritte,                           -- Beschr�nkung Word auf 20 Zeichen f�r Checkboxen
       DritteCBText               = CASE 
                                      WHEN BER.Dritte = 0 THEN 'Nein'
                                      ELSE 'Ja'
                                    END,
       I                          = BER.Institutionen,                    -- Beschr�nkung Word auf 20 Zeichen f�r Checkboxen
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
       EA                         = BER.VmEinnahmenAngabenCodes,          -- Beschr�nkung Word auf 20 Zeichen f�r Checkboxen
       BerichtVersicherungen      = dbo.fnLOVTextListe('VmBerichtVersicherungen', BER.VmBerichtVersicherungenCodes),
       BV                         = BER.VmBerichtVersicherungenCodes,     -- Beschr�nkung Word auf 20 Zeichen f�r Checkboxen
       BerichtBesondereAngaben    = dbo.fnLOVTextListe('VmBerichtBesondereAngaben', BER.VmBerichtBesondereAngabenCodes),
       BBA                        = BER.VmBerichtBesondereAngabenCodes,   -- Beschr�nkung Word auf 20 Zeichen f�r Checkboxen
       EinnahmenBemerkungen       = BER.EinnahmenBemerkungen,
       VersicherungenBemerkungen  = BER.VersicherungenBemerkungen,
       BesondereAngabenBem        = BER.BesondereAngabenBemerkungen,
       AU                         = BER.AbrechnungUnterschrieben,         -- Beschr�nkung Word auf 20 Zeichen f�r Checkboxen
       AbrechnungUnterschrieben   = CASE 
                                      WHEN BER.AbrechnungUnterschrieben = 0 THEN 'Nein'
                                      ELSE 'Ja'
                                    END,
       PT                         = BER.PassationTeilnahme,               -- Beschr�nkung Word auf 20 Zeichen f�r Checkboxen
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
  LEFT JOIN dbo.XLovCode LOVTA   WITH (READUNCOMMITTED) ON LOVTA.LOVName = 'VmT�tigkeit'
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
