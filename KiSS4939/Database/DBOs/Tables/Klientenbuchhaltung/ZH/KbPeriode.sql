CREATE TABLE [dbo].[KbPeriode](
	[KbPeriodeID] [int] IDENTITY(1,1) NOT NULL,
	[KbMandantCode] [int] NOT NULL,
	[PeriodeVon] [datetime] NOT NULL,
	[PeriodeBis] [datetime] NOT NULL,
	[PeriodeStatusCode] [int] NOT NULL,
	[KbPeriodeTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KbPeriode] PRIMARY KEY CLUSTERED 
(
	[KbPeriodeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
