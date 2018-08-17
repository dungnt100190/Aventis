SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
EXECUTE dbo.spDropObject spIkMonatszahlen_TotalSaldo
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH_Branches/KiSS4.1.37_MASTER_ZH/Stored Procedures/spIkMonatszahlen_TotalSaldo.sql $
  $Author: Nweber $
  $Modtime: 2.10.09 13:43 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Totalsaldo berechnen für Nachzahlungen seit ein gegebenen Datum
    @FaLeistungID: FaLeistungID
    @BaPersonID:   BaPersonID vom Gläubiger
    @SaldoVon:     Datum von welchem das Totalsaldo für Nachzahlungen muss berechnet werden
  -
  RETURNS: Totalsaldo (AuszahlungSoll - Auszahlung) für ein Gläubiger
  -
  TEST:    EXEC dbo.spIkMonatszahlen_TotalSaldo 7025942, 173948
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH_Branches/KiSS4.1.37_MASTER_ZH/Stored Procedures/spIkMonatszahlen_TotalSaldo.sql $
 * 
 * 2     2.10.09 13:44 Nweber
 * #5155: TotalSaldo für Nachzahlungen ab ein gegebenes Datum berechnen
 * 
 * 1     1.10.09 13:27 Nweber
 * #5155: SP um das Totalsaldo über alle Positionen für ein Gäubiger zu
 * berechnen.
=================================================================================================*/
CREATE PROCEDURE dbo.spIkMonatszahlen_TotalSaldo
(
  @FaLeistungID INT,
  @BaPersonID INT,
  @SaldoVon DATETIME
)
AS
BEGIN

  select 
    TotalSaldo = 
      -- Auszahlung
      SUM(CASE 
        WHEN G.IstElternteil = 1 THEN 0
        WHEN P.Einmalig = 1 THEN IsNull(P.BetragEinmalig, 0)
        WHEN P.IkRechtstitelID IS NULL AND IsNull(P.HatMehrereAlteRT, 0) = 1 THEN 0
        ELSE IsNull(P.BetragZahlung,0)
      END)
      -
      -- AuszahlungSoll
      SUM(CASE 
        WHEN G.IstElternteil = 1 THEN 0
        WHEN P.Einmalig = 1 THEN 0 -- IsNull(P.BetragEinmalig, 0)
        WHEN P.IkRechtstitelID IS NOT NULL AND IsNull(P.HatMehrereAlteRT, 0) = 1 THEN 0  -- bei Daten des alten Konzepts
        ELSE IsNull(P.BetragZahlungSoll,0)
      END)
  from dbo.IkPosition P WITH(READUNCOMMITTED)
  left outer join dbo.IkRechtstitel R WITH (READUNCOMMITTED) on R.IkRechtstitelID = P.IkRechtstitelID
  left outer join dbo.IkGlaeubiger G WITH (READUNCOMMITTED) on G.IkGlaeubigerID = (
    select top 1 Q.IkGlaeubigerID from dbo.IkGlaeubiger Q WITH(READUNCOMMITTED)
    left join dbo.IkRechtstitel R on R.IkRechtstitelID = Q.IkRechtstitelID
    where R.FaLeistungID = @FaLeistungID
      and Q.BaPersonID = P.BaPersonID
    -- zuerst den aktiven, dann in Vorbereitung, dann prov eingestellt, dann ungültig alle anderen
    order by case Q.IkGlaeubigerStatusCode when 2 then 1 when 1 then 2 when 3 then 3 else 4 end asc
  )
  where P.FaLeistungID = @FaLeistungID
    and (P.Einmalig = 0 or P.IkBuchungsartCode in (2,3))
    and P.BaPersonID = @BaPersonID
    and P.Datum > @SaldoVon
    AND ( 
      -- Auszahlung
      CASE 
        WHEN G.IstElternteil = 1 THEN 0
        WHEN P.Einmalig = 1 THEN IsNull(P.BetragEinmalig, 0)
        WHEN P.IkRechtstitelID IS NULL AND IsNull(P.HatMehrereAlteRT, 0) = 1 THEN 0
        ELSE IsNull(P.BetragZahlung,0)
      END
      -
      -- AuszahlungSoll
      CASE 
        WHEN G.IstElternteil = 1 THEN 0
        WHEN P.Einmalig = 1 THEN 0 -- IsNull(P.BetragEinmalig, 0)
        WHEN P.IkRechtstitelID IS NOT NULL AND IsNull(P.HatMehrereAlteRT, 0) = 1 THEN 0  -- bei Daten des alten Konzepts
        ELSE IsNull(P.BetragZahlungSoll,0)
      END
    ) > 0
  group by P.FaLeistungID

END

