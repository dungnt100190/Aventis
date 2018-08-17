SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnBFSGetKatalogVersion
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/Sostat/fnBFSGetKatalogVersion.sql $
  $Author: Rhesterberg $
  $Modtime: 25.08.10 11:04 $
  $Revision: 5 $
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
  WARNING: This object is shared in Visual SourceSafe, beware of changes!
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/Sostat/fnBFSGetKatalogVersion.sql $
 * 
 * 5     25.08.10 11:04 Rhesterberg
 * #6484 neue BFSKatalogversion
 * 
 * 4     25.08.10 11:04 Rhesterberg
 * #6484 neue BFSKatalogversion
 * 
 * 3     5.02.10 13:51 Nweber
 * shared
 * 
 * 2     11.12.09 10:22 Lloreggia
 * Header aktualisiert
 * 
 * 1     17.11.09 21:25 Rstahel
 * #5018: BFS-Anpassungen für ZH
 * 
 * 2     10.03.09 18:08 Rstahel
 * Abgleich der Functions aus KISS4_MASTER_ZH
=================================================================================================*/
CREATE FUNCTION [dbo].[fnBFSGetKatalogVersion]
( 
	@Erhebungsjahr INT
)
RETURNS INT
AS
BEGIN

	RETURN (
		SELECT TOP 1 BFSKatalogVersionID
        FROM dbo.BFSKatalogVersion 
        WHERE  Jahr <= IsNull(@Erhebungsjahr, Jahr)
        ORDER BY Jahr DESC, BFSKatalogVersionID DESC 
    )
END

