CREATE TABLE [dbo].[SstMT940Saldo](
	[SstMT940SaldoID] [int] IDENTITY(1,1) NOT NULL,
	[Kontonummer] [varchar](50) NULL,
	[BaPersonID] [int] NULL,
	[Stichtag] [datetime] NULL,
	[Saldo] [money] NOT NULL,
	[Endsaldo] [money] NOT NULL,
	[PscdKontoauszugID] [varchar](50) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[SstMt940SaldoTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_SstMT940Saldo] PRIMARY KEY CLUSTERED 
(
	[SstMT940SaldoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_SstMT940Saldo_BaPersonID_Stichtag]    Script Date: 05/06/2015 17:18:02 ******/
CREATE NONCLUSTERED INDEX [IX_SstMT940Saldo_BaPersonID_Stichtag] ON [dbo].[SstMT940Saldo] 
(
	[BaPersonID] ASC,
	[Stichtag] ASC
)
INCLUDE ( [Saldo]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO


/****** Object:  Index [IX_SstMT940Saldo_Kontonummer_Stichtag]    Script Date: 05/06/2015 17:18:02 ******/
CREATE NONCLUSTERED INDEX [IX_SstMT940Saldo_Kontonummer_Stichtag] ON [dbo].[SstMT940Saldo] 
(
	[Kontonummer] ASC,
	[Stichtag] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID des PSCD-Kontoauszugs (PscdKlientengelderSaldoLog.AZIDT bzw. KgZahlungseingang.PscdKontoauszug)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstMT940Saldo', @level2type=N'COLUMN',@level2name=N'PscdKontoauszugID'
GO

ALTER TABLE [dbo].[SstMT940Saldo]  WITH CHECK ADD  CONSTRAINT [FK_SstMT940Saldo_BaPersonID] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[SstMT940Saldo] CHECK CONSTRAINT [FK_SstMT940Saldo_BaPersonID]
GO

ALTER TABLE [dbo].[SstMT940Saldo] ADD  CONSTRAINT [DF_SstMT940Saldo_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[SstMT940Saldo] ADD  CONSTRAINT [DF_SstMT940Saldo_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

