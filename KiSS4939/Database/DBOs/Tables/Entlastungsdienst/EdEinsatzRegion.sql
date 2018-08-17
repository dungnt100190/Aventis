CREATE TABLE [dbo].[EdEinsatzRegion](
	[EdEinsatzRegionID] [int] IDENTITY(1,1) NOT NULL,
	[OrgUnitID] [int] NOT NULL,
	[Bezeichnung] [varchar](255) NOT NULL,
	[BezeichnungTID] [int] NULL,
	[Aktiv] [bit] NOT NULL CONSTRAINT [DF_EdEinsatzRegion_Aktiv]  DEFAULT ((0)),
	[Bemerkungen] [varchar](2000) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL CONSTRAINT [DF_EdEinsatzRegion_Created]  DEFAULT (getdate()),
	[EdEinsatzRegionTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_EdEinsatzRegion] PRIMARY KEY CLUSTERED 
(
	[EdEinsatzRegionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_EdEinsatzRegion_OrgUnitID]    Script Date: 03/16/2010 10:04:28 ******/
CREATE NONCLUSTERED INDEX [IX_EdEinsatzRegion_OrgUnitID] ON [dbo].[EdEinsatzRegion] 
(
	[OrgUnitID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PrimaryKey, wird als ID benutzt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzRegion', @level2type=N'COLUMN',@level2name=N'EdEinsatzRegionID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf XOrgUnit.OrgUnitID, wird für die KGS-Zuweisung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzRegion', @level2type=N'COLUMN',@level2name=N'OrgUnitID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bezeichnung der Einsatzregion' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzRegion', @level2type=N'COLUMN',@level2name=N'Bezeichnung'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Multilanguage-TID der Bezeichnung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzRegion', @level2type=N'COLUMN',@level2name=N'BezeichnungTID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob Einsatzregion aktiv oder inaktiv ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzRegion', @level2type=N'COLUMN',@level2name=N'Aktiv'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zusätzliche Bemerkungen zur Einsatzregion' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzRegion', @level2type=N'COLUMN',@level2name=N'Bemerkungen'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzRegion', @level2type=N'COLUMN',@level2name=N'Creator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzRegion', @level2type=N'COLUMN',@level2name=N'Created'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzRegion', @level2type=N'COLUMN',@level2name=N'EdEinsatzRegionTS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Verwaltung der Einsatzregionen des Entlastungsdienstes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatzRegion'
GO
ALTER TABLE [dbo].[EdEinsatzRegion]  WITH CHECK ADD  CONSTRAINT [FK_EdEinsatzRegion_XOrgUnit] FOREIGN KEY([OrgUnitID])
REFERENCES [dbo].[XOrgUnit] ([OrgUnitID])
GO
ALTER TABLE [dbo].[EdEinsatzRegion] CHECK CONSTRAINT [FK_EdEinsatzRegion_XOrgUnit]