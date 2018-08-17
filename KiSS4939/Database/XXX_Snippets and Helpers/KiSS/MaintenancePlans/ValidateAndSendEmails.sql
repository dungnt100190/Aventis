-------------------------------------------------------------------------------
-- no count
-------------------------------------------------------------------------------
SET NOCOUNT ON;

-------------------------------------------------------------------------------
-- init vars
-------------------------------------------------------------------------------
DECLARE @CRLF VARCHAR(10);
DECLARE @STAT_FAILED TINYINT;
DECLARE @STAT_SUCCEEDED TINYINT;
DECLARE @STAT_RETRY TINYINT;
DECLARE @STAT_CANCELED TINYINT;
DECLARE @STAT_INPROGRESS TINYINT;
DECLARE @EMAIL_TO NVARCHAR(100);
DECLARE @EMAIL_FROM NVARCHAR(50);

DECLARE @JobId UNIQUEIDENTIFIER;
DECLARE @JobName SYSNAME;
DECLARE @Today DATETIME;
DECLARE @Subject VARCHAR(200);
DECLARE @Body VARCHAR(MAX);
DECLARE @StepName SYSNAME;
DECLARE @Err_Severity INT;
DECLARE @RunDatetime DATETIME;
DECLARE @DBName SYSNAME;
DECLARE @Command VARCHAR(3200);
DECLARE @ErrMessage VARCHAR(1024);
DECLARE @RunStatus INT;
DECLARE @InstanceID INT;

-------------------------------------------------------------------------------
-- set constant vars
-------------------------------------------------------------------------------
-- constants for Job Status execution:
SET @STAT_FAILED     = 0;
SET @STAT_SUCCEEDED  = 1;
SET @STAT_RETRY      = 2;
SET @STAT_CANCELED   = 3;
SET @STAT_INPROGRESS = 4;
SET @Today           = GETDATE();

SET @CRLF = CHAR(10); -- + char(13)  -- carriage return & line feed
SET @EMAIL_TO   = 'GL-D-KiSS-DB@born.ch';
SET @EMAIL_FROM = 'GL-D-KiSS-DB@born.ch';

-------------------------------------------------------------------------------
-- loop all jobs
-------------------------------------------------------------------------------
-- setup cursor
DECLARE curAllJobs CURSOR FAST_FORWARD FOR
  SELECT JOB.job_id
  FROM msdb..sysjobs JOB;

