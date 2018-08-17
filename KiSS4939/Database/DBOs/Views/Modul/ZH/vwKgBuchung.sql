SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwKgBuchung
GO

CREATE VIEW [dbo].[vwKgBuchung] AS
SELECT
  BUC.KgBuchungID,
  BUC.KgPeriodeID,
  BUC.KgPositionID,
  BUC.KgBuchungTypCode,
  BUC.KgAusgleichStatusCode,
  BUC.KgZahlungseingangID,
  BUC.CodeVorlage,
  BUC.BelegNr,
  BUC.BelegNrPos,
  BUC.BuchungsDatum,
  BUC.SollKtoNr,
  BUC.HabenKtoNr,
  BUC.Betrag,
  BUC.BetragFW,
  BUC.FbWaehrungID,
  BUC.Text,
  BUC.ValutaDatum,
  BUC.BarbezugDatum,
  BUC.TransferDatum,
  BUC.KgBuchungStatusCode,
  BUC.UserIDKasse,
  BUC.BaZahlungswegID,
  BUC.BaInstitutionID,
  BUC.EinzahlungsscheinCode,
  BUC.KgAuszahlungsArtCode,
  BUC.BaBankID,
  BUC.BankKontoNummer,
  BUC.IBANNummer,
  BUC.PostKontoNummer,
  BUC.ESRTeilnehmer,
  BUC.ESRReferenznummer,
  BUC.BeguenstigtName,
  BUC.BeguenstigtName2,
  BUC.BeguenstigtStrasse,
  BUC.BeguenstigtHausNr,
  BUC.BeguenstigtPostfach,
  BUC.BeguenstigtOrt,
  BUC.BeguenstigtPLZ,
  BUC.BeguenstigtLandCode,
  BUC.MitteilungZeile1,
  BUC.MitteilungZeile2,
  BUC.MitteilungZeile3,
  BUC.MitteilungZeile4,
  BUC.ErstelltUserID,
  BUC.ErstelltDatum,
  BUC.MutiertUserID,
  BUC.MutiertDatum,
  BUC.KgBuchungTS,
  BUC.PscdFehlermeldung,
  BUC.PscdBelegNr,
  BUC.StorniertKgBuchungID,
  BUC.NeubuchungVonKgBuchungID,
  FaLeistungID             = LEI.FaLeistungID,
  SollKtoName              = KTOS.KontoName,
  SollKtoNrName            = KTOS.KontoNr + ' ' + KTOS.KontoName,
  SollKontoartCode         = KTOS.KgKontoartCode ,
  HabenKtoName             = KTOH.KontoName ,
  HabenKtoNrName           = KTOH.KontoNr + ' ' + KTOH.KontoName,
  HabenKontoartCode        = KTOH.KgKontoartCode ,
  Mandant                  = PRS.NameVorname,
  BaPersonID               = LEI.BaPersonID,
  Adresse                  = PRS.Wohnsitz,
  MTLogon                  = USR1.LogonName,
  MTName                   = IsNull(USR1.LastName,'') + IsNull(', ' + USR1.FirstName,''),
  ErfLogon                 = USR2.LogonName ,
  ErfName                  = IsNull(USR2.LastName,'') + IsNull(', ' + USR2.FirstName,'') ,
  StatusText               = STA.Text,
  PeriodeVon               = PER.PeriodeVon,
  PeriodeBis               = PER.PeriodeBis,
  PeriodeAbgeschlossenBis  = PER.AbgeschlossenBis,
  KgPeriodeStatusCode      = PER.KgPeriodeStatusCode,
  KgPeriodeStatusText      = PST.Text,
  FallBaPersonID           = FAL.BaPersonID
FROM   KgBuchung BUC
       INNER JOIN KgKonto          KTOS ON KTOS.KgPeriodeID = BUC.KgPeriodeID AND
                                           KTOS.KontoNr = BUC.SollKtoNr
       INNER JOIN KgKonto          KTOH ON KTOH.KgPeriodeID = BUC.KgPeriodeID AND
                                           KTOH.KontoNr = BUC.HabenKtoNr
       INNER JOIN KgPeriode        PER  ON PER.KgPeriodeID = BUC.KgPeriodeID
       INNER JOIN FaLeistung       LEI  ON LEI.FaLeistungID = PER.FaLeistungID
       INNER JOIN vwPerson2         PRS  ON PRS.BaPersonID = LEI.BaPersonID
       INNER JOIN FaFall           FAL  ON FAL.FaFallID = LEI.FaFallID
       LEFT  JOIN XUser            USR1 ON USR1.UserID = LEI.UserID
       LEFT  JOIN XUser            USR2 ON USR2.UserID = BUC.ErstelltUserID
       LEFT  JOIN XLOVCode         STA  ON STA.LOVName = 'KgBuchungStatus' AND
                                           STA.Code = BUC.KgBuchungStatusCode
       LEFT  JOIN XLOVCode         PST  ON PST.LOVName = 'KgPeriodeStatus' AND
                                           PST.Code = PER.KgPeriodeStatusCode
