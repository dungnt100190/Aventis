SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spIkForderung_Delete_Check
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spIkForderung_Delete_Check.sql $
  $Author: Ckaeser $
  $Modtime: 12.08.09 14:27 $
  $Revision: 4 $
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
*/
/*
  KiSS 4.0
  --------
  DB-Object: spIkForderung_Delete_Check
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 15.12.2008 16:12
*/
CREATE PROCEDURE dbo.spIkForderung_Delete_Check
  -- IkForderungID :
  @IkForderungID INT
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON

  -- ---------------------------------------------------
  -- Kontrolle, ob Forderung bereits verbucht ist
  -- ---------------------------------------------------
  SELECT AnzahlVerbucht = COUNT(*) FROM dbo.IkForderungPosition FB WITH (READUNCOMMITTED)
  WHERE FB.IkForderungID = @IkForderungID
  AND EXISTS (
    SELECT BUC.KbBuchungID FROM dbo.KbBuchung BUC WITH (READUNCOMMITTED)
    WHERE BUC.IkPositionID = FB.IkPositionID
      AND BUC.KbBuchungStatusCode != 8 )
END
