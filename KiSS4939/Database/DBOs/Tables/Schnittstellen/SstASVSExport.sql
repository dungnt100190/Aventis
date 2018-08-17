GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SstASVSExport](
	[SstASVSExportID] INT IDENTITY(1,1) NOT NULL,
  [DatumExport] DATETIME,
  [Bemerkung] VARCHAR(400),
  [DocumentID] int,
	[Creator] VARCHAR(50) NOT NULL,
  [Created] DATETIME NOT NULL CONSTRAINT DF_SstASVSVersand_Created DEFAULT (GETDATE()),
	[Modifier] VARCHAR(50) NOT NULL,
  [Modified] VARCHAR(50) NOT NULL CONSTRAINT DF_SstASVSVersand_Modified DEFAULT (GETDATE()),
  [SstASVSExportTS] TIMESTAMP,
  CONSTRAINT PK_SstASVSExport PRIMARY KEY CLUSTERED 
  (
	  [SstASVSExportID] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der Primary Key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstASVSExport', @level2type=N'COLUMN',@level2name=N'SstASVSExportID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Export-Datum' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstASVSExport', @level2type=N'COLUMN',@level2name=N'DatumExport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ein beliebiger Benutzer-Kommentar zum Expoort-Eintrag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstASVSExport', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ein Verweis auf die Exportierte XML-Datei' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstASVSExport', @level2type=N'COLUMN',@level2name=N'DocumentID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der Ersteller des Eintrages' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstASVSExport', @level2type=N'COLUMN',@level2name=N'Creator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der Zeitpunkt des Erstellen des Datensatzes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstASVSExport', @level2type=N'COLUMN',@level2name=N'Created'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der letzte Benutzer, welcher den Datensatz verändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstASVSExport', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der Zeitpunkt der letzten Veränderung des Datensatzes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstASVSExport', @level2type=N'COLUMN',@level2name=N'Modified'
GO

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Jeder Tabellen Eintrag entspricht einem ASV-Export' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstASVSExport'

