DECLARE @LinkedServer VARCHAR(255);
DECLARE @DataSrc VARCHAR(255);

SET @LinkedServer = 'kiss_linked_vis_server';
--SET @DataSrc = 'sozm9500'; -- ZH
SET @DataSrc = 'bisrv1029\a99tdbse02'; -- bisrv1029 (ex schinti)

IF (EXISTS (SELECT TOP 1 1 
            FROM sys.servers 
            WHERE [Name]=@LinkedServer))
BEGIN
  -- drop linked server
  EXEC sp_dropserver @LinkedServer, 'droplogins';
  
  -- info
  PRINT ('Info: Droped linked server before creating new instance: ' + CONVERT(VARCHAR, GETDATE(), 113));
END;

-- create new linked server to another MS SQL Server
EXEC sp_addlinkedserver   
   @server=@LinkedServer, 
   @srvproduct=N'',
   @provider=N'SQLNCLI', 
   @datasrc=@DataSrc;

/*  
--Test
EXECUTE SP_TABLES_EX @LinkedServer

SELECT *
FROM kiss_linked_vis_server.KiSS_ZH_VIS_Test.dbo.SD_BERICHTE_HIST

*/