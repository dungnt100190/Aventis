GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SstASVSExport_Eintrag](
  [SstASVSExport_EintragID] INT IDENTITY(1,1) NOT NULL,
	[SstASVSExportID] INT NOT NULL,
  [WhASVSEintragID] INT NOT NULL,
  [ASVSExportCode] INT,
  [Creator] VARCHAR(50) NOT NULL,
  [Created] DATETIME NOT NULL CONSTRAINT DF_SstASVSExport_Created DEFAULT (GETDATE()),
  [Modifier] VARCHAR(50) NOT NULL,
  [Modified] VARCHAR(50) NOT NULL CONSTRAINT DF_SstASVSExport_Modified DEFAULT (GETDATE()),
  [SstASVSExport_EintragTS] timestamp,
  CONSTRAINT PK_SstASVSExport_Eintrag PRIMARY KEY CLUSTERED 
  (
	  [SstASVSExport_EintragID] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beschreibt die Export-Art (normal oder zum löschen/ungültig erklären; siehe entsprechenden LOV-Wert)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstASVSExport_Eintrag', @level2type=N'COLUMN',@level2name=N'ASVSExportCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Verbindungstabelle für m:n Verknüfung zwischen SstASVSExport und WhASVSEintrag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstASVSExport_Eintrag'
GO
ALTER TABLE [dbo].[SstASVSExport_Eintrag] WITH CHECK ADD CONSTRAINT [FK_WhASVSEintrag_Eintrag_SstASVSExport] FOREIGN KEY([SstASVSExportID])
REFERENCES [dbo].[SstASVSExport] ([SstASVSExportID])
GO
ALTER TABLE [dbo].[SstASVSExport_Eintrag] WITH CHECK ADD CONSTRAINT [FK_WhASVSEintrag_Eintrag_WhASVSEintrag] FOREIGN KEY([WhASVSEintragID])
REFERENCES [dbo].[WhASVSEintrag] ([WhASVSEintragID])
GO
CREATE NONCLUSTERED INDEX [IX_SstASVSExport_WhASVSEintrag] ON [dbo].[SstASVSExport_Eintrag]
(
	[WhASVSEintragID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO
CREATE NONCLUSTERED INDEX [IX_SstASVSExport_SstASVSExport] ON [dbo].[SstASVSExport_Eintrag]
(
	[SstASVSExportID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO
SET ANSI_PADDING OFF