-- iterate through cursor
OPEN curAllJobs;
WHILE (1 = 1)
BEGIN
  -- read next row and check if we have one
  FETCH NEXT 
  FROM curAllJobs 
  INTO @JobId;
  
  IF (@@FETCH_STATUS != 0)
  BEGIN
    BREAK;
  END;
  
  --===========================================================================
  -- <Cursor_Jobs>
  --===========================================================================
  PRINT ('Info: Processing current job: ' + CONVERT(VARCHAR(255), @JobId));
  
  -----------------------------------------------------------------------------
  -- reset vars for each entry
  -----------------------------------------------------------------------------
  SET @Body = '';

  -----------------------------------------------------------------------------
  -- init cursor for loop jobs
  -----------------------------------------------------------------------------
  DECLARE curFailedJobs CURSOR READ_ONLY FOR
    SELECT SJ.name,
           SJH.step_name,
           SJH.sql_severity,
           SJS.database_name ,
           run_datetime = CONVERT(DATETIME, LEFT(run_date, 4) + '/' +
                                            SUBSTRING(run_date, 5, 2) + '/' +
                                            RIGHT(run_date, 2) + ' ' + LEFT(STUFF('000000', 7 - LEN(run_time), LEN(run_time), CONVERT(VARCHAR(6), run_time)), 2) + ':' +
                                            SUBSTRING(STUFF('000000', 7 - LEN(run_time), LEN(run_time), CONVERT(VARCHAR(6), run_time)), 3, 2) + ':' + RIGHT(CASE WHEN run_time = 0 THEN '000000' ELSE run_time END, 2)),
           SJS.command,
           SJH.message,
           SJH.run_status,
           SJH.instance_id
    FROM msdb..sysjobs                      SJ
      INNER JOIN (SELECT instance_id,
                         job_id,
                         step_id,
                         step_name,
                         sql_message_id,
                         sql_severity,
                         message,
                         run_status,
                         run_duration,
                         operator_id_emailed,
                         operator_id_netsent,
                         operator_id_paged,
                         retries_attempted,
                         server,
                         run_date = CONVERT(VARCHAR(8), run_date),
                         run_time = CASE
                                      WHEN LEN(CONVERT(VARCHAR(8), run_time )) = 5 THEN '0' + CONVERT(VARCHAR(8), run_time)
                                      ELSE CONVERT(VARCHAR(8), run_time)
                                    END
                  FROM msdb..sysjobhistory) SJH ON SJH.job_id = SJ.job_id
      
      INNER JOIN msdb..sysjobsteps          SJS ON SJS.job_id = SJH.job_id
                                               AND SJS.step_id = SJH.step_id

      -- sjh_Min contains the most recent instance_id (an identity column) from where we should start checking for any failed status records.
      LEFT  JOIN (-- to account for when there is are multiple log history
                  SELECT HIS1.job_id,
                         instance_id = MAX(HIS1.instance_id)
                  FROM msdb..sysjobhistory HIS1
                  WHERE HIS1.job_id = @JobId
                    AND HIS1.step_id =0
                  GROUP BY HIS1.job_id
                   
                  UNION
                  
                  -- to account for when you run the job for the first time, there is no history, there will not be any records where the step_id=0.
                  SELECT HIS2.job_id,
                         instance_id = MIN(HIS2.instance_id)
                  FROM msdb..sysjobhistory HIS2
                  WHERE HIS2.job_id = @JobId
                    AND NOT EXISTS (SELECT TOP 1 1
                                    FROM msdb..sysjobhistory SHIS
                                    WHERE SHIS.job_id = @JobId
                                      AND SHIS.step_id = 0)
                  GROUP BY HIS2.job_id)     SJH_MIN ON SJH_MIN.job_id = SJ.job_id
                                                   AND SJH.instance_id > SJH_MIN.instance_id -- we only want the most recent error message(s).
    WHERE SJ.job_id = @JobId
      AND SJH.step_id <> 0                   -- exclude the job outcome step
      --AND SJH.run_status IN (@STAT_FAILED)   -- filter for only failed status (FIX: done later as we want to handle only latest)
    ORDER BY SJH.instance_id DESC;

  -----------------------------------------------------------------------------
  -- do cursor iterations
  -----------------------------------------------------------------------------
  OPEN curFailedJobs
  FETCH NEXT
  FROM curFailedJobs
  INTO @JobName, @StepName, @Err_Severity, @DBName, @RunDatetime, @Command, @ErrMessage, @RunStatus, @InstanceID;

  WHILE @@fetch_status = 0
  BEGIN
    -- check if last entry was successfully done
    IF (@RunStatus <> @STAT_FAILED)
    BEGIN
      -- cancel
      BREAK;
    END;
  
    -- Build the Email Body
    SET @Body = @Body +
                '--------------------------------------' + @CRLF +
                'StepName   = ' + ISNULL(@StepName, '<->') + @CRLF +
                'InstanceID = ' + ISNULL(CONVERT(VARCHAR(50), ISNULL(@InstanceID, '')), '<->') + @CRLF +
                'DBName     = ' + ISNULL(CONVERT(VARCHAR(50), ISNULL(@DBName, '')), '<->') + @CRLF +
                'RunDate    = ' + ISNULL(CONVERT(VARCHAR(50), @RunDatetime ), '<->') + @CRLF;

    IF (@Err_Severity <> 0)
    BEGIN
      SET @Body = @Body +
                'Severity   = ' + ISNULL(CONVERT(VARCHAR(10), @Err_Severity), '<->') + @CRLF;
    END;

    SET @Body = @Body +
                'Error      = ' + ISNULL(@ErrMessage, '<->') + @CRLF +
                'Command    = ' + ISNULL(@Command, '<->') + @CRLF + 
                '--------------------------------------' + @CRLF + @CRLF;

    FETCH NEXT
    FROM curFailedJobs
    INTO @JobName, @StepName, @Err_Severity, @DBName, @RunDatetime, @Command, @ErrMessage, @RunStatus, @InstanceID;
  END;

  CLOSE curFailedJobs;
  DEALLOCATE curFailedJobs;

  -----------------------------------------------------------------------------
  -- send email
  -----------------------------------------------------------------------------
  IF (RTRIM(@Body) <> '')
  BEGIN
    -- prepare message subject and body
    SET @Subject = 'Job [' + ISNULL(@JobName, '<->') + '] FAILED on Server [\\' + @@SERVERNAME + ']';
    SET @Body = 'JobName = ' + ISNULL(@JobName, '<->')  + @CRLF  +
                '======================================'+ @CRLF +
                @Body;

    -- debug only
    /*
    PRINT '*********************************';
    PRINT 'Message Length = ' + CONVERT(VARCHAR(20), LEN(@Body));
    PRINT '@Body = ' + @CRLF + @Body;
    PRINT '*********************************';
    --*/
    
    --/*
    -- send email
    EXEC msdb.dbo.sp_send_dbmail  @profile_name = 'KiSS_DBMail',
                                  @recipients = @EMAIL_TO,
                                  @Subject = @Subject,
                                  @body = @Body;  -- SQL2005+
    --*/
  END;
  --=============================================================================
  -- </Cursor_Jobs>
  --=============================================================================
END; -- [WHILE cursor]

-- clean up cursor
CLOSE curAllJobs;
DEALLOCATE curAllJobs;
GO