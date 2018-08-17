SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmVmVaterschaft;
GO
/*===============================================================================================
  $Revision: 1
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Enthält Felder für Vaterschafts-Textmarken.
  -
  RETURNS: .
  -
  TEST:    SELECT TOP 10 * FROM dbo.vwTmVmVaterschaft;
=================================================================================================*/

CREATE VIEW dbo.vwTmVmVaterschaft
AS
SELECT

  FaLeistungID  = LEI.FaLeistungID,
  BaPersonID    = LEI.BaPersonID,

  -----------------------------------------------------------------------------
  -- VmVaterschaft
  -----------------------------------------------------------------------------
  AnerkennungDat = CONVERT(VARCHAR, VMV.AnerkennungDatum, 104),
  AnerkennungOrt = VMV.AnerkennungOrt,
  UHVDat         = CONVERT(VARCHAR, VMV.UHVDatum, 104),
  SgeVDat        = CONVERT(VARCHAR, VMV.SorgerechtVereinbDatum, 104),
  GenehmDat      = CONVERT(VARCHAR, VMV.SchlussberichtGenehmigung, 104)

FROM dbo.FaLeistung           LEI WITH (READUNCOMMITTED)
  LEFT JOIN dbo.VmVaterschaft VMV WITH (READUNCOMMITTED) ON VMV.FaLeistungID = LEI.FaLeistungID
  LEFT JOIN dbo.vwTmPerson    PRS ON PRS.BaPersonID = LEI.BaPersonID
WHERE ModulID = 5 -- Vm
  AND LEI.FaProzessCode = 502; -- Vaterschaft
GO
