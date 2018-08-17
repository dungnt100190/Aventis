SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON
GO
EXECUTE dbo.spDropObject vwAsylBuchungen
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwAsylBuchungen.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:52 $
  $Revision: 3 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwAsylBuchungen.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwAsylBuchungen]
AS

SELECT
		KBK.BaPersonID, KBU.KbBuchungTypCode, Betrag = IsNull(KBK.Betrag, KBU.Betrag),
		KBK.VerwPeriodeVon, KBK.VerwPeriodeBis, BKA.Hauptvorgang, BKA.Teilvorgang, LEI.FaFallID

FROM
		dbo.KbBuchungBrutto KBU WITH (READUNCOMMITTED)
		LEFT OUTER JOIN dbo.KbBuchungBruttoPerson    KBK WITH (READUNCOMMITTED) ON KBU.KbBuchungBruttoID = KBK.KbBuchungBruttoID
		LEFT OUTER JOIN dbo.BgKostenart              BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID     = KBU.BgKostenartID
		LEFT OUTER JOIN dbo.BgBudget                 BUD WITH (READUNCOMMITTED) ON BUD.BgBudgetID        = KBU.BgBudgetID
		LEFT OUTER JOIN dbo.BgFinanzplan             FIP WITH (READUNCOMMITTED) ON FIP.BgFinanzplanID    = BUD.BgFinanzplanID
		LEFT OUTER JOIN dbo.FaLeistung               LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID      = FIP.FaLeistungID
WHERE
		(KBU.KbBuchungTypCode IN (1))
		AND (KBU.KbBuchungStatusCode IN (6, 10))
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
GRANT SELECT ON [dbo].[vwAsylBuchungen] TO [tools_access]
GO
GRANT  SELECT  ON [dbo].[vwAsylBuchungen]  TO [tools_sonar_ek_asyl_role]
GO
