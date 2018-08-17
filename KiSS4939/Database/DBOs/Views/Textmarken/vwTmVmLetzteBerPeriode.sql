SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmVmLetzteBerPeriode;
GO

/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken um die Daten der Berichtsperiode der letzten Massnahme einer Person zu bekommen

  TEST:    SELECT TOP 10 * FROM dbo.vwTmVmLetzteBerPeriode;
=================================================================================================*/

CREATE VIEW dbo.vwTmVmLetzteBerPeriode
AS
  SELECT 
    PRS.BaPersonID,

    -- Massnahme
    Von        = CONVERT(VARCHAR(10), BER.DatumVon, 104),
    Bis        = CONVERT(VARCHAR(10), BER.DatumBis, 104),
    Verfuegung = CONVERT(VARCHAR(10), BER.DatumVerfuegungKESB, 104),
    Versand    = CONVERT(VARCHAR(10), BER.DatumVersand, 104),
    Art        = dbo.fnLOVMLText('KesMassnahmeBerichtsart', BER.KesMassnahmeBerichtsartCode, 1)

    
  FROM dbo.BaPerson                          PRS WITH (READUNCOMMITTED)
    INNER JOIN dbo.KesMassnahme              MAS WITH (READUNCOMMITTED) ON MAS.KesMassnahmeID = (SELECT TOP 1 MAS2.KesMassnahmeID
                                                                                                 FROM dbo.KesMassnahme MAS2 WITH (READUNCOMMITTED)
                                                                                                   INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = MAS2.FaLeistungID
                                                                                                 WHERE LEI.BaPersonID = PRS.BaPersonID
                                                                                                 ORDER BY MAS2.DatumVon DESC)
    LEFT  JOIN dbo.KesMassnahmeBericht       BER WITH (READUNCOMMITTED) ON BER.KesMassnahmeID = MAS.KesMassnahmeID
                                                                       AND BER.KesMassnahmeBerichtID = (SELECT TOP 1 BER2.KesMassnahmeBerichtID
                                                                                                        FROM dbo.KesMassnahmeBericht BER2 WITH (READUNCOMMITTED)
                                                                                                        WHERE BER2.KesMassnahmeID = BER.KesMassnahmeID
                                                                                                        ORDER BY BER2.DatumBis DESC)
GO


