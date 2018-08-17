CREATE TABLE [dbo].[BwAuswertungOrganisation](
	[BwAuswertungOrganisationID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[AbwesenheitKlient] [money] NULL,
	[AuswertungAm] [datetime] NULL,
	[BefristetBis] [datetime] NULL,
	[BwAustrittNachCode] [int] NULL,
	[BwEintrittVonCode] [int] NULL,
	[KostenBeitragKanton] [bit] NOT NULL,
	[KostenBeitragPI] [bit] NOT NULL,
	[KostenBSVBeitrag] [bit] NOT NULL,
	[KostenELEmpfaenger] [bit] NOT NULL,
	[KostenWeitereBeitraege] [bit] NOT NULL,
	[KostenSelbstzahler] [bit] NOT NULL,
	[LeistungIstBefristet] [bit] NOT NULL,
	[Vereinbarungen] [varchar](max) NULL,
	[ZieleErreicht] [int] NULL,
	[ZieleBegruendung] [varchar](max) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[BwAuswertungOrganisationTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BwAuswertungOrganisation] PRIMARY KEY CLUSTERED 
(
	[BwAuswertungOrganisationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_BwAuswertungOrganisation_FaLeistungID] UNIQUE NONCLUSTERED 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel in Form einer ID.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwAuswertungOrganisation', @level2type=N'COLUMN',@level2name=N'BwAuswertungOrganisationID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID der zugehörigen Leistung. Fremdschlüssel auf FaLeistung.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwAuswertungOrganisation', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zeitpunkt der Auswertung.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwAuswertungOrganisation', @level2type=N'COLUMN',@level2name=N'AuswertungAm'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code welcher festlegt ob Ziele ganz, teilweise oder nicht erreicht wurden.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwAuswertungOrganisation', @level2type=N'COLUMN',@level2name=N'ZieleErreicht'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Begründung zum Erreichungsgrad der Ziele' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwAuswertungOrganisation', @level2type=N'COLUMN',@level2name=N'ZieleBegruendung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kostenschlüssel zum Zeitpunkt der Vereinbarung - EL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwAuswertungOrganisation', @level2type=N'COLUMN',@level2name=N'KostenELEmpfaenger'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kostenschlüssel zum Zeitpunkt der Vereinbarung - BSV' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwAuswertungOrganisation', @level2type=N'COLUMN',@level2name=N'KostenBSVBeitrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kostenschlüssel zum Zeitpunkt der Vereinbarung - Selbstzahler' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwAuswertungOrganisation', @level2type=N'COLUMN',@level2name=N'KostenSelbstzahler'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Abwesenheit des Klienten in Wochen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwAuswertungOrganisation', @level2type=N'COLUMN',@level2name=N'AbwesenheitKlient'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wahr wenn die Leistung bis zu einem Zeitpunkt befristet ist. Sonst Falsch.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwAuswertungOrganisation', @level2type=N'COLUMN',@level2name=N'LeistungIstBefristet'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zeitpunkt des Endes der Leistung.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwAuswertungOrganisation', @level2type=N'COLUMN',@level2name=N'BefristetBis'
GO

EXEC sys.sp_addextendedproperty @name=N'LOVName', @value=N'BwEintrittVon' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwAuswertungOrganisation', @level2type=N'COLUMN',@level2name=N'BwEintrittVonCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Aus welchen Betreuungsettings Klienten/innen ins Begleitete Wohnen kommen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwAuswertungOrganisation', @level2type=N'COLUMN',@level2name=N'BwEintrittVonCode'
GO

EXEC sys.sp_addextendedproperty @name=N'LOVName', @value=N'BwAustrittNach' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwAuswertungOrganisation', @level2type=N'COLUMN',@level2name=N'BwAustrittNachCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'In welche Betreuungsettings die Klienten/innen gehen nach Abschluss der DL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwAuswertungOrganisation', @level2type=N'COLUMN',@level2name=N'BwAustrittNachCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Weitere Vereinbarungen.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwAuswertungOrganisation', @level2type=N'COLUMN',@level2name=N'Vereinbarungen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer welcher den Eintrag erstellt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwAuswertungOrganisation', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zeitpunkt zu welchem der Eintrag erstellt wurde.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwAuswertungOrganisation', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Benutzer welcher den Eintrag als letzer editiert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwAuswertungOrganisation', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zeitpunkt zu welchem der Eintrag als letztes modifiziert wurde.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwAuswertungOrganisation', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp für Konsistenzprüfung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwAuswertungOrganisation', @level2type=N'COLUMN',@level2name=N'BwAuswertungOrganisationTS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kosten Beitrag Kanton' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwAuswertungOrganisation', @level2type=N'COLUMN',@level2name=N'KostenBeitragKanton'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kosten Beitrag PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwAuswertungOrganisation', @level2type=N'COLUMN',@level2name=N'KostenBeitragPI'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kosten Weitere Beiträge' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwAuswertungOrganisation', @level2type=N'COLUMN',@level2name=N'KostenWeitereBeitraege'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Unbekannt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwAuswertungOrganisation'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabelle Auswertung und Organisation' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwAuswertungOrganisation'
GO

ALTER TABLE [dbo].[BwAuswertungOrganisation]  WITH CHECK ADD  CONSTRAINT [FK_BwAuswertungOrganisation_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BwAuswertungOrganisation] CHECK CONSTRAINT [FK_BwAuswertungOrganisation_FaLeistung]
GO

ALTER TABLE [dbo].[BwAuswertungOrganisation] ADD  CONSTRAINT [DF_BwAuswertungOrganisation_KostenELEmpfaenger]  DEFAULT ((0)) FOR [KostenELEmpfaenger]
GO

ALTER TABLE [dbo].[BwAuswertungOrganisation] ADD  CONSTRAINT [DF_BwAuswertungOrganisation_KostenBSVBeitrag]  DEFAULT ((0)) FOR [KostenBSVBeitrag]
GO

ALTER TABLE [dbo].[BwAuswertungOrganisation] ADD  CONSTRAINT [DF_BwAuswertungOrganisation_KostenSelbstzahler]  DEFAULT ((0)) FOR [KostenSelbstzahler]
GO

ALTER TABLE [dbo].[BwAuswertungOrganisation] ADD  CONSTRAINT [DF_BwAuswertungOrganisation_LeistungIstBefristet]  DEFAULT ((0)) FOR [LeistungIstBefristet]
GO

ALTER TABLE [dbo].[BwAuswertungOrganisation] ADD  CONSTRAINT [DF_BwAuswertungOrganisation_KostenBeitragKanton]  DEFAULT ((0)) FOR [KostenBeitragKanton]
GO

ALTER TABLE [dbo].[BwAuswertungOrganisation] ADD  CONSTRAINT [DF_BwAuswertungOrganisation_KostenBeitragPI]  DEFAULT ((0)) FOR [KostenBeitragPI]
GO

ALTER TABLE [dbo].[BwAuswertungOrganisation] ADD  CONSTRAINT [DF_BwAuswertungOrganisation_KostenWeitereBeitraege]  DEFAULT ((0)) FOR [KostenWeitereBeitraege]
GO

ALTER TABLE [dbo].[BwAuswertungOrganisation] ADD  CONSTRAINT [DF_BwAuswertungOrganisation_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[BwAuswertungOrganisation] ADD  CONSTRAINT [DF_BwAuswertungOrganisation_Modified]  DEFAULT (getdate()) FOR [Modified]
GO





