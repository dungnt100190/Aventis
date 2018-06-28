# using vNext image
FROM microsoft/mssql-server-linux
 
# create directory within SQL container for database files
RUN mkdir -p /var/opt/mssql/backup
 
#copy the database files from host to container
#ADD https://aventisstorage.file.core.windows.net/database-backups/KiSS_Standard_R4939.bak -o /var/opt/mssql/backup
COPY KiSS_Standard_R4939.bak /var/opt/mssql/backup

# set environment variables
ENV sa_password=D0102A72-7838-4078-9829-DBD038018C18
 
ENV ACCEPT_EULA=Y
 
#RUN /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "D0102A72-7838-4078-9829-DBD038018C18" -Q "RESTORE FILELISTONLY FROM DISK = '/var/opt/mssql/backup/KiSS_Standard_R4939.bak'"

#ENV attach_dbs="[{'dbName':'KiSS_Standard_R4939','dbFiles':['C:\\SQLServer\\DatabaseA.mdf','C:\\SQLServer\\DatabaseA_log.ldf']},{'dbName':'DatabaseB','dbFiles':['C:\\SQLServer\\DatabaseB.mdf','C:\\SQLServer\\DatabaseB_Data.ndf','C:\\SQLServer\\DatabaseB_log.ldf']},{'dbName':'DatabaseC','dbFiles':['C:\\SQLServer\\DatabaseC.mdf','C:\\SQLServer\\DatabaseC_log.ldf']}]"