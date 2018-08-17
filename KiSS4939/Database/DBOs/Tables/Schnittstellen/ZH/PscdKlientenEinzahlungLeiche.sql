CREATE TABLE [dbo].[PscdKlientenEinzahlungLeiche](
	[PscdKlientenEinzahlungLeicheID] [int] IDENTITY(1,1) NOT NULL,
	[MANDT] [varchar](3) NULL,
	[ABSND] [varchar](50) NULL,
	[AZIDT] [varchar](20) NULL,
	[ESNUM] [varchar](5) NULL,
	[EPERL] [varchar](1) NULL,
	[BVDAT] [varchar](8) NULL,
	[BUDAT] [varchar](8) NULL,
	[VALUT] [varchar](8) NULL,
	[KWAER] [varchar](5) NULL,
	[KWBTR] [money] NULL,
	[SPESK] [money] NULL,
	[VORGC] [varchar](3) NULL,
	[VGEXT] [varchar](27) NULL,
	[VWEZW1] [varchar](65) NULL,
	[VWEZW2] [varchar](65) NULL,
	[VWEZW3] [varchar](65) NULL,
	[VWEZW4] [varchar](65) NULL,
	[VWEZW5] [varchar](65) NULL,
	[VWEZW6] [varchar](65) NULL,
	[VWEZW7] [varchar](65) NULL,
	[VWEZW8] [varchar](65) NULL,
	[STATUS] [varchar](2) NULL,
	[ErstelltDatum] [datetime] NOT NULL CONSTRAINT [DF_PscdKlientenEinzahlungLeiche_ErstelltDatum]  DEFAULT (getdate()),
 CONSTRAINT [PK_PscdKlientenEinzahlungLeiche] PRIMARY KEY CLUSTERED 
(
	[PscdKlientenEinzahlungLeicheID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON