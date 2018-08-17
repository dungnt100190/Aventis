CREATE TABLE [dbo].[MigBuchhaltung](
	[Laufnummer] [decimal](9, 0) NOT NULL,
	[HerkunftCode] [decimal](4, 0) NULL,
	[HerkunftText] [nvarchar](50) NULL,
	[BuchungsJahr] [decimal](4, 0) NULL,
	[ImpKontoId] [nvarchar](50) NULL,
	[ImpUmsatzSoll] [decimal](15, 2) NULL,
	[ImpUmsatzHaben] [decimal](15, 2) NULL,
	[ImpSaldo] [decimal](15, 2) NULL,
	[ExpKontoId] [nvarchar](50) NULL,
	[ExpUmsatzSoll] [decimal](15, 2) NULL,
	[ExpUmsatzHaben] [decimal](15, 2) NULL,
	[ExpSaldo] [decimal](15, 2) NULL,
	[DiffSaldoImpExp] [decimal](15, 2) NULL,
	[KissKontoId] [nvarchar](50) NULL,
	[KissUmsatzSoll] [decimal](15, 2) NULL,
	[KissUmsatzHaben] [decimal](15, 2) NULL,
	[KissSaldo] [decimal](15, 2) NULL,
	[DiffSaldoExpKiss] [decimal](15, 2) NULL,
	[DiffSaldoExpKissErklaerbar] [decimal](15, 2) NULL,
	[DiffSaldoExpKissNichtErklaerbar] [decimal](15, 2) NULL,
	[lMigBuchhaltung] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_MigBuchhaltung] PRIMARY KEY CLUSTERED 
(
	[Laufnummer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [ARCHIV]
) ON [ARCHIV]
