SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spAdmAngemeldeteBenutzer
GO
/*===============================================================================================
  $Revision: 4$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    exec spAdmAngemeldeteBenutzer
=================================================================================================*/

CREATE PROCEDURE spAdmAngemeldeteBenutzer
AS
SELECT
  Prozess           = P.spid,
  Benutzer          = CASE WHEN charindex('(',P.HostName) > 0 AND charindex(')',P.HostName) > 0
                      THEN (SELECT TOP 1 LastName + IsNull(', ' + FirstName,'')
                            FROM   XUser
                            WHERE  LogonName = (SubString(P.HostName,charindex('(',P.HostName) + 1, charindex(')',P.HostName) - charindex('(',P.HostName) - 1)) collate database_default
                            )
                      ELSE  P.loginame collate database_default
                      END,
  PC                = P.HostName,
  Status            = P.Status,
  [angemeldet seit] = CONVERT(varchar,P.login_time,120),
  [letztmals aktiv] = CONVERT(varchar,P.last_batch,120),
  [Anzahl Sperren]  = (SELECT count(*)
                       FROM   master.dbo.syslockinfo
                       WHERE  req_spid = P.spid AND
                              rsc_objid > 0 AND
                              rsc_indid = 0 AND
                              rsc_type = 5),
  [gesperrt durch]  = P.blocked,
  [Verursacher]     = CASE WHEN EXISTS (SELECT 1 FROM master.dbo.sysprocesses
                                        WHERE blocked = P.spid AND
                                        P.blocked = 0) 
                      THEN '!'
                      ELSE ''
                      END
FROM
  master..sysprocesses P
  INNER JOIN master..sysdatabases D on P.dbid = D.dbid
WHERE
  P.loginame = 'kiss3' AND
  D.Name = db_name() AND
  year(P.last_batch) <> 1900
ORDER BY Benutzer
