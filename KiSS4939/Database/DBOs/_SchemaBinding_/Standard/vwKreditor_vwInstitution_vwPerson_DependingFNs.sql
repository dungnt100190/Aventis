/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to (re)create construct of vwKreditor, vwInstitution, vwPerson and all
           depending functions as they are all created with flag "WITH SCHEMABINDING" and therefore
           depend on each other. 
=================================================================================================*/

-------------------------------------------------------------------------------
-- drop all items in order of dependence if existing (top down)
-------------------------------------------------------------------------------

{Include:Drop_vwKreditor_vwInstitution_vwPerson_DependingFNs}
GO
-------------------------------------------------------------------------------
-- (re)create items (bottom up)
-------------------------------------------------------------------------------
{Include:fnDateOf}
GO
{Include:fnBaGetBaAdresseID_BaPerson}
GO
{Include:fnGetAge}
GO
--
{Include:fnGetLastFirstName}
GO
{Include:fnGetMLText}
GO
{Include:fnXDbObjectMLMsg}
GO
{Include:fnXGetPostfachTextML}
GO
{Include:fnBaGetPostfachText}
GO
{Include:fnLandMLText}
GO
{Include:fnBaGetBaAdresseID_BaInstitution}
GO
{Include:fnTnToPc}
GO
{Include:fnBaGetBaAdresseID}
GO
{Include:fnGetAdressText}
GO
--
{Include:vwPerson}
GO
{Include:vwPerson2:IFNSE=ZH}
GO
{Include:vwInstitution}
GO
{Include:vwKreditor}
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
