SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmAbrechnungErgaenzungen;
GO
/*===============================================================================================
  $Revision: 3$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: <ZH Klientenkontoabrechnung Ergänzungen>
    Im Detailblatt (Worddokument) der Klientenkontoabrechnung werden die Ergänzungen
    aufgelistet. Die Ergänzungen können im Reiter Ergänzungen in der Maske  
    Klientenkontoabrechung eingegeben werden.
  RETURNS: <ZH Klientenkontoabrechnung Ergänzungen>
=================================================================================================
  TEST:    SELECT TOP 10 <Columns> FROM dbo.vwTmAbrechnungErgaenzungen;
=================================================================================================*/

CREATE VIEW dbo.vwTmAbrechnungErgaenzungen
AS
SELECT
  WhDetailblattID,
  Korrekturtext, 
  Betrag = CASE 
             WHEN WhDetailblattKorrekturVorzeichenCode = 1 -- 1: Reduktion, 2: Erhöhung
               THEN -Betrag
             ELSE Betrag
           END
  FROM dbo.whDetailblattKorrekturPosition WITH (READUNCOMMITTED);
GO
