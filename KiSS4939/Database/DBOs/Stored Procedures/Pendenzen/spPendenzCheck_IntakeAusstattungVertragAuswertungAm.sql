﻿SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
EXECUTE spDropObject spPendenzCheck_IntakeAusstattungVertragAuswertungAm
GO
/*===============================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:       Pendenzen zur Auswertung des Ausstattungs-Vertrags in der Intakesphase erstellen

  RETURNS:       Datensatz mit anzulegenden Pendenzen
  -
  TEST:          EXEC dbo.spPendenzCheck_IntakeAusstattungVertragAuswertungAm
=================================================================================================*/

CREATE PROCEDURE dbo.spPendenzCheck_IntakeAusstattungVertragAuswertungAm
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
  SET NOCOUNT ON;

  -- declare local variables
  DECLARE @AutoGeneratedType INT;
  DECLARE @ReferenceTable VARCHAR(100);
  DECLARE @Today DATETIME;
  DECLARE @AnzahlTage INT;
  DECLARE @IntakeAuswertungGeplantAm DATETIME;
  DECLARE @Code INT;

  SET @AutoGeneratedType = 10;  -- AuswertungIntakesphase
  SET @ReferenceTable = 'DynaValue';
  SET @Today = GETDATE();
  SET @Code = 30 --Intake Ausstattung Vertrag Auswertung Am

  SET @AnzahlTage = CONVERT(INT, ISNULL(dbo.fnXConfig('System\Pendenzen\IntakeAusstattungVertragAuswertungAm\AnzahlTage', GETDATE()), 30));

  SELECT DISTINCT
    TaskSenderCode   = 5,  -- DbScript
    TaskReceiverCode = 1,  -- Person
    TaskTypeCode     = @Code,  -- Intake Ausstattung Vertrag Auswertung Am
    TaskStatusCode   = 1,  -- Pendent
    CreateDate       = @Today,
    StartDate        = NULL,
    ExpirationDate   = CONVERT(DATETIME, DYV.Value, 104),
    Subject          = (SELECT Value1 FROM XLOVCode WHERE LOVName ='TaskType' AND Code = @Code),
    TaskDescription  = (SELECT dbo.fnStringReplace(Value2, CONVERT(VARCHAR, DYV.Value, 104)) FROM XLOVCode WHERE LOVName ='TaskType' AND Code = @Code),
    FaLeistungID     = PHA.FaLeistungID,
    BaPersonID       = LEI.BaPersonID,
    SenderID         = NULL,
    ReceiverID       = LEI.UserID,
    ReferenceTable    = @ReferenceTable,
    ReferenceID       = DYV.DynaValueID, --PHA.FaPhaseID,
    AutoGeneratedType = @AutoGeneratedType
FROM FaPhase            PHA
  INNER JOIN DynaValue  DYV ON DYV.FaPhaseID = PHA.FaPhaseID
  INNER JOIN DynaField  DFD ON DYV.DynaFieldID = DFD.DynaFieldID
  INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = PHA.FaLeistungID
WHERE PHA.DatumBis IS NULL -- keine abgeschlossenen Phasen 
  AND DFD.FieldName = 'FaIntAusstattungVerAuswert'
  AND DATEADD(DAY, @AnzahlTage, @Today) >= DYV.Value 
  AND NOT EXISTS (
	  SELECT TOP 1 1 FROM dbo.XTaskAutoGenerated TAG 
	  WHERE TAG.XTaskAutoGeneratedTypeCode = @AutoGeneratedType
	    AND TAG.ReferenceTable = @ReferenceTable
		AND TAG.ReferenceID = DYV.DynaValueID);
END
GO


		