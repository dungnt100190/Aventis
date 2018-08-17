SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmPerson
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwTmPerson.sql $
  $Author: Rstahel $
  $Modtime: 23.04.10 18:37 $
  $Revision: 6 $
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
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwTmPerson.sql $
 * 
 * 6     23.04.10 18:37 Rstahel
 * FrauHerrnVornameName wieder hinzugefügt (sozstu wollte dies so).
 * 
 * 5     26.01.10 11:45 Mmarghitola
 * #5616: unnötige Joins entfernt
 * 
 * 4     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 3     6.08.09 14:16 Spsota
 * Views aktualisiert für Tabelle BaLand
 * 
 * 2     10.03.09 18:03 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/
/*
===================================================================================================
Author:      sozheo
Create date: ??.??.????
Description: Textmarke für betroffene Person
===================================================================================================
ZUM KONTROLLIEREN:
-----------------
select * from vwTmPerson
===================================================================================================
History:
--------
??.??.???? : ????? : neu erstellt
30.07.2008 : sozheo : Wohnsitzadresse soll in jedem Fall nur ein Datensatz zurückliefern
01.08.2008 : sozheo : BaPerson.Bemerkung hinzugefügt
===================================================================================================
*/
CREATE VIEW [dbo].[vwTmPerson]
AS

