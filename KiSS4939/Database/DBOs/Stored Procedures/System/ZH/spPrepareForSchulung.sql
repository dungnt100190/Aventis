SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
EXECUTE spDropObject spPrepareForSchulung
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:       
  -
  RETURNS:       
  -
=================================================================================================
  TEST:          
=================================================================================================*/

CREATE  PROCEDURE dbo.spPrepareForSchulung

AS

-- xconfig setzen

UPDATE XConfig
  SET ValueVarchar = 'http://10.1.100.114/AlphaSvc/Schulung/AlphaSvc.asmx',
      DatumVon = '1900-01-01 00:00:00.000'
WHERE KeyPath  = 'System\Schnittstellen\Alpha\AlphaWebServiceURL'

 

UPDATE XConfig
  SET ValueVarchar = 'http://10.1.100.114/PSCDSvc/Schulung/PSCDSvc.asmx',
      DatumVon = '1900-01-01 00:00:00.000'
WHERE KeyPath  = 'System\Schnittstellen\PSCD\PSCDWebServiceURL'

 

UPDATE XConfig
  SET ValueVarchar = '',
      DatumVon = '1900-01-01 00:00:00.000'
WHERE KeyPath  = 'System\Schnittstellen\Alpha\Proxy'

 

UPDATE XConfig
  SET ValueVarchar = '',
      DatumVon = '1900-01-01 00:00:00.000'
WHERE KeyPath  = 'System\Schnittstellen\PSCD\Proxy'

