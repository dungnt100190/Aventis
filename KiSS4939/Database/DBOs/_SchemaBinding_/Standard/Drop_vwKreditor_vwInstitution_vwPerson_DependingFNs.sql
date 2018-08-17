/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to drop construct of vwKreditor, vwInstitution, vwPerson to later 
           re-createand them again. See vwKreditor_vwInstitution_vwPerson_DependingFNs.sql
           for further details. 
=================================================================================================*/

-------------------------------------------------------------------------------
-- drop all items in order of dependence if existing (top down)
-------------------------------------------------------------------------------
EXECUTE dbo.spDropObject vwKreditor;
GO
EXECUTE dbo.spDropObject vwInstitution;
GO
EXECUTE dbo.spDropObject vwPerson;
GO
--
EXECUTE dbo.spDropObject fnGetAdressText;
GO
EXECUTE dbo.spDropObject fnBaGetBaAdresseID;
GO
EXECUTE dbo.spDropObject fnTnToPc;
GO
EXECUTE dbo.spDropObject fnBaGetBaAdresseID_BaInstitution;
GO
EXECUTE dbo.spDropObject fnLandMLText;
GO
EXECUTE dbo.spDropObject fnBaGetPostfachText;
GO
EXECUTE dbo.spDropObject fnXGetPostfachTextML;
GO
EXECUTE dbo.spDropObject fnXDbObjectMLMsg;
GO
EXECUTE dbo.spDropObject fnGetMLText;
GO
EXECUTE dbo.spDropObject fnGetLastFirstName;
GO
--
EXECUTE dbo.spDropObject fnGetAge;
GO
EXECUTE dbo.spDropObject fnBaGetBaAdresseID_BaPerson;
GO
EXECUTE dbo.spDropObject fnDateOf;
GO
