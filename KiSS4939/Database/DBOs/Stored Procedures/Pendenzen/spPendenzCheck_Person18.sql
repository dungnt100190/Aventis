SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
EXECUTE spDropObject spPendenzCheck_Person18
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spPendenzCheck_Person18.sql $
  $Author: Lloreggia $
  $Modtime: 16.12.09 13:52 $
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:       Sucht Personen, die in K�rze 18 Jahre alt werden
    @AnzahlTage: Die Anzahl Tage vor dem 18. Geburtstag
  -
  RETURNS:       Ein Datensatz mit anzulegenden Pendenzen
  -
  TEST:          EXEC dbo.spPendenzCheck_Person18
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spPendenzCheck_Person18.sql $
 * 
 * 4     16.12.09 13:53 Lloreggia
 * Pendenzen werden nur f�r offene Leistungen erzeugt
 * 
 * 3     30.11.09 10:08 Lloreggia
 * Header angepasst
=================================================================================================*/

CREATE PROCEDURE dbo.spPendenzCheck_Person18
(
	@AnzahlTage INT = 30
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  -- declare local variables
  DECLARE @Alter INT
  DECLARE @AutoGeneratedType INT
  DECLARE @ReferenceTable VARCHAR(100)
  DECLARE @Code INT
  
  SET @Alter = 18
  SET @AutoGeneratedType = 1  -- Person18
  SET @ReferenceTable = 'BaPerson'
  SET @Code = 21 -- Fristablauf Person 18

	SELECT DISTINCT
    TaskSenderCode   = 5,  -- DbScript
    TaskReceiverCode = 1,  -- Person
    TaskTypeCode     = @Code,  -- Fristablauf Person 18
    TaskStatusCode   = 1,  -- Pendent
    CreateDate       = DATEADD(DAY, -@AnzahlTage, DATEADD(YEAR, @Alter, PRS.GeburtsDatum)),
    StartDate        = NULL,
    ExpirationDate   = DATEADD(YEAR, @Alter, PRS.GeburtsDatum),
    Subject          = (SELECT dbo.fnStringReplace(Value1, CONVERT(varchar, DATEADD(YEAR, @Alter, PRS.GeburtsDatum), 104)) FROM XLOVCode WHERE LOVName ='TaskType' AND Code = @Code),
    TaskDescription  = (SELECT Value2 FROM XLOVCode WHERE LOVName ='TaskType' AND Code = @Code),
    FaLeistungID     = FPL.FaLeistungID,
    BaPersonID       = FPP.BaPersonID,
    SenderID         = NULL,
    ReceiverID       = LEI.UserID,
    ReferenceTable    = @ReferenceTable,
    ReferenceID       = PRS.BaPersonID,
    AutoGeneratedType = @AutoGeneratedType
  FROM dbo.BgFinanzplan                  FPL WITH (READUNCOMMITTED)
    INNER JOIN dbo.BgFinanzplan_BaPerson FPP WITH (READUNCOMMITTED) ON FPL.BgFinanzplanID = FPP.BgFinanzplanID
                                                                   --AND FPP.IstUnterstuetzt = 1
    INNER JOIN dbo.BaPerson              PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = FPP.BaPersonID
    INNER JOIN dbo.FaLeistung            LEI WITH (READUNCOMMITTED) ON FPL.FaLeistungID = LEI.FaLeistungID
  WHERE ISNULL(LEI.DatumBis, '99990101') >= GETDATE()
    AND FPL.BgBewilligungStatusCode >= 5
    AND DATEDIFF(DAY, GETDATE(), DATEADD(YEAR, @Alter, PRS.GeburtsDatum)) <= @AnzahlTage
    AND GETDATE() <= DATEADD(YEAR, @Alter, PRS.GeburtsDatum)
    AND NOT EXISTS (SELECT TOP 1 1
                    FROM dbo.XTaskAutoGenerated TAG WITH (READUNCOMMITTED)
                    WHERE TAG.XTaskAutoGeneratedTypeCode = @AutoGeneratedType
                      AND TAG.ReferenceTable = @ReferenceTable
                      AND TAG.ReferenceID = PRS.BaPersonID);

END
GO
