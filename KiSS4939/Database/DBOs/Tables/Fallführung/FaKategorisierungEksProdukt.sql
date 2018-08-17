CREATE TABLE [dbo].[FaKategorisierungEksProdukt](
	[FaKategorisierungEksProduktID] [int] IDENTITY(1,1) NOT NULL,
	[OrgUnitID] [int] NOT NULL,
	[Text] [varchar](100) NOT NULL,
	[ShortText] [varchar](50) NOT NULL,
	[FaKategorieCode] [int] NOT NULL,
	[Frist] [int] NULL,
	[FaKategorisierungEksProduktFristTypCode] [int] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[FaKategorisierungEksProduktTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaKategorisierungEksProdukt] PRIMARY KEY CLUSTERED 
(
	[FaKategorisierungEksProduktID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_FaKategorisierungEksProdukt_OrgUnitID]    Script Date: 10/17/2012 16:22:14 ******/
CREATE NONCLUSTERED INDEX [IX_FaKategorisierungEksProdukt_OrgUnitID] ON [dbo].[FaKategorisierungEksProdukt] 
(
	[OrgUnitID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierungEksProdukt', @level2type=N'COLUMN',@level2name=N'FaKategorisierungEksProduktID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf XOrgUnit' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierungEksProdukt', @level2type=N'COLUMN',@level2name=N'OrgUnitID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Text, der im Dropdown angezeigt wird' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierungEksProdukt', @level2type=N'COLUMN',@level2name=N'Text'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Text, der im Fallnavigator angezeigt wird' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierungEksProdukt', @level2type=N'COLUMN',@level2name=N'ShortText'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die Anzahl Tage/Monate/Jahre (abhängig von FaKategorisierungEksProduktFristTypCode) für die Berechnung des Felds ''Frist''' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierungEksProdukt', @level2type=N'COLUMN',@level2name=N'Frist'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der Typ des Felds ''Frist'' (Tag/Monat/Jahr)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierungEksProdukt', @level2type=N'COLUMN',@level2name=N'FaKategorisierungEksProduktFristTypCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierungEksProdukt', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierungEksProdukt', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierungEksProdukt', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierungEksProdukt', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierungEksProdukt', @level2type=N'COLUMN',@level2name=N'FaKategorisierungEksProduktTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Lucas Loreggia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierungEksProdukt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wird für Auswahl EKS-Produkt auf der Maske Fa - Kategorisierung verwendet (an Stelle einer LOV, wegen FK auf XOrgUnit)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierungEksProdukt'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Fallführung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierungEksProdukt'
GO

ALTER TABLE [dbo].[FaKategorisierungEksProdukt]  WITH CHECK ADD  CONSTRAINT [FK_FaKategorisierungEksProdukt_XOrgUnit] FOREIGN KEY([OrgUnitID])
REFERENCES [dbo].[XOrgUnit] ([OrgUnitID])
GO

ALTER TABLE [dbo].[FaKategorisierungEksProdukt] CHECK CONSTRAINT [FK_FaKategorisierungEksProdukt_XOrgUnit]
GO

ALTER TABLE [dbo].[FaKategorisierungEksProdukt] ADD  CONSTRAINT [DF_FaKategorisierungEksProdukt_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[FaKategorisierungEksProdukt] ADD  CONSTRAINT [DF_FaKategorisierungEksProdukt_Modified]  DEFAULT (getdate()) FOR [Modified]
GO
