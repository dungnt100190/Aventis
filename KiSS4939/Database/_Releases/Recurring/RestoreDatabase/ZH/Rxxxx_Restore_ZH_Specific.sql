USE [{DBName}];

--XDocument umhängen
IF NOT EXISTS(SELECT TOP 1 1 FROM sys.objects WHERE name = 'XDocument_view')
BEGIN
  exec [{DBName}].dbo.sp_rename 'XDocument', 'XDocument_view', 'OBJECT';
  exec [{DBName}].dbo.sp_rename 'XDocument_table', 'XDocument', 'OBJECT';
END;

-- VIS-Views umhängen
IF EXISTS (SELECT TOP 1 1 FROM master.dbo.sysservers WHERE srvname = '{VisServerName}') 
BEGIN
  {Include:vwVIS_BERICHT:NOGO}
  {Include:vwVIS_DOSSIER:NOGO}
  {Include:vwVIS_MANDATSTRAEGER:NOGO}
  {Include:vwVIS_MANDATSTRAEGER_SIMPLE:NOGO}
  {Include:vwVIS_MASSNAHMEN:NOGO}
  {Include:vwVIS_MASSNAHMEN_HIST:NOGO}
  {Include:vwVIS_ABTEILUNG:NOGO}
  {Inculde:vwVIS_OPERATION:NOGO}
GO

-- gleiches passwort für alle user
UPDATE dbo.XUser
SET PAsswordHash = 'qRA14B1yQ8g=';
