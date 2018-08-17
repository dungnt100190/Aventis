/*
Ablösung der in KiSS-integrierten Performance-Messung in XLog. 

Skripts von Guido Wymann. 

Skript 1_cre_Trace_Procedure_XLog.sql erstellt eine Prozedur in der master-DB mit den Trace-Parameter

Script 2_cre_Start_Trace_Job.sql erstellt einen SQL-Job, welcher täglich um 00:05 Uhr den Trace für 23h55min startet. 

Die Trace-Files werden mit Datum versehen, so dass es pro Tag 1 Trace-File gibt. Ich schlage vor, jeweils das File vom Vortag in eine separate Instanz
und DB zu laden, um so wie gewohnt mit SQL-Queries Abfragen zu erstellen. Folgende Events werden getraced, welche länger als 5 Sekunden dauern.
 */

USE [master]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[SQLTrace_XLog] 
@path nvarchar(128), 
@duration smallint 
as 

declare @tracestarttime datetime 
declare @TraceID int 
declare @options int 
declare @filename nvarchar(245) 
declare @filesize bigint 
declare @tracestoptime datetime 
declare @createcode int 
declare @on bit 
declare @startcode int
declare @maxduration bigint
 
set @tracestarttime = current_timestamp 

/* Set the name of the trace file. */ 
set @filename = 'XLog' +
cast(year(current_timestamp) as varchar) + 
cast(month(current_timestamp) as varchar) + 
cast(day(current_timestamp) as varchar) 
set @options = 2 
set @filename = @path + N'\' + @filename 
set @filesize = 20 
set @maxduration = 1435

/* You can change the first parameter in the dateadd function to set how long your trace will be 
For example, if it is hh, the trace will last @duration hours */ 

set @tracestoptime = dateadd(mi, @duration, @tracestarttime) 
set @on = 1 

--set up the trace 
exec @createcode = sp_trace_create  @TraceID = @TraceID output,  @options = @options,  
 @tracefile = @filename,   @maxfilesize = @filesize,  @stoptime = @tracestoptime 
if @createcode = 0 

--trace created 
 begin 
 --set events and columns 
 
 -- Set the events
exec sp_trace_setevent @TraceID, 10, 15, @on
exec sp_trace_setevent @TraceID, 10, 16, @on
exec sp_trace_setevent @TraceID, 10, 9, @on
exec sp_trace_setevent @TraceID, 10, 17, @on
exec sp_trace_setevent @TraceID, 10, 10, @on
exec sp_trace_setevent @TraceID, 10, 18, @on
exec sp_trace_setevent @TraceID, 10, 11, @on
exec sp_trace_setevent @TraceID, 10, 12, @on
exec sp_trace_setevent @TraceID, 10, 13, @on
exec sp_trace_setevent @TraceID, 10, 6, @on
exec sp_trace_setevent @TraceID, 10, 14, @on
exec sp_trace_setevent @TraceID, 43, 15, @on
exec sp_trace_setevent @TraceID, 43, 1, @on
exec sp_trace_setevent @TraceID, 43, 9, @on
exec sp_trace_setevent @TraceID, 43, 10, @on
exec sp_trace_setevent @TraceID, 43, 11, @on
exec sp_trace_setevent @TraceID, 43, 12, @on
exec sp_trace_setevent @TraceID, 43, 13, @on
exec sp_trace_setevent @TraceID, 43, 6, @on
exec sp_trace_setevent @TraceID, 43, 14, @on
exec sp_trace_setevent @TraceID, 45, 16, @on
exec sp_trace_setevent @TraceID, 45, 1, @on
exec sp_trace_setevent @TraceID, 45, 9, @on
exec sp_trace_setevent @TraceID, 45, 17, @on
exec sp_trace_setevent @TraceID, 45, 10, @on
exec sp_trace_setevent @TraceID, 45, 18, @on
exec sp_trace_setevent @TraceID, 45, 11, @on
exec sp_trace_setevent @TraceID, 45, 12, @on
exec sp_trace_setevent @TraceID, 45, 13, @on
exec sp_trace_setevent @TraceID, 45, 6, @on
exec sp_trace_setevent @TraceID, 45, 14, @on
exec sp_trace_setevent @TraceID, 45, 15, @on
exec sp_trace_setevent @TraceID, 12, 15, @on
exec sp_trace_setevent @TraceID, 12, 16, @on
exec sp_trace_setevent @TraceID, 12, 1, @on
exec sp_trace_setevent @TraceID, 12, 9, @on
exec sp_trace_setevent @TraceID, 12, 17, @on
exec sp_trace_setevent @TraceID, 12, 6, @on
exec sp_trace_setevent @TraceID, 12, 10, @on
exec sp_trace_setevent @TraceID, 12, 14, @on
exec sp_trace_setevent @TraceID, 12, 18, @on
exec sp_trace_setevent @TraceID, 12, 11, @on
exec sp_trace_setevent @TraceID, 12, 12, @on
exec sp_trace_setevent @TraceID, 12, 13, @on

-- Set the Filters
declare @intfilter int
declare @bigintfilter bigint

exec sp_trace_setfilter @TraceID, 10, 0, 7, N'SQL Server Profiler - e0dc386c-476f-45cb-b39d-177a9fc552f2'
set @bigintfilter = 5000000
exec sp_trace_setfilter @TraceID, 13, 0, 4, @bigintfilter

--start the trace 
 exec @startcode = sp_trace_setstatus  @TraceID = @TraceID,  @status = 1 
 end
 if @startcode = 0 
 begin
  select 'Trace started at ' + cast(@tracestarttime as varchar) +    ' for ' +    cast(@duration as varchar)+ ' minutes; trace id is ' + cast(@TraceID as nvarchar) + '.'
 end else 
 begin 
  select 'Error starting trace.' 
 end 


