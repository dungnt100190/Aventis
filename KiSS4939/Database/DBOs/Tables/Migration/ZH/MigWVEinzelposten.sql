CREATE TABLE [dbo].[MigWVEinzelposten](
	[MigWVEinzelpostenID] [int] IDENTITY(1,1) NOT NULL,
	[Laufnummer] [int] NULL,
	[FallProleist] [int] NULL,
	[PersonProleist] [int] NULL,
	[UnterTraegerProleist] [int] NULL,
	[ExpDB_Person] [int] NULL,
	[BelegNrProleist] [int] NOT NULL,
	[Betrag] [money] NOT NULL,
	[LANrProleist] [int] NULL,
	[LATextProleist] [varchar](255) NULL,
	[VonDatum] [datetime] NOT NULL,
	[BisDatum] [datetime] NOT NULL,
	[WV_Code] [varchar](255) NOT NULL,
	[BED] [int] NOT NULL,
	[Status_WVEP] [varchar](255) NOT NULL,
	[WVFakturaID] [int] NOT NULL,
	[WVSJ_ID] [int] NOT NULL,
	[WVFJ_ID] [int] NOT NULL,
	[WVUSPID] [int] NOT NULL,
	[WVEPID] [int] NOT NULL,
	[FakturalaufDatum] [datetime] NOT NULL,
	[FakturaPeriodeVon] [datetime] NOT NULL,
	[FakturaPeriodeBis] [datetime] NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[Hauptvorgang] [int] NOT NULL,
	[Teilvorgang] [int] NOT NULL,
	[PscdBelegNr] [bigint] NOT NULL,
	[KbWVEinzelpostenStatusCode] [int] NOT NULL,
	[BaPersonID_falsch] [int] NOT NULL,
	[KbWVEinzelpostenID] [int] NULL,
 CONSTRAINT [PK_MigWVEinzelposten] PRIMARY KEY CLUSTERED 
(
	[MigWVEinzelpostenID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[MigWVEinzelposten]  WITH CHECK ADD  CONSTRAINT [FK_MigWVEinzelposten_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[MigWVEinzelposten] CHECK CONSTRAINT [FK_MigWVEinzelposten_BaPerson]