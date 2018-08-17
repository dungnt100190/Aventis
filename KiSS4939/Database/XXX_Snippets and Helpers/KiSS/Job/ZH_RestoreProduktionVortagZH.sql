/****** Object:  Job [Restore Produktion -> KISS_ZH_PROD_VORTAG]    Script Date: 07/16/2014 15:49:56 ******/
IF  EXISTS (SELECT job_id FROM msdb.dbo.sysjobs_view WHERE name = N'Restore Produktion -> KISS_ZH_PROD_VORTAG')
EXEC msdb.dbo.sp_delete_job @job_id=N'c551e927-45fa-4490-a8a4-b3b0988fc2d1', @delete_unused_schedule=1
GO

/****** Object:  Job [Restore Produktion -> KISS_ZH_PROD_VORTAG]    Script Date: 07/16/2014 15:49:56 ******/
BEGIN TRANSACTION
DECLARE @ReturnCode INT
SELECT @ReturnCode = 0
/****** Object:  JobCategory [[Uncategorized (Local)]]]    Script Date: 07/16/2014 15:49:56 ******/
IF NOT EXISTS (SELECT name FROM msdb.dbo.syscategories WHERE name=N'[Uncategorized (Local)]' AND category_class=1)
BEGIN
EXEC @ReturnCode = msdb.dbo.sp_add_category @class=N'JOB', @type=N'LOCAL', @name=N'[Uncategorized (Local)]'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

END

DECLARE @jobId BINARY(16)
EXEC @ReturnCode =  msdb.dbo.sp_add_job @job_name=N'Restore Produktion -> KISS_ZH_PROD_VORTAG', 
    @enabled=1, 
    @notify_level_eventlog=0, 
    @notify_level_email=0, 
    @notify_level_netsend=0, 
    @notify_level_page=0, 
    @delete_level=0, 
    @description=N'No description available.', 
    @category_name=N'[Uncategorized (Local)]', 
    @owner_login_name=N'sa', @job_id = @jobId OUTPUT
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Restore]    Script Date: 07/16/2014 15:49:57 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Restore', 
    @step_id=1, 
    @cmdexec_success_code=0, 
    @on_success_action=3, 
    @on_success_step_id=0, 
    @on_fail_action=2, 
    @on_fail_step_id=0, 
    @retry_attempts=0, 
    @retry_interval=0, 
    @os_run_priority=0, @subsystem=N'TSQL', 
    @command=N'IF EXISTS(SELECT TOP 1 1 FROM SYS.DATABASES WHERE name = ''KISS_ZH_PROD_VORTAG'') BEGIN
  ALTER DATABASE [KISS_ZH_PROD_VORTAG] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
END
GO

RESTORE DATABASE [KISS_ZH_PROD_VORTAG] 
FROM  DISK = N''I:\BakTrc\mssql2008\Backup\KISS_PROD\kiss_zh.bak'' WITH  FILE = 1,

MOVE N''KiSS_ZH_Primary'' TO N''I:\Database\mssql2008\KISS_ZH_PROD_VORTAG\KISS_ZH_PROD_VORTAG.mdf'',  
MOVE N''KiSS_ZH_Data_2'' TO N''I:\Database\mssql2008\KISS_ZH_PROD_VORTAG\KISS_ZH_PROD_VORTAG_Archiv.ndf'',  
MOVE N''KiSS_ZH_Daten1'' TO N''I:\Database\mssql2008\KISS_ZH_PROD_VORTAG\KISS_ZH_PROD_VORTAG_Daten1.ndf'',  
MOVE N''KiSS_ZH_Daten2'' TO N''I:\Database\mssql2008\KISS_ZH_PROD_VORTAG\KISS_ZH_PROD_VORTAG_Daten2.ndf'',  
MOVE N''KiSS_ZH_Daten3'' TO N''I:\Database\mssql2008\KISS_ZH_PROD_VORTAG\KISS_ZH_PROD_VORTAG_Daten3.ndf'',  
MOVE N''KiSS_ZH_System'' TO N''I:\Database\mssql2008\KISS_ZH_PROD_VORTAG\KISS_ZH_PROD_VORTAG_System.ndf'',
MOVE N''KISS_ZH_Logging'' TO N''I:\Database\mssql2008\KISS_ZH_PROD_VORTAG\KISS_ZH_PROD_VORTAG_Logging.ndf'',
MOVE N''KiSS_ZH_Log'' TO N''I:\TransLog\mssql2008\KISS_ZH_PROD_VORTAG\KISS_ZH_PROD_VORTAG_log.LDF'', 

