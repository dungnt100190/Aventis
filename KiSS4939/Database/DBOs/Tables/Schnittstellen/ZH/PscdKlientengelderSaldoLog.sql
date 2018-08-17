CREATE TABLE [dbo].[PscdKlientengelderSaldoLog](
	[PscdKlientengelderSaldoLogID] [int] IDENTITY(1,1) NOT NULL,
	[ABSND] [varchar](50) NULL,
	[AZDAT] [varchar](50) NULL,
	[AZIDT] [varchar](50) NULL,
	[EDATE] [varchar](50) NULL,
	[ESBTR] [money] NULL,
	[ESBTRSpecified] [bit] NULL,
	[ESTYP] [varchar](50) NULL,
	[ESVOZ] [varchar](50) NULL,
	[ETIME] [varchar](50) NULL,
	[EUSER] [varchar](50) NULL,
	[KUKEY] [varchar](50) NULL,
	[MANDT] [varchar](50) NULL,
	[SIBAN] [varchar](50) NULL,
	[SSBTR] [money] NULL,
	[SSBTRSpecified] [bit] NULL,
	[SSTYP] [varchar](50) NULL,
	[SSVOZ] [varchar](50) NULL,
	[STATUS] [varchar](50) NULL,
	[SUMHA] [money] NULL,
	[SUMHASpecified] [bit] NULL,
	[SUMSO] [money] NULL,
	[SUMSOSpecified] [bit] NULL,
	[WAERS] [varchar](50) NULL,
	[BaPersonID] [int] NULL,
	[Verarbeitet] [bit] NOT NULL CONSTRAINT [DF_PscdKlientengelderSaldoLog_Verarbeitet]  DEFAULT ((0)),
	[ErstelltDatum] [datetime] NOT NULL CONSTRAINT [DF_PscdKlientengelderSaldoLog_ErstelltDatum]  DEFAULT (getdate()),
 CONSTRAINT [PK_PscdKlientengelderSaldoLog] PRIMARY KEY CLUSTERED 
(
	[PscdKlientengelderSaldoLogID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON