SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnBruttoToNetto
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

CREATE FUNCTION dbo.fnBruttoToNetto
(
  @KbBuchungBruttoID int
)
RETURNS int
AS
BEGIN
  DECLARE @KbBuchungID int

  SELECT @KbBuchungID = KBU.KbBuchungID
  FROM dbo.KbBuchungBrutto KBB WITH (READUNCOMMITTED)
    INNER JOIN dbo.KbBuchungBruttoPerson KBP WITH (READUNCOMMITTED) ON KBP.KbBuchungBruttoID = KBB.KbBuchungBruttoID
    INNER JOIN dbo.KbBuchungKostenart    KBK WITH (READUNCOMMITTED) ON KBK.BgPositionID      = KBP.BgPositionID
    INNER JOIN dbo.KbBuchung             KBU WITH (READUNCOMMITTED) ON KBU.KbBuchungID       = KBK.KbBuchungID AND (KBB.Betrag < 0 OR IsNull(KBP.Schuldner_BaPersonID,-1) = IsNull(KBU.Schuldner_BaPersonID,-1)) AND (KBB.Betrag < 0 OR IsNull(KBP.Schuldner_BaInstitutionID,-1) = IsNull(KBU.Schuldner_BaInstitutionID,-1)) AND KBU.ValutaDatum = KBB.ValutaDatum
  WHERE KBB.KbBuchungBruttoID = @KbBuchungBruttoID

  -- Durch eine verspätete Übertragung ans PSCD kann die Netto- und die Bruttobuchung ein unterschiedliches Datum
  -- aufweisen. Falls nur eine Nettobuchung besteht, ist die Zuordnung noch möglich.
  IF @KbBuchungID IS NULL BEGIN
	SELECT @KbBuchungID = CASE WHEN Count(KBU.KbBuchungID) OVER () = 1 THEN KBU.KbBuchungID ELSE NULL END
    FROM dbo.KbBuchungBrutto KBB WITH (READUNCOMMITTED)
      INNER JOIN dbo.KbBuchungBruttoPerson KBP WITH (READUNCOMMITTED) ON KBP.KbBuchungBruttoID = KBB.KbBuchungBruttoID
      INNER JOIN dbo.KbBuchungKostenart KBK WITH (READUNCOMMITTED) ON KBK.BgPositionID = KBP.BgPositionID
      INNER JOIN dbo.KbBuchung KBU WITH (READUNCOMMITTED) ON KBU.KbBuchungID = KBK.KbBuchungID
		AND (KBB.Betrag < 0 OR IsNull(KBP.Schuldner_BaPersonID,-1) = IsNull(KBU.Schuldner_BaPersonID,-1))
		AND (KBB.Betrag < 0 OR IsNull(KBP.Schuldner_BaInstitutionID,-1) = IsNull(KBU.Schuldner_BaInstitutionID,-1))
    WHERE KBB.KbBuchungBruttoID = @KbBuchungBruttoID
    GROUP BY KBU.KbBuchungID
  END

  -- Eine Netto-Buchung mehrere Bruttobelege kann Schuldner_BaPersonID/Schuldner_BaInstitutionID mit Wert null haben
  IF @KbBuchungID IS NULL BEGIN
	SELECT @KbBuchungID = CASE WHEN Count(KBU.KbBuchungID) OVER () = 1 THEN KBU.KbBuchungID ELSE NULL END
    FROM dbo.KbBuchungBrutto KBB WITH (READUNCOMMITTED)
      INNER JOIN dbo.KbBuchungBruttoPerson KBP WITH (READUNCOMMITTED) ON KBP.KbBuchungBruttoID = KBB.KbBuchungBruttoID
      INNER JOIN dbo.KbBuchungKostenart KBK WITH (READUNCOMMITTED) ON KBK.BgPositionID = KBP.BgPositionID
      INNER JOIN dbo.KbBuchung KBU WITH (READUNCOMMITTED) ON KBU.KbBuchungID = KBK.KbBuchungID
    WHERE KBB.KbBuchungBruttoID = @KbBuchungBruttoID
		AND (KBU.Schuldner_BaPersonID IS NULL AND KBU.Schuldner_BaInstitutionID IS NULL)
		AND KBU.ValutaDatum = KBB.ValutaDatum
    GROUP BY KBU.KbBuchungID
  END

  RETURN @KbBuchungID

END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
