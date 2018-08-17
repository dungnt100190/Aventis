CREATE TABLE [dbo].[KgSparhafenSaldo](
	[KgSparhafenSaldoID] [int] IDENTITY(1,1) NOT NULL,
	[NameVorname] [varchar](250) NOT NULL,
	[KontoNr] [varchar](9) NOT NULL,
	[Saldo] [money] NOT NULL,
	[Rubrik] [int] NOT NULL,
	[Kategorie] [int] NOT NULL,
	[KgSparhafenSaldoImportID] [int] NOT NULL,
	[BaPersonID] [int] NULL,
	[KissKontoNr] [varchar](10) NULL,
	[manuelleZuordnung] [bit] NOT NULL,
	[KgSparhafenSaldoTS] [timestamp] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[KgSparhafenSaldoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_KgSparhafenSaldo_KgSparhafenSaldoImportID]    Script Date: 03/22/2012 10:29:09 ******/
CREATE NONCLUSTERED INDEX [IX_KgSparhafenSaldo_KgSparhafenSaldoImportID] ON [dbo].[KgSparhafenSaldo] 
(
	[KgSparhafenSaldoImportID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_KgSparhafenSaldo_BaPersonID]    Script Date: 03/22/2012 10:29:09 ******/
CREATE NONCLUSTERED INDEX [IX_KgSparhafenSaldo_BaPersonID] ON [dbo].[KgSparhafenSaldo] 
(
	[NameVorname] ASC,
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [DATEN1]
GO

ALTER TABLE [dbo].[KgSparhafenSaldo]  WITH CHECK ADD  CONSTRAINT [FK_KgSparhafenSaldo_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[KgSparhafenSaldo] CHECK CONSTRAINT [FK_KgSparhafenSaldo_BaPerson]
GO

ALTER TABLE [dbo].[KgSparhafenSaldo]  WITH CHECK ADD  CONSTRAINT [FK_KgSparhafenSaldo_KgSparhafenSaldoImportID] FOREIGN KEY([KgSparhafenSaldoImportID])
REFERENCES [dbo].[KgSparhafenSaldoImport] ([KgSparhafenSaldoImportID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[KgSparhafenSaldo] CHECK CONSTRAINT [FK_KgSparhafenSaldo_KgSparhafenSaldoImportID]
GO

