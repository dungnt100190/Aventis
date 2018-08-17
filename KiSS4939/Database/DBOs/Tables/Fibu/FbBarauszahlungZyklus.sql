CREATE TABLE [dbo].[FbBarauszahlungZyklus](
	[FbBarauszahlungZyklusID] [int] IDENTITY(1,1) NOT NULL,
	[FbBarauszahlungAuftragID] [int] NOT NULL,
	[DatumStart] [datetime] NOT NULL,
	[DauerNaechsteZahlung] [int] NOT NULL,
	[DauerTypCode] [int] NOT NULL,
	[WochentagCode] [int] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[FbBarauszahlungZyklusTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FbBarauszahlungZyklus] PRIMARY KEY CLUSTERED 
(
	[FbBarauszahlungZyklusID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_FbBarauszahlungZyklus_FbBarauszahlungAuftragID]    Script Date: 01/22/2014 16:06:11 ******/
CREATE NONCLUSTERED INDEX [IX_FbBarauszahlungZyklus_FbBarauszahlungAuftragID] ON [dbo].[FbBarauszahlungZyklus] 
(
	[FbBarauszahlungAuftragID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel von Barauszahlungszyklus' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungZyklus', @level2type=N'COLUMN',@level2name=N'FbBarauszahlungZyklusID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel von einem Barauszahlungsauftrag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungZyklus', @level2type=N'COLUMN',@level2name=N'FbBarauszahlungAuftragID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum der erste geplante Barauszahlung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungZyklus', @level2type=N'COLUMN',@level2name=N'DatumStart'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Desctiption', @value=N'Dauer bis zu nächste Barauszahlung je nach Dauertyp (Tage oder Monat)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungZyklus', @level2type=N'COLUMN',@level2name=N'DauerNaechsteZahlung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Enum DauerTyp (Tag, Monat)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungZyklus', @level2type=N'COLUMN',@level2name=N'DauerTypCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wochentag vom Zyklus. Wird verwendet wenn in der Periodizität vom Barauszahlungsauftrag ein Wochentag gesetzt ist.
Enum und LOV Wochentag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungZyklus', @level2type=N'COLUMN',@level2name=N'WochentagCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungZyklus', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungZyklus', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungZyklus', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungZyklus', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungZyklus', @level2type=N'COLUMN',@level2name=N'FbBarauszahlungZyklusTS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'beinhaltet Informationen für den Zyklus einer Barauszahlung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungZyklus'
GO

ALTER TABLE [dbo].[FbBarauszahlungZyklus]  WITH CHECK ADD  CONSTRAINT [FK_FbBarauszahlungZyklus_FbBarauszahlungAuftrag] FOREIGN KEY([FbBarauszahlungAuftragID])
REFERENCES [dbo].[FbBarauszahlungAuftrag] ([FbBarauszahlungAuftragID])
GO

ALTER TABLE [dbo].[FbBarauszahlungZyklus] CHECK CONSTRAINT [FK_FbBarauszahlungZyklus_FbBarauszahlungAuftrag]
GO

ALTER TABLE [dbo].[FbBarauszahlungZyklus] ADD  CONSTRAINT [DF_FbBarauszahlungZyklus_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[FbBarauszahlungZyklus] ADD  CONSTRAINT [DF_FbBarauszahlungZyklus_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


