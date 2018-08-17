CREATE TABLE [dbo].[KaVermittlungEinsatz](
	[KaVermittlungEinsatzID] [int] IDENTITY(1,1) NOT NULL,
	[KaVermittlungVorschlagID] [int] NULL,
	[Lehrvertrag] [datetime] NULL,
	[EinsatzVon] [datetime] NULL,
	[EinsatzBis] [datetime] NULL,
	[Unbefristet] [bit] NULL,
	[Verlaengerung] [bit] NULL,
	[Arbeitspensum] [int] NULL,
	[ArbeitspensumErgaenzungen] [varchar](100) NULL,
	[Leistungsfaehigkeit] [int] NULL,
	[EinsatzVereinbarungDokID] [int] NULL,
	[EinsatzVereinbarungErhalten] [datetime] NULL,
	[EinsatzVereinbarungUnterschrieben] [bit] NULL,
	[EinsatzEinladungDokID] [int] NULL,
	[BIEAZDatumVon] [datetime] NULL,
	[BIEAZDatumBis] [datetime] NULL,
	[BIEAZVerlaengert] [bit] NULL,
	[BIEAZVereinbarungDokID] [int] NULL,
	[BIEAZVereinbarungUnterschrieben] [bit] NULL,
	[BIEAZBemerkung] [varchar](1000) NULL,
	[BIBruttolohn] [money] NULL,
	[BIFinanzierungsgradEAZ] [int] NULL,
	[BIBeteilungEAZ] [money] NULL,
	[BIPZwischenbericht1Datum] [datetime] NULL,
	[BIPZwischenbericht1Erhalten] [bit] NULL,
	[BIPZwischenbericht2Datum] [datetime] NULL,
	[BIPZwischenbericht2Erhalten] [bit] NULL,
	[InizioEinsatzAbbruchDurchCode] [int] NULL,
	[InizioEinsatzAbbruch] [datetime] NULL,
	[Abschluss] [datetime] NULL,
	[InizioAbschlussGrund] [varchar](100) NULL,
	[InizioLoesung] [varchar](100) NULL,
	[InizioAnschlussloesungCode] [int] NULL,
	[BIAbschlussGrundCode] [int] NULL,
	[BIPAbschlussGrundCode] [int] NULL,
	[BIBIPSIAbschlussDurchCode] [int] NULL,
	[SIAbschlussGrundCode] [int] NULL,
	[Attest] [int] NULL,
	[EinsatzBemerkungen] [varchar](1000) NULL,
	[KaVermittlungEinsatzTS] [timestamp] NOT NULL,
	[MigrationKA] [int] NULL,
 CONSTRAINT [PK_KaVermittlungEinsatz] PRIMARY KEY CLUSTERED 
(
	[KaVermittlungEinsatzID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_KaVermittlungEinsatz_KaVermittlungVorschlagID] ON [dbo].[KaVermittlungEinsatz] 
(
	[KaVermittlungVorschlagID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KaVermittlungEinsatz Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungEinsatz', @level2type=N'COLUMN',@level2name=N'KaVermittlungEinsatzID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaVermittlungEinsatz_KaVermittlungVorschlag) => KaVermittlungVorschlag.KaVermittlungVorschlagID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungEinsatz', @level2type=N'COLUMN',@level2name=N'KaVermittlungVorschlagID'
GO

ALTER TABLE [dbo].[KaVermittlungEinsatz]  WITH CHECK ADD  CONSTRAINT [FK_KaVermittlungEinsatz_KaVermittlungVorschlag] FOREIGN KEY([KaVermittlungVorschlagID])
REFERENCES [dbo].[KaVermittlungVorschlag] ([KaVermittlungVorschlagID])
GO

ALTER TABLE [dbo].[KaVermittlungEinsatz] CHECK CONSTRAINT [FK_KaVermittlungEinsatz_KaVermittlungVorschlag]
GO

ALTER TABLE [dbo].[KaVermittlungEinsatz] ADD  CONSTRAINT [DF_KaVermittlungEinsatz_Unbefristet]  DEFAULT ((0)) FOR [Unbefristet]
GO

ALTER TABLE [dbo].[KaVermittlungEinsatz] ADD  CONSTRAINT [DF_KaVermittlungEinsatz_Verlaengerung]  DEFAULT ((0)) FOR [Verlaengerung]
GO

ALTER TABLE [dbo].[KaVermittlungEinsatz] ADD  CONSTRAINT [DF_KaVermittlungEinsatz_EinsatzVereinbarungUnterschrieben]  DEFAULT ((0)) FOR [EinsatzVereinbarungUnterschrieben]
GO

ALTER TABLE [dbo].[KaVermittlungEinsatz] ADD  CONSTRAINT [DF_KaVermittlungEinsatz_BIEAZVerlaengert]  DEFAULT ((0)) FOR [BIEAZVerlaengert]
GO

ALTER TABLE [dbo].[KaVermittlungEinsatz] ADD  CONSTRAINT [DF_KaVermittlungEinsatz_BIEAZVereinbarungUnterschrieben]  DEFAULT ((0)) FOR [BIEAZVereinbarungUnterschrieben]
GO

ALTER TABLE [dbo].[KaVermittlungEinsatz] ADD  CONSTRAINT [DF_KaVermittlungEinsatz_BIPZwischenbericht1Erhalten]  DEFAULT ((0)) FOR [BIPZwischenbericht1Erhalten]
GO

ALTER TABLE [dbo].[KaVermittlungEinsatz] ADD  CONSTRAINT [DF_KaVermittlungEinsatz_BIPZwischenbericht2Erhalten]  DEFAULT ((0)) FOR [BIPZwischenbericht2Erhalten]
GO

ALTER TABLE [dbo].[KaVermittlungEinsatz] ADD  CONSTRAINT [DF_KaVermittlungEinsatz_MigrationKA]  DEFAULT ((0)) FOR [MigrationKA]
GO