NOUNLOAD,  REPLACE,  STATS = 10

GO', 
    @database_name=N'master', 
    @output_file_name=N'I:\Data\MSSQL10.SOZ_KISS_D\MSSQL\Log\RESTORE_VORTAG_ZH$(ESCAPE_NONE(STRTDT))-$(ESCAPE_NONE(STRTTM)).log', 
    @flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [XDocument umhängen]    Script Date: 07/16/2014 15:49:57 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'XDocument umhängen', 
    @step_id=2, 
    @cmdexec_success_code=0, 
    @on_success_action=3, 
    @on_success_step_id=0, 
    @on_fail_action=2, 
    @on_fail_step_id=0, 
    @retry_attempts=0, 
    @retry_interval=0, 
    @os_run_priority=0, @subsystem=N'TSQL', 
    @command=N'exec [KISS_ZH_PROD_VORTAG].dbo.sp_rename ''XDocument'', ''XDocument_view'', ''OBJECT''
exec [KISS_ZH_PROD_VORTAG].dbo.sp_rename ''XDocument_table'', ''XDocument'', ''OBJECT''', 
    @database_name=N'master', 
    @flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [User berechtigen]    Script Date: 07/16/2014 15:49:57 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'User berechtigen', 
    @step_id=3, 
    @cmdexec_success_code=0, 
    @on_success_action=3, 
    @on_success_step_id=0, 
    @on_fail_action=2, 
    @on_fail_step_id=0, 
    @retry_attempts=0, 
    @retry_interval=0, 
    @os_run_priority=0, @subsystem=N'TSQL', 
    @command=N'USE [KISS_ZH_PROD_VORTAG]
GO

ALTER USER [KiSS3] WITH DEFAULT_SCHEMA=[dbo], LOGIN =  [KiSS3]

EXEC sp_addrolemember ''db_owner'', ''KiSS3''

EXEC sp_changedbowner ''sa''', 
    @database_name=N'master', 
    @flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Lock/Unlock DB-unabhängig machen]    Script Date: 07/16/2014 15:49:57 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Lock/Unlock DB-unabhängig machen', 
    @step_id=4, 
    @cmdexec_success_code=0, 
    @on_success_action=3, 
    @on_success_step_id=0, 
    @on_fail_action=2, 
    @on_fail_step_id=0, 
    @retry_attempts=0, 
    @retry_interval=0, 
    @os_run_priority=0, @subsystem=N'TSQL', 
    @command=N'USE [KISS_ZH_PROD_VORTAG]
