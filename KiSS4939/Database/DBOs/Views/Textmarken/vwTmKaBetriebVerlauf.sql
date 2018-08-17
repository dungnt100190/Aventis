SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmKaBetriebVerlauf
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Views/vwTmKaBetriebVerlauf.sql $
  $Author: Lgreulich $
  $Modtime: 28.08.09 11:52 $
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken für die Maske KA - Betriebe Verlauf
  -
  RETURNS: .
  -
  TEST:    SELECT * FROM vwTmKaBetriebVerlauf
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Views/vwTmKaBetriebVerlauf.sql $
 * 
 * 1     28.08.09 12:00 Lgreulich
 * #4884 Neue Textmarken
 * 
 * 
 * 
 * VSS First
=================================================================================================*/

CREATE VIEW dbo.vwTmKaBetriebVerlauf
AS

SELECT 
  KaBetriebBesprechungID,
  Datum         = BES.Datum,
  Kontaktperson = BEK.Name + IsNull(', ' + BEK.Vorname, ''),
  Autor         = USR.LastName + IsNull(', ' + USR.FirstName, ''),
  Stichwort     = BES.Stichwort  
FROM dbo.KaBetriebBesprechung     BES WITH (READUNCOMMITTED)
   LEFT JOIN dbo.XUser            USR WITH (READUNCOMMITTED) ON USR.UserID = BES.AutorID
   LEFT JOIN dbo.KaBetriebKontakt BEK WITH (READUNCOMMITTED) ON BEK.KaBetriebKontaktID = BES.KontaktPersonID

GO 