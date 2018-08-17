CREATE TABLE [dbo].[PscdAusgleich](
	[PscdAusgleichID] [int] IDENTITY(1,1) NOT NULL,
	[AUGBL] [varchar](50) NULL,
	[AUGBT] [money] NULL,
	[AUGDT] [varchar](50) NULL,
	[AUGRD] [varchar](50) NULL,
	[EZDAT] [varchar](50) NULL,
	[OPBEL] [varchar](50) NULL,
	[VTREF] [varchar](50) NULL,
	[GPART] [varchar](50) NULL,
	[KEYZ1] [varchar](50) NULL,
	[OPUPK] [varchar](50) NULL,
	[OPUPW] [varchar](50) NULL,
	[OPUPZ] [varchar](50) NULL,
	[POSZA] [varchar](50) NULL,
	[WVSTAT] [varchar](50) NULL,
	[ErstelltDatum] [datetime] NOT NULL,
	[Verarbeitet] [bit] NOT NULL,
	[Fehlermeldung] [varchar](300) NULL,
 CONSTRAINT [PK_PscdAusgleich] PRIMARY KEY CLUSTERED 
(
	[PscdAusgleichID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_PscdAusgleich_All] ON [dbo].[PscdAusgleich] 
(
	[AUGBL] ASC,
	[OPBEL] ASC,
	[AUGBT] ASC,
	[AUGRD] ASC,
	[AUGDT] ASC,
	[Verarbeitet] ASC
)
INCLUDE ( [EZDAT],
[VTREF],
[GPART],
[KEYZ1],
[OPUPK],
[OPUPW],
[OPUPZ],
[POSZA],
[WVSTAT]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO

CREATE NONCLUSTERED INDEX [IX_PscdAusgleich_AUGBT_Verarbeitet] ON [dbo].[PscdAusgleich] 
(
	[AUGBT] ASC,
	[Verarbeitet] ASC
)
INCLUDE ( [AUGBL],
[AUGRD],
[OPBEL],
[VTREF],
[GPART],
[OPUPK],
[OPUPW],
[OPUPZ]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

CREATE NONCLUSTERED INDEX [IX_PscdAusgleich_OPBEL] ON [dbo].[PscdAusgleich] 
(
	[OPBEL] ASC
)
INCLUDE ( [ErstelltDatum]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'AusgleichBelegNr' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PscdAusgleich', @level2type=N'COLUMN',@level2name=N'AUGBL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'AusgleichBetrag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PscdAusgleich', @level2type=N'COLUMN',@level2name=N'AUGBT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'AusgleichsGrund' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PscdAusgleich', @level2type=N'COLUMN',@level2name=N'AUGRD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'OPBelegNr' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PscdAusgleich', @level2type=N'COLUMN',@level2name=N'OPBEL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PSCD-VertragsgegenstandID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PscdAusgleich', @level2type=N'COLUMN',@level2name=N'VTREF'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PscdGeschaeftspartnerID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PscdAusgleich', @level2type=N'COLUMN',@level2name=N'GPART'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PosInOPBeleg' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PscdAusgleich', @level2type=N'COLUMN',@level2name=N'OPUPK'
GO

ALTER TABLE [dbo].[PscdAusgleich] ADD  CONSTRAINT [DF_PscdAusgleich_ErstelltDatum]  DEFAULT (getdate()) FOR [ErstelltDatum]
GO

ALTER TABLE [dbo].[PscdAusgleich] ADD  CONSTRAINT [DF_PscdAusgleich_Verarbeitet]  DEFAULT ((0)) FOR [Verarbeitet]
GO