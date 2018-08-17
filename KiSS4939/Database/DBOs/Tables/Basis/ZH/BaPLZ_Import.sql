CREATE TABLE [dbo].[BaPLZ_Import](
	[ONRP] [int] NOT NULL,
	[Typ] [int] NOT NULL,
	[PLZ] [int] NOT NULL,
	[Zusatz] [int] NOT NULL,
	[Ort18] [varchar](18) NOT NULL,
	[Ort27] [varchar](27) NOT NULL,
	[Kanton] [varchar](2) NOT NULL,
	[Sprachcode] [int] NOT NULL,
	[Sprachcode_aw] [int] NULL,
	[zugehörigkeit] [int] NOT NULL,
	[Zustellung] [int] NULL,
	[GemeindeBFS] [int] NOT NULL,
	[gueltig] [datetime] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING ON