SELECT PRS.BaPersonID,
  PersonenNr = PRS.BaPersonID,
  Titel = PRS.Titel,
  Name = PRS.Name,
  [FrühererName] = PRS.FruehererName,
  Vorname = PRS.Vorname,
  Vorname2 = PRS.Vorname2,
  Geburtsdatum = CONVERT(varchar,PRS.Geburtsdatum,104),
  Sterbedatum = CONVERT(varchar,PRS.Sterbedatum,104),
  AHVNummer = PRS.AHVNummer,
  Versichertennummer = PRS.Versichertennummer,
  ZIPNr = PRS.ZIPNr,
  KantonRefNr = PRS.KantonaleReferenznummer,
  SKZNr = NULL, --PRS.SKZNr,
  ZivilstandDatum = CONVERT(varchar,PRS.ZivilstandDatum ,104),
  Aufenthaltsstatus = LOVAS.Text,
  AufenthaltGueltigBis = CONVERT(varchar,PRS.AuslaenderStatusGueltigBis,104),
  TelefonP = PRS.Telefon_P,
  TelefonG = PRS.Telefon_G,
  MobilTel1 = PRS.MobilTel1,
  MobilTel2 = PRS.MobilTel2,
  EMail = PRS.EMail,
  -- Original: BemerkungNORTF = PRS.Bemerkung, -- bgr: Nicht gut da der RTF Algorithmus der Textmarken Fehler erzeugt, wenn kein RTF da ist
  BemerkungNORTF = CASE
    WHEN PRS.Bemerkung IS NOT NULL AND PRS.Bemerkung NOT like '{\rtf%' THEN '{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}\viewkind4\uc1\pard\fs20 ' + replace(CONVERT(varchar(8000),PRS.Bemerkung), char(13)+char(10), '\par ') + '}'
    ELSE PRS.Bemerkung
  END,
  Sprache = LOVSP.Text,
  EinwohnerregisterAktiv,
  DeutschKenntnis = LOVDK.Text,
  WichtigerHinweis = LOVWH.Text,

  FrauHerrVornameName = CASE PRS.GeschlechtCode
    WHEN 1 THEN 'Herr '
    WHEN 2 THEN 'Frau '
    ELSE ''
  END + IsNull(PRS.Vorname + ' ', '') + PRS.Name,
  FrauHerrnVornameName = CASE PRS.GeschlechtCode
    WHEN 1 THEN 'Herrn '
    WHEN 2 THEN 'Frau '
    ELSE ''
  END + IsNull(PRS.Vorname + ' ', '') + PRS.Name,
  GeehrteFrauHerrVornameName = CASE PRS.GeschlechtCode
    WHEN 1 THEN 'Sehr geehrter Herr '
    WHEN 2 THEN 'Sehr geehrte Frau '
    ELSE ''
  END + PRS.Vorname + ' ' + PRS.Name,

 AufenthaltsadresseEinzeilig = (
   PRS.Vorname + ' ' + PRS.Name + ', ' +
   IsNull(ADR3.Zusatz + ', ','') +
   IsNull(ADR3.Strasse + IsNull(' ' + ADR3.HausNr,'') + ', ','') +
   IsNull(ADR3.PLZ + ' ','') + ADR3.Ort ),
 AufenthaltsortAdresseEinzOhneName = (
   IsNull(ADR3.Zusatz + ', ','') +
   IsNull(ADR3.Strasse + IsNull(' ' + ADR3.HausNr,'') + ', ','') +
   IsNull(ADR3.PLZ + ' ','') + ADR3.Ort ),
 AufenthaltsortAdresseMehrzeilig = (
   PRS.Vorname + ' ' + PRS.Name + char(13) + char(10) +
   IsNull(ADR3.Zusatz + char(13) + char(10),'') +
   IsNull(ADR3.Strasse + IsNull(' ' + ADR3.HausNr,'') + char(13) + char(10),'') +
   IsNull(ADR3.PLZ + ' ','') + ADR3.Ort ),
 AufenthaltsortAdresseMehrzOhneName = (
   IsNull(ADR3.Zusatz + char(13) + char(10),'') +
   IsNull(ADR3.Strasse + IsNull(' ' + ADR3.HausNr,'') + char(13) + char(10),'') +
   IsNull(ADR3.PLZ + ' ','') + ADR3.Ort ),
 AufenthaltsortStrasseNr = ADR3.Strasse + IsNull(' ' + ADR3.HausNr,''),
 AufenthaltsortPLZOrt    = IsNull(ADR3.PLZ + ' ','') + ADR3.Ort,

 AufenthaltWohnortAdrEinzeilig = (
   PRS.Vorname + ' ' + PRS.Name + ', ' +
   CASE WHEN ADR3.BaAdresseID IS NULL
    THEN IsNull(ADR1.Zusatz + ', ','') +
         IsNull(ADR1.Strasse + IsNull(' ' + ADR1.HausNr,'') + ', ','') +
         IsNull(ADR1.PLZ + ' ','') + ADR1.Ort
    ELSE IsNull(ADR3.Zusatz + ', ','') +
         IsNull(ADR3.Strasse + IsNull(' ' + ADR3.HausNr,'') + ', ','') +
         IsNull(ADR3.PLZ + ' ','') + ADR3.Ort
    END ),
 AufenthaltWohnortAdrEinzOhneName = (
   CASE WHEN ADR3.BaAdresseID IS NULL
    THEN IsNull(ADR1.Zusatz + ', ','') +
         IsNull(ADR1.Strasse + IsNull(' ' + ADR1.HausNr,'') + ', ','') +
         IsNull(ADR1.PLZ + ' ','') + ADR1.Ort
    ELSE IsNull(ADR3.Zusatz + ', ','') +
         IsNull(ADR3.Strasse + IsNull(' ' + ADR3.HausNr,'') + ', ','') +
         IsNull(ADR3.PLZ + ' ','') + ADR3.Ort
    END ),
 AufenthaltWohnortAdrMehrzeilig = (
   PRS.Vorname + ' ' + PRS.Name + char(13) + char(10) +
   CASE WHEN ADR3.BaAdresseID IS NULL
       THEN IsNull(ADR1.Zusatz + char(13) + char(10),'') +
            IsNull(ADR1.Strasse + IsNull(' ' + ADR1.HausNr,'') + char(13) + char(10),'') +
            IsNull(ADR1.PLZ + ' ','') + ADR1.Ort
       ELSE IsNull(ADR3.Zusatz + char(13) + char(10),'') +
            IsNull(ADR3.Strasse + IsNull(' ' + ADR3.HausNr,'') + char(13) + char(10),'') +
            IsNull(ADR3.PLZ + ' ','') + ADR3.Ort
       END ),
 AufenthaltWohnortAdrMehrzOhneName = (
   CASE WHEN ADR3.BaAdresseID IS NULL
       THEN IsNull(ADR1.Zusatz + char(13) + char(10),'') +
            IsNull(ADR1.Strasse + IsNull(' ' + ADR1.HausNr,'') + char(13) + char(10),'') +
            IsNull(ADR1.PLZ + ' ','') + ADR1.Ort
       ELSE IsNull(ADR3.Zusatz + char(13) + char(10),'') +
            IsNull(ADR3.Strasse + IsNull(' ' + ADR3.HausNr,'') + char(13) + char(10),'') +
            IsNull(ADR3.PLZ + ' ','') + ADR3.Ort
       END ),
 AufenthaltWohnsitzStrasseNr =
   CASE WHEN ADR3.BaAdresseID IS NULL
       THEN ADR1.Strasse + IsNull(' ' + ADR1.HausNr,'')
       ELSE ADR3.Strasse + IsNull(' ' + ADR3.HausNr,'')
       END,
 AufenthaltWohnsitzPLZOrt =
   CASE WHEN ADR3.BaAdresseID IS NULL
       THEN IsNull(ADR1.PLZ + ' ','') + ADR1.Ort
       ELSE IsNull(ADR3.PLZ + ' ','') + ADR3.Ort
       END,

 WohnsitzAdresseEinzeilig = (
   PRS.Vorname + ' ' + PRS.Name + ', ' +
   IsNull(ADR1.Zusatz + ', ','') +
   IsNull(ADR1.Strasse + IsNull(' ' + ADR1.HausNr,'') + ', ','') +
   IsNull(ADR1.PLZ + ' ','') + ADR1.Ort ),
 WohnsitzAdresseEinzOhneKomma = (
   PRS.Vorname + ' ' + PRS.Name + ' ' +
   IsNull(ADR1.Strasse + IsNull(' ' + ADR1.HausNr,'') + ' ','') +
   IsNull(ADR1.PLZ + ' ','') + ADR1.Ort ),
 WohnsitzAdresseEinzOhneName = (
   IsNull(ADR1.Zusatz + ', ','') +
   IsNull(ADR1.Strasse + IsNull(' ' + ADR1.HausNr,'') + ', ','') +
   IsNull(ADR1.PLZ + ' ','') + ADR1.Ort ),
 WohnsitzAdresseMehrzeilig = (
   PRS.Vorname + ' ' + PRS.Name + char(13) + char(10) +
   IsNull(ADR1.Zusatz + char(13) + char(10),'') +
   IsNull(ADR1.Strasse + IsNull(' ' + ADR1.HausNr,'') + char(13) + char(10),'') +
   IsNull(ADR1.PLZ + ' ','') + ADR1.Ort ),
 WohnsitzAdresseMehrzOhneName = (
   IsNull(ADR1.Zusatz + char(13) + char(10),'') +
   IsNull(ADR1.Strasse + IsNull(' ' + ADR1.HausNr,'') + char(13) + char(10),'') +
   IsNull(ADR1.PLZ + ' ','') + ADR1.Ort ),
 WohnsitzStrasseNr = ADR1.Strasse + IsNull(' ' + ADR1.HausNr,''),
 WohnsitzPLZOrt = IsNull(ADR1.PLZ + ' ','') + ADR1.Ort,

 Beruf = CASE PRS.GeschlechtCode WHEN 1 THEN BERB.BezeichnungM WHEN 2 THEN BERB.BezeichnungW ELSE BERB.Beruf END,
 BerufLetzteTaetigkeit = CASE WHEN NOT PRS.BerufCode IS NULL
    -- Letzte Taetigkeit, wenn diese erfasst wurde ...
    THEN CASE PRS.GeschlechtCode WHEN 1 THEN BERB.BezeichnungM WHEN 2 THEN BERB.BezeichnungW ELSE BERB.Beruf END
    -- ... sonst den erlernten Beruf ausgeben
    ELSE CASE PRS.GeschlechtCode WHEN 1 THEN BERE.BezeichnungM WHEN 2 THEN BERE.BezeichnungW ELSE BERE.Beruf END
  END,
 ErlernterBeruf = CASE PRS.GeschlechtCode WHEN 1 THEN BERE.BezeichnungM WHEN 2 THEN BERE.BezeichnungW ELSE BERE.Beruf END,
 Erwerbssituation = dbo.fnLOVText('BaErwerbssituation', PRS.ErwerbssituationCode),
 SpezFaehigkeiten = PRS.ArbeitSpezFaehigkeiten,

 Geschlecht = LOVG.Text,
 Heimatort = GDE.Name,
 HeimatortNationalitaet = IsNull(GDE.Name,NAT.Text),
 Religion = LOVK.Text,
 KVGAdresseEinzOhneName = (
   IsNull(ADRK.Zusatz + ', ','') +
   IsNull(ADRK.Strasse + IsNull(' ' + ADRK.HausNr,'') + ', ','') +
   IsNull(ADRK.PLZ + ' ','') + ADRK.Ort ),
 KVGMitgliedNr = KVG.MitgliedNr,
 KVGName = INSK.Name,
 NameVorname = PRS.[Name] + IsNull(', ' + PRS.Vorname, ''),
 NameVornameOhneKomma = PRS.[Name] + IsNull(' ' + PRS.Vorname, ''),
 Nationalitaet = CASE WHEN NAT.Text IS NULL AND GDE.Name IS NOT NULL  -- Nationalität leer + Heimatort erfasst => 'Schweiz'
                 THEN 'Schweiz'
                 ELSE NAT.Text
                 END,
 Schulbildung = LOVS.Text,
 PLZHeimatort = IsNull(CAST( GDE.PLZ AS varchar ) + ' ','') + GDE.Name,
 VermieterAdresseEinzOhneName = (
   IsNull(ADRM.Zusatz + ', ','') +
   IsNull(ADRM.Strasse + IsNull(' ' + ADRM.HausNr,'') + ', ','') +
   IsNull(ADRM.PLZ + ' ','') + ADRM.Ort ),
 VermieterName = INSM.Name,
 VornameName = IsNull(PRS.Vorname + ' ','') + PRS.[Name],
 VVGAdresseEinzOhneName = (
   IsNull(ADRV.Zusatz + ', ','') +
   IsNull(ADRV.Strasse + IsNull(' ' + ADRV.HausNr,'') + ', ','') +
   IsNull(ADRV.PLZ + ' ','') + ADRV.Ort ),
 VVGMitgliedNr = VVG.MitgliedNr,
 VVGName = INSV.Name,
 WegzugDatum,-- = PRS.WegzugDatum
 WegzugOrt,
 WegzugPLZ,
 Wohnsituation = LOVW.Text,
 Wohnungsgroesse = LOVGR.Text,
 Zivilstand = LOVZ.Text,
 ZuzugDatum = PRS.ZuzugGdeDatum,
 ZuzugOrt   = PRS.ZuzugGdeOrt,
 ZuzugPLZ   = PRS.ZuzugGdePLZ,
 ZuzugStZhDat = PRS.ZuzugGdeDatum,

 InCHSeit = CONVERT(varchar, PRS.InCHSeit, 104),
 InCHSeitGeburt = CONVERT(bit, IsNull(PRS.InCHSeitGeburt, 0)),
 BFFNr = PRS.BFFNummer