GO
ALTER PROCEDURE [dbo].[spXDocument_Lock]
(
  @DocumentID INT,
  @CheckoutUserID INT,
  @CheckoutFilename VARCHAR(MAX),
  @CheckoutMachinename VARCHAR(MAX),
  @IsTemplate BIT
)
AS
BEGIN
  -------------------------------------------------------------------------------
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  -------------------------------------------------------------------------------
  SET NOCOUNT ON
  
  -------------------------------------------------------------------------------
  -- validate
  -------------------------------------------------------------------------------
  IF (ISNULL(@DocumentID, -1) < 1 OR ISNULL(@CheckOutUserID, -1) < 1 
      OR @CheckoutFilename IS NULL OR @CheckoutMachinename IS NULL
      OR @IsTemplate IS NULL)
  BEGIN
    -- invalid paramters, do not continue, throw back error to caller
    -- do not change error message without changing error Message in XDocFileHandler and others
    RAISERROR(''LockInvalidParameters'' , 18, 1)
    RETURN
  END
  
  -------------------------------------------------------------------------------
  -- vars II.
  -------------------------------------------------------------------------------
  -- declare vars
  DECLARE @tmpCheckoutUserID INT
  DECLARE @tmpCheckoutDate DATETIME
  DECLARE @tmpUserName VARCHAR(200)
  DECLARE @tmpCheckoutFilename VARCHAR(MAX)
  DECLARE @tmpCheckoutMachinename VARCHAR(MAX)

  -------------------------------------------------------------------------------
  -- get current checked-out values
  -- ensure transaction was started from outer call of stored procedure
  -------------------------------------------------------------------------------
  IF @IsTemplate = 1
  BEGIN
    -- using XDocTemplate
    SELECT @tmpCheckoutUserID      = DOC.CheckOut_UserID,
           @tmpCheckoutDate        = DOC.CheckOut_Date,
           @tmpCheckoutFilename    = DOC.CheckOut_Filename,
           @tmpCheckoutMachinename = DOC.CheckOut_Machine,
           @tmpUserName            = USR.LastName + ISNULL('' '' + USR.FirstName, '''')
    FROM dbo.XDocTemplate DOC
      LEFT JOIN dbo.XUser USR WITH (READUNCOMMITTED) ON USR.UserID = DOC.CheckOut_UserID
    WHERE DOC.DocTemplateID = @DocumentID
  END ELSE
  BEGIN
    -- using table XDocument by using view XDocument
    SELECT @tmpCheckoutUserID      = DOC.CheckOut_UserID,
           @tmpCheckoutDate        = DOC.CheckOut_Date,
           @tmpCheckoutFilename    = DOC.CheckOut_Filename,
           @tmpCheckoutMachinename = DOC.CheckOut_Machine,
           @tmpUserName            = USR.LastName + ISNULL('' '' + USR.FirstName, '''')
    FROM dbo.XDocument DOC
      LEFT JOIN dbo.XUser USR WITH (READUNCOMMITTED) ON USR.UserID = DOC.CheckOut_UserID
    WHERE DOC.DocumentID = @DocumentID
  END

  -------------------------------------------------------------------------------
  -- check for existing chekcouts
  -------------------------------------------------------------------------------
  IF (@tmpCheckoutUserID IS NOT NULL AND @tmpCheckoutUserID != @CheckoutUserID)
  BEGIN
    -- file locked by other user
    -- do not change error message without changing error Message in XDocFileHandler and others
    RAISERROR(''FileIsLockedByAnotherUser'' , 18, 1)
    RETURN
  END
  IF (@tmpCheckoutUserID IS NOT NULL AND @tmpCheckoutUserID = @CheckoutUserID)
  BEGIN
    -- file locked by the actual user
    -- do not change error message without changing error Message in XDocFileHandler and others
    RAISERROR(''FileIsLockedByActualUser'' , 18, 1)
    RETURN
  END

  -------------------------------------------------------------------------------
  -- no error occured, lock the document
  -------------------------------------------------------------------------------
  IF @IsTemplate = 1
  BEGIN
    -- ------------------------------------------------------------------------------------------------------
    -- using XDocTemplate
    --
    -- ATTENTION: 
    -- never change the DB for different customers (e.g. KISS4_BSS_MasterDev_DOC.dbo.XDocTemplate)
    -- XDocTemplate is always stored in the main DB, never in the document DB, for any customer
    -- ------------------------------------------------------------------------------------------------------
    UPDATE dbo.XDocTemplate SET
      CheckOut_UserID = @CheckoutUserID, 
      CheckOut_Date = GETDATE(), 
      CheckOut_Filename = @CheckoutFilename, 
      CheckOut_Machine = @CheckoutMachinename
    WHERE DocTemplateID = @DocumentID
  END 
  ELSE
  BEGIN
    -- ------------------------------------------------------------------------------------------------------
    -- using XDocument
    -- 
    -- ATTENTION: 
    -- KISS4_BSS_MasterDev_DOC.dbo.XDocument have to be modified für different customers !!!
    -- ------------------------------------------------------------------------------------------------------
    UPDATE dbo.XDocument SET
      CheckOut_UserID = @CheckoutUserID, 
      CheckOut_Date = GETDATE(), 
      CheckOut_Filename = @CheckoutFilename, 
      CheckOut_Machine = @CheckoutMachinename
    WHERE DocumentID = @DocumentID
  END
END
GO

USE [KISS_ZH_PROD_VORTAG]
GO
ALTER PROCEDURE [dbo].[spXDocument_UnLock]
(
  @DocumentID INT,
  @IsTemplate BIT
)
AS
BEGIN
  -------------------------------------------------------------------------------
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  -------------------------------------------------------------------------------
  SET NOCOUNT ON

  -------------------------------------------------------------------------------
  -- validate
  -------------------------------------------------------------------------------
  IF (ISNULL(@DocumentID, -1) < 1 OR @IsTemplate IS NULL)
  BEGIN
    -- invalid paramters, do not continue, throw back error to caller
    -- do not change error message without changing error Message in XDocFileHandler and others
    RAISERROR(''UnLockInvalidParameters'' , 18, 1)
    RETURN
  END
  
  -- ---------------------------------------------------
  -- unlock documents
  -- ---------------------------------------------------
  IF @IsTemplate = 1
  BEGIN
    -- ------------------------------------------------------------------------------------------------------
    -- using XDocTemplate
    -- 
    -- ATTENTION: 
    -- never change the DB for different customers (e.g. KISS4_BSS_MasterDev_DOC.dbo.XDocTemplate)
    -- XDocTemplate is always stored in the main DB, never in the document DB, for any customer
    -- ------------------------------------------------------------------------------------------------------
    UPDATE dbo.XDocTemplate SET
      CheckOut_UserID = NULL, 
      CheckOut_Date = NULL, 
      CheckOut_Filename = NULL, 
      CheckOut_Machine = NULL
    WHERE DocTemplateID = @DocumentID
  END ELSE
  BEGIN
    -- ------------------------------------------------------------------------------------------------------
    -- using XDocument
    -- 
    -- ATTENTION: 
    -- KISS4_BSS_MasterDev_DOC.dbo.XDocument have to be modified für different customers !!!
    -- ------------------------------------------------------------------------------------------------------
    UPDATE dbo.XDocument SET
      CheckOut_UserID = NULL, 
      CheckOut_Date = NULL, 
      CheckOut_Filename = NULL, 
      CheckOut_Machine = NULL
    WHERE DocumentID = @DocumentID
  END
END

GO', 
    @database_name=N'master', 
    @flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Schnittstellen-Config-Werte ungültig setzen]    Script Date: 07/16/2014 15:49:57 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Schnittstellen-Config-Werte ungültig setzen', 
    @step_id=5, 
    @cmdexec_success_code=0, 
    @on_success_action=3, 
    @on_success_step_id=0, 
    @on_fail_action=2, 
    @on_fail_step_id=0, 
    @retry_attempts=0, 
    @retry_interval=0, 
    @os_run_priority=0, @subsystem=N'TSQL', 
    @command=N'USE [KISS_ZH_PROD_VORTAG]
