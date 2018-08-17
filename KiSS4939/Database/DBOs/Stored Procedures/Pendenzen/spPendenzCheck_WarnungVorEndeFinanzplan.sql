SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
EXECUTE spDropObject spPendenzCheck_WarnungVorEndeFinanzplan
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spPendenzCheck_WarnungVorEndeFinanzplan.sql $
  $Author: Lloreggia $
  $Modtime: 16.12.09 13:53 $
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:       Sucht nach in K�rze ablaufenden Finanzpl�nen
    @AnzahlTage: Anzahl Tage vor dem Ende eines aktiven Finanzplans
  -
  RETURNS:       Ein Datensatz mit anzulegenden Pendenzen
  -
  TEST:          EXEC dbo.spPendenzCheck_WarnungVorEndeFinanzplan
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spPendenzCheck_WarnungVorEndeFinanzplan.sql $
 * 
 * 4     16.12.09 13:53 Lloreggia
 * Pendenzen werden nur f�r offene Leistungen erzeugt
 * 
 * 3     30.11.09 10:07 Lloreggia
 * Header angepasst
=================================================================================================*/

CREATE PROCEDURE dbo.spPendenzCheck_WarnungVorEndeFinanzplan 
(
	@AnzahlTage INT = 30
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  -- declare local variables
  DECLARE @AutoGeneratedType INT
  DECLARE @ReferenceTable VARCHAR(100)
  DECLARE @Code INT;
  
  SET @AutoGeneratedType = 0  -- WarnungVorEndeFinanzplan
  SET @ReferenceTable = 'BgFinanzplan'
  SET @Code = 33 --WarnungVorEndeFinanzplan

	SELECT DISTINCT
    TaskSenderCode   = 5,  -- DbScript
    TaskReceiverCode = 1,  -- Person
    TaskTypeCode     = @Code,  -- WarnungVorEndeFinanzplan
    TaskStatusCode   = 1,  -- Pendent
    CreateDate       = DATEADD(DAY, -@AnzahlTage, FPL.DatumBis),
    StartDate        = NULL,
    ExpirationDate   = FPL.DatumBis,
    Subject           = (SELECT dbo.fnStringReplace(Value1, CONVERT(varchar, FPL.DatumBis, 104)) FROM XLOVCode WHERE LOVName ='TaskType' AND Code = @Code),
    TaskDescription   = (SELECT Value2 FROM XLOVCode WHERE LOVName ='TaskType' AND Code = @Code),
    FaLeistungID     = FPL.FaLeistungID,
    BaPersonID       = LEI.BaPersonID,
    SenderID         = NULL,
    ReceiverID       = LEI.UserID,
    ReferenceTable   = @ReferenceTable,
    ReferenceID      = FPL.BgFinanzplanID,
    AutoGeneratedType = @AutoGeneratedType
  FROM dbo.BgFinanzplan                  FPL WITH (READUNCOMMITTED)
    INNER JOIN dbo.FaLeistung            LEI WITH (READUNCOMMITTED) ON FPL.FaLeistungID = LEI.FaLeistungID
  WHERE ISNULL(LEI.DatumBis, '99990101') >= GETDATE()
    AND DATEDIFF(DAY, GETDATE(), FPL.DatumBis) <= @AnzahlTage
    AND GETDATE() <= FPL.DatumBis
    AND FPL.BgBewilligungStatusCode >= 5
    AND NOT EXISTS (SELECT TOP 1 1
                    FROM dbo.XTaskAutoGenerated TAG WITH (READUNCOMMITTED)
                    WHERE TAG.XTaskAutoGeneratedTypeCode = @AutoGeneratedType
                      AND TAG.ReferenceTable = @ReferenceTable
                      AND TAG.ReferenceID = FPL.BgFinanzplanID);

END
GO
