CREATE TABLE [dbo].[BFSWert](
	[BFSWertID] [int] IDENTITY(1,1) NOT NULL,
	[BFSDossierID] [int] NOT NULL,
	[BFSDossierPersonID] [int] NULL,
	[BFSFrageID] [int] NOT NULL,
	[Wert] [sql_variant] NULL,
	[PlausiFehler] [varchar](max) NULL,
	[BFSWertTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BFSWert] PRIMARY KEY CLUSTERED 
(
	[BFSWertID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3],
 CONSTRAINT [IX_BFSWert] UNIQUE NONCLUSTERED 
(
	[BFSDossierID] ASC,
	[BFSDossierPersonID] ASC,
	[BFSFrageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_BFSWert_BFSDossierID_BFSFrageID_BFSDossierPersonID_PlausiFehler] ON [dbo].[BFSWert] 
(
	[BFSDossierID] ASC,
	[BFSFrageID] ASC,
	[BFSDossierPersonID] ASC
)
INCLUDE ( [PlausiFehler]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für BFSWert Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BFSWert', @level2type=N'COLUMN',@level2name=N'BFSWertID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BFSWert_BFSDossier) => BFSDossier.BFSDossierID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BFSWert', @level2type=N'COLUMN',@level2name=N'BFSDossierID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BFSWert_BFSDossierPerson) => BFSDossierPerson.BFSDossierPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BFSWert', @level2type=N'COLUMN',@level2name=N'BFSDossierPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BFSWert_BFSFrage) => BFSFrage.BFSFrageID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BFSWert', @level2type=N'COLUMN',@level2name=N'BFSFrageID'
GO

ALTER TABLE [dbo].[BFSWert]  WITH CHECK ADD  CONSTRAINT [FK_BFSWert_BFSDossier] FOREIGN KEY([BFSDossierID])
REFERENCES [dbo].[BFSDossier] ([BFSDossierID])
GO

ALTER TABLE [dbo].[BFSWert] CHECK CONSTRAINT [FK_BFSWert_BFSDossier]
GO

ALTER TABLE [dbo].[BFSWert]  WITH CHECK ADD  CONSTRAINT [FK_BFSWert_BFSDossierPerson] FOREIGN KEY([BFSDossierPersonID])
REFERENCES [dbo].[BFSDossierPerson] ([BFSDossierPersonID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BFSWert] CHECK CONSTRAINT [FK_BFSWert_BFSDossierPerson]
GO

ALTER TABLE [dbo].[BFSWert]  WITH CHECK ADD  CONSTRAINT [FK_BFSWert_BFSFrage] FOREIGN KEY([BFSFrageID])
REFERENCES [dbo].[BFSFrage] ([BFSFrageID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BFSWert] CHECK CONSTRAINT [FK_BFSWert_BFSFrage]
GO