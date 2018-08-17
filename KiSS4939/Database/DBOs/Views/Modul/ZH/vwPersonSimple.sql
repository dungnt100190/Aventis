SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwPersonSimple;
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: This is a simple view of the table BaPerson. The aim of this view is to be faster as
           the VwPerson.
           Joins are not allowed in this view, in order to keep it fast!
  -
  RETURNS: A few amount of information about a person. (BaPersonID, NameVorname)
=================================================================================================
  TEST:    SELECT TOP 10 BaPersonID, NameVorname FROM dbo.vwPersonSimple;
=================================================================================================*/

CREATE VIEW dbo.vwPersonSimple
AS
SELECT
  PRS.BaPersonID,
  NameVorname = PRS.Name + IsNull(', ' + PRS.Vorname, ''),
  PRS.Versichertennummer,
  PRS.GeschlechtCode,
  PRS.Geburtsdatum,
  DisplayText = PRS.Name + IsNull(', ' + PRS.Vorname, '') + ' (' +
                IsNull(CONVERT(varchar,dbo.fnGetAgeMortal(PRS.Geburtsdatum, GetDate(),PRS.Sterbedatum)),'-') + ',' +
                IsNull((SELECT TOP 1 GES.ShortText
                        FROM dbo.XLOVCode GES WITH(READUNCOMMITTED)
                        WHERE GES.LOVName = 'BaGeschlecht' AND GES.Code = PRS.GeschlechtCode),'?') + ')'
FROM dbo.BaPerson PRS WITH (READUNCOMMITTED);
