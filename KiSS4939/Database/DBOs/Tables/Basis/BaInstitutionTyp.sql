CREATE TABLE [dbo].[BaInstitutionTyp](
	[BaInstitutionTypID] [int] IDENTITY(1,1) NOT NULL,
	[OrgUnitID] [int] NULL,
	[Name] [varchar](255) NOT NULL,
	[NameTID] [int] NULL,
	[Aktiv] [bit] NOT NULL,
	[Bemerkung] [varchar](max) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[BaInstitutionTypTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaInstitutionTyp] PRIMARY KEY CLUSTERED 
(
	[BaInstitutionTypID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_BaInstitutionTyp_OrgUnitID] ON [dbo].[BaInstitutionTyp] 
(
	[OrgUnitID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für BaInstitutionTyp Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionTyp', @level2type=N'COLUMN',@level2name=N'BaInstitutionTypID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf XOrgUnit.OrgUnitID, um einen Typ einer Abteilung zuzuweisen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionTyp', @level2type=N'COLUMN',@level2name=N'OrgUnitID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name/Bezeichnung eines Types' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionTyp', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TID der Name-Spalte, wird für die Mehrsprachigkeit verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionTyp', @level2type=N'COLUMN',@level2name=N'NameTID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob ein Typ aktiv verwendet wird oder nicht' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionTyp', @level2type=N'COLUMN',@level2name=N'Aktiv'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zusätzliche Bemerkungen eines Types' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionTyp', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionTyp', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionTyp', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionTyp', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionTyp', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Records, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionTyp', @level2type=N'COLUMN',@level2name=N'BaInstitutionTypTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Samuel Psota, Christoph Jäggi' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionTyp'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mögliche Typen einer Institution, in Verwendung mit der Tabelle BaInstitution_BaInstitutionTyp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionTyp'
GO

ALTER TABLE [dbo].[BaInstitutionTyp]  WITH CHECK ADD  CONSTRAINT [FK_BaInstitutionTyp_XOrgUnit] FOREIGN KEY([OrgUnitID])
REFERENCES [dbo].[XOrgUnit] ([OrgUnitID])
GO

ALTER TABLE [dbo].[BaInstitutionTyp] CHECK CONSTRAINT [FK_BaInstitutionTyp_XOrgUnit]
GO

ALTER TABLE [dbo].[BaInstitutionTyp] ADD  CONSTRAINT [DF_BaInstitutionTyp_Aktiv]  DEFAULT ((0)) FOR [Aktiv]
GO

ALTER TABLE [dbo].[BaInstitutionTyp] ADD  CONSTRAINT [DF_BaInstitutionTyp_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[BaInstitutionTyp] ADD  CONSTRAINT [DF_BaInstitutionTyp_Modified]  DEFAULT (getdate()) FOR [Modified]
GO