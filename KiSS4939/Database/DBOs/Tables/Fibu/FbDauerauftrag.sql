CREATE TABLE [dbo].[FbDauerauftrag](
	[FbDauerauftragID] [int] IDENTITY(1,1) NOT NULL,
	[Text] [varchar](200) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[SollKtoNr] [int] NOT NULL,
	[HabenKtoNr] [int] NOT NULL,
	[Betrag] [money] NOT NULL,
	[FbZahlungswegID] [int] NOT NULL,
	[DatumVon] [datetime] NOT NULL,
	[PeriodizitaetCode] [int] NOT NULL,
	[WochentagCode] [int] NULL,
	[Monatstag1] [int] NULL,
	[Monatstag2] [int] NULL,
	[VorWochenende] [bit] NOT NULL,
	[DatumBis] [datetime] NULL,
	[ReferenzNummer] [varchar](50) NULL,
	[Zahlungsgrund] [varchar](50) NULL,
	[Status] [int] NOT NULL,
	[FbDauerauftragTS] [timestamp] NOT NULL,
	[DauerauftragDokID] [int] NULL,
 CONSTRAINT [PK_FbDauerauftrag] PRIMARY KEY CLUSTERED 
(
	[FbDauerauftragID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_FbDauerauftrag_BaPersonID]    Script Date: 05/17/2013 10:41:22 ******/
CREATE NONCLUSTERED INDEX [IX_FbDauerauftrag_BaPersonID] ON [dbo].[FbDauerauftrag] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_FbDauerauftrag_FbZahlungswegID]    Script Date: 05/17/2013 10:41:22 ******/
CREATE NONCLUSTERED INDEX [IX_FbDauerauftrag_FbZahlungswegID] ON [dbo].[FbDauerauftrag] 
(
	[FbZahlungswegID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für FbDauerauftrag Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbDauerauftrag', @level2type=N'COLUMN',@level2name=N'FbDauerauftragID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_FbDauerauftrag_BaPerson) => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbDauerauftrag', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_FbDauerauftrag_FbZahlungsweg) => FbZahlungsweg.FbZahlungswegID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbDauerauftrag', @level2type=N'COLUMN',@level2name=N'FbZahlungswegID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Periodizität -  LOV FbBarauszahlungPeriodizitaet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbDauerauftrag', @level2type=N'COLUMN',@level2name=N'PeriodizitaetCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code für den Wochentag - LOV WochentagCode' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbDauerauftrag', @level2type=N'COLUMN',@level2name=N'WochentagCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob Zahlung ggf vor dem Wochenende ausgeführt werden soll' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbDauerauftrag', @level2type=N'COLUMN',@level2name=N'VorWochenende'
GO

ALTER TABLE [dbo].[FbDauerauftrag]  WITH CHECK ADD  CONSTRAINT [FK_FbDauerauftrag_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[FbDauerauftrag] CHECK CONSTRAINT [FK_FbDauerauftrag_BaPerson]
GO

ALTER TABLE [dbo].[FbDauerauftrag]  WITH NOCHECK ADD  CONSTRAINT [FK_FbDauerauftrag_FbZahlungsweg] FOREIGN KEY([FbZahlungswegID])
REFERENCES [dbo].[FbZahlungsweg] ([FbZahlungswegID])
GO

ALTER TABLE [dbo].[FbDauerauftrag] CHECK CONSTRAINT [FK_FbDauerauftrag_FbZahlungsweg]
GO

ALTER TABLE [dbo].[FbDauerauftrag] ADD  CONSTRAINT [DF_FbDauerauftrag_VorWochenende]  DEFAULT ((0)) FOR [VorWochenende]
GO

ALTER TABLE [dbo].[FbDauerauftrag] ADD  CONSTRAINT [DF_FbDauerauftrag_Status]  DEFAULT ((1)) FOR [Status]
GO


