SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER OFF;
GO
EXECUTE dbo.spDropObject vwTmAbrechnungDetail;
GO

/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE VIEW dbo.vwTmAbrechnungDetail
AS

SELECT 
  WhAbrechnungID,
  WhDetailblattID,
  DatumVon,
  DatumBis,
  KlientName,
  Grund,
  TotalAusgabenKlient,
  TotalAusgabenDritte,
  TotalEinnahmenKlient,
  TotalEinnahmenSD,
  TotalEinnahmenSDInklErgaenzungen,
  TotalVerrechnungRueckerstattung,
  TotalZahlungenKlient,
  TotalAusgaben,
  SaldoZugunstenKlientEffektiv = SaldoZugunstenKlient,
  TotalKorrekturen
FROM (SELECT
        DET.WhAbrechnungID,
        DET.WhDetailblattID,
        DET.DatumVon,
        DET.DatumBis,
        KlientName = PER.NameVorname,
        DET.Grund,
        TotalAusgabenKlient = Replace(CONVERT(varchar(20), DET.TotalAusgabenKlient, 1), ',', ''''),
        TotalAusgabenDritte  = Replace(CONVERT(varchar(20), DET.TotalAusgabenDritte, 1), ',', ''''),
        TotalEinnahmenKlient  = Replace(CONVERT(varchar(20), DET.TotalEinnahmenKlient, 1), ',', ''''),
        TotalEinnahmenSD  = Replace(CONVERT(varchar(20), DET.TotalEinnahmenSD, 1), ',', ''''),
        TotalEinnahmenSDInklErgaenzungen  = Replace(CONVERT(varchar(20), DET.TotalEinnahmenSD + ISNULL(ERG.TotalErgaenzungen, 0), 1), ',', ''''),
        TotalVerrechnungRueckerstattung  = Replace(CONVERT(varchar(20), DET.TotalVerrechnungRueckerstattung, 1), ',', ''''),
        TotalZahlungenKlient = Replace(CONVERT(varchar(20), DET.TotalAusgabenKlient - DET.TotalVerrechnungRueckerstattung - DET.TotalEinnahmenKlient, 1), ',', ''''),
        TotalAusgaben = Replace(CONVERT(varchar(20), DET.TotalAusgabenKlient - DET.TotalVerrechnungRueckerstattung - DET.TotalEinnahmenKlient + DET.TotalAusgabenDritte, 1), ',', ''''),
        TotalKorrekturen = ISNULL(ERG.TotalErgaenzungen, 0),
        SaldoZugunstenKlient = DET.TotalEinnahmenSD - (DET.TotalAusgabenKlient - DET.TotalVerrechnungRueckerstattung - DET.TotalEinnahmenKlient + DET.TotalAusgabenDritte) + ISNULL(ERG.TotalErgaenzungen, 0)
      FROM dbo.WhDetailblatt          DET WITH (READUNCOMMITTED)
        INNER JOIN dbo.WhAbrechnung   ABR WITH (READUNCOMMITTED) ON ABR.WhAbrechnungID = DET.WhAbrechnungID
        INNER JOIN dbo.FaFall         FAL WITH (READUNCOMMITTED) ON FAL.FaFallID = ABR.FaFallID
        LEFT  JOIN dbo.vwPersonSimple PER WITH (READUNCOMMITTED) ON PER.BaPersonID = FAL.BaPersonID
        LEFT  JOIN (SELECT WhDetailblattID, 
                           TotalErgaenzungen = SUM(Betrag)
                    FROM dbo.vwTmAbrechnungErgaenzungen
                    GROUP BY WhDetailblattID) ERG ON DET.WhDetailblattID = ERG.WhDetailblattID
      ) SubAbrechnungDetail;
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Effektiver Saldo zu Gunsten des Klients, d.h. Negativbetrag wird ausgewiesen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwTmAbrechnungDetail', @level2type=N'COLUMN',@level2name=N'SaldoZugunstenKlientEffektiv'
GO