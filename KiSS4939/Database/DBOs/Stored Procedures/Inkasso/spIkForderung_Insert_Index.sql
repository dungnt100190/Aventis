SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spIkForderung_Insert_Index;
GO
/*===============================================================================================
  $Revision: 11 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @IkForderungID: IkForderungID
    @NewDate:       Per Datum
  -
  RETURNS: .
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spIkForderung_Insert_Index
(
  @IkForderungID INT,
  @NewDate DATETIME
)
AS
BEGIN
  -----------------------------------------------------------------------------
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  -----------------------------------------------------------------------------
  SET NOCOUNT ON;

  -----------------------------------------------------------------------------
  -- go on
  -----------------------------------------------------------------------------
  DECLARE 
    @IkRechtstitelID INT,
    @BaPersonID INT,
    @Betrag_Basis MONEY,
    @IkForderungPeriodischCode INT,
    @NovIndex MONEY,
    @NovIndex_old MONEY,
    @Basisindex MONEY,
    @Betrag_Berechnet MONEY,
    @Rundung INT,
    @IkIndexTypCode INT,
    @DatumGueltigBis DATETIME,
    @TeuerungsEinsprache BIT,
    @ErrorMsg VARCHAR(500),
    @IkAnpassungsRegelCode INT;
  
  -----------------------------------------------------------------------------
  -- Kontrollen der Parameter
  -----------------------------------------------------------------------------
  SELECT 
    @IkRechtstitelID           = F.IkRechtstitelID,
    @BaPersonID                = F.BaPersonID,
    @Betrag_Basis              = F.Betrag,
    @IkForderungPeriodischCode = F.IkForderungPeriodischCode,
    @DatumGueltigBis           = F.DatumGueltigBis,
    @Basisindex                = RT.IndexStandPunkte,
    @Rundung                   = RT.IkIndexRundenCode,
    @IkIndexTypCode            = RT.IkIndexTypCode,
    @TeuerungsEinsprache       = CONVERT(BIT, CASE WHEN F.Teuerungseinsprache = 1 THEN 1 ELSE 0 END),
    @IkAnpassungsRegelCode     = F.IkAnpassungsRegelCode
  FROM dbo.IkForderung         F  WITH (READUNCOMMITTED)
    INNER JOIN dbo.IkRechtstitel RT WITH (READUNCOMMITTED) ON RT.IkRechtstitelID = F.IkRechtstitelID
  WHERE F.IkForderungID = @IkForderungID;

  IF (@@ROWCOUNT = 0 OR @Betrag_Basis IS NULL OR @IkForderungID IS NULL OR @IkRechtstitelID IS NULL) 
  BEGIN
    SET @ErrorMsg = 'Der Aufruf-Parameter @IkForderungID (' + CONVERT(VARCHAR(15), ISNULL(@IkForderungID, 0)) + 
                    ') ist ungültig (spIkForderung_Insert_Index).';
    
    RAISERROR (@ErrorMsg, 18, 1);
    RETURN -1;
  END;

  IF (ISNULL(@Betrag_Basis, 0) = 0)
  BEGIN
    -- Wenn eine 0 Forderung erwischt wurde, nichts machen
    RETURN 2;
  END;

  IF (@DatumGueltigBis IS NOT NULL AND @DatumGueltigBis < @NewDate) 
  BEGIN
    -- Wenn die alte Forderung eine Bis-Datum hat, dann kontrollieren,
    -- dass DatumAb und DatumBis bei der neuen Forderung konsistent sind
    RETURN 5;
  END;

  -- ---------------------------------------------------
  -- Neuer index holen
  -- ---------------------------------------------------
  SET @NovIndex = dbo.fnIkGetLandesindexWert(@IkIndexTypCode, (YEAR(@NewDate) - 1), 11);  -- es wird immer der November-Index des Vorjahres genommen
  
  IF (@NovIndex IS NULL)
  BEGIN
    SET @ErrorMsg = 'Der Index für die neue Forderung konnte nicht ermittelt werden ' + 
                    '(spIkForderung_Insert_Index, IkForderungID = ' + CONVERT(VARCHAR(15), @IkForderungID) + 
                    ', Index-Zeitpunkt (neu) = Nov. ' + CONVERT(VARCHAR(4), (YEAR(@NewDate) - 1)) + ').';
    
    RAISERROR (@ErrorMsg, 18, 1);
    RETURN -2;
  END;
  
  -----------------------------------------------------------------------------
  -- Alter index holen
  -----------------------------------------------------------------------------
  SET @NovIndex_old = dbo.fnIkGetLandesindexWert(@IkIndexTypCode, (YEAR(@NewDate) - 2), 11);  -- es wird immer der November-Index des Vor-Vorjahres genommen

  IF (@NovIndex_old IS NULL)
  BEGIN
    SET @ErrorMsg = 'Der Index für die neue Forderung konnte nicht ermittelt werden ' + 
                    '(spIkForderung_Insert_Index, IkForderungID = ' + CONVERT(VARCHAR(15), @IkForderungID) +
                    ', Index-Zeitpunkt (alt) = Nov. ' + CONVERT(VARCHAR(4), (YEAR(@NewDate) - 2)) + ').';
    
    RAISERROR (@ErrorMsg, 18, 1);
    RETURN -2;
  END;
  
  -----------------------------------------------------------------------------
  -- Kontrolle, ob es nach der gewählten Forderung noch 
  -- eine NULL-Forderung gibt, welche vor dem neuen Datum liegt
  -- oder das DatumGueltigBis entsprechend gesetzt wurde
  -----------------------------------------------------------------------------
  IF (EXISTS (SELECT TOP 1 1 
              FROM dbo.IkForderung F WITH (READUNCOMMITTED)
              WHERE F.IkRechtstitelID = @IkRechtstitelID
                AND F.BaPersonID = @BaPersonID
                AND F.IkForderungPeriodischCode = @IkForderungPeriodischCode
                AND F.DatumAnpassenAb >= dbo.fnDateSerial(YEAR(@NewDate), 1, 1)
                AND F.DatumAnpassenAb < @NewDate
                AND (F.Betrag = 0 OR (F.DatumGueltigBis >= dbo.fnDateSerial(YEAR(@NewDate), 1, 1)
                 AND F.DatumGueltigBis < @NewDate))))
  BEGIN
    RETURN 3;
  END;
  
  -----------------------------------------------------------------------------
  -- Kontrolle, ob die Forderung bereits erstellt wurde
  -----------------------------------------------------------------------------
  IF (EXISTS (SELECT TOP 1 1 
              FROM dbo.IkForderung F WITH (READUNCOMMITTED)
              WHERE F.IkRechtstitelID = @IkRechtstitelID
                AND F.BaPersonID = @BaPersonID
                AND F.IkForderungPeriodischCode = @IkForderungPeriodischCode
                AND F.DatumAnpassenAb = @NewDate
                AND F.IkAnpassungsGrundCode = 2))
  BEGIN
    RETURN 4;
  END;
  
  -----------------------------------------------------------------------------
  -- Neue Forderung ertsellen
  -----------------------------------------------------------------------------
  BEGIN TRANSACTION;
  
  BEGIN TRY;
    -- Neuer Betrag errechnen
    IF @IkAnpassungsRegelCode = 2
    BEGIN
      SET @Betrag_Berechnet = dbo.fnIkAlimenteRunden(@Rundung, @Betrag_Basis * ISNULL(@NovIndex,100) / ISNULL(@NovIndex_old,100));
    END
    ELSE
    BEGIN
      SET @Betrag_Berechnet = @Betrag_Basis;
    END;
    
    -- Neue Forderung speichern
    INSERT INTO dbo.IkForderung (FaLeistungID, IkRechtstitelID, BaPersonID, IkForderungPeriodischCode, DatumAnpassenAb, DatumGueltigBis, 
                                 Betrag, IkAnpassungsGrundCode, IkAnpassungsRegelCode, IndexStandBeiBerechnung, IndexStandDatum, 
                                 Bemerkung, Sollgestellt, Teuerungseinsprache, ALBVBerechtigt, Unterstuetzungsfall, TeilALBV, TeilALBVBetrag) 
      SELECT
        NULL, IkRechtstitelID, BaPersonID, IkForderungPeriodischCode, @NewDate, @DatumGueltigBis, 
        @Betrag_Berechnet, 2, IkAnpassungsRegelCode, 
        -- IndexStandBeiBerechnung:  
        -- ------------------------
        -- Wenn Teuerungseinsprache "ja", dann: 
        -- Alte Forderung kopieren, Datum letzte Indexanpassung kopieren und nicht senden und 
        -- lediglich gültig ab ändern auf 01.01.2009
        -- Wenn Teuerungseinsprache "nein", dann: 
        -- Alte Forderung kopieren, Datum Indexanpassung 11.2008 und dazugehörende Punkte übernehmen und 
        -- gültig ab ändern auf 01.01.2009
        CASE 
          WHEN @TeuerungsEinsprache = 1 AND @IkAnpassungsRegelCode != 2 THEN IndexStandBeiBerechnung
          ELSE @NovIndex
        END, 
        -- IndexStandDatum:
        -- ----------------
        -- Wenn Teuerungseinsprache "ja", dann: 
        -- Alte Forderung kopieren, Datum letzte Indexanpassung kopieren und nicht senden und 
        -- lediglich gültig ab ändern auf 01.01.2009
        -- Wenn Teuerungseinsprache "nein", dann: 
        -- Alte Forderung kopieren, Datum Indexanpassung 11.2008 und dazugehörende Punkte übernehmen und 
        -- gültig ab ändern auf 01.01.2009
        CASE
          WHEN @TeuerungsEinsprache = 1 AND @IkAnpassungsRegelCode != 2 THEN IndexStandDatum
          ELSE CONVERT(DATETIME, CONVERT(VARCHAR(4), YEAR(@NewDate) - 1) + '1101')
        END,
        Bemerkung, 0, Teuerungseinsprache, ALBVBerechtigt, Unterstuetzungsfall, TeilALBV, TeilALBVBetrag
      FROM dbo.IkForderung F
      WHERE F.IkForderungID = @IkForderungID;
    
    COMMIT TRANSACTION;
  END TRY
  BEGIN CATCH
    ROLLBACK TRANSACTION;
    
    SET @ErrorMsg = ERROR_MESSAGE();
    RAISERROR (@ErrorMsg, 18, 1);
    
    RETURN -4;
  END CATCH;
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN 1;
END;
GO