CREATE TABLE [dbo].[FbKonto](
	[FbKontoID] [int] IDENTITY(1,1) NOT NULL,
	[FbPeriodeID] [int] NULL,
	[KontoKlasseCode] [int] NOT NULL,
	[KontoTypCode] [int] NOT NULL,
	[KontoNr] [int] NOT NULL,
	[KontoName] [varchar](100) NOT NULL,
	[EroeffnungsSaldo] [money] NOT NULL,
	[SaldoGruppeName] [varchar](20) NULL,
	[FbDTAZugangID] [int] NULL,
	[FbKontoTS] [timestamp] NOT NULL,
	[FbDepotNr] [varchar](20) NULL,
	[EroeffnungsSaldoModifier] [varchar](50) NULL,
	[EroeffnungsSaldoModified] [datetime] NULL,
	[EroeffnungsSaldoCreator] [varchar](50) NULL,
	[EroeffnungsSaldoCreated] [datetime] NULL,
	[EroeffnungsSaldo_AtCreation] [money] NULL,
 CONSTRAINT [PK_FbKonto] PRIMARY KEY CLUSTERED 
(
	[FbKontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_FbKonto_FbDTAZugangID] ON [dbo].[FbKonto] 
(
	[FbDTAZugangID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_FbKonto_FbPeriodeID] ON [dbo].[FbKonto] 
(
	[FbPeriodeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE UNIQUE NONCLUSTERED INDEX [IX_FbKonto_FbPeriodeIDKontoNr_Unique] ON [dbo].[FbKonto] 
(
	[FbPeriodeID] ASC,
	[KontoNr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für FbKonto Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbKonto', @level2type=N'COLUMN',@level2name=N'FbKontoID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_FbKonto_FbPeriode) => FbPeriode.FbPeriodeID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbKonto', @level2type=N'COLUMN',@level2name=N'FbPeriodeID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_FbKonto_FbDTAZugang) => FbDTAZugang.FbDTAZugangID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbKonto', @level2type=N'COLUMN',@level2name=N'FbDTAZugangID'
GO

ALTER TABLE [dbo].[FbKonto]  WITH CHECK ADD  CONSTRAINT [FK_FbKonto_FbDTAZugang] FOREIGN KEY([FbDTAZugangID])
REFERENCES [dbo].[FbDTAZugang] ([FbDTAZugangID])
GO

ALTER TABLE [dbo].[FbKonto] CHECK CONSTRAINT [FK_FbKonto_FbDTAZugang]
GO

ALTER TABLE [dbo].[FbKonto]  WITH CHECK ADD  CONSTRAINT [FK_FbKonto_FbPeriode] FOREIGN KEY([FbPeriodeID])
REFERENCES [dbo].[FbPeriode] ([FbPeriodeID])
GO

ALTER TABLE [dbo].[FbKonto] CHECK CONSTRAINT [FK_FbKonto_FbPeriode]
GO

ALTER TABLE [dbo].[FbKonto] ADD  CONSTRAINT [DF__FbKonto__Eroeffn__2FD17C8F]  DEFAULT (0) FOR [EroeffnungsSaldo]
GO