GO
UPDATE XConfig
SET DatumVon = CONVERT(datetime, ''30000101'')
WHERE KeyPath IN (
''System\Schnittstellen\PSCD\PSCDNotificationWebServiceURL'',
''System\Schnittstellen\PSCD\PSCDWebServiceURL'',
''System\Schnittstellen\BackgroundWorkerService\BackgroundWorkerWebServiceURL'')
', 
    @database_name=N'master', 
    @flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Passwörter setzen]    Script Date: 07/16/2014 15:49:57 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Passwörter setzen', 
    @step_id=6, 
    @cmdexec_success_code=0, 
    @on_success_action=3, 
    @on_success_step_id=0, 
    @on_fail_action=2, 
    @on_fail_step_id=0, 
    @retry_attempts=0, 
    @retry_interval=0, 
    @os_run_priority=0, @subsystem=N'TSQL', 
    @command=N'USE [KISS_ZH_PROD_VORTAG]
GO

INSERT INTO dbo.HistoryVersion(AppUser) VALUES(''restore'');

UPDATE dbo.XUser
SET PAsswordHash = ''qRA14B1yQ8g='';', 
    @database_name=N'master', 
    @flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [zweistufiges Login]    Script Date: 07/16/2014 15:49:57 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'zweistufiges Login', 
    @step_id=7, 
    @cmdexec_success_code=0, 
    @on_success_action=3, 
    @on_success_step_id=0, 
    @on_fail_action=2, 
    @on_fail_step_id=0, 
    @retry_attempts=0, 
    @retry_interval=0, 
    @os_run_priority=0, @subsystem=N'TSQL', 
    @command=N'USE KISS_ZH_PROD_VORTAG;

UPDATE CFG 
  SET ValueVarchar = ''f1bHmUlteSA=''
FROM XConfig CFG
WHERE KeyPath = ''System\Allgemein\Benutzername_TechnischerBenutzer''

UPDATE CFG 
  SET ValueVarchar = ''TNCVFBpHDUBfXID3OAbNK0U+L4apiRnA''
FROM XConfig CFG
WHERE KeyPath = ''System\Allgemein\Passwort_TechnischerBenutzer''
', 
    @database_name=N'master', 
    @flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [VIS-Views auf LinkedServer VMB0004\VMB_I umbiegen]    Script Date: 07/16/2014 15:49:57 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'VIS-Views auf LinkedServer VMB0004\VMB_I umbiegen', 
    @step_id=8, 
    @cmdexec_success_code=0, 
    @on_success_action=3, 
    @on_success_step_id=0, 
    @on_fail_action=2, 
    @on_fail_step_id=0, 
    @retry_attempts=0, 
    @retry_interval=0, 
    @os_run_priority=0, @subsystem=N'TSQL', 
    @command=N'USE [KISS_ZH_PROD_VORTAG]
