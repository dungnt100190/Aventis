CREATE TABLE [dbo].[OLD_30_FlTypZahlungslauf](
	[FlTypZahlungslaufID] [int] NOT NULL,
	[NameFbTypeZahlungslauf] [varchar](50) NOT NULL,
	[FlTypeVerfuegungCode] [int] NULL,
	[ScanByDvGeneric] [bit] NOT NULL CONSTRAINT [DF_tcoKissFbTypeZahlungslauf_ScanDvGeneric]  DEFAULT (0),
	[ScanByAiVerfuegung] [bit] NOT NULL CONSTRAINT [DF_tcoKissFbTypeZahlungslauf_ScanAlimenteBevorschusssung]  DEFAULT (0),
	[ScanByMxAdmin] [bit] NOT NULL CONSTRAINT [DF_tcoKissFbTypeZahlungslauf_ScanAdminSozialhilfe]  DEFAULT (0),
	[ScanByMxStandard] [bit] NOT NULL CONSTRAINT [DF_tcoKissFbTypeZahlungslauf_ScanStandardSozialhilfe]  DEFAULT (0),
	[FlTypZahlungslaufTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FlTypZahlungslauf] PRIMARY KEY CLUSTERED 
(
	[FlTypZahlungslaufID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO