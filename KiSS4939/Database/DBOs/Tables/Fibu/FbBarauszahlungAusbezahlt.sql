CREATE TABLE [dbo].[FbBarauszahlungAusbezahlt](
	[FbBarauszahlungAusbezahltID] [int] IDENTITY(1,1) NOT NULL,
	[FbBarauszahlungZyklusID] [int] NOT NULL,
	[FbBuchungID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[Datum] [datetime] NOT NULL,
	[Stichtag] [datetime] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[FbBarauszahlungAusbezahltTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FbBarauszahlungAusbezahlt] PRIMARY KEY CLUSTERED 
(
	[FbBarauszahlungAusbezahltID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_FbBarauszahlungAusbezahlt_FbBarauszahlungZyklusID]    Script Date: 01/22/2014 16:05:32 ******/
CREATE NONCLUSTERED INDEX [IX_FbBarauszahlungAusbezahlt_FbBarauszahlungZyklusID] ON [dbo].[FbBarauszahlungAusbezahlt] 
(
	[FbBarauszahlungZyklusID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_FbBarauszahlungAusbezahlt_FbBuchungID]    Script Date: 01/22/2014 16:05:32 ******/
CREATE NONCLUSTERED INDEX [IX_FbBarauszahlungAusbezahlt_FbBuchungID] ON [dbo].[FbBarauszahlungAusbezahlt] 
(
	[FbBuchungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_FbBarauszahlungAusbezahlt_UserID]    Script Date: 01/22/2014 16:05:32 ******/
CREATE NONCLUSTERED INDEX [IX_FbBarauszahlungAusbezahlt_UserID] ON [dbo].[FbBarauszahlungAusbezahlt] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAusbezahlt', @level2type=N'COLUMN',@level2name=N'FbBarauszahlungAusbezahltID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel von einem Barauszahlungszyklus' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAusbezahlt', @level2type=N'COLUMN',@level2name=N'FbBarauszahlungZyklusID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf der Buchung die erstellt wurde nach dem Auszahlen von der VM-Kasse' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAusbezahlt', @level2type=N'COLUMN',@level2name=N'FbBuchungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Benutzer welcher die Auszahlung ausgelöst hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAusbezahlt', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum wenn die Barauszahlung ausbezahlt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAusbezahlt', @level2type=N'COLUMN',@level2name=N'Datum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stichtag der Barauszahlung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAusbezahlt', @level2type=N'COLUMN',@level2name=N'Stichtag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAusbezahlt', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAusbezahlt', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAusbezahlt', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAusbezahlt', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAusbezahlt', @level2type=N'COLUMN',@level2name=N'FbBarauszahlungAusbezahltTS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'beinhaltet Dati für einen Zyklus wenn eine Barauszahlung ausbezahlt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBarauszahlungAusbezahlt'
GO

ALTER TABLE [dbo].[FbBarauszahlungAusbezahlt]  WITH CHECK ADD  CONSTRAINT [FK_FbBarauszahlungAusbezahlt_FbBarauszahlungZyklus] FOREIGN KEY([FbBarauszahlungZyklusID])
REFERENCES [dbo].[FbBarauszahlungZyklus] ([FbBarauszahlungZyklusID])
GO

ALTER TABLE [dbo].[FbBarauszahlungAusbezahlt] CHECK CONSTRAINT [FK_FbBarauszahlungAusbezahlt_FbBarauszahlungZyklus]
GO

ALTER TABLE [dbo].[FbBarauszahlungAusbezahlt]  WITH CHECK ADD  CONSTRAINT [FK_FbBarauszahlungAusbezahlt_FbBuchung] FOREIGN KEY([FbBuchungID])
REFERENCES [dbo].[FbBuchung] ([FbBuchungID])
GO

ALTER TABLE [dbo].[FbBarauszahlungAusbezahlt] CHECK CONSTRAINT [FK_FbBarauszahlungAusbezahlt_FbBuchung]
GO

ALTER TABLE [dbo].[FbBarauszahlungAusbezahlt]  WITH CHECK ADD  CONSTRAINT [FK_FbBarauszahlungAusbezahlt_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FbBarauszahlungAusbezahlt] CHECK CONSTRAINT [FK_FbBarauszahlungAusbezahlt_XUser]
GO

ALTER TABLE [dbo].[FbBarauszahlungAusbezahlt] ADD  CONSTRAINT [DF_FbBarauszahlungAusbezahlt_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[FbBarauszahlungAusbezahlt] ADD  CONSTRAINT [DF_FbBarauszahlungAusbezahlt_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