FROM         dbo.BaPerson PRS WITH (READUNCOMMITTED)
-- 30.07.2008 : sozheo : Wohnsitzadresse soll in jedem Fall nur ein Datensatz zurückliefern
--    LEFT  JOIN BaAdresse             ADR1 ON ADR1.BaPersonID = PRS.BaPersonID AND ADR1.AdresseCode = 1 -- Wohnsitz
--                                  AND GetDate() BETWEEN IsNull(ADR1.DatumVon, GetDate()) AND IsNull(ADR1.DatumBis, GetDate())
    LEFT  JOIN dbo.BaAdresse             ADR1 WITH (READUNCOMMITTED) ON ADR1.BaAdresseID = (
      SELECT TOP 1 BaAdresseID FROM dbo.BaAdresse  WITH (READUNCOMMITTED)
      WHERE BaPersonID = PRS.BaPersonID AND AdresseCode = 1 /* Wohnsitz */
        AND GetDate() BETWEEN IsNull(DatumVon, GetDate()) AND IsNull(DatumBis, GetDate())
      ORDER BY DatumVon DESC )

--    LEFT  JOIN BaAdresse             ADR3 ON ADR3.BaPersonID = PRS.BaPersonID AND ADR3.AdresseCode = 2 -- Aufenthalt
--                                  AND GetDate() BETWEEN IsNull(ADR3.DatumVon, GetDate()) AND IsNull(ADR3.DatumBis, GetDate())
    LEFT  JOIN BaAdresse             ADR3 ON ADR3.BaAdresseID = (
      SELECT TOP 1 BaAdresseID FROM dbo.BaAdresse  WITH (READUNCOMMITTED)
      WHERE BaPersonID = PRS.BaPersonID AND AdresseCode = 2 /* Aufenthalt */
        AND GetDate() BETWEEN IsNull(DatumVon, GetDate()) AND IsNull(DatumBis, GetDate())
      ORDER BY DatumVon DESC )
    LEFT OUTER JOIN dbo.BaInstitution         INS3 WITH (READUNCOMMITTED) ON INS3.BaInstitutionID = ADR3.BaInstitutionID
    LEFT OUTER JOIN dbo.BaBeruf               BERB WITH (READUNCOMMITTED) ON BERB.BaBerufID = PRS.BerufCode
    LEFT OUTER JOIN dbo.BaBeruf               BERE WITH (READUNCOMMITTED) ON BERE.BaBerufID = PRS.ErlernterBerufCode
    LEFT OUTER JOIN dbo.XLOVCode              LOVG WITH (READUNCOMMITTED) ON LOVG.LOVName = 'BaGeschlecht' AND LOVG.Code = PRS.GeschlechtCode
    LEFT OUTER JOIN dbo.XLOVCode              LOVK WITH (READUNCOMMITTED) ON LOVK.LOVName = 'BaReligion'   AND LOVK.Code = PRS.ReligionCode
    LEFT OUTER JOIN dbo.BaGemeinde            GDE  WITH (READUNCOMMITTED) ON GDE.BaGemeindeID = PRS.HeimatgemeindeCode
    LEFT OUTER JOIN dbo.BaKrankenversicherung KVG  WITH (READUNCOMMITTED) ON KVG.BaKrankenversicherungID IN ( SELECT TOP 1 BaKrankenversicherungID FROM BaKrankenversicherung WHERE BaPersonID = PRS.BaPersonID AND GesetzesGrundlageCode = 1 /* KVG */ AND GetDate() BETWEEN IsNull(DatumVon, GetDate()) AND IsNull(DatumBis, GetDate()) ORDER BY DatumVon DESC )
    LEFT OUTER JOIN dbo.BaInstitution         INSK WITH (READUNCOMMITTED) ON KVG.BaInstitutionID = INSK.BaInstitutionID
    LEFT OUTER JOIN dbo.BaAdresse             ADRK WITH (READUNCOMMITTED) ON ADRK.BaInstitutionID = KVG.BaInstitutionID
    LEFT OUTER JOIN dbo.BaKrankenversicherung VVG  WITH (READUNCOMMITTED) ON VVG.BaKrankenversicherungID IN ( SELECT TOP 1 BaKrankenversicherungID FROM BaKrankenversicherung WHERE BaPersonID = PRS.BaPersonID AND GesetzesGrundlageCode = 2 /* VVG */ AND GetDate() BETWEEN IsNull(DatumVon, GetDate()) AND IsNull(DatumBis, GetDate()) ORDER BY DatumVon DESC )
    LEFT OUTER JOIN dbo.BaInstitution         INSV WITH (READUNCOMMITTED) ON VVG.BaInstitutionID  = INSV.BaInstitutionID
    LEFT OUTER JOIN dbo.BaAdresse             ADRV WITH (READUNCOMMITTED) ON ADRV.BaInstitutionID = VVG.BaInstitutionID
    LEFT OUTER JOIN dbo.BaLand								NAT  WITH (READUNCOMMITTED) ON NAT.BaLandID = PRS.NationalitaetCode
    LEFT OUTER JOIN dbo.XLOVCode              LOVS WITH (READUNCOMMITTED) ON LOVS.LOVName = 'BaAusbildungstyp'    AND LOVS.Code = PRS.HoechsteAusbildungCode
    --LEFT  JOIN BaWohnsituationPerson BWP  ON BWP.BaPersonID = PRS.BaPersonID
    LEFT OUTER JOIN dbo.BaWohnsituation       BWO  WITH (READUNCOMMITTED) ON BWO.BaWohnsituationID IN (SELECT TOP 1 BWO.BaWohnsituationID
                                                                       FROM dbo.BaWohnsituationPerson  BWR WITH (READUNCOMMITTED)
                                                                         LEFT OUTER JOIN dbo.BaWohnsituation BWO WITH (READUNCOMMITTED) ON BWO.BaWohnsituationID = BWR.BaWohnsituationID
                                                                       WHERE BWR.BaPersonID = PRS.BaPersonID AND GetDate() BETWEEN IsNull(BWO.DatumVon, GetDate()) AND IsNull(BWO.DatumBis, GetDate()) )

    LEFT OUTER JOIN dbo.BaInstitution         INSM  WITH (READUNCOMMITTED) ON INSM.BaInstitutionID = BWO.BaInstitutionID
    LEFT OUTER JOIN dbo.BaAdresse             ADRM  WITH (READUNCOMMITTED) ON ADRM.BaInstitutionID = INSM.BaInstitutionID
    LEFT OUTER JOIN dbo.XLOVCode              LOVW  WITH (READUNCOMMITTED) ON LOVW.LOVName   = 'BaWohnstatus'             AND LOVW.Code = BWO.WohnsituationCode
    LEFT OUTER JOIN dbo.XLOVCode              LOVGR WITH (READUNCOMMITTED) ON LOVGR.LOVName  = 'BaWohnungsgroesse'        AND LOVGR.Code = BWO.WohnungsgroesseCode
    LEFT OUTER JOIN dbo.XLOVCode              LOVZ  WITH (READUNCOMMITTED) ON LOVZ.LOVName   = 'BaZivilstand'             AND LOVZ.Code = PRS.ZivilstandCode
    LEFT OUTER JOIN dbo.XLOVCode              LOVAS WITH (READUNCOMMITTED) ON LOVAS.LOVName  = 'BaAufenthaltsstatus'      AND LOVAS.Code = PRS.AuslaenderStatusCode
    LEFT OUTER JOIN dbo.XLOVCode              LOVSP WITH (READUNCOMMITTED) ON LOVSP.LOVName  = 'BaPersonSprache'          AND LOVSP.Code = PRS.SprachCode
    LEFT OUTER JOIN dbo.XLOVCode              LOVDK WITH (READUNCOMMITTED) ON LOVDK.LOVName  = 'BaDeutschkenntnis'        AND LOVDK.Code = PRS.DeutschVerstehenCode
    LEFT OUTER JOIN dbo.XLOVCode              LOVWH WITH (READUNCOMMITTED) ON LOVWH.LOVName  = 'BaPersonWichtigerHinweis' AND LOVWH.Code = PRS.WichtigerHinweisCode

GO
GRANT SELECT ON [dbo].[vwTmPerson] TO [tools_access]