GO
{Include:vwVIS_BERICHT:DISABLEAPPENDERS:REPLACE=',''}
{Include:vwVIS_MASSNAHMEN_HIST:DISABLEAPPENDERS:REPLACE=',''}
{Include:vwVIS_DOSSIER:DISABLEAPPENDERS:REPLACE=',''}
{Include:vwVIS_MANDATSTRAEGER:DISABLEAPPENDERS:REPLACE=',''}
{Include:vwVIS_MANDATSTRAEGER_SIMPLE:DISABLEAPPENDERS:REPLACE=',''}
{Include:vwVIS_MASSNAHMEN:DISABLEAPPENDERS:REPLACE=',''}
{Include:vwVIS_ABTEILUNG:DISABLEAPPENDERS:REPLACE=',''}
{Include:vwVIS_BERICHT:DISABLEAPPENDERS:REPLACE=',''}
{Include:vwVIS_OPERATION:DISABLEAPPENDERS:REPLACE=',''}
GO
', 
    @database_name=N'master', 
    @flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Configwert DBName setzen]    Script Date: 07/16/2014 15:49:57 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Configwert DBName setzen', 
    @step_id=9, 
    @cmdexec_success_code=0, 
    @on_success_action=4, 
    @on_success_step_id=10, 
    @on_fail_action=2, 
    @on_fail_step_id=0, 
    @retry_attempts=0, 
    @retry_interval=0, 
    @os_run_priority=0, @subsystem=N'TSQL', 
    @command=N'USE KISS_ZH_PROD_VORTAG
GO

UPDATE XConfig
SET ValueVarchar = ''KISS_ZH_PROD_VORTAG''
WHERE KeyPath = ''System\Allgemein\DbName''', 
    @database_name=N'master', 
    @flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [User unlocken und Adminrechte geben.]    Script Date: 07/16/2014 15:49:57 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'User unlocken und Adminrechte geben.', 
    @step_id=10, 
    @cmdexec_success_code=0, 
    @on_success_action=1, 
    @on_success_step_id=0, 
    @on_fail_action=2, 
    @on_fail_step_id=0, 
    @retry_attempts=0, 
    @retry_interval=0, 
    @os_run_priority=0, @subsystem=N'TSQL', 
    @command=N'USE KISS_ZH_PROD_VORTAG
GO

INSERT INTO dbo.HistoryVersion (AppUser)
                VALUES (''diag_admin'')
                SELECT SCOPE_IDENTITY()

UPDATE USR
 SET IsLocked = 0,
     IsUserAdmin = 1,
  IsUserBIAGAdmin = 1
--SELECT USR.* 
FROM XUser USR
WHERE LogonName = ''diag_admin'';', 
    @database_name=N'master', 
    @flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_update_job @job_id = @jobId, @start_step_id = 1
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobschedule @job_id=@jobId, @name=N'Nightly 3am', 
    @enabled=1, 
    @freq_type=4, 
    @freq_interval=1, 
    @freq_subday_type=1, 
    @freq_subday_interval=0, 
    @freq_relative_interval=0, 
    @freq_recurrence_factor=0, 
    @active_start_date=20080820, 
    @active_end_date=99991231, 
    @active_start_time=40000, 
    @active_end_time=235959, 
    @schedule_uid=N'f9880d0c-7392-4753-a158-fb74e240c0ea'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobschedule @job_id=@jobId, @name=N'test', 
    @enabled=0, 
    @freq_type=1, 
    @freq_interval=0, 
    @freq_subday_type=0, 
    @freq_subday_interval=0, 
    @freq_relative_interval=0, 
    @freq_recurrence_factor=0, 
    @active_start_date=20130122, 
    @active_end_date=99991231, 
    @active_start_time=93500, 
    @active_end_time=235959, 
    @schedule_uid=N'603a427c-84ff-4adf-83c8-098fd82695c2'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobserver @job_id = @jobId, @server_name = N'(local)'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
COMMIT TRANSACTION
GOTO EndSave
QuitWithRollback:
    IF (@@TRANCOUNT > 0) ROLLBACK TRANSACTION
EndSave:

GO

