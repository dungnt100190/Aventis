CREATE TABLE [dbo].[EdKurs](
	[EdKursID] [int] IDENTITY(1,1) NOT NULL,
	[OrgUnitID] [int] NULL,
	[Bezeichnung] [varchar](255) NOT NULL,
	[BezeichnungTID] [int] NULL,
	[Aktiv] [bit] NOT NULL,
	[Bemerkungen] [varchar](2000) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[EdKursTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_EdKurs] PRIMARY KEY CLUSTERED 
(
	[EdKursID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_EdKurs_OrgUnitID] ON [dbo].[EdKurs] 
(
	[OrgUnitID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PrimaryKey, wird als ID benutzt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdKurs', @level2type=N'COLUMN',@level2name=N'EdKursID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf XOrgUnit.OrgUnitID, wird für die KGS-Zuweisung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdKurs', @level2type=N'COLUMN',@level2name=N'OrgUnitID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bezeichnung des Kurses' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdKurs', @level2type=N'COLUMN',@level2name=N'Bezeichnung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Multilanguage-TID der Bezeichnung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdKurs', @level2type=N'COLUMN',@level2name=N'BezeichnungTID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob Kurs aktiv oder inaktiv ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdKurs', @level2type=N'COLUMN',@level2name=N'Aktiv'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zusätzliche Bemerkungen zum Kurs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdKurs', @level2type=N'COLUMN',@level2name=N'Bemerkungen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdKurs', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdKurs', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdKurs', @level2type=N'COLUMN',@level2name=N'EdKursTS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kursverwaltung des Entlastungsdienstes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdKurs'
GO

ALTER TABLE [dbo].[EdKurs]  WITH CHECK ADD  CONSTRAINT [FK_EdKurs_XOrgUnit] FOREIGN KEY([OrgUnitID])
REFERENCES [dbo].[XOrgUnit] ([OrgUnitID])
GO

ALTER TABLE [dbo].[EdKurs] CHECK CONSTRAINT [FK_EdKurs_XOrgUnit]
GO

ALTER TABLE [dbo].[EdKurs] ADD  CONSTRAINT [DF_EdKurs_Aktiv]  DEFAULT ((0)) FOR [Aktiv]
GO

ALTER TABLE [dbo].[EdKurs] ADD  CONSTRAINT [DF_EdKurs_Created]  DEFAULT (getdate()) FOR [Created]
GO