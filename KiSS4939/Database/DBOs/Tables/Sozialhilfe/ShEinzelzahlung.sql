-- Tabelle wird vermutlich nur noch aufgrund von Altdaten verwendet!
CREATE TABLE [dbo].[ShEinzelzahlung](
	[ShEinzelzahlungID] [int] IDENTITY(1,1) NOT NULL,
	[BgBudgetID] [int] NOT NULL,
	[BaPersonID] [int] NULL,
	[ShBelegID] [int] NOT NULL,
	[FlKostenartID] [int] NULL,
	[BgSpezkontoID] [int] NULL,
	[BgPositionsartID] [int] NULL,
	[RechnungDatum] [datetime] NULL,
	[NameEinzelzahlung] [varchar](100) NULL,
	[Betrag] [money] NOT NULL,
	[BetragAnfrage] [money] NULL,
	[ShStatusEinzelzahlungCode] [int] NOT NULL,
	[Value1] [sql_variant] NULL,
	[Value2] [sql_variant] NULL,
	[Value3] [sql_variant] NULL,
	[Bemerkung] [text] NULL,
	[ShEinzelzahlungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_ShEinzelzahlung] PRIMARY KEY NONCLUSTERED 
(
	[ShEinzelzahlungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [DATEN1] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE CLUSTERED INDEX [IX_ShEinzelzahlung] ON [dbo].[ShEinzelzahlung] 
(
	[BgBudgetID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


CREATE NONCLUSTERED INDEX [IX_ShEinzelzahlung_ShSpezkontoID] ON [dbo].[ShEinzelzahlung] 
(
	[BgSpezkontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für ShEinzelzahlung Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ShEinzelzahlung', @level2type=N'COLUMN',@level2name=N'ShEinzelzahlungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_ShEinzelzahlung_ShBeleg) => ShBeleg.BgBudgetID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ShEinzelzahlung', @level2type=N'COLUMN',@level2name=N'BgBudgetID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_ShEinzelzahlung_BaPerson) => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ShEinzelzahlung', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_ShEinzelzahlung_ShBeleg) => ShBeleg.ShBelegID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ShEinzelzahlung', @level2type=N'COLUMN',@level2name=N'ShBelegID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_ShEinzelzahlung_BgKostenart) => BgKostenart.BgKostenartID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ShEinzelzahlung', @level2type=N'COLUMN',@level2name=N'FlKostenartID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_ShEinzelzahlung_BgSpezkonto) => BgSpezkonto.BgSpezkontoID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ShEinzelzahlung', @level2type=N'COLUMN',@level2name=N'BgSpezkontoID'
GO

ALTER TABLE [dbo].[ShEinzelzahlung]  WITH CHECK ADD  CONSTRAINT [FK_ShEinzelzahlung_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[ShEinzelzahlung] CHECK CONSTRAINT [FK_ShEinzelzahlung_BaPerson]
GO

ALTER TABLE [dbo].[ShEinzelzahlung]  WITH CHECK ADD  CONSTRAINT [FK_ShEinzelzahlung_BgBudget] FOREIGN KEY([BgBudgetID])
REFERENCES [dbo].[BgBudget] ([BgBudgetID])
GO

ALTER TABLE [dbo].[ShEinzelzahlung] CHECK CONSTRAINT [FK_ShEinzelzahlung_BgBudget]
GO

ALTER TABLE [dbo].[ShEinzelzahlung]  WITH CHECK ADD  CONSTRAINT [FK_ShEinzelzahlung_BgPositionsart] FOREIGN KEY([BgPositionsartID])
REFERENCES [dbo].[BgPositionsart] ([BgPositionsartID])
GO

ALTER TABLE [dbo].[ShEinzelzahlung] CHECK CONSTRAINT [FK_ShEinzelzahlung_BgPositionsart]
GO

ALTER TABLE [dbo].[ShEinzelzahlung]  WITH CHECK ADD  CONSTRAINT [FK_ShEinzelzahlung_BgSpezkonto] FOREIGN KEY([BgSpezkontoID])
REFERENCES [dbo].[BgSpezkonto] ([BgSpezkontoID])
GO

ALTER TABLE [dbo].[ShEinzelzahlung] CHECK CONSTRAINT [FK_ShEinzelzahlung_BgSpezkonto]
GO

ALTER TABLE [dbo].[ShEinzelzahlung] ADD  CONSTRAINT [DF_ShEinzelzahlung_Betrag]  DEFAULT ((0)) FOR [Betrag]
GO

ALTER TABLE [dbo].[ShEinzelzahlung] ADD  CONSTRAINT [DF_ShEinzelzahlung_ShStatusEinzelzahlungCode]  DEFAULT ((0)) FOR [ShStatusEinzelzahlungCode]
GO