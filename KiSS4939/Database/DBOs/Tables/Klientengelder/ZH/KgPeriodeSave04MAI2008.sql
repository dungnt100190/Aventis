CREATE TABLE [dbo].[KgPeriodeSave04MAI2008](
	[KgPeriodeID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[PeriodeVon] [datetime] NOT NULL,
	[PeriodeBis] [datetime] NOT NULL,
	[AbgeschlossenBis] [datetime] NULL,
	[KgPeriodeStatusCode] [int] NOT NULL,
	[BaZahlungswegID] [int] NULL,
	[Vermittlungsfall] [bit] NOT NULL,
	[KgPeriodeTS] [timestamp] NOT NULL
) ON [PRIMARY]
